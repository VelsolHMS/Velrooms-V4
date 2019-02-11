using CrystalDecisions.CrystalReports.Engine;
using HMS.Model.Others;
using System;
using System.Data;
using System.Windows.Controls;

namespace HMS.Reports
{
    /// <summary>
    /// Interaction logic for Departuretoday.xaml
    /// </summary>
    public partial class Departuretoday : Page
    {
        public Departuretoday()
        {
            InitializeComponent();
            ReportDocument re = new ReportDocument();
            DataTable d = report1();
            DataTable d1 = report();
            re.Load("../../Reports/TodayDepartures1.rpt");
            re.Load("../../Reports/TodayDepartures.rpt");
            re.Subreports[0].SetDataSource(d1);
            re.SetDataSource(d);
            re.PrintToPrinter(0, false, 0, 0);
            re.Refresh();
        }
        Report repor = new Report();
        public DataTable report()
        {
            DataTable D = new DataTable();
            D.Columns.Add("RoomNo", typeof(int));
            D.Columns.Add("GuestName", typeof(string));
            D.Columns.Add("MobileNo", typeof(string));
            //D.Columns.Add("IdType", typeof(string));
            D.Columns.Add("IdData", typeof(string));
            D.Columns.Add("DepartureDate", typeof(string));
            DataTable d = repor.todaydeparture();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D.NewRow();
                r["RoomNo"] = d.Rows[i]["ROOM_NO"];
                r["GuestName"] = d.Rows[i]["FIRSTNAME"];
                r["MobileNo"] = d.Rows[i]["MOBILE_NO"];
                // r["IdType"] = d.Rows[i]["ID_TYPE"];
                string IdProofData;
                if (d.Rows[i]["ID_DATA"].ToString() == "" || d.Rows[i]["ID_DATA"].ToString() == null)
                {
                    IdProofData = "";
                }
                else
                {
                    IdProofData = d.Rows[i]["ID_DATA"] + " (" + d.Rows[i]["ID_TYPE"] + ")";
                }
                r["IdData"] = IdProofData; //d.Rows[i]["ID_DATA"];
                r["DepartureDate"] = d.Rows[i]["DEPARTURE"];
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
            DataRow row = d.NewRow();
            repor.Address();
            row["Name"] = Report.Name;
            row["Address"] = Report.Address1;
            row["Gst"] = Report.Gst;
            d.Rows.Add(row);
            return d;
        }
    }
}
