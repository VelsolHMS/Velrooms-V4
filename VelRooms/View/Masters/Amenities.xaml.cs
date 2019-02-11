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
using DAL;
using System.Data.SqlClient;
using System.Data;
using HMS.Model.Masters;
using HMS.Model;
using HMS.ViewModel;
using System.Web.UI.DataVisualization.Charting;

namespace HMS.View.Masters
{
    /// <summary>
    /// Interaction logic for Amenities.xaml
    /// </summary>
    public partial class Amenities : Page
    {
        Amenity amenity = new Amenity();
        private data da = new data();
        private int error = 0;
        DataTable am = new DataTable();
        public Amenities()
        {
            data.COUNT = 0;
            InitializeComponent();
            data.COUNT = 1;

            bt = "add";
            Enable(); count = 0; u = 0;
            save.Content = "Save";
            am = amenity.data();
            Dgamenity.ItemsSource = am.DefaultView;
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

        public void Disable()
        {
            txtamenitycode.IsEnabled = false;
            txtamenityname.IsEnabled = false;
            txtdescription.IsEnabled = false;
            txtprice.IsEnabled = false;
            txtreportingname.IsEnabled = false;

            //add.IsEnabled = true; save.IsEnabled = false; modify.IsEnabled = true; clear.IsEnabled = false;
        }
        public void Enable()
        {
            txtamenitycode.IsEnabled = true;
            txtamenityname.IsEnabled = true;
            txtdescription.IsEnabled = true;
            txtprice.IsEnabled = true;
            txtreportingname.IsEnabled = true;
            //add.IsEnabled = false; save.IsEnabled = true; modify.IsEnabled = false; clear.IsEnabled = true;
        }
        public void Clear()
        {
            txtamenitycode.Text = "";
            txtamenityname.Text = "";
            txtdescription.Text = "";
            txtprice.Text = "";
            txtreportingname.Text = "";
            count = 0; u = 0;
            this.NavigationService.Refresh();
        }
        public void BIND()
        {
            amenity.AMENITY_CODE = txtamenitycode.Text;
            amenity.AMENITY_NAME = txtamenityname.Text;
            amenity.AMOUNT = txtprice.Text;
            amenity.DESCRIPTION = txtdescription.Text;
            amenity.REPORTING_NAME = txtreportingname.Text;
            amenity.STATUS = status.Text;
            amenity.button = bt;
            //11/15/2017 U I I SRI
            //amenity.USER_NAME = login.u;
            amenity.INSERT_BY = login.u;
            amenity.INSERT_DATE = DateTime.Today;
        }
        public static string bt = null;
        //private void add_Click(object sender, RoutedEventArgs e)
        //{
        //    //txtamenitycode.Select(0, 0);
        //    //txtamenityname.Select(0, 0);
        //    //Keyboard.Focus(txtamenityname);

        //      Clear();
        //    

        //    add.Background = new SolidColorBrush(Colors.Orange);
        //    modify.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
        //    //insertpop.Content = "Close";
        //}
        private void modify_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bt = "modify"; count = 0; u = 0;
                Enable();
                save.Content = "Update";
                // insertpop.Content = "close";
                // modify.Background = new SolidColorBrush(Colors.Orange);
                // add.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            }
            catch (Exception) { }
        }
        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (error != 0 || txtamenitycode.Text =="" ||txtamenityname.Text ==""||txtprice.Text =="" )
                {
                   // pop1.IsOpen = true;
                    if(txtamenitycode.Text == "")
                    { txtamenitycode.Text = ""; }
                    if (txtamenityname.Text == "")
                    { txtamenityname.Text = ""; }
                    if (txtprice.Text == "")
                    { txtprice.Text = ""; }
                }
                else
                {
                    BIND();
                    if (bt == "add")
                    {
                        amenity.INSERT();
                        Clear();
                        DataTable dt = amenity.grid();
                        Dgamenity.ItemsSource = dt.DefaultView;
                        MessageBox.Show("inserted sucessfully");
                        //string a1 = "Close", b1 = Convert.ToString(insertpop.Content);
                        //if (b1 == a1)
                        //{
                        //    insert.Content = "Inserted Sucessfully";
                        //    pop2.IsOpen = true;
                        //}
                    }
                    else
                    {
                        //string a = "close", b = Convert.ToString(insertpop.Content);
                        //if (b == a)
                        //{
                        //    insert.Content = "Updated Sucessfully";
                        //    pop2.IsOpen = true;
                        //}
                        amenity.UPDATE_BY = login.u;
                        amenity.UPDATE_DATE = DateTime.Today;
                        amenity.UPDATE();
                        Clear();
                        DataTable dt = amenity.grid();
                        Dgamenity.ItemsSource = dt.DefaultView;
                        MessageBox.Show("update sucessfully");
                    }
                    //this.NavigationService.Refresh();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("please Enter correct values");
            }
        }
        data at = new data();
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            Clear(); Disable();
            this.NavigationService.Refresh();
            save.Content = "Save";
            //modify.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            //add.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
        }
        public void BIND_FETCHED_DATA()
        {
            // txtamenitycode.Text = amenity.AMENITY_CODE;
            txtamenityname.Text = amenity.AMENITY_NAME; name = 0;
            txtdescription.Text = amenity.DESCRIPTION;
            txtprice.Text = amenity.AMOUNT;
            txtreportingname.Text = amenity.REPORTING_NAME;
            status.Text = amenity.STATUS;
        }
        public static int name = 0; public static int code = 0; public static int lostfocuscode = 0;
        public static string codeclear = null; public static string Text = null; public static string nameclear = null;
        public DataTable D = null;
        private void txtamenitycode_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (bt == "add")
                {
                    amenity.GET_STATUS_OF_DATA();
                }
                BIND();
                if (bt == "modify")
                {
                    if (txtamenitycode.Text == "")
                    {
                        li.Visibility = Visibility.Hidden;
                    }
                    else if (txtamenitycode.Text != "")
                    {
                        amenity.GET_STATUS_OF_DATA();
                        if (amenity.match == 1)
                        {
                            BIND_FETCHED_DATA();
                            li.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            BIND_FETCHED_DATA();
                            li.Visibility = Visibility.Visible;
                        }
                        if (amenity.match != 1)
                        {
                            if (txtamenityname.Text == "" && txtreportingname.Text == "" && txtprice.Text == "")
                            {
                                D = amenity.setdata();
                                if (D != null)
                                {
                                    li.ItemsSource = D.DefaultView;
                                    li.Visibility = Visibility.Visible;
                                }
                                txtamenitycode.Text = amenity.d;
                                int b = amenity.d.Length;
                                txtamenitycode.Select(txtamenitycode.Text.Length, b);
                            }
                        }
                    }
                    amenity.GETCOUNT();
                    if (amenity.pc == 1)
                    {
                        txtamenitycode.Text = string.Empty; amenity.pc = 0;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("please check the amenity code");
            }
        }
        public string d = null; public int count = 0;
        public void GETDATA()
        {
            DataTable D = amenity.setdata();
            if (D != null)
            {
                if (txtamenitycode.Text != "")
                {
                    d = txtamenitycode.Text;
                }
            }
            txtamenitycode.Text = d;
        }
        private void txtamenitycode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (name != 1)
                {
                    if (bt == "modify")
                    {
                        if (e.Key == Key.Back)
                        {
                            if (codeclear != "1")
                            {
                                Text = "code";
                                amenity.CLEARBACK_CODE(); codeclear = "0";
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("please check the amenity code");
            }
        }
        private void txtamenitycode_LostFocus(object sender, RoutedEventArgs e)
        {
            li.Visibility = Visibility.Hidden;
        }
        private void txtamenityname_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (bt == "add")
            //{
            //    BIND(); amenity.GET_STATUS_OF_DATA_NAMEFIELD();
            //}
            //if (code != 1)
            //{

            //    if (bt == "modify")
            //    {
            //        BIND();

            //        object ob = amenity.GET_STATUS_OF_DATA_NAMEFIELD();
            //        if (txtamenityname.Text != "")
            //        {
            //            if (ob != null)
            //            {
            //                nameclear = "1"; name = 1; list.Visibility = Visibility.Hidden;
            //                string w = "SELECT * FROM AMENITIES WHERE NAME='" + txtamenityname.Text + "'";
            //                amenity.GET_FETCHED_DATA_NAME(w); MATCH_NAME = 1;
            //                BIND_NAMEFIELD();
            //            }
            //            else
            //            {

            //                amenity.CLEARBACK_NAME(); BIND_NAMEFIELD(); list.Visibility = Visibility.Visible; MATCH_NAME = 0;
            //            }
            //            u++;
            //            if (u >= 3)
            //            {
            //                if (f.Length != 2 && f.Length < 2)
            //                {
            //                    if (f.Length == 1)
            //                    {
            //                        f = ""; txtamenityname.Text = ""; u = 0; amenity.CLEARBACK_NAME(); BIND_NAMEFIELD();
            //                    }
            //                }
            //            }
            //            if (MATCH_NAME != 1)
            //            {
            //                GETDATA_NAMEFIELD();
            //            }
            //        }
            //    }
            //}
        }
        public static int u = 0; public static string f = null; public static int MATCH_NAME = 0; public static int MATCH_CODE = 0;
        public void GETDATA_NAMEFIELD()
        {
            if (txtamenityname.Text != "")
            {
                DataTable D = amenity.setdata_NAME();
                if (D != null)
                {
                    f = txtamenityname.Text;
                    list.ItemsSource = D.DefaultView;
                    list.Visibility = Visibility.Visible;
                }
            }
            txtamenityname.Text = f;
        }
        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (bt == "modify")
                {
                    list.Items.Refresh();
                    list.Visibility = Visibility.Hidden;
                    string s = "SELECT * FROM AMENITIES WHERE AMENITY_CODE='" + amenity.AMENITY_CODE + "'";
                    amenity.GET_FETCHED_DATA(s);
                    BIND_FETCHED_DATA();
                    //  txtamenityname.Text = amenity.F;
                    list.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception) { }
        }
        private void txtamenityname_KeyUp(object sender, KeyEventArgs e)
        {
            //if (code != 1)
            //{
            //    if (bt == "modify")
            //    {
            //        if (e.Key == Key.Back)
            //        {
            //            if (nameclear != "1")
            //            {
            //                Text = "name";

            //                amenity.CLEARBACK_NAME(); nameclear = "0";
            //            }


            //            if (txtamenityname.Text.Length == 0)
            //            {

            //                list.Visibility = Visibility.Hidden;
            //            }
            //        }
            //    }
            //}
        }
        private void txtamenityname_LostFocus(object sender, RoutedEventArgs e)
        {
            //list.Visibility = Visibility.Hidden; name = 0;
        }
        private void txtamenityname_GotFocus(object sender, RoutedEventArgs e)
        {
            //    if (lostfocuscode != 1)
            //    {
            //        if (name != 1)
            //        {
            //            if (bt == "modify")
            //            {
            //                GETDATA_NAMEFIELD();
            //            }
            //        }
            //    }
        }
        public void BIND_NAMEFIELD()
        {
            txtamenitycode.Text = amenity.AMENITY_CODE; code = 0;
            txtprice.Text = amenity.AMOUNT;
            txtreportingname.Text = amenity.REPORTING_NAME;
            txtdescription.Text = amenity.DESCRIPTION;
            status.Text = amenity.STATUS;
        }
        private void txtamenitycode_GotFocus(object sender, RoutedEventArgs e)
        {
            if (name != 1)
            {
                if (bt == "modify")
                {
                    if (txtamenitycode.Text != "")
                    {
                        amenity.setdata();
                    }
                }
            }
        }
        private void insertpop_Click(object sender, RoutedEventArgs e)
        {
            pop2.IsOpen = false;
        }
        private void Dgamenity_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Binding b = new Binding();
            int i = Dgamenity.SelectedIndex;
            try
            {
                string ss = am.Rows[i]["AMENITY_CODE"].ToString();
                txtamenitycode.Text = am.Rows[i]["AMENITY_CODE"].ToString();
                txtamenityname.Text = am.Rows[i]["AMENITY_NAME"].ToString();
                txtdescription.Text = am.Rows[i]["DESCRIPTION"].ToString();
                txtprice.Text = am.Rows[i]["AMOUNT"].ToString();
                txtreportingname.Text = am.Rows[i]["REPORTING_NAME"].ToString();
                status.Text = am.Rows[i]["STATUS"].ToString();
                bt = "modify"; count = 0; u = 0;
                Enable();
                save.Content = "Update";
                Dgamenity.UnselectAll();
            }
            catch (Exception)
            {
                MessageBox.Show("please check the fileds.");
            }
        }
    }
}
