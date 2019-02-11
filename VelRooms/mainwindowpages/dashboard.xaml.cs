using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using HMS.Model.Others;
using System.Data;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HMS.Model.Masters;
using HMS.Model;
using HMS.View.Operations;
using HMS.Model.Operations;

namespace VELROOMS.mainwindowpages
{
    /// <summary>
    /// Interaction logic for dashboard.xaml
    /// </summary>
    public partial class dashboard : Page
    {
        dashboard1 db = new dashboard1();
        Entireroom ENT = new Entireroom();
        List<String> LI = new List<string>();
        Settle1 X = new Settle1();
        public decimal checkintotalcount, discounttotalcount, miscellenoustotalcount, postchargestotalcount, paidoutstotalcount;

        public decimal jan, feb, mar, apr, may, june, july, aug, sep, oct, nov, dec;
        public string pendingbillcompany;
        public dashboard()
        {
            InitializeComponent();
            DataTable discountcount = db.discount_count();
            if (discountcount.Rows.Count == 0)
            {
                discounttotalcount = 0;
            }
            else
            {
                discounttotalcount = db.discounttotal;
            }

            DataTable postchargescount = db.postcharges_count();
            if (postchargescount.Rows.Count == 0)
            {
                postchargestotalcount = 0;
            }
            else
            {
                postchargestotalcount = db.postchargestotal;
            }

            DataTable miscellenous = db.miscellenous_count();
            if (miscellenous.Rows.Count == 0)
            {
                miscellenoustotalcount = 0;
            }
            else
            {
                miscellenoustotalcount = db.miscellenoustotal;
            }

            DataTable paidouts = db.paidouts_count();
            if (paidouts.Rows.Count == 0)
            {
                paidoutstotalcount = 0;
            }
            else
            {
                paidoutstotalcount = db.paidoutstotal;
            }


            DataTable checkincount = db.roomcheckin_count();
            if (checkincount.Rows.Count == 0)
            {
                checkintotalcount = 0;
            }
            else
            {
                checkintotalcount = db.checkintotal;
            }

            DataTable reservation = db.reservation_list();
            reservationlist.ItemsSource = reservation.DefaultView;
            DataTable companypending = X.companypendingbill();
            if (companypending.Rows.Count == 0)
            {
                pendingbillcompany = "0";
            }
            else
            {
                pendingbillcompany = X.pendingbillcompany;
            }
            companypendingdash.ItemsSource = companypending.DefaultView;
            //DataTable ADVANCE_RES = db.reservation_advance();

            // reservationlist.ItemsSource = ADVANCE_RES.DefaultView;


            //DataTable d = new DataTable();
            ///d.Columns.Add("RESERVATION_ID", (typeof(string)));
            //  d.Columns.Add("RESERVATION", (typeof(string)));
            //d.Columns.Add("FIRSTNAME", (typeof(string)));
            //d.Columns.Add("NO_OF_ROOMS", (typeof(int)));
            //d.Columns.Add("ARRIVAL_DATE", (typeof(DateTime)));
            //d.Columns.Add("MOBILE_NO", (typeof(Int64)));
            //d.Columns.Add("AMOUNT_RECEIVED", (typeof(decimal)));
            //for(int i=0; i<reservation.Rows.Count ; i++)
            //{
            //    DataRow r = d.NewRow();
            //    r["RESERVATION_ID"] = reservation.Rows[i]["RESERVATION_ID"].ToString();
            //    //if (ADVANCE_RES.Rows[i]["RESERVATION_ID"].ToString() !=null )
            //    //{
            //    //    r["RESERVATION"] = 0.00;
            //    //}
            //    //else
            //    //{
            //    //    r["RESERVATION"] = ADVANCE_RES.Rows[i]["RESERVATION_ID"].ToString();
            //    //}
            //    r["FIRSTNAME"] = reservation.Rows[i]["FIRSTNAME"].ToString();
            //    r["NO_OF_ROOMS"] = reservation.Rows[i]["NO_OF_ROOMS"].ToString();
            //    r["ARRIVAL_DATE"] = reservation.Rows[i]["ARRIVAL_DATE"].ToString();
            //    r["MOBILE_NO"] = reservation.Rows[i]["MOBILE_NO"].ToString();
            //    if(reservation.Rows[i]["RESERVATION_ID"].ToString() == ADVANCE_RES.Rows[i]["RESERVATION_ID"].ToString())
            //    {
            //        r["AMOUNT_RECEIVED"] = ADVANCE_RES.Rows[i]["AMOUNT_RECEIVED"].ToString();
            //    }
            //    else
            //    {
            //        r["AMOUNT_RECEIVED"] = 0.00;
            //    }

            //        d.Rows.Add(r);
            //}
            //reservationlist.ItemsSource = d.DefaultView;

            // ROOM_NO,GUEST_NAME,ARRIVAL_DATE,ARRIVAL_TIME,CONTACT_NO,(pndng) as pndng 
            DataTable guestinfo = db.guestinfo_list();
            DataTable d = new DataTable();
            d.Columns.Add("ROOM_NO", (typeof(int)));
            d.Columns.Add("GUEST_NAME", (typeof(string)));
            d.Columns.Add("ARRIVAL_DATE", (typeof(DateTime)));
            d.Columns.Add("ARRIVAL_TIME", (typeof(string)));
            d.Columns.Add("CONTACT_NO", (typeof(Int64)));
            d.Columns.Add("AMOUNT_RECEIVED", (typeof(decimal)));
            d.Columns.Add("DEPARTURE_TIME", (typeof(string)));

            for (int i = 0; i < guestinfo.Rows.Count; i++)
            {
                //pndng = Checkout.stotalpendingamount;
                DataRow r = d.NewRow();
                r["ROOM_NO"] = guestinfo.Rows[i]["ROOM_NO"].ToString();
                r["GUEST_NAME"] = guestinfo.Rows[i]["GUEST_NAME"].ToString();
                r["ARRIVAL_DATE"] = guestinfo.Rows[i]["ARRIVAL_DATE"].ToString();
                r["ARRIVAL_TIME"] = guestinfo.Rows[i]["ARRIVAL_TIME"].ToString();
                r["CONTACT_NO"] = guestinfo.Rows[i]["CONTACT_NO"].ToString();
                // r["AMOUNT_RECEIVED"] = pndng;
                r["DEPARTURE_TIME"] = guestinfo.Rows[i]["ARRIVAL_TIME"].ToString();
                d.Rows.Add(r);
            }

            guestlist.ItemsSource = guestinfo.DefaultView;
            DataTable S = db.jan();
            if (S.Rows.Count == 0)
            {
                JAN = 0;
            }
            else
            {
                JAN = db.JAN;

            }
            DataTable SR = db.feb();
            if (SR.Rows.Count == 0)
            {
                FEB = 0;
            }
            else
            {
                FEB = db.FEB;

            }
            DataTable SRI = db.mar();
            if (SRI.Rows.Count == 0)
            {
                MAR = 0;
            }
            else
            {
                MAR = db.MAR;

            }
            DataTable SRIK = db.apr();
            if (SRIK.Rows.Count == 0)
            {
                APR = 0;
            }
            else
            {
                APR = db.APR;

            }
            DataTable SRIKA = db.may();
            if (SRIKA.Rows.Count == 0)
            {
                MAY = 0;
            }
            else
            {
                MAY = db.MAY;

            }
            DataTable SRIKAR = db.june();
            if (SRIKAR.Rows.Count == 0)
            {
                JUNE = 0;
            }
            else
            {
                JUNE = db.JUNE;

            }
            DataTable SRIKAR1 = db.july();
            if (SRIKAR1.Rows.Count == 0)
            {
                JULY = 0;
            }
            else
            {
                JULY = db.JULY;

            }
            DataTable SRIKAR11 = db.aug();
            if (SRIKAR11.Rows.Count == 0)
            {
                AUG = 0;
            }
            else
            {
                AUG = db.AUG;

            }
            DataTable SRIKAR112 = db.sep();
            if (SRIKAR112.Rows.Count == 0)
            {
                SEP = 0;
            }
            else
            {
                SEP = db.SEP;

            }
            DataTable SRIKAR113 = db.oct();
            if (SRIKAR113.Rows.Count == 0)
            {
                OCT = 0;
            }
            else
            {
                OCT = db.OCT;

            }
            DataTable SRIKAR114 = db.nov();
            if (SRIKAR114.Rows.Count == 0)
            {
                NOV = 0;
            }
            else
            {
                NOV = db.NOV;

            }
            DataTable SRIKAR115 = db.dec();
            if (SRIKAR115.Rows.Count == 0)
            {

                DEC = 0;
            }
            else
            {
                DEC = db.DEC;
            }
            DataTable SRIKAR9 = db.SRI();
            if (SRIKAR9.Rows.Count == 0)
            {

                SRIKAR245 = 0;
            }
            else
            {
                SRIKAR245 = db.SRIKAR245;
                txtforentoffice.Text = db.SRIKAR245.ToString();
            }

            DataTable dpending = db.pendingonboard();
            if (dpending.Rows.Count == 0)
            {

                pending = 0;
            }
            else
            {
                pending = db.pending;
                PENDINGONBOARD.Text = db.pending.ToString();
            }
            DataTable ccharges = db.charges();
            if (ccharges.Rows.Count == 0)
            {
                charge = 0;
            }
            else
            {
                charge = db.charge;
                POSTCHRGES.Text = db.charge.ToString();
            }
        }
        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (TAX.Text == "January")
            {
                DataTable s = db.JANUARY();
                jan = db.jan1;
                
                taxcode.ItemsSource = s.DefaultView;
            }
            else if (TAX.Text == "February")
            {
                DataTable s = db.FEBRUARY();
                    feb = db.feb1;
                taxcode.ItemsSource = s.DefaultView;
            }
            else if (TAX.Text == "March")
            {
                DataTable s = db.march();
                mar = db.mar1;
                taxcode.ItemsSource = s.DefaultView;
            }
            else if (TAX.Text == "April")
            {
                DataTable s = db.APRIL();
                    apr = db.apr1;
                taxcode.ItemsSource = s.DefaultView;
            }
            else if (TAX.Text == "May")
            {
                DataTable s = db.MAYY();
                    may = db.may1;
                taxcode.ItemsSource = s.DefaultView;
            }
            else if (TAX.Text == "June")
            {
                DataTable s = db.JUN();
                    june = db.june1;
                taxcode.ItemsSource = s.DefaultView;
            }
            else if (TAX.Text == "July")
            {
                DataTable s = db.JUL();
                    july = db.july1;
                taxcode.ItemsSource = s.DefaultView;
            }
            else if (TAX.Text == "August")
            {
                DataTable s = db.AUGEST();
                    aug = db.aug1;
                taxcode.ItemsSource = s.DefaultView;
            }
            else if (TAX.Text == "September")
            {
                DataTable s = db.SEPTE();
                    sep = db.sep1;
                
                taxcode.ItemsSource = s.DefaultView;
            }
            else if (TAX.Text == "October")
            {
                DataTable s = db.OCTOB();
                
                    oct = db.oct1;
                
                taxcode.ItemsSource = s.DefaultView;
            }
            else if (TAX.Text == "November")
            {
                DataTable s = db.NOVEM();
             
                    nov = db.nov1;
                
                taxcode.ItemsSource = s.DefaultView;
            }
            else if (TAX.Text == "December")
            {
                DataTable s = db.DECM();
                    dec = db.dec1;
                taxcode.ItemsSource = s.DefaultView;
            }
        }

