using System;

namespace PresentationBase.CommonGUIBase
{
    public interface IMDIChildFormGUI
	{
		void InitForm();
		void RefreshForm();
		void PrintForm(); 
		void ExitForm();
	}
}