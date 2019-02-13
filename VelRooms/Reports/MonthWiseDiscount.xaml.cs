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
    /// Interaction logic for MonthWiseDiscount.xaml
    /// </summary>
    public partial class MonthWiseDiscount : Page
    {
        public decimal MonthlyDiscount = 0;
        public MonthWiseDiscount()
        {
            InitializeComponent();
            fromdate.DisplayDateEnd = DateTime.Today.Date;
            todate.DisplayDateEnd = DateTime.Today.Date;
        }
        Report rp = new Report();
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (fromdate.Text == "" && todate.Text == "")
            {
                MessageBox.Show("Please select Date");
            }
            else
            {
                DataTable dr = rp.MonthWiseDiscount2();
                if (dr.Rows.Count == 0)
                {
                    MessageBox.Show("There is No Data (Unable to Print Report)");
                }
                else
                {
                    rp.MWDFromDate = fromdate.Text;
                    rp.MWDToDate = todate.Text;
                    ReportDocument re = new ReportDocument();
                    DataTable d1 = report();
                    re.Load("../../Reports/MonthWiseDiscountSubReport.rpt");
                    DataTable d = report1();
                    re.Load("../../Reports/MonthWiseDiscountMainReport.rpt");
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
            d.Columns.Add("FromDate", typeof(DateTime));
            d.Columns.Add("ToDate", typeof(DateTime));
            d.Columns.Add("GrandTotal", typeof(decimal));
            DataRow row = d.NewRow();
            DataTable dg= rp.MonthWiseDiscount1();
            row["Hotel"] = dg.Rows[0]["Hotel"].ToString();
            row["HotelAddress"] = dg.Rows[0]["HotelAddress"].ToString();
            row["GstNo"] = dg.Rows[0]["GST"].ToString();
            row["FromDate"] = rp.MWDFromDate;
            row["ToDate"] = rp.MWDToDate;
            row["GrandTotal"] = MonthlyDiscount;
            d.Rows.Add(row);
            return d;
        }

        private DataTable report()
        {
            DataTable D = new DataTable();
            D.Columns.Add("Date", typeof(DateTime));
            D.Columns.Add("DiscountAmount", typeof(decimal));

            DataTable d = rp.MonthWiseDiscount2();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D.NewRow();
                r["Date"] = d.Rows[i]["INSERT_DATE"];
                r["DiscountAmount"] = d.Rows[i]["AMOUNT"];
                D.Rows.Add(r);
                if(d.Rows[i]["AMOUNT"].ToString() == null || d.Rows[i]["AMOUNT"].ToString() == "")
                {
                    MonthlyDiscount += 0;
                }
                else
                {
                    MonthlyDiscount += Convert.ToDecimal(d.Rows[i]["AMOUNT"]);
                }
            }
            return D;
        }
    }
}
