﻿namespace Microsoft.Azure.AzConfig.Runtime.Json
{
    public sealed class DecimalConverter : JsonConverter<decimal>
    {
        internal override JsonNode ToJson(decimal value) => new JsonNumber(value.ToString());

        internal override decimal FromJson(JsonNode node)
        {
            return (decimal)node;
        }
    }
}