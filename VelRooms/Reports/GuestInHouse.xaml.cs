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
    /// Interaction logic for GuestInHouse.xaml
    /// </summary>
    public partial class GuestInHouse : Page
    {
        public GuestInHouse()
        {
            InitializeComponent();
            DataTable dr = repor.GuestInHouse();
            if (dr.Rows.Count == 0)
            {
                MessageBox.Show("There is No Data (Unable to Print Report)");
            }
            else
            {
                ReportDocument re = new ReportDocument();
                DataTable d = report1();
                DataTable d1 = report();
                re.Load("../../Reports/GuestInHouseSubReport.rpt");
                re.Load("../../Reports/GuestInHouseReport.rpt");
                re.Subreports[0].SetDataSource(d1);
                re.SetDataSource(d);
                re.PrintToPrinter(0, false, 0, 0);
                re.Refresh();
            }
        }
        Report repor = new Report();
        public DataTable report()
        {
            DataTable D = new DataTable();
            D.Columns.Add("RoomNo", typeof(int));
            D.Columns.Add("GuestName", typeof(string));
            D.Columns.Add("Mobile", typeof(string));
            D.Columns.Add("IdProofData", typeof(string));
            D.Columns.Add("CheckinDate", typeof(DateTime));
            D.Columns.Add("DepartureDate",typeof(DateTime));
            DataTable d = repor.GuestInHouse();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D.NewRow();
                r["RoomNo"] = d.Rows[i]["ROOM_NO"];
                r["GuestName"] = d.Rows[i]["FIRSTNAME"];
                r["Mobile"] = d.Rows[i]["MOBILE_NO"];
                string IdProofData;
                if (d.Rows[i]["ID_DATA"].ToString() == "" || d.Rows[i]["ID_DATA"].ToString() == null)
                {
                    IdProofData = "";
                }
                else
                {
                    IdProofData = d.Rows[i]["ID_DATA"] + " (" + d.Rows[i]["ID_TYPE"] + ")";
                }
                r["IdProofData"] = IdProofData; //d.Rows[i]["ID_DATA"];
                r["CheckinDate"] = d.Rows[i]["DATETIME_ARRIVAL"];
                r["DepartureDate"] = d.Rows[i]["DEPARTURE_DATE"];
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
