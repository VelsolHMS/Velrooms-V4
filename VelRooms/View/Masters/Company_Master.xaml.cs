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

namespace HMS.View.Masters
{
    /// <summary>
    /// Interaction logic for Company_Master.xaml
    /// </summary>
    public partial class Company_Master : Page
    {
        public string res, resyes, resno;
        private int error = 0;
        RESERVATION r = new RESERVATION();
        public Company_Master()
        {
            data.COUNT = 0;
            InitializeComponent();
            data.COUNT = 1;
            savee.IsEnabled = true;
            clearr.IsEnabled = true;
            searchh.IsEnabled = false;
            txtblacklistedby.IsEnabled = false;
            txtcreditdays.IsEnabled = false;
            txtcreditlimit.IsEnabled = false;
            txtreason.IsEnabled = false;
            DataTable s = r.state();
            txtstate.ItemsSource = s.DefaultView;
            insertpop.Content = "insertpopup";
            savee.Content = "Save";
        }
        private void check_Checked(object sender, RoutedEventArgs e)
        {
            txtcreditlimit.IsEnabled = true;
            txtcreditdays.IsEnabled = true;
        }
        private void check_Unchecked(object sender, RoutedEventArgs e)
        {
            txtcreditdays.IsEnabled = false;
            txtcreditlimit.IsEnabled = false;
        }
        private void yes_Checked(object sender, RoutedEventArgs e)
        {
            txtblacklistedby.IsEnabled = true;
            txtreason.IsEnabled = true;
        }
        private void no_Checked(object sender, RoutedEventArgs e)
        {
            txtblacklistedby.IsEnabled = false;
            txtreason.IsEnabled = false;
        }

        //clear method
        public void clear()
        {
            txtcompanycode.Text = "";
            txtcompanyname.Text = "";
            txtcontactpersonname.Text = "";
            txtcontactpersonnumber.Text = "";
            txtcategory.Text = "";
            txtplotno.Text = "";
            txtlandmark.Text = "";
            txtcity.Text = "";
            //txtstate.Text = "";
           // txtcountry.Text = "";
            txtpincode.Text = "";
            txtcontact.Text = "";
            txtemail.Text = "";
            txtdiscount.Text = "";
            check.IsChecked = false;
            txtcreditlimit.Text = "";
            txtcreditdays.Text = "";
            yes.IsChecked = false;
            no.IsChecked = false;
            txtblacklistedby.Text = "";
            txtreason.Text = "";
            txtremarks.Text = "";
            //combo1.Text = "";
        }
        private void clearr_Click(object sender, RoutedEventArgs e)
        {
            clear();
            //addd.IsEnabled = true;
            mod.IsEnabled = true;
            savee.IsEnabled = true;
            clearr.IsEnabled = true;
            searchh.IsEnabled = false;
            this.NavigationService.Refresh();
            savee.Content = "Save";

            //addd.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            mod.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
        }

        //private void addd_Click(object sender, RoutedEventArgs e)
        //{
        //    clear();

        //    txtcompanycode.IsEnabled = true;
        //    txtcompanyname.IsEnabled = true;
        //    txtcontactpersonname.IsEnabled = true;
        //    txtcontactpersonnumber.IsEnabled = true;
        //    txtcategory.IsEnabled = true;
        //    txtplotno.IsEnabled = true;
        //    txtlandmark.IsEnabled = true;
        //    txtcity.IsEnabled = true;
        //    txtstate.IsEnabled = true;
        //    txtcountry.IsEnabled = true;
        //    txtpincode.IsEnabled = true;
        //    txtcontact.IsEnabled = true;
        //    txtemail.IsEnabled = true;
        //    txtdiscount.IsEnabled = true;
        //    txtremarks.IsEnabled = true;
        //    combo1.IsEnabled = true;

        //    savee.IsEnabled = true;
        //    mod.IsEnabled = false;
        //    addd.IsEnabled = false;
        //    searchh.IsEnabled = false;
        //    clearr.IsEnabled = true;
        //   

        //    addd.Background = new SolidColorBrush(Colors.Orange);
        //    mod.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
        //}

