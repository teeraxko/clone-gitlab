using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Entity.CommonEntity;

using Facade.CommonFacade;

using ictus.Common.Entity.General;

namespace Presentation.PiGUI.UserControl
{
	public class UCTAge : System.Windows.Forms.UserControl
	{

		public UCTAge()
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

		private System.Windows.Forms.DateTimePicker dtpBirthDate;
		private System.Windows.Forms.Label label125;
		private System.Windows.Forms.Label label1;
		private FarPoint.Win.Input.FpDouble fpdAgeyear;
		private FarPoint.Win.Input.FpDouble fpdAgemonth;
		private System.Windows.Forms.Label label00;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			this.label125 = new System.Windows.Forms.Label();
			this.fpdAgeyear = new FarPoint.Win.Input.FpDouble();
			this.label00 = new System.Windows.Forms.Label();
			this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.fpdAgemonth = new FarPoint.Win.Input.FpDouble();
			this.SuspendLayout();
			// 
			// label125
			// 
			this.label125.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label125.Location = new System.Drawing.Point(296, 0);
			this.label125.Name = "label125";
			this.label125.Size = new System.Drawing.Size(32, 23);
			this.label125.TabIndex = 65;
			this.label125.Text = "เดือน";
			// 
			// fpdAgeyear
			// 
			this.fpdAgeyear.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
			this.fpdAgeyear.AllowClipboardKeys = true;
			this.fpdAgeyear.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpdAgeyear.Enabled = false;
			this.fpdAgeyear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpdAgeyear.Location = new System.Drawing.Point(176, 0);
			this.fpdAgeyear.Name = "fpdAgeyear";
			this.fpdAgeyear.Size = new System.Drawing.Size(40, 20);
			this.fpdAgeyear.TabIndex = 2;
			this.fpdAgeyear.Text = "";
			// 
			// label00
			// 
			this.label00.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label00.Location = new System.Drawing.Point(128, 0);
			this.label00.Name = "label00";
			this.label00.Size = new System.Drawing.Size(40, 23);
			this.label00.TabIndex = 64;
			this.label00.Text = "label";
			// 
			// dtpBirthDate
			// 
			this.dtpBirthDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.dtpBirthDate.Checked = false;
			this.dtpBirthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpBirthDate.Location = new System.Drawing.Point(8, 0);
			this.dtpBirthDate.Name = "dtpBirthDate";
			this.dtpBirthDate.ShowCheckBox = true;
			this.dtpBirthDate.Size = new System.Drawing.Size(96, 20);
			this.dtpBirthDate.TabIndex = 1;
			this.dtpBirthDate.Value = new System.DateTime(2005, 9, 7, 11, 17, 46, 732);
			this.dtpBirthDate.ValueChanged += new System.EventHandler(this.dtpBirthDate_ValueChanged);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label1.Location = new System.Drawing.Point(224, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(16, 23);
			this.label1.TabIndex = 67;
			this.label1.Text = "ปี";
			// 
			// fpdAgemonth
			// 
			this.fpdAgemonth.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
			this.fpdAgemonth.AllowClipboardKeys = true;
			this.fpdAgemonth.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpdAgemonth.Enabled = false;
			this.fpdAgemonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpdAgemonth.Location = new System.Drawing.Point(240, 0);
			this.fpdAgemonth.Name = "fpdAgemonth";
			this.fpdAgemonth.Size = new System.Drawing.Size(40, 20);
			this.fpdAgemonth.TabIndex = 3;
			this.fpdAgemonth.Text = "";
			// 
			// UCTAge
			// 
			this.Controls.Add(this.label1);
			this.Controls.Add(this.fpdAgemonth);
			this.Controls.Add(this.label125);
			this.Controls.Add(this.fpdAgeyear);
			this.Controls.Add(this.label00);
			this.Controls.Add(this.dtpBirthDate);
			this.Name = "UCTAge";
			this.Size = new System.Drawing.Size(336, 24);
			this.Load += new System.EventHandler(this.UCTAge_Load);
			this.ResumeLayout(false);

		}
		#endregion

//   ================================ Property =====================
		private bool birthdayChange = false;
		public DateTime Birthday
		{
			get
			{
				if(dtpBirthDate.Checked)
				{
					DateTime temp = dtpBirthDate.Value;	
					return temp;					
				}
				else
				{
					return NullConstant.DATETIME;
				}
			}
			set
			{				
				if(value == NullConstant.DATETIME)
				{
					dtpBirthDate.Checked = false;	
				}
				else
				{
					dtpBirthDate.Value = value;
					dtpBirthDate.Checked = true;
				}
				dtpBirthDate.Tag = dtpBirthDate.Checked;
			}
		}

		public string Ageyear
		{
			get
			{return fpdAgeyear.Text;}
			set
			{fpdAgeyear.Text = value;}
		}

		public string Agemonth
		{
			get
			{return fpdAgemonth.Text;}
			set
			{fpdAgemonth.Text = value;}
		}

		public string label
		{
			get
			{return label00.Text;}
			set
			{label00.Text = value;}
		}

		public void Clear()
		{
			dtpBirthDate.Value = DateTime.Today;
			dtpBirthDate.Checked = false;
			label00.Text = "อายุ";
			fpdAgeyear.Text = "0";
			fpdAgemonth.Text = "0";
		}

		public void calculateDate()
		{
			int currentday = DateTime.Today.Day;
			int currentmonth = DateTime.Today.Month;
			int currentyear = DateTime.Today.Year;

			DateTime hiredate = dtpBirthDate.Value;
			int dayhire = hiredate.Day;
			int monthhire = hiredate.Month;
			int yearhire = hiredate.Year;

			int diffyear = currentyear-yearhire;
			int diffmonth = currentmonth-monthhire;
			int diffday = currentday-dayhire;
			if(diffday < 0)
			{
				diffmonth = diffmonth -1;
			}
			if(diffmonth < 0)
			{
				diffyear = diffyear - 1;
				diffmonth = diffmonth + 12;
			}
			fpdAgeyear.Text = Convert.ToString(diffyear);
			fpdAgemonth.Text = Convert.ToString(diffmonth);
		}

		public void SetChangeAll(bool value)
		{
			birthdayChange = value;
		}

		public bool HasChangeAge()
		{
			return birthdayChange || (dtpBirthDate.Checked != (bool)dtpBirthDate.Tag);
		}

		private void dtpBirthDate_ValueChanged(object sender, System.EventArgs e)
		{
			birthdayChange = true;
			calculateDate();
		}

		private void UCTAge_Load(object sender, System.EventArgs e)
		{
			//dtpBirthDate.Checked = false;
//			dtpBirthDate.MaxDate = DateTime.Today;
		}

		public void DTPChecked(bool value)
		{
			dtpBirthDate.Checked = value;	
		}
	}
}
