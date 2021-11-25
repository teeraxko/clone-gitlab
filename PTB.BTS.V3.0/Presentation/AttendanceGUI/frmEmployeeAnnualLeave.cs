using System;
using System.Collections;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

using Entity.AttendanceEntities;
using Entity.CommonEntity;
using ictus.PIS.PI.Entity;

using Facade.AttendanceFacade;

using Presentation.CommonGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

namespace Presentation.AttendanceGUI
{
	public class frmEmployeeAnnualLeave : Presentation.AttendanceGUI.frmEmployeeAttendanceBase, IMDIChildForm
	{
        #region Designer generated code

        private System.Windows.Forms.DateTimePicker dtpForMonth;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdAmend;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Label lblForMonth;
        private System.Windows.Forms.GroupBox gpbAnnualLeav;
        private FarPoint.Win.Spread.FpSpread fpsAnnualLeave;
        private FarPoint.Win.Spread.SheetView fpsAnnualLeave_Sheet1;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem mniAdd;
        private System.Windows.Forms.MenuItem mniEdit;
        private System.Windows.Forms.MenuItem mniDelete;
        private FarPoint.Win.Input.FpDouble fpdJan;
        private FarPoint.Win.Input.FpDouble fpdFeb;
        private FarPoint.Win.Input.FpDouble fpdMar;
        private FarPoint.Win.Input.FpDouble fpdApr;
        private FarPoint.Win.Input.FpDouble fpdMay;
        private FarPoint.Win.Input.FpDouble fpdJun;
        private FarPoint.Win.Input.FpDouble fpdJul;
        private FarPoint.Win.Input.FpDouble fpdAug;
        private FarPoint.Win.Input.FpDouble fpdSep;
        private FarPoint.Win.Input.FpDouble fpdOct;
        private FarPoint.Win.Input.FpDouble fpdNov;
        private FarPoint.Win.Input.FpDouble fpdDec;
        private Presentation.AttendanceGUI.UCTAnnualLeaveHead uctAnnualLeaveHeadCurrent;
        private Presentation.AttendanceGUI.UCTAnnualLeaveHead uctAnnualLeaveHeadPrevious;
        private System.Windows.Forms.Label lblDec;
        private System.Windows.Forms.Label lblNov;
        private System.Windows.Forms.Label lblOct;
        private System.Windows.Forms.Label lblSep;
        private System.Windows.Forms.Label lblAug;
        private System.Windows.Forms.Label lblJul;
        private System.Windows.Forms.Label lblJun;
        private System.Windows.Forms.Label lblMay;
        private System.Windows.Forms.Label lblApr;
        private System.Windows.Forms.Label lblMar;
        private System.Windows.Forms.Label lblFeb;
        private System.Windows.Forms.Label lblJan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblYearCurrent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblYearNext;
        private System.Windows.Forms.Label label6;
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmEmployeeAnnualLeave));
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType3 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.lblForMonth = new System.Windows.Forms.Label();
            this.dtpForMonth = new System.Windows.Forms.DateTimePicker();
            this.gpbAnnualLeav = new System.Windows.Forms.GroupBox();
            this.fpdDec = new FarPoint.Win.Input.FpDouble();
            this.fpdNov = new FarPoint.Win.Input.FpDouble();
            this.fpdOct = new FarPoint.Win.Input.FpDouble();
            this.fpdSep = new FarPoint.Win.Input.FpDouble();
            this.fpdAug = new FarPoint.Win.Input.FpDouble();
            this.fpdJul = new FarPoint.Win.Input.FpDouble();
            this.fpdJun = new FarPoint.Win.Input.FpDouble();
            this.fpdMay = new FarPoint.Win.Input.FpDouble();
            this.fpdApr = new FarPoint.Win.Input.FpDouble();
            this.fpdMar = new FarPoint.Win.Input.FpDouble();
            this.fpdFeb = new FarPoint.Win.Input.FpDouble();
            this.fpdJan = new FarPoint.Win.Input.FpDouble();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblDec = new System.Windows.Forms.Label();
            this.lblNov = new System.Windows.Forms.Label();
            this.lblOct = new System.Windows.Forms.Label();
            this.lblSep = new System.Windows.Forms.Label();
            this.lblAug = new System.Windows.Forms.Label();
            this.lblJul = new System.Windows.Forms.Label();
            this.lblJun = new System.Windows.Forms.Label();
            this.lblMay = new System.Windows.Forms.Label();
            this.lblApr = new System.Windows.Forms.Label();
            this.lblMar = new System.Windows.Forms.Label();
            this.lblFeb = new System.Windows.Forms.Label();
            this.lblJan = new System.Windows.Forms.Label();
            this.uctAnnualLeaveHeadCurrent = new Presentation.AttendanceGUI.UCTAnnualLeaveHead();
            this.uctAnnualLeaveHeadPrevious = new Presentation.AttendanceGUI.UCTAnnualLeaveHead();
            this.label22 = new System.Windows.Forms.Label();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdAmend = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.fpsAnnualLeave = new FarPoint.Win.Spread.FpSpread();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.mniAdd = new System.Windows.Forms.MenuItem();
            this.mniEdit = new System.Windows.Forms.MenuItem();
            this.mniDelete = new System.Windows.Forms.MenuItem();
            this.fpsAnnualLeave_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblYearCurrent = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblYearNext = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gpbAnnualLeav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpsAnnualLeave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsAnnualLeave_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblForMonth
            // 
            this.lblForMonth.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblForMonth.AutoSize = true;
            this.lblForMonth.Location = new System.Drawing.Point(416, 146);
            this.lblForMonth.Name = "lblForMonth";
            this.lblForMonth.Size = new System.Drawing.Size(58, 16);
            this.lblForMonth.TabIndex = 24;
            this.lblForMonth.Text = "สำหรับเดือน";
            this.lblForMonth.Visible = false;
            // 
            // dtpForMonth
            // 
            this.dtpForMonth.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpForMonth.CustomFormat = "MM/yyyy";
            this.dtpForMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpForMonth.Location = new System.Drawing.Point(488, 144);
            this.dtpForMonth.Name = "dtpForMonth";
            this.dtpForMonth.Size = new System.Drawing.Size(72, 20);
            this.dtpForMonth.TabIndex = 23;
            this.dtpForMonth.Visible = false;
            this.dtpForMonth.ValueChanged += new System.EventHandler(this.dtpForMonth_ValueChanged);
            // 
            // gpbAnnualLeav
            // 
            this.gpbAnnualLeav.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbAnnualLeav.Controls.Add(this.label6);
            this.gpbAnnualLeav.Controls.Add(this.lblYearNext);
            this.gpbAnnualLeav.Controls.Add(this.label4);
            this.gpbAnnualLeav.Controls.Add(this.label3);
            this.gpbAnnualLeav.Controls.Add(this.lblYearCurrent);
            this.gpbAnnualLeav.Controls.Add(this.label1);
            this.gpbAnnualLeav.Controls.Add(this.fpdDec);
            this.gpbAnnualLeav.Controls.Add(this.fpdNov);
            this.gpbAnnualLeav.Controls.Add(this.fpdOct);
            this.gpbAnnualLeav.Controls.Add(this.fpdSep);
            this.gpbAnnualLeav.Controls.Add(this.fpdAug);
            this.gpbAnnualLeav.Controls.Add(this.fpdJul);
            this.gpbAnnualLeav.Controls.Add(this.fpdJun);
            this.gpbAnnualLeav.Controls.Add(this.fpdMay);
            this.gpbAnnualLeav.Controls.Add(this.fpdApr);
            this.gpbAnnualLeav.Controls.Add(this.fpdMar);
            this.gpbAnnualLeav.Controls.Add(this.fpdFeb);
            this.gpbAnnualLeav.Controls.Add(this.fpdJan);
            this.gpbAnnualLeav.Controls.Add(this.label26);
            this.gpbAnnualLeav.Controls.Add(this.label25);
            this.gpbAnnualLeav.Controls.Add(this.label24);
            this.gpbAnnualLeav.Controls.Add(this.label23);
            this.gpbAnnualLeav.Controls.Add(this.lblDec);
            this.gpbAnnualLeav.Controls.Add(this.lblNov);
            this.gpbAnnualLeav.Controls.Add(this.lblOct);
            this.gpbAnnualLeav.Controls.Add(this.lblSep);
            this.gpbAnnualLeav.Controls.Add(this.lblAug);
            this.gpbAnnualLeav.Controls.Add(this.lblJul);
            this.gpbAnnualLeav.Controls.Add(this.lblJun);
            this.gpbAnnualLeav.Controls.Add(this.lblMay);
            this.gpbAnnualLeav.Controls.Add(this.lblApr);
            this.gpbAnnualLeav.Controls.Add(this.lblMar);
            this.gpbAnnualLeav.Controls.Add(this.lblFeb);
            this.gpbAnnualLeav.Controls.Add(this.lblJan);
            this.gpbAnnualLeav.Controls.Add(this.uctAnnualLeaveHeadCurrent);
            this.gpbAnnualLeav.Controls.Add(this.uctAnnualLeaveHeadPrevious);
            this.gpbAnnualLeav.Location = new System.Drawing.Point(116, 175);
            this.gpbAnnualLeav.Name = "gpbAnnualLeav";
            this.gpbAnnualLeav.Size = new System.Drawing.Size(780, 97);
            this.gpbAnnualLeav.TabIndex = 54;
            this.gpbAnnualLeav.TabStop = false;
            this.gpbAnnualLeav.Visible = false;
            // 
            // fpdDec
            // 
            this.fpdDec.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
            this.fpdDec.AllowClipboardKeys = true;
            this.fpdDec.BackColor = System.Drawing.Color.MistyRose;
            this.fpdDec.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdDec.DecimalPlaces = 1;
            this.fpdDec.DecimalSeparator = ".";
            this.fpdDec.Enabled = false;
            this.fpdDec.Location = new System.Drawing.Point(624, 64);
            this.fpdDec.Name = "fpdDec";
            this.fpdDec.NumberGroupSeparator = ",";
            this.fpdDec.Size = new System.Drawing.Size(32, 20);
            this.fpdDec.TabIndex = 99;
            this.fpdDec.Text = "";
            this.fpdDec.UseSeparator = true;
            // 
            // fpdNov
            // 
            this.fpdNov.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
            this.fpdNov.AllowClipboardKeys = true;
            this.fpdNov.BackColor = System.Drawing.Color.MistyRose;
            this.fpdNov.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdNov.DecimalPlaces = 1;
            this.fpdNov.DecimalSeparator = ".";
            this.fpdNov.Enabled = false;
            this.fpdNov.Location = new System.Drawing.Point(592, 64);
            this.fpdNov.Name = "fpdNov";
            this.fpdNov.NumberGroupSeparator = ",";
            this.fpdNov.Size = new System.Drawing.Size(32, 20);
            this.fpdNov.TabIndex = 98;
            this.fpdNov.Text = "";
            this.fpdNov.UseSeparator = true;
            // 
            // fpdOct
            // 
            this.fpdOct.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
            this.fpdOct.AllowClipboardKeys = true;
            this.fpdOct.BackColor = System.Drawing.Color.MistyRose;
            this.fpdOct.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdOct.DecimalPlaces = 1;
            this.fpdOct.DecimalSeparator = ".";
            this.fpdOct.Enabled = false;
            this.fpdOct.Location = new System.Drawing.Point(560, 64);
            this.fpdOct.Name = "fpdOct";
            this.fpdOct.NumberGroupSeparator = ",";
            this.fpdOct.Size = new System.Drawing.Size(32, 20);
            this.fpdOct.TabIndex = 97;
            this.fpdOct.Text = "";
            this.fpdOct.UseSeparator = true;
            // 
            // fpdSep
            // 
            this.fpdSep.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
            this.fpdSep.AllowClipboardKeys = true;
            this.fpdSep.BackColor = System.Drawing.Color.MistyRose;
            this.fpdSep.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdSep.DecimalPlaces = 1;
            this.fpdSep.DecimalSeparator = ".";
            this.fpdSep.Enabled = false;
            this.fpdSep.Location = new System.Drawing.Point(528, 64);
            this.fpdSep.Name = "fpdSep";
            this.fpdSep.NumberGroupSeparator = ",";
            this.fpdSep.Size = new System.Drawing.Size(32, 20);
            this.fpdSep.TabIndex = 96;
            this.fpdSep.Text = "";
            this.fpdSep.UseSeparator = true;
            // 
            // fpdAug
            // 
            this.fpdAug.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
            this.fpdAug.AllowClipboardKeys = true;
            this.fpdAug.BackColor = System.Drawing.Color.MistyRose;
            this.fpdAug.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdAug.DecimalPlaces = 1;
            this.fpdAug.DecimalSeparator = ".";
            this.fpdAug.Enabled = false;
            this.fpdAug.Location = new System.Drawing.Point(496, 64);
            this.fpdAug.Name = "fpdAug";
            this.fpdAug.NumberGroupSeparator = ",";
            this.fpdAug.Size = new System.Drawing.Size(32, 20);
            this.fpdAug.TabIndex = 95;
            this.fpdAug.Text = "";
            this.fpdAug.UseSeparator = true;
            // 
            // fpdJul
            // 
            this.fpdJul.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
            this.fpdJul.AllowClipboardKeys = true;
            this.fpdJul.BackColor = System.Drawing.Color.MistyRose;
            this.fpdJul.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdJul.DecimalPlaces = 1;
            this.fpdJul.DecimalSeparator = ".";
            this.fpdJul.Enabled = false;
            this.fpdJul.Location = new System.Drawing.Point(464, 64);
            this.fpdJul.Name = "fpdJul";
            this.fpdJul.NumberGroupSeparator = ",";
            this.fpdJul.Size = new System.Drawing.Size(32, 20);
            this.fpdJul.TabIndex = 94;
            this.fpdJul.Text = "";
            this.fpdJul.UseSeparator = true;
            // 
            // fpdJun
            // 
            this.fpdJun.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
            this.fpdJun.AllowClipboardKeys = true;
            this.fpdJun.BackColor = System.Drawing.Color.MistyRose;
            this.fpdJun.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdJun.DecimalPlaces = 1;
            this.fpdJun.DecimalSeparator = ".";
            this.fpdJun.Enabled = false;
            this.fpdJun.Location = new System.Drawing.Point(432, 64);
            this.fpdJun.Name = "fpdJun";
            this.fpdJun.NumberGroupSeparator = ",";
            this.fpdJun.Size = new System.Drawing.Size(32, 20);
            this.fpdJun.TabIndex = 93;
            this.fpdJun.Text = "";
            this.fpdJun.UseSeparator = true;
            // 
            // fpdMay
            // 
            this.fpdMay.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
            this.fpdMay.AllowClipboardKeys = true;
            this.fpdMay.BackColor = System.Drawing.Color.MistyRose;
            this.fpdMay.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdMay.DecimalPlaces = 1;
            this.fpdMay.DecimalSeparator = ".";
            this.fpdMay.Enabled = false;
            this.fpdMay.Location = new System.Drawing.Point(400, 64);
            this.fpdMay.Name = "fpdMay";
            this.fpdMay.NumberGroupSeparator = ",";
            this.fpdMay.Size = new System.Drawing.Size(32, 20);
            this.fpdMay.TabIndex = 92;
            this.fpdMay.Text = "";
            this.fpdMay.UseSeparator = true;
            // 
            // fpdApr
            // 
            this.fpdApr.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
            this.fpdApr.AllowClipboardKeys = true;
            this.fpdApr.BackColor = System.Drawing.Color.MistyRose;
            this.fpdApr.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdApr.DecimalPlaces = 1;
            this.fpdApr.DecimalSeparator = ".";
            this.fpdApr.Enabled = false;
            this.fpdApr.Location = new System.Drawing.Point(368, 64);
            this.fpdApr.Name = "fpdApr";
            this.fpdApr.NumberGroupSeparator = ",";
            this.fpdApr.Size = new System.Drawing.Size(32, 20);
            this.fpdApr.TabIndex = 91;
            this.fpdApr.Text = "";
            this.fpdApr.UseSeparator = true;
            // 
            // fpdMar
            // 
            this.fpdMar.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
            this.fpdMar.AllowClipboardKeys = true;
            this.fpdMar.BackColor = System.Drawing.Color.MistyRose;
            this.fpdMar.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdMar.DecimalPlaces = 1;
            this.fpdMar.DecimalSeparator = ".";
            this.fpdMar.Enabled = false;
            this.fpdMar.Location = new System.Drawing.Point(720, 64);
            this.fpdMar.Name = "fpdMar";
            this.fpdMar.NumberGroupSeparator = ",";
            this.fpdMar.Size = new System.Drawing.Size(32, 20);
            this.fpdMar.TabIndex = 90;
            this.fpdMar.Text = "";
            this.fpdMar.UseSeparator = true;
            // 
            // fpdFeb
            // 
            this.fpdFeb.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
            this.fpdFeb.AllowClipboardKeys = true;
            this.fpdFeb.BackColor = System.Drawing.Color.MistyRose;
            this.fpdFeb.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdFeb.DecimalPlaces = 1;
            this.fpdFeb.DecimalSeparator = ".";
            this.fpdFeb.Enabled = false;
            this.fpdFeb.Location = new System.Drawing.Point(688, 64);
            this.fpdFeb.Name = "fpdFeb";
            this.fpdFeb.NumberGroupSeparator = ",";
            this.fpdFeb.Size = new System.Drawing.Size(32, 20);
            this.fpdFeb.TabIndex = 89;
            this.fpdFeb.Text = "";
            this.fpdFeb.UseSeparator = true;
            // 
            // fpdJan
            // 
            this.fpdJan.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
            this.fpdJan.AllowClipboardKeys = true;
            this.fpdJan.BackColor = System.Drawing.Color.MistyRose;
            this.fpdJan.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdJan.DecimalPlaces = 1;
            this.fpdJan.DecimalSeparator = ".";
            this.fpdJan.Enabled = false;
            this.fpdJan.Location = new System.Drawing.Point(656, 64);
            this.fpdJan.Name = "fpdJan";
            this.fpdJan.NumberGroupSeparator = ",";
            this.fpdJan.Size = new System.Drawing.Size(32, 20);
            this.fpdJan.TabIndex = 88;
            this.fpdJan.Text = "";
            this.fpdJan.UseSeparator = true;
            // 
            // label26
            // 
            this.label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label26.Location = new System.Drawing.Point(208, 16);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(56, 20);
            this.label26.TabIndex = 79;
            this.label26.Text = "ขายคืน";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label25.Location = new System.Drawing.Point(144, 16);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 20);
            this.label25.TabIndex = 78;
            this.label25.Text = "ใช้ไป";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label24.Location = new System.Drawing.Point(272, 16);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(56, 20);
            this.label24.TabIndex = 77;
            this.label24.Text = "คงเหลือ";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label23.Location = new System.Drawing.Point(80, 16);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(56, 20);
            this.label23.TabIndex = 76;
            this.label23.Text = "วันลาทั้งสิ้น";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDec
            // 
            this.lblDec.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDec.Location = new System.Drawing.Point(624, 40);
            this.lblDec.Name = "lblDec";
            this.lblDec.Size = new System.Drawing.Size(32, 20);
            this.lblDec.TabIndex = 71;
            this.lblDec.Text = "ธ.ค";
            this.lblDec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNov
            // 
            this.lblNov.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNov.Location = new System.Drawing.Point(592, 40);
            this.lblNov.Name = "lblNov";
            this.lblNov.Size = new System.Drawing.Size(32, 20);
            this.lblNov.TabIndex = 70;
            this.lblNov.Text = "พ.ย";
            this.lblNov.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOct
            // 
            this.lblOct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOct.Location = new System.Drawing.Point(560, 40);
            this.lblOct.Name = "lblOct";
            this.lblOct.Size = new System.Drawing.Size(32, 20);
            this.lblOct.TabIndex = 69;
            this.lblOct.Text = "ต.ค";
            this.lblOct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSep
            // 
            this.lblSep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSep.Location = new System.Drawing.Point(528, 40);
            this.lblSep.Name = "lblSep";
            this.lblSep.Size = new System.Drawing.Size(32, 20);
            this.lblSep.TabIndex = 68;
            this.lblSep.Text = "ก.ย";
            this.lblSep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAug
            // 
            this.lblAug.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAug.Location = new System.Drawing.Point(496, 40);
            this.lblAug.Name = "lblAug";
            this.lblAug.Size = new System.Drawing.Size(32, 20);
            this.lblAug.TabIndex = 67;
            this.lblAug.Text = "ส.ค";
            this.lblAug.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblJul
            // 
            this.lblJul.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblJul.Location = new System.Drawing.Point(464, 40);
            this.lblJul.Name = "lblJul";
            this.lblJul.Size = new System.Drawing.Size(32, 20);
            this.lblJul.TabIndex = 66;
            this.lblJul.Text = "ก.ค";
            this.lblJul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblJun
            // 
            this.lblJun.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblJun.Location = new System.Drawing.Point(432, 40);
            this.lblJun.Name = "lblJun";
            this.lblJun.Size = new System.Drawing.Size(32, 20);
            this.lblJun.TabIndex = 65;
            this.lblJun.Text = "มิ.ย";
            this.lblJun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMay
            // 
            this.lblMay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMay.Location = new System.Drawing.Point(400, 40);
            this.lblMay.Name = "lblMay";
            this.lblMay.Size = new System.Drawing.Size(32, 20);
            this.lblMay.TabIndex = 64;
            this.lblMay.Text = "พ.ค";
            this.lblMay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblApr
            // 
            this.lblApr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblApr.Location = new System.Drawing.Point(368, 40);
            this.lblApr.Name = "lblApr";
            this.lblApr.Size = new System.Drawing.Size(32, 20);
            this.lblApr.TabIndex = 63;
            this.lblApr.Text = "เม.ย";
            this.lblApr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMar
            // 
            this.lblMar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMar.Location = new System.Drawing.Point(720, 40);
            this.lblMar.Name = "lblMar";
            this.lblMar.Size = new System.Drawing.Size(32, 20);
            this.lblMar.TabIndex = 62;
            this.lblMar.Text = "มี.ค";
            this.lblMar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFeb
            // 
            this.lblFeb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFeb.Location = new System.Drawing.Point(688, 40);
            this.lblFeb.Name = "lblFeb";
            this.lblFeb.Size = new System.Drawing.Size(32, 20);
            this.lblFeb.TabIndex = 61;
            this.lblFeb.Text = "ก.พ";
            this.lblFeb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblJan
            // 
            this.lblJan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblJan.Location = new System.Drawing.Point(656, 40);
            this.lblJan.Name = "lblJan";
            this.lblJan.Size = new System.Drawing.Size(32, 20);
            this.lblJan.TabIndex = 45;
            this.lblJan.Text = "ม.ค";
            this.lblJan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uctAnnualLeaveHeadCurrent
            // 
            this.uctAnnualLeaveHeadCurrent.Location = new System.Drawing.Point(8, 32);
            this.uctAnnualLeaveHeadCurrent.Name = "uctAnnualLeaveHeadCurrent";
            this.uctAnnualLeaveHeadCurrent.Size = new System.Drawing.Size(328, 32);
            this.uctAnnualLeaveHeadCurrent.TabIndex = 106;
            // 
            // uctAnnualLeaveHeadPrevious
            // 
            this.uctAnnualLeaveHeadPrevious.Location = new System.Drawing.Point(8, 56);
            this.uctAnnualLeaveHeadPrevious.Name = "uctAnnualLeaveHeadPrevious";
            this.uctAnnualLeaveHeadPrevious.Size = new System.Drawing.Size(328, 32);
            this.uctAnnualLeaveHeadPrevious.TabIndex = 107;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(128, 432);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(8, 16);
            this.label22.TabIndex = 75;
            this.label22.Text = "-";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdDelete.Location = new System.Drawing.Point(531, 432);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.TabIndex = 58;
            this.cmdDelete.Text = "ลบ";
            this.cmdDelete.Visible = false;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdAmend
            // 
            this.cmdAmend.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdAmend.Location = new System.Drawing.Point(451, 432);
            this.cmdAmend.Name = "cmdAmend";
            this.cmdAmend.TabIndex = 57;
            this.cmdAmend.Text = "แก้ไข";
            this.cmdAmend.Visible = false;
            this.cmdAmend.Click += new System.EventHandler(this.cmdAmend_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdAdd.Location = new System.Drawing.Point(371, 432);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.TabIndex = 56;
            this.cmdAdd.Text = "เพิ่ม";
            this.cmdAdd.Visible = false;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // fpsAnnualLeave
            // 
            this.fpsAnnualLeave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.fpsAnnualLeave.ContextMenu = this.contextMenu1;
            this.fpsAnnualLeave.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpsAnnualLeave.Location = new System.Drawing.Point(116, 280);
            this.fpsAnnualLeave.Name = "fpsAnnualLeave";
            this.fpsAnnualLeave.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																						this.fpsAnnualLeave_Sheet1});
            this.fpsAnnualLeave.Size = new System.Drawing.Size(780, 136);
            this.fpsAnnualLeave.TabIndex = 59;
            this.fpsAnnualLeave.TabStop = false;
            this.fpsAnnualLeave.Visible = false;
            this.fpsAnnualLeave.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsAnnualLeave_CellDoubleClick);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.mniAdd,
																						 this.mniEdit,
																						 this.mniDelete});
            // 
            // mniAdd
            // 
            this.mniAdd.Index = 0;
            this.mniAdd.Text = "เพิ่ม";
            this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
            // 
            // mniEdit
            // 
            this.mniEdit.Index = 1;
            this.mniEdit.Text = "แก้ไข";
            this.mniEdit.Click += new System.EventHandler(this.mniEdit_Click);
            // 
            // mniDelete
            // 
            this.mniDelete.Index = 2;
            this.mniDelete.Text = "ลบ";
            this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
            // 
            // fpsAnnualLeave_Sheet1
            // 
            this.fpsAnnualLeave_Sheet1.Reset();
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpsAnnualLeave_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpsAnnualLeave_Sheet1.ColumnCount = 7;
            this.fpsAnnualLeave_Sheet1.ColumnHeader.RowCount = 2;
            this.fpsAnnualLeave_Sheet1.RowCount = 1;
            this.fpsAnnualLeave_Sheet1.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType1.DropDownButton = false;
            this.fpsAnnualLeave_Sheet1.Cells.Get(0, 6).CellType = textCellType1;
            this.fpsAnnualLeave_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
            this.fpsAnnualLeave_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "วันที่";
            this.fpsAnnualLeave_Sheet1.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 3;
            this.fpsAnnualLeave_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ช่วงเวลา";
            this.fpsAnnualLeave_Sheet1.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
            this.fpsAnnualLeave_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "ปีที่ใช้";
            this.fpsAnnualLeave_Sheet1.ColumnHeader.Cells.Get(0, 6).RowSpan = 2;
            this.fpsAnnualLeave_Sheet1.ColumnHeader.Cells.Get(0, 6).Text = "สาเหตุ";
            this.fpsAnnualLeave_Sheet1.ColumnHeader.Cells.Get(1, 2).Text = "ครึ่งวันแรก";
            this.fpsAnnualLeave_Sheet1.ColumnHeader.Cells.Get(1, 3).Text = "ครึ่งวันหลัง";
            this.fpsAnnualLeave_Sheet1.ColumnHeader.Cells.Get(1, 4).Text = "ทั้งวัน";
            this.fpsAnnualLeave_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
            this.fpsAnnualLeave_Sheet1.Columns.Default.Resizable = false;
            textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType2.DropDownButton = false;
            this.fpsAnnualLeave_Sheet1.Columns.Get(0).CellType = textCellType2;
            this.fpsAnnualLeave_Sheet1.Columns.Get(0).Visible = false;
            textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType3.DropDownButton = false;
            this.fpsAnnualLeave_Sheet1.Columns.Get(1).CellType = textCellType3;
            this.fpsAnnualLeave_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsAnnualLeave_Sheet1.Columns.Get(2).CellType = checkBoxCellType1;
            this.fpsAnnualLeave_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsAnnualLeave_Sheet1.Columns.Get(2).Label = "ครึ่งวันแรก";
            this.fpsAnnualLeave_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpsAnnualLeave_Sheet1.Columns.Get(3).CellType = checkBoxCellType2;
            this.fpsAnnualLeave_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsAnnualLeave_Sheet1.Columns.Get(3).Label = "ครึ่งวันหลัง";
            this.fpsAnnualLeave_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpsAnnualLeave_Sheet1.Columns.Get(4).CellType = checkBoxCellType3;
            this.fpsAnnualLeave_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsAnnualLeave_Sheet1.Columns.Get(4).Label = "ทั้งวัน";
            this.fpsAnnualLeave_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType4.DropDownButton = false;
            this.fpsAnnualLeave_Sheet1.Columns.Get(5).CellType = textCellType4;
            this.fpsAnnualLeave_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType5.DropDownButton = false;
            this.fpsAnnualLeave_Sheet1.Columns.Get(6).CellType = textCellType5;
            this.fpsAnnualLeave_Sheet1.Columns.Get(6).Width = 420F;
            this.fpsAnnualLeave_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.fpsAnnualLeave_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpsAnnualLeave_Sheet1.RowHeader.Rows.Default.Resizable = false;
            this.fpsAnnualLeave_Sheet1.Rows.Default.Resizable = false;
            this.fpsAnnualLeave_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpsAnnualLeave_Sheet1.SheetName = "Sheet1";
            this.fpsAnnualLeave_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(368, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 16);
            this.label1.TabIndex = 108;
            this.label1.Text = "|------------------------------  ปี";
            // 
            // lblYearCurrent
            // 
            this.lblYearCurrent.AutoSize = true;
            this.lblYearCurrent.Location = new System.Drawing.Point(505, 16);
            this.lblYearCurrent.Name = "lblYearCurrent";
            this.lblYearCurrent.Size = new System.Drawing.Size(35, 16);
            this.lblYearCurrent.TabIndex = 109;
            this.lblYearCurrent.Text = "XXXX";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(540, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 16);
            this.label3.TabIndex = 110;
            this.label3.Text = "------------------------------|";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(656, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 16);
            this.label4.TabIndex = 111;
            this.label4.Text = "|----- ปี";
            // 
            // lblNextCurrent
            // 
            this.lblYearNext.AutoSize = true;
            this.lblYearNext.Location = new System.Drawing.Point(693, 16);
            this.lblYearNext.Name = "lblNextCurrent";
            this.lblYearNext.Size = new System.Drawing.Size(35, 16);
            this.lblYearNext.TabIndex = 112;
            this.lblYearNext.Text = "XXXX";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(728, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 16);
            this.label6.TabIndex = 113;
            this.label6.Text = "-----|";
            // 
            // frmEmployeeAnnualLeave
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(976, 462);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdAmend);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.gpbAnnualLeav);
            this.Controls.Add(this.lblForMonth);
            this.Controls.Add(this.dtpForMonth);
            this.Controls.Add(this.fpsAnnualLeave);
            this.Controls.Add(this.label22);
            this.Name = "frmEmployeeAnnualLeave";
            this.Text = "ข้อมูลการลาพักร้อนประจำปี";
            this.Load += new System.EventHandler(this.frmEmployeeAnnualLeave_Load);
            this.Controls.SetChildIndex(this.label22, 0);
            this.Controls.SetChildIndex(this.fpsAnnualLeave, 0);
            this.Controls.SetChildIndex(this.dtpForMonth, 0);
            this.Controls.SetChildIndex(this.lblForMonth, 0);
            this.Controls.SetChildIndex(this.gpbAnnualLeav, 0);
            this.Controls.SetChildIndex(this.cmdAdd, 0);
            this.Controls.SetChildIndex(this.cmdAmend, 0);
            this.Controls.SetChildIndex(this.cmdDelete, 0);
            this.gpbAnnualLeav.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpsAnnualLeave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsAnnualLeave_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

		#region - Property -
			private EmployeeAnnualLeaveFacade facadeEmployeeAnnualLeave;
			public EmployeeAnnualLeaveFacade FacadeEmployeeAnnualLeave
			{
				get
				{
					return facadeEmployeeAnnualLeave;
				}
			}

			private frmEmployeeAnnualLeaveEntry frmEntry;

			private int SelectedRow
			{
				get
				{
					return fpsAnnualLeave_Sheet1.ActiveRowIndex;
				}
			}

			private string SelectedKey
			{
				get
				{
					return fpsAnnualLeave_Sheet1.Cells[SelectedRow,0].Text;
				}
			}

			private AnnualLeaveDay SelectedValue
			{
				get
				{
					return facadeEmployeeAnnualLeave.AnnualLeave.CurrentAnnualLeave[SelectedKey];
				}
			}

			private bool isReadonly = true;
		#endregion

		//==============================  Constructor  ==============================
		public frmEmployeeAnnualLeave() : base()
		{
			InitializeComponent();
			facadeEmployeeAnnualLeave = new EmployeeAnnualLeaveFacade();
			facadeEmployeeAttendance = facadeEmployeeAnnualLeave;
			frmEntry = new frmEmployeeAnnualLeaveEntry(this);
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miGenAnnualLeaveDay");
            this.title = UserProfile.GetFormName("miAttendance", "miGenAnnualLeaveDay");
		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miGenAnnualLeaveDay");
        }

		#region - Override -
			protected override void visibleForm(bool value)
			{
				base.visibleForm(value);
				lblForMonth.Visible = value;
				dtpForMonth.Visible = value;
				gpbAnnualLeav.Visible = value;
				fpsAnnualLeave.Visible = value;
			}

			protected override void visibleButton(bool value)
			{
				cmdAdd.Visible = value;
				cmdAmend.Visible = value;
				cmdDelete.Visible = value;
			}

			public override void InitForm()
			{
				base.InitForm();
				dtpForMonth.Value = DateTime.Today;				
			}

			public override void RefreshForm()
			{
				try
				{
					if(facadeEmployeeAnnualLeave.Employee!=null && facadeEmployeeAnnualLeave.Employee.EmployeeNo!="")
					{
						base.RefreshForm();
						bool result = facadeEmployeeAnnualLeave.FillEmployeeYearAnnualLeave(dtpForMonth.Value);
						bindForm(facadeEmployeeAnnualLeave.AnnualLeave);
						if(!result)
						{
							enabledAddButton(false);
							enabledEditButton(false);
						}									
					}

                    if (dtpForMonth.Value.Month >= 4)
                    {
                        lblYearCurrent.Text = dtpForMonth.Value.Year.ToString();
                        lblYearNext.Text = dtpForMonth.Value.AddYears(1).Year.ToString();
                    }
                    else
                    {
                        lblYearCurrent.Text = dtpForMonth.Value.AddYears(-1).Year.ToString();
                        lblYearNext.Text = dtpForMonth.Value.Year.ToString();
                    }

					if(isReadonly)
					{
						cmdAdd.Enabled = false;
						cmdDelete.Enabled = false;
						mniAdd.Enabled = false;
						mniDelete.Enabled = false;
					}
				}
				catch(SqlException sqlex)
				{
					Message(sqlex);
				}
				catch(AppExceptionBase ex)
				{
					Message(ex);
				}
				catch(Exception ex)
				{
					Message(ex);
				}
				finally
				{}
			}
		#endregion

		#region - Private Method -
			private void bindAnnualLeaveHead(AnnualLeaveYear value, UCTAnnualLeaveHead control)
			{
				if(value==null || value.LeaveHead==null)
				{
					control.Clear();
				}
				else
				{
					control.ForYear = value.LeaveHead.ForYear;
					control.TotalDays = value.LeaveHead.TotalDays;
					control.UseDays = value.LeaveHead.UseDays;
					control.SellDays = value.LeaveHead.SellDays;
					control.RemainDays = value.LeaveHead.RemainDays;				
				}
			}

			private void bindSummarizeAnnualLeaveYear(AnnualLeaveYear value)
			{
                fpdJan.Value = 0;
                fpdFeb.Value = 0;
                fpdMar.Value = 0;
                fpdApr.Value = 0;
                fpdMay.Value = 0;
                fpdJun.Value = 0;
                fpdJul.Value = 0;
                fpdAug.Value = 0;
                fpdSep.Value = 0;
                fpdOct.Value = 0;
                fpdNov.Value = 0;
                fpdDec.Value = 0;

				if(value == null)
				{
					clearSummarizeAnnualLeaveYear();
				}
				else
				{
                    foreach (AnnualLeaveDay entity in value)
                    {
                        if (dtpForMonth.Value >= new DateTime(2007, 4, 1) && entity.LeaveDate.Year == 2007 && entity.LeaveDate.Month <= 3)
                        {
                            continue;
                        }

                        switch (entity.LeaveDate.Month)
                        {
                            case 1:
                                fpdJan.Value = Convert.ToDecimal(fpdJan.Value) + entity.DaysUsed;
                                break;
                            case 2:
                                fpdFeb.Value = Convert.ToDecimal(fpdFeb.Value) + entity.DaysUsed;
                                break;
                            case 3:
                                fpdMar.Value = Convert.ToDecimal(fpdMar.Value) + entity.DaysUsed;
                                break;
                            case 4:
                                fpdApr.Value = Convert.ToDecimal(fpdApr.Value) + entity.DaysUsed;
                                break;
                            case 5:
                                fpdMay.Value = Convert.ToDecimal(fpdMay.Value) + entity.DaysUsed;
                                break;
                            case 6:
                                fpdJun.Value = Convert.ToDecimal(fpdJun.Value) + entity.DaysUsed;
                                break;
                            case 7:
                                fpdJul.Value = Convert.ToDecimal(fpdJul.Value) + entity.DaysUsed;
                                break;
                            case 8:
                                fpdAug.Value = Convert.ToDecimal(fpdAug.Value) + entity.DaysUsed;
                                break;
                            case 9:
                                fpdSep.Value = Convert.ToDecimal(fpdSep.Value) + entity.DaysUsed;
                                break;
                            case 10:
                                fpdOct.Value = Convert.ToDecimal(fpdOct.Value) + entity.DaysUsed;
                                break;
                            case 11:
                                fpdNov.Value = Convert.ToDecimal(fpdNov.Value) + entity.DaysUsed;
                                break;
                            case 12:
                                fpdDec.Value = Convert.ToDecimal(fpdDec.Value) + entity.DaysUsed;
                                break;
                        }
                    }
                        //fpdJan.Value = value.CountByMonth(1);
                        //fpdFeb.Value = value.CountByMonth(2);
                        //fpdMar.Value = value.CountByMonth(3);
                        //fpdApr.Value = value.CountByMonth(4);
                        //fpdMay.Value = value.CountByMonth(5);
                        //fpdJun.Value = value.CountByMonth(6);
                        //fpdJul.Value = value.CountByMonth(7);
                        //fpdAug.Value = value.CountByMonth(8);
                        //fpdSep.Value = value.CountByMonth(9);
                        //fpdOct.Value = value.CountByMonth(10);
                        //fpdNov.Value = value.CountByMonth(11);
                        //fpdDec.Value = value.CountByMonth(12);
				}
			}

			private void clearSummarizeAnnualLeaveYear()
			{
				fpdJan.Value = 0;
				fpdFeb.Value = 0;
				fpdMar.Value = 0;
				fpdApr.Value = 0;
				fpdMay.Value = 0;
				fpdJun.Value = 0;
				fpdJul.Value = 0;
				fpdAug.Value = 0;
				fpdSep.Value = 0;
				fpdOct.Value = 0;
				fpdNov.Value = 0;
				fpdDec.Value = 0;
			}

			private void bindAnnualLeaveDay(AnnualLeaveDay value)
			{
				int row = fpsAnnualLeave_Sheet1.RowCount++;				
				fpsAnnualLeave_Sheet1.Cells[row, 0].Text = value.EntityKey;
				fpsAnnualLeave_Sheet1.Cells[row, 1].Text = value.LeaveDate.Day.ToString();
				switch(value.PeriodStatus)
				{
					case LEAVE_PERIOD_TYPE.AM :
					{
						fpsAnnualLeave_Sheet1.Cells[row, 2].Value = true;
						fpsAnnualLeave_Sheet1.Cells[row, 3].Value = false;
						fpsAnnualLeave_Sheet1.Cells[row, 4].Value = false;
						break;
					}
					case LEAVE_PERIOD_TYPE.PM :
					{
						fpsAnnualLeave_Sheet1.Cells[row, 2].Value = false;
						fpsAnnualLeave_Sheet1.Cells[row, 3].Value = true;
						fpsAnnualLeave_Sheet1.Cells[row, 4].Value = false;
						break;
					}
					case LEAVE_PERIOD_TYPE.ONE_DAY :
					{
						fpsAnnualLeave_Sheet1.Cells[row, 2].Value = false;
						fpsAnnualLeave_Sheet1.Cells[row, 3].Value = false;
						fpsAnnualLeave_Sheet1.Cells[row, 4].Value = true;
						break;
					}
				}
				switch(value.LeaveYearStatus)
				{
					case LEAVE_YEAR_STATUS_TYPE.CURRENT :
					{
						fpsAnnualLeave_Sheet1.Cells[row, 5].Text = value.ForYear.ToString();
						break;
					}
					case LEAVE_YEAR_STATUS_TYPE.PREVIOUS :
					{
						fpsAnnualLeave_Sheet1.Cells[row, 5].Text = (value.ForYear-1).ToString();
						break;
					}
					case LEAVE_YEAR_STATUS_TYPE.MIX :
					{
						fpsAnnualLeave_Sheet1.Cells[row, 5].Text = EmployeeAnnualLeaveFacade.Mix;
						break;
					}
				}
				
				fpsAnnualLeave_Sheet1.Cells[row, 6].Text = value.Reason.Name;
			}

			private void bindAnnualLeaveMonth(AnnualLeaveYear value)
			{
				fpsAnnualLeave_Sheet1.RowCount = 0;
				for(int i=0; i<value.Count; i++)
				{
					if(value[i].LeaveDate.Month == dtpForMonth.Value.Month && value[i].LeaveDate.Year == dtpForMonth.Value.Year)
					{
						bindAnnualLeaveDay(value[i]);
					}
				}
				if(fpsAnnualLeave_Sheet1.RowCount>0)
				{
					enabledEditButton(true);
				}
				else
				{
					enabledEditButton(false);
				}
			}

			private bool availableYear(AnnualLeaveYear value)
			{
				return value!=null && value.LeaveHead.RemainDays>0;
			}

			private void bindForm(AnnualLeave value)
			{
				if(value.CurrentAnnualLeave==null)
				{
					uctAnnualLeaveHeadCurrent.Clear();
					uctAnnualLeaveHeadPrevious.Clear();
					clearSummarizeAnnualLeaveYear();
					fpsAnnualLeave_Sheet1.RowCount = 0;
					enabledAddButton(false);
					enabledEditButton(false);
				}
				else
				{
					bindAnnualLeaveHead(value.CurrentAnnualLeave, uctAnnualLeaveHeadCurrent);
					bindAnnualLeaveHead(value.PreviousAnnualLeave, uctAnnualLeaveHeadPrevious);
					bindSummarizeAnnualLeaveYear(value.CurrentAnnualLeave);
					bindAnnualLeaveMonth(value.CurrentAnnualLeave);
					if(availableYear(value.CurrentAnnualLeave) || availableYear(value.PreviousAnnualLeave))
					{
						enabledAddButton(true);
					}
					else
					{
						enabledAddButton(false);
					}
				}
			}

			private void enabledAddButton(bool enabled)
			{
				mniAdd.Enabled = enabled;
				cmdAdd.Enabled = enabled;
			}

			private void enabledEditButton(bool enabled)
			{
				mniEdit.Enabled = enabled;
				mniDelete.Enabled = enabled;

				cmdAmend.Enabled = enabled;
				cmdDelete.Enabled = enabled;
			}
		#endregion

		//==============================  Base Event   ==============================
		private void AddEvent()
		{
			try
			{
				frmEntry.InitAddAction(dtpForMonth.Value);
				frmEntry.ShowDialog();
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
			}
			catch(Exception ex)
			{
				Message(ex);
			}
			finally
			{}
		}

		private void EditEvent()
		{
			try
			{
				frmEntry.InitEditAction(SelectedValue);
				frmEntry.ShowDialog();				
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
			}
			catch(Exception ex)
			{
				Message(ex);
			}
		}

		private void DeleteEvent()
		{
			try
			{
				if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
				{
					deleteAnnualLeaveDay(SelectedValue);
				}
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
			}
			catch(Exception ex)
			{
				Message(ex);
			}
		}



		//============================== Public Method ==============================
		public bool AddAnnualLeaveDayList(AnnualLeaveDayList value)
		{
			if(facadeEmployeeAnnualLeave.InsertAnnualLeave(value, dtpForMonth.Value))
			{
				bindForm(facadeEmployeeAnnualLeave.AnnualLeave);
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool UpdateAnnualLeaveDay(AnnualLeaveDay value)
		{
			if(facadeEmployeeAnnualLeave.UpdateAnnualLeave(value, dtpForMonth.Value))
			{
				bindForm(facadeEmployeeAnnualLeave.AnnualLeave);
				return true;
			}
			else
			{
				return false;
			}
		}

		private bool deleteAnnualLeaveDay(AnnualLeaveDay value)
		{
			if(facadeEmployeeAnnualLeave.DeleteAnnualLeave(value, dtpForMonth.Value))
			{
				bindForm(facadeEmployeeAnnualLeave.AnnualLeave);
				return true;
			}
			else
			{
				return false;
			}
		}

		//==============================     event     ==============================
		private void frmEmployeeAnnualLeave_Load(object sender, System.EventArgs e)
		{
			InitForm();
		}

		private void dtpForMonth_ValueChanged(object sender, System.EventArgs e)
		{
			RefreshForm();
		}

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			AddEvent();
		}

		private void mniAdd_Click(object sender, System.EventArgs e)
		{
			AddEvent();
		}

		private void mniEdit_Click(object sender, System.EventArgs e)
		{
			EditEvent();
		}

		private void cmdAmend_Click(object sender, System.EventArgs e)
		{
			EditEvent();
		}

		private void fpsAnnualLeave_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				EditEvent();
			}
		}

		private void cmdDelete_Click(object sender, System.EventArgs e)
		{
			DeleteEvent();
		}

		private void mniDelete_Click(object sender, System.EventArgs e)
		{
			DeleteEvent();
		}
	}
}







































