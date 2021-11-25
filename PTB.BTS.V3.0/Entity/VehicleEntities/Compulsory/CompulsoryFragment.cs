using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.VehicleEntities
{
    public struct CompulsoryFragment
    {
        private string prefix;
        public string Prefix
        {
            get
            {
                return prefix;
            }
            set
            {
                prefix = value;
            }
        }

        private string endorsement;
        public string Endorsement
        {
            get
            {
                return endorsement;
            }
            set
            {
                endorsement = value;
            }
        }

        private string number;
        public string Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }
    }
}
