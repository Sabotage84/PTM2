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
    /// Логика взаимодействия для EditEqWin.xaml
    /// </summary>
    /// 
    
    public partial class EditEqWin : Window
    {
        
        public EditEqWin(BaseEquipment item)
        {
            InitializeComponent();
            if(item!=null)
            {
                EditInPrice_txtbx.Text = item.Price.ToString();
                EditK_txtbx.Text = item.K.ToString();
                EditName_txtbl.Text = item.FullName;
                EditOffer_txtbx.Text = item.OfferNum;
                EditInPrice_txtbx.Text = item.InPrise.ToString();
                EditDescr_txtbx.Text = item.Description;
            }

        }

        private void SaveEdit_btn_Click(object sender, RoutedEventArgs e)
        {
            BaseEquipment t = new BaseEquipment();
            t.Description = EditDescr_txtbx.Text;
            t.FullName = EditName_txtbl.Text;
            t.InPrise = double.Parse(EditInPrice_txtbx.Text);
            t.K = int.Parse(EditK_txtbx.Text);
            t.OfferNum = EditOffer_txtbx.Text;
            t.Price = int.Parse(EditPrice_txtbx.Text);
            MainWindow.s =t;
            DialogResult = true;
            Close();
        }

        private void CancelEdit_btn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
