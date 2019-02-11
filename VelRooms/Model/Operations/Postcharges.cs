using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using HMS.View.Masters;

namespace HMS.Model
{
    public class Postcharges
    {
        public int ROOMNO { get; set; }
        public DateTime DATE { get; set; }
        public string GUEST_NAME { get; set; }
        public string REVENUE_CODE { get; set; }
        public string PARTICULARS { get; set; }
        public Decimal CHARGES { get; set; }
        public string TAX_CODE { get; set; }
        public Decimal TOTAL_AMOUNT { get; set; }
        public int CHECKIN_ID { get; set; }
        public int VOUCHER_NO { get; set; }
        //11/15/2017
        //public string USER_NAME { get; set; }
        public string INSERT_BY { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime UPDTAE_DATE { get; set; }

        //for night audit
        public double ROOM_TARRIF { get; set; }
        public double EXTRABED_CHILD { get; set; }
        public double EXTRABED_ADULT { get; set; }
        //end for night audit

        public DataTable GET_CHECKEIN_ROOMS()
        {
            string S = "SELECT ROOM_NO FROM ROOMMASTER WHERE BACKGROUND_COLOR=@BGCOLOR";
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@BGCOLOR", "Orange");
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(S, LIST);
            return DT;
        }
        public DataTable GET_DETAILS()
        {
            string S = "SELECT * FROM CHECKIN WHERE ROOM_NO =@ROOMNO AND CHECK_OUT=0";
            var LIS = new List<SqlParameter>();
            LIS.AddSqlParameter("@ROOMNO", ROOMNO);
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(S, LIS);
            return DT;
        }
        public int GET_VOUCHER_NO()
        {
            int a = 0;
            string S = "SELECT MAX(POSTCHARGES_ID) FROM POSTCHARGES";
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
        public void A()
        {
            var LIST = new List<SqlParameter>();
            string SS = "UPDATE POSTCHARGES SET POSTCHARGES=0 WHERE ROOM_NO ='" + ROOMNO + "' AND CHECKIN_ID='"+CHECKIN_ID+"' ";
            DbFunctions.ExecuteCommand<int>(SS, LIST);
        }

      
        public int GET_MAX_NAME()
        {
            int A = 0;
            String S = "SELECT MAX(CHECKIN_ID) FROM CHECKIN WHERE ROOM_NO=@ROOMNO";
            var LIS = new List<SqlParameter>();
            LIS.AddSqlParameter("@ROOMNO", ROOMNO);
            object C = DbFunctions.ExecuteCommand<object>(S, LIS);
            if (C != System.DBNull.Value)
            {
                A = Convert.ToInt32(C);
            }
            return A;

        }

        public string GET_TAXFROM_REVENUE()
        {
            string S = "SELECT TAX_STRUCTURE FROM REVENUE WHERE REVENUE_CODE=@RVCODE";
            var listParams = new List<SqlParameter>();
            listParams.AddSqlParameter("@RVCODE", REVENUE_CODE);
            Object D = DbFunctions.ExecuteCommand<Object>(S, listParams);
            string TAX = D.ToString();
            return TAX;
        }
        public DataTable GET_REVENUE()
        {
            var LIST = new List<SqlParameter>();
            string S = "SELECT NAME FROM REVENUE WHERE MISCELLANOUS='Yes' AND STATUS='ACTIVE' "; 
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(S, LIST);
            return DT;
        }
        public DataTable GET_tax()
        {

            string S = "SELECT TAX_CODE FROM TAX_CODE WHERE STATUS='ACTIVE' ";
            var LIST = new List<SqlParameter>();
            DataTable D1 = DbFunctions.ExecuteCommand<DataTable>(S, LIST);
            return D1;
        }

        public void postextar()
        {
            var list = new List<SqlParameter>();
            string s = "update CHECKIN SET CHARGED_EBED_ADULT=(SELECT EXTRABED_ADULT FROM ROOMMASTER WHERE ROOM_NO = '" + ROOMNO + "'),CHARGED_EBED_CHILD=(SELECT EXTRABED_CHILD FROM ROOMMASTER WHERE ROOM_NO = '" + ROOMNO + "') WHERE ROOM_NO ='" + ROOMNO + "'";
            DbFunctions.ExecuteCommand<int>(s, list);
        }
        //srikar
        public void INSERT()
        {
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@CHECKIN_ID", CHECKIN_ID);
            LIST.AddSqlParameter("@DATE", DATE);
            LIST.AddSqlParameter("@ROOM_NO", ROOMNO);
            LIST.AddSqlParameter("@GUEST_NAME", GUEST_NAME);
            LIST.AddSqlParameter("@REVENUE_CODE", REVENUE_CODE);
            LIST.AddSqlParameter("@PARTICULAR", PARTICULARS);
            LIST.AddSqlParameter("@CHARGES", CHARGES);
            LIST.AddSqlParameter("@TAX_CODE", TAX_CODE);
            LIST.AddSqlParameter("@TOTAL_AMOUNT", TOTAL_AMOUNT);
            // USER INSERT SRIkar INSERTBY
            //LIST.AddSqlParameter("@USER_NAME", srikar);
            INSERT_BY = login.u;
            LIST.AddSqlParameter("@INSERT_BY", INSERT_BY);
            INSERT_DATE = DateTime.Today;
            LIST.AddSqlParameter("@INSERT_DATE", INSERT_DATE);
            string S = "INSERT INTO POSTCHARGES (CHECKIN_ID,ROOM_NO,CHARGED_DATETIME,GUEST_NAME,REVENUE_CODE,PARTICULARS,CHARGES,TAX_CODE,TOTAL_AMOUNT,INSERT_BY,INSERT_DATE)VALUES(@CHECKIN_ID,@ROOM_NO,@DATE,@GUEST_NAME,@REVENUE_CODE,@PARTICULAR,@CHARGES,@TAX_CODE,@TOTAL_AMOUNT,@INSERT_BY,@INSERT_DATE)";
            DbFunctions.ExecuteCommand<int>(S, LIST);
        }

        //SELECT POSTCHARGES_ID, TOTAL_AMOUNT FROM POSTCHARGES WHERE CHECKIN_ID = 232 And ROOM_NO = 203 AND POSTCHARGES = 0
        public DataTable Getpostcharges()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT CHARGES FROM POSTCHARGES WHERE CHECKIN_ID = '" + CHECKIN_ID + "' AND POSTCHARGES = 0 And ROOM_NO = '" + ROOMNO + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {
                CHARGES = 0;
            }
            else
            {
                CHARGES = Convert.ToDecimal(dt.Rows[0]["CHARGES"]);
            }
            return dt;
        }
        public DataTable GetNightAuditcharges()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT SUM(EXTRABED_ADULT) AS EXTRABED_ADULT,SUM(EXTRABED_CHILD) AS EXTRABED_CHILD,SUM(ROOM_TARRIF) AS ROOM_TARRIF FROM night_audit WHERE CHECKIN_ID = '" + CHECKIN_ID + "' AND NIGHT = 0 And ROOM_NO = '" + ROOMNO + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {
                EXTRABED_ADULT = 0;
                EXTRABED_CHILD = 0;
                ROOM_TARRIF = 0;
            }
            else
            {
                EXTRABED_ADULT = Convert.ToDouble(dt.Rows[0]["EXTRABED_ADULT"]);
                EXTRABED_CHILD = Convert.ToDouble(dt.Rows[0]["EXTRABED_CHILD"]);
                ROOM_TARRIF = Convert.ToDouble(dt.Rows[0]["ROOM_TARRIF"]);
            }
            return dt;
        }
    }
}
