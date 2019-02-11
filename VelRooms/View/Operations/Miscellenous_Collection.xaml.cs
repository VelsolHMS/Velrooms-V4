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

namespace HMS.View.Operations
{
    /// <summary>
    /// Interaction logic for Miscellenous_Collection.xaml
    /// </summary>
    public partial class Miscellenous_Collection : Page
    {
        public int error = 0;
        public Miscellenous_Collection()
        {
            data.COUNT = 0;
            InitializeComponent();
            data.COUNT = 1;
            //txtmember.IsEnabled = false;
            //cbrevenue.IsEnabled = false;
            //cbpayment.IsEnabled = false;
            //txtexchangerate.IsEnabled = false;
            //txtexchangeamount.IsEnabled = false;
            //txtcurrency.IsEnabled = false;
            //txtreceivedamt.IsEnabled = false;
            //cbtaxcode.IsEnabled = false;
            //txtparticulars.IsEnabled = false;
            //txttaxamount.IsEnabled = false;
            //txttotalamount.IsEnabled = false;
            txtcurrency.Text = "INR";
            btnclear.IsEnabled = true;
            btnsave.IsEnabled = true;
            miscellenous mi = new miscellenous();
            DataTable revenuecodes = mi.revenue();
            cbrevenue.ItemsSource = revenuecodes.DefaultView;
            DataTable taxcodes = mi.taxcodes();
            cbtaxcode.ItemsSource = taxcodes.DefaultView;
            receiptno.Content = mi.getid();
        }
        //private void btnadd_Click(object sender, RoutedEventArgs e)
        //{
        //    txtmember.IsEnabled = true;
        //    cbrevenue.IsEnabled = true;
        //    cbpayment.IsEnabled = true;
        //    txtexchangerate.IsEnabled = false;
        //    txtexchangeamount.IsEnabled = false;
        //    txtcurrency.IsEnabled = true;
        //    txtreceivedamt.IsEnabled = true;
        //    cbtaxcode.IsEnabled = true;
        //    txtparticulars.IsEnabled = true;
        //    txttaxamount.IsEnabled = true;
        //    txttotalamount.IsEnabled = true;

        //    btnclear.IsEnabled = true;
        //    btnsave.IsEnabled = true;
        //    btnmodify.IsEnabled = false;
        //    btnadd.IsEnabled = false;
        //    insertpop.Content = "insertpopup";
        //    clear();

        //    btnsave.Content = "Save";
        //}
        private void btnclear_Click(object sender, RoutedEventArgs e)
        {
            clear();
            //btnadd.IsEnabled = true;
            //btnmodify.IsEnabled = true;
            btnclear.IsEnabled = true;
            btnsave.IsEnabled = false;
            this.NavigationService.Refresh();
            btnsave.Content = "Save";
        }
        public void clear()
        {
            txtmember.Text = "";
            cbrevenue.Text = "";
            cbpayment.Text = "";
            txtexchangerate.Text = "";
            txtexchangeamount.Text = "";
            txtreceivedamt.Text = "";
            cbtaxcode.Text = "";
            txtparticulars.Text = "";
            txttaxamount.Text = "";
            txttotalamount.Text = "";
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
        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (error != 0||txtmember.Text==""||txtreceivedamt.Text==""||txtparticulars.Text=="")
                {
                 //   pop1.IsOpen = true;
                    if(txtmember.Text=="")
                        { txtmember.Text = ""; }
                    if(txtreceivedamt.Text=="")
                        { txtreceivedamt.Text = ""; }
                    if(txtparticulars.Text=="")
                        { txtparticulars.Text = ""; }
                }
                else
                {
                    miscellenous mi = new miscellenous();
                    mi.MEMBER_NAME = txtmember.Text;
                    mi.REVENUE = cbrevenue.Text;
                    mi.PAYMENT_MODE = cbpayment.Text;
                    mi.EXCHANGE_RATE = txtexchangerate.Text;
                    mi.EXCHANGE_AMOUNT = txtexchangeamount.Text;
                    mi.CURRENCY_CODE = txtcurrency.Text;
                    mi.RECEIVED_AMOUNT = txtreceivedamt.Text;
                    mi.TAX_CODE = cbtaxcode.Text;
                    mi.PARTICULARS = txtparticulars.Text;
                    mi.TAX_AMOUNT = txttaxamount.Text;
                    mi.TOTAL_AMOUNT = txttotalamount.Text;
                    //ss r r ii uu ii 11/15/2017
                    //mi.USER_NAME = login.u;
                    mi.INSERT_BY = login.u;
                    mi.INSERT_DATE = DateTime.Today;

                    mi.Insert();
                    string a1 = "Save", b1 = Convert.ToString(btnsave.Content);
                    if (b1 == a1)
                    {
                        MessageBox.Show("Saved sucessfully");
                        clear();
                        this.NavigationService.Refresh();
                        //insert.Content = "Inserted Sucessfully";
                        //pop2.IsOpen = true;
                    }
                    // btnadd.IsEnabled = true;
                    btnclear.IsEnabled = true;
                    btnsave.IsEnabled = true;
                    //btnmodify.IsEnabled = false;
                    clear();
                    btnsave.Content = "Save";
                    this.NavigationService.Refresh();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("please check the values");
            }
        }
        //private void btnmodify_Click(object sender, RoutedEventArgs e)
        //{
        //    txtmember.IsEnabled = true;
        //    cbrevenue.IsEnabled = true;
        //    cbpayment.IsEnabled = true;
        //    txtexchangerate.IsEnabled = false;
        //    txtexchangeamount.IsEnabled = false;
        //    txtcurrency.IsEnabled = true;
        //    txtreceivedamt.IsEnabled = true;
        //    cbtaxcode.IsEnabled = true;
        //    txtparticulars.IsEnabled = true;
        //    txttaxamount.IsEnabled = true;
        //    txttotalamount.IsEnabled = true;

