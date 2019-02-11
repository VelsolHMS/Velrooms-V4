using System;
using System.Collections.Generic;
using System.Data;
using DAL;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.View.Masters;

namespace HMS.Model
{
    class discount
    {
        public string result;
        public string ROOM_NO { get; set; }
        public string RESERVATION_ID { get; set; }
        public string GUEST_NAME { get; set; }
        public string DISCOUNT_ON_TAX { get; set; }
        public string PARTICULARS { get; set; }
        public string AMOUNT { get; set; }
        public string PERCENTAGE { get; set; }
        public string DISCOUNT_ROOM { get; set; }
        public int CHECKIN_ID { get; set; }
        //11/15/2017
        //public string USER_NAME { get; set; }
        public string INSERT_BY { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime UPDTAE_DATE { get; set; }

        DateTime date = DateTime.Today;
        public void Insert()
        {
            var list = new List<SqlParameter>();

            list.AddSqlParameter("@ROOM_NO", ROOM_NO);
            list.AddSqlParameter("@RESERVATION_NO", RESERVATION_ID);
            list.AddSqlParameter("@GUEST_NAME", GUEST_NAME);
            list.AddSqlParameter("@DISCOUNT_ON_TAX", DISCOUNT_ON_TAX);
            list.AddSqlParameter("@PARTICULARS", PARTICULARS);
            list.AddSqlParameter("@AMOUNT", AMOUNT);
            list.AddSqlParameter("@PERCENTAGE", PERCENTAGE);
            list.AddSqlParameter("@DISCOUNT_DATE", date);
            list.AddSqlParameter("@CHECKIN_ID", CHECKIN_ID);
            // USER INSERT SRI INSERTBY
            //list.AddSqlParameter("@USER_NAME", USER_NAME);
            INSERT_BY = login.u;
            INSERT_DATE = DateTime.Today;
            list.AddSqlParameter("@INSERT_BY", INSERT_BY);
            list.AddSqlParameter("@INSERT_DATE", INSERT_DATE);
            //USER_NAME = login.u;


            //string query = "IF EXISTS (SELECT ROOM_NO FROM DISCOUNT WHERE ROOM_NO = @ROOM_NO AND DISCOUNT=0 AND CHECKIN_ID='"+ CHECKIN_ID +"') BEGIN UPDATE DISCOUNT SET GUEST_NAME = @GUEST_NAME, DISCOUNT_ON_TAX = @DISCOUNT_ON_TAX," +
            //    " PARTICULAR = @PARTICULARS, AMOUNT = @AMOUNT, PERCENTAGE = @PERCENTAGE,DISCOUNT_DATE = @DISCOUNT_DATE,INSERT_BY=@INSERT_BY,INSERT_DATE=@INSERT_DATE WHERE ROOM_NO = @ROOM_NO END ELSE BEGIN INSERT INTO DISCOUNT " +
            //    "(ROOM_NO, RESERVATION_NO, GUEST_NAME, DISCOUNT_ON_TAX, PARTICULAR, AMOUNT, PERCENTAGE, DISCOUNT_DATE, CHECKIN_ID,INSERT_BY,INSERT_DATE) VALUES (@ROOM_NO, @RESERVATION_NO, @GUEST_NAME," +
            //    " @DISCOUNT_ON_TAX, @PARTICULARS, @AMOUNT, @PERCENTAGE, @DISCOUNT_DATE, @CHECKIN_ID,@INSERT_BY,@INSERT_DATE)END";
            string query = " INSERT INTO DISCOUNT " +
               "(ROOM_NO, RESERVATION_NO, GUEST_NAME, DISCOUNT_ON_TAX, PARTICULAR, AMOUNT, PERCENTAGE, DISCOUNT_DATE, CHECKIN_ID,INSERT_BY,INSERT_DATE) VALUES (@ROOM_NO, @RESERVATION_NO, @GUEST_NAME," +
               " @DISCOUNT_ON_TAX, @PARTICULARS, @AMOUNT, @PERCENTAGE, @DISCOUNT_DATE, @CHECKIN_ID,@INSERT_BY,@INSERT_DATE)";
            DbFunctions.ExecuteCommand<int>(query, list);
        }

        //Method To Retrive Room No's
        public DataTable Retrive_Room_No()
        {
            var list = new List<SqlParameter>();

            string query = "SELECT ROOM_NO FROM CHECKIN WHERE CHECK_OUT =0 ";

            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(query, list);

            return dt;
        }

        public void A()
        {
            var LIST = new List<SqlParameter>();
            string SS = "UPDATE DISCOUNT SET DISCOUNT=0 WHERE ROOM_NO ='" + ROOM_NO + "' AND CHECKIN_ID='"+ CHECKIN_ID +"' ";
            DbFunctions.ExecuteCommand<int>(SS, LIST);
        }
        //Method To Retrive Guest Name And Checkin ID No Using Room No
        public DataTable Retrive_guestname()
        {
            var list = new List<SqlParameter>();
            string query = "SELECT FIRSTNAME,CHECKIN_ID FROM CHECKIN WHERE ROOM_NO = '" + ROOM_NO + "' AND CHECK_OUT=0 ";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(query, list);
            if (dt.Rows.Count > 0)
            {
                GUEST_NAME = dt.Rows[0]["FIRSTNAME"].ToString();
                CHECKIN_ID = int.Parse(dt.Rows[0]["CHECKIN_ID"].ToString());
            }
            return dt;
        }
        public DataTable CheckDiscount()
        {
            var list = new List<SqlParameter>();
            string query = "SELECT ROOM_NO, GUEST_NAME, CHECKIN_ID, PARTICULAR, AMOUNT, PERCENTAGE FROM DISCOUNT WHERE CHECKIN_ID = '" + CHECKIN_ID + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(query, list);
            if (dt.Rows.Count > 0)
            {
                GUEST_NAME = dt.Rows[0]["GUEST_NAME"].ToString();
            }
            return dt;
        }
        public void UpdateDiscount()
        {
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@AMOUNT", AMOUNT);
            LIST.AddSqlParameter("@PARTICULARS", PARTICULARS);
            LIST.AddSqlParameter("@PERCENTAGE", PERCENTAGE);
            LIST.AddSqlParameter("@INSERT_DATE", DateTime.Today.Date);
            LIST.AddSqlParameter("@INSERT_BY", login.u);
            string SS = "Update Discount set AMOUNT = @AMOUNT, PARTICULAR = @PARTICULARS, PERCENTAGE = @PERCENTAGE, DISCOUNT_DATE = @INSERT_DATE, INSERT_DATE = @INSERT_DATE, INSERT_BY = @INSERT_BY where CHECKIN_ID = '"+ CHECKIN_ID + "'";
            DbFunctions.ExecuteCommand<int>(SS, LIST);
        }
        //Method To Get Room No To Restrict Discounts
        public DataTable Room_Discount()
        {
            var list = new List<SqlParameter>();
            string query = "SELECT ROOM_NO FROM DISCOUNT WHERE ROOM_NO = '" + ROOM_NO + "' AND CHECKIN_ID='"+ CHECKIN_ID +"' ";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(query, list);
            if (dt.Rows.Count <=0)
            {
                result = "0";
            }
            else
            {
                result = "2";
             DISCOUNT_ROOM = dt.Rows[0]["ROOM_NO"].ToString();
         
            }

            return dt;
        }

        //Method To Retrive Data Using Room No
        public DataTable Retrive()
        {
            var list = new List<SqlParameter>();
            string query = "SELECT * FROM DISCOUNT WHERE ROOM_NO = '" + ROOM_NO + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(query, list);
            RESERVATION_ID = dt.Rows[0]["RESERVATION_NO"].ToString();
            GUEST_NAME = dt.Rows[0]["GUEST_NAME"].ToString();
            DISCOUNT_ON_TAX = dt.Rows[0]["DISCOUNT_ON_TAX"].ToString();
            PARTICULARS = dt.Rows[0]["PARTICULAR"].ToString();
            AMOUNT = dt.Rows[0]["AMOUNT"].ToString();
            PERCENTAGE = dt.Rows[0]["PERCENTAGE"].ToString();
            return dt;
        }
        public DataTable GetdiscountAmount()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT AMOUNT FROM DISCOUNT WHERE CHECKIN_ID = '" + CHECKIN_ID + "' AND DISCOUNT = 0 And ROOM_NO = '" + ROOM_NO + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {
                AMOUNT = "0";
            }
            else
            {
                AMOUNT = dt.Rows[0]["AMOUNT"].ToString();
            }
            return dt;
        }
    }
}
