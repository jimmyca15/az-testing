namespace Microsoft.Azure.AzConfig.Models
{
    using static Microsoft.Azure.AzConfig.Runtime.Extensions;
    /// <summary>The result of a request to list configuration store operations.</summary>
    public partial class OperationDefinitionListResult : Microsoft.Azure.AzConfig.Models.IOperationDefinitionListResult, Microsoft.Azure.AzConfig.Runtime.IValidates
    {
        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URI that can be used to request the next set of paged results.</summary>
        public string NextLink
        {
            get
            {
                return this._nextLink;
            }
            set
            {
                this._nextLink = value;
            }
        }
        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.AzConfig.Models.IOperationDefinition[] _value;

        /// <summary>The collection value.</summary>
        public Microsoft.Azure.AzConfig.Models.IOperationDefinition[] Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
        /// <summary>Creates an new <see cref="OperationDefinitionListResult" /> instance.</summary>
        public OperationDefinitionListResult()
        {
        }
        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.AzConfig.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async System.Threading.Tasks.Task Validate(Microsoft.Azure.AzConfig.Runtime.IEventListener eventListener)
        {
            if (Value != null ) {
                    for (int __i = 0; __i < Value.Length; __i++) {
                      await eventListener.AssertObjectIsValid($"Value[{__i}]", Value[__i]);
                    }
                  }
        }
    }
    /// The result of a request to list configuration store operations.
    public partial interface IOperationDefinitionListResult : Microsoft.Azure.AzConfig.Runtime.IJsonSerializable {
        string NextLink { get; set; }
        Microsoft.Azure.AzConfig.Models.IOperationDefinition[] Value { get; set; }
    }
}