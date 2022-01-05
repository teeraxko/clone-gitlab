using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Configuration;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;
using Entity.ContractEntities;

using Facade.PiFacade;
using Facade.VehicleFacade;

using Presentation.CommonGUI;
using Report.Reports;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using Report.Reports.Contract;
using Facade.ContractFacade;
using System.Data.SqlClient;
using SystemFramework.AppException;


namespace Presentation.ContractGUI
{
    public partial class FrmrptContractAttachmentReport : ChildFormBase, IMDIChildForm
    {

        /// <summary>
        /// Attachment No pass as parameter to the report
        /// </summary>
        private DocumentNo attachmentNo;
        public DocumentNo ConditionAttachmentNo
        {
            set
            {
                attachmentNo = value;
            }
        }
        //============================== Constructor ==============================
        public FrmrptContractAttachmentReport()
            : base()
        {
            InitializeComponent();
            this.Text = "Contract Attachment Report";
        }
             //============================== Private Method ==============================
        /// <summary>
        /// Show report
        /// </summary>
        private void CreateReport()
        {
            try
            {
                Company company = (new ContractFacadeBase()).GetCompany();
                ReportContractAttachment report = new ReportContractAttachment();
                report.SetCriteria(company.CompanyCode, attachmentNo.ToString());
                this.crvReport.ReportSource = report.Report;

                this.crvReport.Visible = true;
                this.crvReport.DisplayToolbar = true;
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
                MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
            }

        }
        /// <summary>
        /// Set  crystal report parameter
        /// </summary>
        /// <param name="paraValue"></param>
        /// <returns></returns>
        private ParameterValues CrytalParameterValue(object paraValue)
        {
            ParameterValues paramValues = new ParameterValues();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = paraValue;
            paramValues.Add(paramDiscreteValue);
            return paramValues;
        }

        //==============================Base Event ==============================
        public void InitForm()
        {
            this.Cursor = Cursors.WaitCursor;
            if (attachmentNo == null)
            {
                throw new NullReferenceException("Attachment No could not be null.");
                this.ExitForm();
            }
            CreateReport();
            RefreshForm();
            this.crvReport.DisplayToolbar = true;
            this.Cursor = Cursors.Default;
        }

        public void RefreshForm()
        {
            this.crvReport.DisplayToolbar = true;
        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            this.Hide();
        }

        //============================== Event ==============================
        private void FrmrptLeasingPurchasing_Load(object sender, EventArgs e)
        {
            InitForm();
        }

    }
}