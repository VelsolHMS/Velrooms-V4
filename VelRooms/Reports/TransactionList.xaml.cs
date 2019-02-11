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
    /// Interaction logic for TransactionList.xaml
    /// </summary>
    public partial class TransactionList : Page
    {
        Report rp = new Report();
        public TransactionList()
        {
            InitializeComponent();
            txtdate.DisplayDateEnd = DateTime.Today.Date;
        }
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (txtdate.Text == "" || txtdate.Text == null)
            {
                MessageBox.Show("Please Select Date");
            }
            else
            {
                rp.SelectedDate = txtdate.Text;
                ReportDocument re = new ReportDocument();
                DataTable cout = report5();
                re.Load("../../Reports/TransactioncoutsubReport.rpt");
                DataTable refu = report4();
                re.Load("../../Reports/TransactionRefundsubReport.rpt");
                DataTable disc = report2();
                re.Load("../../Reports/TransactionDiscsubReport.rpt");
                DataTable pc = report3();
                re.Load("../../Reports/TransactionPCsubReport.rpt");
                DataTable adv = report1();
                re.Load("../../Reports/TransactionAdvanceReport.rpt");
                DataTable d = report();
                re.Load("../../Reports/TransactionListReport.rpt");
                re.Subreports[4].SetDataSource(cout);
                re.Subreports[3].SetDataSource(refu);
                re.Subreports[2].SetDataSource(disc);
                re.Subreports[1].SetDataSource(pc);
                re.Subreports[0].SetDataSource(adv);
                re.SetDataSource(d);
                re.PrintToPrinter(1, false, 0, 0);
                re.Refresh();
            }
            //rp.SelectedDate = txtdate.Text;
            //ReportDocument re = new ReportDocument();
            //DataTable d5 = report5();
            //if (d5.Rows.Count != 0) { re.Load("../../Reports/TransactioncoutsubReport.rpt"); }
            ////re.Load("../../Reports/TransactionListcheckoutReport.rpt");
            //DataTable d4 = report4();
            //if (d4.Rows.Count != 0) { re.Load("../../Reports/TransactionRefundsubReport.rpt"); }
            ////re.Load("../../Reports/TransactionListRefundReport.rpt");
            //DataTable d3 = report3();
            //if (d3.Rows.Count != 0) { re.Load("../../Reports/TransactionDiscsubReport.rpt"); }
            ////re.Load("../../Reports/TransactionListDiscReport.rpt");
            //DataTable d2 = report2();
            //if (d2.Rows.Count != 0) { re.Load("../../Reports/TransactionPCsubReport.rpt"); }
            ////re.Load("../../Reports/TransactionListPCReport.rpt");
            //DataTable d1 = report1();
            //if (d1.Rows.Count != 0) { re.Load("../../Reports/TransactionAdvanceReport.rpt"); }
            ////re.Load("../../Reports/TransactionListSubReport.rpt");
            //DataTable d = report();
            //re.Load("../../Reports/TransactionListReport.rpt");
            //if (d5.Rows.Count!=0) { re.Subreports[4].SetDataSource(d5); }
            //if (d4.Rows.Count!=0) { re.Subreports[3].SetDataSource(d4); }
            //if (d3.Rows.Count!=0) { re.Subreports[2].SetDataSource(d3); }
            //if (d2.Rows.Count!=0) { re.Subreports[1].SetDataSource(d2); }
            //if (d1.Rows.Count!=0) { re.Subreports[0].SetDataSource(d1); }
            //re.SetDataSource(d);
            //re.PrintToPrinter(1, false, 0, 0);
            //re.Refresh();
        }
        private DataTable report()
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
        public static int rno;
        private DataTable report1()
        {
            DataTable D1 = new DataTable();
            D1.Columns.Add("RoomNo", typeof(string));
            D1.Columns.Add("Name", typeof(string));
            D1.Columns.Add("Amount", typeof(string));
            D1.Columns.Add("PayMode", typeof(string));
            D1.Columns.Add("Remarks", typeof(string));
            D1.Columns.Add("User", typeof(string));

            DataTable d = rp.advtranslist();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D1.NewRow();
                if (d.Rows.Count == 0)
                {
                    r["RoomNo"] = 0;
                    r["Name"] = 0;
                    r["Amount"] = 0;
                    r["PayMode"] = 0;
                    r["Remarks"] = 0;
                    r["User"] = 0;
                }
                else
                {
                    if (d.Rows[i]["ROOM_NO"].ToString() == null || d.Rows[i]["ROOM_NO"].ToString() == "")
                    {
                        r["RoomNo"] = d.Rows[i]["RESERVATION_ID"];
                    }
                    else
                    {
                        r["RoomNo"] = d.Rows[i]["ROOM_NO"];
                    }
                    r["Name"] = d.Rows[i]["GUEST_NAME"];
                    r["Amount"] = d.Rows[i]["AMOUNT_RECEIVED"];
                    r["PayMode"] = d.Rows[i]["PAYTYPE"];
                    r["Remarks"] = d.Rows[i]["PARTICULARS"];
                    r["User"] = d.Rows[i]["INSERT_BY"];
                    D1.Rows.Add(r);
                }
            }
            return D1;
        }
        private DataTable report2()
        {
            DataTable D2 = new DataTable();
            D2.Columns.Add("RoomNo", typeof(string));
            D2.Columns.Add("Name", typeof(string));
            D2.Columns.Add("Amount", typeof(string));
            D2.Columns.Add("PayMode", typeof(string));
            D2.Columns.Add("Remarks", typeof(string));
            D2.Columns.Add("User", typeof(string));

            DataTable d = rp.pctranslist();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D2.NewRow();
                if (d.Rows.Count == 0)
                {
                    r["RoomNo"] = 0;
                    r["Name"] = 0;
                    r["Amount"] = 0;
                    r["Remarks"] = 0;
                    r["User"] = 0;
                }
                else
                {
                    r["RoomNo"] = d.Rows[i]["ROOM_NO"];
                    r["Name"] = d.Rows[i]["GUEST_NAME"];
                    r["Amount"] = d.Rows[i]["TOTAL_AMOUNT"];
                    r["Remarks"] = d.Rows[i]["PARTICULARS"];
                    r["User"] = d.Rows[i]["INSERT_BY"];
                    D2.Rows.Add(r);
                }
            }
            return D2;
        }
        private DataTable report3()
        {
            DataTable D3 = new DataTable();
            D3.Columns.Add("RoomNo", typeof(string));
            D3.Columns.Add("Name", typeof(string));
            D3.Columns.Add("Amount", typeof(string));
            D3.Columns.Add("PayMode", typeof(string));
            D3.Columns.Add("Remarks", typeof(string));
            D3.Columns.Add("User", typeof(string));

            DataTable d = rp.disctranslist();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D3.NewRow();
                if (d.Rows.Count == 0)
                {
                    r["RoomNo"] = 0;
                    r["Name"] = 0;
                    r["Amount"] = 0;
                    r["Remarks"] = 0;
                    r["User"] = 0;
                }
                else
                {
                    if (d.Rows[i]["ROOM_NO"].ToString() == null || d.Rows[i]["ROOM_NO"].ToString() == "")
                    {
                        r["RoomNo"] = d.Rows[i]["RESERVATION_NO"];
                    }
                    else
                    {
                        r["RoomNo"] = d.Rows[i]["ROOM_NO"];
                    }
                    r["Name"] = d.Rows[i]["GUEST_NAME"];
                    r["Amount"] = d.Rows[i]["AMOUNT"];
                    r["Remarks"] = d.Rows[i]["PARTICULAR"];
                    r["User"] = d.Rows[i]["INSERT_BY"];
                    D3.Rows.Add(r);
                }
            }
            return D3;
        }
        public static decimal refamount, taxtarrif;
        private DataTable report4()
        {
            DataTable D4 = new DataTable();
            D4.Columns.Add("RoomNo", typeof(string));
            D4.Columns.Add("Name", typeof(string));
            D4.Columns.Add("Amount", typeof(string));
            D4.Columns.Add("PayMode", typeof(string));
            D4.Columns.Add("Remarks", typeof(string));
            D4.Columns.Add("User", typeof(string));

            DataTable d = rp.refundtranslist();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D4.NewRow();
                if (d.Rows.Count == 0)
                {
                    r["RoomNo"] = 0;
                    r["Name"] = 0;
                    r["Amount"] = 0;
                    r["Remarks"] = 0;
                    r["User"] = 0;
                }
                else
                {
                    //TAX1 = Convert.ToDecimal(d.Rows[i]["TAX"]);
                    //if (TAX1 == 0)
                    //{ refamount = Convert.ToDecimal(d.Rows[i]["ROOM_TARRIF"]) - Convert.ToDecimal(d.Rows[i]["ADVANCE"]); }
                    //else
                    //{
                    //    taxtarrif = (Convert.ToDecimal(d.Rows[i]["ROOM_TARRIF"]) * TAX1 / 100);
                    //    refamount = (Convert.ToDecimal(d.Rows[i]["ROOM_TARRIF"]) + taxtarrif) - Convert.ToDecimal(d.Rows[i]["ADVANCE"]);
                    //    refamount = Math.Round(refamount, 2, MidpointRounding.AwayFromZero);
                    //}
                    //if (refamount < 0)
                    //{
                        if (d.Rows[i]["ROOM_NO"].ToString() == null || d.Rows[i]["ROOM_NO"].ToString() == "")
                        {
                            r["RoomNo"] = d.Rows[i]["RESERVATION_ID"];
                        }
                        else
                        {
                            r["RoomNo"] = d.Rows[i]["ROOM_NO"];
                        }
                        r["Name"] = d.Rows[i]["GUEST_NAME"];
                        r["Amount"] = d.Rows[i]["BALANCE_AMOUNT"]; //-(refamount); 
                        r["Remarks"] = d.Rows[i]["REASON"];
                        r["User"] = d.Rows[i]["INSERT_BY"];
                        D4.Rows.Add(r);
                   // }
                }
            }
            return D4;
        }
        public static decimal adv, tariff, ttd, TAX1, tttax;
        private DataTable report5()
        {
            DataTable D5 = new DataTable();
            D5.Columns.Add("RoomNo", typeof(string));
            D5.Columns.Add("Name", typeof(string));
            D5.Columns.Add("Amount", typeof(string));
            D5.Columns.Add("PayMode", typeof(string));
            D5.Columns.Add("Remarks", typeof(string));
            D5.Columns.Add("User", typeof(string));

            DataTable d = rp.couttranslist();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D5.NewRow();
                if (d.Rows.Count == 0)
                {
                    r["RoomNo"] = 0;
                    r["Name"] = 0;
                    r["Amount"] = 0;
                    r["User"] = 0;
                    r["PayMode"] = 0;
                }
                else
                {
                    if (d.Rows[i]["ROOM_NO"].ToString() == null || d.Rows[i]["ROOM_NO"].ToString() == "")
                    {
                        r["RoomNo"] = " ";
                    }
                    else
                    {
                        r["RoomNo"] = d.Rows[i]["ROOM_NO"];
                    }
                    r["Name"] = d.Rows[i]["GUEST_NAME"];
                    if (d.Rows[i]["BALANCE_AMOUNT"].ToString() == "" || d.Rows[i]["BALANCE_AMOUNT"] == null)
                    {
                        ttd = Convert.ToDecimal("0.00");
                        r["Amount"] = Math.Round(ttd, 2, MidpointRounding.AwayFromZero);
                    }
                    else
                    { 
                        tariff = Convert.ToDecimal(d.Rows[i]["BALANCE_AMOUNT"]);
                        r["Amount"] =  Math.Round(tariff, 2, MidpointRounding.AwayFromZero);
                    }
                    r["User"] = d.Rows[i]["INSERT_BY"];
                    r["PayMode"] = d.Rows[i]["PAYMENT_MODE"];
                    D5.Rows.Add(r);
                }
            }
            return D5;
        }  
    }
}
