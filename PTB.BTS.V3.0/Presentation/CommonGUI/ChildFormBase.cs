using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace Presentation.CommonGUI
{
    public partial class ChildFormBase : Presentation.CommonGUI.FormBase
    {
        #region Contructor
        public ChildFormBase()
            : base()
        {
            InitializeComponent();
        } 
        #endregion

        #region Public Method
        public virtual int MasterCount()
        {
            return 0;
        }

        public virtual string FormID()
        {
            return string.Empty;
        } 
        #endregion

        #region Protected Method
        protected string title
        {
            set { this.Text = value; }
        }

        protected void baseInitMenuMDIParent(frmMain value)
        {
            MainMenuNewStatus = false;
            MainMenuRefreshStatus = false;
            MainMenuDeleteStatus = false;
            MainMenuPrintStatus = false;

            value.EnableNewCommand(false);
            value.EnableDeleteCommand(false);
            value.EnableRefreshCommand(false);
            value.EnablePrintCommand(false);
        }

        protected virtual void From_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// Close report document and destroy object
        /// </summary>
        /// <param name="doc"></param>
        protected void CloseReport(CrystalDecisions.Windows.Forms.CrystalReportViewer report)
        {
            if (report.ReportSource != null && report.ReportSource is ReportDocument)
            {
                ((ReportDocument)report.ReportSource).Close();
                ((ReportDocument)report.ReportSource).Dispose();
            }
        } 
        #endregion
    }
}