        public string pndng;
        public decimal pending;
        public decimal charge;
        

        //private void LoadPieChartData()
        //{
        //    ((PieSeries)mcChart.Series[0]).ItemsSource =
        //        new KeyValuePair<string, decimal>[]{
        //    new KeyValuePair<string, decimal>("Paidouts", paidoutstotalcount),
        //    new KeyValuePair<string, decimal>("Miscellenous", miscellenoustotalcount),
        //    new KeyValuePair<string, decimal>("Discount", discounttotalcount),
        //    new KeyValuePair<string, decimal>("Checkin", checkintotalcount),
        //    new KeyValuePair<string, decimal>("Postcharges", postchargestotalcount),

        //};

        //    ((ColumnSeries)mcBar.Series[0]).ItemsSource =
        //        new KeyValuePair<string, decimal>[]{
        //    new KeyValuePair<string, decimal>("Jan",JAN),
        //    new KeyValuePair<string, decimal>("Feb",FEB),
        //    new KeyValuePair<string, decimal>("Mar", MAR),
        //    new KeyValuePair<string, decimal>("Apr", APR),
        //    new KeyValuePair<string, decimal>("May", MAY),
        //    new KeyValuePair<string, decimal>("Jun", JUNE),
        //    new KeyValuePair<string, decimal>("Jul", JULY),
        //    new KeyValuePair<string, decimal>("Aug", AUG),
        //    new KeyValuePair<string, decimal>("Sep", SEP),
        //    new KeyValuePair<string, decimal>("Oct", OCT),
        //    new KeyValuePair<string, decimal>("Nov", NOV),
        //    new KeyValuePair<string, decimal>("Dec", DEC) };
        //}
        public decimal JAN, FEB, MAR, APR, MAY, JUNE, JULY, AUG, SEP, OCT, NOV, DEC, SRIKAR245;

    }

}