        private void txtcompanycode_LostFocus(object sender, RoutedEventArgs e)
        {
            companymaster cm = new companymaster();
            try
            {
                string a = "Update", b = Convert.ToString(savee.Content);
                if (b == a)
                {
                    cm.COMPANY_CODE = txtcompanycode.Text;
                    cm.UPDATE_BY = login.u;
                    cm.UPDATE_DATE = DateTime.Today;
                    cm.Retrive();
                    txtcompanyname.Text = cm.COMPANY_NAME;
                    if (cm.ALLOW_CREDIT == "1")
                    {
                        check.IsChecked = true;
                        txtcreditlimit.Text = cm.CREDITLIMIT;
                        txtcreditdays.Text = cm.CREDITDAYS;
                    }
                    else
                    {
                        check.IsChecked = false;
                        txtcreditlimit.Text = "";
                        txtcreditdays.Text = "";
                    }
                    if (cm.YES == "1")
                    {
                        yes.IsChecked = true;
                        txtblacklistedby.Text = cm.BLACKLISTEDBY;
                        txtreason.Text = cm.REASON;
                    }
                    else
                    {
                        no.IsChecked = true;
                        txtblacklistedby.Text = "";
                        txtreason.Text = "";
                    }

                    txtcontactpersonname.Text = cm.CONTACT_PERSON_NAME;
                    txtcontactpersonnumber.Text = cm.CONTACT_PERSON_NUMBER;
                    txtcategory.Text = cm.CATEGORY;
                    txtplotno.Text = cm.PLOT_NO;
                    txtlandmark.Text = cm.LANDMARK;
                    txtcity.Text = cm.CITY;
                    txtstate.Text = cm.STATE;
                    txtcountry.Text = cm.COUNTRY;
                    txtpincode.Text = cm.PINCODE;
                    txtcontact.Text = cm.CONTACT;
                    txtemail.Text = cm.EMAIL;
                    txtdiscount.Text = cm.DISCOUNT;
                    txtremarks.Text = cm.REMARKS;
                    combo1.Text = cm.STATUS;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please check the company code.");
            }
        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                error++;
            else
                error--;
        }
        private void savee_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (error != 0 ||txtcompanycode.Text =="" ||txtcompanyname.Text =="" ||txtcontactpersonname.Text =="" ||txtcontactpersonnumber.Text==""||txtcontact.Text==""||txtplotno.Text==""||txtdiscount.Text == ""||yes.IsChecked == true)
                {
                  //  pop1.IsOpen = true;
                    if(txtcompanycode.Text =="")
                    { txtcompanycode.Text = ""; }
                    if(txtcompanyname.Text =="")
                    { txtcompanyname.Text = ""; }
                    if(txtcontactpersonname.Text =="")
                    { txtcontactpersonname.Text = ""; }
                    if(txtcontactpersonnumber.Text =="")
                    { txtcontactpersonnumber.Text = ""; }
                    if(txtcontact.Text=="")
                    { txtcontact.Text = ""; }
                    if(txtplotno.Text=="")
                    { txtplotno.Text = ""; }
                    if(txtdiscount.Text == "")
                    { txtdiscount.Text = ""; }
                    if(yes.IsChecked == true)
                    { txtblacklistedby.Text = ""; }
                }
                else
                {
                    if (check.IsChecked == true)
                    {
                        res = "1";
                    }
                    else
                    {
                        res = "0";
                    }
                    if (yes.IsChecked == true)
                    {
                        resyes = "1";
                    }
                    else
                    {
                        resyes = "0";
                    }
                    if (no.IsChecked == true)
                    {
                        resno = "1";
                    }
                    else
                    {
                        resno = "0";
                    }
                    companymaster cm = new companymaster();
                    cm.COMPANY_CODE = txtcompanycode.Text;
                    cm.COMPANY_NAME = txtcompanyname.Text;
                    cm.CONTACT_PERSON_NAME = txtcontactpersonname.Text;
                    cm.CONTACT_PERSON_NUMBER = txtcontactpersonnumber.Text;
                    cm.CATEGORY = txtcategory.Text;
                    cm.PLOT_NO = txtplotno.Text;
                    cm.LANDMARK = txtlandmark.Text;
                    cm.CITY = txtcity.Text;
                    cm.STATE = txtstate.Text;
                    cm.COUNTRY = txtcountry.Text;
                    cm.PINCODE = txtpincode.Text;
                    cm.CONTACT = txtcontact.Text;
                    cm.EMAIL = txtemail.Text;
                    cm.ALLOW_CREDIT = res.ToString();
                    cm.DISCOUNT = txtdiscount.Text;
                    cm.CREDITLIMIT = txtcreditlimit.Text;
                    cm.CREDITDAYS = txtcreditdays.Text;
                    cm.BLACKLISTEDBY = txtblacklistedby.Text;
                    cm.YES = resyes.ToString();
                    cm.NO = resno.ToString();
                    cm.REASON = txtreason.Text;
                    cm.REMARKS = txtremarks.Text;
                    cm.STATUS = combo1.Text;
                    cm.GST = gst_no.Text;
                    //11/15/2017 U I I sri
                    cm.INSERT_BY = login.u;
                    cm.INSERT_DATE = DateTime.Today;
                    //sri///
                    string a1 = "Save", b1 = Convert.ToString(savee.Content);
                    if (b1 == a1)
                    {
                        //  insert.Content = "Inserted Sucessfully";
                        // pop2.IsOpen = true;
                        cm.Insert();
                        MessageBox.Show("inserted sucessfully");
                        clear();
                    }
                    string a = "Update", b = Convert.ToString(savee.Content);
                    if (b == a)
                    {
                        cm.Update();
                        MessageBox.Show("updated sucessfully");
                        clear();
                    }
                    //addd.IsEnabled = true;
                    mod.IsEnabled = true;
                    savee.IsEnabled = true;
                    clearr.IsEnabled = true;
                    searchh.IsEnabled = false;
                //    clear();
                    this.NavigationService.Refresh();
                    check.IsEnabled = false;

                    yes.IsEnabled = false;
                    no.IsEnabled = false;

                    savee.Content = "Save";
                    
                    //addd.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    mod.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("please Enter correct values");
            }
        }
        private void insertpop_Click(object sender, RoutedEventArgs e)
        {
            pop2.IsOpen = false;
        }
        private void mod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (error != 0 || yes.IsChecked == true)
                {
                    if (yes.IsChecked == true)
                        txtblacklistedby.Text = "";
                }
                companymaster c = new companymaster();
                txtcompanycode.IsEnabled = true;
                txtcompanyname.IsEnabled = true;
                txtcontactpersonname.IsEnabled = true;
                txtcontactpersonnumber.IsEnabled = true;
                txtcategory.IsEnabled = true;
                txtplotno.IsEnabled = true;
                txtlandmark.IsEnabled = true;
                txtcity.IsEnabled = true;
                txtstate.IsEnabled = true;
                txtcountry.IsEnabled = true;
                txtpincode.IsEnabled = true;
                txtcontact.IsEnabled = true;
                txtemail.IsEnabled = true;
                txtdiscount.IsEnabled = true;
                txtremarks.IsEnabled = true;
                combo1.IsEnabled = true;

