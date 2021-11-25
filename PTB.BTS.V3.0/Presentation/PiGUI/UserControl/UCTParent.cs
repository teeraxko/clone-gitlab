using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Entity.CommonEntity;

using Facade.CommonFacade;
namespace Presentation.PiGUI.UserControl
{
	public class UCTParent : System.Windows.Forms.UserControl
	{
		public UCTParent()
		{
			InitializeComponent();
		}

		#region Component Designer generated code
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		private System.Windows.Forms.Label label71;
		private System.Windows.Forms.Label label72;
		private System.Windows.Forms.CheckBox chkAlive;
		public System.Windows.Forms.ComboBox cboPrefix;
		private System.Windows.Forms.TextBox txtSurName;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label70;
		public Presentation.PiGUI.UserControl.UCTAge uctAge1;
		public System.Windows.Forms.ComboBox cboOccupation;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.chkAlive = new System.Windows.Forms.CheckBox();
			this.cboPrefix = new System.Windows.Forms.ComboBox();
			this.txtSurName = new System.Windows.Forms.TextBox();
			this.label71 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label72 = new System.Windows.Forms.Label();
			this.label70 = new System.Windows.Forms.Label();
			this.uctAge1 = new Presentation.PiGUI.UserControl.UCTAge();
			this.cboOccupation = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// chkAlive
			// 
			this.chkAlive.Checked = true;
			this.chkAlive.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkAlive.Location = new System.Drawing.Point(288, 40);
			this.chkAlive.Name = "chkAlive";
			this.chkAlive.Size = new System.Drawing.Size(88, 24);
			this.chkAlive.TabIndex = 5;
			this.chkAlive.Text = "  ยังมีชีวิตอยู่";
			this.chkAlive.CheckedChanged += new System.EventHandler(this.chkAlive_CheckedChanged);
			// 
			// cboPrefix
			// 
			this.cboPrefix.Location = new System.Drawing.Point(64, 8);
			this.cboPrefix.MaxLength = 10;
			this.cboPrefix.Name = "cboPrefix";
			this.cboPrefix.Size = new System.Drawing.Size(80, 21);
			this.cboPrefix.TabIndex = 1;
			this.cboPrefix.TextChanged += new System.EventHandler(this.cboPrefix_TextChanged);
			this.cboPrefix.SelectedIndexChanged += new System.EventHandler(this.cboPrefix_SelectedIndexChanged);
			// 
			// txtSurName
			// 
			this.txtSurName.Location = new System.Drawing.Point(288, 8);
			this.txtSurName.MaxLength = 50;
			this.txtSurName.Name = "txtSurName";
			this.txtSurName.Size = new System.Drawing.Size(128, 20);
			this.txtSurName.TabIndex = 3;
			this.txtSurName.Text = "";
			this.txtSurName.TextChanged += new System.EventHandler(this.txtSurName_TextChanged);
			// 
			// label71
			// 
			this.label71.Location = new System.Drawing.Point(0, 40);
			this.label71.Name = "label71";
			this.label71.Size = new System.Drawing.Size(48, 23);
			this.label71.TabIndex = 58;
			this.label71.Text = "อาชีพ";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(152, 8);
			this.txtName.MaxLength = 50;
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(128, 20);
			this.txtName.TabIndex = 2;
			this.txtName.Text = "";
			this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
			// 
			// label72
			// 
			this.label72.Location = new System.Drawing.Point(0, 8);
			this.label72.Name = "label72";
			this.label72.Size = new System.Drawing.Size(56, 23);
			this.label72.TabIndex = 57;
			this.label72.Text = "ชื่อ - สกุล";
			// 
			// label70
			// 
			this.label70.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label70.Location = new System.Drawing.Point(0, 72);
			this.label70.Name = "label70";
			this.label70.Size = new System.Drawing.Size(48, 23);
			this.label70.TabIndex = 59;
			this.label70.Text = "วันเกิด";
			// 
			// uctAge1
			// 
			this.uctAge1.Agemonth = "0";
			this.uctAge1.Ageyear = "0";
			this.uctAge1.Birthday = new System.DateTime(2005, 9, 7, 11, 17, 46, 732);
			this.uctAge1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.uctAge1.label = "label";
			this.uctAge1.Location = new System.Drawing.Point(56, 70);
			this.uctAge1.Name = "uctAge1";
			this.uctAge1.Size = new System.Drawing.Size(336, 24);
			this.uctAge1.TabIndex = 6;
			// 
			// cboOccupation
			// 
			this.cboOccupation.AccessibleDescription = "";
			this.cboOccupation.Location = new System.Drawing.Point(64, 38);
			this.cboOccupation.MaxLength = 50;
			this.cboOccupation.Name = "cboOccupation";
			this.cboOccupation.Size = new System.Drawing.Size(160, 21);
			this.cboOccupation.TabIndex = 4;
			this.cboOccupation.TextChanged += new System.EventHandler(this.cboOccupation_TextChanged);
			this.cboOccupation.SelectedIndexChanged += new System.EventHandler(this.cboOccupation_SelectedIndexChanged);
			// 
			// UCTParent
			// 
			this.Controls.Add(this.cboOccupation);
			this.Controls.Add(this.uctAge1);
			this.Controls.Add(this.chkAlive);
			this.Controls.Add(this.cboPrefix);
			this.Controls.Add(this.txtSurName);
			this.Controls.Add(this.label70);
			this.Controls.Add(this.label71);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label72);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.Name = "UCTParent";
			this.Size = new System.Drawing.Size(424, 96);
			this.ResumeLayout(false);

		}
		#endregion
		
