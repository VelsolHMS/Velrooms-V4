using CrystalDecisions.CrystalReports.Engine;
using HMS.Model.Others;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace HMS.View
{
    /// <summary>
    /// Interaction logic for Pendingbillreport.xaml
    /// </summary>
    public partial class Pendingbillreport : Page
    {
        public Pendingbillreport()
        {
            InitializeComponent();
        }
        Report r = new Report();
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            r.pendingfromdate = fromdate.Text;
            r.pendingtodate = todate.Text;
            ReportDocument re = new ReportDocument();
            DataTable n = report();
            re.Load("../../PENDINGBILLReport1.rpt");
            re.SetDataSource(n);
            re.PrintToPrinter(1, false, 0, 0);
            re.Refresh();
        }
        public DataTable report()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name",typeof(string));
            dt.Columns.Add("Address",typeof(string));
            dt.Columns.Add("Gst",typeof(string));
            dt.Columns.Add("Date",typeof(DateTime));
            dt.Columns.Add("Bill_No",typeof(int));
            dt.Columns.Add("GuestName",typeof(string));
            dt.Columns.Add("Phone",typeof(Int64));
            dt.Columns.Add("TotalAmount",typeof(decimal));
            dt.Columns.Add("BalanceAmount",typeof(decimal));
            DataTable dd = r.PENDINGBILLREPORT();
            r.Address();
            for (int i = 0; i < dd.Rows.Count; i++)
            {
                DataRow row = dt.NewRow();
                row["Name"] =Report.Name;
                row["Address"] =Report.Address1;
                row["Gst"] =Report.Gst;
                row["Date"] =dd.Rows[i]["INSERT_DATE"];
                row["Bill_No"] =dd.Rows[i]["BILL_NO"];
                row["GuestName"] =dd.Rows[i]["GUESTNAME"];
                row["Phone"] =dd.Rows[i]["MOBILENO"];
                row["TotalAmount"] =dd.Rows[i]["TOTAL"];
                row["BalanceAmount"] =dd.Rows[i]["BALANCE"];
                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}
