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
using HMS.ViewModel;
using System.Windows.Shapes;
using HMS.Model;
using System.Data.SqlClient;
using System.Data;

namespace HMS.View.Masters
{
    /// <summary>
    /// Interaction logic for TAXCODE.xaml
    /// </summary>
    public partial class TAXCODE : Page
    {
        Taxcode1 tax = new Taxcode1();
        public int error = 0;
        public void CLEAR()
        {
            txtactivedate.Text = "";
            txttaxcode.Text = "";
            txtfactor.Text = "";
            txtfromamount.Text = "";
            txttaxcode.Text = "";
            txttoamount.Text = "";
        }
        public TAXCODE()
        {
            data.COUNT = 0;
            InitializeComponent();
            data.COUNT = 1;
            txtactivedate.Text = DateTime.Today.Date.ToString();
            DataTable R1 = new DataTable();
            R1 = tax.fill_taxgrid();
            dgtax.ItemsSource = R1.DefaultView;
            AddAutoIncrementColumn();
            save.IsEnabled = true;
            Clear.IsEnabled = true;
            save.Content = "save";
            insertpop.Content = "insertpopup";
            //CLEAR();
        }
        private void AddAutoIncrementColumn()
        {
            DataColumn id = new DataColumn();
            id.DataType = System.Type.GetType("System.Int32");
            id.AutoIncrement = true;
            id.AutoIncrementSeed = 1;
            id.AutoIncrementStep = 1;
        }
        //private void ADD_Click(object sender, RoutedEventArgs e)
        //{
        //    CLEAR();
        //    txtactivedate.IsEnabled = true;
        //    ComboBox1.IsEnabled = true;
        //    txttaxcode.IsEnabled = true;
        //    ComboBox2.IsEnabled = true;
        //    ComboBox3.IsEnabled = true;
        //    ComboBox4.IsEnabled = true;
        //    txtfactor.IsEnabled = true;
        //    txtfromamount.IsEnabled = true;
        //    txttaxcode.IsEnabled = true;
        //    txttoamount.IsEnabled = true;
        //    save.IsEnabled = true;
        //    Clear.IsEnabled = true;
        //    modify.IsEnabled = false;
        //    ADD.IsEnabled = false;
        //    save.Content = "save";
        //    insertpop.Content = "insertpopup";

