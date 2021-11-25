using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Presentation.AttendanceGUI
{
	public class UCTAnnualLeaveHead : System.Windows.Forms.UserControl
	{
		#region Component Designer generated code
		private System.Windows.Forms.Label lblForYear;
		private System.Windows.Forms.TextBox txbTotalDays;
		private System.Windows.Forms.TextBox txbUseDays;
		private System.Windows.Forms.TextBox txbSellDays;
		private System.Windows.Forms.TextBox txbRemainDays;
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
			this.lblForYear = new System.Windows.Forms.Label();
			this.txbTotalDays = new System.Windows.Forms.TextBox();
			this.txbUseDays = new System.Windows.Forms.TextBox();
			this.txbSellDays = new System.Windows.Forms.TextBox();
			this.txbRemainDays = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lblForYear
			// 
			this.lblForYear.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblForYear.Location = new System.Drawing.Point(8, 8);
			this.lblForYear.Name = "lblForYear";
			this.lblForYear.Size = new System.Drawing.Size(56, 20);
			this.lblForYear.TabIndex = 109;
			this.lblForYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txbTotalDays
			// 
			this.txbTotalDays.Location = new System.Drawing.Point(72, 8);
			this.txbTotalDays.Name = "txbTotalDays";
			this.txbTotalDays.ReadOnly = true;
			this.txbTotalDays.Size = new System.Drawing.Size(56, 20);
			this.txbTotalDays.TabIndex = 110;
			this.txbTotalDays.Text = "";
			this.txbTotalDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txbUseDays
			// 
			this.txbUseDays.Location = new System.Drawing.Point(136, 8);
			this.txbUseDays.Name = "txbUseDays";
			this.txbUseDays.ReadOnly = true;
			this.txbUseDays.Size = new System.Drawing.Size(56, 20);
			this.txbUseDays.TabIndex = 111;
			this.txbUseDays.Text = "";
			this.txbUseDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txbSellDays
			// 
			this.txbSellDays.Location = new System.Drawing.Point(200, 8);
			this.txbSellDays.Name = "txbSellDays";
			this.txbSellDays.ReadOnly = true;
			this.txbSellDays.Size = new System.Drawing.Size(56, 20);
			this.txbSellDays.TabIndex = 112;
			this.txbSellDays.Text = "";
			this.txbSellDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txbRemainDays
			// 
			this.txbRemainDays.Location = new System.Drawing.Point(264, 8);
			this.txbRemainDays.Name = "txbRemainDays";
			this.txbRemainDays.ReadOnly = true;
			this.txbRemainDays.Size = new System.Drawing.Size(56, 20);
			this.txbRemainDays.TabIndex = 113;
			this.txbRemainDays.Text = "";
			this.txbRemainDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// UCTAnnualLeaveHead
			// 
			this.Controls.Add(this.txbRemainDays);
			this.Controls.Add(this.txbSellDays);
			this.Controls.Add(this.txbUseDays);
			this.Controls.Add(this.txbTotalDays);
			this.Controls.Add(this.lblForYear);
			this.Name = "UCTAnnualLeaveHead";
			this.Size = new System.Drawing.Size(328, 32);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Constant -
		#endregion

		#region - Property -
			public int ForYear
			{
				set{lblForYear.Text = value.ToString();}
			}

			public decimal TotalDays
			{
				set{txbTotalDays.Text = value.ToString();}
			}

			public decimal UseDays
			{
				set{txbUseDays.Text = value.ToString();}
			}

			public decimal SellDays
			{
				set{txbSellDays.Text = value.ToString();}
			}

			public decimal RemainDays
			{
				set{txbRemainDays.Text = value.ToString();}
			}
		#endregion

		//==============================  Constructor  ==============================\
		public UCTAnnualLeaveHead()
		{
			InitializeComponent();
		}

		//============================== Public Method ==============================
		public void Clear()
		{
			lblForYear.Text = "";
			txbTotalDays.Text = "";
			txbUseDays.Text = "";
			txbSellDays.Text = "";
			txbRemainDays.Text = "";
		}
	}
}