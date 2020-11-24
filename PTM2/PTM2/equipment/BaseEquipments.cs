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
        ObservableCollection<BaseEquipment> defaultList = new ObservableCollection<BaseEquipment>();
        ObservableCollection<BaseEquipment> offerList = new ObservableCollection<BaseEquipment>();

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
        public ObservableCollection<BaseEquipment> DefaultList { get => defaultList; set => defaultList = value; }
        public ObservableCollection<BaseEquipment> OfferList { get => offerList; set => offerList = value; }

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
            DefaultList.Add(item);
            NotifyPropertyChanged();
        }

        public void RemoveItem(BaseEquipment item)
        {
            EqList.Remove(item);
            DefaultList.Remove(item);
        }
        private void eqList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged();
        }

        private void offerList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged();
        }
        internal BaseEquipments()
        {
            eqList.CollectionChanged += eqList_CollectionChanged;
            offerList.CollectionChanged += offerList_CollectionChanged;
            XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<BaseEquipment>));

            using (FileStream fs = new FileStream(@"C:\eq.xml", FileMode.OpenOrCreate))
            {

                try
                {
                    EqList = (ObservableCollection<BaseEquipment>)formatter.Deserialize(fs);
                    DefaultList = new ObservableCollection<BaseEquipment>(EqList);
                    //DefaultList = (ObservableCollection<BaseEquipment>)formatter.Deserialize(fs);
                }
                catch
                {
                    MessageBox.Show("Файл с првйсом не найден!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    
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
                    ObservableCollection<BaseEquipment> t = eqList;
                    EqList = DefaultList;
                    formatter.Serialize(fs, EqList);
                    EqList = t;
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить файл с прайсом!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public void Sort()
        {
            List<BaseEquipment> t = new List<BaseEquipment>(eqList);
            List<BaseEquipment> t1 = new List<BaseEquipment>(DefaultList);
            t.Sort();
            t1.Sort();
            EqList.Clear();
            foreach (var item in t)
            {
                EqList.Add(item);
            }
            DefaultList.Clear();
            foreach (var item in t1)
            {
                DefaultList.Add(item);
            }
        }
        public void AddToOffer(BaseEquipment item)
        {
            if (item != null)
                OfferList.Add(item);
        }
        public void SearchEqByName(string searchString)
        {
            if(string.IsNullOrEmpty(searchString))
            {
                EqList.Clear();
                foreach (var item in DefaultList)
                {
                    EqList.Add(item);
                }
            }
            else
            {
                List<BaseEquipment> t = new List<BaseEquipment>();
                foreach (var item in DefaultList)
                {
                    if (item.FullName.Contains(searchString))
                    {
                        t.Add(item);
                    }
                }
                EqList.Clear();
                foreach (var item in t)
                {
                    EqList.Add(item);
                }
            }
            Sort();
        }
    }
}
