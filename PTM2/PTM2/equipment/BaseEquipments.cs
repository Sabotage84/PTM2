using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace PTM2.equipment
{
    [Serializable]
    public class BaseEquipments: IEnumerable, INotifyPropertyChanged
    {
        ObservableCollection<BaseEquipment> eqList = new ObservableCollection<BaseEquipment>();

        private static readonly Lazy<BaseEquipments> lazy =
        new Lazy<BaseEquipments>(() => new BaseEquipments());

        public event PropertyChangedEventHandler PropertyChanged;

        public static BaseEquipments modulInstance { get { return lazy.Value; } }

        public ObservableCollection<BaseEquipment> EqList { get => eqList; 
            set
                {
                    eqList = value;
                }
            }

        public IEnumerator GetEnumerator()
        {
            return EqList.GetEnumerator();
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void ADDItem(BaseEquipment item)
        {

            eqList.Add(item);
            NotifyPropertyChanged();
        }

        public void RemoveItem(BaseEquipment item)
        {
            EqList.Remove(item);
        }

        

        private void eqList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged();
        }

        internal BaseEquipments()
        {
            eqList.CollectionChanged += eqList_CollectionChanged;

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
                    //Server s1 = new Server("СТВ","Метроном-300/GNS","Metr 300" ,2250);
                    //ADDItem(s1);
                    //Server s2 = new Server("СТВ","Метроном-200/GNS","Metr 200" ,1500);
                    //ADDItem(s2);
                    formatter.Serialize(fs, EqList);
                }

            }
        }
        public void SevePriceList()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<BaseEquipment>));


            using (FileStream fs = new FileStream("eq.xml", FileMode.Create))
            {
                try
                {
                    formatter.Serialize(fs, EqList);
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить файл с прайсом!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        }
}
