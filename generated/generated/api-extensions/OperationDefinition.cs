namespace Microsoft.Azure.AzConfig.Models
{

    /// <summary>The definition of a configuration store operation.</summary>
    [System.ComponentModel.TypeConverter(typeof(OperationDefinitionTypeConverter))]
    public partial class OperationDefinition
    {

        /// <summary>
        /// Creates a new instance of <see cref="OperationDefinition" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.AzConfig.Models.IOperationDefinition FromJsonString(string jsonText) => FromJson(Microsoft.Azure.AzConfig.Runtime.Json.JsonNode.Parse(jsonText));
        /// <summary>Serializes this instance to a json string.</summary>
        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.AzConfig.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The definition of a configuration store operation.
    [System.ComponentModel.TypeConverter(typeof(OperationDefinitionTypeConverter))]
    public partial interface IOperationDefinition {

    }
}