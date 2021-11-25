using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using SystemFramework.AppException;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using Facade.CommonFacade;
using Facade.AttendanceFacade;

using Presentation.CommonGUI;
using ictus.Common.Entity;
using ictus.Common.Entity.Time;
using System.Collections.Generic;

namespace Presentation.AttendanceGUI
{
	public class frmGenerateMealBenefit : ChildFormBase, IMDIChildForm
	{
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

		#region Windows Form Designer generated code
		private FarPoint.Win.Spread.FpSpread fpsMealAllowance;
		private FarPoint.Win.Spread.SheetView fpsMealAllowance_Sheet1;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCalculate;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mniAdd;
		private System.Windows.Forms.MenuItem mniDelete;

        private System.Windows.Forms.GroupBox groupBox1; 
        private System.Windows.Forms.DateTimePicker dtpForMonth;
        private System.Windows.Forms.Label lblForMonth;

        FarPoint.Win.Spread.StyleInfo focusStyle;

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();

            this.focusStyle = new FarPoint.Win.Spread.StyleInfo();
            this.focusStyle.BackColor = Color.LightBlue;

			this.fpsMealAllowance = new FarPoint.Win.Spread.FpSpread();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.fpsMealAllowance_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCalculate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpForMonth = new System.Windows.Forms.DateTimePicker();
            this.lblForMonth = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpsMealAllowance)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsMealAllowance_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// fpsTelephone
			// 
			this.fpsMealAllowance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsMealAllowance.ContextMenu = this.contextMenu1;
            this.fpsMealAllowance.EditModePermanent = true;
            this.fpsMealAllowance.EditModeReplace = true;
			this.fpsMealAllowance.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsMealAllowance.Location = new System.Drawing.Point(8, 64);
			this.fpsMealAllowance.Name = "fpsMealAllowance";
			this.fpsMealAllowance.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {this.fpsMealAllowance_Sheet1});
			this.fpsMealAllowance.Size = new System.Drawing.Size(670, 350);
			this.fpsMealAllowance.TabIndex = 0;
            this.fpsMealAllowance.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(fpsMealAllowance_CellClick);

			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mniAdd,
																					  this.mniDelete});
			// 
			// mniAdd
			// 
			this.mniAdd.Index = 0;
			this.mniAdd.Text = "เพิ่ม";
			this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
            //
			// mniDelete
			// 
			this.mniDelete.Index = 1;
			this.mniDelete.Text = "ลบ";
			this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);

            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.dtpForMonth);
            this.groupBox1.Controls.Add(this.lblForMonth);
            this.groupBox1.Controls.Add(this.cmdCalculate);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(670, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dtpForMonth
            // 
            this.dtpForMonth.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpForMonth.CustomFormat = "MM/yyyy";
            this.dtpForMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpForMonth.Location = new System.Drawing.Point(300, 16);
            this.dtpForMonth.Name = "dtpForMonth";
            this.dtpForMonth.Size = new System.Drawing.Size(78, 20);
            this.dtpForMonth.TabIndex = 1;
            this.dtpForMonth.ValueChanged += new System.EventHandler(this.dtpForMonth_ValueChanged);
            // 
            // lblForMonth
            // 
            this.lblForMonth.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblForMonth.Location = new System.Drawing.Point(230, 16);
            this.lblForMonth.Name = "lblForMonth";
            this.lblForMonth.Size = new System.Drawing.Size(64, 23);
            this.lblForMonth.TabIndex = 21;
            this.lblForMonth.Text = "สำหรับเดือน";
            this.lblForMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

			// 
			// fpsTelephone_Sheet1
			// 
			this.fpsMealAllowance_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsMealAllowance_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsMealAllowance_Sheet1.ColumnCount =6;
			this.fpsMealAllowance_Sheet1.RowCount = 1;
			this.fpsMealAllowance_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "รหัส";
            this.fpsMealAllowance_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ชื่อ - สกุล";
			this.fpsMealAllowance_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "Meal Allowance";
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsMealAllowance_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsMealAllowance_Sheet1.Columns.Get(0).Visible = false;
			this.fpsMealAllowance_Sheet1.Columns.Get(1).AllowAutoSort = true;

			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			textCellType2.ReadOnly = true;
			textCellType2.Static = true;
			this.fpsMealAllowance_Sheet1.Columns.Get(1).CellType = textCellType2;
            this.fpsMealAllowance_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsMealAllowance_Sheet1.Columns.Get(1).Label = "รหัส";
			this.fpsMealAllowance_Sheet1.Columns.Get(1).Locked = true;
			this.fpsMealAllowance_Sheet1.Columns.Get(1).Resizable = false;
			this.fpsMealAllowance_Sheet1.Columns.Get(1).Width = 80F;
			this.fpsMealAllowance_Sheet1.Columns.Get(1).AllowAutoSort = true;
            this.fpsMealAllowance_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.MistyRose;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			textCellType3.ReadOnly = true;
			textCellType3.Static = true;
			
            this.fpsMealAllowance_Sheet1.Columns.Get(2).CellType = textCellType3;
			this.fpsMealAllowance_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fpsMealAllowance_Sheet1.Columns.Get(2).Label = "ชื่อ - สกุล";
			this.fpsMealAllowance_Sheet1.Columns.Get(2).Locked = true;
			this.fpsMealAllowance_Sheet1.Columns.Get(2).Resizable = false;
			this.fpsMealAllowance_Sheet1.Columns.Get(2).Width = 380F;
			this.fpsMealAllowance_Sheet1.Columns.Get(2).AllowAutoSort = true;
            this.fpsMealAllowance_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.MistyRose;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
            
            this.fpsMealAllowance_Sheet1.Columns.Get(3).CellType = numberCellType1;
            this.fpsMealAllowance_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fpsMealAllowance_Sheet1.Columns.Get(3).Label = "Meal Allowance";
			this.fpsMealAllowance_Sheet1.Columns.Get(3).Resizable = false;
			this.fpsMealAllowance_Sheet1.Columns.Get(3).Width = 150F;
            this.fpsMealAllowance_Sheet1.Columns.Get(3).AllowAutoSort = true;
            numberCellType1.ReadOnly = false;
			numberCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType1.DecimalPlaces = 0;
			numberCellType1.DropDownButton = false;
			numberCellType1.MaximumValue = 9999.99;
			numberCellType1.MinimumValue = 0;
			numberCellType1.Separator = ",";
			numberCellType1.ShowSeparator = true;

            this.fpsMealAllowance_Sheet1.Columns.Get(4).CellType = numberCellType2;
            this.fpsMealAllowance_Sheet1.Columns.Get(4).Visible = false;
            this.fpsMealAllowance_Sheet1.Columns.Get(5).CellType = numberCellType3;
            this.fpsMealAllowance_Sheet1.Columns.Get(5).Visible = false;

            numberCellType2.DecimalPlaces = 0;
            numberCellType3.DecimalPlaces = 0;

			this.fpsMealAllowance_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsMealAllowance_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsMealAllowance_Sheet1.Rows.Default.Resizable = false;
			this.fpsMealAllowance_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsMealAllowance_Sheet1.SheetName = "Sheet1";
			this.fpsMealAllowance_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpsMealAllowance_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;

            // 
            // cmdCalculate
            // 
            this.cmdCalculate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdCalculate.Location = new System.Drawing.Point(400, 14);
            this.cmdCalculate.Name = "cmdCalculate";
            this.cmdCalculate.TabIndex = 2;
            this.cmdCalculate.Text = "คำนวณ";
            this.cmdCalculate.Click += new EventHandler(cmdCalculate_Click);
			
            // 
			// cmdDelete
			// 
			this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.cmdCancel.Location = new System.Drawing.Point(400, 440);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 4;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);

			// 
			// cmdAdd
			// 
			this.cmdSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.cmdSave.Location = new System.Drawing.Point(299, 440);
			this.cmdSave.Name = "cmdSave";
			this.cmdSave.TabIndex = 3;
			this.cmdSave.Text = "บันทึก";
			this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
			// 
            // frmMealAllowanceCondition
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(832, 477);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.fpsMealAllowance);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmMealAllowanceCondition";

			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMealAllowanceCondition_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpsMealAllowance)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsMealAllowance_Sheet1)).EndInit();
			this.ResumeLayout(false);
		}

		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmMain mdiParent;
        private bool isFirstCalculate = false;
        private bool isFirstInitPage = true;

        FarPoint.Win.Spread.CellType.NumberCellType numberCellType3;


		#endregion