        //   // btnadd.IsEnabled = false;
        //    btnclear.IsEnabled = true;
        //    btnsave.IsEnabled = true;
        //    btnmodify.IsEnabled = false;
        //    btnsave.Content = "Update";
        //}
        private void txtmember_LostFocus(object sender, RoutedEventArgs e)
        {
            //miscellenous mi = new miscellenous();
            //string a = "Update", b = Convert.ToString(btnsave.Content);
            //if (b == a)
            //{
            //    mi.MEMBER_NAME = txtmember.Text;
            //    mi.UPDATE_BY = login.u;
            //    mi.UPDATE_DATE = DateTime.Today.ToShortDateString();
            //    mi.Retrive();
            //    cbrevenue.Text = mi.REVENUE;
            //    cbpayment.Text = mi.PAYMENT_MODE;
            //    txtexchangerate.Text = mi.EXCHANGE_RATE;
            //    txtexchangeamount.Text = mi.EXCHANGE_AMOUNT;
            //    txtcurrency.Text = mi.CURRENCY_CODE;
            //    txtreceivedamt.Text = mi.RECEIVED_AMOUNT;
            //    cbtaxcode.Text = mi.TAX_CODE;
            //    txttaxamount.Text = mi.TAX_AMOUNT;
            //    txtparticulars.Text = mi.PARTICULARS;
            //    txttotalamount.Text = mi.TOTAL_AMOUNT;
            //}
        }
        private void cbtaxcode_DropDownClosed(object sender, System.EventArgs e)
        {
            miscellenous mi = new miscellenous();
            try
            {
                mi.TAX_CODE = cbtaxcode.Text;
                DataTable tax = mi.tax();
                mi.REVENUE = cbrevenue.Text;
                DataTable d = mi.mixtax();

                //Percentage Calculation For Received Amount            
                decimal taxamountvalue = 0, taxamount = 0, totalamount = 0, receivedamountvalue = 0, receivedamount = 0, MISTAX = 0, MISAMOUNT = 0;
                decimal.TryParse(tax.Rows[0]["FACTOR"].ToString(), out taxamountvalue);
                decimal.TryParse(txtreceivedamt.Text, out receivedamountvalue);
                decimal.TryParse(d.Rows[0]["MIS_TAX_STRUCTURE"].ToString(), out MISTAX);
                if (decimal.TryParse(txtreceivedamt.Text, out receivedamount))
                {
                    taxamount = (receivedamount * taxamountvalue) / 100;
                    MISAMOUNT = (receivedamount * MISTAX) / 100;
                    totalamount = receivedamountvalue + taxamount + MISAMOUNT;

                    txttaxamount.Text = taxamount.ToString();
                    txttotalamount.Text = totalamount.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("please check the revenue and taxcode");
            }
        }
        private void insertpop_Click(object sender, RoutedEventArgs e)
        {
            pop2.IsOpen = false;
        }
        private void txttaxamount_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
        private void cbrevenue_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                miscellenous m = new miscellenous();
                m.REVENUE = cbrevenue.Text;
                DataTable s = m.mixtax();
                mixtax.Content = s.Rows[0]["MIS_TAX_STRUCTURE"].ToString();
            }
            catch (Exception) { }
        }
    }
}
