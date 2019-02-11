using CrystalDecisions.CrystalReports.Engine;
using HMS.Model.Others;
using System;
using System.Data;
using System.Windows.Controls;

namespace HMS.Reports
{
    /// <summary>
    /// Interaction logic for CheckoutDay.xaml
    /// </summary>
    public partial class CheckoutDay : Page
    {
        public CheckoutDay()
        {
            InitializeComponent();
            ReportDocument re = new ReportDocument();
            DataTable d1 = report();
            re.Load("../../Reports/CheckoutDayReport2.rpt");
            DataTable d = report1();
            re.Load("../../Reports/CheckoutDayReport1.rpt");
            re.Subreports[0].SetDataSource(d1);
            re.SetDataSource(d);
            re.PrintToPrinter(1, false, 0, 0);
            re.Refresh();
        }
        Report repor = new Report();
        public DataTable report()
        {
            DataTable D = new DataTable();
            D.Columns.Add("Room_No", typeof(int));
            D.Columns.Add("Reservation_No", typeof(int));
            D.Columns.Add("GuestName", typeof(string));
            D.Columns.Add("Mobile_No", typeof(string));
            D.Columns.Add("Id_Proof", typeof(string));
            //D.Columns.Add("Id_Data", typeof(string));
            D.Columns.Add("ArrivalDate_Time", typeof(DateTime));
            D.Columns.Add("Name", typeof(string));
            D.Columns.Add("Address", typeof(string));
            D.Columns.Add("Gst", typeof(string));
            D.Columns.Add("User", typeof(string));
            DataTable d = repor.Checkoutday();
            for(int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D.NewRow();
                r["Room_No"] = d.Rows[i]["ROOM_NO"];
                r["Reservation_No"] = d.Rows[i]["RESERVATION_ID"];
                r["GuestName"] = d.Rows[i]["GUEST_NAME"];
                r["Mobile_No"] = d.Rows[i]["MOBILE_NO"];
                string IdProofData;
                if(d.Rows[i]["ID_TYPE"].ToString() == null || d.Rows[i]["ID_TYPE"].ToString() == "")
                {
                    IdProofData = "";
                }
                else
                {
                    IdProofData = d.Rows[i]["ID_DATA"] + " (" + d.Rows[i]["ID_TYPE"] + ")";
                }
                r["Id_Proof"] = IdProofData;
                //r["Id_Data"] = d.Rows[i]["ID_DATA"];
                r["ArrivalDate_Time"] = d.Rows[i]["ARRIVAL_TIMEDATE"];
                r["User"] = d.Rows[i]["INSERT_BY"];
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
            row["Name"] =Report.Name;
            row["Address"] =Report.Address1;
            row["Gst"] =Report.Gst;
            d.Rows.Add(row);
            return d;
        }
    }
}