//		============================== Property ==============================

        private frmGenerateMealBenefitEntry frmEntry;

		private GenerateMealBenefitFacade facadeMealCondition;
        public GenerateMealBenefitFacade FacadeMealCondition
		{
            get { return this.facadeMealCondition; }
		}

		private int SelectedRow
		{
            get { return this.fpsMealAllowance_Sheet1.ActiveRowIndex; }
		}

		private string SelectedKey
		{
            get { return this.fpsMealAllowance_Sheet1.Cells[SelectedRow, 0].Text; }
		}

//		============================== Constructor ==============================
        public frmGenerateMealBenefit()
            : base()
		{
			InitializeComponent();
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miGenerateMealBenefit");
            this.title = UserProfile.GetFormName("miAttendance", "miGenerateMealBenefit");

		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miGenerateMealBenefit");
        }

//		==============================Private method ==============================
		private void newObject()
		{
            this.facadeMealCondition = new GenerateMealBenefitFacade();
		}

        private void BindData(int row, EmployeeMealAllowance value)
		{
            this.fpsMealAllowance_Sheet1.Cells[row, 0].Text = value.EntityKey;
            this.fpsMealAllowance_Sheet1.Cells[row, 1].Text = GUIFunction.GetString(value.AEmployee.EmployeeNo);
            this.fpsMealAllowance_Sheet1.Cells[row, 2].Text = GUIFunction.GetString(value.AEmployee.EmployeeName);
            this.fpsMealAllowance_Sheet1.Cells[row, 3].Text = GUIFunction.GetString(value.MealAllowance);
            this.fpsMealAllowance_Sheet1.Cells[row, 4].Text = GUIFunction.GetString(value.Benefit_Month);
            this.fpsMealAllowance_Sheet1.Cells[row, 5].Text = GUIFunction.GetString(value.Benefit_Year);
		}

        private void BindForm()
        {
            if (this.facadeMealCondition.data != null
                && this.facadeMealCondition.data.Count > 0)
            {
                this.fpsMealAllowance_Sheet1.RowCount = this.facadeMealCondition.data.Count;

                int index = 0;
                foreach (EmployeeMealAllowance row in this.facadeMealCondition.data)
                {
                    this.BindData(index++, row);
                }

                this.mdiParent.RefreshMasterCount();
                this.fpsMealAllowance_Sheet1.SetActiveCell(0, 3);
            }
        }

		private void ClearForm()
		{
			this.fpsMealAllowance_Sheet1.RowCount = 0;
		}	