                //addd.IsEnabled = false;
                mod.IsEnabled = true;
                savee.IsEnabled = true;
                searchh.IsEnabled = false;
                clearr.IsEnabled = true;

                companymaster cm = new companymaster();
                //mod.Content = "Modify";
                string a = "Modify";
                string b = Convert.ToString(mod.Content);
                if (a == b)
                {
                    mod.Content = "Update";
                    cm.Retrive();
                    txtcompanycode.Text = cm.COMPANY_CODE;
                    txtcompanyname.Text = cm.COMPANY_NAME;
                    txtcontactpersonname.Text = cm.CONTACT_PERSON_NAME;
                    txtcontactpersonnumber.Text = cm.CONTACT_PERSON_NUMBER;
                    txtcategory.Text = cm.CATEGORY;
                    txtplotno.Text = cm.PLOT_NO;
                    txtlandmark.Text = cm.LANDMARK;
                    txtcity.Text = cm.CITY;
                    txtstate.Text = cm.STATE;
                    txtcountry.Text = cm.COUNTRY;
                    txtpincode.Text = cm.PINCODE;
                    txtcontact.Text = cm.CONTACT;
                    txtemail.Text = cm.EMAIL;
                    if (check.IsChecked == true)
                    {
                        txtcreditlimit.Text = cm.CREDITLIMIT;
                        txtcreditdays.Text = cm.CREDITDAYS;
                    }
                    else
                    {
                        txtcreditdays.IsEnabled = false;
                        txtcreditlimit.IsEnabled = false;
                    }
                    //    cm.ALLOW_CREDIT = res.ToString();
                    txtdiscount.Text = cm.DISCOUNT;
                    if (yes.IsChecked == true)
                    {
                        txtblacklistedby.Text = cm.BLACKLISTEDBY;
                        txtreason.Text = cm.REASON;
                    }
                    if (no.IsChecked == true)
                    {
                        txtblacklistedby.IsEnabled = false;
                        txtreason.IsEnabled = false;
                    }
                    txtblacklistedby.Text = cm.BLACKLISTEDBY;
                    //cm.YES = resyes.ToString();
                    //cm.NO = resno.ToString();
                    txtremarks.Text = cm.REMARKS;
                    combo1.Text = cm.STATUS;
                }
                else
                {
                    cm.Update();
                    MessageBox.Show("Updated Successfully");
                    mod.Content = "Modify";
                    clear();
                    this.NavigationService.Refresh();
                }
                insertpop.Content = "updatepopup";
                mod.Background = new SolidColorBrush(Colors.Orange);
                //addd.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            }
            catch (Exception)
            {
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pop1.IsOpen = false;
        }
    }
}

