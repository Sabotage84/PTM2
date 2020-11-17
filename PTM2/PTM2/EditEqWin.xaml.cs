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
                EditPrice_txtbx.Text = item.Price.ToString();
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
            bool check = true;
            t.Description = EditDescr_txtbx.Text;
            t.FullName = EditName_txtbl.Text;
            t.OfferNum = EditOffer_txtbx.Text;
            try
            {
                t.InPrise = double.Parse(EditInPrice_txtbx.Text);
            }
            catch (Exception)
            {
                check = false;
                MessageBox.Show("Не равильно задана входная цена");
            }
            try
            {
                t.K = int.Parse(EditK_txtbx.Text);
            }
            catch (Exception)
            {
                check = false;
                MessageBox.Show("Не равильно задан коэффициент");
            }
            try
            {
                t.Price = int.Parse(EditPrice_txtbx.Text);
            }
            catch (Exception)
            {
                check = false;
                MessageBox.Show("Не равильно задана цена");
            }
            if (check && t != null)
            {
                MainWindow.s = t;
                DialogResult = true;
                Close();
            }
        }

        private void CancelEdit_btn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void EditInPrice_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalculatePrice();
        }

        

        private void EditK_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalculatePrice();
        }

        private void EditPrice_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double t, k;
                if (!(string.IsNullOrEmpty(EditPrice_txtbx.Text) || string.IsNullOrEmpty(EditK_txtbx.Text)))
                {
                    t = double.Parse(EditPrice_txtbx.Text);
                    k = double.Parse(EditK_txtbx.Text);
                    EditInPrice_txtbx.Text = (t / k).ToString();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Входная цена или коэффициент имеют неверное значение!");
            }
        }

        private void CalculatePrice()
        {
            try
            {
                double t, k;
                if (!(string.IsNullOrEmpty(EditInPrice_txtbx.Text) || string.IsNullOrEmpty(EditK_txtbx.Text)))
                {
                    t = double.Parse(EditInPrice_txtbx.Text);
                    k = double.Parse(EditK_txtbx.Text);
                    EditPrice_txtbx.Text = (t * k).ToString();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Входная цена или коэффициент имеют неверное значение!");
            }
        }
    }
}
