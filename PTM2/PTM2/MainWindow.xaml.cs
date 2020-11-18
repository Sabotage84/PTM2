﻿using PTM2.equipment;
using System;
using System.Collections.Generic;
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
        public static BaseEquipment s;

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
            pr.ADDItem(s);
            pr.Sort();

        }

        private void SavePriceList_btn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Точно сохраняем?", "Save", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                pr.SevePriceList();
        }

        private void Remove_btn_Click(object sender, RoutedEventArgs e)
        {
            pr.RemoveItem((BaseEquipment)PriceListLV.SelectedItem);
            pr.Sort();
        }

        private void EditPricePosition_Click(object sender, RoutedEventArgs e)
        {
            EditEqWin w = new EditEqWin((BaseEquipment)PriceListLV.SelectedItem);
            w.Owner = this;
            w.ShowDialog();
            if (w.DialogResult==true)
            {
                pr.RemoveItem((BaseEquipment)PriceListLV.SelectedItem);
                pr.ADDItem(s);
                pr.Sort();
            }
        }

        private void SearchEq_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            pr.SearchEqByName(SearchEq_txtbx.Text);
        }
    }
}
