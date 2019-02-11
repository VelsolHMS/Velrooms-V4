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
using HMS.Model;
using HMS.ViewModel;

namespace HMS.View.Operations
{
    /// <summary>
    /// Interaction logic for CheckinDeparture.xaml
    /// </summary>
    public partial class CheckinDeparture : Page
    {
        public int error = 0;
        mainwindowpages.operations o = new mainwindowpages.operations();
        public CheckinDeparture()
        {
            data.COUNT = 0;
            InitializeComponent();
            txtstaydep.Text = "";
            data.COUNT = 1;
            txttime.IsReadOnly = true;
        }
        public static string date; public string time;
        private void txtstaydep_LostFocus(object sender, RoutedEventArgs e)
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
        public static int p; 
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            if (error != 0)
            {
                pop1.IsOpen = true;
            }
            else
            {
                if (txttime.Text != "" && txtstaydep.Text != "")
                {
                    p = 1;
                    GroupCheckinDeparture.group = 0;
                    Vacant v = new Vacant();
                    this.NavigationService.Navigate(v);
                }
                else
                {
                    p = 0;
                    MessageBox.Show("Please enter  Stay-Days ");
                }
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            txttime.Text = ""; txtstaydep.Text = ""; this.NavigationService.Refresh();
            mainwindowpages.home h = new mainwindowpages.home();
            this.NavigationService.Navigate(h);
            o.Visibility = Visibility.Hidden;
            o.Foreground = new SolidColorBrush(Colors.White);
        }
    }
}
