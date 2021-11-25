using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Presentation.CommonGUI;
using Entity.VehicleEntities;
using Facade.VehicleFacade;
using Facade.CommonFacade;
using ictus.Common.Entity.Time;
using System.Data.SqlClient;
using SystemFramework.AppException;

namespace Presentation.VehicleGUI
{
    public partial class FrmVehicleList : EntryFormBase
    {
        #region - Private -
        private int SelectedRow
        {
            get { return dtgVehicleList.CurrentRow.Index; }
        }

        private string SelectedKey
        {
            get { return dtgVehicleList[0, SelectedRow].Value.ToString(); }
        }

        public Vehicle SelectedVehicle
        {
            get { return facadeVehicleList.ObjVehicleList[SelectedKey]; }
        }

        private bool selected;
        public bool Selected
        {
            get { return selected; }
        }
        #endregion

        //============================== Property ==============================
        private VehicleListFacade facadeVehicleList;
        public VehicleListFacade FacadeVehicleList
        {
            get { return facadeVehicleList; }
        }

        public string ConditionPlatePrefix
        {
            set { facadeVehicleList.ConditionVehicle.PlatePrefix = value; }
        }

        public string ConditionPlateRunningNo
        {
            set { facadeVehicleList.ConditionVehicle.PlateRunningNo = value; }
        }

        public string ConditionPurchaseNo
        {
            set { facadeVehicleList.ConditionPurchasing = value; }
        }

        private bool isVehicleAvailable = false;
        public bool IsVehicleAvailable
        {
            set { isVehicleAvailable = value; }
        }

        private bool vehicleOutInsurance = false;
        public bool VehicleOutInsurance
        {
            set { vehicleOutInsurance = value; }
        }

        private bool isVehicleAssign = false;
        public bool IsVehicleAssign
        {
            set { isVehicleAssign = value; }
        }

        private bool isVehiclePO = false;
        public bool IsVehiclePO
        {
            set { isVehiclePO = value; }
        }

        private bool isVehicleCalculation = false;
        public bool IsVehicleCalculation
        {
            set { isVehicleCalculation = value; }
        }

        private DateTime conditionStartDate;
        public DateTime ConditionStartDate
        {
            set { conditionStartDate = value; }
        }

        private DateTime conditionEndDate;
        public DateTime ConditionEndDate
        {
            set { conditionEndDate = value; }
        }

        //============================== Constructor ==============================
        public FrmVehicleList() : base()
        {
            InitializeComponent();
            facadeVehicleList = new VehicleListFacade();
        }

        //============================== private method ==============================
        private void bindVehicle(int row, Vehicle value)
        {
            dtgVehicleList[0, row].Value = value.EntityKey;
            dtgVehicleList[1, row].Value = value.PlateNo;
            dtgVehicleList[2, row].Value = value.RegisterDate;

            YearMonth yearMonth = (YearMonth)facadeVehicleList.CalculateAge(Convert.ToDateTime(dtgVehicleList[2, row].Value));
            dtgVehicleList[3, row].Value = yearMonth.Year;
            dtgVehicleList[4, row].Value = yearMonth.Month;
            dtgVehicleList[5, row].Value = value.AModel.ABrand.AName.English;
            dtgVehicleList[6, row].Value = value.AModel.AName.English;
            dtgVehicleList[7, row].Value = GUIFunction.GetString(value.AKindOfVehicle);
            dtgVehicleList[8, row].Value = value.ChassisNo;
        }

        private void bindForm()
        {
            dtgVehicleList.RowCount = 0;

            if (facadeVehicleList.ObjVehicleList != null)
            {
                for (int i = 0; i < facadeVehicleList.ObjVehicleList.Count; i++)
                {
                    dtgVehicleList.RowCount++;
                    bindVehicle(i, facadeVehicleList.ObjVehicleList[i]);
                }
            }
        }

        private void clearForm()
        {
            dtgVehicleList.RowCount = 0;
            btnOK.Enabled = false;
        }

        //============================== Base Event ==============================
        public void InitForm()
        {
            try
            {
                if (vehicleOutInsurance)
                {
                    if (facadeVehicleList.DisplayVehicleOutInsurance(conditionStartDate, conditionEndDate))
                    {
                        bindForm();
                    }
                    else
                    {
                        clearForm();
                    }
                }
                else if (isVehicleAssign)
                {
                    //TODO : Ya
                    if (facadeVehicleList.DisplayVehicleIsAssign(conditionStartDate,conditionEndDate))
                    {
                        bindForm();
                    }
                    else
                    {
                        selected = false;
                        isVehicleAssign = false;
                        clearForm();
                    }
                }
                else if (isVehicleAvailable)
                {
                    if (facadeVehicleList.DisplayVehicleActiveList(conditionStartDate, conditionEndDate))
                    {
                        bindForm();
                    }
                    else
                    {
                        selected = false;
                        clearForm();
                    }
                }
                // add by Thawatchai B. 08/11/08
                else if (isVehiclePO)
                {
                    if (facadeVehicleList.DisplayVehicleByPO())
                    {
                        bindForm();
                    }
                    else
                    {
                        selected = false;
                        clearForm();
                    }
                }
                // end add
                else if (isVehicleCalculation)
                {
                    if (facadeVehicleList.DisplayVehicleByCalculation())
                    {
                        bindForm();
                    }
                    else
                    {
                        selected = false;
                        clearForm();
                    }
                }

                else
                {
                    if (facadeVehicleList.DisplayVehicle())
                    {
                        bindForm();
                    }
                    else
                    {
                        selected = false;
                        clearForm();
                    }
                }
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

        //==============================Event ==============================
        private void dtgVehicleList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EditEvent();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EditEvent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            selected = false;
            this.Hide();
        }

        private void FrmVehicleList_Load(object sender, EventArgs e)
        {
            InitForm();
        }
    }
}