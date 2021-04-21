﻿// ==========================================================================
//  Notifo.io
// ==========================================================================
//  Copyright (c) Sebastian Stehle
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using System.ComponentModel.DataAnnotations;
using Notifo.Domain.Channels.MobilePush;
using Notifo.Infrastructure.Reflection;

namespace Notifo.Areas.Api.Controllers.MobilePush.Dtos
{
    public sealed class MobilePushTokenDto
    {
        /// <summary>
        /// The device token.
        /// </summary>
        [Required]
        public string Token { get; set; }

        /// <summary>
        /// The device type.
        /// </summary>
        public MobileDeviceType DeviceType { get; set; }

        public static MobilePushTokenDto FromToken(MobilePushToken token)
        {
            return SimpleMapper.Map(token, new MobilePushTokenDto());
        }
    }
}
