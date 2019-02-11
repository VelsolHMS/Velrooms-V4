using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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
    /// Interaction logic for MonthWiseGSTReport.xaml
    /// </summary>
    public partial class MonthWiseGSTReport : Page
    {
        Report rep = new Report();
        public MonthWiseGSTReport()
        {
            InitializeComponent();
            fromdate.DisplayDateEnd = DateTime.Today.Date;
            todate.DisplayDateEnd = DateTime.Today.Date;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if(fromdate.Text == "" || todate.Text == "")
            {
                MessageBox.Show("Please Select the Date");
            }
            else
            {
                rep.FromDate = fromdate.Text;
                rep.ToDate = todate.Text;
                ReportDocument re = new ReportDocument();
                DataTable d1 = report();
                re.Load("../../Reports/GstMonthSubreport.rpt");
                DataTable d = report1();
                re.Load("../../Reports/GstMonthReport.rpt");
                re.Subreports[0].SetDataSource(d1);
                re.SetDataSource(d);
                re.PrintToPrinter(1, false, 0, 0);
                re.Refresh();
            }
        }
        public static string fd, td;
        private DataTable report1()
        {
            DataTable d = new DataTable();
            d.Columns.Add("Name", typeof(string));
            d.Columns.Add("Address", typeof(string));
            d.Columns.Add("GstNo", typeof(string));
            d.Columns.Add("FromDate", typeof(DateTime));
            d.Columns.Add("ToDate", typeof(DateTime));
            d.Columns.Add("GstSlab1", typeof(string));
            d.Columns.Add("GstSlab2", typeof(string));
            d.Columns.Add("GstSlab3", typeof(string));
            d.Columns.Add("GstSlab4", typeof(string));
            d.Columns.Add("GstSlab5", typeof(string));
            d.Columns.Add("Slab1", typeof(string));
            d.Columns.Add("Slab2", typeof(string));
            d.Columns.Add("Slab3", typeof(string));
            d.Columns.Add("Slab4", typeof(string));
            d.Columns.Add("Slab5", typeof(string));

            DataTable DT = rep.TOTALGST();
            DataTable dt = rep.monthwisegst();
            DataTable dd = rep.taxcode();
            
            DataRow row = d.NewRow();
            rep.Address();
            row["Name"] = Report.Name;
            row["Address"] = Report.Address1;
            row["GstNo"] = Report.Gst;
            row["FromDate"] = fromdate.Text;
            row["ToDate"] = todate.Text;

            if(DT.Rows.Count == 0) { }
            else if(DT.Rows.Count == 1)
            {
                row["Slab1"] = dd.Rows[0]["TAX_CODE"].ToString();
                row["GstSlab1"] = Convert.ToDecimal(DT.Rows[0]["TOTALGST"].ToString() );
            }
            else if (DT.Rows.Count == 2)
            {
                row["Slab1"] = dd.Rows[0]["TAX_CODE"].ToString();
                row["Slab2"] = dd.Rows[1]["TAX_CODE"].ToString();
                row["GstSlab1"] = Convert.ToDecimal(DT.Rows[0]["TOTALGST"].ToString());
                row["GstSlab2"] = Convert.ToDecimal(DT.Rows[1]["TOTALGST"].ToString());
            }
            else if(DT.Rows.Count == 3)
            {
                row["Slab1"] = dd.Rows[0]["TAX_CODE"].ToString();
                row["Slab2"] = dd.Rows[1]["TAX_CODE"].ToString();
                row["Slab3"] = dd.Rows[2]["TAX_CODE"].ToString();
                row["GstSlab1"] = Convert.ToDecimal(DT.Rows[0]["TOTALGST"].ToString());
                row["GstSlab2"] = Convert.ToDecimal(DT.Rows[1]["TOTALGST"].ToString());
                row["GstSlab3"] = Convert.ToDecimal(DT.Rows[2]["TOTALGST"].ToString());
            }
            else if (DT.Rows.Count == 4)
            {
                row["Slab1"] = dd.Rows[0]["TAX_CODE"].ToString();
                row["Slab2"] = dd.Rows[1]["TAX_CODE"].ToString();
                row["Slab3"] = dd.Rows[2]["TAX_CODE"].ToString();
                row["Slab4"] = dd.Rows[3]["TAX_CODE"].ToString();
                row["GstSlab1"] = Convert.ToDecimal(DT.Rows[0]["TOTALGST"].ToString());
                row["GstSlab2"] = Convert.ToDecimal(DT.Rows[1]["TOTALGST"].ToString());
                row["GstSlab3"] = Convert.ToDecimal(DT.Rows[2]["TOTALGST"].ToString());
                row["GstSlab4"] = Convert.ToDecimal(DT.Rows[3]["TOTALGST"].ToString());
            }
            else if (DT.Rows.Count == 5)
            {
                row["Slab1"] = dd.Rows[0]["TAX_CODE"].ToString();
                row["Slab2"] = dd.Rows[1]["TAX_CODE"].ToString();
                row["Slab3"] = dd.Rows[2]["TAX_CODE"].ToString();
                row["Slab4"] = dd.Rows[3]["TAX_CODE"].ToString();
                row["Slab5"] = dd.Rows[4]["TAX_CODE"].ToString();
                row["GstSlab1"] = Convert.ToDecimal(DT.Rows[0]["TOTALGST"].ToString());
                row["GstSlab2"] = Convert.ToDecimal(DT.Rows[1]["TOTALGST"].ToString());
                row["GstSlab3"] = Convert.ToDecimal(DT.Rows[2]["TOTALGST"].ToString());
                row["GstSlab4"] = Convert.ToDecimal(DT.Rows[3]["TOTALGST"].ToString());
                row["GstSlab5"] = Convert.ToDecimal(DT.Rows[4]["TOTALGST"].ToString());
            }
            else { }
            d.Rows.Add(row);
            return d;
        }
        public static decimal ggst, tariff,totaltariff;
        public static string gs;
        private DataTable report()
        {
            DataTable D = new DataTable();
            D.Columns.Add("Date", typeof(DateTime));
            D.Columns.Add("GstSlab", typeof(string));
            D.Columns.Add("TotalTariff", typeof(string));
            D.Columns.Add("TotalGst", typeof(string));

            DataTable d = rep.monthwisegst();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D.NewRow();
                r["Date"] = d.Rows[i]["INSERT_DATE"];
                r["GstSlab"] = d.Rows[i]["TAX"];
                if (d.Rows[i]["GST"] == null || d.Rows[i]["GST"].ToString() == "")
                {
                    ggst = Convert.ToDecimal("0.00");
                }
                else
                {
                    ggst = Convert.ToDecimal(d.Rows[i]["GST"]);
                }
                r["TotalTariff"] = d.Rows[i]["ROOM_TARRIF"];
                tariff = Convert.ToDecimal(d.Rows[i]["ROOM_TARRIF"]);
                r["TotalGst"] = ((ggst * tariff) / 100);
                totaltariff = ((ggst * tariff) / 100);
                D.Rows.Add(r);
            }
            return D;
        }
    }
}