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
using HMS.View.Masters;
using System.Text.RegularExpressions;
using HMS.Model.Operations;
using HMS.mainwindowpages;

namespace HMS.View.Operations
{
    /// <summary>
    /// Interaction logic for Refund.xaml
    /// </summary>
    public partial class Refund : Page
    {
        REFUND R = new REFUND();
        Checkout co = new Checkout();
        Checkout1 cout = new Checkout1();
        RESERVATION re = new RESERVATION();
        operations oo = new operations();
        advance1 ad = new advance1();

        public static string receivedid ,cid;
        public static decimal aa,ba, ta,tax, sgtax,TARIFF,pccharge,Discount;
        public int error = 0;
        public static int a, RRNO;
        
        public Refund()
        {
            data.COUNT = 0;
            InitializeComponent();
            data.COUNT = 1;
            Checkout.adv34 = 0;
            if (Checkout.ref34 == 1)
            {
                refund.IsChecked = true;
                amount.IsEnabled = false;
                balance_amount.IsEnabled = false;
                retensioncharges.IsChecked = false;
                retensioncharges.IsEnabled = false;
                ADVANCEAMOUNT.Text = Checkout.Ch_Advance.ToString();
                ROOMNO.Text = Checkout.roomno;
                cout.ROOM_NO = Checkout.roomno;

                DataTable dt = cout.checkoutdata();
                if (dt.Rows.Count == 0) { }
                else
                {
                    GUESTNAME.Text = dt.Rows[0]["FIRSTNAME"].ToString();
                    ARRIVAL_DATE.Text = dt.Rows[0]["ARRIVAL_DATE"].ToString();
                    DEPARTURE_DATE.Text = dt.Rows[0]["DEPARTURE_DATE"].ToString();
                    PAX.Text = dt.Rows[0]["PAX"].ToString();
                    balance_amount.Text = (Checkout.Ch_PendingAmount * (-1)).ToString();
                    amount.Text = (Checkout.Ch_Charges + Checkout.Ch_Tarrif + (Checkout.Ch_CSGST * 2) - Checkout.Ch_Discount).ToString();
                    cid = dt.Rows[0]["CHECKIN_ID"].ToString();
                    //aa = Convert.ToDecimal(ADVANCEAMOUNT.Text);
                    //TARIFF = Convert.ToDecimal(dt.Rows[0]["ROOM_TARRIF"].ToString());
                    //if(dt.Rows[0]["Discount"].ToString() == null || dt.Rows[0]["Discount"].ToString() == "")
                    //{
                    //    Discount = 0;
                    //}
                    //else
                    //{
                    //    Discount = Convert.ToDecimal(dt.Rows[0]["Discount"].ToString());
                    //}
                    //if (dt.Rows[0]["POSTCHARGES"].ToString() == "" || dt.Rows[0]["POSTCHARGES"].ToString() == null)
                    //{ pccharge = Convert.ToDecimal("0.00"); }
                    //else
                    //{
                    //    pccharge = Convert.ToDecimal(dt.Rows[0]["POSTCHARGES"].ToString());
                    //}
                    //if (dt.Rows[0]["TAX"].ToString() == "" || dt.Rows[0]["TAX"].ToString() == null) { tax = Convert.ToDecimal("0.00"); }
                    //else
                    //{
                    //    tax = Convert.ToDecimal(dt.Rows[0]["TAX"].ToString());
                    //}
                    //sgtax = (Convert.ToDecimal(TARIFF) + Convert.ToDecimal(pccharge))* tax / 100;
                    //sgtax = Math.Round(sgtax, 2, MidpointRounding.AwayFromZero);
                    //ta = (Convert.ToDecimal(TARIFF) + Convert.ToDecimal(pccharge)) + sgtax - Discount;
                    //amount.Text = Convert.ToString(Math.Round(ta, 2, MidpointRounding.AwayFromZero));
                    //ba = Convert.ToDecimal((aa - ta));
                    //balance_amount.Text =  Convert.ToString(Math.Round(ba, 2, MidpointRounding.AwayFromZero));
                }
            }
            if(RESERVATIONS.ResRef == 1)
            {
                amount.IsEnabled = false;
                refund.IsChecked = true;
                //retensioncharges.IsChecked = false;
                balance_amount.IsEnabled = false;
            }
        }
        public void disable()
        {
            RESERVATION_ID.IsEnabled = false; ROOMNO.IsEnabled = false; GUESTNAME.IsEnabled = false; COMPANYNAME.IsEnabled = false;
            ARRIVAL_DATE.IsEnabled = false; DEPARTURE_DATE.IsEnabled = false; ROOMS.IsEnabled = false; PAX.IsEnabled = false;
            ADVANCEAMOUNT.IsEnabled = false; refund.IsEnabled = false; retensioncharges.IsEnabled = false; amount.IsEnabled = false;
            balance_amount.IsEnabled = false; reason.IsEnabled = false;
        }
        public void enable()
        {
            RESERVATION_ID.IsEnabled = true; ROOMNO.IsEnabled = true; refund.IsEnabled = true; retensioncharges.IsEnabled = true; amount.IsEnabled = true;
            balance_amount.IsEnabled = true; reason.IsEnabled = true;
        }
        public static string B = null;
        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clear();
                B = "ADD";
                RR.Visibility = Visibility.Visible; AM.Visibility = Visibility.Visible; mod.Visibility = Visibility.Hidden;
                enable();

