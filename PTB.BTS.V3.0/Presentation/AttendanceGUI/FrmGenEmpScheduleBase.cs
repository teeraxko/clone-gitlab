using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.ContractEntities;
using ictus.PIS.PI.Entity;

using Facade.AttendanceFacade;

using Presentation.CommonGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;

namespace Presentation.AttendanceGUI
{
    public partial class FrmGenEmpScheduleBase : Presentation.CommonGUI.ChildFormBase, IMDIChildForm
    {
        #region - Private -
        protected bool isReadonly = true;
        private frmMain mdiParent;
        protected GenEmpScheduleFacadeBase facadeGenEmpSchedule;

        private int indexCandidateListBox = 0;
        private int indexSelectedListBox = 0;
        #endregion

        #region - Property -
        private EmployeeList empListCandidate
        {
            get
            {
                return facadeGenEmpSchedule.ListEmployeeList;
            }
        }

        private EmployeeList empListSelected
        {
            get
            {
                return facadeGenEmpSchedule.SelectedEmployeeList;
            }
        }

        private EmployeeList listBoxCandidate
        {
            get
            {
                return facadeGenEmpSchedule.ListBoxCandidate;
            }
        }
        #endregion

        //==============================  Constructor  ==============================
        public FrmGenEmpScheduleBase()
        {
            InitializeComponent();
        }


        #region - Private Method -
        private void enablePositionType(bool enable)
        {
            gpbPositionType.Enabled = enable;
            if (!enable)
            {
                rdoOfficer.Checked = true;
            }
        }

        private void enableCondition(bool enable)
        {
            gpbCondition.Enabled = enable;

            if (!enable)
            {
                cboServiceStaffType.SelectedIndex = -1;
            }
        }

        private void bindListBox(EmployeeList value, ListBox control)
        {
            for (int i = 0; i < value.Count; i++)
            {
                control.Items.Add(value[i]);
                listBoxCandidate.Add(value[i]);
            }
        }
        #endregion

        #region - validate -
        private bool validategenEmpSchedule()
        {
            if (facadeGenEmpSchedule.SelectedEmployeeList.Count == 0)
            {
                Message(MessageList.Error.E0005, "พนักงาน");
                cmdShow.Focus();
                return false;
            }
            return true;
        }
        #endregion

        //==============================  Base Event   ==============================
        #region IMDIChildForm Members

        public void InitForm()
        {
            MainMenuNewStatus = false;
            MainMenuRefreshStatus = false;
            MainMenuPrintStatus = false;
            mdiParent.EnableNewCommand(false);
            mdiParent.EnableRefreshCommand(false);
            mdiParent.EnablePrintCommand(false);

            dtpForMonth.Value = DateTime.Today.Date;
            rdoSelectAll.Checked = true;

            cboServiceStaffType.DataSource = facadeGenEmpSchedule.DataSourceServiceStaffType;
            cboServiceStaffType.SelectedIndex = -1;

            listBoxCandidate.Clear();
            ltbEmpListCandidate.Items.Clear();
            ltbEmpListSelected.Items.Clear();
        }

