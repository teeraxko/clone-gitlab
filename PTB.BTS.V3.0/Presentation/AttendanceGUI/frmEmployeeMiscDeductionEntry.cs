using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Presentation.AttendanceGUI
{
	public class frmEmployeeMiscDeductionEntry : Presentation.AttendanceGUI.frmEmployeeMiscBenfitEntry
	{
		private System.ComponentModel.IContainer components = null;

		public frmEmployeeMiscDeductionEntry(frmEmployeeMiscDeduction parentForm) : base(parentForm)
		{
			InitializeComponent();
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
	}
}

