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
    public partial class FrmPurchaseOrderList : ChildFormBase, IMDIChildForm
    {
        #region Private Variable
        private VehiclePurchasingFacade facadeVehiclePurchasing;
        private FrmPurchaseOrderEntry frmEntry;
        private frmMain mdiParent;
        private const string VEHICLE_PURCHASE_NO = "PTB-P-";
        private const string CANCEL_STATUS = "Cancel";
        #endregion

        #region Property
        public VehiclePurchasingFacade FacadeVehiclePurchasing
        {
            get { return facadeVehiclePurchasing; }
        }

        private int selectedRow
        {
            get { return dtgPO.CurrentRow.Index; }
        }

        private string selectedKey
        {
            get { return dtgPO[1, selectedRow].Value.ToString(); }
        }

        private string selectedKeyField(int keyField)
        {
            return dtgPO[keyField, selectedRow].Value.ToString();
        }

        private VehicleQuotation selectedVehicleQuotation
        {
            get
            {
                if (dtgPO.CurrentRow != null)
                {
                    VehicleQuotation vehicleQuotation = new VehicleQuotation();
                    VehiclePurchasing vehiclePurchasing = new VehiclePurchasing();
                    vehiclePurchasing.PurchasNo = new DocumentNo(selectedKey);

                    if (selectedKeyField(7) != "")
                    {
                        vehicleQuotation.QuotationNo = new DocumentNo(selectedKeyField(7));
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

        private VehiclePurchasing selectedVehiclePurchasing
        {
            get 
            {
                if (dtgPO.Rows[selectedRow].Tag != null)
                {
                    return (VehiclePurchasing)dtgPO.Rows[selectedRow].Tag;
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

        #region Constructor
        public FrmPurchaseOrderList()
        {

            InitializeComponent();
            facadeVehiclePurchasing = new VehiclePurchasingFacade();
        } 
        #endregion

        #region IMDIChildForm Members

        public override int MasterCount()
        {
            return 0;
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miPO", "miPO");
        }
        #endregion

        #region IMDIChildFormGUI Members
        public void InitForm()
        {
            mdiParent.EnableNewCommand(false);
            MainMenuNewStatus = false;
            mdiParent.EnableRefreshCommand(false);
            MainMenuRefreshStatus = false;
            mdiParent.EnablePrintCommand(false);
            MainMenuPrintStatus = false;

            enableAmend(false);
            visibleForm(false);
            clearForm();
        }

        public void RefreshForm()
        {
            if (mdiParent != null)
            {
                mdiParent.EnableNewCommand(true);
                MainMenuNewStatus = true;
                mdiParent.EnableRefreshCommand(true);
                MainMenuRefreshStatus = true;
            }

            searchEvent();
        }

        public void PrintForm()
        {}

        public void ExitForm()
        {
            this.Close();
        }

        private void enableAmend(bool value)
        {
            btnAdd.Enabled = true;
            btnEdit.Enabled = value;
            btnCancelPO.Enabled = value;
        }

        private void clearForm()
        {
            txtPOYY.Text = "";
            txtPOMM.Text = "";
            txtPOXXX.Text = "";
            dtpFromDate.Value = DateTime.Today.Date;
            gpbShowData.Enabled = true;
        }

        private void visibleForm(bool value)
        {
            gpbPODetail.Visible = value;
            dtgPO.Visible = value;
            btnAdd.Visible = value;
            btnEdit.Visible = value;
            btnCancelPO.Visible = value;
        }

        private bool validateCancel()
        {
            if (selectedKeyField(6) != "")
            {
                ContractStatus contractStatus = new ContractStatus();
                contractStatus.Code = ContractStatus.CONTRACT_STS_CREATED;

                if (facadeVehiclePurchasing.GetPurchasingContractByContractStatus(selectedVehiclePurchasing, contractStatus).Count > 0)
                {
                    Message(MessageList.Error.E0013, "ยกเลิกใบสั่งซื้อได้", "เอกสารสัญญาได้ผ่านการอนุมัติเรียบร้อยแล้ว");
                    return false;
                }

                if (facadeVehiclePurchasing.GetPurchasingContractListByVehicleSelling(selectedVehiclePurchasing).Count > 0)
                {
                    Message(MessageList.Error.E0013, "ยกเลิกใบสั่งซื้อได้", "รถยนต์อยู่ในสถานะขายเรียบร้อยแล้ว");
                    return false;
                }
            }

            if (selectedVehiclePurchasing != null && selectedVehiclePurchasing.PurchaseStatus == PURCHAS_STATUS_TYPE.CANCEL)
            {
                Message(MessageList.Error.E0013, "ยกเลิกใบสั่งซื้อได้", "สถานะใบสั่งซื้อถูกยกเลิกไปแล้ว");
                return false;
            }

            return true;
        }
        #endregion

        #region Form Base Event

        private void purchaseNoChange()
        {
            if (txtPOYY.Text.Length == 2 && txtPOMM.Text.Length == 2 && txtPOXXX.Text.Length == 3)
            {
                searchEvent();
            }
            else
            {
                if (txtPOYY.Text.Length == 2)
                {
                    if (txtPOMM.Text.Length == 2)
                    {
                        txtPOXXX.Focus();
                    }
                    else
                    {
                        txtPOMM.Focus();
                    }
                }
                else
                {
                    txtPOYY.Focus();
                }
            }
        }

        private void bindFrom(List<VehiclePurchasing> list)
        {
            dtgPO.Rows.Clear();

            if (list.Count > 0 )
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
            dtgPO.Rows[row].Tag = vehiclePurchase;
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
                        if (dtgPO[6, row].Value.ToString() != string.Empty)
                        {
                            dtgPO[6, row].Value += ", ";
                        }

                        dtgPO[6, row].Value += entity.Contract != null ? entity.Contract.ContractNo.ToString() : string.Empty ;
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
        }
        #endregion

        #region Process Event
        private void searchEvent()
        {
            DateTime aIssueDate;
            gpbShowData.Enabled = false;

            if (dtpFromDate.Checked)
            {
                aIssueDate = dtpFromDate.Value.Date;
            }
            else
            {
                aIssueDate = new DateTime(1900, 01, 01);
            }

            try
            {
                List<VehiclePurchasing> list = null;
                VehiclePurchasing vehiclePurchasing = new VehiclePurchasing();
                string poYY, poMM, poXXX;
                poYY = (txtPOYY.Text == "" ? "" : txtPOYY.Text);
                poMM = (txtPOMM.Text == "" ? "" : txtPOMM.Text);
                poXXX = (txtPOXXX.Text == "" ? "" : txtPOXXX.Text);
                vehiclePurchasing.PurchasNo = new DocumentNo(DOCUMENT_TYPE.PURCHASING_VEHICLE, poYY, poMM, poXXX);

                using (VehiclePurchasingFacade facade = new VehiclePurchasingFacade())
                {
                    list = facade.SearchPurchaseOrder(vehiclePurchasing.PurchasNo, aIssueDate);              
                }

                if (list.Count > 0)
                {
                    visibleForm(true);
                    enableAmend(true);
                    bindFrom(list);
                }
                else
                {
                    visibleForm(true);
                    enableAmend(false);
                    dtgPO.Rows.Clear();

                    Message(MessageList.Error.E0004, " ข้อมูลที่ค้นหา");
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

        private void addEvent()
        {
            try
            {
                frmEntry = new FrmPurchaseOrderEntry(this);
                frmEntry.InitAddAction();
                frmEntry.ShowDialog();
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

        private void editEvent()
        {
            try
            {
                if (selectedVehicleQuotation.Purchasing != null)
                {
                    frmEntry = new FrmPurchaseOrderEntry(this);
                    frmEntry.InitEditAction(selectedVehicleQuotation);
                    frmEntry.ShowDialog();
                }
                else
                {
                    Message(MessageList.Error.E0005, " Vehicle Purchasing");
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

        private void cancelEvent()
        {
            try
            {
                if (validateCancel())
                {
                    if (Message(MessageList.Question.Q0015) == DialogResult.Yes)
                    {
                        if (selectedVehicleQuotation != null)
                        {
                            if (facadeVehiclePurchasing.CancelPurchaseOrder(selectedVehicleQuotation.Purchasing))
                            {
                                Message(MessageList.Information.I0001);
                                RefreshForm();
                            }
                        }
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

        public bool AddRow(VehiclePurchasing vehiclePurchasing, DocumentNo quotationNo)
        {
            using (VehiclePurchasingFacade facade = new VehiclePurchasingFacade())
            {
                if (facade.InsertPurchasing(vehiclePurchasing, quotationNo))
                {
                    RefreshForm();
                    enableAmend(true);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool UpdateRow(VehiclePurchasing vehiclePurchasing, DocumentNo quotationNo)
        {
            using (VehiclePurchasingFacade facade = new VehiclePurchasingFacade())
            {
                if (facade.UpdatePurchasing(vehiclePurchasing, quotationNo))
                {
                    RefreshForm();
                    enableAmend(true);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Cancel PO
        /// </summary>
        /// <param name="vehiclePurchasing"></param>
        /// <returns>true if cancel process is success</returns>
        public bool CancelRow(VehiclePurchasing vehiclePurchasing)
        {
            using (VehiclePurchasingFacade facade = new VehiclePurchasingFacade())
            {
                if (facade.CancelPurchaseOrder(vehiclePurchasing))
                {
                    RefreshForm();
                    enableAmend(true);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion

        #region Form Event
        private void FrmPurchaseOrderList_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
            this.WindowState = FormWindowState.Maximized;
        }

        private void txtPOYY_TextChanged(object sender, EventArgs e)
        {
            purchaseNoChange();
        }

        private void txtPOMM_TextChanged(object sender, EventArgs e)
        {
            purchaseNoChange();
        }

        private void txtPOXXX_TextChanged(object sender, EventArgs e)
        {
            purchaseNoChange();
        }

        private void txtPOYY_DoubleClick(object sender, EventArgs e)
        {
            searchEvent();
        }

        private void txtPOMM_DoubleClick(object sender, EventArgs e)
        {
            searchEvent();
        }

        private void txtPOXXX_DoubleClick(object sender, EventArgs e)
        {
            searchEvent();
        }

        private void txtPOYY_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!IsNumericChar(e.KeyChar))
            {
                e.KeyChar = (Char)Keys.None; //char = '\0'
            }
        }

        private void txtPOMM_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!IsNumericChar(e.KeyChar))
            {
                e.KeyChar = (Char)Keys.None; //char = '\0'
            }
        }

        private void txtPOXXX_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!IsNumericChar(e.KeyChar))
            {
                e.KeyChar = (Char)Keys.None; //char = '\0'
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchEvent();
        }

        private void dtgPO_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                editEvent();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addEvent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            editEvent();
        }

        private void btnCancelPO_Click(object sender, EventArgs e)
        {
            cancelEvent();
        }

        private void mniAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Enabled)
            {
                addEvent();
            }
        }

        private void mniEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Enabled == true)
            {
                editEvent();
            }
        }

        private void mniCancelPO_Click(object sender, EventArgs e)
        {
            if (btnCancelPO.Enabled == true)
            {
                cancelEvent();
            }
        }

        public bool IsNumericChar(char value)
        {
            switch (value)
            {
                case '0': return true;
                case '1': return true;
                case '2': return true;
                case '3': return true;
                case '4': return true;
                case '5': return true;
                case '6': return true;
                case '7': return true;
                case '8': return true;
                case '9': return true;
                case '\b': return true;
            }
            return false;
        }
        #endregion
    }
}
