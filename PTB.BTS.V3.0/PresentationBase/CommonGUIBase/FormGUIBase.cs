using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using SystemFramework.AppMessage;
using SystemFramework.AppException;
using SystemFramework.AppConfig;

using ictus.Framework.ExceptionManagement;
using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;

namespace PresentationBase.CommonGUIBase
{
    public partial class FormGUIBase : Form
    {
        protected SqlException sqlException;

        public FormGUIBase(): base()
        {
            InitializeComponent();
        }

        protected ActionType action = ActionType.ADD;
        public enum ActionType
        {
            ADD, EDIT
        }

        public bool IsMustQuestion = false;

        #region - Form State -
        public bool MainMenuNewStatus = false;
        public bool MainMenuDeleteStatus = false;
        public bool MainMenuRefreshStatus = false;
        public bool MainMenuPrintStatus = false;

        protected void clearMainMenuStatus()
        {
            MainMenuNewStatus = false;
            MainMenuDeleteStatus = false;
            MainMenuRefreshStatus = false;
            MainMenuPrintStatus = false;
        }
        #endregion

        #region - message -
        private void log(Exception ex)
        {
            UserLogon userLogon = new UserLogon();
            userLogon.UserName = UserProfile.UserID;
            userLogon.ApplicationName = "PTB/BTS V2";
            userLogon.AppVersion = ApplicationVersion.Version;
            ExceptionManager.Publish(ex, userLogon);
            userLogon = null;
        }

        protected void errorMessage(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        protected void infoMessage(string msg)
        {
            MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        protected void MessageForm(Exception exception)
        {
            if (exception is AppExceptionBase)
            {
                Message((AppExceptionBase)exception);
            }
            else if (exception is SqlException)
            {
                Message((SqlException)exception);
            }
            else
            {
                Message(exception);
            }
        }

        //		throw SqlException
        protected void Message(SqlException ex)
        {
            errorMessage(MessageList.GetMessage(MessageList.Error.E0024) + "\n" + ex.Message);
            log(ex);
        }

        //		throw Exception;
        protected void Message(Exception ex)
        {
            errorMessage(MessageList.GetMessage(MessageList.Error.E0027) + "\n" + ex.Message);
            log(ex);
        }

        //			TransactionException
        protected void Message(TransactionException ex)
        {
            errorMessage(MessageList.GetMessage(MessageList.Error.E0024));
            log(ex);
        }

        //		throw AppExceptionBase;
        protected void Message(AppExceptionBase ex)
        {
            errorMessage(ex.CustomMessage);
        }

        //		throw AppExceptionBase;
        protected void Message(DuplicateException ex)
        {
            errorMessage(ex.CustomMessage);
            log(ex);
        }

        //		Information
        protected void Message(MessageList.Information message)
        {
            infoMessage(MessageList.GetMessage(message));
        }

        //		Warning
        protected DialogResult Message(MessageList.Warning message)
        {
            return MessageBox.Show(MessageList.GetMessage(message), "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        //		Error
        protected void Message(MessageList.Error message, params string[] value)
        {
            string strMessage = string.Format(MessageList.GetMessage(message), value);
            errorMessage(strMessage);
        }

        protected DialogResult Message(MessageList.Question message, params string[] value)
        {
            string strMessage = string.Format(MessageList.GetMessage(message), value);
            if (message == MessageList.Question.Q0003 || message == MessageList.Question.Q0005 || message == MessageList.Question.Q0011)
            {
                return MessageBox.Show(strMessage, "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            }
            else
            {
                return MessageBox.Show(strMessage, "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            }
        }
        #endregion

        #region - DateTimePicker -
        protected void clearDTP(DateTimePicker obj)
        {
            obj.MinDate = DateTimePicker.MinDateTime;
            obj.MaxDate = DateTimePicker.MaxDateTime;
        }

        protected void setDTPForMonth(DateTimePicker obj, YearMonth value)
        {
            clearDTP(obj);
            obj.MinDate = value.MinDateOfMonth;
            obj.MaxDate = value.MaxDateOfMonth;
        }

        protected void setDTPForMonth(DateTimePicker obj, DateTime value)
        {
            YearMonth yearMonth = new YearMonth(value);
            setDTPForMonth(obj, yearMonth);
            obj.Value = value;
        }

        protected void setDTPForYear(DateTimePicker obj, YearMonth value)
        {
            clearDTP(obj);
            obj.MinDate = value.MinDateOfYear;
            obj.MaxDate = value.MaxDateOfYear;
            obj.Value = value.DateTime;
        }

        protected void setDTPForYear(DateTimePicker obj, DateTime value)
        {
            YearMonth yearMonth = new YearMonth(value);
            setDTPForYear(obj, yearMonth);
            obj.Value = value;
        }
        #endregion

        #region - util function -
        protected void setSelected(TextBox control)
        {
            control.Focus();
            control.SelectionStart = 0;
            control.SelectionLength = control.Text.Length;
        }

        protected void setSelectedByCode(ComboBox control, DualFieldBase code)
        {
            DualFieldBase dualField;
            for (int i = 0; i < control.Items.Count; i++)
            {
                dualField = (DualFieldBase)control.Items[i];
                if (dualField.Code == code.Code)
                {
                    control.SelectedIndex = i;
                    dualField = null;
                    return;
                }
                dualField = null;
            }
        }
        #endregion
    }
}