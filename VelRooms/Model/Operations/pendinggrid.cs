using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.SqlClient;
using System.Data;

namespace HMS.Model.Operations
{
    public class pendinggrid
    {
        public string ROOM_NO { get; set; }
        public string BILL_NO { get; set; }
        public string GUEST_NAME { get; set; }
        public string COMPANY { get; set; }
        public string INSERT_DATE { get; set; }
        public string RESERVATION_NO { get; set; }
        public string PENDINGAMOUNT { get; set; }
        public DataTable GridData()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT * FROM SETTLE_OTHERPAY WHERE PAYTYPE = 'Bill On Hold' AND STATUS = 'BOH'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s,list);
            return dt;
        }
        public void Reservation_No()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@res", ROOM_NO);
            string s = "SELECT RESERVATION_ID FROM CHECKIN WHERE ROOM_NO = @RES AND CHECK_OUT = 0";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if(dt.Rows.Count == 0)
            {
                RESERVATION_NO = "0";
            }
            else
            {
                RESERVATION_NO = dt.Rows[0]["RESERVATION_ID"].ToString();
            }
        }
        public void Guestname()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@bill", BILL_NO);
            string s = "SELECT GUEST_NAME,COMPANYNAME FROM PRINTSTATUS WHERE BILL_NO = @bill";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if(dt.Rows.Count == 0)
            {
                GUEST_NAME = "";
                COMPANY = "";
            }
            else
            {
                GUEST_NAME = dt.Rows[0]["GUEST_NAME"].ToString();
                COMPANY = dt.Rows[0]["COMPANYNAME"].ToString();
            }
        }
        public void Checkout()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@bill", BILL_NO);
            string s = "SELECT INSERT_DATE,BALANCE FROM SETTLE_OTHERPAY WHERE BILL_NO = @bill";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if(dt.Rows.Count == 0)
            {
                //INSERT_DATE = "";
                PENDINGAMOUNT = "0.00";
            }
            else
            {
                DateTime ss = Convert.ToDateTime(dt.Rows[0]["INSERT_DATE"]).Date;
                INSERT_DATE = ss.ToShortDateString();
                PENDINGAMOUNT = dt.Rows[0]["BALANCE"].ToString();
            }
        }
    }
}
