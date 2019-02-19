using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using DAL;
using System.Globalization;
using HMS.Model;
using HMS.ViewModel;
using HMS;
using HMS.View.Masters;

namespace HMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Page
    {
        public int error = 0;
        RESERVATION r = new RESERVATION();
        Hotelinfo hinfo = new Hotelinfo();

        public MainWindow()
        {
            data.COUNT = 0;
            InitializeComponent();
            data.COUNT = 1;
            btnSave.Content = "Save";
            DataTable s = r.state();
            txtstate.ItemsSource = s.DefaultView;
            txtcountry.Text = "India";
          //  Hotel();
            //Hotelinfo h = new Hotelinfo();
            //txtblock.Content = h.getid1();
        }

        // to disable ....
        public void Hotel()
        {
            btnSave.Content = "Update";
            string a = "Update", b = Convert.ToString(btnSave.Content);

            if (b == a)
            {
                hinfo.Name = txtname.Text;
                hinfo.UPDATE_BY = login.u;
                hinfo.UPDATE_DATE = DateTime.Today;
                hinfo.GetInfo();
                txtname.Text = hinfo.Name;
                txtCity.Text = hinfo.city;
                txtcountry.Text = hinfo.Country;
                Txtemail.Text = hinfo.Email;
                txtgst.Text = hinfo.GST_NO;
                txtlandline1.Text = hinfo.Landline_1;
                txtlandline2.Text = hinfo.Landline_2;
                txtlandmark.Text = hinfo.Landmark;
                txtmobile.Text = hinfo.Mobile_No;
                txtPincode.Text = hinfo.Pincode;
                txtplotno.Text = hinfo.Plot_No;
                txtstate.Text = hinfo.State;
                txtweb.Text = hinfo.website;

                if (hinfo.HOURS12 == "0")
                {
                    txt12.IsChecked = false;
                }
                else
                {
                    txt12.IsChecked = true;
                }
                if (hinfo.HOURS24 == "0")
                {
                    txt24.IsChecked = false;
                }
                else
                {
                    txt24.IsChecked = true;
                }
                txthours.Text = hinfo.EXTRAHOURS;
            }
        }
        private void dis()
        {
            //Add.IsEnabled = true;
            Modify.IsEnabled = true;
            btnSave.IsEnabled = true;
            clear.IsEnabled = true;
            txtname.IsEnabled = false;
            txtplotno.IsEnabled = false;
            txtCity.IsEnabled = false;
            txtstate.IsEnabled = false;
            txtPincode.IsEnabled = false;
            txtcountry.IsEnabled = false;
            Txtemail.IsEnabled = false;
            txtmobile.IsEnabled = false;
            txtlandline1.IsEnabled = false;
            txtlandline2.IsEnabled = false;
            txtweb.IsEnabled = false;
            txtgst.IsEnabled = false;
            txtlandmark.IsEnabled = false;
            txt12.IsEnabled = false;
            txt24.IsEnabled = false;
            txthours.IsEnabled = false;
        }
        // to enable....
        public void enb()
        {
            //Add.IsEnabled = false;
            Modify.IsEnabled = true;
            btnSave.IsEnabled = true;
            clear.IsEnabled = true;
            txtname.IsEnabled = true;
            txtplotno.IsEnabled = true;
            txtCity.IsEnabled = true;
            txtstate.IsEnabled = true;
            txtPincode.IsEnabled = true;
            txtcountry.IsEnabled = true;
            Txtemail.IsEnabled = true;
            txtmobile.IsEnabled = true;
            txtlandline1.IsEnabled = true;
            txtlandline2.IsEnabled = true;
            txtweb.IsEnabled = true;
            txtgst.IsEnabled = true;
            txtlandmark.IsEnabled = true;
            txt12.IsEnabled = true;
            txt24.IsEnabled = true;
            txthours.IsEnabled = true;
        }

        // to clear...
        public void clr()
        {
            txtname.Clear();
            txtplotno.Clear();
            txtlandmark.Clear();
            txtPincode.Clear();
            txtcountry.Clear();
            txtmobile.Clear();
            Txtemail.Clear();
            txtlandline1.Clear();
            txtlandline2.Clear();
            txtweb.Clear();
            txtgst.Clear();
            txt12.IsChecked = false;
            txt24.IsChecked = false;
            txthours.Clear();
        }
        // To clear text fileds..
        public void clrtextfield()
        {
            txtname.Text = "";
            txtplotno.Text = "";
            //txtstate.Text = "";
            txtweb.Text = "";
            txtPincode.Text = "";
            txtmobile.Text = "";
            txtlandmark.Text = "";
            txtlandline2.Text = "";
            txtlandline1.Text = "";
            txtgst.Text = "";
            Txtemail.Text = "";
            txtcountry.Text = "";
            txtCity.Text = "";
            txthours.Clear();
        }
        //
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            clrtextfield();
            //this.Add.IsEnabled = false;
            if (!this.btnSave.IsEnabled)
            {
                this.btnSave.IsEnabled = true;
            }
            if (!this.clear.IsEnabled)
            {
                this.clear.IsEnabled = true;
            }

            Modify.IsEnabled = false;

            enb();
            //insertpop.Content = "insertpopup";
           

            //Add.Background = new SolidColorBrush(Colors.Orange);
            Modify.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
        }
        // Modify button...
        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            this.Modify.IsEnabled = true;
            if (!this.btnSave.IsEnabled)
            {
                this.btnSave.IsEnabled = true;
            }
            if (!this.clear.IsEnabled)
            {
                this.clear.IsEnabled = true;
            }
            enb();
            btnSave.Content = "Update";
            string a = "Update", b = Convert.ToString(btnSave.Content);
            if (b == a)
            {
                hinfo.Name = txtname.Text;
                hinfo.UPDATE_BY = login.u;
                hinfo.UPDATE_DATE = DateTime.Today;
                hinfo.GetInfo();
                txtname.Text = hinfo.Name;
                txtCity.Text = hinfo.city;
                txtcountry.Text = hinfo.Country;
                Txtemail.Text = hinfo.Email;
                txtgst.Text = hinfo.GST_NO;
                txtlandline1.Text = hinfo.Landline_1;
                txtlandline2.Text = hinfo.Landline_2;
                txtlandmark.Text = hinfo.Landmark;
                txtmobile.Text = hinfo.Mobile_No;
                txtPincode.Text = hinfo.Pincode;
                txtplotno.Text = hinfo.Plot_No;
                txtstate.Text = hinfo.State;
                txtweb.Text = hinfo.website;
                
                if (hinfo.HOURS12 == "0")
                {
                    txt12.IsChecked = false;
                }
                else
                {
                    txt12.IsChecked = true;
                }
                if (hinfo.HOURS24 == "0")
                {
                    txt24.IsChecked = false;
                }
                else
                {
                    txt24.IsChecked = true;
                }
                txthours.Text = hinfo.EXTRAHOURS;
            }
            Modify.Background = new SolidColorBrush(Colors.Orange);
            //Add.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            //insertpop.Content = "updatepopup";
        }
        //clear button ...
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            this.clear.IsEnabled = true;
            if (!this.Modify.IsEnabled)
            {
                this.Modify.IsEnabled = true;
            }
            //if (!this.Add.IsEnabled)
            //{
            //    this.Add.IsEnabled = true;
            //}
            btnSave.IsEnabled = true;
            dis();
            clrtextfield();
            clr();
            this.NavigationService.Refresh();
            btnSave.Content = "Save";

            //Add.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            Modify.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
        }

        //data saving......

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pop1.IsOpen = false;
        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                error++;
            else
                error--;
        }
        public string rs12,rs24;

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ValidationResult result = new ValidationResult(true, null);

            try
            {
                if (error != 0 || txtname.Text == "" || txtCity.Text == "" || txtcountry.Text == "" || txtgst.Text == "" || txtplotno.Text == "" || txtlandline1.Text == "" || txtmobile.Text == "" || txtPincode.Text == "" || txtstate.Text == ""||Txtemail.Text =="")    
                {
                    //pop1.IsOpen = true;
                    if(txtname.Text == "")
                    {  txtname.Text = "";  }
                    if(txtCity.Text == "")
                    {  txtCity.Text = "";  }
                    if(txtcountry.Text == "")
                    { txtcountry.Text = "";  }
                    if (txtgst.Text == "")
                    { txtgst.Text = ""; }
                    if (txtplotno.Text == "")
                    { txtplotno.Text = ""; }
                    if (txtlandline1.Text == "")
                    { txtlandline1.Text = ""; }
                    if (txtmobile.Text == "")
                    { txtmobile.Text = ""; }
                    if (txtPincode.Text == "")
                    { txtPincode.Text = ""; }
                    if(txtstate.Text == "")
                    { txtstate.Text = ""; }
                    if(Txtemail.Text =="")
                    { Txtemail.Text = ""; }
                }
                else
                {
                    if (txt12.IsChecked == true)
                    {
                        rs12 = "1";
                    }
                    else
                    {
                        rs12 = "0";
                    }
                    if (txt24.IsChecked == true)
                    {
                        rs24 = "1";
                    }
                    else
                    {
                        rs24 = "0";
                    }
                    hinfo.Name = txtname.Text;
                    hinfo.city = txtCity.Text;
                    hinfo.Country = txtcountry.Text;
                    hinfo.Email = Txtemail.Text;
                    hinfo.GST_NO = txtgst.Text;
                    hinfo.Plot_No = txtplotno.Text.Trim();
                    hinfo.Landline_1 = txtlandline1.Text;
                    hinfo.Landline_2 = txtlandline2.Text;
                    hinfo.Landmark = txtlandmark.Text;
                    hinfo.Mobile_No = txtmobile.Text;
                    hinfo.Pincode = txtPincode.Text.Trim();
                    hinfo.State = txtstate.Text;
                    hinfo.website = txtweb.Text;
                    hinfo.HOURS12 = rs12;
                    hinfo.HOURS24 = rs24;
                    hinfo.EXTRAHOURS = txthours.Text;
                    // S R II I I 11/15/2017 
                    //hinfo.USER_NAME = login.u;
                    hinfo.INSERT_BY = login.u;
                    hinfo.INSERT_DATE = DateTime.Today;
                    DataTable dt = hinfo.GetIn();
                   
                        if (dt.Rows.Count >= 1)
                        {
                            //hinfo.Insert();
                            string a = "Update", b = Convert.ToString(btnSave.Content);
                        if (a == b)
                        {
                            hinfo.Name = txtname.Text;

                            hinfo.city = txtCity.Text;
                            hinfo.Country = txtcountry.Text;
                            hinfo.Email = Txtemail.Text;
                            hinfo.GST_NO = txtgst.Text;
                            hinfo.Plot_No = txtplotno.Text.Trim();
                            hinfo.Landline_1 = txtlandline1.Text;
                            hinfo.Landline_2 = txtlandline2.Text;
                            hinfo.Landmark = txtlandmark.Text;
                            hinfo.Mobile_No = txtmobile.Text;
                            hinfo.Pincode = txtPincode.Text.Trim();
                            hinfo.State = txtstate.Text;
                            hinfo.website = txtweb.Text;
                            hinfo.HOURS12 = rs12;
                            hinfo.HOURS24 = rs24;
                            hinfo.EXTRAHOURS = txthours.Text;
                            hinfo.Insert();
                            //System.Windows.MessageBox.Show("Updated sucessfully");
                            popup_update.IsOpen = true;
                            btnSave.Content = "Save";
                            clrtextfield();
                            this.NavigationService.Refresh();
                        }
                        //insert.Content = "Updated Sucessfully";
                        //pop3.IsOpen = true;
                            else
                            {
                                pop2.IsOpen = true;
                            }
                        }
                        else if (dt.Rows.Count == 0)
                        {
                            hinfo.Insert();
                            string a1 = "Save", b1 = Convert.ToString(btnSave.Content);
                            if (b1 == a1)
                            {
                            // insert.Content = "Inserted Sucessfully";
                            //pop3.IsOpen = true;
                            //btnSave.Content = "Save";
                            //System.Windows.MessageBox.Show("Saved sucuessfully");
                            popup_insert.IsOpen = true;
                                

                            }
                            clrtextfield();
                            this.NavigationService.Refresh();
                            this.btnSave.IsEnabled = true;
                            if (!this.Modify.IsEnabled)
                            {
                                this.Modify.IsEnabled = true;
                            }
                            btnSave.Content = "Save";
                            dis();

                            //Add.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                            Modify.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                        //}
                    }

                }
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("please check the values.");
            }
        }
        private void txtname_LostFocus(object sender, RoutedEventArgs e)
        {
            //Hotelinfo hinfo = new Hotelinfo();
            string a = "Update", b = Convert.ToString(btnSave.Content);
            if (b == a)
            {
                hinfo.Name = txtname.Text;
                hinfo.UPDATE_BY = login.u;
                hinfo.UPDATE_DATE = DateTime.Today;
                hinfo.GetInfo();
                txtCity.Text = hinfo.city;
                txtcountry.Text = hinfo.Country;
                Txtemail.Text = hinfo.Email;
                txtgst.Text = hinfo.GST_NO;
                txtlandline1.Text = hinfo.Landline_1;
                txtlandline2.Text = hinfo.Landline_2;
                txtlandmark.Text = hinfo.Landmark;
                txtmobile.Text = hinfo.Mobile_No;
                txtPincode.Text = hinfo.Pincode;
                txtplotno.Text = hinfo.Plot_No;
                txtstate.Text = hinfo.State;
                txtweb.Text = hinfo.website;
                if(hinfo.HOURS12 == "0")
                {
                    txt12.IsChecked = false;
                }
                else
                {
                    txt12.IsChecked = true;
                }
                if(hinfo.HOURS24 == "0")
                {
                    txt24.IsChecked = false;
                }
                else
                {
                    txt24.IsChecked = true;
                }
                txthours.Text = hinfo.EXTRAHOURS;
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            clrtextfield();
            pop2.IsOpen = false;
            this.NavigationService.Refresh();
        }

        private void updatepop_Click(object sender, RoutedEventArgs e)
        {
            popup_update.IsOpen = false;
        }

        private void insertpop_Click(object sender, RoutedEventArgs e)
        {
            popup_insert.IsOpen = false;
        }

       
        
        //Image Upload Code...
        //private void btnupload_Click(object sender, RoutedEventArgs e)
        //{
        //    Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
        //    dlg.InitialDirectory = "c:\\";
        //    dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
        //    if(dlg.ShowDialog()==true)
        //    {
        //        System.IO.Stream stream = System.IO.File.Open(dlg.FileName, System.IO.FileMode.Open);
        //        BitmapImage imgsrc = new BitmapImage();
        //        imgsrc.BeginInit();
        //        imgsrc.StreamSource = stream;
        //        imgsrc.EndInit();
        //    }    
    }
}


