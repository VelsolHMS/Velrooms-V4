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
    /// Interaction logic for RoomTarrif.xaml
    /// </summary>
    public partial class RoomTarrif : Page
    {
        Report rp = new Report();
        public RoomTarrif()
        {
            InitializeComponent();
            DataTable dr = rp.RoomTarrif2();
            if (dr.Rows.Count == 0)
            {
                MessageBox.Show("There is No Data (Unable to Print Report)");
            }
            else
            {
                ReportDocument re = new ReportDocument();
                DataTable d1 = report();
                re.Load("../../Reports/RoomTarrifSubReport.rpt");
                DataTable d = report1();
                re.Load("../../Reports/RoomTarrifMainReport.rpt");
                re.Subreports[0].SetDataSource(d1);
                re.SetDataSource(d);
                re.PrintToPrinter(1, false, 0, 0);
                re.Refresh();
            }
        }
        private DataTable report1()
        {
            DataTable d = new DataTable();
            d.Columns.Add("Hotel", typeof(string));
            d.Columns.Add("HotelAddress", typeof(string));
            d.Columns.Add("GstNo", typeof(string));
            DataRow row = d.NewRow();
            DataTable dt= rp.RoomTarrif1();
            row["Hotel"] = dt.Rows[0]["Hotel"].ToString();
            row["HotelAddress"] = dt.Rows[0]["HotelAddress"].ToString();
            row["GstNo"] = dt.Rows[0]["GST"].ToString();
            d.Rows.Add(row);
            return d;
        }
        private DataTable report()
        {
            DataTable D1 = new DataTable();
            D1.Columns.Add("Room Category", typeof(string));
            D1.Columns.Add("RoomNo", typeof(int));
            D1.Columns.Add("SingleT", typeof(decimal));
            D1.Columns.Add("DoubleT", typeof(decimal));
            D1.Columns.Add("TripleT", typeof(decimal));
            D1.Columns.Add("QuadT", typeof(decimal));
            D1.Columns.Add("ExBedA", typeof(decimal));
            D1.Columns.Add("ExBedC", typeof(decimal));
            DataTable d = rp.RoomTarrif2();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D1.NewRow();
                r["Room Category"] = d.Rows[i]["ROOM_CATEGORY"];
                r["RoomNo"] = d.Rows[i]["ROOM_NO"];
                r["SingleT"] = d.Rows[i]["SINGLERATE_TARRIF"];
                r["DoubleT"] = d.Rows[i]["DOUBLERATE_TARRIF"];
                r["TripleT"] = d.Rows[i]["TRIPLERATE_TARRIF"];
                r["QuadT"] = d.Rows[i]["QUADRATE_TARRIF"];
                r["ExBedA"] = d.Rows[i]["EXTRABED_ADULT"];
                r["ExBedC"] = d.Rows[i]["EXTRABED_CHILD"];
                D1.Rows.Add(r);
            }
            return D1;
        }
    }
}
