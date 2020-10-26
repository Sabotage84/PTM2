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
        BaseEquipments pr;

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
            pr.ADDItem(new Server("Метроном-1000/GNS"));
        }
    }
}
