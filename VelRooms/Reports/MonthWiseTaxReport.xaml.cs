using CrystalDecisions.CrystalReports.Engine;
using HMS.Model.Others;
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

namespace HMS.Reports
{
    /// <summary>
    /// Interaction logic for MonthWiseTaxReport.xaml
    /// </summary>
    public partial class MonthWiseTaxReport : Page
    {
        Report rep = new Report();
        public MonthWiseTaxReport()
        {
            InitializeComponent();
            fromdate.DisplayDateEnd = DateTime.Today.Date;
            todate.DisplayDateEnd = DateTime.Today.Date;
        }
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if(fromdate.Text == "" || todate.Text == null)
            {
                MessageBox.Show("Please select Date");
            }
            else
            {
                ReportDocument re = new ReportDocument();
                DataTable d1 = report();
                re.Load("../../Reports/TaxMonthReport1.rpt");
                DataTable d = report1();
                re.Load("../../Reports/TaxMonthReport.rpt");
                re.Subreports[0].SetDataSource(d1);
                re.SetDataSource(d);
                re.PrintToPrinter(1, false, 0, 0);
                re.Refresh();
            }
        }
        public static string fd, td;
        private DataTable report1()
        {
            fd = fromdate.Text;
            td = todate.Text;
            DataTable d = new DataTable();
            d.Columns.Add("Name", typeof(string));
            d.Columns.Add("Address", typeof(string));
            d.Columns.Add("Gst", typeof(string));
            d.Columns.Add("FromDate", typeof(DateTime));
            d.Columns.Add("ToDate", typeof(DateTime));
            DataRow row = d.NewRow();
            rep.Address();
            row["Name"] = Report.Name;
            row["Address"] = Report.Address1;
            row["Gst"] = Report.Gst;
            row["FromDate"] = fromdate.Text;
            row["ToDate"] = todate.Text;
            d.Rows.Add(row);
            return d;
        }
        private DataTable report()
        {
            DataTable D = new DataTable();
            D.Columns.Add("RoomNo", typeof(int));
            D.Columns.Add("GuestName", typeof(string));
            D.Columns.Add("Contact", typeof(Int64));
            D.Columns.Add("StayDays", typeof(string));
            D.Columns.Add("RoomCategory", typeof(string));
            D.Columns.Add("RoomTariff", typeof(string));
            D.Columns.Add("Tax", typeof(string));

            DataTable d = rep.monthwisetax();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D.NewRow();
                r["RoomNo"] = d.Rows[i]["ROOM_NO"];
                r["GuestName"] = d.Rows[i]["FIRSTNAME"];
                r["Contact"] = d.Rows[i]["MOBILE_NO"];
                r["StayDays"] = d.Rows[i]["STAY_DAYS"];
                r["RoomCategory"] = d.Rows[i]["ROOM_CATEGORY"];
                r["RoomTariff"] = d.Rows[i]["ROOM_TARRIF"];
                r["Tax"] = d.Rows[i]["TAX"];
                D.Rows.Add(r);
            }
            return D;
        }
    }
}