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
using System.Windows.Shapes;

namespace PTM2
{
    /// <summary>
    /// Логика взаимодействия для AddToPriceListWindow.xaml
    /// </summary>
    public partial class AddToPriceListWindow : Window
    {
        BaseEquipments beq;
        public AddToPriceListWindow()
        {
            InitializeComponent();
            beq = BaseEquipments.modulInstance;
        }

        private void AddEq_btn_Click(object sender, RoutedEventArgs e)
        {
            string sName = Name_txtbx.Text;
            string des = Description_txtbx.Text;
            string offerNum = OfferNumber_txtbx.Text;
            bool allRight = true;
            int p=0;
            double dp = 0;
            double k=0;
            if (fullPrice_rdbtn.IsChecked==true)
            {
                try
                {
                    Price_txtbx.BorderBrush = Brushes.Gray;
                    p = int.Parse(Price_txtbx.Text);
                }
                catch (Exception)
                {
                    allRight = false;
                    Price_txtbx.BorderBrush = Brushes.Red;
                }

                try
                {
                    k = double.Parse(K_txtbx.Text);
                    K_txtbx.BorderBrush = Brushes.Gray;
                }
                catch (Exception)
                {
                    K_txtbx.BorderBrush = Brushes.Red;
                    allRight = false;
                }
                if (allRight)
                {
                    MainWindow.s = new BaseEquipment(sName, des, offerNum, p, k);
                    Close();
                }
            }
            if (inPrice1.IsChecked==true)
            {
                try
                {
                    InPrice_txtbx.BorderBrush = Brushes.Gray;
                    dp = double.Parse(InPrice_txtbx.Text);
                }
                catch (Exception)
                {
                    allRight = false;
                    InPrice_txtbx.BorderBrush = Brushes.Red;
                }

                try
                {
                    k = double.Parse(KK.Text);
                    KK.BorderBrush = Brushes.Gray;
                }
                catch (Exception)
                {
                    KK.BorderBrush = Brushes.Red;
                    allRight = false;
                }
                string type1="STV", type2="Сервер точного времени";
                if (NewTypeOfEq_chbx.IsChecked == false)
                {
                    if (string.IsNullOrEmpty(TypeOFeq_cmbx.SelectedItem.ToString()))
                    {
                        allRight = false;
                        MessageBox.Show("Неверный тип оборудования!");
                    }
                    else
                    {
                        type1 = TypeOFeq_cmbx.SelectedItem.ToString();
                        type2 = beq.TypeOfEquipment[type1];
                    }
                }
                else
                {
                    beq.TypeOfEquipment.Add(NewTypeOfEq_txtbx.Text, NewTypeOfEqDes_txtbx.Text);
                    type1 = NewTypeOfEq_txtbx.Text;
                    type2 = beq.TypeOfEquipment[type1];
                }
                if (allRight)
                {
                    MainWindow.s = new BaseEquipment(sName, des, offerNum, dp, k, type2, type1);
                    Close();
                }

            }
            
            
            
            
        }

        private void fullPrice_rdbtn_Checked(object sender, RoutedEventArgs e)
        {
            K_txtbx.IsEnabled = true;
            Price_txtbx.IsEnabled = true;
        }

        private void fullPrice_rdbtn_Unchecked(object sender, RoutedEventArgs e)
        {
            K_txtbx.IsEnabled = false;
            Price_txtbx.IsEnabled = false;
        }

        private void inPrice1_Checked(object sender, RoutedEventArgs e)
        {
            InPrice_txtbx.IsEnabled = true;
            KK.IsEnabled = true;

        }

        private void inPrice1_Unchecked(object sender, RoutedEventArgs e)
        {
            InPrice_txtbx.IsEnabled = false;
            KK.IsEnabled = false;
        }

        private void CancelAddEq_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.s = null;
            Close();
        }

        private void NewTypeOfEq_chbx_Checked(object sender, RoutedEventArgs e)
        {
            TypeOFeq_cmbx.IsEnabled = false;
            NewTypeOfEq_txtbx.IsEnabled = true;
            NewTypeOfEqDes_txtbx.IsEnabled = true;
        }

        private void NewTypeOfEq_chbx_Unchecked(object sender, RoutedEventArgs e)
        {
            NewTypeOfEq_txtbx.Text = string.Empty;
            NewTypeOfEq_txtbx.IsEnabled = false;
            NewTypeOfEqDes_txtbx.Text = string.Empty;
            NewTypeOfEqDes_txtbx.IsEnabled = false;
            TypeOFeq_cmbx.IsEnabled = true;
        }
    }
}
