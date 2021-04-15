﻿// ==========================================================================
//  Notifo.io
// ==========================================================================
//  Copyright (c) Sebastian Stehle
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Notifo.Domain.UserNotifications.MongoDb
{
    internal sealed class Base64Serializer : SerializerBase<string>
    {
        public override string Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var read = context.Reader.ReadString();

            return read.FromBase64();
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, string value)
        {
            var writer = context.Writer;

            writer.WriteString(value.ToBase64());
        }
    }
}
