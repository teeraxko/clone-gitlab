using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Presentation.AttendanceGUI
{
	public class UCTLeavePeriod : System.Windows.Forms.UserControl
	{
		#region Component Designer generated code
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rdoFromAllDay;
		private System.Windows.Forms.RadioButton rdoFromSecondtHalf;
		private System.Windows.Forms.RadioButton rdoFromtFirstHalf;
		private System.ComponentModel.Container components = null;

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

		private void InitializeComponent()
		{
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.rdoFromAllDay = new System.Windows.Forms.RadioButton();
			this.rdoFromSecondtHalf = new System.Windows.Forms.RadioButton();
			this.rdoFromtFirstHalf = new System.Windows.Forms.RadioButton();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.rdoFromAllDay);
			this.groupBox2.Controls.Add(this.rdoFromSecondtHalf);
			this.groupBox2.Controls.Add(this.rdoFromtFirstHalf);
			this.groupBox2.Location = new System.Drawing.Point(8, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(120, 120);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "ช่วงเวลา";
			// 
			// rdoFromAllDay
			// 
			this.rdoFromAllDay.Location = new System.Drawing.Point(24, 88);
			this.rdoFromAllDay.Name = "rdoFromAllDay";
			this.rdoFromAllDay.Size = new System.Drawing.Size(56, 24);
			this.rdoFromAllDay.TabIndex = 2;
			this.rdoFromAllDay.Text = " ทั้งวัน";
			// 
			// rdoFromSecondtHalf
			// 
			this.rdoFromSecondtHalf.Location = new System.Drawing.Point(24, 56);
			this.rdoFromSecondtHalf.Name = "rdoFromSecondtHalf";
			this.rdoFromSecondtHalf.Size = new System.Drawing.Size(80, 24);
			this.rdoFromSecondtHalf.TabIndex = 1;
			this.rdoFromSecondtHalf.Text = " ครึ่งวันหลัง";
			// 
			// rdoFromtFirstHalf
			// 
			this.rdoFromtFirstHalf.Location = new System.Drawing.Point(24, 24);
			this.rdoFromtFirstHalf.Name = "rdoFromtFirstHalf";
			this.rdoFromtFirstHalf.Size = new System.Drawing.Size(80, 24);
			this.rdoFromtFirstHalf.TabIndex = 0;
			this.rdoFromtFirstHalf.Text = " ครึ่งวันแรก";
			// 
			// UCTLeavePeriod
			// 
			this.Controls.Add(this.groupBox2);
			this.Name = "UCTLeavePeriod";
			this.Size = new System.Drawing.Size(136, 136);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		#region - Constant -
			public enum PERIOD_TYPE
			{
				AM,
				PM,
				ALL_DAY,
			}
		#endregion

		#region - Property -
		#endregion

		//==============================  Constructor  ==============================
		public UCTLeavePeriod()
		{
			InitializeComponent();
		}

		//============================== Public Method ==============================
		public void Clear()
		{
			rdoFromtFirstHalf.Checked = false;
			rdoFromSecondtHalf.Checked = false;
			rdoFromAllDay.Checked = false;
		}

		public void EnablePeriod(bool enable)
		{
			rdoFromtFirstHalf.Enabled = enable;
			rdoFromSecondtHalf.Enabled = enable;
			rdoFromAllDay.Enabled = enable;
		}

		public void EnablePeriod(PERIOD_TYPE value, bool enable)
		{
			switch(value)
			{
				case PERIOD_TYPE.AM :
				{
					rdoFromtFirstHalf.Enabled = enable;
					break;
				}
				case PERIOD_TYPE.PM :
				{
					rdoFromSecondtHalf.Enabled = enable;
					break;
				}
				case PERIOD_TYPE.ALL_DAY :
				{
					rdoFromAllDay.Enabled = enable;
					break;
				}
			}
		}

		public PERIOD_TYPE SelectedValue
		{
			get
			{
				if(rdoFromtFirstHalf.Checked)
				{
					return PERIOD_TYPE.AM;
				}
				if(rdoFromSecondtHalf.Checked)
				{
					return PERIOD_TYPE.PM;
				}
				return PERIOD_TYPE.ALL_DAY;
			}
			set
			{
				switch(value)
				{
					case PERIOD_TYPE.AM :
					{
						rdoFromtFirstHalf.Checked = true;
						break;
					}
					case PERIOD_TYPE.PM :
					{
						rdoFromSecondtHalf.Checked = true;
						break;
					}
					case PERIOD_TYPE.ALL_DAY :
					{
						rdoFromAllDay.Checked = true;
						break;
					}
				}
			}
		}
	}
}