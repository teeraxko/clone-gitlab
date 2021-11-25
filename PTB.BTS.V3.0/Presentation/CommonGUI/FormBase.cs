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

using Facade.AttendanceFacade;

using PresentationBase.CommonGUIBase;

using SystemFramework.AppMessage;
using SystemFramework.AppException;
using SystemFramework.AppConfig;

using ictus.Framework.ExceptionManagement;

namespace Presentation.CommonGUI
{
    public partial class FormBase : PresentationBase.CommonGUIBase.FormGUIBase
    {
        public FormBase(): base()
        {
            InitializeComponent();
        }

        #region - util function -
        protected TimePeriod getTimePeriod(DateTime form, DateTime to, DateTime forDate)
        {
            return AttendanceCommonFacade.GetTimePeriod(form, to, forDate);
        }

        protected TimePeriod getTimePeriod(DateTime form, DateTime to)
        {
            return AttendanceCommonFacade.GetTimePeriod(form, to);
        }

        protected TimePeriod getTimePeriod(TimePeriod value, DateTime forDate)
        {
            return AttendanceCommonFacade.GetTimePeriod(value, forDate);
        }

        protected TimePeriod getTimePeriod(TimePeriod value)
        {
            return AttendanceCommonFacade.GetTimePeriod(value);
        }

        protected TimePeriod getBreakTimePeriod(DateTime startBreak, DateTime endBreak, DateTime startWork, DateTime endWork, DateTime forDate)
        {
            return AttendanceCommonFacade.GetBreakTimePeriod(startBreak, endBreak, startWork, endWork, forDate);
        }

        protected TimePeriod getBreakTimePeriod(DateTime startBreak, DateTime endBreak, DateTime startWork, DateTime endWork)
        {
            return AttendanceCommonFacade.GetBreakTimePeriod(startBreak, endBreak, startWork, endWork);
        }

        protected DateTime getTime(DateTime time)
        {
            return AttendanceCommonFacade.GetTime(time);
        }

        protected TimePeriod getTime(DateTime from, DateTime to)
        {
            return AttendanceCommonFacade.GetTime(from, to);
        }
        #endregion
    }
}