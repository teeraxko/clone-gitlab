using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Presentation.CommonGUI;
using Facade.VehicleFacade;
using Entity.VehicleEntities;
using SystemFramework.AppConfig;
using SystemFramework.AppException;
using Facade.CommonFacade;
using System.Data.SqlClient;
using SystemFramework.AppMessage;

namespace Presentation.VehicleGUI
{
    public partial class FrmModel : ChildFormBase, IMDIChildForm
    {
        #region - Private -
        private bool isReadonly = true;
        private FrmModelEntry frmEntry;
        private frmMain mdiParent;

        //============================== Property ==============================
        private ModelFacade facadeModel;
        public ModelFacade FacadeModel
        {
            get { return facadeModel; }
        }

        private int SelectedRow
        {
            get{return dtgModel.CurrentRow.Index;}
        }

        private string SelectedKey
        {
            get { return dtgModel[0, SelectedRow].Value.ToString(); }
        }

        private Model SelectedModel
        {
            get{return facadeModel.AModelList[SelectedKey];}
        }
        #endregion


        public Brand Brand
        {
            get{return facadeModel.AModelList.ABrand;}
        }

        //============================== Constructor ==============================
        public FrmModel() : base()
        {
            InitializeComponent();
            newObject();
            isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleVehicleModel");
            this.title = UserProfile.GetFormName("miVehicle", "miVehicleVehicleModel");
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miVehicle", "miVehicleVehicleModel");
        }

        private void newObject()
        {
            facadeModel = new ModelFacade();
            frmEntry = new FrmModelEntry(this);
        }

        //==============================Private method ==============================
        private void bindModel(int row, Model aModel)
        {
            dtgModel[0, row].Value = aModel.EntityKey;
            dtgModel[1, row].Value = aModel.Code;
            dtgModel[2, row].Value = aModel.AName.English;
            dtgModel[3, row].Value = aModel.AModelType.AName.Thai;
            dtgModel[4, row].Value = GUIFunction.GetString(aModel.GearType);
            dtgModel[5, row].Value = GUIFunction.GetString(aModel.BreakType);
            dtgModel[6, row].Value = aModel.AGasolineType.AName.Thai;
            dtgModel[7, row].Value = aModel.EngineCC;
            dtgModel[8, row].Value = aModel.NoOfSeat;
        }

        private void bindForm()
        {
            dtgModel.RowCount = 0;

            int ModelCount = facadeModel.AModelList.Count;
            if (ModelCount > 0)
            {
                for (int i = 0; i < ModelCount; i++)
                {
                    dtgModel.RowCount++;
                    bindModel(i, facadeModel.AModelList[i]);
                }
                mdiParent.RefreshMasterCount();
            }
            else
            {
                clearForm();
            }
        }

        private void enableButton1(bool enable)
        {
            mniUpdate.Enabled = enable;
            btnUpdate.Enabled = enable;
            mniDelete.Enabled = enable;
            btnDelete.Enabled = enable;
        }

        private void enableButton2(bool enable)
        {
            btnAdd.Enabled = enable;
            mniAdd.Enabled = enable;
        }

        private void enableButtonAll(bool enable)
        {
            enableButton1(enable);
            enableButton2(enable);
        }

        private void clearForm()
        {
            dtgModel.RowCount = 0;
            enableButton1(false);
        }

        private void InitCombo()
        {
            cboBrandCode.SelectedIndex = -1;
            cboBrandCode.Text = "";
        }

        private void hideCase()
        {
            dtgModel.Hide();
            btnAdd.Hide();
            btnUpdate.Hide();
            btnDelete.Hide();
            InitCombo();
        }

        private void showCase()
        {
            dtgModel.Show();
            btnAdd.Show();
            btnUpdate.Show();
            btnDelete.Show();
        }
        private void enableCase(bool enable)
        {
            cboBrandCode.Enabled = enable;
            btnShow.Enabled = enable;
        }

