using System;
using System.Collections.Generic;
using System.Text;
using Entity.VehicleEntities;
using PTB.BTS.Vehicle.Flow;
using Facade.PiFacade;

namespace Facade.TempFacade
{
    public class Test01Facade : CommonPIFacadeBase
    {
        public Test01Facade()
        {
            ObjKindOfVehicleList = new KindOfVehicleList(GetCompany());
        }

        public KindOfVehicleList ObjKindOfVehicleList;
        public KindOfVehicleList DataSourceKindOfVehicle
        {
            get
            {
                KindOfVehicleFlow flowMTB = new KindOfVehicleFlow();
                KindOfVehicleList mtbList = new KindOfVehicleList(GetCompany());

                flowMTB.FillMTBList(mtbList);
                flowMTB = null;

                KindOfVehicle kindOfVehicle;

                for (int i = 0; i < mtbList.Count; i++)
                {
                    kindOfVehicle = (KindOfVehicle)mtbList.BaseGet(i);
                    ObjKindOfVehicleList.Add(kindOfVehicle.AName.English, kindOfVehicle);
                }

                return mtbList;
            }
        }
    }
}
