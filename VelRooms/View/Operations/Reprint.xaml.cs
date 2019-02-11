using CrystalDecisions.CrystalReports.Engine;
using HMS.mainwindowpages;
using HMS.Model;
using HMS.Model.Operations;
using SAPBusinessObjects.WPF.Viewer;
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
using System.Drawing.Printing;
using HMS.View.Masters;
using HMS.Model.Others;

namespace HMS.View.Operations
{
    /// <summary>
    /// Interaction logic for Reprint.xaml
    /// </summary>
    public partial class Reprint : Page
    {
        Checksin c = new Checksin();
        Print P = new Print();
        Report rp = new Report();
        public DataTable S = new DataTable();
        public DataTable dt = new DataTable();
        public int dt_value = 0;
        public Reprint()
        {
            InitializeComponent();
        }
        private void txtsearch_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtsearch.Text.ToString() == null || txtsearch.Text.ToString() == "")
                {
                }
                else
                {
                    c.CHECKIN_ID = Convert.ToInt32(txtsearch.Text);
                    // c.MOBILE_NUMBER =Convert.ToInt64( txtsearch.Text);
                    dt = c.REPRRINT2();
                    if (dt.Rows.Count == 0)
                    {
                        txtsearch.Text = "";
                        MessageBox.Show("Enter Correct Checkin Id");
                        DATEPICKER.Text = "";
                        chkId.Text = "";
                        txtname.Text = "";
                        btn.IsEnabled = false;
                    }
                    else
                    {
                        DATAGRID.ItemsSource = dt.DefaultView;
                        dt_value = 1;
                        DATEPICKER.Text = "";
                        chkId.Text = "";
                        txtname.Text = "";
                        btn.IsEnabled = false;
                    }
                }
            }
            catch (Exception) { }
        }
        private void DATEPICKER_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if(DATEPICKER.Text.ToString() == null || DATEPICKER.Text.ToString() == "")
                {
                }
                else
                {
                    c.REPRINTDATE = DATEPICKER.Text;
                    dt = c.REPRRINT1();
                    if (dt.Rows.Count == 0)
                    {
                        //DATEPICKER.Text = "";
                        MessageBox.Show("No Checkouts on This Day.!");
                        txtsearch.Text = "";
                        chkId.Text = "";
                        txtname.Text = "";
                        btn.IsEnabled = false;
                    }
                    else
                    {
                        DATAGRID.ItemsSource = dt.DefaultView;
                        dt_value = 0;
                        txtsearch.Text = "";
                        chkId.Text = "";
                        txtname.Text = "";
                        btn.IsEnabled = false;
                    }
                }
            }
            catch (Exception) { }
        }
        private void DATAGRID_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int i = DATAGRID.SelectedIndex;
            DataTable dt_rows;
            if (i >= 0)
            {
                if(dt_value == 0)
                {
                    c.REPRINTDATE = DATEPICKER.Text;
                    dt_rows = c.REPRRINT1();
                }
                else
                {
                    c.CHECKIN_ID = Convert.ToInt32(txtsearch.Text);
                    dt_rows = c.REPRRINT2();
                }
                if(dt_rows.Rows.Count > 0)
                {
                    chkId.Text = dt_rows.Rows[i]["CHECKIN_ID"].ToString();
                    txtname.Text = dt_rows.Rows[i]["GUEST_NAME"].ToString();
                    btn.IsEnabled = true;
                }
            }
            else { }
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ReportDocument re = new ReportDocument();
                DataTable d1 = SubReport();
                re.Load("../../Reports/ReprintCheckoutSubRpt.rpt");
                DataTable d = MainReport();
                re.Load("../../Reports/ReprintCheckout.rpt");
                re.Subreports[0].SetDataSource(d1);
                re.SetDataSource(d);
                re.PrintToPrinter(1, false, 0, 0);
                re.Refresh();
                rp_Discount = 0; rp_Advance = 0; rp_Refund = 0; rp_Tarrif = 0; rp_Charges = 0; rp_Tariff = 0; rp_Tax = 0; rp_RoomTarrif = 0; rp_Gst = 0; rp_SubTotal = 0; rp_GrandTotal = 0; rp_FinalTax = 0; rp_FinalAdvance = 0; rp_FinalCharges = 0;
            }
            catch (Exception) { }
        }
        public decimal rp_Discount, rp_Advance, rp_Refund, rp_Tarrif, rp_Charges, rp_Tariff, rp_Tax, rp_RoomTarrif, rp_Gst,rp_SubTotal, rp_GrandTotal, rp_FinalTax , rp_FinalAdvance, rp_FinalCharges;

        public DataTable MainReport()
        {
            DataTable d = new DataTable();
            d.Columns.Add("Hotel", typeof(string));
            d.Columns.Add("HotelAddress", typeof(string));
            d.Columns.Add("Gst", typeof(string));
            d.Columns.Add("GuestName",typeof(string));
            d.Columns.Add("Address", typeof(string));
            d.Columns.Add("RoomNo", typeof(string));
            d.Columns.Add("Reservation", typeof(string));
            d.Columns.Add("InvoiceNo", typeof(string));
            d.Columns.Add("RoomType", typeof(string));
            d.Columns.Add("CheckinDate", typeof(DateTime));
            d.Columns.Add("CheckinTime", typeof(DateTime));
            d.Columns.Add("CheckoutDate", typeof(DateTime));
            d.Columns.Add("RoomTarrif", typeof(decimal));
            d.Columns.Add("Advance", typeof(decimal));
            d.Columns.Add("Charges", typeof(decimal));
            d.Columns.Add("Discount", typeof(decimal));
            d.Columns.Add("Refund", typeof(decimal));
            d.Columns.Add("SubTotal", typeof(decimal));
            d.Columns.Add("CGST", typeof(decimal));
            d.Columns.Add("SGST", typeof(decimal));
            d.Columns.Add("GrandTotal", typeof(decimal));
            DataRow row = d.NewRow();
            rp.TodayBookings1();
            row["Hotel"] = Report.Hotel;
            row["HotelAddress"] = Report.HotelAddress;
            row["Gst"] = Report.GST;

            P.id = Convert.ToInt32(chkId.Text);
            DataTable ss = P.REPRINT();
            row["GuestName"] = ss.Rows[0]["FIRSTNAME"].ToString();
            row["Address"] = ss.Rows[0]["ADDRESS"].ToString();
            row["RoomNo"] = ss.Rows[0]["ROOM_NO"].ToString();
            row["Reservation"] = ss.Rows[0]["RESERVATION_ID"].ToString();
            row["InvoiceNo"] = ss.Rows[0]["INVOICENO"].ToString();
            row["RoomType"] = ss.Rows[0]["ROOM_CATEGORY"].ToString();
            row["CheckinDate"] = Convert.ToDateTime(ss.Rows[0]["ARRIVAL_DATE"]);
            row["CheckinTime"] = Convert.ToDateTime(ss.Rows[0]["ARRIVAL_TIME"]);
            row["CheckoutDate"] = Convert.ToDateTime(ss.Rows[0]["CHECKOUT"]);
            DataTable cs = P.CheckoutCharges();
            if (cs.Rows[0]["Discount"].ToString() == null || cs.Rows[0]["Discount"].ToString() == "")
            {
                rp_Discount = 0;
            }
            else
            {
                rp_Discount = Convert.ToDecimal(cs.Rows[0]["Discount"]);
            }
            if (cs.Rows[0]["Refund"].ToString() == null || cs.Rows[0]["Refund"].ToString() == "")
            {
                rp_Refund = 0;
            }
            else
            {
                rp_Refund = Convert.ToDecimal(cs.Rows[0]["Refund"]);
            }
            row["RoomTarrif"] = Math.Round(rp_RoomTarrif, 2, MidpointRounding.AwayFromZero);
            row["Advance"] = Math.Round(rp_FinalAdvance, 2, MidpointRounding.AwayFromZero);
            row["Charges"] = Math.Round(rp_FinalCharges, 2, MidpointRounding.AwayFromZero);
            row["Discount"] = Math.Round(rp_Discount, 2, MidpointRounding.AwayFromZero);
            row["Refund"] = Math.Round(rp_Refund, 2, MidpointRounding.AwayFromZero);
            rp_SubTotal = rp_RoomTarrif + rp_FinalTax + rp_FinalCharges;
            row["SubTotal"] = Math.Round(rp_SubTotal, 2, MidpointRounding.AwayFromZero);
            row["CGST"] = Math.Round(rp_FinalTax / 2, 2, MidpointRounding.AwayFromZero);
            row["SGST"] = Math.Round(rp_FinalTax / 2, 2, MidpointRounding.AwayFromZero);
            rp_GrandTotal = rp_SubTotal - rp_FinalAdvance - rp_Discount + rp_Refund;
            row["GrandTotal"] = Math.Round(rp_GrandTotal, 2, MidpointRounding.AwayFromZero);
            d.Rows.Add(row);
            return d;
        }
        public DataTable SubReport()
        {
            P.ids = Convert.ToInt32(chkId.Text);
            DataTable dd = new DataTable();
            dd.Columns.Add("Dates", typeof(DateTime));
            dd.Columns.Add("Tarrif", typeof(Decimal));
            dd.Columns.Add("Advance", typeof(Decimal));
            dd.Columns.Add("Charges", typeof(Decimal));
            dd.Columns.Add("Tax", typeof(Decimal));
            DataTable NA_Details = P.reprintcount();
            if (NA_Details.Rows.Count > 0)
            {
                //na_grid
                for (int i = 0; i < NA_Details.Rows.Count; i++)
                {
                    DataRow na = dd.NewRow();
                    na["Dates"] = Convert.ToDateTime(NA_Details.Rows[i]["INSERT_DATE"]).ToShortDateString();
                    if (NA_Details.Rows[i]["ROOM_TARRIF"].ToString() == null || NA_Details.Rows[i]["ROOM_TARRIF"].ToString() == "")
                    {
                        rp_Tariff = 0;
                    }
                    else
                    {
                        rp_Tariff = Convert.ToDecimal(NA_Details.Rows[i]["ROOM_TARRIF"]);
                    }
                    if (NA_Details.Rows[i]["GST"].ToString() == null || NA_Details.Rows[i]["GST"].ToString() == "")
                    {
                        rp_Tax = 0;
                    }
                    else
                    {
                        rp_Tax = Convert.ToDecimal(NA_Details.Rows[i]["GST"]);
                    }
                    if (i == (NA_Details.Rows.Count - 1))
                    {
                        P.From_dt = Convert.ToDateTime(NA_Details.Rows[i]["INSERT_DATE"]);
                        P.To_dt = Convert.ToDateTime(NA_Details.Rows[i]["INSERT_DATE"]).AddDays(1);
                        P.GetAdvance();
                        P.GetCharges();
                        rp_Advance = P.rp_Advance;
                        rp_Charges = P.rp_Charges;
                    }
                    else
                    {
                        if (NA_Details.Rows[i]["ADVANCE"].ToString() == null || NA_Details.Rows[i]["ADVANCE"].ToString() == "")
                        {
                            rp_Advance = 0;
                        }
                        else
                        {
                            rp_Advance = Convert.ToDecimal(NA_Details.Rows[i]["ADVANCE"]);
                        }
                        if (NA_Details.Rows[i]["CHARGES"].ToString() == null || NA_Details.Rows[i]["CHARGES"].ToString() == "")
                        {
                            rp_Charges = 0;
                        }
                        else
                        {
                            rp_Charges = Convert.ToDecimal(NA_Details.Rows[i]["CHARGES"]);
                        }
                    }
                    rp_RoomTarrif += rp_Tariff;
                    rp_Gst = (rp_Tariff * rp_Tax) / 100;
                    rp_FinalTax += rp_Gst;
                    rp_FinalAdvance += rp_Advance;
                    rp_FinalCharges += rp_Charges;
                    na["Tarrif"] = Math.Round(rp_Tariff, 2, MidpointRounding.AwayFromZero);
                    na["Tax"] = Math.Round(rp_Gst, 2, MidpointRounding.AwayFromZero);
                    na["Advance"] = Math.Round(rp_Advance, 2, MidpointRounding.AwayFromZero);
                    na["Charges"] = Math.Round(rp_Charges, 2, MidpointRounding.AwayFromZero);
                    dd.Rows.Add(na);
                }
            }
            return dd;
        }
    }
}
