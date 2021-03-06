﻿using System;

namespace Microsoft.Azure.AzConfig.Runtime.Json
{
    public sealed class BinaryConverter : JsonConverter<byte[]>
    {
        internal override JsonNode ToJson(byte[] value) => new XBinary(value);

        internal override byte[] FromJson(JsonNode node)
        {
            switch (node.Type)
            {
                case JsonType.String : return Convert.FromBase64String(node.ToString());    // Base64 Encoded
                case JsonType.Binary : return ((XBinary)node).Value;
            }

            throw new ConversionException(node, typeof(byte[]));
        }
    }
}