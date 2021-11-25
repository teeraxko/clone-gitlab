using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.ContractEntities;
using Entity.CommonEntity;
using Entity.AttendanceEntities;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using Facade.ContractFacade;
using Facade.CommonFacade;

using Presentation.CommonGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;

namespace Presentation.AttendanceGUI
{
	public class frmGenerateOtherBenefitDetail : EntryFormBase
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
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblEmpNo;
		private System.Windows.Forms.Label lblEmpName;
		private FarPoint.Win.Spread.FpSpread fpsBenefitDetail;
		private FarPoint.Win.Spread.SheetView fpsBenefitDetail_Sheet1;
		private System.Windows.Forms.Button cmdClose;

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmGenerateOtherBenefitDetail));
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType2 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType3 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType4 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblEmpName = new System.Windows.Forms.Label();
			this.lblEmpNo = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.fpsBenefitDetail = new FarPoint.Win.Spread.FpSpread();
			this.fpsBenefitDetail_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.cmdClose = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpsBenefitDetail)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsBenefitDetail_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblEmpName);
			this.groupBox1.Controls.Add(this.lblEmpNo);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(16, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(648, 64);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// lblEmpName
			// 
			this.lblEmpName.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblEmpName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblEmpName.Location = new System.Drawing.Point(140, 24);
			this.lblEmpName.Name = "lblEmpName";
			this.lblEmpName.Size = new System.Drawing.Size(216, 23);
			this.lblEmpName.TabIndex = 2;
			this.lblEmpName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblEmpNo
			// 
			this.lblEmpNo.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblEmpNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblEmpNo.Location = new System.Drawing.Point(76, 24);
			this.lblEmpNo.Name = "lblEmpNo";
			this.lblEmpNo.Size = new System.Drawing.Size(56, 23);
			this.lblEmpNo.TabIndex = 1;
			this.lblEmpNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(20, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "พนักงาน";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// fpsBenefitDetail
			// 
			this.fpsBenefitDetail.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsBenefitDetail.Location = new System.Drawing.Point(16, 80);
			this.fpsBenefitDetail.Name = "fpsBenefitDetail";
			this.fpsBenefitDetail.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																						  this.fpsBenefitDetail_Sheet1});
			this.fpsBenefitDetail.Size = new System.Drawing.Size(646, 336);
			this.fpsBenefitDetail.TabIndex = 1;
			// 
			// fpsBenefitDetail_Sheet1
			// 
			this.fpsBenefitDetail_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsBenefitDetail_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsBenefitDetail_Sheet1.ColumnCount = 6;
			this.fpsBenefitDetail_Sheet1.ColumnHeader.RowCount = 2;
			this.fpsBenefitDetail_Sheet1.RowCount = 1;
			this.fpsBenefitDetail_Sheet1.ColumnHeader.Cells.Get(0, 0).ColumnSpan = 2;
			this.fpsBenefitDetail_Sheet1.ColumnHeader.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsBenefitDetail_Sheet1.ColumnHeader.Cells.Get(0, 0).Text = "วันที่ปฏิบัติงาน";
			this.fpsBenefitDetail_Sheet1.ColumnHeader.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsBenefitDetail_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
			this.fpsBenefitDetail_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "หมายเลขสัญญา";
			this.fpsBenefitDetail_Sheet1.ColumnHeader.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsBenefitDetail_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
			this.fpsBenefitDetail_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "วันที่เริ่ม";
			this.fpsBenefitDetail_Sheet1.ColumnHeader.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsBenefitDetail_Sheet1.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
			this.fpsBenefitDetail_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "วันที่สิ้นสุด";
			this.fpsBenefitDetail_Sheet1.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
			this.fpsBenefitDetail_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "ลูกค้า (แผนก)";
			this.fpsBenefitDetail_Sheet1.ColumnHeader.Cells.Get(1, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsBenefitDetail_Sheet1.ColumnHeader.Cells.Get(1, 0).Text = "เริ่ม";
			this.fpsBenefitDetail_Sheet1.ColumnHeader.Cells.Get(1, 1).Text = "จนถึง";
			this.fpsBenefitDetail_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
			this.fpsBenefitDetail_Sheet1.Columns.Default.Resizable = false;
			this.fpsBenefitDetail_Sheet1.Columns.Get(0).AllowAutoSort = true;
			dateTimeCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType1.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType1.DateDefault = new System.DateTime(2006, 6, 12, 17, 10, 49, 0);
			dateTimeCellType1.DropDownButton = false;
			dateTimeCellType1.TimeDefault = new System.DateTime(2006, 6, 12, 17, 10, 49, 0);
			this.fpsBenefitDetail_Sheet1.Columns.Get(0).CellType = dateTimeCellType1;
			this.fpsBenefitDetail_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsBenefitDetail_Sheet1.Columns.Get(0).Label = "เริ่ม";
			this.fpsBenefitDetail_Sheet1.Columns.Get(0).Width = 90F;
			this.fpsBenefitDetail_Sheet1.Columns.Get(1).AllowAutoSort = true;
			dateTimeCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType2.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType2.DateDefault = new System.DateTime(2006, 6, 12, 17, 12, 35, 0);
			dateTimeCellType2.DropDownButton = false;
			dateTimeCellType2.TimeDefault = new System.DateTime(2006, 6, 12, 17, 12, 35, 0);
			this.fpsBenefitDetail_Sheet1.Columns.Get(1).CellType = dateTimeCellType2;
			this.fpsBenefitDetail_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsBenefitDetail_Sheet1.Columns.Get(1).Label = "จนถึง";
			this.fpsBenefitDetail_Sheet1.Columns.Get(1).Width = 90F;
			this.fpsBenefitDetail_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsBenefitDetail_Sheet1.Columns.Get(2).CellType = textCellType1;
			this.fpsBenefitDetail_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
			this.fpsBenefitDetail_Sheet1.Columns.Get(2).Width = 110F;
			this.fpsBenefitDetail_Sheet1.Columns.Get(3).AllowAutoSort = true;
			dateTimeCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType3.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType3.DateDefault = new System.DateTime(2006, 6, 13, 15, 36, 27, 0);
			dateTimeCellType3.DropDownButton = false;
			dateTimeCellType3.TimeDefault = new System.DateTime(2006, 6, 13, 15, 36, 27, 0);
			this.fpsBenefitDetail_Sheet1.Columns.Get(3).CellType = dateTimeCellType3;
			this.fpsBenefitDetail_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsBenefitDetail_Sheet1.Columns.Get(3).Width = 90F;
			this.fpsBenefitDetail_Sheet1.Columns.Get(4).AllowAutoSort = true;
			dateTimeCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType4.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType4.DateDefault = new System.DateTime(2006, 6, 13, 15, 36, 32, 0);
			dateTimeCellType4.DropDownButton = false;
			dateTimeCellType4.TimeDefault = new System.DateTime(2006, 6, 13, 15, 36, 32, 0);
			this.fpsBenefitDetail_Sheet1.Columns.Get(4).CellType = dateTimeCellType4;
			this.fpsBenefitDetail_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsBenefitDetail_Sheet1.Columns.Get(4).Width = 90F;
			this.fpsBenefitDetail_Sheet1.Columns.Get(5).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsBenefitDetail_Sheet1.Columns.Get(5).CellType = textCellType2;
			this.fpsBenefitDetail_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
			this.fpsBenefitDetail_Sheet1.Columns.Get(5).Width = 120F;
			this.fpsBenefitDetail_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
			this.fpsBenefitDetail_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsBenefitDetail_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsBenefitDetail_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsBenefitDetail_Sheet1.SheetName = "Sheet1";
			this.fpsBenefitDetail_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// cmdClose
			// 
			this.cmdClose.Location = new System.Drawing.Point(584, 432);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 2;
			this.cmdClose.Text = "ปิด";
			this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
			// 
			// frmGenerateOtherBenefitDetail
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(680, 470);
			this.Controls.Add(this.cmdClose);
			this.Controls.Add(this.fpsBenefitDetail);
			this.Controls.Add(this.groupBox1);
			this.Name = "frmGenerateOtherBenefitDetail";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "รายละเอียดพนักงาน";
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fpsBenefitDetail)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsBenefitDetail_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private - 
		private frmGenerateOtherBenefit parentForm;

		private ServiceStaffAssignmentList objServiceStaffAssignmentList
		{
			get{return parentForm.FacadeGenerateOtherBenefit.ObjServiceStaffAssignmentList;}
		}

		private ServiceStaffAssignmentList objServiceStaffAssignmentConditionList
		{
			get{return parentForm.FacadeGenerateOtherBenefit.ObjServiceStaffAssignmentConditionList;}
		}
		#endregion

