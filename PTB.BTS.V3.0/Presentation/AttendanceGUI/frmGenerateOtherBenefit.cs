using System;
using System.Collections;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using Entity.ContractEntities;
using Entity.CommonEntity;
using Entity.AttendanceEntities;

using Facade.AttendanceFacade;
using Facade.CommonFacade;

using Presentation.CommonGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

namespace Presentation.AttendanceGUI
{
	public class frmGenerateOtherBenefit : ChildFormBase, IMDIChildForm
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
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.DateTimePicker dtpForMonth;
		private System.Windows.Forms.Label lblForMonth;
		private FarPoint.Win.Spread.FpSpread fpsExtraBenefit;
		private FarPoint.Win.Spread.SheetView fpsExtraBenefit_Sheet1;
		private System.Windows.Forms.Button cmdCalculate;

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmGenerateOtherBenefit));
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dtpForMonth = new System.Windows.Forms.DateTimePicker();
			this.lblForMonth = new System.Windows.Forms.Label();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.fpsExtraBenefit = new FarPoint.Win.Spread.FpSpread();
			this.fpsExtraBenefit_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.cmdCalculate = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpsExtraBenefit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsExtraBenefit_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.groupBox1.Controls.Add(this.dtpForMonth);
			this.groupBox1.Controls.Add(this.lblForMonth);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(811, 48);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// dtpForMonth
			// 
			this.dtpForMonth.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.dtpForMonth.CustomFormat = "MM/yyyy";
			this.dtpForMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpForMonth.Location = new System.Drawing.Point(402, 16);
			this.dtpForMonth.Name = "dtpForMonth";
			this.dtpForMonth.Size = new System.Drawing.Size(78, 20);
			this.dtpForMonth.TabIndex = 20;
			this.dtpForMonth.ValueChanged += new System.EventHandler(this.dtpForMonth_ValueChanged);
			// 
			// lblForMonth
			// 
			this.lblForMonth.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblForMonth.Location = new System.Drawing.Point(330, 16);
			this.lblForMonth.Name = "lblForMonth";
			this.lblForMonth.Size = new System.Drawing.Size(64, 23);
			this.lblForMonth.TabIndex = 21;
			this.lblForMonth.Text = "สำหรับเดือน";
			this.lblForMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(420, 240);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 6;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdOK.Location = new System.Drawing.Point(332, 240);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 5;
			this.cmdOK.Text = "บันทึก";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// fpsExtraBenefit
			// 
			this.fpsExtraBenefit.AllowDragFill = true;
			this.fpsExtraBenefit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsExtraBenefit.EditModePermanent = true;
			this.fpsExtraBenefit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpsExtraBenefit.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsExtraBenefit.Location = new System.Drawing.Point(8, 64);
			this.fpsExtraBenefit.Name = "fpsExtraBenefit";
			this.fpsExtraBenefit.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																						 this.fpsExtraBenefit_Sheet1});
			this.fpsExtraBenefit.Size = new System.Drawing.Size(811, 160);
			this.fpsExtraBenefit.TabIndex = 31;
			this.fpsExtraBenefit.TabStop = false;
			this.fpsExtraBenefit.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpsExtraBenefit_ButtonClicked);
			// 
			// fpsExtraBenefit_Sheet1
			// 
			this.fpsExtraBenefit_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsExtraBenefit_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsExtraBenefit_Sheet1.ColumnCount = 7;
			this.fpsExtraBenefit_Sheet1.RowCount = 1;
			this.fpsExtraBenefit_Sheet1.Cells.Get(0, 6).Locked = false;
			this.fpsExtraBenefit_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "เบี้ยขยัน";
			this.fpsExtraBenefit_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "รหัส";
			this.fpsExtraBenefit_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ชื่อ - นามสกุล";
			this.fpsExtraBenefit_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "เบี้ยขยัน";
			this.fpsExtraBenefit_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "หมายเหตุ";
			this.fpsExtraBenefit_Sheet1.ColumnHeader.Cells.Get(0, 6).Text = "รายละเอียด";
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsExtraBenefit_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsExtraBenefit_Sheet1.Columns.Get(0).Visible = false;
			this.fpsExtraBenefit_Sheet1.Columns.Get(1).AllowAutoSort = true;
			this.fpsExtraBenefit_Sheet1.Columns.Get(1).CellType = checkBoxCellType1;
			this.fpsExtraBenefit_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsExtraBenefit_Sheet1.Columns.Get(1).Label = "เบี้ยขยัน";
			this.fpsExtraBenefit_Sheet1.Columns.Get(1).Resizable = false;
			this.fpsExtraBenefit_Sheet1.Columns.Get(2).AllowAutoSort = true;
			this.fpsExtraBenefit_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.MistyRose;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsExtraBenefit_Sheet1.Columns.Get(2).CellType = textCellType2;
			this.fpsExtraBenefit_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsExtraBenefit_Sheet1.Columns.Get(2).Label = "รหัส";
			this.fpsExtraBenefit_Sheet1.Columns.Get(2).Locked = true;
			this.fpsExtraBenefit_Sheet1.Columns.Get(2).Resizable = false;
			this.fpsExtraBenefit_Sheet1.Columns.Get(2).Width = 65F;
			this.fpsExtraBenefit_Sheet1.Columns.Get(3).AllowAutoSort = true;
			this.fpsExtraBenefit_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.MistyRose;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			this.fpsExtraBenefit_Sheet1.Columns.Get(3).CellType = textCellType3;
			this.fpsExtraBenefit_Sheet1.Columns.Get(3).Label = "ชื่อ - นามสกุล";
			this.fpsExtraBenefit_Sheet1.Columns.Get(3).Locked = true;
			this.fpsExtraBenefit_Sheet1.Columns.Get(3).Resizable = false;
			this.fpsExtraBenefit_Sheet1.Columns.Get(3).Width = 185F;
			this.fpsExtraBenefit_Sheet1.Columns.Get(4).AllowAutoSort = true;
			this.fpsExtraBenefit_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.MistyRose;
			numberCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType1.DecimalPlaces = 0;
			numberCellType1.DropDownButton = false;
			numberCellType1.MinimumValue = 0;
			numberCellType1.Separator = ",";
			numberCellType1.ShowSeparator = true;
			this.fpsExtraBenefit_Sheet1.Columns.Get(4).CellType = numberCellType1;
			this.fpsExtraBenefit_Sheet1.Columns.Get(4).Label = "เบี้ยขยัน";
			this.fpsExtraBenefit_Sheet1.Columns.Get(4).Locked = true;
			this.fpsExtraBenefit_Sheet1.Columns.Get(4).Resizable = false;
			this.fpsExtraBenefit_Sheet1.Columns.Get(4).Width = 55F;
			this.fpsExtraBenefit_Sheet1.Columns.Get(5).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			textCellType4.MaxLength = 60;
			this.fpsExtraBenefit_Sheet1.Columns.Get(5).CellType = textCellType4;
			this.fpsExtraBenefit_Sheet1.Columns.Get(5).Label = "หมายเหตุ";
			this.fpsExtraBenefit_Sheet1.Columns.Get(5).Width = 310F;
			this.fpsExtraBenefit_Sheet1.Columns.Get(6).AllowAutoSort = true;
			this.fpsExtraBenefit_Sheet1.Columns.Get(6).BackColor = System.Drawing.Color.White;
			buttonCellType1.ButtonColor = System.Drawing.Color.LavenderBlush;
			buttonCellType1.Text = "ดูข้อมูล";
			this.fpsExtraBenefit_Sheet1.Columns.Get(6).CellType = buttonCellType1;
			this.fpsExtraBenefit_Sheet1.Columns.Get(6).Label = "รายละเอียด";
			this.fpsExtraBenefit_Sheet1.Columns.Get(6).Locked = false;
			this.fpsExtraBenefit_Sheet1.Columns.Get(6).Resizable = false;
			this.fpsExtraBenefit_Sheet1.Columns.Get(6).Width = 80F;
			this.fpsExtraBenefit_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsExtraBenefit_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsExtraBenefit_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsExtraBenefit_Sheet1.SheetName = "Sheet1";
			this.fpsExtraBenefit_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// cmdCalculate
			// 
			this.cmdCalculate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdCalculate.Location = new System.Drawing.Point(12, 240);
			this.cmdCalculate.Name = "cmdCalculate";
			this.cmdCalculate.TabIndex = 32;
			this.cmdCalculate.Text = "คำนวณ";
			this.cmdCalculate.Click += new System.EventHandler(this.cmdCalculate_Click);
			// 
			// frmGenerateOtherBenefit
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(826, 280);
			this.Controls.Add(this.cmdCalculate);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.fpsExtraBenefit);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmGenerateOtherBenefit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "คำนวณค่าเบี้ยขยัน, ค่าโทรศัพท์";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmGenerateOtherBenefit_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fpsExtraBenefit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsExtraBenefit_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private frmMain mdiParent;
		private YearMonth yearMonth;
		private int extraRate = 0;
		#endregion

		#region - Property -		
		private int selectedRow
		{
			get{return fpsExtraBenefit_Sheet1.ActiveRowIndex;}
		}

		private string selectEmpNo
		{
			get{return fpsExtraBenefit_Sheet1.Cells[selectedRow,2].Text;}
		}

		private ServiceStaffAssignmentList objServiceStaffAssignmentList
		{
			get{return facadeGenerateOtherBenefit.ObjServiceStaffAssignmentList;}
		}

		private EmployeeList ObjEmployeeList
		{
			get{return facadeGenerateOtherBenefit.ObjEmployeeList;}
		}

		private GenerateOtherBenefitFacade facadeGenerateOtherBenefit;
		public GenerateOtherBenefitFacade FacadeGenerateOtherBenefit
		{
			get{return facadeGenerateOtherBenefit;}
		}
		#endregion

