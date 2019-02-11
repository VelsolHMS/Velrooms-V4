using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HMS.Model;
using HMS.ViewModel;
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
using HMS.Model.Operations;
using System.Data;

namespace HMS.View.Operations
{
    /// <summary>
    /// Interaction logic for SplitBill.xaml
    /// </summary>
    public partial class SplitBill : Page
    {
        //Print p = new Print();
        Postcharges pc = new Postcharges();
        Print p = new Print();
        discount dc = new discount();
        Checksin ch = new Checksin();
        advance1 ad = new advance1();
        Checkout1 co = new Checkout1();
        public int bill_no, taxtype, CheckinId,No_of_bills;
        public double total_amount_db, taxamount, splitedtax, total_cost, splitedmoney, money, finalamoutwithorwithouttax, finalcostwithtax, finalcostwithouttax, advance_db, discount_db, postcharges_db, roomtarrif_db, extrabed_a_db,extrabed_c_db;
        public SplitBill()
        {
            InitializeComponent();
        }
        private void Print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Room_no.Text == "")
                {
                    MessageBox.Show("Please Enter Room No");
                }
                else
                {
                    if (No_of_bills != 0)
                    {
                        double roomtariff_split = roomtarrif_db / No_of_bills;
                        double advance_split = advance_db / No_of_bills;
                        double discount_split = discount_db / No_of_bills;
                        double extracharges_split = (extrabed_a_db + extrabed_c_db) / No_of_bills;
                        double cgst_sgst_split = splitedtax / 2;
                        double totalamout_split = splitedtax + roomtariff_split + extracharges_split;
                        double balance_split = totalamout_split - advance_split - discount_split;

                        for (int i = 0; i < No_of_bills; i++)
                        {
                            //bill_no = bill_no + i;
                            //co.BILL_NO = (bill_no + i).ToString();
                            co.ROOM_NO = Room_no.Text;
                            Checkout1.LL = CheckinId;
                            co.CGST = Convert.ToString(Math.Round(cgst_sgst_split, 2, MidpointRounding.AwayFromZero));
                            co.SGST = Convert.ToString(Math.Round(cgst_sgst_split, 2, MidpointRounding.AwayFromZero));
                            co.ROOM_TARRIF = Convert.ToString(Math.Round(roomtariff_split, 2, MidpointRounding.AwayFromZero));
                            co.EXTRA_CHARGES = Convert.ToString(Math.Round(extracharges_split, 2, MidpointRounding.AwayFromZero));
                            co.ADVANCE = Convert.ToString(Math.Round(advance_split, 2, MidpointRounding.AwayFromZero));
                            co.DISCOUNT = Convert.ToString(Math.Round(discount_split, 2, MidpointRounding.AwayFromZero));
                            co.TOTAL = Convert.ToString(Math.Round(totalamout_split, 2, MidpointRounding.AwayFromZero));
                            co.BALANCE_AMOUNT = Convert.ToString(Math.Round(balance_split, 2, MidpointRounding.AwayFromZero));
                            co.BillSplitInsert();
                        }
                        MessageBox.Show("INSERTED SUCCESFULLY");
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Please Select No of Bill Splits");
                    }
                }
            }
            catch (Exception) { }
        }
        private void Clearall_Click_1(object sender, RoutedEventArgs e)
        {
            Clear();
        }
        private void Room_no_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Room_no.Text == "")
                {
                    MessageBox.Show("Please Enter Room No");
                }
                else
                {
                    //p.ROOM_NO = Room_no.Text;
                    //p.GetBillDetails();
                    //getting Checking Id By using Room No
                    bill_no = p.GET_MAXBILLNO();
                    ch.ROOM_NO = Room_no.Text;
                    ch.getCheckinId();
                    CheckinId = ch.CHECKIN_ID;
                    Checkout1.LL = CheckinId;
                    co.ROOM_NO = Room_no.Text;
                    co.CheckingBillgeneration();
                    if (co.RESERVATION_ID == "")
                    {
                        Room_no.Text = "";
                        MessageBox.Show("You have already splited this Bill");
                    }
                    else
                    {
                        first_name.Text = ch.FIRSTNAME;
                        mobile_no.Text = ch.MOBILE_NUMBER.ToString();

                        if (CheckinId == 0)
                        {
                            Clear();
                            MessageBox.Show("No Rooms Found");
                        }
                        else
                        {
                            //getting advance amount By using Room No & checkin Id
                            ad.ROOM_NO = Room_no.Text;
                            ad.GetadvanceAmount(CheckinId);
                            advance_db = Convert.ToDouble(ad.AMOUNT_RECEIVED);

                            //getting discount amount By using Room No & checkin Id
                            dc.CHECKIN_ID = CheckinId;
                            dc.ROOM_NO = Room_no.Text;
                            dc.GetdiscountAmount();
                            discount_db = Convert.ToDouble(dc.AMOUNT);

                            //getting postscharges amount By using Room No & checkin Id
                            pc.CHECKIN_ID = CheckinId;
                            pc.ROOMNO = Convert.ToInt16(Room_no.Text);
                            pc.Getpostcharges();
                            postcharges_db = Convert.ToDouble(pc.TOTAL_AMOUNT);

                            //getting postscharges amount By using Room No & checkin Id
                            pc.CHECKIN_ID = CheckinId;
                            pc.ROOMNO = Convert.ToInt16(Room_no.Text);
                            pc.Getpostcharges();
                            postcharges_db = Convert.ToDouble(pc.CHARGES);

                            //getting nightaudit charges by using Room no and checkin ID
                            pc.CHECKIN_ID = CheckinId;
                            pc.ROOMNO = Convert.ToInt16(Room_no.Text);
                            pc.GetNightAuditcharges();
                            roomtarrif_db = pc.ROOM_TARRIF;
                            extrabed_a_db = pc.EXTRABED_ADULT;
                            extrabed_c_db = pc.EXTRABED_CHILD;
                            total_amount_db = (roomtarrif_db + extrabed_a_db + extrabed_c_db + postcharges_db) - discount_db;//+ advance_db
                            amount.Text = total_amount_db.ToString();
                            if (total_amount_db < 1000.00)
                            {
                                taxamount = 0.01 * total_amount_db;
                            }
                            else if (total_amount_db >= 1000.00 && total_amount_db <= 2499.00)
                            {
                                taxamount = 0.12 * total_amount_db;
                            }
                            else if (total_amount_db <= 4999.00 && total_amount_db >= 2500.00)
                            {
                                taxamount = 0.18 * total_amount_db;
                            }
                            else if (total_amount_db >= 5000.00)
                            {
                                taxamount = 0.25 * total_amount_db;
                            }
                            name1.Text = ch.FIRSTNAME;
                            name2.Text = ch.FIRSTNAME;
                            name3.Text = ch.FIRSTNAME;
                            name4.Text = ch.FIRSTNAME;
                            name5.Text = ch.FIRSTNAME;
                            name6.Text = ch.FIRSTNAME;
                            name7.Text = ch.FIRSTNAME;
                            name8.Text = ch.FIRSTNAME;
                            name9.Text = ch.FIRSTNAME;
                            name10.Text = ch.FIRSTNAME;
                            billno1.Text = bill_no.ToString();
                            billno2.Text = (bill_no + 1).ToString();
                            billno3.Text = (bill_no + 2).ToString();
                            billno4.Text = (bill_no + 3).ToString();
                            billno5.Text = (bill_no + 4).ToString();
                            billno6.Text = (bill_no + 5).ToString();
                            billno7.Text = (bill_no + 6).ToString();
                            billno8.Text = (bill_no + 7).ToString();
                            billno9.Text = (bill_no + 8).ToString();
                            billno10.Text = (bill_no + 9).ToString();

                            No_of_bills = 0;
                            Split2.IsChecked = false;
                            Split3.IsChecked = false;
                            Split4.IsChecked = false;
                            Split5.IsChecked = false;
                            Split6.IsChecked = false;
                            Split7.IsChecked = false;
                            Split8.IsChecked = false;
                            Split9.IsChecked = false;
                            Split10.IsChecked = false;
                            stackrow1.Visibility = Visibility.Hidden;
                            stackrow2.Visibility = Visibility.Hidden;
                            stackrow3.Visibility = Visibility.Hidden;
                            stackrow4.Visibility = Visibility.Hidden;
                            stackrow5.Visibility = Visibility.Hidden;
                            stackrow6.Visibility = Visibility.Hidden;
                            stackrow7.Visibility = Visibility.Hidden;
                            stackrow8.Visibility = Visibility.Hidden;
                            stackrow9.Visibility = Visibility.Hidden;
                            stackrow10.Visibility = Visibility.Hidden;
                            final_amout_text.Text = "";
                            final_amout.Text = "";
                            with_tax.IsChecked = true;
                        }
                    }
                }
            }
            catch (Exception) { }
        }
        //private void Split1_Checked(object sender, RoutedEventArgs e)
        //{
        //    if (Room_no.Text == "")
        //    {
        //    }
        //    else
        //    {
        //        //decimal ttlamt = Convert.ToDecimal(S.TOTAL);
        //        //txtttlamt.Text = Convert.ToString(Math.Round(ttlamt, 2, MidpointRounding.AwayFromZero));
        //        money = Convert.ToDouble(amount.Text);
        //        total_cost = money + taxamount;
        //        amount1.Text = Convert.ToString(Math.Round(money, 2, MidpointRounding.AwayFromZero));
        //        tax1.Text = Convert.ToString(Math.Round(taxamount, 2, MidpointRounding.AwayFromZero));
        //        total1.Text = Convert.ToString(Math.Round(total_cost, 2, MidpointRounding.AwayFromZero));
        //        stackrow2.Visibility = Visibility.Hidden;
        //        stackrow3.Visibility = Visibility.Hidden;
        //        stackrow4.Visibility = Visibility.Hidden;
        //        stackrow5.Visibility = Visibility.Hidden;
        //        stackrow6.Visibility = Visibility.Hidden;
        //        stackrow7.Visibility = Visibility.Hidden;
        //        stackrow8.Visibility = Visibility.Hidden;
        //        stackrow9.Visibility = Visibility.Hidden;
        //        stackrow10.Visibility = Visibility.Hidden;
        //    }
        //}
        private void Split2_Checked(object sender, RoutedEventArgs e)
        {
            No_of_bills = 2;
            if (Room_no.Text == "")
            {
            }
            else
            {
                money = Convert.ToDouble(amount.Text);
                splitedmoney = money / 2;
                if (taxtype == 1)
                {
                    splitedtax = taxamount / 2;
                    finalcostwithtax = (splitedtax * 2) + (splitedmoney * 2);
                }
                else
                {
                    splitedtax = 0;
                    finalcostwithtax = (splitedmoney * 2);
                }
                total_cost = splitedmoney + splitedtax;
                splitedDataassigning();
                final_amout.Text = Convert.ToString(Math.Round(finalcostwithtax, 2, MidpointRounding.AwayFromZero));
                final_amout_text.Text = "Total amount for 2 Bills with Tax :";
                stackrow1.Visibility = Visibility.Visible;
                stackrow2.Visibility = Visibility.Visible;
                stackrow3.Visibility = Visibility.Hidden;
                stackrow4.Visibility = Visibility.Hidden;
                stackrow5.Visibility = Visibility.Hidden;
                stackrow6.Visibility = Visibility.Hidden;
                stackrow7.Visibility = Visibility.Hidden;
                stackrow8.Visibility = Visibility.Hidden;
                stackrow9.Visibility = Visibility.Hidden;
                stackrow10.Visibility = Visibility.Hidden;
            }
        }
        private void Split3_Checked(object sender, RoutedEventArgs e)
        {
            No_of_bills = 3;
            if (Room_no.Text == "")
            {
            }
            else
            {
                money = Convert.ToDouble(amount.Text);
                splitedmoney = money / 3;
                if (taxtype == 1)
                {
                    splitedtax = taxamount / 3;
                    finalcostwithtax = (splitedtax * 3) + (splitedmoney * 3);
                }
                else
                {
                    splitedtax = 0;
                    finalcostwithtax = (splitedmoney * 3);
                }
                total_cost = splitedmoney + splitedtax;
                splitedDataassigning();
                final_amout.Text = Convert.ToString(Math.Round(finalcostwithtax, 2, MidpointRounding.AwayFromZero));
                final_amout_text.Text = "Total amount for 3 Bills with Tax :";
                stackrow1.Visibility = Visibility.Visible;
                stackrow2.Visibility = Visibility.Visible;
                stackrow3.Visibility = Visibility.Visible;
                stackrow4.Visibility = Visibility.Hidden;
                stackrow5.Visibility = Visibility.Hidden;
                stackrow6.Visibility = Visibility.Hidden;
                stackrow7.Visibility = Visibility.Hidden;
                stackrow8.Visibility = Visibility.Hidden;
                stackrow9.Visibility = Visibility.Hidden;
                stackrow10.Visibility = Visibility.Hidden;
            }
        }
        private void Split4_Checked(object sender, RoutedEventArgs e)
        {
            No_of_bills = 4;
            if (Room_no.Text == "")
            {
            }
            else
            {
                money = Convert.ToDouble(amount.Text);
                splitedmoney = money / 4;
                if (taxtype == 1)
                {
                    splitedtax = taxamount / 4;
                    finalcostwithtax = (splitedtax * 4) + (splitedmoney * 4);
                }
                else
                {
                    splitedtax = 0;
                    finalcostwithtax = (splitedmoney * 4);
                }
                total_cost = splitedmoney + splitedtax;
                splitedDataassigning();
                final_amout.Text = Convert.ToString(Math.Round(finalcostwithtax, 2, MidpointRounding.AwayFromZero));
                final_amout_text.Text = "Total amount for 4 Bills with Tax :";
                stackrow1.Visibility = Visibility.Visible;
                stackrow2.Visibility = Visibility.Visible;
                stackrow3.Visibility = Visibility.Visible;
                stackrow4.Visibility = Visibility.Visible;
                stackrow5.Visibility = Visibility.Hidden;
                stackrow6.Visibility = Visibility.Hidden;
                stackrow7.Visibility = Visibility.Hidden;
                stackrow8.Visibility = Visibility.Hidden;
                stackrow9.Visibility = Visibility.Hidden;
                stackrow10.Visibility = Visibility.Hidden;
            }
        }
        private void Split5_Checked(object sender, RoutedEventArgs e)
        {
            No_of_bills = 5;
            if (Room_no.Text == "")
            {
            }
            else
            {
                money = Convert.ToDouble(amount.Text);
                splitedmoney = money / 5;
                if (taxtype == 1)
                {
                    splitedtax = taxamount / 5;
                    finalcostwithtax = (splitedtax * 5) + (splitedmoney * 5);
                }
                else
                {
                    splitedtax = 0;
                    finalcostwithtax = (splitedmoney * 5);
                }
                total_cost = splitedmoney + splitedtax;
                splitedDataassigning();
                final_amout.Text = Convert.ToString(Math.Round(finalcostwithtax, 2, MidpointRounding.AwayFromZero));
                final_amout_text.Text = "Total amount for 5 Bills with Tax :";
                stackrow1.Visibility = Visibility.Visible;
                stackrow2.Visibility = Visibility.Visible;
                stackrow3.Visibility = Visibility.Visible;
                stackrow4.Visibility = Visibility.Visible;
                stackrow5.Visibility = Visibility.Visible;
                stackrow6.Visibility = Visibility.Hidden;
                stackrow7.Visibility = Visibility.Hidden;
                stackrow8.Visibility = Visibility.Hidden;
                stackrow9.Visibility = Visibility.Hidden;
                stackrow10.Visibility = Visibility.Hidden;
            }
        }
        private void Split6_Checked(object sender, RoutedEventArgs e)
        {
            No_of_bills = 6;
            if (Room_no.Text == "")
            {
            }
            else
            {
                money = Convert.ToDouble(amount.Text);
                splitedmoney = money / 6;
                finalcostwithtax = (splitedtax * 6) + (splitedmoney * 6);
                if (taxtype == 1)
                {
                    splitedtax = taxamount / 6;
                    finalcostwithtax = (splitedtax * 6) + (splitedmoney * 6);
                }
                else
                {
                    splitedtax = 0;
                    finalcostwithtax = (splitedmoney * 6);
                }
                total_cost = splitedmoney + splitedtax;
                splitedDataassigning();
                final_amout.Text = Convert.ToString(Math.Round(finalcostwithtax, 2, MidpointRounding.AwayFromZero));
                final_amout_text.Text = "Total amount for 6 Bills with Tax :";
                stackrow1.Visibility = Visibility.Visible;
                stackrow2.Visibility = Visibility.Visible;
                stackrow3.Visibility = Visibility.Visible;
                stackrow4.Visibility = Visibility.Visible;
                stackrow5.Visibility = Visibility.Visible;
                stackrow6.Visibility = Visibility.Visible;
                stackrow7.Visibility = Visibility.Hidden;
                stackrow8.Visibility = Visibility.Hidden;
                stackrow9.Visibility = Visibility.Hidden;
                stackrow10.Visibility = Visibility.Hidden;
            }
        }
        private void Split7_Checked(object sender, RoutedEventArgs e)
        {
            No_of_bills = 7;
            if (Room_no.Text == "")
            {
            }
            else
            {
                money = Convert.ToDouble(amount.Text);
                splitedmoney = money / 7;
                if (taxtype == 1)
                {
                    splitedtax = taxamount / 7;
                    finalcostwithtax = (splitedtax * 7) + (splitedmoney * 7);
                }
                else
                {
                    splitedtax = 0;
                    finalcostwithtax = (splitedmoney * 7);
                }
                total_cost = splitedmoney + splitedtax;
                splitedDataassigning();
                final_amout.Text = Convert.ToString(Math.Round(finalcostwithtax, 2, MidpointRounding.AwayFromZero));
                final_amout_text.Text = "Total amount for 7 Bills with Tax :";
                stackrow1.Visibility = Visibility.Visible;
                stackrow2.Visibility = Visibility.Visible;
                stackrow3.Visibility = Visibility.Visible;
                stackrow4.Visibility = Visibility.Visible;
                stackrow5.Visibility = Visibility.Visible;
                stackrow6.Visibility = Visibility.Visible;
                stackrow7.Visibility = Visibility.Visible;
                stackrow8.Visibility = Visibility.Hidden;
                stackrow9.Visibility = Visibility.Hidden;
                stackrow10.Visibility = Visibility.Hidden;
            }
        }
        private void Split8_Checked(object sender, RoutedEventArgs e)
        {
            No_of_bills = 8;
            if (Room_no.Text == "")
            {
            }
            else
            {
                money = Convert.ToDouble(amount.Text);
                splitedmoney = money / 8;
                if (taxtype == 1)
                {
                    splitedtax = taxamount / 8;
                    finalcostwithtax = (splitedtax * 8) + (splitedmoney * 8);
                }
                else
                {
                    splitedtax = 0;
                    finalcostwithtax = (splitedmoney * 8);
                }
                total_cost = splitedmoney + splitedtax;
                splitedDataassigning();
                final_amout.Text = Convert.ToString(Math.Round(finalcostwithtax, 2, MidpointRounding.AwayFromZero));
                final_amout_text.Text = "Total amount for 8 Bills with Tax :";
                stackrow1.Visibility = Visibility.Visible;
                stackrow2.Visibility = Visibility.Visible;
                stackrow3.Visibility = Visibility.Visible;
                stackrow4.Visibility = Visibility.Visible;
                stackrow5.Visibility = Visibility.Visible;
                stackrow6.Visibility = Visibility.Visible;
                stackrow7.Visibility = Visibility.Visible;
                stackrow8.Visibility = Visibility.Visible;
                stackrow9.Visibility = Visibility.Hidden;
                stackrow10.Visibility = Visibility.Hidden;
            }
        }
        private void Split9_Checked(object sender, RoutedEventArgs e)
        {
            No_of_bills = 9;
            if (Room_no.Text == "")
            {
            }
            else
            {
                money = Convert.ToDouble(amount.Text);
                splitedmoney = money / 9;
                if (taxtype == 1)
                {
                    splitedtax = taxamount / 9;
                    finalcostwithtax = (splitedtax * 9) + (splitedmoney * 9);
                }
                else
                {
                    splitedtax = 0;
                    finalcostwithtax = (splitedmoney * 9);
                }
                total_cost = splitedmoney + splitedtax;
                splitedDataassigning();
                final_amout.Text = Convert.ToString(Math.Round(finalcostwithtax, 2, MidpointRounding.AwayFromZero));
                final_amout_text.Text = "Total amount for 9 Bills with Tax :";
                stackrow1.Visibility = Visibility.Visible;
                stackrow2.Visibility = Visibility.Visible;
                stackrow3.Visibility = Visibility.Visible;
                stackrow4.Visibility = Visibility.Visible;
                stackrow5.Visibility = Visibility.Visible;
                stackrow6.Visibility = Visibility.Visible;
                stackrow7.Visibility = Visibility.Visible;
                stackrow8.Visibility = Visibility.Visible;
                stackrow9.Visibility = Visibility.Visible;
                stackrow10.Visibility = Visibility.Hidden;
            }
        }
        private void Split10_Checked(object sender, RoutedEventArgs e)
        {
            No_of_bills = 10;
            if (Room_no.Text == "")
            {
            }
            else
            {
                money = Convert.ToDouble(amount.Text);
                splitedmoney = money / 10;
                if (taxtype == 1)
                {
                    splitedtax = taxamount / 10;
                    finalcostwithtax = (splitedtax * 10) + (splitedmoney * 10);
                }
                else
                {
                    splitedtax = 0;
                    finalcostwithtax = (splitedmoney * 10);
                }
                total_cost = splitedmoney + splitedtax;
                splitedDataassigning();
                final_amout.Text = Convert.ToString(Math.Round(finalcostwithtax, 2, MidpointRounding.AwayFromZero));
                final_amout_text.Text = "Total amount for 10 Bills with Tax :";
                stackrow1.Visibility = Visibility.Visible;
                stackrow2.Visibility = Visibility.Visible;
                stackrow3.Visibility = Visibility.Visible;
                stackrow4.Visibility = Visibility.Visible;
                stackrow5.Visibility = Visibility.Visible;
                stackrow6.Visibility = Visibility.Visible;
                stackrow7.Visibility = Visibility.Visible;
                stackrow8.Visibility = Visibility.Visible;
                stackrow9.Visibility = Visibility.Visible;
                stackrow10.Visibility = Visibility.Visible;
            }
        }
        private void with_tax_Checked(object sender, RoutedEventArgs e)
        {
            taxtype = 1;
            if (Room_no.Text == "")
            {
            }
            else
            {
                money = Convert.ToDouble(amount.Text);
                if (Split2.IsChecked == true)
                {
                    splitedmoney = money / 2;
                    splitedtax = taxamount / 2;
                    total_cost = splitedmoney + splitedtax;
                    splitedDataassigning();
                    finalcostwithtax = (splitedtax * 2) + (splitedmoney * 2);
                    final_amout_text.Text = "Total amount for 2 Bills with Tax :";
                    final_amout.Text = Convert.ToString(Math.Round(finalcostwithtax, 2, MidpointRounding.AwayFromZero));
                }
                else if(Split3.IsChecked == true)
                {
                    splitedmoney = money / 3;
                    splitedtax = taxamount / 3;
                    total_cost = splitedmoney + splitedtax;
                    splitedDataassigning();
                    finalcostwithtax = (splitedtax * 3) + (splitedmoney * 3);
                    final_amout_text.Text = "Total amount for 3 Bills with Tax :";
                    final_amout.Text = Convert.ToString(Math.Round(finalcostwithtax, 2, MidpointRounding.AwayFromZero));
                }
                else if (Split4.IsChecked == true)
                {
                    splitedmoney = money / 4;
                    splitedtax = taxamount / 4;
                    total_cost = splitedmoney + splitedtax;
                    splitedDataassigning();
                    finalcostwithtax = (splitedtax * 4) + (splitedmoney * 4);
                    final_amout_text.Text = "Total amount for 4 Bills with Tax :";
                    final_amout.Text = Convert.ToString(Math.Round(finalcostwithtax, 2, MidpointRounding.AwayFromZero));
                }
                else if (Split5.IsChecked == true)
                {
                    splitedmoney = money / 5;
                    splitedtax = taxamount / 5;
                    total_cost = splitedmoney + splitedtax;
                    splitedDataassigning();
                    finalcostwithtax = (splitedtax * 5) + (splitedmoney * 5);
                    final_amout_text.Text = "Total amount for 5 Bills with Tax :";
                    final_amout.Text = Convert.ToString(Math.Round(finalcostwithtax, 2, MidpointRounding.AwayFromZero));
                }
                else if (Split6.IsChecked == true)
                {
                    splitedmoney = money / 6;
                    splitedtax = taxamount / 6;
                    total_cost = splitedmoney + splitedtax;
                    splitedDataassigning();
                    finalcostwithtax = (splitedtax * 6) + (splitedmoney * 6);
                    final_amout_text.Text = "Total amount for 6 Bills with Tax :";
                    final_amout.Text = Convert.ToString(Math.Round(finalcostwithtax, 2, MidpointRounding.AwayFromZero));
                }
                else if (Split7.IsChecked == true)
                {
                    splitedmoney = money / 7;
                    splitedtax = taxamount / 7;
                    total_cost = splitedmoney + splitedtax;
                    splitedDataassigning();
                    finalcostwithtax = (splitedtax * 7) + (splitedmoney * 7);
                    final_amout_text.Text = "Total amount for 7 Bills with Tax :";
                    final_amout.Text = Convert.ToString(Math.Round(finalcostwithtax, 2, MidpointRounding.AwayFromZero));
                }
                else if (Split8.IsChecked == true)
                {
                    splitedmoney = money / 8;
                    splitedtax = taxamount / 8;
                    total_cost = splitedmoney + splitedtax;
                    splitedDataassigning();
                    finalcostwithtax = (splitedtax * 8) + (splitedmoney * 8);
                    final_amout_text.Text = "Total amount for 8 Bills with Tax :";
                    final_amout.Text = Convert.ToString(Math.Round(finalcostwithtax, 2, MidpointRounding.AwayFromZero));
                }
                else if (Split9.IsChecked == true)
                {
                    splitedmoney = money / 9;
                    splitedtax = taxamount / 9;
                    total_cost = splitedmoney + splitedtax;
                    splitedDataassigning();
                    finalcostwithtax = (splitedtax * 9) + (splitedmoney * 9);
                    final_amout_text.Text = "Total amount for 9 Bills with Tax :";
                    final_amout.Text = Convert.ToString(Math.Round(finalcostwithtax, 2, MidpointRounding.AwayFromZero));
                }
                else if (Split10.IsChecked == true)
                {
                    splitedmoney = money / 10;
                    splitedtax = taxamount / 10;
                    total_cost = splitedmoney + splitedtax;
                    splitedDataassigning();
                    finalcostwithtax = (splitedtax * 10) + (splitedmoney * 10);
                    final_amout_text.Text = "Total amount for 10 Bills with Tax :";
                    final_amout.Text = Convert.ToString(Math.Round(finalcostwithtax, 2, MidpointRounding.AwayFromZero));
                }
            }
        }
        private void without_tax_Checked(object sender, RoutedEventArgs e)
        {
            taxtype = 0;
            if (Room_no.Text == "")
            {
            }
            else
            {
                money = Convert.ToDouble(amount.Text);
                final_amout.Text = "";
                splitedtax = 0;
                if (Split2.IsChecked == true)
                {
                    splitedmoney = money / 2;
                    finalcostwithtax = (splitedmoney * 2);
                    final_amout_text.Text = "Total amount for 2 Bills with out Tax :";
                    final_amout.Text = Convert.ToString(Math.Round(finalcostwithtax, 2, MidpointRounding.AwayFromZero));
                }
                else if (Split3.IsChecked == true)
                {
                    splitedmoney = money / 3;
                    finalcostwithtax = (splitedmoney * 3);
                    final_amout_text.Text = "Total amount for 3 Bills with out Tax :";
                    final_amout.Text = Convert.ToString(Math.Round(finalcostwithtax, 2, MidpointRounding.AwayFromZero));
                }
                else if (Split4.IsChecked == true)
                {
                    splitedmoney = money / 4;
                    finalcostwithtax = (splitedmoney * 4);
                    final_amout_text.Text = "Total amount for 4 Bills with out Tax :";
                    final_amout.Text = Convert.ToString(Math.Round(finalcostwithtax, 2, MidpointRounding.AwayFromZero));
                }
                else if (Split5.IsChecked == true)
                {
                    splitedmoney = money / 5;
                    finalcostwithtax = (splitedmoney * 5);
                    final_amout_text.Text = "Total amount for 5 Bills with out Tax :";
                    final_amout.Text = Convert.ToString(Math.Round(finalcostwithtax, 2, MidpointRounding.AwayFromZero));
                }
                else if (Split6.IsChecked == true)
                {
                    splitedmoney = money / 6;
                    finalcostwithtax = (splitedmoney * 6);
                    final_amout_text.Text = "Total amount for 6 Bills with out Tax :";
                    final_amout.Text = Convert.ToString(Math.Round(finalcostwithtax, 2, MidpointRounding.AwayFromZero));
                }
                else if (Split7.IsChecked == true)
                {
                    splitedmoney = money / 7;
                    finalcostwithtax = (splitedmoney * 7);
                    final_amout_text.Text = "Total amount for 7 Bills with out Tax :";
                    final_amout.Text = Convert.ToString(Math.Round(finalcostwithtax, 2, MidpointRounding.AwayFromZero));
                }
                else if (Split8.IsChecked == true)
                {
                    splitedmoney = money / 8;
                    finalcostwithtax = (splitedmoney * 8);
                    final_amout_text.Text = "Total amount for 8 Bills with out Tax :";
                    final_amout.Text = Convert.ToString(Math.Round(finalcostwithtax, 2, MidpointRounding.AwayFromZero));
                }
                else if (Split9.IsChecked == true)
                {
                    splitedmoney = money / 9;
                    finalcostwithtax = (splitedmoney * 9);
                    final_amout_text.Text = "Total amount for 9 Bills with out Tax :";
                    final_amout.Text = Convert.ToString(Math.Round(finalcostwithtax, 2, MidpointRounding.AwayFromZero));
                }
                else if (Split10.IsChecked == true)
                {
                    splitedmoney = money / 10;
                    finalcostwithtax = (splitedmoney * 10);
                    final_amout_text.Text = "Total amount for 10 Bills with out Tax :";
                    final_amout.Text = Convert.ToString(Math.Round(finalcostwithtax, 2, MidpointRounding.AwayFromZero));
                }
                total_cost = splitedmoney + splitedtax;
                splitedDataassigning();
            }
        }
        public void Clear()
        {
            Room_no.Text = "";
            first_name.Text = "";
            mobile_no.Text = "";
            amount.Text = "";
            taxamount = 0.00;
            money = 0;
            splitedmoney = 0;
            splitedtax = 0;
            total_cost = 0;
            No_of_bills = 0;
            stackrow1.Visibility = Visibility.Hidden;
            stackrow2.Visibility = Visibility.Hidden;
            stackrow2.Visibility = Visibility.Hidden;
            stackrow3.Visibility = Visibility.Hidden;
            stackrow4.Visibility = Visibility.Hidden;
            stackrow5.Visibility = Visibility.Hidden;
            stackrow6.Visibility = Visibility.Hidden;
            stackrow7.Visibility = Visibility.Hidden;
            stackrow8.Visibility = Visibility.Hidden;
            stackrow9.Visibility = Visibility.Hidden;
            stackrow10.Visibility = Visibility.Hidden;
        }
        public void splitedDataassigning()
        {
            amount1.Text = Convert.ToString(Math.Round(splitedmoney, 2, MidpointRounding.AwayFromZero));
            amount2.Text = Convert.ToString(Math.Round(splitedmoney, 2, MidpointRounding.AwayFromZero));
            amount3.Text = Convert.ToString(Math.Round(splitedmoney, 2, MidpointRounding.AwayFromZero));
            amount4.Text = Convert.ToString(Math.Round(splitedmoney, 2, MidpointRounding.AwayFromZero));
            amount5.Text = Convert.ToString(Math.Round(splitedmoney, 2, MidpointRounding.AwayFromZero));
            amount6.Text = Convert.ToString(Math.Round(splitedmoney, 2, MidpointRounding.AwayFromZero));
            amount7.Text = Convert.ToString(Math.Round(splitedmoney, 2, MidpointRounding.AwayFromZero));
            amount8.Text = Convert.ToString(Math.Round(splitedmoney, 2, MidpointRounding.AwayFromZero));
            amount9.Text = Convert.ToString(Math.Round(splitedmoney, 2, MidpointRounding.AwayFromZero));
            amount10.Text = Convert.ToString(Math.Round(splitedmoney, 2, MidpointRounding.AwayFromZero));
            tax1.Text = Convert.ToString(Math.Round(splitedtax, 2, MidpointRounding.AwayFromZero));
            tax2.Text = Convert.ToString(Math.Round(splitedtax, 2, MidpointRounding.AwayFromZero));
            tax3.Text = Convert.ToString(Math.Round(splitedtax, 2, MidpointRounding.AwayFromZero));
            tax4.Text = Convert.ToString(Math.Round(splitedtax, 2, MidpointRounding.AwayFromZero));
            tax5.Text = Convert.ToString(Math.Round(splitedtax, 2, MidpointRounding.AwayFromZero));
            tax6.Text = Convert.ToString(Math.Round(splitedtax, 2, MidpointRounding.AwayFromZero));
            tax7.Text = Convert.ToString(Math.Round(splitedtax, 2, MidpointRounding.AwayFromZero));
            tax8.Text = Convert.ToString(Math.Round(splitedtax, 2, MidpointRounding.AwayFromZero));
            tax9.Text = Convert.ToString(Math.Round(splitedtax, 2, MidpointRounding.AwayFromZero));
            tax10.Text = Convert.ToString(Math.Round(splitedtax, 2, MidpointRounding.AwayFromZero));
            total1.Text = Convert.ToString(Math.Round(total_cost, 2, MidpointRounding.AwayFromZero));
            total2.Text = Convert.ToString(Math.Round(total_cost, 2, MidpointRounding.AwayFromZero));
            total3.Text = Convert.ToString(Math.Round(total_cost, 2, MidpointRounding.AwayFromZero));
            total4.Text = Convert.ToString(Math.Round(total_cost, 2, MidpointRounding.AwayFromZero));
            total5.Text = Convert.ToString(Math.Round(total_cost, 2, MidpointRounding.AwayFromZero));
            total6.Text = Convert.ToString(Math.Round(total_cost, 2, MidpointRounding.AwayFromZero));
            total7.Text = Convert.ToString(Math.Round(total_cost, 2, MidpointRounding.AwayFromZero));
            total8.Text = Convert.ToString(Math.Round(total_cost, 2, MidpointRounding.AwayFromZero));
            total9.Text = Convert.ToString(Math.Round(total_cost, 2, MidpointRounding.AwayFromZero));
            total10.Text = Convert.ToString(Math.Round(total_cost, 2, MidpointRounding.AwayFromZero));
        }
    }
}
