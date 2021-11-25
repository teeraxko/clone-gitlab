namespace Presentation.ContractGUI.ContractChargeRateGUI
{
    partial class FrmMinimumOTCharge
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.ctmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mniUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.mniDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.dtgDriverStatus = new System.Windows.Forms.DataGridView();
            this.EntityKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Hour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctmMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDriverStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDelete.Location = new System.Drawing.Point(250, 198);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(74, 23);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "ลบ";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUpdate.Location = new System.Drawing.Point(169, 198);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "แก้ไข";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdd.Location = new System.Drawing.Point(88, 198);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(76, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "เพิ่ม";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ctmMenu
            // 
            this.ctmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAdd,
            this.mniUpdate,
            this.mniDelete});
            this.ctmMenu.Name = "ctmMenu";
            this.ctmMenu.Size = new System.Drawing.Size(102, 70);
            // 
            // mniAdd
            // 
            this.mniAdd.Name = "mniAdd";
            this.mniAdd.Size = new System.Drawing.Size(101, 22);
            this.mniAdd.Text = "เพิ่ม";
            this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
            // 
            // mniUpdate
            // 
            this.mniUpdate.Name = "mniUpdate";
            this.mniUpdate.Size = new System.Drawing.Size(101, 22);
            this.mniUpdate.Text = "แก้ไข";
            this.mniUpdate.Click += new System.EventHandler(this.mniUpdate_Click);
            // 
            // mniDelete
            // 
            this.mniDelete.Name = "mniDelete";
            this.mniDelete.Size = new System.Drawing.Size(101, 22);
            this.mniDelete.Text = "ลบ";
            this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
            // 
            // dtgDriverStatus
            // 
            this.dtgDriverStatus.AllowUserToAddRows = false;
            this.dtgDriverStatus.AllowUserToDeleteRows = false;
            this.dtgDriverStatus.AllowUserToResizeColumns = false;
            this.dtgDriverStatus.AllowUserToResizeRows = false;
            this.dtgDriverStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgDriverStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgDriverStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgDriverStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EntityKey,
            this.Status,
            this.Hour,
            this.Amount});
            this.dtgDriverStatus.ContextMenuStrip = this.ctmMenu;
            this.dtgDriverStatus.Location = new System.Drawing.Point(12, 16);
            this.dtgDriverStatus.MultiSelect = false;
            this.dtgDriverStatus.Name = "dtgDriverStatus";
            this.dtgDriverStatus.ReadOnly = true;
            this.dtgDriverStatus.RowHeadersWidth = 23;
            this.dtgDriverStatus.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgDriverStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDriverStatus.Size = new System.Drawing.Size(388, 168);
            this.dtgDriverStatus.TabIndex = 14;
            this.dtgDriverStatus.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDriverStatus_CellDoubleClick);
            // 
            // EntityKey
            // 
            this.EntityKey.HeaderText = "EntityKey";
            this.EntityKey.Name = "EntityKey";
            this.EntityKey.ReadOnly = true;
            this.EntityKey.Visible = false;
            // 
            // Status
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "False";
            this.Status.DefaultCellStyle = dataGridViewCellStyle2;
            this.Status.FalseValue = "";
            this.Status.HeaderText = "เฉพาะคนขับ";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Status.TrueValue = "";
            // 
            // Hour
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "0";
            this.Hour.DefaultCellStyle = dataGridViewCellStyle3;
            this.Hour.HeaderText = "จำนวนชั่วโมงขั้นต่ำ";
            this.Hour.Name = "Hour";
            this.Hour.ReadOnly = true;
            this.Hour.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Hour.Width = 120;
            // 
            // Amount
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.Amount.DefaultCellStyle = dataGridViewCellStyle4;
            this.Amount.HeaderText = "ค่าบริการขั้นต่ำ";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Amount.Width = 120;
            // 
            // FrmMinimumOTCharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(413, 234);
            this.Controls.Add(this.dtgDriverStatus);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmMinimumOTCharge";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMinimumOTCharge_Load);
            this.ctmMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDriverStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ContextMenuStrip ctmMenu;
        private System.Windows.Forms.ToolStripMenuItem mniAdd;
        private System.Windows.Forms.ToolStripMenuItem mniUpdate;
        private System.Windows.Forms.ToolStripMenuItem mniDelete;
        private System.Windows.Forms.DataGridView dtgDriverStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntityKey;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hour;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
    }
}