//private void bindAnnualLeave(AnnualLeave value, int row)
//{
////			fpsAnnualLeave_Sheet1.Cells[row, 0].Text = value.LeaveDate.Day.ToString();
////			fpsAnnualLeave_Sheet1.Cells[row, 1].Value = (LEAVE_PERIOD_TYPE.AM == value.PeriodStatus);
////			fpsAnnualLeave_Sheet1.Cells[row, 2].Value = (LEAVE_PERIOD_TYPE.PM == value.PeriodStatus);
////			fpsAnnualLeave_Sheet1.Cells[row, 3].Value = (LEAVE_PERIOD_TYPE.ONE_DAY == value.PeriodStatus);
////			fpsAnnualLeave_Sheet1.Cells[row, 4].Value = value.ALeaveReason.Name;
//}
//
//private void bindEmployeeMonthAnnualLeave(AnnualLeaveYear value)
//{
//fpsAnnualLeave_Sheet1.RowCount = value.Count;
//for(int i=0; i<value.Count; i++)
//{
////				bindAnnualLeave(value[i], i);
//}
//if(value.Count>0)
//{
//enableButton(true);
//}
//else
//{
//enableButton(false);
//}
//}
//

//
//private void enableButton(bool enable)
//{
//cmdAmend.Enabled = enable;
//cmdDelete.Enabled = enable;
//}
//#endregion
//
//		//==============================  Base Event   ==============================

//
////		private void EditEvent()
////		{
////			try
////			{
////				frmEntry.InitEditAction(SelectedCompulsoryInsurance);
////				frmEntry.Vehicle = oVehicle;
////				frmEntry.ShowDialog();				
////			}
////			catch(SqlException sqlex)
////			{
////				Message(sqlex);
////			}
////			catch(AppExceptionBase ex)
////			{
////				Message(ex);
////			}
////			catch(Exception ex)
////			{
////				Message(ex);
////			}
////		}
////
////		private void DeleteEvent()
////		{
////			try
////			{
////				if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
////				{
////					DeleteRow();
////				}
////			}
////			catch(SqlException sqlex)
////			{
////				Message(sqlex);
////			}
////			catch(AppExceptionBase ex)
////			{
////				Message(ex);
////			}
////			catch(Exception ex)
////			{
////				Message(ex);
////			}
////		}
