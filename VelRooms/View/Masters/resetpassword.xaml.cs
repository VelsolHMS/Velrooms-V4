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
using HMS.Model.Masters;
using System.Data;
using HMS.ViewModel;
using HMS.Model;
using HMS.View.Masters;

namespace HMS.View.Masters
{
    /// <summary>
    /// Interaction logic for resetpassword.xaml
    /// </summary>
    public partial class resetpassword : Page
    {
        Passwordreset pr = new Passwordreset();
        public DataTable D;
        public int name = 0;
        public int error = 0;
        public resetpassword()
        {
            InitializeComponent();
            //newpass.IsEnabled = false;
            //confpass.IsEnabled = false;
        }
        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //li.Items.Refresh();
            //li.Visibility = Visibility.Hidden;
            string s = "SELECT * FROM REGISTRATION WHERE USER_NAME ='" + pr.USER_NAME + "'";
            pr.GET_FETCHED_DATA(s);
            //BIND_FETCHED_DATA();
            txtname.Text = pr.NAME;
            txtreportname.Text = pr.REPORTING_NAME;
            //  txtamenityname.Text = amenity.F;
            //li.Visibility = Visibility.Hidden;
        }
        private void txtuser_GotFocus(object sender, RoutedEventArgs e)
        {
            if (name != 1)
            {
                if (txtuser.Text != "")
                {
                    pr.setdata();
                }
            }
        }
        private void txtuser_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                pr.USER_NAME = txtuser.Text;

                if (txtuser.Text == "")
                {
                    //li.Visibility = Visibility.Hidden;
                }
                else if (txtuser.Text != "")
                {
                    pr.GET_STATUS_OF_DATA();
                    if (pr.match == 1)
                    {
                        //BIND_FETCHED_DATA();
                        txtname.Text = pr.NAME;
                        txtreportname.Text = pr.REPORTING_NAME;
                        //li.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        //BIND_FETCHED_DATA();
                        txtname.Text = pr.NAME;
                        txtreportname.Text = pr.REPORTING_NAME;
                        //li.Visibility = Visibility.Visible;
                    }
                    if (pr.match != 1)
                    {
                        if (txtname.Text == "" && txtreportname.Text == "")
                        {
                            D = pr.setdata();
                            if (D != null)
                            {
                                //li.ItemsSource = D.DefaultView;
                                //li.Visibility = Visibility.Visible;
                            }
                            txtuser.Text = pr.d;
                            int b = pr.d.Length;
                            txtuser.Select(txtuser.Text.Length, b);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("please check the username");
            }
        }
        private void txtuser_LostFocus(object sender, RoutedEventArgs e)
        {
            //li.Visibility = Visibility.Hidden;
        }
        private void txtuser_KeyUp(object sender, KeyEventArgs e)
        {
        }
        private void oldpass_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                pr.USER_NAME = txtuser.Text;
                pr.Get_Password();
                if (oldpass.Password == pr.OLD_PASSWORD)
                {
                    newpass.IsEnabled = true;
                    confpass.IsEnabled = true;
                }
                else
                {
                    newpass.IsEnabled = false;
                    confpass.IsEnabled = false;
                    MessageBox.Show("Please check your password");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("check the password correctly");
            }
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtuser.Text = "";
            //li.Visibility = Visibility.Hidden;
            txtname.Text = "";
            txtreportname.Text = "";
            oldpass.Password = "";
            newpass.Password = "";
            confpass.Password = "";
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (error!=0||txtname.Text == "" || oldpass.Password == "" || newpass.Password == "" || confpass.Password == "")
            {
                if (txtname.Text == "")
                { txtname.Text = ""; }
                if (oldpass.Password == "")
                { oldpass.Password = ""; }
                if (newpass.Password == "")
                { newpass.Password = ""; }
                if (confpass.Password == "")
                { confpass.Password = ""; }
            }
            else
            {
                try
                {
                    pr.USER_NAME = txtuser.Text;
                    pr.NEW_PASSWORD = newpass.Password;
                    pr.CONFIRM_PASSWORD = confpass.Password;
                    pr.Password_Update();
                    txtuser.Text = "";
                    //li.Visibility = Visibility.Hidden;
                    txtname.Text = "";
                    txtreportname.Text = "";
                    oldpass.Password = "";
                    newpass.Password = "";
                    confpass.Password = "";

                    MessageBox.Show("Sucessfully changed your password");
                }
                catch (Exception)
                {
                    MessageBox.Show("please enter correct values");
                }
            }
        }
        private void txtuser_Error(object sender, ValidationErrorEventArgs e)
        {
        }
        private void newpass_Error(object sender, ValidationErrorEventArgs e)
        {
        }
        private void confpass_Error(object sender, ValidationErrorEventArgs e)
        {
        }
        private void confpass_LostFocus(object sender, RoutedEventArgs e)
        {
            if(newpass.Password == confpass.Password)
            {
            }
            else
            {
                confpass.Password = "";
                MessageBox.Show("Match newpassword and confirmpassword");
            }
        }
    }
}