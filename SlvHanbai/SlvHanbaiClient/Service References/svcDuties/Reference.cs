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
namespace SlvHanbaiClient.svcDuties {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EntityDuties", Namespace="http://schemas.datacontract.org/2004/07/SlvHanbai.Web.Class.Entity")]
    public partial class EntityDuties : SlvHanbaiClient.svcDuties.EntityBase {
        
        private int _company_idField;
        
        private string _company_nmField;
        
        private string _contentField;
        
        private string _duties_date_timeField;
        
        private int _duties_level_idField;
        
        private string _duties_level_nmField;
        
        private int _duties_state_idField;
        
        private string _duties_state_nmField;
        
        private string _duties_timeField;
        
        private string _duties_ymdField;
        
        private int _gropu_idField;
        
        private string _gropu_nmField;
        
        private int _lock_flgField;
        
        private string _memoField;
        
        private long _noField;
        
        private int _person_idField;
        
        private string _person_nmField;
        
        private string _titleField;
        
        private string _upload_file_name1Field;
        
        private string _upload_file_name2Field;
        
        private string _upload_file_name3Field;
        
        private string _upload_file_name4Field;
        
        private string _upload_file_name5Field;
        
        private string _upload_file_path1Field;
        
        private string _upload_file_path2Field;
        
        private string _upload_file_path3Field;
        
        private string _upload_file_path4Field;
        
        private string _upload_file_path5Field;
        
