using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HMS.Model.Others;
using HMS.Model;
using System.Windows.Threading;
using System.Timers;
using HMS.View.Operations;
using System.Windows.Media.Animation;
using System.Globalization;
using HMS.View.Masters;

namespace HMS.mainwindowpages
{
    /// <summary>
    /// Interaction logic for home.xaml
    /// </summary>
    public partial class home : Page
    {
        Home hm = new Home();
        Entireroom e = new Entireroom();
        public Timer t = new Timer();
        blockroom b = new blockroom();
        DoubleAnimation da = new DoubleAnimation();
        public static DateTime at,ct;
        public static string atime, ctime;
        List<String> LI = new List<string>();
        Report rp = new Report();
        public home()
        {
            InitializeComponent();
            da.From = 15;
            da.To = 20;
            da.AutoReverse = true;
            da.RepeatBehavior = new RepeatBehavior(3);
            da.Duration = new Duration(TimeSpan.FromHours(3.0));
            e.night_auditing();
            DataTable ddt = hm.btnblink();
            //DispatcherTimer timer = new DispatcherTimer();
            //timer.Tick += timer_Tick;
            //timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            //timer.Start();
            //for (int i = 0; i < ddt.Rows.Count; i++)
            //{
            //    atime = Convert.ToDateTime(ddt.Rows[i]["ARRIVAL_TIME"]);
            //    ctime = Convert.ToDateTime(DateTime.Today.ToShortTimeString());
            //    double minutes = Convert.ToDateTime(atime).Subtract(ctime).TotalMinutes;
            //    if (minutes == 180)
            //    {
            //        BeginAnimation(TextBlock.FontSizeProperty, da);
            //    }
            //}
            DataTable checkin = hm.checkout_list();
            checkoutlist.ItemsSource = checkin.DefaultView;
            DataTable reservation = hm.reservation_list();
            reservationlist.ItemsSource = reservation.DefaultView;
            string s = null;
            //ROW.Height = new GridLength(8 + I, GridUnitType.Star);
            DataTable dt = hm.GET_ROOMCATEGORY();
            int row = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                s = dt.Rows[i]["ROOM_CATEGORY"].ToString();
                if (LI.Contains(s)) { }
                else
                {
                    LI.Add(s);
                    int NO_OF_ROOMS = 0;
                    Label LB = new Label();
                    LB.Content = s;
                    LB.FontSize = 15;
                    LB.Width = 100;
                    LB.FontWeight = FontWeights.Bold;
                    // LB.Margin = new System.Windows.Thickness(0, 0, 15, 0);
                    WrapPanel WP = new WrapPanel();
                    WP.Orientation = Orientation.Horizontal;
                    WP.Margin = new System.Windows.Thickness(0, 0, 20, 8);
                    Grid g = new Grid();
                    g.Children.Add(WP);
                    WP.Children.Add(LB);
                    Label L = new Label();
                    string K = ":";
                    L.Content = s + " " + K;
                    L.FontWeight = FontWeights.Bold;
                    L.FontSize = 15;
                    //CATEGORY.Children.Add(L);
                    DataTable DT = hm.GET_ROOM_NO(s);
                    DataTable DTS = hm.getstatus();
                    DataTable br = hm.GETBLOCK();
                    for (int J = 0; J < DT.Rows.Count; J++)
                    {
                        int ROOMNO = Convert.ToInt16(DT.Rows[J]["ROOM_NO"]);
                        Button BT = new Button();
                        BT.Height = 30; BT.Width = 75;
                        BT.Margin = new System.Windows.Thickness(2, 3, 2, 0);
                        BT.Content = ROOMNO;
                        BT.BeginAnimation(TextBlock.FontSizeProperty, da);
                        BT.FontSize = 15;
                        BT.BorderBrush = Brushes.DarkGreen;
                        bool exists = DTS.Select().ToList().Exists(row1 => row1["ROOM_NO"].ToString().ToUpper() == ROOMNO.ToString());
                        // bool exists1 = br.Select().ToList().Exists(row2 => row2["ROOM_NO"].ToString().ToUpper() == ROOMNO.ToString());
                        if (exists == true)
                        {
                            BT.Background = Brushes.Blue;
                        }
                        else
                        {
                            string S = hm.GET_BACKGROUND_COLOR(ROOMNO);
                            SET_COLOR(S, BT);
                        }
                        //for (int iI = 0; iI < ddt.Rows.Count; iI++)
                        //{
                        //    atime = Convert.ToString(ddt.Rows[iI]["ARRIVAL_TIME"]);
                        //    at = Convert.ToDateTime(atime);
                        //    ctime = Convert.ToString(DateTime.Now.ToShortDateString());
                        //    ct = Convert.ToDateTime(ctime);
                        //    if (atime.Contains("AM") || atime.Contains("PM"))
                        //        at = DateTime.ParseExact(atime, "dd.MM.yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                        //    if (ctime.Contains("AM") || ctime.Contains("PM"))
                        //        ct = DateTime.ParseExact(ctime, "dd.MM.yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                        //    double minutes = Convert.ToDateTime(at).Subtract(ct).TotalMinutes;
                        //    if (minutes <= 180)
                        //    {
                        //        BT.BeginAnimation(TextBlock.FontSizeProperty, da);
                        //    }
                        //}
                        NO_OF_ROOMS = J + 1;
                        WP.Children.Add(BT);
                    }
                    Label LBL = new Label();
                    LBL.Content = NO_OF_ROOMS;
                    LBL.FontWeight = FontWeights.Bold;
                    LBL.FontSize = 15;
                    //CATEGORY.Children.Add(LBL);
                    RowDefinition rd = new RowDefinition();
                    rd.Height = new GridLength(20, GridUnitType.Star);
                    g.RowDefinitions.Add(rd);
                    WRAP.Children.Add(g);
                    Grid.SetRow(g, row);
                    row++;
                }
            }
            t.Interval = 600000; // 10 minutes
            t.Elapsed += timer_Elasped;
            t.Start();
            Opening_Balance();
        }
        public void Opening_Balance()
        {
            DataTable C_OB = hm.CheckingRowsInOB();
            if(C_OB.Rows.Count == 0)
            {
                hm.AUTHORIZATIONS = login.u;
                hm.AMOUNT = "0.00";
                hm.STATUS = "AUDIT";
                hm.INSERT_DATE = Convert.ToString(DateTime.Today.Date);
                hm.INSERT_BY = login.u;
                hm.AMOUNT_TYPE = "Cash";
                hm.OB_INSERT();

                hm.AUTHORIZATIONS = login.u;
                hm.AMOUNT = "0.00";
                hm.STATUS = "AUDIT";
                hm.INSERT_DATE = Convert.ToString(DateTime.Today.Date);
                hm.INSERT_BY = login.u;
                hm.AMOUNT_TYPE = "ToBank";
                hm.OB_INSERT();
            }
            else if(C_OB.Rows.Count > 0)
            {
                DataTable M_IDate = hm.MaxInsertDate();
                if (M_IDate.Rows[0]["INSERT_DATE"] == null)
                {
                    hm.AUTHORIZATIONS = login.u;
                    hm.AMOUNT = "0.00";
                    hm.STATUS = "AUDIT";
                    hm.INSERT_DATE = Convert.ToString(DateTime.Today.Date);
                    hm.INSERT_BY = login.u;
                    hm.AMOUNT_TYPE = "Cash";
                    hm.OB_INSERT();

                    hm.AUTHORIZATIONS = login.u;
                    hm.AMOUNT = "0.00";
                    hm.STATUS = "AUDIT";
                    hm.INSERT_DATE = Convert.ToString(DateTime.Today.Date);
                    hm.INSERT_BY = login.u;
                    hm.AMOUNT_TYPE = "ToBank";
                    hm.OB_INSERT();
                }
                else
                {
                    DateTime insert_date = Convert.ToDateTime(M_IDate.Rows[0]["INSERT_DATE"]);
                    if(insert_date.Date >= DateTime.Today.Date)
                    {}
                    else
                    {
                        DateTime LoopDate = insert_date.Date.AddDays(1);
                        for(LoopDate = LoopDate.Date; LoopDate <= DateTime.Today.Date; LoopDate = LoopDate.Date.AddDays(1))
                        {
                            decimal ob_R_advance = 0, ob_C_advance = 0, ob_E_Advance = 0, ob_Mis = 0, ob_Paidouts = 0, ob_Refunds = 0, ob_Settle = 0, ob_YOB = 0, ob_Amount = 0, ob_pendingbill = 0;
                            rp.OB_Date = LoopDate.Date.AddDays(-1).ToShortDateString();
                            DataTable OB = rp.OB_Getting_Cash();
                            if(OB.Rows.Count > 0)
                            {
                                if (OB.Rows[0]["PendingBill"].ToString() == null || OB.Rows[0]["PendingBill"].ToString() == "")
                                {
                                    ob_pendingbill = 0;
                                }
                                else
                                {
                                    ob_pendingbill = Convert.ToDecimal(OB.Rows[0]["PendingBill"]);
                                }
                                if (OB.Rows[0]["R_Advance"].ToString() == null || OB.Rows[0]["R_Advance"].ToString() == "")
                                {
                                    ob_R_advance = 0;
                                }
                                else
                                {
                                    ob_R_advance = Convert.ToDecimal(OB.Rows[0]["R_Advance"]);
                                }
                                if (OB.Rows[0]["C_Advance"].ToString() == null || OB.Rows[0]["C_Advance"].ToString() == "")
                                {
                                    ob_C_advance = 0;
                                }
                                else
                                {
                                    ob_C_advance = Convert.ToDecimal(OB.Rows[0]["C_Advance"]);
                                }
                                if (OB.Rows[0]["E_Advance"].ToString() == null || OB.Rows[0]["E_Advance"].ToString() == "")
                                {
                                    ob_E_Advance = 0;
                                }
                                else
                                {
                                    ob_E_Advance = Convert.ToDecimal(OB.Rows[0]["E_Advance"]);
                                }
                                if (OB.Rows[0]["Mis"].ToString() == null || OB.Rows[0]["Mis"].ToString() == "")
                                {
                                    ob_Mis = 0;
                                }
                                else
                                {
                                    ob_Mis = Convert.ToDecimal(OB.Rows[0]["Mis"]);
                                }
                                if (OB.Rows[0]["PaidOuts"].ToString() == null || OB.Rows[0]["PaidOuts"].ToString() == "")
                                {
                                    ob_Paidouts = 0;
                                }
                                else
                                {
                                    ob_Paidouts = Convert.ToDecimal(OB.Rows[0]["PaidOuts"]);
                                }
                                if (OB.Rows[0]["Refund"].ToString() == null || OB.Rows[0]["Refund"].ToString() == "")
                                {
                                    ob_Refunds = 0;
                                }
                                else
                                {
                                    ob_Refunds = Convert.ToDecimal(OB.Rows[0]["Refund"]);
                                }
                                if (OB.Rows[0]["Settle"].ToString() == null || OB.Rows[0]["Settle"].ToString() == "")
                                {
                                    ob_Settle = 0;
                                }
                                else
                                {
                                    ob_Settle = Convert.ToDecimal(OB.Rows[0]["Settle"]);
                                }
                                if (OB.Rows[0]["OpeningBalance"].ToString() == null || OB.Rows[0]["OpeningBalance"].ToString() == "")
                                {
                                    ob_YOB = 0;
                                }
                                else
                                {
                                    ob_YOB = Convert.ToDecimal(OB.Rows[0]["OpeningBalance"]);
                                }
                                ob_Amount = ob_YOB + ob_pendingbill + ob_R_advance + ob_C_advance + ob_E_Advance + ob_Mis - ob_Paidouts - ob_Refunds + ob_Settle;

                                hm.AUTHORIZATIONS = login.u;
                                hm.AMOUNT = Math.Round(ob_Amount,2,MidpointRounding.AwayFromZero).ToString();
                                hm.STATUS = "AUDIT";
                                hm.INSERT_BY = login.u;
                                hm.AMOUNT_TYPE = "Cash";
                                hm.INSERT_DATE = LoopDate.Date.ToShortDateString();
                                hm.OB_INSERT();
                            }

                            ob_R_advance = 0; ob_C_advance = 0; ob_E_Advance = 0; ob_Mis = 0; ob_Paidouts = 0; ob_Refunds = 0; ob_Settle = 0; ob_YOB = 0; ob_Amount = 0; ob_pendingbill = 0;
                            rp.OB_Date = LoopDate.Date.AddDays(-1).ToShortDateString();
                            DataTable OB1 = rp.OB_Getting_Card();
                            if (OB1.Rows.Count > 0)
                            {
                                if (OB1.Rows[0]["PendingBill"].ToString() == null || OB1.Rows[0]["PendingBill"].ToString() == "")
                                {
                                    ob_pendingbill = 0;
                                }
                                else
                                {
                                    ob_pendingbill = Convert.ToDecimal(OB1.Rows[0]["PendingBill"]);
                                }
                                if (OB1.Rows[0]["R_Advance"].ToString() == null || OB1.Rows[0]["R_Advance"].ToString() == "")
                                {
                                    ob_R_advance = 0;
                                }
                                else
                                {
                                    ob_R_advance = Convert.ToDecimal(OB1.Rows[0]["R_Advance"]);
                                }
                                if (OB1.Rows[0]["C_Advance"].ToString() == null || OB1.Rows[0]["C_Advance"].ToString() == "")
                                {
                                    ob_C_advance = 0;
                                }
                                else
                                {
                                    ob_C_advance = Convert.ToDecimal(OB1.Rows[0]["C_Advance"]);
                                }
                                if (OB1.Rows[0]["E_Advance"].ToString() == null || OB1.Rows[0]["E_Advance"].ToString() == "")
                                {
                                    ob_E_Advance = 0;
                                }
                                else
                                {
                                    ob_E_Advance = Convert.ToDecimal(OB1.Rows[0]["E_Advance"]);
                                }
                                if (OB1.Rows[0]["Mis"].ToString() == null || OB1.Rows[0]["Mis"].ToString() == "")
                                {
                                    ob_Mis = 0;
                                }
                                else
                                {
                                    ob_Mis = Convert.ToDecimal(OB1.Rows[0]["Mis"]);
                                }
                                if (OB1.Rows[0]["PaidOuts"].ToString() == null || OB1.Rows[0]["PaidOuts"].ToString() == "")
                                {
                                    ob_Paidouts = 0;
                                }
                                else
                                {
                                    ob_Paidouts = Convert.ToDecimal(OB1.Rows[0]["PaidOuts"]);
                                }
                                if (OB1.Rows[0]["Settle"].ToString() == null || OB1.Rows[0]["Settle"].ToString() == "")
                                {
                                    ob_Settle = 0;
                                }
                                else
                                {
                                    ob_Settle = Convert.ToDecimal(OB1.Rows[0]["Settle"]);
                                }
                                if (OB1.Rows[0]["OpeningBalance"].ToString() == null || OB1.Rows[0]["OpeningBalance"].ToString() == "")
                                {
                                    ob_YOB = 0;
                                }
                                else
                                {
                                    ob_YOB = Convert.ToDecimal(OB1.Rows[0]["OpeningBalance"]);
                                }
                                ob_Amount = ob_YOB + ob_pendingbill + ob_R_advance + ob_C_advance + ob_E_Advance + ob_Mis + ob_Settle - ob_Paidouts;
                                hm.AUTHORIZATIONS = login.u;
                                hm.AMOUNT = Math.Round(ob_Amount, 2, MidpointRounding.AwayFromZero).ToString();
                                hm.STATUS = "AUDIT";
                                hm.INSERT_BY = login.u;
                                hm.AMOUNT_TYPE = "ToBank";
                                hm.INSERT_DATE = LoopDate.Date.ToShortDateString();
                                hm.OB_INSERT();
                            }
                        }
                    }
                }
            }
            else
            {
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            WRAP.Children.GetType();
        }
        public void timer_Elasped(object sender, ElapsedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                b.ColorUpdate1();
            }));
        }
        public int Green = 0; public int orange = 0; public int red = 0; public int blue = 0;
        public int gray = 0; public int pink = 0;
        public void SET_COLOR(string S, Button bt)
        {
            switch (S)
            {
                case "Green":
                    bt.Background = Brushes.DarkGreen;
                    bt.Click += new RoutedEventHandler(Green_click);
                    Green++;
                    break;
                case "Orange":
                    bt.Background = Brushes.Orange;
                    bt.Click += new RoutedEventHandler(Orange_click);
                    orange++;
                    break;
                case "Red":
                    bt.Background = Brushes.Red;
                    bt.Foreground = new System.Windows.Media.SolidColorBrush(Colors.White);
                    bt.Click += new RoutedEventHandler(Red_click);
                    red++;
                    break;
                case "Pink":
                    bt.Background = Brushes.LightPink;
                    bt.Foreground = new System.Windows.Media.SolidColorBrush(Colors.White);
                    bt.Click += new RoutedEventHandler(Pink_click);
                    pink++;
                    break;
                case "Blue":
                    bt.Background = Brushes.Blue;
                    bt.Foreground = new System.Windows.Media.SolidColorBrush(Colors.White);
                    bt.Click += new RoutedEventHandler(Blue_click);
                    blue++;
                    break;
                case "Gray":
                    bt.Background = Brushes.Gray;
                    bt.Click += new RoutedEventHandler(Gray_click);
                    gray++;
                    break;
            }
            VACANT.Content = Green; VACANT.Focusable = true;
            OCCUPIED.Content = orange;
            MAINTANANCE.Content = red;
            MANAGEMENT.Content = pink;
            BLUE.Content = blue;
            GRAY.Content = gray;
        }
        protected void Green_click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("View/Operations/CheckinDeparture.xaml", UriKind.RelativeOrAbsolute));
        }
        protected void Orange_click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("View/Operations/Checkout.xaml", UriKind.RelativeOrAbsolute));
        }
        protected void Red_click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("View/Operations/Block_Room.xaml", UriKind.RelativeOrAbsolute));
        }
        protected void Pink_click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("View/Operations/Block_Room.xaml", UriKind.RelativeOrAbsolute));
        }
        protected void Blue_click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("View/Operations/Block_Room.xaml", UriKind.RelativeOrAbsolute));
        }
        protected void Gray_click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("View/Operations/settle.xaml", UriKind.RelativeOrAbsolute));
        }
        private void btnenquiry_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("View/Operations/enquiry.xaml", UriKind.RelativeOrAbsolute));
        }
        private void btreservation_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("View/Operations/RESERVATIONS.xaml", UriKind.RelativeOrAbsolute));
        }
        private void btncheckin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("View/Operations/CheckinDeparture.xaml", UriKind.RelativeOrAbsolute));
        }
        private void btnadvance_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("View/Operations/Advance.xaml", UriKind.RelativeOrAbsolute));
        }
        private void btncheckouot_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("View/Operations/Checkout.xaml", UriKind.RelativeOrAbsolute));
        }
        private void btnpbbill_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("View/Operations/Pendingbillgrid.xaml", UriKind.Relative));
        }
    }
}