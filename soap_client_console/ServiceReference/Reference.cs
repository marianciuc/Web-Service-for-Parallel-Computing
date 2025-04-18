﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторного создания кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ArrayOfFloat", Namespace="http://tempuri.org/", ItemName="float")]
    public class ArrayOfFloat : System.Collections.Generic.List<float>
    {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IMatrixMultiplyService")]
    public interface IMatrixMultiplyService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMatrixMultiplyService/Multiply", ReplyAction="*")]
        System.Threading.Tasks.Task<ServiceReference.MultiplyResponse> MultiplyAsync(ServiceReference.MultiplyRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMatrixMultiplyService/SaveToFile", ReplyAction="*")]
        System.Threading.Tasks.Task<ServiceReference.SaveToFileResponse> SaveToFileAsync(ServiceReference.SaveToFileRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMatrixMultiplyService/ReadMatrix", ReplyAction="*")]
        System.Threading.Tasks.Task<ServiceReference.ReadMatrixResponse> ReadMatrixAsync(ServiceReference.ReadMatrixRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class MultiplyRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Multiply", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference.MultiplyRequestBody Body;
        
        public MultiplyRequest()
        {
        }
        
        public MultiplyRequest(ServiceReference.MultiplyRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class MultiplyRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string filename1;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string filename2;
        
        public MultiplyRequestBody()
        {
        }
        
        public MultiplyRequestBody(string filename1, string filename2)
        {
            this.filename1 = filename1;
            this.filename2 = filename2;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class MultiplyResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="MultiplyResponse", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference.MultiplyResponseBody Body;
        
        public MultiplyResponse()
        {
        }
        
        public MultiplyResponse(ServiceReference.MultiplyResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class MultiplyResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string MultiplyResult;
        
        public MultiplyResponseBody()
        {
        }
        
        public MultiplyResponseBody(string MultiplyResult)
        {
            this.MultiplyResult = MultiplyResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SaveToFileRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SaveToFile", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference.SaveToFileRequestBody Body;
        
        public SaveToFileRequest()
        {
        }
        
        public SaveToFileRequest(ServiceReference.SaveToFileRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class SaveToFileRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public ServiceReference.ArrayOfFloat[] matrix;
        
        public SaveToFileRequestBody()
        {
        }
        
        public SaveToFileRequestBody(ServiceReference.ArrayOfFloat[] matrix)
        {
            this.matrix = matrix;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SaveToFileResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SaveToFileResponse", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference.SaveToFileResponseBody Body;
        
        public SaveToFileResponse()
        {
        }
        
        public SaveToFileResponse(ServiceReference.SaveToFileResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class SaveToFileResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string SaveToFileResult;
        
        public SaveToFileResponseBody()
        {
        }
        
        public SaveToFileResponseBody(string SaveToFileResult)
        {
            this.SaveToFileResult = SaveToFileResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ReadMatrixRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ReadMatrix", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference.ReadMatrixRequestBody Body;
        
        public ReadMatrixRequest()
        {
        }
        
        public ReadMatrixRequest(ServiceReference.ReadMatrixRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ReadMatrixRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string filename;
        
        public ReadMatrixRequestBody()
        {
        }
        
        public ReadMatrixRequestBody(string filename)
        {
            this.filename = filename;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ReadMatrixResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ReadMatrixResponse", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference.ReadMatrixResponseBody Body;
        
        public ReadMatrixResponse()
        {
        }
        
        public ReadMatrixResponse(ServiceReference.ReadMatrixResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ReadMatrixResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public ServiceReference.ArrayOfFloat[] ReadMatrixResult;
        
        public ReadMatrixResponseBody()
        {
        }
        
        public ReadMatrixResponseBody(ServiceReference.ArrayOfFloat[] ReadMatrixResult)
        {
            this.ReadMatrixResult = ReadMatrixResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    public interface IMatrixMultiplyServiceChannel : ServiceReference.IMatrixMultiplyService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
    public partial class MatrixMultiplyServiceClient : System.ServiceModel.ClientBase<ServiceReference.IMatrixMultiplyService>, ServiceReference.IMatrixMultiplyService
    {
        
        /// <summary>
        /// Реализуйте этот разделяемый метод для настройки конечной точки службы.
        /// </summary>
        /// <param name="serviceEndpoint">Настраиваемая конечная точка</param>
        /// <param name="clientCredentials">Учетные данные клиента.</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public MatrixMultiplyServiceClient() : 
                base(MatrixMultiplyServiceClient.GetDefaultBinding(), MatrixMultiplyServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IMatrixMultiplyService_soap.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public MatrixMultiplyServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(MatrixMultiplyServiceClient.GetBindingForEndpoint(endpointConfiguration), MatrixMultiplyServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public MatrixMultiplyServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(MatrixMultiplyServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public MatrixMultiplyServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(MatrixMultiplyServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public MatrixMultiplyServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference.MultiplyResponse> ServiceReference.IMatrixMultiplyService.MultiplyAsync(ServiceReference.MultiplyRequest request)
        {
            return base.Channel.MultiplyAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference.MultiplyResponse> MultiplyAsync(string filename1, string filename2)
        {
            ServiceReference.MultiplyRequest inValue = new ServiceReference.MultiplyRequest();
            inValue.Body = new ServiceReference.MultiplyRequestBody();
            inValue.Body.filename1 = filename1;
            inValue.Body.filename2 = filename2;
            return ((ServiceReference.IMatrixMultiplyService)(this)).MultiplyAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference.SaveToFileResponse> ServiceReference.IMatrixMultiplyService.SaveToFileAsync(ServiceReference.SaveToFileRequest request)
        {
            return base.Channel.SaveToFileAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference.SaveToFileResponse> SaveToFileAsync(ServiceReference.ArrayOfFloat[] matrix)
        {
            ServiceReference.SaveToFileRequest inValue = new ServiceReference.SaveToFileRequest();
            inValue.Body = new ServiceReference.SaveToFileRequestBody();
            inValue.Body.matrix = matrix;
            return ((ServiceReference.IMatrixMultiplyService)(this)).SaveToFileAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference.ReadMatrixResponse> ServiceReference.IMatrixMultiplyService.ReadMatrixAsync(ServiceReference.ReadMatrixRequest request)
        {
            return base.Channel.ReadMatrixAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference.ReadMatrixResponse> ReadMatrixAsync(string filename)
        {
            ServiceReference.ReadMatrixRequest inValue = new ServiceReference.ReadMatrixRequest();
            inValue.Body = new ServiceReference.ReadMatrixRequestBody();
            inValue.Body.filename = filename;
            return ((ServiceReference.IMatrixMultiplyService)(this)).ReadMatrixAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        #if !NET6_0_OR_GREATER
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        #endif
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IMatrixMultiplyService_soap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Не удалось найти конечную точку с именем \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IMatrixMultiplyService_soap))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:5097/MatrixService.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Не удалось найти конечную точку с именем \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return MatrixMultiplyServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IMatrixMultiplyService_soap);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return MatrixMultiplyServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IMatrixMultiplyService_soap);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IMatrixMultiplyService_soap,
        }
    }
}
