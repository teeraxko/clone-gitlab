using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Report.GUI.Contract;
using Presentation.CommonGUI;
using Entity.ContractEntities;
using Facade.ContractFacade;
using SystemFramework.AppMessage;
using Entity.VehicleEntities;
using ictus.Common.Entity.Time;

namespace Presentation.ContractGUI
{
    public partial class FrmRenewalNotice : ChildFormBase, IMDIChildForm
    {
        #region Declaration

        private enum ContractColumn
        {
            SELECT_CHECKBOX = 0
        }
        private static class CheckBoxColumnValue
        {
            public static readonly string TRUE = "1";
            public static readonly string FALSE = "0";
        }

        private string contractNo;
        private int countGrid;

        private frmMain mdiParent;

        #endregion

        #region Constructor
        public FrmRenewalNotice() : base()
        {
            InitializeComponent();
        } 
        #endregion

        #region Private Method
        /// <summary>
        /// DayInMonth table for generate period condition
        /// </summary>
        private static int[] tbDayInMonths = { 0, // XML Schema months start at 1.
                        31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        /// <summary>
        /// Generate maximum day in month
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        private static int maximumDayInMonthFor(int year, int month)
        {
            if (month != 2)
            { //FEBRUARY
                return tbDayInMonths[month];
            }
            else
            {
                if (((year % 400) == 0)
                        || (((year % 100) != 0) && ((year % 4) == 0)))
                {
                    // is a leap year.
                    return 29;
                }
                else
                {
                    return tbDayInMonths[month];
                }
            }
        }

        private void bindForm()
        {
            if (ValidityPeriod())
            {

                Contract condition = new Contract();
                ContractType contractType = new ContractType();
                KindOfContract kindOfContract = new KindOfContract();

                contractType.Code = ContractType.CONTRACT_TYPE_VEHICLE;
                kindOfContract.Code = KindOfContract.KIND_OF_CONTRACT_LONG;

                ContractList contractList = null;

                condition.AContractType = contractType;
                condition.AKindOfContract = kindOfContract;
                //Generate period to MONTH/YEAR : Add by Aof 02/12/08
                string periodFrom = "01" + "/" + dtpEndDateFrom.Value.Date.Month.ToString() + "/" + dtpEndDateFrom.Value.Date.Year.ToString();
                condition.APeriod.From = Convert.ToDateTime(periodFrom);

                YearMonth yearMonth = new YearMonth(dtpEndDateTo.Value.Date.Year, dtpEndDateTo.Value.Date.Month);
                condition.APeriod.To = yearMonth.MaxDateOfMonth;
                //End add by Aof

                using (RenewalNoticeFacade facade = new RenewalNoticeFacade())
                {
                    contractList = facade.GetContractList(condition);
                }

                dtgView.Rows.Clear();

                dtgView.Visible = false;
                //btnPrint.Visible = false;

                if (contractList != null)
                {
                    for (int i = 0; i < contractList.Count; i++)
                    {
                        dtgView.RowCount++;
                        bindContract(i, contractList[i]);
                    }

                    countGrid = contractList.Count;
                    dtgView.Visible = true;
                    //btnPrint.Visible = true;
                }
                else
                {
                    Message(MessageList.Error.E0004, "เลขที่สัญญา");
                }
            }
        }

        private bool ValidityPeriod()
        {
            if (new DateTime(dtpEndDateFrom.Value.Year, dtpEndDateFrom.Value.Month, 1) > new DateTime(dtpEndDateTo.Value.Year, dtpEndDateTo.Value.Month, 1))
            {
                Message(MessageList.Error.E0011, "From Date ", " To Date");
                return false;
            }

            return true;
        }

        /// <summary>
        /// dtgView[0, i].Value = "0" is mean false
        /// dtgView[0, i].Value = "1" is mean true
        /// </summary>
        /// <param name="i"></param>
        /// <param name="contractBase"></param>
        private void bindContract(int index, ContractBase contractBase)
        {
            Vehicle vehicle = new Vehicle();

            dtgView[0, index].Value = "0";
            dtgView[1, index].Value = contractBase.ContractNo.ToString();
            dtgView[2, index].Value = contractBase.APeriod.From.Date;
            dtgView[3, index].Value = contractBase.APeriod.To.Date;
            dtgView[4, index].Value = contractBase.ACustomer.AName.English;

            using (RenewalNoticeFacade facade = new RenewalNoticeFacade())
            {
                vehicle = facade.GetVehicleByContract(contractBase.ContractNo);
            }

            if (vehicle != null)
            {
                dtgView[5, index].Value = vehicle.PlateNo;
                if (vehicle.AModel != null)
                {
                    dtgView[6, index].Value = vehicle.AModel.ABrand.AName.English;
                    dtgView[7, index].Value = vehicle.AModel.AName.English;
                }
            }
            else
            {
                dtgView[5, index].Value = string.Empty;
                dtgView[6, index].Value = string.Empty;
                dtgView[7, index].Value = string.Empty;
            }
        }

        private void clearScreen()
        {
            dtpEndDateFrom.Value = DateTime.Now;
            dtgView.Visible = false;
        }

        private string checkSelect()
        {
            contractNo = string.Empty;

            for (int i = 0; i < countGrid; i++)
            {
                if (dtgView[0, i].Value.ToString() == "1")
                {
                    if (contractNo == "")
                    {
                        contractNo = "'" + dtgView[1, i].Value + "'";
                    }
                    else
                    {
                        contractNo = contractNo + ",'" + dtgView[1, i].Value + "'";
                    }
                }
            }

            return contractNo;
        } 
        #endregion

        #region IMDIChildFormGUI Members

        public void InitForm()
        {
            mdiParent = (frmMain)this.MdiParent;

            clearScreen();
        }

        public void RefreshForm()
        {
            throw new NotImplementedException();
        }

        public void PrintForm()
        {
            checkSelect();

            if (contractNo == string.Empty)
            {
                Message(MessageList.Error.E0005, " Contract No.");
            }
            else
            {
                FrmReportRenewalNotice frmReportRenewalNotice = new FrmReportRenewalNotice(dtpEndDateTo.Value.Date, contractNo, txtTISAuthorize.Text.Trim());
                frmReportRenewalNotice.MdiParent = this.MdiParent;
                frmReportRenewalNotice.Show();
            }
        }

        public void ExitForm()
        {
            this.Close();
        }

        #endregion

        #region Form Event

        private void FrmRenewalNotice_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            bindForm();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
        }

