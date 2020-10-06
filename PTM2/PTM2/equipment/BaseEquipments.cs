using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace PTM2.equipment
{
    [Serializable]
    public class BaseEquipments: IEnumerable
    {
        List<BaseEquipment> eqList = new List<BaseEquipment>();

        private static readonly Lazy<BaseEquipments> lazy =
        new Lazy<BaseEquipments>(() => new BaseEquipments());

        public static BaseEquipments modulInstance { get { return lazy.Value; } }

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

        public void Save()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<BaseEquipment>));


            using (FileStream fs = new FileStream("eq.xml", FileMode.OpenOrCreate))
            {

                try
                {
                    formatter.Serialize(fs,eqList);
                }
                catch
                {
                    MessageBox.Show("Не удалось создать файл прайса!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }

        }

        private BaseEquipments()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<BaseEquipment>));


            using (FileStream fs = new FileStream("eq.xml", FileMode.OpenOrCreate))
            {

                try
                {
                    eqList = (List<BaseEquipment>)formatter.Deserialize(fs);
                }
                catch
                {

                    MessageBox.Show("Файл с првйсом не найден!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Server s1 = new Server("Метроном-300/GNS");
                    s1.Description = "Metr 300";
                    s1.InPrise = 2250;
                    Server s2 = new Server("Метроном-200/GNS");
                    s2.Description = "Metr 200";
                    s2.InPrise = 1500;

                    formatter.Serialize(fs, eqList);
                }

            }
        }


        }
}
