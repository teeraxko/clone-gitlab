using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presentation.CommonGUI;

using Entity.VehicleEntities;
using Entity.CommonEntity;
using Entity.ContractEntities;
using Entity.VehicleEntities.VehicleLeasing;

using Facade.PiFacade;
using Facade.CommonFacade;
using Facade.VehicleFacade.VehicleLeasingFacade;

using SystemFramework.AppMessage;
using SystemFramework.AppConfig;
using SystemFramework.AppException;


namespace Presentation.VehicleGUI.VehicleLeasingGUI
{
    public partial class FrmCalculationQuotationList : EntryFormBase
    {
        #region - Private -
        private int SelectedRow
        {
            get { return dtgQuotation.CurrentRow.Index; }
        }

        private string SelectedKey
        {
            get { return dtgQuotation[1, SelectedRow].Value.ToString(); }
        }

        private string SelectedKeyField(int keyField)
        {
            return dtgQuotation[keyField, SelectedRow].Value.ToString();
        }

        public VehicleQuotation SelectedVehicleQuotation
        {
            get
            {
                if (dtgQuotation.CurrentRow != null)
                {
                    VehicleQuotation vehicleQuotation = new VehicleQuotation();
                    vehicleQuotation.QuotationNo = new DocumentNo(SelectedKey);
                    return vehicleQuotation;
                }
                else
                {
                    return null;
                }
            }

        }

        private bool selected;
        public bool Selected
        {
            get { return selected; }
        }
        #endregion

        //============================== Property ==============================
        private VehicleQuotationFacade  facadeQuotation;
        public VehicleQuotationFacade FacadeQuotation
        {
            get { return facadeQuotation; }
        }

        public string ConditionQuotationNo
        {
            set { facadeQuotation.ConditionQuotationNo = value; }
        }

        private bool isQuotationAvailable = false;
        public bool IsQuotationAvailable
        {
            set { isQuotationAvailable = value; }
        }

        private bool isQuotationCalculation = false;
        public bool IsQuotationCalculation
        {
            set { isQuotationCalculation = value; }
        }


        //============================== Constructor ==============================
        public FrmCalculationQuotationList() : base()
        {
            InitializeComponent();
            facadeQuotation = new VehicleQuotationFacade();
        }

        //============================== private method ==============================
        private void bindQuotation(int row, VehicleQuotation value, VehicleCalculation value2)
        {
            dtgQuotation[0, row].Value = row.ToString();
            dtgQuotation[1, row].Value = value.QuotationNo.ToString();
            if (value2.Customer != null)
            {
                dtgQuotation[2, row].Value = value2.Customer.AName.English.ToString();
            }
            else
            {
                dtgQuotation[2, row].Value = "";
            }
            if (value2.Customer != null)
            {
                dtgQuotation[3, row].Value = value2.Model.ABrand.AName.English.ToString();
            }
            else
            {
                dtgQuotation[2, row].Value = "";
            }
            if (value2.Customer != null)
            {
                dtgQuotation[4, row].Value = value2.Model.AName.English.ToString();
            }
            else
            {
                dtgQuotation[2, row].Value = "";
            }
            
            dtgQuotation[5, row].Value = value.IsCustomerAccept == true ? "Y" : "N";
            if (value.Purchasing.PurchasNo == null)
            { dtgQuotation[6, row].Value = ""; }
            else
            {
                dtgQuotation[6, row].Value = value.Purchasing.PurchasNo.ToString();
            }
            dtgQuotation[7, row].Value = value.IssueDate.Value.Day + "/" + value.IssueDate.Value.Month + "/" + value.IssueDate.Value.Year;
            if (value.VehicleContract.ContractNo == null)
            {
                dtgQuotation[8, row].Value = "";
            }
            else
            {
                dtgQuotation[8, row].Value = value.VehicleContract.ContractNo.ToString();
            }

        }

        private void bindFrom(List<VehicleQuotation> list, List<VehicleCalculation> list2)
        {
            dtgQuotation.Rows.Clear();

            if (list.Count > 0 && list2.Count > 0)
            {
                dtgQuotation.RowCount = list.Count;

                for (int i = 0; i < list.Count; i++)
                {
                    bindQuotation(i, list[i], list2[i]);
                }
            }
        }
        private void clearForm()
        {
            dtgQuotation.RowCount = 0;
        }

        //============================== Base Event ==============================
        public void InitForm(VehicleQuotation vehicleQuotation)
        {
            try
            {
                if (isQuotationAvailable)
                {
                    List<VehicleQuotation> list = null;
                    List<VehicleCalculation> list2 = null;
                    using (VehicleQuotationFacade facade = new VehicleQuotationFacade())
                    {
                        list = facade.GetQuotationListByQuotation(vehicleQuotation.QuotationNo.ToString());
                        list2 = new List<VehicleCalculation>();
                        foreach (VehicleQuotation entity in list)
                        {
                            VehicleCalculation vehicleCalculation = new VehicleCalculation();
                            using (VehicleCalculationFacade facade2 = new VehicleCalculationFacade())
                            {
                                vehicleCalculation = facade2.GetVehicleSearchConditionByQuotationNo(entity.QuotationNo);
                            }
                            list2.Add(vehicleCalculation);
                        }
                    }

                    if (list.Count > 0 && list2.Count > 0)
                    {
                        bindFrom(list, list2);
                    }
                    else
                    {
                        dtgQuotation.Rows.Clear();

                    }
                }
                else
                {
                    selected = false;
                    clearForm();
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
            //InitForm();
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
        private void dtgQuotation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditEvent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EditEvent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            selected = false;
            this.Close();
        }

        private void FrmVehicleList_Load(object sender, EventArgs e)
        {
            //InitForm();
        }
    }
}
