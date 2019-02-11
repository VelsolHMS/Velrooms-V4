using HMS.Model.Others;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using CrystalDecisions.CrystalReports.Engine;

namespace HMS.View
{
    /// <summary>
    /// Interaction logic for frontoffice.xaml
    /// </summary>
    public partial class frontoffice : Page
    {
        Report r = new Report();
        public frontoffice()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if(todate.Text == "" || todate.Text == null)
            {
                MessageBox.Show("Please select Date");
            }
            else
            {
                r.forentofficedate = todate.Text;
                ReportDocument re = new ReportDocument();
                DataTable dt = forentofficereport();
                re.Load("../../frontofficereport.rpt");
                DataTable d = forentoffice();
                re.Load("../../forentooffice1.rpt");
                DataTable dd = forentoffice1();
                re.Load("../../froentoffice.rpt");
                re.Subreports[1].SetDataSource(dt);
                re.Subreports[0].SetDataSource(d);
                re.SetDataSource(dd);
                re.PrintToPrinter(0, false, 0, 0);
                re.Refresh();
                todate.Text = "";
            }
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Home());
        }
        public DataTable forentoffice()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SL.NO", typeof(int));
            dt.Columns.Add("RegNo", typeof(int));
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Time", typeof(DateTime));
            dt.Columns.Add("RoomNo", typeof(int));
            dt.Columns.Add("BillNo", typeof(int));
            dt.Columns.Add("GuestName", typeof(string));
            dt.Columns.Add("Typeofpay", typeof(string));
            dt.Columns.Add("User", typeof(string));
            dt.Columns.Add("Total", typeof(string));
            DataTable d = r.forentofficeadavance();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow row = dt.NewRow();
                row["SL.NO"] = i + 1;
                if (d.Rows[i]["RESERVATION_ID"].ToString() == "" || d.Rows[i]["RESERVATION_ID"].ToString() == "0")
                {
                    row["RegNo"] = 0;
                }
                else
                {
                    row["RegNo"] = d.Rows[i]["RESERVATION_ID"];
                }
                row["Date"] = d.Rows[i]["DATE"];
                row["Time"] = d.Rows[i]["TIME"];
                row["RoomNo"] = d.Rows[i]["ROOM_NO"];
                row["BillNo"] = d.Rows[i]["BILL"];
                row["GuestName"] = d.Rows[i]["GUESTNAME"];
                row["Typeofpay"] = d.Rows[i]["PAYTYPE"];
                row["User"] = d.Rows[i]["INSERT_BY"];
                row["Total"] = d.Rows[i]["AMOUNT_RECEIVED"];
                dt.Rows.Add(row);
            }
            return dt;
        }

        public DataTable forentoffice1()
        {
            DataTable dd = new DataTable();
            dd.Columns.Add("Name", typeof(string));
            dd.Columns.Add("Address", typeof(string));
            dd.Columns.Add("Gst", typeof(string));
            dd.Columns.Add("User", typeof(string));
            dd.Columns.Add("Cash1", typeof(string));
            dd.Columns.Add("Card", typeof(string));
            dd.Columns.Add("Total", typeof(string));
            dd.Columns.Add("GuestName", typeof(string));
            dd.Columns.Add("RoomNo", typeof(decimal));
            dd.Columns.Add("BillNo", typeof(decimal));
            dd.Columns.Add("Registrationno", typeof(decimal));
            dd.Columns.Add("Sl.no", typeof(decimal));
            dd.Columns.Add("OpeningBalance", typeof(decimal));
            dd.Columns.Add("Advance", typeof(decimal));
            dd.Columns.Add("RoomCollection", typeof(decimal));
            dd.Columns.Add("Othersmiss", typeof(decimal));
            dd.Columns.Add("PendingCollection", typeof(decimal));
            dd.Columns.Add("Cash", typeof(decimal));
            dd.Columns.Add("Cards", typeof(decimal));
            dd.Columns.Add("Cheque", typeof(decimal));
            dd.Columns.Add("Company", typeof(decimal));
            dd.Columns.Add("Typeofpay", typeof(decimal));
            DataRow row = dd.NewRow();
            r.Address();
            r.advancecash();
            r.advancecard();
            //r.advancecheque();
            r.froentcash();
            r.froentcard();
            r.froentcheque();
            row["Name"] = Report.Name;
            row["Address"] = Report.Address1;
            row["Gst"] = Report.Gst;
            row["Cash1"] = Report.Cash;
            row["Card"] = Report.card;
            decimal a = Report.Cash;
            decimal b = Report.card;
            decimal c = a + b;
            row["Total"] = c;
            long ssum = Convert.ToInt64(c);
            row["User"] = NumberToText(ssum);
            row["RoomNo"] = Report.c;
            row["BillNo"] = Report.cr;
            row["Registrationno"] = Report.ch;
            decimal cash = Report.c; decimal card = Report.cr; decimal cheque = Report.ch; decimal tot = cash + card + cheque;
            row["Sl.no"] = tot;
            long l = Convert.ToInt64(tot);
            row["GuestName"] = NumberToText(l);
            r.OPENING();
            row["OpeningBalance"] = Report.openingbalance;
            r.advance();
            row["Advance"] = Report.adv;
            r.Roomcollextion();
            row["RoomCollection"] = Report.ROOMCOLLECT;
            r.Miscellenous();
            row["Othersmiss"] = Report.MISCELL;
            r.pendingbill();
            row["PendingCollection"] = Report.PENDINGBILL;
            r.totalcash();
            row["Cash"] = Report.totalcash1;
            r.totalcard();
            row["Cards"] = Report.totalcard1;
            r.totalcheque();
            row["Cheque"] = Report.totalcheque1;
            row["Company"] = 0.00;
            decimal totca = Report.totalcash1, totcr = Report.totalcard1, totch = Report.totalcheque1;
            row["Typeofpay"] = totca;
            dd.Rows.Add(row);
            return dd;
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

        public DataTable forentofficereport()
        {
            DataTable D = new DataTable();
            D.Columns.Add("Sl.No", typeof(int));
            D.Columns.Add("RegNo", typeof(int));
            D.Columns.Add("Date", typeof(DateTime));
            D.Columns.Add("Time", typeof(DateTime));
            D.Columns.Add("RoomNo", typeof(int));
            D.Columns.Add("BillNo", typeof(int));
            D.Columns.Add("GuestName", typeof(string));
            D.Columns.Add("Typeofpay", typeof(string));
            D.Columns.Add("User", typeof(string));
            D.Columns.Add("Summary", typeof(string));
            D.Columns.Add("Cash", typeof(decimal));
            D.Columns.Add("Card", typeof(decimal));
            D.Columns.Add("Total", typeof(string));
            DataTable dt = r.froentsettle();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = D.NewRow();
                row["Sl.No"] = i + 1;
                row["RegNo"] = dt.Rows[i]["RES_NO"];
                row["Date"] = dt.Rows[i]["DATE"];
                row["Time"] = dt.Rows[i]["TIME"];
                row["RoomNo"] = dt.Rows[i]["ROOM_NO"];
                row["BillNo"] = dt.Rows[i]["BILL_NO"];
                row["GuestName"] = dt.Rows[i]["GUEST_NAME"];
                row["Typeofpay"] = dt.Rows[i]["PAYMODE"];
                row["User"] = dt.Rows[i]["INSERT_BY"];
                row["Total"] = dt.Rows[i]["AMOUNT"];
                D.Rows.Add(row);
            }
            return D;
        }
    }
}
