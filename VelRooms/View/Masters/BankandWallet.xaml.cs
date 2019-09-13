using HMS.Model.Masters;
using HMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace HMS.View.Masters
{
    /// <summary>
    /// Interaction logic for BankandWallet.xaml
    /// </summary>
    public partial class BankandWallet : Page
    {

        BankWallet1 B = new BankWallet1();
        public int error = 0;

        public BankandWallet()
        {
            data.COUNT = 0;
            InitializeComponent();
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

        private void Rbtn1_Checked(object sender, RoutedEventArgs e)
        {
            pagename.Text = "Bank Details";
            stkpnl1.Visibility = Visibility.Visible;
            stkpnl2.Visibility = Visibility.Hidden;
        }

        private void Rbtn2_Checked(object sender, RoutedEventArgs e)
        {
            pagenam.Text = "Wallet Details";
            stkpnl2.Visibility = Visibility.Visible;
            stkpnl1.Visibility = Visibility.Hidden;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {

            txtbankcode.Text = "";
            txtbankname.Text = "";
            txtaccountnumber.Text = "";
            txtreportname.Text = "";
            txtwalletcode.Text = "";
            txtwalletname.Text = "";
            txtreportnam.Text = "";
            ComboBox1.Text = "";
            ComboBox2.Text = "";
            clear.IsEnabled = false;
            Save.IsEnabled = false;
            Save.Content = "SAVE";
            txtbankcode.IsEnabled = false;
            txtbankname.IsEnabled = false;
            txtaccountnumber.IsEnabled = false;
            txtreportname.IsEnabled = false;
            ComboBox1.IsEnabled = false;
            txtwalletcode.IsEnabled = false;
            txtwalletname.IsEnabled = false;
            txtreportnam.IsEnabled = false;
            ComboBox2.IsEnabled = false;
            this.NavigationService.Refresh();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            BankWallet1 BN = new BankWallet1();
            if (rbtn1.IsChecked == true)
            {
                //MessageBox.Show("Bank");
                //Getting Details and Inserting into Bank Table
                if (error != 0 || txtbankcode.Text == "" || txtbankname.Text == "" || txtaccountnumber.Text == "" || txtreportname.Text == "")
                {
                    if (txtbankcode.Text == "")
                    { txtbankcode.Text = ""; }
                    if (txtbankname.Text == "")
                    { txtbankname.Text = ""; }
                    if (txtaccountnumber.Text == "")
                    { txtaccountnumber.Text = ""; }
                    if (txtreportname.Text == "")
                    { txtreportname.Text = ""; }
                }
                else
                {
                    BN.BANK_CODE = txtbankcode.Text;
                    BN.BANK_NAME = txtbankname.Text;
                    BN.ACCOUNT_NUMBER = txtaccountnumber.Text;
                    BN.REPORT_NAME = txtreportname.Text;
                    BN.STATUS = ComboBox1.Text;
                    BN.INSERT_BY = login.u;
                    BN.INSERT_DATE = DateTime.Today;
                    BN.INSERT();
                    this.NavigationService.Refresh();
                }
            }
            else if (rbtn2.IsChecked == true)
            {
                //MessageBox.Show("Wallet");
                //Getting Details and Inserting into wallet Table
                if (error != 0 || txtwalletcode.Text == "" || txtwalletname.Text == "" || txtreportnam.Text == "")
                {
                    if (txtwalletcode.Text == "")
                    { txtwalletcode.Text = ""; }
                    if (txtwalletname.Text == "")
                    { txtwalletname.Text = ""; }
                    if (txtreportnam.Text == "")
                    { txtreportnam.Text = ""; }
                }
                else
                {
                    BN.WALLET_CODE = txtwalletcode.Text;
                    BN.WALLET_NAME = txtwalletname.Text;
                    BN.REPORT_NAME = txtreportnam.Text;
                    BN.STATUS = ComboBox2.Text;
                    BN.INSERT_BY = login.u;
                    BN.INSERT_DATE = DateTime.Today;
                    BN.INSERT1();
                    this.NavigationService.Refresh();
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pop1.IsOpen = false;
        }

        private void Insertpop_Click(object sender, RoutedEventArgs e)
        {
            popup_insert.IsOpen = false;
        }

        private void AddAutoIncrementColumn()
        {
            DataColumn id = new DataColumn();
            id.DataType = System.Type.GetType("System.Int32");
            id.AutoIncrement = true;
            id.AutoIncrementSeed = 1;
            id.AutoIncrementStep = 1;
        }


        public void enable()
        {
            rbtn1.IsEnabled = true; rbtn1.IsChecked = false;
            rbtn2.IsEnabled = true; rbtn2.IsChecked = false;
            txtbankcode.IsEnabled = true; txtbankname.IsEnabled = true;
            txtaccountnumber.IsEnabled = true; txtreportname.IsEnabled = true;
            ComboBox1.IsEnabled = true; txtwalletcode.IsEnabled = true;
            txtwalletname.IsEnabled = true; txtreportnam.IsEnabled = true;
            ComboBox2.IsEnabled = true;
            Save.IsEnabled = true; clear.IsEnabled = true;
        }
    }
}
