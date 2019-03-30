using DAL;
using HMS.View.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model.Operations
{
    public class Settle1
    {
        public string BILL_NO { get; set; }
        public string ROOM_NO { get; set; }
        public string GUEST_NAME { get; set; }
        public string REGISTRATIOIN_NO { get; set; }
        public string COMPANYNAME { get; set; }
        public string TOTAL { get; set; }
        public string TIP_AMOUNT { get; set; }
        public string STATUS { get; set; }
        public string BALANCE { get; set; }
        public string ADVANCE { get; set; }
        public string BALANCE_AMOUNT { get; set; }
        public string PAYMENT_MODE { get; set; }
        public string ONLINE_PAYMENT { get; set; }
        public string CURRENCY { get; set; }
        public string AMOUNT { get; set; }
        public string TRANSFER_NO { get; set; }
        public string CHEQUE_NO { get; set; }
        public string TO_ROOMNO { get; set; }
        public string TOROOM { get; set; }
        public string REMARKS { get; set; }
        public string OTHER { get; set; }
        public string TO_GUEST { get; set; }
        //public string USER_NAME { get; set; }
        public string INSERT_BY { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public void insert()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@BILL_NO", BILL_NO);
            list.AddSqlParameter("@ROOM_NO", ROOM_NO);
            list.AddSqlParameter("@GUEST_NAME", GUEST_NAME);
            list.AddSqlParameter("@RESERVATION_NO", REGISTRATIOIN_NO);
            list.AddSqlParameter("@COMPANY_NAME", COMPANYNAME);
            list.AddSqlParameter("@TOTAL", TOTAL);
            list.AddSqlParameter("@TIP_AMOUNT", TIP_AMOUNT);
            list.AddSqlParameter("@BALANCE_AMOUNT", BALANCE_AMOUNT);
            list.AddSqlParameter("@PAYMENT_MODE", PAYMENT_MODE);
            list.AddSqlParameter("@ONLINE_PAYMENT", ONLINE_PAYMENT);
            list.AddSqlParameter("@CURRENCY", CURRENCY);
            list.AddSqlParameter("@AMOUNT", AMOUNT);
            list.AddSqlParameter("@TRANSFER_NO", TRANSFER_NO);
            list.AddSqlParameter("@CHEQUE_NO", CHEQUE_NO);
            list.AddSqlParameter("@TOROOM", TOROOM);
            list.AddSqlParameter("@REMARKS", REMARKS);
            //list.AddSqlParameter("@USER_NAME", USER_NAME);
            INSERT_BY = login.u;
            INSERT_DATE = DateTime.Today;
            list.AddSqlParameter("@INSERT_BY", INSERT_BY);
            list.AddSqlParameter("@INSERT_DATE", INSERT_DATE);
            //USER_NAME = login.u;
            string QUERY = "INSERT INTO SETTLE(BILL_NO,ROOM_NO,GUEST_NAME,RESERVATION_NO,COMPANY_NAME,TOTAL,TIP_AMOUNT,BALANCE_AMOUNT,PAYMENT_MODE,ONLINE_PAYMENT,CURRENCY,AMOUNT,TRANSFER_NO,CHEQUE_NO,INSERT_BY,INSERT_DATE) VALUES(@BILL_NO,@ROOM_NO,@GUEST_NAME,@RESERVATION_NO,@COMPANY_NAME,@TOTAL,@TIP_AMOUNT,@BALANCE_AMOUNT,@PAYMENT_MODE,@ONLINE_PAYMENT,@CURRENCY,@AMOUNT,@TRANSFER_NO,@CHEQUE_NO,@INSERT_BY,@INSERT_DATE)";
            DbFunctions.ExecuteCommand<int>(QUERY, list);
        }
        public void otherinsert()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@BILL_NO", BILL_NO);
            list.AddSqlParameter("@ROOM_NO", ROOM_NO);
            list.AddSqlParameter("@PAYTYPE", OTHER);
            list.AddSqlParameter("@AMOUNT", AMOUNT);
            list.AddSqlParameter("@TIP_AMOUNT", TIP_AMOUNT);
            list.AddSqlParameter("@REMARKS", REMARKS);
            list.AddSqlParameter("@TO_ROOMNO", TO_ROOMNO);
            list.AddSqlParameter("@STATUS", STATUS);
            list.AddSqlParameter("@BALANCE", BALANCE);
            list.AddSqlParameter("@ADVANCE", ADVANCE);
            //list.AddSqlParameter("@USER_NAME", USER_NAME);
            list.AddSqlParameter("@INSERT_BY", INSERT_BY);
            list.AddSqlParameter("@INSERT_DATE", INSERT_DATE);
            //USER_NAME = login.u;
            INSERT_BY = login.u;
            INSERT_DATE = DateTime.Today;
            string s = "INSERT INTO SETTLE_OTHERPAY (BILL_NO,ROOM_NO,PAYTYPE,AMOUNT,TIP_AMOUNT,REMARKS,TO_ROOMNO,STATUS,BALANCE,ADVANCE,INSERT_BY,INSERT_DATE,COMPANYNAME)" +
                "VALUES (@BILL_NO,@ROOM_NO,@PAYTYPE,@AMOUNT,@TIP_AMOUNT,@REMARKS,@TO_ROOMNO,@STATUS,@BALANCE,(Select ADVANCE from PRINTSTATUS where BILL_NO = @BILL_NO),@INSERT_BY,@INSERT_DATE,(SELECT COMPANY_NAME FROM CHECKIN WHERE  ROOM_NO='" + ROOM_NO + "' AND CHECK_OUT=0))";
            DbFunctions.ExecuteCommand<int>(s, list);
        }
        public void update_color()
        {
            var list = new List<SqlParameter>();
            string color = "UPDATE ROOMMASTER SET BACKGROUND_COLOR = @BGCOLOR WHERE ROOM_NO=@ROOMNO";
            list.AddSqlParameter("@BGCOLOR", "Blue");
            list.AddSqlParameter("@ROOMNO", ROOM_NO);
            DbFunctions.ExecuteCommand<DataTable>(color, list);
        }
        public void roomstatus()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@ROOMNO", ROOM_NO);
            string s = "UPDATE ROOMSTATUS SET STATUS = 0 WHERE STATUS=1 AND ROOM_NO=@ROOMNO";
            DbFunctions.ExecuteCommand<int>(s, list);
        }
        public void get_reservation_no()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT RESERVATION_ID FROM CHECKIN WHERE ROOM_NO = '" + ROOM_NO + "'";
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (DT.Rows.Count == 0)
            {
                REGISTRATIOIN_NO = "0";
            }
            else
            {
                REGISTRATIOIN_NO = DT.Rows[0]["RESERVATION_ID"].ToString();
            }
        }
        public void TRANSFER()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@FROMROOM_NO", ROOM_NO);
            list.AddSqlParameter("@FROMROOM_GUEST", GUEST_NAME);
            list.AddSqlParameter("@TOROOM_NO", TO_ROOMNO);
            list.AddSqlParameter("@TOROOM_GUEST", TO_GUEST);
            list.AddSqlParameter("@PAYTYPE", OTHER);
            list.AddSqlParameter("@AMOUNT", BALANCE);
            list.AddSqlParameter("@REMARKS", REMARKS);
            //list.AddSqlParameter("@USER_NAME", USER_NAME);
            list.AddSqlParameter("@INSERT_BY", INSERT_BY);
            list.AddSqlParameter("@INSERT_DATE", INSERT_DATE);
            //USER_NAME = login.u;
            INSERT_BY = login.u;
            INSERT_DATE = DateTime.Today;
            string ss = "INSERT INTO SETTLE_TRANSFERPAY(CHECKOUT_ID,FROMROOMCHECKIN_ID,TOROOMCHECKIN_ID,FROMROOM_NO,TOROOM_NO,FROMROOM_GUEST,TOROOM_GUEST,PAYTYPE,AMOUNT,REMARKS,INSERT_BY,INSERT_DATE)VALUES((SELECT BILL_NO FROM PRINTSTATUS WHERE ROOM_NO=@FROMROOM_NO AND CHECKIN_ID = (SELECT CHECKIN_ID FROM CHECKIN WHERE ROOM_NO = @FROMROOM_NO AND CHECK_OUT = 0)),(SELECT CHECKIN_ID FROM CHECKIN WHERE ROOM_NO = @FROMROOM_NO AND CHECK_OUT = 0),(SELECT CHECKIN_ID FROM CHECKIN WHERE ROOM_NO = @TOROOM_NO AND CHECK_OUT = 0),@FROMROOM_NO,@TOROOM_NO,(SELECT FIRSTNAME FROM CHECKIN WHERE ROOM_NO = @FROMROOM_NO AND CHECK_OUT = 0),(SELECT FIRSTNAME FROM CHECKIN WHERE ROOM_NO = @TOROOM_NO AND CHECK_OUT = 0),@PAYTYPE,@AMOUNT,@REMARKS,@INSERT_BY,@INSERT_DATE)";
            DbFunctions.ExecuteCommand<int>(ss, list);
        }
        //PENDING BILL COLLECTION 
        //SRIKAR 20/11/2017
        public DataTable get()
        {
            var list = new List<SqlParameter>();
            string s = "select BILL_NO,RESERVATION_NO,ROOM_NO,GUEST_NAME,COMPANY_NAME,CONVERT(decimal(17,2),BALANCE_AMOUNT)AS BALANCE_AMOUNT from SETTLE WHERE BILL_NO ='" + BILL_NO + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {
                BILL_NO = "";
                REGISTRATIOIN_NO = "";
                ROOM_NO = "";
                GUEST_NAME = "";
                COMPANYNAME = "";
                BALANCE_AMOUNT = "";
            }
            else
            {
                BILL_NO = dt.Rows[0]["BILL_NO"].ToString();
                REGISTRATIOIN_NO = dt.Rows[0]["RESERVATION_NO"].ToString();
                ROOM_NO = dt.Rows[0]["ROOM_NO"].ToString();
                GUEST_NAME = dt.Rows[0]["GUEST_NAME"].ToString();
                COMPANYNAME = dt.Rows[0]["COMPANY_NAME"].ToString();
                BALANCE_AMOUNT = dt.Rows[0]["BALANCE_AMOUNT"].ToString();
            }
            return dt;
        }
        public string ColorUpdate(string s)
        {
            var list = new List<SqlParameter>();
            string color = "UPDATE ROOMMASTER SET BACKGROUND_COLOR = '" + s.ToString() + "' WHERE ROOM_NO = '" + ROOM_NO + "' ";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(color, list);
            return dt.ToString();
        }
        public void update()
        {
            //UPDATE night_audit SET NIGHT = 1 WHERE CHECKIN_ID =(select CHECKIN_ID FROM CHECKIN where ROOM_NO = '" + ROOM_NO + "' AND CHECK_OUT =0)
            var list = new List<SqlParameter>();
            string u = "UPDATE night_audit SET NIGHT = 1 WHERE CHECKIN_ID =(Select CHECKIN_ID FROM CHECKIN where ROOM_NO = '" + ROOM_NO + "' AND CHECK_OUT =0)";
            DbFunctions.ExecuteCommand<int>(u, list);
        }
        public void printsupdate()
        {
            var list = new List<SqlParameter>();
            string s = "Update PRINTS set PRINTSTATUS=1 WHERE ROOM_NO='" + ROOM_NO + "'";
            DbFunctions.ExecuteCommand<int>(s, list);
        }
        public void printsBILLLUPDATE()
        {
            var list = new List<SqlParameter>();
            string s = "Update PRINTSTATUS set BILLSETTLE = 1 WHERE CHECKIN_ID =(Select CHECKIN_ID FROM CHECKIN where ROOM_NO = '" + ROOM_NO + "' AND CHECK_OUT =0)";
            DbFunctions.ExecuteCommand<int>(s, list);
        }
        public void UP()
        {
            var I = new List<SqlParameter>();
            string S = "UPDATE INGUESTHOUSEINFO SET GUESTSTATUS = 1 WHERE ROOM_NO='" + ROOM_NO + "' AND GUEST_NAME='"+GUEST_NAME+"'";
            DbFunctions.ExecuteCommand<int>(S, I);
        }
        public string pendingbillcompany;
        public DataTable companypendingbill()
        {
            var list = new List<SqlParameter>();
            string s = "select SUM(AMOUNT)AS AMOUNT, (SELECT COMPANYNAME FROM SETTLE_OTHERPAY WHERE  STATUS=0 ) as COMPANYNAME,(SELECT INSERT_DATE FROM SETTLE_OTHERPAY WHERE  STATUS=0 ) from SETTLE_OTHERPAY WHERE  STATUS=0  ";
            DataTable D= DbFunctions.ExecuteCommand<DataTable>(s, list);
            if(D.Rows.Count == 0)
            {
                pendingbillcompany = "0";
            }
            else
            {
                pendingbillcompany= D.Rows[0]["AMOUNT"].ToString();
            }
            return D ;
        }
        public int f = 0;
        public void BILL()
        {
            string S = "SELECT MAX(BILL_NO) as b FROM PRINTSTATUS";
            var L = new List<SqlParameter>();
            DataTable c = DbFunctions.ExecuteCommand<DataTable>(S, L);
            if (c.Rows[0]["b"].ToString() == null || c.Rows[0]["b"].ToString() == "")
            {
                f = 0;
            }
            else
            {
                f = Convert.ToInt32(c.Rows[0]["b"].ToString());
            }
        }
        public DataTable DETAILS()
        {
            var list = new List<SqlParameter>();
            string S = "SELECT BILL_NO,ROOM_NO,GUEST_NAME,CONVERT(decimal(17,2), BALANCE_AMOUNT) AS BALANCE_AMOUNT FROM PRINTSTATUS WHERE BILL_NO='" + f + "'AND BILLSETTLE=0";
            DataTable s = DbFunctions.ExecuteCommand<DataTable>(S, list);
            return s;
        }
        public DataTable OccupiedCheck()
        {
            //select* from ROOMMASTER where ROOM_NO = '401' and BACKGROUND_COLOR = 'Blue'
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@ROOM_NO", ROOM_NO);
            string S = "Select * from ROOMMASTER where ROOM_NO = @ROOM_NO And BACKGROUND_COLOR = 'Orange'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, list);
            return dt;
        }
    }
}