using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using HMS.View.Masters;
using HMS.View.Operations;

namespace HMS.Model
{
    public class REFUND
    {
        public string GUEST_NAME { get; set; }
        public int PAX { get; set; }
        public DateTime ARRIVAL_DATE { get; set; }
        public DateTime DEPATURE_DATE { get; set; }
        public decimal ADVANCE_AMOUNT { get; set; }
        public string MOBILE_NO { get; set; }
        public int ROOMS { get; set; }
        public string COMPANY_NAME { get; set; }
        public decimal AMOUNT { get; set; }
        public decimal BALANCE_AMOUNT { get; set; }
        public string REASON { get; set; }
        public int RESERVATION_ID { get; set; }
        public int ADVANCE_ID { get; set; }
        public decimal RETENSION_AMOUNT { get; set; }
        public decimal REFUND_AMOUNT { get; set; }
        public string ADVANCE_STATUS { get; set; }
        //11/15/2017
        //public string USER_NAME { get; set; }
        public string INSERT_BY { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime UPDTAE_DATE { get; set; }
        public string STATUS { get; set; }
        public int ROOM_NO { get; set; }

        public DataTable GET_RESERVED_DATA()
        {
            DataTable D = null;
            string S = "SELECT COUNT(RESERVATION_ID) FROM RESERVATION WHERE RESERVATION_ID=@R_ID";
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@R_ID", RESERVATION_ID);
            object a = DbFunctions.ExecuteCommand<object>(S, LIST);
            int b = Convert.ToInt32(a);
            if (b != 0)
            {
                String ST = "SELECT * FROM RESERVATION WHERE RESERVATION_ID=@R_ID";
                var L = new List<SqlParameter>();
                L.AddSqlParameter("@R_ID", RESERVATION_ID);
                D = DbFunctions.ExecuteCommand<DataTable>(ST, L);
            }
            return D;
        }
        public DataTable get_advance()
        {
            DataTable D = null;
            string s = "select COUNT(RESERVATION_ID) FROM ADVANCE WHERE RESERVATION_ID=@R_ID";
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@R_ID", RESERVATION_ID);
            object a = DbFunctions.ExecuteCommand<object>(s, LIST);
            int b = Convert.ToInt32(a);
            if (b != 0)
            {
                string sT = "select * FROM ADVANCE WHERE RESERVATION_ID=@R_ID";
                var L = new List<SqlParameter>();
                L.AddSqlParameter("@R_ID", RESERVATION_ID);
                D = DbFunctions.ExecuteCommand<DataTable>(sT, L);
            }
            return D;
        }
        public void IREFUND()
        {
            var lis = new List<SqlParameter>();
            lis.AddSqlParameter("@RESERVATION_ID", RESERVATION_ID);
            lis.AddSqlParameter("@GUEST_NAME", GUEST_NAME);
            lis.AddSqlParameter("@COMPANY_NAME", COMPANY_NAME);
            lis.AddSqlParameter("@ARRIVAL_DATE", ARRIVAL_DATE);
            lis.AddSqlParameter("@DEPARTURE_DATE", DEPATURE_DATE);
            lis.AddSqlParameter("@NO_OF_ROOMS", ROOMS);
            lis.AddSqlParameter("@PAX", PAX);
            lis.AddSqlParameter("@ADVANCE_AMOUNT", ADVANCE_AMOUNT);
            lis.AddSqlParameter("@AMOUNT", AMOUNT);
            lis.AddSqlParameter("@BALANCE_AMOUNT", BALANCE_AMOUNT);
            lis.AddSqlParameter("@REASON", REASON);
            lis.AddSqlParameter("@INSERT_BY", INSERT_BY);
            lis.AddSqlParameter("@INSERT_DATE", INSERT_DATE);
            lis.AddSqlParameter("@REFUND_Time", DateTime.Now.ToShortTimeString());
            string refu = "INSERT INTO REFUND (RESERVATION_ID,GUEST_NAME,COMPANY_NAME,ARRIVAL_DATE,DEPARTURE_DATE,NO_OF_ROOMS,PAX,ADVANCE_AMOUNT,AMOUNT,BALANCE_AMOUNT,REASON,INSERT_BY,INSERT_DATE,REFUND_Time)VALUES(@RESERVATION_ID,@GUEST_NAME,@COMPANY_NAME,@ARRIVAL_DATE,@DEPARTURE_DATE,@NO_OF_ROOMS,@PAX,@ADVANCE_AMOUNT,@AMOUNT,@BALANCE_AMOUNT,@REASON,@INSERT_BY,@INSERT_DATE,@REFUND_Time)";
            //USER_NAME = login.u;
            INSERT_BY = login.u;
            INSERT_DATE = DateTime.Today;
            DbFunctions.ExecuteCommand<int>(refu, lis);
            //String ST = "UPDATE ADVANCE SET AMOUNT_RECEIVED=@AM_RC WHERE ADVANCE_ID=@AD_ID AND RESERVATION_ID=@RV_ID";
            //var LI = new List<SqlParameter>();
            //LI.AddSqlParameter("@AM_RC", BALANCE_AMOUNT);
            //LI.AddSqlParameter("@AD_ID", ADVANCE_ID);
            //LI.AddSqlParameter("@RV_ID", RESERVATION_ID);
            //DbFunctions.ExecuteCommand<DataTable>(ST, LI);
            //string SR = "SELECT COUNT(ADVANCE_ID) FROM RETENSION WHERE ADVANCE_ID=@AD_ID";
            //var LIT = new List<SqlParameter>();
            //LIT.AddSqlParameter("@AD_ID", ADVANCE_ID);
            //Object A = DbFunctions.ExecuteCommand<Object>(SR, LIT);
            //int ID = Convert.ToInt32(A);
            //if (ID == 1)
            //{
            //    string STR = "UPDATE RETENSION_CHARGES SET BALANCE_AMOUNT=@B_AMOUNT WHERE ADVANCE_ID=@AD_ID";
            //    var LIS = new List<SqlParameter>();
            //    LIS.AddSqlParameter("@B_AMOUNT", BALANCE_AMOUNT);
            //    LIS.AddSqlParameter("@AD_ID", ADVANCE_ID);
            //    DbFunctions.ExecuteCommand<int>(STR, LIS);
            //}
        }
        public void COUTREFUND()
        {
            var lis = new List<SqlParameter>();
            lis.AddSqlParameter("@ROOM_NO", ROOM_NO);
            lis.AddSqlParameter("@GUEST_NAME", GUEST_NAME);
            lis.AddSqlParameter("@COMPANY_NAME", COMPANY_NAME);
            lis.AddSqlParameter("@ARRIVAL_DATE", ARRIVAL_DATE);
            lis.AddSqlParameter("@DEPARTURE_DATE", DEPATURE_DATE);
            lis.AddSqlParameter("@NO_OF_ROOMS", ROOMS);
            lis.AddSqlParameter("@PAX", PAX);
            lis.AddSqlParameter("@ADVANCE_AMOUNT", ADVANCE_AMOUNT);
            lis.AddSqlParameter("@AMOUNT", AMOUNT);
            lis.AddSqlParameter("@BALANCE_AMOUNT", BALANCE_AMOUNT);
            lis.AddSqlParameter("@REASON", REASON);
            lis.AddSqlParameter("@INSERT_BY", INSERT_BY);
            lis.AddSqlParameter("@INSERT_DATE", INSERT_DATE);
            lis.AddSqlParameter("@CHECKIN_ID", Refund.cid);
            lis.AddSqlParameter("@REFUND_Time", DateTime.Now.ToShortTimeString());
            string refu = "INSERT INTO REFUND (ROOM_NO,GUEST_NAME,COMPANY_NAME,CHECKIN_ID,ARRIVAL_DATE,DEPARTURE_DATE,NO_OF_ROOMS,PAX,ADVANCE_AMOUNT,AMOUNT,BALANCE_AMOUNT,REASON,INSERT_BY,INSERT_DATE,REFUND_Time)VALUES(@ROOM_NO,@GUEST_NAME,@COMPANY_NAME,@CHECKIN_ID,@ARRIVAL_DATE,@DEPARTURE_DATE,@NO_OF_ROOMS,@PAX,@ADVANCE_AMOUNT,@AMOUNT,@BALANCE_AMOUNT,@REASON,@INSERT_BY,@INSERT_DATE,@REFUND_Time)";
            //USER_NAME = login.u;
            INSERT_BY = login.u;
            INSERT_DATE = DateTime.Today;
            DbFunctions.ExecuteCommand<int>(refu, lis);
        }
        //public DataTable updatepamount()
        //{
        //    var list = new List<SqlParameter>();
        //    string s = "UPDATE CHECKOUT SET BALANCE = '0.00' WHERE ROOM_NO = '"+Refund.RRNO+"'";
        //    DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
        //    return dt;
        //}
        public void Guestmobileno()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT MOBILE_NO FROM RESERVATION WHERE RESERVATION_ID = '" + RESERVATION_ID + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            MOBILE_NO = dt.Rows[0]["MOBILE_NO"].ToString();
        }
        public void Status_change()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@STATUS", STATUS);
            string s = "UPDATE RESERVATION SET STATUS = @STATUS WHERE RESERVATION_ID = '" + RESERVATION_ID + "'";
            DbFunctions.ExecuteCommand<int>(s, list);
        }
        public void advanceamount()
        {
            var li = new List<SqlParameter>();
            li.AddSqlParameter("@Advance", ADVANCE_AMOUNT);
            string s = "UPDATE ADVANCE SET AMOUNT_RECEIVED ='" + BALANCE_AMOUNT + "' WHERE RESERVATION_ID = '" + RESERVATION_ID + "'";
            DbFunctions.ExecuteCommand<int>(s, li);
        }
        public void IRETENSION()
        {
            var lis = new List<SqlParameter>();
            lis.AddSqlParameter("@RESERVATION_ID", RESERVATION_ID);
            lis.AddSqlParameter("@GUEST_NAME", GUEST_NAME);
            lis.AddSqlParameter("@COMPANY_NAME", COMPANY_NAME);
            lis.AddSqlParameter("@ARRIVAL_DATE", ARRIVAL_DATE);
            lis.AddSqlParameter("@DEPARTURE_DATE", DEPATURE_DATE);
            lis.AddSqlParameter("@NO_OF_ROOMS", ROOMS);
            lis.AddSqlParameter("@PAX", PAX);
            lis.AddSqlParameter("@ADVANCE_AMOUNT", ADVANCE_AMOUNT);
            lis.AddSqlParameter("@AMOUNT", AMOUNT);
            lis.AddSqlParameter("@BALANCE_AMOUNT", BALANCE_AMOUNT);
            lis.AddSqlParameter("@REASON", REASON);
            lis.AddSqlParameter("@INSERT_BY", INSERT_BY); 
            lis.AddSqlParameter("@INSERT_DATE", INSERT_DATE);
            INSERT_BY = login.u;
            INSERT_DATE = DateTime.Today;
            string rete = "INSERT INTO RETENTION (RESERVATION_ID,GUEST_NAME,COMPANY_NAME,ARRIVAL_DATE,DEPARTURE_DATE,NO_OF_ROOMS,PAX,ADVANCE_AMOUNT,AMOUNT,BALANCE_AMOUNT,REASON,INSERT_BY,INSERT_DATE)VALUES(@RESERVATION_ID,@GUEST_NAME,@COMPANY_NAME,@ARRIVAL_DATE,@DEPARTURE_DATE,@NO_OF_ROOMS,@PAX,@ADVANCE_AMOUNT,@AMOUNT,@BALANCE_AMOUNT,@REASON,@INSERT_BY,@INSERT_DATE)";
            //USER_NAME = login.u;
            
            DbFunctions.ExecuteCommand<int>(rete, lis);
            //String ST = "UPDATE ADVANCE SET AMOUNT_RECEIVED=@AM_RC WHERE ADVANCE_ID=@AD_ID AND RESERVATION_ID=@RV_ID";
            //var LI = new List<SqlParameter>();
            //LI.AddSqlParameter("@AM_RC", BALANCE_AMOUNT);
            //LI.AddSqlParameter("@AD_ID", ADVANCE_ID);
            //LI.AddSqlParameter("@RV_ID", RESERVATION_ID);
            //DbFunctions.ExecuteCommand<int>(ST, LI);
            //string SR = "SELECT COUNT(ADVANCE_ID) FROM REFUND WHERE ADVANCE_ID=@AD_ID";
            //var LIT = new List<SqlParameter>();
            //LIT.AddSqlParameter("@AD_ID", ADVANCE_ID);
            //Object A = DbFunctions.ExecuteCommand<Object>(SR, LIT);
            //int ID = Convert.ToInt32(A);
            //if (ID == 1)
            //{
            //    string STR = "UPDATE REFUND SET BALANCE_AMOUNT=@B_AMOUNT WHERE ADVANCE_ID=@AD_ID";
            //    var LIS = new List<SqlParameter>();
            //    LIS.AddSqlParameter("@B_AMOUNT", BALANCE_AMOUNT);
            //    LIS.AddSqlParameter("@AD_ID", ADVANCE_ID);
            //    DbFunctions.ExecuteCommand<int>(STR, LIS);
            //}
        }
        public void FETCH_MOD_REFUND_RETENSION()
        {
            String S = "SELECT * FROM REFUND WHERE ADVANCE_ID=@AD_ID";
            var LI = new List<SqlParameter>();
            LI.AddSqlParameter("@AD_ID", ADVANCE_ID);
            DataTable D = DbFunctions.ExecuteCommand<DataTable>(S, LI);
            REFUND_AMOUNT = Convert.ToDecimal(D.Rows[0]["AMOUNT"]);
            String STR = "SELECT * FROM RETENSION_CHARGES WHERE ADVANCE_ID=@AD_ID";
            var L = new List<SqlParameter>();
            L.AddSqlParameter("@AD_ID", ADVANCE_ID);
            DataTable DF = DbFunctions.ExecuteCommand<DataTable>(STR, L);
            RETENSION_AMOUNT = Convert.ToDecimal(DF.Rows[0]["AMOUNT"]);

        }
        public void Insert_Cancellation()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@RESERVATION_ID", RESERVATION_ID);
            list.AddSqlParameter("@GUESTNAME", GUEST_NAME);
            list.AddSqlParameter("@MOBILE_NO", MOBILE_NO);
            list.AddSqlParameter("@RESERVATION_STATUS", STATUS);
            list.AddSqlParameter("@INSERT_BY", login.u);
            list.AddSqlParameter("@INSERT_DATE", DateTime.Today);
            list.AddSqlParameter("@ADVANCE_STATUS", ADVANCE_STATUS);
            string s = "INSERT INTO RESERVATIONCANCEL(RESERVATION_ID,GUESTNAME,MOBILE_NO,RESERVATION_STATUS,ADVANCE_STATUS,INSERT_BY,INSERT_DATE) VALUES (@RESERVATION_ID,@GUESTNAME,@MOBILE_NO,@RESERVATION_STATUS,@ADVANCE_STATUS,@INSERT_BY,@INSERT_DATE)";
            DbFunctions.ExecuteCommand<int>(s, list);
        }
        public void UPDATE_REF_RET()
        {
            string reserve = "UPDATE ADVANCE SET AMOUNT_RECEIVED=@AD_R WHERE RESERVATION_ID=@RV_ID";
            var LI = new List<SqlParameter>();
            LI.AddSqlParameter("@AD_R", ADVANCE_AMOUNT);
            LI.AddSqlParameter("@RV_ID", RESERVATION_ID);
            DbFunctions.ExecuteCommand<DataTable>(reserve, LI);
            string REFUND = "UPDATE REFUND SET AMOUNT=@AMOUNT ,BALANCE_AMOUNT=@B_AM WHERE ADVANCE_ID=@AD_ID";
            var L = new List<SqlParameter>();
            L.AddSqlParameter("@AMOUNT", REFUND_AMOUNT);
            L.AddSqlParameter("@B_AM", BALANCE_AMOUNT);
            L.AddSqlParameter("@AD_ID", ADVANCE_ID);
            DbFunctions.ExecuteCommand<DataTable>(REFUND, L);
            string RETENSION = "UPDATE RETENSION_CHARGES SET AMOUNT=@AMOUNT ,BALANCE_AMOUNT=@B_AM WHERE ADVANCE_ID=@AD_ID";
            var LIS = new List<SqlParameter>();
            LIS.AddSqlParameter("@AMOUNT", RETENSION_AMOUNT);
            LIS.AddSqlParameter("@AD_ID", ADVANCE_ID);
            LIS.AddSqlParameter("@B_AM", BALANCE_AMOUNT);
            DbFunctions.ExecuteCommand<DataTable>(RETENSION, LIS);
        }
        //public void UpdateAdvance()
        //{
        //    string reserve = "UPDATE ADVANCE SET AMOUNT_RECEIVED=@AD_R WHERE RESERVATION_ID=@RV_ID";
        //    var LI = new List<SqlParameter>();
        //    LI.AddSqlParameter("@AD_R", ADVANCE_AMOUNT);
        //    LI.AddSqlParameter("@RV_ID", RESERVATION_ID);
        //    DbFunctions.ExecuteCommand<DataTable>(reserve, LI);
        //}
        public void CANCELRESERVATION()
        {
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@RESERVATION_ID", RESERVATION_ID);
            LIST.AddSqlParameter("@INSERT_BY", login.u);
            LIST.AddSqlParameter("@INSERT_DATE", DateTime.Today);
            string S = "INSERT INTO RESERVATIONCANCEL(RESERVATION_ID,GUESTNAME,MOBILE_NO,INSERT_BY,INSERT_DATE)"+
                " VALUES(@RESERVATION_ID,(SELECT FIRSTNAME FROM RESERVATION WHERE STATUS='CANCLED' AND RESERVATION_ID ='" + RESERVATION_ID + "' ),(SELECT MOBILE_NO FROM RESERVATION WHERE STATUS='CANCLED' AND RESERVATION_ID ='" + RESERVATION_ID + "' ),@INSERT_BY,@INSERT_DATE) ";
            DbFunctions.ExecuteCommand<int>(S, LIST);
        }
        public void R1()
        {
            var LIST = new List<SqlParameter>();
            string SS = "UPDATE RESERVATION SET RESERVATION = 1 WHERE RESERVATION_ID ='" + RESERVATION_ID + "'   ";
            DbFunctions.ExecuteCommand<int>(SS, LIST);
        }
        public DataTable fill_grid()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT RESERVATION_ID,FIRSTNAME,MOBILE_NO,ARRIVAL_DATE FROM RESERVATION WHERE STATUS <> 'CANCLED'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
    }
}