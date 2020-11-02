using PTM2.equipment;
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
            int p = int.Parse(Price_txtbx.Text);
            double k = double.Parse(K_txtbx.Text);
            
            MainWindow.s = new Server("", sName, des, p, k);
            Close();
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
    }
}