        private void dtgView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectColumnIndex = Convert.ToInt32(ContractColumn.SELECT_CHECKBOX);
            if (e.RowIndex > -1 && e.ColumnIndex == selectColumnIndex)
            {
                // check select only value of selected row

                using (DataGridViewRow row = this.dtgView.Rows[e.RowIndex])
                {
                    // update checkbox value
                    DataGridViewCell cell = row.Cells[e.ColumnIndex];
                    if (cell.Value.ToString() == CheckBoxColumnValue.TRUE)
                        cell.Value = CheckBoxColumnValue.FALSE;
                    else
                        cell.Value = CheckBoxColumnValue.TRUE;
                    this.dtgView.UpdateCellValue(e.ColumnIndex, e.RowIndex);
                    this.dtgView.Update();

                    bool isSelect = (cell.Value.ToString() == CheckBoxColumnValue.TRUE);

                    // Case selected row is not select : check the others
                    if (!isSelect)
                    {
                        isSelect = this.HasSelectRowByCheckbox(this.dtgView, e.ColumnIndex);
                    }

                    // Disable/Enable print toolbar.
                    this.MainMenuPrintStatus = isSelect;
                    this.mdiParent.EnablePrintCommand(this.MainMenuPrintStatus);

                    // dispose and clear object
                    cell.Dispose();

                    cell = null;
                }
            }
        }

        #endregion

        #region Common Methods
        /// <summary>
        /// Check that the rows in DataGridView are selected at least one row.
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="checkboxColumn"></param>
        /// <returns></returns>
        private bool HasSelectRowByCheckbox(DataGridView dgv,int checkboxColumn)
        {
            int indexRow = 0;
            bool isSelect = false;

            while ((indexRow < this.dtgView.Rows.Count) && (!isSelect))
            {
                isSelect = (this.dtgView[checkboxColumn, indexRow].Value.ToString() == CheckBoxColumnValue.TRUE);
                indexRow++;
            }

            return isSelect;
        }
        #endregion
    }
}
