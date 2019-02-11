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
    /// Interaction logic for Plan_Wise_Room_Tarrif.xaml
    /// </summary>
    public partial class Plan_Wise_Room_Tarrif : Page
    {
        Report rp = new Report();
        public Plan_Wise_Room_Tarrif()
        {
            InitializeComponent();
            ReportDocument re = new ReportDocument();
            DataTable d1 = report();
            re.Load("../../Reports/PlanWise RoomTarrif SubReport.rpt");
            DataTable d = report1();
            re.Load("../../Reports/PlanWise Room Tarrif MainReport.rpt");
            re.Subreports[0].SetDataSource(d1);
            re.SetDataSource(d);
            re.PrintToPrinter(1, false, 0, 0);
            re.Refresh();
        }
        private DataTable report1()
        {
            DataTable d = new DataTable();
            d.Columns.Add("Hotel", typeof(string));
            d.Columns.Add("HotelAddress", typeof(string));
            d.Columns.Add("GstNo", typeof(string));
            DataRow row = d.NewRow();
            DataTable dt = rp.RoomTarrif1();
            row["Hotel"] = dt.Rows[0]["Hotel"].ToString();
            row["HotelAddress"] = dt.Rows[0]["HotelAddress"].ToString();
            row["GstNo"] = dt.Rows[0]["GST"].ToString();
            d.Rows.Add(row);
            return d;
        }
        private DataTable report()
        {
            DataTable D1 = new DataTable();
            D1.Columns.Add("Room No", typeof(int));
            D1.Columns.Add("Plan Code", typeof(string));
            D1.Columns.Add("Room Category", typeof(string));
            D1.Columns.Add("SinglePlan", typeof(decimal));
            D1.Columns.Add("DoublePlan", typeof(decimal));
            D1.Columns.Add("TriplePlan", typeof(decimal));
            D1.Columns.Add("QuadPlan", typeof(decimal));
            DataTable d = rp.PlanWiseRoomTarrif();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D1.NewRow();
                r["Room No"] = d.Rows[i]["ROOM_NO"];
                r["Plan Code"] = d.Rows[i]["PLAN_CODE"];
                r["Room Category"] = d.Rows[i]["ROOM_CATEGORY"];
                r["SinglePlan"] = d.Rows[i]["SINGLE_PLAN"];
                r["DoublePlan"] = d.Rows[i]["DOUBLE_PLAN"];
                r["TriplePlan"] = d.Rows[i]["TRIPLE_PLAN"];
                r["QuadPlan"] = d.Rows[i]["QUAD_PLAN"];
                D1.Rows.Add(r);
            }
            return D1;
        }
    }
}
