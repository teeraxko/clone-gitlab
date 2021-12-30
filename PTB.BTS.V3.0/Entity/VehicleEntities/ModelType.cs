using System;

using ictus.Common.Entity.General;

namespace Entity.VehicleEntities
{
	public class ModelType : DualFieldBase
	{
//		============================== Constructor ==============================
		public ModelType() : base()
		{
		}

        public string Model_Type { get; set; }
        public string ThaiDescription { get; set; }
        public string EnglishDescription { get; set; }
        public DateTime ProcessDate { get; set; }
        public string ProcessUser { get; set; }
	}
}