        public void RefreshForm()
        {
            try
            {
                MainMenuNewStatus = true;
                MainMenuRefreshStatus = true;
                MainMenuPrintStatus = true;
                mdiParent.EnableNewCommand(true);
                mdiParent.EnableRefreshCommand(true);
                mdiParent.EnablePrintCommand(true);

                bool result = false;

                listBoxCandidate.Clear();
                ltbEmpListCandidate.Items.Clear();

                if (rdoSelectAll.Checked)
                {
                    result = facadeGenEmpSchedule.FillEmployeeList(dtpForMonth.Value);
                }
                else
                {
                    PositionType positionType = new PositionType();
                    if (rdoOfficer.Checked)
                    {
                        positionType.Type = "O";
                        result = facadeGenEmpSchedule.FillEmployeeList(positionType, dtpForMonth.Value);
                    }
                    else
                    {
                        if (cboServiceStaffType.SelectedIndex == -1 || cboServiceStaffType.Text == "")
                        {
                            positionType.Type = "S";
                            result = facadeGenEmpSchedule.FillEmployeeList(positionType, dtpForMonth.Value);
                        }
                        else
                        {
                            ServiceStaffType serviceStaffType = (ServiceStaffType)cboServiceStaffType.SelectedItem;
                            result = facadeGenEmpSchedule.FillEmployeeList(serviceStaffType, dtpForMonth.Value);
                            serviceStaffType = null;
                        }
                    }
                    positionType = null;
                }

                if (result)
                {
                    for (int i = 0; i < facadeGenEmpSchedule.ListEmployeeList.Count; i++)
                    {
                        if (!empListSelected.Contain(facadeGenEmpSchedule.ListEmployeeList[i]))
                        {
                            ltbEmpListCandidate.Items.Add(facadeGenEmpSchedule.ListEmployeeList[i]);
                            listBoxCandidate.Add(facadeGenEmpSchedule.ListEmployeeList[i]);
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
            finally
            { }
        }

        public void PrintForm()
        {
            try
            {
                if (ltbEmpListSelected.Items.Count > 0)
                {
                    List<string> listEmployeeNo = new List<string>();
                    foreach (Employee employee in ltbEmpListSelected.Items)
                    {
                        listEmployeeNo.Add(employee.EmployeeNo);
                    }

                    Report.GUI.Attendance.FrmReportGenWorkSchedule frmReport = new Report.GUI.Attendance.FrmReportGenWorkSchedule(listEmployeeNo, dtpForMonth.Value);
                    frmReport.Show();
                }
                else
                {
                    Message(MessageList.Error.E0005, "พนักงาน");
                    ltbEmpListCandidate.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageForm(ex);
            }           
        }

        public void ExitForm()
        {
            if (mdiParent != null)
            {
                clearMainMenuStatus();
            }
            this.Close();
        }

        //int IMDIChildForm.MasterCount()
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}

        #endregion

        #region - Selected Base event -
        private void selectedAll()
        {
            for (int i = 0; i < listBoxCandidate.Count; i++)
            {
                if (!empListSelected.Contain(listBoxCandidate[i]))
                {
                    ltbEmpListSelected.Items.Add(listBoxCandidate[i]);
                    empListSelected.Add(listBoxCandidate[i]);
                }
            }
            ltbEmpListCandidate.Items.Clear();
            listBoxCandidate.Clear();
        }

        private void selectedOne()
        {
            if (ltbEmpListCandidate.SelectedIndex != -1)
            {
                indexCandidateListBox = ltbEmpListCandidate.SelectedIndex;
                indexSelectedListBox = ltbEmpListSelected.SelectedIndex;

                Employee employee = (Employee)ltbEmpListCandidate.SelectedItem;
                if (!empListSelected.Contain(employee))
                {
                    ltbEmpListSelected.Items.Add(employee);
                    empListSelected.Add(employee);
                }
                listBoxCandidate.Remove(employee);
                ltbEmpListCandidate.Items.Remove(ltbEmpListCandidate.SelectedItem);
                employee = null;
            }
        }

        private void clearAll()
        {
            ltbEmpListCandidate.Items.Clear();
            listBoxCandidate.Clear();

            bindListBox(empListCandidate, ltbEmpListCandidate);

            ltbEmpListSelected.Items.Clear();
            empListSelected.Clear();
            indexCandidateListBox = indexSelectedListBox;
        }

        private void clearOne()
        {
            if (ltbEmpListSelected.SelectedIndex != -1)
            {
                indexCandidateListBox = ltbEmpListCandidate.SelectedIndex;
                indexSelectedListBox = ltbEmpListSelected.SelectedIndex;

                Employee employee = (Employee)ltbEmpListSelected.SelectedItem;
                if (empListCandidate.Contain(employee))
                {
                    if (!listBoxCandidate.Contain(employee))
                    {
                        ltbEmpListCandidate.Items.Add(employee);
                        listBoxCandidate.Add(employee);
                    }
                }
                ltbEmpListSelected.Items.Remove(ltbEmpListSelected.SelectedItem);
                empListSelected.Remove(employee);

                employee = null;
            }
        }
        #endregion

        private void genEmpSchedule()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                if (validategenEmpSchedule())
                {
                    cmdOK.Enabled = false;
                    if (facadeGenEmpSchedule.GenEmployeeListSchedule(dtpForMonth.Value.Date))
                    {
                        ltbEmpListSelected.Items.Clear();
                        facadeGenEmpSchedule.SelectedEmployeeList.Clear();
                        updatePresentation();
                        this.Cursor = System.Windows.Forms.Cursors.Default;
                    }
                    else
                    {
                        cmdOK.Enabled = true;
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
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        #region - Count -
        private void updateCount()
        {
            lblCandidate.Text = ltbEmpListCandidate.Items.Count.ToString();
            lblSelected.Text = ltbEmpListSelected.Items.Count.ToString();
        }
        private void updateMoveButton()
        {
            if (ltbEmpListCandidate.Items.Count == 0)
            {
                cmdSelect.Enabled = false;
                cmdSelectAll.Enabled = false;
            }
            else
            {
                cmdSelect.Enabled = true;
                cmdSelectAll.Enabled = true;
            }
            if (ltbEmpListSelected.Items.Count == 0)
            {
                cmdRemove.Enabled = false;
                cmdRemoveAll.Enabled = false;

                cmdOK.Enabled = false;
            }
            else
            {
                cmdRemove.Enabled = true;
                cmdRemoveAll.Enabled = true;

                cmdOK.Enabled = true;
            }
        }
        private void updateSelectedList(ListBox control, ref int index)
        {
            if (control.Items.Count == 0 || index == -1)
            {
                return;
            }
            if (control.Items.Count - 1 < index)
            {
                index = control.Items.Count - 1;
                control.SetSelected(index, true);
                return;
            }
            control.SetSelected(index, true);
        }
        private void updateSelectedList()
        {
            updateSelectedList(ltbEmpListCandidate, ref indexCandidateListBox);
            updateSelectedList(ltbEmpListSelected, ref indexSelectedListBox);
        }
        private void updatePresentation()
        {
            updateCount();
            updateMoveButton();
            updateSelectedList();

            if (isReadonly)
            {
                cmdOK.Enabled = false;
            }
        }
        #endregion

        //==============================     event     ==============================
        private void frmGenEmpScheduleBase_Load(object sender, EventArgs e)
        {
            mdiParent = (frmMain)this.ParentForm;
        }

        private void frmGenEmpScheduleBase_Closed(object sender, System.EventArgs e)
        {
            clearMainMenuStatus();
        }

        #region - Condition event -
        private void rdoSelectAll_CheckedChanged(object sender, System.EventArgs e)
        {
            enablePositionType(false);
        }

        private void rdoSelectSome_CheckedChanged(object sender, System.EventArgs e)
        {
            enablePositionType(true);
        }

        private void rdoOfficer_CheckedChanged(object sender, System.EventArgs e)
        {
            enableCondition(false);
        }

        private void rdoService_CheckedChanged(object sender, System.EventArgs e)
        {
            enableCondition(true);
        }
        #endregion

        #region - Selected event -
        private void cmdSelect_Click(object sender, System.EventArgs e)
        {
            selectedOne();
            updatePresentation();
        }

        private void ltbEmpListCandidate_DoubleClick(object sender, System.EventArgs e)
        {
            selectedOne();
            updatePresentation();
        }

        private void cmdSelectAll_Click(object sender, System.EventArgs e)
        {
            selectedAll();
            updatePresentation();
        }

        private void cmdRemove_Click(object sender, System.EventArgs e)
        {
            clearOne();
            updatePresentation();
        }

        private void ltbEmpListSelected_DoubleClick(object sender, System.EventArgs e)
        {
            clearOne();
            updatePresentation();
        }

        private void cmdRemoveAll_Click(object sender, System.EventArgs e)
        {
            clearAll();
            updatePresentation();
        }
        #endregion

        #region - button event -
        private void cmdShow_Click(object sender, System.EventArgs e)
        {
            RefreshForm();
            updatePresentation();
        }

        private void cmdCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            genEmpSchedule();
            this.Cursor = Cursors.Default;
        }
        #endregion
    }
}

