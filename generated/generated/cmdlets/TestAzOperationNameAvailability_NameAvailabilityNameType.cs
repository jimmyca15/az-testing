namespace Microsoft.Azure.AzConfig.Cmdlets
{
    using static Microsoft.Azure.AzConfig.Runtime.Extensions;
    /// <summary>Implement a variant of the cmdlet Test-OperationNameAvailability.</summary>
    [System.Management.Automation.Cmdlet(System.Management.Automation.VerbsDiagnostic.Test, @"AzOperationNameAvailability_NameAvailabilityNameType", SupportsShouldProcess = true)]
    [System.Management.Automation.OutputType(typeof(Microsoft.Azure.AzConfig.Models.INameAvailabilityStatus))]
    public class TestAzOperationNameAvailability_NameAvailabilityNameType : System.Management.Automation.PSCmdlet, Microsoft.Azure.AzConfig.Runtime.IEventListener
    {
        /// <summary>A unique id generatd for the this cmdlet when it is instantiated.</summary>
        private string __correlationId = System.Guid.NewGuid().ToString();
        /// <summary>A copy of the Invocation Info (necessary to allow asJob to clone this cmdlet)</summary>
         private System.Management.Automation.InvocationInfo __invocationInfo;
        /// <summary>A unique id generatd for the this cmdlet when ProcessRecord() is called.</summary>
         private string __processRecordId;
        /// <summary>The <see cref="System.Threading.CancellationTokenSource" /> for this operation.</summary>
        private System.Threading.CancellationTokenSource _cancellationTokenSource = new System.Threading.CancellationTokenSource();
        /// <summary>Wait for .NET debugger to attach</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow= true, HelpMessage = "Wait for .NET debugger to attach")]
        public System.Management.Automation.SwitchParameter Break {get;set;}
        /// <summary>Backing field for <see cref="CheckNameAvailabilityParameters" /> property.</summary>
        private Microsoft.Azure.AzConfig.Models.ICheckNameAvailabilityParameters _checkNameAvailabilityParameters;

        /// <summary>Parameters used for checking whether a resource name is available.</summary>
        [System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "Parameters used for checking whether a resource name is available.", ValueFromPipeline = true)]
        public Microsoft.Azure.AzConfig.Models.ICheckNameAvailabilityParameters CheckNameAvailabilityParameters
        {
            get
            {
                return this._checkNameAvailabilityParameters;
            }
            set
            {
                this._checkNameAvailabilityParameters = value;
            }
        }
        /// <summary>The reference to the client API class.</summary>
        public Microsoft.Azure.AzConfig.AzconfigManagementClient Client => Microsoft.Azure.AzConfig.Module.Instance.ClientAPI;
        /// <summary>
        /// The credentials, account, tenant, and subscription used for communication with Azure
        /// </summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The credentials, account, tenant, and subscription used for communication with Azure.")]
        [System.Management.Automation.ValidateNotNull]
        [System.Management.Automation.Alias("AzureRMContext", "AzureCredential")]
        public object DefaultProfile {get;set;}
        /// <summary>SendAsync Pipeline Steps to be appended to the front of the pipeline</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow= true, HelpMessage = "SendAsync Pipeline Steps to be appended to the front of the pipeline")]
        [System.Management.Automation.ValidateNotNull]
        public Microsoft.Azure.AzConfig.Runtime.SendAsyncStep[] HttpPipelineAppend {get;set;}
        /// <summary>SendAsync Pipeline Steps to be prepended to the front of the pipeline</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow= true, HelpMessage = "SendAsync Pipeline Steps to be prepended to the front of the pipeline")]
        [System.Management.Automation.ValidateNotNull]
        public Microsoft.Azure.AzConfig.Runtime.SendAsyncStep[] HttpPipelinePrepend {get;set;}
        /// <summary>Accessor for our copy of the InvocationInfo.</summary>
        public System.Management.Automation.InvocationInfo InvocationInformation
        {
            get
            {
                return __invocationInfo = __invocationInfo ?? this.MyInvocation ;
            }
            set
            {
                __invocationInfo = value;
            }
        }
        /// <summary>
        /// <see cref="IEventListener" /> cancellation delegate. Stops the cmdlet when called.
        /// </summary>
         System.Action Microsoft.Azure.AzConfig.Runtime.IEventListener.Cancel => _cancellationTokenSource.Cancel;
        /// <summary><see cref="IEventListener" /> cancellation token.</summary>
         System.Threading.CancellationToken Microsoft.Azure.AzConfig.Runtime.IEventListener.Token => _cancellationTokenSource.Token;
        /// <summary>
        /// The instance of the <see cref="Microsoft.Azure.AzConfig.Runtime.HttpPipeline" /> that the remote call will use.
        /// </summary>
        private Microsoft.Azure.AzConfig.Runtime.HttpPipeline Pipeline {get;set;}
        /// <summary>The URI for the proxy server to use</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow= true, HelpMessage = "The URI for the proxy server to use")]
        public System.Uri Proxy {get;set;}
        /// <summary>Credentials for a proxy server to use for the remote call</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow= true, HelpMessage = "Credentials for a proxy server to use for the remote call")]
        [System.Management.Automation.ValidateNotNull]
        public System.Management.Automation.PSCredential ProxyCredential {get;set;}
        /// <summary>Use the default credentials for the proxy</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow= true, HelpMessage = "Use the default credentials for the proxy")]
        public System.Management.Automation.SwitchParameter ProxyUseDefaultCredentials {get;set;}
        /// <summary>Backing field for <see cref="SubscriptionId" /> property.</summary>
        private string _subscriptionId;

        /// <summary>The Microsoft Azure subscription ID.</summary>
        public string SubscriptionId
        {
            get
            {
                return this._subscriptionId;
            }
            set
            {
                this._subscriptionId = value;
            }
        }
        /// <summary>
        /// (overrides the default BeginProcessing method in System.Management.Automation.PSCmdlet)
        /// </summary>

        protected override void BeginProcessing()
        {
            Module.Instance.SetProxyConfiguration(Proxy, ProxyCredential, ProxyUseDefaultCredentials);
            if (Break)
            {
                System.AttachDebugger.Break();
            }
            ((Microsoft.Azure.AzConfig.Runtime.IEventListener)this).Signal(Microsoft.Azure.AzConfig.Runtime.Events.CmdletBeginProcessing).Wait(); if( ((Microsoft.Azure.AzConfig.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
            _subscriptionId = Microsoft.Azure.AzConfig.Module.Instance.GetParameter(this.MyInvocation, __correlationId, "subscriptionId") as string;
        }
        /// <summary>Creates a duplicate instance of this cmdlet (via JSON serialization).</summary>
        /// <returns>
        /// a duplicate instance of TestAzOperationNameAvailability_NameAvailabilityNameType
        /// </returns>
        public Microsoft.Azure.AzConfig.Cmdlets.TestAzOperationNameAvailability_NameAvailabilityNameType Clone()
        {
            var clone = FromJson(this.ToJson(null, Microsoft.Azure.AzConfig.Runtime.SerializationMode.IncludeAll));
            clone.HttpPipelinePrepend = this.HttpPipelinePrepend;
            clone.HttpPipelineAppend = this.HttpPipelineAppend;
            return clone;
        }
        /// <summary>Performs clean-up after the command execution</summary>

        protected override void EndProcessing()
        {
            ((Microsoft.Azure.AzConfig.Runtime.IEventListener)this).Signal(Microsoft.Azure.AzConfig.Runtime.Events.CmdletEndProcessing).Wait(); if( ((Microsoft.Azure.AzConfig.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
        }
        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.AzConfig.Runtime.Json.JsonNode" /> into a new instance of this class.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.AzConfig.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>an instance of TestAzOperationNameAvailability_NameAvailabilityNameType.</returns>
        public static Microsoft.Azure.AzConfig.Cmdlets.TestAzOperationNameAvailability_NameAvailabilityNameType FromJson(Microsoft.Azure.AzConfig.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.AzConfig.Runtime.Json.JsonObject json ? new TestAzOperationNameAvailability_NameAvailabilityNameType(json) : null;
        }
        /// <summary>
        /// Creates a new instance of this cmdlet, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this cmdlet.</param>
        /// <returns>
        /// returns a new instance of the <see cref="TestAzOperationNameAvailability_NameAvailabilityNameType" /> cmdlet
        /// </returns>
        public static Microsoft.Azure.AzConfig.Cmdlets.TestAzOperationNameAvailability_NameAvailabilityNameType FromJsonString(string jsonText) => string.IsNullOrEmpty(jsonText) ? null : FromJson(Microsoft.Azure.AzConfig.Runtime.Json.JsonObject.Parse(jsonText));
        /// <summary>Handles/Dispatches events during the call to the REST service.</summary>
        /// <param name="id">The message id</param>
        /// <param name="token">The message cancellation token. When this call is cancelled, this should be <c>true</c></param>
        /// <param name="messageData">Detailed message data for the message event.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the message is completed.
        /// </returns>
         async System.Threading.Tasks.Task Microsoft.Azure.AzConfig.Runtime.IEventListener.Signal(string id, System.Threading.CancellationToken token, System.Func<Microsoft.Azure.AzConfig.Runtime.EventData> messageData)
        {
            using( NoSynchronizationContext )
            {
                if (token.IsCancellationRequested)
                {
                    return ;
                }
                switch ( id )
                {
                    case Microsoft.Azure.AzConfig.Runtime.Events.Verbose:
                    {
                        WriteVerbose($"{messageData().Message ?? System.String.Empty}");
                        return ;
                    }
                    case Microsoft.Azure.AzConfig.Runtime.Events.Warning:
                    {
                        WriteWarning($"{messageData().Message ?? System.String.Empty}");
                        return ;
                    }
                    case Microsoft.Azure.AzConfig.Runtime.Events.Information:
                    {
                        var data = messageData();
                        WriteInformation(data, new[] { data.Message });
                        return ;
                    }
                    case Microsoft.Azure.AzConfig.Runtime.Events.Debug:
                    {
                        WriteDebug($"{messageData().Message ?? System.String.Empty}");
                        return ;
                    }
                    case Microsoft.Azure.AzConfig.Runtime.Events.Error:
                    {
                        WriteError(new System.Management.Automation.ErrorRecord( new System.Exception(messageData().Message), string.Empty, System.Management.Automation.ErrorCategory.NotSpecified, null ) );
                        return ;
                    }
                }
                await Microsoft.Azure.AzConfig.Module.Instance.Signal(id, token, messageData, (i,t,m) => ((Microsoft.Azure.AzConfig.Runtime.IEventListener)this).Signal(i,t,()=> Microsoft.Azure.AzConfig.Runtime.EventDataConverter.ConvertFrom( m() ) as Microsoft.Azure.AzConfig.Runtime.EventData ), InvocationInformation, this.ParameterSetName, __correlationId, __processRecordId, null );
                if (token.IsCancellationRequested)
                {
                    return ;
                }
                WriteDebug($"{id}: {messageData().Message ?? System.String.Empty}");
            }
        }
        /// <summary>Performs execution of the command.</summary>

        protected override void ProcessRecord()
        {
            ((Microsoft.Azure.AzConfig.Runtime.IEventListener)this).Signal(Microsoft.Azure.AzConfig.Runtime.Events.CmdletProcessRecordStart).Wait(); if( ((Microsoft.Azure.AzConfig.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
            __processRecordId = System.Guid.NewGuid().ToString();
            try
            {
                // work
                if (ShouldProcess($"Call remote 'Operations_CheckNameAvailability' operation"))
                {
                    using( var asyncCommandRuntime = new Microsoft.Azure.AzConfig.Runtime.PowerShell.AsyncCommandRuntime(this, ((Microsoft.Azure.AzConfig.Runtime.IEventListener)this).Token) )
                    {
                        asyncCommandRuntime.Wait( ProcessRecordAsync(),((Microsoft.Azure.AzConfig.Runtime.IEventListener)this).Token);
                    }
                }
            }
            catch (System.AggregateException aggregateException)
            {
                // unroll the inner exceptions to get the root cause
                foreach( var innerException in aggregateException.Flatten().InnerExceptions )
                {
                    ((Microsoft.Azure.AzConfig.Runtime.IEventListener)this).Signal(Microsoft.Azure.AzConfig.Runtime.Events.CmdletException, $"{innerException.GetType().Name} - {innerException.Message} : {innerException.StackTrace}").Wait(); if( ((Microsoft.Azure.AzConfig.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                    // Write exception out to error channel.
                    WriteError( new System.Management.Automation.ErrorRecord(innerException,string.Empty, System.Management.Automation.ErrorCategory.NotSpecified, null) );
                }
            }
            catch (System.Exception exception)
            {
                ((Microsoft.Azure.AzConfig.Runtime.IEventListener)this).Signal(Microsoft.Azure.AzConfig.Runtime.Events.CmdletException, $"{exception.GetType().Name} - {exception.Message} : {exception.StackTrace}").Wait(); if( ((Microsoft.Azure.AzConfig.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                // Write exception out to error channel.
                WriteError( new System.Management.Automation.ErrorRecord(exception,string.Empty, System.Management.Automation.ErrorCategory.NotSpecified, null) );
            }
            finally
            {
                ((Microsoft.Azure.AzConfig.Runtime.IEventListener)this).Signal(Microsoft.Azure.AzConfig.Runtime.Events.CmdletProcessRecordEnd).Wait();
            }
        }
        /// <summary>Performs execution of the command, working asynchronously if required.</summary>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        protected async System.Threading.Tasks.Task ProcessRecordAsync()
        {
            using( NoSynchronizationContext )
            {
                await ((Microsoft.Azure.AzConfig.Runtime.IEventListener)this).Signal(Microsoft.Azure.AzConfig.Runtime.Events.CmdletProcessRecordAsyncStart); if( ((Microsoft.Azure.AzConfig.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                await ((Microsoft.Azure.AzConfig.Runtime.IEventListener)this).Signal(Microsoft.Azure.AzConfig.Runtime.Events.CmdletGetPipeline); if( ((Microsoft.Azure.AzConfig.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                Pipeline = Microsoft.Azure.AzConfig.Module.Instance.CreatePipeline(InvocationInformation, __correlationId, __processRecordId);
                Pipeline.Prepend(HttpPipelinePrepend);
                Pipeline.Append(HttpPipelineAppend);
                // get the client instance
                try
                {
                    await ((Microsoft.Azure.AzConfig.Runtime.IEventListener)this).Signal(Microsoft.Azure.AzConfig.Runtime.Events.CmdletBeforeAPICall); if( ((Microsoft.Azure.AzConfig.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                    await this.Client.OperationsCheckNameAvailability(SubscriptionId, CheckNameAvailabilityParameters, onOK, onDefault, this, Pipeline);
                    await ((Microsoft.Azure.AzConfig.Runtime.IEventListener)this).Signal(Microsoft.Azure.AzConfig.Runtime.Events.CmdletAfterAPICall); if( ((Microsoft.Azure.AzConfig.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                }
                finally
                {
                    await ((Microsoft.Azure.AzConfig.Runtime.IEventListener)this).Signal(Microsoft.Azure.AzConfig.Runtime.Events.CmdletProcessRecordAsyncEnd);
                }
            }
        }
        /// <summary>Interrupts currently running code within the command.</summary>

        protected override void StopProcessing()
        {
            ((Microsoft.Azure.AzConfig.Runtime.IEventListener)this).Cancel();
            base.StopProcessing();
        }
        /// <summary>Constructor for deserialization.</summary>
        /// <param name="json">a <see cref="Microsoft.Azure.AzConfig.Runtime.Json.JsonObject" /> to deserialize from.</param>
        internal TestAzOperationNameAvailability_NameAvailabilityNameType(Microsoft.Azure.AzConfig.Runtime.Json.JsonObject json)
        {
            // deserialize the contents
            _subscriptionId = If( json?.PropertyT<Microsoft.Azure.AzConfig.Runtime.Json.JsonString>("SubscriptionId"), out var __jsonSubscriptionId) ? (string)__jsonSubscriptionId : (string)SubscriptionId;
            _checkNameAvailabilityParameters = If( json?.PropertyT<Microsoft.Azure.AzConfig.Runtime.Json.JsonObject>("CheckNameAvailabilityParameters"), out var __jsonCheckNameAvailabilityParameters) ? Microsoft.Azure.AzConfig.Models.CheckNameAvailabilityParameters.FromJson(__jsonCheckNameAvailabilityParameters) : CheckNameAvailabilityParameters;
        }
        /// <summary>
        /// Intializes a new instance of the <see cref="TestAzOperationNameAvailability_NameAvailabilityNameType" /> cmdlet class.
        /// </summary>
        public TestAzOperationNameAvailability_NameAvailabilityNameType()
        {
        }
        /// <summary>
        /// Serializes the state of this cmdlet to a <see cref="Microsoft.Azure.AzConfig.Runtime.Json.JsonNode" /> object.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.AzConfig.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.AzConfig.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="TestAzOperationNameAvailability_NameAvailabilityNameType" /> as a <see cref="Microsoft.Azure.AzConfig.Runtime.Json.JsonNode"
        /// />.
        /// </returns>
        public Microsoft.Azure.AzConfig.Runtime.Json.JsonNode ToJson(Microsoft.Azure.AzConfig.Runtime.Json.JsonObject container, Microsoft.Azure.AzConfig.Runtime.SerializationMode serializationMode)
        {
            // serialization method
            container = container ?? new Microsoft.Azure.AzConfig.Runtime.Json.JsonObject();
            AddIf( null != (((object)SubscriptionId)?.ToString()) ? (Microsoft.Azure.AzConfig.Runtime.Json.JsonNode) new Microsoft.Azure.AzConfig.Runtime.Json.JsonString(SubscriptionId.ToString()) : null, "SubscriptionId" ,container.Add );
            AddIf( null != CheckNameAvailabilityParameters ? (Microsoft.Azure.AzConfig.Runtime.Json.JsonNode) CheckNameAvailabilityParameters.ToJson(null) : null, "CheckNameAvailabilityParameters" ,container.Add );
            return container;
        }
        /// <summary>
        /// a delegate that is called when the remote service returns default (any response code not handled elsewhere).
        /// </summary>
        /// <param name="responseMessage">the raw response message as an System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.AzConfig.Models.IError" /> from the remote call</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async System.Threading.Tasks.Task onDefault(System.Net.Http.HttpResponseMessage responseMessage, System.Threading.Tasks.Task<Microsoft.Azure.AzConfig.Models.IError> response)
        {
            using( NoSynchronizationContext )
            {
                // Error Response : default
                var code = (await response).ErrorProperty?.Code;;
                var message = (await response).ErrorProperty?.Message;;
                if ((null == code || null == message))
                {
                    // Unrecognized Response. Create an error record based on what we have.
                    WriteError(new System.Management.Automation.ErrorRecord(new System.Exception($"The service encountered an unexpected result: {responseMessage.StatusCode}\nBody: {await responseMessage.Content.ReadAsStringAsync()}"), responseMessage.StatusCode.ToString(), System.Management.Automation.ErrorCategory.InvalidOperation, new { SubscriptionId,CheckNameAvailabilityParameters}));
                }
                else
                {
                    WriteError(new System.Management.Automation.ErrorRecord(new System.Exception($"[{code}] : {message}"), code?.ToString(), System.Management.Automation.ErrorCategory.InvalidOperation, new { SubscriptionId,CheckNameAvailabilityParameters}));
                }
            }
        }
        /// <summary>a delegate that is called when the remote service returns 200 (OK).</summary>
        /// <param name="responseMessage">the raw response message as an System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.AzConfig.Models.INameAvailabilityStatus" /> from
        /// the remote call</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async System.Threading.Tasks.Task onOK(System.Net.Http.HttpResponseMessage responseMessage, System.Threading.Tasks.Task<Microsoft.Azure.AzConfig.Models.INameAvailabilityStatus> response)
        {
            using( NoSynchronizationContext )
            {
                // onOK - response for 200 / application/json
                // (await response) // should be Microsoft.Azure.AzConfig.Models.INameAvailabilityStatus
                WriteObject(await response);
            }
        }
    }
}