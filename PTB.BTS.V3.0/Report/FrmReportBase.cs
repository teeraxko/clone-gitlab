using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PresentationBase.CommonGUIBase;

namespace Report
{
    public partial class FrmReportBase : Form, IMDIChildFormGUI
    {
        public FrmReportBase()
        {
            InitializeComponent();
        }

        private void FrmReportBase_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        #region IMDIChildFormGUI Members

        public void ExitForm()
        {
            this.Close();
        }

        public void InitForm()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        public void PrintForm()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        public void RefreshForm()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}