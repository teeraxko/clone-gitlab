using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.VehicleEntities;
using Entity.CommonEntity;

using Facade.VehicleFacade;
using Facade.CommonFacade;

using Presentation.CommonGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;

namespace Presentation.VehicleGUI
{
	
	public class frmInsuranceTypeOnePolicyList : EntryFormBase
	{
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOK;
		private FarPoint.Win.Spread.SheetView fpsInsuranceTypeOnePolicyList_Sheet1;
		private FarPoint.Win.Spread.FpSpread fpsInsuranceTypeOnePolicyList;
		
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmInsuranceTypeOnePolicyList));
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType2 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.fpsInsuranceTypeOnePolicyList_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.fpsInsuranceTypeOnePolicyList = new FarPoint.Win.Spread.FpSpread();
			((System.ComponentModel.ISupportInitialize)(this.fpsInsuranceTypeOnePolicyList_Sheet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsInsuranceTypeOnePolicyList)).BeginInit();
			this.SuspendLayout();
			// 
			// fpsInsuranceTypeOnePolicyList_Sheet1
			// 
			this.fpsInsuranceTypeOnePolicyList_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsInsuranceTypeOnePolicyList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsInsuranceTypeOnePolicyList_Sheet1.ColumnCount = 5;
			this.fpsInsuranceTypeOnePolicyList_Sheet1.ColumnHeader.RowCount = 2;
			this.fpsInsuranceTypeOnePolicyList_Sheet1.RowCount = 0;
			this.fpsInsuranceTypeOnePolicyList_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
			this.fpsInsuranceTypeOnePolicyList_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "เลขที่กรมธรรม์";
			this.fpsInsuranceTypeOnePolicyList_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
			this.fpsInsuranceTypeOnePolicyList_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "วันที่เริ่มต้น";
			this.fpsInsuranceTypeOnePolicyList_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
			this.fpsInsuranceTypeOnePolicyList_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "วันที่สิ้นสุด";
			this.fpsInsuranceTypeOnePolicyList_Sheet1.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
			this.fpsInsuranceTypeOnePolicyList_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "ชื่อเจ้าหน้าที่";
			this.fpsInsuranceTypeOnePolicyList_Sheet1.ColumnHeader.Cells.Get(1, 1).Text = "เลขที่กรมธรรม์";
			this.fpsInsuranceTypeOnePolicyList_Sheet1.ColumnHeader.Rows.Get(1).Height = 0F;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsInsuranceTypeOnePolicyList_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsInsuranceTypeOnePolicyList_Sheet1.Columns.Get(0).Visible = false;
			this.fpsInsuranceTypeOnePolicyList_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsInsuranceTypeOnePolicyList_Sheet1.Columns.Get(1).CellType = textCellType2;
			this.fpsInsuranceTypeOnePolicyList_Sheet1.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpsInsuranceTypeOnePolicyList_Sheet1.Columns.Get(1).Label = "เลขที่กรมธรรม์";
			this.fpsInsuranceTypeOnePolicyList_Sheet1.Columns.Get(1).Resizable = true;
			this.fpsInsuranceTypeOnePolicyList_Sheet1.Columns.Get(1).Width = 120F;
			this.fpsInsuranceTypeOnePolicyList_Sheet1.Columns.Get(2).AllowAutoSort = true;
			dateTimeCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType1.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType1.DateDefault = new System.DateTime(2005, 10, 19, 9, 36, 16, 0);
			dateTimeCellType1.DropDownButton = false;
			dateTimeCellType1.TimeDefault = new System.DateTime(2005, 10, 19, 9, 36, 16, 0);
			dateTimeCellType1.UserDefinedFormat = "dd/MM/yyyy";
			this.fpsInsuranceTypeOnePolicyList_Sheet1.Columns.Get(2).CellType = dateTimeCellType1;
			this.fpsInsuranceTypeOnePolicyList_Sheet1.Columns.Get(2).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpsInsuranceTypeOnePolicyList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsInsuranceTypeOnePolicyList_Sheet1.Columns.Get(2).Resizable = true;
			this.fpsInsuranceTypeOnePolicyList_Sheet1.Columns.Get(2).Width = 120F;
			this.fpsInsuranceTypeOnePolicyList_Sheet1.Columns.Get(3).AllowAutoSort = true;
			dateTimeCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType2.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType2.DateDefault = new System.DateTime(2005, 10, 19, 9, 36, 52, 0);
			dateTimeCellType2.DropDownButton = false;
			dateTimeCellType2.TimeDefault = new System.DateTime(2005, 10, 19, 9, 36, 52, 0);
			dateTimeCellType2.UserDefinedFormat = "dd/MM/yyyy";
			this.fpsInsuranceTypeOnePolicyList_Sheet1.Columns.Get(3).CellType = dateTimeCellType2;
			this.fpsInsuranceTypeOnePolicyList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsInsuranceTypeOnePolicyList_Sheet1.Columns.Get(3).Resizable = true;
			this.fpsInsuranceTypeOnePolicyList_Sheet1.Columns.Get(3).Width = 120F;
			this.fpsInsuranceTypeOnePolicyList_Sheet1.Columns.Get(4).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			this.fpsInsuranceTypeOnePolicyList_Sheet1.Columns.Get(4).CellType = textCellType3;
            this.fpsInsuranceTypeOnePolicyList_Sheet1.Columns.Get(4).Resizable = true;
			this.fpsInsuranceTypeOnePolicyList_Sheet1.Columns.Get(4).Width = 150F;
			this.fpsInsuranceTypeOnePolicyList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpsInsuranceTypeOnePolicyList_Sheet1.RowHeader.Columns.Default.Resizable = true;
			this.fpsInsuranceTypeOnePolicyList_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsInsuranceTypeOnePolicyList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsInsuranceTypeOnePolicyList_Sheet1.SheetName = "Sheet1";
			this.fpsInsuranceTypeOnePolicyList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(311, 384);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 5;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Location = new System.Drawing.Point(231, 384);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 4;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// fpsInsuranceTypeOnePolicyList
			// 
			this.fpsInsuranceTypeOnePolicyList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsInsuranceTypeOnePolicyList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsInsuranceTypeOnePolicyList.Location = new System.Drawing.Point(22, 24);
			this.fpsInsuranceTypeOnePolicyList.Name = "fpsInsuranceTypeOnePolicyList";
			this.fpsInsuranceTypeOnePolicyList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																									   this.fpsInsuranceTypeOnePolicyList_Sheet1});
			this.fpsInsuranceTypeOnePolicyList.Size = new System.Drawing.Size(572, 336);
			this.fpsInsuranceTypeOnePolicyList.TabIndex = 3;
			this.fpsInsuranceTypeOnePolicyList.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsInsuranceTypeOnePolicyList_CellDoubleClick);
			// 
			// frmInsuranceTypeOnePolicyList
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(616, 422);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.fpsInsuranceTypeOnePolicyList);
			this.Controls.Add(this.cmdCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmInsuranceTypeOnePolicyList";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "รายการกรมธรรม์ประกันภัยชั้นหนึ่ง";
			this.Load += new System.EventHandler(this.frmInsuranceTypeOnePolicyList_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpsInsuranceTypeOnePolicyList_Sheet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsInsuranceTypeOnePolicyList)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private - 
		private int SelectedRow
		{
			get
			{
				return fpsInsuranceTypeOnePolicyList_Sheet1.ActiveRowIndex;
			}
		}

		private string SelectedKey
		{
			get
			{
				return fpsInsuranceTypeOnePolicyList_Sheet1.Cells[SelectedRow,0].Text;
			}
		}

		public InsuranceTypeOne SelectedInsuranceTypeOnePolicy
		{
			get
			{
				return facadeInsuranceTypeOnePolicyList.ObjInsuranceTypeOneList[SelectedKey];
			}
		}

		private bool selected;
		public bool Selected
		{
			get
			{
				return selected;
			}
		}
		#endregion

		//		============================== Property ==============================
		private InsuranceTypeOnePolicyListFacade facadeInsuranceTypeOnePolicyList;	
		public InsuranceTypeOnePolicyListFacade FacadeInsuranceTypeOnePolicyList
		{
			get
			{
				return facadeInsuranceTypeOnePolicyList;
			}
		}
		public string ConditionPolicyCode
		{
			set
			{
				facadeInsuranceTypeOnePolicyList.ConditionInsuranceTypeOne.PolicyNo = value;
			}
		}

		private bool conditionIsExpire = false;
		public bool ConditionIsExpire
		{
			set
			{
				conditionIsExpire = value;
			}
		}
		private DateTime conditionExpireDate;
		public DateTime ConditionExpireDate
		{
			set
			{
				conditionExpireDate = value;
			}
		}

		//		============================== Constructor ==============================
		public frmInsuranceTypeOnePolicyList()
		{
			InitializeComponent();
			facadeInsuranceTypeOnePolicyList = new InsuranceTypeOnePolicyListFacade();
		}

		//		============================== Private Method ==============================
		private void bindInsuranceTypeOnePolicy(int row, InsuranceTypeOne aInsuranceTypeOne)
		{
			fpsInsuranceTypeOnePolicyList_Sheet1.Cells[row,0].Text = GUIFunction.GetString(aInsuranceTypeOne.EntityKey);
			fpsInsuranceTypeOnePolicyList_Sheet1.Cells[row,1].Text = GUIFunction.GetString(aInsuranceTypeOne.PolicyNo);
			fpsInsuranceTypeOnePolicyList_Sheet1.Cells[row,2].Text = GUIFunction.GetString(aInsuranceTypeOne.APeriod.From.Date.ToShortDateString());
			fpsInsuranceTypeOnePolicyList_Sheet1.Cells[row,3].Text = GUIFunction.GetString(aInsuranceTypeOne.APeriod.To.Date.ToShortDateString());
			fpsInsuranceTypeOnePolicyList_Sheet1.Cells[row,4].Text = GUIFunction.GetString(aInsuranceTypeOne.InsuranceInchargeName);

            if (aInsuranceTypeOne.APeriod.To > DateTime.Today)
            {
                fpsInsuranceTypeOnePolicyList_Sheet1.Rows.Get(row).BackColor = System.Drawing.Color.MistyRose;
            }
		}

		private void bindForm()
		{
			if (facadeInsuranceTypeOnePolicyList.ObjInsuranceTypeOneList != null)
			{
				int iRow = facadeInsuranceTypeOnePolicyList.ObjInsuranceTypeOneList.Count;
				fpsInsuranceTypeOnePolicyList_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindInsuranceTypeOnePolicy(i, facadeInsuranceTypeOnePolicyList.ObjInsuranceTypeOneList[i]);
				}				
			}
		}
		private void enableButton(bool enable)
		{
			
		}

		private void clearForm()
		{
			fpsInsuranceTypeOnePolicyList_Sheet1.RowCount = 0;
			cmdOK.Enabled = false;
		}

		//		============================== Base Event ===============================
		public void InitForm()
		{
			bool result = false;
			try
			{
				if(conditionIsExpire)
				{
					result = facadeInsuranceTypeOnePolicyList.DisplayExpireInsuranceTypeOne(conditionExpireDate);
				}
				else
				{
					result = facadeInsuranceTypeOnePolicyList.DisplayInsuranceTypeOne();
				}

				if (result)
				{
					bindForm();
				}
				else
				{
					selected = false;
					clearForm();
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

		public void RefreshForm()
		{
			InitForm();
		}

		public void PrintForm()
		{
		}

		public void ExitForm()
		{
			Dispose(true);
		}

		private void EditEvent()
		{
			selected = true;
			this.Hide();
		}

		//		============================== Event ==============================
		private void frmInsuranceTypeOnePolicyList_Load(object sender, System.EventArgs e)
		{
			InitForm();
		}
		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			EditEvent();
		}
		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			selected = false;
			this.Hide();	
		}
		private void fpsInsuranceTypeOnePolicyList_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				EditEvent();
			}
		}
	}
}
