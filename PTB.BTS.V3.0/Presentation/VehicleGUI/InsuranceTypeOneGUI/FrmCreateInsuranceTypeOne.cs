using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using SystemFramework.AppMessage;
using SystemFramework.AppException;
using SystemFramework.AppConfig;

using Entity.VehicleEntities;

using Facade.CommonFacade;
using Facade.VehicleFacade;

using Presentation.CommonGUI;

namespace Presentation.VehicleGUI.InsuranceTypeOneGUI
{
    public partial class FrmCreateInsuranceTypeOne : ChildFormBase, IMDIChildForm    
    {
        #region - Private -
        private bool isReadonly = true;
        private frmMain mdiParent;
        private FrmCreateInsuranceTypeOneEntry frmEntry; 
        #endregion -Private -       

        #region - Property -
        private CreateInsuranceTypeOneFacade facadeCreateInsuranceTypeOne;
        public CreateInsuranceTypeOneFacade FacadeCreateInsuranceTypeOne
        {
            get { return facadeCreateInsuranceTypeOne; }
        }

        private int SelectedRow
        {
            get { return dtgInsuranceTypeOne.CurrentRow.Index; }
        }

        private string SelectedKey
        {
            get { return dtgInsuranceTypeOne[0, SelectedRow].Value.ToString(); }
        }

        public InsuranceTypeOne selectedInsuranceTypeOne
        {
            get { return (InsuranceTypeOne)facadeCreateInsuranceTypeOne.ObjInsuranceTypeOneList[SelectedKey]; }
        }
        #endregion

        //================================= Constructor ================================
        public FrmCreateInsuranceTypeOne() : base()
        {
            InitializeComponent();
            newObject();
            isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleDocumentMaintainInsuranceTypeOne");
            this.title = UserProfile.GetFormName("miVehicle", "miVehicleDocumentMaintainInsuranceTypeOne");
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miVehicle", "miVehicleDocumentMaintainInsuranceTypeOne");
        }

        public override int MasterCount()
        {
            return facadeCreateInsuranceTypeOne.ObjInsuranceTypeOneList.Count;
        }

        //=============================== Private Method ================================	
        private void newObject()
        {
            facadeCreateInsuranceTypeOne = new CreateInsuranceTypeOneFacade();
            frmEntry = new FrmCreateInsuranceTypeOneEntry(this);
        }

        private void setComboBox()
        {
            cboInsuranceCompany.DataSource = facadeCreateInsuranceTypeOne.DataSourceInsuranceCompName;

            cboEndDate.Items.Clear();
            cboEndDate.Items.Add("");
            for (int i = 2005; i <= DateTime.Today.Year + 1; i++)
            {
                cboEndDate.Items.Add(i);
            }
        }


        private void visibleForm(bool value)
        {
            dtgInsuranceTypeOne.Visible = value;
            btnAdd.Visible = value;
            btnUpdate.Visible = value;
            btnDelete.Visible = value;
            btnAddVehicle.Visible = value;
        }

        private void enableAmend(bool value)
        {
            btnUpdate.Enabled = value;
            btnDelete.Enabled = value;
            mniUpdate.Enabled = value;
            mniDelete.Enabled = value;
            btnAddVehicle.Enabled = value;
        }

        private void clearForm()
        {
            gpbInsuranceTypeOne.Enabled = true;
            cboEndDate.SelectedIndex = -1;
            cboInsuranceCompany.SelectedIndex = 0;
            dtgInsuranceTypeOne.RowCount = 0;
            enableAmend(false);            
        }

        private void bindInsuranceTypeOne(int row, InsuranceTypeOne value)
        {
            dtgInsuranceTypeOne[0, row].Value = value.EntityKey.ToString();
            dtgInsuranceTypeOne[1, row].Value = value.PolicyNo.ToString();
            dtgInsuranceTypeOne[2, row].Value = value.APeriod.From.ToShortDateString();
            dtgInsuranceTypeOne[3, row].Value = value.APeriod.To.ToShortDateString();
            dtgInsuranceTypeOne[4, row].Value = facadeCreateInsuranceTypeOne.CountData(value);
            dtgInsuranceTypeOne[5, row].Value = value.InsuranceInchargeName.ToString();
            dtgInsuranceTypeOne[6, row].Value = value.InsuranceInchargeTelNo.ToString();        
        }

