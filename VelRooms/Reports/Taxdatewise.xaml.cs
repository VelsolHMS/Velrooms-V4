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
    /// Interaction logic for Taxdatewise.xaml
    /// </summary>
    public partial class Taxdatewise : Page
    {
        public Taxdatewise()
        {
            InitializeComponent();
            todate.DisplayDateEnd = DateTime.Today.Date;
        }
        Report repor = new Report();
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if(todate.Text == "" || todate.Text == null)
            {
                MessageBox.Show("Please select Date");
            }
            else
            {
                repor.datetax = todate.Text;
                DataTable dr = repor.datewisetax();
                if (dr.Rows.Count == 0)
                {
                    MessageBox.Show("There is No Data (Unable to Print Report)");
                }
                else
                {
                    ReportDocument re = new ReportDocument();
                    DataTable d = report1();
                    DataTable d1 = report();
                    //re.Load("../../Reports/Daywisetax1.rpt");
                    //re.Load("../../HOTELINFORMATION.rpt");
                    re.Load("../../Reports/Daywisetax1.rpt");
                    re.Load("../../Reports/DateWisetaxreport.rpt");
                    re.Subreports[0].SetDataSource(d1);
                    re.SetDataSource(d);
                    re.PrintToPrinter(1, false, 0, 0);
                    re.Refresh();
                }
            }
        }
        public DataTable report()
        {
            DataTable D = new DataTable();
            D.Columns.Add("RoomNo", typeof(int));
            D.Columns.Add("GuestName", typeof(string));
            D.Columns.Add("MobileNo", typeof(string));
            D.Columns.Add("StayDays", typeof(int));
            D.Columns.Add("Category", typeof(string));
            D.Columns.Add("Tarrif", typeof(string));
            D.Columns.Add("Tax", typeof(string));
            D.Columns.Add("GstAmount", typeof(decimal));
            DataTable d = repor.datewisetax();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D.NewRow();
                r["RoomNo"] = d.Rows[i]["ROOM_NO"];
                r["GuestName"] = d.Rows[i]["FIRSTNAME"];
                r["MobileNo"] = d.Rows[i]["MOBILE_NO"];
                r["StayDays"] = d.Rows[i]["STAY_DAYS"];
                r["Category"] = d.Rows[i]["ROOM_CATEGORY"];
                r["Tarrif"] = Math.Round(Convert.ToDecimal(d.Rows[i]["ROOM_TARRIF"]),2,MidpointRounding.AwayFromZero).ToString();
                r["Tax"] = d.Rows[i]["GST"];
                r["GstAmount"] = d.Rows[i]["GSTAMOUNT"];
                D.Rows.Add(r);
            }
            return D;
        }
        public DataTable report1()
        {
            DataTable d = new DataTable();
            d.Columns.Add("Name", typeof(string));
            d.Columns.Add("Address", typeof(string));
            d.Columns.Add("Gst", typeof(string));
            d.Columns.Add("Date", typeof(DateTime));
            DataRow row = d.NewRow();
            repor.Address();
            row["Name"] = Report.Name;
            row["Address"] = Report.Address1;
            row["Gst"] = Report.Gst;
            row["Date"] = repor.datetax;
            d.Rows.Add(row);
            return d;
        }

        //private void Close_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
