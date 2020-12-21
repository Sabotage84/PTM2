using PTM2.equipment;
using PTM2.Offers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PTM2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public BaseEquipments pr;
        public BaseEquipments offerL;
        
        public static BaseEquipment s=null;
        bool changes = false;

        public MainWindow()
        {
            InitializeComponent();
            
            pr = (BaseEquipments)PriceListLV.DataContext;
            offerL = (BaseEquipments)Offer_lstv.DataContext;
            this.DataContext = pr;
        }

        private void AddToKP_Click(object sender, RoutedEventArgs e)
        {
            offerL.AddToOffer((BaseEquipment)PriceListLV.SelectedItem);
        }

        private void AddToPriceList_Click(object sender, RoutedEventArgs e)
        {
            
            AddToPriceListWindow w = new AddToPriceListWindow();
            w.Owner = this;
            w.ShowDialog();
            if (s != null)
            {
                pr.ADDItem(s);
                pr.Sort();
                changes = true;

            }
            
        }

        private void SavePriceList_btn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Точно сохраняем?", "Save", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                pr.SevePriceList();
                changes = false;
            }
        }

        private void Remove_btn_Click(object sender, RoutedEventArgs e)
        {
            pr.RemoveItem((BaseEquipment)PriceListLV.SelectedItem);
            pr.Sort();
            changes = true;
        }

        private void EditPricePosition_Click(object sender, RoutedEventArgs e)
        {
            BaseEquipment selectedElement = (BaseEquipment)PriceListLV.SelectedItem;
            if (selectedElement != null)
            {
                EditEqWin w = new EditEqWin(selectedElement);
                w.Owner = this;
                w.ShowDialog();
                if (w.DialogResult == true)
                {
                    pr.RemoveItem((BaseEquipment)PriceListLV.SelectedItem);
                    pr.ADDItem(s);
                    pr.Sort();
                    changes = true;
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент для редактирования!");
            }
            
        }

        private void SearchEq_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            pr.SearchEqByName(SearchEq_txtbx.Text);
        }

        private void ClearSearchString_btn_Click(object sender, RoutedEventArgs e)
        {
            SearchEq_txtbx.Text = string.Empty;
        }

        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            if (changes)
            {
                if (MessageBox.Show("Сохранить изменения перед выходом?", "Save", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    pr.SevePriceList();
                }
            }
            Close();
        }

        private void RemoveFromOffer_btn_Click(object sender, RoutedEventArgs e)
        {
            offerL.RemoveFromOffer((BaseEquipment)Offer_lstv.SelectedItem);
        }

        private void CopyOfferToBuf_btn_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<BaseEquipment> tempCol = new ObservableCollection<BaseEquipment>();
            foreach (var item in Offer_lstv.Items)
            {
                tempCol.Add((BaseEquipment)item);
            }
            BufferOffer bo = new BufferOffer(tempCol);
            MessageBox.Show(bo.BufferMessage);

        }

        private void PositionUp_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Offer_lstv.SelectedItem!=null && Offer_lstv.SelectedIndex>0)
            {
                int t = Offer_lstv.SelectedIndex;
                offerL.PositionUpInOffer((BaseEquipment)Offer_lstv.SelectedItem);
                Offer_lstv.SelectedIndex = t - 1;
            }
        }

        private void PositionDown_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Offer_lstv.SelectedItem != null && Offer_lstv.SelectedIndex < Offer_lstv.Items.Count-1)
            {
                int t = Offer_lstv.SelectedIndex;
                offerL.PositionDownInOffer((BaseEquipment)Offer_lstv.SelectedItem);
                Offer_lstv.SelectedIndex = t + 1;
            }
        }
    }
}
