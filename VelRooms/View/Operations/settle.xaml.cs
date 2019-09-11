using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using HMS.ViewModel;
using HMS.Model;
using HMS.Model.Operations;
using HMS.View.Masters;
using System.Data;
using HMS.Model.Others;
using System.Net;
using System.Text;
using System.IO;

namespace HMS.View
{
    /// <summary>
    /// Interaction logic for settle.xaml
    /// </summary>
    public partial class settle : Page
    {
        Print S = new Print();
        Hotelinfo hotelinfo = new Hotelinfo();
        Home hm = new Home();
        Checkout1 c = new Checkout1();
        Settle1 p = new Settle1();
        public int error = 0;
        public settle()
        {
            data.COUNT = 0;
            InitializeComponent();
            data.COUNT = 1;
            //txtbillno.Text = "";
            //txtroom.Text = "";
            //txtname.Text = "";
            //txtreg.Text = "";
            //txtcompany.Text = "";
            //txtttlamt.Text = "";
            //txttipamt.Text = "";
            //txtamt.Text = "";
            //txttrcno.Text = "";
            //txtchkno.Text = "";
            //txtroom.Text = Checkout1.RR.ToString()
            CBONLINEPAYMENT.IsEnabled = false;
            txttipamt1.IsEnabled = true;
            txttipamt.Text = "0.00";
            p.BILL();
            DataTable d = p.DETAILS();
            GUESTDETAILS.ItemsSource = d.DefaultView;
        }
        private void txtbillno_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                S.BILL_NO = txtbillno.Text;
                S.get();
                decimal ttlamt = Convert.ToDecimal(S.TOTAL);
                decimal blamnt = Convert.ToDecimal(S.BLANCEAMOUNT);
                txtroom.Text = S.ROOM_NO;
                txtname.Text = S.GUESTNAME;
                txtcompany.Text = S.COMPANYNAME;
                txtttlamt.Text = Convert.ToString(Math.Round(ttlamt, 2, MidpointRounding.AwayFromZero));
                txtamt.Text = Convert.ToString(Math.Round(blamnt, 2, MidpointRounding.AwayFromZero));
                txtblamt.Text = Convert.ToString(Math.Round(blamnt, 2, MidpointRounding.AwayFromZero));
                txtamt1.Text = txtblamt.Text;
            }
            catch (Exception) { }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (error != 0 || txtbillno.Text == "" || txtroom.Text == "" || txtname.Text == "" || txtttlamt.Text == "" || txtamt.Text == "")
                {
                    if (txtbillno.Text == "")
                    { txtbillno.Text = ""; }
                    if (txtroom.Text == "")
                    { txtroom.Text = ""; }
                    if (txtname.Text == "")
                    { txtname.Text = ""; }
                    //if(txtcompany.Text == "")
                    //{ txtcompany.Text = ""; }
                    if (txtttlamt.Text == "")
                    { txtttlamt.Text = ""; }
                    //if(txttipamt.Text == "")
                    //{ txttipamt.Text = ""; }
                    if (txtamt.Text == "")
                    { txtamt.Text = ""; }
                }
                else
                {
                    Settle1 S = new Settle1();
                    S.BILL_NO = txtbillno.Text;
                    S.ROOM_NO = txtroom.Text;
                    S.GUEST_NAME = txtname.Text;
                    S.REGISTRATIOIN_NO = txtreg.Text;
                    S.COMPANYNAME = txtcompany.Text;
                    S.TOTAL = txtttlamt.Text;
                    S.TIP_AMOUNT = txttipamt.Text;
                    S.BALANCE_AMOUNT = txtblamt.Text;
                    S.PAYMENT_MODE = CBPAYMENT.Text;
                    S.ONLINE_PAYMENT = CBONLINEPAYMENT.Text;
                    S.CURRENCY = CBCURRENCY.Text;
                    S.AMOUNT = txtamt.Text;
                    S.TRANSFER_NO = txttrcno.Text;
                    S.CHEQUE_NO = txtchkno.Text;
                    //S.USER_NAME = login.u;
                    S.INSERT_BY = login.u;
                    S.INSERT_DATE = DateTime.Today;
                    S.insert();
                    Checkout1.RR = int.Parse(txtroom.Text);
                    c.Insert();
                    Send_sms();
                    S.printsupdate();
                    S.ColorUpdate("Blue");
                    c.ADVANCEINT();
                    S.update();
                    c.DISCOUNTINT();
                    c.POSTCHARGESINT();
                    S.UP();
                    S.printsBILLLUPDATE();
                    S.roomstatus();
                    c.CC();
                    clear1();
                    //String SS = await DELAY();
                    //var list = new List<SqlParameter>();
                    //string color = "UPDATE ROOMMASTER SET BACKGROUND_COLOR = @BGCOLOR WHERE ROOM_NO=@ROOMNO";
                    //list.AddSqlParameter("@BGCOLOR", "Green");
                    //list.AddSqlParameter("@ROOMNO", S.ROOM_NO);
                    //DbFunctions.ExecuteCommand<DataTable>(color, list);
                    hm.truncate();
                    MessageBox.Show("Updated Successfully");
                    NavigationService.Navigate(new Uri("View/Operations/Checkout.xaml", UriKind.RelativeOrAbsolute));
                    //NavigationService nav = NavigationService.GetNavigationService(this);
                    //nav.Refresh();
                }
            }
            catch (Exception) { }
        }
        public DataTable()
        {
           
        }


        public void Send_sms()
        {
            DataTable landline = hotelinfo.getLandLinenumber();
            String ll_number = landline.Rows[0]["MOBILE_NO"].ToString();
            //string no = "9848082999";
            String username = "9494433233";
            String password = "33233";
            SmsMobileNumber = "91" + "9494433033";
            SmsMessage = "Check Out : " + + "\nAdvance Paid : " +  + "\nName : " + .t +"";
            String url = "http://sms.zestwings.com/smpp.sms?username=" + username + "&password=" + password + "&to=" + SmsMobileNumber + "&from=HRTVEL&text=" + SmsMessage + "";
            try
            {
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(url);
                //Prepare and Add URL Encoded data
                UTF8Encoding encoding = new UTF8Encoding();
                httpWReq.Method = "GET";
                httpWReq.ContentType = "application/x-www-form-urlencoded";

                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string responseString = reader.ReadToEnd();

                //Close the response
                reader.Close();
                response.Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public async Task<String> DELAY()
        {
            await Task.Delay(900000);
            return "OK";
        }
        public void clear1()
        {
            txtbillno.Text = "";
            txtroom.Text = "";
            txtname.Text = "";
            txtreg.Text = "";
            txtcompany.Text = "";
            txtttlamt.Text = "";
            txttipamt.Text = "";
            txtblamt.Text = "";
            CBPAYMENT.Text = "";
            CBONLINEPAYMENT.Text = "";
            CBCURRENCY.Text = "";
            txtamt.Text = "";
            txttrcno.Text = "";
            txtchkno.Text = "";
            this.NavigationService.Refresh();
        }
        private void CBPAYMENT_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (CBPAYMENT.Text == "Cash")
                {
                    txttrcno.IsEnabled = false;
                    txtchkno.IsEnabled = false;
                    CBONLINEPAYMENT.IsEnabled = false;
                }
                else if (CBPAYMENT.Text == "Card")
                {
                    txttrcno.IsEnabled = true;
                    txtchkno.IsEnabled = false;
                    CBONLINEPAYMENT.IsEnabled = false;
                }
                else if (CBPAYMENT.Text == "Cheque")
                {
                    txttrcno.IsEnabled = false;
                    txtchkno.IsEnabled = true;
                    CBONLINEPAYMENT.IsEnabled = false;
                }
                else if (CBPAYMENT.Text == "Wallet Payment")
                {
                    txttrcno.IsEnabled = true;
                    txtchkno.IsEnabled = false;
                    CBONLINEPAYMENT.IsEnabled = true;
                }
                if (CBPAYMENT.Text == "Others")
                {
                    pu.IsOpen = true;
                    txttrcno.IsEnabled = false;
                    txtchkno.IsEnabled = false;
                    txttipamt1.IsEnabled = false;
                    CBONLINEPAYMENT.IsEnabled = false;
                }
            }
            catch (Exception) { }
        }
        private void CBOTHER_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (CBOTHER.Text == "Payment Type")
                {
                    //txttipamt1.IsEnabled = false;
                    //s.BILL_NO = txtbillno.Text;
                    //s.ROOM_NO = txtroom.Text;
                    //s.OTHER = CBOTHER.Text;
                    //s.AMOUNT = txtamt1.Text;
                    //s.TIP_AMOUNT = txttipamt.Text;
                    //s.REMARKS = txtremark.Text;
                    //s.TO_ROOMNO = txttipamt1.Text;
                    //// s.USER_NAME = login.u;
                    //s.INSERT_BY = login.u;
                    //s.INSERT_DATE = DateTime.Today;
                }
                else if (CBOTHER.Text == "Bill On Hold")
                {
                    txttipamt1.IsEnabled = false;
                    submit.Content = "Bill On Hold";
                    
                }
                else if (CBOTHER.Text == "Complimentry")
                {
                    txttipamt1.IsEnabled = false;
                    submit.Content = "Complimentry";
                }
                else if (CBOTHER.Text == "Transfer")
                {
                    txttipamt1.IsEnabled = true;
                    submit.Content = "Transfer";
                }
            }
            catch (Exception) { }
        }
        Settle1 settle1 = new Settle1();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //try
            //{
                settle1.BILL_NO = txtbillno.Text;
                settle1.ROOM_NO = txtroom.Text;
                settle1.GUEST_NAME = txtname.Text;
                settle1.OTHER = CBOTHER.Text;
                settle1.AMOUNT = txtttlamt.Text;
                settle1.TIP_AMOUNT = txttipamt.Text;
                settle1.REMARKS = txtremark.Text;
                settle1.TO_ROOMNO = txttipamt1.Text;
                settle1.TO_GUEST = TXTTOROOM.Text;
                settle1.BALANCE = txtamt1.Text;
                settle1.INSERT_BY = login.u;
                settle1.INSERT_DATE = DateTime.Today;
                if (CBOTHER.Text == "Payment Type")
                {
                    MessageBox.Show("Please Select The Pay Type");
                }
                else if (CBOTHER.Text == "Bill On Hold")
                {
                    pu.IsOpen = false;
                    settle1.STATUS = "BOH";
                    Checkout1.RR = int.Parse(txtroom.Text);
                    c.Insert();
                    settle1.otherinsert();
                    settle1.printsupdate();
                    settle1.ColorUpdate("Green");
                    settle1.update();
                    c.ADVANCEINT();
                    c.DISCOUNTINT();
                    c.POSTCHARGESINT();
                    settle1.UP();
                    settle1.printsBILLLUPDATE();
                    c.CC();
                    clear1();
                    hm.truncate();
                }
                else if (CBOTHER.Text == "Complimentry")
                {
                    pu.IsOpen = false;
                    settle1.STATUS = "CMP";
                    Checkout1.RR = int.Parse(txtroom.Text);
                    c.Insert();
                    settle1.otherinsert();
                    settle1.printsupdate();
                    settle1.ColorUpdate("Green");
                    settle1.update();
                    c.ADVANCEINT();
                    c.DISCOUNTINT();
                    c.POSTCHARGESINT();
                    settle1.UP();
                    settle1.printsBILLLUPDATE();
                    c.CC();
                    clear1();
                    hm.truncate();
                }
                else if (CBOTHER.Text == "Transfer")
                {
                    if(txttipamt1.Text.ToString() == "" || txttipamt1.Text.ToString() == null)
                    {
                        MessageBox.Show("Please enter occupied Room No");
                    }
                    else
                    {
                        pu.IsOpen = false;
                        Checkout1.RR = int.Parse(txtroom.Text);
                        c.Insert();
                        settle1.TRANSFER();
                        settle1.printsupdate();
                        settle1.ColorUpdate("Green");
                        settle1.update();
                        c.ADVANCEINT();
                        c.DISCOUNTINT();
                        c.POSTCHARGESINT();
                        settle1.UP();
                        settle1.printsBILLLUPDATE();
                        c.CC();
                        clear1();
                        hm.truncate();
                    }
                }
                this.NavigationService.Refresh();
            //}
            //catch (Exception) { }
        }
        private void txttipamt1_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Settle1 S = new Settle1();
                S.ROOM_NO = txttipamt1.Text;
                DataTable dt = S.OccupiedCheck();
                if (dt.Rows.Count == 0)
                {
                    txttipamt1.Text = "";
                    MessageBox.Show("Please Select the Occupied Room.!");
                }
                else
                {
                }
                //string a = "TRANSFER", b = Convert.ToString(submit.Content);
                //if (b == a)
                //{
                //    Checksin SS = new Checksin();
                //    SS.ROOM_NO = txttipamt1.Text;
                //    TXTTOROOM.Text = SS.FIRSTNAME;
                //    SS.roomchange();
                //}
            }
            catch (Exception) { }
        }
        private void txttipamt_LostFocus(object sender, RoutedEventArgs e)
        {
            decimal amnt = ((Convert.ToDecimal(blamnt1)) + (Convert.ToDecimal(txttipamt.Text)));
            txtblamt.Text = Convert.ToString(amnt);
            txtamt.Text = Convert.ToString(amnt);
        }
        private void txtroom_TextInput(object sender, TextCompositionEventArgs e)
        {
        }
        private void txtroom_GotFocus(object sender, RoutedEventArgs e)
        {
            settle1.ROOM_NO = txtroom.Text;
            settle1.get_reservation_no();
            txtreg.Text = settle1.REGISTRATIOIN_NO;
        }
        private void CBPAYMENT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if(CBPAYMENT.SelectedIndex == 4)
            //{
            //    CBONLINEPAYMENT.IsEnabled = true;
            //}
            //else if(CBPAYMENT.SelectedIndex != 4)
            //{
            //    CBONLINEPAYMENT.IsEnabled = false;
            //}
        }
        //txtbillno,txtroom,txtname,txtcompany,txtttlamt,txttipamt,txtblamt,txtamt;
        decimal ttlamt1, blamnt1;
        private object txtfirstname;

        public string SmsMobileNumber { get; private set; }
        public int SmsMessage { get; private set; }
        public string AdvanceAmount { get; private set; }

        private void GUESTDETAILS_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int i = GUESTDETAILS.SelectedIndex;
                DataTable dg = S.getbilllist();
                if (dg.Rows.Count <= 0)
                {
                }
                else
                {
                    ttlamt1 = Convert.ToDecimal(dg.Rows[i]["TOTAL"].ToString());
                    blamnt1 = Convert.ToDecimal(dg.Rows[i]["BALANCE_AMOUNT"].ToString());
                    txtbillno.Text = dg.Rows[i]["BILL_NO"].ToString();
                    txtroom.Text = dg.Rows[i]["ROOM_NO"].ToString();
                    settle1.ROOM_NO = txtroom.Text;
                    settle1.get_reservation_no();
                    txtreg.Text = settle1.REGISTRATIOIN_NO;
                    txtname.Text = dg.Rows[i]["GUEST_NAME"].ToString();
                    txtcompany.Text = dg.Rows[i]["COMPANYNAME"].ToString();
                    txtttlamt.Text = Convert.ToString(Math.Round(ttlamt1, 2, MidpointRounding.AwayFromZero));
                    txtblamt.Text = Convert.ToString(Math.Round(blamnt1, 2, MidpointRounding.AwayFromZero));
                    txtamt.Text = Convert.ToString(Math.Round(blamnt1, 2, MidpointRounding.AwayFromZero));
                    txtamt1.Text = txtblamt.Text;
                    txtamt.IsEnabled = false;
                    txtbillno.IsEnabled = false;
                    txtroom.IsEnabled = false;
                    txtreg.IsEnabled = false;
                    txtttlamt.IsEnabled = false;
                    txtname.IsEnabled = false;
                    txtcompany.IsEnabled = false;
                    txtblamt.IsEnabled = false;
                }
            }
            catch (Exception) { }
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            pu.IsOpen = false;
        }
        

        
    }
}