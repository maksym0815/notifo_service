﻿// ==========================================================================
//  Notifo.io
// ==========================================================================
//  Copyright (c) Sebastian Stehle
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using Namotion.Reflection;
using NJsonSchema;
using NSwag;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;

namespace Notifo.Areas.Api.OpenApi;

public sealed class ErrorDtoProcessor : IDocumentProcessor
{
    public void Process(DocumentProcessorContext context)
    {
        var errorSchema = GetErrorSchema(context);

        foreach (var operation in context.Document.Paths.Values.SelectMany(x => x.Values))
        {
            AddErrorResponses(operation, errorSchema);
        }
    }

    private static void AddErrorResponses(OpenApiOperation operation, JsonSchema errorSchema)
    {
        operation.Responses.Add("500", new OpenApiResponse
        {
            Description = "Operation failed"
        });

        if (!operation.Responses.ContainsKey("400"))
        {
            operation.Responses.Add("400", new OpenApiResponse
            {
                Description = "Validation error"
            });
        }

        foreach (var (code, response) in operation.Responses)
        {
            if (response.Schema == null)
            {
                if (!code.StartsWith("2", StringComparison.OrdinalIgnoreCase) && code != "404")
                {
                    response.Schema = errorSchema;
                }
            }
        }
    }

    private static JsonSchema GetErrorSchema(DocumentProcessorContext context)
    {
        var errorType = typeof(ErrorDto).ToContextualType();

        return context.SchemaGenerator.GenerateWithReference<JsonSchema>(errorType, context.SchemaResolver);
    }
}
