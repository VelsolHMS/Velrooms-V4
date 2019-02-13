using CrystalDecisions.CrystalReports.Engine;
using HMS.Model.Others;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace HMS.Reports
{
    /// <summary>
    /// Interaction logic for DiscountDateWise.xaml
    /// </summary>
    public partial class DiscountDateWise : Page
    {
        public DiscountDateWise()
        {
            InitializeComponent();
            txtdate.DisplayDateEnd = DateTime.Today.Date;
        }
        Report repor = new Report();
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if(txtdate.Text == "")
            {
                MessageBox.Show("Please select the date");
            }
            else
            {
                DataTable dr = repor.DiscountDateWise();
                if (dr.Rows.Count == 0)
                {
                    MessageBox.Show("There is No Data (Unable to Print Report)");
                }
                else
                {
                    repor.Discountdaywisedate = txtdate.Text;
                    ReportDocument re = new ReportDocument();
                    DataTable d = report1();
                    re.Load("../../Reports/DiscountDateWiseReport1.rpt");
                    DataTable dd = report();
                    re.Load("../../Reports/DiscountDateWiseReport.rpt");
                    re.Subreports[0].SetDataSource(d);
                    re.SetDataSource(dd);
                    re.PrintToPrinter(1, false, 0, 0);
                    re.Refresh();
                }
            }
        }
        public DataTable report()
        {
            DataTable dd = new DataTable();
            dd.Columns.Add("Name", typeof(string));
            dd.Columns.Add("Address", typeof(string));
            dd.Columns.Add("Gst", typeof(string));
            dd.Columns.Add("SelectedDate", typeof(DateTime));
            DataRow row = dd.NewRow();
            repor.Address();
            row["Name"]= Report.Name;
            row["Address"] = Report.Address1;
            row["Gst"] = Report.Gst;
            row["SelectedDate"] = repor.Discountdaywisedate;
            dd.Rows.Add(row);
            return dd;
        }
        public DataTable report1()
        {
            DataTable d = new DataTable();
            d.Columns.Add("Checkin_id",typeof(int));
            d.Columns.Add("RoomNo", typeof(int));
            d.Columns.Add("ResNo",typeof(int));
            d.Columns.Add("GuestName", typeof(string));
            d.Columns.Add("MobileNo",typeof(Int64));
            d.Columns.Add("Category",typeof(string));
            d.Columns.Add("Tarrif",typeof(decimal));
            d.Columns.Add("Days",typeof(int));
            d.Columns.Add("Discount",typeof(decimal));
            d.Columns.Add("Total",typeof(decimal));
            DataTable DD= repor.DiscountDateWise();
            for(int i = 0; i < DD.Rows.Count; i++)
            {
                DataRow r = d.NewRow();
                r["Checkin_id"] = DD.Rows[i]["CHECKIN_ID"];
                r["RoomNo"] = DD.Rows[i]["ROOM_NO"];
                r["ResNo"] = DD.Rows[i]["RESERVATION_NO"];
                r["GuestName"] = DD.Rows[i]["GUEST_NAME"];
                r["MobileNo"] = DD.Rows[i]["MOBILENO"];
                r["Category"] = DD.Rows[i]["CATEGORY"];
                r["Tarrif"] = DD.Rows[i]["TARRIF"];
                r["Days"] = DD.Rows[i]["STAYDAYS"];
                r["Discount"] = DD.Rows[i]["AMOUNT"];
                r["Total"] = DD.Rows[i]["DISCOUNTTOTAL"];
                d.Rows.Add(r);
            }
            return d;
        }
    }
}
