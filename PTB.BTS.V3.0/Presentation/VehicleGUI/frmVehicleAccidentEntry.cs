using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using FarPoint.Win.Spread.CellType;

using Entity.VehicleEntities;
using Entity.CommonEntity;
using Entity.ContractEntities;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;

using Facade.CommonFacade;
using Facade.VehicleFacade;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

namespace Presentation.VehicleGUI
{
	public class frmVehicleAccidentEntry : Presentation.VehicleGUI.frmVehicleRepairingEntryBase
	{
		#region Designer generated code
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmVehicleAccidentEntry));
			((System.ComponentModel.ISupportInitialize)(this.fpsPayment)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsPayment_Sheet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsRepairList_Sheet1)).BeginInit();
			// 
			// txtPlatePrefix
			// 
			this.txtPlatePrefix.Name = "txtPlatePrefix";
			// 
			// txtUserName
			// 
			this.txtUserName.Name = "txtUserName";
			// 
			// tabVehicleAccident
			// 
			this.tabVehicleAccident.Name = "tabVehicleAccident";
			this.tabVehicleAccident.SelectedIndexChanged += new System.EventHandler(this.tabVehicleAccident_SelectedIndexChanged);
			// 
			// fpsPayment
			// 
			this.fpsPayment.Name = "fpsPayment";
			// 
			// cboAccidentPlace
			// 
			this.cboAccidentPlace.Name = "cboAccidentPlace";
			this.cboAccidentPlace.Size = new System.Drawing.Size(472, 24);
			// 
			// cboPoliceStation
			// 
			this.cboPoliceStation.Name = "cboPoliceStation";
			this.cboPoliceStation.Size = new System.Drawing.Size(256, 24);
			// 
			// dtpAccidentDate
			// 
			this.dtpAccidentDate.Name = "dtpAccidentDate";
			this.dtpAccidentDate.ValueChanged += new System.EventHandler(this.dtpAccidentDate_ValueChanged);
			// 
			// chkAccessStatus
			// 
			this.chkAccessStatus.Name = "chkAccessStatus";
			// 
			// cboPayerType
			// 
			this.cboPayerType.Name = "cboPayerType";
			this.cboPayerType.Size = new System.Drawing.Size(176, 24);
			// 
			// fpsPayment_Sheet1
			// 
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsPayment_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsPayment_Sheet1.ColumnCount = 5;
			this.fpsPayment_Sheet1.RowCount = 0;
			this.fpsPayment_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "ปี";
			this.fpsPayment_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "เดือน";
			this.fpsPayment_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "จำนวนเงิน";
			this.fpsPayment_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "จ่ายแล้ว";
			this.fpsPayment_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsPayment_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// chkPTBDriver
			// 
			this.chkPTBDriver.Name = "chkPTBDriver";
			// 
			// fpdPaid
			// 
			this.fpdPaid.Name = "fpdPaid";
			this.fpdPaid.Validated += new System.EventHandler(this.fpdPaid_Validated);
			// 
			// dtpPaidDate
			// 
			this.dtpPaidDate.Name = "dtpPaidDate";
			// 
			// tabAccident
			// 
			this.tabAccident.Name = "tabAccident";
			// 
			// tabMaintain
			// 
			this.tabMaintain.Name = "tabMaintain";
			// 
			// cmbGarage
			// 
			this.cmbGarage.Name = "cmbGarage";
			// 
			// dtpRepairTo
			// 
			this.dtpRepairTo.Name = "dtpRepairTo";
			// 
			// dtpRepairForm
			// 
			this.dtpRepairForm.Name = "dtpRepairForm";
			// 
			// txbReceiverNo
			// 
			this.txbReceiverNo.Name = "txbReceiverNo";
			// 
			// fpdExcessTotalAmount
			// 
			this.fpdExcessTotalAmount.Name = "fpdExcessTotalAmount";
			// 
			// chkHasRepair
			// 
			this.chkHasRepair.Name = "chkHasRepair";
			// 
			// fpsRepairList_Sheet1
			// 
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsRepairList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsRepairList_Sheet1.ColumnCount = 4;
			this.fpsRepairList_Sheet1.RowCount = 0;
			this.fpsRepairList_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "อะไหล่";
			this.fpsRepairList_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "รายละเอียด";
			this.fpsRepairList_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "สถานะค่าใช้จ่าย";
			this.fpsRepairList_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
			this.fpsRepairList_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsRepairList_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsRepairList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// frmVehicleAccidentEntry
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1016, 632);
			this.Name = "frmVehicleAccidentEntry";
			this.Load += new System.EventHandler(this.frmVehicleAccidentEntry_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmVehicleAccidentEntry_Paint);
			((System.ComponentModel.ISupportInitialize)(this.fpsPayment)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsPayment_Sheet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsRepairList_Sheet1)).EndInit();

		}
		#endregion

		#region - Private - 
			private Accident objAccident;
		#endregion

		//==============================  Constructor  ==============================
		public frmVehicleAccidentEntry() : base()
		{
			InitializeComponent();
			strGarage = "ศูนย์บริการ";
			programType = PROGRAM_TYPE.ACCIDENT;
			setFpsRepairList();
			fpiMileage.Visible = false;
			lblMileage.Visible = false;
			setPermission(UserProfile.IsReadOnly("miVehicle", "miVehicleMaintenanceAccidentHistory"));
		}

		#region - Private Method - 
			protected override void bindPayment()
			{
				fpsPayment_Sheet1.RowCount = objAccident.ADriverExcessDeduction.Count;
				for(int i=0; i<objAccident.ADriverExcessDeduction.Count; i++)
				{
					fpsPayment_Sheet1.Cells[i, 0].Text = objAccident.ADriverExcessDeduction[i].EntityKey;
					fpsPayment_Sheet1.Cells[i, 1].Text = objAccident.ADriverExcessDeduction[i].AForMonth.Year.ToString();
					fpsPayment_Sheet1.Cells[i, 2].Text = objAccident.ADriverExcessDeduction[i].AForMonth.Month.ToString();
					fpsPayment_Sheet1.Cells[i, 3].Text = objAccident.ADriverExcessDeduction[i].Amount.ToString();
					fpsPayment_Sheet1.Cells[i, 4].Value = objAccident.ADriverExcessDeduction[i].IsPaid;
					fpsPayment_Sheet1.Cells[i, 4].Locked = true;
				}
				bindCmdPayment();
			}

			private ComboBoxCellType DataSourceYear
			{
				get
				{
					int formYear = 2005;
					int toYear = DateTime.Today.Year+1;
					
					int yearCount = toYear - formYear + 1;
					string[] items = new string[yearCount];

					for(int i=formYear; i<=toYear; i++)
					{					
						items[i-formYear] = i.ToString();
					}

					ComboBoxCellType comboBox = new ComboBoxCellType();
					comboBox.Items = items;
					items = null;
					return comboBox;			
				}
			}

			private ComboBoxCellType DataSourceMonth
			{
				get
				{
					string[] items = new string[12];

					for(int i=1; i<=12; i++)
					{					
						items[i-1] = i.ToString();
					}

					ComboBoxCellType comboBox = new ComboBoxCellType();
					comboBox.Items = items;
					items = null;
					return comboBox;			
				}
			}

			protected override void addPaymentRow()
			{
				fpsPayment_Sheet1.RowCount++;
				fpsPayment_Sheet1.Cells[fpsPayment_Sheet1.RowCount-1, 1].Text = "";
				fpsPayment_Sheet1.Cells[fpsPayment_Sheet1.RowCount-1, 2].Text = "";
				fpsPayment_Sheet1.Cells[fpsPayment_Sheet1.RowCount-1, 4].Value = false;
				fpsPayment_Sheet1.Cells[fpsPayment_Sheet1.RowCount-1, 4].Locked = true;
				bindCmdPayment();
				base.addPaymentRow();
			}

			protected override void deletePaymentRow()
			{
				if((bool)fpsPayment_Sheet1.Cells[fpsPayment_Sheet1.ActiveRow.Index, 4].Value)
				{
					Message(MessageList.Error.E0014, "ลบรายการที่จ่ายเงินแล้วได้");
					return;
				}
				else
				{
					if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
					{
						objAccident.ADriverExcessDeduction.Remove(fpsPayment_Sheet1.Cells[fpsPayment_Sheet1.ActiveRow.Index, 0].Text);
						fpsPayment_Sheet1.ActiveRow.Remove();
					}
				}
				bindCmdPayment();
			}
		#endregion

		#region - validate - 
		protected override int getMaxMileage()
		{
			if(action == ActionType.ADD)
			{
				return formParent.FacadeRepairing.GetMaxMileage(dtpRepairForm.Value, null);
			}
			else
			{
				objAccident.RepairingNo = ((DocumentNo)txtDocumentType.Tag).ToString();
				return formParent.FacadeRepairing.GetMaxMileage(dtpAccidentDate.Value, objAccident);
			}
		}

		protected override bool validateAccident()
		{
			if(cboAccidentPlace.Text.Trim() == "")
			{
				Message(MessageList.Error.E0002, "สถานที่เกิดเหตุ");
				tabVehicleAccident.SelectedTab = tabAccident;
				cboAccidentPlace.Focus();
				return false;
			}

            //if (cboPoliceStation.Text.Trim() == "")
            //{
            //    Message(MessageList.Error.E0002, "สถานีตำรวจ");
            //    tabVehicleAccident.SelectedTab = tabAccident;
            //    cboPoliceStation.Focus();
            //    return false;
            //}

            //if (cboPayerType.Text.Trim() == "")
            //{
            //    Message(MessageList.Error.E0005, "ผู้รับผิดชอบค่าเสียหาย");
            //    tabVehicleAccident.SelectedTab = tabAccident;
            //    cboPayerType.Focus();
            //    return false;
            //}

            //decimal excessTotalAmount = decimal.Parse(fpdExcessTotalAmount.Text);
            //if(chkAccessStatus.Checked && excessTotalAmount == 0)
            //{
            //    Message(MessageList.Error.E0002, "จำนวนเงินค่า Excess");
            //    tabVehicleAccident.SelectedTab = tabAccident;
            //    fpdExcessTotalAmount.Focus();
            //    return false;
            //}


            if (chkAccessStatus.Checked && CTFunction.GetPayerType(cboPayerType.Text) == PAYER_TYPE.EMPLOYEE)
            {
                decimal sumPayment = decimal.Zero;
                for (int i = 0; i < fpsPayment_Sheet1.RowCount; i++)
                {
                    sumPayment += decimal.Parse(fpsPayment_Sheet1.Cells[i, 3].Text);
                }
                if (sumPayment == decimal.Zero)
                {
                    Message(MessageList.Error.E0002, "จำนวนเงินค่า Excess");
                    tabVehicleAccident.SelectedTab = tabAccident;
                    fpdExcessTotalAmount.Focus();
                    return false;
                }
            }

            decimal excessTotalAmount = decimal.Parse(fpdExcessTotalAmount.Text);
			if(chkPTBDriver.Checked && chkAccessStatus.Checked && CTFunction.GetPayerType(cboPayerType.Text) == PAYER_TYPE.EMPLOYEE)
			{
				decimal sumPayment = 0;
				for(int i=0; i<fpsPayment_Sheet1.RowCount; i++)
				{
					sumPayment += decimal.Parse(fpsPayment_Sheet1.Cells[i, 3].Text);
				}
				if(fpsPayment_Sheet1.RowCount>0 && sumPayment != excessTotalAmount)
				{
					Message(MessageList.Error.E0019, "ผลรวมค่า Excess");
					return false;
				}
				
				DriverExcessDeduction driverExcessDeduction = new DriverExcessDeduction(formParent.FacadeRepairing.GetCompany());
				ExcessDeduction excessDeduction;
				int year;
				int month;
				for(int i=0; i<fpsPayment_Sheet1.RowCount; i++)
				{
					excessDeduction = new ExcessDeduction();
					year = Convert.ToInt32(fpsPayment_Sheet1.Cells[i,1].Text);
					month = Convert.ToInt32(fpsPayment_Sheet1.Cells[i,2].Text);
					excessDeduction.AForMonth = new YearMonth(year, month);
					if(driverExcessDeduction.Contain(excessDeduction))
					{
						driverExcessDeduction = null;
						excessDeduction = null;
						Message(MessageList.Error.E0010);
						return false;
					}
					else
					{
						driverExcessDeduction.Add(excessDeduction);
					}					
				}
				driverExcessDeduction = null;
				excessDeduction = null;
			}

			if(CTFunction.GetPayerType(cboPayerType.Text)==PAYER_TYPE.EMPLOYEE && chkPTBDriver.Checked && Convert.ToDecimal(fpdExcessTotalAmount.Value)!=0m && Convert.ToDecimal(fpdPaid.Value)!=0m && fpsPayment_Sheet1.RowCount==0)
			{
				Message(MessageList.Error.E0017);
				return false;				
			}

            //User request allow staff deduct excess cross year : woranai 2008/04/08
            //if(fpsPayment_Sheet1.RowCount>0)
            //{
            //    string accidentNo = documentNo.ToString();

            //    Employee employee = (Employee)txtEmployeeNo.Tag;
            //    int year;
            //    int month;
            //    for(int i=0; i<fpsPayment_Sheet1.RowCount; i++)
            //    {
            //        year = Convert.ToInt32(fpsPayment_Sheet1.Cells[i, 1].Text);
            //        month = Convert.ToInt32(fpsPayment_Sheet1.Cells[i, 2].Text);

            //        //User request driver pay all excess deduct to end of year (month 12 can duplicate) : woranai 21/12/2007
            //        if(month != 12 && ((VehicleAccidentFacade)formParent.FacadeRepairing).IsDuplicateWithOtherAccident(employee, new YearMonth(year, month), accidentNo))
            //        {
            //            Message(MessageList.Error.E0052);
            //            return false;
            //        }

            //        if (i != 0)
            //        {
            //            int yearBefore = Convert.ToInt32(fpsPayment_Sheet1.Cells[i - 1, 1].Text);
            //            if (year != yearBefore)
            //            {
            //                Message(MessageList.Error.E0013, "บันทึกข้อมูลได้", "ปีที่หักค่า excess เกินปีที่เริ่มหัก");
            //                return false;
            //            }
            //        }
            //    }			
            //}

			return base.validateAccident();
		}

		protected override bool validateMaintain()
		{
			if(chkHasRepair.Checked)
			{
				return base.validateMaintain();
			}
			else
			{
				return true;
			}
		}
		#endregion

		#region - Get Object -
		protected override void fillHeader()
		{
			base.fillHeader();
			objRepairing.RepairingType = REPAIRING_TYPE.ACCIDENTR;
		}

		private void clearMaintain()
		{
			objRepairing.Garage = null;
			objRepairing.GarageInchargeName = "";
			objRepairing.GarageTelNo = "";
			objRepairing.RepairPeriod.From = NullConstant.DATETIME;
			objRepairing.RepairPeriod.To = NullConstant.DATETIME;
			objRepairing.RepairingPaymentType = null;
			objRepairing.MaintenanceAmount = 0;
			objRepairing.VatAmount = 0;
			objRepairing.TotalAmount = 0;
			objRepairing.TaxInvoiceNo = "";
			objRepairing.TaxInvoiceDate = NullConstant.DATETIME;
			objRepairing.Remark1 = "";
			objRepairing.Remark2 = "";
			objRepairing.ARepairSparePartsList.Clear();
		}

		protected override void fillObjRepairing()
		{
			fillHeader();
			fillAccident();	
			if(chkHasRepair.Checked)
			{
				fillMaintenance();
			}
			else
			{
				objRepairing.AReceiver = (Employee)txbReceiverNo.Tag;
				clearMaintain();
			}
		}
		#endregion

        protected override void setMaintenance(RepairingInfoBase value)
		{
			base.setMaintenance(value);
			if(value.ARepairSparePartsList.Count>0)
			{
				chkHasRepair.Checked = true;
			}
			else
			{
				chkHasRepair.Checked = false;
			}
		}

		protected override void  initDataSource()
		{
			base.initDataSource();
			fpsRepairList_Sheet1.Columns[3].CellType = FormParent.FacadeRepairing.DataSourceExpenseStatus;
		}

		protected override void setHeader()
		{
			if(action == ActionType.ADD)
			{
				txtUserName.Text = FormParent.FacadeRepairing.GetHirerName(FormParent.FacadeRepairing.VehicleRepairing.AVehicleInfo, dtpAccidentDate.Value.Date, dtpAccidentDate.Value.Date);
			}
		}

		//==============================  Base Event   ==============================
		private void clearDriverExcessDeduction()
		{
			DriverExcessDeduction driverExcessDeduction = new DriverExcessDeduction(formParent.FacadeRepairing.GetCompany());
			
			for(int i=0; i<objAccident.ADriverExcessDeduction.Count; i++)
			{
				if(objAccident.ADriverExcessDeduction[i].IsPaid)
				{
					driverExcessDeduction.Add(objAccident.ADriverExcessDeduction[i]);
				}
			}
			objAccident.ADriverExcessDeduction.Clear();
			for(int i=0; i<driverExcessDeduction.Count; i++)
			{
				objAccident.ADriverExcessDeduction.Add(driverExcessDeduction[i]);
			}
		}
		
		private void calculatePaymentNew(decimal excess, decimal amountPerMonth, YearMonth startMonthYear)
		{
			try
			{
				decimal fraction = excess % amountPerMonth;
				int numberOfMonth;
				numberOfMonth = (int)(excess / amountPerMonth);

				DateTime dtYearMonth = new DateTime(startMonthYear.Year, startMonthYear.Month, 1);

				ExcessDeduction excessDeduction;
				int forMonth = startMonthYear.Month;
				int forYear = startMonthYear.Year;
				for(int i=0; i<numberOfMonth; i++)
				{
					excessDeduction = new ExcessDeduction();
					excessDeduction.AForMonth = new YearMonth(dtYearMonth.Year, dtYearMonth.Month);
					dtYearMonth = dtYearMonth.AddMonths(1);
					excessDeduction.Amount = amountPerMonth;

					objAccident.ADriverExcessDeduction.Add(excessDeduction);
				}

				if(fraction != 0)
				{
					excessDeduction = new ExcessDeduction();
					excessDeduction.AForMonth = new YearMonth(dtYearMonth.Year, dtYearMonth.Month);
					excessDeduction.Amount = fraction;
					objAccident.ADriverExcessDeduction.Add(excessDeduction);
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
			{}
		}

		//============================== Public Method ==============================
		public override void InitAddAction(VehicleInfo value)
		{
			objAccident = new Accident(FormParent.FacadeRepairing.GetCompany());
			base.InitAddAction(value);
            enablechkVat(false);
		}

        public override void InitEditAction(RepairingInfoBase value)
		{
			objAccident = (Accident)value;
			base.InitEditAction(value);
		}

		protected override void getVehicleAssignment(VehicleInfo value)
		{
			VehicleAssignment vehicleAssignment = formParent.FacadeRepairing.GetVehicleAssignmentOnTime(value, dtpAccidentDate.Value, dtpAccidentDate.Value);
			if(vehicleAssignment==null)
			{
				objRepairing.AVehicleContract = null;
				if(action == ActionType.ADD)
				{
					objRepairing.AHirer.Name = "";
				}
			}
			else
			{
				objRepairing.AVehicleContract = (VehicleContract)vehicleAssignment.AContract;
				if(action == ActionType.ADD)
				{
					objRepairing.AHirer = vehicleAssignment.AHirer;
				}				
			}
			vehicleAssignment = null;
		}

		protected override void calculatePayment()
		{
			decimal excessTotal = decimal.Parse(fpdExcessTotalAmount.Text);
			decimal paidPerMonth = decimal.Parse(fpdPaid.Text);

			if(excessTotal == 0m)
			{
				Message(MessageList.Error.E0002, "ค่า Excess");
				tabVehicleAccident.SelectedTab = tabAccident;
				fpdExcessTotalAmount.Focus();
				return;
			}

			if(paidPerMonth == 0)
			{
				Message(MessageList.Error.E0002, "จำนวนเงินที่ถูกหักต่อเดือน");
				tabVehicleAccident.SelectedTab = tabAccident;
				fpdPaid.Focus();
				return;
			}

			if(paidPerMonth < 500)
			{
				Message(MessageList.Error.E0018, "จำนวนเงินที่ถูกหักต่อเดือน", "500 บาท");
				tabVehicleAccident.SelectedTab = tabAccident;
				fpdPaid.Focus();
				return;
			}

			if(fpsPayment_Sheet1.RowCount == 0)
			{
				calculatePaymentNew(excessTotal, paidPerMonth, new YearMonth(dtpPaidDate.Value));
				bindPayment();
			}
			else
			{
				decimal sum = 0;
				DateTime initDate = dtpPaidDate.Value;
				initDate = initDate.AddMonths(-1);
				int maxYear = initDate.Year;
				int maxMonth = initDate.Month;
				for(int i=0; i<objAccident.ADriverExcessDeduction.Count; i++)
				{
					if(objAccident.ADriverExcessDeduction[i].IsPaid)
					{
						sum += objAccident.ADriverExcessDeduction[i].Amount;
						if(objAccident.ADriverExcessDeduction[i].AForMonth.Year>maxYear)
						{
							maxYear = objAccident.ADriverExcessDeduction[i].AForMonth.Year;
							maxMonth = objAccident.ADriverExcessDeduction[i].AForMonth.Month;
						}
						else
						{
							if(objAccident.ADriverExcessDeduction[i].AForMonth.Year==maxYear && objAccident.ADriverExcessDeduction[i].AForMonth.Month>maxMonth)
							{
								maxMonth = objAccident.ADriverExcessDeduction[i].AForMonth.Month;
							}
						}
					}
				}
				if(excessTotal<sum)
				{
					Message(MessageList.Error.E0018, "จำนวนเงินค่า Excess", "จำนวนเงินที่พนักงานจ่ายแล้ว");
					fpdExcessTotalAmount.Focus();
					return;
				}
				else
				{
					sum = excessTotal - sum;
					clearDriverExcessDeduction();
					DateTime temp = new DateTime(maxYear, maxMonth, 1);
					temp = temp.AddMonths(1);
					calculatePaymentNew(sum, paidPerMonth, new YearMonth(temp));
					bindPayment();
				}
			}
		}

		//==============================     event     ==============================
		private void frmVehicleAccidentEntry_Load(object sender, System.EventArgs e)
		{
			fpsPayment_Sheet1.Columns[1].CellType = DataSourceYear;
			fpsPayment_Sheet1.Columns[2].CellType = DataSourceMonth;
			setCombo();

			if(action==ActionType.ADD)
			{
                objRepairing = new Accident(formParent.FacadeRepairing.GetCompany());   
				getVehicleAssignment((VehicleInfo)txtPlatePrefix.Tag);
				setContact(objRepairing);
			}
			
		}

		private void frmVehicleAccidentEntry_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			setCombo();
		}

		

		private void tabVehicleAccident_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			setCombo();
		}

		private void fpdPaid_Validated(object sender, System.EventArgs e)
		{
//			if(fpsPayment_Sheet1.RowCount>0)
//			{
//				decimal paidPerMonth = decimal.Parse(fpdPaid.Text);
//				if(paidPerMonth < 500)
//				{
//					Message(MessageList.Error.E0018, "จำนวนเงินที่ถูกหักต่อเดือน", "500 บาท");
//					fpdPaid.Focus();
//					return;
//				}
//			}
		}

		private void dtpAccidentDate_ValueChanged(object sender, System.EventArgs e)
		{
			getVehicleAssignment((VehicleInfo)txtPlatePrefix.Tag);
			setContact(objRepairing);	
		}
	}
}