        //    ADD.Background = new SolidColorBrush(Colors.Orange);
        //    modify.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
        //}
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
        public DataTable ResultTable = new DataTable();
        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (error != 0 || txttaxcode.Text == "" || txtfromamount.Text == "" || ComboBox2.Text == "" || txtfactor.Text == "" || txtactivedate.Text == "") //|| Convert.ToInt32(txtfromamount.Text) > Convert.ToInt32(txttoamount.Text)
                {
                    //   pop1.IsOpen = true;
                    txtactivedate.Text = "";
                    if (txttaxcode.Text == "")
                    { txttaxcode.Text = ""; }
                    if (txtfromamount.Text == "")
                    { txtfromamount.Text = ""; }
                    if (txttoamount.Text == "")
                    { txttoamount.Text = ""; }
                    if (ComboBox2.Text == "")
                    { ComboBox2.Text = ""; }
                    if (txtfactor.Text == "")
                    { txtfactor.Text = ""; }
                    if (txtactivedate.Text == "")
                    {
                        txtactivedate.Text = string.Empty;
                        txtactivedate.Text = null;
                    }
                }
                else
                {
                    Taxcode1 CODE = new Taxcode1();
                    CODE.ACTIVEDATE = Convert.ToDateTime(txtactivedate.Text);
                    CODE.MODULE = ComboBox1.Text;
                    CODE.TAX_CODE = txttaxcode.Text;
                    CODE.TAX_NAME = ComboBox2.Text;
                    CODE.FROM_AMOUNT = txtfromamount.Text;
                    CODE.TO_AMOUNT = txttoamount.Text;
                    CODE.CALCULATION_TYPE = ComboBox3.Text;
                    CODE.FACTOR = txtfactor.Text;
                    CODE.STATUS = ComboBox4.Text;
                    CODE.INSERT_BY = login.u;
                    CODE.INSERT_DATE = DateTime.Today;

                    string a = "save", b = Convert.ToString(save.Content);
                    if (a == b)
                    {
                        CODE.INSERT();
                        DataTable R = CODE.fill_taxgrid();
                        dgtax.ItemsSource = R.DefaultView;
                        //MessageBox.Show("Saved Successfully");
                        popup_insert.IsOpen = true;
                    }
                    else
                    {

                        CODE.UPDATE();
                        DataTable dt = CODE.fill_taxdata();
                        dgtax.ItemsSource = dt.DefaultView;
                        //MessageBox.Show("Updated Successfully");
                        popup_update.IsOpen = true;
                        save.Content = "Save";
                    }
                    CLEAR();
                    this.NavigationService.Refresh();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("pleaase Enter correct vaues");
            }
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            CLEAR();
            this.NavigationService.Refresh();
            save.IsEnabled = false;
            Clear.IsEnabled = false;
            txtactivedate.IsEnabled = false;
            ComboBox1.IsEnabled = false;
            txttaxcode.IsEnabled = false;
            ComboBox2.IsEnabled = false;
            ComboBox3.IsEnabled = false;
            ComboBox4.IsEnabled = false;
            txtfactor.IsEnabled = false;
            txtfromamount.IsEnabled = false;
            txttaxcode.IsEnabled = false;
            txttoamount.IsEnabled = false;
        }
        private void modify_Click(object sender, RoutedEventArgs e)
        {
            txtactivedate.IsEnabled = true;
            txtfactor.IsEnabled = true;
            txtfromamount.IsEnabled = true;
            txttaxcode.IsEnabled = true;
            txttoamount.IsEnabled = true;
            ComboBox1.IsEnabled = true;
            ComboBox2.IsEnabled = true;
            ComboBox3.IsEnabled = true;
            ComboBox4.IsEnabled = true;
            save.IsEnabled = true;
            Clear.IsEnabled = true;
            // ADD.IsEnabled = false;
            save.Content = "UPDATE";
            insertpop.Content = "updatepopup";
        }
        private void txttaxcode_LostFocus(object sender, RoutedEventArgs e)
        {
            string a = "UPDATE", b = Convert.ToString(save.Content);
            if (b == a)
            {
                Taxcode1 CODE = new Taxcode1();
                CODE.TAX_CODE = txttaxcode.Text;
                CODE.UPDATE_BY = login.u;
                CODE.UPDATE_DATE = DateTime.Today;
                CODE.Retrive();
                txtactivedate.Text = Convert.ToString(CODE.ACTIVEDATE);
                ComboBox1.Text = CODE.MODULE;
                txttaxcode.Text = CODE.TAX_CODE;
                ComboBox2.Text = CODE.TAX_NAME;
                txtfromamount.Text = CODE.FROM_AMOUNT;
                txttoamount.Text = CODE.TO_AMOUNT;
                ComboBox3.Text = CODE.CALCULATION_TYPE;
                txtfactor.Text = CODE.FACTOR;
                ComboBox4.Text = CODE.STATUS;
            }
        }
        private void txtactivedate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtactivedate.SelectedDate < DateTime.Today.Date)
            {
                MessageBox.Show("Active date cannot be less than the current date");
                txtactivedate.Text = "";
            }
            else if (txtactivedate.SelectedDate == DateTime.Today.Date)
            {
                txtactivedate.Text = Convert.ToString(DateTime.Today.Date);
            }
        }
        private void dgtax_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int i = dgtax.SelectedIndex;
            DataTable dt = tax.fill_taxdata();
            if (dt.Rows.Count == 0)
            { }
            else
            {
                if (i >= 0)
                {
                    save.Content = "Update";
                    txtactivedate.Text = Convert.ToDateTime(dt.Rows[i]["ACTIVE_DATE"]).ToString();
                    txttaxcode.Text = dt.Rows[i]["TAX_CODE"].ToString();
                    ComboBox2.Text = dt.Rows[i]["TAX_NAME"].ToString();
                    ComboBox1.Text = dt.Rows[i]["MODULE"].ToString();
                    txtfromamount.Text = dt.Rows[i]["FROM_AMOUNT"].ToString();
                    txttoamount.Text = dt.Rows[i]["TO_AMOUNT"].ToString();
                    ComboBox3.Text = dt.Rows[i]["CALCULATION_TYPE"].ToString();
                    txtfactor.Text = dt.Rows[i]["FACTOR"].ToString();
                    ComboBox4.Text = dt.Rows[i]["STATUS"].ToString();
                }
                else
                { }
            }
        }
        private void dgtax_LoadingRow_1(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1);
        }
        public decimal fromamount, toamount;
        public static decimal amount, amount1;

        private void updatepop_Click(object sender, RoutedEventArgs e)
        {
            popup_update.IsOpen = false;
        }

        private void insertpop_Click(object sender, RoutedEventArgs e)
        {
            popup_insert.IsOpen = false;
        }

        private void txttoamount_LostFocus(object sender, RoutedEventArgs e)
        {
            Taxcode1 CODE = new Taxcode1();
            if(txtfromamount.Text == "")
            {
            }
            else
            {
                amount = decimal.Parse(txtfromamount.Text);
            }
            if(txttoamount.Text == "")
            {
            }
            else
            {
                amount1 = decimal.Parse(txttoamount.Text);
            }
            DataTable DT = CODE.values();
            if (DT.Rows.Count == 0) { }
            else
            {
                fromamount = decimal.Parse(DT.Rows[0]["FROM_AMOUNT"].ToString());
                toamount = decimal.Parse(DT.Rows[0]["TO_AMOUNT"].ToString());
            }
            if (amount1 < amount)
            {
                txtfromamount.Text = "";
                txttoamount.Text = "";
                MessageBox.Show("ToAmount cannot be lessthen FromAmount??" +
                                           "Please enter valid Amounts ");
            }
            else if (fromamount == amount && toamount == amount1)
            {
                if (txtfromamount.Text == "" || txttoamount.Text == "")
                {
                }
                else
                {
                    txtfromamount.Text = "";
                    txttoamount.Text = "";
                    MessageBox.Show("FromAmount And ToAmount's are already exicte ? please enter different amount");
                }
            }
            else
            {
            }
        }
    }
}