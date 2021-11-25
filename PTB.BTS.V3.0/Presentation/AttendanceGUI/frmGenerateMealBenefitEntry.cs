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
using System.Collections.Generic;
using ictus.Common.Entity;
using ictus.Common.Entity.Time;

namespace Presentation.AttendanceGUI
{
    public class frmGenerateMealBenefitEntry : EntryFormBase
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
		private FarPoint.Win.Spread.FpSpread fpsMealAllowanceEntry;
		private FarPoint.Win.Spread.SheetView fpsMealAllowanceEntry_Sheet1;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;


		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
			this.fpsMealAllowanceEntry = new FarPoint.Win.Spread.FpSpread();

			this.fpsMealAllowanceEntry_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();

			((System.ComponentModel.ISupportInitialize)(this.fpsMealAllowanceEntry)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsMealAllowanceEntry_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// fpsTelephone
			// 
			this.fpsMealAllowanceEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsMealAllowanceEntry.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsMealAllowanceEntry.Location = new System.Drawing.Point(23, 24);
            this.fpsMealAllowanceEntry.Name = "frmGenerateMealBenefitEntry";
			this.fpsMealAllowanceEntry.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {this.fpsMealAllowanceEntry_Sheet1});
			this.fpsMealAllowanceEntry.Size = new System.Drawing.Size(600, 300);
			this.fpsMealAllowanceEntry.TabIndex = 0;
            this.fpsMealAllowanceEntry.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsMealAllowanceEntry_CellDoubleClick);

			// 
			// fpsTelephone_Sheet1
			// 
			this.fpsMealAllowanceEntry_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsMealAllowanceEntry_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsMealAllowanceEntry_Sheet1.ColumnCount = 5;
			this.fpsMealAllowanceEntry_Sheet1.RowCount = 1;
			this.fpsMealAllowanceEntry_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "รหัส";
			this.fpsMealAllowanceEntry_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ชื่อ - สกุล";
			this.fpsMealAllowanceEntry_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ส่วนงาน";

			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsMealAllowanceEntry_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsMealAllowanceEntry_Sheet1.Columns.Get(0).Visible = false;
			this.fpsMealAllowanceEntry_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			textCellType2.ReadOnly = true;
			textCellType2.Static = true;
			
            this.fpsMealAllowanceEntry_Sheet1.Columns.Get(1).CellType = textCellType2;
            this.fpsMealAllowanceEntry_Sheet1.Columns.Get(1).Label = "รหัส";
			this.fpsMealAllowanceEntry_Sheet1.Columns.Get(1).Locked = true;
			this.fpsMealAllowanceEntry_Sheet1.Columns.Get(1).Resizable = false;
			this.fpsMealAllowanceEntry_Sheet1.Columns.Get(1).Width = 80F;
			this.fpsMealAllowanceEntry_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			textCellType3.ReadOnly = true;
			textCellType3.Static = true;
			
            this.fpsMealAllowanceEntry_Sheet1.Columns.Get(2).CellType = textCellType3;
			this.fpsMealAllowanceEntry_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsMealAllowanceEntry_Sheet1.Columns.Get(2).Label = "ชื่อ - สกุล";
			this.fpsMealAllowanceEntry_Sheet1.Columns.Get(2).Locked = true;
			this.fpsMealAllowanceEntry_Sheet1.Columns.Get(2).Resizable = false;
			this.fpsMealAllowanceEntry_Sheet1.Columns.Get(2).Width = 280F;
			this.fpsMealAllowanceEntry_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			
            this.fpsMealAllowanceEntry_Sheet1.Columns.Get(3).CellType = textCellType4;
			this.fpsMealAllowanceEntry_Sheet1.Columns.Get(3).Label = "ตำแหน่ง";
			this.fpsMealAllowanceEntry_Sheet1.Columns.Get(3).Resizable = false;
			this.fpsMealAllowanceEntry_Sheet1.Columns.Get(3).Width = 180F;

            this.fpsMealAllowanceEntry_Sheet1.Columns.Get(4).CellType = textCellType5;
            this.fpsMealAllowanceEntry_Sheet1.Columns.Get(4).Visible = false;

			this.fpsMealAllowanceEntry_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
			this.fpsMealAllowanceEntry_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsMealAllowanceEntry_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsMealAllowanceEntry_Sheet1.Rows.Default.Resizable = false;
			this.fpsMealAllowanceEntry_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpsMealAllowanceEntry_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsMealAllowanceEntry_Sheet1.SheetName = "Sheet1";
			this.fpsMealAllowanceEntry_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// cmdDelete
			// 
			this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.cmdOK.Location = new System.Drawing.Point(265, 350);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 3;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// cmdEdit
			// 
			this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.cmdCancel.Location = new System.Drawing.Point(348, 350);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 2;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);

			// 
			// frmTelephoneCondition
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(650, 400);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.fpsMealAllowanceEntry);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmGenerateMealBenefitEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.frmTelephoneCondition_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpsMealAllowanceEntry)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsMealAllowanceEntry_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
        private frmGenerateMealBenefit parentForm;
		private frmMain mdiParent;
        private List<EmployeeMealAllowance> currentStaff;

		#endregion

