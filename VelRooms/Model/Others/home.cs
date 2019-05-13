using DAL;
using HMS.View.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model.Others
{
    public class Home
    {
        public string ROOM_CATEGORY { get; set; }

        public DateTime date =  DateTime.Today.Date;
        public DataTable GET_ROOMCATEGORY()
        {
            var listParams = new List<SqlParameter>();
            string S = "SELECT ROOM_CATEGORY FROM ROOMMASTER WHERE ACTIVE_DATE <=current_timestamp AND  STATUS='Active' ";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, listParams);
            return dt;
        }
        public DataTable GET_ROOM_NO(String R)
        {
            var listParams = new List<SqlParameter>();
            string S = "SELECT ROOM_NO FROM ROOMMASTER WHERE ROOM_CATEGORY='" + R + "' AND ACTIVE_DATE <=current_timestamp AND  STATUS='Active'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, listParams);
            return dt;
        }
        public DataTable getstatus()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT ROOM_NO FROM ROOMSTATUS WHERE STATUS=0";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable get_details(int A)
        {
            string s = "SELECT * FROM CHECKIN WHERE ROOM_NO=@ROOMNO";
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@ROOMNO", A);
            DataTable D = DbFunctions.ExecuteCommand<DataTable>(s, LIST);
            return D;
        }
        public DataTable GETBLOCK()
        {
            var LIST = new List<SqlParameter>();
            string s = "SELECT ROOM_NO FROM BLOCK_ROOM";
            DataTable D = DbFunctions.ExecuteCommand<DataTable>(s, LIST);
            return D;
        }
        public string GET_BACKGROUND_COLOR(int A)
        {
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@ROOMNO", A);
            string S = "SELECT BACKGROUND_COLOR FROM ROOMMASTER WHERE ROOM_NO=@ROOMNO";
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(S, LIST);
            string COLOR = DT.Rows[0]["BACKGROUND_COLOR"].ToString();
            return COLOR;
        }
        public DataTable GET_ROOM_NO_COLOR(string s)
        {
            var listParams = new List<SqlParameter>();
            string S = "SELECT ROOM_NO FROM ROOMMASTER WHERE ROOM_CATEGORY=@ROOMCATEGORY AND BACKGROUND_COLOR=@BGCOLOR";
            listParams.AddSqlParameter("@ROOMCATEGORY", s);
            listParams.AddSqlParameter("@BGCOLOR", "Green");
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, listParams);
            return dt;
        }
        public DataTable GET_ROOMCATEGORY_VACANT_ROOM(int A)
        {
            var LIST = new List<SqlParameter>();
            string S = "SELECT ROOM_CATEGORY FROM ROOMMASTER WHERE ROOM_NO=@ROOMNO WHERE ACTIVE_DATE <=current_timestamp AND  STATUS='Active' ";
            LIST.AddSqlParameter("@ROOMNO", A);
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(S, LIST);
            return DT;
        }
        // Method To Retrive Reservation Details
        public DataTable reservation_list()
        {
            var list = new List<SqlParameter>();
            string query = "SELECT RESERVATION_ID,FIRSTNAME,NO_OF_ROOMS,ARRIVAL_DATE,MOBILE_NO FROM RESERVATION WHERE RESERVATION !=1 AND DAY(ARRIVAL_DATE)=DAY(GETDATE()) AND MONTH(ARRIVAL_DATE) = MONTH(GETDATE()) AND YEAR(ARRIVAL_DATE) = YEAR(GETDATE())";
            DataTable reserve = DbFunctions.ExecuteCommand<DataTable>(query, list);
            return reserve;
        }
        public DataTable checkout_list()
        {
            var list = new List<SqlParameter>();
            string query = "SELECT ROOM_NO,FIRSTNAME,DEPARTURE_DATE,MOBILE_NO FROM CHECKIN WHERE CHECK_OUT =0 ";
            DataTable reserve = DbFunctions.ExecuteCommand<DataTable>(query, list);
            return reserve;
        }
        public void truncate()
        {
            var list = new List<SqlParameter>();
            string s = "TRUNCATE TABLE PRINTS";
            DbFunctions.ExecuteCommand<int>(s, list);
        }
        public DataTable btnblink()
        {
            var list = new List<SqlParameter>();
            string s = "select ARRIVAL_TIME from CHECKIN WHERE DEPARTURE_DATE = CAST(GETDATE()AS DATE)";
            DataTable reserve = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return reserve;
        }
        //Opening Balance Daily Auditing..!
        public DataTable CheckingRowsInOB()
        {
            var list = new List<SqlParameter>();
            string s = "select * from PAIDOUT_OPENINGBALANCE where STATUS = 'AUDIT'";
            DataTable reserve = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return reserve;
        }
        public string OPENINGBLANCE { get; set; }
        public string AUTHORIZATIONS { get; set; }
        public string AMOUNT { get; set; }
        public string STATUS { get; set; }
        public string INSERT_BY { get; set; }
        public string INSERT_DATE { get; set; }
        public string AMOUNT_TYPE { get; set; }
        public void OB_INSERT()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@AUTHORIZATIONS", AUTHORIZATIONS);
            list.AddSqlParameter("@AMOUNT", AMOUNT);
            list.AddSqlParameter("@AMOUNT_TYPE", AMOUNT_TYPE);
            list.AddSqlParameter("@STATUS", STATUS);
            list.AddSqlParameter("@INSERT_BY", INSERT_BY);
            list.AddSqlParameter("@INSERT_DATE", INSERT_DATE);
            string SS = "INSERT INTO PAIDOUT_OPENINGBALANCE(AUTHORIZATIONS,AMOUNT,STATUS,AMOUNT_TYPE,INSERT_BY,INSERT_DATE)VALUES(@AUTHORIZATIONS,@AMOUNT,'AUDIT',@AMOUNT_TYPE,@INSERT_BY,@INSERT_DATE)";
            DbFunctions.ExecuteCommand<int>(SS, list);
        }
        public DataTable MaxInsertDate()
        {
            //select max(INSERT_DATE) as INSERT_DATE from PAIDOUT_OPENINGBALANCE where STATUS = 'AUDIT'
            var list = new List<SqlParameter>();
            string s = "SELECT max(INSERT_DATE) as INSERT_DATE from PAIDOUT_OPENINGBALANCE where STATUS = 'AUDIT'";
            DataTable reserve = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return reserve;
        }
        public DateTime TodaysDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public DataTable GettingDataUsingTime()
        {
            var list = new List<SqlParameter>();
            string s = "select DISTINCT (select COUNT(CHECKIN_ID) from checkin where INSERT_DATE = '"+ TodaysDate + "' and ARRIVAL_TIME Between '"+ StartTime + "' and '"+EndTime+"')  As Checkins," +
                        "(select COUNT(CHECKOUT_ID) from CHECKOUT where INSERT_DATE = '" + TodaysDate + "' and Checkout_Time Between '" + StartTime + "' and '" + EndTime + "') As Checkouts," +
                        "(select COUNT(RESERVATION_ID) from RESERVATION where INSERT_DATE = '" + TodaysDate + "' and Reservation_Time Between '" + StartTime + "' and '" + EndTime + "') As Reservations," +
                        "(select Sum(AMOUNT) from SETTLE where INSERT_DATE = '" + TodaysDate + "' and Settle_Time Between '" + StartTime + "' and '" + EndTime + "') As Settlements," +
                        "(select Sum(BALANCE_AMOUNT) from REFUND where INSERT_DATE = '" + TodaysDate + "' and REFUND_Time Between '" + StartTime + "' and '" + EndTime + "') As Refunds," +
                        "(select Sum(AMOUNT_RECEIVED) from ADVANCE where INSERT_DATE = '" + TodaysDate + "' and ADVANCE_Time Between '" + StartTime + "' and '" + EndTime + "') As Advances," +
                        "(select Sum(AMOUNT) from PAIDOUT where INSERT_DATE = '" + TodaysDate + "' and Paidout_Time Between '" + StartTime + "' and '" + EndTime + "') As Paidouts from CHECKIN";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public string SmsMessage { get; set; }
        public string SmsTime { get; set; }
        public string TimeZone { get; set; }
        public string PhoneNo { get; set; }
        public string InsertDate { get; set; }
        public string InsertBy { get; set; }
        public void SmsStatusInsert()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@SmsMessage", SmsMessage);
            list.AddSqlParameter("@SmsTime", DateTime.Now.ToShortTimeString());
            list.AddSqlParameter("@TimeZone", TimeZone);
            list.AddSqlParameter("@PhoneNo", PhoneNo);
            list.AddSqlParameter("@InsertDate", DateTime.Today.Date);
            list.AddSqlParameter("@InsertBy", login.u);
            string SS = "INSERT INTO SMSSTATUS(SmsMessage,SmsTime,TimeZone,PhoneNo,InsertDate,InsertBy)VALUES(@SmsMessage,@SmsTime,@TimeZone,@PhoneNo,@InsertDate,@InsertBy)";
            DbFunctions.ExecuteCommand<int>(SS, list);
        }
        public DataTable CheckingSms()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@InsertDate", DateTime.Today.Date);
            list.AddSqlParameter("@TimeZone", TimeZone);
            string s = "Select * from SMSSTATUS where InsertDate = @InsertDate and TimeZone = @TimeZone";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
    }
}