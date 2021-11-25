//using System;
//using System.Drawing;
//using System.Collections;
//using System.ComponentModel;
//using System.Windows.Forms;
//using System.Data.SqlClient;

//using Entity.VehicleEntities;
//using Entity.CommonEntity;

//using Facade.VehicleFacade;
//using Facade.CommonFacade;

//using Presentation.CommonGUI;

//using SystemFramework.AppException;
//using SystemFramework.AppMessage;

//using ictus.Common.Entity.Time;

//namespace Presentation.VehicleGUI
//{
//    public class TMPfrmVehicleList : EntryFormBase
//    {
//        protected override void Dispose( bool disposing )
//        {
//            if( disposing )
//            {
//                if(components != null)
//                {
//                    components.Dispose();
//                }
//            }
//            base.Dispose( disposing );
//        }

//        #region Windows Form Designer generated code

//        private System.Windows.Forms.Button cmdOK;
//        private System.Windows.Forms.Button cmdCancel;
//        private FarPoint.Win.Spread.FpSpread fpsVehicleList;
//        private FarPoint.Win.Spread.SheetView fpsVehicleList_Sheet1;
//        private System.ComponentModel.Container components = null;

//        private void InitializeComponent()
//        {
//            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
//            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
//            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
//            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TMPfrmVehicleList));
//            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
//            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
//            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
//            this.fpsVehicleList = new FarPoint.Win.Spread.FpSpread();
//            this.fpsVehicleList_Sheet1 = new FarPoint.Win.Spread.SheetView();
//            this.cmdOK = new System.Windows.Forms.Button();
//            this.cmdCancel = new System.Windows.Forms.Button();
//            ((System.ComponentModel.ISupportInitialize)(this.fpsVehicleList)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.fpsVehicleList_Sheet1)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // fpsVehicleList
//            // 
//            this.fpsVehicleList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
//            this.fpsVehicleList.Location = new System.Drawing.Point(23, 24);
//            this.fpsVehicleList.Name = "fpsVehicleList";
//            this.fpsVehicleList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
//                                                                                        this.fpsVehicleList_Sheet1});
//            this.fpsVehicleList.Size = new System.Drawing.Size(764, 336);
//            this.fpsVehicleList.TabIndex = 0;
//            this.fpsVehicleList.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsVehicleList_CellDoubleClick);
//            // 
//            // fpsVehicleList_Sheet1
//            // 
//            this.fpsVehicleList_Sheet1.Reset();
//            // Formulas and custom names must be loaded with R1C1 reference style
//            this.fpsVehicleList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
//            this.fpsVehicleList_Sheet1.ColumnCount = 8;
//            this.fpsVehicleList_Sheet1.ColumnHeader.RowCount = 2;
//            this.fpsVehicleList_Sheet1.RowCount = 0;
//            this.fpsVehicleList_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
//            this.fpsVehicleList_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "ทะเบียนรถ";
//            this.fpsVehicleList_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
//            this.fpsVehicleList_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "วันที่จดทะเบียน";
//            this.fpsVehicleList_Sheet1.ColumnHeader.Cells.Get(0, 3).ColumnSpan = 2;
//            this.fpsVehicleList_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "อายุรถ";
//            this.fpsVehicleList_Sheet1.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
//            this.fpsVehicleList_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "ยี่ห้อรถ";
//            this.fpsVehicleList_Sheet1.ColumnHeader.Cells.Get(0, 6).RowSpan = 2;
//            this.fpsVehicleList_Sheet1.ColumnHeader.Cells.Get(0, 6).Text = "รุ่นรถ";
//            this.fpsVehicleList_Sheet1.ColumnHeader.Cells.Get(0, 7).RowSpan = 2;
//            this.fpsVehicleList_Sheet1.ColumnHeader.Cells.Get(0, 7).Text = "ประเภทรถ";
//            this.fpsVehicleList_Sheet1.ColumnHeader.Cells.Get(1, 3).Text = "ปี";
//            this.fpsVehicleList_Sheet1.ColumnHeader.Cells.Get(1, 4).Text = "เดือน";
//            textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            textCellType1.DropDownButton = false;
//            this.fpsVehicleList_Sheet1.Columns.Get(0).CellType = textCellType1;
//            this.fpsVehicleList_Sheet1.Columns.Get(0).Visible = false;
//            this.fpsVehicleList_Sheet1.Columns.Get(1).AllowAutoSort = true;
//            textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            textCellType2.DropDownButton = false;
//            this.fpsVehicleList_Sheet1.Columns.Get(1).CellType = textCellType2;
//            this.fpsVehicleList_Sheet1.Columns.Get(1).Resizable = false;
//            this.fpsVehicleList_Sheet1.Columns.Get(1).Width = 80F;
//            this.fpsVehicleList_Sheet1.Columns.Get(2).AllowAutoSort = true;
//            dateTimeCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            dateTimeCellType1.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
//            dateTimeCellType1.DateDefault = new System.DateTime(2005, 10, 20, 11, 27, 12, 0);
//            dateTimeCellType1.DropDownButton = false;
//            dateTimeCellType1.TimeDefault = new System.DateTime(2005, 10, 20, 11, 27, 12, 0);
//            dateTimeCellType1.UserDefinedFormat = "dd/MM/yyyy";
//            this.fpsVehicleList_Sheet1.Columns.Get(2).CellType = dateTimeCellType1;
//            this.fpsVehicleList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
//            this.fpsVehicleList_Sheet1.Columns.Get(2).Resizable = false;
//            this.fpsVehicleList_Sheet1.Columns.Get(2).Width = 110F;
//            this.fpsVehicleList_Sheet1.Columns.Get(3).AllowAutoSort = true;
//            this.fpsVehicleList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
//            this.fpsVehicleList_Sheet1.Columns.Get(3).Label = "ปี";
//            this.fpsVehicleList_Sheet1.Columns.Get(3).Resizable = false;
//            this.fpsVehicleList_Sheet1.Columns.Get(3).Width = 68F;
//            this.fpsVehicleList_Sheet1.Columns.Get(4).AllowAutoSort = true;
//            this.fpsVehicleList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
//            this.fpsVehicleList_Sheet1.Columns.Get(4).Label = "เดือน";
//            this.fpsVehicleList_Sheet1.Columns.Get(4).Resizable = false;
//            this.fpsVehicleList_Sheet1.Columns.Get(5).AllowAutoSort = true;
//            textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            textCellType3.DropDownButton = false;
//            this.fpsVehicleList_Sheet1.Columns.Get(5).CellType = textCellType3;
//            this.fpsVehicleList_Sheet1.Columns.Get(5).Resizable = false;
//            this.fpsVehicleList_Sheet1.Columns.Get(5).Width = 90F;
//            this.fpsVehicleList_Sheet1.Columns.Get(6).AllowAutoSort = true;
//            textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            textCellType4.DropDownButton = false;
//            this.fpsVehicleList_Sheet1.Columns.Get(6).CellType = textCellType4;
//            this.fpsVehicleList_Sheet1.Columns.Get(6).Resizable = false;
//            this.fpsVehicleList_Sheet1.Columns.Get(6).Width = 180F;
//            this.fpsVehicleList_Sheet1.Columns.Get(7).AllowAutoSort = true;
//            textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            textCellType5.DropDownButton = false;
//            this.fpsVehicleList_Sheet1.Columns.Get(7).CellType = textCellType5;
//            this.fpsVehicleList_Sheet1.Columns.Get(7).Resizable = false;
//            this.fpsVehicleList_Sheet1.Columns.Get(7).Width = 110F;
//            this.fpsVehicleList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
//            this.fpsVehicleList_Sheet1.RowHeader.Columns.Default.Resizable = false;
//            this.fpsVehicleList_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
//            this.fpsVehicleList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
//            this.fpsVehicleList_Sheet1.SheetName = "Sheet1";
//            this.fpsVehicleList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
//            // 
//            // cmdOK
//            // 
//            this.cmdOK.Location = new System.Drawing.Point(328, 376);
//            this.cmdOK.Name = "cmdOK";
//            this.cmdOK.TabIndex = 1;
//            this.cmdOK.Text = "ตกลง";
//            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
//            // 
//            // cmdCancel
//            // 
//            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
//            this.cmdCancel.Location = new System.Drawing.Point(408, 376);
//            this.cmdCancel.Name = "cmdCancel";
//            this.cmdCancel.TabIndex = 2;
//            this.cmdCancel.Text = "ยกเลิก";
//            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
//            // 
//            // frmVehicleList
//            // 
//            this.AcceptButton = this.cmdOK;
//            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
//            this.CancelButton = this.cmdCancel;
//            this.ClientSize = new System.Drawing.Size(810, 422);
//            this.Controls.Add(this.cmdCancel);
//            this.Controls.Add(this.cmdOK);
//            this.Controls.Add(this.fpsVehicleList);
//            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
//            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
//            this.Name = "frmVehicleList";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
//            this.Text = "รายการรถ";
//            this.Load += new System.EventHandler(this.frmVehicleList_Load);
//            ((System.ComponentModel.ISupportInitialize)(this.fpsVehicleList)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.fpsVehicleList_Sheet1)).EndInit();
//            this.ResumeLayout(false);

