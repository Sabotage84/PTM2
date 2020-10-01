using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTM2.equipment
{
    class uschv:BaseEquipment
    {
        public uschv(string sName, double coef = 2.6)
        {
            PreName = "Устройство синхронизации частоты и времени";
            K = coef;

        }
    }
}
