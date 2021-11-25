using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PresentationBase.CommonGUIBase
{
    public partial class ChildFormGUIBase : PresentationBase.CommonGUIBase.FormGUIBase
    {
        public ChildFormGUIBase() : base()
        {
            InitializeComponent();
        }

        protected void From_Load(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}