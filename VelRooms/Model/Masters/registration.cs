using DAL;
using HMS.View.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model.Masters
{
    public class registration
    {
        public string USERNAME { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public string MOBILE_NO { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public string RETYPEPASSWORD { get; set; }
        public string DESGINATION { get; set; }
        public string Status { get; set; }
        //11/15/2017
        //public string USER_NAME { get; set; }
        public string INSERT_BY { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime UPDATE_DATE { get; set; }

        public DataTable License()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT DURATION,INSERT_DATE FROM LICENSE WHERE APP_NAME='Hotel(HMS)' AND STATUS='Running'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable License1()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT INSERT_DATE,DURATION FROM LICENSE WHERE APP_NAME='Hotel(HMS)' AND STATUS='Running'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public void UPDATELICENSESTATUS()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@STATUS", "Expired");
            string s = "UPDATE LICENSE SET STATUS=@STATUS WHERE APP_NAME='Hotel(HMS)' AND STATUS='Running'";
            DbFunctions.ExecuteCommand<int>(s, list);
        }
        public void INSERT()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@USER_NAME", USERNAME);
            list.AddSqlParameter("@FIRSTNAME", FIRSTNAME);
            list.AddSqlParameter("@LASTNAME", LASTNAME);
            list.AddSqlParameter("@MOBILE_NO", MOBILE_NO);
            list.AddSqlParameter("@EMAIL", EMAIL);
            list.AddSqlParameter("@PASS_WORD", PASSWORD);
            list.AddSqlParameter("@RETYPEPASSWORD", RETYPEPASSWORD);
            list.AddSqlParameter("@DESGINATION", DESGINATION);
            list.AddSqlParameter("@Status", Status);
            // USER INSERT SRIKAR INSERTBY
            INSERT_BY = login.u;
            INSERT_DATE = DateTime.Today.Date;
            list.AddSqlParameter("@INSERT_BY", INSERT_BY);
            list.AddSqlParameter("@INSERT_DATE", INSERT_DATE);

            string QUERY = "INSERT INTO REGISTRATION(USER_NAME,FIRSTNAME,LASTNAME,MOBILE_NO,EMAIL,PASS_WORD,RETYPEPASSWORD,DESGINATION,INSERT_BY,INSERT_DATE,Status)VALUES(@USER_NAME,@FIRSTNAME,@LASTNAME,@MOBILE_NO,@EMAIL,@PASS_WORD,@RETYPEPASSWORD,@DESGINATION,@INSERT_BY,@INSERT_DATE,@Status)";
            DbFunctions.ExecuteCommand<int>(QUERY, list);
        }

        public void UPDATE()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@USER_NAME", USERNAME);
            list.AddSqlParameter("@FIRSTNAME", FIRSTNAME);
            list.AddSqlParameter("@LASTNAME", LASTNAME);
            list.AddSqlParameter("@MOBILE_NO", MOBILE_NO);
            list.AddSqlParameter("@EMAIL", EMAIL);
            list.AddSqlParameter("@PASS_WORD", PASSWORD);
            list.AddSqlParameter("@RETYPEPASSWORD", RETYPEPASSWORD);
            list.AddSqlParameter("@DESGINATION", DESGINATION);
            list.AddSqlParameter("@Status", Status);
            // USER INSERT SRIKAR INSERTBY
            INSERT_BY = login.u;
            INSERT_DATE = DateTime.Today;
            list.AddSqlParameter("@UPDATE_BY", INSERT_BY);
            list.AddSqlParameter("@UPDATE_DATE", INSERT_DATE);

            string QUERY = "UPDATE REGISTRATION SET FIRSTNAME=@FIRSTNAME,LASTNAME=@LASTNAME,MOBILE_NO=@MOBILE_NO,EMAIL=@EMAIL,PASS_WORD=@PASS_WORD,RETYPEPASSWORD=@RETYPEPASSWORD,DESGINATION=@DESGINATION,Status=@Status WHERE USER_NAME='" + USERNAME  + "'";
            DbFunctions.ExecuteCommand<int>(QUERY, list);
        }

        public DataTable signin()
        {
            var list = new List<SqlParameter>();
            string s = "select PASS_WORD from REGISTRATION WHERE USER_NAME='" + USERNAME + "'";
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (DT.Rows.Count == 0)
            {
                PASSWORD = "";
            }
            else
            {
                PASSWORD = DT.Rows[0]["PASS_WORD"].ToString();
            }
            return DT;
        }
        public DataTable user()
        {
            var list = new List<SqlParameter>();
            string s = "select USER_NAME FROM REGISTRATION WHERE USER_NAME='" + USERNAME + "' and Status = 'Active' ";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
      
        public DataTable a()
        {
            var list = new List<SqlParameter>();
            string s = "select * from REGISTRATION WHERE USER_NAME='" + USERNAME + "' ";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            FIRSTNAME = dt.Rows[0]["FIRSTNAME"].ToString();
            LASTNAME = dt.Rows[0]["LASTNAME"].ToString();
            MOBILE_NO = dt.Rows[0]["MOBILE_NO"].ToString();
            EMAIL = dt.Rows[0]["EMAIL"].ToString();
            PASSWORD = dt.Rows[0]["PASS_WORD"].ToString();
            RETYPEPASSWORD = dt.Rows[0]["RETYPEPASSWORD"].ToString();
            DESGINATION = dt.Rows[0]["DESGINATION"].ToString();
            return dt;
        }

        public string SIGNIN { get; set; }
        public string SIGNOUT { get; set; }

        public DateTime INSERTDATE { get; set; }
        public string S = login.u;
        //  DateTime PgTime = new DateTime();
        DateTime instance = DateTime.Now;
        // string time = instance.ToString("t");
        public void users()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@USERNAME", USERNAME.ToUpper());
            string time = instance.ToString("t");
            SIGNIN = time;
            list.AddSqlParameter("@SIGNIN", time);
            SIGNOUT = "00:00".ToString();
            list.AddSqlParameter("@SIGNOUT", SIGNOUT);
            INSERTDATE = Convert.ToDateTime(DateTime.Now.ToString("ddd, MMM d, yyyy"));
            list.AddSqlParameter("@INSERTDATE", INSERTDATE);
            string s = "insert into USERS (USERNAME,SIGNIN,SIGNOUT,INSERTDATE)VALUES(@USERNAME,@SIGNIN,@SIGNOUT,@INSERTDATE)";
            DbFunctions.ExecuteCommand<int>(s, list);
        }

        public void updates()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@USERNAME", login.u);
            string time = instance.ToString("t");
            SIGNOUT = time;
            list.AddSqlParameter("@SIGNOUT", time);
            string s = "update USERS set SIGNOUT=@SIGNOUT WHERE USERNAME=@USERNAME  ";
            DbFunctions.ExecuteCommand<int>(s, list);
        }

        public void MASTERPERMISSIONS()
        {
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@USERNAME", USERNAME.ToUpper());
            LIST.AddSqlParameter("@DESIGINATION",DESGINATION);
            LIST.AddSqlParameter("@INSERT_BY",login.u);
            LIST.AddSqlParameter("@INSERT_DATE", DateTime.Today.Date);
            string s = "INSERT INTO MASTERPERMISSIONS(USERNAME,DESIGINATION,HOTELINFO,COMPANY,CATEGORY,PLANDEFINATION,ROOMTARRIF,AMENITIES,REVENUE,DEPARTMENT,RESET_PASSWORD,REG_USER,USERPEMISSIONS,TAX,INSERT_BY,INSERT_DATE)"+
                "VALUES(@USERNAME,@DESIGINATION,0,1,0,0,0,0,0,1,0,0,0,0,@INSERT_BY,@INSERT_DATE)";
            DbFunctions.ExecuteCommand<int>(s, LIST);
        }
        public void OPERTIONPERMISSIONS()
        {
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@USERNAME", USERNAME.ToUpper());
            LIST.AddSqlParameter("@DESIGINATION", DESGINATION);
            LIST.AddSqlParameter("@INSERT_BY", login.u);
            LIST.AddSqlParameter("@INSERT_DATE", DateTime.Today.Date);
            string s = "INSERT INTO OPERATIONPERMISSIONS(USERNAME,DESIGINATION,ENQUIRY,RESERVATION,CHECKIN,CHECKOUT,CO_COMPANY,CO_BILLONHOLD,CO_TRANSFER,ADVANCE,PENDINGBILL,PB_COMPANY,PB_BILLONHOLD,GROUP_CHECKIN,POSTCHARGES,PAIDOUTS,ROOMCHANGE,REFUND,BLOCK_ROOM,DISCOUNT,GUESTINFO,CHANGEROOMSTATUS,MISSALES,BILLSETTLE,REPRINT,DASHBOARD,INSERT_BY,INSERT_DATE) VALUES(@USERNAME,@DESIGINATION,1,1,1,1,0,0,1,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,@INSERT_BY,@INSERT_DATE)";
            DbFunctions.ExecuteCommand<int>(s,LIST);
        }
        public void REPORTPERMISSION()
        {
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@USERNAME", USERNAME.ToUpper());
            LIST.AddSqlParameter("@DESIGINATION", DESGINATION);
            LIST.AddSqlParameter("@INSERT_BY", login.u);
            LIST.AddSqlParameter("@INSERT_DATE", DateTime.Today.Date);
            string s = "INSERT INTO REPORTPERMISSIONS(USERNAME,DESIGINATION,TARIFF_POSTED_DAY,ROOMOCCUPANCY,DISCOUNT_DAY,DISCOUNT_MONTH,EXPECTED_ARRIVALS,EXPECTED_DEPARTURES,CANCELLED_RESERVATION,TODAY_ARRIVALS,CHECKOUTFORTHE_DAY,GUEST_ADVANCE,GUEST_INHOUSE,ROOM_RATELIST,RESERVATION_LIST,TRANSACTION_LIST,TAX_REPORT,FO_TRANSACTIONLIST,CHANGE_GUESTINFO,ROOM_CHANGE,OUTSTANDING_BALANCE,MONTHWISE_ROOMTARIFF,PENDINGBILL,INSERT_BY,INSERT_DATE) VALUES(@USERNAME,@DESIGINATION,1,1,1,0,1,1,1,1,1,0,1,1,1,0,0,1,1,1,0,0,1,@INSERT_BY,@INSERT_DATE)";
            DbFunctions.ExecuteCommand<int>(s,LIST);
        }
        public DataTable username()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT USER_NAME,DESGINATION FROM REGISTRATION WHERE USER_NAME='" + USERNAME + "' ";
            DataTable D = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return D;
        }
        public DataTable username1()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT USER_NAME,DESGINATION FROM REGISTRATION WHERE USER_NAME='" + login.u + "' ";
            DataTable D = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return D;
        }
        public DataTable fill_reggrid()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT USER_NAME,DESGINATION,MOBILE_NO,Status,FIRSTNAME FROM REGISTRATION";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable fill_regdata()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT USER_NAME,FIRSTNAME,LASTNAME,MOBILE_NO,EMAIL,PASS_WORD,RETYPEPASSWORD,DESGINATION,Status FROM REGISTRATION";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
    }
}