        private string messageField;
        
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
        public string _content {
            get {
                return this._contentField;
            }
            set {
                if ((object.ReferenceEquals(this._contentField, value) != true)) {
                    this._contentField = value;
                    this.RaisePropertyChanged("_content");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _duties_date_time {
            get {
                return this._duties_date_timeField;
            }
            set {
                if ((object.ReferenceEquals(this._duties_date_timeField, value) != true)) {
                    this._duties_date_timeField = value;
                    this.RaisePropertyChanged("_duties_date_time");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int _duties_level_id {
            get {
                return this._duties_level_idField;
            }
            set {
                if ((this._duties_level_idField.Equals(value) != true)) {
                    this._duties_level_idField = value;
                    this.RaisePropertyChanged("_duties_level_id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _duties_level_nm {
            get {
                return this._duties_level_nmField;
            }
            set {
                if ((object.ReferenceEquals(this._duties_level_nmField, value) != true)) {
                    this._duties_level_nmField = value;
                    this.RaisePropertyChanged("_duties_level_nm");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int _duties_state_id {
            get {
                return this._duties_state_idField;
            }
            set {
                if ((this._duties_state_idField.Equals(value) != true)) {
                    this._duties_state_idField = value;
                    this.RaisePropertyChanged("_duties_state_id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _duties_state_nm {
            get {
                return this._duties_state_nmField;
            }
            set {
                if ((object.ReferenceEquals(this._duties_state_nmField, value) != true)) {
                    this._duties_state_nmField = value;
                    this.RaisePropertyChanged("_duties_state_nm");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _duties_time {
            get {
                return this._duties_timeField;
            }
            set {
                if ((object.ReferenceEquals(this._duties_timeField, value) != true)) {
                    this._duties_timeField = value;
                    this.RaisePropertyChanged("_duties_time");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _duties_ymd {
            get {
                return this._duties_ymdField;
            }
            set {
                if ((object.ReferenceEquals(this._duties_ymdField, value) != true)) {
                    this._duties_ymdField = value;
                    this.RaisePropertyChanged("_duties_ymd");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int _gropu_id {
            get {
                return this._gropu_idField;
            }
            set {
                if ((this._gropu_idField.Equals(value) != true)) {
                    this._gropu_idField = value;
                    this.RaisePropertyChanged("_gropu_id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _gropu_nm {
            get {
                return this._gropu_nmField;
            }
            set {
                if ((object.ReferenceEquals(this._gropu_nmField, value) != true)) {
                    this._gropu_nmField = value;
                    this.RaisePropertyChanged("_gropu_nm");
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
        public long _no {
            get {
                return this._noField;
            }
            set {
                if ((this._noField.Equals(value) != true)) {
                    this._noField = value;
                    this.RaisePropertyChanged("_no");
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
        public string _title {
            get {
                return this._titleField;
            }
            set {
                if ((object.ReferenceEquals(this._titleField, value) != true)) {
                    this._titleField = value;
                    this.RaisePropertyChanged("_title");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _upload_file_name1 {
            get {
                return this._upload_file_name1Field;
            }
            set {
                if ((object.ReferenceEquals(this._upload_file_name1Field, value) != true)) {
                    this._upload_file_name1Field = value;
                    this.RaisePropertyChanged("_upload_file_name1");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _upload_file_name2 {
            get {
                return this._upload_file_name2Field;
            }
            set {
                if ((object.ReferenceEquals(this._upload_file_name2Field, value) != true)) {
                    this._upload_file_name2Field = value;
                    this.RaisePropertyChanged("_upload_file_name2");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _upload_file_name3 {
            get {
                return this._upload_file_name3Field;
            }
            set {
                if ((object.ReferenceEquals(this._upload_file_name3Field, value) != true)) {
                    this._upload_file_name3Field = value;
                    this.RaisePropertyChanged("_upload_file_name3");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _upload_file_name4 {
            get {
                return this._upload_file_name4Field;
            }
            set {
                if ((object.ReferenceEquals(this._upload_file_name4Field, value) != true)) {
                    this._upload_file_name4Field = value;
                    this.RaisePropertyChanged("_upload_file_name4");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _upload_file_name5 {
            get {
                return this._upload_file_name5Field;
            }
            set {
                if ((object.ReferenceEquals(this._upload_file_name5Field, value) != true)) {
                    this._upload_file_name5Field = value;
                    this.RaisePropertyChanged("_upload_file_name5");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _upload_file_path1 {
            get {
                return this._upload_file_path1Field;
            }
            set {
                if ((object.ReferenceEquals(this._upload_file_path1Field, value) != true)) {
                    this._upload_file_path1Field = value;
                    this.RaisePropertyChanged("_upload_file_path1");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _upload_file_path2 {
            get {
                return this._upload_file_path2Field;
            }
            set {
                if ((object.ReferenceEquals(this._upload_file_path2Field, value) != true)) {
                    this._upload_file_path2Field = value;
                    this.RaisePropertyChanged("_upload_file_path2");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _upload_file_path3 {
            get {
                return this._upload_file_path3Field;
            }
            set {
                if ((object.ReferenceEquals(this._upload_file_path3Field, value) != true)) {
                    this._upload_file_path3Field = value;
                    this.RaisePropertyChanged("_upload_file_path3");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _upload_file_path4 {
            get {
                return this._upload_file_path4Field;
            }
            set {
                if ((object.ReferenceEquals(this._upload_file_path4Field, value) != true)) {
                    this._upload_file_path4Field = value;
                    this.RaisePropertyChanged("_upload_file_path4");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _upload_file_path5 {
            get {
                return this._upload_file_path5Field;
            }
            set {
                if ((object.ReferenceEquals(this._upload_file_path5Field, value) != true)) {
                    this._upload_file_path5Field = value;
                    this.RaisePropertyChanged("_upload_file_path5");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EntityBase", Namespace="http://schemas.datacontract.org/2004/07/SlvHanbai.Web.Class.Entity")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SlvHanbaiClient.svcDuties.EntityDuties))]
    public partial class EntityBase : object, System.ComponentModel.INotifyPropertyChanged {
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="", ConfigurationName="svcDuties.svcDuties")]
    public interface svcDuties {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:svcDuties/GetDuties", ReplyAction="urn:svcDuties/GetDutiesResponse")]
        System.IAsyncResult BeginGetDuties(string random, long no, int kbn, System.AsyncCallback callback, object asyncState);
        
        System.Collections.ObjectModel.ObservableCollection<SlvHanbaiClient.svcDuties.EntityDuties> EndGetDuties(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:svcDuties/UpdateDuties", ReplyAction="urn:svcDuties/UpdateDutiesResponse")]
        System.IAsyncResult BeginUpdateDuties(string random, int type, long no, SlvHanbaiClient.svcDuties.EntityDuties entity, System.AsyncCallback callback, object asyncState);
        
        string EndUpdateDuties(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface svcDutiesChannel : SlvHanbaiClient.svcDuties.svcDuties, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetDutiesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetDutiesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.ObjectModel.ObservableCollection<SlvHanbaiClient.svcDuties.EntityDuties> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.ObjectModel.ObservableCollection<SlvHanbaiClient.svcDuties.EntityDuties>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UpdateDutiesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public UpdateDutiesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public partial class svcDutiesClient : System.ServiceModel.ClientBase<SlvHanbaiClient.svcDuties.svcDuties>, SlvHanbaiClient.svcDuties.svcDuties {
        
        private BeginOperationDelegate onBeginGetDutiesDelegate;
        
        private EndOperationDelegate onEndGetDutiesDelegate;
        
        private System.Threading.SendOrPostCallback onGetDutiesCompletedDelegate;
        
        private BeginOperationDelegate onBeginUpdateDutiesDelegate;
        
        private EndOperationDelegate onEndUpdateDutiesDelegate;
        
        private System.Threading.SendOrPostCallback onUpdateDutiesCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public svcDutiesClient() {
        }
        
        public svcDutiesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public svcDutiesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public svcDutiesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public svcDutiesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
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
        
        public event System.EventHandler<GetDutiesCompletedEventArgs> GetDutiesCompleted;
        
        public event System.EventHandler<UpdateDutiesCompletedEventArgs> UpdateDutiesCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult SlvHanbaiClient.svcDuties.svcDuties.BeginGetDuties(string random, long no, int kbn, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetDuties(random, no, kbn, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Collections.ObjectModel.ObservableCollection<SlvHanbaiClient.svcDuties.EntityDuties> SlvHanbaiClient.svcDuties.svcDuties.EndGetDuties(System.IAsyncResult result) {
            return base.Channel.EndGetDuties(result);
        }
        
        private System.IAsyncResult OnBeginGetDuties(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string random = ((string)(inValues[0]));
            long no = ((long)(inValues[1]));
            int kbn = ((int)(inValues[2]));
            return ((SlvHanbaiClient.svcDuties.svcDuties)(this)).BeginGetDuties(random, no, kbn, callback, asyncState);
        }
        
        private object[] OnEndGetDuties(System.IAsyncResult result) {
            System.Collections.ObjectModel.ObservableCollection<SlvHanbaiClient.svcDuties.EntityDuties> retVal = ((SlvHanbaiClient.svcDuties.svcDuties)(this)).EndGetDuties(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetDutiesCompleted(object state) {
            if ((this.GetDutiesCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetDutiesCompleted(this, new GetDutiesCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetDutiesAsync(string random, long no, int kbn) {
            this.GetDutiesAsync(random, no, kbn, null);
        }
        
        public void GetDutiesAsync(string random, long no, int kbn, object userState) {
            if ((this.onBeginGetDutiesDelegate == null)) {
                this.onBeginGetDutiesDelegate = new BeginOperationDelegate(this.OnBeginGetDuties);
            }
            if ((this.onEndGetDutiesDelegate == null)) {
                this.onEndGetDutiesDelegate = new EndOperationDelegate(this.OnEndGetDuties);
            }
            if ((this.onGetDutiesCompletedDelegate == null)) {
                this.onGetDutiesCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetDutiesCompleted);
            }
            base.InvokeAsync(this.onBeginGetDutiesDelegate, new object[] {
                        random,
                        no,
                        kbn}, this.onEndGetDutiesDelegate, this.onGetDutiesCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult SlvHanbaiClient.svcDuties.svcDuties.BeginUpdateDuties(string random, int type, long no, SlvHanbaiClient.svcDuties.EntityDuties entity, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginUpdateDuties(random, type, no, entity, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        string SlvHanbaiClient.svcDuties.svcDuties.EndUpdateDuties(System.IAsyncResult result) {
            return base.Channel.EndUpdateDuties(result);
        }
        
        private System.IAsyncResult OnBeginUpdateDuties(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string random = ((string)(inValues[0]));
            int type = ((int)(inValues[1]));
            long no = ((long)(inValues[2]));
            SlvHanbaiClient.svcDuties.EntityDuties entity = ((SlvHanbaiClient.svcDuties.EntityDuties)(inValues[3]));
            return ((SlvHanbaiClient.svcDuties.svcDuties)(this)).BeginUpdateDuties(random, type, no, entity, callback, asyncState);
        }
        
        private object[] OnEndUpdateDuties(System.IAsyncResult result) {
            string retVal = ((SlvHanbaiClient.svcDuties.svcDuties)(this)).EndUpdateDuties(result);
            return new object[] {
                    retVal};
        }
        
        private void OnUpdateDutiesCompleted(object state) {
            if ((this.UpdateDutiesCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.UpdateDutiesCompleted(this, new UpdateDutiesCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void UpdateDutiesAsync(string random, int type, long no, SlvHanbaiClient.svcDuties.EntityDuties entity) {
            this.UpdateDutiesAsync(random, type, no, entity, null);
        }
        
        public void UpdateDutiesAsync(string random, int type, long no, SlvHanbaiClient.svcDuties.EntityDuties entity, object userState) {
            if ((this.onBeginUpdateDutiesDelegate == null)) {
                this.onBeginUpdateDutiesDelegate = new BeginOperationDelegate(this.OnBeginUpdateDuties);
            }
            if ((this.onEndUpdateDutiesDelegate == null)) {
                this.onEndUpdateDutiesDelegate = new EndOperationDelegate(this.OnEndUpdateDuties);
            }
            if ((this.onUpdateDutiesCompletedDelegate == null)) {
                this.onUpdateDutiesCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnUpdateDutiesCompleted);
            }
            base.InvokeAsync(this.onBeginUpdateDutiesDelegate, new object[] {
                        random,
                        type,
                        no,
                        entity}, this.onEndUpdateDutiesDelegate, this.onUpdateDutiesCompletedDelegate, userState);
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
        
        protected override SlvHanbaiClient.svcDuties.svcDuties CreateChannel() {
            return new svcDutiesClientChannel(this);
        }
        
        private class svcDutiesClientChannel : ChannelBase<SlvHanbaiClient.svcDuties.svcDuties>, SlvHanbaiClient.svcDuties.svcDuties {
            
            public svcDutiesClientChannel(System.ServiceModel.ClientBase<SlvHanbaiClient.svcDuties.svcDuties> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginGetDuties(string random, long no, int kbn, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[3];
                _args[0] = random;
                _args[1] = no;
                _args[2] = kbn;
                System.IAsyncResult _result = base.BeginInvoke("GetDuties", _args, callback, asyncState);
                return _result;
            }
            
            public System.Collections.ObjectModel.ObservableCollection<SlvHanbaiClient.svcDuties.EntityDuties> EndGetDuties(System.IAsyncResult result) {
                object[] _args = new object[0];
                System.Collections.ObjectModel.ObservableCollection<SlvHanbaiClient.svcDuties.EntityDuties> _result = ((System.Collections.ObjectModel.ObservableCollection<SlvHanbaiClient.svcDuties.EntityDuties>)(base.EndInvoke("GetDuties", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginUpdateDuties(string random, int type, long no, SlvHanbaiClient.svcDuties.EntityDuties entity, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[4];
                _args[0] = random;
                _args[1] = type;
                _args[2] = no;
                _args[3] = entity;
                System.IAsyncResult _result = base.BeginInvoke("UpdateDuties", _args, callback, asyncState);
                return _result;
            }
            
            public string EndUpdateDuties(System.IAsyncResult result) {
                object[] _args = new object[0];
                string _result = ((string)(base.EndInvoke("UpdateDuties", _args, result)));
                return _result;
            }
        }
    }
}