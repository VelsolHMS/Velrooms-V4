using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Model.Operations
{
    public class Print
    {
        public string BILL_NO { get; set; }
        public string DATES { get; set; }
        public string ROOM_NO { get; set; }
        public string ARRIVALDATE { get; set; }
        public string DEPARTUREDATE { get; set; }
        public string GUESTNAME { get; set; }
        public string MOBILENO { get; set; }
        public string ROOMTARRIF { get; set; }
        public string EXTRACHARGES { get; set; }
        public string CGST { get; set; }
        public string SGST { get; set; }
        public string TOTAL { get; set; }
        public string TRANSFERAMOUNT { get; set; }
        public string ADVANCE { get; set; }
        public string DISCOUNT { get; set; }
        public string BLANCEAMOUNT { get; set; }
        public string COMPANYNAME { get; set; }
        public DataTable get()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT * FROM PRINTSTATUS WHERE BILL_NO = '" + BILL_NO + "'AND BILLSETTLE=0";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Bill_No Already Settled");
            }
            else
            {
                BILL_NO = dt.Rows[0]["BILL_NO"].ToString();
                DATES = dt.Rows[0]["DATE"].ToString();
                ARRIVALDATE = dt.Rows[0]["ARRIVAL_DATE"].ToString();
                DEPARTUREDATE = dt.Rows[0]["DEPARTURE_DATE"].ToString();
                ROOM_NO = dt.Rows[0]["ROOM_NO"].ToString();
                GUESTNAME = dt.Rows[0]["GUEST_NAME"].ToString();
                MOBILENO = dt.Rows[0]["MOBILE_NO"].ToString();
                COMPANYNAME = dt.Rows[0]["COMPANYNAME"].ToString();
                TOTAL = dt.Rows[0]["TOTAL"].ToString();
                // dt.Rows[0]["TIP_AMOUNT"].ToString();
                BLANCEAMOUNT = dt.Rows[0]["BALANCE_AMOUNT"].ToString();
            }
            return dt;
        }
        public DataTable getbilllist()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT * FROM PRINTSTATUS WHERE BILLSETTLE=0";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public int id { get; set; }
        public DataTable REPRINT()
        {
            var list = new List<SqlParameter>();
            string s = "select FIRSTNAME,ADDRESS,ROOM_NO,CHARGED_TARRIF,TAX,RESERVATION_ID,ROOM_CATEGORY,ARRIVAL_DATE,ARRIVAL_TIME,(SELECT BILL_NO FROM PRINTSTATUS WHERE CHECKIN_ID='" + id+"') AS INVOICENO,(SELECT INSERT_DATE FROM PRINTSTATUS WHERE CHECKIN_ID='"+id+"') AS CHECKOUT from CHECKIN where CHECKIN_ID='"+id+"'";
            DataTable D = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return D;
        }
        public DataTable CheckoutCharges()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT (SELECT SUM(AMOUNT_RECEIVED) from ADVANCE where CHECKIN_ID = c.CHECKIN_ID AND ADVANCE = 1) AS Advance," +
                    "(SELECT SUM(CHARGES) from POSTCHARGES where CHECKIN_ID = c.CHECKIN_ID AND POSTCHARGES = 1) As Charges," +
                    "(SELECT SUM(AMOUNT) from DISCOUNT where CHECKIN_ID = c.CHECKIN_ID AND DISCOUNT = 1) As Discount," +
                    "(SELECT COUNT(ROOM_TARRIF) from night_audit where CHECKIN_ID = c.CHECKIN_ID AND NIGHT = 1) As AuditCount," +
                    "(SELECT SUM(AMOUNT) from SETTLE_TRANSFERPAY where TOROOMCHECKIN_ID = c.CHECKIN_ID) As TransferAmount,"+
                    "(SELECT SUM(BALANCE_AMOUNT) from REFUND where CHECKIN_ID = c.CHECKIN_ID) As Refund from CHECKIN c Where CHECKIN_ID = '" + id+"'";
            DataTable D = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return D;
        }
        public int ids { get; set; }
        public DataTable reprintcount()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT c.INSERT_DATE,c.ROOM_TARRIF,(SELECT SUM(AMOUNT_RECEIVED) FROM ADVANCE WHERE ADVANCE = 1 AND CHECKIN_ID = c.CHECKIN_ID AND INSERT_DATE = c.INSERT_DATE) AS ADVANCE," +
                "(Select SUM(CHARGES) from POSTCHARGES where POSTCHARGES = 1 AND  CHECKIN_ID = c.CHECKIN_ID AND INSERT_DATE = c.INSERT_DATE) AS CHARGES," +
                "c.GST FROM night_audit c WHERE NIGHT = 1 AND CHECKIN_ID = '"+ ids + "'";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d; 
        }
        public DateTime From_dt { get; set; }
        public DateTime To_dt { get; set; }
        public decimal rp_Advance, rp_Charges;
        public DataTable GetAdvance()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT Sum(AMOUNT_RECEIVED) as ADVANCE from ADVANCE where INSERT_DATE Between '"+ From_dt + "' and '"+To_dt+"' and CHECKIN_ID = '" + ids + "' AND ADVANCE = 1";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if(d.Rows.Count == 0)
            {
                rp_Advance = 0;
            }
            else
            {
                if(d.Rows[0]["ADVANCE"].ToString() == null || d.Rows[0]["ADVANCE"].ToString() == "")
                {
                    rp_Advance = 0;
                }
                else
                {
                    rp_Advance = Convert.ToDecimal(d.Rows[0]["ADVANCE"]);
                }
            }
            return d;
        }
        public DataTable GetCharges()
        {
            var list = new List<SqlParameter>();
            string s = "select Sum(CHARGES) as CHARGES from POSTCHARGES where INSERT_DATE Between '" + From_dt + "' and '" + To_dt + "' and CHECKIN_ID = '" + ids + "' AND POSTCHARGES = 1";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (d.Rows.Count == 0)
            {
                rp_Charges = 0;
            }
            else
            {
                if (d.Rows[0]["CHARGES"].ToString() == null || d.Rows[0]["CHARGES"].ToString() == "")
                {
                    rp_Charges = 0;
                }
                else
                {
                    rp_Charges = Convert.ToDecimal(d.Rows[0]["CHARGES"]);
                }
            }
            return d;
        }
        public int GET_MAXBILLNO()
        {
            int a = 0;
            string S = "SELECT MAX(BILL_NO) FROM PRINTSTATUS";
            var L = new List<SqlParameter>();
            object c = DbFunctions.ExecuteCommand<object>(S, L);
            if (c == System.DBNull.Value)
            {
                a = 1;
            }
            else
            {
                a = Convert.ToInt32(c);
                a = a + 1;
            }
            return a;
        }
    }
}



