﻿// ==========================================================================
//  Notifo.io
// ==========================================================================
//  Copyright (c) Sebastian Stehle
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Notifo.Domain.Utils;
using Notifo.Infrastructure.Collections;
using Notifo.Infrastructure.Validation;

namespace Notifo.Domain.Users;

public sealed class UpsertUser : UserCommand
{
    public string? FullName { get; set; }

    public string? EmailAddress { get; set; }

    public string? PhoneNumber { get; set; }

    public string? PreferredLanguage { get; set; }

    public string? PreferredTimezone { get; set; }

    public bool? RequiresWhitelistedTopics { get; set; }

    public ReadonlyDictionary<string, string>? Properties { get; set; }

    public ChannelSettings? Settings { get; set; }

    public Scheduling? Scheduling { get; set; }

    public bool HasScheduling { get; set; }

    public bool MergeSettings { get; set; }

    public override bool CanCreate => true;

    private sealed class Validator : AbstractValidator<UpsertUser>
    {
        public Validator()
        {
            RuleFor(x => x.EmailAddress).EmailAddress().Unless(x => string.IsNullOrWhiteSpace(x.EmailAddress));
            RuleFor(x => x.PreferredLanguage).Language();
            RuleFor(x => x.PreferredTimezone).Timezone();
            RuleFor(x => x.PhoneNumber).PhoneNumber();
        }
    }

    public override async ValueTask<User?> ExecuteAsync(User target, IServiceProvider serviceProvider,
        CancellationToken ct)
    {
        Validate<Validator>.It(this);

        var newUser = target;

        if (Is.Changed(FullName, target.FullName))
        {
            newUser = newUser with
            {
                FullName = FullName.Trim()
            };
        }

        if (Is.Changed(EmailAddress, target.EmailAddress))
        {
            newUser = newUser with
            {
                EmailAddress = EmailAddress.Trim().ToLowerInvariant()
            };
        }

        if (Is.Changed(PhoneNumber, target.PhoneNumber))
        {
            newUser = newUser with
            {
                PhoneNumber = PhoneNumber.Trim().ToLowerInvariant()
            };
        }

        if (Is.Changed(Properties, target.Properties))
        {
            newUser = newUser with
            {
                Properties = Properties
            };
        }

        if (Is.Changed(PreferredLanguage, target.PreferredLanguage))
        {
            newUser = newUser with
            {
                PreferredLanguage = PreferredLanguage.Trim()
            };
        }

        if (Is.Changed(PreferredTimezone, target.PreferredTimezone))
        {
            newUser = newUser with
            {
                PreferredTimezone = PreferredTimezone.Trim()
            };
        }

        if (Is.Changed(RequiresWhitelistedTopics, target.RequiresWhitelistedTopics))
        {
            newUser = newUser with
            {
                RequiresWhitelistedTopics = RequiresWhitelistedTopics.Value
            };
        }

        if (HasScheduling && Is.Changed(Scheduling, target.Scheduling))
        {
            newUser = newUser with
            {
                Scheduling = Scheduling
            };
        }

        if (Settings != null)
        {
            var newSettings = Settings;

            if (MergeSettings)
            {
                newSettings = ChannelSettings.Merged(target.Settings, Settings);
            }

            newUser = newUser with
            {
                Settings = newSettings
            };
        }

        if (string.IsNullOrWhiteSpace(target.ApiKey))
        {
            var tokenGenerator = serviceProvider.GetRequiredService<IApiKeyGenerator>();

            newUser = newUser with
            {
                ApiKey = await tokenGenerator.GenerateUserTokenAsync(target.AppId, target.Id)
            };
        }

        return newUser;
    }
}
