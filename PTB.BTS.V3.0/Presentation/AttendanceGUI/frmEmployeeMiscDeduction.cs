using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Facade.AttendanceFacade;

using SystemFramework.AppConfig;

namespace Presentation.AttendanceGUI
{
	public class frmEmployeeMiscDeduction : Presentation.AttendanceGUI.frmEmployeeMiscBenefit
	{
		private System.ComponentModel.IContainer components = null;

		public frmEmployeeMiscDeduction()
		{
			InitializeComponent();
            //this.Text = "รายการหักเงินตามพนักงาน";
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miEmployeeMiscDeducttion");
            this.title = UserProfile.GetFormName("miAttendance", "miEmployeeMiscDeducttion");

		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miEmployeeMiscDeducttion");
        }

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		protected override void newLayer()
		{
			facadeEmployeeAttendance = new EmployeeMiscDeductionFacade();
			facadeEmployeeMiscBenefit = (EmployeeMiscDeductionFacade)facadeEmployeeAttendance;
		}
	}
}

