﻿// ==========================================================================
//  Notifo.io
// ==========================================================================
//  Copyright (c) Sebastian Stehle
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using Notifo.Domain.Integrations;

namespace Notifo.Domain.Channels.MobilePush;

public readonly struct MobilePushOptions
{
    public string DeviceToken { get; init; }

    public string? DeviceIdentifier { get; init; }

    public MobileDeviceType DeviceType { get; init; }

    public bool IsConfirmed { get; init; }

    public bool Wakeup { get; init; }

    public Guid ConfigurationId { get; init; }
}
