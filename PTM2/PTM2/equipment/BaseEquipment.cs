﻿using System;
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
        public override bool Equals(object obj)
        {
            if(obj.GetType() != GetType()) return false;

            BaseEquipment item = (BaseEquipment)obj;
            return (item.FullName==FullName);
        }

        public override int GetHashCode()
        {
            var hashCode = 1327208659;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(preName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(shortName);
            hashCode = hashCode * -1521134295 + inPrise.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(description);
            return hashCode;
        }
    }
}
