using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
namespace Presentation.PiGUI
{
	public class frmBloodGroupEntry : SingleFieldGUIEntryBase
	{
		public frmBloodGroupEntry()
		{}

		public frmBloodGroupEntry(SingleFieldGUIMainBase parentForm): base(parentForm)
		{
			title = "หมู่เลือด";
			lable = "ชื่อหมู่เลือด";
			Maxlength = 10;
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMasterBloodGroup");

		}
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new BloodGroup();
		}

		private void InitializeComponent()
		{
			// 
			// frmBloodGroupEntry
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Name = "frmBloodGroupEntry";
			this.Load += new System.EventHandler(this.frmBloodGroupEntry_Load);

		}

		private void frmBloodGroupEntry_Load(object sender, System.EventArgs e)
		{
		}
	}
}
