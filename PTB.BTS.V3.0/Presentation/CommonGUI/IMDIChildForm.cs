using System;

using PresentationBase.CommonGUIBase;

namespace Presentation.CommonGUI
{
    public interface IMDIChildForm : PresentationBase.CommonGUIBase.IMDIChildFormGUI
	{
        int MasterCount();
        string FormID();
	}
}