                // ADD.Background = new SolidColorBrush(Colors.Orange);
                mod.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            }
            catch (Exception) { }
        }
        public int RERF = 0;
        private void RESERVATION_ID_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ROOMNO.IsEnabled = false;
                if (a != 0)
                {
                    // RESERVATION_ID.Text = receivedid;
                    // ADD.IsEnabled = false;
                    //MODIFY.IsEnabled = false;
                    CLEAR.IsEnabled = false;
                    SAVE.IsEnabled = true;
                    refund.IsEnabled = true;
                    retensioncharges.IsEnabled = true;
                    amount.IsEnabled = true;
                    reason.IsEnabled = true;
                }
                Regex n = new Regex(@"^[0-9]+$");
                string i = RESERVATION_ID.Text;
                if (n.IsMatch(i))
                {
                    if (B == "ADD" || RESERVATION_ID.Text != "")
                    {
                        FETCH();
                    }
                    if (B == "MODIFY")
                    {
                        FETCH();
                        if (CAN == 0)
                        {
                            if (RESERVATION_ID.Text != "")
                            {
                                R.FETCH_MOD_REFUND_RETENSION(); RERF = 1;
                                R.REFUND_AMOUNT = decimal.Round(R.REFUND_AMOUNT, 2);
                                refundmod.Text = R.REFUND_AMOUNT.ToString(); R.RETENSION_AMOUNT = decimal.Round(R.RETENSION_AMOUNT, 2);
                                retensionmod.Text = R.RETENSION_AMOUNT.ToString();
                                totalrefund = R.ADVANCE_AMOUNT + R.REFUND_AMOUNT;
                                totalrefund = decimal.Round(totalrefund, 2);
                                totalretension = R.ADVANCE_AMOUNT + R.RETENSION_AMOUNT;
                                totalretension = decimal.Round(totalretension, 2);
                                total_amount = R.REFUND_AMOUNT + R.RETENSION_AMOUNT + R.ADVANCE_AMOUNT;
                                RERF = 0;
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }
        public int CAN = 0; public decimal totalretension = 0; public decimal total_amount = 0;
        public void FETCH()
        {
            try
            {
                if (RESERVATION_ID.Text != "")
                {
                    R.RESERVATION_ID = Convert.ToInt16(RESERVATION_ID.Text);
                    DataTable D = R.GET_RESERVED_DATA();
                    if (D != null)
                    {
                        if (B == "MODIFY" || B == "ADD")
                        {
                            //  CANCEL = D.Rows[0]["CANCEL"].ToString();
                            //if (CANCEL != "")
                            //{
                            //    CAN = 1;
                            //    if (B == "MODIFY")
                            //    {
                            //        MessageBox.Show("You cant modify  ,reservation has been cancelled ");
                            //    }
                            //    if (B == "ADD") { MessageBox.Show("You cant ADD ,reservation has been cancelled "); }
                            //}
                        }
                        if (CAN == 0)
                        {
                            RESERVATION_ID.Foreground = Brushes.Black;
                            GUESTNAME.Text = D.Rows[0]["FIRSTNAME"] + " " + D.Rows[0]["LASTNAME"];
                            COMPANYNAME.Text = D.Rows[0]["COMPANY_NAME"].ToString();
                            DateTime A = Convert.ToDateTime(D.Rows[0]["ARRIVAL_DATE"].ToString());
                            ARRIVAL_DATE.Text = A.ToShortDateString();
                            DateTime DE = Convert.ToDateTime(D.Rows[0]["DEPARTURE_DATE"].ToString());
                            DEPARTURE_DATE.Text = DE.ToShortDateString();
                            ROOMS.Text = D.Rows[0]["NO_OF_ROOMS"].ToString();
                            PAX.Text = D.Rows[0]["PAX"].ToString();
                        }
                    }
                    if (D == null)
                    {
                        RESERVATION_ID.Foreground = Brushes.Red;
                        MessageBox.Show("Invalid Reservation ID");
                    }
                    if (CAN == 0)
                    {
                        DataTable DT = R.get_advance();
                        if (DT != null)
                        {
                            R.ADVANCE_AMOUNT = Convert.ToDecimal(DT.Rows[0]["AMOUNT_RECEIVED"]);
                            R.ADVANCE_AMOUNT = decimal.Round(R.ADVANCE_AMOUNT, 2);
                            ADVANCEAMOUNT.Text = R.ADVANCE_AMOUNT.ToString();
                            advance_amnt = R.ADVANCE_AMOUNT;
                            R.ADVANCE_ID = Convert.ToInt16(DT.Rows[0]["ADVANCE_ID"]);
                        }
                        if (DT == null)
                        {
                            ADVANCEAMOUNT.Text = "0.00";
                        }
                    }
                }
                else if (RESERVATION_ID.Text == "")
                {
                    GUESTNAME.Text = ""; COMPANYNAME.Text = ""; ADVANCEAMOUNT.Text = ""; ROOMNO.Text = "";
                    ROOMS.Text = ""; PAX.Text = ""; ARRIVAL_DATE.Text = ""; DEPARTURE_DATE.Text = "";
                    if (B == "MODIFY") { RERF = 1; refundmod.Text = ""; retensionmod.Text = ""; RERF = 0; }
                }
            }
            catch (Exception) { }
        }
        public decimal totalrefund = 0;
        private void ROOMNO_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
        private void refund_Checked(object sender, RoutedEventArgs e)
        {
            if(RESERVATIONS.ResRef == 1)
            {
                balance_amount.IsEnabled = false;
                amount.IsEnabled = false;
                balance_amount.Text = ADVANCEAMOUNT.Text;
                amount.Text = "0.00";
            }
            //if (a != 0)
            //{
            //    retensioncharges.IsEnabled = true;
            //}
            //else
            //{
            //    retensioncharges.IsEnabled = false;
            //    amount.Text = "";
            //    reason.Text = "";
            //}
        }
        private void retensioncharges_Checked(object sender, RoutedEventArgs e)
        {
            if(RESERVATIONS.ResRef == 1)
            {
                amount.Text = "0.00";
                amount.IsEnabled = false;
                balance_amount.IsEnabled = true;
                balance_amount.Text = ADVANCEAMOUNT.Text;
            }
            else
            {
                try
                {
                    if (a != 0)
                    {
                        refund.IsEnabled = true;
                    }
                    if (retensioncharges.IsChecked == true)
                    {
                        //  BIND();
                        R.RESERVATION_ID = Convert.ToInt32(RESERVATION_ID.Text);
                        R.GUEST_NAME = GUESTNAME.Text;
                        R.PAX = Convert.ToInt32(PAX.Text);
                        R.ADVANCE_AMOUNT = Convert.ToDecimal(ADVANCEAMOUNT.Text);
                        R.ARRIVAL_DATE = Convert.ToDateTime(ARRIVAL_DATE.Text);
                        R.DEPATURE_DATE = Convert.ToDateTime(DEPARTURE_DATE.Text);
                        R.COMPANY_NAME = COMPANYNAME.Text;
                        //R.AMOUNT = Convert.ToDecimal(amount.Text);
                        //R.BALANCE_AMOUNT = Convert.ToDecimal(balance_amount.Text);
                        //R.REASON = reason.Text;
                        R.advanceamount();
                        //R.IRETENSION();
                        FETCH();
                        amount.Text = "";
                        balance_amount.Text = "";
                        reason.Text = "";
                        if (ADVANCEAMOUNT.Text == "0.00")
                        {
                            canc.IsOpen = true;
                        }
                    }
                    else
                    {
                        refund.IsEnabled = false;
                        amount.Text = "";
                        reason.Text = "";
                    }
                }
                catch (Exception) { }
            }
        }
        private void amount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (amount.Text != "")
                {
                    if (ADVANCEAMOUNT.Text != "")
                    {
                        decimal C = 0;
                        decimal A = Convert.ToDecimal(amount.Text);
                        decimal B = Convert.ToDecimal(ADVANCEAMOUNT.Text);
                        if (B >= A)
                        {
                            C = B - A;
                            balance_amount.Text = C.ToString();
                        }
                        if (A > B)
                        {
                            MessageBox.Show("YOU HAVE EXCEEDED YOUR ADVANCEAMOUNT");
                            amount.Text = "";
                        }
                        decimal D = A + C;
                        if (B < D)
                        {
                            MessageBox.Show("YOU HAVE EXCEEDED YOUR ADVANCEAMOUNT");
                            amount.Text = ""; balance_amount.Text = "";
                        }
                        if (B < C)
                        {
                            MessageBox.Show("YOU HAVE EXCEEDED YOUR ADVANCEAMOUNT");
                            balance_amount.Text = "";
                        }
                    }
                }
                if (amount.Text == "")
                {
                    balance_amount.Text = "";
                }
            }
            catch (Exception) { }
        }
        public void BIND()
        {
            if (ROOMNO.Text == "")
            {
                R.RESERVATION_ID = Convert.ToInt16(RESERVATION_ID.Text);
                R.GUEST_NAME = GUESTNAME.Text;
                R.ROOMS = Convert.ToInt16(ROOMS.Text);
                R.COMPANY_NAME = COMPANYNAME.Text;
                R.ARRIVAL_DATE = Convert.ToDateTime(ARRIVAL_DATE.Text);
                R.DEPATURE_DATE = Convert.ToDateTime(DEPARTURE_DATE.Text);
                R.ROOMS = Convert.ToInt16(ROOMS.Text);
                R.PAX = Convert.ToInt16(PAX.Text);
                R.ADVANCE_AMOUNT = Convert.ToDecimal(ADVANCEAMOUNT.Text);
                R.AMOUNT = Convert.ToDecimal(amount.Text);
                R.BALANCE_AMOUNT = Convert.ToDecimal(balance_amount.Text);
                R.REASON = reason.Text;
                //11/15/2017
                //R.USER_NAME = login.u;
                R.INSERT_BY = login.u;
                R.INSERT_DATE = DateTime.Today.Date;
                //}
            }
            if (RESERVATION_ID.Text == "")
            {
                R.ROOM_NO = Convert.ToInt16(ROOMNO.Text);
                RRNO = R.ROOM_NO;
                R.GUEST_NAME = GUESTNAME.Text;
                //R.ROOMS = Convert.ToInt16(ROOMS.Text);
                //R.COMPANY_NAME = COMPANYNAME.Text;
                R.ARRIVAL_DATE = Convert.ToDateTime(ARRIVAL_DATE.Text);
                R.DEPATURE_DATE = Convert.ToDateTime(DEPARTURE_DATE.Text);
                //R.ROOMS = Convert.ToInt16(ROOMS.Text);
                R.PAX = Convert.ToInt16(PAX.Text);
                R.ADVANCE_AMOUNT = Convert.ToDecimal(ADVANCEAMOUNT.Text);
                R.AMOUNT = Convert.ToDecimal(amount.Text);
                R.BALANCE_AMOUNT = Convert.ToDecimal(balance_amount.Text);
                if (reason.Text != "")
                {
                    R.REASON = reason.Text;
                }//11/15/2017
                //R.USER_NAME = login.u;
                R.INSERT_BY = login.u;
                R.INSERT_DATE = DateTime.Today;
                //}
            }
            if (B == "ADD")
            {
                if (refund.IsChecked == true)
                {
                    R.AMOUNT = Convert.ToDecimal(amount.Text);
                    R.BALANCE_AMOUNT = Convert.ToDecimal(balance_amount.Text);
                }
                if (retensioncharges.IsChecked == true)
                {
                    R.AMOUNT = Convert.ToDecimal(amount.Text);
                    R.BALANCE_AMOUNT = Convert.ToDecimal(balance_amount.Text);
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
        private void SAVE_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (error != 0 || amount.Text == "" || balance_amount.Text == "" || GUESTNAME.Text == "") //||reason.Text==""||RESERVATION_ID.Text==""
                {
                    if (amount.Text == "")
                    { amount.Text = ""; }
                    if (balance_amount.Text == "")
                    { balance_amount.Text = ""; }
                    //if (reason.Text == "")
                    //{ reason.Text = ""; }
                    //if(RESERVATION_ID.Text=="")
                    //{ RESERVATION_ID.Text = ""; }
                    if (GUESTNAME.Text == "")
                    { GUESTNAME.Text = ""; }
                }
                else
                {
                    BIND();
                    if (RESERVATION_ID.Text != "")
                    {
                        if (refund.IsChecked == true)
                        {
                            if (balance_amount.Text == "0.00" || balance_amount.Text == "0.0" || balance_amount.Text == "0")
                            {
                                MessageBox.Show("Refund amount Should not be Zero");
                            }
                            else
                            {
                                R.IREFUND();
                            }
                        }
                        else if (retensioncharges.IsChecked == true)
                        {
                            R.IREFUND();
                            R.IRETENSION();
                        }
                    }else if (ROOMNO.Text != "")
                    {
                        R.COUTREFUND();
                        // R.updatepamount();
                    }
                    if (balance_amount.Text == "0.00")
                    {
                        canc.IsOpen = true;
                    }
                    else if (balance_amount.Text != "0.00")
                    {
                        ADVANCEAMOUNT.Text = balance_amount.Text;
                        //MessageBox.Show("Saved Successfully");
                    }
                    popup_insert.IsOpen = true;
                    //if (Checkout.ref34 == 1)
                    //{
                    //    Checkout check = new Checkout();
                    //    this.NavigationService.Navigate(check);
                    //}

                }
                //if (retensioncharges.IsChecked == true)
                //{
                //    BIND();
                //    R.advanceamount();
                //    R.IRETENSION();
                //    FETCH();
                //    amount.Text = "";
                //    balance_amount.Text = "";
                //    reason.Text = "";
                //    if (ADVANCEAMOUNT.Text == "0.00")
                //    {
                //        canc.IsOpen = true;
                //    }
                //}
                //if (ADD.IsEnabled == false && MODIFY.IsEnabled == false && CLEAR.IsEnabled == false)
                //{
                //    if (refund.IsChecked == true)
                //    {
                //        BIND();
                //        R.advanceamount();
                //        R.IREFUND();
                //        FETCH();
                //        amount.Text = "";
                //        balance_amount.Text = "";
                //        reason.Text = "";
                //        if (ADVANCEAMOUNT.Text == "0.00")
                //        {
                //            canc.IsOpen = true;
                //        }
                //    }
                //    else if (retensioncharges.IsChecked == true)
                //    {
                //        BIND();
                //        R.advanceamount();
                //        R.IRETENSION();
                //        FETCH();
                //        amount.Text = "";
                //        balance_amount.Text = "";
                //        reason.Text = "";
                //        if (ADVANCEAMOUNT.Text == "0.00")
                //        {
                //            canc.IsOpen = true;
                //        }
                //    }
                //}
                //else if (error != 0)
                //{
                //    pop1.IsOpen = true;
                //}
                //else
                //{
                //    if (B == "ADD")
                //    {
                //        if (refund.IsChecked == true)
                //        {
                //            BIND();
                //            R.IREFUND();

                //        }
                //        if (retensioncharges.IsChecked == true)
                //        {
                //            BIND();
                //            R.IRETENSION();
                //        }

                //    }
                //    if (B == "MODIFY")
                //    {
                //        R.REFUND_AMOUNT = Convert.ToDecimal(refundmod.Text);
                //        R.RETENSION_AMOUNT = Convert.ToDecimal(retensionmod.Text);
                //        R.ADVANCE_AMOUNT = Convert.ToDecimal(ADVANCEAMOUNT.Text);
                //        R.BALANCE_AMOUNT = Convert.ToDecimal(ADVANCEAMOUNT.Text);
                //        R.RESERVATION_ID = Convert.ToInt16(RESERVATION_ID.Text);
                //        R.UPDATE_REF_RET();
                //    }
                //    clear(); disable();

                //    ADD.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                //    mod.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                //}
            }
            catch (Exception) { }
        }
        public decimal num1, num2, num3;
        private void balance_amount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(retensioncharges.IsChecked == true)
            {
                num1 = Convert.ToDecimal(ADVANCEAMOUNT.Text);
                num2 = Convert.ToDecimal(balance_amount.Text);
                num3 = num1 - num2;
                amount.Text = Math.Round(num3, 2, MidpointRounding.AwayFromZero).ToString();
            }
            else
            {
                if(RESERVATIONS.ResRef == 1)
                {
                    amount.Text = "0.00";
                    balance_amount.Text = ADVANCEAMOUNT.Text;
                }
            }
        }
        public void clear()
        {
            ROOMNO.Text = ""; amount.Text = ""; reason.Text = ""; balance_amount.Text = ""; refund.IsChecked = false; retensioncharges.IsChecked = false; RERF = 1; refundmod.Text = ""; retensionmod.Text = ""; RERF = 0;
            //ADD.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            mod.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            this.NavigationService.Refresh();
        }
        private void MODIFY_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                enable();
                B = "MODIFY";
                RR.Visibility = Visibility.Hidden; AM.Visibility = Visibility.Hidden; mod.Visibility = Visibility.Visible;

                mod.Background = new SolidColorBrush(Colors.Orange);
                //ADD.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            }
            catch (Exception) { }
        }
        public decimal advance_amnt = 0; public decimal c = 0;
        public int STOP = 0;
        private void refundmod_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (RERF != 1)
                {
                    if (refundmod.Text != "")
                    {
                        decimal a = Convert.ToDecimal(ADVANCEAMOUNT.Text);
                        if (refundmod.Text == ".")
                        {
                            refundmod.Text = 0 + refundmod.Text;
                        }
                        decimal b = Convert.ToDecimal(refundmod.Text);
                        if (crt != 0)
                        {
                            decimal limit = RET_AMOUNT + ref_model;
                            if (limit <= total_amount)
                            {
                                if (b < limit)
                                {
                                    if (b <= ref_mod)
                                    {
                                        c = ref_mod - b;

                                        if (ADVANCEAMOUNT.Text != "0")
                                        {
                                            if (advance_amnt == 0) { ADVANCEAMOUNT.Text = (adv - b).ToString(); }
                                            else
                                            {
                                                c = c + advance_amnt; ADVANCEAMOUNT.Text = c.ToString();
                                            }
                                        }
                                        else
                                        {
                                            if (advance_amnt != 0) { ADVANCEAMOUNT.Text = c.ToString(); }
                                            else if (advance_amnt == 0)
                                            {
                                                ADVANCEAMOUNT.Text = (c + RET_AMOUNT).ToString();
                                            }
                                        }
                                    }
                                    else if (b > ref_mod)
                                    {
                                        c = b - ref_mod;
                                        if (ADVANCEAMOUNT.Text != "0")
                                        {
                                            if (advance_amnt == 0) { ADVANCEAMOUNT.Text = (adv - b).ToString(); }
                                            else
                                            {
                                                c = c + advance_amnt; if (c > RET_AMOUNT) { c = limit - b; ADVANCEAMOUNT.Text = c.ToString(); }
                                                else { ADVANCEAMOUNT.Text = c.ToString(); }
                                            }
                                        }
                                        else
                                        {
                                            if (advance_amnt != 0) { ADVANCEAMOUNT.Text = c.ToString(); }
                                            else if (advance_amnt == 0)
                                            {
                                                ADVANCEAMOUNT.Text = (c + RET_AMOUNT).ToString();
                                            }
                                        }
                                    }
                                }
                                else if (b > limit)
                                {
                                    //show error
                                    MessageBox.Show("false");
                                }
                                else if (b == limit)
                                {
                                    ADVANCEAMOUNT.Text = (0.00).ToString(); // advance_amnt = R.ADVANCE_AMOUNT;
                                }
                                if (refundmod.Text.Length == 1) { refu = Convert.ToDecimal(refundmod.Text); }
                            }
                        }
                        if (crt == 0)
                        {
                            decimal limit = R.ADVANCE_AMOUNT + R.REFUND_AMOUNT;
                            if (b < limit)
                            {
                                if (b <= R.REFUND_AMOUNT)
                                {
                                    c = R.REFUND_AMOUNT - b;

                                    if (ADVANCEAMOUNT.Text != "0")
                                    {
                                        if (R.ADVANCE_AMOUNT == 0) { ADVANCEAMOUNT.Text = c.ToString(); }
                                        else
                                        {
                                            if (advance_amnt == 0) { ADVANCEAMOUNT.Text = (adv - b).ToString(); }
                                            else
                                            {
                                                c = c + advance_amnt; ADVANCEAMOUNT.Text = c.ToString();
                                            }
                                        }
                                    }
                                    else { if (advance_amnt != 0) { ADVANCEAMOUNT.Text = c.ToString(); } }

                                }
                                else if (b > R.REFUND_AMOUNT)
                                {
                                    c = b - R.REFUND_AMOUNT;
                                    if (ADVANCEAMOUNT.Text != "0")
                                    {

                                        if (R.ADVANCE_AMOUNT == 0) { ADVANCEAMOUNT.Text = c.ToString(); }
                                        else
                                        {
                                            if (advance_amnt == 0) { ADVANCEAMOUNT.Text = (adv - b).ToString(); }
                                            else
                                            {
                                                c = c + advance_amnt; if (c > R.ADVANCE_AMOUNT) { c = limit - b; ADVANCEAMOUNT.Text = c.ToString(); }
                                                else { ADVANCEAMOUNT.Text = c.ToString(); }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (advance_amnt != 0) { ADVANCEAMOUNT.Text = c.ToString(); }
                                    }
                                }
                            }
                            else if (b > limit)
                            {
                                //show error
                                MessageBox.Show("false");
                            }
                            else if (b == limit)
                            {
                                ADVANCEAMOUNT.Text = (0.00).ToString(); // advance_amnt = R.ADVANCE_AMOUNT;
                            }
                            if (refundmod.Text.Length == 1) { refu = Convert.ToDecimal(refundmod.Text); }
                        }
                    }
                    else { if (refu != 0) { adv = Convert.ToDecimal(ADVANCEAMOUNT.Text); adv = adv + refu; ADVANCEAMOUNT.Text = adv.ToString(); advance_amnt = 0; } refu = 0; }
                }
            }
            catch (Exception) { }
        }
        public decimal refu = 0; public decimal crt = 0; public decimal adv = 0;
        public decimal ret = 0; public decimal refun = 0;
        private void retensionmod_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (RERF != 1)
                {
                    if (retensionmod.Text != "")
                    {
                        decimal a = Convert.ToDecimal(ADVANCEAMOUNT.Text);
                        decimal b = Convert.ToDecimal(retensionmod.Text);
                        if (c != 0)
                        {
                            decimal limit = REF_AMOUNT + ret_model;
                            if (limit <= total_amount)
                            {
                                if (b < limit)
                                {
                                    if (b <= ret_mode)
                                    {
                                        crt = ret_mode - b;
                                        if (ADVANCEAMOUNT.Text != "0")
                                        {
                                            if (advance_amnt == 0) { ADVANCEAMOUNT.Text = (readv - b).ToString(); }
                                            else
                                            {
                                                crt = crt + advance_amnt; ADVANCEAMOUNT.Text = crt.ToString();
                                            }
                                        }
                                        else
                                        {
                                            if (advance_amnt != 0) { ADVANCEAMOUNT.Text = crt.ToString(); }
                                            else if (advance_amnt == 0)
                                            {
                                                ADVANCEAMOUNT.Text = (c + REF_AMOUNT).ToString();
                                            }
                                        }
                                    }
                                    else if (b > ret_mode)
                                    {
                                        crt = b - ret_mode;
                                        if (ADVANCEAMOUNT.Text != "0")
                                        {
                                            if (advance_amnt == 0) { ADVANCEAMOUNT.Text = (readv - b).ToString(); }
                                            else
                                            {
                                                crt = crt + advance_amnt; if (crt > REF_AMOUNT) { crt = limit - b; ADVANCEAMOUNT.Text = crt.ToString(); }
                                                else { ADVANCEAMOUNT.Text = crt.ToString(); }
                                            }
                                        }
                                        else
                                        {
                                            if (advance_amnt != 0) { ADVANCEAMOUNT.Text = crt.ToString(); }
                                            else if (advance_amnt == 0)
                                            {
                                                ADVANCEAMOUNT.Text = (c + REF_AMOUNT).ToString();
                                            }
                                        }
                                    }
                                }
                                else if (b > limit)
                                {
                                    //show error
                                    MessageBox.Show("false");
                                }
                                else if (b == limit)
                                {
                                    ADVANCEAMOUNT.Text = "0.00";// advance_amnt = R.ADVANCE_AMOUNT;
                                }
                                if (retensionmod.Text.Length == 1) { ret = Convert.ToDecimal(retensionmod.Text); }
                            }
                        }
                        if (c == 0)
                        {
                            decimal limit = R.ADVANCE_AMOUNT + R.RETENSION_AMOUNT;
                            if (b < limit)
                            {
                                if (b <= R.RETENSION_AMOUNT)
                                {
                                    crt = R.RETENSION_AMOUNT - b;

                                    if (ADVANCEAMOUNT.Text != "0")
                                    {
                                        if (R.ADVANCE_AMOUNT == 0) { ADVANCEAMOUNT.Text = crt.ToString(); }
                                        else
                                        {
                                            if (advance_amnt == 0) { ADVANCEAMOUNT.Text = (readv - b).ToString(); }
                                            else
                                            {
                                                crt = crt + advance_amnt; ADVANCEAMOUNT.Text = crt.ToString();
                                            }
                                        }
                                    }
                                    else { if (advance_amnt != 0) { ADVANCEAMOUNT.Text = crt.ToString(); } }
                                }
                                else if (b > R.RETENSION_AMOUNT)
                                {
                                    crt = b - R.RETENSION_AMOUNT;
                                    if (ADVANCEAMOUNT.Text != "0")
                                    {
                                        if (R.ADVANCE_AMOUNT == 0) { ADVANCEAMOUNT.Text = crt.ToString(); }
                                        else
                                        {
                                            if (advance_amnt == 0) { ADVANCEAMOUNT.Text = (readv - b).ToString(); }
                                            else
                                            {
                                                crt = crt + advance_amnt; if (crt > R.ADVANCE_AMOUNT) { crt = limit - b; ADVANCEAMOUNT.Text = crt.ToString(); }
                                                else { ADVANCEAMOUNT.Text = crt.ToString(); }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (advance_amnt != 0) { ADVANCEAMOUNT.Text = crt.ToString(); }
                                    }
                                }
                            }
                            else if (b > limit)
                            {
                                //show error
                                MessageBox.Show("false");
                            }
                            else if (b == limit)
                            {
                                ADVANCEAMOUNT.Text = "0.00";// advance_amnt = R.ADVANCE_AMOUNT;
                            }
                            if (retensionmod.Text.Length == 1) { ret = Convert.ToDecimal(retensionmod.Text); }
                        }
                    }
                    else { if (ret != 0) { readv = Convert.ToDecimal(ADVANCEAMOUNT.Text); readv = readv + ret; ADVANCEAMOUNT.Text = readv.ToString(); } }
                }
            }
            catch (Exception) { }
        }
        public decimal readv = 0;

        private void ADVANCEAMOUNT_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void insertpop_Click(object sender, RoutedEventArgs e)
        {
            popup_insert.IsOpen = false;
            clear();
            this.NavigationService.Refresh();
        }

        public decimal REF_AMOUNT = 0; public decimal RET_AMOUNT = 0;

        

        public decimal ref_mod = 0; public decimal ret_mode = 0; public decimal ret_model = 0; public decimal ref_model = 0;
        private void refundmod_LostFocus(object sender, RoutedEventArgs e)
        {
            c = Convert.ToDecimal(ADVANCEAMOUNT.Text);
            advance_amnt = Convert.ToDecimal(ADVANCEAMOUNT.Text);
            REF_AMOUNT = Convert.ToDecimal(ADVANCEAMOUNT.Text);
            if (retensionmod.Text != "")
            {
                ret_mode = Convert.ToDecimal(retensionmod.Text);
                ret_model = Convert.ToDecimal(retensionmod.Text);
            }
            else { ret_mode = 0; ret_model = 0; }
        }
        private void retensionmod_LostFocus(object sender, RoutedEventArgs e)
        {
            crt = Convert.ToDecimal(ADVANCEAMOUNT.Text);
            advance_amnt = Convert.ToDecimal(ADVANCEAMOUNT.Text);
            RET_AMOUNT = Convert.ToDecimal(ADVANCEAMOUNT.Text);
            if (refundmod.Text != "")
            {
                ref_mod = Convert.ToDecimal(refundmod.Text);
                ref_model = Convert.ToDecimal(refundmod.Text);
            }
            else { ref_mod = 0; ref_model = 0; }
        }
        private void CLEAR_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Refresh();
        }
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RESERVATION r = new RESERVATION();
                RESERVATIONS re = new RESERVATIONS();
                R.Guestmobileno();
                R.RESERVATION_ID = Convert.ToInt32(RESERVATION_ID.Text);
                R.GUEST_NAME = GUESTNAME.Text;
                R.STATUS = "CANCLED";
                R.ADVANCE_STATUS = "CLEARED";
                R.Status_change();
                R.Insert_Cancellation();
                R.CANCELRESERVATION();
                R.R1();
                this.NavigationService.Navigate(re);
                DataTable dt = r.fill_grid();
                re.dgres.ItemsSource = dt.DefaultView;
            }
            catch (Exception) { }
        }
        private void ROOMNO_LostFocus(object sender, RoutedEventArgs e)
        {
        }
    }
}
