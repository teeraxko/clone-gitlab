using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Presentation.CommonGUI;
using SystemFramework.AppConfig;
using Entity.VehicleEntities;
using SystemFramework.AppMessage;
using Facade.VehicleFacade.LeasingFacade;
using SystemFramework.AppException;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Entity.VehicleEntities.Leasing;

namespace Presentation.VehicleGUI.Leasing
{
    public partial class FrmInterestCost : ChildFormBase, IMDIChildForm
    {
        private frmMain mdiParent;
        private bool isReadOnly = true;
        private InterestCostFacade facadeInterestCost;

        //================================= Constructor ================================
        public FrmInterestCost()
            : base()
        {
            InitializeComponent();
            facadeInterestCost = new InterestCostFacade();
            isReadOnly = UserProfile.IsReadOnly("miVehicle", "miVehicleInterestCost");
            this.title = UserProfile.GetFormName("miVehicle", "miVehicleInterestCost");
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miVehicle", "miVehicleInterestCost");
        }

        //=============================== Private Method ================================	
        private void setVehicle(VehicleInfo value)
        {
            txtPlatePrefix.Tag = value;
            txtPlatePrefix.Text = value.PlatePrefix;
            fpiPlateRunningNo.Text = value.PlateRunningNo;
            fpdBodyPrice.Value = value.VehicleAmount;
        }

        private void formVehicleList()
        {
            FrmVehicleList dialogVehicleList = new FrmVehicleList();

            dialogVehicleList.ConditionPlatePrefix = txtPlatePrefix.Text;
            dialogVehicleList.ConditionPlateRunningNo = fpiPlateRunningNo.Text;
            dialogVehicleList.ShowDialog();

            if (dialogVehicleList.Selected)
            {
                setVehicle(facadeInterestCost.GetVehicleInfo(dialogVehicleList.SelectedVehicle.PlatePrefix, dialogVehicleList.SelectedVehicle.PlateRunningNo));
            }
        }

        private bool validatePlateVehicle()
        {
            if (txtPlatePrefix.Text == "")
            {
                Message(MessageList.Error.E0002, "ทะเบียนรถ");
                txtPlatePrefix.Focus();
                return false;
            }
            else if (fpiPlateRunningNo.Text == "")
            {
                Message(MessageList.Error.E0002, "ทะเบียนรถ");
                fpiPlateRunningNo.Focus();
                return false;
            }
            else
            {
                VehicleInfo vehicleInfo = facadeInterestCost.GetVehicleInfo(txtPlatePrefix.Text.Trim(), fpiPlateRunningNo.Text.Trim());
                if (vehicleInfo == null)
                {
                    Message(MessageList.Error.E0004, "ทะเบียนรถ");
                    txtPlatePrefix.Focus();
                    return false;
                }
                else
                {
                    setVehicle(vehicleInfo);
                    return true;
                }
            }
        }

        private void calCost()
        {
            try
            {
                InterestCostList listCost = new InterestCostList();
                listCost.LeaseTerm = Convert.ToInt16(fpiLeaseTerm.Value);
                listCost.TotalCost = Convert.ToDecimal(fpdBodyPrice.Value);
                listCost.PercentResidualValue = Convert.ToDecimal(fpdPercentResidual.Value);
                listCost.Rate = Convert.ToDecimal(fpdPercentRateOfReturn.Value);

                if (facadeInterestCost.PrintInterestCost(listCost))
                {
                    reportDatabaseLogon();
                }
                else
                {
                    Message(MessageList.Error.E0014, "คำนวณ Interest Cost ได้");
                }
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
        }

        private void reportDatabaseLogon()
        {
            try
            {
                crvPrint.Show();
                ReportDocument rdprint1 = new ReportDocument();

                rdprint1.Load(@ApplicationProfile.REPORT_PATH + "rptInterestCost.rpt");
                DataSourceConnections dataSourceConnections1 = rdprint1.DataSourceConnections;
                IConnectionInfo iConnectionInfo1 = dataSourceConnections1[0];
                iConnectionInfo1.SetConnection(ApplicationProfile.SERVER_NAME, ApplicationProfile.DB_NAME, ApplicationProfile.DB_USER_NAME, ApplicationProfile.DB_USER_PASSWORD);

                rdprint1.DataDefinition.FormulaFields["Comp_Name"].Text = "'" + facadeInterestCost.GetCompanyInfo().AFullName.Thai + "'";
                crvPrint.ReportSource = rdprint1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
            }
        }

        private void clearForm()
        {
            gpbInterestCost.Enabled = true;
            txtPlatePrefix.Tag = null;
            txtPlatePrefix.Text = "";
            fpiPlateRunningNo.Text = "";
            lblPlateNo.Text = "";
            lblPlatePrefix.Text = "";
            fpiLeaseTerm.Value = 0;
            fpdBodyPrice.Value = decimal.Zero;
            fpdPercentResidual.Value = decimal.Zero;
            fpdPercentRateOfReturn.Value = decimal.Zero;
            crvPrint.Hide();

            fpdBodyPrice.MaxValue = 9999999.99;
            fpdBodyPrice.MinValue = 0.00;
            fpdPercentRateOfReturn.MaxValue = 99.99;
            fpdPercentRateOfReturn.MinValue = 0.00;
            fpdPercentResidual.MaxValue = 99.99;
            fpdPercentResidual.MinValue = 0.00;
        }
        
        //============================== Base Event ==============================
        public void InitForm()
        {
            clearForm();
            mdiParent.EnableNewCommand(true);
            MainMenuNewStatus = true; 
        }

        public void RefreshForm()
        {
        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            this.Close();
        }

        //============================== Event ==============================
        private void FrmInterestCost_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            calCost();
        }

        private void txtPlatePrefix_TextChanged(object sender, EventArgs e)
        {
            lblPlatePrefix.Text = txtPlatePrefix.Text;
            if (txtPlatePrefix.Text.Length == txtPlatePrefix.MaxLength)
            {
                fpiPlateRunningNo.Focus();
            }
        }

        private void fpiPlateRunningNo_TextChanged(object sender, EventArgs e)
        {
            lblPlateNo.Text = fpiPlateRunningNo.Text;
            if (fpiPlateRunningNo.Text.Length == 4)
            {
                validatePlateVehicle();
            }
        }

        private void fpiPlateRunningNo_DoubleClick(object sender, EventArgs e)
        {
            formVehicleList();
        }

        private void fpiPlateRunningNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                validatePlateVehicle();
            }
        }
    }
}