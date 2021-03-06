﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 14.0.23107.0
// 
namespace Client_trivia_Aluma_Gelbard.RemoteDatabaseService {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Score", Namespace="http://schemas.datacontract.org/2004/07/triviaService")]
    public partial class Score : object, System.ComponentModel.INotifyPropertyChanged {
        
        private float fastest_timeField;
        
        private int highest_scoreField;
        
        private int idField;
        
        private int late_scoreField;
        
        private int longest_strikeField;
        
        private int scoreField;
        
        private int user_idField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float fastest_time {
            get {
                return this.fastest_timeField;
            }
            set {
                if ((this.fastest_timeField.Equals(value) != true)) {
                    this.fastest_timeField = value;
                    this.RaisePropertyChanged("fastest_time");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int highest_score {
            get {
                return this.highest_scoreField;
            }
            set {
                if ((this.highest_scoreField.Equals(value) != true)) {
                    this.highest_scoreField = value;
                    this.RaisePropertyChanged("highest_score");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int late_score {
            get {
                return this.late_scoreField;
            }
            set {
                if ((this.late_scoreField.Equals(value) != true)) {
                    this.late_scoreField = value;
                    this.RaisePropertyChanged("late_score");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int longest_strike {
            get {
                return this.longest_strikeField;
            }
            set {
                if ((this.longest_strikeField.Equals(value) != true)) {
                    this.longest_strikeField = value;
                    this.RaisePropertyChanged("longest_strike");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int score {
            get {
                return this.scoreField;
            }
            set {
                if ((this.scoreField.Equals(value) != true)) {
                    this.scoreField = value;
                    this.RaisePropertyChanged("score");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int user_id {
            get {
                return this.user_idField;
            }
            set {
                if ((this.user_idField.Equals(value) != true)) {
                    this.user_idField = value;
                    this.RaisePropertyChanged("user_id");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RemoteDatabaseService.ITriviaService")]
    public interface ITriviaService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITriviaService/SaveScore", ReplyAction="http://tempuri.org/ITriviaService/SaveScoreResponse")]
        System.Threading.Tasks.Task<bool> SaveScoreAsync(Client_trivia_Aluma_Gelbard.RemoteDatabaseService.Score score);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITriviaService/DeleteScore", ReplyAction="http://tempuri.org/ITriviaService/DeleteScoreResponse")]
        System.Threading.Tasks.Task<bool> DeleteScoreAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITriviaService/UpdateScore", ReplyAction="http://tempuri.org/ITriviaService/UpdateScoreResponse")]
        System.Threading.Tasks.Task<bool> UpdateScoreAsync(Client_trivia_Aluma_Gelbard.RemoteDatabaseService.Score score);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITriviaService/SelectAll", ReplyAction="http://tempuri.org/ITriviaService/SelectAllResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Client_trivia_Aluma_Gelbard.RemoteDatabaseService.Score>> SelectAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITriviaService/GetUserScore", ReplyAction="http://tempuri.org/ITriviaService/GetUserScoreResponse")]
        System.Threading.Tasks.Task<Client_trivia_Aluma_Gelbard.RemoteDatabaseService.Score> GetUserScoreAsync(int user_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITriviaService/GetTop10Score", ReplyAction="http://tempuri.org/ITriviaService/GetTop10ScoreResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Client_trivia_Aluma_Gelbard.RemoteDatabaseService.Score>> GetTop10ScoreAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITriviaServiceChannel : Client_trivia_Aluma_Gelbard.RemoteDatabaseService.ITriviaService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TriviaServiceClient : System.ServiceModel.ClientBase<Client_trivia_Aluma_Gelbard.RemoteDatabaseService.ITriviaService>, Client_trivia_Aluma_Gelbard.RemoteDatabaseService.ITriviaService {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public TriviaServiceClient() : 
                base(TriviaServiceClient.GetDefaultBinding(), TriviaServiceClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_ITriviaService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TriviaServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(TriviaServiceClient.GetBindingForEndpoint(endpointConfiguration), TriviaServiceClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TriviaServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(TriviaServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TriviaServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(TriviaServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TriviaServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task<bool> SaveScoreAsync(Client_trivia_Aluma_Gelbard.RemoteDatabaseService.Score score) {
            return base.Channel.SaveScoreAsync(score);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteScoreAsync(int id) {
            return base.Channel.DeleteScoreAsync(id);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateScoreAsync(Client_trivia_Aluma_Gelbard.RemoteDatabaseService.Score score) {
            return base.Channel.UpdateScoreAsync(score);
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Client_trivia_Aluma_Gelbard.RemoteDatabaseService.Score>> SelectAllAsync() {
            return base.Channel.SelectAllAsync();
        }
        
        public System.Threading.Tasks.Task<Client_trivia_Aluma_Gelbard.RemoteDatabaseService.Score> GetUserScoreAsync(int user_id) {
            return base.Channel.GetUserScoreAsync(user_id);
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Client_trivia_Aluma_Gelbard.RemoteDatabaseService.Score>> GetTop10ScoreAsync() {
            return base.Channel.GetTop10ScoreAsync();
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ITriviaService)) {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ITriviaService)) {
                return new System.ServiceModel.EndpointAddress("http://localhost:8733/Design_Time_Addresses/triviaService/TriviaService/");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return TriviaServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_ITriviaService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return TriviaServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_ITriviaService);
        }
        
        public enum EndpointConfiguration {
            
            BasicHttpBinding_ITriviaService,
        }
    }
}
