using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.CommonEntity {    

    public partial class ApplicationConfiguration : EntityBase, IKey
    {
        public ApplicationConfiguration() : base()
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
        public string ConfigCode { get; set; }
        public string ConfigValue { get; set; }
        public string ValueType { get; set; }
        public string Description { get; set; }
        public string ProcessUser { get; set; }
        public System.DateTime ProcessDate { get; set; }
    }

}
