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
using HMS.Model.Others;
using VELROOMS.mainwindowpages;

namespace HMS.mainwindowpages
{
    /// <summary>
    /// Interaction logic for DB.xaml
    /// </summary>
    public partial class DB : Page
    {

        db cs = new db();
        public static string FIRSTNAME, ARRIVAL_DATE, DEPARTURE_DATE, tarrif, advance, blnc,aa;
        public static int ROOM_NO,STAY_DAYS;
        public static string time;
        public static decimal a, a1, b, b1, a2, b2, c=0;
        public static decimal CHARGED_TARRIF, BALANCE, AMOUNT_RECEIVED, POSTCHARGES;
        ListView listrem = new ListView();
        public DB()
        {
            InitializeComponent();
            time =DateTime.Today.TimeOfDay.Ticks.ToString();
            DataTable advcount = cs.advance();
            if (advcount.Rows.Count == 0)
            {
                lbladv.Content = "0.00";
            }
            else
            {
                lbladv.Content = cs.advtotal;
            }

            DataTable porcount = cs.Charged();
            if (porcount.Rows.Count == 0)
            {
                lblcharge.Content = "0.00";
            }
            else
            {
                lblcharge.Content = cs.porctotal;
            }
            DataTable tarcount = cs.Tariff();
            if (tarcount.Rows.Count == 0)
            {
                lblroom.Content = "0.00";
            }
            else
            {
                lblroom.Content = cs.tartotal;
            }
            DataTable ds = cs.Todaysale();
            if (ds.Rows.Count == 0)
            { }
            else
            {
                if (ds.Rows[0]["AMOUNT_RECEIVED"].ToString() == "0" || ds.Rows[0]["AMOUNT_RECEIVED"].ToString() == "")
                { }
                else
                {
                    a = Convert.ToDecimal(ds.Rows[0]["AMOUNT_RECEIVED"]);
                }
                if (ds.Rows[0]["POSTCHARGES"].ToString() == "0" || ds.Rows[0]["POSTCHARGES"].ToString() == "")
                { }
                else
                {
                    a1 = Convert.ToDecimal(ds.Rows[0]["POSTCHARGES"]);
                }
                if (ds.Rows[0]["PAIDOUT"].ToString() == "0" || ds.Rows[0]["PAIDOUT"].ToString() == "")
                { }
                else
                {
                    b = Convert.ToDecimal(ds.Rows[0]["PAIDOUT"]);
                }
                if (ds.Rows[0]["REFUND"].ToString() == "0" || ds.Rows[0]["REFUND"].ToString() == "")
                { }
                else
                {
                    b1 = Convert.ToDecimal(ds.Rows[0]["REFUND"]);
                }
                a2 = a + a1;
                b2 = b + b1;
                c = a2 - b2;
                lblsale.Content = c;
            }
            DataTable CHECK = cs.CHECKINS();
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("ROOM_NO", typeof(int));
            dt1.Columns.Add("FIRSTNAME", typeof(string));
            dt1.Columns.Add("ARRIVAL_DATE", typeof(string));
            dt1.Columns.Add("DEPARTURE_DATE", typeof(string));
            dt1.Columns.Add("CHARGED_TARRIF", typeof(decimal));
            dt1.Columns.Add("AMOUNT_RECEIVED", typeof(decimal));
            dt1.Columns.Add("BALANCE", typeof(decimal));
            dt1.Columns.Add("STAY_DAYS", typeof(int));
            dt1.Columns.Add("POSTCHARGES", typeof(decimal));
            for (int i = 0; i < CHECK.Rows.Count; i++)
            {
                ROOM_NO = Convert.ToInt32(CHECK.Rows[i]["ROOM_NO"]);
                FIRSTNAME = CHECK.Rows[i]["FIRSTNAME"].ToString();
                ARRIVAL_DATE = (CHECK.Rows[i]["ARRIVAL_DATE"]).ToString();
                DEPARTURE_DATE = (CHECK.Rows[i]["DEPARTURE_DATE"]).ToString();
                STAY_DAYS = Convert.ToInt32(CHECK.Rows[i]["STAY_DAYS"]);
                decimal tarrif = Convert.ToDecimal(CHECK.Rows[i]["CHARGED_TARRIF"]);
                CHARGED_TARRIF = tarrif * STAY_DAYS;
                if (CHECK.Rows[i]["POSTCHARGES"].ToString() == "" || CHECK.Rows[i]["POSTCHARGES"].ToString() == "0")
                {
                    decimal PC =Convert.ToDecimal(0.00);
                }
                else
                {
                    POSTCHARGES = Convert.ToDecimal(CHECK.Rows[i]["POSTCHARGES"]);
                    CHARGED_TARRIF = Convert.ToDecimal(CHECK.Rows[i]["CHARGED_TARRIF"]) + POSTCHARGES;
                }
                if (CHECK.Rows[i]["AMOUNT_RECEIVED"].ToString() == "" || CHECK.Rows[i]["AMOUNT_RECEIVED"].ToString() == "0")
                {
                    amount = Convert.ToDecimal(0.00);
                    AMOUNT_RECEIVED = Convert.ToDecimal(Math.Round(amount, 2, MidpointRounding.AwayFromZero));
                }
                else
                {
                    AMOUNT_RECEIVED = Convert.ToDecimal(CHECK.Rows[i]["AMOUNT_RECEIVED"]);
                }
                BALANCE = Convert.ToDecimal(CHARGED_TARRIF - AMOUNT_RECEIVED);
                DataRow row = dt1.NewRow();
                row["ROOM_NO"] = ROOM_NO;
                row["FIRSTNAME"] = FIRSTNAME;
                row["ARRIVAL_DATE"] = ARRIVAL_DATE;
                row["DEPARTURE_DATE"] = DEPARTURE_DATE;
                row["CHARGED_TARRIF"] = CHARGED_TARRIF;
                row["AMOUNT_RECEIVED"] = AMOUNT_RECEIVED;
                row["BALANCE"] = BALANCE;
                row["STAY_DAYS"] = STAY_DAYS;
                dt1.Rows.Add(row);
            }
            LISTCHECK.ItemsSource = dt1.DefaultView;
            label();
            DataTable dt = cs.RESERVCHECKOUT();
            listrem1.ItemsSource = dt.DefaultView;
            LoadPieChartData();
        }
        public void label()
        {
            WrapPanel wp = new WrapPanel();
            DataTable dt = cs.RESERVCHECKOUT();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Label lbl = new Label();
                lbl.Width = 5;
                lbl.Height = 19;
                string len = dt.Rows[i]["ROOM_NO"].ToString();
                if (len.Length == 3)
                {
                    lbl.Background = Brushes.Red;
                }
                else
                {
                    lbl.Background = Brushes.Green;
                }
                lbl.Margin = new System.Windows.Thickness(0, 15, 0, 5);
                wp.Orientation = Orientation.Vertical;
                wp.Children.Add(lbl);
            }
            wrap.Children.Add(wp);
        }
        public static string type, percent;
        public static decimal amount;
        private void LoadPieChartData()
        {
            List<KeyValuePair<string, string>> ValueList = new List<KeyValuePair<string, string>>();
            DataTable dt = cs.ROOMCAT();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                type = dt.Rows[i]["ROOM_CATEGORY"].ToString();

                if (dt.Rows[i]["COUNT"].ToString() == "")
                {
                    percent = "0";
                }
                else
                {
                    percent = dt.Rows[i]["COUNT"].ToString();

                }
                ValueList.Add(new KeyValuePair<string, string>(type, percent));
               
            }
            
            pieChart.DataContext = ValueList;
        }

    }
}