//		============================== Constructor ==============================
		public frmGenerateOtherBenefitDetail(frmGenerateOtherBenefit frmParent) : base()
		{
			InitializeComponent();
			this.parentForm = frmParent;
		}

//		============================== Private method ==============================
		private void bindAssignment(ServiceStaffAssignment value, int iRow)
		{
			lblEmpNo.Text = value.AAssignedServiceStaff.EmployeeNo;
			lblEmpName.Text = value.AAssignedServiceStaff.EmployeeName;
			fpsBenefitDetail_Sheet1.Cells[iRow,0].Text = value.APeriod.From.ToShortDateString();
			fpsBenefitDetail_Sheet1.Cells[iRow,1].Text = value.APeriod.To.ToShortDateString();
			fpsBenefitDetail_Sheet1.Cells[iRow,2].Text = value.AContract.ContractNo.ToString();
			fpsBenefitDetail_Sheet1.Cells[iRow,3].Text = value.AContract.APeriod.From.ToShortDateString();
			fpsBenefitDetail_Sheet1.Cells[iRow,4].Text = value.AContract.APeriod.To.ToShortDateString();

			string customer = value.AContract.ACustomer.ShortName;

			if(value.AContract.ACustomerDepartment != null && !value.AContract.ACustomerDepartment.ShortName.Equals(""))
			{
				customer += " (" + value.AContract.ACustomerDepartment.ShortName + ") ";
			}

			fpsBenefitDetail_Sheet1.Cells[iRow,5].Text = customer;
		}