//   ================================ Property =====================
		private bool prefixChange = false;
		public string Prefix
		{
			get
			{return cboPrefix.Text;}
			set
			{cboPrefix.Text = value;}
		}
		public ArrayList PrefixDatasource
		{
			set
			{
				setDataSource(cboPrefix, value);
			}
		}
		private bool thaiName = false;
		public string ThaiName
		{
			get
			{return txtName.Text;}
			set
			{txtName.Text = value;}
		}

		private bool surName = false;
		public string SurName
		{
			get
			{return txtSurName.Text;}
			set
			{txtSurName.Text = value;}
		}

		private bool occupation = false;
		public string Occupation
		{
			get
			{return cboOccupation.Text;}
			set
			{cboOccupation.Text = value;}
		}
		public ArrayList OccupationDatasource
		{
			set
			{
				setDataSource(cboOccupation, value);
			}
		}
		public DateTime Birthdate
		{
			get
			{return uctAge1.Birthday;}
			set
			{uctAge1.Birthday = value;}
		}

		private bool alive = true;
		public bool Alive
		{
			get
			{return chkAlive.Checked;}
			set
			{chkAlive.Checked = value;}
		}
		

		private void setDataSource(ComboBox control, ArrayList dataSource)
		{
			control.Items.Clear();
			for(int i=0; i<dataSource.Count; i++)
			{
				control.Items.Add(dataSource[i]);
			}
		}
		private void setDataSource(ComboBox control, string[] dataSource)
		{
			
			for(int i=0; i<dataSource.Length; i++)
			{
				control.Items.Add(dataSource[i]);
			}
		}

		public void Clear()
		{
			cboOccupation.SelectedIndex = -1;
			cboPrefix.SelectedIndex = -1;
			cboOccupation.Text = "";
			cboPrefix.Text = "";
			txtName.Text = "";
			txtSurName.Text = "";
			chkAlive.Checked = true;
			uctAge1.Clear();
		}

		public void SetChangeAll(bool value)
		{
			prefixChange = value;
			thaiName = value;
			surName  =value;
			occupation = value;
			alive = value;
			uctAge1.SetChangeAll(value);
		}
		public void BirthDateChecked(bool value)
		{
			uctAge1.DTPChecked(value);
		}

		public bool HasChangeParent()
		{
			return prefixChange || thaiName || surName || occupation || alive || uctAge1.HasChangeAge();
		}

		private void cboPrefix_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			prefixChange = true;
		}

		private void txtName_TextChanged(object sender, System.EventArgs e)
		{
			thaiName = true;
		}

		private void txtSurName_TextChanged(object sender, System.EventArgs e)
		{
			surName  = true;
		}

		private void cboOccupation_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			occupation = true;
		}

		private void chkAlive_CheckedChanged(object sender, System.EventArgs e)
		{
			alive = true;
		}

		private void cboPrefix_TextChanged(object sender, System.EventArgs e)
		{
			prefixChange = true;
		}

		private void cboOccupation_TextChanged(object sender, System.EventArgs e)
		{
			occupation = true;
		}

	}
}
