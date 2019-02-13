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
using CrystalDecisions.CrystalReports.Engine;
using HMS.Model.Others;
using System.Data;

namespace HMS.Reports
{
    /// <summary>
    /// Interaction logic for TodayBookings.xaml
    /// </summary>
    public partial class TodayBookings : Page
    {
        Report rp = new Report();
        public TodayBookings()
        {
            InitializeComponent();
            DataTable dr = rp.TodayBookings2();
            if (dr.Rows.Count == 0)
            {
                MessageBox.Show("There is No Data (Unable to Print Report)");
            }
            else
            {
                ReportDocument re = new ReportDocument();
                DataTable d1 = report();
                re.Load("../../Reports/TodayBookings2.rpt");
                DataTable d = report1();
                re.Load("../../Reports/TodayBookings1.rpt");
                re.Subreports[0].SetDataSource(d1);
                re.SetDataSource(d);
                re.PrintToPrinter(1, false, 0, 0);
                re.Refresh();
            }
        }
        private DataTable report1()
        {
            DataTable d = new DataTable();
            d.Columns.Add("Hotel", typeof(string));
            d.Columns.Add("HotelAddress", typeof(string));
            d.Columns.Add("GstNo", typeof(string));
            DataRow row = d.NewRow();
            rp.TodayBookings1();
            row["Hotel"] = Report.Hotel;
            row["HotelAddress"] = Report.HotelAddress;
            row["GstNo"] = Report.GST;
            d.Rows.Add(row);
            return d;
        }
        private DataTable report()
        {
            DataTable D = new DataTable();
            D.Columns.Add("Booking ID", typeof(int));
            D.Columns.Add("Name", typeof(string));
            D.Columns.Add("Mobile", typeof(string));
            D.Columns.Add("Checkin Date", typeof(string));
            D.Columns.Add("Rooms", typeof(int));
            D.Columns.Add("Pax", typeof(int));
            D.Columns.Add("Stay Days", typeof(int));
            D.Columns.Add("Advance", typeof(decimal));
            D.Columns.Add("User", typeof(string));

            DataTable d = rp.TodayBookings2();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D.NewRow();
                r["Booking ID"] = d.Rows[i]["RESERVATION_ID"];
                r["Name"] = d.Rows[i]["FIRSTNAME"];
                r["Mobile"] = d.Rows[i]["MOBILE_NO"];
                r["Checkin Date"] = d.Rows[i]["ARRIVAL"];
                r["Rooms"] = d.Rows[i]["NO_OF_ROOMS"];
                r["Pax"] = d.Rows[i]["PAX"];
                r["Stay Days"] = d.Rows[i]["DAYS"];
                r["Advance"] = d.Rows[i]["ADVANCEGIVEN"];
                r["User"] = d.Rows[i]["INSERT_BY"];
                D.Rows.Add(r);
            }
            return D;
        }
    }
}
