﻿// ==========================================================================
//  Notifo.io
// ==========================================================================
//  Copyright (c) Sebastian Stehle
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using System.Reflection;
using NJsonSchema;
using NJsonSchema.Generation;

namespace Notifo.Areas.Api.OpenApi;

public sealed class RequiredSchemaProcessor : ISchemaProcessor
{
    public void Process(SchemaProcessorContext context)
    {
        if (context.Type.GetCustomAttribute<OpenApiRequestAttribute>() != null)
        {
            return;
        }

        foreach (var property in context.Schema.Properties.Values)
        {
            if (!property.IsNullable(SchemaType.OpenApi3))
            {
                property.IsRequired = true;
            }
        }
    }
}
