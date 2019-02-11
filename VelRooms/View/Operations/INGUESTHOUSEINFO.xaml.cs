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
using HMS.Model;
using HMS.View.Masters;
using HMS.ViewModel;

namespace HMS.View.Operations
{
    /// <summary>
    /// Interaction logic for INGUESTHOUSEINFO.xaml
    /// </summary>
    public partial class INGUESTHOUSEINFO : Page
    {
        public int error = 0;
        //public void FALSE()
        //{
        //    txtroomno.IsEnabled = false;
        //    txtname.IsEnabled = false;
        //    txtcompanyname.IsEnabled = false;
        //    txtarrivaltime.IsEnabled = false;
        //    txtdeparturetime.IsEnabled = false;
        //    txtcontactno.IsEnabled = false;
        //    txtemail.IsEnabled = false;
        //    dt.IsEnabled = false;
        //    dt1.IsEnabled = false;
        //    Save.IsEnabled = false;
        //    clear.IsEnabled = false;
        //}
        public void TRUE()
        {
            txtroomno.IsEnabled = true;
            txtname.IsEnabled = true;
            txtcompanyname.IsEnabled = true;
            txtarrivaltime.IsEnabled = true;
            txtdeparturetime.IsEnabled = true;
            txtcontactno.IsEnabled = true;
            txtemail.IsEnabled = true;
            dt.IsEnabled = true;
            dt1.IsEnabled = true;
            Save.IsEnabled = true;
            clear.IsEnabled = true;
            Modify.IsEnabled = true;
        }
        public void CLEAR()
        {
            txtroomno.Text = "";
            txtname.Text = "";
            txtcompanyname.Text = "";
            txtarrivaltime.Text = "";
            txtdeparturetime.Text = "";
            txtcontactno.Text = "";
            txtemail.Text = "";
            dt.Text = "";
            dt1.Text = "";
            Save.IsEnabled = false;
            txtroomno.IsReadOnly = false;
            this.NavigationService.Refresh();
        }
        public INGUESTHOUSEINFO()
        {
            data.COUNT = 0;
            InitializeComponent();
            data.COUNT = 1;
            //FALSE();
           // Add.IsEnabled = true;
            Modify.IsEnabled = true;
            Save.Content = "Save";
            insertpop.Content = "insertpopup";
        }
        //private void Add_Click(object sender, RoutedEventArgs e)
        //{
        //    //Add.IsEnabled = false;
        //    Modify.IsEnabled = false;
        //    Save.Content = "Save";
        //    TRUE();
        //    CLEAR();
        //    //insertpop.Content = "insertpopup";
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
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (error != 0 || txtroomno.Text == "" || txtcontactno.Text == "")
                {
                    //         pop1.IsOpen = true;
                    if (txtroomno.Text == "")
                    { txtroomno.Text = ""; }
                    if (txtcontactno.Text == "")
                    { txtcontactno.Text = ""; }
                }
                else
                {
                    INGUESTHOUSEINFOS IN = new INGUESTHOUSEINFOS();
                    IN.ROOM_NO = txtroomno.Text;
                    IN.GUEST_NAME = txtname.Text;
                    IN.COMPANY_NAME = txtcompanyname.Text;
                    IN.ARRIVAL_DATE = dt.Text;
                    IN.ARRIVAL_TIME = txtarrivaltime.Text;
                    IN.DEPARTURE_DATE = dt1.Text;
                    IN.DEPARTURE_TIME = txtdeparturetime.Text;
                    IN.CONTACT_NO = txtcontactno.Text;
                    IN.EMAIL = txtemail.Text;
                    IN.ID_TYPE = idproof.Text;
                    IN.ID_DATA = txtproof.Text;

                    //11/15/2017 dddd
                    //IN.USER_NAME = login.u;
                    IN.INSERT_BY = login.u;
                    IN.INSERT_DATE = DateTime.Today;


                    string a1 = "Save", b1 = Convert.ToString(Save.Content);
                    if (b1 == a1)
                    {
                        IN.INSERT();
                        IN.guestupdate();
                        MessageBox.Show("Saved sucessfully");
                        // Save.Content = "Save";
                        //insert.Content = "Inserted Sucessfully";
                        //pop2.IsOpen = true;
                    }

                    string a = "Update", b = Convert.ToString(Save.Content);
                    if (b == a)
                    {
                        IN.INSERT();
                        //insert.Content = "Updated Sucessfully";
                        //  pop2.IsOpen = true;
                        MessageBox.Show("Updated sucessfully");
                    }
                    IN.UPDTE();
                    CLEAR();
                }
            }
            catch (Exception) { }
        }
        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            //Add.IsEnabled = false;
            Save.Content = "Update";
            Modify.IsEnabled = true;
            TRUE();
            insertpop.Content = "updatepopup";
        }
        private void txtroomno_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                INGUESTHOUSEINFOS I = new INGUESTHOUSEINFOS();
                I.ROOM_NO = txtroomno.Text;
                DataTable dl = I.guest();
                if(dl.Rows.Count == 0)
                {
                    Save.IsEnabled = false;
                    txtroomno.IsReadOnly = false;
                }
                else
                {
                    txtroomno.IsReadOnly = true;
                    Save.IsEnabled = true;
                    txtname.Text = I.GUEST_NAME;
                    txtcompanyname.Text = I.COMPANY_NAME;
                    dt.Text = I.ARRIVAL_DATE;
                    txtarrivaltime.Text = I.ARRIVAL_TIME;
                    dt1.Text = I.DEPARTURE_DATE;
                    txtdeparturetime.Text = I.DEPARTURE_TIME;
                    txtcontactno.Text = I.CONTACT_NO;
                    txtemail.Text = I.EMAIL;
                }
            }
            catch (Exception)
            {
            }
        }
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            CLEAR();
        }
        private void insertpop_Click(object sender, RoutedEventArgs e)
        {
            pop2.IsOpen = false;
        }
        data daa = new data();
        private void txtproof_LostFocus(object sender, RoutedEventArgs e)
        {
            Binding b = new Binding();
            if (idproof.Text == "Aadhar")
            {
                b.Source = daa;
                daa.Addharcard = txtproof.Text;
                b.Path = new PropertyPath("Addharcard");
                b.NotifyOnValidationError = true;
                b.ValidatesOnDataErrors = true;
                BindingOperations.SetBinding(txtproof, TextBox.TextProperty, b);
            }
            else if (idproof.Text == "Pancard")
            {
                b.Source = daa;
                daa.Pancard = txtproof.Text;
                b.Path = new PropertyPath("Pancard");
                b.NotifyOnValidationError = true;
                b.ValidatesOnDataErrors = true;
                BindingOperations.SetBinding(txtproof, TextBox.TextProperty, b);
            }
            else if (idproof.Text == "Driving License")
            {
                b.Source = daa;
                daa.Driving = txtproof.Text;
                b.Path = new PropertyPath("Driving");
                b.NotifyOnValidationError = true;
                b.ValidatesOnDataErrors = true;
                BindingOperations.SetBinding(txtproof, TextBox.TextProperty, b);
            }
            else if (idproof.Text == "VoterId")
            {
                b.Source = daa;
                daa.Voterid = txtproof.Text;
                b.Path = new PropertyPath("Voterid");
                b.NotifyOnValidationError = true;
                b.ValidatesOnDataErrors = true;
                BindingOperations.SetBinding(txtproof, TextBox.TextProperty, b);
            }
            else if (idproof.Text == "Passport")
            {
                b.Source = daa;
                daa.Passport = txtproof.Text;
                b.Path = new PropertyPath("Passport");
                b.NotifyOnValidationError = true;
                b.ValidatesOnDataErrors = true;
                BindingOperations.SetBinding(txtproof, TextBox.TextProperty, b);
            }
        }
        private void txtproof_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (idproof.Text == "Aadhar")
            {
                if (txtproof.Text.Length == 4)
                {
                    txtproof.Text += "-";
                    txtproof.SelectionStart = txtproof.Text.Length + 4;
                }
                if (txtproof.Text.Length == 9)
                {
                    txtproof.Text += "-";
                    txtproof.SelectionStart = txtproof.Text.Length + 9;
                }
            }
        }
    }
}
