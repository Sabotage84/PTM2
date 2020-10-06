using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTM2.equipment
{
    class Server:BaseEquipment
    {
        public Server(string sName, double coef = 2.6)
        {
            PreName = "Сервер точного времени";
            K = coef;




        }
    }
}
