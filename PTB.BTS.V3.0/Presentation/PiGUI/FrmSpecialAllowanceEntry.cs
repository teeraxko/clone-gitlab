using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Presentation.CommonGUI;
using ictus.PIS.PI.Entity;
using SystemFramework.AppException;
using System.Data.SqlClient;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

namespace Presentation.PiGUI
{
    public partial class FrmSpecialAllowanceEntry : EntryFormBase
    {
        private FrmSpecialAllowance parentForm;
        private bool isReadOnly = true;

        #region Property
        private SpecialAllowance _specialAllowance;
        public SpecialAllowance SpecialAllowance
        {
            get
            {
                _specialAllowance = new SpecialAllowance();
                _specialAllowance.Code = txtCode.Text.Trim();
                _specialAllowance.AName.Thai = txtThaiName.Text;
                _specialAllowance.AName.English = txtEnglishName.Text;
                _specialAllowance.Amount = nudAmount.Value;
                return _specialAllowance;
            }
            set
            {
                _specialAllowance = value;
                txtCode.Text = value.Code;
                txtThaiName.Text = value.AName.Thai;
                txtEnglishName.Text = value.AName.English;
                nudAmount.Value = value.Amount;
            }
        } 
        #endregion

        #region Constructor
        public FrmSpecialAllowanceEntry(FrmSpecialAllowance value): base()
        {
            InitializeComponent();
            parentForm = value;
            setValue();
            isReadOnly = UserProfile.IsReadOnly("miPI", "miSpecialAllowance");
            this.title = UserProfile.GetFormName("miPI", "miSpecialAllowance");
        }
        #endregion

        #region Public method
        internal void InitAddAction()
        {
            baseADD();
            clearForm();
            txtCode.Enabled = true;
        }

        internal void InitEditAction(SpecialAllowance entity)
        {
            baseEDIT();
            clearForm();
            txtCode.Enabled = false;
            SpecialAllowance = entity;

            if (isReadOnly)
            {
                btnOK.Enabled = false;
            }
        } 
        #endregion

        #region Private method
        private void setValue()
        {
        }

        private void clearForm()
        {
            txtCode.Text = "";
            txtThaiName.Text = "";
            txtEnglishName.Text = "";
            nudAmount.Value = decimal.Zero;
        }

        private bool validateForm()
        {
            if (txtCode.Text.Trim() == "")
            {
                Message(MessageList.Error.E0002, "รหัส");
                txtCode.Focus();
                return false;
            }
            if (txtThaiName.Text == "")
            {
                Message(MessageList.Error.E0002, "ชื่อภาษาไทย");
                txtThaiName.Focus();
                return false;
            }
            if (txtEnglishName.Text == "")
            {
                Message(MessageList.Error.E0002, "ชื่อภาษาอังกฤษ");
                txtEnglishName.Focus();
                return false;
            }
            if (nudAmount.Value == decimal.Zero)
            {
                Message(MessageList.Error.E0002, "จำนวนเงิน");
                nudAmount.Focus();
                return false;
            }

            return true;
        }

        private void AddEvent()
        {
            try
            {
                if (validateForm())
                {
                    if (parentForm.AddRow(SpecialAllowance))
                    {
                        clearForm();
                    }
                }
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
        }

        private void EditEvent()
        {
            try
            {
                if (validateForm())
                {
                    if (parentForm.UpdateRow(SpecialAllowance))
                    {
                        this.Close();
                    }
                }
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
        }
        
        #endregion

        #region Form Event
        private void FrmSpecialAllowanceEntry_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            switch (action)
            {
                case ActionType.ADD:
                    AddEvent();
                    break;
                case ActionType.EDIT:
                    EditEvent();
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}