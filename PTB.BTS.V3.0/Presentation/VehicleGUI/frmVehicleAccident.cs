using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.VehicleEntities;

using Facade.VehicleFacade;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

namespace Presentation.VehicleGUI
{
	public class frmVehicleAccident : Presentation.VehicleGUI.frmVehicleRepairingBase
	{
		#region Designer generated code
		private FarPoint.Win.Spread.FpSpread fpsVehicleAccident;
		private FarPoint.Win.Spread.SheetView fpsVehicleAccident_Sheet1;
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
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmVehicleAccident));
			this.fpsVehicleAccident = new FarPoint.Win.Spread.FpSpread();
			this.fpsVehicleAccident_Sheet1 = new FarPoint.Win.Spread.SheetView();
			((System.ComponentModel.ISupportInitialize)(this.fpsVehicleAccident)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsVehicleAccident_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// cmdDelete
			// 
			this.cmdDelete.Name = "cmdDelete";
			// 
			// cmdEdit
			// 
			this.cmdEdit.Name = "cmdEdit";
			// 
			// cmdAdd
			// 
			this.cmdAdd.Name = "cmdAdd";
			// 
			// fpsVehicleAccident
			// 
			this.fpsVehicleAccident.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsVehicleAccident.ContextMenuStrip = this.ctmDetail;
			this.fpsVehicleAccident.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsVehicleAccident.Location = new System.Drawing.Point(168, 160);
			this.fpsVehicleAccident.Name = "fpsVehicleAccident";
			this.fpsVehicleAccident.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																							this.fpsVehicleAccident_Sheet1});
			this.fpsVehicleAccident.Size = new System.Drawing.Size(688, 256);
			this.fpsVehicleAccident.TabIndex = 2;
			this.fpsVehicleAccident.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsVehicleAccident_CellDoubleClick);
			// 
			// fpsVehicleAccident_Sheet1
			// 
			this.fpsVehicleAccident_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsVehicleAccident_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsVehicleAccident_Sheet1.ColumnCount = 5;
			this.fpsVehicleAccident_Sheet1.RowCount = 0;
			this.fpsVehicleAccident_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "เลขที่เอกสาร";
			this.fpsVehicleAccident_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ชื่อลูกค้า";
			this.fpsVehicleAccident_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ชื่อพนักงานขับรถ";
			this.fpsVehicleAccident_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "วัน/เวลาที่เกิดเหตุ";
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsVehicleAccident_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsVehicleAccident_Sheet1.Columns.Get(0).Visible = false;
			this.fpsVehicleAccident_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			textCellType2.ReadOnly = true;
			this.fpsVehicleAccident_Sheet1.Columns.Get(1).CellType = textCellType2;
			this.fpsVehicleAccident_Sheet1.Columns.Get(1).Label = "เลขที่เอกสาร";
			this.fpsVehicleAccident_Sheet1.Columns.Get(1).Resizable = false;
			this.fpsVehicleAccident_Sheet1.Columns.Get(1).Width = 120F;
			this.fpsVehicleAccident_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			textCellType3.ReadOnly = true;
			this.fpsVehicleAccident_Sheet1.Columns.Get(2).CellType = textCellType3;
			this.fpsVehicleAccident_Sheet1.Columns.Get(2).Label = "ชื่อลูกค้า";
			this.fpsVehicleAccident_Sheet1.Columns.Get(2).Resizable = false;
			this.fpsVehicleAccident_Sheet1.Columns.Get(2).Width = 200F;
			this.fpsVehicleAccident_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			textCellType4.ReadOnly = true;
			this.fpsVehicleAccident_Sheet1.Columns.Get(3).CellType = textCellType4;
			this.fpsVehicleAccident_Sheet1.Columns.Get(3).Label = "ชื่อพนักงานขับรถ";
			this.fpsVehicleAccident_Sheet1.Columns.Get(3).Resizable = false;
			this.fpsVehicleAccident_Sheet1.Columns.Get(3).Width = 170F;
			this.fpsVehicleAccident_Sheet1.Columns.Get(4).AllowAutoSort = true;
			dateTimeCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType1.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType1.DateDefault = new System.DateTime(2005, 10, 21, 9, 41, 26, 0);
			dateTimeCellType1.DropDownButton = false;
			dateTimeCellType1.ReadOnly = true;
			dateTimeCellType1.TimeDefault = new System.DateTime(2005, 10, 21, 9, 41, 26, 0);
			this.fpsVehicleAccident_Sheet1.Columns.Get(4).CellType = dateTimeCellType1;
			this.fpsVehicleAccident_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsVehicleAccident_Sheet1.Columns.Get(4).Label = "วัน/เวลาที่เกิดเหตุ";
			this.fpsVehicleAccident_Sheet1.Columns.Get(4).Resizable = false;
			this.fpsVehicleAccident_Sheet1.Columns.Get(4).Width = 130F;
			this.fpsVehicleAccident_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpsVehicleAccident_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsVehicleAccident_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsVehicleAccident_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsVehicleAccident_Sheet1.SheetName = "Sheet1";
			this.fpsVehicleAccident_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// frmVehicleAccident
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1024, 486);
			this.Controls.Add(this.fpsVehicleAccident);
			this.Name = "frmVehicleAccident";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Controls.SetChildIndex(this.cmdAdd, 0);
			this.Controls.SetChildIndex(this.cmdEdit, 0);
			this.Controls.SetChildIndex(this.cmdDelete, 0);
			this.Controls.SetChildIndex(this.fpsVehicleAccident, 0);
			((System.ComponentModel.ISupportInitialize)(this.fpsVehicleAccident)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsVehicleAccident_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		#endregion

		//==============================  Constructor  ==============================
		public frmVehicleAccident() : base()
		{
			InitializeComponent();
			facadeRepairing = new VehicleAccidentFacade();
            this.title = UserProfile.GetFormName("miVehicle", "miVehicleMaintenanceAccidentHistory");
			setPermission(UserProfile.IsReadOnly("miVehicle", "miVehicleMaintenanceAccidentHistory"));
		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miVehicle", "miVehicleMaintenanceAccidentHistory");
        }

		#region - Private Method -
			protected override void newfrmEntry()
			{
				frmEntry = new frmVehicleAccidentEntry();
			}

			protected override void visibleDetail(bool value)
			{
				fpsVehicleAccident.Visible = value;
			}

			protected override void clearDetail()
			{
				fpsVehicleAccident_Sheet1.RowCount = 0;
				enableButton(false);
			}

        protected void bindDetail(int row, RepairingInfoBase value)
			{
				fpsVehicleAccident_Sheet1.Cells[row, 0].Text = value.EntityKey;
				fpsVehicleAccident_Sheet1.Cells[row, 1].Text = value.RepairingNo;
				if(value.ACustomer != null)
				{
					fpsVehicleAccident_Sheet1.Cells[row, 2].Text = value.ACustomer.AName.Thai;
				}
				fpsVehicleAccident_Sheet1.Cells[row, 3].Text = value.DriverName;
				fpsVehicleAccident_Sheet1.Cells[row, 4].Text = ((Accident)value).HappenTime.ToShortDateString();
			}

			protected override void displayDetail()
			{
				fpsVehicleAccident_Sheet1.RowCount = ObjVehicleRepairing.Count;
				if(ObjVehicleRepairing.Count>0)
				{
					for(int i=0; i<ObjVehicleRepairing.Count; i++)
					{
						bindDetail(i, ObjVehicleRepairing[i]);
					}
					enableButton(true);
                    fpsVehicleAccident_Sheet1.SetActiveCell(fpsVehicleAccident_Sheet1.RowCount, 0);
				}
				else
				{
					clearDetail();
				}
			}

			private bool validateDelete(Accident value)
			{
				for(int i=0; i<value.ADriverExcessDeduction.Count; i++)
				{
					if(value.ADriverExcessDeduction[i].IsPaid)
					{
						Message(MessageList.Error.E0013, "ลบข้อมูลอุบัติเหตุรายการนี้ได้", "มีการหักเงินพนักงานแล้ว");
						return false;
					}
				}

				return true;
			}
		#endregion

		//==============================  Base Event   ==============================
		protected override void EditEvent()
		{
			try
			{
				newfrmEntry();
				frmEntry.FormParent = this;
				int row = fpsVehicleAccident_Sheet1.ActiveRow.Index;
				string key = fpsVehicleAccident_Sheet1.Cells[row,0].Text;
				frmEntry.InitEditAction(facadeRepairing.VehicleRepairing[key]);
				frmEntry.ShowDialog();	
			}
			catch(TransactionException ex)
			{
				Message(ex);
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

		protected override void DeleteEvent()
		{
			try
			{
				string key = fpsVehicleAccident_Sheet1.Cells[fpsVehicleAccident_Sheet1.ActiveRow.Index, 0].Text;
				Accident accident = (Accident)facadeRepairing.VehicleRepairing[key];

				if(validateDelete(accident))
				{
					if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
					{
						if(facadeRepairing.DeleteRepairing(accident))
						{
							if(fpsVehicleAccident_Sheet1.RowCount>1)
							{
								fpsVehicleAccident_Sheet1.Rows.Remove(fpsVehicleAccident_Sheet1.ActiveRow.Index, 1);
							}
							else
							{
								clearDetail();
							}
						}	
					}			
				}
			}
			catch(TransactionException ex)
			{
				Message(ex);
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
        public override bool AddRow(RepairingInfoBase value)
		{
			if(base.AddRow(value))
			{
				fpsVehicleAccident_Sheet1.RowCount++;
				bindDetail(fpsVehicleAccident_Sheet1.RowCount-1, value);
                fpsVehicleAccident_Sheet1.SetActiveCell(fpsVehicleAccident_Sheet1.RowCount, 0);
				return true;
			}
			return false;
		}

        public override bool EditRow(RepairingInfoBase value)
		{
			if(base.EditRow(value))
			{
				bindDetail(fpsVehicleAccident_Sheet1.ActiveRow.Index, value);	
				return true;
			}
			return false;
		}

		//==============================     event     ==============================
		private void fpsVehicleAccident_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				EditEvent();
			}
		}
	}
}