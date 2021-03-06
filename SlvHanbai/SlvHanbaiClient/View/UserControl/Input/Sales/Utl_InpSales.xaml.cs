﻿using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Windows.Data;
using System.Threading;
using System.Collections.ObjectModel;  // ObservableCollectionを利用するために必要   
using System.ServiceModel.DomainServices.Client;
using SlvHanbaiClient.Class;
using SlvHanbaiClient.Class.Converter;
using SlvHanbaiClient.Class.Utility;
using SlvHanbaiClient.Class.UI;
using SlvHanbaiClient.Class.Data;
using SlvHanbaiClient.Class.Data;
using SlvHanbaiClient.Class.WebService;
using SlvHanbaiClient.svcOrder;
using SlvHanbaiClient.svcEstimate;
using SlvHanbaiClient.svcSales;
using SlvHanbaiClient.svcMstData;
using SlvHanbaiClient.View.UserControl.Custom;
using SlvHanbaiClient.View.Dlg;

namespace SlvHanbaiClient.View.UserControl.Input.Sales
{
    public partial class Utl_InpSales : ExUserControl
    {

        #region Filed Const

        private const String CLASS_NM = "Utl_InpSales";
        private const String PG_NM = DataPgEvidence.PGName.Sales.SalesInp;
        private Common.gePageType _PageType = Common.gePageType.InpSales;

        private Utl_FunctionKey utlFunctionKey = null;

        private const ExWebService.geWebServiceCallKbn _GetHeadWebServiceCallKbn = ExWebService.geWebServiceCallKbn.GetSalesListH;
        private const ExWebService.geWebServiceCallKbn _GetDetailWebServiceCallKbn = ExWebService.geWebServiceCallKbn.GetSalesListD;
        private const ExWebService.geWebServiceCallKbn _UpdWebServiceCallKbn = ExWebService.geWebServiceCallKbn.UpdateSales;

        private EntitySalesH _entityH = new EntitySalesH();
        private ObservableCollection<EntitySalesD> _entityListD = new ObservableCollection<EntitySalesD>();

        private EntityOrderH _entityOrderH = new EntityOrderH();
        private ObservableCollection<EntityOrderD> _entityListOrderD = new ObservableCollection<EntityOrderD>();

        private EntityEstimateH _entityEstimateH = new EntityEstimateH();
        private ObservableCollection<EntityEstimateD> _entityListEstimateD = new ObservableCollection<EntityEstimateD>();

        private EntitySalesH _before_entityH = new EntitySalesH();
        private ObservableCollection<EntitySalesD> _before_entityListD = new ObservableCollection<EntitySalesD>();

        // 赤伝発行保持用
        private EntitySalesH _entityRedH = new EntitySalesH();
        private ObservableCollection<EntitySalesD> _entityListRedD = new ObservableCollection<EntitySalesD>();

        private readonly string tableName = "T_SALES_H";
        private Control activeControl;

        private Common.geWinType WinType = Common.geWinType.ListSales;

        private Dlg_DataForm dataForm;
        private Common.geDataFormType DataFormType = Common.geDataFormType.SalesDetail;

        private Dlg_MstSearch masterDlg;
        private Dlg_Copying copyDlg;
        private Common.geWinGroupType beforeWinGroupType;

        private string beforeValue = "";                // DataGrid編集チェック用
        private int beforeSelectedIndex = -1;           // DataGrid編集前 行
        private int _selectIndex = 0;                   // データグリッド現在行保持用
        private int _selectColumn = 0;                  // データグリッド現在列保持用

        #endregion

        #region Constructor

        public Utl_InpSales()
        {
            InitializeComponent();
            this.Tag = "Main";      // ファンクションキーを受けつけ用
        }

        #endregion

        #region Page Events

        private void ExUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (Common.gblnLogin == false) return;

            this.utlNo._ExUserControl_LostFocus -= this.utlNo_LostFocus;
            this.utlNo._ExUserControl_LostFocus += this.utlNo_LostFocus;
            this.utlOrderNo._ExUserControl_LostFocus -= this.utlOrderNo_LostFocus;
            this.utlOrderNo._ExUserControl_LostFocus += this.utlOrderNo_LostFocus;
            this.utlEstimateNo._ExUserControl_LostFocus -= this.utlEstimateNo_LostFocus;
            this.utlEstimateNo._ExUserControl_LostFocus += this.utlEstimateNo_LostFocus;

            // 画面初期化
            ExVisualTreeHelper.initDisplay(this.LayoutRoot);

            // ファンクションキー初期設定
            this.utlFunctionKey = ExVisualTreeHelper.GetUtlFunctionKey(this.LayoutRoot);
            this.utlFunctionKey.gFunctionKeyEnable = Utl_FunctionKey.geFunctionKeyEnable.Init;

            // バインド設定
            this.utlCustomer.utlSupplier = this.utlSupply;
            SetBinding();

            // 明細追加
            this.RecordAdd();

            dg.ItemsSource = _entityListD;

            ExBackgroundWorker.DoWork_Focus(this.utlNo.txtID, 10);
        }

