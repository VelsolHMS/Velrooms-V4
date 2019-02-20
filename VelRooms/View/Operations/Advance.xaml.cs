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
using System.Data;
using HMS.ViewModel;
using HMS.View.Masters;
using System.Web;
using System.Net;
using System.IO;
using HMS.mainwindowpages;
using CrystalDecisions.CrystalReports.Engine;
using HMS.Model.Operations;
using HMS.View.Operations;

namespace HMS.View.Operations
{
    /// <summary>
    /// Interaction logic for Advance.xaml
    /// </summary>
    public partial class Advance : Page
    {
        public string cc;
        public static decimal aa, ta,tax,sgtax,tamount;
        public int error = 0;
        Checkout1 cout = new Checkout1();
        advance1 adv = new advance1();
        Hotelinfo hotelinfo = new Hotelinfo();
        operations oo = new operations();

        //ReportDocument r = new ReportDocument();
        public Advance()
        {
            data.COUNT = 0;
            InitializeComponent();
            data.COUNT = 1;
            reports.a = 1;
            txtcurrencycode.Text = "INR";
            rbroom.IsChecked = true;
            lblreceiptno.Content = adv.id();
            btnsearch.IsEnabled = true;
            btnsave.IsEnabled = true;
            txtgustname.IsEnabled = true;
            txtcompany.IsEnabled = true;
            txtcompany1.IsEnabled = true;
            txtcontactno.IsEnabled = true;
            Checkout.ref34 = 0;
            //if (Checkout.adv34 == 1)
            //{
            //    DataTable dt = cout.checkoutdata();
            //    if (dt.Rows.Count == 0) { }
            //    else
            //    {
            //        txtroomno.Text = dt.Rows[0]["ROOM_NO"].ToString();
            //        txtgustname.Text = dt.Rows[0]["FIRSTNAME"].ToString();

            //        if (dt.Rows[0]["ADVANCE"].ToString() == "" || dt.Rows[0]["ADVANCE"].ToString() == null)
            //        { aa = Convert.ToDecimal("0.00"); }
            //        else { aa = Convert.ToDecimal(dt.Rows[0]["ADVANCE"].ToString()); }

            //        ta = Convert.ToDecimal(dt.Rows[0]["ROOM_TARRIF"].ToString());
            //        if (dt.Rows[0]["TAX"].ToString() == "" || dt.Rows[0]["TAX"].ToString() == null) { tax = Convert.ToDecimal("0.00"); }
            //        else
            //        {
            //            tax = Convert.ToDecimal(dt.Rows[0]["TAX"].ToString());
            //        }
            //        sgtax = Convert.ToDecimal((ta * tax) / 100);
            //        sgtax = Math.Round(sgtax, 2, MidpointRounding.AwayFromZero);
            //        tamount = Convert.ToDecimal(ta + sgtax);
            //        if (tamount >= aa)
            //        { txtamountreceived.Text = (tamount - aa).ToString(); }
            //        else
            //        {
            //            txtamountreceived.Text = (aa - tamount).ToString();
            //        }
            //        txtcontactno.Text = dt.Rows[0]["MOBILE_NO"].ToString();
            //    }
           // }
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
            pop2.IsOpen = false;
            clear();
            this.NavigationService.Refresh();
        }
        public static DataTable crystal1;
        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            if(txtroomno.Text == "" || txtamountreceived.Text == "")
            {
                //MessageBox.Show("Please Fill all Fields");
                pop2.IsOpen = true;
            }
            else
            {
                popup.IsOpen = true;
            }
        }
        private void yes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (error != 0 || (rbroom.IsChecked == true && txtroomno.Text == "") || (rbresr.IsChecked == true && txtreservation.Text == ""))
                {
                    pop2.IsOpen = true;
                    popup.IsOpen = false;
                }
                else
                {
                    adv.ROOM_NO = txtroomno.Text;
                    adv.RESERVATION_NO = txtreservation.Text;
                    adv.PAYMENT_MODE = cbpayment.Text;
                    adv.CURRENCY_CODE = txtcurrencycode.Text;
                    adv.AMOUNT_RECEIVED = txtamountreceived.Text;
                    adv.ONLINE_PAYMENT = cbonlinepay.Text;
                    adv.PARTICULARS = txtparticulars.Text;
                    adv.TRANSACTION_NO = txttransactionno.Text;
                    adv.CHEQUE_NO = txtchequeno.Text;
                    adv.RECEIPT_NO = lblreceiptno.Content.ToString();
                    // SS RR ii UU ii  11/15/2017
                    //adv.USER_NAME = login.u;
                    if (txtroomno.IsEnabled == true)
                    {
                        adv.ADVANCE_FOR = "Room";
                    }
                    else if (rbresr.IsChecked == true)
                    {
                        adv.ADVANCE_FOR = "Reservation";
                    }
                    adv.INSERT_BY = login.u;
                    adv.INSERT_DATE = DateTime.Today;
                    string a1 = "Save", b1 = Convert.ToString(btnsave.Content);
                    if (b1 == a1)
                    {
                        adv.Insert();
                        //adv.A();
                        popup.IsOpen = false;
                        adv.company_contact();
                        cc = adv.COMPANY_CONTACT;
                        DataTable d = report();
                        advance1.dt = d;
                        //************For Report****************
                        ReportDocument r = new ReportDocument();
                        Checkout1 co = new Checkout1();
                        DataTable hot = co.hotel();
                        crystal1 = hot;
                        r.Load("../../HOTELINFORMATION.rpt");
                        r.Load("../../ADVANCESREPORT.rpt");
                        advance1 advance = new advance1();
                        r.SetDataSource(advance1.dt);
                        r.Subreports[0].SetDataSource(crystal1);
                        r.PrintToPrinter(1, false, 0, 0);
                        r.Refresh();
                        btnsave.IsEnabled = true;
                        btnsearch.IsEnabled = false;
                        clear();
                        btnsave.Content = "Save";
                        popup.IsOpen = false;
                        //MessageBox.Show("inserted sucessfully");
                        popup_insert.IsOpen = true;
                        clear();
                        this.NavigationService.Refresh();
                    }
                }
                this.NavigationService.Refresh();
            }
            catch (Exception) { }
        }
        private void no_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (error != 0 || (rbroom.IsChecked == true && txtroomno.Text == "") || (rbresr.IsChecked == true && txtreservation.Text == ""))
                {
                    pop2.IsOpen = true;
                    popup.IsOpen = false;
                }
                else
                {
                    adv.ROOM_NO = txtroomno.Text;
                    adv.RESERVATION_NO = txtreservation.Text;
                    adv.PAYMENT_MODE = cbpayment.Text;
                    adv.CURRENCY_CODE = txtcurrencycode.Text;
                    adv.AMOUNT_RECEIVED = txtamountreceived.Text;
                    adv.ONLINE_PAYMENT = cbonlinepay.Text;
                    adv.PARTICULARS = txtparticulars.Text;
                    adv.TRANSACTION_NO = txttransactionno.Text;
                    adv.CHEQUE_NO = txtchequeno.Text;
                    adv.RECEIPT_NO = lblreceiptno.Content.ToString();
                    // SS RR ii UU ii  11/15/2017
                    //adv.USER_NAME = login.u;
                    if (txtroomno.IsEnabled == true)
                    {
                        adv.ADVANCE_FOR = "Room";
                    }
                    else if (rbresr.IsChecked == true)
                    {
                        adv.ADVANCE_FOR = "Reservation";
                    }
                    adv.INSERT_BY = login.u;
                    adv.INSERT_DATE = DateTime.Today;
                    string a1 = "Save", b1 = Convert.ToString(btnsave.Content);
                    if (b1 == a1)
                    {
                        adv.Insert();
                        //adv.A();
                        adv.company_contact();
                        popup.IsOpen = false;
                        cc = adv.COMPANY_CONTACT;
                        //MessageBox.Show("inserted sucessfully");
                        popup_insert.IsOpen = true;
                        this.NavigationService.Refresh();
                        clear();
                    }
                }
                this.NavigationService.Refresh();
            }
            catch (Exception) { }
        }
        //public void Send_SMS()
        //{
        //    DataTable landline = hotelinfo.getLandLinenumber();
        //    String ll_number = landline.Rows[0]["LANDLINE1"].ToString();

            //    String username = "9494433233";
            //    String password = "33233";
            //    String mobileNumber = "91" + txtmobileno.Text;
            //    String customer = "Thank you very much for choosing us! \nYour Room No's: " + tbrmst.Text + "\nAdvance Paid: 0.00 \nFor Assistance Call : " + ll_number + "";
            //    String url = "http://sms.zestwings.com/smpp.sms?username=" + username + "&password=" + password + "&to=" + mobileNumber + "&from=VELSOL&text=" + customer + "";

            //    try
            //    {
            //        HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(url);

            //        //Prepare and Add URL Encoded data
            //        UTF8Encoding encoding = new UTF8Encoding();
            //        //byte[] data = encoding.GetBytes(sbPostData.ToString());
            //        //Specify post method
            //        httpWReq.Method = "POST";
            //        httpWReq.ContentType = "application/x-www-form-urlencoded";

            //        HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
            //        StreamReader reader = new StreamReader(response.GetResponseStream());
            //        string responseString = reader.ReadToEnd();

            //        //Close the response
            //        reader.Close();
            //        response.Close();
            //    }
            //    catch (SystemException ex)
            //    {
            //        MessageBox.Show(ex.Message.ToString());
            //    }
            //    //     popup.IsOpen = false;
            //}
        public DataTable report()
        {
            DataTable advrec = new DataTable();

            advrec.Columns.Add("Date", typeof(DateTime));
            advrec.Columns.Add("Receipt No", typeof(string));
            advrec.Columns.Add("Room No", typeof(Int64));
            advrec.Columns.Add("Reservation No", typeof(Int64));
            advrec.Columns.Add("Guest Name", typeof(string));
            advrec.Columns.Add("Guest Contact", typeof(Int64));
            advrec.Columns.Add("Company Name", typeof(string));
            advrec.Columns.Add("Company Contact", typeof(Int64));
            advrec.Columns.Add("Amount", typeof(decimal));
            advrec.Columns.Add("Payment Mode", typeof(string));
            advrec.Columns.Add("Particulars", typeof(string));
            advrec.Columns.Add("Transaction Number", typeof(string));
            advrec.Columns.Add("Cheque Number", typeof(string));
            advrec.Columns.Add("User Name", typeof(string));

            DataRow row = advrec.NewRow();

            row["Date"] = DateTime.Now;
            row["Receipt No"] = lblreceiptno.Content;
            if (txtroomno.Text == "")
            {
                row["Reservation No"] = txtreservation.Text;
                row["Room No"] = 0;
            }
            else
            {
                row["Room No"] = txtroomno.Text;
                row["Reservation No"] = 0;
            }
            row["Guest Name"] = txtgustname.Text;
            row["Guest Contact"] = txtcontactno.Text;
            row["Company Name"] = txtcompany1.Text;
            row["Company Contact"] = cc;
            row["Amount"] = txtamountreceived.Text;
            row["Payment Mode"] = cbpayment.Text;
            row["Particulars"] = txtparticulars.Text;
            if (txttransactionno.Text == "")
            {
                row["Transaction Number"] = "0";
            }
            else
            {
                row["Transaction Number"] = txttransactionno.Text;
            }
            if(txtchequeno.Text == "")
            {
                row["Cheque Number"] = "0";
            }
            else
            {
                row["Cheque Number"] = txtchequeno.Text;
            }
            row["User Name"] = login.u;
            advrec.Rows.Add(row);
            return advrec;
        }
        //clear Method
        public void clear()
        {
            txtroomno.Text = "";
            txtreservation.Text = "";
            txtgustname.Text = "";
            txtcompany.Text = "";
            txtcompany1.Text = "";
            txtcontactno.Text = "";
            cbpayment.Text = "";
            txtamountreceived.Text = "";
            cbonlinepay.Text = "";
            txtparticulars.Text = "";
            txttransactionno.Text = "";
            txtchequeno.Text = "";
            //this.NavigationService.Refresh();
            //btnadd.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
        }
        private void rbroom_Checked(object sender, RoutedEventArgs e)
        {
            txtreservation.Text = null;
            txtreservation.IsEnabled = false;
            txtroomno.IsEnabled = true;

            txtgustname.IsEnabled = true;
            txtcompany.IsEnabled = true;
            txtcompany1.IsEnabled = true;
            txtcontactno.IsEnabled = true;

            txtgustname.Text = "";
            txtcompany.Text = "";
            txtcompany1.Text = "";
            txtcontactno.Text = "";
        }
        private void rbresr_Checked(object sender, RoutedEventArgs e)
        {
            txtroomno.Text = null;
            txtroomno.IsEnabled = false;
            txtreservation.IsEnabled = true;

            txtgustname.IsEnabled = true;
            txtcompany.IsEnabled = true;
            txtcompany1.IsEnabled = true;
            txtcontactno.IsEnabled = true;
            
            txtgustname.Text = "";
            txtcompany.Text = "";
            txtcompany1.Text = "";
            txtcontactno.Text = "";
        }
        private void cbpayment_DropDownClosed(object sender, System.EventArgs e)
        {
            if (cbpayment.Text == "Cheque")
            {
                txtchequeno.IsEnabled = true;
                cbonlinepay.IsEnabled = false;
                txttransactionno.IsEnabled = false;

                cbonlinepay.Text = "";
                txttransactionno.Text = "";
            }
            else if (cbpayment.Text == "Online Payment")
            {
                txtchequeno.IsEnabled = false;
                cbonlinepay.IsEnabled = true;
                txttransactionno.IsEnabled = true;

                txtchequeno.Text = "";
                txttransactionno.Text = "";
            }
            else if (cbpayment.Text == "Cash")
            {
                txtchequeno.IsEnabled = false;
                cbonlinepay.IsEnabled = false;
                txttransactionno.IsEnabled = false;

                txtchequeno.Text = "";
                cbonlinepay.Text = "";
                txttransactionno.Text = "";
            }
            else if (cbpayment.Text == "Card")
            {
                txtchequeno.IsEnabled = false;
                cbonlinepay.IsEnabled = false;
                txttransactionno.IsEnabled = true;
                cbonlinepay.Text = "";
                txtchequeno.Text = "";
                txttransactionno.Text = "";
            }
        }
        public string rno;
        private void txtroomno_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable dt = adv.RoomNo();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rno = dt.Rows[i]["ROOM_NO"].ToString();
                    if (txtroomno.Text == rno)
                    {
                        adv.ROOM_NO = txtroomno.Text;
                        adv.UPDATE_BY = login.u;
                        adv.UPDATE_DATE = DateTime.Today;
                        DataTable dtt = adv.guestinfo();
                        adv.guestinfo();
                        txtgustname.Text = adv.GUEST_NAME;
                        txtcompany.Text = adv.COMPANY_CODE;
                        txtcompany1.Text = adv.COMPANY;
                        txtcontactno.Text = adv.CONTACT_NO;
                        txtroomno.IsEnabled = false;
                        txtreservation.IsEnabled = false;
                        txtgustname.IsEnabled = false;
                        txtcompany.IsEnabled = false;
                        txtcompany1.IsEnabled = false;
                        txtcontactno.IsEnabled = false;
                        break;
                    }
                }
                if (txtroomno.Text != rno)
                {
                    txtroomno.Foreground = Brushes.Red;
                    txtroomno.Text = "";
                    txtgustname.Text = "";
                    txtcompany.Text = "";
                    txtcompany1.Text = "";
                    txtcontactno.Text = "";
                    //MessageBox.Show("Please Enter Valid Room No");
                    pop2.IsOpen = true;
                    txtroomno.Foreground = Brushes.Black;
                }
            }
            catch (Exception) { }
        }

        private void insertpop_Click(object sender, RoutedEventArgs e)
        {
            popup_insert.IsOpen = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            pop2.IsOpen = false;
        }

        private void txtgustname_GotFocus(object sender, RoutedEventArgs e)
        {
            if(rbroom.IsChecked == true)
            {
                if (txtroomno.Text == "")
                {
                    txtroomno.Focus();
                }
            }else if(rbresr.IsChecked == true)
            {
                if (txtreservation.Text == "")
                {
                    txtreservation.Focus();
                }
            }
        }
        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("mainwindowpages/home.xaml", UriKind.RelativeOrAbsolute));
        }
        private void txtreservation_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                adv.RESERVATION_NO = txtreservation.Text;
                DataTable dttt = adv.Resguestinfo();
                if (dttt.Rows.Count > 0)
                {
                    if (adv.ROOM_NO == null || adv.ROOM_NO == "")
                    {
                        txtroomno.Text = "";
                    }
                    else
                    {
                        txtroomno.Text = adv.ROOM_NO;
                    }
                    txtgustname.Text = adv.GUEST_NAME;
                    txtcompany1.Text = adv.COMPANY;
                    txtcontactno.Text = adv.CONTACT_NO;
                    txtroomno.IsEnabled = false;
                    txtgustname.IsEnabled = false;
                    txtcompany.IsEnabled = false;
                    txtcompany1.IsEnabled = false;
                    txtcontactno.IsEnabled = false;
                }
                else
                {
                    txtgustname.IsEnabled = true;
                    txtcompany.IsEnabled = true;
                    txtcompany1.IsEnabled = true;
                    txtcontactno.IsEnabled = true;

                    txtgustname.Text = "";
                    txtcompany.Text = "";
                    txtcompany1.Text = "";
                    txtcontactno.Text = "";
                    txtreservation.Text = "";
                    MessageBox.Show("Reservation id Not valid");
                }
            }
            catch (Exception) { }
        }
        private void btnclear_Click(object sender, RoutedEventArgs e)
        {
            clear();
            this.NavigationService.Refresh();
        }
    }
}