using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.VehicleEntities
{
    public static class ObjectCreater
    {
        public static CompulsoryDocNoBase CreateCompulsoryDocNo()
        {
            return new SMCompulsoryDocNo();
        }
    }
}