//		==============================  Constructor  ==============================
		public frmGenerateOtherBenefit() : base()
		{
			InitializeComponent();
			facadeGenerateOtherBenefit = new GenerateOtherBenefitFacade();
            this.title = UserProfile.GetFormName("miAttendance", "miGenerateOtherBenefit");
		}

//		==============================Private method ==============================
		private void bindExtraBenefit(int i, EmployeeExtraBenefit value)
		{
			fpsExtraBenefit_Sheet1.Cells.Get(i,0).Text = value.EntityKey.ToString();

			if (value[0].ABenefitPayment.PaymentStatus.Equals(PAYMENT_STATUS_TYPE.NO))
			{
				fpsExtraBenefit_Sheet1.Cells.Get(i,1).Value = false;
			}
			else
			{
				fpsExtraBenefit_Sheet1.Cells.Get(i,1).Value = true;
			}

			fpsExtraBenefit_Sheet1.Cells.Get(i,2).Text = value.Employee.EmployeeNo.ToString();
			fpsExtraBenefit_Sheet1.Cells.Get(i,3).Text = value.Employee.EmployeeName.ToString();
			fpsExtraBenefit_Sheet1.Cells.Get(i,4).Text = value[0].TotalAmount.ToString();
			fpsExtraBenefit_Sheet1.Cells.Get(i,5).Text = value[0].Remark.ToString();
		}

		private void bindForm()
		{
			this.fpsExtraBenefit_Sheet1.RowCount = 0;
			this.fpsExtraBenefit_Sheet1.RowCount = facadeGenerateOtherBenefit.ObjEmployeeExtraBenefitList.Count;

			for(int iRow=0; iRow < facadeGenerateOtherBenefit.ObjEmployeeExtraBenefitList.Count; iRow++)
			{
				bindExtraBenefit(iRow,facadeGenerateOtherBenefit.ObjEmployeeExtraBenefitList[iRow]);
			}		
			mdiParent.RefreshMasterCount();			
		}

		private bool calculateOtherBenefit()
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			bool result = false;

			try
			{
				if (facadeGenerateOtherBenefit.CalculateOtherBenefit(yearMonth))
				{
					this.fpsExtraBenefit_Sheet1.RowCount = facadeGenerateOtherBenefit.ObjTimeCardEmployeeBenefitList.Count;
					for(int iRow=0; iRow < facadeGenerateOtherBenefit.ObjTimeCardEmployeeBenefitList.Count; iRow++)
					{
						bindExtraBenefit(iRow,facadeGenerateOtherBenefit.ObjTimeCardEmployeeBenefitList[iRow]);
					}	
					mdiParent.RefreshMasterCount();
					result = true;
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
			return result;
		}

		private void showDetail()
		{
			try
			{
				frmGenerateOtherBenefitDetail frmDetail = new frmGenerateOtherBenefitDetail(this);
				frmDetail.InitForm(ObjEmployeeList[selectEmpNo], yearMonth);
				frmDetail.ShowDialog();				
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

		private void generateExtraAGTBenefit()
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

				EmployeeExtraBenefitList listEmployeeExtraBanefitList = new EmployeeExtraBenefitList(facadeGenerateOtherBenefit.GetCompany());
				EmployeeExtraBenefit objEmployeeExtraBenefit;
				ExtraBenefit objExtrabenefit;

				for (int i=0; i<fpsExtraBenefit_Sheet1.RowCount; i++)
				{
					objExtrabenefit = new ExtraBenefit();
					objExtrabenefit.AYearMonth = yearMonth;

					if (fpsExtraBenefit_Sheet1.Cells[i,1].Value.Equals(true))
					{
						objExtrabenefit.TotalAmount = decimal.Parse(fpsExtraBenefit_Sheet1.Cells[i,4].Text);	
						objExtrabenefit.ABenefitPayment.PaymentStatus = PAYMENT_STATUS_TYPE.YES;
					}
					else
					{
						objExtrabenefit.TotalAmount = decimal.Zero;
						objExtrabenefit.ABenefitPayment.PaymentStatus = PAYMENT_STATUS_TYPE.NO;
					}
					objExtrabenefit.Remark = fpsExtraBenefit_Sheet1.Cells[i,5].Text;

					objEmployeeExtraBenefit = new EmployeeExtraBenefit(ObjEmployeeList[fpsExtraBenefit_Sheet1.Cells[i,2].Text]);
					objEmployeeExtraBenefit.Add(objExtrabenefit);

					listEmployeeExtraBanefitList.Add(objEmployeeExtraBenefit);
				}

				objEmployeeExtraBenefit = null;
				objExtrabenefit = null;

				if(facadeGenerateOtherBenefit.GenerateOtherBenefit(listEmployeeExtraBanefitList, yearMonth))
				{
					this.Cursor = System.Windows.Forms.Cursors.Default;
					Message(MessageList.Information.I0001);
					dtpForMonth.Focus();
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

		private void setBenefit(int row)
		{
			if (fpsExtraBenefit_Sheet1.Cells[row, 1].Value.Equals(true))
			{
				fpsExtraBenefit_Sheet1.Cells[row, 4].Value = extraRate.ToString(); 
			}		
			else
			{
				fpsExtraBenefit_Sheet1.Cells[row, 4].Value = 0; 
			}
		}

//		============================== Base Event ==============================
		public void InitForm()
		{
			clearMainMenuStatus();
			mdiParent.EnableRefreshCommand(true);
			MainMenuRefreshStatus = true;

			cmdOK.Enabled = false;
			yearMonth = new YearMonth(dtpForMonth.Value);

			try
			{
				OtherBenefitRate objOtherBenefitRate = new OtherBenefitRate();
				facadeGenerateOtherBenefit.FillOtherBenefitRete(ref objOtherBenefitRate);
				extraRate = objOtherBenefitRate.ExtraRate;
				objOtherBenefitRate = null;

				if(facadeGenerateOtherBenefit.FillEmployeeList())
				{
					if(facadeGenerateOtherBenefit.DisplayEmployeeExtraBenefit(yearMonth))
					{
						bindForm();
						cmdOK.Enabled = true;
					}
					else
					{
						fpsExtraBenefit_Sheet1.RowCount = 0;
						cmdOK.Enabled = false;
					}
				}				
			}
			catch(SqlException ex)
			{
				Message(ex);
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
				this.Cursor = System.Windows.Forms.Cursors.Arrow;
			}

			if(UserProfile.IsReadOnly("miAttendance", "miGenerateOtherBenefit"))
			{
				cmdOK.Enabled = false;
			}
		}

		public void RefreshForm()
		{			
			InitForm();
		}

		public void PrintForm()
		{
		}

		public void ExitForm()
		{
			clearMainMenuStatus();
			Dispose(true);
		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miGenerateOtherBenefit");
        }

//		============================== event ==============================
		private void frmGenerateOtherBenefit_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();		
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			generateExtraAGTBenefit();
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cmdCalculate_Click(object sender, System.EventArgs e)
		{
			if(calculateOtherBenefit())
			{
				cmdOK.Enabled = true;
			}
			else
			{
				cmdOK.Enabled = false;
			}
		}

		private void dtpForMonth_ValueChanged(object sender, System.EventArgs e)
		{
			InitForm();
		}

		private void fpsExtraBenefit_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
		{
			if (e.Column.Equals(6))
			{
				showDetail(); 			
			}
			else if (e.Column.Equals(1))
			{
				setBenefit(e.Row);
			}
		}
	}
}
