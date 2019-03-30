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
    /// Interaction logic for CancelledReservations.xaml
    /// </summary>
    public partial class CancelledReservations : Page
    {
        public CancelledReservations()
        {
            InitializeComponent();
            txtdate.DisplayDateEnd = DateTime.Today.Date;
        }
        Report rp = new Report();
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (txtdate.Text == "" || txtdate.Text == null)
            {
                MessageBox.Show("Please select Date");
            }
            else
            {
                rp.Canceldate = txtdate.Text;
                DataTable dr = rp.Cancelreservation2();
                if (dr.Rows.Count == 0)
                {
                    MessageBox.Show("There is No Data (Unable to Print Report)");
                }
                else
                {
                    ReportDocument re = new ReportDocument();
                    DataTable d1 = report();
                    re.Load("../../Reports/ReservationCancel2.rpt");
                    DataTable d = report1();
                    re.Load("../../Reports/ReservationCancel1.rpt");
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
            d.Columns.Add("GstNo", typeof(string));
            d.Columns.Add("Date", typeof(DateTime));
            DataRow row = d.NewRow();
            rp.Cancelreservation1();
            row["Hotel"] = Report.Hotel;
            row["HotelAddress"] = Report.HotelAddress;
            row["GstNo"] = Report.GST;
            row["Date"] = rp.Canceldate;
            d.Rows.Add(row);
            return d;
        }
        private DataTable report()
        {
            DataTable D = new DataTable();
            D.Columns.Add("Booking Cancellation ID", typeof(int));
            D.Columns.Add("Booking ID", typeof(int));
            D.Columns.Add("Name", typeof(string));
            D.Columns.Add("Mobile No", typeof(string));
            D.Columns.Add("Booked Date", typeof(DateTime));
            D.Columns.Add("User", typeof(string));

            DataTable d = rp.Cancelreservation2();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D.NewRow();
                r["Booking Cancellation ID"] = d.Rows[i]["CANCEL_ID"];
                r["Booking ID"] = d.Rows[i]["RESERVATION_ID"];
                r["Name"] = d.Rows[i]["GUESTNAME"];
                r["Mobile No"] = d.Rows[i]["MOBILE_NO"];
                r["Booked Date"] = d.Rows[i]["INSERT_DATE"];
                r["User"] = d.Rows[i]["INSERT_BY"];
                D.Rows.Add(r);
            }
            return D;
        }
    }
}
