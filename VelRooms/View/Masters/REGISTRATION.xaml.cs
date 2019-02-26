using HMS.Model.Masters;
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
using System.Data;

namespace HMS.View.Masters
{
    /// <summary>
    /// Interaction logic for REGISTRATION.xaml
    /// </summary>
    public partial class REGISTRATION : Page
    {
        registration re = new registration();
        public int error = 0;
        public string desg;
        public REGISTRATION()
        {
            data.COUNT = 0;
            InitializeComponent();
            data.COUNT = 1;
            //TXTUSER.Text = "";
            //TXTFIRSTNAME.Text = "";
            //TXTCONTACT.Text = "";
            //TXTEMAIL.Text = "";
            //TXTPASSWORD.Text = "";
            //TXTREPASSWORD.Text = "";
            popup1.IsOpen = false;
            popupinsert.IsOpen = false;
            CONFIRM.Content = "Save";
            DataTable dt = re.fill_reggrid();
            dgreg.ItemsSource = dt.DefaultView;
            DataTable d = re.username1();
            if(d.Rows.Count == 0)
            {
            }
            else
            {
                desg = d.Rows[0]["DESGINATION"].ToString();
                if (d.Rows[0]["DESGINATION"].ToString() == "Admin")
                {
                    rb.Visibility = Visibility.Visible;
                }
                else
                {
                    rb.Visibility = Visibility.Hidden;
                }
            }
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
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                enable();
                MODIFY.IsEnabled = false;
                //Add.IsEnabled = false;
                CONFIRM.IsEnabled = true;
                Clear.IsEnabled = true;
                // insertpop.Content = "insertpopup";
                CONFIRM.Content = "CONFIRM";
                //Add.Background = new SolidColorBrush(Colors.Orange);
            }
            catch (Exception) { }
        }
        private void MODIFY_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CONFIRM.Content = "Update";
                //Add.IsEnabled = false;
                MODIFY.IsEnabled = false;
                CONFIRM.IsEnabled = true;
                Clear.IsEnabled = true;
                enable();
                //insertpop.Content = "updatepopup";
            }
            catch (Exception) { }
        }
        private void CONFIRM_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (error != 0 || TXTFIRSTNAME.Text =="" ||TXTLASTNAME.Text=="" || TXTUSER.Text=="" ||TXTCONTACT.Text=="" ||TXTPASSWORD.Password=="" ||TXTREPASSWORD.Password == "")
                {
               //     pop1.IsOpen = true;
                    if (TXTFIRSTNAME.Text == "")
                        TXTFIRSTNAME.Text = "";
                    if (TXTLASTNAME.Text == "")
                        TXTLASTNAME.Text = "";
                    if (TXTUSER.Text == "")
                        TXTUSER.Text = "";
                    if (TXTCONTACT.Text == "")
                        TXTCONTACT.Text = "";
                    if (TXTPASSWORD.Password == "")
                        TXTPASSWORD.Password = "";
                    if (TXTREPASSWORD.Password == "")
                        TXTREPASSWORD.Password = "";
                }
                else
                {
                    if (rb.IsChecked == false && rb1.IsChecked == false)
                    {
                        MessageBox.Show("Please select Admin Or User");
                    }
                    else
                    {
                        re.USERNAME = TXTUSER.Text;
                        re.FIRSTNAME = TXTFIRSTNAME.Text;
                        re.LASTNAME = TXTLASTNAME.Text;
                        re.MOBILE_NO = TXTCONTACT.Text;
                        re.EMAIL = TXTEMAIL.Text;
                        re.PASSWORD = TXTPASSWORD.Password;
                        re.RETYPEPASSWORD = TXTREPASSWORD.Password;
                        re.Status = txtstatus.Text;
                        if (rb.IsChecked == true)
                        {
                            re.DESGINATION = Convert.ToString(rb.Content);
                        }
                        else
                        {
                            re.DESGINATION = Convert.ToString(rb1.Content);
                        }
                        if (TXTPASSWORD.Password == "" || TXTREPASSWORD.Password == "")
                        {
                            MessageBox.Show("please enter the password");
                            TXTPASSWORD.Focus();
                            return;
                        }
                        else if (TXTPASSWORD.Password != TXTREPASSWORD.Password)
                        {
                            MessageBox.Show("password not matching");
                            TXTREPASSWORD.Focus();
                            return;
                        }
                        DataTable DT = re.username();
                        if (DT.Rows.Count == 0)
                        {
                        }
                        else
                        {
                            string DESIGINATION = DT.Rows[0]["DESGINATION"].ToString();
                            if (DESIGINATION == "User")
                            {
                                re.MASTERPERMISSIONS();
                                re.OPERTIONPERMISSIONS();
                                re.REPORTPERMISSION();
                            }
                            else
                            {
                            }
                        }
                        clear();
                        string a1 = "Save", b1 = Convert.ToString(CONFIRM.Content);
                        if (b1 == a1)
                        {
                            re.INSERT();
                            DataTable dt = re.fill_reggrid();
                            dgreg.ItemsSource = dt.DefaultView;
                            popupinsert.IsOpen = true;
                            // MessageBox.Show("inserted sucessfully");
                        }
                        string a = "Update", b = Convert.ToString(CONFIRM.Content);
                        if (b == a)
                        {
                            re.UPDATE();
                            DataTable dt = re.fill_reggrid();
                            dgreg.ItemsSource = dt.DefaultView;
                            popup1.IsOpen = true;
                            //MessageBox.Show("updated sucessfully");
                            
                        }
                        this.NavigationService.Refresh();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("please enter correct values");
            }
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            clear();
            disable();
            CONFIRM.IsEnabled = false;
            MODIFY.IsEnabled = true;
            this.NavigationService.Refresh();
        }
        public void clear()
        {
            TXTUSER.Text = "";
            TXTREPASSWORD.Password = "";
            TXTPASSWORD.Password = "";
            TXTLASTNAME.Text = "";
            TXTFIRSTNAME.Text = "";
            TXTEMAIL.Text = "";
            TXTCONTACT.Text = "";
            txtstatus.Text = "";
            txtstatus.IsEnabled = false;
        }
        public void enable()
        {
            TXTUSER.IsEnabled = true;
            TXTREPASSWORD.IsEnabled = true;
            TXTPASSWORD.IsEnabled = true;
            TXTLASTNAME.IsEnabled = true;
            TXTFIRSTNAME.IsEnabled = true;
            TXTEMAIL.IsEnabled = true;
            TXTCONTACT.IsEnabled = true;
            rb.IsEnabled = true;
            rb1.IsEnabled = true;
        }
        public void disable()
        {
            TXTUSER.IsEnabled = false;
            TXTREPASSWORD.IsEnabled = false;
            TXTPASSWORD.IsEnabled = false;
            TXTLASTNAME.IsEnabled = false;
            TXTFIRSTNAME.IsEnabled = false;
            TXTEMAIL.IsEnabled = false;
            TXTCONTACT.IsEnabled = false;
            rb.IsEnabled = false;
            rb1.IsEnabled = false;
        }
        public static string st;
        private void dgreg_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int i = dgreg.SelectedIndex;
                DataTable dt = re.fill_regdata();
                if (dt.Rows.Count == 0)
                { }
                else
                {
                    if (i >= 0)
                    {
                        CONFIRM.Content = "Update";
                        TXTUSER.IsReadOnly = true;
                        TXTUSER.Text = dt.Rows[i]["USER_NAME"].ToString();
                        TXTFIRSTNAME.Text = dt.Rows[i]["FIRSTNAME"].ToString();
                        TXTLASTNAME.Text = dt.Rows[i]["LASTNAME"].ToString();
                        TXTCONTACT.Text = dt.Rows[i]["MOBILE_NO"].ToString();
                        TXTEMAIL.Text = dt.Rows[i]["EMAIL"].ToString();
                        TXTPASSWORD.Password = dt.Rows[i]["PASS_WORD"].ToString();
                        TXTREPASSWORD.Password = dt.Rows[i]["RETYPEPASSWORD"].ToString();
                        txtstatus.Text = dt.Rows[i]["Status"].ToString();
                        if(desg == "Admin")
                        {
                            txtstatus.IsEnabled = true;
                            rb.IsEnabled = true;
                            rb1.IsEnabled = true;
                        }
                        else
                        {
                            txtstatus.IsEnabled = false;
                            rb.IsEnabled = false;
                            rb1.IsEnabled = false;
                        }
                        if (dt.Rows[i]["DESGINATION"].ToString() == "Admin")
                        {
                            rb.IsChecked = true;
                        }
                        else
                        {
                            rb1.IsChecked = true;
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            popup1.IsOpen = false;
            this.NavigationService.Refresh();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            popupinsert.IsOpen = false;
            this.NavigationService.Refresh();
        }
    }
}