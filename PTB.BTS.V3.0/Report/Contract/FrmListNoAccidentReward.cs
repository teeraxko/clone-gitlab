using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PresentationBase.CommonGUIBase;
using CrystalDecisions.CrystalReports.Engine;
using System.Globalization;
using PTB.BTS.Report.Flow;
using ictus.Common.Entity;
using PTB.BTS.PI.Flow;

namespace Report.Contract 
{
    public partial class FrmListNoAccidentReward : FrmReportBase
    {        
        private CompanyInfo _comp;
        private CompanyInfo comp
        {
            get {
                    if (_comp == null) {
                        CompanyFlow companyFlow = new CompanyFlow();
                        _comp = new CompanyInfo("12");
                        companyFlow.FillCompany(ref _comp);
                    }
                    return _comp;
            }
        }

        private NoAccidentRewardFlow flow = new NoAccidentRewardFlow();

        
        public FrmListNoAccidentReward() 
        {
            InitializeComponent();
            this.Text = "Name List For No Accident Reward Report";
            if (DateTime.Now.Month > 5) {
                mtxtForYear.Text = DateTime.Now.Year.ToString("0000");
            } else {
                mtxtForYear.Text = (DateTime.Now.Year - 1).ToString("0000");
            }
            RetiveDataInfo();
        }

        private void mtxtForYear_Validated(object sender, EventArgs e) {
            RetiveDataInfo();
        }

        private void RetiveDataInfo() {
            if (ValidYear()) {
                CultureInfo cul = new CultureInfo("en-US");
                lblFromDate.Text = (new DateTime(int.Parse(mtxtForYear.Text), 6, 1)).ToString("dd/MM/yyyy", cul);
                lblToDate.Text = (new DateTime(int.Parse(mtxtForYear.Text) + 1, 5, 31)).ToString("dd/MM/yyyy", cul);
                lblPaymentDate.Text = flow.GetPaymentDate(int.Parse(mtxtForYear.Text), this.comp).ToString("dd/MM/yyyy", cul);
                lblReward.Text = flow.GetReward().ToString("0");
            } else {
                lblFromDate.Text = string.Empty;
                lblToDate.Text = string.Empty;
                lblPaymentDate.Text = string.Empty;
            }
        }


        private void btnShowReport_Click(object sender, EventArgs e) {
            if (ValidYear()) {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                Application.DoEvents();
                GenerateData();
                ShowReport();
                this.Cursor = System.Windows.Forms.Cursors.Default;
            } else {
                MessageBox.Show("Invalid Year", "Report could not be created", MessageBoxButtons.OK);
            }
        }

        private void ShowReport() {
            try {
               
                Application.DoEvents();
                string reportName = "rptNoAccidentRewardN.rpt";
                ReportDocument rpt = Common.GetReportDocument(reportName);
                Common.SetFormularField(rpt,"Comp_Name","'" + this.comp.AFullName.Thai + "'");
                Common.SetFormularField(rpt, "forYear", mtxtForYear.Text);
                Common.SetParameterField(rpt, "@fromDate", new DateTime(int.Parse(mtxtForYear.Text), 6, 1));
                Common.SetParameterField(rpt, "@toDate", new DateTime(int.Parse(mtxtForYear.Text) + 1, 5, 31));
                crv.ReportSource = rpt;
               

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK);
            }
        }

        private void GenerateData() {
            int forYear = Convert.ToInt32(mtxtForYear.Text);
            DateTime fromDate = new DateTime(int.Parse(mtxtForYear.Text), 6, 1);
            DateTime toDate = new DateTime(int.Parse(mtxtForYear.Text) + 1, 5, 31);
            DateTime paymentDate = flow.GetPaymentDate(forYear,this.comp);
            int reward = flow.GetReward();
            flow.GenerateTimeCardCharge(forYear, fromDate, toDate, paymentDate, reward);
        }


        private bool ValidYear() {
            int iYear = Convert.ToInt32(mtxtForYear.Text);
            return !(iYear > DateTime.Now.Year && iYear >= 1753);
        }

    }
}