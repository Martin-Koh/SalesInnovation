﻿#pragma checksum "C:\Users\Owner\SkyDrive\SlvHanbai\SlvHanbaiClient\View\UserControl\Input\Purchase\Utl_InpSearchPurchase.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DA465FE20F8C3B441B64C18E4989F26B"
//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.18033
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

using SlvHanbaiClient.Class.UI;
using SlvHanbaiClient.View.UserControl.Custom;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace SlvHanbaiClient.View.UserControl.Input.Purchase {
    
    
    public partial class Utl_InpSearchPurchase : SlvHanbaiClient.Class.UI.ExUserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBox txtDummy;
        
        internal SlvHanbaiClient.Class.UI.ExLabel lblPruchaseYmd;
        
        internal SlvHanbaiClient.Class.UI.ExDatePicker datPurchaseYmd_F;
        
        internal SlvHanbaiClient.Class.UI.ExDatePicker datPurchaseYmd_T;
        
        internal SlvHanbaiClient.Class.UI.ExLabel lblSalesNo;
        
        internal SlvHanbaiClient.View.UserControl.Custom.Utl_InpNoText utlPurchaseNo_F;
        
        internal SlvHanbaiClient.View.UserControl.Custom.Utl_InpNoText utlPurchaseNo_T;
        
        internal SlvHanbaiClient.Class.UI.ExLabel lblNokiYmd;
        
        internal SlvHanbaiClient.Class.UI.ExDatePicker datNokiYmd_F;
        
        internal SlvHanbaiClient.Class.UI.ExDatePicker datNokiYmd_T;
        
        internal SlvHanbaiClient.Class.UI.ExLabel lblOrderNo;
        
        internal SlvHanbaiClient.View.UserControl.Custom.Utl_InpNoText utlPurchaseOrderNo_F;
        
        internal SlvHanbaiClient.View.UserControl.Custom.Utl_InpNoText utlPurchaseOrderNo_T;
        
        internal SlvHanbaiClient.Class.UI.ExLabel lblInpPerson;
        
        internal SlvHanbaiClient.View.UserControl.Custom.Utl_MstText utlPerson_F;
        
        internal SlvHanbaiClient.View.UserControl.Custom.Utl_MstText utlPerson_T;
        
        internal SlvHanbaiClient.View.UserControl.Custom.Utl_MstText utlPurchase;
        
        internal SlvHanbaiClient.Class.UI.ExLabel lblCommodity;
        
        internal SlvHanbaiClient.View.UserControl.Custom.Utl_MstText utlCommodity;
        
        internal SlvHanbaiClient.View.UserControl.Custom.Utl_MeiText utlSendKbn;
        
        internal SlvHanbaiClient.Class.UI.ExLabel lblSendKbn;
        
        internal SlvHanbaiClient.View.UserControl.Custom.Utl_MstText utlCustomer;
        
        internal SlvHanbaiClient.View.UserControl.Custom.Utl_MstText utlSupplier;
        
        internal SlvHanbaiClient.Class.UI.ExCheckBox chkKake;
        
        internal SlvHanbaiClient.Class.UI.ExCheckBox chkCash;
        
        internal SlvHanbaiClient.Class.UI.ExCheckBox chkUnDelivary;
        
        internal SlvHanbaiClient.Class.UI.ExCheckBox chkPartDelivary;
        
        internal SlvHanbaiClient.Class.UI.ExCheckBox chkFullDelivary;
        
        internal SlvHanbaiClient.Class.UI.ExCheckBox chkTorikeshi;
        
        internal System.Windows.Controls.RadioButton rdoPaymentNo;
        
        internal System.Windows.Controls.RadioButton rdoPaymentYes;
        
        internal System.Windows.Controls.RadioButton rdoPaymentNothing;
        
        internal System.Windows.Controls.Grid GridDetail;
        
        internal SlvHanbaiClient.Class.UI.ExDataGrid dg;
        
        internal System.Windows.Controls.Grid GridDetailSelect;
        
        internal System.Windows.Controls.Button btnSelectAll;
        
        internal System.Windows.Controls.Button btnNoSelectAll;
        
        internal SlvHanbaiClient.Class.UI.ExDataGrid dgSelect;
        
        internal System.Windows.Controls.DataGridCheckBoxColumn dataG_HeaderSelect;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/SlvHanbaiClient;component/View/UserControl/Input/Purchase/Utl_InpSearchPurchase." +
                        "xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.txtDummy = ((System.Windows.Controls.TextBox)(this.FindName("txtDummy")));
            this.lblPruchaseYmd = ((SlvHanbaiClient.Class.UI.ExLabel)(this.FindName("lblPruchaseYmd")));
            this.datPurchaseYmd_F = ((SlvHanbaiClient.Class.UI.ExDatePicker)(this.FindName("datPurchaseYmd_F")));
            this.datPurchaseYmd_T = ((SlvHanbaiClient.Class.UI.ExDatePicker)(this.FindName("datPurchaseYmd_T")));
            this.lblSalesNo = ((SlvHanbaiClient.Class.UI.ExLabel)(this.FindName("lblSalesNo")));
            this.utlPurchaseNo_F = ((SlvHanbaiClient.View.UserControl.Custom.Utl_InpNoText)(this.FindName("utlPurchaseNo_F")));
            this.utlPurchaseNo_T = ((SlvHanbaiClient.View.UserControl.Custom.Utl_InpNoText)(this.FindName("utlPurchaseNo_T")));
            this.lblNokiYmd = ((SlvHanbaiClient.Class.UI.ExLabel)(this.FindName("lblNokiYmd")));
            this.datNokiYmd_F = ((SlvHanbaiClient.Class.UI.ExDatePicker)(this.FindName("datNokiYmd_F")));
            this.datNokiYmd_T = ((SlvHanbaiClient.Class.UI.ExDatePicker)(this.FindName("datNokiYmd_T")));
            this.lblOrderNo = ((SlvHanbaiClient.Class.UI.ExLabel)(this.FindName("lblOrderNo")));
            this.utlPurchaseOrderNo_F = ((SlvHanbaiClient.View.UserControl.Custom.Utl_InpNoText)(this.FindName("utlPurchaseOrderNo_F")));
            this.utlPurchaseOrderNo_T = ((SlvHanbaiClient.View.UserControl.Custom.Utl_InpNoText)(this.FindName("utlPurchaseOrderNo_T")));
            this.lblInpPerson = ((SlvHanbaiClient.Class.UI.ExLabel)(this.FindName("lblInpPerson")));
            this.utlPerson_F = ((SlvHanbaiClient.View.UserControl.Custom.Utl_MstText)(this.FindName("utlPerson_F")));
            this.utlPerson_T = ((SlvHanbaiClient.View.UserControl.Custom.Utl_MstText)(this.FindName("utlPerson_T")));
            this.utlPurchase = ((SlvHanbaiClient.View.UserControl.Custom.Utl_MstText)(this.FindName("utlPurchase")));
            this.lblCommodity = ((SlvHanbaiClient.Class.UI.ExLabel)(this.FindName("lblCommodity")));
            this.utlCommodity = ((SlvHanbaiClient.View.UserControl.Custom.Utl_MstText)(this.FindName("utlCommodity")));
            this.utlSendKbn = ((SlvHanbaiClient.View.UserControl.Custom.Utl_MeiText)(this.FindName("utlSendKbn")));
            this.lblSendKbn = ((SlvHanbaiClient.Class.UI.ExLabel)(this.FindName("lblSendKbn")));
            this.utlCustomer = ((SlvHanbaiClient.View.UserControl.Custom.Utl_MstText)(this.FindName("utlCustomer")));
            this.utlSupplier = ((SlvHanbaiClient.View.UserControl.Custom.Utl_MstText)(this.FindName("utlSupplier")));
            this.chkKake = ((SlvHanbaiClient.Class.UI.ExCheckBox)(this.FindName("chkKake")));
            this.chkCash = ((SlvHanbaiClient.Class.UI.ExCheckBox)(this.FindName("chkCash")));
            this.chkUnDelivary = ((SlvHanbaiClient.Class.UI.ExCheckBox)(this.FindName("chkUnDelivary")));
            this.chkPartDelivary = ((SlvHanbaiClient.Class.UI.ExCheckBox)(this.FindName("chkPartDelivary")));
            this.chkFullDelivary = ((SlvHanbaiClient.Class.UI.ExCheckBox)(this.FindName("chkFullDelivary")));
            this.chkTorikeshi = ((SlvHanbaiClient.Class.UI.ExCheckBox)(this.FindName("chkTorikeshi")));
            this.rdoPaymentNo = ((System.Windows.Controls.RadioButton)(this.FindName("rdoPaymentNo")));
            this.rdoPaymentYes = ((System.Windows.Controls.RadioButton)(this.FindName("rdoPaymentYes")));
            this.rdoPaymentNothing = ((System.Windows.Controls.RadioButton)(this.FindName("rdoPaymentNothing")));
            this.GridDetail = ((System.Windows.Controls.Grid)(this.FindName("GridDetail")));
            this.dg = ((SlvHanbaiClient.Class.UI.ExDataGrid)(this.FindName("dg")));
            this.GridDetailSelect = ((System.Windows.Controls.Grid)(this.FindName("GridDetailSelect")));
            this.btnSelectAll = ((System.Windows.Controls.Button)(this.FindName("btnSelectAll")));
            this.btnNoSelectAll = ((System.Windows.Controls.Button)(this.FindName("btnNoSelectAll")));
            this.dgSelect = ((SlvHanbaiClient.Class.UI.ExDataGrid)(this.FindName("dgSelect")));
            this.dataG_HeaderSelect = ((System.Windows.Controls.DataGridCheckBoxColumn)(this.FindName("dataG_HeaderSelect")));
        }
    }
}
