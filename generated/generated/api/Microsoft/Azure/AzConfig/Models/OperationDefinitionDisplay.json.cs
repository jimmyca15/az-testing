namespace Microsoft.Azure.AzConfig.Models
{
    using static Microsoft.Azure.AzConfig.Runtime.Extensions;
    /// <summary>The display information for a configuration store operation.</summary>
    public partial class OperationDefinitionDisplay
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        partial void AfterFromJson(Microsoft.Azure.AzConfig.Runtime.Json.JsonObject json);
        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.AzConfig.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        partial void AfterToJson(ref Microsoft.Azure.AzConfig.Runtime.Json.JsonObject container);
        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>
        partial void BeforeFromJson(Microsoft.Azure.AzConfig.Runtime.Json.JsonObject json, ref bool returnNow);
        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>
        partial void BeforeToJson(ref Microsoft.Azure.AzConfig.Runtime.Json.JsonObject container, ref bool returnNow);
        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.AzConfig.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.AzConfig.Models.IOperationDefinitionDisplay.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.AzConfig.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>an instance of Microsoft.Azure.AzConfig.Models.IOperationDefinitionDisplay.</returns>
        public static Microsoft.Azure.AzConfig.Models.IOperationDefinitionDisplay FromJson(Microsoft.Azure.AzConfig.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.AzConfig.Runtime.Json.JsonObject json ? new OperationDefinitionDisplay(json) : null;
        }
        /// <summary>
        /// Deserializes a Microsoft.Azure.AzConfig.Runtime.Json.JsonObject into a new instance of <see cref="OperationDefinitionDisplay" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.AzConfig.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal OperationDefinitionDisplay(Microsoft.Azure.AzConfig.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            _description = If( json?.PropertyT<Microsoft.Azure.AzConfig.Runtime.Json.JsonString>("description"), out var __jsonDescription) ? (string)__jsonDescription : (string)Description;
            _operation = If( json?.PropertyT<Microsoft.Azure.AzConfig.Runtime.Json.JsonString>("operation"), out var __jsonOperation) ? (string)__jsonOperation : (string)Operation;
            _provider = If( json?.PropertyT<Microsoft.Azure.AzConfig.Runtime.Json.JsonString>("provider"), out var __jsonProvider) ? (string)__jsonProvider : (string)Provider;
            _resource = If( json?.PropertyT<Microsoft.Azure.AzConfig.Runtime.Json.JsonString>("resource"), out var __jsonResource) ? (string)__jsonResource : (string)Resource;
            AfterFromJson(json);
        }
        /// <summary>
        /// Serializes this instance of <see cref="OperationDefinitionDisplay" /> into a <see cref="Microsoft.Azure.AzConfig.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.AzConfig.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.AzConfig.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="OperationDefinitionDisplay" /> as a <see cref="Microsoft.Azure.AzConfig.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.AzConfig.Runtime.Json.JsonNode ToJson(Microsoft.Azure.AzConfig.Runtime.Json.JsonObject container, Microsoft.Azure.AzConfig.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.AzConfig.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)Description)?.ToString()) ? (Microsoft.Azure.AzConfig.Runtime.Json.JsonNode) new Microsoft.Azure.AzConfig.Runtime.Json.JsonString(Description.ToString()) : null, "description" ,container.Add );
            AddIf( null != (((object)Operation)?.ToString()) ? (Microsoft.Azure.AzConfig.Runtime.Json.JsonNode) new Microsoft.Azure.AzConfig.Runtime.Json.JsonString(Operation.ToString()) : null, "operation" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.AzConfig.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)Provider)?.ToString()) ? (Microsoft.Azure.AzConfig.Runtime.Json.JsonNode) new Microsoft.Azure.AzConfig.Runtime.Json.JsonString(Provider.ToString()) : null, "provider" ,container.Add );
            }
            AddIf( null != (((object)Resource)?.ToString()) ? (Microsoft.Azure.AzConfig.Runtime.Json.JsonNode) new Microsoft.Azure.AzConfig.Runtime.Json.JsonString(Resource.ToString()) : null, "resource" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}