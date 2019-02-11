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
using HMS.Model.Operations;
using HMS.ViewModel;
using HMS.View.Masters;
using System.Data;

namespace HMS.View.Operations
{
    /// <summary>
    /// Interaction logic for Paidouts.xaml
    /// </summary>
    public partial class Paidouts : Page
    {
        PAIDOUT P = new PAIDOUT();
        public int error = 0;
        public Paidouts()
        {
            data.COUNT = 0;
            InitializeComponent();
            //disable();
            data.COUNT = 1;
            rbtn1.IsChecked = true;
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
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (error != 0 || txtauthorization.Text == "" || txtamount.Text == "" || txtparticualr.Text == "")
                {
                    //     pop1.IsOpen = true;
                    if (txtauthorization.Text == "")
                    { txtauthorization.Text = ""; }
                    if (txtamount.Text == "")
                    { txtamount.Text = ""; }
                    if (txtparticualr.Text == "")
                    { txtparticualr.Text = ""; }
                }
                else
                {
                    P.OUTLETCODE = CB.Text;
                    P.VOCHERNUMBER = txtvochernumber.Content.ToString();
                    //P.VOCHERNUMBER = lablle.Content.ToString();
                    P.AUTHORIZATIONS = txtauthorization.Text;
                    P.AMOUNT = txtamount.Text;
                    P.PARTICULAR = txtparticualr.Text;
                    //11/15/2017
                    //P.USER_NAME = login.u;
                    P.INSERT_BY = login.u;
                    P.INSERT_DATE = DateTime.Today;
                    P.PAYTYPE = cbpaytype.Text;
                    if (rbtn1.IsChecked == true)
                    {
                        P.INSERT();
                        MessageBox.Show("Saved sucessfully");
                        txtvochernumber.Visibility = Visibility.Visible;
                        //lablle.Visibility = Visibility.Hidden;
                        clearr();
                        this.NavigationService.Refresh();
                    }
                    else
                    {
                        P.AMOUNT_TYPE = "Cash";
                        P.INSERT1();
                        MessageBox.Show("Saved sucessfully");
                        clearr();
                        this.NavigationService.Refresh();
                    }
                }
            }
            catch (Exception) { }
        }
        private void rbtn2_Checked(object sender, RoutedEventArgs e)
        {
            txtvochernumber.Content = P.getid1();
            //cbpaytype.IsEnabled = false;
            pagename.Text = "Opening Balance Details";
            paytype_sp.Visibility = Visibility.Hidden;
            // txtvochernumber.Visibility = Visibility.Hidden;

            // lablle.Visibility = Visibility.Visible;
            //  lablle.Content = P.getid1();
        }
        private void rbtn1_Checked(object sender, RoutedEventArgs e)
        {
            txtvochernumber.Content = P.id();
            cbpaytype.SelectedIndex = 0;
            //cbpaytype.IsEnabled = true;
            pagename.Text = "Paid Out Details";
            paytype_sp.Visibility = Visibility.Visible;
        }
        //private void add_Click(object sender, RoutedEventArgs e)
        //{
        //    enable();
        //}
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            clearr();
        }
        //public void disable()
        //{
        //    rbtn1.IsEnabled = false; rbtn1.IsChecked = false;
        //    rbtn2.IsEnabled = false; rbtn2.IsChecked = false;
        //    txtvochernumber.IsEnabled = false; txtauthorization.IsEnabled = false;
        //    txtamount.IsEnabled = false; txtparticualr.IsEnabled = false; CB.IsEnabled = false;
        //   // add.IsEnabled = true;
        //    Save.IsEnabled = true; clearall.IsEnabled = true;
        //}
        public void enable()
        {
            rbtn1.IsEnabled = true; rbtn1.IsChecked = false;
            rbtn2.IsEnabled = true; rbtn2.IsChecked = false;
            txtvochernumber.IsEnabled = true; txtauthorization.IsEnabled = true;
            txtamount.IsEnabled = true; txtparticualr.IsEnabled = true; CB.IsEnabled = true;
            Save.IsEnabled = true; clearall.IsEnabled = true;
           // add.IsEnabled = false;
        }
        public void clearr()
        {
            txtvochernumber.Content = ""; txtparticualr.Clear(); txtamount.Clear(); txtauthorization.Clear();
           /* disable()*/ CB.SelectedIndex = 0;
            this.NavigationService.Refresh();
        }
    }
}
