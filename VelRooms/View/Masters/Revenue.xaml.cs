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
using System.Data.SqlClient;
using System.Data;

namespace HMS.View.Masters
{
    /// <summary>
    /// Interaction logic for Revenue.xaml
    /// </summary>
    public partial class Revenue : Page
    {
        revenue re = new revenue();
        public int error = 0;
        public Revenue()
        {
            data.COUNT = 0;
            InitializeComponent();
            data.COUNT = 1;
            insertpop.Content = "insertpopup";
            Save.Content = "Save";
            DataTable dt = re.fill_revenuegrid();
            dgrevenue.ItemsSource = dt.DefaultView;
            //txtrevenuecode.IsEnabled = false;
            //txttaxstructure.IsEnabled = false;
            //txtname.IsEnabled = false;
            //txtmistaxstructure.IsEnabled = false;

            //COMBOBOX2.IsEnabled = false;
            //COMBOBOX3.IsEnabled = false;
            //COMBOBOX4.IsEnabled = false;

            Save.IsEnabled = true;
            clear.IsEnabled = true;
        }
       // private void add_Click(object sender, RoutedEventArgs e)
       // {
       //     txtrevenuecode.IsEnabled = true;
       //     txttaxstructure.IsEnabled = true;
       //     txtname.IsEnabled = true;
       //     txtmistaxstructure.IsEnabled = true;
       //     COMBOBOX2.IsEnabled = true;
       //     COMBOBOX3.IsEnabled = true;
       //     COMBOBOX4.IsEnabled = true;

       //     Save.IsEnabled = true;
       //     clear.IsEnabled = true;
       //     Modify.IsEnabled = false;
       //     add.IsEnabled = false;

       //     clearing();
       ////     insertpop.Content = "insertpopup";
       //     Save.Content = "Save";

