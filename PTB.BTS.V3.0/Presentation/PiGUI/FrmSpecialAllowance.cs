using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Presentation.CommonGUI;

using Facade.PiFacade;
using ictus.PIS.PI.Entity;
using System.Data.SqlClient;
using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;


namespace Presentation.PiGUI
{
    public partial class FrmSpecialAllowance : ChildFormBase, IMDIChildForm
    {
        #region - Private -
        private bool isReadonly = true;
        private frmMain mdiParent;
        private FrmSpecialAllowanceEntry frmEntry;
        #endregion -Private -       

        #region - Property -
        private SpecialAllowanceFacade facadeSpecialAllowance;
        public SpecialAllowanceFacade FacadeSpecialAllowance
        {
            get { return facadeSpecialAllowance; }
        }

        private int SelectedRow
        {
            get { return dtgAllowance.CurrentRow.Index; }
        }

        private string SelectedKey
        {
            get { return dtgAllowance[0, SelectedRow].Value.ToString(); }
        }

        public SpecialAllowance selectedSpecialAllowance
        {
            get { return (SpecialAllowance)facadeSpecialAllowance.ObjSpecialAllowanceList[SelectedKey]; }
        }

        #endregion

        //================================= Constructor ================================

        public FrmSpecialAllowance() : base()
        {
            InitializeComponent();
            newObject();
            isReadonly = UserProfile.IsReadOnly("miPI", "miSpecialAllowance");
            this.title = UserProfile.GetFormName("miPI", "miSpecialAllowance");

        }
        public override string FormID()
        {
            return UserProfile.GetFormID("miPI", "miSpecialAllowance");
        }

        public override int MasterCount()
        {
            return facadeSpecialAllowance.ObjSpecialAllowanceList.Count;
        }
        //=============================== Private Method ================================	
        private void newObject()
        {
            facadeSpecialAllowance = new SpecialAllowanceFacade();
            frmEntry = new FrmSpecialAllowanceEntry(this);
        }

        private void enableAmend(bool value)
        {
            btnAdd.Enabled = true;
            mniAdd.Enabled = true;
            btnUpdate.Enabled = value;
            btnDelete.Enabled = value;
            mniUpdate.Enabled = value;
            mniDelete.Enabled = value;
        }

        private void clearForm()
        {
            dtgAllowance.RowCount = 0;
            enableAmend(false);
        }

        private void bindSpecealAllowance(int row, SpecialAllowance value)
        {
            dtgAllowance[0, row].Value = value.EntityKey.ToString();
            dtgAllowance[1, row].Value = value.Code;
            dtgAllowance[2, row].Value = value.AName.Thai;
            dtgAllowance[3, row].Value = value.AName.English;
            dtgAllowance[4, row].Value = value.Amount;
        }

        private void bindForm()
        {
            dtgAllowance.RowCount = 0;

            if (facadeSpecialAllowance.ObjSpecialAllowanceList.Count > 0)
            {
                for (int i = 0; i < facadeSpecialAllowance.ObjSpecialAllowanceList.Count; i++)
                {
                    dtgAllowance.RowCount++;
                    bindSpecealAllowance(i, facadeSpecialAllowance.ObjSpecialAllowanceList[i]);
                }
            }
        }

        //		==========================Public Method========================
        public bool AddRow(SpecialAllowance value)
        {
            if (facadeSpecialAllowance.InsertSpecialAllowance(value))
            {
                dtgAllowance.RowCount++;
                bindSpecealAllowance(dtgAllowance.RowCount - 1, value);
                enableAmend(true);
                mdiParent.RefreshMasterCount();
                return true;
            }
            return false;
        }

        public bool UpdateRow(SpecialAllowance value)
        {
            if (facadeSpecialAllowance.UpdateModel(value))
            {
                bindSpecealAllowance(SelectedRow, value);
                return true;
            }
            return false;
        }

        private void addEvent()
        {
            try
            {
                frmEntry = new FrmSpecialAllowanceEntry(this);
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
                frmEntry = new FrmSpecialAllowanceEntry(this);
                frmEntry.InitEditAction(selectedSpecialAllowance);
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
                    if (facadeSpecialAllowance.DeleteModel(selectedSpecialAllowance))
                    {
                        if (dtgAllowance.RowCount > 1)
                        {
                            dtgAllowance.Rows.RemoveAt(SelectedRow);
                        }
                        else
                        {
                            dtgAllowance.RowCount = 0;
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
            newObject();
            clearForm();
            RefreshForm();

            mdiParent.EnableRefreshCommand(true);
            MainMenuRefreshStatus = true;    
        }

        public void RefreshForm()
        {
            try
            {
                if (facadeSpecialAllowance.DisplaySpecialAllowance())
                {
                    enableAmend(true);
                    bindForm();
                }
                else
                {
                    enableAmend(false);
                    dtgAllowance.RowCount = 0;
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
        private void FrmSpecialAllowance_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
            this.WindowState = FormWindowState.Maximized;
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

        private void dtgAllowance_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                updateEvent();
            }
        }
   }
}