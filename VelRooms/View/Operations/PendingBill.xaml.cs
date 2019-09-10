using HMS.Model.Operations;
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
using System.Data;
using HMS.View.Masters;
using HMS.View.Operations;

namespace HMS.View.Operations
{
    /// <summary>
    /// Interaction logic for PendingBill.xaml
    /// </summary>
    public partial class PendingBill : Page
    {
        public int error = 0;
        public PendingBill()
        {
            data.COUNT = 0;
            InitializeComponent();
            data.COUNT = 1;
            txtbalanceamount1.IsEnabled = false;
        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                error++;
            else
                error--;
        }
        private void rd_Checked(object sender, RoutedEventArgs e)
        {
            grid1.Visibility = Visibility.Visible;
            grd2.Visibility = Visibility.Hidden;
            Submit1.Visibility = Visibility.Visible;
            Clear1.Visibility = Visibility.Visible;
        }
        private void rd1_Checked(object sender, RoutedEventArgs e)
        {
            grid1.Visibility = Visibility.Hidden;
            grd2.Visibility = Visibility.Visible;
            Submit1.Visibility = Visibility.Hidden;
            Clear1.Visibility = Visibility.Hidden;
        }
        Settle1 s = new Settle1();
        private void dt_CalendarClosed(object sender, RoutedEventArgs e)
        {
            s.INSERT_DATE = Convert.ToDateTime(dt.Text);
        }
        private void txtbillno_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                s.BILL_NO = txtbillno.Text;
                s.get();
                txtresno.Text = s.REGISTRATIOIN_NO;
                txtroomnno.Text = s.ROOM_NO;
                txtname.Text = s.GUEST_NAME;
                txtcompanyname.Text = s.COMPANYNAME;
                txtpendingamount1.Text = s.BALANCE_AMOUNT;
                txtpendingamount1.IsReadOnly = true;
            }
            catch (Exception) { }
        }
        private void txtamount1_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal a = decimal.Parse(txtpendingamount1.Text);
                decimal b = decimal.Parse(txtamount1.Text);
                decimal c = a - b;
                txtbalanceamount1.Text = c.ToString();
                if (txtbalanceamount1.Text == "0.00")
                {
                    combobox4.IsEnabled = false;
                }
                else
                {
                    combobox4.IsEnabled = true;
                }
                if (txtamount1.Text == "0")
                {
                    Submit1.IsEnabled = false;
                }
                else
                {
                    Submit1.IsEnabled = true;
                }
            }
            catch(Exception){
                MessageBox.Show("please enter correct values");
            }
        }
        public void clear()
        {
            dt.Text = "";
            txtbillno.Text = "";
            txtresno.Text = "";
            txtroomnno.Text = "";
            txtname.Text = "";
            txtcompany.Text = "";
            txtcompanyname.Text = "";
            txtamount1.Text = "";
            txtbalanceamount1.Text = "";
            txtpendingamount1.Text = "";
            txtremarks1.Text = "";
            combobox3.SelectedIndex = 0;
            combobox4.SelectedIndex = 0;
            this.NavigationService.Refresh();
        }
        private void Clear1_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }
        private void txtcompanyname1_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Pendingbill p = new Pendingbill();
                p.COMPANY_NAME = txtcompanyname1.Text;
                p.get();
                txtbillretrive.Text = p.BILL_NO;
                txtpendingamount.Text = p.PENDING_AMOUNT;
            }
            catch (Exception) { }
        }
        private void txtamount_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal a = decimal.Parse(txtpendingamount.Text);
                decimal b = decimal.Parse(txtamount.Text);
                decimal c = a - b;
                txtbalanceamount.Text = c.ToString();
                if (txtbalanceamount.Text == "0.00")
                {
                    combobox1.IsEnabled = false;
                }
                else
                {
                    combobox1.IsEnabled = true;
                }
                if (txtamount.Text == "0")
                {
                    Submit.IsEnabled = false;
                }
                else
                {
                    Submit.IsEnabled = true;
                }
            }
            catch (Exception) {
                MessageBox.Show("please enter correct values");
                txtamount.Text = "";
            }
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            clear1();
        }
        public void clear1()
        {
            txtcompanyname1.Text = "";
            txtpendingamount.Text = "";
            txtamount.Text = "";
            txtbalanceamount.Text = "";
            combobox.Text = "";
            combobox1.Text = "";
            txtremarks.Text = "";
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pendingbill b = new Pendingbill();
                b.COMPANY_NAME = txtcompanyname1.Text;
                b.PENDING_AMOUNT = txtpendingamount.Text;
                b.Amount_Recevied = txtamount.Text;
                b.BALANCE_AMOUNT = txtbalanceamount.Text;
                b.PAYMENT_TYPE = combobox.Text;
                b.PENDING_PAY_TYPE = combobox1.Text;
                b.REMARKS = txtremarks.Text;
                b.insert1();
                clear1();
                //  this.NavigationService.Refresh();
                //MessageBox.Show("Saved Successfully");
                popup_insert.IsOpen = true;
            }
            catch (Exception) { }
        }
        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("mainwindowpages/home.xaml", UriKind.RelativeOrAbsolute));
        }
        private void Submit1_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (error != 0 || txtbillno.Text == "" || txtamount1.Text == "")
                {
                    if (txtbillno.Text == "")
                    { txtbillno.Text = ""; }
                    if (txtamount1.Text == "")
                    { txtamount1.Text = ""; }
                }
                else
                {
                    Pendingbill p = new Pendingbill();
                    p.BILL_DATE = dt.Text;
                    p.BILL_NO = txtbillno.Text;
                    p.Registration_No = txtresno.Text;
                    p.ROOM_NO = txtroomnno.Text;
                    p.GUEST_NAME = txtname.Text;
                    p.COMPANY_CODE = txtcompany.Text;
                    p.COMPANY_NAME = txtcompanyname.Text;
                    p.Amount_Recevied = txtamount1.Text;
                    p.PENDING_AMOUNT = txtpendingamount1.Text;
                    p.BALANCE_AMOUNT = txtbalanceamount1.Text;
                    p.PAYMENT_TYPE = combobox3.Text;
                    
                    if (txtbalanceamount1.Text == "0.00")
                    {
                        p.PENDING_PAY_TYPE = "Settled";
                        p.REMARKS = txtremarks1.Text;
                        p.INSERT();
                        p.balance_update();
                        p.status_update();
                        clear();
                        this.NavigationService.Refresh();
                        //MessageBox.Show("Saved Successfully");
                        popup_insert.IsOpen = true;
                    }
                    else
                    {
                        p.PENDING_PAY_TYPE = combobox4.Text;
                        p.REMARKS = txtremarks1.Text;
                        p.INSERT();
                        p.balance_update();
                        clear();
                        this.NavigationService.Refresh();
                        //MessageBox.Show("Updated Successfully");
                        popup_update.IsOpen = true;
                    }
                }
            }
            catch (Exception) { }
        }

        private void insertpop_Click(object sender, RoutedEventArgs e)
        {
            popup_insert.IsOpen = false;
        }

        private void updatepop_Click(object sender, RoutedEventArgs e)
        {
            popup_update.IsOpen = false;
        }
    }
}
