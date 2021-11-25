using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using Facade.CommonFacade;
using Facade.AttendanceFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppException;
using SystemFramework.AppMessage;

namespace Presentation.AttendanceGUI
{
    public class frmSaleAnnualLeave : ChildFormBase, IMDIChildForm
    {
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

        #region Windows Form Designer generated code
        private System.Windows.Forms.Button cmdCancel;
        private FarPoint.Win.Spread.FpSpread fpsSaleAnnualLeave;
        private FarPoint.Win.Spread.SheetView fpsSaleAnnualLeave_Sheet1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpForYear;
        private System.Windows.Forms.Label lblForYear;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.DateTimePicker dtpSaleDate;

        private System.ComponentModel.Container components = null;

        private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.fpsSaleAnnualLeave = new FarPoint.Win.Spread.FpSpread();
            this.fpsSaleAnnualLeave_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpForYear = new System.Windows.Forms.DateTimePicker();
            this.lblForYear = new System.Windows.Forms.Label();
            this.dtpSaleDate = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fpsSaleAnnualLeave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsSaleAnnualLeave_Sheet1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdCancel.Location = new System.Drawing.Point(420, 376);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.TabIndex = 49;
            this.cmdCancel.Text = "ยกเลิก";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // fpsSaleAnnualLeave
            // 
            this.fpsSaleAnnualLeave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.fpsSaleAnnualLeave.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpsSaleAnnualLeave.Location = new System.Drawing.Point(22, 88);
            this.fpsSaleAnnualLeave.Name = "fpsSaleAnnualLeave";
            this.fpsSaleAnnualLeave.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																							this.fpsSaleAnnualLeave_Sheet1});
            this.fpsSaleAnnualLeave.Size = new System.Drawing.Size(791, 272);
            this.fpsSaleAnnualLeave.TabIndex = 50;
            this.fpsSaleAnnualLeave.TabStop = false;
            // 
            // fpsSaleAnnualLeave_Sheet1
            // 
            this.fpsSaleAnnualLeave_Sheet1.Reset();
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpsSaleAnnualLeave_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpsSaleAnnualLeave_Sheet1.ColumnCount = 6;
            this.fpsSaleAnnualLeave_Sheet1.RowCount = 1;
            this.fpsSaleAnnualLeave_Sheet1.ColumnHeader.Cells.Get(0, 0).Text = "รหัสพนักงาน";
            this.fpsSaleAnnualLeave_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "ชื่อ - สกุล";
            this.fpsSaleAnnualLeave_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "แผนก";
            this.fpsSaleAnnualLeave_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ส่วนงาน";
            this.fpsSaleAnnualLeave_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "วันลาที่เหลือ";
            this.fpsSaleAnnualLeave_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "วันลาที่ต้องการขาย";
            this.fpsSaleAnnualLeave_Sheet1.ColumnHeader.Rows.Get(0).Height = 34F;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(0).AllowAutoSort = true;
            textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType1.DropDownButton = false;
            textCellType1.ReadOnly = true;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(0).Label = "รหัสพนักงาน";
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(0).Locked = true;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(0).Resizable = false;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(0).Width = 75F;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(1).AllowAutoSort = true;
            textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType2.DropDownButton = false;
            textCellType2.ReadOnly = true;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(1).CellType = textCellType2;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(1).Label = "ชื่อ - สกุล";
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(1).Locked = true;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(1).Resizable = false;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(1).Width = 200F;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(2).AllowAutoSort = true;
            textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType3.DropDownButton = false;
            textCellType3.ReadOnly = true;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(2).CellType = textCellType3;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(2).Label = "แผนก";
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(2).Locked = true;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(2).Resizable = false;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(2).Width = 80F;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(3).AllowAutoSort = true;
            textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType4.DropDownButton = false;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(3).CellType = textCellType4;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(3).Label = "ส่วนงาน";
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(3).Locked = true;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(3).Resizable = false;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(3).Width = 200F;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(4).AllowAutoSort = true;
            numberCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            numberCellType1.DecimalPlaces = 1;
            numberCellType1.DecimalSeparator = ".";
            numberCellType1.DropDownButton = false;
            numberCellType1.FixedPoint = false;
            numberCellType1.MaximumValue = 999;
            numberCellType1.MinimumValue = 0;
            numberCellType1.SpinDecimalIncrement = 0.5F;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(4).CellType = numberCellType1;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(4).Label = "วันลาที่เหลือ";
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(4).Locked = true;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(4).Resizable = false;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(4).Width = 90F;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(5).AllowAutoSort = true;
            numberCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            numberCellType2.DecimalPlaces = 1;
            numberCellType2.DecimalSeparator = ".";
            numberCellType2.DropDownButton = false;
            numberCellType2.FixedPoint = false;
            numberCellType2.MaximumValue = 999;
            numberCellType2.MinimumValue = 0;
            numberCellType2.SpinDecimalIncrement = 0.5F;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(5).CellType = numberCellType2;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(5).Label = "วันลาที่ต้องการขาย";
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(5).Resizable = false;
            this.fpsSaleAnnualLeave_Sheet1.Columns.Get(5).Width = 90F;
            this.fpsSaleAnnualLeave_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpsSaleAnnualLeave_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.MultiRange;
            this.fpsSaleAnnualLeave_Sheet1.SheetName = "Sheet1";
            this.fpsSaleAnnualLeave_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.dtpForYear);
            this.groupBox1.Controls.Add(this.lblForYear);
            this.groupBox1.Controls.Add(this.dtpSaleDate);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Location = new System.Drawing.Point(25, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(784, 56);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            // 
            // dtpForYear
            // 
            this.dtpForYear.CustomFormat = "yyyy";
            this.dtpForYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.dtpForYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpForYear.Location = new System.Drawing.Point(216, 24);
            this.dtpForYear.Name = "dtpForYear";
            this.dtpForYear.ShowUpDown = true;
            this.dtpForYear.Size = new System.Drawing.Size(56, 20);
            this.dtpForYear.TabIndex = 80;
            this.dtpForYear.Value = new System.DateTime(2548, 1, 1, 0, 0, 0, 0);
            this.dtpForYear.ValueChanged += new System.EventHandler(this.dtpForYear_ValueChanged);
            // 
            // lblForYear
            // 
            this.lblForYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.lblForYear.Location = new System.Drawing.Point(120, 24);
            this.lblForYear.Name = "lblForYear";
            this.lblForYear.Size = new System.Drawing.Size(96, 16);
            this.lblForYear.TabIndex = 81;
            this.lblForYear.Text = "ขายวันลาสำหรับปี";
            // 
            // dtpSaleDate
            // 
            this.dtpSaleDate.Enabled = false;
            this.dtpSaleDate.Location = new System.Drawing.Point(424, 22);
            this.dtpSaleDate.Name = "dtpSaleDate";
            this.dtpSaleDate.Size = new System.Drawing.Size(128, 20);
            this.dtpSaleDate.TabIndex = 77;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(368, 24);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(40, 16);
            this.label21.TabIndex = 76;
            this.label21.Text = "วันที่ขาย";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdOK.Location = new System.Drawing.Point(340, 376);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.TabIndex = 48;
            this.cmdOK.Text = "ตกลง";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // frmSaleAnnualLeave
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(834, 414);
            this.Controls.Add(this.fpsSaleAnnualLeave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSaleAnnualLeave";
            //this.Text = "ข้อมูลการขายวันหยุดพักร้อน";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSaleAnnualLeave_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fpsSaleAnnualLeave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsSaleAnnualLeave_Sheet1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region - Private -
        private bool isReadonly = true;
        private SaleAnnualLeaveFacade facadeSaleAnnualLeave;
        private frmMain mdiParent;
        #endregion

        //		==============================  Constructor  ==============================
        public frmSaleAnnualLeave()
            : base()
        {
            InitializeComponent();
            facadeSaleAnnualLeave = new SaleAnnualLeaveFacade();
            fpsSaleAnnualLeave.EditModeReplace = true;
            isReadonly = UserProfile.IsReadOnly("miAttendance", "miAttendanceSaleAnnualLeave");
            this.title = UserProfile.GetFormName("miAttendance", "miAttendanceSaleAnnualLeave");

        }
        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miAttendanceSaleAnnualLeave");
        }

        //		============================== private method ==============================
        public override int MasterCount()
        {
            return facadeSaleAnnualLeave.ObjAnnualLeaveHeadList.Count;
        }

        //		============================== private method ==============================
        private void setDate(DateTime value)
        {
            DateTime forDate = new DateTime(value.AddYears(1).Year, 6, 1);
            dtpSaleDate.Value = facadeSaleAnnualLeave.RetriveDate(forDate);
        }

        private void clearForm()
        {
            fpsSaleAnnualLeave_Sheet1.RowCount = 0;
            cmdOK.Enabled = false;
            cmdCancel.Enabled = true;
        }

        private void bindForm()
        {
            if (facadeSaleAnnualLeave.ObjAnnualLeaveHeadList != null)
            {
                bool isNull = false;
                int iRow = facadeSaleAnnualLeave.ObjAnnualLeaveHeadList.Count;
                fpsSaleAnnualLeave_Sheet1.RowCount = iRow;

                if (facadeSaleAnnualLeave.ObjAnnualLeaveHeadList.LeaveControl == null)
                {
                    isNull = true;
                }

                for (int i = 0; i < iRow; i++)
                {
                    bindSaleAnnualLeave(facadeSaleAnnualLeave.ObjAnnualLeaveHeadList[i], i, isNull);
                }
                mdiParent.RefreshMasterCount();
            }
        }

        private void bindSaleAnnualLeave(AnnualLeaveHead value, int i, bool isNull)
        {
            fpsSaleAnnualLeave_Sheet1.Cells.Get(i, 0).Text = GUIFunction.GetString(value.Employee.EmployeeNo);
            fpsSaleAnnualLeave_Sheet1.Cells.Get(i, 1).Text = GUIFunction.GetString(value.Employee.EmployeeName);
            fpsSaleAnnualLeave_Sheet1.Cells.Get(i, 2).Text = GUIFunction.GetString(value.Employee.ASection.ADepartment.ShortName);
            fpsSaleAnnualLeave_Sheet1.Cells.Get(i, 3).Text = GUIFunction.GetString(value.Employee.ASection.AFullName.English);

            if (isNull)
            {
                fpsSaleAnnualLeave_Sheet1.Cells.Get(i, 4).Text = GUIFunction.GetString(value.RemainDays);
                fpsSaleAnnualLeave_Sheet1.Cells.Get(i, 5).Text = GUIFunction.GetString(value.RemainDays);
            }
            else
            {
                fpsSaleAnnualLeave_Sheet1.Cells.Get(i, 4).Text = GUIFunction.GetString(value.RemainDays + value.SellDays);
                fpsSaleAnnualLeave_Sheet1.Cells.Get(i, 5).Text = GUIFunction.GetString(value.SellDays);
            }
        }

        private void processSaleAnnualLeave()
        {
            try
            {
                bool result = true;
                string key;

                for (int i = 0; i < fpsSaleAnnualLeave_Sheet1.RowCount; i++)
                {
                    if (validateSaleDay(i))
                    {
                        key = fpsSaleAnnualLeave_Sheet1.Cells[i, 0].Text;
                        facadeSaleAnnualLeave.ObjAnnualLeaveHeadList[key].SellDays = Convert.ToDecimal(fpsSaleAnnualLeave_Sheet1.Cells[i, 5].Value);
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }


                if (result)
                {
                    if (facadeSaleAnnualLeave.ProcessSaleAnnualLeave(dtpSaleDate.Value))
                    {
                        Message(MessageList.Information.I0001);
                        RefreshForm();
                    }
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

        private bool validateSaleDay(int row)
        {
            if (Convert.ToDecimal(fpsSaleAnnualLeave_Sheet1.Cells[row, 4].Value) < Convert.ToDecimal(fpsSaleAnnualLeave_Sheet1.Cells[row, 5].Value))
            {
                Message(MessageList.Error.E0011, "วันลาที่ต้องการขาย", "วันลาที่เหลือ");
                cmdCancel.Focus();
                return false;
            }
            return true;
        }

        private bool PrintProcess()
        {
            bool result = true;
            string key;
            AnnualLeaveSaleList objAnnualLeaveSaleList = new AnnualLeaveSaleList(facadeSaleAnnualLeave.ObjAnnualLeaveHeadList.Company);
            AnnualLeaveSale objAnnualLeaveSale;

            for (int i = 0; i < fpsSaleAnnualLeave_Sheet1.RowCount; i++)
            {
                objAnnualLeaveSale = new AnnualLeaveSale();
                key = fpsSaleAnnualLeave_Sheet1.Cells[i, 0].Text;

                if (validateSaleDay(i))
                {
                    objAnnualLeaveSale.AEmployee = facadeSaleAnnualLeave.ObjAnnualLeaveHeadList[key].Employee;
                    objAnnualLeaveSale.RemainDays = Convert.ToDecimal(fpsSaleAnnualLeave_Sheet1.Cells[i, 4].Value);
                    objAnnualLeaveSale.SellDays = Convert.ToDecimal(fpsSaleAnnualLeave_Sheet1.Cells[i, 5].Value);
                    objAnnualLeaveSaleList.Add(objAnnualLeaveSale);
                }
                else
                {
                    result = false;
                    break;
                }
            }

            if (result)
            {
                return facadeSaleAnnualLeave.PrintSaleAnnualLeave(objAnnualLeaveSaleList);
            }
            return false;
        }

        //		==============================  Base Event   ==============================
        public void InitForm()
        {
            MainMenuNewStatus = false;
            MainMenuDeleteStatus = false;
            MainMenuRefreshStatus = true;
            MainMenuPrintStatus = true;
            mdiParent.EnableNewCommand(false);
            mdiParent.EnableDeleteCommand(false);
            mdiParent.EnableRefreshCommand(true);
            mdiParent.EnablePrintCommand(true);

            dtpForYear.Value = new DateTime(DateTime.Today.AddYears(-1).Year, 1, 1);
        }

        public void RefreshForm()
        {
            try
            {
                if (facadeSaleAnnualLeave.FillAnnualLeaveHeadList(dtpForYear.Value.Year))
                {
                    bindForm();
                    cmdOK.Enabled = true;
                }
                else
                {
                    clearForm();
                }
                mdiParent.RefreshMasterCount();
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
            {
                if (isReadonly)
                {
                    cmdOK.Enabled = false;
                }
            }
        }

        public void PrintForm()
        {
            try
            {
                if (PrintProcess())
                {
                    frmListofAnnualLeaveSale formReport = new frmListofAnnualLeaveSale();
                    formReport.SelectedDate = dtpForYear.Value;
                    formReport.SelectedReportName = "rptAnnualLeaveSale.rpt";
                    formReport.Show();
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
            Dispose(true);
            this.Close();
        }

        //		==============================     event     ==============================
        private void frmSaleAnnualLeave_Load(object sender, System.EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
        }

        private void cmdOK_Click(object sender, System.EventArgs e)
        {
            processSaleAnnualLeave();
        }

        private void cmdCancel_Click(object sender, System.EventArgs e)
        {
            ExitForm();
        }

        private void dtpForYear_ValueChanged(object sender, System.EventArgs e)
        {
            setDate(dtpForYear.Value);
            RefreshForm();
        }
    }
}
