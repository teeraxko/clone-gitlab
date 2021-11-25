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
	public class UCTPerson : System.Windows.Forms.UserControl
	{
		private System.ComponentModel.Container components = null;

		public UCTPerson()
		{
			InitializeComponent();
		}
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

		#region Component Designer generated code

		private System.Windows.Forms.Label label87;
		private System.Windows.Forms.Label label85;
		private System.Windows.Forms.Label label74;
		private System.Windows.Forms.Label label75;
		private System.Windows.Forms.Label label76;
		public System.Windows.Forms.ComboBox cboGender;
		public System.Windows.Forms.ComboBox cboRelationShip;
		public System.Windows.Forms.ComboBox cboOccupation;
		public Presentation.PiGUI.UserControl.UCTAddress uctAddress1;
		public Presentation.PiGUI.UserControl.UCTAge uctAge1;
		private System.Windows.Forms.TextBox txtName;
		private void InitializeComponent()
		{
			this.cboGender = new System.Windows.Forms.ComboBox();
			this.label87 = new System.Windows.Forms.Label();
			this.cboRelationShip = new System.Windows.Forms.ComboBox();
			this.label85 = new System.Windows.Forms.Label();
			this.label74 = new System.Windows.Forms.Label();
			this.cboOccupation = new System.Windows.Forms.ComboBox();
			this.label75 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label76 = new System.Windows.Forms.Label();
			this.uctAddress1 = new Presentation.PiGUI.UserControl.UCTAddress();
			this.uctAge1 = new Presentation.PiGUI.UserControl.UCTAge();
			this.SuspendLayout();
			// 
			// cboGender
			// 
			this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboGender.Location = new System.Drawing.Point(464, 40);
			this.cboGender.MaxLength = 1;
			this.cboGender.Name = "cboGender";
			this.cboGender.Size = new System.Drawing.Size(88, 21);
			this.cboGender.TabIndex = 5;
			this.cboGender.SelectedIndexChanged += new System.EventHandler(this.cboGender_SelectedIndexChanged);
			// 
			// label87
			// 
			this.label87.Location = new System.Drawing.Point(424, 40);
			this.label87.Name = "label87";
			this.label87.Size = new System.Drawing.Size(32, 23);
			this.label87.TabIndex = 70;
			this.label87.Text = "เพศ";
			// 
			// cboRelationShip
			// 
			this.cboRelationShip.Location = new System.Drawing.Point(776, 8);
			this.cboRelationShip.MaxLength = 50;
			this.cboRelationShip.Name = "cboRelationShip";
			this.cboRelationShip.Size = new System.Drawing.Size(128, 21);
			this.cboRelationShip.TabIndex = 3;
			this.cboRelationShip.TextChanged += new System.EventHandler(this.cboRelationShip_TextChanged);
			this.cboRelationShip.SelectedIndexChanged += new System.EventHandler(this.cboRelationShip_SelectedIndexChanged);
			// 
			// label85
			// 
			this.label85.Location = new System.Drawing.Point(688, 8);
			this.label85.Name = "label85";
			this.label85.Size = new System.Drawing.Size(72, 23);
			this.label85.TabIndex = 65;
			this.label85.Text = "เกี่ยวข้องเป็น";
			// 
			// label74
			// 
			this.label74.Location = new System.Drawing.Point(2, 40);
			this.label74.Name = "label74";
			this.label74.Size = new System.Drawing.Size(48, 23);
			this.label74.TabIndex = 38;
			this.label74.Text = "วันเกิด";
			// 
			// cboOccupation
			// 
			this.cboOccupation.AccessibleDescription = "";
			this.cboOccupation.Location = new System.Drawing.Point(496, 8);
			this.cboOccupation.MaxLength = 50;
			this.cboOccupation.Name = "cboOccupation";
			this.cboOccupation.Size = new System.Drawing.Size(160, 21);
			this.cboOccupation.TabIndex = 2;
			this.cboOccupation.TextChanged += new System.EventHandler(this.cboOccupation_TextChanged);
			this.cboOccupation.SelectedIndexChanged += new System.EventHandler(this.cboOccupation_SelectedIndexChanged);
			// 
			// label75
			// 
			this.label75.Location = new System.Drawing.Point(432, 8);
			this.label75.Name = "label75";
			this.label75.Size = new System.Drawing.Size(48, 23);
			this.label75.TabIndex = 36;
			this.label75.Text = "อาชีพ";
			// 
			// txtName
			// 
			this.txtName.AccessibleDescription = "txtCName";
			this.txtName.Location = new System.Drawing.Point(64, 8);
			this.txtName.MaxLength = 100;
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(352, 20);
			this.txtName.TabIndex = 1;
			this.txtName.Text = "";
			this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
			// 
			// label76
			// 
			this.label76.Location = new System.Drawing.Point(2, 8);
			this.label76.Name = "label76";
			this.label76.Size = new System.Drawing.Size(56, 23);
			this.label76.TabIndex = 33;
			this.label76.Text = "ชื่อ - สกุล";
			// 
			// uctAddress1
			// 
			this.uctAddress1.AddressLine = "";
			this.uctAddress1.District = "";
			this.uctAddress1.FaxNo = "";
			this.uctAddress1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.uctAddress1.Location = new System.Drawing.Point(-6, 64);
			this.uctAddress1.Name = "uctAddress1";
			this.uctAddress1.PostalCode = "0";
			this.uctAddress1.Province = "";
			this.uctAddress1.Size = new System.Drawing.Size(920, 72);
			this.uctAddress1.Street = "";
			this.uctAddress1.SubDistrict = "";
			this.uctAddress1.TabIndex = 6;
			this.uctAddress1.Telephone = "";
			// 
			// uctAge1
			// 
			this.uctAge1.Agemonth = "0";
			this.uctAge1.Ageyear = "0";
			this.uctAge1.Birthday = new System.DateTime(2005, 9, 7, 11, 17, 46, 732);
			this.uctAge1.label = "label";
			this.uctAge1.Location = new System.Drawing.Point(56, 40);
			this.uctAge1.Name = "uctAge1";
			this.uctAge1.Size = new System.Drawing.Size(336, 24);
			this.uctAge1.TabIndex = 4;
			// 
			// UCTPerson
			// 
			this.Controls.Add(this.uctAge1);
			this.Controls.Add(this.uctAddress1);
			this.Controls.Add(this.label85);
			this.Controls.Add(this.cboGender);
			this.Controls.Add(this.label87);
			this.Controls.Add(this.cboRelationShip);
			this.Controls.Add(this.label76);
			this.Controls.Add(this.label74);
			this.Controls.Add(this.cboOccupation);
			this.Controls.Add(this.label75);
			this.Controls.Add(this.txtName);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.Name = "UCTPerson";
			this.Size = new System.Drawing.Size(920, 128);
			this.ResumeLayout(false);

		}
		#endregion
	
//   ================================ Property =====================
		private bool thaiName = false;
		public string ThaiName
		{
			get
			{return txtName.Text;}
			set
			{txtName.Text = value;}
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
		private bool relationShip = false;
		public string RelationShip
		{
			get
			{return cboRelationShip.Text;}
			set
			{cboRelationShip.Text = value;}
		}
		public ArrayList RelationShipDatasource
		{
			set
			{
				setDataSource(cboRelationShip, value);
			}
		}
		private bool gender = false;
		public string Gender
		{
			get
			{return cboGender.Text;}
			set
			{cboGender.Text = value;}
		}
		public string[] GenderDatasource
		{
			set
			{
				setDataSource(cboGender, value);
			}
		}
		public DateTime Birthdate
		{
			get
			{return uctAge1.Birthday;}
			set
			{uctAge1.Birthday = value;}
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
			control.Items.Clear();
			for(int i=0; i<dataSource.Length; i++)
			{
				control.Items.Add(dataSource[i]);
			}
		}

		public void Clear()
		{
			cboGender.SelectedIndex = -1;
			cboOccupation.SelectedIndex = -1;
			cboRelationShip.SelectedIndex = -1;
			cboGender.Text = "";
			cboOccupation.Text = "";
			cboRelationShip.Text = "";
			txtName.Text = "";
			uctAddress1.Clear();
			uctAge1.Clear();
		}

		public void SetChangeAll(bool value)
		{
			thaiName = value;
			occupation = value;
			relationShip  =value;
			gender = value;
			uctAge1.SetChangeAll(value);
			uctAddress1.SetChangeAll(value);
		}
		public void BirthDateChecked(bool value)
		{
			uctAge1.DTPChecked(value);
		}
		public bool HasChangeParent()
		{
			return thaiName || occupation || relationShip || gender || uctAge1.HasChangeAge() || uctAddress1.HasChangeAddress();
		}

		private void txtName_TextChanged(object sender, System.EventArgs e)
		{
			thaiName = true;
		}

		private void cboOccupation_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			occupation = true;
		}

		private void cboRelationShip_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			relationShip = true;
		}

		private void cboGender_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			gender = true;
		}

		private void cboOccupation_TextChanged(object sender, System.EventArgs e)
		{
			occupation = true;
		}

		private void cboRelationShip_TextChanged(object sender, System.EventArgs e)
		{
			relationShip = true;
		}

	}
}
