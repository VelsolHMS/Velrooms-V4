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
    /// Interaction logic for MonthWiseRoomTariff.xaml
    /// </summary>
    public partial class MonthWiseRoomTariff : Page
    {
        public MonthWiseRoomTariff()
        {
            InitializeComponent();
            fromdate.DisplayDateEnd = DateTime.Today.Date;
            todate.DisplayDateEnd = DateTime.Today.Date;
        }
        Report repor = new Report();
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if(fromdate.Text == "" && todate.Text == "")
            {
                MessageBox.Show("Please select the Date..!");
            }
            else
            {
                repor.MWFromDate = fromdate.Text;
                repor.MWToDate = todate.Text;
                DataTable dr = repor.MWRoomTariff();
                if (dr.Rows.Count == 0)
                {
                    MessageBox.Show("There is No Data (Unable to Print Report)");
                }
                else
                {
                    ReportDocument re = new ReportDocument();
                    DataTable d = report1();
                    re.Load("../../Reports/RoomTariffMonthWiseSubReport.rpt");
                    DataTable dd = report();
                    re.Load("../../Reports/RoomTariffMonthwiseReport.rpt");
                    re.Subreports[0].SetDataSource(d);
                    re.SetDataSource(dd);
                    re.PrintToPrinter(1, false, 0, 0);
                    re.Refresh();
                }
            }
            //select ROOM_NO,MAX(ROOM_CATEGORY)AS ROOM_CATEGORY,Count(ROOM_NO)AS COU , SUM(CHARGED_TARRIF) as TARIFF from CHECKIN where INSERT_DATE between '2018-11-11' and '2018-12-11' group by ROOM_NO
        }
        public DataTable report()
        {
            DataTable dd = new DataTable();
            dd.Columns.Add("Name", typeof(string));
            dd.Columns.Add("Address", typeof(string));
            dd.Columns.Add("Gst", typeof(string));
            dd.Columns.Add("FromDate", typeof(DateTime));
            dd.Columns.Add("ToDate", typeof(DateTime));
            DataRow row = dd.NewRow();
            repor.Address();
            row["Name"] = Report.Name;
            row["Address"] = Report.Address1;
            row["Gst"] = Report.Gst;
            row["FromDate"] = repor.MWFromDate;
            row["ToDate"] = repor.MWToDate;
            dd.Rows.Add(row);
            return dd;
        }
        public DataTable report1()
        {
            DataTable d = new DataTable();
            d.Columns.Add("RoomNo", typeof(int));
            d.Columns.Add("RoomCategory", typeof(string));
            d.Columns.Add("NoofTimesBooked", typeof(int));
            d.Columns.Add("TotalTariff", typeof(decimal));
            DataTable DD = repor.MWRoomTariff();
            for (int i = 0; i < DD.Rows.Count; i++)
            {
                DataRow r = d.NewRow();
                r["RoomNo"] = DD.Rows[i]["ROOM_NO"];
                r["RoomCategory"] = DD.Rows[i]["ROOM_CATEGORY"];
                r["NoofTimesBooked"] = DD.Rows[i]["Room_count"];
                r["TotalTariff"] = DD.Rows[i]["TARIFF"];
                d.Rows.Add(r);
            }
            return d;
        }
    }
}
