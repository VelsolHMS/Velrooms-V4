using DAL;
using HMS.View.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HMS.Model
{
    public class advance1
    {
        public string ROOM_NO { get; set; }
        public string RESERVATION_NO { get; set; }
        public string GUEST_NAME { get; set; }
        public string COMPANY { get; set; }
        public string ADVANCE_FOR { get; set; }
        public string CONTACT_NO { get; set; }
        public string PAYMENT_MODE { get; set; }
        public string CURRENCY_CODE { get; set; }
        public string COMPANY_CONTACT { get; set; }
        public string COMPANY_CODE { get; set; }
        public string AMOUNT_RECEIVED { get; set; }
        public string ONLINE_PAYMENT { get; set; }
        public string PARTICULARS { get; set; }
        public string TRANSACTION_NO { get; set; }
        public string RECEIPT_NO { get; set; }
        public string CHEQUE_NO { get; set; }
        //11/15/2017
        //public string USER_NAME { get; set; }
        public string INSERT_BY { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public static DataTable dt { get; set; }
        public DateTime ADVANCE_Time { get; set; }
        //Insertion of data into database
        public void Insert()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@ROOM_NO", ROOM_NO);
            list.AddSqlParameter("@RESERVATION_NO", RESERVATION_NO);
            list.AddSqlParameter("@PAYMENT_MODE", PAYMENT_MODE);
            list.AddSqlParameter("@CURRENCY_CODE", CURRENCY_CODE);
            list.AddSqlParameter("@AMOUNT_RECEIVED", AMOUNT_RECEIVED);
            list.AddSqlParameter("@ONLINE_PAYMENT", ONLINE_PAYMENT);
            list.AddSqlParameter("@PARTICULARS", PARTICULARS);
            list.AddSqlParameter("@TRANSACTION_NO", TRANSACTION_NO);
            list.AddSqlParameter("@RECEIPT_NO", RECEIPT_NO);
            list.AddSqlParameter("@ADVANCE_FOR", ADVANCE_FOR);
            list.AddSqlParameter("@CHEQUE_NO", CHEQUE_NO);
            list.AddSqlParameter("@ADVANCE_Time", DateTime.Now.ToShortTimeString());
            // USER INSERT SRIKAR INSERTBY
            //list.AddSqlParameter("@USER_NAME", USER_NAME);
            INSERT_BY = login.u;
            INSERT_DATE = DateTime.Today;
            list.AddSqlParameter("@INSERT_BY", INSERT_BY);
            list.AddSqlParameter("@INSERT_DATE", INSERT_DATE);
            UPDATE_BY = login.u;
            UPDATE_DATE = DateTime.Today;
            list.AddSqlParameter("@UPDATE_BY", UPDATE_BY);
            list.AddSqlParameter("@UPDATE_DATE", UPDATE_DATE);
            string query = "INSERT INTO ADVANCE(RESERVATION_ID, CHECKIN_ID,ROOM_NO, PAYTYPE, CURRENCY_CODE, AMOUNT_RECEIVED, PARTICULARS, " +
                           "TRANSACTION_NO,RECEIPT_NO,ADVANCE_FOR, CHEQUE_NO,INSERT_BY,INSERT_DATE,ADVANCE,ADVANCE_Time)VALUES (@RESERVATION_NO,(select CHECKIN_ID FROM CHECKIN WHERE ROOM_NO=@ROOM_NO AND CHECK_OUT != 1 ), @ROOM_NO, @PAYMENT_MODE, @CURRENCY_CODE, @AMOUNT_RECEIVED," +
                           "@PARTICULARS, @TRANSACTION_NO, @RECEIPT_NO,@ADVANCE_FOR, @CHEQUE_NO,@INSERT_BY,@INSERT_DATE,'0',@ADVANCE_Time)";
            DbFunctions.ExecuteCommand<int>(query, list);
        }

        public int CHECKINID;
        public static int CHECKIN;
        public DataTable checkinupdate()
        {
            var list = new List<SqlParameter>();
            string s = "Select CHECKIN_ID FROM CHECKIN WHERE ROOM_NO = '" + ROOM_NO + "' AND CHECK_OUT=0 ";
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (DT.Rows.Count == 0)
            {
                CHECKINID = 0;
            }
            else
            {
                CHECKINID = int.Parse(DT.Rows[0]["CHECKIN_ID"].ToString());
                CHECKIN = CHECKINID;
            }
            return DT;
        }
        public DataTable guestinfo()
        {
            var list = new List<SqlParameter>();
            string s = "Select FIRSTNAME,COMPANY_NAME,MOBILE_NO FROM CHECKIN WHERE ROOM_NO = '" + ROOM_NO + "' AND CHECK_OUT=0 ";
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (DT.Rows.Count == 0)
            {
                GUEST_NAME = "";
                COMPANY = "";
                CONTACT_NO = "";
                CHECKINID = 0;
            }
            else
            {
                GUEST_NAME = DT.Rows[0]["FIRSTNAME"].ToString();
                COMPANY = DT.Rows[0]["COMPANY_NAME"].ToString();
                CONTACT_NO = DT.Rows[0]["MOBILE_NO"].ToString();
                CHECKIN = CHECKINID;
            }
            return DT;
        }
        public DataTable Resguestinfo()
        {
            var list = new List<SqlParameter>();
            string s = "select FIRSTNAME,COMPANY_NAME,MOBILE_NO,(SELECT ROOM_NO FROM CHECKIN WHERE RESERVATION_ID='"+RESERVATION_NO+"') AS ROOM_NO from RESERVATION WHERE RESERVATION_ID = '" + RESERVATION_NO + "'";
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (DT.Rows.Count == 0)
            {
                GUEST_NAME = "";
                COMPANY = "";
                CONTACT_NO = "";
                ROOM_NO = "";
            }
            else
            {
                GUEST_NAME = DT.Rows[0]["FIRSTNAME"].ToString();
                COMPANY = DT.Rows[0]["COMPANY_NAME"].ToString();
                CONTACT_NO = DT.Rows[0]["MOBILE_NO"].ToString();
                ROOM_NO = DT.Rows[0]["ROOM_NO"].ToString();
            }
            return DT;
        }
        public DataTable RoomNo()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT ROOM_NO FROM CHECKIN WHERE CHECK_OUT=0";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public void ADV()
        {
            var LIST = new List<SqlParameter>();
            string SS = "UPDATE ADVANCE SET ADVANCE = 0 where ROOM_NO ='" + ROOM_NO + "'  ";
            DbFunctions.ExecuteCommand<int>(SS, LIST);
        }

        //Modified by sRIKAR
        //Method to retrive company code and contact person number.

        public DataTable company_contact()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT CONTACT_PERSON_NUMBER, COMPANY_CODE FROM COMPANYMASTER WHERE COMPANY_NAME = '" + COMPANY + "'";
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (DT.Rows.Count == 0)
            {
                COMPANY_CODE = "0";
                COMPANY_CONTACT = "0";
            }
            else
            {
                COMPANY_CODE = DT.Rows[0]["COMPANY_CODE"].ToString();
                COMPANY_CONTACT = DT.Rows[0]["CONTACT_PERSON_NUMBER"].ToString();
            }
            return DT;
        }
        //public void A()
        //{
        //    var LIST = new List<SqlParameter>();
        //    string SS = "UPDATE ADVANCE SET ADVANCE = 0 where ROOM_NO ='" + ROOM_NO + "'  ";
        //    DbFunctions.ExecuteCommand<int>(SS, LIST);
        //}

        public void COUTADV()
        {
            var LIST = new List<SqlParameter>();
            string SS = "UPDATE ADVANCE SET ADVANCE = 1 where ROOM_NO ='" + ROOM_NO + "'  ";
            DbFunctions.ExecuteCommand<int>(SS, LIST);
        }
        public DataTable GET_HOTELADDRESS()
        {
            String S = "SELECT NAME,PLOT_NO,LANDMARK,CITY,STATE,PINCODE,COUNTRY FROM hotelinfo WHERE HOTELINFO_ID=@HOTELINFOID";
            var L = new List<SqlParameter>();
            L.AddSqlParameter("@HOTELINFOID", 1);
            DataTable D = DAL.DbFunctions.ExecuteCommand<DataTable>(S, L);
            DataTable H = new DataTable();
            H.Columns.Add("NAME", typeof(string)); H.Columns.Add("ADDRESS", typeof(string));
            DataRow DR = H.NewRow();
            H.Rows.Add(DR);

            H.Rows[0]["NAME"] = D.Rows[0]["NAME"];
            H.Rows[0]["ADDRESS"] = "Address" + " : " + D.Rows[0]["PLOT_NO"] + "," + D.Rows[0]["LANDMARK"] + "," + D.Rows[0]["CITY"] + "," + D.Rows[0]["PINCODE"] + "," + D.Rows[0]["STATE"] + "," + D.Rows[0]["COUNTRY"];
            return H;
        }
        public int id()
        {
            int a = 0;
            string S = "SELECT MAX(ADVANCE_ID) FROM ADVANCE";
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
        public DataTable GetadvanceAmount(int CheckinId)
        {
            var list = new List<SqlParameter>();
            string s = "SELECT AMOUNT_RECEIVED FROM ADVANCE WHERE CHECKIN_ID = '"+ CheckinId + "' AND ADVANCE = 0 And ROOM_NO = '" + ROOM_NO + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {
                AMOUNT_RECEIVED = "0";
            }
            else
            {
                AMOUNT_RECEIVED = dt.Rows[0]["AMOUNT_RECEIVED"].ToString();
            }
            return dt;
        }
    }
}
