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
    /// Interaction logic for ReservationList.xaml
    /// </summary>
    public partial class ReservationList : Page
    {
        public ReservationList()
        {
            InitializeComponent();
            txtdate.DisplayDateEnd = DateTime.Today.Date;
        }
        Report rp = new Report();
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if(txtdate.Text == "" || txtdate.Text == null)
            {
                MessageBox.Show("Please Select Date");
            }
            else
            {
                DataTable dr = rp.Reservlist2();
                if (dr.Rows.Count == 0)
                {
                    MessageBox.Show("There is No Data (Unable to Print Report)");
                }
                else
                {
                    rp.ReservDate = txtdate.Text;
                    ReportDocument re = new ReportDocument();
                    DataTable d1 = report();
                    re.Load("../../Reports/Reservationlist2.rpt");
                    DataTable d = report1();
                    re.Load("../../Reports/Reservationlist1.rpt");
                    re.Subreports[0].SetDataSource(d1);
                    re.SetDataSource(d);
                    re.PrintToPrinter(1, false, 0, 0);
                    re.Refresh();
                }
            }
        }
        private DataTable report1()
        {
            DataTable d = new DataTable();
            d.Columns.Add("Hotel", typeof(string));
            d.Columns.Add("HotelAddress", typeof(string));
            d.Columns.Add("GST", typeof(string));
            d.Columns.Add("Date", typeof(DateTime));
            DataRow row = d.NewRow();
            rp.Reservlist1();
            row["Hotel"] = Report.Hotel;
            row["HotelAddress"] = Report.HotelAddress;
            row["GST"] = Report.GST;
            row["Date"] = rp.ReservDate;
            d.Rows.Add(row);
            return d;
        }
        private DataTable report()
        {
            DataTable D = new DataTable();
            D.Columns.Add("Booking ID", typeof(int));
            D.Columns.Add("Name", typeof(string));
            D.Columns.Add("Mobile No", typeof(string));
            D.Columns.Add("ID", typeof(string));
            D.Columns.Add("Checkin Date", typeof(string));
            D.Columns.Add("ROOMS", typeof(int));
            D.Columns.Add("PAX", typeof(int));
            D.Columns.Add("Checkout Date", typeof(string));
            D.Columns.Add("Stay Days", typeof(Int64));
            D.Columns.Add("User", typeof(string));

            DataTable d = rp.Reservlist2();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D.NewRow();
                r["Booking ID"] = d.Rows[i]["RESERVATION_ID"];
                r["Name"] = d.Rows[i]["FIRSTNAME"];
                r["Mobile No"] = d.Rows[i]["MOBILE_NO"];
                r["ID"] = d.Rows[i]["ID"];
                r["Checkin Date"] = d.Rows[i]["ARRIVAL"];
                r["ROOMS"] = d.Rows[i]["NO_OF_ROOMS"];
                r["PAX"] = d.Rows[i]["PAX"];
                r["Checkout Date"] = d.Rows[i]["DEPARTURE"];
                r["Stay Days"] = d.Rows[i]["DAYS"];
                r["User"] = d.Rows[i]["INSERT_BY"];
                D.Rows.Add(r);
            }
            return D;
        }
    }
}
