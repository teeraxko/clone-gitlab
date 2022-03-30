using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.CommonEntity {    

    public partial class EmailFormat : EntityBase, IKey
    {
        public EmailFormat()
            : base()
		{
		}

		#region IKey Members

		public override string EntityKey
		{
			get{return Id.ToString();}
        }

        #endregion


        public int Id { get; set; }
        public string Module { get; set; }
        public string EmailCode { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }
        public string ProcessUser { get; set; }
        public System.DateTime ProcessDate { get; set; }
    }

}
