using DAL;
using HMS.View.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace HMS.Model
{
    public class companymaster
    {
        public string COMPANY_CODE { get; set; }
        public string COMPANY_NAME { get; set; }
        public string CONTACT_PERSON_NAME { get; set; }
        public string CONTACT_PERSON_NUMBER { get; set; }
        public string CATEGORY { get; set; }
        public string PLOT_NO { get; set; }
        public string LANDMARK { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string COUNTRY { get; set; }
        public string PINCODE { get; set; }
        public string CONTACT { get; set; }
        public string EMAIL { get; set; }
        public string DISCOUNT { get; set; }
        public string CREDITLIMIT { get; set; }
        public string CREDITDAYS { get; set; }
        public string BLACKLISTEDBY { get; set; }
        public string REASON { get; set; }
        public string REMARKS { get; set; }
        public string STATUS { get; set; }
        public string ALLOW_CREDIT { get; set; }
        public string YES { get; set; }
        public string NO { get; set; }
        //11/15/2017
        //public string USER_NAME { get; set; }
        public string INSERT_BY { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public string GST { get; set; }

        //Insertion of data into database
        public void Insert()
        {
            var list = new List<SqlParameter>();

            list.AddSqlParameter("@COMPANY_CODE", COMPANY_CODE);
            list.AddSqlParameter("@COMPANY_NAME", COMPANY_NAME);
            list.AddSqlParameter("@CONTACT_PERSON_NAME", CONTACT_PERSON_NAME);
            list.AddSqlParameter("@CONTACT_PERSON_NUMBER", CONTACT_PERSON_NUMBER);
            list.AddSqlParameter("@CATEGORY", CATEGORY);
            list.AddSqlParameter("@PLOT_NO", PLOT_NO);
            list.AddSqlParameter("@LANDMARK", LANDMARK);
            list.AddSqlParameter("@CITY", CITY);
            list.AddSqlParameter("@STATE", STATE);
            list.AddSqlParameter("@COUNTRY", COUNTRY);
            list.AddSqlParameter("@PINCODE", PINCODE);
            list.AddSqlParameter("@MOBILE_NO", Convert.ToInt64(CONTACT));
            list.AddSqlParameter("@EMAIL", EMAIL);
            list.AddSqlParameter("@DISCOUNT", DISCOUNT);
            list.AddSqlParameter("@CREDITLIMIT", CREDITLIMIT);
            list.AddSqlParameter("@CREDITDAYS", CREDITDAYS);
            list.AddSqlParameter("@BLACKLISTED_BY", BLACKLISTEDBY);
            list.AddSqlParameter("@REASON", REASON);
            list.AddSqlParameter("@REMARKS", REMARKS);
            list.AddSqlParameter("@STATUS", STATUS);
            list.AddSqlParameter("@ALLOW_CREDIT", Convert.ToInt32(ALLOW_CREDIT));
            list.AddSqlParameter("@YES", Convert.ToInt16(YES));
            list.AddSqlParameter("@NO", Convert.ToInt16(NO));
            list.AddSqlParameter("@GST", GST);
            INSERT_BY = login.u;

            list.AddSqlParameter("@INSERT_BY", INSERT_BY);
            list.AddSqlParameter("@INSERT_DATE", INSERT_DATE);
            INSERT_DATE = DateTime.Today;
            UPDATE_BY = login.u;
            UPDATE_DATE = DateTime.Today;

            list.AddSqlParameter("@UPDATE_BY", UPDATE_BY);
            list.AddSqlParameter("@UPDATE_DATE", UPDATE_DATE);
            //USER_NAME = login.u;


            string query = "IF EXISTS (SELECT COMPANY_CODE FROM COMPANYMASTER WHERE COMPANY_CODE = @COMPANY_CODE) BEGIN UPDATE COMPANYMASTER SET COMPANY_NAME = @COMPANY_NAME," +
                           "CONTACT_PERSON_NAME = @CONTACT_PERSON_NAME,CONTACT_PERSON_NUMBER = @CONTACT_PERSON_NUMBER,CATEGORY = @CATEGORY,PLOT_NO = @PLOT_NO," +
                           "LANDMARK = @LANDMARK,CITY = @CITY,STATE = @STATE,COUNTRY = @COUNTRY,PINCODE = @PINCODE,MOBILE_NO = @MOBILE_NO,EMAIL = @EMAIL,DISCOUNT = @DISCOUNT,CREDITLIMIT = @CREDITLIMIT,CREDITDAYS = @CREDITDAYS," +
                           "BLACKLISTED_BY = @BLACKLISTED_BY,REASON = @REASON,REMARKS = @REMARKS,STATUS = @STATUS,ALLOW_CREDIT = @ALLOW_CREDIT,GST=@GST,UPDATE_BY=@UPDATE_BY,UPDATE_DATE=@UPDATE_DATE,YES = @YES,NO = @NO WHERE COMPANY_CODE = @COMPANY_CODE END " +
                           "ELSE BEGIN INSERT INTO COMPANYMASTER(COMPANY_CODE, COMPANY_NAME, CONTACT_PERSON_NAME, CONTACT_PERSON_NUMBER, CATEGORY, PLOT_NO, LANDMARK, " +
                           "CITY, STATE, COUNTRY, PINCODE, MOBILE_NO, EMAIL, DISCOUNT, CREDITLIMIT, CREDITDAYS, BLACKLISTED_BY, REASON, REMARKS, STATUS, ALLOW_CREDIT,GST,INSERT_BY,INSERT_DATE, YES, NO)VALUES (@COMPANY_CODE,@COMPANY_NAME," +
                           "@CONTACT_PERSON_NAME,@CONTACT_PERSON_NUMBER,@CATEGORY,@PLOT_NO,@LANDMARK,@CITY,@STATE,@COUNTRY,@PINCODE,@MOBILE_NO,@EMAIL,@DISCOUNT,@CREDITLIMIT,@CREDITDAYS,@BLACKLISTED_BY,@REASON,@REMARKS," +
                           "@STATUS,@ALLOW_CREDIT,@GST,@INSERT_BY,@INSERT_DATE,@YES,@NO)END";

            DbFunctions.ExecuteCommand<int>(query, list);

        }
        public void Update()
        {
            var list = new List<SqlParameter>();

            list.AddSqlParameter("@COMPANY_CODE", COMPANY_CODE);
            list.AddSqlParameter("@COMPANY_NAME", COMPANY_NAME);
            list.AddSqlParameter("@CONTACT_PERSON_NAME", CONTACT_PERSON_NAME);
            list.AddSqlParameter("@CONTACT_PERSON_NUMBER", CONTACT_PERSON_NUMBER);
            list.AddSqlParameter("@CATEGORY", CATEGORY);
            list.AddSqlParameter("@PLOT_NO", PLOT_NO);
            list.AddSqlParameter("@LANDMARK", LANDMARK);
            list.AddSqlParameter("@CITY", CITY);
            list.AddSqlParameter("@STATE", STATE);
            list.AddSqlParameter("@COUNTRY", COUNTRY);
            list.AddSqlParameter("@PINCODE", PINCODE);
            list.AddSqlParameter("@MOBILE_NO", Convert.ToInt64(CONTACT));
            list.AddSqlParameter("@EMAIL", EMAIL);
            list.AddSqlParameter("@DISCOUNT", DISCOUNT);
            list.AddSqlParameter("@CREDITLIMIT", CREDITLIMIT);
            list.AddSqlParameter("@CREDITDAYS", CREDITDAYS);
            list.AddSqlParameter("@BLACKLISTED_BY", BLACKLISTEDBY);
            list.AddSqlParameter("@REASON", REASON);
            list.AddSqlParameter("@REMARKS", REMARKS);
            list.AddSqlParameter("@STATUS", STATUS);
            list.AddSqlParameter("@ALLOW_CREDIT", Convert.ToInt32(ALLOW_CREDIT));
            list.AddSqlParameter("@YES", Convert.ToInt16(YES));
            list.AddSqlParameter("@NO", Convert.ToInt16(NO));
            UPDATE_BY = login.u;
            UPDATE_DATE = DateTime.Today;

            list.AddSqlParameter("@UPDATE_BY", UPDATE_BY);
            list.AddSqlParameter("@UPDATE_DATE", UPDATE_DATE);

            string s = "UPDATE COMPANYMASTER SET COMPANY_NAME = @COMPANY_NAME," +
                           "CONTACT_PERSON_NAME = @CONTACT_PERSON_NAME,CONTACT_PERSON_NUMBER = @CONTACT_PERSON_NUMBER,CATEGORY = @CATEGORY,PLOT_NO = @PLOT_NO," +
                           "LANDMARK = @LANDMARK,CITY = @CITY,STATE = @STATE,COUNTRY = @COUNTRY,PINCODE = @PINCODE,MOBILE_NO = @MOBILE_NO,EMAIL = @EMAIL,DISCOUNT = @DISCOUNT,CREDITLIMIT = @CREDITLIMIT,CREDITDAYS = @CREDITDAYS," +
                           "BLACKLISTED_BY = @BLACKLISTED_BY,REASON = @REASON,REMARKS = @REMARKS,STATUS = @STATUS,ALLOW_CREDIT = @ALLOW_CREDIT,UPDATE_BY=@UPDATE_BY,UPDATE_DATE=@UPDATE_DATE,YES = @YES,NO = @NO WHERE COMPANY_CODE = @COMPANY_CODE";
            DbFunctions.ExecuteCommand<int>(s, list);
        }
        //Retrival of data from database
        public void Retrive()
        {
            var list = new List<SqlParameter>();

            string S = "SELECT * FROM COMPANYMASTER ";

            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, list);

            COMPANY_CODE = dt.Rows[0]["COMPANY_CODE"].ToString();
            COMPANY_NAME = dt.Rows[0]["COMPANY_NAME"].ToString();
            CONTACT_PERSON_NAME = dt.Rows[0]["CONTACT_PERSON_NAME"].ToString();
            CONTACT_PERSON_NUMBER = dt.Rows[0]["CONTACT_PERSON_NUMBER"].ToString();
            CATEGORY = dt.Rows[0]["CATEGORY"].ToString();
            PLOT_NO = dt.Rows[0]["PLOT_NO"].ToString();
            LANDMARK = dt.Rows[0]["LANDMARK"].ToString();
            CITY = dt.Rows[0]["CITY"].ToString();
            STATE = dt.Rows[0]["STATE"].ToString();
            COUNTRY = dt.Rows[0]["COUNTRY"].ToString();
            PINCODE = dt.Rows[0]["PINCODE"].ToString();
            CONTACT = dt.Rows[0]["MOBILE_NO"].ToString();
            EMAIL = dt.Rows[0]["EMAIL"].ToString();
            DISCOUNT = dt.Rows[0]["DISCOUNT"].ToString();
            CREDITLIMIT = dt.Rows[0]["CREDITLIMIT"].ToString();
            CREDITDAYS = dt.Rows[0]["CREDITDAYS"].ToString();
            BLACKLISTEDBY = dt.Rows[0]["BLACKLISTED_BY"].ToString();
            REASON = dt.Rows[0]["REASON"].ToString();
            REMARKS = dt.Rows[0]["REMARKS"].ToString();
            STATUS = dt.Rows[0]["STATUS"].ToString();
            ALLOW_CREDIT = dt.Rows[0]["ALLOW_CREDIT"].ToString();
            YES = dt.Rows[0]["YES"].ToString();
            NO = dt.Rows[0]["NO"].ToString();
        }
        public string address;
        public DataTable get()
        {
            var list = new List<SqlParameter>();

            // string s = "select PLOT_NO,LANDMARK,CITY,STATE,COUNTRY,PINCODE,MOBILE_NO,EMAIL FROM COMPANYMASTER WHERE COMPANY_NAME='" + COMPANY_NAME + "'";
            string s = "SELECT PLOT_NO+','+LANDMARK+','+CITY+','+STATE+','+COUNTRY+','+CONVERT(VARCHAR(10),PINCODE) as address FROM COMPANYMASTER  WHERE COMPANY_NAME='" + COMPANY_NAME + "' ";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);

            if (dt.Rows.Count == 0)
            {
                address = "";
            }
            else
            {
                
                address = dt.Rows[0]["address"].ToString();
            }
            return dt;
        }
    }
}