       //     add.Background = new SolidColorBrush(Colors.Orange);
       //     Modify.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
       // }

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
                if (error != 0 ||txtrevenuecode.Text =="" ||txtname.Text=="" || txttaxstructure.Text ==""||txtmistaxstructure.Text=="")
                {
                  //  pop1.IsOpen = true;
                    if(txtrevenuecode.Text =="")
                    { txtrevenuecode.Text = ""; }
                    if(txtname.Text =="")
                    { txtname.Text = ""; }
                    if(txttaxstructure.Text=="")
                    { txttaxstructure.Text = ""; }
                    if(txtmistaxstructure.Text=="")
                    { txtmistaxstructure.Text = ""; }
                }
                else
                {
                    revenue rev = new revenue();

                    rev.REVENUE_CODE = txtrevenuecode.Text;
                    rev.NAME = txtname.Text;
                    rev.MISCELLANOUS = COMBOBOX2.Text;
                    rev.PRINT_VOUCHER = COMBOBOX3.Text;
                    rev.TAX_STRUCTURE = txttaxstructure.Text;
                    rev.MIS_TAX_STRUCTURE = txtmistaxstructure.Text;
                    rev.STATUS = COMBOBOX4.Text;
                    // ss rr ii u ii 11/15/2017
                    //rev.USER_NAME = login.u;
                    rev.INSERT_BY = login.u;
                    rev.INSERT_DATE = DateTime.Today;
                    // add.IsEnabled = true;
                    // Modify.IsEnabled = true;
                    // Save.IsEnabled = false;
                    // clear.IsEnabled = false;
                    string a1 = "Save", b1 = Convert.ToString(Save.Content);
                    if (b1 == a1)
                    {
                        //Save.Content = "Save";
                        //insert.Content = "Inserted Sucessfully";
                        //pop2.IsOpen = true;
                        rev.Insert();
                        DataTable dt = rev.fill_revenuegrid();
                        dgrevenue.ItemsSource = dt.DefaultView;
                        MessageBox.Show("inserted sucessfully");
                    }
                    string a = "Update", b = Convert.ToString(Save.Content);
                    if (b == a)
                    {
                        //insert.Content = "Updated Sucessfully";
                        //pop2.IsOpen = true;
                        rev.UPDATE();
                        DataTable dt = rev.fill_revenuegrid();
                        dgrevenue.ItemsSource = dt.DefaultView;
                        MessageBox.Show("updated sucessfully");
                    }
                    clearing();
                    this.NavigationService.Refresh();
                    txtrevenuecode.IsEnabled = false;
                    txttaxstructure.IsEnabled = false;
                    txtname.IsEnabled = false;
                    txtmistaxstructure.IsEnabled = false;
                    COMBOBOX2.IsEnabled = false;
                    COMBOBOX3.IsEnabled = false;
                    COMBOBOX4.IsEnabled = false;
                    Save.Content = "Save";
                    // add.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    // Modify.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("please Enter correct values");
            }
        }
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            clearing();
            this.NavigationService.Refresh();
            // Modify.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
        }
        //clear method
        public void clearing()
        {
            txtrevenuecode.Text = "";
            txtname.Text = "";
            //COMBOBOX2.Text = "";
            //COMBOBOX3.Text = "";
            txttaxstructure.Text = "";
            txtmistaxstructure.Text = "";
            //COMBOBOX4.Text = "";
        }
        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            txtrevenuecode.IsEnabled = true;
            txttaxstructure.IsEnabled = true;
            txtname.IsEnabled = true;
            txtmistaxstructure.IsEnabled = true;
            COMBOBOX2.IsEnabled = true;
            COMBOBOX3.IsEnabled = true;
            COMBOBOX4.IsEnabled = true;

            //add.IsEnabled = false;
            //Modify.IsEnabled = true;
            clear.IsEnabled = true;
            Save.IsEnabled = true;
            insertpop.Content = "updatepopup";
            Save.Content = "Update";
            // Modify.Background = new SolidColorBrush(Colors.Orange);
            // add.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
        }
        private void txtrevenuecode_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                revenue rev = new revenue();
                string a = "Update", b = Convert.ToString(Save.Content);
                if (b == a)
                {
                    rev.REVENUE_CODE = txtrevenuecode.Text;
                    rev.UPDATE_BY = login.u;
                    rev.UPDATE_DATE = DateTime.Today;
                    rev.Retrive();

                    txtname.Text = rev.NAME;
                    COMBOBOX2.Text = rev.MISCELLANOUS;
                    COMBOBOX3.Text = rev.PRINT_VOUCHER;
                    txttaxstructure.Text = rev.TAX_STRUCTURE;
                    txtmistaxstructure.Text = rev.MIS_TAX_STRUCTURE;
                    COMBOBOX4.Text = rev.STATUS;
                }
            }
            catch (Exception) { }
        }
        private void insertpop_Click(object sender, RoutedEventArgs e)
        {
            pop2.IsOpen = false;
        }
        private void dgrevenue_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int i = dgrevenue.SelectedIndex;
                DataTable dt = re.fill_revenuedata();
                if (dt.Rows.Count == 0)
                { }
                else
                {
                    if (i >= 0)
                    {
                        Save.Content = "Update";
                        txtrevenuecode.Text = dt.Rows[i]["REVENUE_CODE"].ToString();
                        txtname.Text = dt.Rows[i]["NAME"].ToString();
                        txttaxstructure.Text = dt.Rows[i]["TAX_STRUCTURE"].ToString();
                        txtmistaxstructure.Text = dt.Rows[i]["MIS_TAX_STRUCTURE"].ToString();
                        COMBOBOX2.Text = dt.Rows[i]["MISCELLANOUS"].ToString();
                        COMBOBOX3.Text = dt.Rows[i]["PRINT_VOUCHER"].ToString();
                        COMBOBOX4.Text = dt.Rows[i]["STATUS"].ToString();
                    }
                    else
                    { }
                }
            }
            catch (Exception) { }
        }
    }
}
