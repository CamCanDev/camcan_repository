﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.Phone.ServiceReference, version 3.7.0.0
// 
namespace CamCan.CamCanService {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Scenario", Namespace="http://schemas.datacontract.org/2004/07/CamCan_Service")]
    public partial class Scenario : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int _scenarioIDField;
        
        private string _scenarioInformationField;
        
        private string _videoLinkField;
        
        private int scenarioIDField;
        
        private string scenarioInformationField;
        
        private string videoLinkField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int _scenarioID {
            get {
                return this._scenarioIDField;
            }
            set {
                if ((this._scenarioIDField.Equals(value) != true)) {
                    this._scenarioIDField = value;
                    this.RaisePropertyChanged("_scenarioID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _scenarioInformation {
            get {
                return this._scenarioInformationField;
            }
            set {
                if ((object.ReferenceEquals(this._scenarioInformationField, value) != true)) {
                    this._scenarioInformationField = value;
                    this.RaisePropertyChanged("_scenarioInformation");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _videoLink {
            get {
                return this._videoLinkField;
            }
            set {
                if ((object.ReferenceEquals(this._videoLinkField, value) != true)) {
                    this._videoLinkField = value;
                    this.RaisePropertyChanged("_videoLink");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int scenarioID {
            get {
                return this.scenarioIDField;
            }
            set {
                if ((this.scenarioIDField.Equals(value) != true)) {
                    this.scenarioIDField = value;
                    this.RaisePropertyChanged("scenarioID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string scenarioInformation {
            get {
                return this.scenarioInformationField;
            }
            set {
                if ((object.ReferenceEquals(this.scenarioInformationField, value) != true)) {
                    this.scenarioInformationField = value;
                    this.RaisePropertyChanged("scenarioInformation");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string videoLink {
            get {
                return this.videoLinkField;
            }
            set {
                if ((object.ReferenceEquals(this.videoLinkField, value) != true)) {
                    this.videoLinkField = value;
                    this.RaisePropertyChanged("videoLink");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserProfile", Namespace="http://schemas.datacontract.org/2004/07/CamCan_Service")]
    public partial class UserProfile : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int _completedField;
        
        private string _nameField;
        
        private string _passwordField;
        
        private int completedField;
        
        private string nameField;
        
        private string passwordField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int _completed {
            get {
                return this._completedField;
            }
            set {
                if ((this._completedField.Equals(value) != true)) {
                    this._completedField = value;
                    this.RaisePropertyChanged("_completed");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _name {
            get {
                return this._nameField;
            }
            set {
                if ((object.ReferenceEquals(this._nameField, value) != true)) {
                    this._nameField = value;
                    this.RaisePropertyChanged("_name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _password {
            get {
                return this._passwordField;
            }
            set {
                if ((object.ReferenceEquals(this._passwordField, value) != true)) {
                    this._passwordField = value;
                    this.RaisePropertyChanged("_password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int completed {
            get {
                return this.completedField;
            }
            set {
                if ((this.completedField.Equals(value) != true)) {
                    this.completedField = value;
                    this.RaisePropertyChanged("completed");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string password {
            get {
                return this.passwordField;
            }
            set {
                if ((object.ReferenceEquals(this.passwordField, value) != true)) {
                    this.passwordField = value;
                    this.RaisePropertyChanged("password");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CamCanService.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService1/returnScenario", ReplyAction="http://tempuri.org/IService1/returnScenarioResponse")]
        System.IAsyncResult BeginreturnScenario(int id, System.AsyncCallback callback, object asyncState);
        
        CamCan.CamCanService.Scenario EndreturnScenario(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService1/returnComleted", ReplyAction="http://tempuri.org/IService1/returnComletedResponse")]
        System.IAsyncResult BeginreturnComleted(string user, string pass, System.AsyncCallback callback, object asyncState);
        
        int EndreturnComleted(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService1/returnUser", ReplyAction="http://tempuri.org/IService1/returnUserResponse")]
        System.IAsyncResult BeginreturnUser(string user, string pass, System.AsyncCallback callback, object asyncState);
        
        CamCan.CamCanService.UserProfile EndreturnUser(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService1/insertAnswer", ReplyAction="http://tempuri.org/IService1/insertAnswerResponse")]
        System.IAsyncResult BegininsertAnswer(string Empid, int ScenID, int QuestID, string resonse, string correct, System.AsyncCallback callback, object asyncState);
        
        string EndinsertAnswer(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : CamCan.CamCanService.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class returnScenarioCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public returnScenarioCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public CamCan.CamCanService.Scenario Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((CamCan.CamCanService.Scenario)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class returnComletedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public returnComletedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public int Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class returnUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public returnUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public CamCan.CamCanService.UserProfile Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((CamCan.CamCanService.UserProfile)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class insertAnswerCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public insertAnswerCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<CamCan.CamCanService.IService1>, CamCan.CamCanService.IService1 {
        
        private BeginOperationDelegate onBeginreturnScenarioDelegate;
        
        private EndOperationDelegate onEndreturnScenarioDelegate;
        
        private System.Threading.SendOrPostCallback onreturnScenarioCompletedDelegate;
        
        private BeginOperationDelegate onBeginreturnComletedDelegate;
        
        private EndOperationDelegate onEndreturnComletedDelegate;
        
        private System.Threading.SendOrPostCallback onreturnComletedCompletedDelegate;
        
        private BeginOperationDelegate onBeginreturnUserDelegate;
        
        private EndOperationDelegate onEndreturnUserDelegate;
        
        private System.Threading.SendOrPostCallback onreturnUserCompletedDelegate;
        
        private BeginOperationDelegate onBegininsertAnswerDelegate;
        
        private EndOperationDelegate onEndinsertAnswerDelegate;
        
        private System.Threading.SendOrPostCallback oninsertAnswerCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<returnScenarioCompletedEventArgs> returnScenarioCompleted;
        
        public event System.EventHandler<returnComletedCompletedEventArgs> returnComletedCompleted;
        
        public event System.EventHandler<returnUserCompletedEventArgs> returnUserCompleted;
        
        public event System.EventHandler<insertAnswerCompletedEventArgs> insertAnswerCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult CamCan.CamCanService.IService1.BeginreturnScenario(int id, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginreturnScenario(id, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        CamCan.CamCanService.Scenario CamCan.CamCanService.IService1.EndreturnScenario(System.IAsyncResult result) {
            return base.Channel.EndreturnScenario(result);
        }
        
        private System.IAsyncResult OnBeginreturnScenario(object[] inValues, System.AsyncCallback callback, object asyncState) {
            int id = ((int)(inValues[0]));
            return ((CamCan.CamCanService.IService1)(this)).BeginreturnScenario(id, callback, asyncState);
        }
        
        private object[] OnEndreturnScenario(System.IAsyncResult result) {
            CamCan.CamCanService.Scenario retVal = ((CamCan.CamCanService.IService1)(this)).EndreturnScenario(result);
            return new object[] {
                    retVal};
        }
        
        private void OnreturnScenarioCompleted(object state) {
            if ((this.returnScenarioCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.returnScenarioCompleted(this, new returnScenarioCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void returnScenarioAsync(int id) {
            this.returnScenarioAsync(id, null);
        }
        
        public void returnScenarioAsync(int id, object userState) {
            if ((this.onBeginreturnScenarioDelegate == null)) {
                this.onBeginreturnScenarioDelegate = new BeginOperationDelegate(this.OnBeginreturnScenario);
            }
            if ((this.onEndreturnScenarioDelegate == null)) {
                this.onEndreturnScenarioDelegate = new EndOperationDelegate(this.OnEndreturnScenario);
            }
            if ((this.onreturnScenarioCompletedDelegate == null)) {
                this.onreturnScenarioCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnreturnScenarioCompleted);
            }
            base.InvokeAsync(this.onBeginreturnScenarioDelegate, new object[] {
                        id}, this.onEndreturnScenarioDelegate, this.onreturnScenarioCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult CamCan.CamCanService.IService1.BeginreturnComleted(string user, string pass, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginreturnComleted(user, pass, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        int CamCan.CamCanService.IService1.EndreturnComleted(System.IAsyncResult result) {
            return base.Channel.EndreturnComleted(result);
        }
        
        private System.IAsyncResult OnBeginreturnComleted(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string user = ((string)(inValues[0]));
            string pass = ((string)(inValues[1]));
            return ((CamCan.CamCanService.IService1)(this)).BeginreturnComleted(user, pass, callback, asyncState);
        }
        
        private object[] OnEndreturnComleted(System.IAsyncResult result) {
            int retVal = ((CamCan.CamCanService.IService1)(this)).EndreturnComleted(result);
            return new object[] {
                    retVal};
        }
        
        private void OnreturnComletedCompleted(object state) {
            if ((this.returnComletedCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.returnComletedCompleted(this, new returnComletedCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void returnComletedAsync(string user, string pass) {
            this.returnComletedAsync(user, pass, null);
        }
        
        public void returnComletedAsync(string user, string pass, object userState) {
            if ((this.onBeginreturnComletedDelegate == null)) {
                this.onBeginreturnComletedDelegate = new BeginOperationDelegate(this.OnBeginreturnComleted);
            }
            if ((this.onEndreturnComletedDelegate == null)) {
                this.onEndreturnComletedDelegate = new EndOperationDelegate(this.OnEndreturnComleted);
            }
            if ((this.onreturnComletedCompletedDelegate == null)) {
                this.onreturnComletedCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnreturnComletedCompleted);
            }
            base.InvokeAsync(this.onBeginreturnComletedDelegate, new object[] {
                        user,
                        pass}, this.onEndreturnComletedDelegate, this.onreturnComletedCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult CamCan.CamCanService.IService1.BeginreturnUser(string user, string pass, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginreturnUser(user, pass, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        CamCan.CamCanService.UserProfile CamCan.CamCanService.IService1.EndreturnUser(System.IAsyncResult result) {
            return base.Channel.EndreturnUser(result);
        }
        
        private System.IAsyncResult OnBeginreturnUser(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string user = ((string)(inValues[0]));
            string pass = ((string)(inValues[1]));
            return ((CamCan.CamCanService.IService1)(this)).BeginreturnUser(user, pass, callback, asyncState);
        }
        
        private object[] OnEndreturnUser(System.IAsyncResult result) {
            CamCan.CamCanService.UserProfile retVal = ((CamCan.CamCanService.IService1)(this)).EndreturnUser(result);
            return new object[] {
                    retVal};
        }
        
        private void OnreturnUserCompleted(object state) {
            if ((this.returnUserCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.returnUserCompleted(this, new returnUserCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void returnUserAsync(string user, string pass) {
            this.returnUserAsync(user, pass, null);
        }
        
        public void returnUserAsync(string user, string pass, object userState) {
            if ((this.onBeginreturnUserDelegate == null)) {
                this.onBeginreturnUserDelegate = new BeginOperationDelegate(this.OnBeginreturnUser);
            }
            if ((this.onEndreturnUserDelegate == null)) {
                this.onEndreturnUserDelegate = new EndOperationDelegate(this.OnEndreturnUser);
            }
            if ((this.onreturnUserCompletedDelegate == null)) {
                this.onreturnUserCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnreturnUserCompleted);
            }
            base.InvokeAsync(this.onBeginreturnUserDelegate, new object[] {
                        user,
                        pass}, this.onEndreturnUserDelegate, this.onreturnUserCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult CamCan.CamCanService.IService1.BegininsertAnswer(string Empid, int ScenID, int QuestID, string resonse, string correct, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BegininsertAnswer(Empid, ScenID, QuestID, resonse, correct, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        string CamCan.CamCanService.IService1.EndinsertAnswer(System.IAsyncResult result) {
            return base.Channel.EndinsertAnswer(result);
        }
        
        private System.IAsyncResult OnBegininsertAnswer(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string Empid = ((string)(inValues[0]));
            int ScenID = ((int)(inValues[1]));
            int QuestID = ((int)(inValues[2]));
            string resonse = ((string)(inValues[3]));
            string correct = ((string)(inValues[4]));
            return ((CamCan.CamCanService.IService1)(this)).BegininsertAnswer(Empid, ScenID, QuestID, resonse, correct, callback, asyncState);
        }
        
        private object[] OnEndinsertAnswer(System.IAsyncResult result) {
            string retVal = ((CamCan.CamCanService.IService1)(this)).EndinsertAnswer(result);
            return new object[] {
                    retVal};
        }
        
        private void OninsertAnswerCompleted(object state) {
            if ((this.insertAnswerCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.insertAnswerCompleted(this, new insertAnswerCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void insertAnswerAsync(string Empid, int ScenID, int QuestID, string resonse, string correct) {
            this.insertAnswerAsync(Empid, ScenID, QuestID, resonse, correct, null);
        }
        
        public void insertAnswerAsync(string Empid, int ScenID, int QuestID, string resonse, string correct, object userState) {
            if ((this.onBegininsertAnswerDelegate == null)) {
                this.onBegininsertAnswerDelegate = new BeginOperationDelegate(this.OnBegininsertAnswer);
            }
            if ((this.onEndinsertAnswerDelegate == null)) {
                this.onEndinsertAnswerDelegate = new EndOperationDelegate(this.OnEndinsertAnswer);
            }
            if ((this.oninsertAnswerCompletedDelegate == null)) {
                this.oninsertAnswerCompletedDelegate = new System.Threading.SendOrPostCallback(this.OninsertAnswerCompleted);
            }
            base.InvokeAsync(this.onBegininsertAnswerDelegate, new object[] {
                        Empid,
                        ScenID,
                        QuestID,
                        resonse,
                        correct}, this.onEndinsertAnswerDelegate, this.oninsertAnswerCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override CamCan.CamCanService.IService1 CreateChannel() {
            return new Service1ClientChannel(this);
        }
        
        private class Service1ClientChannel : ChannelBase<CamCan.CamCanService.IService1>, CamCan.CamCanService.IService1 {
            
            public Service1ClientChannel(System.ServiceModel.ClientBase<CamCan.CamCanService.IService1> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginreturnScenario(int id, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = id;
                System.IAsyncResult _result = base.BeginInvoke("returnScenario", _args, callback, asyncState);
                return _result;
            }
            
            public CamCan.CamCanService.Scenario EndreturnScenario(System.IAsyncResult result) {
                object[] _args = new object[0];
                CamCan.CamCanService.Scenario _result = ((CamCan.CamCanService.Scenario)(base.EndInvoke("returnScenario", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginreturnComleted(string user, string pass, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[2];
                _args[0] = user;
                _args[1] = pass;
                System.IAsyncResult _result = base.BeginInvoke("returnComleted", _args, callback, asyncState);
                return _result;
            }
            
            public int EndreturnComleted(System.IAsyncResult result) {
                object[] _args = new object[0];
                int _result = ((int)(base.EndInvoke("returnComleted", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginreturnUser(string user, string pass, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[2];
                _args[0] = user;
                _args[1] = pass;
                System.IAsyncResult _result = base.BeginInvoke("returnUser", _args, callback, asyncState);
                return _result;
            }
            
            public CamCan.CamCanService.UserProfile EndreturnUser(System.IAsyncResult result) {
                object[] _args = new object[0];
                CamCan.CamCanService.UserProfile _result = ((CamCan.CamCanService.UserProfile)(base.EndInvoke("returnUser", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BegininsertAnswer(string Empid, int ScenID, int QuestID, string resonse, string correct, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[5];
                _args[0] = Empid;
                _args[1] = ScenID;
                _args[2] = QuestID;
                _args[3] = resonse;
                _args[4] = correct;
                System.IAsyncResult _result = base.BeginInvoke("insertAnswer", _args, callback, asyncState);
                return _result;
            }
            
            public string EndinsertAnswer(System.IAsyncResult result) {
                object[] _args = new object[0];
                string _result = ((string)(base.EndInvoke("insertAnswer", _args, result)));
                return _result;
            }
        }
    }
}