//        }
//        #endregion

//        #region - Private - 
//        private int SelectedRow
//        {
//            get{return fpsVehicleList_Sheet1.ActiveRowIndex;}
//        }

//        private string SelectedKey
//        {
//            get{return fpsVehicleList_Sheet1.Cells[SelectedRow,0].Text;}
//        }

//        public Vehicle SelectedVehicle
//        {
//            get{return facadeVehicleList.ObjVehicleList[SelectedKey];}
//        }

//        private bool selected;
//        public bool Selected
//        {
//            get{return selected;}
//        }
//        #endregion

////		============================== Property ==============================
//        private VehicleListFacade facadeVehicleList;	
//        public VehicleListFacade FacadeVehicleList
//        {
//            get{return facadeVehicleList;}
//        }

//        public string ConditionPlatePrefix
//        {
//            set{facadeVehicleList.ConditionVehicle.PlatePrefix = value;}
//        }

//        public string ConditionPlateRunningNo
//        {
//            set{facadeVehicleList.ConditionVehicle.PlateRunningNo = value;}
//        }

//        private bool isVehicleAvailable = false;
//        public bool IsVehicleAvailable
//        {
//            set { isVehicleAvailable = value; }
//        }

//        private bool vehicleOutInsurance = false;
//        public bool VehicleOutInsurance
//        {
//            set{vehicleOutInsurance = value;}
//        }

