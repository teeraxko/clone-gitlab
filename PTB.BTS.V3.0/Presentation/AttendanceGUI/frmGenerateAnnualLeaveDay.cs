using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using Facade.AttendanceFacade;

using Presentation.CommonGUI;

using SystemFramework.AppException;
using SystemFramework.AppConfig;

namespace Presentation.AttendanceGUI
{
    public class frmGenerateAnnualLeaveDay : Presentation.CommonGUI.ChildFormBase, IMDIChildForm
    {
        #region Windows Form Designer generated code
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.DateTimePicker dtpValidToDate;
        private System.Windows.Forms.DateTimePicker dtpValidFromDate;
        private System.Windows.Forms.DateTimePicker dtpForMonth;
        private System.Windows.Forms.Label lblForMonth;
        private FarPoint.Win.Spread.FpSpread fpsGenAnnualLeave;
        private FarPoint.Win.Spread.SheetView fpsGenAnnualLeave_Sheet1;
        private System.ComponentModel.Container components = null;

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
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmGenerateAnnualLeaveDay));
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpForMonth = new System.Windows.Forms.DateTimePicker();
            this.lblForMonth = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.dtpValidToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpValidFromDate = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.fpsGenAnnualLeave = new FarPoint.Win.Spread.FpSpread();
            this.fpsGenAnnualLeave_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpsGenAnnualLeave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsGenAnnualLeave_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.dtpForMonth);
            this.groupBox1.Controls.Add(this.lblForMonth);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.dtpValidToDate);
            this.groupBox1.Controls.Add(this.dtpValidFromDate);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Location = new System.Drawing.Point(40, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(840, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dtpForMonth
            // 
            this.dtpForMonth.CustomFormat = "yyyy";
            this.dtpForMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.dtpForMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpForMonth.Location = new System.Drawing.Point(216, 24);
            this.dtpForMonth.Name = "dtpForMonth";
            this.dtpForMonth.ShowUpDown = true;
            this.dtpForMonth.Size = new System.Drawing.Size(56, 20);
            this.dtpForMonth.TabIndex = 80;
            this.dtpForMonth.Value = new System.DateTime(2548, 1, 1, 0, 0, 0, 0);
            this.dtpForMonth.ValueChanged += new System.EventHandler(this.dtpForMonth_ValueChanged);
            // 
            // lblForMonth
            // 
            this.lblForMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.lblForMonth.Location = new System.Drawing.Point(96, 24);
            this.lblForMonth.Name = "lblForMonth";
            this.lblForMonth.Size = new System.Drawing.Size(96, 16);
            this.lblForMonth.TabIndex = 81;
            this.lblForMonth.Text = "สร้างวันลาสำหรับปี";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(568, 24);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(8, 16);
            this.label22.TabIndex = 79;
            this.label22.Text = "-";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpValidToDate
            // 
            this.dtpValidToDate.Enabled = false;
            this.dtpValidToDate.Location = new System.Drawing.Point(584, 22);
            this.dtpValidToDate.Name = "dtpValidToDate";
            this.dtpValidToDate.Size = new System.Drawing.Size(128, 20);
            this.dtpValidToDate.TabIndex = 78;
            // 
            // dtpValidFromDate
            // 
            this.dtpValidFromDate.Enabled = false;
            this.dtpValidFromDate.Location = new System.Drawing.Point(432, 22);
            this.dtpValidFromDate.Name = "dtpValidFromDate";
            this.dtpValidFromDate.Size = new System.Drawing.Size(128, 20);
            this.dtpValidFromDate.TabIndex = 77;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(336, 24);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(80, 16);
            this.label21.TabIndex = 76;
            this.label21.Text = "รอบระหว่างวันที่";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdCancel.Location = new System.Drawing.Point(463, 368);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.TabIndex = 45;
            this.cmdCancel.Text = "ยกเลิก";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdOK.Location = new System.Drawing.Point(383, 368);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.TabIndex = 44;
            this.cmdOK.Text = "ตกลง";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // fpsGenAnnualLeave
            // 
            this.fpsGenAnnualLeave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.fpsGenAnnualLeave.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpsGenAnnualLeave.Location = new System.Drawing.Point(40, 80);
            this.fpsGenAnnualLeave.Name = "fpsGenAnnualLeave";
            this.fpsGenAnnualLeave.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																						   this.fpsGenAnnualLeave_Sheet1});
            this.fpsGenAnnualLeave.Size = new System.Drawing.Size(840, 272);
            this.fpsGenAnnualLeave.TabIndex = 46;
            this.fpsGenAnnualLeave.TabStop = false;
            this.fpsGenAnnualLeave.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // fpsGenAnnualLeave_Sheet1
            // 
            this.fpsGenAnnualLeave_Sheet1.Reset();
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpsGenAnnualLeave_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpsGenAnnualLeave_Sheet1.ColumnCount = 6;
            this.fpsGenAnnualLeave_Sheet1.RowCount = 0;
            this.fpsGenAnnualLeave_Sheet1.ColumnHeader.Cells.Get(0, 0).Text = "รหัสพนักงาน";
            this.fpsGenAnnualLeave_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "ชื่อ - สกุล";
            this.fpsGenAnnualLeave_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ส่วนงาน";
            this.fpsGenAnnualLeave_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "วันที่เข้างาน";
            this.fpsGenAnnualLeave_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "วันลาปีที่แล้ว";
            this.fpsGenAnnualLeave_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "วันลาปีนี้";
            this.fpsGenAnnualLeave_Sheet1.ColumnHeader.Rows.Get(0).Height = 34F;
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(0).AllowAutoSort = true;
            textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType1.DropDownButton = false;
            textCellType1.ReadOnly = true;
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(0).Label = "รหัสพนักงาน";
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(0).Width = 70F;
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(1).AllowAutoSort = true;
            textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType2.DropDownButton = false;
            textCellType2.ReadOnly = true;
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(1).CellType = textCellType2;
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(1).Label = "ชื่อ - สกุล";
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(1).Width = 250F;
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(2).AllowAutoSort = true;
            textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType3.DropDownButton = false;
            textCellType3.ReadOnly = true;
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(2).CellType = textCellType3;
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(2).Label = "ส่วนงาน";
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(2).Width = 230F;
            dateTimeCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            dateTimeCellType1.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
            dateTimeCellType1.DateDefault = new System.DateTime(2006, 1, 17, 17, 34, 4, 0);
            dateTimeCellType1.DropDownButton = false;
            dateTimeCellType1.TimeDefault = new System.DateTime(2006, 1, 17, 17, 34, 4, 0);
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(3).CellType = dateTimeCellType1;
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(3).Label = "วันที่เข้างาน";
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(3).Resizable = false;
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(3).Width = 90F;
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(4).AllowAutoSort = true;
            numberCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            numberCellType1.DropDownButton = false;
            numberCellType1.FixedPoint = false;
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(4).CellType = numberCellType1;
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(4).Label = "วันลาปีที่แล้ว";
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(4).Width = 70F;
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(5).AllowAutoSort = true;
            numberCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            numberCellType2.DropDownButton = false;
            numberCellType2.FixedPoint = false;
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(5).CellType = numberCellType2;
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(5).Label = "วันลาปีนี้";
            this.fpsGenAnnualLeave_Sheet1.Columns.Get(5).Width = 70F;
            this.fpsGenAnnualLeave_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpsGenAnnualLeave_Sheet1.SheetName = "Sheet1";
            this.fpsGenAnnualLeave_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmGenerateAnnualLeaveDay
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(920, 414);
            this.Controls.Add(this.fpsGenAnnualLeave);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmGenerateAnnualLeaveDay";
            //this.Text = "ข้อมูลการลาพักร้อนประจำปี";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGenerateAnnualLeaveDay_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpsGenAnnualLeave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsGenAnnualLeave_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region - Private -
        private GenerateAnnualLeaveDayFacade facadeGenAnnualLeaveDay;
        private frmMain mdiParent;
        private bool isReadonly = true;
        #endregion

        //==============================  Constructor  ==============================
        public frmGenerateAnnualLeaveDay()
        {
            InitializeComponent();
            facadeGenAnnualLeaveDay = new GenerateAnnualLeaveDayFacade();
            isReadonly = UserProfile.IsReadOnly("miAttendance", "miAttEmpAnnualLeave");
            this.title = UserProfile.GetFormName("miAttendance", "miAttEmpAnnualLeave");

        }
        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miAttEmpAnnualLeave");
        }

        #region - Private Method -
        private void visibleForm(bool visible)
        {
            fpsGenAnnualLeave.Visible = visible;
            fpsGenAnnualLeave_Sheet1.Visible = visible;
            cmdOK.Visible = visible;
            cmdCancel.Visible = visible;
        }

        private void bindAnnualLeaveDualHead(AnnualLeaveDualHead value, int row)
        {
            fpsGenAnnualLeave_Sheet1.Cells[row, 0].Text = value.Employee.EmployeeNo;
            fpsGenAnnualLeave_Sheet1.Cells[row, 1].Text = value.Employee.EmployeeName;
            fpsGenAnnualLeave_Sheet1.Cells[row, 2].Text = value.Employee.ASection.AFullName.English;
            fpsGenAnnualLeave_Sheet1.Cells[row, 3].Text = value.Employee.HireDate.ToShortDateString();
            if (value.Previous != null)
            {
                fpsGenAnnualLeave_Sheet1.Cells[row, 4].Text = value.Previous.TotalDays.ToString();
            }
            fpsGenAnnualLeave_Sheet1.Cells[row, 5].Text = value.Current.TotalDays.ToString();
        }

        private void bindForm()
        {
            fpsGenAnnualLeave_Sheet1.RowCount = facadeGenAnnualLeaveDay.AnnualLeaveDualHeadList.Count;
            for (int i = 0; i < facadeGenAnnualLeaveDay.AnnualLeaveDualHeadList.Count; i++)
            {
                bindAnnualLeaveDualHead(facadeGenAnnualLeaveDay.AnnualLeaveDualHeadList[i], i);
            }
        }

        private void clearForm()
        {
            fpsGenAnnualLeave_Sheet1.RowCount = 0;
            cmdOK.Enabled = false;
        }

        private DateTime getValidDate(DateTime day, int year)
        {
            return new DateTime(year, day.Month, day.Day);
        }
        #endregion

        //==============================  Base Event   ==============================
        public void InitForm()
        {
            dtpForMonth.Value = new DateTime(DateTime.Today.Year, 4, 1);
            visibleForm(false);
        }

        public void RefreshForm()
        {
            try
            {
                bool result = facadeGenAnnualLeaveDay.FillAnnualLeaveHeadList(dtpForMonth.Value.Year);
                visibleForm(true);
                bindForm();

                if (facadeGenAnnualLeaveDay.AnnualLeaveDualHeadList.Count == 0)
                {
                    cmdOK.Enabled = false;
                }
                else
                {
                    cmdOK.Enabled = result;
                }

                if (facadeGenAnnualLeaveDay.AnnualLeaveDualHeadList != null && facadeGenAnnualLeaveDay.AnnualLeaveDualHeadList.LeaveControl != null)
                {
                    dtpValidFromDate.Value = facadeGenAnnualLeaveDay.AnnualLeaveDualHeadList.LeaveControl.ValidPeriod.From;
                    dtpValidToDate.Value = facadeGenAnnualLeaveDay.AnnualLeaveDualHeadList.LeaveControl.ValidPeriod.To;
                }

                if (isReadonly)
                {
                    cmdOK.Enabled = false;
                }
            }
            catch (SqlException ex)
            {
                Message(ex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
            finally
            { }
        }

        public void PrintForm()
        {
            try
            {
                if (facadeGenAnnualLeaveDay.PrintTrNewAnnualLeaveDays())
                {
                    frmListofNewAnnualLeaveDay objfrm = new frmListofNewAnnualLeaveDay();
                    objfrm.ForYear = dtpForMonth.Value.Year;
                    objfrm.ValidForm = dtpValidFromDate.Value.Date;
                    objfrm.ValidTo = dtpValidToDate.Value.Date;
                    objfrm.ShowDialog();
                }
            }
            catch (SqlException ex)
            {
                Message(ex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
            finally
            { }
        }

        public void ExitForm()
        {
            this.Close();
        }

        private void insertEvent()
        {
            try
            {
                facadeGenAnnualLeaveDay.ValidTimeFrom = getValidDate(dtpValidFromDate.Value, dtpForMonth.Value.Year);
                facadeGenAnnualLeaveDay.ValidTimeTo = getValidDate(dtpValidToDate.Value, dtpForMonth.Value.Year + 1);
                if (facadeGenAnnualLeaveDay.InsertAnnualLeaveDualHeadList())
                {
                    Message(SystemFramework.AppMessage.MessageList.Information.I0001);
                    clearForm();
                }
            }
            catch (SqlException ex)
            {
                Message(ex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
            finally
            { }
        }
        //============================== Public Method ==============================

        //==============================     event     ==============================
        private void frmGenerateAnnualLeaveDay_Load(object sender, System.EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            MainMenuNewStatus = true;
            MainMenuDeleteStatus = false;
            MainMenuRefreshStatus = true;
            MainMenuPrintStatus = true;
            mdiParent.EnableNewCommand(true);
            mdiParent.EnableDeleteCommand(false);
            mdiParent.EnableRefreshCommand(true);
            mdiParent.EnablePrintCommand(true);

            InitForm();
            RefreshForm();
        }

        private void dtpForMonth_ValueChanged(object sender, System.EventArgs e)
        {
            dtpValidFromDate.Value = dtpForMonth.Value;
            //New carry over from 6 month to 12 month : woranai 2008/04/22
            dtpValidToDate.Value = new DateTime(dtpForMonth.Value.Year + 2, 3, 31);
            RefreshForm();
        }

        private void cmdOK_Click(object sender, System.EventArgs e)
        {
            insertEvent();
        }

        private void cmdCancel_Click(object sender, System.EventArgs e)
        {
            ExitForm();
        }
    }
}