﻿using System;

namespace Microsoft.Azure.AzConfig.Runtime.Json
{
    internal class ConversionException : Exception
    {
        internal ConversionException(string message)
            : base(message) { }

        internal ConversionException(JsonNode node, Type targetType)
            : base($"Cannot convert '{node.Type}' to a {targetType.Name}") { }
    }
}