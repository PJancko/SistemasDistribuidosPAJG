﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace rsPersona
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Persona", Namespace="http://tempuri.org/")]
    public partial class Persona : object
    {
        
        private int idField;
        
        private string nombreField;
        
        private int edadField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string nombre
        {
            get
            {
                return this.nombreField;
            }
            set
            {
                this.nombreField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public int edad
        {
            get
            {
                return this.edadField;
            }
            set
            {
                this.edadField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="rsPersona.wsPersonaSoap")]
    public interface wsPersonaSoap
    {
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento ObtenerPersonasResult del espacio de nombres http://tempuri.org/ no está marcado para convertirse en valor nulo
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObtenerPersonas", ReplyAction="*")]
        rsPersona.ObtenerPersonasResponse ObtenerPersonas(rsPersona.ObtenerPersonasRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObtenerPersonas", ReplyAction="*")]
        System.Threading.Tasks.Task<rsPersona.ObtenerPersonasResponse> ObtenerPersonasAsync(rsPersona.ObtenerPersonasRequest request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento nombre del espacio de nombres http://tempuri.org/ no está marcado para convertirse en valor nulo
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AgregarPersona", ReplyAction="*")]
        rsPersona.AgregarPersonaResponse AgregarPersona(rsPersona.AgregarPersonaRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AgregarPersona", ReplyAction="*")]
        System.Threading.Tasks.Task<rsPersona.AgregarPersonaResponse> AgregarPersonaAsync(rsPersona.AgregarPersonaRequest request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento nombre del espacio de nombres http://tempuri.org/ no está marcado para convertirse en valor nulo
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ActualizarPersona", ReplyAction="*")]
        rsPersona.ActualizarPersonaResponse ActualizarPersona(rsPersona.ActualizarPersonaRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ActualizarPersona", ReplyAction="*")]
        System.Threading.Tasks.Task<rsPersona.ActualizarPersonaResponse> ActualizarPersonaAsync(rsPersona.ActualizarPersonaRequest request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento EliminarPersonaResult del espacio de nombres http://tempuri.org/ no está marcado para convertirse en valor nulo
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/EliminarPersona", ReplyAction="*")]
        rsPersona.EliminarPersonaResponse EliminarPersona(rsPersona.EliminarPersonaRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/EliminarPersona", ReplyAction="*")]
        System.Threading.Tasks.Task<rsPersona.EliminarPersonaResponse> EliminarPersonaAsync(rsPersona.EliminarPersonaRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ObtenerPersonasRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ObtenerPersonas", Namespace="http://tempuri.org/", Order=0)]
        public rsPersona.ObtenerPersonasRequestBody Body;
        
        public ObtenerPersonasRequest()
        {
        }
        
        public ObtenerPersonasRequest(rsPersona.ObtenerPersonasRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class ObtenerPersonasRequestBody
    {
        
        public ObtenerPersonasRequestBody()
        {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ObtenerPersonasResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ObtenerPersonasResponse", Namespace="http://tempuri.org/", Order=0)]
        public rsPersona.ObtenerPersonasResponseBody Body;
        
        public ObtenerPersonasResponse()
        {
        }
        
        public ObtenerPersonasResponse(rsPersona.ObtenerPersonasResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ObtenerPersonasResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public rsPersona.Persona[] ObtenerPersonasResult;
        
        public ObtenerPersonasResponseBody()
        {
        }
        
        public ObtenerPersonasResponseBody(rsPersona.Persona[] ObtenerPersonasResult)
        {
            this.ObtenerPersonasResult = ObtenerPersonasResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AgregarPersonaRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AgregarPersona", Namespace="http://tempuri.org/", Order=0)]
        public rsPersona.AgregarPersonaRequestBody Body;
        
        public AgregarPersonaRequest()
        {
        }
        
        public AgregarPersonaRequest(rsPersona.AgregarPersonaRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class AgregarPersonaRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string nombre;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int edad;
        
        public AgregarPersonaRequestBody()
        {
        }
        
        public AgregarPersonaRequestBody(string nombre, int edad)
        {
            this.nombre = nombre;
            this.edad = edad;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AgregarPersonaResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AgregarPersonaResponse", Namespace="http://tempuri.org/", Order=0)]
        public rsPersona.AgregarPersonaResponseBody Body;
        
        public AgregarPersonaResponse()
        {
        }
        
        public AgregarPersonaResponse(rsPersona.AgregarPersonaResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class AgregarPersonaResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string AgregarPersonaResult;
        
        public AgregarPersonaResponseBody()
        {
        }
        
        public AgregarPersonaResponseBody(string AgregarPersonaResult)
        {
            this.AgregarPersonaResult = AgregarPersonaResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ActualizarPersonaRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ActualizarPersona", Namespace="http://tempuri.org/", Order=0)]
        public rsPersona.ActualizarPersonaRequestBody Body;
        
        public ActualizarPersonaRequest()
        {
        }
        
        public ActualizarPersonaRequest(rsPersona.ActualizarPersonaRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ActualizarPersonaRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int id;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string nombre;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int edad;
        
        public ActualizarPersonaRequestBody()
        {
        }
        
        public ActualizarPersonaRequestBody(int id, string nombre, int edad)
        {
            this.id = id;
            this.nombre = nombre;
            this.edad = edad;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ActualizarPersonaResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ActualizarPersonaResponse", Namespace="http://tempuri.org/", Order=0)]
        public rsPersona.ActualizarPersonaResponseBody Body;
        
        public ActualizarPersonaResponse()
        {
        }
        
        public ActualizarPersonaResponse(rsPersona.ActualizarPersonaResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ActualizarPersonaResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string ActualizarPersonaResult;
        
        public ActualizarPersonaResponseBody()
        {
        }
        
        public ActualizarPersonaResponseBody(string ActualizarPersonaResult)
        {
            this.ActualizarPersonaResult = ActualizarPersonaResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class EliminarPersonaRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="EliminarPersona", Namespace="http://tempuri.org/", Order=0)]
        public rsPersona.EliminarPersonaRequestBody Body;
        
        public EliminarPersonaRequest()
        {
        }
        
        public EliminarPersonaRequest(rsPersona.EliminarPersonaRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class EliminarPersonaRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int id;
        
        public EliminarPersonaRequestBody()
        {
        }
        
        public EliminarPersonaRequestBody(int id)
        {
            this.id = id;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class EliminarPersonaResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="EliminarPersonaResponse", Namespace="http://tempuri.org/", Order=0)]
        public rsPersona.EliminarPersonaResponseBody Body;
        
        public EliminarPersonaResponse()
        {
        }
        
        public EliminarPersonaResponse(rsPersona.EliminarPersonaResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class EliminarPersonaResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string EliminarPersonaResult;
        
        public EliminarPersonaResponseBody()
        {
        }
        
        public EliminarPersonaResponseBody(string EliminarPersonaResult)
        {
            this.EliminarPersonaResult = EliminarPersonaResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public interface wsPersonaSoapChannel : rsPersona.wsPersonaSoap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public partial class wsPersonaSoapClient : System.ServiceModel.ClientBase<rsPersona.wsPersonaSoap>, rsPersona.wsPersonaSoap
    {
        
        /// <summary>
        /// Implemente este método parcial para configurar el punto de conexión de servicio.
        /// </summary>
        /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
        /// <param name="clientCredentials">Credenciales de cliente</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public wsPersonaSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(wsPersonaSoapClient.GetBindingForEndpoint(endpointConfiguration), wsPersonaSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public wsPersonaSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(wsPersonaSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public wsPersonaSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(wsPersonaSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public wsPersonaSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        rsPersona.ObtenerPersonasResponse rsPersona.wsPersonaSoap.ObtenerPersonas(rsPersona.ObtenerPersonasRequest request)
        {
            return base.Channel.ObtenerPersonas(request);
        }
        
        public rsPersona.Persona[] ObtenerPersonas()
        {
            rsPersona.ObtenerPersonasRequest inValue = new rsPersona.ObtenerPersonasRequest();
            inValue.Body = new rsPersona.ObtenerPersonasRequestBody();
            rsPersona.ObtenerPersonasResponse retVal = ((rsPersona.wsPersonaSoap)(this)).ObtenerPersonas(inValue);
            return retVal.Body.ObtenerPersonasResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<rsPersona.ObtenerPersonasResponse> rsPersona.wsPersonaSoap.ObtenerPersonasAsync(rsPersona.ObtenerPersonasRequest request)
        {
            return base.Channel.ObtenerPersonasAsync(request);
        }
        
        public System.Threading.Tasks.Task<rsPersona.ObtenerPersonasResponse> ObtenerPersonasAsync()
        {
            rsPersona.ObtenerPersonasRequest inValue = new rsPersona.ObtenerPersonasRequest();
            inValue.Body = new rsPersona.ObtenerPersonasRequestBody();
            return ((rsPersona.wsPersonaSoap)(this)).ObtenerPersonasAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        rsPersona.AgregarPersonaResponse rsPersona.wsPersonaSoap.AgregarPersona(rsPersona.AgregarPersonaRequest request)
        {
            return base.Channel.AgregarPersona(request);
        }
        
        public string AgregarPersona(string nombre, int edad)
        {
            rsPersona.AgregarPersonaRequest inValue = new rsPersona.AgregarPersonaRequest();
            inValue.Body = new rsPersona.AgregarPersonaRequestBody();
            inValue.Body.nombre = nombre;
            inValue.Body.edad = edad;
            rsPersona.AgregarPersonaResponse retVal = ((rsPersona.wsPersonaSoap)(this)).AgregarPersona(inValue);
            return retVal.Body.AgregarPersonaResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<rsPersona.AgregarPersonaResponse> rsPersona.wsPersonaSoap.AgregarPersonaAsync(rsPersona.AgregarPersonaRequest request)
        {
            return base.Channel.AgregarPersonaAsync(request);
        }
        
        public System.Threading.Tasks.Task<rsPersona.AgregarPersonaResponse> AgregarPersonaAsync(string nombre, int edad)
        {
            rsPersona.AgregarPersonaRequest inValue = new rsPersona.AgregarPersonaRequest();
            inValue.Body = new rsPersona.AgregarPersonaRequestBody();
            inValue.Body.nombre = nombre;
            inValue.Body.edad = edad;
            return ((rsPersona.wsPersonaSoap)(this)).AgregarPersonaAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        rsPersona.ActualizarPersonaResponse rsPersona.wsPersonaSoap.ActualizarPersona(rsPersona.ActualizarPersonaRequest request)
        {
            return base.Channel.ActualizarPersona(request);
        }
        
        public string ActualizarPersona(int id, string nombre, int edad)
        {
            rsPersona.ActualizarPersonaRequest inValue = new rsPersona.ActualizarPersonaRequest();
            inValue.Body = new rsPersona.ActualizarPersonaRequestBody();
            inValue.Body.id = id;
            inValue.Body.nombre = nombre;
            inValue.Body.edad = edad;
            rsPersona.ActualizarPersonaResponse retVal = ((rsPersona.wsPersonaSoap)(this)).ActualizarPersona(inValue);
            return retVal.Body.ActualizarPersonaResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<rsPersona.ActualizarPersonaResponse> rsPersona.wsPersonaSoap.ActualizarPersonaAsync(rsPersona.ActualizarPersonaRequest request)
        {
            return base.Channel.ActualizarPersonaAsync(request);
        }
        
        public System.Threading.Tasks.Task<rsPersona.ActualizarPersonaResponse> ActualizarPersonaAsync(int id, string nombre, int edad)
        {
            rsPersona.ActualizarPersonaRequest inValue = new rsPersona.ActualizarPersonaRequest();
            inValue.Body = new rsPersona.ActualizarPersonaRequestBody();
            inValue.Body.id = id;
            inValue.Body.nombre = nombre;
            inValue.Body.edad = edad;
            return ((rsPersona.wsPersonaSoap)(this)).ActualizarPersonaAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        rsPersona.EliminarPersonaResponse rsPersona.wsPersonaSoap.EliminarPersona(rsPersona.EliminarPersonaRequest request)
        {
            return base.Channel.EliminarPersona(request);
        }
        
        public string EliminarPersona(int id)
        {
            rsPersona.EliminarPersonaRequest inValue = new rsPersona.EliminarPersonaRequest();
            inValue.Body = new rsPersona.EliminarPersonaRequestBody();
            inValue.Body.id = id;
            rsPersona.EliminarPersonaResponse retVal = ((rsPersona.wsPersonaSoap)(this)).EliminarPersona(inValue);
            return retVal.Body.EliminarPersonaResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<rsPersona.EliminarPersonaResponse> rsPersona.wsPersonaSoap.EliminarPersonaAsync(rsPersona.EliminarPersonaRequest request)
        {
            return base.Channel.EliminarPersonaAsync(request);
        }
        
        public System.Threading.Tasks.Task<rsPersona.EliminarPersonaResponse> EliminarPersonaAsync(int id)
        {
            rsPersona.EliminarPersonaRequest inValue = new rsPersona.EliminarPersonaRequest();
            inValue.Body = new rsPersona.EliminarPersonaRequestBody();
            inValue.Body.id = id;
            return ((rsPersona.wsPersonaSoap)(this)).EliminarPersonaAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.wsPersonaSoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.wsPersonaSoap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpTransportBindingElement httpBindingElement = new System.ServiceModel.Channels.HttpTransportBindingElement();
                httpBindingElement.AllowCookies = true;
                httpBindingElement.MaxBufferSize = int.MaxValue;
                httpBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.wsPersonaSoap))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:56116/wsPersona.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.wsPersonaSoap12))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:56116/wsPersona.asmx");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            wsPersonaSoap,
            
            wsPersonaSoap12,
        }
    }
}
