﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.237
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 4.0.50826.0
// 
namespace SlvHanbaiClient.svcUser {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EntityBase", Namespace="http://schemas.datacontract.org/2004/07/SlvHanbai.Web.Class.Entity")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SlvHanbaiClient.svcUser.EntityUser))]
    public partial class EntityBase : object, System.ComponentModel.INotifyPropertyChanged {
        
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
    [System.Runtime.Serialization.DataContractAttribute(Name="EntityUser", Namespace="http://schemas.datacontract.org/2004/07/SlvHanbai.Web.Class.Entity")]
    public partial class EntityUser : SlvHanbaiClient.svcUser.EntityBase {
        
        private string _after_login_idField;
        
        private int _company_idField;
        
        private string _company_nmField;
        
        private int _display_division_idField;
        
        private string _display_division_nmField;
        
        private int _group_idField;
        
        private string _group_nmField;
        
        private int _idField;
        
        private int _lock_flgField;
        
        private string _login_idField;
        
        private string _login_passwordField;
        
        private string _memoField;
        
        private string _nameField;
        
        private int _person_idField;
        
        private string _person_nmField;
        
        private string messageField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _after_login_id {
            get {
                return this._after_login_idField;
            }
            set {
                if ((object.ReferenceEquals(this._after_login_idField, value) != true)) {
                    this._after_login_idField = value;
                    this.RaisePropertyChanged("_after_login_id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int _company_id {
            get {
                return this._company_idField;
            }
            set {
                if ((this._company_idField.Equals(value) != true)) {
                    this._company_idField = value;
                    this.RaisePropertyChanged("_company_id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _company_nm {
            get {
                return this._company_nmField;
            }
            set {
                if ((object.ReferenceEquals(this._company_nmField, value) != true)) {
                    this._company_nmField = value;
                    this.RaisePropertyChanged("_company_nm");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int _display_division_id {
            get {
                return this._display_division_idField;
            }
            set {
                if ((this._display_division_idField.Equals(value) != true)) {
                    this._display_division_idField = value;
                    this.RaisePropertyChanged("_display_division_id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _display_division_nm {
            get {
                return this._display_division_nmField;
            }
            set {
                if ((object.ReferenceEquals(this._display_division_nmField, value) != true)) {
                    this._display_division_nmField = value;
                    this.RaisePropertyChanged("_display_division_nm");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int _group_id {
            get {
                return this._group_idField;
            }
            set {
                if ((this._group_idField.Equals(value) != true)) {
                    this._group_idField = value;
                    this.RaisePropertyChanged("_group_id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _group_nm {
            get {
                return this._group_nmField;
            }
            set {
                if ((object.ReferenceEquals(this._group_nmField, value) != true)) {
                    this._group_nmField = value;
                    this.RaisePropertyChanged("_group_nm");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int _id {
            get {
                return this._idField;
            }
            set {
                if ((this._idField.Equals(value) != true)) {
                    this._idField = value;
                    this.RaisePropertyChanged("_id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int _lock_flg {
            get {
                return this._lock_flgField;
            }
            set {
                if ((this._lock_flgField.Equals(value) != true)) {
                    this._lock_flgField = value;
                    this.RaisePropertyChanged("_lock_flg");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _login_id {
            get {
                return this._login_idField;
            }
            set {
                if ((object.ReferenceEquals(this._login_idField, value) != true)) {
                    this._login_idField = value;
                    this.RaisePropertyChanged("_login_id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _login_password {
            get {
                return this._login_passwordField;
            }
            set {
                if ((object.ReferenceEquals(this._login_passwordField, value) != true)) {
                    this._login_passwordField = value;
                    this.RaisePropertyChanged("_login_password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _memo {
            get {
                return this._memoField;
            }
            set {
                if ((object.ReferenceEquals(this._memoField, value) != true)) {
                    this._memoField = value;
                    this.RaisePropertyChanged("_memo");
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
        public int _person_id {
            get {
                return this._person_idField;
            }
            set {
                if ((this._person_idField.Equals(value) != true)) {
                    this._person_idField = value;
                    this.RaisePropertyChanged("_person_id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _person_nm {
            get {
                return this._person_nmField;
            }
            set {
                if ((object.ReferenceEquals(this._person_nmField, value) != true)) {
                    this._person_nmField = value;
                    this.RaisePropertyChanged("_person_nm");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string message {
            get {
                return this.messageField;
            }
            set {
                if ((object.ReferenceEquals(this.messageField, value) != true)) {
                    this.messageField = value;
                    this.RaisePropertyChanged("message");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="", ConfigurationName="svcUser.svcUser")]
    public interface svcUser {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:svcUser/GetUser", ReplyAction="urn:svcUser/GetUserResponse")]
        System.IAsyncResult BeginGetUser(string random, int Id, System.AsyncCallback callback, object asyncState);
        
        SlvHanbaiClient.svcUser.EntityUser EndGetUser(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:svcUser/UpdateUser", ReplyAction="urn:svcUser/UpdateUserResponse")]
        System.IAsyncResult BeginUpdateUser(string random, int type, long Id, SlvHanbaiClient.svcUser.EntityUser entity, System.AsyncCallback callback, object asyncState);
        
        string EndUpdateUser(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface svcUserChannel : SlvHanbaiClient.svcUser.svcUser, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public SlvHanbaiClient.svcUser.EntityUser Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((SlvHanbaiClient.svcUser.EntityUser)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UpdateUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public UpdateUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public partial class svcUserClient : System.ServiceModel.ClientBase<SlvHanbaiClient.svcUser.svcUser>, SlvHanbaiClient.svcUser.svcUser {
        
        private BeginOperationDelegate onBeginGetUserDelegate;
        
        private EndOperationDelegate onEndGetUserDelegate;
        
        private System.Threading.SendOrPostCallback onGetUserCompletedDelegate;
        
        private BeginOperationDelegate onBeginUpdateUserDelegate;
        
        private EndOperationDelegate onEndUpdateUserDelegate;
        
        private System.Threading.SendOrPostCallback onUpdateUserCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public svcUserClient() {
        }
        
        public svcUserClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public svcUserClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public svcUserClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public svcUserClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
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
                    throw new System.InvalidOperationException("CookieContainer を設定できません。バインドに HttpCookieContainerBindingElement が含まれていることを確認してくだ" +
                            "さい。");
                }
            }
        }
        
        public event System.EventHandler<GetUserCompletedEventArgs> GetUserCompleted;
        
        public event System.EventHandler<UpdateUserCompletedEventArgs> UpdateUserCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult SlvHanbaiClient.svcUser.svcUser.BeginGetUser(string random, int Id, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetUser(random, Id, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SlvHanbaiClient.svcUser.EntityUser SlvHanbaiClient.svcUser.svcUser.EndGetUser(System.IAsyncResult result) {
            return base.Channel.EndGetUser(result);
        }
        
        private System.IAsyncResult OnBeginGetUser(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string random = ((string)(inValues[0]));
            int Id = ((int)(inValues[1]));
            return ((SlvHanbaiClient.svcUser.svcUser)(this)).BeginGetUser(random, Id, callback, asyncState);
        }
        
        private object[] OnEndGetUser(System.IAsyncResult result) {
            SlvHanbaiClient.svcUser.EntityUser retVal = ((SlvHanbaiClient.svcUser.svcUser)(this)).EndGetUser(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetUserCompleted(object state) {
            if ((this.GetUserCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetUserCompleted(this, new GetUserCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetUserAsync(string random, int Id) {
            this.GetUserAsync(random, Id, null);
        }
        
        public void GetUserAsync(string random, int Id, object userState) {
            if ((this.onBeginGetUserDelegate == null)) {
                this.onBeginGetUserDelegate = new BeginOperationDelegate(this.OnBeginGetUser);
            }
            if ((this.onEndGetUserDelegate == null)) {
                this.onEndGetUserDelegate = new EndOperationDelegate(this.OnEndGetUser);
            }
            if ((this.onGetUserCompletedDelegate == null)) {
                this.onGetUserCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetUserCompleted);
            }
            base.InvokeAsync(this.onBeginGetUserDelegate, new object[] {
                        random,
                        Id}, this.onEndGetUserDelegate, this.onGetUserCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult SlvHanbaiClient.svcUser.svcUser.BeginUpdateUser(string random, int type, long Id, SlvHanbaiClient.svcUser.EntityUser entity, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginUpdateUser(random, type, Id, entity, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        string SlvHanbaiClient.svcUser.svcUser.EndUpdateUser(System.IAsyncResult result) {
            return base.Channel.EndUpdateUser(result);
        }
        
        private System.IAsyncResult OnBeginUpdateUser(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string random = ((string)(inValues[0]));
            int type = ((int)(inValues[1]));
            long Id = ((long)(inValues[2]));
            SlvHanbaiClient.svcUser.EntityUser entity = ((SlvHanbaiClient.svcUser.EntityUser)(inValues[3]));
            return ((SlvHanbaiClient.svcUser.svcUser)(this)).BeginUpdateUser(random, type, Id, entity, callback, asyncState);
        }
        
        private object[] OnEndUpdateUser(System.IAsyncResult result) {
            string retVal = ((SlvHanbaiClient.svcUser.svcUser)(this)).EndUpdateUser(result);
            return new object[] {
                    retVal};
        }
        
        private void OnUpdateUserCompleted(object state) {
            if ((this.UpdateUserCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.UpdateUserCompleted(this, new UpdateUserCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void UpdateUserAsync(string random, int type, long Id, SlvHanbaiClient.svcUser.EntityUser entity) {
            this.UpdateUserAsync(random, type, Id, entity, null);
        }
        
        public void UpdateUserAsync(string random, int type, long Id, SlvHanbaiClient.svcUser.EntityUser entity, object userState) {
            if ((this.onBeginUpdateUserDelegate == null)) {
                this.onBeginUpdateUserDelegate = new BeginOperationDelegate(this.OnBeginUpdateUser);
            }
            if ((this.onEndUpdateUserDelegate == null)) {
                this.onEndUpdateUserDelegate = new EndOperationDelegate(this.OnEndUpdateUser);
            }
            if ((this.onUpdateUserCompletedDelegate == null)) {
                this.onUpdateUserCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnUpdateUserCompleted);
            }
            base.InvokeAsync(this.onBeginUpdateUserDelegate, new object[] {
                        random,
                        type,
                        Id,
                        entity}, this.onEndUpdateUserDelegate, this.onUpdateUserCompletedDelegate, userState);
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
        
        protected override SlvHanbaiClient.svcUser.svcUser CreateChannel() {
            return new svcUserClientChannel(this);
        }
        
        private class svcUserClientChannel : ChannelBase<SlvHanbaiClient.svcUser.svcUser>, SlvHanbaiClient.svcUser.svcUser {
            
            public svcUserClientChannel(System.ServiceModel.ClientBase<SlvHanbaiClient.svcUser.svcUser> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginGetUser(string random, int Id, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[2];
                _args[0] = random;
                _args[1] = Id;
                System.IAsyncResult _result = base.BeginInvoke("GetUser", _args, callback, asyncState);
                return _result;
            }
            
            public SlvHanbaiClient.svcUser.EntityUser EndGetUser(System.IAsyncResult result) {
                object[] _args = new object[0];
                SlvHanbaiClient.svcUser.EntityUser _result = ((SlvHanbaiClient.svcUser.EntityUser)(base.EndInvoke("GetUser", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginUpdateUser(string random, int type, long Id, SlvHanbaiClient.svcUser.EntityUser entity, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[4];
                _args[0] = random;
                _args[1] = type;
                _args[2] = Id;
                _args[3] = entity;
                System.IAsyncResult _result = base.BeginInvoke("UpdateUser", _args, callback, asyncState);
                return _result;
            }
            
            public string EndUpdateUser(System.IAsyncResult result) {
                object[] _args = new object[0];
                string _result = ((string)(base.EndInvoke("UpdateUser", _args, result)));
                return _result;
            }
        }
    }
}
