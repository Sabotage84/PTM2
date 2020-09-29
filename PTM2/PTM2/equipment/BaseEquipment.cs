using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTM2.equipment
{
    class BaseEquipment
    {
        string preName;

        public string PreName { get => preName; set => preName = value; }
        public string ShortName { get => shortName; set => shortName = value; }
        public string FullName { 
            get {
                return PreName + " " + ShortName; 
            } }

        public double K { get => k; set => k = value; }
        public double Price { get
            {
                return K * inPrise;
            }
            }

        public string Description { get => description; set => description = value; }

        string shortName;
        string fullName;
        double inPrise;
        double k;
        double price;
        string description;


    }
}
