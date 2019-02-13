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
    /// Interaction logic for RoomOccupancy.xaml
    /// </summary>
    public partial class RoomOccupancy : Page
    {
        public RoomOccupancy()
        {
            InitializeComponent();
            txtfromdate.DisplayDateEnd = DateTime.Today.Date;
            txttodate.DisplayDateEnd = DateTime.Today.Date;
        }
        Report rp = new Report();
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if(txtfromdate.Text == "" || txttodate.Text == "")
            {
                MessageBox.Show("Please Select the Date.!");
            }
            else
            {
                DataTable dr = rp.RoomOccupency1();
                if (dr.Rows.Count == 0)
                {
                    MessageBox.Show("There is No Data (Unable to Print Report)");
                }
                else
                {
                    rp.RoomOCCfromdate = txtfromdate.Text;
                    rp.RoomOCCtodate = txttodate.Text;
                    ReportDocument re = new ReportDocument();
                    DataTable d1 = report();
                    re.Load("../../Reports/RoomOccupency2.rpt");
                    DataTable d = report1();
                    re.Load("../../Reports/RoomOccupency.rpt");
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
            D.Columns.Add("Category", typeof(string));
            D.Columns.Add("Roomno", typeof(int));
            D.Columns.Add("Count", typeof(string));

            DataTable d = rp.RoomOccupency2();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D.NewRow();
                r["Category"] =d.Rows[i]["Category"];
                r["Roomno"] = d.Rows[i]["Roomno"];
                r["Count"] = d.Rows[i]["Count"];
                D.Rows.Add(r);
            }
            return D;
        }
        public DataTable report1()
        {
            DataTable d = new DataTable();
            d.Columns.Add("Hotel", typeof(string));
            d.Columns.Add("HotelAddress", typeof(string));
            d.Columns.Add("FromDate", typeof(DateTime));
            d.Columns.Add("ToDate", typeof(DateTime));
            d.Columns.Add("GstNo", typeof(string));
            DataRow row = d.NewRow();
            rp.RoomOccupency1();
            row["Hotel"] = Report.Hotel;
            row["HotelAddress"] = Report.HotelAddress;
            row["FromDate"] = rp.RoomOCCfromdate;
            row["ToDate"] = rp.RoomOCCtodate;
            row["GstNo"] = Report.GST;
            d.Rows.Add(row);
            return d;
        }
    }
}
