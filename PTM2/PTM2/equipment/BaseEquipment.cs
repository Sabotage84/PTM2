using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTM2.equipment
{
    public class BaseEquipment : IComparable
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
                return K * InPrise;
            }
            }

        public string Description { get => description; set => description = value; }
        public double InPrise { get => inPrise; set => inPrise = value; }

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
            hashCode = hashCode * -1521134295 + InPrise.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(description);
            return hashCode;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            BaseEquipment otherEq = obj as BaseEquipment;
            if (otherEq != null)
                return this.FullName.CompareTo(otherEq.FullName);
            else
                throw new ArgumentException("Object is not a equipment");
        }
    }
}