//		============================== Public method ==============================
		public void InitForm(Employee value, YearMonth yearMonth)
		{
			lblEmpNo.Text = string.Empty;
			lblEmpName.Text = string.Empty;

			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				int iRow = 0;
				fpsBenefitDetail_Sheet1.RowCount = 0;

				if(value != null)
				{
					lblEmpNo.Text = value.EmployeeNo;
					lblEmpName.Text = value.EmployeeName;
				}

				if (objServiceStaffAssignmentList == null)
				{
					if (parentForm.FacadeGenerateOtherBenefit.GetServiceStaffAssignmentInPeriodList(value, yearMonth))
					{
						for(int i=0; i<objServiceStaffAssignmentConditionList.Count; i++)
						{
							fpsBenefitDetail_Sheet1.RowCount++;
							bindAssignment(objServiceStaffAssignmentConditionList[i], iRow);
							iRow++;
						}
					}
				}
				else
				{
					for(int i=0; i<objServiceStaffAssignmentList.Count; i++)
					{
						if(objServiceStaffAssignmentList[i].AAssignedServiceStaff.EmployeeNo.Equals(value.EmployeeNo))
						{
							fpsBenefitDetail_Sheet1.RowCount++;
							bindAssignment(objServiceStaffAssignmentList[i], iRow);
							iRow++;
						}
					}
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
			{
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
		}

//		============================== Event ==============================
		private void cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
