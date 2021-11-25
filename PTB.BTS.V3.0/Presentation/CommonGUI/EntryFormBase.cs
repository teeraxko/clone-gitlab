using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Entity.CommonEntity;

namespace Presentation.CommonGUI
{
    public partial class EntryFormBase : Presentation.CommonGUI.FormBase
    {
        public EntryFormBase(): base()
        {
            InitializeComponent();
        }

        protected const string ADDTITLE = "เพิ่มข้อมูล";
        protected const string EDITTITLE = "แก้ไขข้อมูล";

        protected string title;

        protected void baseADD()
        {
            action = ActionType.ADD;
            if (title == null || title == "")
            {
                this.Text = ADDTITLE + this.Text;
            }
            else
            {
                this.Text = ADDTITLE + this.title;
            }
        }

        protected void baseEDIT()
        {
            action = ActionType.EDIT;
            if (title == null || title == "")
            {
                this.Text = EDITTITLE + this.Text;
            }
            else
            {
                this.Text = EDITTITLE + this.title;
            }
        }
    }
}