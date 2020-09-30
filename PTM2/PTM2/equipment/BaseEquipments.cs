using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTM2.equipment
{
    class BaseEquipments: IEnumerable
    {
        List<BaseEquipment> eqList = new List<BaseEquipment>();

        public IEnumerator GetEnumerator()
        {
            return eqList.GetEnumerator();
        }

        public void ADDItem(BaseEquipment item)
        {
            eqList.Add(item);
        }

        public void RemoveItem(BaseEquipment item)
        {
            eqList.Remove(item);
        }
    }
}
