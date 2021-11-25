using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SystemFramework.AppConfig;
using PTB.BTS.BTS2BizPacFacade.RepairingBPFacade;

namespace PTB.BTS.BTS2BizPacPresentation.ConnectBizPac
{
    public partial class FrmVehicleRepairingHistoryBP : FrmBizPacRepairingConnectBase
    {
        //============================== Constructor ==============================
        public FrmVehicleRepairingHistoryBP() : base()
        {
            InitializeComponent();
            facadeBTS2BizPacConnect = new VehicleRepairingBPFacade();
            isReadonly = UserProfile.IsReadOnly("miBizPacConnect", "miBizPacConnectVehicleRepairing");
        }

        //============================== Public method ==============================
        #region - Override base -
        protected override void PrintReport()
        {
            FrmrptVehicleRepairingExpense objfrm = new FrmrptVehicleRepairingExpense();
            objfrm.MdiParent = (Presentation.frmMain)this.MdiParent;
            objfrm.fileName = base.fileName;
            objfrm.Show();
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miBizPacConnect", "miBizPacConnectVehicleRepairing");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }

        public override string Title
        {
            get 
            {
                lblFormName.Text = UserProfile.GetFormName("miBizPacConnect", "miBizPacConnectVehicleRepairing");
                return lblFormName.Text;
            }
        }

        public override string DocNoColumnName
        {
            get { return "�Ţ����ë���"; }
        }

        public override string PaidToColumnName
        {
            get { return "�����ٹ���ԡ��"; }
        }

        public override string RemarkColumnName
        {
            get { return "�����˵�"; }
        }

        public override string AmountColumnName
        {
            get { return "��ҫ���"; }
        }

        public override string TaxInvoiceNoColumnName
        {
            get { return "�Ţ���㺡ӡѺ����"; }
        }

        public override string TaxInvoiceDateColumnName
        {
            get { return "�ѹ����͡㺡ӡѺ����"; }
        }
        #endregion

    }
}

