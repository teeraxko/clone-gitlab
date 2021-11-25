using System;
using System.Collections.Generic;
using System.Text;
using Presentation.CommonGUI;
using Facade.PiFacade;

namespace Presentation.PiGUI
{
    public class FrmSSHospital : DualFieldGUIMainBase
    {
        public FrmSSHospital()
		{
            frmEntry = new FrmSSHospitalEntry(this);
            facadeMTB = new SSHospitalFacade();
			title = "�������ç��Һ�Ż�Сѹ�ѧ��";
            columnCode = "�����ç��Һ�Ż�Сѹ�ѧ��";
            columnTHName = "�����ç��Һ�Ż�Сѹ�ѧ�� (������)";
            columnENName = "�����ç��Һ�Ż�Сѹ�ѧ�� (�����ѧ���)";
		}
    }
}
