using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTM2.equipment
{
    [Serializable]
    public class Server:BaseEquipment
    {
        public Server(string pre, string sName, int inPrice, double coef = 2.6)
        {
            PreName = pre;
            ShortName = sName;
            FullName = PreName + ShortName;
            InPrise = inPrice;
            K = coef;
            Price = InPrise * K;

        }

        private Server()
        {

        }
    }
}
