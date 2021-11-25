using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SystemFramework.AppConfig;
using PTB.BTS.BTS2BizPacFacade.ContractBPFacade;
using System.Data.SqlClient;
using SystemFramework.AppException;
using Entity.ContractEntities;

namespace PTB.BTS.BTS2BizPacPresentation.CancelBizPac
{
    public partial class FrmServiceStaffContractChargeCancelBP : FrmBizPacCancelBase
    {
        //============================== Constructor ==============================
        public FrmServiceStaffContractChargeCancelBP()
            : base()
        {
            InitializeComponent();
            facadeBTS2BizPacConnect = new OtherSSContractChargeBPFacade();

            try
            {

                isReadonly = UserProfile.IsReadOnly("miBizPacConnect", "miBizPacCancelServiceStaffContractCharge");
                cboSelectCheck.DataSource = facadeBTS2BizPacConnect.DataSourceCustomer;
                lblSelectName.Text = "ชื่อลูกค้า";
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
        }

        //============================== Public method ==============================
        #region - Override base -
        public override string FormID()
        {
            return UserProfile.GetFormID("miBizPacConnect", "miBizPacCancelServiceStaffContractCharge");
        }

        public override int MasterCount()
        {
            return base.MasterCount();
        }

        public override string Title
        {
            get
            {
                lblFormName.Text = UserProfile.GetFormName("miBizPacConnect", "miBizPacCancelServiceStaffContractCharge");
                return lblFormName.Text;
            }
        }

        protected override void visibleForm(bool visible)
        {
            base.visibleForm(visible);
            gpbSelectCheck.Visible = visible;
        }

        protected override void SelectAll(int select)
        {
            Customer customer = new Customer();
            if (cboSelectCheck.Text.Trim() != "")
            {
                customer = (Customer)cboSelectCheck.SelectedItem;
            }
            else
            {
                customer = null;
            }

            for (int i = 0; i < dtgBizPacConnect.RowCount; i++)
            {
                if (customer == null)
                {
                    dtgBizPacConnect[1, i].Value = select.ToString();
                }
                else
                {
                    if (dtgBizPacConnect[8, i].Value.ToString() == customer.Code)
                    {
                        dtgBizPacConnect[1, i].Value = select.ToString();
                    }
                }
            }

            customer = null;
        }

        protected override string GetSelectCheck(PTB.BTS.BTS2BizPacEntity.IBTS2BizPacHeader value)
        {
            Customer customer = ((ContractBase)value).ACustomer;
            return (customer != null) ? customer.Code : string.Empty;
        }

        public override string DocNoColumnName
        {
            get { return "หมายเลขสัญญา"; }
        }

        public override string PaidToColumnName
        {
            get { return "ชื่อศูนย์บริการ"; }
        }

        public override string RemarkColumnName
        {
            get { return "หมายเหตุ"; }
        }

        public override string AmountColumnName
        {
            get { return "ค่าซ่อม"; }
        }

        public override string TaxInvoiceNoColumnName
        {
            get { return "เลขที่ใบกำกับภาษี"; }
        }

        public override string TaxInvoiceDateColumnName
        {
            get { return "วันที่ออกใบกำกับภาษี"; }
        }
        #endregion
    }
}