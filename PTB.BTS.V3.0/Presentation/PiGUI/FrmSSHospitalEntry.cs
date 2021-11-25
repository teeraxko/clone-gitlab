using System;
using System.Collections.Generic;
using System.Text;
using Presentation.CommonGUI;
using ictus.PIS.PI.Entity;

namespace Presentation.PiGUI
{
    public class FrmSSHospitalEntry : DualFieldGUIEntryBase
    {
        public FrmSSHospitalEntry(DualFieldGUIMainBase parentForm)
            : base(parentForm)
		{
			maxLength = 6;
            title = "�ç��Һ�Ż�Сѹ�ѧ��";
            lable1 = "����þ.��Сѹ�ѧ��";
            lable2 = "����þ.��Сѹ�ѧ��(������)";
            lable3 = "����þ.��Сѹ�ѧ��(�����ѧ���)";
		}

        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new SSHospital();
		}
    }
}
