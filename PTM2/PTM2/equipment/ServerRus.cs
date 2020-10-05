using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTM2.equipment
{
    class ServerRus:BaseEquipment
    {

        public ServerRus(string sName, double coef = 2)
        {
            PreName = "Сервер точного времени";
            K = coef;
        }
    }
}
