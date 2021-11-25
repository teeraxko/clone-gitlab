//using System;
//using System.Drawing;
//using System.Collections;
//using System.ComponentModel;
//using System.Windows.Forms;
//using System.Data.SqlClient;

//using Entity.ContractEntities;
//using Entity.CommonEntity;
//using Entity.AttendanceEntities;

//using Facade.ContractFacade;
//using Facade.CommonFacade;

//using Presentation.CommonGUI;

//using SystemFramework.AppException;
//using SystemFramework.AppMessage;
//namespace Presentation.ContractGUI
//{
//    public class frmContractList : EntryFormBase
//    {
//        #region Windows Form Designer generated code
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
//        private FarPoint.Win.Spread.FpSpread fpsContractList;
//        private FarPoint.Win.Spread.SheetView fpsContractList_Sheet1;
//        private System.Windows.Forms.Button cmdCancel;
//        private System.Windows.Forms.Button cmdOK;
//        private System.ComponentModel.Container components = null;
//        private void InitializeComponent()
//        {
//            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
//            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
//            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
//            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
//            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
//            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
//            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmContractList));
//            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType2 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
//            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
//            this.fpsContractList = new FarPoint.Win.Spread.FpSpread();
//            this.fpsContractList_Sheet1 = new FarPoint.Win.Spread.SheetView();
//            this.cmdCancel = new System.Windows.Forms.Button();
//            this.cmdOK = new System.Windows.Forms.Button();
//            ((System.ComponentModel.ISupportInitialize)(this.fpsContractList)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.fpsContractList_Sheet1)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // fpsContractList
//            // 
//            this.fpsContractList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
//            this.fpsContractList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
//            this.fpsContractList.Location = new System.Drawing.Point(16, 8);
//            this.fpsContractList.Name = "fpsContractList";
//            this.fpsContractList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
//                                                                                         this.fpsContractList_Sheet1});
//            this.fpsContractList.Size = new System.Drawing.Size(977, 367);
//            this.fpsContractList.TabIndex = 0;
//            this.fpsContractList.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsContractList_CellDoubleClick);
//            // 
//            // fpsContractList_Sheet1
//            // 
//            this.fpsContractList_Sheet1.Reset();
//            // Formulas and custom names must be loaded with R1C1 reference style
//            this.fpsContractList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
//            this.fpsContractList_Sheet1.ColumnCount = 8;
//            this.fpsContractList_Sheet1.RowCount = 0;
//            textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            textCellType1.DropDownButton = false;
//            this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 1).CellType = textCellType1;
//            this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "สถานะสัญญา";
//            this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "เลขที่สัญญา";
//            this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ประเภทสัญญา";
//            this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "ลูกค้า";
//            this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "วันที่เริ่มต้นสัญญา";
//            this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 6).Text = "วันที่สิ้นสุดสัญญา";
//            this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 7).Text = "ชนิดสัญญา";
//            this.fpsContractList_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
//            this.fpsContractList_Sheet1.Columns.Default.Resizable = false;
//            textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            textCellType2.DropDownButton = false;
//            this.fpsContractList_Sheet1.Columns.Get(0).CellType = textCellType2;
//            this.fpsContractList_Sheet1.Columns.Get(0).Visible = false;
//            this.fpsContractList_Sheet1.Columns.Get(1).AllowAutoSort = true;
//            this.fpsContractList_Sheet1.Columns.Get(1).Label = "สถานะสัญญา";
//            this.fpsContractList_Sheet1.Columns.Get(1).Width = 76F;
//            this.fpsContractList_Sheet1.Columns.Get(2).AllowAutoSort = true;
//            textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            textCellType3.DropDownButton = false;
//            this.fpsContractList_Sheet1.Columns.Get(2).CellType = textCellType3;
//            this.fpsContractList_Sheet1.Columns.Get(2).Label = "เลขที่สัญญา";
//            this.fpsContractList_Sheet1.Columns.Get(2).Width = 95F;
//            this.fpsContractList_Sheet1.Columns.Get(3).AllowAutoSort = true;
//            textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            textCellType4.DropDownButton = false;
//            this.fpsContractList_Sheet1.Columns.Get(3).CellType = textCellType4;
//            this.fpsContractList_Sheet1.Columns.Get(3).Label = "ประเภทสัญญา";
//            this.fpsContractList_Sheet1.Columns.Get(3).Width = 150F;
//            this.fpsContractList_Sheet1.Columns.Get(4).AllowAutoSort = true;
//            textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            textCellType5.DropDownButton = false;
//            this.fpsContractList_Sheet1.Columns.Get(4).CellType = textCellType5;
//            this.fpsContractList_Sheet1.Columns.Get(4).Label = "ลูกค้า";
//            this.fpsContractList_Sheet1.Columns.Get(4).Width = 228F;
//            this.fpsContractList_Sheet1.Columns.Get(5).AllowAutoSort = true;
//            dateTimeCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            dateTimeCellType1.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
//            dateTimeCellType1.DateDefault = new System.DateTime(2005, 10, 26, 15, 4, 9, 0);
//            dateTimeCellType1.DropDownButton = false;
//            dateTimeCellType1.TimeDefault = new System.DateTime(2005, 10, 26, 15, 4, 9, 0);
//            this.fpsContractList_Sheet1.Columns.Get(5).CellType = dateTimeCellType1;
//            this.fpsContractList_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
//            this.fpsContractList_Sheet1.Columns.Get(5).Label = "วันที่เริ่มต้นสัญญา";
//            this.fpsContractList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
//            this.fpsContractList_Sheet1.Columns.Get(5).Width = 100F;
//            this.fpsContractList_Sheet1.Columns.Get(6).AllowAutoSort = true;
//            dateTimeCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            dateTimeCellType2.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
//            dateTimeCellType2.DateDefault = new System.DateTime(2005, 10, 26, 15, 4, 12, 0);
//            dateTimeCellType2.DropDownButton = false;
//            dateTimeCellType2.TimeDefault = new System.DateTime(2005, 10, 26, 15, 4, 12, 0);
//            this.fpsContractList_Sheet1.Columns.Get(6).CellType = dateTimeCellType2;
//            this.fpsContractList_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
//            this.fpsContractList_Sheet1.Columns.Get(6).Label = "วันที่สิ้นสุดสัญญา";
//            this.fpsContractList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
//            this.fpsContractList_Sheet1.Columns.Get(6).Width = 100F;
//            this.fpsContractList_Sheet1.Columns.Get(7).AllowAutoSort = true;
//            textCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            textCellType6.DropDownButton = false;
//            this.fpsContractList_Sheet1.Columns.Get(7).CellType = textCellType6;
//            this.fpsContractList_Sheet1.Columns.Get(7).Label = "ชนิดสัญญา";
//            this.fpsContractList_Sheet1.Columns.Get(7).Width = 170F;
//            this.fpsContractList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
//            this.fpsContractList_Sheet1.RowHeader.Columns.Default.Resizable = false;
//            this.fpsContractList_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
//            this.fpsContractList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
//            this.fpsContractList_Sheet1.SheetName = "Sheet1";
//            this.fpsContractList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
//            // 
//            // cmdCancel
//            // 
//            this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
//            this.cmdCancel.Location = new System.Drawing.Point(498, 407);
//            this.cmdCancel.Name = "cmdCancel";
//            this.cmdCancel.TabIndex = 6;
//            this.cmdCancel.Text = "ยกเลิก";
//            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
//            // 
//            // cmdOK
//            // 
//            this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//            this.cmdOK.Location = new System.Drawing.Point(418, 407);
//            this.cmdOK.Name = "cmdOK";
//            this.cmdOK.TabIndex = 5;
//            this.cmdOK.Text = "ตกลง";
//            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
//            // 
//            // frmContractList
//            // 
//            this.AcceptButton = this.cmdOK;
//            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
//            this.CancelButton = this.cmdCancel;
//            this.ClientSize = new System.Drawing.Size(1010, 447);
//            this.Controls.Add(this.cmdCancel);
//            this.Controls.Add(this.cmdOK);
//            this.Controls.Add(this.fpsContractList);
//            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
//            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
//            this.Name = "frmContractList";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
//            this.Text = "รายการเอกสารสัญญา";
//            this.Load += new System.EventHandler(this.frmContractList_Load);
//            ((System.ComponentModel.ISupportInitialize)(this.fpsContractList)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.fpsContractList_Sheet1)).EndInit();
//            this.ResumeLayout(false);

