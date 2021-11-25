using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Presentation.CommonGUI;
using SystemFramework.AppConfig;
using System.Data.SqlClient;
using SystemFramework.AppException;
using SystemFramework.AppMessage;
using Facade.VehicleFacade.LeasingFacade;
using Entity.VehicleEntities.Leasing;

namespace Presentation.VehicleGUI.ProfitLostGUI
{
    public partial class FrmProfitLost : ChildFormBase, IMDIChildForm
    {
        private FrmProfitLostEntry frmEntry;
        private frmMain mdiParent;

        private ProfitAndLostFacade facadePL;
        public ProfitAndLostFacade FacadePL
        {
            get { return facadePL; }
        }

        private ProfitAndLostList listPL;
        public ProfitAndLostList ListPL
        {
            get { return listPL; }
        }

        private int selectedRow
        {
            get { return dtgPL.CurrentRow.Index; }
        }

        private string selectedKey
        {
            get { return dtgPL[0, selectedRow].Value.ToString(); }
        }

        private ProfitAndLost selectedPL
        {
            get { return (ProfitAndLost)listPL[selectedKey]; }
        }

        //================================= Constructor ================================
        public FrmProfitLost() : base()
        {
            InitializeComponent();
            this.title = UserProfile.GetFormName("miVehicle", "miVehicleProfitLost");
        }

        public override string FormID()
        {
            return UserProfile.GetFormID("miVehicle", "miVehicleProfitLost");
        }

        public override int MasterCount()
        {
            return listPL.Count;
        }

        //==========================Private Method========================
        private void bindPL(int row, ProfitAndLost profitAndLost)
        {
            dtgPL[0, row].Value = profitAndLost.EntityKey;
            dtgPL[1, row].Value = profitAndLost.Vehicle.PlateNumber;
            dtgPL[2, row].Value = profitAndLost.Rental;
            dtgPL[3, row].Value = profitAndLost.Rate;
            dtgPL[4, row].Value = profitAndLost.Pmt;
            dtgPL[5, row].Value = profitAndLost.FV;
            dtgPL[6, row].Value = profitAndLost.Contract;
            dtgPL[7, row].Value = profitAndLost.RentalAge;
            dtgPL[8, row].Value = profitAndLost.Remain;
            dtgPL[9, row].Value = profitAndLost.Sale;
            dtgPL[10, row].Value = profitAndLost.Price;
        }

        private void enableAmend(bool value)
        {
            btnUpdate.Enabled = value;
            btnDelete.Enabled = value;
            mniUpdate.Enabled = value;
            mniDelete.Enabled = value;
        }

        private void clearForm()
        {
            dtgPL.RowCount = 0;
            enableAmend(false);
        }

        //==========================Public Method========================
        public bool AddRow(IProfitAndLost value)
        {
            if (listPL.Contain(value))
            {
                Message(MessageList.Error.E0013, "เพิ่มรถคันนี้ได้", "มีรถคันนี้ในรายการแล้ว");
                return false;
            }
            else
            {
                listPL.Add(value);
                dtgPL.RowCount++;
                bindPL(dtgPL.RowCount - 1, (ProfitAndLost)value);
                enableAmend(true);
                mdiParent.RefreshMasterCount();
                return true;
            }
        }

        public bool UpdateRow(IProfitAndLost value)
        {
            listPL[value.EntityKey] = value;
            bindPL(selectedRow, (ProfitAndLost)value);
            return true;
        }

        private void addEvent()
        {
            try
            {
                frmEntry = new FrmProfitLostEntry(this);
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
                frmEntry = new FrmProfitLostEntry(this);
                frmEntry.InitEditAction(selectedPL);
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
                    listPL.Remove(selectedPL);

                    if (dtgPL.RowCount > 1)
                    {
                        dtgPL.Rows.RemoveAt(selectedRow);
                    }
                    else
                    {
                        dtgPL.RowCount = 0;
                        enableAmend(false);
                    }
                    mdiParent.RefreshMasterCount();
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

        private void printEvent()
        {
            try
            {
                if (listPL.Count > 0)
                {
                    listPL.BVDate = dtpBVDate.Value;

                    if (facadePL.PrintProfitAndLost(listPL))
                    {
                        FrmrptProfitLost frmRpt = new FrmrptProfitLost();
                        frmRpt.BVDate = dtpBVDate.Value;
                        frmRpt.Show();
                    }
                    else
                    {
                        Message(MessageList.Error.E0014, "พิมพ์รายงานได้");
                    }
                }
                else
                {
                    Message(MessageList.Error.E0005, "รายการรถ");                    
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
        #region IMDIChildFormGUI Members

        public void InitForm()
        {
            facadePL = new ProfitAndLostFacade();
            listPL = new ProfitAndLostList();
            clearForm();
            DateTime forDate = DateTime.Today.AddMonths(-1);
            dtpBVDate.Value = new DateTime(forDate.Year, forDate.Month, DateTime.DaysInMonth(forDate.Year, forDate.Month));

            mdiParent.EnableNewCommand(true);
            MainMenuNewStatus = true;

            if (UserProfile.IsReadOnly("miVehicle", "miVehicleProfitLost"))
            {
                enableAmend(false);
                btnAdd.Enabled = false;
                mniAdd.Enabled = false;
            }
        }

        public void RefreshForm()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void PrintForm()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void ExitForm()
        {
            this.Close();
        }

        #endregion


        //============================== Event ==============================
        private void FrmProfitLost_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printEvent();
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

        private void dtgPL_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                updateEvent();
            }
        }
    }
}