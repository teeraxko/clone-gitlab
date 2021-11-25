using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.CommonGUI {
    public class MenuContain {
        private string loadAssemblyName;

        public string LoadAssemblyName {
            get { return loadAssemblyName; }
            set { loadAssemblyName = value; }
        }

        private string loadClassName;

        public string LoadClassName {
            get { return loadClassName; }
            set { loadClassName = value; }
        }

        private object obj;

        public PresentationBase.CommonGUIBase.ChildFormGUIBase ChildFrm  {
            get { return (PresentationBase.CommonGUIBase.ChildFormGUIBase)obj; }
            set { obj = value; }
        }

        public PresentationBase.CommonGUIBase.IMDIChildFormGUI mdiFrm {
            get { return (PresentationBase.CommonGUIBase.IMDIChildFormGUI)obj; }
        }


        public object Frm {
            set { obj = value; }
        }
	
	

    }
}
