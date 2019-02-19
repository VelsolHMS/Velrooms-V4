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
using HMS.ViewModel;
using HMS.Model;
using HMS.Model.Operations;

namespace HMS.View.Operations
{
    /// <summary>
    /// Interaction logic for GroupCheckinDeparture.xaml
    /// </summary>
    public partial class GroupCheckinDeparture : Page
    {
        public static string date;
        public static int rooms, group, days;
        public int error = 0;
        gruopcheckin gc = new gruopcheckin();
        public GroupCheckinDeparture()
        {
            data.COUNT = 0;
            InitializeComponent();
            data.COUNT = 1;
        }
        private void txtstaydep_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime d;
                int value;
                if (int.TryParse(txtstaydep.Text, out value))
                {
                    DateTime dt = DateTime.Now;
                    dt = dt.AddDays(value);
                    d = dt.Date;
                    date = d.ToString("d");
                }
                else if (DateTime.TryParse(txtstaydep.Text, out d))
                {
                    date = d.ToShortDateString();
                }
                DateTime dtt = DateTime.Now;
                txttime.Text = dtt.ToString("hh:mm:ss tt");
            }
            catch (Exception) { }
        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                error++;
            else
                error--;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pop1.IsOpen = false;
        }
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            if (error != 0)
            {
                pop1.IsOpen = true;
            }
            else
            {
                if (txtrooms.Text != "" && txttime.Text != "" && txtstaydep.Text != "")
                {
                    days = int.Parse(txtstaydep.Text);
                    group = 1;
                    
                    Vacant v = new Vacant();
                    this.NavigationService.Navigate(v);
                }
                else
                {
                    MessageBox.Show("Please enter  Stay-Days ");
                }
            }
        }
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            txttime.Text = ""; txtstaydep.Text = ""; this.NavigationService.Refresh();
            mainwindowpages.home h = new mainwindowpages.home();
            this.NavigationService.Navigate(h);
        }
        private void txtrooms_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtrooms.Text))
                {
                    txtrooms.Text = "";
                    this.NavigationService.Refresh();
                }
                else
                {
                    rooms = int.Parse(txtrooms.Text);
                    if(rooms > 4)
                    {
                        txtrooms.Text = "";
                        MessageBox.Show("You can't book more than 4 rooms.!");
                    }
                    else if(rooms < 2)
                    {
                        txtrooms.Text = "";
                        MessageBox.Show("You need to book atleast 2 Rooms.!");
                    }
                }
            }
            catch (Exception)
            {
                txtrooms.Text = "";
                MessageBox.Show("Please type only numbers.!");
            }
        }
    }
}
