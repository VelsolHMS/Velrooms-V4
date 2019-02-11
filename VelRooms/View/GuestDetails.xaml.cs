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

namespace HMS.View
{
    /// <summary>
    /// Interaction logic for GuestDetails.xaml
    /// </summary>
    public partial class GuestDetails : Page
    {
        public GuestDetails()
        {
            InitializeComponent();
        }
        Report r = new Report();
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Home());
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            r.Fmdate = fromdate.Text;
            r.Todate = todate.Text;
            ReportDocument re = new ReportDocument();
            DataTable Da = report1();
            re.Load("../../Guestdetails.rpt");
            DataTable Da1 = report();
            re.Load("../../GuestdetailsReport1.rpt");
            re.Subreports[0].SetDataSource(Da);
            re.SetDataSource(Da1);
            re.PrintToPrinter(1, false, 0, 0);
            re.Refresh();
        }

        public DataTable report()
        {
            DataTable d = new DataTable();
            d.Columns.Add("Name", typeof(string));
            d.Columns.Add("Address",typeof(string));
            d.Columns.Add("Gst", typeof(string));
           // d.Columns.Add("Date", typeof(DateTime));
           // d.Columns.Add("GuestName", typeof(string));
           // d.Columns.Add("mobile", typeof(Int64));
            //d.Columns.Add("email", typeof(string));
           // DataTable d1=r.guestdetails();
            r.Address();
           // for (int i = 0; i < d1.Rows.Count; i++)
           // {
                DataRow row = d.NewRow();
                row["Name"] =Report.Name;
                row["Address"] =Report.Address1;
                row["Gst"] =Report.Gst;
               // row["Date"] =d1.Rows[i]["ARRIVAL_DATE"];
               // row["GuestName"] = d1.Rows[i]["FIRSTNAME"];
               // row["mobile"] = d1.Rows[i]["MOBILE_NO"];
              //  row["email"] = d1.Rows[i]["EMAIL"];
                d.Rows.Add(row);
            //}
            return d;
        }

        public DataTable report1()
        {
            DataTable d = new DataTable();
            d.Columns.Add("Date", typeof(DateTime));
            d.Columns.Add("GuestName", typeof(string));
            d.Columns.Add("mobile", typeof(Int64));
            d.Columns.Add("email", typeof(string));
            DataTable d1 = r.guestdetails();
            r.Address();
            for (int i = 0; i < d1.Rows.Count; i++)
            {
                DataRow row = d.NewRow();
                //row["Name"] = Report.Name;
                //row["Address"] = Report.Address1;
                //row["Gst"] = Report.Gst;
                row["Date"] = d1.Rows[i]["ARRIVAL_DATE"];
                row["GuestName"] = d1.Rows[i]["FIRSTNAME"];
                row["mobile"] = d1.Rows[i]["MOBILE_NO"];
                row["email"] = d1.Rows[i]["EMAIL"];
                d.Rows.Add(row);
            }
            return d;
        }
    }
}
