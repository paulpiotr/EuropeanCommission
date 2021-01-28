﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//
//     Zmiany w tym pliku mogą spowodować niewłaściwe zachowanie i zostaną utracone
//     w przypadku ponownego wygenerowania kodu.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ViesServiceReference
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat", ConfigurationName="ViesServiceReference.checkVatPortType")]
    public interface checkVatPortType
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        ViesServiceReference.checkVatResponse checkVat(ViesServiceReference.checkVatRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<ViesServiceReference.checkVatResponse> checkVatAsync(ViesServiceReference.checkVatRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        ViesServiceReference.checkVatApproxResponse checkVatApprox(ViesServiceReference.checkVatApproxRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<ViesServiceReference.checkVatApproxResponse> checkVatApproxAsync(ViesServiceReference.checkVatApproxRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="checkVat", WrapperNamespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", IsWrapped=true)]
    public partial class checkVatRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=0)]
        public string countryCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=1)]
        public string vatNumber;
        
        public checkVatRequest()
        {
        }
        
        public checkVatRequest(string countryCode, string vatNumber)
        {
            this.countryCode = countryCode;
            this.vatNumber = vatNumber;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="checkVatResponse", WrapperNamespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", IsWrapped=true)]
    public partial class checkVatResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=0)]
        public string countryCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=1)]
        public string vatNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime requestDate;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=3)]
        public bool valid;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=4)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string name;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=5)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string address;
        
        public checkVatResponse()
        {
        }
        
        public checkVatResponse(string countryCode, string vatNumber, System.DateTime requestDate, bool valid, string name, string address)
        {
            this.countryCode = countryCode;
            this.vatNumber = vatNumber;
            this.requestDate = requestDate;
            this.valid = valid;
            this.name = name;
            this.address = address;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types")]
    public enum matchCode
    {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1")]
        Item1,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2")]
        Item2,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("3")]
        Item3,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="checkVatApprox", WrapperNamespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", IsWrapped=true)]
    public partial class checkVatApproxRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=0)]
        public string countryCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=1)]
        public string vatNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=2)]
        public string traderName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=3)]
        public string traderCompanyType;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=4)]
        public string traderStreet;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=5)]
        public string traderPostcode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=6)]
        public string traderCity;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=7)]
        public string requesterCountryCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=8)]
        public string requesterVatNumber;
        
        public checkVatApproxRequest()
        {
        }
        
        public checkVatApproxRequest(string countryCode, string vatNumber, string traderName, string traderCompanyType, string traderStreet, string traderPostcode, string traderCity, string requesterCountryCode, string requesterVatNumber)
        {
            this.countryCode = countryCode;
            this.vatNumber = vatNumber;
            this.traderName = traderName;
            this.traderCompanyType = traderCompanyType;
            this.traderStreet = traderStreet;
            this.traderPostcode = traderPostcode;
            this.traderCity = traderCity;
            this.requesterCountryCode = requesterCountryCode;
            this.requesterVatNumber = requesterVatNumber;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="checkVatApproxResponse", WrapperNamespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", IsWrapped=true)]
    public partial class checkVatApproxResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=0)]
        public string countryCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=1)]
        public string vatNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime requestDate;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=3)]
        public bool valid;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=4)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string traderName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=5)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string traderCompanyType;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=6)]
        public string traderAddress;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=7)]
        public string traderStreet;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=8)]
        public string traderPostcode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=9)]
        public string traderCity;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=10)]
        public ViesServiceReference.matchCode traderNameMatch;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=11)]
        public ViesServiceReference.matchCode traderCompanyTypeMatch;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=12)]
        public ViesServiceReference.matchCode traderStreetMatch;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=13)]
        public ViesServiceReference.matchCode traderPostcodeMatch;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=14)]
        public ViesServiceReference.matchCode traderCityMatch;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=15)]
        public string requestIdentifier;
        
        public checkVatApproxResponse()
        {
        }
        
        public checkVatApproxResponse(
                    string countryCode, 
                    string vatNumber, 
                    System.DateTime requestDate, 
                    bool valid, 
                    string traderName, 
                    string traderCompanyType, 
                    string traderAddress, 
                    string traderStreet, 
                    string traderPostcode, 
                    string traderCity, 
                    ViesServiceReference.matchCode traderNameMatch, 
                    ViesServiceReference.matchCode traderCompanyTypeMatch, 
                    ViesServiceReference.matchCode traderStreetMatch, 
                    ViesServiceReference.matchCode traderPostcodeMatch, 
                    ViesServiceReference.matchCode traderCityMatch, 
                    string requestIdentifier)
        {
            this.countryCode = countryCode;
            this.vatNumber = vatNumber;
            this.requestDate = requestDate;
            this.valid = valid;
            this.traderName = traderName;
            this.traderCompanyType = traderCompanyType;
            this.traderAddress = traderAddress;
            this.traderStreet = traderStreet;
            this.traderPostcode = traderPostcode;
            this.traderCity = traderCity;
            this.traderNameMatch = traderNameMatch;
            this.traderCompanyTypeMatch = traderCompanyTypeMatch;
            this.traderStreetMatch = traderStreetMatch;
            this.traderPostcodeMatch = traderPostcodeMatch;
            this.traderCityMatch = traderCityMatch;
            this.requestIdentifier = requestIdentifier;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface checkVatPortTypeChannel : ViesServiceReference.checkVatPortType, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class checkVatPortTypeClient : System.ServiceModel.ClientBase<ViesServiceReference.checkVatPortType>, ViesServiceReference.checkVatPortType
    {
        
        /// <summary>
        /// Wdróż tę metodę częściową, aby skonfigurować punkt końcowy usługi.
        /// </summary>
        /// <param name="serviceEndpoint">Punkt końcowy do skonfigurowania</param>
        /// <param name="clientCredentials">Poświadczenia klienta</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public checkVatPortTypeClient() : 
                base(checkVatPortTypeClient.GetDefaultBinding(), checkVatPortTypeClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.checkVatPort.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public checkVatPortTypeClient(EndpointConfiguration endpointConfiguration) : 
                base(checkVatPortTypeClient.GetBindingForEndpoint(endpointConfiguration), checkVatPortTypeClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public checkVatPortTypeClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(checkVatPortTypeClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public checkVatPortTypeClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(checkVatPortTypeClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public checkVatPortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public ViesServiceReference.checkVatResponse checkVat(ViesServiceReference.checkVatRequest request)
        {
            return base.Channel.checkVat(request);
        }
        
        public System.Threading.Tasks.Task<ViesServiceReference.checkVatResponse> checkVatAsync(ViesServiceReference.checkVatRequest request)
        {
            return base.Channel.checkVatAsync(request);
        }
        
        public ViesServiceReference.checkVatApproxResponse checkVatApprox(ViesServiceReference.checkVatApproxRequest request)
        {
            return base.Channel.checkVatApprox(request);
        }
        
        public System.Threading.Tasks.Task<ViesServiceReference.checkVatApproxResponse> checkVatApproxAsync(ViesServiceReference.checkVatApproxRequest request)
        {
            return base.Channel.checkVatApproxAsync(request);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.checkVatPort))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Nie można znaleźć punktu końcowego o nazwie „{0}”.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.checkVatPort))
            {
                return new System.ServiceModel.EndpointAddress("http://ec.europa.eu/taxation_customs/vies/services/checkVatService");
            }
            throw new System.InvalidOperationException(string.Format("Nie można znaleźć punktu końcowego o nazwie „{0}”.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return checkVatPortTypeClient.GetBindingForEndpoint(EndpointConfiguration.checkVatPort);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return checkVatPortTypeClient.GetEndpointAddress(EndpointConfiguration.checkVatPort);
        }
        
        public enum EndpointConfiguration
        {
            
            checkVatPort,
        }
    }
}