//        }
//        #endregion

//        #region - Constant -
//            enum ContractListType
//            {
//                VEHICLE,
//                DRIVER_OTHER,
//                AVAILABLE,
//                NOT_SPECIFIC
//            }
//        #endregion
				
//        #region - Private - 
//        private int SelectedRow
//        {
//            get{return fpsContractList_Sheet1.ActiveRowIndex;}
//        }

//        private string SelectedKey
//        {
//            get{return fpsContractList_Sheet1.Cells[SelectedRow,0].Text;}
//        }

//        public ContractBase SelectedContract
//        {
//            get{return (ContractBase)facadeListContract.ObjContractList[SelectedKey];}
//        }

//        private bool selected;
//        public bool Selected
//        {
//            get{return selected;}
//        }
//        #endregion

////		============================== Property ==============================
//        private ContractListFacade facadeListContract;	
//        public ContractListFacade FacadeListContract
//        {
//            get{return facadeListContract;}
//        }

//        public Customer ConditionCustomer
//        {
//            set{facadeListContract.ConditionContract.ACustomerDepartment.ACustomer = value;}
//        }

//        public ContractType ConditionCONTRACT_TYPE
//        {
//            set{facadeListContract.ConditionContract.AContractType = value;}
//        }

//        public ContractStatus ConditionContractStatus
//        {
//            set{facadeListContract.ConditionContract.AContractStatus = value;}
//        }

