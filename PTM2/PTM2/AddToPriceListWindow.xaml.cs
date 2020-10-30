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
            int p = int.Parse(inPrice_txtbx.Text);
            double k = double.Parse(K_txtbx.Text);
            
            MainWindow.s = new Server("", sName, des, p, k);
            Close();
        }
    }
}
