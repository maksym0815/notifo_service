﻿// ==========================================================================
//  Notifo.io
// ==========================================================================
//  Copyright (c) Sebastian Stehle
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Notifo.Infrastructure;
using Notifo.Infrastructure.Collections;

namespace Notifo.Domain.Users
{
    public sealed class RemoveUserAllowedTopic : ICommand<User>
    {
        public TopicId Prefix { get; set; }

        public ValueTask<User?> ExecuteAsync(User user, IServiceProvider serviceProvider,
            CancellationToken ct)
        {
            if (!user.AllowedTopics.Contains(Prefix))
            {
                return default;
            }

            var newUser = user with
            {
                AllowedTopics = user.AllowedTopics.Where(x => x != Prefix).ToImmutableList()
            };

            return new ValueTask<User?>(newUser);
        }
    }
}
