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
namespace SlvHanbaiClient.svcReport {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EntityBase", Namespace="http://schemas.datacontract.org/2004/07/SlvHanbai.Web.Class.Entity")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SlvHanbaiClient.svcReport.EntityReportSetting))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SlvHanbaiClient.svcReport.EntityReport))]
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
    [System.Runtime.Serialization.DataContractAttribute(Name="EntityReportSetting", Namespace="http://schemas.datacontract.org/2004/07/SlvHanbai.Web.Class.Entity")]
    public partial class EntityReportSetting : SlvHanbaiClient.svcReport.EntityBase {
        
        private double _bottom_marginField;
        
        private string _group_id_fromField;
        
        private string _group_id_toField;
        
        private string _group_nm_fromField;
        
        private string _group_nm_toField;
        
        private int _group_totalField;
        
        private double _left_marginField;
        
        private string _messageField;
        
        private int _orientationField;
        
        private string _pg_idField;
        
        private double _right_marginField;
        
        private int _sizeField;
        
        private double _top_marginField;
        
        private int _total_kbnField;
        
        private int _user_idField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double _bottom_margin {
            get {
                return this._bottom_marginField;
            }
            set {
                if ((this._bottom_marginField.Equals(value) != true)) {
                    this._bottom_marginField = value;
                    this.RaisePropertyChanged("_bottom_margin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _group_id_from {
            get {
                return this._group_id_fromField;
            }
            set {
                if ((object.ReferenceEquals(this._group_id_fromField, value) != true)) {
                    this._group_id_fromField = value;
                    this.RaisePropertyChanged("_group_id_from");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _group_id_to {
            get {
                return this._group_id_toField;
            }
            set {
                if ((object.ReferenceEquals(this._group_id_toField, value) != true)) {
                    this._group_id_toField = value;
                    this.RaisePropertyChanged("_group_id_to");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _group_nm_from {
            get {
                return this._group_nm_fromField;
            }
            set {
                if ((object.ReferenceEquals(this._group_nm_fromField, value) != true)) {
                    this._group_nm_fromField = value;
                    this.RaisePropertyChanged("_group_nm_from");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _group_nm_to {
            get {
                return this._group_nm_toField;
            }
            set {
                if ((object.ReferenceEquals(this._group_nm_toField, value) != true)) {
                    this._group_nm_toField = value;
                    this.RaisePropertyChanged("_group_nm_to");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int _group_total {
            get {
                return this._group_totalField;
            }
            set {
                if ((this._group_totalField.Equals(value) != true)) {
                    this._group_totalField = value;
                    this.RaisePropertyChanged("_group_total");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double _left_margin {
            get {
                return this._left_marginField;
            }
            set {
                if ((this._left_marginField.Equals(value) != true)) {
                    this._left_marginField = value;
                    this.RaisePropertyChanged("_left_margin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _message {
            get {
                return this._messageField;
            }
            set {
                if ((object.ReferenceEquals(this._messageField, value) != true)) {
                    this._messageField = value;
                    this.RaisePropertyChanged("_message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int _orientation {
            get {
                return this._orientationField;
            }
            set {
                if ((this._orientationField.Equals(value) != true)) {
                    this._orientationField = value;
                    this.RaisePropertyChanged("_orientation");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _pg_id {
            get {
                return this._pg_idField;
            }
            set {
                if ((object.ReferenceEquals(this._pg_idField, value) != true)) {
                    this._pg_idField = value;
                    this.RaisePropertyChanged("_pg_id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double _right_margin {
            get {
                return this._right_marginField;
            }
            set {
                if ((this._right_marginField.Equals(value) != true)) {
                    this._right_marginField = value;
                    this.RaisePropertyChanged("_right_margin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int _size {
            get {
                return this._sizeField;
            }
            set {
                if ((this._sizeField.Equals(value) != true)) {
                    this._sizeField = value;
                    this.RaisePropertyChanged("_size");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double _top_margin {
            get {
                return this._top_marginField;
            }
            set {
                if ((this._top_marginField.Equals(value) != true)) {
                    this._top_marginField = value;
                    this.RaisePropertyChanged("_top_margin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int _total_kbn {
            get {
                return this._total_kbnField;
            }
            set {
                if ((this._total_kbnField.Equals(value) != true)) {
                    this._total_kbnField = value;
                    this.RaisePropertyChanged("_total_kbn");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int _user_id {
            get {
                return this._user_idField;
            }
            set {
                if ((this._user_idField.Equals(value) != true)) {
                    this._user_idField = value;
                    this.RaisePropertyChanged("_user_id");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EntityReport", Namespace="http://schemas.datacontract.org/2004/07/SlvHanbai.Web.Class.Entity")]
    public partial class EntityReport : SlvHanbaiClient.svcReport.EntityBase {
        
        private string _downLoadFileNameField;
        
        private string _downLoadFilePathField;
        
        private string _downLoadFileSizeField;
        
        private string _downLoadUrlField;
        
        private string _messageField;
        
        private bool _retField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _downLoadFileName {
            get {
                return this._downLoadFileNameField;
            }
            set {
                if ((object.ReferenceEquals(this._downLoadFileNameField, value) != true)) {
                    this._downLoadFileNameField = value;
                    this.RaisePropertyChanged("_downLoadFileName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _downLoadFilePath {
            get {
                return this._downLoadFilePathField;
            }
            set {
                if ((object.ReferenceEquals(this._downLoadFilePathField, value) != true)) {
                    this._downLoadFilePathField = value;
                    this.RaisePropertyChanged("_downLoadFilePath");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _downLoadFileSize {
            get {
                return this._downLoadFileSizeField;
            }
            set {
                if ((object.ReferenceEquals(this._downLoadFileSizeField, value) != true)) {
                    this._downLoadFileSizeField = value;
                    this.RaisePropertyChanged("_downLoadFileSize");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _downLoadUrl {
            get {
                return this._downLoadUrlField;
            }
            set {
                if ((object.ReferenceEquals(this._downLoadUrlField, value) != true)) {
                    this._downLoadUrlField = value;
                    this.RaisePropertyChanged("_downLoadUrl");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _message {
            get {
                return this._messageField;
            }
            set {
                if ((object.ReferenceEquals(this._messageField, value) != true)) {
                    this._messageField = value;
                    this.RaisePropertyChanged("_message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool _ret {
            get {
                return this._retField;
            }
            set {
                if ((this._retField.Equals(value) != true)) {
                    this._retField = value;
                    this.RaisePropertyChanged("_ret");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="", ConfigurationName="svcReport.svcReport")]
    public interface svcReport {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:svcReport/ReportOut", ReplyAction="urn:svcReport/ReportOutResponse")]
        System.IAsyncResult BeginReportOut(string random, string rptKbn, string pgId, string parameters, System.AsyncCallback callback, object asyncState);
        
        SlvHanbaiClient.svcReport.EntityReport EndReportOut(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:svcReport/GetReportSetting", ReplyAction="urn:svcReport/GetReportSettingResponse")]
        System.IAsyncResult BeginGetReportSetting(string random, string Id, System.AsyncCallback callback, object asyncState);
        
        SlvHanbaiClient.svcReport.EntityReportSetting EndGetReportSetting(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:svcReport/UpdateReportSetting", ReplyAction="urn:svcReport/UpdateReportSettingResponse")]
        System.IAsyncResult BeginUpdateReportSetting(string random, int type, string Id, SlvHanbaiClient.svcReport.EntityReportSetting entity, System.AsyncCallback callback, object asyncState);
        
        string EndUpdateReportSetting(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface svcReportChannel : SlvHanbaiClient.svcReport.svcReport, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ReportOutCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public ReportOutCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public SlvHanbaiClient.svcReport.EntityReport Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((SlvHanbaiClient.svcReport.EntityReport)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetReportSettingCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetReportSettingCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public SlvHanbaiClient.svcReport.EntityReportSetting Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((SlvHanbaiClient.svcReport.EntityReportSetting)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UpdateReportSettingCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public UpdateReportSettingCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public partial class svcReportClient : System.ServiceModel.ClientBase<SlvHanbaiClient.svcReport.svcReport>, SlvHanbaiClient.svcReport.svcReport {
        
        private BeginOperationDelegate onBeginReportOutDelegate;
        
        private EndOperationDelegate onEndReportOutDelegate;
        
        private System.Threading.SendOrPostCallback onReportOutCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetReportSettingDelegate;
        
        private EndOperationDelegate onEndGetReportSettingDelegate;
        
        private System.Threading.SendOrPostCallback onGetReportSettingCompletedDelegate;
        
        private BeginOperationDelegate onBeginUpdateReportSettingDelegate;
        
        private EndOperationDelegate onEndUpdateReportSettingDelegate;
        
        private System.Threading.SendOrPostCallback onUpdateReportSettingCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public svcReportClient() {
        }
        
        public svcReportClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public svcReportClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public svcReportClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public svcReportClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
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
        
        public event System.EventHandler<ReportOutCompletedEventArgs> ReportOutCompleted;
        
        public event System.EventHandler<GetReportSettingCompletedEventArgs> GetReportSettingCompleted;
        
        public event System.EventHandler<UpdateReportSettingCompletedEventArgs> UpdateReportSettingCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult SlvHanbaiClient.svcReport.svcReport.BeginReportOut(string random, string rptKbn, string pgId, string parameters, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginReportOut(random, rptKbn, pgId, parameters, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SlvHanbaiClient.svcReport.EntityReport SlvHanbaiClient.svcReport.svcReport.EndReportOut(System.IAsyncResult result) {
            return base.Channel.EndReportOut(result);
        }
        
        private System.IAsyncResult OnBeginReportOut(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string random = ((string)(inValues[0]));
            string rptKbn = ((string)(inValues[1]));
            string pgId = ((string)(inValues[2]));
            string parameters = ((string)(inValues[3]));
            return ((SlvHanbaiClient.svcReport.svcReport)(this)).BeginReportOut(random, rptKbn, pgId, parameters, callback, asyncState);
        }
        
        private object[] OnEndReportOut(System.IAsyncResult result) {
            SlvHanbaiClient.svcReport.EntityReport retVal = ((SlvHanbaiClient.svcReport.svcReport)(this)).EndReportOut(result);
            return new object[] {
                    retVal};
        }
        
        private void OnReportOutCompleted(object state) {
            if ((this.ReportOutCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.ReportOutCompleted(this, new ReportOutCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void ReportOutAsync(string random, string rptKbn, string pgId, string parameters) {
            this.ReportOutAsync(random, rptKbn, pgId, parameters, null);
        }
        
        public void ReportOutAsync(string random, string rptKbn, string pgId, string parameters, object userState) {
            if ((this.onBeginReportOutDelegate == null)) {
                this.onBeginReportOutDelegate = new BeginOperationDelegate(this.OnBeginReportOut);
            }
            if ((this.onEndReportOutDelegate == null)) {
                this.onEndReportOutDelegate = new EndOperationDelegate(this.OnEndReportOut);
            }
            if ((this.onReportOutCompletedDelegate == null)) {
                this.onReportOutCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnReportOutCompleted);
            }
            base.InvokeAsync(this.onBeginReportOutDelegate, new object[] {
                        random,
                        rptKbn,
                        pgId,
                        parameters}, this.onEndReportOutDelegate, this.onReportOutCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult SlvHanbaiClient.svcReport.svcReport.BeginGetReportSetting(string random, string Id, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetReportSetting(random, Id, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SlvHanbaiClient.svcReport.EntityReportSetting SlvHanbaiClient.svcReport.svcReport.EndGetReportSetting(System.IAsyncResult result) {
            return base.Channel.EndGetReportSetting(result);
        }
        
        private System.IAsyncResult OnBeginGetReportSetting(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string random = ((string)(inValues[0]));
            string Id = ((string)(inValues[1]));
            return ((SlvHanbaiClient.svcReport.svcReport)(this)).BeginGetReportSetting(random, Id, callback, asyncState);
        }
        
        private object[] OnEndGetReportSetting(System.IAsyncResult result) {
            SlvHanbaiClient.svcReport.EntityReportSetting retVal = ((SlvHanbaiClient.svcReport.svcReport)(this)).EndGetReportSetting(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetReportSettingCompleted(object state) {
            if ((this.GetReportSettingCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetReportSettingCompleted(this, new GetReportSettingCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetReportSettingAsync(string random, string Id) {
            this.GetReportSettingAsync(random, Id, null);
        }
        
        public void GetReportSettingAsync(string random, string Id, object userState) {
            if ((this.onBeginGetReportSettingDelegate == null)) {
                this.onBeginGetReportSettingDelegate = new BeginOperationDelegate(this.OnBeginGetReportSetting);
            }
            if ((this.onEndGetReportSettingDelegate == null)) {
                this.onEndGetReportSettingDelegate = new EndOperationDelegate(this.OnEndGetReportSetting);
            }
            if ((this.onGetReportSettingCompletedDelegate == null)) {
                this.onGetReportSettingCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetReportSettingCompleted);
            }
            base.InvokeAsync(this.onBeginGetReportSettingDelegate, new object[] {
                        random,
                        Id}, this.onEndGetReportSettingDelegate, this.onGetReportSettingCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult SlvHanbaiClient.svcReport.svcReport.BeginUpdateReportSetting(string random, int type, string Id, SlvHanbaiClient.svcReport.EntityReportSetting entity, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginUpdateReportSetting(random, type, Id, entity, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        string SlvHanbaiClient.svcReport.svcReport.EndUpdateReportSetting(System.IAsyncResult result) {
            return base.Channel.EndUpdateReportSetting(result);
        }
        
        private System.IAsyncResult OnBeginUpdateReportSetting(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string random = ((string)(inValues[0]));
            int type = ((int)(inValues[1]));
            string Id = ((string)(inValues[2]));
            SlvHanbaiClient.svcReport.EntityReportSetting entity = ((SlvHanbaiClient.svcReport.EntityReportSetting)(inValues[3]));
            return ((SlvHanbaiClient.svcReport.svcReport)(this)).BeginUpdateReportSetting(random, type, Id, entity, callback, asyncState);
        }
        
        private object[] OnEndUpdateReportSetting(System.IAsyncResult result) {
            string retVal = ((SlvHanbaiClient.svcReport.svcReport)(this)).EndUpdateReportSetting(result);
            return new object[] {
                    retVal};
        }
        
        private void OnUpdateReportSettingCompleted(object state) {
            if ((this.UpdateReportSettingCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.UpdateReportSettingCompleted(this, new UpdateReportSettingCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void UpdateReportSettingAsync(string random, int type, string Id, SlvHanbaiClient.svcReport.EntityReportSetting entity) {
            this.UpdateReportSettingAsync(random, type, Id, entity, null);
        }
        
        public void UpdateReportSettingAsync(string random, int type, string Id, SlvHanbaiClient.svcReport.EntityReportSetting entity, object userState) {
            if ((this.onBeginUpdateReportSettingDelegate == null)) {
                this.onBeginUpdateReportSettingDelegate = new BeginOperationDelegate(this.OnBeginUpdateReportSetting);
            }
            if ((this.onEndUpdateReportSettingDelegate == null)) {
                this.onEndUpdateReportSettingDelegate = new EndOperationDelegate(this.OnEndUpdateReportSetting);
            }
            if ((this.onUpdateReportSettingCompletedDelegate == null)) {
                this.onUpdateReportSettingCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnUpdateReportSettingCompleted);
            }
            base.InvokeAsync(this.onBeginUpdateReportSettingDelegate, new object[] {
                        random,
                        type,
                        Id,
                        entity}, this.onEndUpdateReportSettingDelegate, this.onUpdateReportSettingCompletedDelegate, userState);
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
        
        protected override SlvHanbaiClient.svcReport.svcReport CreateChannel() {
            return new svcReportClientChannel(this);
        }
        
        private class svcReportClientChannel : ChannelBase<SlvHanbaiClient.svcReport.svcReport>, SlvHanbaiClient.svcReport.svcReport {
            
            public svcReportClientChannel(System.ServiceModel.ClientBase<SlvHanbaiClient.svcReport.svcReport> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginReportOut(string random, string rptKbn, string pgId, string parameters, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[4];
                _args[0] = random;
                _args[1] = rptKbn;
                _args[2] = pgId;
                _args[3] = parameters;
                System.IAsyncResult _result = base.BeginInvoke("ReportOut", _args, callback, asyncState);
                return _result;
            }
            
            public SlvHanbaiClient.svcReport.EntityReport EndReportOut(System.IAsyncResult result) {
                object[] _args = new object[0];
                SlvHanbaiClient.svcReport.EntityReport _result = ((SlvHanbaiClient.svcReport.EntityReport)(base.EndInvoke("ReportOut", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginGetReportSetting(string random, string Id, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[2];
                _args[0] = random;
                _args[1] = Id;
                System.IAsyncResult _result = base.BeginInvoke("GetReportSetting", _args, callback, asyncState);
                return _result;
            }
            
            public SlvHanbaiClient.svcReport.EntityReportSetting EndGetReportSetting(System.IAsyncResult result) {
                object[] _args = new object[0];
                SlvHanbaiClient.svcReport.EntityReportSetting _result = ((SlvHanbaiClient.svcReport.EntityReportSetting)(base.EndInvoke("GetReportSetting", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginUpdateReportSetting(string random, int type, string Id, SlvHanbaiClient.svcReport.EntityReportSetting entity, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[4];
                _args[0] = random;
                _args[1] = type;
                _args[2] = Id;
                _args[3] = entity;
                System.IAsyncResult _result = base.BeginInvoke("UpdateReportSetting", _args, callback, asyncState);
                return _result;
            }
            
            public string EndUpdateReportSetting(System.IAsyncResult result) {
                object[] _args = new object[0];
                string _result = ((string)(base.EndInvoke("UpdateReportSetting", _args, result)));
                return _result;
            }
        }
    }
}