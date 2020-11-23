using PTM2.equipment;
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
        
        public static BaseEquipment s=null;
        bool changes = false;

        public MainWindow()
        {
            InitializeComponent();
            
            pr = (BaseEquipments)PriceListLV.DataContext; 
            this.DataContext = pr;
        }

        private void AddToKP_Click(object sender, RoutedEventArgs e)
        {
            
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
    }
}