        private void ExUserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            this.utlNo._ExUserControl_LostFocus -= this.utlNo_LostFocus;
        }

        #endregion

        #region Function Key Button Events

        // F1ボタン(登録) クリック
        public override void btnF1_Click(object sender, RoutedEventArgs e)
        {
            ExDataGridUtilty.zCommitEdit(this.dg);
            if (Common.gblnDesynchronizeLock == true) return;

            // ボタン押下時非同期入力チェックON
            Common.gblnBtnDesynchronizeLock = true;

            // 入力確定の為、BackgroundWorker経由で入力チェックを呼出
            ExBackgroundInputCheckWk bk = new ExBackgroundInputCheckWk();
            bk.utl = this;
            bk.waitTime = 500;
            this.txtDummy.IsTabStop = true;
            bk.focusCtl = this.txtDummy;
            bk.bw.RunWorkerAsync();
        }

        // F2ボタン(クリア) クリック
        public override void btnF2_Click(object sender, RoutedEventArgs e)
        {
            this.utlFunctionKey.gFunctionKeyEnable = Utl_FunctionKey.geFunctionKeyEnable.Init;
            Common.gblnDesynchronizeLock = false;

            // 先頭選択
            this.dg.SelectedFirst();

            // ヘッダ初期化
            _entityH = null;
            SetBinding();

            // 明細初期化
            _entityListD = null;
            _entityListD = new ObservableCollection<EntitySalesD>();

            // 明細追加
            Common.gblnDesynchronizeLock = false;
            this.btnF7_Click(null, null);

            this.dg.ItemsSource = _entityListD;

            this.utlFunctionKey.gFunctionKeyEnable = Utl_FunctionKey.geFunctionKeyEnable.Init;

            this.utlNo.txtID_IsReadOnly = false;
            //this.utlNo.IsEnabled = true;
            this.utlNo.txtID.Text = "";
            ExBackgroundWorker.DoWork_Focus(this.utlNo.txtID, 10);

            // ロック解除
            DataPgLock.gLockPg(PG_NM, "", (int)DataPgLock.geLockType.UnLock);
        }

        // F3ボタン(複写) クリック
        public override void btnF3_Click(object sender, RoutedEventArgs e)
        {
            if (_entityH == null || _entityListD == null) return;

            copyDlg = new Dlg_Copying();

            copyDlg.utlCopying.gPageType = _PageType;
            copyDlg.utlCopying.gWinMsterType = Common.geWinMsterType.None;
            copyDlg.utlCopying.utlMstID.MstKbn = Class.Data.MstData.geMDataKbn.None;
            copyDlg.utlCopying.tableName = this.tableName;
            copyDlg.utlCopying.before_id = this.utlNo.txtID.Text.Trim();

            copyDlg.Show();
            copyDlg.Closed += copyDlg_Closed;
        }

        private void copyDlg_Closed(object sender, EventArgs e)
        {
            Dlg_Copying dlg = (Dlg_Copying)sender;
            if (dlg.utlCopying.DialogResult == true)
            {
                // ロック解除
                DataPgLock.gLockPg(PG_NM, ExCast.zCStr(_entityH._id), (int)DataPgLock.geLockType.UnLock);

                // 引き継いではいけない情報は初期化する
                _entityH._red_before_no = 0;
                _entityH._order_no = 0;
                _entityH._estimateno = 0;
                _entityH._invoice_close_flg = 0;
                _entityH._invoice_no = 0;
                _entityH._invoice_state = "";
                _entityH._receipt_receivable_kbn = 0;
                _entityH._receipt_receivable_kbn_nm = "消込未";
                _entityH._lock_flg = 0;

                for (int i = 1; i <= _entityListD.Count; i++)
                {
                    _entityListD[i - 1]._order_id = 0;
                    _entityListD[i - 1]._order_stay_number = 0;
                }

                if (dlg.utlCopying.copy_id == "")
                {
                    this.utlFunctionKey.gFunctionKeyEnable = Utl_FunctionKey.geFunctionKeyEnable.Init;
                    this.utlNo.txtID_IsReadOnly = false;
                    this.utlNo.txtID.Text = "";
                }
                else
                {
                    if (dlg.utlCopying.ExistsData == true)
                    {
                        this.utlFunctionKey.gFunctionKeyEnable = Utl_FunctionKey.geFunctionKeyEnable.Upd;
                    }
                    else
                    {
                        this.utlFunctionKey.gFunctionKeyEnable = Utl_FunctionKey.geFunctionKeyEnable.New;
                    }
                    string _id = dlg.utlCopying.copy_id;
                    if (ExCast.IsNumeric(dlg.utlCopying.copy_id))
                    {
                        _id = ExCast.zCDbl(_id).ToString();
                        _entityH._no = ExCast.zCLng(_id);
                        this.utlNo.txtID.Text = _id;
                        this.utlNo.txtID.FormatToID();
                    }
                    else
                    {
                        _entityH._no = ExCast.zCLng(_id);
                        this.utlNo.txtID.Text = _id;
                    }

                    this.utlNo.txtID_IsReadOnly = true;
                    ExBackgroundWorker.DoWork_Focus(this.utlPerson.txtID, 10);
                }

                // バインド反映
                SetBinding();

                // 前回情報保持
                ConvertBeforeData(_entityH, _entityListD, _before_entityH, _before_entityListD);
            }
        }

        // F4ボタン(削除) クリック
        public override void btnF4_Click(object sender, RoutedEventArgs e)
        {
            // ボタン押下時非同期入力チェックON
            Common.gblnBtnDesynchronizeLock = true;

            InputCheckDelete();
        }
        
        // F5ボタン(参照) クリック
        public override void btnF5_Click(object sender, RoutedEventArgs e)
        {
            if (activeControl == null)
            {
                return;
            }

            switch (activeControl.Name)
            {
                case "utlNo":
                case "utlEstimateNo":
                case "utlOrderNo":
                    Utl_InpNoText inp = (Utl_InpNoText)activeControl;
                    inp.ShowList();
                    break;
                case "datSalesYmd":
                case "datNokiYmd":
                    ExDatePicker dt = (ExDatePicker)activeControl;
                    dt.ShowCalender();
                    break;
                case "utlTax":
                case "utlBusiness":
                    Utl_MeiText mei = (Utl_MeiText)activeControl;
                    mei.ShowList();
                    break;
                case "utlPerson":
                case "utlCustomer":
                case "utlSupply":
                    Utl_MstText mst = (Utl_MstText)activeControl;
                    mst.ShowList();
                    break;
                case "DetailGoods":
                    txtGoodsID_MouseDoubleClick(null, null);
                    break;
                case "DetailUnitPrice":
                    txtUnitPrice_MouseDoubleClick(null, null);
                    break;
                default:
                    break;
            }
        }

        // F6ボタン(明細画面) クリック
        public override void btnF6_Click(object sender, RoutedEventArgs e)
        {
            ExDataGridUtilty.zCommitEdit(this.dg);
            if (Common.gblnDesynchronizeLock == true) return;

            Common.gDataFormType = DataFormType;
            Common.dataForm._entityH = this._entityH;
            Common.dataForm._entityListD = this._entityListD;
            Common.dataForm.Closed -= dlg_Closed;
            Common.dataForm.Closed += dlg_Closed;
            Common.dataForm.Show();
        }

        private void dlg_Closed(object sender, EventArgs e)
        {
            Common.dataForm.Closed -= dlg_Closed;

            // 明細合計計算
            DataDetail.CalcSumDetail(this._entityH, this._entityListD);

            this.dg.Focus();
        }

        // F7ボタン(明細追加) クリック
        public override void btnF7_Click(object sender, RoutedEventArgs e)
        {
            ExDataGridUtilty.zCommitEdit(this.dg);
            if (Common.gblnDesynchronizeLock == true) return;

            // 入力確定の為、BackgroundWorker経由で行挿入を呼出
            ExBackgroundRecordAddWk bk = new ExBackgroundRecordAddWk();
            bk.utl = this;
            this.txtDummy.IsTabStop = true;
            if (sender != null) bk.waitFlg = true;
            bk.focusCtl = this.txtDummy;
            bk.bw.RunWorkerAsync();
        }

        public override void RecordAdd()
        {
            if (Common.gblnDesynchronizeLock == true) return;

            if (_entityListD == null) _entityListD = new ObservableCollection<EntitySalesD>();

            EntitySalesD entity = new EntitySalesD();
            int cnt = 1;
            if (_entityListD != null) cnt = _entityListD.Count + 1;
            entity._rec_no = cnt;
            SetInitCombo(ref entity);   // コンボボックス初期選択
            _entityListD.Add(entity);
            dg.SelectedIndex = entity._rec_no - 1;
            dg.Focus();
            if (dg.CurrentColumn != null)
            {
                dg.ScrollIntoView(entity, dg.Columns[0]);
                dg.CommitEdit();
                dg.CurrentColumn = dg.Columns[0];
                dg.BeginEdit();
                dg.MoveNextCell();
            }

            // ファンクションキー設定
            string _activeCtlName = "";
            if (this.activeControl != null) _activeCtlName = ExCast.zCStr(this.activeControl.Name);
            switch (_activeCtlName)
            {
                case "cboBreakDown":
                case "cboDeliver":
                case "txtGoodsName":
                case "cboUnit":
                case "txtEnterNum":
                case "txtNumber":
                case "txtUnitPrice":
                case "txtPrice":
                case "txtCaseNum":
                case "cboTaxDivision":
                case "txtGoodsID":
                    if (this._entityListD.Count > 1)
                    {
                        ExVisualTreeHelper.SetFunctionKeyEnabled("F8", true, this);
                    }
                    else
                    {
                        ExVisualTreeHelper.SetFunctionKeyEnabled("F8", false, this);
                    }
                    break;
            }
        }

        // F8ボタン(明細削除) クリック
        public override void btnF8_Click(object sender, RoutedEventArgs e)
        {
            ExDataGridUtilty.zCommitEdit(this.dg);
            if (Common.gblnDesynchronizeLock == true) return;

            // 選択有りか、データ有りか確認
            if (this.dg.SelectedIndex < 0) return;
            if (this.dg.ItemsSource == null) return;
            if (_entityListD == null) return;
            if (_entityListD.Count == 0) return;

            if (_entityListD[this.dg.SelectedIndex]._order_id != 0)
            {
                ExMessageBox.Show("受注データからの転記分の為、削除できません。" + Environment.NewLine + "対象行データを取消する場合、納品区分を取消に変更して下さい。");
                return;
            }

            // 行削除
            _entityListD.RemoveAt(this.dg.SelectedIndex);

            // 行削除後の選択
            if (this.dg.SelectedIndex != 0) this.dg.SelectedIndex = this.dg.SelectedIndex - 1;

            // データ1件もない場合、デフォルト行の追加
            if (_entityListD.Count == 0) btnF7_Click(null, null);

            // 行番号振り直し
            for (int i = 1; i <= _entityListD.Count; i++)
            {
                _entityListD[i -1]._rec_no = i;
            }

            // 明細合計計算
            DataDetail.CalcSumDetail(this._entityH, this._entityListD);
        }

        // F9ボタン(赤伝発行) クリック
        public override void btnF9_Click(object sender, RoutedEventArgs e)
        {
            SetRedData();
            SetBinding();
            this.utlFunctionKey.gFunctionKeyEnable = Utl_FunctionKey.geFunctionKeyEnable.Init;
            this.utlNo.txtID_IsReadOnly = false;
            this.utlNo.txtID.Text = "";
            ExBackgroundWorker.DoWork_Focus(this.utlPerson.txtID, 10);
        }

        // F11ボタン(印刷) クリック
        public override void btnF11_Click(object sender, RoutedEventArgs e)
        {
            beforeWinGroupType = Common.gWinGroupType;
            Common.gWinMsterType = Common.geWinMsterType.None;
            Common.gWinGroupType = Common.geWinGroupType.InpListReport;
            Common.gWinType = this.WinType;

            Common.InpSearchSales.Closed -= reportDlg_Closed;
            Common.InpSearchSales.Closed += reportDlg_Closed;
            Common.InpSearchSales.Show();
        }

        private void reportDlg_Closed(object sender, EventArgs e)
        {
            Common.InpSearchSales.Closed -= reportDlg_Closed;
            Common.gWinGroupType = beforeWinGroupType;
        }

        // F12ボタン(メニュー) クリック
        public override void btnF12_Click(object sender, RoutedEventArgs e)
        {
            UA_Main pg = (UA_Main)ExVisualTreeHelper.FindPerentPage(this.Parent);
            Common.gPageGroupType = Common.gePageGroupType.Menu;
            Common.gPageType = Common.gePageType.Menu;
            pg.ChangePage();
        }

        #endregion

        #region Button Click Events

        private void btnSalesBalance_Click(object sender, RoutedEventArgs e)
        {
            if (this._entityH == null)
            {
                ExMessageBox.Show("得意先を選択して下さい。");
                return;
            }

            if (string.IsNullOrEmpty(this._entityH._invoice_id) || this._entityH._invoice_id == "0")
            {
                ExMessageBox.Show("得意先を選択して下さい。");
                return;
            }

            Dlg_MstSearch searchDlg = new Dlg_MstSearch(MstData.geMDataKbn.SalesBalance);
            searchDlg.MstKbn = Class.Data.MstData.geMDataKbn.SalesBalance;
            searchDlg.MstGroupKbn = Class.Data.MstData.geMGroupKbn.None;
            searchDlg.txtCode.Text = ExCast.zNumZeroNothingFormat(this._entityH._invoice_id);
            searchDlg.Show();
        }

        private void btnInventory_Click(object sender, RoutedEventArgs e)
        {
            if (ExCast.zCStr(_entityListD[dg.SelectedIndex]._commodity_id) != "" && ExCast.zCInt(_entityListD[dg.SelectedIndex]._inventory_management_division_id) == 1)
            {
            }
            else
            {
                ExMessageBox.Show("商品を選択して下さい。");
                return;
            }

            Dlg_MstSearch searchDlg = new Dlg_MstSearch(MstData.geMDataKbn.Inventory);
            searchDlg.MstKbn = Class.Data.MstData.geMDataKbn.Inventory;
            searchDlg.MstGroupKbn = Class.Data.MstData.geMGroupKbn.None;
            searchDlg.txtCode.Text = ExCast.zNumZeroNothingFormat(ExCast.zCStr(_entityListD[dg.SelectedIndex]._commodity_id));
            searchDlg.Show();
        }

        #endregion

        #region GotFocus Events

        private void txt_GotFocus(object sender, RoutedEventArgs e)
        {
            Control ctl = (Control)sender;

            switch (ctl.Name)
            {
                #region Header

                case "utlNo":
                case "utlOrderNo":
                case "utlEstimateNo":
                case "datSalesYmd":
                case "utlPerson":
                case "utlCustomer":
                case "utlSupply":
                case "utlTax":
                case "utlBusiness":
                case "datNokiYmd":
                    ExVisualTreeHelper.SetFunctionKeyEnabled("F5", true, this);
                    ExVisualTreeHelper.SetFunctionKeyEnabled("F8", false, this);
                    activeControl = ctl;
                    break;
                case "txtLastUpdYmd":
                case "txtMemo":
                    ExVisualTreeHelper.SetFunctionKeyEnabled("F5", false, this);
                    ExVisualTreeHelper.SetFunctionKeyEnabled("F8", false, this);
                    activeControl = null;
                    break;

                #endregion

                #region Detail

                case "cboBreakDown":
                case "cboDeliverDivison":
                case "txtGoodsName":
                case "cboUnit":
                case "txtEnterNum":
                case "txtNumber":
                case "txtPrice":
                case "txtCaseNum":
                case "cboTaxDivision":
                case "txtDetailMemo":
                    ExVisualTreeHelper.SetFunctionKeyEnabled("F5", false, this);
                    if (this._entityListD.Count > 1)
                    {
                        ExVisualTreeHelper.SetFunctionKeyEnabled("F8", true, this);
                    }
                    else
                    {
                        ExVisualTreeHelper.SetFunctionKeyEnabled("F8", false, this);
                    }
                    activeControl = ctl;
                    break;
                case "txtGoodsID":
                    ExVisualTreeHelper.SetFunctionKeyEnabled("F5", true, this);
                    if (this._entityListD.Count > 1)
                    {
                        ExVisualTreeHelper.SetFunctionKeyEnabled("F8", true, this);
                    }
                    else
                    {
                        ExVisualTreeHelper.SetFunctionKeyEnabled("F8", false, this);
                    }
                    ExTextBox txt = new ExTextBox();
                    txt.Name = "DetailGoods";
                    activeControl = txt;
                    break;
                case "txtUnitPrice":
                    ExVisualTreeHelper.SetFunctionKeyEnabled("F5", true, this);
                    if (this._entityListD.Count > 1)
                    {
                        ExVisualTreeHelper.SetFunctionKeyEnabled("F8", true, this);
                    }
                    else
                    {
                        ExVisualTreeHelper.SetFunctionKeyEnabled("F8", false, this);
                    }
                    txt = new ExTextBox();
                    txt.Name = "DetailUnitPrice";
                    activeControl = txt;
                    break;

                #endregion

                default:
                    break;
            }
        }

        #endregion

        #region LostFocus Events

        private void utlNo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.utlNo.txtID.Text.Trim()))
            {
                if (this._entityH != null) this._entityH._no = 0;
                return;
            }

            if (this.utlNo.txtID.Text.Trim() != "")
            {
                GetHeadData(ExCast.zCLng(this.utlNo.txtID.Text.Trim()));
            }
        }

        private void utlEstimateNo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.utlEstimateNo.txtID.Text.Trim()))
            {
                if (this._entityH != null) this._entityH._estimateno = 0;
                return;
            }

            if (this.utlEstimateNo.txtID.Text.Trim() != "" && this.utlEstimateNo.txtID.UpdataFlg == true)
            {
                GetHeadEstimate(ExCast.zCLng(this.utlEstimateNo.txtID.Text.Trim()));
            }
        }

        private void utlOrderNo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.utlOrderNo.txtID.Text.Trim()))
            {
                if (this._entityH != null) this._entityH._order_no = 0;
                return;
            }

            if (this.utlOrderNo.txtID.Text.Trim() != "" && this.utlOrderNo.txtID.UpdataFlg == true)
            {
                GetHeadOrder(ExCast.zCLng(this.utlOrderNo.txtID.Text.Trim()));
            }
        }

        #endregion

        #region Binding Setting

        private void SetBinding()
        {
            if (_entityH == null)
            {
                _entityH = new EntitySalesH();
            }

            if (_entityListD == null)
            {
                _entityListD = new ObservableCollection<EntitySalesD>();
            }

            // マスタコントロールPropertyChanged
            _entityH.PropertyChanged += this.utlCustomer.MstID_Changed;
            _entityH.PropertyChanged += this.utlSupply.MstID_Changed;
            _entityH.PropertyChanged += this.utlPerson.MstID_Changed;
            _entityH.PropertyChanged += this._PropertyChanged;
            this.utlCustomer.ParentData = _entityH;
            this.utlSupply.ParentData = _entityH;
            this.utlPerson.ParentData = _entityH;

            NumberConverter nmConvDecm0 = new NumberConverter();
            NumberConverter nmConvDecm2 = new NumberConverter();
            nmConvDecm2.DecimalPlaces = 2;

            #region Bind

            // バインド
            Binding BindingOrderNo = new Binding("_order_no");
            BindingOrderNo.Mode = BindingMode.TwoWay;
            BindingOrderNo.Source = _entityH;
            this.utlOrderNo.txtID.SetBinding(TextBox.TextProperty, BindingOrderNo);

            Binding BindingEstimateNo = new Binding("_estimateno");
            BindingEstimateNo.Mode = BindingMode.TwoWay;
            BindingEstimateNo.Source = _entityH;
            this.utlEstimateNo.txtID.SetBinding(TextBox.TextProperty, BindingEstimateNo);

            Binding BindingSalesYmd = new Binding("_sales_ymd");
            BindingSalesYmd.Mode = BindingMode.TwoWay;
            BindingSalesYmd.Source = _entityH;
            this.datSalesYmd.SetBinding(DatePicker.SelectedDateProperty, BindingSalesYmd);

            if (string.IsNullOrEmpty(_entityH._sales_ymd))
            {
                _entityH._sales_ymd = DateTime.Now.ToString("yyyy/MM/dd");
            }
            
            Binding BindingInpPersonID = new Binding("_update_person_id");
            BindingInpPersonID.Mode = BindingMode.TwoWay;
            BindingInpPersonID.Source = _entityH;
            this.utlPerson.txtID.SetBinding(TextBox.TextProperty, BindingInpPersonID);

            Binding BindingInpPersonName = new Binding("_update_person_nm");
            BindingInpPersonName.Mode = BindingMode.TwoWay;
            BindingInpPersonName.Source = _entityH;
            this.utlPerson.txtNm.SetBinding(TextBox.TextProperty, BindingInpPersonName);

            if (_entityH._update_person_id == 0)
            {
                // デフォルト担当の設定
                this.utlPerson.txtID.Text = Common.gintDefaultPersonId.ToString();
                _entityH._update_person_id = Common.gintDefaultPersonId;
                this.utlPerson.MstID_Changed(null, new PropertyChangedEventArgs("_update_person_id"));
            }

            Binding BindingCustomeNo = new Binding("_customer_id");
            BindingCustomeNo.Mode = BindingMode.TwoWay;
            BindingCustomeNo.Source = _entityH;
            this.utlCustomer.txtID.SetBinding(TextBox.TextProperty, BindingCustomeNo);

            Binding BindingCustomeName = new Binding("_customer_name");
            BindingCustomeName.Mode = BindingMode.TwoWay;
            BindingCustomeName.Source = _entityH;
            this.utlCustomer.txtNm.SetBinding(TextBox.TextProperty, BindingCustomeName);

            Binding BindingInvoiceName = new Binding("_invoice_name");
            BindingInvoiceName.Mode = BindingMode.TwoWay;
            BindingInvoiceName.Source = _entityH;
            this.utlInvoice.txtNm.SetBinding(TextBox.TextProperty, BindingInvoiceName);

            Binding BindingInvoiceNo = new Binding("_invoice_no");
            BindingInvoiceNo.Mode = BindingMode.TwoWay;
            BindingInvoiceNo.Source = _entityH;
            this.txtInvoiceNo.SetBinding(TextBox.TextProperty, BindingInvoiceNo);

            Binding BindingInvoiceState = new Binding("_invoice_state");
            BindingInvoiceState.Mode = BindingMode.TwoWay;
            BindingInvoiceState.Source = _entityH;
            this.txtInvoiceState.SetBinding(TextBox.TextProperty, BindingInvoiceState);

            Binding BindingReceiptState = new Binding("_receipt_receivable_kbn_nm");
            BindingReceiptState.Mode = BindingMode.TwoWay;
            BindingReceiptState.Source = _entityH;
            this.txtReceiptState.SetBinding(TextBox.TextProperty, BindingReceiptState);

            Binding BindingSupplyNo = new Binding("_supplier_id");
            BindingSupplyNo.Mode = BindingMode.TwoWay;
            BindingSupplyNo.Source = _entityH;
            this.utlSupply.txtID.SetBinding(TextBox.TextProperty, BindingSupplyNo);
            this.utlSupply.txtID2.SetBinding(TextBox.TextProperty, BindingCustomeNo);

            Binding BindingSupplyName = new Binding("_supplier_name");
            BindingSupplyName.Mode = BindingMode.TwoWay;
            BindingSupplyName.Source = _entityH;
            this.utlSupply.txtNm.SetBinding(TextBox.TextProperty, BindingSupplyName);

            Binding BindingTax = new Binding("_tax_change_id");
            BindingTax.Mode = BindingMode.TwoWay;
            BindingTax.Source = _entityH;
            this.utlTax.txtID.SetBinding(TextBox.TextProperty, BindingTax);

            Binding BindingTaxName = new Binding("_tax_change_name");
            BindingTaxName.Mode = BindingMode.TwoWay;
            BindingTaxName.Source = _entityH;
            this.utlTax.txtNm.SetBinding(TextBox.TextProperty, BindingTaxName);

            Binding BindingBusiness = new Binding("_business_division_id");
            BindingBusiness.Mode = BindingMode.TwoWay;
            BindingBusiness.Source = _entityH;
            this.utlBusiness.txtID.SetBinding(TextBox.TextProperty, BindingBusiness);

            Binding BindingBusinessName = new Binding("_business_division_name");
            BindingBusinessName.Mode = BindingMode.TwoWay;
            BindingBusinessName.Source = _entityH;
            this.utlBusiness.txtNm.SetBinding(TextBox.TextProperty, BindingBusinessName);

            Binding BindingUnitKindId = new Binding("_unit_kind_id");
            BindingUnitKindId.Mode = BindingMode.TwoWay;
            BindingUnitKindId.Source = _entityH;
            this.utlUnitKind.txtID.SetBinding(TextBox.TextProperty, BindingUnitKindId);

            Binding BindingCreditRate = new Binding("_credit_rate");
            BindingCreditRate.Mode = BindingMode.TwoWay;
            BindingCreditRate.Source = _entityH;
            this.txtCreditRate.SetBinding(TextBox.TextProperty, BindingCreditRate);

            Binding BindingNokiYmd = new Binding("_supply_ymd");
            BindingNokiYmd.Mode = BindingMode.TwoWay;
            BindingNokiYmd.Source = _entityH;
            this.datNokiYmd.SetBinding(DatePicker.SelectedDateProperty, BindingNokiYmd);

            Binding BindingMemo = new Binding("_memo");
            BindingMemo.Mode = BindingMode.TwoWay;
            BindingMemo.Source = _entityH;
            this.txtMemo.SetBinding(TextBox.TextProperty, BindingMemo);

            // 入数計
            Binding BindingEnterNumber = new Binding("_sum_enter_number");
            BindingEnterNumber.Mode = BindingMode.TwoWay;
            BindingEnterNumber.Source = _entityH;
            BindingEnterNumber.Converter = nmConvDecm0;
            this.txtEnterNumber.SetBinding(TextBox.TextProperty, BindingEnterNumber);
            
            // ケース数計
            Binding BindingCaseNumber = new Binding("_sum_case_number");
            BindingCaseNumber.Mode = BindingMode.TwoWay;
            BindingCaseNumber.Source = _entityH;
            BindingCaseNumber.Converter = nmConvDecm0;
            this.txtCaseNumber.SetBinding(TextBox.TextProperty, BindingCaseNumber);
            
            // 数量計
            Binding BindingNumber = new Binding("_sum_number");
            BindingNumber.Mode = BindingMode.TwoWay;
            BindingNumber.Source = _entityH;
            BindingNumber.Converter = nmConvDecm2;
            this.txtNumber.SetBinding(TextBox.TextProperty, BindingNumber);
            
            // 単価計
            Binding BindingUnitPrice = new Binding("_sum_unit_price");
            BindingUnitPrice.Mode = BindingMode.TwoWay;
            BindingUnitPrice.Source = _entityH;
            BindingUnitPrice.Converter = nmConvDecm2;
            this.txtUnitPrice.SetBinding(TextBox.TextProperty, BindingUnitPrice);
            
            // 売上原価計

            // 消費税額計
            Binding BindingSumTax = new Binding("_sum_tax");
            BindingSumTax.Mode = BindingMode.TwoWay;
            BindingSumTax.Source = _entityH;
            BindingSumTax.Converter = nmConvDecm0;
            this.txtTax.SetBinding(TextBox.TextProperty, BindingSumTax);
            
            // 税抜金額計
            Binding BindingTaxNoPrice = new Binding("_sum_no_tax_price");
            BindingTaxNoPrice.Mode = BindingMode.TwoWay;
            BindingTaxNoPrice.Source = _entityH;
            BindingTaxNoPrice.Converter = nmConvDecm0;
            this.txtTaxNoPrice.SetBinding(TextBox.TextProperty, BindingTaxNoPrice);

            // 税込金額計
            this.txtSumPrice.Text = ExCast.zCStr(ExCast.zCDbl(_entityH._sum_no_tax_price) + ExCast.zCDbl(_entityH._sum_tax));
            this.txtSumPrice.OnFormatString();

            // 金額計
            Binding BindingPrice = new Binding("_sum_price");
            BindingPrice.Mode = BindingMode.TwoWay;
            BindingPrice.Source = _entityH;
            BindingPrice.Converter = nmConvDecm0;
            this.txtPrice.SetBinding(TextBox.TextProperty, BindingPrice);
            
            // 粗利計(売上金額計-売上原価計)
            Binding BindingProfits = new Binding("_sum_profits");
            BindingProfits.Mode = BindingMode.TwoWay;
            BindingProfits.Source = _entityH;
            BindingProfits.Converter = nmConvDecm0;
            this.txtProfits.SetBinding(TextBox.TextProperty, BindingProfits);
            
            // 粗利率(売上原価計÷売上金額計×100)
            Binding BindingProfitsPercent = new Binding("_profits_percent");
            BindingProfitsPercent.Mode = BindingMode.TwoWay;
            BindingProfitsPercent.Source = _entityH;
            BindingProfitsPercent.Converter = nmConvDecm0;
            this.txtProfitsPercent.SetBinding(TextBox.TextProperty, BindingProfitsPercent);

            // 与信限度額
            Binding BindingCreditLimitPrice = new Binding("_credit_limit_price");
            BindingCreditLimitPrice.Mode = BindingMode.TwoWay;
            BindingCreditLimitPrice.Source = _entityH;
            BindingCreditLimitPrice.Converter = nmConvDecm0;
            this.txtCreditLimitPrice.SetBinding(TextBox.TextProperty, BindingCreditLimitPrice);

            // 売掛残高
            Binding BindingSalesCreditPrice = new Binding("_sales_credit_price");
            BindingSalesCreditPrice.Mode = BindingMode.TwoWay;
            BindingSalesCreditPrice.Source = _entityH;
            BindingSalesCreditPrice.Converter = nmConvDecm0;
            this.txtSalesLimitPrice.SetBinding(TextBox.TextProperty, BindingSalesCreditPrice);

            #endregion

            this.utlOrderNo.txtID.OnFormatString();
            this.utlOrderNo.txtID.SetZeroToNullString();
            this.utlEstimateNo.txtID.OnFormatString();
            this.utlEstimateNo.txtID.SetZeroToNullString();
            this.utlCustomer.txtID.SetZeroToNullString();
            this.utlSupply.txtID.SetZeroToNullString();
            this.utlPerson.txtID.SetZeroToNullString();
            this.utlTax.txtID.SetZeroToNullString();
            this.utlBusiness.txtID.SetZeroToNullString();

            this.txtInvoiceNo.Text = ExCast.zFormatForID(this.txtInvoiceNo.Text, Common.gintidFigureSlipNo);
            this.txtSalesLimitPrice.OnFormatString();
            this.txtCreditLimitPrice.OnFormatString();

        }

        #endregion

        #region Data Select

        #region ヘッダデータ取得

        // ヘッダデータ取得
        private void GetHeadData(long _No)
        {
            object[] prm = new object[2];
            prm[0] = _No.ToString();
            prm[1] = _No.ToString();
            webService.objPerent = this;
            webService.CallWebService(_GetHeadWebServiceCallKbn,
                                      ExWebService.geDialogDisplayFlg.Yes,
                                      ExWebService.geDialogCloseFlg.No,
                                      prm);
        }

        #endregion

        #region 明細データ取得

        // 明細データ取得
        private void GetDetailData(long _No)
        {
            object[] prm = new object[1];
            prm[0] = _No.ToString();
            webService.objPerent = this;
            webService.CallWebService(_GetDetailWebServiceCallKbn,
                                      ExWebService.geDialogDisplayFlg.No,
                                      ExWebService.geDialogCloseFlg.Yes,
                                      prm);
        }

        #endregion

        #region 受注ヘッダデータ取得

        // ヘッダデータ取得
        private void GetHeadOrder(long _No)
        {
            object[] prm = new object[2];
            prm[0] = _No.ToString();
            prm[1] = _No.ToString();
            webService.objPerent = this;
            webService.CallWebService(ExWebService.geWebServiceCallKbn.GetOrderListH,
                                      ExWebService.geDialogDisplayFlg.Yes,
                                      ExWebService.geDialogCloseFlg.No,
                                      prm);
        }

        #endregion

        #region 受注明細データ取得

        // 明細データ取得
        private void GetDetailOrder(long _No)
        {
            object[] prm = new object[1];
            prm[0] = _No.ToString();
            webService.objPerent = this;
            webService.CallWebService(ExWebService.geWebServiceCallKbn.GetOrderListD,
                                      ExWebService.geDialogDisplayFlg.No,
                                      ExWebService.geDialogCloseFlg.Yes,
                                      prm);
        }

        #endregion

        #region 見積ヘッダデータ取得

        // ヘッダデータ取得
        private void GetHeadEstimate(long _No)
        {
            _entityEstimateH = null;
            _entityListEstimateD = null;

            object[] prm = new object[2];
            prm[0] = _No.ToString();
            prm[1] = _No.ToString();
            webService.objPerent = this;
            webService.CallWebService(ExWebService.geWebServiceCallKbn.GetEstimateListH,
                                      ExWebService.geDialogDisplayFlg.Yes,
                                      ExWebService.geDialogCloseFlg.No,
                                      prm);
        }

        #endregion

        #region 見積明細データ取得

        // 明細データ取得
        private void GetDetailEstimate(long _No)
        {
            object[] prm = new object[1];
            prm[0] = _No.ToString();
            webService.objPerent = this;
            webService.CallWebService(ExWebService.geWebServiceCallKbn.GetEstimateListD,
                                      ExWebService.geDialogDisplayFlg.No,
                                      ExWebService.geDialogCloseFlg.Yes,
                                      prm);
        }

        #endregion

        #region データ取得コールバック呼出(ExWebServiceクラスより呼出)

        // データ取得コールバック呼出
        public override void DataSelect(int intKbn, object objList)
        {
            switch ((ExWebService.geWebServiceCallKbn)intKbn)
            {
                #region 売上

                // 売上ヘッダ
                case _GetHeadWebServiceCallKbn:
                    // 更新
                    if (objList != null)
                    {
                        _entityH = (EntitySalesH)objList;

                        // エラー発生時
                        if (_entityH._message != "" && _entityH._message != null)
                        {
                            webService.ProcessingDlgClose();
                            this.utlNo.txtID.Text = "";
                            return;
                        }

                        // バインド反映
                        SetBinding();

                        // 明細データ取得
                        GetDetailData(_entityH._id);
                    }
                    // 新規
                    else
                    {
                        //// 明細追加
                        //this.btnF7_Click(null, null);

                        //this.dg.ItemsSource = _entityListD;
                        webService.ProcessingDlgClose();
                        this.utlFunctionKey.gFunctionKeyEnable = Utl_FunctionKey.geFunctionKeyEnable.New;
                        //this.utlNo.txtID_IsReadOnly = true;
                        //this.utlNo.IsEnabled = false;
                        this.utlNo.txtID_IsReadOnly = false;
                    }
                    ExBackgroundWorker.DoWork_Focus(this.utlPerson.txtID, 10);
                    break;
                // 売上明細
                case _GetDetailWebServiceCallKbn:
                    // 2回設定がかかりエラーになる為
                    try
                    {
                        this.dg.ItemsSource = null;
                    }
                    catch
                    {
                        return;
                    }

                    if (objList != null)
                    {
                        _entityListD = (ObservableCollection<EntitySalesD>)objList;
                    }
                    else
                    {
                        _entityListD = null;
                    }

                    // 明細追加
                    this.btnF7_Click(null, null);

                    // 明細再計算
                    DataDetail.IsCalcPrice = false;
                    DataDetail.ReCalcDetail(_entityH, _entityListD);
                    DataDetail.IsCalcPrice = true;

                    this.dg.ItemsSource = _entityListD;

                    // 前回情報保持
                    ConvertBeforeData(_entityH, _entityListD, _before_entityH, _before_entityListD);

                    if (_entityH._invoice_close_flg == 1)
                    {
                        this.utlFunctionKey.gFunctionKeyEnable = Utl_FunctionKey.geFunctionKeyEnable.Sel;
                        this.utlMode.txtMode.Text = " 参照モード(請求締切済) ";
                        return;
                    }

                    if (_entityH._receipt_receivable_kbn_nm == "消込未" || _entityH._receipt_receivable_kbn_nm == "")
                    {
                    }
                    else
                    {
                        this.utlFunctionKey.gFunctionKeyEnable = Utl_FunctionKey.geFunctionKeyEnable.Sel;
                        this.utlMode.txtMode.Text = " 参照モード(" + _entityH._receipt_receivable_kbn_nm + ") ";
                        return;
                    }

                    if (_entityH._lock_flg == 0)
                    {
                        this.utlFunctionKey.gFunctionKeyEnable = Utl_FunctionKey.geFunctionKeyEnable.Upd;
                        ConvertRedData(_entityH, _entityListD, _entityRedH, _entityListRedD);
                        _entityRedH._no = 0;
                        _entityRedH._id = 0;
                        _entityRedH._red_before_no = _entityH._no;
                    }
                    else
                    {
                        this.utlFunctionKey.gFunctionKeyEnable = Utl_FunctionKey.geFunctionKeyEnable.Sel;
                    }

                    // 売掛再計算
                    CalcSalesCredit();

                    ExBackgroundWorker.DoWork_Focus(this.utlPerson.txtID, 10);
                    this.utlNo.txtID_IsReadOnly = true;
                    //this.utlNo.IsEnabled = false;
                    break;

                #endregion

                #region 受注

                // 受注ヘッダ
                case ExWebService.geWebServiceCallKbn.GetOrderListH:
                    // 更新
                    if (objList != null)    
                    {
                        _entityOrderH = (EntityOrderH)objList;

                        // エラー発生時
                        if (_entityH._message != "" && _entityH._message != null)
                        {
                            webService.ProcessingDlgClose();
                            this.utlOrderNo.txtID.Text = "";
                            ExBackgroundWorker.DoWork_Focus(this.utlOrderNo.txtID, 10);
                            return;
                        }

                        if (_entityOrderH._sales_allocation_flg == 1)
                        {
                            MessageBox.Show("売上計上済の為、受注番号：" + this.utlOrderNo.txtID.Text + " は選択できません。");
                            webService.ProcessingDlgClose();
                            this.utlOrderNo.txtID.Text = "";
                            ExBackgroundWorker.DoWork_Focus(this.utlOrderNo.txtID, 10);
                            return;
                        }

                        // 明細データ取得
                        GetDetailOrder(_entityOrderH._id);
                    }
                    // 新規
                    else
                    {
                        MessageBox.Show("受注番号：" + this.utlOrderNo.txtID.Text + " は存在しません。");
                        webService.ProcessingDlgClose();
                        this.utlOrderNo.txtID.Text = "";
                        ExBackgroundWorker.DoWork_Focus(this.utlOrderNo.txtID, 10);
                    }
                    break;
                // 受注明細
                case ExWebService.geWebServiceCallKbn.GetOrderListD:
                    // 2回設定がかかりエラーになる為
                    try
                    {
                        this.dg.ItemsSource = null;
                    }
                    catch
                    {
                        return;
                    }

                    if (objList != null)
                    {
                        _entityListOrderD = (ObservableCollection<EntityOrderD>)objList;
                    }
                    else 
                    {
                        _entityListOrderD = null;
                    }

                    // バインド反映
                    SetBinding();

                    ConverOrderToSales(this._entityH, this._entityListD, this._entityOrderH, this._entityListOrderD);

                    // 明細再計算
                    DataDetail.IsCalcPrice = false;
                    DataDetail.ReCalcDetail(_entityH, _entityListD);
                    DataDetail.IsCalcPrice = true;


                    // 売掛再計算
                    CalcSalesCredit();

                    if (string.IsNullOrEmpty(_entityH._memo))
                    {
                        _entityH._memo = "受注No : " + ExCast.zFormatForID(_entityOrderH._no, Common.gintidFigureSlipNo);
                    }

                    this.dg.ItemsSource = _entityListD;
                    ExBackgroundWorker.DoWork_Focus(this.datNokiYmd, 10);

                    this.utlEstimateNo.txtID.OnFormatString();
                    this.utlOrderNo.txtID.OnFormatString();
                    this.utlEstimateNo.txtID.UpdataFlg = false;
                    this.utlOrderNo.txtID.UpdataFlg = false;

                    break;

                #endregion

                #region 見積

                // 見積ヘッダ
                case ExWebService.geWebServiceCallKbn.GetEstimateListH:
                    // 更新
                    if (objList != null)
                    {
                        _entityEstimateH = (EntityEstimateH)objList;

                        // エラー発生時
                        if (_entityEstimateH._message != "" && _entityEstimateH._message != null)
                        {
                            webService.ProcessingDlgClose();
                            this.utlEstimateNo.txtID.Text = "";
                            ExBackgroundWorker.DoWork_Focus(this.utlEstimateNo.txtID, 10);
                            return;
                        }

                        if (_entityEstimateH._order_allocation_flg == 1)
                        {
                            MessageBox.Show("受注計上済の為、見積番号：" + this.utlEstimateNo.txtID.Text + " は選択できません。");
                            webService.ProcessingDlgClose();
                            this.utlEstimateNo.txtID.Text = "";
                            ExBackgroundWorker.DoWork_Focus(this.utlEstimateNo.txtID, 10);
                            return;
                        }
                        else if (_entityEstimateH._sales_allocation_flg == 1)
                        {
                            MessageBox.Show("売上計上済の為、見積番号：" + this.utlEstimateNo.txtID.Text + " は選択できません。");
                            webService.ProcessingDlgClose();
                            this.utlEstimateNo.txtID.Text = "";
                            ExBackgroundWorker.DoWork_Focus(this.utlEstimateNo.txtID, 10);
                            return;
                        }

                        if (Common.gintEstimateApprovalFlg == 1 && _entityEstimateH._state != 1)
                        {
                            MessageBox.Show("承認されていない為、見積番号：" + this.utlEstimateNo.txtID.Text + " は選択できません。");
                            webService.ProcessingDlgClose();
                            this.utlEstimateNo.txtID.Text = "";
                            ExBackgroundWorker.DoWork_Focus(this.utlEstimateNo.txtID, 10);
                            return;
                        }

                        // 明細データ取得
                        GetDetailEstimate(_entityEstimateH._id);
                    }
                    // 新規
                    else
                    {
                        MessageBox.Show("見積番号：" + this.utlEstimateNo.txtID.Text + " は存在しません。");
                        webService.ProcessingDlgClose();
                        this.utlEstimateNo.txtID.Text = "";
                        ExBackgroundWorker.DoWork_Focus(this.utlEstimateNo.txtID, 10);
                    }
                    break;
                // 見積明細
                case ExWebService.geWebServiceCallKbn.GetEstimateListD:
                    // 2回設定がかかりエラーになる為
                    try
                    {
                        this.dg.ItemsSource = null;
                    }
                    catch
                    {
                        return;
                    }

                    if (objList != null)
                    {
                        _entityListEstimateD = (ObservableCollection<EntityEstimateD>)objList;
                    }
                    else
                    {
                        _entityListEstimateD = null;
                    }

                    // バインド反映
                    SetBinding();

                    ConverEstimateToSales(this._entityH, this._entityListD, this._entityEstimateH, this._entityListEstimateD);

                    // 明細再計算
                    DataDetail.IsCalcPrice = false;
                    DataDetail.ReCalcDetail(_entityH, _entityListD);
                    DataDetail.IsCalcPrice = true;

                    this.dg.ItemsSource = _entityListD;

                    // 売掛再計算
                    CalcSalesCredit();

                    if (string.IsNullOrEmpty(_entityH._memo))
                    {
                        _entityH._memo = "見積No : " + ExCast.zFormatForID(this._entityEstimateH._no, Common.gintidFigureSlipNo);
                    }

                    ExBackgroundWorker.DoWork_Focus(this.utlOrderNo.txtID, 10);

                    this.utlEstimateNo.txtID.OnFormatString();
                    this.utlOrderNo.txtID.OnFormatString();
                    this.utlEstimateNo.txtID.UpdataFlg = false;
                    this.utlOrderNo.txtID.UpdataFlg = false;

                    break;

                #endregion

                default:
                    break;
            }
        }

        #endregion

        #endregion

        #region Data Update

        // データ追加・更新・削除
        private void UpdateData(Common.geUpdateType upd)
        {
            object[] prm = new object[6];

            prm[0] = (int)upd;
            prm[1] = ExCast.zCLng(this.utlNo.txtID.Text.Trim());
            prm[2] = _entityH;
            prm[3] = _entityListD;
            prm[4] = _before_entityH;
            prm[5] = _before_entityListD;
            webService.objPerent = this;
            webService.CallWebService(_UpdWebServiceCallKbn,
                                      ExWebService.geDialogDisplayFlg.Yes,
                                      ExWebService.geDialogCloseFlg.Yes,
                                      prm);
        }

        public override void DataUpdate(int intKbn, string errMessage)
        {
            if ((ExWebService.geWebServiceCallKbn)intKbn == _UpdWebServiceCallKbn)
            {
                if (string.IsNullOrEmpty(errMessage))
                {
                    btnF2_Click(null, null);
                }
            }
        }

        #endregion

        #region Input Check

        // 入力チェック
        public override void InputCheckUpdate()
        {
            #region Field

            string errMessage = "";
            string warnMessage = "";
            int _selectIndex = 0;
            int _selectColumn = 0;
            bool IsDetailExists = false;
            Control errCtl = null;
            List<string> list_warn_commodity = new List<string>();

            #endregion

            try
            {
                #region

                if (Common.gblnDesynchronizeLock == true)
                {
                    errMessage += "現在排他処理中です。再度実行してください。" + Environment.NewLine;
                }

                #endregion

                #region ヘッダチェック

                #region 必須チェック

                // 売上日
                if (string.IsNullOrEmpty(_entityH._sales_ymd))
                {
                    errMessage += "売上日が入力されていません。" + Environment.NewLine;
                    if (errCtl == null) errCtl = this.datSalesYmd;
                }

                // 入力担当者
                if (_entityH._update_person_id == 0)
                {
                    errMessage += "入力担当者が入力(選択)されていません。" + Environment.NewLine;
                    if (errCtl == null) errCtl = this.utlPerson.txtID;
                }

                // 得意先
                if (string.IsNullOrEmpty(_entityH._customer_id))
                {
                    errMessage += "得意先が入力(選択)されていません。" + Environment.NewLine;
                    if (errCtl == null) errCtl = this.utlCustomer.txtID;
                }

                // 税転換
                if (_entityH._tax_change_id == 0)
                {
                    errMessage += "税転換が入力(選択)されていません。" + Environment.NewLine;
                    if (errCtl == null) errCtl = this.utlTax.txtID;
                }

                // 取引区分
                if (_entityH._business_division_id == 0)
                {
                    errMessage += "取引区分が入力(選択)されていません。" + Environment.NewLine;
                    if (errCtl == null) errCtl = this.utlBusiness.txtID;
                }

                #endregion

                #region 入力チェック

                // 入力担当者
                if (_entityH._update_person_id != 0 && string.IsNullOrEmpty(this.utlPerson.txtNm.Text.Trim()))
                {
                    errMessage += "入力担当者が適切に入力(選択)されていません。" + Environment.NewLine;
                    if (errCtl == null) errCtl = this.utlPerson.txtID;
                }

                // 得意先
                if (_entityH._customer_id != "" && string.IsNullOrEmpty(this.utlCustomer.txtNm.Text.Trim()))
                {
                    errMessage += "得意先が適切に入力(選択)されていません。" + Environment.NewLine;
                    if (errCtl == null) errCtl = this.utlCustomer.txtID;
                }

                // 納入先
                if (_entityH._supplier_id != "" && string.IsNullOrEmpty(this.utlSupply.txtNm.Text.Trim()))
                {
                    errMessage += "納入先が適切に入力(選択)されていません。" + Environment.NewLine;
                    if (errCtl == null) errCtl = this.utlSupply.txtID;
                }

                // 税転換
                if (_entityH._tax_change_id != 0 && string.IsNullOrEmpty(this.utlTax.txtNm.Text.Trim()))
                {
                    errMessage += "税転換が適切に入力(選択)されていません。" + Environment.NewLine;
                    if (errCtl == null) errCtl = this.utlTax.txtID;
                }

                // 取引区分
                if (_entityH._business_division_id != 0 && string.IsNullOrEmpty(this.utlBusiness.txtNm.Text.Trim()))
                {
                    errMessage += "取引区分が適切に入力(選択)されていません。" + Environment.NewLine;
                    if (errCtl == null) errCtl = this.utlBusiness.txtID;
                }

                #endregion

                #region 日付チェック

                // 売上日
                if (string.IsNullOrEmpty(_entityH._sales_ymd) == false)
                {
                    if (ExCast.IsDate(_entityH._sales_ymd) == false)
                    {
                        errMessage += "売上日の形式が不正です。(yyyy/mm/dd形式で入力(選択)して下さい)" + Environment.NewLine;
                        if (errCtl == null) errCtl = this.datSalesYmd;
                    }
                }

                // 納入指定日
                if (string.IsNullOrEmpty(_entityH._supply_ymd) == false)
                {
                    if (ExCast.IsDate(_entityH._supply_ymd) == false)
                    {
                        errMessage += "納入指定日の形式が不正です。(yyyy/mm/dd形式で入力(選択)して下さい)" + Environment.NewLine;
                        if (errCtl == null) errCtl = this.datNokiYmd;
                    }
                }

                #endregion

                #region 日付変換

                // 受注日
                if (string.IsNullOrEmpty(_entityH._sales_ymd) == false)
                {
                    _entityH._sales_ymd = ExCast.zConvertToDate(_entityH._sales_ymd).ToString("yyyy/MM/dd");

                }

                // 納入指定日
                if (string.IsNullOrEmpty(_entityH._supply_ymd) == false)
                {
                    _entityH._supply_ymd = ExCast.zConvertToDate(_entityH._supply_ymd).ToString("yyyy/MM/dd");
                }

                #endregion

                #region 正数チェック

                if (ExCast.zCLng(_entityH._no) < 0)
                {
                    errMessage += "受注番号には正の整数を入力して下さい。" + Environment.NewLine;
                }

                if (ExCast.zCLng(_entityH._estimateno) < 0)
                {
                    errMessage += "見積番号には正の整数を入力して下さい。" + Environment.NewLine;
                    if (errCtl == null) errCtl = this.utlEstimateNo.txtID;
                }

                #endregion

                #region 範囲チェック

                if (ExCast.zCLng(_entityH._no) > 999999999999999)
                {
                    errMessage += "売上番号には15桁以内の正の整数を入力して下さい。" + Environment.NewLine;
                }

                if (ExCast.zCLng(_entityH._order_no) > 999999999999999)
                {
                    errMessage += "受注番号には15桁以内の正の整数を入力して下さい。" + Environment.NewLine;
                }

                if (ExCast.zCLng(_entityH._estimateno) > 999999999999999)
                {
                    errMessage += "見積番号には15桁以内の正の整数を入力して下さい。" + Environment.NewLine;
                    if (errCtl == null) errCtl = this.utlEstimateNo.txtID;
                }
                if (ExString.LenB(_entityH._memo) > 94)
                {
                    errMessage += "摘要には全角47桁文字以内(半角94桁文字以内)を入力して下さい。" + Environment.NewLine;
                    if (errCtl == null) errCtl = this.txtMemo;
                }

                #endregion

                #endregion

                #region 明細チェック

                #region 明細再計算

                // 明細再計算
                DataDetail.IsCalcPrice = false;
                DataDetail.ReCalcDetail(_entityH, _entityListD);
                DataDetail.IsCalcPrice = true;

                #endregion

                #region 明細入力チェック

                if (_entityListD == null)
                {
                    errMessage += "明細が入力されていません。" + Environment.NewLine;
                }

                if (_entityListD.Count == 0)
                {
                    errMessage += "明細が入力されていません。" + Environment.NewLine;
                }

                #endregion

                for (int i = 0; i <= _entityListD.Count - 1; i++)
                {
                    if (_entityListD[i]._breakdown_id <= 3 && string.IsNullOrEmpty(_entityListD[i]._commodity_id))
                    {
                        #region 商品未選択チェック

                        // 摘要以外で商品未選択は登録されない
                        if (!string.IsNullOrEmpty(_entityListD[i]._commodity_name) ||
                            _entityListD[i]._unit_id != 1 ||
                            _entityListD[i]._enter_number != 0 ||
                            _entityListD[i]._case_number != 0 ||
                            _entityListD[i]._number != 0 ||
                            _entityListD[i]._unit_price != 0 ||
                            _entityListD[i]._price != 0 ||
                            _entityListD[i]._tax_division_id != 1 ||
                            !string.IsNullOrEmpty(_entityListD[i]._memo))
                        {
                            // なんらかの入力がされている場合、警告を出す
                            warnMessage += (i + 1).ToString() + "行目は商品が選択されていない為、登録されません。" + Environment.NewLine;
                            if (errCtl == null)
                            {
                                errCtl = this.dg;
                                _selectIndex = i;
                                _selectColumn = 1;
                            }
                        }

                        #endregion
                    }
                    else
                    {
                        #region 必須チェック

                        // 内訳
                        if (string.IsNullOrEmpty(_entityListD[i]._breakdown_nm))
                        {
                            errMessage += (i + 1).ToString() + "行目の内訳を選択して下さい。" + Environment.NewLine;
                            if (errCtl == null)
                            {
                                errCtl = this.dg;
                                _selectIndex = i;
                                _selectColumn = 3;
                            }
                        }

                        switch (ExCast.zCStr(_entityListD[i]._breakdown_nm))
                        {
                            case "通常":       // 通常
                            case "値引":       // 値引
                            case "諸経費":     // 諸経費
                                // 単価
                                if (ExCast.zCDbl(_entityListD[i]._unit_price) == 0)
                                {
                                    errMessage += (i + 1).ToString() + "行目の単価が0です。" + Environment.NewLine;
                                    if (errCtl == null)
                                    {
                                        errCtl = this.dg;
                                        _selectIndex = i;
                                        _selectColumn = 9;
                                    }
                                }
                                // 数量
                                if (ExCast.zCDbl(_entityListD[i]._number) == 0)
                                {
                                    errMessage += (i + 1).ToString() + "行目の数量が0です。" + Environment.NewLine;
                                    if (errCtl == null)
                                    {
                                        errCtl = this.dg;
                                        _selectIndex = i;
                                        _selectColumn = 8;
                                    }
                                }
                                // 金額
                                if (ExCast.zCDbl(_entityListD[i]._price) == 0)
                                {
                                    errMessage += (i + 1).ToString() + "行目の金額が0です。" + Environment.NewLine;
                                    if (errCtl == null)
                                    {
                                        errCtl = this.dg;
                                        _selectIndex = i;
                                        _selectColumn = 10;
                                    }
                                }
                                // 課税区分
                                if (ExCast.zCStr(_entityListD[i]._tax_division_nm) == "")
                                {
                                    errMessage += (i + 1).ToString() + "行目の課税区分を選択して下さい。" + Environment.NewLine;
                                    if (errCtl == null)
                                    {
                                        errCtl = this.dg;
                                        _selectIndex = i;
                                        _selectColumn = 11;
                                    }
                                }
                                break;
                        }

                        #endregion

                        #region 数値チェック

                        // 入数
                        if (ExCast.IsNumeric(_entityListD[i]._enter_number) == false)
                        {
                            errMessage += (i + 1).ToString() + "行目の入数に数値以外が入力されています。" + Environment.NewLine;
                            if (errCtl == null)
                            {
                                errCtl = this.dg;
                                _selectIndex = i;
                                _selectColumn = 6;
                            }
                        }

                        // ケース数
                        if (ExCast.IsNumeric(_entityListD[i]._case_number) == false)
                        {
                            errMessage += (i + 1).ToString() + "行目のケース数に数値以外が入力されています。" + Environment.NewLine;
                            if (errCtl == null)
                            {
                                errCtl = this.dg;
                                _selectIndex = i;
                                _selectColumn = 7;
                            }
                        }
                        // 数量
                        if (ExCast.IsNumeric(_entityListD[i]._number) == false)
                        {
                            errMessage += (i + 1).ToString() + "行目の数量に数値以外が入力されています。" + Environment.NewLine;
                            if (errCtl == null)
                            {
                                errCtl = this.dg;
                                _selectIndex = i;
                                _selectColumn = 8;
                            }
                        }
                        // 単価
                        if (ExCast.IsNumeric(_entityListD[i]._unit_price) == false)
                        {
                            errMessage += (i + 1).ToString() + "行目の単価に数値以外が入力されています。" + Environment.NewLine;
                            if (errCtl == null)
                            {
                                errCtl = this.dg;
                                _selectIndex = i;
                                _selectColumn = 9;
                            }
                        }
                        // 金額
                        if (ExCast.IsNumeric(_entityListD[i]._price) == false)
                        {
                            errMessage += (i + 1).ToString() + "行目の金額に数値以外が入力されています。" + Environment.NewLine;
                            if (errCtl == null)
                            {
                                errCtl = this.dg;
                                _selectIndex = i;
                                _selectColumn = 10;
                            }
                        }

                        #endregion

                        #region 正数チェック

                        if (ExCast.zCDbl(_entityListD[i]._enter_number) < 0)
                        {
                            errMessage += (i + 1).ToString() + "行目の入数に正の数値を入力して下さい)" + Environment.NewLine;
                            if (errCtl == null)
                            {
                                errCtl = this.dg;
                                _selectIndex = i;
                                _selectColumn = 6;
                            }
                        }

                        #endregion

                        #region 範囲チェック

                        // 入数
                        if (ExCast.zCDbl(_entityListD[i]._enter_number) > 9999)
                        {
                            errMessage += (i + 1).ToString() + "行目の入数に9,999以内の数値を入力して下さい。" + Environment.NewLine;
                            if (errCtl == null)
                            {
                                errCtl = this.dg;
                                _selectIndex = i;
                                _selectColumn = 6;
                            }
                        }

                        // ケース数
                        if (ExCast.zCDbl(_entityListD[i]._case_number) > 9999)
                        {
                            errMessage += (i + 1).ToString() + "行目のケース数に9,999以内の数値を入力して下さい。" + Environment.NewLine;
                            if (errCtl == null)
                            {
                                errCtl = this.dg;
                                _selectIndex = i;
                                _selectColumn = 7;
                            }
                        }
                        if (ExCast.zCDbl(_entityListD[i]._case_number) < -9999)
                        {
                            errMessage += (i + 1).ToString() + "行目のケース数に-9,999以上の数値を入力して下さい。" + Environment.NewLine;
                            if (errCtl == null)
                            {
                                errCtl = this.dg;
                                _selectIndex = i;
                                _selectColumn = 7;
                            }
                        }

                        // 数量
                        if (ExCast.zCDbl(_entityListD[i]._number) > 99999999)
                        {
                            errMessage += (i + 1).ToString() + "行目の数量に99,999,999以内の数値を入力して下さい。" + Environment.NewLine;
                            if (errCtl == null)
                            {
                                errCtl = this.dg;
                                _selectIndex = i;
                                _selectColumn = 8;
                            }
                        }
                        if (ExCast.zCDbl(_entityListD[i]._number) < -99999999)
                        {
                            errMessage += (i + 1).ToString() + "行目の数量に-99,999,999以上の数値を入力して下さい。" + Environment.NewLine;
                            if (errCtl == null)
                            {
                                errCtl = this.dg;
                                _selectIndex = i;
                                _selectColumn = 8;
                            }
                        }

                        // 単価
                        if (ExCast.zCDbl(_entityListD[i]._unit_price) > 99999999)
                        {
                            errMessage += (i + 1).ToString() + "行目の単価に99,999,999以内の数値を入力して下さい。" + Environment.NewLine;
                            if (errCtl == null)
                            {
                                errCtl = this.dg;
                                _selectIndex = i;
                                _selectColumn = 9;
                            }
                        }
                        if (ExCast.zCDbl(_entityListD[i]._unit_price) < -99999999)
                        {
                            errMessage += (i + 1).ToString() + "行目の単価に-99,999,999以上の数値を入力して下さい。" + Environment.NewLine;
                            if (errCtl == null)
                            {
                                errCtl = this.dg;
                                _selectIndex = i;
                                _selectColumn = 9;
                            }
                        }

                        // 金額
                        if (ExCast.zCDbl(_entityListD[i]._price) > 99999999999)
                        {
                            errMessage += (i + 1).ToString() + "行目の金額に99,999,999,999以内の数値を入力して下さい。" + Environment.NewLine;
                            if (errCtl == null)
                            {
                                errCtl = this.dg;
                                _selectIndex = i;
                                _selectColumn = 10;
                            }
                        }
                        if (ExCast.zCDbl(_entityListD[i]._price) < -99999999999)
                        {
                            errMessage += (i + 1).ToString() + "行目の金額に-99,999,999,999以上の数値を入力して下さい。" + Environment.NewLine;
                            if (errCtl == null)
                            {
                                errCtl = this.dg;
                                _selectIndex = i;
                                _selectColumn = 10;
                            }
                        }

                        // 備考
                        if (ExString.LenB(_entityListD[i]._memo) > 14)
                        {
                            errMessage += (i + 1).ToString() + "行目の備考に全角7桁文字以内(半角14桁文字以内)を入力して下さい。" + Environment.NewLine;
                            if (errCtl == null)
                            {
                                errCtl = this.dg;
                                _selectIndex = i;
                                _selectColumn = 12;
                            }
                        }

                        // 課税区分
                        if (ExCast.zCInt(_entityListD[i]._tax_division_id) == 1 && ExCast.zCStr(_entityListD[i]._tax_division_nm) != "課税")
                        {
                            errMessage += (i + 1).ToString() + "行目の課税区分が不正です。(課税で1以外)" + Environment.NewLine;
                            if (errCtl == null)
                            {
                                errCtl = this.dg;
                                _selectIndex = i;
                                _selectColumn = 12;
                            }
                        }

                        if (ExCast.zCInt(_entityListD[i]._tax_division_id) == 2 && ExCast.zCStr(_entityListD[i]._tax_division_nm) != "非課税")
                        {
                            errMessage += (i + 1).ToString() + "行目の課税区分が不正です。(非課税で2以外)" + Environment.NewLine;
                            if (errCtl == null)
                            {
                                errCtl = this.dg;
                                _selectIndex = i;
                                _selectColumn = 12;
                            }
                        }

                        #endregion

                        #region 在庫チェック

                        // 在庫
                        if (ExCast.zCStr(_entityListD[i]._commodity_id) != "" && ExCast.zCInt(_entityListD[i]._inventory_management_division_id) == 1)
                        {
                            double sum_number = 0;

                            for (int _i = 0; _i <= _entityListD.Count - 1; _i++)
                            {
                                if (ExCast.zCStr(_entityListD[i]._commodity_id) == ExCast.zCStr(_entityListD[_i]._commodity_id))
                                {
                                    sum_number += ExCast.zCDbl(_entityListD[_i]._number);
                                }
                            }

                            if (ExCast.zCDbl(_entityListD[i]._inventory_number) - sum_number < 0)
                            {
                                bool _set = true;
                                foreach (string item in list_warn_commodity)
                                {
                                    if (item == ExCast.zCStr(_entityListD[i]._commodity_id))
                                    {
                                        _set = false;
                                    }
                                }

                                if (_set == true)
                                {
                                    warnMessage += "商品コード：" + _entityListD[i]._commodity_id + "(" + _entityListD[i]._commodity_name + ") の在庫数がマイナスになります。" + Environment.NewLine;
                                    if (errCtl == null)
                                    {
                                        errCtl = this.dg;
                                        _selectIndex = i;
                                        _selectColumn = 3;
                                    }
                                    list_warn_commodity.Add(ExCast.zCStr(_entityListD[i]._commodity_id));
                                }
                            }
                        }

                        #endregion

                        IsDetailExists = true;
                    }
                }

                #region 登録対象データ存在チェック

                if (IsDetailExists == false)
                {
                    errMessage += "明細の登録対象データがありません。" + Environment.NewLine;
                    if (errCtl == null)
                    {
                        errCtl = this.dg;
                        _selectIndex = 0;
                        _selectColumn = 1;
                    }
                }

                #endregion

                #region 掛売上チェック

                // 掛売上 or 都度請求
                if ((_entityH._business_division_id == 1 || _entityH._business_division_id == 3) && _entityH._credit_limit_price != 0)
                {
                    //if (_entityH._credit_limit_price < _entityH._sales_credit_price + _entityH._sum_no_tax_price + _entityH._sum_tax)
                    if (_entityH._credit_limit_price < _entityH._sales_credit_price)
                    {
                        warnMessage += "売掛残高が与信限度額を超えます。" + Environment.NewLine;
                        if (errCtl == null)
                        {
                            errCtl = this.dg;
                            _selectIndex = 0;
                            _selectColumn = 1;
                        }
                    }
                }

                #endregion

                #endregion

                #region エラー or 警告時処理

                bool flg = true;

                if (!string.IsNullOrEmpty(errMessage))
                {
                    ExMessageBox.Show(errMessage, Dlg.MessageBox.MessageBoxIcon.Error);
                    flg = false;
                }
                else
                {
                    if (!string.IsNullOrEmpty(warnMessage))
                    {
                        warnMessage += "このまま登録を続行してもよろしいですか？" + Environment.NewLine;
                        ExMessageBox.ResultShow(this, errCtl, warnMessage);
                        flg = false;
                        //if (ExMessageBox.ResultShow(warnMessage) == MessageBoxResult.Cancel)
                        //{
                        //    flg = false;
                        //}
                    }
                }

                this.txtDummy.IsTabStop = false;

                if (flg == false)
                {
                    if (errCtl != null)
                    {
                        switch (errCtl.Name)
                        {
                            case "dg":
                                errCtl.Focus();
                                this.dg.SelectedIndex = _selectIndex;
                                dg.CurrentColumn = dg.Columns[_selectColumn];
                                break;
                            default:
                                ExBackgroundWorker.DoWork_Focus(errCtl, 10);
                                break;
                        }
                    }
                    return;
                }

                #endregion

                #region 更新処理

                switch (this.utlFunctionKey.gFunctionKeyEnable)
                {
                    case Utl_FunctionKey.geFunctionKeyEnable.New:
                    case Utl_FunctionKey.geFunctionKeyEnable.Init:
                        UpdateData(Common.geUpdateType.Insert);
                        break;
                    case Utl_FunctionKey.geFunctionKeyEnable.Upd:
                        UpdateData(Common.geUpdateType.Update);
                        break;
                    default:
                        break;
                }

                #endregion
            }
            finally
            {
                Common.gblnBtnProcLock = false;
                Common.gblnBtnDesynchronizeLock = false;
            }
        }

        public override void ResultMessageBox(MessageBoxResult _MessageBoxResult, Control _errCtl)
        {
            if (_MessageBoxResult == MessageBoxResult.OK)
            {
                #region 更新処理

                switch (this.utlFunctionKey.gFunctionKeyEnable)
                {
                    case Utl_FunctionKey.geFunctionKeyEnable.New:
                    case Utl_FunctionKey.geFunctionKeyEnable.Init:
                        UpdateData(Common.geUpdateType.Insert);
                        break;
                    case Utl_FunctionKey.geFunctionKeyEnable.Upd:
                        UpdateData(Common.geUpdateType.Update);
                        break;
                    default:
                        break;
                }

                #endregion
            }
            else
            {
                if (_errCtl != null)
                {
                    switch (_errCtl.Name)
                    {
                        case "dg":
                            _errCtl.Focus();
                            this.dg.SelectedIndex = _selectIndex;
                            dg.CurrentColumn = dg.Columns[_selectColumn];
                            break;
                        default:
                            ExBackgroundWorker.DoWork_Focus(_errCtl, 10);
                            break;
                    }
                }
            }
        }

        // 入力チェック
        private void InputCheckDelete()
        {
            try
            {
                if (this.utlNo.txtID.Text.Trim() == "")
                {
                    ExMessageBox.Show("受注データが選択されていません。");
                    return;
                }

                if (this._entityH == null)
                {
                    ExMessageBox.Show("受注データが選択されていません。");
                    return;
                }

                if (this._entityH._id == 0)
                {
                    ExMessageBox.Show("受注データが選択されていません。");
                    return;
                }

                UpdateData(Common.geUpdateType.Delete);
            }
            finally
            {
                Common.gblnBtnProcLock = false;
                Common.gblnBtnDesynchronizeLock = false;
            }
        }

        #endregion

        #region DataGrid Events

        private void dg_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            try
            {
                beforeValue = "";
                beforeSelectedIndex = -1;
                beforeSelectedIndex = this.dg.SelectedIndex;

                EntitySalesD entity = (EntitySalesD)e.Row.DataContext;
                switch (e.Column.DisplayIndex)
                {
                    case 1:         // 内訳
                        beforeValue = entity._breakdown_nm;
                        break;
                    case 2:         // 納品区分
                        beforeValue = entity._deliver_division_nm;
                        break;
                    case 3:         // 商品コード
                        beforeValue = entity._commodity_id;
                        break;
                    case 4:         // 商品名
                        beforeValue = entity._commodity_name;
                        break;
                    case 5:         // 単位
                        beforeValue = entity._unit_nm;
                        break;
                    case 6:         // 入数
                        beforeValue = ExCast.zCStr(entity._enter_number);
                        break;
                    case 7:         // ケース数
                        beforeValue = ExCast.zCStr(entity._case_number);
                        break;
                    case 8:         // 数量
                        beforeValue = ExCast.zCStr(entity._number);
                        break;
                    case 9:         // 単価
                        beforeValue = ExCast.zCStr(entity._unit_price);
                        break;
                    case 10:         // 金額
                        beforeValue = ExCast.zCStr(entity._price);
                        break;
                    case 11:         // 備考
                        beforeValue = ExCast.zCStr(entity._memo);
                        break;
                    case 12:         // 課税区分
                        beforeValue = ExCast.zCStr(entity._tax_division_nm);
                        break;
                }
            }
            catch
            {
            }
        }

        private void dg_CellEditEnded(object sender, DataGridCellEditEndedEventArgs e)
        {
            EntitySalesD entity = (EntitySalesD)e.Row.DataContext;

            // コンボボックスID連動
            switch (e.Column.DisplayIndex)
            {
                case 1:         // 内訳
                    if (_entityListD == null) return;
                    if (_entityListD.Count >= dg.SelectedIndex && dg.SelectedIndex != -1)
                    {
                        _entityListD[dg.SelectedIndex]._breakdown_id = MeiNameList.GetID(MeiNameList.geNameKbn.BREAKDOWN_ID, ExCast.zCStr(entity._breakdown_nm));
                        // 消費税
                        if (_entityListD[dg.SelectedIndex]._breakdown_id == 5)
                        {
                            _entityListD[dg.SelectedIndex]._tax_division_nm = "非課税";
                            _entityListD[dg.SelectedIndex]._tax_division_id = MeiNameList.GetID(MeiNameList.geNameKbn.TAX_DIVISION_ID, ExCast.zCStr(_entityListD[dg.SelectedIndex]._tax_division_nm));
                        }
                        // 返品
                        else if (_entityListD[dg.SelectedIndex]._breakdown_id == 6)
                        {
                            DataDetail.CalRedcDetail(_entityListD[dg.SelectedIndex]);
                            DataDetail.CalcSumDetail(_entityH, _entityListD);
                        }
                    }
                    break;
                case 2:         // 納品区分
                    if (_entityListD == null) return;
                    if (_entityListD.Count >= dg.SelectedIndex && dg.SelectedIndex != -1)
                    {
                        _entityListD[dg.SelectedIndex]._deliver_division_id = MeiNameList.GetID(MeiNameList.geNameKbn.DELIVER_DIVISION_ID, ExCast.zCStr(entity._deliver_division_nm));
                        DataDetail.CalcSumDetail(_entityH, _entityListD);       　// 明細合計計算
                    }
                    break;
                case 5:         // 単価
                    if (_entityListD == null) return;
                    if (_entityListD.Count >= dg.SelectedIndex && dg.SelectedIndex != -1)
                        _entityListD[dg.SelectedIndex]._unit_id = MeiNameList.GetID(MeiNameList.geNameKbn.UNIT_ID, ExCast.zCStr(entity._unit_nm));
                    break;
                case 12:        // 課税区分
                    if (_entityListD == null) return;
                    if (_entityListD.Count >= dg.SelectedIndex && dg.SelectedIndex != -1)
                    {
                        _entityListD[dg.SelectedIndex]._tax_division_id = MeiNameList.GetID(MeiNameList.geNameKbn.TAX_DIVISION_ID, ExCast.zCStr(entity._tax_division_nm));
                        // 課税選択で内訳が消費税の場合
                        if (_entityListD[dg.SelectedIndex]._tax_division_id == 1 && _entityListD[dg.SelectedIndex]._breakdown_id == 5)
                        {
                            ExMessageBox.Show("内訳が消費税の場合、課税区分に課税を選択できません。");
                            _entityListD[dg.SelectedIndex]._tax_division_nm = "非課税";
                            _entityListD[dg.SelectedIndex]._tax_division_id = MeiNameList.GetID(MeiNameList.geNameKbn.TAX_DIVISION_ID, ExCast.zCStr(_entityListD[dg.SelectedIndex]._tax_division_nm));
                        }
                    }
                    break;
            }

            if (beforeSelectedIndex == -1) return;

            // 明細計算
            switch (e.Column.DisplayIndex)
            {
                case 3:         // 商品コード
                    if (beforeValue == entity._commodity_id) return;
                    if (Common.gblnDesynchronizeLock == true) return;
                    Common.gblnDesynchronizeLock = true;
                    entity._commodity_id = ExCast.zFormatForID(entity._commodity_id, Common.gintidFigureCommodity);
                    MstData _mstData = new MstData();
                    _mstData.GetMData(MstData.geMDataKbn.Commodity, new string[] { entity._commodity_id, ExCast.zCStr(beforeSelectedIndex) }, this);
                    break;
                case 6:         // 入数
                    if (beforeValue == ExCast.zCStr(entity._enter_number)) return;
                    DataDetail.CalcDetailNumber(beforeSelectedIndex, _entityH, _entityListD);   // 明細数量計算
                    break;
                case 7:         // ケース数
                    if (beforeValue == ExCast.zCStr(entity._case_number)) return;
                    DataDetail.CalcDetailNumber(beforeSelectedIndex, _entityH, _entityListD);   // 明細数量計算
                    break;
                case 8:         // 数量
                    if (beforeValue == ExCast.zCStr(entity._number)) return;
                    DataDetail.CalcDetail(beforeSelectedIndex, _entityH, _entityListD);       　// 明細計算
                    //OrderDetailData.CalcDetailNumber(dg.SelectedIndex, _entityH, _entityListD);   // 明細数量計算
                    break;
                case 9:         // 単価
                    if (beforeValue == ExCast.zCStr(entity._unit_price)) return;
                    DataDetail.CalcDetail(beforeSelectedIndex, _entityH, _entityListD);         // 明細計算
                    break;
                case 10:        // 金額
                    if (beforeValue == ExCast.zCStr(entity._price)) return;
                    DataDetail.IsCalcPrice = false;
                    DataDetail.CalcDetail(beforeSelectedIndex, _entityH, _entityListD);         // 明細計算
                    DataDetail.IsCalcPrice = true;
                    break;
                case 12:        // 課税区分
                    if (beforeValue == ExCast.zCStr(entity._tax_division_nm)) return;
                    DataDetail.CalcDetail(beforeSelectedIndex, _entityH, _entityListD);         // 明細計算
                    break;
            }
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_entityListD == null)
            {
                txtInventory.Text = "";
                return;
            }

            if (_entityListD.Count >= dg.SelectedIndex && dg.SelectedIndex != -1)
            {
                if (ExCast.zCStr(_entityListD[dg.SelectedIndex]._commodity_id) != "" && ExCast.zCInt(_entityListD[dg.SelectedIndex]._inventory_management_division_id) == 1)
                {
                    txtInventory.Text = ExCast.zCStr(_entityListD[dg.SelectedIndex]._inventory_number);
                }
                else
                {
                    txtInventory.Text = "";
                }

                if (ExCast.zCLng(this._entityH._order_no) != 0)
                {
                    this.txtOrderStillNumber.Text = ExCast.zCStr(_entityListD[dg.SelectedIndex]._order_stay_number);
                }
                else
                {
                    this.txtOrderStillNumber.Text = "";
                }
            }
            else
            {
                txtInventory.Text = "";
                this.txtOrderStillNumber.Text = "";
            }
        }

        private void txtGoodsID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _selectIndex = dg.SelectedIndex;
            _selectColumn = dg.CurrentColumn.DisplayIndex;
            beforeValue = "";
            if (_entityListD == null) return;
            if (_entityListD.Count >= _selectIndex)
            {
                beforeValue = _entityListD[_selectIndex]._commodity_id;
            }

            masterDlg = new Dlg_MstSearch();
            masterDlg.MstKbn = MstData.geMDataKbn.Commodity;
            masterDlg.Show();
            masterDlg.Closed += masterDlg_Closed;
        }

        private void masterDlg_Closed(object sender, EventArgs e)
        {
            Dlg_MstSearch dlg = (Dlg_MstSearch)sender;
            if (Dlg_MstSearch.this_DialogResult == true)
            {
                if (_entityListD == null) return;
                if (_entityListD.Count >= _selectIndex)
                {
                    _entityListD[_selectIndex]._commodity_id = Dlg_MstSearch.this_id.ToString();
                    _entityListD[_selectIndex]._commodity_name = Dlg_MstSearch.this_name.ToString();
                }
            }
            if (beforeValue != _entityListD[_selectIndex]._commodity_id)
            {
                MstData _mstData = new MstData();
                _mstData.GetMData(MstData.geMDataKbn.Commodity, new string[] { _entityListD[_selectIndex]._commodity_id, ExCast.zCStr(_selectIndex) }, this);
            }

            dg.Focus();
            dg.SelectedIndex = _selectIndex;
            dg.CurrentColumn = dg.Columns[_selectColumn];
        }

        private void txtUnitPrice_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _selectIndex = dg.SelectedIndex;
            _selectColumn = dg.CurrentColumn.DisplayIndex;
            beforeValue = "";
            if (_entityListD == null) return;
            if (_entityListD.Count >= _selectIndex)
            {
                beforeValue = ExCast.zCStr(_entityListD[_selectIndex]._unit_price);
            }

            Dlg_UnitPriceSetting unitPriceDlg = new Dlg_UnitPriceSetting();
            unitPriceDlg.kbn = Dlg_UnitPriceSetting.eKbn.Sales;

            // 税転換が内税で明細課税有りの場合
            if ((_entityH._tax_change_id == 4 || _entityH._tax_change_id == 5 || _entityH._tax_change_id == 6) && _entityListD[_selectIndex]._tax_division_id == 1)
            {
                unitPriceDlg.retail_price = _entityListD[_selectIndex]._retail_price_before_tax;
                unitPriceDlg.sales_unit_price = _entityListD[_selectIndex]._sales_unit_price_before_tax;
                unitPriceDlg.sales_cost_price = _entityListD[_selectIndex]._sales_cost_price_before_tax;
            }
            else
            {
                unitPriceDlg.retail_price = _entityListD[_selectIndex]._retail_price_skip_tax;
                unitPriceDlg.sales_unit_price = _entityListD[_selectIndex]._sales_unit_price_skip_tax;
                unitPriceDlg.sales_cost_price = _entityListD[_selectIndex]._sales_cost_price_skip_tax;
            }
            unitPriceDlg.unit_decimal_digit = _entityListD[_selectIndex]._unit_decimal_digit;
            unitPriceDlg.credit_rate = _entityH._credit_rate;
            unitPriceDlg.Closed += unitPriceDlg_Closed;
            unitPriceDlg.Show();
        }

        private void unitPriceDlg_Closed(object sender, EventArgs e)
        {
            Dlg_UnitPriceSetting unitPriceDlg = (Dlg_UnitPriceSetting)sender;
            if (unitPriceDlg.DialogResult == true)
            {
                if (_entityListD == null) return;
                if (_entityListD.Count >= _selectIndex)
                {
                    _entityListD[_selectIndex]._unit_price = unitPriceDlg.return_unit_price;
                }
            }
            if (beforeValue != ExCast.zCStr(_entityListD[_selectIndex]._unit_price))
            {
                DataDetail.CalcDetail(_selectIndex, _entityH, _entityListD);
            }

            dg.Focus();
            dg.SelectedIndex = _selectIndex;
            dg.CurrentColumn = dg.Columns[_selectColumn];
        }

        private void dg_LayoutUpdated(object sender, EventArgs e)
        {
            if (this.utlFunctionKey != null)
            {
                if (this.utlFunctionKey.gFunctionKeyEnable == Utl_FunctionKey.geFunctionKeyEnable.Sel)
                {
                    ExVisualTreeHelper.SetEnabled(this.dg, false);
                }
            }
        }

        #endregion

        #region Master Data Select

        public override void MstDataSelect(ExWebServiceMst.geWebServiceMstNmCallKbn intKbn, svcMstData.EntityMstData mst)
        {
            try
            {
                svcMstData.EntityMstData _mst = null;
                _mst = mst;

                switch (intKbn)
                {
                    case ExWebServiceMst.geWebServiceMstNmCallKbn.GetCustomer:
                        // _PropertyChangedにて設定
                        break;
                    case ExWebServiceMst.geWebServiceMstNmCallKbn.GetCommodity:
                        if (Common.gblnDesynchronizeLock == false) return;
                        if (_mst == null) return;

                        // attribute20に選択された行が設定されてくる
                        if (string.IsNullOrEmpty(_mst.attribute20))
                        {
                            // 商品から明細へ
                            DataDetail.SetCommodityToDetail(dg.SelectedIndex, _entityH, _entityListD, _mst);
                            // 明細再計算
                            DataDetail.ReCalcDetail(_entityH, _entityListD);
                            // 明細フッターセット
                            SetDetailFooter();
                        }
                        else
                        {
                            if (_entityListD.Count >= ExCast.zCInt(_mst.attribute20) + 1)
                            {
                                // 商品から明細へ
                                DataDetail.SetCommodityToDetail(ExCast.zCInt(_mst.attribute20), _entityH, _entityListD, _mst);
                                // 明細再計算
                                DataDetail.ReCalcDetail(_entityH, _entityListD);
                                // 明細フッターセット
                                SetDetailFooter();                                      
                            }
                        }
                        break;
                }
            }
            finally
            {
                Common.gblnDesynchronizeLock = false;
            }
        }

        #endregion

        #region Detail

        private void SetInitCombo(ref EntitySalesD entityD)
        {
            // コンボボックス初期選択
            List<string> lst;
            lst = MeiNameList.GetListMei(MeiNameList.geNameKbn.BREAKDOWN_ID);
            entityD._breakdown_nm = lst[0];
            entityD._breakdown_id = MeiNameList.GetID(MeiNameList.geNameKbn.BREAKDOWN_ID, lst[0]);

            lst = MeiNameList.GetListMei(MeiNameList.geNameKbn.DELIVER_DIVISION_ID);
            entityD._deliver_division_nm = lst[2];
            entityD._deliver_division_id = MeiNameList.GetID(MeiNameList.geNameKbn.DELIVER_DIVISION_ID, lst[2]);

            lst = MeiNameList.GetListMei(MeiNameList.geNameKbn.UNIT_ID);
            entityD._unit_nm = lst[0];
            entityD._unit_id = MeiNameList.GetID(MeiNameList.geNameKbn.UNIT_ID, lst[0]);

            lst = MeiNameList.GetListMei(MeiNameList.geNameKbn.TAX_DIVISION_ID);
            entityD._tax_division_nm = lst[0];
            entityD._tax_division_id = MeiNameList.GetID(MeiNameList.geNameKbn.TAX_DIVISION_ID, lst[0]);
        }

        // 明細フッターセット
        public void SetDetailFooter()
        {
            // 初期化
            txtInventory.Text = "";

            if (_entityListD == null) return;
            if (_entityListD.Count >= dg.SelectedIndex && dg.SelectedIndex != -1)
            {
                txtInventory.Text = ExCast.zCStr(_entityListD[dg.SelectedIndex]._inventory_number);
            }
        }

        #endregion

        #region PropertyChanged

        private void _PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string _prop = e.PropertyName;
            if (_prop == null) _prop = "";
            if (_prop.Length > 0)
            {
                if (_prop.Substring(0, 1) == "_")
                {
                    _prop = _prop.Substring(1, _prop.Length - 1);
                }
            }

            switch (_prop)
            {
                case "customer_name":
                    if (Common.gblnDesynchronizeLock == false) return;

                    string _before = _entityH._supplier_id;
                    _entityH._supplier_id = "";
                    _entityH._supplier_id = _before;

                    // 明細再計算
                    DataDetail.ReCalcDetail(_entityH, _entityListD);
                    Common.gblnDesynchronizeLock = false;
                    break;
                case "business_division_id":
                    // 現金売上、都度請求時
                    if (_entityH._business_division_id == 2 || _entityH._business_division_id == 3)
                    {
                        switch (_entityH._tax_change_id)
                        {
                            case 0:
                            case 1:     // 外税伝票計
                            case 2:     // 外税明細単位
                            case 4:     // 内税伝票計
                            case 5:     // 内税伝票計
                            case 7:     // 非課税
                                break;
                            default:
                                if (_entityH._business_division_id == 2)
                                {
                                    ExMessageBox.Show("取引区分に「現金売上」指定時は請求単位の税転換を指定できません。");
                                }
                                else
                                {
                                    ExMessageBox.Show("取引区分に「都度請求」指定時は請求単位の税転換を指定できません。");
                                }
                                _entityH._tax_change_id = 0;
                                break;
                        }
                    }

                    CalcSalesCredit();

                    break;
                case "tax_change_id":
                    // 現金売上、都度請求時
                    if (_entityH._business_division_id == 2 || _entityH._business_division_id == 3)
                    {
                        switch (_entityH._tax_change_id)
                        {
                            case 0:
                            case 1:     // 外税伝票計
                            case 2:     // 外税明細単位
                            case 4:     // 内税伝票計
                            case 5:     // 内税伝票計
                            case 7:     // 非課税
                                break;
                            default:
                                if (_entityH._business_division_id == 2)
                                {
                                    ExMessageBox.Show("取引区分に「現金売上」指定時は請求単位の税転換を指定できません。");
                                }
                                else
                                {
                                    ExMessageBox.Show("取引区分に「都度請求」指定時は請求単位の税転換を指定できません。");
                                }
                                _entityH._tax_change_id = 0;
                                break;
                        }
                    }

                    if (_entityListD == null) return;
                    if (_entityListD.Count == 0) return;
                    if (dg.ItemsSource == null) return;

                    // 明細再計算
                    DataDetail.ReCalcDetail(_entityH, _entityListD);

                    break;
                case "sum_tax":
                case "sum_no_tax_price":
                    this.txtSumPrice.Text = ExCast.zCStr(ExCast.zCDbl(_entityH._sum_no_tax_price) + ExCast.zCDbl(_entityH._sum_tax));
                    this.txtSumPrice.OnFormatString();
                    CalcSalesCredit();
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Calc Sales Credit

        private void CalcSalesCredit()
        {
            switch (this.utlFunctionKey.gFunctionKeyEnable)
            {
                case Utl_FunctionKey.geFunctionKeyEnable.Upd:
                    switch (_entityH._business_division_id)
                    {
                        case 1:
                        case 3:
                            double _before_credit_price = _before_entityH._sales_credit_price - (_before_entityH._sum_no_tax_price + _before_entityH._sum_tax);
                            this.txtSalesLimitPrice.Text = ExCast.zCStr(_before_credit_price + ExCast.zCDbl(this.txtSumPrice.Text));
                            break;
                        default:
                            this.txtSalesLimitPrice.Text = ExCast.zCStr(_entityH._before_sales_credit_price);
                            break;
                    }
                    break;
                default:
                    this.txtSalesLimitPrice.Text = ExCast.zCStr(_entityH._before_sales_credit_price);
                    break;
            }
            this.txtSalesLimitPrice.OnFormatString();
        }

        #endregion

        #region ConverEstimateToSales

        private void ConverEstimateToSales(EntitySalesH _entitySalesH,
                                           ObservableCollection<EntitySalesD> _entitySalesListD,
                                           EntityEstimateH _entityEstimateH,
                                           ObservableCollection<EntityEstimateD> _entityListEstimateD)
        {
            #region Set Entity Head

            _entitySalesH._order_no = 0;
            //_entitySalesH._sales_ymd = _entityEstimateH.or;

            this.utlCustomer.Is_MstID_Changed = false;
            this.utlSupply.Is_MstID_Changed = false;

            _entitySalesH._customer_id = _entityEstimateH._customer_id;
            _entitySalesH._customer_name = _entityEstimateH._customer_name;

            _entitySalesH._supplier_id = _entityEstimateH._supplier_id;
            _entitySalesH._supplier_name = _entityEstimateH._supplier_name;

            this.utlCustomer.Is_MstID_Changed = true;
            this.utlSupply.Is_MstID_Changed = true;
            this.utlCustomer.MstID_Changed(_entityEstimateH, new PropertyChangedEventArgs("customer_id"));
            this.utlSupply.MstID_Changed(_entityEstimateH, new PropertyChangedEventArgs("supplier_id"));

            _entitySalesH._tax_change_id = _entityEstimateH._tax_change_id;
            _entitySalesH._tax_change_name = _entityEstimateH._tax_change_name;

            _entitySalesH._business_division_id = _entityEstimateH._business_division_id;
            _entitySalesH._business_division_name = _entityEstimateH._business_division_name;

            _entitySalesH._supply_ymd = _entityEstimateH._supply_ymd;
            _entitySalesH._sum_enter_number = _entityEstimateH._sum_enter_number;
            _entitySalesH._sum_case_number = _entityEstimateH._sum_case_number;
            _entitySalesH._sum_number = _entityEstimateH._sum_number;
            _entitySalesH._sum_unit_price = _entityEstimateH._sum_unit_price;
            _entitySalesH._sum_sales_cost = _entityEstimateH._sum_sales_cost;
            _entitySalesH._sum_tax = _entityEstimateH._sum_tax;
            _entitySalesH._sum_no_tax_price = _entityEstimateH._sum_no_tax_price;
            _entitySalesH._sum_price = _entityEstimateH._sum_price;
            _entitySalesH._sum_profits = _entityEstimateH._sum_profits;
            _entitySalesH._profits_percent = _entityEstimateH._profits_percent;
            _entitySalesH._credit_limit_price = _entityEstimateH._credit_limit_price;
            _entitySalesH._sales_credit_price = _entityEstimateH._sales_credit_price;
            _entitySalesH._before_sales_credit_price = _entityEstimateH._sales_credit_price;

            _entitySalesH._invoice_id = _entityEstimateH._invoice_id;
            _entitySalesH._invoice_name = _entityEstimateH._invoice_name;

            _entitySalesH._credit_rate = _entityEstimateH._credit_rate;
            _entitySalesH._unit_kind_id = _entityEstimateH._unit_kind_id;

            _entitySalesH._invoice_state = "";
            _entitySalesH._receipt_receivable_kbn_nm = "消込未";

            _entitySalesH._memo = _entityEstimateH._memo;

            //_entitySalesH._update_person_id = ExCast.zCInt(dt.DefaultView[0]["UPDATE_PERSON_ID"]);
            //_entitySalesH._update_person_nm = ExCast.zCStr(dt.DefaultView[0]["UPDATE_PERSON_NM"]);

            //_entitySalesH._lock_flg = (int)lockFlg;

            #endregion

            #region Set Entity Detail

            if (_entitySalesListD == null) _entitySalesListD = new ObservableCollection<EntitySalesD>();
            _entitySalesListD.Clear();

            for (int i = 0; i <= _entityListEstimateD.Count - 1; i++)
            {
                EntitySalesD _entityD = new EntitySalesD();
                _entityD._id = _entitySalesH._id;
                _entityD._rec_no = _entityListEstimateD[i]._rec_no;
                _entityD._breakdown_id = _entityListEstimateD[i]._breakdown_id;
                _entityD._breakdown_nm = _entityListEstimateD[i]._breakdown_nm;
                List<string> lst;
                lst = MeiNameList.GetListMei(MeiNameList.geNameKbn.DELIVER_DIVISION_ID);
                _entityD._deliver_division_nm = lst[2];
                _entityD._deliver_division_id = MeiNameList.GetID(MeiNameList.geNameKbn.DELIVER_DIVISION_ID, lst[2]);
                //_entityD._deliver_division_id = _entityListEstimateD[i]._deliver_division_id;
                //_entityD._deliver_division_nm = _entityListEstimateD[i]._deliver_division_nm;
                _entityD._commodity_id = _entityListEstimateD[i]._commodity_id;
                _entityD._commodity_name = _entityListEstimateD[i]._commodity_name;
                _entityD._unit_id = _entityListEstimateD[i]._unit_id;
                _entityD._unit_nm = _entityListEstimateD[i]._unit_nm;
                _entityD._enter_number = _entityListEstimateD[i]._enter_number;
                _entityD._case_number = _entityListEstimateD[i]._case_number;
                _entityD._number = _entityListEstimateD[i]._number;
                _entityD._order_number = _entityListEstimateD[i]._number;
                _entityD._order_stay_number = 0;
                _entityD._unit_price = _entityListEstimateD[i]._unit_price;
                _entityD._sales_cost = _entityListEstimateD[i]._sales_cost;
                _entityD._tax = _entityListEstimateD[i]._tax;
                _entityD._no_tax_price = _entityListEstimateD[i]._no_tax_price;
                _entityD._price = _entityListEstimateD[i]._price;
                _entityD._profits = _entityListEstimateD[i]._profits;
                _entityD._profits_percent = _entityListEstimateD[i]._profits_percent;
                _entityD._memo = _entityListEstimateD[i]._memo;
                _entityD._tax_division_id = _entityListEstimateD[i]._tax_division_id;
                _entityD._tax_division_nm = _entityListEstimateD[i]._tax_division_nm;
                _entityD._tax_percent = _entityListEstimateD[i]._tax_percent;
                _entityD._inventory_number = _entityListEstimateD[i]._inventory_number;
                _entityD._inventory_management_division_id = _entityListEstimateD[i]._inventory_management_division_id;
                _entityD._number_decimal_digit = _entityListEstimateD[i]._number_decimal_digit;
                _entityD._unit_decimal_digit = _entityListEstimateD[i]._unit_decimal_digit;
                _entitySalesListD.Add(_entityD);

            }

            #endregion
        }

        #endregion

        #region ConverOrderToSales

        private void ConverOrderToSales(EntitySalesH _entitySalesH,
                                        ObservableCollection<EntitySalesD> _entitySalesListD,
                                        EntityOrderH _entityOrderH,
                                        ObservableCollection<EntityOrderD> _entityListOrderD)
        {
            #region Set Entity Head

            _entitySalesH._estimateno = _entityOrderH._estimateno;
            //_entitySalesH._sales_ymd = _entityOrderH.or;

            this.utlCustomer.Is_MstID_Changed = false;
            this.utlSupply.Is_MstID_Changed = false;

            _entitySalesH._customer_id = _entityOrderH._customer_id;
            _entitySalesH._customer_name = _entityOrderH._customer_name;

            _entitySalesH._supplier_id = _entityOrderH._supplier_id;
            _entitySalesH._supplier_name = _entityOrderH._supplier_name;

            this.utlCustomer.Is_MstID_Changed = true;
            this.utlSupply.Is_MstID_Changed = true;
            this.utlCustomer.MstID_Changed(_entityOrderH, new PropertyChangedEventArgs("customer_id"));
            this.utlSupply.MstID_Changed(_entityOrderH, new PropertyChangedEventArgs("supplier_id"));

            _entitySalesH._tax_change_id = _entityOrderH._tax_change_id;
            _entitySalesH._tax_change_name = _entityOrderH._tax_change_name;

            _entitySalesH._business_division_id = _entityOrderH._business_division_id;
            _entitySalesH._business_division_name = _entityOrderH._business_division_name;

            _entitySalesH._supply_ymd = _entityOrderH._supply_ymd;
            _entitySalesH._sum_enter_number = _entityOrderH._sum_enter_number;
            _entitySalesH._sum_case_number = _entityOrderH._sum_case_number;
            _entitySalesH._sum_number = _entityOrderH._sum_number;
            _entitySalesH._sum_unit_price = _entityOrderH._sum_unit_price;
            _entitySalesH._sum_sales_cost = _entityOrderH._sum_sales_cost;
            _entitySalesH._sum_tax = _entityOrderH._sum_tax;
            _entitySalesH._sum_no_tax_price = _entityOrderH._sum_no_tax_price;
            _entitySalesH._sum_price = _entityOrderH._sum_price;
            _entitySalesH._sum_profits = _entityOrderH._sum_profits;
            _entitySalesH._profits_percent = _entityOrderH._profits_percent;
            _entitySalesH._credit_limit_price = _entityOrderH._credit_limit_price;
            _entitySalesH._sales_credit_price = _entityOrderH._sales_credit_price;
            _entitySalesH._before_sales_credit_price = _entityOrderH._sales_credit_price;

            _entitySalesH._invoice_id = _entityOrderH._invoice_id;
            _entitySalesH._invoice_name = _entityOrderH._invoice_name;

            _entitySalesH._credit_rate = _entityOrderH._credit_rate;
            _entitySalesH._unit_kind_id = _entityOrderH._unit_kind_id;

            _entitySalesH._invoice_state = "";
            _entitySalesH._receipt_receivable_kbn = 1;
            _entitySalesH._receipt_receivable_kbn_nm = "消込未";

            _entitySalesH._memo = _entityOrderH._memo;

            //_entitySalesH._update_person_id = ExCast.zCInt(dt.DefaultView[0]["UPDATE_PERSON_ID"]);
            //_entitySalesH._update_person_nm = ExCast.zCStr(dt.DefaultView[0]["UPDATE_PERSON_NM"]);

            //_entitySalesH._lock_flg = (int)lockFlg;

            #endregion

            #region Set Entity Detail

            if (_entitySalesListD == null) _entitySalesListD = new ObservableCollection<EntitySalesD>();
            _entitySalesListD.Clear();

            for (int i = 0; i <= _entityListOrderD.Count - 1; i++)
            {
                EntitySalesD _entityD = new EntitySalesD();
                _entityD._id = _entitySalesH._id;
                _entityD._rec_no = _entityListOrderD[i]._rec_no;
                _entityD._breakdown_id = _entityListOrderD[i]._breakdown_id;
                _entityD._breakdown_nm = _entityListOrderD[i]._breakdown_nm;
                List<string> lst;
                lst = MeiNameList.GetListMei(MeiNameList.geNameKbn.DELIVER_DIVISION_ID);
                _entityD._deliver_division_nm = lst[2];
                _entityD._deliver_division_id = MeiNameList.GetID(MeiNameList.geNameKbn.DELIVER_DIVISION_ID, lst[2]);
                //_entityD._deliver_division_id = 2;
                //_entityD._deliver_division_nm = _entityListOrderD[i]._deliver_division_nm;
                _entityD._commodity_id = _entityListOrderD[i]._commodity_id;
                _entityD._commodity_name = _entityListOrderD[i]._commodity_name;
                _entityD._unit_id = _entityListOrderD[i]._unit_id;
                _entityD._unit_nm = _entityListOrderD[i]._unit_nm;
                _entityD._enter_number = _entityListOrderD[i]._enter_number;
                _entityD._case_number = _entityListOrderD[i]._case_number;
                _entityD._number = _entityListOrderD[i]._number;
                _entityD._order_id = _entityOrderH._id;
                _entityD._order_number = _entityListOrderD[i]._number;
                _entityD._order_stay_number = 0;
                _entityD._unit_price = _entityListOrderD[i]._unit_price;
                _entityD._sales_cost = _entityListOrderD[i]._sales_cost;
                _entityD._tax = _entityListOrderD[i]._tax;
                _entityD._no_tax_price = _entityListOrderD[i]._no_tax_price;
                _entityD._price = _entityListOrderD[i]._price;
                _entityD._profits = _entityListOrderD[i]._profits;
                _entityD._profits_percent = _entityListOrderD[i]._profits_percent;
                _entityD._memo = _entityListOrderD[i]._memo;
                _entityD._tax_division_id = _entityListOrderD[i]._tax_division_id;
                _entityD._tax_division_nm = _entityListOrderD[i]._tax_division_nm;
                _entityD._tax_percent = _entityListOrderD[i]._tax_percent;
                _entityD._inventory_number = _entityListOrderD[i]._inventory_number;
                _entityD._inventory_management_division_id = _entityListOrderD[i]._inventory_management_division_id;
                _entityD._number_decimal_digit = _entityListOrderD[i]._number_decimal_digit;
                _entityD._unit_decimal_digit = _entityListOrderD[i]._unit_decimal_digit;
                _entitySalesListD.Add(_entityD);
            }

            #endregion
        }

        #endregion

        #region ConvertRedDate

        private void ConvertRedData(EntitySalesH _prm_entityH, 
                                    ObservableCollection<EntitySalesD> _prm_entityListD, 
                                    EntitySalesH _prm_entityRedH, 
                                    ObservableCollection<EntitySalesD> _prm_entityListRedD)
        {
            for (int i = 0; i <= _prm_entityListD.Count - 1; i++)
            {
                _prm_entityListRedD.Clear();

                #region Set Entity Detail

                EntitySalesD _entityD = new EntitySalesD();

                _entityD._id = _prm_entityListD[i]._id;
                _entityD._rec_no = _prm_entityListD[i]._rec_no;
                _entityD._breakdown_id = _prm_entityListD[i]._breakdown_id;
                _entityD._breakdown_nm = _prm_entityListD[i]._breakdown_nm;
                _entityD._deliver_division_id = _prm_entityListD[i]._deliver_division_id;
                _entityD._deliver_division_nm = _prm_entityListD[i]._deliver_division_nm;
                _entityD._commodity_id = _prm_entityListD[i]._commodity_id;
                _entityD._commodity_name = _prm_entityListD[i]._commodity_name;
                _entityD._unit_id = _prm_entityListD[i]._unit_id;
                _entityD._unit_nm = _prm_entityListD[i]._unit_nm;
                _entityD._enter_number = _prm_entityListD[i]._enter_number;
                _entityD._case_number = _prm_entityListD[i]._case_number;
                _entityD._number = _prm_entityListD[i]._number;
                _entityD._unit_price = _prm_entityListD[i]._unit_price;
                _entityD._sales_cost = _prm_entityListD[i]._sales_cost;
                _entityD._tax = _prm_entityListD[i]._tax;
                _entityD._no_tax_price = _prm_entityListD[i]._no_tax_price;
                _entityD._price = _prm_entityListD[i]._price;
                _entityD._profits = _prm_entityListD[i]._profits;
                _entityD._profits_percent = _prm_entityListD[i]._profits_percent;
                _entityD._tax_division_id = _prm_entityListD[i]._tax_division_id;
                _entityD._tax_division_nm = _prm_entityListD[i]._tax_division_nm;
                _entityD._tax_percent = _prm_entityListD[i]._tax_percent;
                _entityD._inventory_management_division_id = _prm_entityListD[i]._inventory_management_division_id;
                _entityD._inventory_number = _prm_entityListD[i]._inventory_number;
                _entityD._retail_price_skip_tax = _prm_entityListD[i]._retail_price_skip_tax;
                _entityD._retail_price_before_tax = _prm_entityListD[i]._retail_price_before_tax;
                _entityD._sales_unit_price_skip_tax = _prm_entityListD[i]._sales_unit_price_skip_tax;
                _entityD._sales_unit_price_before_tax = _prm_entityListD[i]._sales_unit_price_before_tax;
                _entityD._sales_cost_price_skip_tax = _prm_entityListD[i]._sales_cost_price_skip_tax;
                _entityD._sales_cost_price_before_tax = _prm_entityListD[i]._sales_cost_price_before_tax;
                _entityD._number_decimal_digit = _prm_entityListD[i]._number_decimal_digit;
                _entityD._unit_decimal_digit = _prm_entityListD[i]._unit_decimal_digit;
                _entityD._order_id = _prm_entityListD[i]._order_id;
                _entityD._order_number = _prm_entityListD[i]._order_number;
                _entityD._order_stay_number = _prm_entityListD[i]._order_stay_number;
                _entityD._memo = _prm_entityListD[i]._memo;
                _entityD._lock_flg = _prm_entityListD[i]._lock_flg;
                _entityD._message = _prm_entityListD[i]._message;

                #endregion

                _prm_entityListRedD.Add(_entityD);
            }

            #region Set Entity Head

            _prm_entityRedH._id = _prm_entityH._id;
            _prm_entityRedH._no = _prm_entityH._no;
            _prm_entityRedH._red_before_no = _prm_entityH._red_before_no;
            _prm_entityRedH._order_no = _prm_entityH._order_no;
            _prm_entityRedH._estimateno = _prm_entityH._estimateno;
            _prm_entityRedH._sales_ymd = _prm_entityH._sales_ymd;
            _prm_entityRedH._customer_id = _prm_entityH._customer_id;
            _prm_entityRedH._customer_name = _prm_entityH._customer_name;
            _prm_entityRedH._tax_change_id = _prm_entityH._tax_change_id;
            _prm_entityRedH._tax_change_name = _prm_entityH._tax_change_name;
            _prm_entityRedH._business_division_id = _prm_entityH._business_division_id;
            _prm_entityRedH._business_division_name = _prm_entityH._business_division_name;
            _prm_entityRedH._supplier_id = _prm_entityH._supplier_id;
            _prm_entityRedH._supplier_name = _prm_entityH._supplier_name;
            _prm_entityRedH._supply_ymd = _prm_entityH._supply_ymd;
            _prm_entityRedH._sum_enter_number = _prm_entityH._sum_enter_number;
            _prm_entityRedH._sum_case_number = _prm_entityH._sum_case_number;
            _prm_entityRedH._sum_number = _prm_entityH._sum_number;
            _prm_entityRedH._sum_unit_price = _prm_entityH._sum_unit_price;
            _prm_entityRedH._sum_sales_cost = _prm_entityH._sum_sales_cost;
            _prm_entityRedH._sum_tax = _prm_entityH._sum_tax;
            _prm_entityRedH._sum_no_tax_price = _prm_entityH._sum_no_tax_price;
            _prm_entityRedH._sum_price = _prm_entityH._sum_price;
            _prm_entityRedH._sum_profits = _prm_entityH._sum_profits;
            _prm_entityRedH._profits_percent = _prm_entityH._profits_percent;
            _prm_entityRedH._invoice_close_flg = _prm_entityH._invoice_close_flg;
            _prm_entityRedH._memo = _prm_entityH._memo;
            _prm_entityRedH._update_flg = _prm_entityH._update_flg;
            _prm_entityRedH._update_person_id = _prm_entityH._update_person_id;
            _prm_entityRedH._update_person_nm = _prm_entityH._update_person_nm;
            _prm_entityRedH._update_date = _prm_entityH._update_date;
            _prm_entityRedH._update_time = _prm_entityH._update_time;
            _prm_entityRedH._price_fraction_proc_id = _prm_entityH._price_fraction_proc_id;
            _prm_entityRedH._tax_fraction_proc_id = _prm_entityH._tax_fraction_proc_id;
            _prm_entityRedH._unit_kind_id = _prm_entityH._unit_kind_id;
            _prm_entityRedH._credit_limit_price = _prm_entityH._credit_limit_price;
            _prm_entityRedH._sales_credit_price = _prm_entityH._sales_credit_price;
            _prm_entityRedH._before_sales_credit_price = _prm_entityH._before_sales_credit_price;
            _prm_entityRedH._invoice_id = _prm_entityH._invoice_id;
            _prm_entityRedH._invoice_name = _prm_entityH._invoice_name;
            _prm_entityRedH._invoice_yyyymmdd = _prm_entityH._invoice_yyyymmdd;
            _prm_entityRedH._credit_rate = _prm_entityH._credit_rate;
            _prm_entityRedH._collect_day = _prm_entityH._collect_day;
            _prm_entityRedH._collect_cycle_id = _prm_entityH._collect_cycle_id;
            _prm_entityRedH._invoice_no = _prm_entityH._invoice_no;
            _prm_entityRedH._invoice_state = _prm_entityH._invoice_state;
            _prm_entityRedH._receipt_receivable_kbn = _prm_entityH._receipt_receivable_kbn;
            _prm_entityRedH._receipt_receivable_kbn_nm = _prm_entityH._receipt_receivable_kbn_nm;
            _prm_entityRedH._lock_flg = _prm_entityH._lock_flg;
            _prm_entityRedH._message = _prm_entityH._message;

            #endregion
        }

        #endregion

        #region ConvertBeforeDate

        private void ConvertBeforeData(EntitySalesH _prm_entityH,
                                       ObservableCollection<EntitySalesD> _prm_entityListD,
                                       EntitySalesH _prm_before_entityH,
                                       ObservableCollection<EntitySalesD> _prm_before_entityListD)
        {

            #region Set Entity Detail
            
            _prm_before_entityListD.Clear();

            for (int i = 0; i <= _prm_entityListD.Count - 1; i++)
            {

                EntitySalesD _entityD = new EntitySalesD();

                _entityD._id = _prm_entityListD[i]._id;
                _entityD._rec_no = _prm_entityListD[i]._rec_no;
                _entityD._breakdown_id = _prm_entityListD[i]._breakdown_id;
                _entityD._breakdown_nm = _prm_entityListD[i]._breakdown_nm;
                _entityD._deliver_division_id = _prm_entityListD[i]._deliver_division_id;
                _entityD._deliver_division_nm = _prm_entityListD[i]._deliver_division_nm;
                _entityD._commodity_id = _prm_entityListD[i]._commodity_id;
                _entityD._commodity_name = _prm_entityListD[i]._commodity_name;
                _entityD._unit_id = _prm_entityListD[i]._unit_id;
                _entityD._unit_nm = _prm_entityListD[i]._unit_nm;
                _entityD._enter_number = _prm_entityListD[i]._enter_number;
                _entityD._case_number = _prm_entityListD[i]._case_number;
                _entityD._number = _prm_entityListD[i]._number;
                _entityD._unit_price = _prm_entityListD[i]._unit_price;
                _entityD._sales_cost = _prm_entityListD[i]._sales_cost;
                _entityD._tax = _prm_entityListD[i]._tax;
                _entityD._no_tax_price = _prm_entityListD[i]._no_tax_price;
                _entityD._price = _prm_entityListD[i]._price;
                _entityD._profits = _prm_entityListD[i]._profits;
                _entityD._profits_percent = _prm_entityListD[i]._profits_percent;
                _entityD._tax_division_id = _prm_entityListD[i]._tax_division_id;
                _entityD._tax_division_nm = _prm_entityListD[i]._tax_division_nm;
                _entityD._tax_percent = _prm_entityListD[i]._tax_percent;
                _entityD._inventory_management_division_id = _prm_entityListD[i]._inventory_management_division_id;
                _entityD._inventory_number = _prm_entityListD[i]._inventory_number;
                _entityD._retail_price_skip_tax = _prm_entityListD[i]._retail_price_skip_tax;
                _entityD._retail_price_before_tax = _prm_entityListD[i]._retail_price_before_tax;
                _entityD._sales_unit_price_skip_tax = _prm_entityListD[i]._sales_unit_price_skip_tax;
                _entityD._sales_unit_price_before_tax = _prm_entityListD[i]._sales_unit_price_before_tax;
                _entityD._sales_cost_price_skip_tax = _prm_entityListD[i]._sales_cost_price_skip_tax;
                _entityD._sales_cost_price_before_tax = _prm_entityListD[i]._sales_cost_price_before_tax;
                _entityD._number_decimal_digit = _prm_entityListD[i]._number_decimal_digit;
                _entityD._unit_decimal_digit = _prm_entityListD[i]._unit_decimal_digit;
                _entityD._order_id = _prm_entityListD[i]._order_id;
                _entityD._order_number = _prm_entityListD[i]._order_number;
                _entityD._order_stay_number = _prm_entityListD[i]._order_stay_number;
                _entityD._memo = _prm_entityListD[i]._memo;
                _entityD._lock_flg = _prm_entityListD[i]._lock_flg;
                _entityD._message = _prm_entityListD[i]._message;

                _prm_before_entityListD.Add(_entityD);
            }

            #endregion

            #region Set Entity Head

            _prm_before_entityH._id = _prm_entityH._id;
            _prm_before_entityH._no = _prm_entityH._no;
            _prm_before_entityH._red_before_no = _prm_entityH._red_before_no;
            _prm_before_entityH._order_no = _prm_entityH._order_no;
            _prm_before_entityH._estimateno = _prm_entityH._estimateno;
            _prm_before_entityH._sales_ymd = _prm_entityH._sales_ymd;
            _prm_before_entityH._customer_id = _prm_entityH._customer_id;
            _prm_before_entityH._customer_name = _prm_entityH._customer_name;
            _prm_before_entityH._tax_change_id = _prm_entityH._tax_change_id;
            _prm_before_entityH._tax_change_name = _prm_entityH._tax_change_name;
            _prm_before_entityH._business_division_id = _prm_entityH._business_division_id;
            _prm_before_entityH._business_division_name = _prm_entityH._business_division_name;
            _prm_before_entityH._supplier_id = _prm_entityH._supplier_id;
            _prm_before_entityH._supplier_name = _prm_entityH._supplier_name;
            _prm_before_entityH._supply_ymd = _prm_entityH._supply_ymd;
            _prm_before_entityH._sum_enter_number = _prm_entityH._sum_enter_number;
            _prm_before_entityH._sum_case_number = _prm_entityH._sum_case_number;
            _prm_before_entityH._sum_number = _prm_entityH._sum_number;
            _prm_before_entityH._sum_unit_price = _prm_entityH._sum_unit_price;
            _prm_before_entityH._sum_sales_cost = _prm_entityH._sum_sales_cost;
            _prm_before_entityH._sum_tax = _prm_entityH._sum_tax;
            _prm_before_entityH._sum_no_tax_price = _prm_entityH._sum_no_tax_price;
            _prm_before_entityH._sum_price = _prm_entityH._sum_price;
            _prm_before_entityH._sum_profits = _prm_entityH._sum_profits;
            _prm_before_entityH._profits_percent = _prm_entityH._profits_percent;
            _prm_before_entityH._invoice_close_flg = _prm_entityH._invoice_close_flg;
            _prm_before_entityH._memo = _prm_entityH._memo;
            _prm_before_entityH._update_flg = _prm_entityH._update_flg;
            _prm_before_entityH._update_person_id = _prm_entityH._update_person_id;
            _prm_before_entityH._update_person_nm = _prm_entityH._update_person_nm;
            _prm_before_entityH._update_date = _prm_entityH._update_date;
            _prm_before_entityH._update_time = _prm_entityH._update_time;
            _prm_before_entityH._price_fraction_proc_id = _prm_entityH._price_fraction_proc_id;
            _prm_before_entityH._tax_fraction_proc_id = _prm_entityH._tax_fraction_proc_id;
            _prm_before_entityH._unit_kind_id = _prm_entityH._unit_kind_id;
            _prm_before_entityH._credit_limit_price = _prm_entityH._credit_limit_price;
            _prm_before_entityH._sales_credit_price = _prm_entityH._sales_credit_price;
            _prm_before_entityH._before_sales_credit_price = _prm_entityH._before_sales_credit_price;
            _prm_before_entityH._invoice_id = _prm_entityH._invoice_id;
            _prm_before_entityH._invoice_name = _prm_entityH._invoice_name;
            _prm_before_entityH._invoice_yyyymmdd = _prm_entityH._invoice_yyyymmdd;
            _prm_before_entityH._credit_rate = _prm_entityH._credit_rate;
            _prm_before_entityH._collect_day = _prm_entityH._collect_day;
            _prm_before_entityH._collect_cycle_id = _prm_entityH._collect_cycle_id;
            _prm_before_entityH._invoice_no = _prm_entityH._invoice_no;
            _prm_before_entityH._invoice_state = _prm_entityH._invoice_state;
            _prm_before_entityH._receipt_receivable_kbn = _prm_entityH._receipt_receivable_kbn;
            _prm_before_entityH._receipt_receivable_kbn_nm = _prm_entityH._receipt_receivable_kbn_nm;
            _prm_before_entityH._lock_flg = _prm_entityH._lock_flg;
            _prm_before_entityH._message = _prm_entityH._message;

            #endregion
        }

        #endregion

        #region Red Data Set

        private void SetRedData()
        {
            //ConvertRedData(_entityH, _entityListD, _entityRedH, _entityListRedD);
            //_entityRedH._no = 0;
            //_entityRedH._id = 0;
            //_entityRedH._red_before_no = _entityH._no;

            _entityRedH._sum_case_number = _entityRedH._sum_case_number * -1;                                   // ケース数計
            _entityRedH._sum_number = _entityRedH._sum_number * -1;                                             // 数量計
            _entityRedH._sum_tax = _entityRedH._sum_tax * -1;                                                   // 消費税額計
            _entityRedH._sum_no_tax_price = _entityRedH._sum_no_tax_price * -1;                                 // 税抜金額計
            _entityRedH._sum_price = _entityRedH._sum_price * -1;                                               // 金額計
            _entityRedH._sum_profits = _entityRedH._sum_profits * -1;                                           // 粗利計(売上金額計-売上原価計)
            _entityRedH._sales_credit_price = _entityRedH._sales_credit_price - _entityH._sum_price;            // 売掛残高
            _entityRedH._before_sales_credit_price = _entityRedH._sales_credit_price;                           // 売掛残高
            
            for (int i = 0; i <= _entityListRedD.Count - 1; i++)
            {
                DataDetail.CalRedcDetail(_entityListRedD[i]);
            }

            _entityH = _entityRedH;
            _entityListD = _entityListRedD;
        }

        #endregion

    }

}