//		============================== Property ==============================		
        private GenerateMealBenefitFacade facadeMealAllowance;
        public GenerateMealBenefitFacade FacadeMealAllowance
		{
            get { return this.facadeMealAllowance; }
		}

//		============================== Constructor ==============================
        public frmGenerateMealBenefitEntry()
            : base()
		{
			InitializeComponent();
            this.title = UserProfile.GetFormName("miAttendance", "miTelephoneCondition");
		}

        public frmGenerateMealBenefitEntry(frmGenerateMealBenefit parentForm)
            : base()
		{
			InitializeComponent();
			this.parentForm = parentForm;
            this.title = UserProfile.GetFormName("miAttendance", "miGenerateMealBenefit");
		}

//		==============================Private method ==============================
		private void newObject()
		{
            this.facadeMealAllowance = new GenerateMealBenefitFacade();
		}

        private void BindDataGrid(int row, EmployeeMealAllowance value)
		{
            this.fpsMealAllowanceEntry_Sheet1.Cells[row, 0].Text = value.EntityKey;
            this.fpsMealAllowanceEntry_Sheet1.Cells[row, 1].Text = GUIFunction.GetString(value.AEmployee.EmployeeNo);
            this.fpsMealAllowanceEntry_Sheet1.Cells[row, 2].Text = GUIFunction.GetString(value.AEmployee.EmployeeName);
            this.fpsMealAllowanceEntry_Sheet1.Cells[row, 3].Text = GUIFunction.GetString(value.AEmployee.APosition.AName.English);
            this.fpsMealAllowanceEntry_Sheet1.Cells[row, 4].Text = GUIFunction.GetString(value.MealAllowance);
		}

		private void BindForm()
		{
            if (this.facadeMealAllowance.additionalStaff != null)
			{
                int iRow = this.facadeMealAllowance.additionalStaff.Count;
                this.fpsMealAllowanceEntry_Sheet1.RowCount = iRow;

                this.AddDataToDataGrid(iRow);
			}

            this.fpsMealAllowanceEntry_Sheet1.SetActiveCell(0, 0);
		}

        private void AddDataToDataGrid(int iRow)
        {
            int indexGrid = 0;

            for (int index = 0; index < iRow; index++)
            {
                if (!this.currentStaff.Exists(delegate(EmployeeMealAllowance emp)
                {
                    return emp.AEmployee.EmployeeNo == this.facadeMealAllowance.additionalStaff[index].AEmployee.EmployeeNo;
                }))
                {
                    this.BindDataGrid(indexGrid++, this.facadeMealAllowance.additionalStaff[index]);
                }
            }

            this.fpsMealAllowanceEntry_Sheet1.RowCount = indexGrid;
        }

//		============================== Base Event ==============================
        public void InitAddAction(List<EmployeeMealAllowance> currentStaff, DateTime benefitDate)
        {
            this.baseADD();

            this.newObject();

            this.currentStaff = currentStaff;

            this.GenerateListOfAvailableStaff(benefitDate);
        }

        private void ClearForm()
        {
            this.fpsMealAllowanceEntry_Sheet1.RowCount = 0;
        }	

        private void GenerateListOfAvailableStaff(DateTime benefitDate)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.ClearForm();

                this.facadeMealAllowance.AdditionalStaffForGenerateMealBenefit(new Company("12"), benefitDate);
                this.BindForm();
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

        public void PrintForm() { }

		public void ExitForm()
		{
            this.clearMainMenuStatus();
            this.Dispose(true);
		}
		
		private void AddEvent(int rowIndex)
		{
            if (this.fpsMealAllowanceEntry_Sheet1.SelectionCount > 0
                && rowIndex > -1)
            {
                EmployeeMealAllowance addedRow = this.facadeMealAllowance.additionalStaff.Find(delegate(EmployeeMealAllowance emp)
                                                {
                                                    return emp.AEmployee.EmployeeNo == this.fpsMealAllowanceEntry_Sheet1.Cells[rowIndex, 1].Text;
                                                });

                if (addedRow != null)
                {
                    this.parentForm.AddNewStaff(addedRow);

                    this.Hide();
                }
            }
		}

//		============================== event ==============================	
        private void frmTelephoneCondition_Load(object sender, System.EventArgs e) { }  

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
            this.AddEvent(fpsMealAllowanceEntry_Sheet1.ActiveRow.Index);
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}

        private void fpsMealAllowanceEntry_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
                this.AddEvent(e.Row);
			}
		}
	}
}
