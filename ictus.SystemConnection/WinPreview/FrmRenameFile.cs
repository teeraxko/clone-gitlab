using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ictus.SystemConnection.BizPac.Core;
using YST_DLV;

namespace WinPreview
{
    public partial class FrmRenameFile : Form
    {
        public FrmRenameFile()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BizPacRenameFile a = new BizPacRenameFile();
            a.RenameFile();
        }
    }
}