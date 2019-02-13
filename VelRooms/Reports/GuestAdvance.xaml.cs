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
    /// Interaction logic for GuestAdvance.xaml
    /// </summary>
    public partial class GuestAdvance : Page
    {
        public GuestAdvance()
        {
            InitializeComponent();
            txtdate.DisplayDateEnd = DateTime.Today.Date;
        }
        Report rp = new Report();
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if(txtdate.Text == "" || txtdate.Text == null)
            {
                MessageBox.Show("Please select Date");
            }
            else
            {
                DataTable dr = rp.DAY1();
                if (dr.Rows.Count == 0)
                {
                    MessageBox.Show("There is No Data (Unable to Print Report)");
                }
                else
                {
                    rp.DayWiseAdvanceDate = txtdate.Text;
                    ReportDocument re = new ReportDocument();
                    DataTable d1 = report();
                    re.Load("../../Reports/DayWiseAdvanceSubReport.rpt");
                    DataTable d = report1();
                    re.Load("../../Reports/DayWiseAdvanceMainReport.rpt");
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
            d.Columns.Add("Hotel", typeof(string));
            d.Columns.Add("HotelAddress", typeof(string));
            d.Columns.Add("GstNo", typeof(string));
            d.Columns.Add("Date", typeof(DateTime));
            DataRow row = d.NewRow();
            rp.Daywiseadvance1();
            row["Hotel"] = Report.Hotel;
            row["HotelAddress"] = Report.HotelAddress;
            row["GstNo"] = Report.GST;
            row["Date"] = rp.DayWiseAdvanceDate;
            d.Rows.Add(row);
            return d;
        }
        private DataTable report()
        {
            DataTable D = new DataTable();
            D.Columns.Add("Room No", typeof(string));
            D.Columns.Add("Name", typeof(string));
            D.Columns.Add("Phone", typeof(string));
            D.Columns.Add("ID Prrof", typeof(string));
            D.Columns.Add("Advance", typeof(decimal));
            D.Columns.Add("User", typeof(string));

            DataTable d = rp.DAY1();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D.NewRow();
                if (d.Rows[i]["ROOM_NO"].ToString() == null || d.Rows[i]["ROOM_NO"].ToString() == "")
                {
                    rp.RES = d.Rows[i]["RESERVATION_ID"].ToString();
                    DataTable D1 = rp.DAY2();
                    string Room_No_Res = D1.Rows[0]["RESERVATION_ID"] + " (B)";
                    r["Room No"] = Room_No_Res;
                    r["Name"] = D1.Rows[0]["FIRSTNAME"];
                    r["Phone"] = D1.Rows[0]["MOBILE_NO"];
                    r["ID Prrof"] = D1.Rows[0]["ID"];
                    r["Advance"] = D1.Rows[0]["AMOUNT_RECEIVED"];
                    r["User"] = D1.Rows[0]["INSERT_BY"];
                }
                else
                { 
                    rp.ROOM= d.Rows[i]["ROOM_NO"].ToString();
                    DataTable D2 = rp.DAY3();
                    r["Room No"] = D2.Rows[0]["ROOM_NO"];
                    r["Name"] = D2.Rows[0]["FIRSTNAME"];
                    r["Phone"] = D2.Rows[0]["MOBILE_NO"];
                    r["ID Prrof"] = D2.Rows[0]["ID"];
                    r["Advance"] = D2.Rows[0]["AMOUNT_RECEIVED"];
                    r["User"] = D2.Rows[0]["INSERT_BY"];
                }
                D.Rows.Add(r);
            }
            return D;
        }
        //public static string RES,ROOM;
    }
}
