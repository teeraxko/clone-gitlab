using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SystemFramework.AppConfig;
using PTB.BTS.BTS2BizPacFacade.ExcessBPFacade;
using PTB.BTS.BTS2BizPacPresentation.ConnectBizPac;

namespace PTB.BTS.BTS2BizPacPresentation.CancelBizPac
{
    public partial class FrmVehicleExcessCancelBP : FrmBizPacCancelBase
    {
        //============================== Constructor ==============================
        public FrmVehicleExcessCancelBP()
            : base()
        {
            InitializeComponent();
            facadeBTS2BizPacConnect = new VehicleExcessBPFacade();
            isReadonly = UserProfile.IsReadOnly("miBizPacConnect", "miBizPacCancelVehicleExcess"); 
        }

        //============================== Public method ==============================
        #region - Override base -
        protected override void PrintReport()
        {
            FrmrptExcessExpense objfrm = new FrmrptExcessExpense();
            objfrm.MdiParent = (Presentation.frmMain)this.MdiParent;
            objfrm.fileName = BP_CANCEL_FILE_NAME;
            objfrm.Show();
        }


        public override string FormID()
        {
            return UserProfile.GetFormID("miBizPacConnect", "miBizPacCancelVehicleExcess");
        }

        public override string Title
        {
            get
            {
                lblFormName.Text = UserProfile.GetFormName("miBizPacConnect", "miBizPacCancelVehicleExcess");
                return lblFormName.Text;
            }
        }

        public override string DocNoColumnName
        {
            get { return "�Ţ����غѵ��˵�"; }
        }

        public override string PaidToColumnName
        {
            get { return "���ͺ���ѷ��Сѹ/�ٹ���ԡ��"; }
        }

        public override string RemarkColumnName
        {
            get { return "�����˵�"; }
        }

        public override string AmountColumnName
        {
            get { return "��� Excess"; }
        }

        public override string TaxInvoiceNoColumnName
        {
            get { return "�Ţ���������Ѻ�Թ"; }
        }

        public override string TaxInvoiceDateColumnName
        {
            get { return "�ѹ���������Ѻ�Թ"; }
        }
        #endregion
    }
}

