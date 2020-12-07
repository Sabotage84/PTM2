using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PTM2.equipment
{
    [XmlInclude(typeof(Server))]
    [Serializable]
    public class BaseEquipment : IComparable
    {
        public BaseEquipment()
        {

        }
        public BaseEquipment(string sName, string discr, string offer, int inPrice, double coef = 2.6, TypeOfEquipment t=TypeOfEquipment.STV)
        {
            PreName = GetPreName(t);
            ShortName = sName;
            Description = discr;
            FullName = PreName + ShortName;
            InPrise = inPrice;
            K = coef;
            Price = InPrise * K;
        }

        public BaseEquipment(string sName, string discr, string offer, double price, double coef, TypeOfEquipment t=TypeOfEquipment.STV)
        {
            PreName = GetPreName(t);
            ShortName = sName;
            FullName = PreName + ShortName;
            Description = discr;
            InPrise = price;
            K = coef;
            Price = price * coef;
        }

        private string GetPreName(TypeOfEquipment t)
        {
            string res = "";
            switch (t)
            {
                case TypeOfEquipment.STV:
                    res = "Сервер точного времени";
                    break;
                case TypeOfEquipment.USCHV:
                    res = "Устройство синхронизации частоты и времени";
                    break;
                case TypeOfEquipment.POVERKA:
                    res = "";
                    break;
                case TypeOfEquipment.ANTENNA:
                    res = "Антенна";
                    break;
                case TypeOfEquipment.LIGHTPROT:
                    res = "Грозоразрядник";
                    break;
                case TypeOfEquipment.CABEL:
                    res = "Антенный кабель";
                    break;
                case TypeOfEquipment.SDU:
                    res = "Устройство синхронизации размножитель / конкертер";
                    break;
                case TypeOfEquipment.CON:
                    res = "Устройство синхронизации размножитель / конкертер";
                    break;
                case TypeOfEquipment.CLOCK:
                    res = "Часы";
                    break;
                default:
                    break;
            }
            return res;
        }

        public string PreName { get => preName; set => preName = value; }
        public string ShortName { get => shortName; set => shortName = value; }
        public double K { get => k; set => k = value; }
        public string Description { get => description; set => description = value; }
        public double InPrise { get => inPrise; set => inPrise = value; }
        public double Price { get => price; set => price = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string OfferNum { get => offerNum; set => offerNum = value; }
        public TypeOfEquipment Type { get => type; set => type = value; }

        TypeOfEquipment type;
        string offerNum;
        string preName;
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

    public enum TypeOfEquipment
    {
        STV, 
        USCHV,
        POVERKA,
        ANTENNA,
        LIGHTPROT,
        CABEL,
        SDU,
        CON,
        CLOCK
    }
}
