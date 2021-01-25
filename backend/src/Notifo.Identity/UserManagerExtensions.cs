﻿// ==========================================================================
//  Notifo.io
// ==========================================================================
//  Copyright (c) Sebastian Stehle
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Notifo.Domain.Identity;
using Notifo.Infrastructure.Validation;
using Squidex.Log;

namespace Notifo.Identity
{
    internal static class UserManagerExtensions
    {
        public static async Task Throw(this Task<IdentityResult> task, ISemanticLog log)
        {
            var result = await task;

            if (!result.Succeeded)
            {
                var errorMessageBuilder = new StringBuilder();

                foreach (var error in result.Errors)
                {
                    errorMessageBuilder.Append(error.Code);
                    errorMessageBuilder.Append(": ");
                    errorMessageBuilder.AppendLine(error.Description);
                }

                var errorMessage = errorMessageBuilder.ToString();

                log.LogError(errorMessage, (ctx, w) => w
                    .WriteProperty("action", "IdentityOperation")
                    .WriteProperty("status", "Failed")
                    .WriteProperty("message", ctx));

                throw new ValidationException(result.Errors.Select(x => new ValidationError(x.Description)).ToList());
            }
        }

        public static async Task<IdentityResult> SyncClaims(this UserManager<IdentityUser> userManager, IdentityUser user, UserValues values)
        {
            var current = await userManager.GetClaimsAsync(user);

            var claimsToRemove = new List<Claim>();
            var claimsToAdd = new List<Claim>();

            void RemoveClaims(Func<Claim, bool> predicate)
            {
                claimsToAdd.RemoveAll(x => predicate(x));
                claimsToRemove.AddRange(current.Where(predicate));
            }

            void AddClaim(string type, string value)
            {
                claimsToAdd.Add(new Claim(type, value));
            }

            void SyncBoolean(string type, bool? value)
            {
                if (value != null)
                {
                    RemoveClaims(x => x.Type == type);

                    if (value == true)
                    {
                        AddClaim(type, value.ToString()!);
                    }
                }
            }

            SyncBoolean(NotifoClaimTypes.Consent, values.Consent);
            SyncBoolean(NotifoClaimTypes.ConsentForEmails, values.ConsentForEmails);
            SyncBoolean(NotifoClaimTypes.Invited, values.Invited);

            if (claimsToRemove.Count > 0)
            {
                var result = await userManager.RemoveClaimsAsync(user, claimsToRemove);

                if (!result.Succeeded)
                {
                    return result;
                }
            }

            if (claimsToAdd.Count > 0)
            {
                return await userManager.AddClaimsAsync(user, claimsToAdd);
            }

            return IdentityResult.Success;
        }
    }
}