//		============================== Public method ==============================

        public void DeleteRow()
        {
            this.fpsMealAllowance.ActiveSheet.Rows.Remove(SelectedRow, 1);

            this.mdiParent.RefreshMasterCount();
        }

		public override int MasterCount()
		{
            return this.facadeMealCondition.data.Count;
		}

//		============================== Base Event ==============================
		public void InitForm()
		{
            if (isFirstInitPage)
            {
                this.newObject();
                this.MainMenuNewStatus = false;
                this.MainMenuDeleteStatus = false;
                this.MainMenuRefreshStatus = true;
                this.MainMenuPrintStatus = true;
                this.mdiParent.EnableNewCommand(false);
                this.mdiParent.EnableDeleteCommand(false);
                this.mdiParent.EnableRefreshCommand(true);
                this.mdiParent.EnablePrintCommand(true);

                this.ClearForm();

                this.mniAdd.Visible = false;
                this.mniDelete.Visible = false;
                this.cmdSave.Enabled = false;

                this.isFirstCalculate = true;
                this.isFirstInitPage = false;
            }
            else
            {
                this.Calculate();
            }
		}

        private void SetModeOfPanelByPaymentDate()
        {
            this.facadeMealCondition.CheckIsExistPayment(new Company("12"), new YearMonth(dtpForMonth.Value));
            this.SetControlByPanelMode();
        }

        private void SetControlByPanelMode()
        {
            if (UserProfile.IsReadOnly("miAttendance", "miGenerateMealBenefit"))
            {
                this.SetControlToReadOnlyMode();
            }
            else
            {
                this.isReadonly = this.facadeMealCondition.IsExistPayment;

                if (isReadonly)
                {
                    this.SetControlToReadOnlyMode();
                }
                else
                {
                    this.SetControlToWriteMode();
                }
            }
        }

        private void SetControlToWriteMode()
        {
            this.mniAdd.Visible = true;
            this.mniDelete.Visible = true;
            this.cmdSave.Enabled = true;

            this.numberCellType3.ReadOnly = false;
            this.fpsMealAllowance_Sheet1.Columns.Get(3).Locked = false;
            this.fpsMealAllowance_Sheet1.Columns.Get(3).BackColor = Color.White;
        }

        private void SetControlToReadOnlyMode()
        {
            this.mniAdd.Visible = false;
            this.mniDelete.Visible = false;
            this.cmdSave.Enabled = false;

            this.numberCellType3.ReadOnly = true;
            this.fpsMealAllowance_Sheet1.Columns.Get(3).Locked = true;
            this.fpsMealAllowance_Sheet1.Columns.Get(3).BackColor = Color.MistyRose;
        }

		public void RefreshForm()
		{
            this.InitForm();
		}

        public void PrintForm() { }

		public void ExitForm()
		{
            this.clearMainMenuStatus();
            this.Dispose(true);
		}
		
		private void AddEvent()
		{
			try
			{
                List<EmployeeMealAllowance> currentStaff = new List<EmployeeMealAllowance>();

                currentStaff = this.GetDataFromDataGrid();

                frmEntry = new frmGenerateMealBenefitEntry(this);
                frmEntry.InitAddAction(currentStaff, this.dtpForMonth.Value);
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
            if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
            {
                this.DeleteRow();
            }
        }

        private void Save()
        {
            if (this.fpsMealAllowance_Sheet1.RowCount == 0
                || (this.facadeMealCondition.data[0].Benefit_Month == this.dtpForMonth.Value.Month
                    && this.facadeMealCondition.data[0].Benefit_Year == this.dtpForMonth.Value.Year))
            {
                this.CallProcessSave();
            }
            else
            {
                Message(MessageList.Information.I0006);
            }
        }

        private void CallProcessSave()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int originalMonth = this.facadeMealCondition.data[0].Benefit_Month;
                int originalYear = this.facadeMealCondition.data[0].Benefit_Year;

                this.facadeMealCondition.data.Clear();
                this.facadeMealCondition.data = this.GetDataFromDataGrid();

                this.facadeMealCondition.Save(new Company("12")
                                       , new YearMonth
                                       {
                                           Month = originalMonth
                                           ,
                                           Year = originalYear
                                       });

                Message(MessageList.Information.I0001);
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
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
                this.Cursor = Cursors.Default;
            }
        }

        private List<EmployeeMealAllowance> GetDataFromDataGrid()
        {
            List<EmployeeMealAllowance> data = new List<EmployeeMealAllowance>();

            for (int rowIndex = 0; rowIndex < this.fpsMealAllowance_Sheet1.RowCount; rowIndex++)
            {
                EmployeeMealAllowance rowData = new EmployeeMealAllowance();

                rowData.AEmployee = new ictus.PIS.PI.Entity.Employee();
                rowData.AEmployee.EmployeeNo = fpsMealAllowance_Sheet1.Cells[rowIndex, 1].Text;
                rowData.MealAllowance = decimal.Parse(fpsMealAllowance_Sheet1.Cells[rowIndex, 3].Text);
                rowData.Benefit_Month = Convert.ToInt32(fpsMealAllowance_Sheet1.Cells[rowIndex, 4].Text);
                rowData.Benefit_Year = int.Parse(fpsMealAllowance_Sheet1.Cells[rowIndex, 5].Text);

                data.Add(rowData);
            }

            return data;
        }

        private void SetActiveRowStyleToFocusStyle(int rowIndex)
        {
            this.fpsMealAllowance_Sheet1.SetStyleInfo(rowIndex, 0, this.focusStyle);
            this.fpsMealAllowance_Sheet1.SetStyleInfo(rowIndex, 1, this.focusStyle);
            this.fpsMealAllowance_Sheet1.SetStyleInfo(rowIndex, 2, this.focusStyle);
            this.fpsMealAllowance_Sheet1.SetStyleInfo(rowIndex, 3, this.focusStyle);
        }

        private void ClearAllPreviousFocusStyle()
        {
            for (int rowIndex = 0; rowIndex < fpsMealAllowance_Sheet1.RowCount; rowIndex++)
            {
                this.fpsMealAllowance_Sheet1.SetStyleInfo(rowIndex, 0, new FarPoint.Win.Spread.StyleInfo());
                this.fpsMealAllowance_Sheet1.SetStyleInfo(rowIndex, 1, new FarPoint.Win.Spread.StyleInfo { BackColor = Color.MistyRose });
                this.fpsMealAllowance_Sheet1.SetStyleInfo(rowIndex, 2, new FarPoint.Win.Spread.StyleInfo { BackColor = Color.MistyRose });

                if (this.isReadonly
                    || UserProfile.IsReadOnly("miAttendance", "miGenerateMealBenefit"))
                {
                    this.fpsMealAllowance_Sheet1.SetStyleInfo(rowIndex, 3, new FarPoint.Win.Spread.StyleInfo { BackColor = Color.MistyRose });
                }
                else
                {
                    this.fpsMealAllowance_Sheet1.SetStyleInfo(rowIndex, 3, new FarPoint.Win.Spread.StyleInfo { BackColor = Color.White });
                }
            }
        }

        private void CallProcessCalculate()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.ClearForm();

                this.facadeMealCondition.Calculate(new Company("12"), dtpForMonth.Value);
                this.BindForm();

                this.SetModeOfPanelByPaymentDate();
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
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
                this.Cursor = Cursors.Default;
            }

            this.isFirstCalculate = false;
        }