//        public string ConditionYY
//        {
//            set{facadeListContract.YY = value;}
//        }

//        public string ConditionMM
//        {
//            set{facadeListContract.MM = value;}
//        }

//        public string ConditionXXX
//        {
//            set{facadeListContract.XXX = value;}
//        }

//        private ContractListType contractListType = ContractListType.NOT_SPECIFIC;
//        public bool IsVehicleContract
//        {
//            set
//            {
//                if(value)
//                {
//                    contractListType = ContractListType.VEHICLE;
//                }
//            }
//        }

//        public bool IsDOContract
//        {
//            set
//            {
//                if(value)
//                {
//                    contractListType = ContractListType.DRIVER_OTHER;
//                }
//            }
//        }

//        public bool IsAvailableContract
//        {
//            set
//            {
//                if(value)
//                {
//                    contractListType = ContractListType.AVAILABLE;
//                }
//            }
//        }

//        public TimePeriod ConditionTimePeriodFrom
//        {
//            set{facadeListContract.ConditionContract.APeriod = value;}
//        }

////		============================== Constructor ==============================
//        public frmContractList():base()
//        {
//            InitializeComponent();
//            facadeListContract = new ContractListFacade();
//        }
////		============================== private method ==============================
//        private void bindContract(int row, ContractBase value)
//        {
//            fpsContractList_Sheet1.Cells[row,0].Text = GUIFunction.GetString(value.EntityKey);
//            fpsContractList_Sheet1.Cells[row,1].Text = GUIFunction.GetString(value.AContractStatus);
//            fpsContractList_Sheet1.Cells[row,2].Text = GUIFunction.GetString(value.ContractNo.ToString());
//            fpsContractList_Sheet1.Cells[row,3].Text = GUIFunction.GetString(value.AContractType);
//            fpsContractList_Sheet1.Cells[row,4].Text = GUIFunction.GetString(value.ACustomerDepartment.ACustomer.AName.English);
//            fpsContractList_Sheet1.Cells[row,5].Text = GUIFunction.GetString(value.APeriod.From.Date.ToShortDateString());
//            fpsContractList_Sheet1.Cells[row,6].Text = GUIFunction.GetString(value.APeriod.To.Date.ToShortDateString());
//            fpsContractList_Sheet1.Cells[row,7].Text = GUIFunction.GetString(value.AKindOfContract.AName.Thai);
//        }
//        private void bindForm()
//        {
//            if (facadeListContract.ObjContractList != null)
//            {
//                int iRow = facadeListContract.ObjContractList.Count;
//                fpsContractList_Sheet1.RowCount = iRow;
//                for(int i=0; i<iRow; i++)
//                {
//                    bindContract(i, (ContractBase)facadeListContract.ObjContractList[i]);
//                }				
//            }
//        }
//        private void enableButton(bool enable)
//        {
			
//        }

//        private void clearForm()
//        {
//            fpsContractList_Sheet1.RowCount = 0;
//            cmdOK.Enabled = false;
//        }

////		============================== Base Event ==============================
//        public void InitForm()
//        {
//            try
//            {
//                switch(contractListType)
//                {
//                    case ContractListType.VEHICLE :
//                    {
//                        if (facadeListContract.DisplayVehicleContract())
//                        {
//                            bindForm();
//                        }
//                        else
//                        {
//                            selected = false;
//                            clearForm();
//                        }
//                        break;
//                    }
//                    case ContractListType.DRIVER_OTHER :
//                    {
//                        if (facadeListContract.DisplayDriverOtherContract())
//                        {
//                            bindForm();
//                        }
//                        else
//                        {
//                            selected = false;
//                            clearForm();
//                        }
//                        break;
//                    }
//                    case ContractListType.AVAILABLE :
//                    {
//                        if (facadeListContract.DisplayAvailableContract())
//                        {
//                            bindForm();
//                        }
//                        else
//                        {
//                            selected = false;
//                            clearForm();
//                        }
//                        break;
//                    }
//                    default :
//                    {
//                        if (facadeListContract.DisplayContract())
//                        {
//                            bindForm();
//                        }
//                        else
//                        {
//                            selected = false;
//                            clearForm();
//                        }
//                        break;
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

//        private void frmContractList_Load(object sender, System.EventArgs e)
//        {
//            InitForm();
//        }

//        private void fpsContractList_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
//        {
//            if(!e.ColumnHeader)
//            {
//                EditEvent();
//            }
//        }

//    }
//}
