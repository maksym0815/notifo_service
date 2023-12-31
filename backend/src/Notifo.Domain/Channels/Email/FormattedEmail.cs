﻿// ==========================================================================
//  Notifo.io
// ==========================================================================
//  Copyright (c) Sebastian Stehle
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

#pragma warning disable SA1313 // Parameter names should begin with lower-case letter

using Notifo.Domain.Integrations;

namespace Notifo.Domain.Channels.Email;

public readonly record struct FormattedEmail(EmailMessage? Message, List<EmailFormattingError>? Errors);