//		============================== event ==============================	
		private void frmMealAllowanceCondition_Load(object sender, System.EventArgs e)
		{
            this.mdiParent = (frmMain)this.MdiParent;
            this.InitForm();
		}

		private void cmdSave_Click(object sender, System.EventArgs e)
		{
            this.Save();
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
            this.ExitForm();    
		}

		private void mniAdd_Click(object sender, System.EventArgs e)
		{
            this.AddEvent();
		}

		private void mniDelete_Click(object sender, System.EventArgs e)
		{
            this.DeleteEvent();
		}

        private void dtpForMonth_ValueChanged(object sender, System.EventArgs e)
        {
            //this.GetDataByDate();

           // this.SetModeOfPanelByPaymentDate();
        }

        private void fpsMealAllowance_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.Column >= 0 && e.Row >= 0)
            {
                this.SetFocusStyleToRow(e.Row, e.Column);
            }
        }

        private void SetFocusStyleToRow(int rowIndex, int columeIndex)
        {
            this.ClearAllPreviousFocusStyle();

            this.fpsMealAllowance_Sheet1.SetActiveCell(rowIndex, columeIndex);

            this.SetActiveRowStyleToFocusStyle(rowIndex);
        }

        private void cmdCalculate_Click(object sender, EventArgs e)
        {
            this.Calculate();
        }

        private void Calculate()
        {
            if (!this.isFirstCalculate
                && !this.isReadonly)
            {
                if (this.IsModifyData())
                {
                    DialogResult result = Message(MessageList.Question.Q0020);

                    if (result == DialogResult.Yes)
                    {
                        this.CallProcessSave();
                    }
                    else if (result == DialogResult.No)
                    {
                        this.CallProcessCalculate();
                    }
                }
                else
                {
                    this.CallProcessCalculate();
                }
            }
            else
            {
                this.CallProcessCalculate();
            }
        }

        private bool IsModifyData()
        {
            List<EmployeeMealAllowance> currentDataList = new List<EmployeeMealAllowance>();
            List<EmployeeMealAllowance> originalDataLiat = new List<EmployeeMealAllowance>();

            int originalMonth = this.facadeMealCondition.data.Count == 0 ? this.dtpForMonth.Value.Month : this.facadeMealCondition.data[0].Benefit_Month;
            int originalYear = this.facadeMealCondition.data.Count == 0 ? this.dtpForMonth.Value.Year : this.facadeMealCondition.data[0].Benefit_Year;

            currentDataList = this.GetDataFromDataGrid();
            originalDataLiat = facadeMealCondition.Get(new Company("12")
                                                  , new YearMonth
                                                  {
                                                      Month = originalMonth
                                                      ,
                                                      Year = originalYear
                                                  });

            if (currentDataList.Count != originalDataLiat.Count)
            {
                return true;
            }
            else
            {
                foreach (EmployeeMealAllowance row in currentDataList)
                {
                    EmployeeMealAllowance originalData = originalDataLiat.Find(delegate(EmployeeMealAllowance emp)
                                                         {
                                                             return emp.AEmployee.EmployeeNo == row.AEmployee.EmployeeNo;
                                                         });
                    if (originalData.MealAllowance != row.MealAllowance)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        internal void AddNewStaff(EmployeeMealAllowance addedRow)
        {
            this.fpsMealAllowance_Sheet1.RowCount++;

            this.fpsMealAllowance_Sheet1.Cells[this.fpsMealAllowance_Sheet1.RowCount - 1, 0].Text = this.fpsMealAllowance_Sheet1.RowCount.ToString();
            this.fpsMealAllowance_Sheet1.Cells[this.fpsMealAllowance_Sheet1.RowCount - 1, 1].Text = GUIFunction.GetString(addedRow.AEmployee.EmployeeNo);
            this.fpsMealAllowance_Sheet1.Cells[this.fpsMealAllowance_Sheet1.RowCount - 1, 2].Text = GUIFunction.GetString(addedRow.AEmployee.EmployeeName);
            this.fpsMealAllowance_Sheet1.Cells[this.fpsMealAllowance_Sheet1.RowCount - 1, 3].Text = GUIFunction.GetString(addedRow.MealAllowance);
            this.fpsMealAllowance_Sheet1.Cells[this.fpsMealAllowance_Sheet1.RowCount - 1, 4].Text = fpsMealAllowance_Sheet1.Cells[0, 4].Text;
            this.fpsMealAllowance_Sheet1.Cells[this.fpsMealAllowance_Sheet1.RowCount - 1, 5].Text = this.fpsMealAllowance_Sheet1.Cells[0, 5].Text;

            this.SetFocusStyleToRow(this.fpsMealAllowance_Sheet1.RowCount - 1, 3);
            this.fpsMealAllowance_Sheet1.SortRows(1, true, false);

            int focusRowIndex = this.FindFocusRowIndex();
            this.fpsMealAllowance_Sheet1.SetActiveCell(focusRowIndex, 3);
            this.fpsMealAllowance.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Center, FarPoint.Win.Spread.HorizontalPosition.Center);

            this.mdiParent.RefreshMasterCount();
        }

        private int FindFocusRowIndex()
        {
            for (int rowIndex = 0; rowIndex < fpsMealAllowance_Sheet1.RowCount; rowIndex++)
            {
                if (this.fpsMealAllowance_Sheet1.Cells[rowIndex, 1].BackColor == this.focusStyle.BackColor)
                {
                    return rowIndex;
                }             
            }

            return 0;
        }
    }
}
