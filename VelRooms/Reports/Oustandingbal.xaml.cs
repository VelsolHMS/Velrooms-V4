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
using CrystalDecisions.CrystalReports.Engine;
using HMS.Model.Others;

namespace HMS.Reports
{
    /// <summary>
    /// Interaction logic for Oustandingbal.xaml
    /// </summary>
    public partial class Oustandingbal : Page
    {
        Report rp = new Report();
        public Oustandingbal()
        {
            InitializeComponent();
            txtdate.DisplayDateEnd = DateTime.Today.Date;
        }
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if(txtdate.Text == "" || txtdate.Text == null)
            {
                MessageBox.Show("Please select Date");
            }
            else
            {
                rp.SelectedDate = txtdate.Text;
                DataTable dr = rp.outbalcmpwise();
                if (dr.Rows.Count == 0)
                {
                    MessageBox.Show("There is No Data(Unable to Print Report)");
                }
                else
                {
                    ReportDocument re = new ReportDocument();
                    DataTable d1 = report();
                    re.Load("../../Reports/OutstandingbalReport1.rpt");
                    DataTable d = report1();
                    re.Load("../../Reports/OutstandingbalReport.rpt");
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
            d.Columns.Add("Name", typeof(string));
            d.Columns.Add("Address", typeof(string));
            d.Columns.Add("GSTNO", typeof(string));
            d.Columns.Add("Date", typeof(DateTime));
            DataRow row = d.NewRow();
            rp.Address();
            row["Name"] = Report.Name;
            row["Address"] = Report.Address1;
            row["GSTNO"] = Report.Gst;
            row["Date"] = rp.SelectedDate;
            d.Rows.Add(row);
            return d;
        }

        private DataTable report()
        {
            DataTable D = new DataTable();
            D.Columns.Add("Code", typeof(string));
            D.Columns.Add("Name", typeof(string));
            D.Columns.Add("Address", typeof(string));
            D.Columns.Add("PendingAmount", typeof(string));
            D.Columns.Add("Remarks", typeof(string));
            
            DataTable d = rp.outbalcmpwise();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D.NewRow();
                    r["Code"] = d.Rows[i]["COMPANY_CODE"];
                    r["Name"] = d.Rows[i]["COMPANY_NAME"];
                    r["Address"] = d.Rows[i]["COMPANYADDRESS"];
                    r["PendingAmount"] = d.Rows[i]["PENDINGAMOUNT"];
                    r["Remarks"] = d.Rows[i]["REMARKS"];
                D.Rows.Add(r);
            }
            return D;
        }
    }
}
