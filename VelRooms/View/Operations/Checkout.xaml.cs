using HMS.mainwindowpages;
using HMS.Model;
using HMS.Model.Operations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using HMS.View.Masters;
using CrystalDecisions.CrystalReports.Engine;

namespace HMS.View.Operations
{
    /// <summary>
    /// Interaction logic for Checkout.xaml
    /// </summary>
    public partial class Checkout : Page
    {
        Checkout1 co = new Checkout1();
        advance1 AD = new advance1();
        public DataTable dt = new DataTable();
        public DataTable pd_grid = new DataTable();
        public DataTable na_grid = new DataTable();
        public DataTable dt1 = new DataTable();
        public DataTable d1 = new DataTable();
        public DataTable d2, d3, d4 = new DataTable();
        public DataTable print = new DataTable();
        public decimal amount = 0, radv , rref;
        public static int ref34 = 0, adv34 = 0;

        List<String> li = new List<string>();
        //public int abc = 3;

        public decimal rpercentage = 0, rchargedtarrif = 0, ramount = 0, radvanceamt = 0, rcharges, rtotalpendingamnt = 0, finalcharged;
        public decimal tarrif = 0, advance = 0, discount = 0, cgst = 0, sgst = 0, charges = 0, tot = 0, tot1 = 0, stax = 0, ctax = 0, subtotal = 0;
        public string arraival;
        public float g;

