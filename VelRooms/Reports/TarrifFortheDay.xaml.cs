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
    /// Interaction logic for TarrifFortheDay.xaml
    /// </summary>
    public partial class TarrifFortheDay : Page
    {
        public TarrifFortheDay()
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
                DataTable dr = repor.TarrifPostedDay();
                if (dr.Rows.Count == 0)
                {
                    MessageBox.Show("There is No Data (Unable to Print Report)");
                }
                else
                {
                    repor.tarrifposteddate = todate.Text;
                    ReportDocument re = new ReportDocument();
                    DataTable d = report1();
                    DataTable d1 = report();
                    re.Load("../../Reports/TarrifPostedFortheDay1.rpt");
                    re.Load("../../Reports/TarrifPostedFortheDay.rpt");
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
            D.Columns.Add("Room_No", typeof(int));
            D.Columns.Add("Guest_Name", typeof(string));
            D.Columns.Add("Category", typeof(string));
            D.Columns.Add("Tarrif", typeof(decimal));
            D.Columns.Add("Tax", typeof(string));
            D.Columns.Add("GstAmount", typeof(decimal));
            DataTable d = repor.TarrifPostedDay();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D.NewRow();
                r["Room_No"] = d.Rows[i]["ROOM_NO"];
                r["Guest_Name"] = d.Rows[i]["GUESTNAME"];
                r["Category"] = d.Rows[i]["CATEGORY"];
                r["Tarrif"] = d.Rows[i]["TARRIF"];
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
            row["Date"] = repor.tarrifposteddate;
            d.Rows.Add(row);
            return d;
        }

        //private void Close_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}