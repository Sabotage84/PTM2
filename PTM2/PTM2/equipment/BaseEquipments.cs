﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<BaseEquipment> eqList = new ObservableCollection<BaseEquipment>();

        private static readonly Lazy<BaseEquipments> lazy =
        new Lazy<BaseEquipments>(() => new BaseEquipments());

        public static BaseEquipments modulInstance { get { return lazy.Value; } }

        public ObservableCollection<BaseEquipment> EqList { get => eqList; set => eqList = value; }

        public IEnumerator GetEnumerator()
        {
            return EqList.GetEnumerator();
        }

        public void ADDItem(BaseEquipment item)
        {
            EqList.Add(item);
        }

        public void RemoveItem(BaseEquipment item)
        {
            EqList.Remove(item);
        }

        public void Save()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<BaseEquipment>));


            using (FileStream fs = new FileStream("eq.xml", FileMode.OpenOrCreate))
            {

                try
                {
                    formatter.Serialize(fs,EqList);
                }
                catch
                {
                    MessageBox.Show("Не удалось создать файл прайса!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }

        }

        internal BaseEquipments()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<BaseEquipment>));


            using (FileStream fs = new FileStream("eq.xml", FileMode.OpenOrCreate))
            {

                try
                {
                    EqList = (ObservableCollection<BaseEquipment>)formatter.Deserialize(fs);
                }
                catch
                {

                    MessageBox.Show("Файл с првйсом не найден!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Server s1 = new Server("Метроном-300/GNS");
                    s1.Description = "Metr 300";
                    s1.InPrise = 2250;
                    ADDItem(s1);
                    Server s2 = new Server("Метроном-200/GNS");
                    s2.Description = "Metr 200";
                    s2.InPrise = 1500;
                    ADDItem(s2);
                    formatter.Serialize(fs, EqList);
                }

            }
        }


        }
}
