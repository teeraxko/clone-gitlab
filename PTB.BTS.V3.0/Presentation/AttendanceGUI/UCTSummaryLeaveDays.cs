using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Presentation.AttendanceGUI
{
	public class UCTSummaryLeaveDays : System.Windows.Forms.UserControl
	{
		#region Component Designer generated code
		private System.Windows.Forms.GroupBox gpbLeave;
		private System.Windows.Forms.Label lblDayInMonth10;
		private System.Windows.Forms.Label lblDayInMonth9;
		private System.Windows.Forms.Label lblDayInMonth8;
		private System.Windows.Forms.Label lblDayInMonth7;
		private System.Windows.Forms.Label lblDayInMonth6;
		private System.Windows.Forms.Label lblDayInMonth5;
		private System.Windows.Forms.Label lblDayInMonth4;
		private System.Windows.Forms.Label lblDayInMonth3;
		private System.Windows.Forms.Label lblDayInMonth2;
		private System.Windows.Forms.Label lblDayInMonth1;
		private System.Windows.Forms.Label lblDayInMonth12;
		private System.Windows.Forms.Label lblDayInMonth11;
		private System.Windows.Forms.Label lblMonth10;
		private System.Windows.Forms.Label lblMonth9;
		private System.Windows.Forms.Label lblMonth8;
		private System.Windows.Forms.Label lblMonth7;
		private System.Windows.Forms.Label lblMonth6;
		private System.Windows.Forms.Label lblMonth5;
		private System.Windows.Forms.Label lblMonth4;
		private System.Windows.Forms.Label lblMonth3;
		private System.Windows.Forms.Label lblMonth2;
		private System.Windows.Forms.Label lblMonth1;
		private System.Windows.Forms.Label lblMonth12;
		private System.Windows.Forms.Label lblMonth11;
		private System.Windows.Forms.Label lblTotalDays;
		private System.Windows.Forms.Label lblTotal;
        private Label label2;
        private Label label1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label lblYearNext;
        private Label label3;
        private Label lblYearCurrent;

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
            this.gpbLeave = new System.Windows.Forms.GroupBox();
            this.lblTotalDays = new System.Windows.Forms.Label();
            this.lblDayInMonth10 = new System.Windows.Forms.Label();
            this.lblDayInMonth9 = new System.Windows.Forms.Label();
            this.lblDayInMonth8 = new System.Windows.Forms.Label();
            this.lblDayInMonth7 = new System.Windows.Forms.Label();
            this.lblDayInMonth6 = new System.Windows.Forms.Label();
            this.lblDayInMonth5 = new System.Windows.Forms.Label();
            this.lblDayInMonth4 = new System.Windows.Forms.Label();
            this.lblDayInMonth3 = new System.Windows.Forms.Label();
            this.lblDayInMonth2 = new System.Windows.Forms.Label();
            this.lblDayInMonth1 = new System.Windows.Forms.Label();
            this.lblDayInMonth12 = new System.Windows.Forms.Label();
            this.lblDayInMonth11 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblMonth10 = new System.Windows.Forms.Label();
            this.lblMonth9 = new System.Windows.Forms.Label();
            this.lblMonth8 = new System.Windows.Forms.Label();
            this.lblMonth7 = new System.Windows.Forms.Label();
            this.lblMonth6 = new System.Windows.Forms.Label();
            this.lblMonth5 = new System.Windows.Forms.Label();
            this.lblMonth4 = new System.Windows.Forms.Label();
            this.lblMonth3 = new System.Windows.Forms.Label();
            this.lblMonth2 = new System.Windows.Forms.Label();
            this.lblMonth1 = new System.Windows.Forms.Label();
            this.lblMonth12 = new System.Windows.Forms.Label();
            this.lblMonth11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblYearCurrent = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblYearNext = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gpbLeave.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbLeave
            // 
            this.gpbLeave.Controls.Add(this.label6);
            this.gpbLeave.Controls.Add(this.label5);
            this.gpbLeave.Controls.Add(this.label4);
            this.gpbLeave.Controls.Add(this.lblYearNext);
            this.gpbLeave.Controls.Add(this.label3);
            this.gpbLeave.Controls.Add(this.lblYearCurrent);
            this.gpbLeave.Controls.Add(this.label2);
            this.gpbLeave.Controls.Add(this.label1);
            this.gpbLeave.Controls.Add(this.lblTotalDays);
            this.gpbLeave.Controls.Add(this.lblDayInMonth10);
            this.gpbLeave.Controls.Add(this.lblDayInMonth9);
            this.gpbLeave.Controls.Add(this.lblDayInMonth8);
            this.gpbLeave.Controls.Add(this.lblDayInMonth7);
            this.gpbLeave.Controls.Add(this.lblDayInMonth6);
            this.gpbLeave.Controls.Add(this.lblDayInMonth5);
            this.gpbLeave.Controls.Add(this.lblDayInMonth4);
            this.gpbLeave.Controls.Add(this.lblDayInMonth3);
            this.gpbLeave.Controls.Add(this.lblDayInMonth2);
            this.gpbLeave.Controls.Add(this.lblDayInMonth1);
            this.gpbLeave.Controls.Add(this.lblDayInMonth12);
            this.gpbLeave.Controls.Add(this.lblDayInMonth11);
            this.gpbLeave.Controls.Add(this.lblTotal);
            this.gpbLeave.Controls.Add(this.lblMonth10);
            this.gpbLeave.Controls.Add(this.lblMonth9);
            this.gpbLeave.Controls.Add(this.lblMonth8);
            this.gpbLeave.Controls.Add(this.lblMonth7);
            this.gpbLeave.Controls.Add(this.lblMonth6);
            this.gpbLeave.Controls.Add(this.lblMonth5);
            this.gpbLeave.Controls.Add(this.lblMonth4);
            this.gpbLeave.Controls.Add(this.lblMonth3);
            this.gpbLeave.Controls.Add(this.lblMonth2);
            this.gpbLeave.Controls.Add(this.lblMonth1);
            this.gpbLeave.Controls.Add(this.lblMonth12);
            this.gpbLeave.Controls.Add(this.lblMonth11);
            this.gpbLeave.Location = new System.Drawing.Point(8, 0);
            this.gpbLeave.Name = "gpbLeave";
            this.gpbLeave.Size = new System.Drawing.Size(656, 104);
            this.gpbLeave.TabIndex = 60;
            this.gpbLeave.TabStop = false;
            this.gpbLeave.Text = "จำนวนวันลา";
            // 
            // lblTotalDays
            // 
            this.lblTotalDays.BackColor = System.Drawing.Color.MistyRose;
            this.lblTotalDays.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblTotalDays.Location = new System.Drawing.Point(600, 72);
            this.lblTotalDays.Name = "lblTotalDays";
            this.lblTotalDays.Size = new System.Drawing.Size(48, 20);
            this.lblTotalDays.TabIndex = 113;
            this.lblTotalDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDayInMonth10
            // 
            this.lblDayInMonth10.BackColor = System.Drawing.Color.MistyRose;
            this.lblDayInMonth10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDayInMonth10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblDayInMonth10.Location = new System.Drawing.Point(296, 72);
            this.lblDayInMonth10.Name = "lblDayInMonth10";
            this.lblDayInMonth10.Size = new System.Drawing.Size(32, 20);
            this.lblDayInMonth10.TabIndex = 111;
            this.lblDayInMonth10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDayInMonth9
            // 
            this.lblDayInMonth9.BackColor = System.Drawing.Color.MistyRose;
            this.lblDayInMonth9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDayInMonth9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblDayInMonth9.Location = new System.Drawing.Point(248, 72);
            this.lblDayInMonth9.Name = "lblDayInMonth9";
            this.lblDayInMonth9.Size = new System.Drawing.Size(32, 20);
            this.lblDayInMonth9.TabIndex = 110;
            this.lblDayInMonth9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDayInMonth8
            // 
            this.lblDayInMonth8.BackColor = System.Drawing.Color.MistyRose;
            this.lblDayInMonth8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDayInMonth8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblDayInMonth8.Location = new System.Drawing.Point(200, 72);
            this.lblDayInMonth8.Name = "lblDayInMonth8";
            this.lblDayInMonth8.Size = new System.Drawing.Size(32, 20);
            this.lblDayInMonth8.TabIndex = 109;
            this.lblDayInMonth8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDayInMonth7
            // 
            this.lblDayInMonth7.BackColor = System.Drawing.Color.MistyRose;
            this.lblDayInMonth7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDayInMonth7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblDayInMonth7.Location = new System.Drawing.Point(152, 72);
            this.lblDayInMonth7.Name = "lblDayInMonth7";
            this.lblDayInMonth7.Size = new System.Drawing.Size(32, 20);
            this.lblDayInMonth7.TabIndex = 108;
            this.lblDayInMonth7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDayInMonth6
            // 
            this.lblDayInMonth6.BackColor = System.Drawing.Color.MistyRose;
            this.lblDayInMonth6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDayInMonth6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblDayInMonth6.Location = new System.Drawing.Point(104, 72);
            this.lblDayInMonth6.Name = "lblDayInMonth6";
            this.lblDayInMonth6.Size = new System.Drawing.Size(32, 20);
            this.lblDayInMonth6.TabIndex = 107;
            this.lblDayInMonth6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDayInMonth5
            // 
            this.lblDayInMonth5.BackColor = System.Drawing.Color.MistyRose;
            this.lblDayInMonth5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDayInMonth5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblDayInMonth5.Location = new System.Drawing.Point(56, 72);
            this.lblDayInMonth5.Name = "lblDayInMonth5";
            this.lblDayInMonth5.Size = new System.Drawing.Size(32, 20);
            this.lblDayInMonth5.TabIndex = 106;
            this.lblDayInMonth5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDayInMonth4
            // 
            this.lblDayInMonth4.BackColor = System.Drawing.Color.MistyRose;
            this.lblDayInMonth4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDayInMonth4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblDayInMonth4.Location = new System.Drawing.Point(8, 72);
            this.lblDayInMonth4.Name = "lblDayInMonth4";
            this.lblDayInMonth4.Size = new System.Drawing.Size(32, 20);
            this.lblDayInMonth4.TabIndex = 105;
            this.lblDayInMonth4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDayInMonth3
            // 
            this.lblDayInMonth3.BackColor = System.Drawing.Color.MistyRose;
            this.lblDayInMonth3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDayInMonth3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblDayInMonth3.Location = new System.Drawing.Point(536, 72);
            this.lblDayInMonth3.Name = "lblDayInMonth3";
            this.lblDayInMonth3.Size = new System.Drawing.Size(32, 20);
            this.lblDayInMonth3.TabIndex = 104;
            this.lblDayInMonth3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDayInMonth2
            // 
            this.lblDayInMonth2.BackColor = System.Drawing.Color.MistyRose;
            this.lblDayInMonth2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDayInMonth2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblDayInMonth2.Location = new System.Drawing.Point(488, 72);
            this.lblDayInMonth2.Name = "lblDayInMonth2";
            this.lblDayInMonth2.Size = new System.Drawing.Size(32, 20);
            this.lblDayInMonth2.TabIndex = 103;
            this.lblDayInMonth2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDayInMonth1
            // 
            this.lblDayInMonth1.BackColor = System.Drawing.Color.MistyRose;
            this.lblDayInMonth1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDayInMonth1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblDayInMonth1.Location = new System.Drawing.Point(440, 72);
            this.lblDayInMonth1.Name = "lblDayInMonth1";
            this.lblDayInMonth1.Size = new System.Drawing.Size(32, 20);
            this.lblDayInMonth1.TabIndex = 102;
            this.lblDayInMonth1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDayInMonth12
            // 
            this.lblDayInMonth12.BackColor = System.Drawing.Color.MistyRose;
            this.lblDayInMonth12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDayInMonth12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblDayInMonth12.Location = new System.Drawing.Point(392, 72);
            this.lblDayInMonth12.Name = "lblDayInMonth12";
            this.lblDayInMonth12.Size = new System.Drawing.Size(32, 20);
            this.lblDayInMonth12.TabIndex = 114;
            this.lblDayInMonth12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDayInMonth11
            // 
            this.lblDayInMonth11.BackColor = System.Drawing.Color.MistyRose;
            this.lblDayInMonth11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDayInMonth11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblDayInMonth11.Location = new System.Drawing.Point(344, 72);
            this.lblDayInMonth11.Name = "lblDayInMonth11";
            this.lblDayInMonth11.Size = new System.Drawing.Size(32, 20);
            this.lblDayInMonth11.TabIndex = 112;
            this.lblDayInMonth11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotal.Location = new System.Drawing.Point(600, 40);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(48, 20);
            this.lblTotal.TabIndex = 100;
            this.lblTotal.Text = "รวม";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMonth10
            // 
            this.lblMonth10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMonth10.Location = new System.Drawing.Point(296, 40);
            this.lblMonth10.Name = "lblMonth10";
            this.lblMonth10.Size = new System.Drawing.Size(32, 20);
            this.lblMonth10.TabIndex = 69;
            this.lblMonth10.Text = "ต.ค";
            this.lblMonth10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMonth9
            // 
            this.lblMonth9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMonth9.Location = new System.Drawing.Point(248, 40);
            this.lblMonth9.Name = "lblMonth9";
            this.lblMonth9.Size = new System.Drawing.Size(32, 20);
            this.lblMonth9.TabIndex = 68;
            this.lblMonth9.Text = "ก.ย";
            this.lblMonth9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMonth8
            // 
            this.lblMonth8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMonth8.Location = new System.Drawing.Point(200, 40);
            this.lblMonth8.Name = "lblMonth8";
            this.lblMonth8.Size = new System.Drawing.Size(32, 20);
            this.lblMonth8.TabIndex = 67;
            this.lblMonth8.Text = "ส.ค";
            this.lblMonth8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMonth7
            // 
            this.lblMonth7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMonth7.Location = new System.Drawing.Point(152, 40);
            this.lblMonth7.Name = "lblMonth7";
            this.lblMonth7.Size = new System.Drawing.Size(32, 20);
            this.lblMonth7.TabIndex = 66;
            this.lblMonth7.Text = "ก.ค";
            this.lblMonth7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMonth6
            // 
            this.lblMonth6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMonth6.Location = new System.Drawing.Point(104, 40);
            this.lblMonth6.Name = "lblMonth6";
            this.lblMonth6.Size = new System.Drawing.Size(32, 20);
            this.lblMonth6.TabIndex = 65;
            this.lblMonth6.Text = "มิ.ย";
            this.lblMonth6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMonth5
            // 
            this.lblMonth5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMonth5.Location = new System.Drawing.Point(56, 40);
            this.lblMonth5.Name = "lblMonth5";
            this.lblMonth5.Size = new System.Drawing.Size(32, 20);
            this.lblMonth5.TabIndex = 64;
            this.lblMonth5.Text = "พ.ค";
            this.lblMonth5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMonth4
            // 
            this.lblMonth4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMonth4.Location = new System.Drawing.Point(8, 40);
            this.lblMonth4.Name = "lblMonth4";
            this.lblMonth4.Size = new System.Drawing.Size(32, 20);
            this.lblMonth4.TabIndex = 63;
            this.lblMonth4.Text = "เม.ย";
            this.lblMonth4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMonth3
            // 
            this.lblMonth3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMonth3.Location = new System.Drawing.Point(536, 40);
            this.lblMonth3.Name = "lblMonth3";
            this.lblMonth3.Size = new System.Drawing.Size(32, 20);
            this.lblMonth3.TabIndex = 62;
            this.lblMonth3.Text = "มี.ค";
            this.lblMonth3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMonth2
            // 
            this.lblMonth2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMonth2.Location = new System.Drawing.Point(488, 40);
            this.lblMonth2.Name = "lblMonth2";
            this.lblMonth2.Size = new System.Drawing.Size(32, 20);
            this.lblMonth2.TabIndex = 61;
            this.lblMonth2.Text = "ก.พ";
            this.lblMonth2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMonth1
            // 
            this.lblMonth1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMonth1.Location = new System.Drawing.Point(440, 40);
            this.lblMonth1.Name = "lblMonth1";
            this.lblMonth1.Size = new System.Drawing.Size(32, 20);
            this.lblMonth1.TabIndex = 45;
            this.lblMonth1.Text = "ม.ค";
            this.lblMonth1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMonth12
            // 
            this.lblMonth12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMonth12.Location = new System.Drawing.Point(392, 40);
            this.lblMonth12.Name = "lblMonth12";
            this.lblMonth12.Size = new System.Drawing.Size(32, 20);
            this.lblMonth12.TabIndex = 101;
            this.lblMonth12.Text = "ธ.ค";
            this.lblMonth12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMonth11
            // 
            this.lblMonth11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMonth11.Location = new System.Drawing.Point(344, 40);
            this.lblMonth11.Name = "lblMonth11";
            this.lblMonth11.Size = new System.Drawing.Size(32, 20);
            this.lblMonth11.TabIndex = 100;
            this.lblMonth11.Text = "พ.ย";
            this.lblMonth11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 13);
            this.label1.TabIndex = 115;
            this.label1.Text = "|-------------------------------------------------";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 13);
            this.label2.TabIndex = 116;
            this.label2.Text = "-------------------------------------------------|";
            // 
            // lblPreviousYear
            // 
            this.lblYearCurrent.AutoSize = true;
            this.lblYearCurrent.Location = new System.Drawing.Point(206, 16);
            this.lblYearCurrent.Name = "lblPreviousYear";
            this.lblYearCurrent.Size = new System.Drawing.Size(35, 13);
            this.lblYearCurrent.TabIndex = 117;
            this.lblYearCurrent.Text = "XXXX";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 118;
            this.label3.Text = "ปี";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(480, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 120;
            this.label4.Text = "ปี";
            // 
            // lblCurrentYear
            // 
            this.lblYearNext.AutoSize = true;
            this.lblYearNext.Location = new System.Drawing.Point(494, 16);
            this.lblYearNext.Name = "lblCurrentYear";
            this.lblYearNext.Size = new System.Drawing.Size(35, 13);
            this.lblYearNext.TabIndex = 119;
            this.lblYearNext.Text = "XXXX";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(440, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 121;
            this.label5.Text = "|---------";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(529, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 122;
            this.label6.Text = "---------|";
            // 
            // UCTSummaryLeaveDays
            // 
            this.Controls.Add(this.gpbLeave);
            this.Name = "UCTSummaryLeaveDays";
            this.Size = new System.Drawing.Size(672, 112);
            this.Load += new System.EventHandler(this.UCTSummaryLeaveDays_Load);
            this.gpbLeave.ResumeLayout(false);
            this.gpbLeave.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		public UCTSummaryLeaveDays()
		{
			InitializeComponent();
		}

		private float[] dayInMonth = new float[12];

		public void Clear()
		{
			lblDayInMonth1.Text = "";
			lblDayInMonth2.Text = "";
			lblDayInMonth3.Text = "";
			lblDayInMonth4.Text = "";
			lblDayInMonth5.Text = "";
			lblDayInMonth6.Text = "";
			lblDayInMonth7.Text = "";
			lblDayInMonth8.Text = "";
			lblDayInMonth9.Text = "";
			lblDayInMonth10.Text = "";
			lblDayInMonth11.Text = "";
			lblDayInMonth12.Text = "";

			for(int i=0; i<12; i++)
			{
				dayInMonth[i] = 0;
			}
		}

		public void Add(int month, float day)
		{
			dayInMonth[month - 1] += day;
		}

		public void ShowDayInMonth(DateTime forDate)
		{
			lblDayInMonth1.Text = dayInMonth[0].ToString();
			lblDayInMonth2.Text = dayInMonth[1].ToString();
			lblDayInMonth3.Text = dayInMonth[2].ToString();
			lblDayInMonth4.Text = dayInMonth[3].ToString();
			lblDayInMonth5.Text = dayInMonth[4].ToString();
			lblDayInMonth6.Text = dayInMonth[5].ToString();
			lblDayInMonth7.Text = dayInMonth[6].ToString();
			lblDayInMonth8.Text = dayInMonth[7].ToString();
			lblDayInMonth9.Text = dayInMonth[8].ToString();
			lblDayInMonth10.Text = dayInMonth[9].ToString();
			lblDayInMonth11.Text = dayInMonth[10].ToString();
			lblDayInMonth12.Text = dayInMonth[11].ToString();

			float total = 0;
			for(int i=0; i<12; i++)
			{
				total += dayInMonth[i];
			}

			lblTotalDays.Text = total.ToString();

            if (forDate.Month >= 4)
            {
                lblYearCurrent.Text = forDate.Year.ToString();
                lblYearNext.Text = forDate.AddYears(1).Year.ToString();                
            }
            else
            {
                lblYearCurrent.Text = forDate.AddYears(-1).Year.ToString();
                lblYearNext.Text = forDate.Year.ToString();
            }
		}

		private void UCTSummaryLeaveDays_Load(object sender, System.EventArgs e)
		{
		}
	}
}