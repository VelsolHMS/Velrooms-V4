using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using HMS.Model.Others;
using System.Windows;
using System.Windows.Controls;

namespace HMS.Reports
{
    /// <summary>
    /// Interaction logic for frontofficeReport.xaml
    /// </summary>
    public partial class frontofficeReport : Page
    {
        Report rp = new Report();
        public decimal Acard = 0, Acash = 0, ATotal = 0,SCash = 0,SCard = 0, STotal = 0,SBOH = 0,SComplimentry = 0,PendingAmount = 0,Paidouts = 0;
        public decimal OpeningBalance = 0, Advances = 0, RoomCollection = 0, MisCollections = 0, Refunds = 0, Cash = 0, Card = 0;
        public frontofficeReport()
        {
            InitializeComponent();
            txtdate.DisplayDateEnd = DateTime.Today.Date;
        }
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if(txtdate.Text == null || txtdate.Text == "")
            {
                MessageBox.Show("Please select Date");
            }
            else
            {
                rp.SelectedDate = txtdate.Text;
                ReportDocument re = new ReportDocument();
                DataTable d_ExtraAdvance = ExtraAdvance();
                re.Load("../../Reports/FrontOfficeAdvanceSubReport.rpt");
                DataTable d_CheckinAdvance = CheckinAdvance();
                re.Load("../../Reports/FrontOfficeCheckinAdvanceSubReport.rpt");
                DataTable d_ResAdvance = ResAdvance();
                re.Load("../../Reports/FrontOfficeResAdvanceSubReport.rpt");
                DataTable d_PostCharges = postcharges();
                re.Load("../../Reports/FrontOfficePostChargesSubReport.rpt");
                DataTable d_MisCollection = miscollection();
                re.Load("../../Reports/FrontOfficeMisCollSubReport.rpt");
                DataTable d_Paidouts = paidout();
                re.Load("../../Reports/FrontOfficePaidoutsSubReport.rpt");
                DataTable d_Refund = refund();
                re.Load("../../Reports/FrontOfficeRefundSubReport.rpt");
                DataTable d_Settle = settle();
                re.Load("../../Reports/FrontOfficeSettleSubReport.rpt");
                DataTable d_Rescancel = ResCancel();
                re.Load("../../Reports/FrontOfficeResCancelSubReport.rpt");
                DataTable d = report();
                re.Load("../../Reports/FrontOfficeReport.rpt");
                //re.SetDataSource
                re.Subreports[8].SetDataSource(d_Settle);
                re.Subreports[7].SetDataSource(d_Rescancel);
                re.Subreports[6].SetDataSource(d_ResAdvance);
                re.Subreports[5].SetDataSource(d_Refund);
                re.Subreports[4].SetDataSource(d_PostCharges);
                re.Subreports[3].SetDataSource(d_Paidouts);
                re.Subreports[2].SetDataSource(d_MisCollection);
                re.Subreports[1].SetDataSource(d_CheckinAdvance);
                re.Subreports[0].SetDataSource(d_ExtraAdvance);
                re.SetDataSource(d);
                re.PrintToPrinter(0, false, 0, 0);
                re.Refresh();
            }
            txtdate.Text = "";
            Acard = 0; Acash = 0; ATotal = 0; SCash = 0; SCard = 0; STotal = 0; SBOH = 0; SComplimentry = 0; PendingAmount = 0; Paidouts = 0;
            OpeningBalance = 0; Advances = 0; RoomCollection = 0; MisCollections = 0; Refunds = 0; Cash = 0; Card = 0;
        }
        private DataTable report()
        {
            DataTable d = new DataTable();
            d.Columns.Add("Name", typeof(string));
            d.Columns.Add("Address", typeof(string));
            d.Columns.Add("Gst", typeof(string));
            d.Columns.Add("SelectedDate", typeof(DateTime));
            d.Columns.Add("ACash", typeof(decimal));
            d.Columns.Add("ACard", typeof(decimal));
            d.Columns.Add("ATotal", typeof(decimal));
            d.Columns.Add("ATotalSummary", typeof(string));
            d.Columns.Add("SCash", typeof(decimal));
            d.Columns.Add("SCard", typeof(decimal));
            d.Columns.Add("SBOH", typeof(decimal));
            d.Columns.Add("SComplimentry", typeof(decimal));
            d.Columns.Add("STotal", typeof(decimal));
            d.Columns.Add("STotalSummary", typeof(string));
            d.Columns.Add("OpeningBalance", typeof(decimal));
            d.Columns.Add("OpeningBalanceB", typeof(decimal)); 
            d.Columns.Add("Advances", typeof(decimal));
            d.Columns.Add("RoomCollection", typeof(decimal));
            d.Columns.Add("Misc", typeof(decimal));
            d.Columns.Add("PendingBills", typeof(decimal));
            d.Columns.Add("PaidOuts", typeof(decimal));
            d.Columns.Add("Refunds", typeof(decimal));
            d.Columns.Add("Cash", typeof(decimal));
            d.Columns.Add("Card", typeof(decimal));
            d.Columns.Add("Company", typeof(string));
            d.Columns.Add("BOH", typeof(decimal));
            d.Columns.Add("Complimentry", typeof(decimal));
            DataRow row = d.NewRow();
            rp.Address();
            row["Name"] = Report.Name;
            row["Address"] = Report.Address1;
            row["Gst"] = Report.Gst;
            row["SelectedDate"] = rp.SelectedDate;
            row["ACash"] = Math.Round(Acash, 2, MidpointRounding.AwayFromZero); 
            row["ACard"] = Math.Round(Acard, 2, MidpointRounding.AwayFromZero);
            ATotal = Acash + Acard;
            row["ATotal"] = Math.Round(ATotal, 2, MidpointRounding.AwayFromZero);
            long total = Convert.ToInt64(ATotal);
            row["ATotalSummary"] = NumberToText(total);
            row["SCash"] = Math.Round(SCash, 2, MidpointRounding.AwayFromZero);
            row["SCard"] = Math.Round(SCard, 2, MidpointRounding.AwayFromZero);
            row["SBOH"] = Math.Round(SBOH, 2, MidpointRounding.AwayFromZero);
            row["SComplimentry"] = Math.Round(SComplimentry, 2, MidpointRounding.AwayFromZero);
            STotal = SCash + SCard + SBOH + SComplimentry;
            row["STotal"] = Math.Round(STotal, 2, MidpointRounding.AwayFromZero);
            long StotalSummary = Convert.ToInt64(STotal);
            row["STotalSummary"] = NumberToText(StotalSummary);
            decimal Cash_Total = Acash + SCash;
            decimal Card_Total = Acard + SCard;
            row["Cash"] = Math.Round(Cash_Total, 2, MidpointRounding.AwayFromZero);
            row["Card"] = Math.Round(Card_Total, 2, MidpointRounding.AwayFromZero);
            row["Misc"] = Math.Round(MisCollections, 2, MidpointRounding.AwayFromZero);
            row["PaidOuts"] = Math.Round(Paidouts, 2, MidpointRounding.AwayFromZero);
            row["Refunds"] = Math.Round(Refunds, 2, MidpointRounding.AwayFromZero);
            DataTable d1 = rp.PendingBillAmount();
            if(d1.Rows[0]["PendingBill"].ToString() == null || d1.Rows[0]["PendingBill"].ToString() == "")
            {
                PendingAmount = 0;
            }
            else
            {
                PendingAmount = Convert.ToDecimal(d1.Rows[0]["PendingBill"]);
            }
            row["PendingBills"] = Math.Round(PendingAmount, 2, MidpointRounding.AwayFromZero);
            row["Advances"] = Math.Round(Advances, 2, MidpointRounding.AwayFromZero);
            row["RoomCollection"] = Math.Round(RoomCollection, 2, MidpointRounding.AwayFromZero);
            row["BOH"] = Math.Round(SBOH, 2, MidpointRounding.AwayFromZero);
            row["Complimentry"] = Math.Round(SComplimentry, 2, MidpointRounding.AwayFromZero);
            row["Company"] = "0.00";

            DateTime date = Convert.ToDateTime(txtdate.Text);
            rp.OB_Date1 = date.ToShortDateString();
            DataTable OB_Amount = rp.OpeningBalance_Cash();
            if(OB_Amount.Rows[0]["AMOUNT"].ToString() == null || OB_Amount.Rows[0]["AMOUNT"].ToString() == "")
            {
                //OpeningBalance = 0;
                rp.OB_Date = date.AddDays(-1).ToShortDateString();
                DataTable OB = rp.OB_Getting_Cash();
                decimal ob_R_advance = 0, ob_C_advance = 0, ob_E_Advance = 0, ob_Mis = 0, ob_Paidouts = 0, ob_Refunds = 0, ob_Settle = 0, ob_Amount = 0, ob_pendingbill = 0;
                if (OB.Rows.Count > 0)
                {
                    if (OB.Rows[0]["PendingBill"].ToString() == null || OB.Rows[0]["PendingBill"].ToString() == "")
                    {
                        ob_pendingbill = 0;
                    }
                    else
                    {
                        ob_pendingbill = Convert.ToDecimal(OB.Rows[0]["PendingBill"]);
                    }
                    if (OB.Rows[0]["R_Advance"].ToString() == null || OB.Rows[0]["R_Advance"].ToString() == "")
                    {
                        ob_R_advance = 0;
                    }
                    else
                    {
                        ob_R_advance = Convert.ToDecimal(OB.Rows[0]["R_Advance"]);
                    }
                    if (OB.Rows[0]["C_Advance"].ToString() == null || OB.Rows[0]["C_Advance"].ToString() == "")
                    {
                        ob_C_advance = 0;
                    }
                    else
                    {
                        ob_C_advance = Convert.ToDecimal(OB.Rows[0]["C_Advance"]);
                    }
                    if (OB.Rows[0]["E_Advance"].ToString() == null || OB.Rows[0]["E_Advance"].ToString() == "")
                    {
                        ob_E_Advance = 0;
                    }
                    else
                    {
                        ob_E_Advance = Convert.ToDecimal(OB.Rows[0]["E_Advance"]);
                    }
                    if (OB.Rows[0]["Mis"].ToString() == null || OB.Rows[0]["Mis"].ToString() == "")
                    {
                        ob_Mis = 0;
                    }
                    else
                    {
                        ob_Mis = Convert.ToDecimal(OB.Rows[0]["Mis"]);
                    }
                    if (OB.Rows[0]["PaidOuts"].ToString() == null || OB.Rows[0]["PaidOuts"].ToString() == "")
                    {
                        ob_Paidouts = 0;
                    }
                    else
                    {
                        ob_Paidouts = Convert.ToDecimal(OB.Rows[0]["PaidOuts"]);
                    }
                    if (OB.Rows[0]["Refund"].ToString() == null || OB.Rows[0]["Refund"].ToString() == "")
                    {
                        ob_Refunds = 0;
                    }
                    else
                    {
                        ob_Refunds = Convert.ToDecimal(OB.Rows[0]["Refund"]);
                    }
                    if (OB.Rows[0]["Settle"].ToString() == null || OB.Rows[0]["Settle"].ToString() == "")
                    {
                        ob_Settle = 0;
                    }
                    else
                    {
                        ob_Settle = Convert.ToDecimal(OB.Rows[0]["Settle"]);
                    }
                    ob_Amount = ob_pendingbill + ob_R_advance + ob_C_advance + ob_E_Advance + ob_Mis - ob_Paidouts - ob_Refunds + ob_Settle;
                    OpeningBalance = ob_Amount;
                }
                else
                {
                    OpeningBalance = 0;
                }
            }
            else
            {
                OpeningBalance = Convert.ToDecimal(OB_Amount.Rows[0]["AMOUNT"]);
            }
            row["OpeningBalance"] = Math.Round(OpeningBalance,2,MidpointRounding.AwayFromZero);

            OpeningBalance = 0;
            DataTable OB_Amount_Card = rp.OpeningBalance_Card();
            if (OB_Amount_Card.Rows[0]["AMOUNT"].ToString() == null || OB_Amount_Card.Rows[0]["AMOUNT"].ToString() == "")
            {
                //OpeningBalance = 0;
                rp.OB_Date = date.AddDays(-1).ToShortDateString();
                DataTable OB1 = rp.OB_Getting_Card();
                decimal ob_R_advance1 = 0, ob_C_advance1 = 0, ob_E_Advance1 = 0, ob_Mis1 = 0, ob_Settle1 = 0, ob_Amount1 = 0, ob_pendingbill1 = 0, ob_Paidouts1 = 0;
                if (OB1.Rows.Count > 0)
                {
                    if (OB1.Rows[0]["PendingBill"].ToString() == null || OB1.Rows[0]["PendingBill"].ToString() == "")
                    {
                        ob_pendingbill1 = 0;
                    }
                    else
                    {
                        ob_pendingbill1 = Convert.ToDecimal(OB1.Rows[0]["PendingBill"]);
                    }
                    if (OB1.Rows[0]["R_Advance"].ToString() == null || OB1.Rows[0]["R_Advance"].ToString() == "")
                    {
                        ob_R_advance1 = 0;
                    }
                    else
                    {
                        ob_R_advance1 = Convert.ToDecimal(OB1.Rows[0]["R_Advance"]);
                    }
                    if (OB1.Rows[0]["C_Advance"].ToString() == null || OB1.Rows[0]["C_Advance"].ToString() == "")
                    {
                        ob_C_advance1 = 0;
                    }
                    else
                    {
                        ob_C_advance1 = Convert.ToDecimal(OB1.Rows[0]["C_Advance"]);
                    }
                    if (OB1.Rows[0]["E_Advance"].ToString() == null || OB1.Rows[0]["E_Advance"].ToString() == "")
                    {
                        ob_E_Advance1 = 0;
                    }
                    else
                    {
                        ob_E_Advance1 = Convert.ToDecimal(OB1.Rows[0]["E_Advance"]);
                    }
                    if (OB1.Rows[0]["Mis"].ToString() == null || OB1.Rows[0]["Mis"].ToString() == "")
                    {
                        ob_Mis1 = 0;
                    }
                    else
                    {
                        ob_Mis1 = Convert.ToDecimal(OB1.Rows[0]["Mis"]);
                    }
                    if (OB1.Rows[0]["PaidOuts"].ToString() == null || OB1.Rows[0]["PaidOuts"].ToString() == "")
                    {
                        ob_Paidouts1 = 0;
                    }
                    else
                    {
                        ob_Paidouts1 = Convert.ToDecimal(OB1.Rows[0]["PaidOuts"]);
                    }
                    if (OB1.Rows[0]["Settle"].ToString() == null || OB1.Rows[0]["Settle"].ToString() == "")
                    {
                        ob_Settle1 = 0;
                    }
                    else
                    {
                        ob_Settle1 = Convert.ToDecimal(OB1.Rows[0]["Settle"]);
                    }
                    ob_Amount1 = ob_pendingbill1 + ob_R_advance1 + ob_C_advance1 + ob_E_Advance1 + ob_Mis1 + ob_Settle1 - ob_Paidouts1;
                    OpeningBalance = ob_Amount1;
                }
                else
                {
                    OpeningBalance = 0;
                }
            }
            else
            {
                OpeningBalance = Convert.ToDecimal(OB_Amount_Card.Rows[0]["AMOUNT"]);
            }
            row["OpeningBalanceB"] = Math.Round(OpeningBalance, 2, MidpointRounding.AwayFromZero);
            d.Rows.Add(row);
            return d;
        }
        private DataTable ResAdvance()
        {
            DataTable D = new DataTable();
            D.Columns.Add("R_RoomRes", typeof(string));
            D.Columns.Add("R_GuestName", typeof(string));
            D.Columns.Add("R_Advance", typeof(string));
            D.Columns.Add("R_User", typeof(string));

            DataTable d = rp.FOResAdvance();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D.NewRow();
                if (d.Rows.Count == 0)
                {
                    r["R_RoomRes"] = 0;
                    r["R_GuestName"] = 0;
                    r["R_Advance"] = 0;
                    r["R_User"] = 0;
                }
                else
                {
                    string ResId_Room, charges_paymode;
                    if(d.Rows[i]["ROOM_NO"].ToString() == "" || d.Rows[i]["ROOM_NO"].ToString() == null || d.Rows[i]["ROOM_NO"].ToString() == "0")
                    {
                        ResId_Room = d.Rows[i]["RESERVATION_ID"].ToString();
                    }
                    else
                    {
                        ResId_Room = d.Rows[i]["RESERVATION_ID"] + " (" + d.Rows[i]["ROOM_NO"] + ")";
                    }
                    r["R_RoomRes"] = ResId_Room;
                    r["R_GuestName"] = d.Rows[i]["GUESTNAME"];
                    if (d.Rows[i]["PAYTYPE"].ToString() == "" || d.Rows[i]["PAYTYPE"].ToString() == null)
                    {
                        charges_paymode = Math.Round(Convert.ToDecimal(d.Rows[i]["AMOUNT_RECEIVED"]), 2, MidpointRounding.AwayFromZero) +"  (Card)";
                    }
                    else
                    {
                        charges_paymode = Math.Round(Convert.ToDecimal(d.Rows[i]["AMOUNT_RECEIVED"]), 2, MidpointRounding.AwayFromZero) + " ("+d.Rows[i]["PAYTYPE"]+")";
                    }
                    r["R_Advance"] = charges_paymode;
                    r["R_User"] = d.Rows[i]["INSERT_BY"];
                    if(d.Rows[i]["PAYTYPE"].ToString() == "Cash")
                    {
                        Acash += Convert.ToDecimal(d.Rows[i]["AMOUNT_RECEIVED"]);
                    }
                    else
                    {
                        Acard += Convert.ToDecimal(d.Rows[i]["AMOUNT_RECEIVED"]);
                    }
                    Advances += Convert.ToDecimal(d.Rows[i]["AMOUNT_RECEIVED"]);
                    D.Rows.Add(r);
                }
            }
            return D;
        }
        private DataTable CheckinAdvance()
        {
            DataTable D = new DataTable();
            D.Columns.Add("C_RoomRes", typeof(string));
            D.Columns.Add("C_GuestName", typeof(string));
            D.Columns.Add("C_Advance", typeof(string));
            D.Columns.Add("C_User", typeof(string));

            DataTable d = rp.FOCheckInAdvance();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D.NewRow();
                if (d.Rows.Count == 0)
                {
                    r["C_RoomRes"] = 0;
                    r["C_GuestName"] = 0;
                    r["C_Advance"] = 0;
                    r["C_User"] = 0;
                }
                else
                {
                    string charges_paymode;
                    r["C_RoomRes"] = d.Rows[i]["ROOM_NO"];
                    r["C_GuestName"] = d.Rows[i]["GUESTNAME"];
                    if (d.Rows[i]["PAYTYPE"].ToString() == "" || d.Rows[i]["PAYTYPE"].ToString() == null)
                    {
                        charges_paymode = Math.Round(Convert.ToDecimal(d.Rows[i]["AMOUNT_RECEIVED"]), 2, MidpointRounding.AwayFromZero) + " (Card)";
                    }
                    else
                    {
                        charges_paymode = Math.Round(Convert.ToDecimal(d.Rows[i]["AMOUNT_RECEIVED"]), 2, MidpointRounding.AwayFromZero) + " (" + d.Rows[i]["PAYTYPE"] + ")";
                    }
                    r["C_Advance"] = charges_paymode;
                    r["C_User"] = d.Rows[i]["INSERT_BY"];
                    if (d.Rows[i]["PAYTYPE"].ToString() == "Cash")
                    {
                        Acash += Convert.ToDecimal(d.Rows[i]["AMOUNT_RECEIVED"]);
                    }
                    else
                    {
                        Acard += Convert.ToDecimal(d.Rows[i]["AMOUNT_RECEIVED"]);
                    }
                    Advances += Convert.ToDecimal(d.Rows[i]["AMOUNT_RECEIVED"]);
                    D.Rows.Add(r);
                }
            }
            return D;
        }
        private DataTable ExtraAdvance()
        {
            DataTable D = new DataTable();
            D.Columns.Add("E_RoomRes", typeof(string));
            D.Columns.Add("E_Guestname", typeof(string));
            D.Columns.Add("E_Advance", typeof(string));
            D.Columns.Add("E_User", typeof(string));

            DataTable d = rp.FOExtraAdvance();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D.NewRow();
                if (d.Rows.Count == 0)
                {
                    r["E_RoomRes"] = 0;
                    r["E_Guestname"] = 0;
                    r["E_Advance"] = 0;
                    r["E_User"] = 0;
                }
                else
                {
                    string ResId_Room, charges_paymode;
                    if (d.Rows[i]["RESERVATION_ID"].ToString() == "" || d.Rows[i]["RESERVATION_ID"].ToString() == null || d.Rows[i]["RESERVATION_ID"].ToString() == "0")
                    {
                        ResId_Room = d.Rows[i]["ROOM_NO"].ToString();
                    }
                    else
                    {
                        ResId_Room = d.Rows[i]["ROOM_NO"] + " (" + d.Rows[i]["RESERVATION_ID"] + ")";
                    }
                    r["E_RoomRes"] = ResId_Room;
                    r["E_Guestname"] = d.Rows[i]["GUESTNAME"];
                    if (d.Rows[i]["PAYTYPE"].ToString() == "" || d.Rows[i]["PAYTYPE"].ToString() == null)
                    {
                        charges_paymode = Math.Round(Convert.ToDecimal(d.Rows[i]["AMOUNT_RECEIVED"]), 2, MidpointRounding.AwayFromZero) + "(Card)";
                    }
                    else
                    {
                        charges_paymode = Math.Round(Convert.ToDecimal(d.Rows[i]["AMOUNT_RECEIVED"]), 2, MidpointRounding.AwayFromZero) + " (" + d.Rows[i]["PAYTYPE"] + ")";
                    }
                    r["E_Advance"] = charges_paymode;
                    r["E_User"] = d.Rows[i]["INSERT_BY"];
                    if (d.Rows[i]["PAYTYPE"].ToString() == "Cash")
                    {
                        Acash += Convert.ToDecimal(d.Rows[i]["AMOUNT_RECEIVED"]);
                    }
                    else
                    {
                        Acard += Convert.ToDecimal(d.Rows[i]["AMOUNT_RECEIVED"]);
                    }
                    Advances += Convert.ToDecimal(d.Rows[i]["AMOUNT_RECEIVED"]);
                    D.Rows.Add(r);
                }
            }
            return D;
        }
        public DataTable postcharges()
        {
            DataTable D = new DataTable();
            D.Columns.Add("Room", typeof(string));
            D.Columns.Add("GuestName", typeof(string));
            D.Columns.Add("Charges", typeof(string));
            D.Columns.Add("Reason", typeof(string));
            D.Columns.Add("User", typeof(string));
            D.Columns.Add("SNo", typeof(string));

            DataTable d = rp.FOPostCharge();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D.NewRow();
                if (d.Rows.Count == 0)
                {
                    r["Room"] = 0;
                    r["GuestName"] = 0;
                    r["Charges"] = 0;
                    r["User"] = 0;
                }
                else
                {
                    r["Room"] = d.Rows[i]["ROOM_NO"].ToString();
                    r["GuestName"] = d.Rows[i]["GUEST_NAME"].ToString();
                    r["Charges"] = Math.Round(Convert.ToDecimal(d.Rows[i]["CHARGES"]), 2, MidpointRounding.AwayFromZero).ToString();
                    r["User"] = d.Rows[i]["INSERT_BY"].ToString();
                    D.Rows.Add(r);
                }
            }
            return D;
        }
        public DataTable miscollection()
        {
            DataTable D = new DataTable();
            D.Columns.Add("Amount", typeof(string));
            D.Columns.Add("User", typeof(string));
            D.Columns.Add("Member", typeof(string));
            DataTable d = rp.FOMisColl();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D.NewRow();
                if (d.Rows.Count == 0)
                {
                    r["Amount"] = 0;
                    r["User"] = 0;
                    r["Member"] = 0;
                }
                else
                {
                    if(d.Rows[i]["RECEIVED_AMOUNT"].ToString() == "" || d.Rows[i]["RECEIVED_AMOUNT"].ToString() == null)
                    {
                        r["Amount"] = "";
                        MisCollections += 0;
                    }
                    else
                    {
                        r["Amount"] = Math.Round(Convert.ToDecimal(d.Rows[i]["RECEIVED_AMOUNT"]), 2, MidpointRounding.AwayFromZero).ToString();
                        MisCollections += Convert.ToDecimal(d.Rows[i]["RECEIVED_AMOUNT"]);
                    }
                    r["User"] = d.Rows[i]["INSERT_BY"].ToString();
                    r["Member"] = d.Rows[i]["MEMBER_NAME"].ToString();
                    D.Rows.Add(r);
                }
            }
            return D;
        }
        public DataTable paidout()
        {
            DataTable D = new DataTable();
            D.Columns.Add("Voucher", typeof(string));
            D.Columns.Add("Amount", typeof(string));
            D.Columns.Add("User", typeof(string));
            D.Columns.Add("Name", typeof(string));
            DataTable d = rp.FOPaidOut();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D.NewRow();
                if (d.Rows.Count == 0)
                {
                    r["Voucher"] = 0;
                    r["Amount"] = 0;
                    r["User"] = 0;
                    r["Name"] = 0;
                }
                else
                {
                    r["Voucher"] = d.Rows[i]["VOCHERNUMBER"].ToString();
                    r["Amount"] = Math.Round(Convert.ToDecimal(d.Rows[i]["AMOUNT"]), 2, MidpointRounding.AwayFromZero).ToString()+" ("+ d.Rows[i]["PAY_TYPE"]+")";
                    r["User"] = d.Rows[i]["INSERT_BY"].ToString();
                    r["Name"] = d.Rows[i]["AUTHORIZATIONS"].ToString();
                    Paidouts += Math.Round(Convert.ToDecimal(d.Rows[i]["AMOUNT"]), 2, MidpointRounding.AwayFromZero);
                    D.Rows.Add(r);
                }
            }
            return D;
        }
        public DataTable refund()
        {
            DataTable D = new DataTable();
            D.Columns.Add("ResId", typeof(string));
            D.Columns.Add("Name", typeof(string));
            D.Columns.Add("Balance", typeof(string));
            D.Columns.Add("Reason", typeof(string));
            D.Columns.Add("Amount", typeof(string));
            D.Columns.Add("User", typeof(string));
            DataTable d = rp.FORefund();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D.NewRow();
                if (d.Rows.Count == 0)
                {
                    r["ResId"] = 0;
                    r["Name"] = 0;
                    r["Balance"] = 0;
                    r["User"] = 0;
                }
                else
                {
                    string ResId_RoomNo;
                    if (d.Rows[i]["RESERVATION_ID"].ToString() == "" || d.Rows[i]["RESERVATION_ID"].ToString() == null)
                    {
                        ResId_RoomNo = d.Rows[i]["ROOM_NO"]+"";
                    }
                    else if(d.Rows[i]["ROOM_NO"].ToString() == "" || d.Rows[i]["ROOM_NO"].ToString() == null)
                    {
                        ResId_RoomNo = d.Rows[i]["RESERVATION_ID"] + "";
                    }
                    else
                    {
                        ResId_RoomNo = d.Rows[i]["RESERVATION_ID"] + " ("+d.Rows[i]["ROOM_NO"] +")";
                    }
                    r["ResId"] = ResId_RoomNo;
                    r["Name"] = d.Rows[i]["GUEST_NAME"].ToString();
                    r["Balance"] = Math.Round(Convert.ToDecimal(d.Rows[i]["BALANCE_AMOUNT"]), 2, MidpointRounding.AwayFromZero).ToString();
                    r["User"] = d.Rows[i]["INSERT_BY"].ToString();
                    Refunds += Math.Round(Convert.ToDecimal(d.Rows[i]["BALANCE_AMOUNT"]), 2, MidpointRounding.AwayFromZero);
                    D.Rows.Add(r);
                }
            }
            return D;
        }
        public decimal Amount;
        public DataTable settle()
        {
            DataTable D = new DataTable();
            D.Columns.Add("Room", typeof(string));
            D.Columns.Add("Name", typeof(string));
            D.Columns.Add("Amount", typeof(string));
            D.Columns.Add("User", typeof(string));
            //DataTable d = rp.FOSettle();
            //for (int i = 0; i < d.Rows.Count; i++)
            //{
            //    DataRow r = D.NewRow();
            //    if (d.Rows.Count == 0)
            //    {
            //        r["Room"] = 0;
            //        r["Name"] = 0;
            //        r["Amount"] = 0;
            //        r["User"] = 0;
            //    }
            //    else
            //    {
            //        r["Room"] = d.Rows[i]["ROOM_NO"].ToString();
            //        r["Name"] = d.Rows[i]["GUEST_NAME"].ToString();
            //        r["Amount"] = Math.Round(Convert.ToDecimal(d.Rows[i]["BALANCE_AMOUNT"]), 2, MidpointRounding.AwayFromZero).ToString();
            //        r["User"] = d.Rows[i]["INSERT_BY"].ToString();
            //        D.Rows.Add(r);
            //    }
            //}
            DataTable d = rp.FOSettlements();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D.NewRow();
                if (d.Rows.Count == 0)
                {
                    r["Room"] = 0;
                    r["Name"] = 0;
                    r["Amount"] = 0;
                    r["User"] = 0;
                }
                else
                {
                    //ROOM_NO,RESERVATION_NO,GUEST_NAME,BALANCE_AMOUNT,INSERT_BY,PAYMENT_MODE
                    string Res_Room;
                    if(d.Rows[i]["RESERVATION_NO"].ToString() == "0")
                    {
                        Res_Room = d.Rows[i]["ROOM_NO"].ToString();
                    }
                    else
                    {
                        Res_Room = d.Rows[i]["ROOM_NO"]+" ("+d.Rows[i]["RESERVATION_NO"]+")";
                    }
                    r["Room"] = Res_Room;
                    r["Name"] = d.Rows[i]["GUEST_NAME"].ToString();
                    if(d.Rows[i]["BALANCE_AMOUNT"].ToString()==null || d.Rows[i]["BALANCE_AMOUNT"].ToString() == "")
                    {
                        Amount = 0;
                    }
                    else
                    {
                        Amount = Convert.ToDecimal(d.Rows[i]["BALANCE_AMOUNT"]);
                    }
                    if (Amount > 0)
                    {
                        r["Amount"] = Math.Round(Convert.ToDecimal(d.Rows[i]["BALANCE_AMOUNT"]), 2, MidpointRounding.AwayFromZero) + " (" + d.Rows[i]["PAYMENT_MODE"].ToString() + ")";
                    }else
                    {
                        r["Amount"] = "0.00";
                    }
                    r["User"] = d.Rows[i]["INSERT_BY"].ToString();
                    if (d.Rows[i]["PAYMENT_MODE"].ToString() == "Cash")
                    {
                        SCash += Convert.ToDecimal(d.Rows[i]["BALANCE_AMOUNT"]);
                    }
                    else
                    {
                        SCard += Convert.ToDecimal(d.Rows[i]["BALANCE_AMOUNT"]);
                    }
                    RoomCollection += Convert.ToDecimal(d.Rows[i]["BALANCE_AMOUNT"]);
                    D.Rows.Add(r);
                }
            }
            DataTable d1 = rp.FOOtherSettlements();
            for (int i = 0; i < d1.Rows.Count; i++)
            {
                DataRow r = D.NewRow();
                if (d1.Rows.Count == 0)
                {
                    r["Room"] = 0;
                    r["Name"] = 0;
                    r["Amount"] = 0;
                    r["User"] = 0;
                }
                else
                {
                    //ROOM_NO,PAYTYPE,AMOUNT,INSERT_BY
                    r["Room"] = d1.Rows[i]["ROOM_NO"].ToString();
                    r["Name"] = "";
                    r["Amount"] = Math.Round(Convert.ToDecimal(d1.Rows[i]["AMOUNT"]), 2, MidpointRounding.AwayFromZero) + " (" + d1.Rows[i]["PAYTYPE"].ToString() + ")";
                    r["User"] = d1.Rows[i]["INSERT_BY"].ToString();
                    if (d1.Rows[i]["PAYTYPE"].ToString() == "Bill On Hold")
                    {
                        SBOH += Convert.ToDecimal(d1.Rows[i]["AMOUNT"]);
                    }
                    else if (d1.Rows[i]["PAYTYPE"].ToString() == "Complimentry")
                    {
                        SComplimentry += Convert.ToDecimal(d1.Rows[i]["AMOUNT"]);
                    }
                    else
                    {
                        SBOH += Convert.ToDecimal(d1.Rows[i]["AMOUNT"]);
                    }
                    D.Rows.Add(r);
                }
            }
            return D;
        }
        public DataTable ResCancel()
        {
            DataTable D = new DataTable();
            D.Columns.Add("ResId", typeof(string));
            D.Columns.Add("Name", typeof(string));
            D.Columns.Add("User", typeof(string));
            DataTable d = rp.FORescancel();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                DataRow r = D.NewRow();
                if (d.Rows.Count == 0)
                {
                    r["ResId"] = 0;
                    r["Name"] = 0;
                    r["User"] = 0;
                }
                else
                {
                    r["ResId"] = d.Rows[i]["RESERVATION_ID"].ToString();
                    r["Name"] = d.Rows[i]["GUESTNAME"].ToString();
                    r["User"] = d.Rows[i]["INSERT_BY"].ToString();
                    D.Rows.Add(r);
                }
            }
            return D;
        }
        private static string NumberToText(long n)
        {
            if (n < 0)
                return "Minus " + NumberToText(-n);
            else if (n == 0)
                return "";
            else if (n <= 19)
                return new string[] {"One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight",
                                "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
                                "Seventeen", "Eighteen", "Nineteen"}[n - 1] + " ";
            else if (n <= 99)
                return new string[] {"Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy",
                                "Eighty", "Ninety"}[n / 10 - 2] + " " + NumberToText(n % 10);
            else if (n <= 199)
                return "One Hundred " + NumberToText(n % 100);
            else if (n <= 999)
                return NumberToText(n / 100) + "Hundred " + NumberToText(n % 100);
            else if (n <= 1999)
                return "One Thousand " + NumberToText(n % 1000);
            else if (n <= 999999)
                return NumberToText(n / 1000) + "Thousand " + NumberToText(n % 1000);
            else if (n <= 1999999)
                return "One Million " + NumberToText(n % 1000000);
            else if (n <= 999999999)
                return NumberToText(n / 1000000) + "Million " + NumberToText(n % 1000000);
            else if (n <= 1999999999)
                return "One Billion " + NumberToText(n % 1000000000);
            else
                return NumberToText(n / 1000000000) + "Billion " + NumberToText(n % 1000000000);
        }
    }
}
