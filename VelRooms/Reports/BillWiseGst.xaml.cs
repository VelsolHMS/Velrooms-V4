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
    /// Interaction logic for BillWiseGst.xaml
    /// </summary>
    public partial class BillWiseGst : Page
    {
        Report rep = new Report();
        public BillWiseGst()
        {
            InitializeComponent();
            fromdate.DisplayDateEnd = DateTime.Today.Date;
            todate.DisplayDateEnd = DateTime.Today.Date;
        }
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (fromdate.Text == "" || todate.Text == "")
            {
                MessageBox.Show("Please Select the Date");
            }
            else
            {
                rep.FromDate = fromdate.Text;
                rep.ToDate = todate.Text;
                DataTable dr = rep.GetBillWiseDetails();
                if (dr.Rows.Count == 0)
                {
                    MessageBox.Show("There is No Data (Unable to Print Report)");
                }
                else
                {
                    rep.FromDate = fromdate.Text;
                    rep.ToDate = todate.Text;
                    ReportDocument re = new ReportDocument();
                    DataTable d1 = report();
                    re.Load("../../Reports/BillWiseGstSubReport.rpt");
                    DataTable d = report1();
                    re.Load("../../Reports/BillWiseCrystal.rpt");
                    re.Subreports[0].SetDataSource(d1);
                    re.SetDataSource(d);
                    re.PrintToPrinter(1, false, 0, 0);
                    re.Refresh();
                }
            }
        }
        public DataTable report1()
        {
            DataTable d = new DataTable();
            d.Columns.Add("Name", typeof(string));
            d.Columns.Add("Address", typeof(string));
            d.Columns.Add("Gst", typeof(string));
            d.Columns.Add("FromDate", typeof(DateTime));
            d.Columns.Add("ToDate", typeof(DateTime));
            DataRow row = d.NewRow();
            rep.Address();
            row["Name"] = Report.Name;
            row["Address"] = Report.Address1;
            row["Gst"] = Report.Gst;
            row["FromDate"] = Convert.ToDateTime(fromdate.Text);
            row["ToDate"] = Convert.ToDateTime(todate.Text);
            d.Rows.Add(row);
            return d;
        }
        public DataTable report()
        {
            DataTable D = new DataTable();
            D.Columns.Add("Date", typeof(DateTime));
            D.Columns.Add("BillNo", typeof(string));
            D.Columns.Add("GstNo", typeof(string));
            D.Columns.Add("GstPer", typeof(decimal));
            D.Columns.Add("TotalTarrif", typeof(decimal));
            D.Columns.Add("TotalGst", typeof(decimal));
            decimal cgst = 0, sgst = 0, GST = 0;
            DataTable d = rep.GetBillWiseDetails();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D.NewRow();
                r["Date"] = Convert.ToDateTime(d.Rows[i]["DATE"]);
                r["BillNo"] = d.Rows[i]["BILL_NO"];
                if (d.Rows[i]["Company_Gst"] == null || d.Rows[i]["Company_Gst"].ToString() == "")
                {
                    r["GstNo"] = "";
                }
                else
                {
                    r["GstNo"] = d.Rows[i]["Company_Gst"];
                }
                if (d.Rows[i]["TaxPer"] == null || d.Rows[i]["TaxPer"].ToString() == "")
                {
                    r["GstPer"] = "";
                }
                else
                {
                    r["GstPer"] = Math.Round(Convert.ToDecimal(d.Rows[i]["TaxPer"]),2,MidpointRounding.AwayFromZero);
                }
                if (d.Rows[i]["ROOM_TARRIF"] == null || d.Rows[i]["ROOM_TARRIF"].ToString() == "")
                {
                    r["TotalTarrif"] = 0;
                }
                else
                {
                    r["TotalTarrif"] = Math.Round(Convert.ToDecimal(d.Rows[i]["ROOM_TARRIF"]),2,MidpointRounding.AwayFromZero);
                }
                if (d.Rows[i]["CGST"] == null || d.Rows[i]["CGST"].ToString() == "")
                {
                    cgst = 0;
                }
                else
                {
                    cgst = Convert.ToDecimal(d.Rows[i]["CGST"]);
                }
                if (d.Rows[i]["SGST"] == null || d.Rows[i]["SGST"].ToString() == "")
                {
                    sgst = 0;
                }
                else
                {
                    sgst = Convert.ToDecimal(d.Rows[i]["SGST"]);
                }
                GST = cgst + sgst;
                r["TotalGst"] = Math.Round(GST, 2, MidpointRounding.AwayFromZero);
                D.Rows.Add(r);
            }
            return D;
        }
    }
}