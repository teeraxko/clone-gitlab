using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Presentation.CommonGUI;
using Facade.ContractFacade;
using SystemFramework.AppConfig;
using System.Data.SqlClient;
using SystemFramework.AppException;
using Entity.ContractEntities;
using SystemFramework.AppMessage;

namespace Presentation.ContractGUI
{
    public partial class FrmCompensateRate : ChildFormBase, IMDIChildForm
    {
        private CompensateRateFacade facadeCompensateRate;

        //================================= Constructor ================================
        public FrmCompensateRate() : base()
        {
            InitializeComponent();
            facadeCompensateRate = new CompensateRateFacade();
            this.title = UserProfile.GetFormName("miContract", "miContractSettingCompensate");
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miContract", "miContractSettingCompensate");
        }
        //================================= Private method ================================
        private void updateRate()
        { 
            Compensate compensate = new Compensate();
            compensate.CompensateRate = Convert.ToDecimal(fpdCompensateRate.Value);

            if (facadeCompensateRate.MaintainCompensate(compensate))
            {
                Message(MessageList.Information.I0001);
            }
            else
            {
                Message(MessageList.Error.E0014, " Update ข้อมูลได้");                
            }
        }

        //============================== Base Event ==============================
        public void InitForm()
        {
            fpdCompensateRate.MaxValue = 99.99;
            fpdCompensateRate.MinValue = 0.00;

            try
            {
                Compensate compensate = facadeCompensateRate.GetCompensate();
                if (compensate != null)
                {
                    fpdCompensateRate.Value = compensate.CompensateRate;
                }
                else
                {
                    fpdCompensateRate.Value = decimal.Zero;
                }
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

            if (UserProfile.IsReadOnly("miContract", "miContractSettingCompensate"))
            {
                btnOK.Enabled = false;
            }
        }

        public void RefreshForm()
        {
            InitForm();
        }

        public void PrintForm()
        {}

        public void ExitForm()
        {
            this.Close();
        }

        //================================= Event ================================
        private void btnOK_Click(object sender, EventArgs e)
        {
            updateRate();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCompensateRate_Load(object sender, EventArgs e)
        {
            MdiParent = (frmMain)this.MdiParent;
            InitForm();
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
        }      
    }
}