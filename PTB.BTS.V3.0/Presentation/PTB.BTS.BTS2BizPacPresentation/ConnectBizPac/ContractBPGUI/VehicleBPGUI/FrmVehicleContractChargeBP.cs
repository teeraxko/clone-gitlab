using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SystemFramework.AppConfig;
using PTB.BTS.BTS2BizPacFacade.ContractBPFacade;

namespace PTB.BTS.BTS2BizPacPresentation.ConnectBizPac
{
    public partial class FrmVehicleContractChargeBP : FrmBizPacChargeConnectBase
    {
        //============================== Constructor ==============================
        public FrmVehicleContractChargeBP(): base()
        {
            InitializeComponent();
            facadeBTS2BizPacConnect = new VehicleContractChargeBPFacade();
            isReadonly = UserProfile.IsReadOnly("miBizPacConnect", "miBizPacConnectVehicleContractCharge");
        }

        //============================== Public method ==============================
        #region - Override base -
        protected override void PrintReport()
        {
            FrmrptVehicleCharge objfrm = new FrmrptVehicleCharge();
            objfrm.MdiParent = (Presentation.frmMain)this.MdiParent;
            objfrm.fileName = base.fileName;
            objfrm.isSaveFile = true;
            objfrm.Show();
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miBizPacConnect", "miBizPacConnectVehicleContractCharge");
        }

        public override string Title
        {
            get
            {
                lblFormName.Text = UserProfile.GetFormName("miBizPacConnect", "miBizPacConnectVehicleContractCharge");
                return lblFormName.Text;
            }
        }

        public override string DocNoColumnName
        {
            get { return "�����Ţ�ѭ��"; }
        }

        public override string PaidToColumnName
        {
            get { return "���ͺ���ѷ�١���"; }
        }

        public override string RemarkColumnName
        {
            get { return "�����˵�"; }
        }

        public override string AmountColumnName
        {
            get { return "������"; }
        }

        public override string TaxInvoiceNoColumnName
        {
            get { return "�ѹ�����������ѭ��"; }
        }

        public override string TaxInvoiceDateColumnName
        {
            get { return "�ѹ�������ش�ѭ��"; }
        }
        #endregion
    }
}