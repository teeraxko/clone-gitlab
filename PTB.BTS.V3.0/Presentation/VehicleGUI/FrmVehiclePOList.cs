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


namespace Presentation.VehicleGUI
{
    public partial class FrmVehiclePOList : EntryFormBase
    {
        #region Private
        private VehiclePurchasingFacade facadeVehiclePurchasing;
        private const string CANCEL_STATUS = "Cancel";
        #endregion

        #region Property
        public VehiclePurchasingFacade FacadeVehiclePurchasing
        {
            get { return facadeVehiclePurchasing; }
        }

        private int SelectedRow
        {
            get { return dtgPO.CurrentRow.Index; }
        }

        private string SelectedKey
        {
            get { return dtgPO[1, SelectedRow].Value.ToString(); }
        }

        private string SelectedKeyField(int keyField)
        {
            return dtgPO[keyField, SelectedRow].Value.ToString();
        }

        public VehicleQuotation SelectedVehiclePurchasing
        {
            get
            {
                if (dtgPO.CurrentRow != null)
                {
                    VehicleQuotation vehicleQuotation = new VehicleQuotation();
                    VehiclePurchasing vehiclePurchasing = new VehiclePurchasing();
                    vehiclePurchasing.PurchasNo = new DocumentNo(SelectedKey);
                    if (SelectedKeyField(7) != "")
                    {
                        vehicleQuotation.QuotationNo = new DocumentNo(SelectedKeyField(7));
                    }
                    vehicleQuotation.Purchasing = vehiclePurchasing;
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

        private bool isPOAvailable = false;
        public bool IsPOAvailable
        {
            set { isPOAvailable = value; }
        }
        #endregion

        #region Constructor
        public FrmVehiclePOList()
            : base()
        {
            InitializeComponent();
            facadeVehiclePurchasing = new VehiclePurchasingFacade();
        } 
        #endregion

        #region IMDIChildForm Members

        public int MasterCount()
        {
            return 0;
        }

        public string FormID()
        {
            return UserProfile.GetFormID("miVehiclePOList", "miVehiclePOList");
        }
        #endregion

        #region IMDIChildFormGUI Members

        public void InitForm(VehiclePurchasing vehiclePurchasing)
        {
            try
            {
                List<VehiclePurchasing> list = null;

                using (VehiclePurchasingFacade facade = new VehiclePurchasingFacade())
                {
                    list = facade.SearchPurchaseOrderByVehicle(vehiclePurchasing.PurchasNo);
                }

                if (list.Count > 0)
                {
                    bindFrom(list);
                }
                else
                {
                    dtgPO.Rows.Clear();
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
        }

        public void PrintForm()
        {

        }

        public void ExitForm()
        {
            this.Close();
        }

        private void enableAmend(bool value)
        {
            btnOK.Enabled = true;
            btnCancel.Enabled = value;
        }

        private void clearForm()
        {
            dtgPO.Rows.Clear();
        }

        #endregion

        #region Form Base Event

        private void bindFrom(List<VehiclePurchasing> list)
        {
            dtgPO.Rows.Clear();

            if (list.Count > 0)
            {
                dtgPO.RowCount = list.Count;

                for (int i = 0; i < list.Count; i++)
                {
                    bindPurchasing(i, list[i]);
                }
            }
        }

        private void bindPurchasing(int row, VehiclePurchasing vehiclePurchase)
        {
            dtgPO[0, row].Value = row.ToString();
            dtgPO[1, row].Value = vehiclePurchase.PurchasNo.ToString();
            dtgPO[2, row].Value = vehiclePurchase.IssueDate.Date;
            dtgPO[3, row].Value = vehiclePurchase.Model.ABrand.AName.English;
            dtgPO[4, row].Value = vehiclePurchase.Model.AName.English;
            dtgPO[5, row].Value = vehiclePurchase.Vendor.ShortName;

            if (vehiclePurchase.PurchaseStatus == PURCHAS_STATUS_TYPE.APPROVE)
            {
                using (VehiclePurchasingFacade facade = new VehiclePurchasingFacade())
                {
                    #region Get Contract List
                    dtgPO[6, row].Value = string.Empty;

                    List<VehiclePurchasingContract> purchaseContractList = facade.GetPurchasingContractListByPurchase(vehiclePurchase);

                    foreach (VehiclePurchasingContract entity in purchaseContractList)
                    {
                        if (entity.Contract != null)
                        {
                            if (dtgPO[6, row].Value.ToString() != string.Empty)
                            {
                                dtgPO[6, row].Value += ", ";
                            }

                            dtgPO[6, row].Value += entity.Contract.ContractNo.ToString();
                        }
                    }
                    #endregion

                    #region Get Quotation

                    VehicleQuotation quotation = facade.GetQuotationByPurchaseNo(vehiclePurchase.PurchasNo);

                    dtgPO[7, row].Value = quotation.QuotationNo != null ? quotation.QuotationNo.ToString() : string.Empty;
                    #endregion
                }
            }
            else
            {
                dtgPO[6, row].Value = CANCEL_STATUS;
                dtgPO[7, row].Value = string.Empty;
            }

            dtgPO[8, row].Value = vehiclePurchase.VendorQuotationDate.Value.Date;
        }
        #endregion

        #region Process Event
        
        private void EditEvent()
        {
            selected = true;
            this.Hide();
        }

        #endregion

        #region Form Event
        private void dtgPO_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
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
            if (btnCancel.Enabled == true)
            {
                selected = false;
                this.Close();
            }
        }

        private void mniOK_Click(object sender, EventArgs e)
        {
            if (btnOK.Enabled == true)
            {
                EditEvent();
            }
        }

        private void mniCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Enabled == true)
            {
                selected = false;
                this.Close();
            }
        }

  

        #endregion
    }
}