        private void bindForm()
        {
            dtgInsuranceTypeOne.RowCount = 0;

            if (facadeCreateInsuranceTypeOne.ObjInsuranceTypeOneList.Count > 0)
            {
                for (int i = 0; i < facadeCreateInsuranceTypeOne.ObjInsuranceTypeOneList.Count; i++)
                {
                    dtgInsuranceTypeOne.RowCount++;
                    bindInsuranceTypeOne(i, facadeCreateInsuranceTypeOne.ObjInsuranceTypeOneList[i]);
                }
            }            
        }

        //		==========================Public Method========================
        public bool AddRow(InsuranceTypeOne value)
        {
            if (facadeCreateInsuranceTypeOne.InsertInsuranceTypeOne(value))
            {
                dtgInsuranceTypeOne.RowCount++;
                bindInsuranceTypeOne(dtgInsuranceTypeOne.RowCount - 1, value);
                enableAmend(true);
                mdiParent.RefreshMasterCount();
                return true;
            }
            return false;
        }

        public bool UpdateRow(InsuranceTypeOne value)
        {
            if (facadeCreateInsuranceTypeOne.UpdateInsuranceTypeOne(value))
            {
                bindInsuranceTypeOne(SelectedRow, value);
                return true;
            }
            return false;
        }

        private void addEvent()
        {
            try
            {
                frmEntry = new FrmCreateInsuranceTypeOneEntry(this);
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

        private void updateEvent()
        {
            try
            {
                frmEntry = new FrmCreateInsuranceTypeOneEntry(this);
                frmEntry.InitEditAction(selectedInsuranceTypeOne);
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

        private void deleteEvent()
        {
            try
            {
                if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
                {
                    if (facadeCreateInsuranceTypeOne.DeleteInsuranceTypeOne(selectedInsuranceTypeOne))
                    {
                        if (dtgInsuranceTypeOne.RowCount > 1)
                        {
                            dtgInsuranceTypeOne.Rows.RemoveAt(SelectedRow);
                        }
                        else
                        {
                            dtgInsuranceTypeOne.RowCount = 0;
                            enableAmend(false);
                        }

                        mdiParent.RefreshMasterCount();
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

        //============================== Base Event ==============================
        public void InitForm()
        {
            visibleForm(false);
            newObject();
            setComboBox();
            clearForm();
            gpbInsuranceTypeOne.Enabled = true;

            mdiParent.EnableNewCommand(true);
            mdiParent.EnableRefreshCommand(true);
            MainMenuNewStatus = true;
            MainMenuRefreshStatus = true;            
        }

        public void RefreshForm()
        {
            try
            {
                visibleForm(true);
                gpbInsuranceTypeOne.Enabled = false;

                if (facadeCreateInsuranceTypeOne.DisplayInsuranceTypeOne(cboEndDate.Text, cboInsuranceCompany.SelectedText))
                {
                    enableAmend(true);
                    bindForm();
                }
                else
                {
                    enableAmend(false);
                    dtgInsuranceTypeOne.RowCount = 0;
                }

                mdiParent.RefreshMasterCount();
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

            if (isReadonly)
            {
                mniAdd.Enabled = false;
                btnAdd.Enabled = false;
                enableAmend(false);
            }
        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            this.Close();
        }


        //============================== Event ==============================
        private void FrmCreateInsuranceTypeOne_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnShowData_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addEvent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateEvent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteEvent();
        }

        private void mniAdd_Click(object sender, EventArgs e)
        {
            addEvent();
        }

        private void mniUpdate_Click(object sender, EventArgs e)
        {
            updateEvent();
        }

        private void mniDelete_Click(object sender, EventArgs e)
        {
            deleteEvent();
        }

        private void dtgInsuranceTypeOne_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                updateEvent();
            }
        }

        private void btnAddVehicle_Click(object sender, EventArgs e)
        {
            FrmVehicleInsuranceTypeOne objfrm = new FrmVehicleInsuranceTypeOne(selectedInsuranceTypeOne);
            objfrm.MdiParent = (frmMain)this.MdiParent;
            this.Close();
            objfrm.Show();
        }
    }
}