        //==========================Public Method========================
        public bool AddRow(Model aModel, Vendor vendor)
        {
            if (facadeModel.InsertModel(aModel, vendor))
            {
                dtgModel.RowCount++;
                bindModel(dtgModel.RowCount - 1, aModel);
                enableButton1(true);
                mdiParent.RefreshMasterCount();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateRow(Model aModel, Vendor vendor)
        {
            if (facadeModel.UpdateModel(aModel, vendor))
            {
                bindModel(SelectedRow, aModel);
                return true;
            }
            else
            {
                return false;
            }
        }
        private void DeleteRow()
        {
            if (facadeModel.DeleteModel(SelectedModel))
            {
                if (dtgModel.RowCount > 1)
                {
                    dtgModel.Rows.RemoveAt(SelectedRow);
                }
                else
                {
                    clearForm();
                }
                mdiParent.RefreshMasterCount();
            }
        }

        //==============================Public method ==============================
        public override int MasterCount()
        {
            return facadeModel.AModelList.Count;
        }


        //============================== Base Event ==============================
        public void InitForm()
        {
            try
            {
                mdiParent.EnableNewCommand(false);
                mdiParent.EnableDeleteCommand(false);
                mdiParent.EnableRefreshCommand(false);
                mdiParent.EnablePrintCommand(false);
                clearMainMenuStatus();

                newObject();
                mdiParent.RefreshMasterCount();

                cboBrandCode.DataSource = facadeModel.DataSourceBrand;

                enableCase(true);
                clearForm();
                hideCase();
                enableButtonAll(true);
                InitCombo();
            }
            catch (AppExceptionBase ex)
            { Message(ex); }
            catch (Exception ex)
            { Message(ex); }
        }

        public void RefreshForm()
        {
            mdiParent.EnableNewCommand(true);
            mdiParent.EnableDeleteCommand(false);
            mdiParent.EnableRefreshCommand(true);
            mdiParent.EnablePrintCommand(true);
            MainMenuNewStatus = true;
            MainMenuDeleteStatus = false;
            MainMenuRefreshStatus = true;
            MainMenuPrintStatus = true;

            try
            {
                Brand cboItem = (Brand)cboBrandCode.SelectedItem;

                if (cboItem == null)
                {
                    Message(MessageList.Error.E0005, "ยี่ห้อรถ");
                    cboBrandCode.Focus();
                }
                else
                {
                    if (facadeModel.DisplayModel(cboItem.Code))
                    {
                        enableButtonAll(true);
                    }
                    else
                    {
                        clearForm();
                        enableButton2(true);
                    }
                    enableCase(false);
                    showCase();
                    bindForm();
                }                
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
                hideCase();
                enableCase(true);
            }
            catch (Exception ex)
            {
                Message(ex);
            }

            if (isReadonly)
            {
                btnAdd.Enabled = false;
                mniAdd.Enabled = false;
                btnDelete.Enabled = false;
                mniDelete.Enabled = false;
            }
        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            Dispose(true);
        }

        private void AddEvent()
        {
            try
            {
                frmEntry = new FrmModelEntry(this);
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
            finally
            {
            }
        }

        private void EditEvent()
        {
            try
            {
                frmEntry = new FrmModelEntry(this);
                frmEntry.InitEditAction(SelectedModel);
                frmEntry.ThaiModelName();
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
            finally
            {
            }
        }

        private void DeleteEvent()
        {
            try
            {
                if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
                {
                    DeleteRow();
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
            finally
            {
            }
        }

        //==============================Event ==============================
        private void FrmModel_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEvent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EditEvent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteEvent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void dtgModel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EditEvent();
            }
        }

        private void mniAdd_Click(object sender, EventArgs e)
        {
            AddEvent();
        }

        private void mniUpdate_Click(object sender, EventArgs e)
        {
            EditEvent();
        }

        private void mniDelete_Click(object sender, EventArgs e)
        {
            DeleteEvent();
        }
    }
}