        private void btnviewbill_Click(object sender, RoutedEventArgs e)
        {
            //************** For Report ****************
            //ReportDocument rrr = new ReportDocument();
            //rrr.Load("../../Checkoutbilling.rpt");
            //Checkout1 co1 = new Checkout1();
            //DataTable hotel2 = co1.GET_HOTELADDRESS();
            //rrr.Subreports[0].SetDataSource(hotel2);
            //rrr.SetDataSource(Checkout1.dt);

            //var openFileDialog = new Microsoft.Win32.OpenFileDialog
            //{
            //    DefaultExt = ".pdf",
            //    Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*"
            //};
            //var fileOpenResult = openFileDialog.ShowDialog();
            //if (fileOpenResult != true)
            //{
            //    return;
            //}
        }
        public int id;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Refresh();
            pop1.IsOpen = false;
        }
        private void btnprovbill_Click(object sender, RoutedEventArgs e)
        {
            Checkout1 co = new Checkout1();
            co.ROOM_NO = roomno;
            d1 = co.guestinfo();
            d2 = co.ROOMCATEGORY();
            d3 = co.checkoutdetails();
            d4 = co.company_contact();
            id = co.get_checkout_id();
            // ********** For Report *******************
            // ReportDocument rrr = new ReportDocument();
            //rrr.Load("../../Checkoutreport.rpt");
            // Checkout1 co1 = new Checkout1();
            // DataTable hotel2 = co1.GET_HOTELADDRESS();
            //rrr.Subreports[0].SetDataSource(hotel2);
            //rrr.SetDataSource(Checkout1.dt);
            //rrr.PrintToPrinter(1, false, 0, 0);
        }
        public string provibill = null;
        private void btnsplitbill_Click(object sender, RoutedEventArgs e)
        {
            SplitBill sb = new SplitBill();
            this.NavigationService.Navigate(sb);
        }
        private void btncharges_Click(object sender, RoutedEventArgs e)
        {
            PostChargesxaml pc = new PostChargesxaml();
            this.NavigationService.Navigate(pc);
        }
        public DataTable dcheckout;
        public decimal NA_Tariff, NA_Tax, NA_CSGST,NA_Charges,NA_Advance;
        private void grdpaymentdetails_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            na_grid.Rows.Clear();
            int index = grdpaymentdetails.SelectedIndex;
            if (co.ROOM_NO == "" || co.ROOM_NO == null)
            {
                MessageBox.Show("Please select the Room No");
            }
            else
            {
                Roomno.Text = co.ROOM_NO;
                DataTable dt = co.room_category();
                co.ROOM_CATEGORY = dt.Rows[0]["ROOM_CATEGORY"].ToString();
                roomcategory.Text = co.ROOM_CATEGORY;
                DataTable Checking_RC = co.CheckingIfRoomChanged();
                if(Checking_RC.Rows.Count > 0)
                {
                    transfered_txt.Visibility = Visibility.Visible;
                    transfered_txt.Text = "Transfered from " + Checking_RC.Rows[0]["MAIN_ROOM"] + " Room";
                }
                else
                {
                    transfered_txt.Visibility = Visibility.Hidden;
                }
                DataTable NA_Details = co.Room_NA_Details();
                if (NA_Details.Rows.Count > 0)
                {
                    //na_grid
                    for (int i = 0; i < NA_Details.Rows.Count; i++)
                    {
                        DataRow na = na_grid.NewRow();
                        na["Date"] = Convert.ToDateTime(NA_Details.Rows[i]["INSERT_DATE"]).ToShortDateString() + " " + NA_Details.Rows[i]["INSERT_TIME"].ToString();
                        if (NA_Details.Rows[i]["ROOM_TARRIF"].ToString() == null || NA_Details.Rows[i]["ROOM_TARRIF"].ToString() == "")
                        {
                            NA_Tariff = 0;
                        }
                        else
                        {
                            NA_Tariff = Convert.ToDecimal(NA_Details.Rows[i]["ROOM_TARRIF"]);
                        }
                        if (NA_Details.Rows[i]["GST"].ToString() == null || NA_Details.Rows[i]["GST"].ToString() == "")
                        {
                            NA_Tax = 0;
                        }
                        else
                        {
                            NA_Tax = Convert.ToDecimal(NA_Details.Rows[i]["GST"]);
                        }
                        if (i == (NA_Details.Rows.Count - 1))
                        {
                            co.From_dt = Convert.ToDateTime(NA_Details.Rows[i]["INSERT_DATE"]);
                            co.To_dt = Convert.ToDateTime(NA_Details.Rows[i]["INSERT_DATE"]).AddDays(1);
                            co.GetAdvance();
                            co.GetCharges();
                            NA_Advance = co.NA_Advance;
                            NA_Charges = co.NA_Charges;
                        }
                        else
                        {
                            if (NA_Details.Rows[i]["ADVANCE"].ToString() == null || NA_Details.Rows[i]["ADVANCE"].ToString() == "")
                            {
                                NA_Advance = 0;
                            }
                            else
                            {
                                NA_Advance = Convert.ToDecimal(NA_Details.Rows[i]["ADVANCE"]);
                            }
                            if (NA_Details.Rows[i]["CHARGES"].ToString() == null || NA_Details.Rows[i]["CHARGES"].ToString() == "")
                            {
                                NA_Charges = 0;
                            }
                            else
                            {
                                NA_Charges = Convert.ToDecimal(NA_Details.Rows[i]["CHARGES"]);
                            }
                        }
                        NA_CSGST = (NA_Tariff * NA_Tax) / 100;
                        na["Tariff"] = Math.Round(NA_Tariff, 2, MidpointRounding.AwayFromZero);
                        na["CGST"] = Math.Round(NA_CSGST / 2, 2, MidpointRounding.AwayFromZero);
                        na["SGST"] = Math.Round(NA_CSGST / 2, 2, MidpointRounding.AwayFromZero);
                        na["Advance"] = Math.Round(NA_Advance, 2, MidpointRounding.AwayFromZero);
                        na["PostCharges"] = Math.Round(NA_Charges, 2, MidpointRounding.AwayFromZero);
                        na_grid.Rows.Add(na);
                    }
                    checkoutgrid.ItemsSource = na_grid.DefaultView;
                }
                pop1.IsOpen = true;
            }
        }
        private void btnsettlebill_Click(object sender, RoutedEventArgs e)
        {
            settle st = new settle();
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(st);
        }
        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("mainwindowpages/home.xaml", UriKind.RelativeOrAbsolute));
        }
        public static string rrr;//stotalpendingamount
        private void Btnadv_Click(object sender, RoutedEventArgs e)
        {
            //adv34 = 1;
            //Advance a = new Advance();
            //this.NavigationService.Navigate(a);
        }
        private void Btnref_Click(object sender, RoutedEventArgs e)
        {
            ref34 = 1;
            Refund d = new Refund();
            this.NavigationService.Navigate(d);
        }
        public static decimal Ch_CSGST, Ch_Tarrif, Ch_Total, Ch_Discount, Ch_Advance, Ch_Charges, Ch_Refunds, Ch_PendingAmount, PrintType;
        private void yes_Click(object sender, RoutedEventArgs e)
        {
            co.ROOM_NO = "";
            try
            {
                popup.IsOpen = false;
                co.ROOM_NO = roomno;
                if(co.ROOM_NO == "" || co.ROOM_NO == null)
                {
                    MessageBox.Show("Please select the room and try Again.!");
                    this.NavigationService.Refresh();
                }
                else
                {
                    DataTable ch_p = co.check_prints();
                    if (ch_p.Rows.Count == 0)
                    {
                        Ch_Total = (Ch_CSGST * 2) + Ch_Tarrif + Ch_Charges + RC_TransferAmount;
                        if (Ch_PendingAmount < 0)
                        {
                            popamount.IsOpen = true;
                            pamount.Text = Ch_PendingAmount.ToString();
                        }
                        else
                        {
                            popamount.IsOpen = false;
                            co.Prints_insert();
                            co.PrintStatus_Insert();
                            co.color();
                            PrintType = 0;
                            ReportDocument r = new ReportDocument();
                            DataTable hot = report();
                            r.Load("../../Checkoutbilling.rpt");
                            DataTable table = hotelprint();
                            r.Load("../../CheckoutbillReport1.rpt");
                            r.SetDataSource(table);
                            r.Subreports[0].SetDataSource(hot);
                            r.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                            r.PrintToPrinter(1, false, 0, 0);
                            r.Refresh();
                            PrintType = 1;
                            ReportDocument r2 = new ReportDocument();
                            DataTable hot2 = report();
                            r2.Load("../../Checkoutbilling.rpt");
                            DataTable table2 = hotelprint();
                            r2.Load("../../CheckoutbillReport1.rpt");
                            r2.SetDataSource(table2);
                            r2.Subreports[0].SetDataSource(hot2);
                            r2.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                            r2.PrintToPrinter(1, false, 0, 0);
                            r2.Refresh();
                            this.NavigationService.Refresh();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Settle the Room And Try again.!");
                    }
                }
            }
            catch (Exception) { }
        }
        public static decimal pcharge;
        private void no_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                popup.IsOpen = false;
                ReportDocument r = new ReportDocument();
                co.ROOM_NO = roomno;
                if (co.ROOM_NO == "" || co.ROOM_NO == null)
                {
                    MessageBox.Show("Please select the room and try Again.!");
                    this.NavigationService.Refresh();
                }
                else
                {
                    DataTable ch_p = co.check_prints();
                    if (ch_p.Rows.Count == 0)
                    {
                        if (Ch_PendingAmount < 0)
                        {
                            popamount.IsOpen = true;
                            pamount.Text = Ch_PendingAmount.ToString();
                        }
                        else
                        {
                            Ch_Total = (Ch_CSGST * 2) + Ch_Tarrif + Ch_Charges + RC_TransferAmount;
                            co.Prints_insert();
                            co.PrintStatus_Insert();
                            co.color();
                            this.NavigationService.Refresh();
                        }
                    }
                    else
                    {
                        popup.IsOpen = false;
                        MessageBox.Show("Please Settle the Room And Try again.!");
                    }
                }
            }
            catch (Exception) { }
        }
        public string discountamount, chargedtarrif, advanceamount, totalpendingamount, totalcharges, Cgst;
        public static string roomno;
        public int gst;
        public decimal totalcgst, totalsgst;
        public DataTable DT;
        public Checkout()
        {
            InitializeComponent();
            pd_grid.Columns.Add("Roomno", typeof(string));
            pd_grid.Columns.Add("Tarrif", typeof(string));
            pd_grid.Columns.Add("Charges", typeof(string));
            pd_grid.Columns.Add("Cgst", typeof(string));
            pd_grid.Columns.Add("Sgst", typeof(string));
            pd_grid.Columns.Add("Advance", typeof(string));
            pd_grid.Columns.Add("Discount", typeof(string));
            pd_grid.Columns.Add("Refund", typeof(string));
            pd_grid.Columns.Add("Transfer", typeof(string)); 
            pd_grid.Columns.Add("Pending_Amount", typeof(string));

            na_grid.Columns.Add("Date", typeof(string));
            na_grid.Columns.Add("Tariff", typeof(decimal));
            na_grid.Columns.Add("CGST", typeof(decimal));
            na_grid.Columns.Add("SGST", typeof(decimal));
            na_grid.Columns.Add("Advance", typeof(decimal));
            na_grid.Columns.Add("PostCharges", typeof(decimal));
            reports.a = 3;
            string s = null;
            DataTable dt = co.GET_ROOMCATEGORY();
            int row = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                s = dt.Rows[i]["ROOM_CATEGORY"].ToString();
                if (li.Contains(s)) { }
                else
                {
                    li.Add(s);
                    int NO_OF_ROOMS = 0;
                    Label LB = new Label();
                    LB.Content = s;
                    LB.FontSize = 15;
                    LB.Width = 130;
                    LB.FontWeight = FontWeights.Bold;
                    WrapPanel WP = new WrapPanel();
                    WP.Orientation = Orientation.Horizontal;
                    WP.Margin = new System.Windows.Thickness(0, 0, 10, 8);
                    Grid g = new Grid();
                    g.Children.Add(WP);
                    WP.Children.Add(LB);
                    Label L = new Label();
                    string K = ":";
                    L.Content = s + " " + K;
                    L.FontWeight = FontWeights.Bold;
                    L.FontSize = 15;
                    DT = co.GET_ROOM_NO(s);
                    
                    for (int J = 0; J < DT.Rows.Count; J++)
                    {
                        string SRI = DT.Rows[J]["BACKGROUND_COLOR"].ToString();
                        if (SRI == "Orange")
                        {
                            int ROOMNO = Convert.ToInt16(DT.Rows[J]["ROOM_NO"]);
                            Button BT = new Button();
                            BT.Height = 24; BT.Width = 70;
                            if(J == 6)
                            {
                                BT.Margin = new System.Windows.Thickness(132, 5, 2, 0);
                            }
                            else if(J == 12)
                            {
                                BT.Margin = new System.Windows.Thickness(132, 5, 2, 0);
                            }
                            else if (J == 18)
                            {
                                BT.Margin = new System.Windows.Thickness(132, 5, 2, 0);
                            }
                            else if (J == 24)
                            {
                                BT.Margin = new System.Windows.Thickness(132, 5, 2, 0);
                            }
                            else
                            {
                                BT.Margin = new System.Windows.Thickness(2, 5, 2, 0);
                            }
                            BT.Padding = new System.Windows.Thickness(0, -3, 0, 0);
                            BT.Content = ROOMNO;
                            BT.FontSize = 15;
                            BT.Click += BT_Click;
                            WP.Children.Add(BT);
                            NO_OF_ROOMS = J + 1;
                        }
                        else if (SRI == "Gray")
                        {
                            int ROOMNO = Convert.ToInt16(DT.Rows[J]["ROOM_NO"]);
                            Button BT = new Button();
                            BT.Height = 24; BT.Width = 70;
                            if (J == 6)
                            {
                                BT.Margin = new System.Windows.Thickness(132, 5, 2, 0);
                            }
                            else if (J == 12)
                            {
                                BT.Margin = new System.Windows.Thickness(132, 5, 2, 0);
                            }
                            else if (J == 18)
                            {
                                BT.Margin = new System.Windows.Thickness(132, 5, 2, 0);
                            }
                            else if (J == 24)
                            {
                                BT.Margin = new System.Windows.Thickness(132, 5, 2, 0);
                            }
                            else
                            {
                                BT.Margin = new System.Windows.Thickness(2, 5, 2, 0);
                            }
                            BT.Padding = new System.Windows.Thickness(0, -3, 0, 0);
                            BT.Content = ROOMNO;
                            BT.FontSize = 15;
                            BT.Click += BT_Click;
                            WP.Children.Add(BT);
                            BT.Background = Brushes.Gray;
                            NO_OF_ROOMS = J + 1;
                        }
                    }
                    RowDefinition rd = new RowDefinition();
                    rd.Height = new GridLength(20, GridUnitType.Star);
                    g.RowDefinitions.Add(rd);
                    WRAP.Children.Add(g);
                    Grid.SetRow(g, row);
                    row++;
                }
            }
        }
        public decimal RC_Tariff1, RC_Tax1, RC_Tax2, RC_FinalTariff, RC_FinalTax, RC_Advance, RC_Discount, RC_Charges, RC_Dis_Per, RC_Refund;
        public static decimal RC_TransferAmount;
        public string RC_CheckinId;
        public DateTime DepartureDate;
        private void BT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pd_grid.Rows.Clear();
                Button btn = (Button)sender;
                co.ROOM_NO = Convert.ToString(btn.Content);
                DataTable dt = co.TransferAmount();
                if (dt.Rows[0]["AMOUNT"].ToString() == "" || dt.Rows[0]["AMOUNT"].ToString() == null)
                {
                    RC_TransferAmount = 0;
                }
                else
                {
                    RC_TransferAmount = Convert.ToDecimal(dt.Rows[0]["AMOUNT"]);
                }
                roomno = co.ROOM_NO;
                DataTable dt_user = co.UserDetails();
                grduserdetails.ItemsSource = dt_user.DefaultView;
                if(dt_user.Rows.Count > 0)
                {
                    DepartureDate = Convert.ToDateTime(dt_user.Rows[0]["DEPARTURE_DATE"]);
                }
                DataTable dt_RoomCharges = co.RoomAdditionalCharges();
                DataTable Checking_RC = co.CheckingIfRoomChanged();
                if(dt_RoomCharges.Rows.Count > 0)
                {
                    RC_CheckinId = dt_RoomCharges.Rows[0]["CHECKIN_ID"].ToString();
                    if(dt_RoomCharges.Rows[0]["ADVANCE"].ToString() == null || dt_RoomCharges.Rows[0]["ADVANCE"].ToString() == "")
                    {
                        RC_Advance = 0;
                    }
                    else
                    {
                        RC_Advance = Convert.ToDecimal(dt_RoomCharges.Rows[0]["ADVANCE"]);
                    }
                    if (dt_RoomCharges.Rows[0]["DISCOUNT"].ToString() == null || dt_RoomCharges.Rows[0]["DISCOUNT"].ToString() == "")
                    {
                        RC_Discount = 0;
                    }
                    else
                    {
                        RC_Discount = Convert.ToDecimal(dt_RoomCharges.Rows[0]["DISCOUNT"]);
                    }
                    if (dt_RoomCharges.Rows[0]["POSTCHARGES"].ToString() == null || dt_RoomCharges.Rows[0]["POSTCHARGES"].ToString() == "")
                    {
                        RC_Charges = 0;
                    }
                    else
                    {
                        RC_Charges = Convert.ToDecimal(dt_RoomCharges.Rows[0]["POSTCHARGES"]);
                    }
                    if (dt_RoomCharges.Rows[0]["DIS_PER"].ToString() == null || dt_RoomCharges.Rows[0]["DIS_PER"].ToString() == "")
                    {
                        RC_Dis_Per = 0;
                    }
                    else
                    {
                        RC_Dis_Per = Convert.ToDecimal(dt_RoomCharges.Rows[0]["DIS_PER"]);
                    }
                    if (dt_RoomCharges.Rows[0]["REFUND"].ToString() == null || dt_RoomCharges.Rows[0]["REFUND"].ToString() == "")
                    {
                        RC_Refund = 0;
                    }
                    else
                    {
                        RC_Refund = Convert.ToDecimal(dt_RoomCharges.Rows[0]["REFUND"]);
                    }
                }
                DataTable RC_NA = co.GetNightAudit(RC_CheckinId);
                if (RC_NA.Rows.Count > 0)
                {
                    for (int k = 0; k < RC_NA.Rows.Count; k++)
                    {
                        RC_Tariff1 = Convert.ToDecimal(RC_NA.Rows[k]["ROOM_TARRIF"]);
                        if(RC_NA.Rows[k]["GST"].ToString() == null || RC_NA.Rows[k]["GST"].ToString() == "")
                        {
                            RC_Tax1 = 0;
                        }
                        else
                        {
                            RC_Tax1 = Convert.ToDecimal(RC_NA.Rows[k]["GST"]);
                        }
                        RC_Tax2 = RC_Tariff1 * RC_Tax1 / 100;
                        RC_FinalTariff += RC_Tariff1;
                        RC_FinalTax += RC_Tax2;
                    }
                }
                if (RC_Dis_Per == 0)
                {
                    discountamount = Convert.ToString(Math.Round(RC_Discount, 2, MidpointRounding.AwayFromZero));
                }
                else
                {
                    rpercentage = (RC_FinalTariff * RC_Dis_Per) / 100;
                    discountamount = Convert.ToString(Math.Round(rpercentage, 2, MidpointRounding.AwayFromZero));
                }
                rtotalpendingamnt = RC_FinalTariff + RC_FinalTax + RC_Charges - RC_Advance - Convert.ToDecimal(discountamount) + RC_Refund + RC_TransferAmount;
                totalpendingamount = Convert.ToString(Math.Round(rtotalpendingamnt, 2, MidpointRounding.AwayFromZero));
                DataRow pd = pd_grid.NewRow();
                pd["Roomno"] = co.ROOM_NO;
                pd["Tarrif"] = Math.Round(RC_FinalTariff, 2, MidpointRounding.AwayFromZero);
                Ch_Tarrif = Math.Round(RC_FinalTariff, 2, MidpointRounding.AwayFromZero); 
                pd["Charges"] = Math.Round(RC_Charges, 2, MidpointRounding.AwayFromZero);
                Ch_Charges = Math.Round(RC_Charges, 2, MidpointRounding.AwayFromZero);
                pd["Cgst"] = Math.Round(RC_FinalTax / 2, 2, MidpointRounding.AwayFromZero);
                Ch_CSGST = Math.Round(RC_FinalTax / 2, 2, MidpointRounding.AwayFromZero);
                pd["Sgst"] = Math.Round(RC_FinalTax / 2, 2, MidpointRounding.AwayFromZero);
                pd["Advance"] = Math.Round(RC_Advance, 2, MidpointRounding.AwayFromZero);
                Ch_Advance = Math.Round(RC_Advance, 2, MidpointRounding.AwayFromZero);
                pd["Discount"] = discountamount;
                Ch_Discount = Convert.ToDecimal(discountamount);
                pd["Refund"] = Math.Round(RC_Refund, 2, MidpointRounding.AwayFromZero);
                Ch_Refunds = Math.Round(RC_Refund, 2, MidpointRounding.AwayFromZero);
                Ch_PendingAmount = Math.Round(rtotalpendingamnt, 2, MidpointRounding.AwayFromZero);
                pd["Transfer"] = Math.Round(RC_TransferAmount, 2, MidpointRounding.AwayFromZero);
                pd["Pending_Amount"] = totalpendingamount;
                pd_grid.Rows.Add(pd);
                grdpaymentdetails.ItemsSource = pd_grid.DefaultView;
                RC_FinalTariff = 0;
                RC_FinalTax = 0;
            }
            catch (Exception) { }
        }
        private void btndiscount_Click(object sender, RoutedEventArgs e)
        {
            Discount d = new Discount();
            this.NavigationService.Navigate(d);
        }
        private void btnadvance_Click(object sender, RoutedEventArgs e)
        {
            Advance a = new Advance();
            this.NavigationService.Navigate(a);
        }
        private void btnclear_Click(object sender, RoutedEventArgs e)
        {
            pd_grid.Rows.Clear();
            na_grid.Rows.Clear();
            grdpaymentdetails.ItemsSource = "";
            grduserdetails.ItemsSource = "";
            checkoutgrid.ItemsSource = "";
            this.NavigationService.Refresh();
        }
        public static DataTable crystal;
        public static DataTable crystal1;
        private void btnprintbill_Click(object sender, RoutedEventArgs e)
        {
            if(DepartureDate < DateTime.Today.Date)
            {
                MessageBox.Show("Please change the departure date in GuestInfo page..!");
            }
            else
            {
                popup.IsOpen = true;
            }
        }
        public void printandprovibills()
        {
            //Checkout1 co = new Checkout1();
            //co.ROOM_NO = roomno;
            //d1 = co.guestinfo();
            //d2 = co.ROOMCATEGORY();
            //d3 = co.checkoutdetails();
            //d4 = co.company_contact();
            //id = co.get_checkout_id();

            //decimal.TryParse(chargedtarrif.ToString(), out finalcharged);
            ////abc = 3;
            //DataTable d = report();
            //if (provibill == "provibill")
            //{
            //    d.Columns.Remove("Checkout Bill No :");
            //    Checkout1.dt = d;
            //}
            //else if (provibill == "printbill")
            //{
            //    Checkout1.dt = d;
            //}
            //ReportDocument r = new ReportDocument();
            //r.Load("../../Checkoutbilling.rpt");

            ////  **********For Report*******************
            //ReportDocument rrr = new ReportDocument();
            //rrr.Load("../../Checkoutreport.rpt");
            //Checkout1 co1 = new Checkout1();
            //DataTable hotel2 = co1.GET_HOTELADDRESS();
            ////rrr.Subreports[0].SetDataSource(hotel2);
            //rrr.SetDataSource(Checkout1.dt);
            //rrr.PrintToPrinter(1, false, 0, 0);

            //co.BILL_NO = Convert.ToString(id);
            //co.DATE = Convert.ToString(DateTime.Today);
            //co.ROOM_NO = roomno;
            //if (dt.Rows.Count == 0) { }
            //else
            //{
            //    co.ARRIVAL_DATE = dt.Rows[0]["ARRIVAL_DATE"].ToString();
            //    co.DEPARTURE_DATE = dt.Rows[0]["DEPARTURE_DATE"].ToString();
            //    co.GUEST_NAME = dt.Rows[0]["FIRSTNAME"].ToString();
            //    co.CONTACT_NO = d1.Rows[0]["MOBILE_NO"].ToString();
            //    co.ROOM_TARRIF = Convert.ToString(finalcharged);
            //    co.EXTRA_CHARGES = Convert.ToString(charges);
            //    co.CGST = Convert.ToString(totalcgst);
            //    co.SGST = Convert.ToString(totalsgst);
            //    decimal tot = tarrif + charges + cgst + sgst;
            //    co.TOTAL = Convert.ToString(tot);
            //    co.ADVANCE = Convert.ToString(advance);
            //    co.DISCOUNT = Convert.ToString(discount);
            //    co.BALANCE_AMOUNT = totalpendingamount;
            //    co.COMPANY = d1.Rows[0]["COMPANY_NAME"].ToString();

            //    co.print_insert();
            //    co.print_insert1();

            //    co.CURRENTDATE = DateTime.Today;
            //    decimal b = cgst + sgst;
            //    co.GST_MONEY = Convert.ToString(b);
            //    co.GST_PERCENTAGE = Convert.ToString(gst);
            //    co.CGST = Convert.ToString(g);
            //    co.SGST = Convert.ToString(g);
            //    co.arrival = Convert.ToDateTime(co.ARRIVAL_DATE);
            //    co.departure = Convert.ToDateTime(co.DEPARTURE_DATE);

            //    co.Insert();
            //}
        }
        public DataTable hotelprint()
        {
            co.ROOM_NO = roomno;
            d1 = co.guestinfo();
            id = co.get_checkout_id() - 1;
            DataTable d = new DataTable();
            d.Columns.Add("Name", typeof(string));
            d.Columns.Add("Address1", typeof(string));
            d.Columns.Add("Gst", typeof(string));
            d.Columns.Add("TarrifTotal", typeof(decimal));
            d.Columns.Add("C.Gst", typeof(decimal));
            d.Columns.Add("S.Gst", typeof(decimal));
            d.Columns.Add("OtherCharges", typeof(decimal));
            d.Columns.Add("Total", typeof(decimal));
            d.Columns.Add("Advance", typeof(decimal));
            d.Columns.Add("Discount", typeof(decimal));
            d.Columns.Add("User", typeof(string));
            d.Columns.Add("BillNo", typeof(int));
            d.Columns.Add("GuestName", typeof(string));
            d.Columns.Add("RoomNo", typeof(int));
            d.Columns.Add("RoomType", typeof(string));
            d.Columns.Add("CheckInDate", typeof(DateTime));
            d.Columns.Add("CheckoutDate", typeof(DateTime));
            d.Columns.Add("StayDays", typeof(int));
            d.Columns.Add("Mobile", typeof(Int64));
            d.Columns.Add("Address", typeof(string));
            d.Columns.Add("City", typeof(string));
            d.Columns.Add("State", typeof(string));
            d.Columns.Add("Coutry", typeof(string));
            d.Columns.Add("PinCode", typeof(int));
            d.Columns.Add("Gst1", typeof(string));
            d.Columns.Add("Signature", typeof(string));
            d.Columns.Add("DiscountAmount", typeof(decimal));
            d.Columns.Add("Refund", typeof(decimal));
            d.Columns.Add("Transfer", typeof(decimal));
            d.Columns.Add("Company", typeof(string));
            d.Columns.Add("Time", typeof(DateTime));
            d.Columns.Add("PrintType", typeof(string));
            co.hotel();
            DataRow r = d.NewRow();
            r["Name"] = Checkout1.N;
            r["Address1"] = Checkout1.AD;
            r["Gst"] = Checkout1.GS;
            r["TarrifTotal"] = Ch_Tarrif;
            r["C.Gst"] = Ch_CSGST;
            r["S.Gst"] = Ch_CSGST;
            r["OtherCharges"] = Ch_Charges;
            r["Total"] = Ch_PendingAmount;
            long dsq = Convert.ToInt64(Ch_PendingAmount);
            r["Advance"] = Ch_Advance;
            r["Discount"] = Ch_Total;
            r["User"] = login.u;
            r["BillNo"] = id;
            r["GuestName"] = d1.Rows[0]["FIRSTNAME"];
            r["RoomNo"] = roomno;
            r["RoomType"] = d1.Rows[0]["ROOM_CATEGORY"].ToString();
            r["CheckInDate"] = d1.Rows[0]["ARRIVAL_DATE"].ToString();
            r["Time"] = d1.Rows[0]["ARRIVAL_TIME"].ToString();
            time.Text = d1.Rows[0]["ARRIVAL_TIME"].ToString();
            r["CheckoutDate"] = DateTime.Today.Date;
            r["StayDays"] = count;
            r["Mobile"] = d1.Rows[0]["MOBILE_NO"].ToString();
            r["Address"] = d1.Rows[0]["ADDRESS"].ToString();
            r["City"] = d1.Rows[0]["CITY"].ToString();
            r["State"] = d1.Rows[0]["STATE"].ToString();
            r["Coutry"] = d1.Rows[0]["COUNTRY"].ToString();
            r["PinCode"] = d1.Rows[0]["ZIP"].ToString();
            r["Gst1"] = 00000;
            r["Signature"] = NumberToText(dsq);
            r["DiscountAmount"] = Ch_Discount;
            r["Refund"] = Ch_Refunds;
            r["Transfer"] = RC_TransferAmount;
            if(d1.Rows[0]["COMPANY_NAME"].ToString() == null || d1.Rows[0]["COMPANY_NAME"].ToString() == "" || d1.Rows[0]["COMPANY_NAME"].ToString() == "Select a Compny")
            {
                r["Company"] = d1.Rows[0]["Company_Gst"].ToString();
            }else
            {
                r["Company"] = d1.Rows[0]["Company_Gst"].ToString() + " (" + d1.Rows[0]["COMPANY_NAME"].ToString() + ")";
            }
            if(PrintType == 0)
            {
                r["PrintType"] = "Owner Copy";
            }else if (PrintType == 1)
            {
                r["PrintType"] = " ";
            }
            d.Rows.Add(r);
            return d;
        }
        private static string NumberToText(long n)
        {
            if (n < 0)
                return "Minus " + NumberToText(-n);
            else if (n == 0)
                return "";
            else if (n <= 19)
                return new string[] {"One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight",
                                "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
                                "Seventeen", "Eighteen", "Nineteen"}[n - 1] + " ";
            else if (n <= 99)
                return new string[] {"Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy",
                                "Eighty", "Ninety"}[n / 10 - 2] + " " + NumberToText(n % 10);
            else if (n <= 199)
                return "One Hundred " + NumberToText(n % 100);
            else if (n <= 999)
                return NumberToText(n / 100) + "Hundred " + NumberToText(n % 100);
            else if (n <= 1999)
                return "One Thousand " + NumberToText(n % 1000);
            else if (n <= 999999)
                return NumberToText(n / 1000) + "Thousand " + NumberToText(n % 1000);
            else if (n <= 1999999)
                return "One Million " + NumberToText(n % 1000000);
            else if (n <= 999999999)
                return NumberToText(n / 1000000) + "Million " + NumberToText(n % 1000000);
            else if (n <= 1999999999)
                return "One Billion " + NumberToText(n % 1000000000);
            else
                return NumberToText(n / 1000000000) + "Billion " + NumberToText(n % 1000000000);
        }
        public decimal rp_Advance, rp_Charges, rp_Tariff, rp_Tax, rp_Gst;
        public int count;
        public DataTable report()
        {
            Checkout1 C = new Checkout1();
            count = co.night_auditcount();
            C.ROOM_NO = roomno;
            DataTable advrec = new DataTable();
            advrec.Columns.Add("Date", typeof(DateTime));
            advrec.Columns.Add("Tarrif", typeof(decimal));
            advrec.Columns.Add("Advance", typeof(decimal));
            advrec.Columns.Add("OtherCharges", typeof(decimal));
            advrec.Columns.Add("Tax", typeof(decimal));
            advrec.Columns.Add("Total", typeof(decimal));
            DataTable NA_Details = co.Room_NA_Details();
            if (NA_Details.Rows.Count > 0)
            {
                //na_grid
                for (int i = 0; i < NA_Details.Rows.Count; i++)
                {
                    DataRow na = advrec.NewRow();
                    na["Date"] = Convert.ToDateTime(NA_Details.Rows[i]["INSERT_DATE"]).ToShortDateString();
                    if (NA_Details.Rows[i]["ROOM_TARRIF"].ToString() == null || NA_Details.Rows[i]["ROOM_TARRIF"].ToString() == "")
                    {
                        rp_Tariff = 0;
                    }
                    else
                    {
                        rp_Tariff = Convert.ToDecimal(NA_Details.Rows[i]["ROOM_TARRIF"]);
                    }
                    if (NA_Details.Rows[i]["GST"].ToString() == null || NA_Details.Rows[i]["GST"].ToString() == "")
                    {
                        rp_Tax = 0;
                    }
                    else
                    {
                        rp_Tax = Convert.ToDecimal(NA_Details.Rows[i]["GST"]);
                    }
                    if (i == (NA_Details.Rows.Count - 1))
                    {
                        co.From_dt = Convert.ToDateTime(NA_Details.Rows[i]["INSERT_DATE"]);
                        co.To_dt = Convert.ToDateTime(NA_Details.Rows[i]["INSERT_DATE"]).AddDays(1);
                        co.GetAdvance();
                        co.GetCharges();
                        rp_Advance = co.NA_Advance;
                        rp_Charges = co.NA_Charges;
                    }
                    else
                    {
                        if (NA_Details.Rows[i]["ADVANCE"].ToString() == null || NA_Details.Rows[i]["ADVANCE"].ToString() == "")
                        {
                            rp_Advance = 0;
                        }
                        else
                        {
                            rp_Advance = Convert.ToDecimal(NA_Details.Rows[i]["ADVANCE"]);
                        }
                        if (NA_Details.Rows[i]["CHARGES"].ToString() == null || NA_Details.Rows[i]["CHARGES"].ToString() == "")
                        {
                            rp_Charges = 0;
                        }
                        else
                        {
                            rp_Charges = Convert.ToDecimal(NA_Details.Rows[i]["CHARGES"]);
                        }
                    }
                    rp_Gst = (rp_Tariff * rp_Tax) / 100;
                    na["Tarrif"] = Math.Round(rp_Tariff, 2, MidpointRounding.AwayFromZero);
                    na["Tax"] = Math.Round(rp_Gst, 2, MidpointRounding.AwayFromZero);
                    na["Advance"] = Math.Round(rp_Advance, 2, MidpointRounding.AwayFromZero);
                    na["OtherCharges"] = Math.Round(rp_Charges, 2, MidpointRounding.AwayFromZero);
                    na["Total"] = Math.Round(rp_Tariff + rp_Charges + rp_Gst - rp_Advance, 2, MidpointRounding.AwayFromZero);
                    advrec.Rows.Add(na);
                }
            }
            return advrec;
        }

     

    }
}