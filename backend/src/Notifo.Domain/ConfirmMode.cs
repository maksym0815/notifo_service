﻿// ==========================================================================
//  Notifo.io
// ==========================================================================
//  Copyright (c) Sebastian Stehle
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using System;

namespace Notifo.Domain
{
    public enum ConfirmMode
    {
        None,
        [Obsolete]
        Seen,
        Explicit
    }
}
