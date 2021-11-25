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
using Facade.VehicleFacade.VehicleLeasingFacade;
using ictus.Common.Entity.Time;
using System.Data.SqlClient;
using SystemFramework.AppException;

namespace Presentation.VehicleGUI.VehicleLeasingGUI
{
    public partial class FrmQuotationSearchVehicle : EntryFormBase
    {
        public event FrmQuotationSearchVehicleEventHandler SelectFinished;
        public event EventHandler SelectCanceled;

        ////#region - Private -
        //private int SelectedRow
        //{
        //    get { return dtgVehicleList.CurrentRow.Index; }
        //}

        //private string SelectedKey
        //{
        //    get { return dtgVehicleList[0, SelectedRow].Value.ToString(); }
        //}

        //public Vehicle SelectedVehicle
        //{
        //    get { return facadeVehicleQuotation.ObjVehicleList[SelectedKey]; }
        //}

        //private bool selected;
        //public bool Selected
        //{
        //    get { return selected; }
        //}
        //============================== Property ==============================
        //private VehicleQuotationFacade facadeVehicleQuotation;
        //public VehicleQuotationFacade FacadeVehicleQuotation
        //{
        //    get { return facadeVehicleQuotation; }
        //}

        //public string ConditionPlatePrefix
        //{
        //    set { facadeVehicleQuotation.ConditionVehicle.PlatePrefix = value; }
        //}

        //public string ConditionPlateRunningNo
        //{
        //    set { facadeVehicleQuotation.ConditionVehicle.PlateRunningNo = value; }
        //}

        //private bool isVehicleAvailable = false;
        //public bool IsVehicleAvailable
        //{
        //    set { isVehicleAvailable = value; }
        //}

        //private bool vehicleOutInsurance = false;
        //public bool VehicleOutInsurance
        //{
        //    set { vehicleOutInsurance = value; }
        //}

        //private bool isVehicleAssign = false;
        //public bool IsVehicleAssign
        //{
        //    set { isVehicleAssign = value; }
        //}

        //private DateTime conditionStartDate;
        //public DateTime ConditionStartDate
        //{
        //    set { conditionStartDate = value; }
        //}

        //private DateTime conditionEndDate;
        //public DateTime ConditionEndDate
        //{
        //    set { conditionEndDate = value; }
        //}
        //#endregion

        //======================= Public Method =======================

        private VehicleQuotationFacade facade = new VehicleQuotationFacade();
        private bool _isSelected = false;

        public FrmQuotationSearchVehicle()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Search vehicle list for quotation
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="num"></param>
        /// <param name="quotationType">Renewal = 0, Used = 1</param>
        public FrmQuotationSearchVehicle(string prefix, string num, int quotationType)
        {
            InitializeComponent();
            facade.FillVehicleForCreateQuotation(prefix,num,quotationType);
            PaintForm();
        }      

        private void PaintForm()
        {
            dtgVehicleList.RowCount = 0;

            if (facade.ObjVehicleList != null)
            {
                for (int i = 0; i < facade.ObjVehicleList.Count; i++)
                {
                    dtgVehicleList.RowCount++;
                    PaintGridRow(i, facade.ObjVehicleList[i]);
                }
            }

            btnOK.Enabled = dtgVehicleList.RowCount > 0;
        }

        private void PaintGridRow(int row, Vehicle value)
        {
            dtgVehicleList.Rows[row].Tag = value;
            dtgVehicleList[0, row].Value = value.EntityKey;
            dtgVehicleList[1, row].Value = value.PlateNo;
            dtgVehicleList[2, row].Value = value.RegisterDate;

            YearMonth yearMonth = (YearMonth)facade.CalculateAge(Convert.ToDateTime(dtgVehicleList[2, row].Value));
            dtgVehicleList[3, row].Value = yearMonth.Year;
            dtgVehicleList[4, row].Value = yearMonth.Month;
            dtgVehicleList[5, row].Value = value.AModel.ABrand.AName.English;
            dtgVehicleList[6, row].Value = value.AModel.AName.English;
            dtgVehicleList[7, row].Value = GUIFunction.GetString(value.AKindOfVehicle);
            dtgVehicleList[8, row].Value = value.ChassisNo;
        }
        //======================= Event ===============================
        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectVehicle(dtgVehicleList.CurrentRow.Index);
        }

        private void dtgVehicleList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectVehicle(e.RowIndex);
        }

        private void SelectVehicle(int rowIndex)
        {
            if (rowIndex >= 0)
            {
                _isSelected = true;
                Vehicle result = (Vehicle)dtgVehicleList.Rows[rowIndex].Tag;
                OnSelectFinished(new FrmQuotationSearchVehicleEventArgs(result));
                this.Close();
            }
        }

        private void OnSelectFinished(FrmQuotationSearchVehicleEventArgs e)
        {
            if (SelectFinished != null)
            {
                SelectFinished(this, e);
            }
        }

        private void OnSelectCanceled(EventArgs e)
        {
            if (SelectCanceled != null)
            {
                SelectCanceled(this, e);
            }
        }


       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void FrmQuotationSearchVehicle_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_isSelected)
            {
                OnSelectCanceled(new EventArgs());
            }
        }





    }

    public delegate void FrmQuotationSearchVehicleEventHandler(object sender, FrmQuotationSearchVehicleEventArgs e);
    public class FrmQuotationSearchVehicleEventArgs : EventArgs
    {
        public FrmQuotationSearchVehicleEventArgs(Vehicle vehicle)
        {
            _vehicle = vehicle;
        }
        private Vehicle _vehicle;
        public Vehicle Vehicle { get { return _vehicle; } }
    }


}