//        private bool isVehicleAssign = false;
//        public bool IsVehicleAssign
//        {
//            set{isVehicleAssign = value;}
//        }
		
//        private DateTime conditionStartDate;
//        public DateTime ConditionStartDate
//        {
//            set{conditionStartDate = value;}
//        }

//        private DateTime conditionEndDate;
//        public DateTime ConditionEndDate
//        {
//            set{conditionEndDate = value;}
//        }
////		============================== Constructor ==============================
//        public TMPfrmVehicleList():base()
//        {
//            InitializeComponent();
//            facadeVehicleList = new VehicleListFacade();
//        }
////		============================== private method ==============================
//        private void bindVehicle(int row, Vehicle value)
//        {
//            fpsVehicleList_Sheet1.Cells[row,0].Text = GUIFunction.GetString(value.EntityKey);
//            fpsVehicleList_Sheet1.Cells[row,1].Text = GUIFunction.GetString(value.PlateNo);
//            fpsVehicleList_Sheet1.Cells[row,2].Text = GUIFunction.GetString(value.RegisterDate);

//            YearMonth yearMonth = (YearMonth)facadeVehicleList.CalculateAge(Convert.ToDateTime(fpsVehicleList_Sheet1.Cells[row,2].Text));
//            fpsVehicleList_Sheet1.Cells[row,3].Text = Convert.ToString(yearMonth.Year);
//            fpsVehicleList_Sheet1.Cells[row,4].Text = Convert.ToString(yearMonth.Month);
//            fpsVehicleList_Sheet1.Cells[row,5].Text = GUIFunction.GetString(value.AModel.ABrand.AName.English);
//            fpsVehicleList_Sheet1.Cells[row,6].Text = GUIFunction.GetString(value.AModel.AName.English);
//            fpsVehicleList_Sheet1.Cells[row,7].Text = GUIFunction.GetString(value.AKindOfVehicle);
//        }
//        private void bindForm()
//        {
//            if (facadeVehicleList.ObjVehicleList != null)
//            {
//                int iRow = facadeVehicleList.ObjVehicleList.Count;
//                fpsVehicleList_Sheet1.RowCount = iRow;
//                for(int i=0; i<iRow; i++)
//                {
//                    bindVehicle(i, facadeVehicleList.ObjVehicleList[i]);
//                }				
//            }
//        }
//        private void enableButton(bool enable)
//        {
			
//        }

//        private void clearForm()
//        {
//            fpsVehicleList_Sheet1.RowCount = 0;
//            cmdOK.Enabled = false;
//        }

////		============================== Base Event ==============================
//        public void InitForm()
//        {
//            try
//            {
//                if(vehicleOutInsurance)
//                {
//                    if(facadeVehicleList.DisplayVehicleOutInsurance(conditionStartDate, conditionEndDate))
//                    {
//                        bindForm();
//                    }
//                    else
//                    {
//                        clearForm();
//                    }
//                }
//                else
//                {
//                    if(isVehicleAssign)
//                    {
//                        if (facadeVehicleList.DisplayVehicleIsAssign())
//                        {
//                            bindForm();
//                        }
//                        else
//                        {
//                            selected = false;
//                            isVehicleAssign = false;
//                            clearForm();
//                        }				
//                    }
//                    else
//                    {
//                        if (facadeVehicleList.DisplayVehicle(isVehicleAvailable))
//                        {
//                            bindForm();
//                        }
//                        else
//                        {
//                            selected = false;
//                            clearForm();
//                        }
//                    }
//                }
//            }
//            catch(SqlException sqlex)
//            {
//                Message(sqlex);
//            }
//            catch(AppExceptionBase ex)
//            {
//                Message(ex);
//            }
//            catch(Exception ex)
//            {
//                Message(ex);
//            }
//        }

//        public void RefreshForm()
//        {
//            InitForm();
//        }

//        public void PrintForm()
//        {
//        }

//        public void ExitForm()
//        {
//            Dispose(true);
//        }

//        private void EditEvent()
//        {
//            selected = true;
//            this.Hide();
//        }
////		==============================Event ==============================
//        private void cmdCancel_Click(object sender, System.EventArgs e)
//        {
//            selected = false;
//            this.Hide();
//        }

//        private void cmdOK_Click(object sender, System.EventArgs e)
//        {
//            EditEvent();
//        }

//        private void frmVehicleList_Load(object sender, System.EventArgs e)
//        {
//            InitForm();
//        }

//        private void fpsVehicleList_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
//        {
//            if(!e.ColumnHeader)
//            {
//                EditEvent();
//            }
//        }
//    }
//}
