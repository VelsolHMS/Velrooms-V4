using DAL;
using HMS.Model;
using HMS.Model.Operations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using HMS.View;
using HMS.mainwindowpages;
using HMS.ViewModel;
using HMS.View.Masters;
using System.Text.RegularExpressions;

namespace HMS.View.Operations
{
    /// <summary>
    /// Interaction logic for enquiry.xaml
    /// </summary>
    public partial class enquiry : Page
    {
        RESERVATION R = new RESERVATION();
        Enquiry1 E = new Enquiry1();
        public int error = 0;
        public enquiry()
        {
            data.COUNT = 0;
            InitializeComponent();
            data.COUNT = 1;
            txtdate.Text = DateTime.Today.Date.ToString();
            DataTable dt = E.fill_enquirygrid();
            dg.ItemsSource = dt.DefaultView;
            DataTable d = R.GET();
            cbroomtype.ItemsSource = d.DefaultView;
            Enquiry1 e = new Enquiry1();
            txtenquiryno.Text = e.getid().ToString();

        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                error++;
            else
                error--;
        }
        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("mainwindowpages/home.xaml", UriKind.RelativeOrAbsolute));
        }
        public void clear()
        {
            txtname.Text = "";
            txtcontact.Text = "";
            txtcomingfrom.Text = "";
            cbroomtype.Text = "";
            txtrooms.Text = "";
            txtpax.Text = "";
            txtdate.Text = "";
            this.NavigationService.Refresh();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (error != 0 || txtname.Text =="" || txtcontact.Text == "" ||txtpax.Text == "" ||txtdate.Text==""||txttime.Text == ""||txtrooms.Text == "")
            {
                txtdate.Text = "";
                //pop1.IsOpen = true;
                if(txtname.Text == "")
                { txtname.Text = ""; }
                if (txtcontact.Text == "")
                    txtcontact.Text = "";
                if (txtrooms.Text == "")
                    txtrooms.Text = "";
                if (txtpax.Text == "")
                    txtpax.Text = "";
                if (txtdate.Text == "")
                {
                    txtdate.Text = string.Empty;
                    txtdate.Text = null;
                }
                if (txttime.Text == "")
                    txttime.Text = "";
            }
            else
            {
                Enquiry1 EN = new Enquiry1();
                //string a= txtdate.Text;
                EN.Enquiry_id = Convert.ToInt32(txtenquiryno.Text);
                EN.Name = txtname.Text;
                EN.Contact = Convert.ToInt64(txtcontact.Text);
                EN.ComingFrom = txtcomingfrom.Text;
                EN.RoomType = cbroomtype.Text;
                EN.Expected_Rooms = Convert.ToInt32(txtrooms.Text);
                EN.Expected_Pax = Convert.ToInt32(txtpax.Text);
                EN.Expected_Arrival_Date = Convert.ToDateTime(txtdate.Text);
                EN.Time =txttime.Text;
                EN.Insert_by = login.u;
                EN.Insert_date = DateTime.Today;
                string a = "Save"; string b = Convert.ToString(Save.Content);
                if(a==b)
                {
                    EN.insert();
                    DataTable dt = EN.fill_enquirygrid();
                    dg.ItemsSource = dt.DefaultView;
                    //MessageBox.Show("Saved sucessfully");
                    popup_insert.IsOpen = true;
                    clear();
                }
                else
                {
                    
                    EN.UPDATE();
                    DataTable dt = EN.fetch_data();
                    dg.ItemsSource = dt.DefaultView;
                    //MessageBox.Show("Updated sucessfully");
                    popup_update.IsOpen = true;
                    clear();
                    Save.Content = "Save";
                }
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            clear();
        }
        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    Enquiry1 n = new Enquiry1();
        //    if (enquiryid.Text != "")
        //    {
        //        n.Enquiry_id = Convert.ToInt32(enquiryid.Text);
        //        DataTable d = n.id();
        //        dg.ItemsSource = d.DefaultView;
        //    }
        //    else if (enquirydate.Text != "")
        //    {
        //        n.Expected_Arrival_Date = enquirydate.Text;
        //        // Convert.ToDateTime(enquirydate.Text);
        //        DataTable d1 = n.date();
        //        dg.ItemsSource = d1.DefaultView;
        //    }
        //    else if (enquiryname.Text != "")
        //    {
        //        n.Name = enquiryname.Text;
        //        DataTable d2 = n.Name1();
        //        dg.ItemsSource = d2.DefaultView;
        //    }
        //    else if (enquirycontact.Text != "")
        //    {

        //        n.Contact = Convert.ToInt64(enquirycontact.Text);
        //        DataTable d3 = n.Contact1();
        //        dg.ItemsSource = d3.DefaultView;
        //    }
        //}
        private void btnok_Click(object sender, RoutedEventArgs e)
        {
            Enquiry1 n = new Enquiry1();
            //var list = new List<SqlParameter>();
            //string s = "select * from Enquiry where Insert_Date between @fromdate and @todate";
            //string a = date.Text;
            //string b = date1.Text;
            //list.AddSqlParameter("@fromdate", date);
            //list.AddSqlParameter("@todate", date1);
            //n.Date = CHANGEFORMAT(date.Text);
            //n.Date1 = CHANGEFORMAT(date1.Text);
            n.Date = date.Text;
            n.Date1 = date1.Text;
            DataTable d = n.insertdate();
            dg.ItemsSource = d.DefaultView;
        }
        //private void Button_Click_3(object sender, RoutedEventArgs e)
        //{
        //    enquiryid.Text = "";
        //    enquiryname.Text = "";
        //    enquirydate.Text = "";
        //    enquirycontact.Text = "";
        //    dg.ItemsSource = "";
        //    date.Text = "";
        //    date1.Text = "";
        //}
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            pop1.IsOpen = false;
        }
        private void txtdate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtdate.SelectedDate < DateTime.Today)
            {
                //MessageBox.Show("Active from date cannot be less than the current date");
                pop1.IsOpen = true;
                txtdate.Text = "";
            }
            else if (date.SelectedDate == DateTime.Today)
            {
                txtdate.Text = Convert.ToString(DateTime.Today);
            }
        }
        private void txttime_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txttime.Text))
            {
                txttime.Text = "00:00";
            }
            else
            {
            }
        }
        private void dg_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int i = dg.SelectedIndex;
            DataTable dt = E.fetch_data();
            if(dt.Rows.Count==0)
            {
            }
            else
            {
                if(i>=0)
                {
                    Save.Content = "Update";
                    txtenquiryno.Text = dt.Rows[i]["Enquiry_id"].ToString();
                    txtname.Text = dt.Rows[i]["Name"].ToString();
                    txtcontact.Text = dt.Rows[i]["Contact"].ToString();
                    txtcomingfrom.Text = dt.Rows[i]["ComingFrom"].ToString();
                    txtpax.Text = dt.Rows[i]["Expected_Pax"].ToString();
                    txtrooms.Text = dt.Rows[i]["Expected_Rooms"].ToString();
                    txtdate.Text = Convert.ToDateTime(dt.Rows[i]["Expected_Arrival_Date"]).ToString();
                    txttime.Text = dt.Rows[i]["TIME"].ToString();
                    cbroomtype.Text = dt.Rows[i]["RoomType"].ToString();
                }
                else
                { }
            }
        }
        private void txtsearch_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtsearch.Text.Length >= 1 && txtsearch.Text.Length < 3)
            {
                var reg = new Regex(@"[^0-9]");
                if (reg.IsMatch(txtsearch.Text))
                {
                    MessageBox.Show("enter without special chars");
                }
                else
                {
                    E.Enquiry_id = Convert.ToInt32(txtsearch.Text);
                    DataTable dt = E.Enquiry();
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("there is no data please check the value");
                    }
                    else
                    {
                        DataTable dt1 = E.id();
                        dg.ItemsSource = dt1.DefaultView;
                    }
                }
            }
            else if (txtsearch.Text.Length == 10)
            {
                var regexItem = new Regex(@"^\d{4}[-]\d{2}[-]\d{2}$");
                if (regexItem.IsMatch(txtsearch.Text) )
                {
                    E.ed = DateTime.Parse(txtsearch.Text);
                    DataTable dt = E.Enquiry();
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("there is no data please check the value");
                    }
                    else
                    {
                        DataTable dt1 = E.date();
                        dg.ItemsSource = dt1.DefaultView;
                    }
                }
                else
                {
                    E.Contact = Convert.ToInt64(txtsearch.Text);
                    DataTable dt = E.Enquiry();
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("there is no data please check the value");
                    }
                    else
                    {
                        DataTable dt1 = E.Contact1();
                        dg.ItemsSource = dt1.DefaultView;
                    }
                }
            }
            else if (txtsearch.Text.Length >= 3 && txtsearch.Text.Length <= 8)
            {
                E.Name = txtsearch.Text;
                DataTable dt = E.Enquiry();
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("there is no data please check the value");
                }
                else
                {
                    DataTable dt1 = E.Name1();
                    dg.ItemsSource = dt1.DefaultView;
                }
            }
            else
            {
                DataTable dt = E.Enquiry();
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("there is no data please check the value");
                }
                else
                {
                    DataTable dt1 = E.Enquiry();
                    dg.ItemsSource = dt1.DefaultView;
                }
            }
            if (txtsearch.Text == "")
            {
                DataTable dtp = E.fill_enquirygrid();
                if(dtp.Rows.Count == 0)
                {
                    MessageBox.Show("there is no data please check the value");
                }
                else
                {
                    dg.ItemsSource = dtp.DefaultView;
                }
            }
        }
        private void date_LostFocus(object sender, RoutedEventArgs e)
        {
        }
        public static DateTime datet, datet1;

        private void insertpop_Click_1(object sender, RoutedEventArgs e)
        {
            popup_insert.IsOpen = false;
        }

        private void updatepop_Click(object sender, RoutedEventArgs e)
        {
            popup_update.IsOpen = false;
        }

        private void btnsearch_Click(object sender, RoutedEventArgs e)
        {
            Enquiry1 n = new Enquiry1();
            if(date.Text =="" ||date1.Text == "")
            {
            }
            else
            {
                datet = DateTime.Parse(date.Text);
                datet1 = DateTime.Parse(date1.Text);
                if (datet1.Ticks > datet.Ticks)
                {
                    DataTable d = n.insertdate();
                    if (d.Rows.Count == 0)
                    {
                        date.Text = "";
                        date1.Text = "";
                        MessageBox.Show("there is no data please check the value");
                    }
                    else
                    {
                        dg.ItemsSource = d.DefaultView;
                    }
                }
                else
                {
                    date.Text = "";
                    date1.Text = "";
                    MessageBox.Show("Select to-date greter then from-date");
                }
            }
        }
    }
}

