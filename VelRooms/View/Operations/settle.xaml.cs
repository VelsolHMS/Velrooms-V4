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
                    S.printsupdate();
                    S.ColorUpdate("Blue");
                    c.ADVANCEINT();
                    c.CC();
                    S.update();
                    S.print();
                    c.DISCOUNTINT();
                    c.POSTCHARGESINT();
                    S.UP();
                    S.printsBILLLUPDATE();
                    S.roomstatus();
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
        Settle1 s = new Settle1();
        private void CBOTHER_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (CBOTHER.Text == "Payment Type")
                {
                    txttipamt1.IsEnabled = false;
                    s.BILL_NO = txtbillno.Text;
                    s.ROOM_NO = txtroom.Text;
                    s.OTHER = CBOTHER.Text;
                    s.AMOUNT = txtamt1.Text;
                    s.TIP_AMOUNT = txttipamt.Text;
                    s.REMARKS = txtremark.Text;
                    s.TO_ROOMNO = txttipamt1.Text;
                    // s.USER_NAME = login.u;
                    s.INSERT_BY = login.u;
                    s.INSERT_DATE = DateTime.Today;
                }
                else if (CBOTHER.Text == "Bill On Hold")
                {
                    txttipamt1.IsEnabled = false;
                    submit.Content = "Bill On Hold";
                    s.BILL_NO = txtbillno.Text;
                    s.ROOM_NO = txtroom.Text;
                    s.GUEST_NAME = txtname.Text;
                    s.OTHER = CBOTHER.Text;
                    s.AMOUNT = txtamt1.Text;
                    s.TIP_AMOUNT = txttipamt.Text;
                    s.STATUS = "BOH";
                    s.REMARKS = txtremark.Text;
                    s.TO_ROOMNO = txttipamt1.Text;
                    s.TO_GUEST = TXTTOROOM.Text;
                    // s.USER_NAME = login.u;
                    s.INSERT_BY = login.u;
                    s.INSERT_DATE = DateTime.Today;
                }
                else if (CBOTHER.Text == "Complimentry")
                {
                    txttipamt1.IsEnabled = false;
                    submit.Content = "Complimentry";
                    s.BILL_NO = txtbillno.Text;
                    s.ROOM_NO = txtroom.Text;
                    s.GUEST_NAME = txtname.Text;
                    s.OTHER = CBOTHER.Text;
                    s.AMOUNT = txtamt1.Text;
                    s.TIP_AMOUNT = txttipamt.Text;
                    s.REMARKS = txtremark.Text;
                    s.TO_ROOMNO = txttipamt1.Text;
                    s.GUEST_NAME = TXTTOROOM.Text;
                    s.STATUS = "CMP";
                    //s.USER_NAME = login.u;
                    s.INSERT_BY = login.u;
                    s.INSERT_DATE = DateTime.Today;
                }
                else if (CBOTHER.Text == "Transfer")
                {
                    txttipamt1.IsEnabled = true;
                    submit.Content = "Transfer";
                }
            }
            catch (Exception) { }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CBOTHER.Text == "Payment Type")
                {
                    Settle1 S = new Settle1();
                    txttipamt1.IsEnabled = false;
                    s.BILL_NO = txtbillno.Text;
                    s.ROOM_NO = txtroom.Text;
                    s.OTHER = CBOTHER.Text;
                    s.AMOUNT = txtttlamt.Text;
                    s.TIP_AMOUNT = txttipamt.Text;
                    s.REMARKS = txtremark.Text;
                    s.TO_ROOMNO = txttipamt1.Text;
                    // s.USER_NAME = login.u;
                    s.INSERT_BY = login.u;
                    s.INSERT_DATE = DateTime.Today;
                    s.otherinsert();
                    pu.IsOpen = false;
                    S.printsupdate();
                    S.ColorUpdate("Green");
                    Checkout1.RR = int.Parse(txtroom.Text);
                    c.ADVANCEINT();
                    c.CC();
                    s.update();
                    s.print();
                    c.DISCOUNTINT();
                    c.POSTCHARGESINT();
                    S.UP();
                    S.printsBILLLUPDATE();
                    clear1();
                    hm.truncate();
                }
                else if (CBOTHER.Text == "Bill On Hold")
                {
                    Settle1 S = new Settle1();
                    txttipamt1.IsEnabled = false;
                    submit.Content = "Bill On Hold";
                    S.BILL_NO = txtbillno.Text;
                    S.ROOM_NO = txtroom.Text;
                    S.GUEST_NAME = txtname.Text;
                    S.OTHER = CBOTHER.Text;
                    S.AMOUNT = txtttlamt.Text;
                    decimal amt1 = Convert.ToDecimal(txtttlamt.Text);
                    S.TIP_AMOUNT = txttipamt.Text;
                    S.REMARKS = txtremark.Text;
                    S.TO_ROOMNO = txttipamt1.Text;
                    S.TO_GUEST = TXTTOROOM.Text;
                    S.STATUS = "BOH";
                    S.BALANCE = txtamt1.Text;
                    decimal blamt = Convert.ToDecimal(txtamt1.Text);
                    S.ADVANCE = (amt1 - blamt).ToString();
                    // s.USER_NAME = login.u;
                    S.INSERT_BY = login.u;
                    S.INSERT_DATE = DateTime.Today;
                    S.otherinsert();
                    S.printsupdate();
                    S.ColorUpdate("Green");
                    Checkout1.RR = int.Parse(txtroom.Text);
                    c.ADVANCEINT();
                    c.CC();
                    S.update();
                    S.print();
                    c.DISCOUNTINT();
                    c.POSTCHARGESINT();
                    S.printsBILLLUPDATE();
                    S.UP();
                    pu.IsOpen = false;
                    clear1();
                    hm.truncate();
                }
                else if (CBOTHER.Text == "Complimentry")
                {
                    Settle1 S = new Settle1();
                    txttipamt1.IsEnabled = false;
                    submit.Content = "Complimentry";
                    s.BILL_NO = txtbillno.Text;
                    s.ROOM_NO = txtroom.Text;
                    s.GUEST_NAME = txtname.Text;
                    s.OTHER = CBOTHER.Text;
                    s.AMOUNT = txtttlamt.Text;
                    decimal amt11 = Convert.ToDecimal(txtttlamt.Text);
                    s.TIP_AMOUNT = txttipamt.Text;
                    s.REMARKS = txtremark.Text;
                    s.TO_ROOMNO = txttipamt1.Text;
                    s.GUEST_NAME = TXTTOROOM.Text;
                    s.STATUS = "CMP";
                    s.BALANCE = txtamt1.Text;
                    decimal blamt1 = Convert.ToDecimal(txtamt1.Text);
                    s.ADVANCE = (amt11 - blamt1).ToString();
                    //s.USER_NAME = login.u;
                    s.INSERT_BY = login.u;
                    s.INSERT_DATE = DateTime.Today;
                    s.otherinsert();
                    pu.IsOpen = false;
                    S.printsupdate();
                    S.ColorUpdate("Green");
                    Checkout1.RR = int.Parse(txtroom.Text);
                    c.ADVANCEINT();
                    c.CC();
                    s.update();
                    s.print();
                    c.DISCOUNTINT();
                    c.POSTCHARGESINT();
                    S.UP();
                    clear1();
                    hm.truncate();
                }
                //else if (CBOTHER.Text == "Transfer")
                //{
                //    submit.Content = "transfer";
                //}
                else if (CBOTHER.Text == "Transfer")
                {
                    Settle1 S = new Settle1();
                    S.BILL_NO = txtbillno.Text;
                    S.ROOM_NO = txtroom.Text;
                    S.GUEST_NAME = txtname.Text;
                    S.OTHER = CBOTHER.Text;
                    S.AMOUNT = txtttlamt.Text;
                    S.TIP_AMOUNT = txttipamt.Text;
                    S.REMARKS = txtremark.Text;
                    S.TO_ROOMNO = txttipamt1.Text;
                    //s.TO_GUEST = TXTTOROOM.Text;
                    // s.USER_NAME = login.u;
                    S.INSERT_BY = login.u;
                    S.INSERT_DATE = DateTime.Today;

                    submit.Content = "submit";
                    //s.otherinsert();
                    S.TRANSFER();
                    pu.IsOpen = false;
                    S.printsupdate();
                    S.ColorUpdate("Green");
                    Checkout1.RR = int.Parse(txtroom.Text);
                    c.ADVANCEINT();
                    c.CC();
                    S.update();
                    S.print();
                    c.DISCOUNTINT();
                    c.POSTCHARGESINT();
                    S.Transfer_amunt();
                    S.UP();
                    S.printsBILLLUPDATE();
                    clear1();
                    hm.truncate();
                }
                this.NavigationService.Refresh();
            }
            catch (Exception) { }
        }
        private void txttipamt1_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                string a = "TRANSFER", b = Convert.ToString(submit.Content);
                if (b == a)
                {
                    Checksin SS = new Checksin();
                    SS.ROOM_NO = txttipamt1.Text;
                    TXTTOROOM.Text = SS.FIRSTNAME;
                    SS.roomchange();
                }
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
            s.ROOM_NO = txtroom.Text;
            s.get_reservation_no();
            txtreg.Text = s.REGISTRATIOIN_NO;
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
                    s.ROOM_NO = txtroom.Text;
                    s.get_reservation_no();
                    txtreg.Text = s.REGISTRATIOIN_NO;
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