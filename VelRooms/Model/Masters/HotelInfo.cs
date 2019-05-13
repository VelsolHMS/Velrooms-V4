using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.SqlClient;
using System.Data;
using HMS.View.Masters;

namespace HMS.Model
{
    public class Hotelinfo
    {
        public string Name { get; set; }
        public string city { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string GST_NO { get; set; }
        public string Landline_1 { get; set; }
        public string Landline_2 { get; set; }
        public string Landmark { get; set; }
        public string Mobile_No { get; set; }
        public string Pincode { get; set; }
        public string Plot_No { get; set; }
        public string State { get; set; }
        public string website { get; set; }
        public string HOURS12 { get; set; }
        public string HOURS24 { get; set; }
        public string EXTRAHOURS { get; set; }
        //11/15/2017
        //public string USER_NAME { get; set; }
        public string INSERT_BY { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        //Insertion of data into database
       
        public void Insert()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@NAME", Name);
            list.AddSqlParameter("@PLOT_NO", Plot_No);
            list.AddSqlParameter("@LANDMARK", Landmark);
            list.AddSqlParameter("@CITY", city);
            list.AddSqlParameter("@STATE", State);
            list.AddSqlParameter("@PINCODE", Pincode);
            list.AddSqlParameter("@COUNTRY", Country);
            list.AddSqlParameter("@MOBILE_NO", Mobile_No);
            list.AddSqlParameter("@EMAIL_ID", Email);
            list.AddSqlParameter("@LANDLINE1", Landline_1);
            list.AddSqlParameter("@LANDLINE2", Landline_2);
            list.AddSqlParameter("@WEBSITE", website);
            list.AddSqlParameter("@GST", GST_NO);
            list.AddSqlParameter("@HOURS12", HOURS12);
            list.AddSqlParameter("@HOURS24", HOURS24);
            list.AddSqlParameter("@EXTRAHOURS", EXTRAHOURS);
            // USER INSERT SRI INSERTBY
            //list.AddSqlParameter("@USER_NAME", USER_NAME);
            list.AddSqlParameter("@INSERT_BY", login.u);
            INSERT_DATE = DateTime.Today;
            list.AddSqlParameter("@INSERT_DATE", INSERT_DATE);

            list.AddSqlParameter("@UPDATE_BY", login.u);
            UPDATE_DATE = DateTime.Today;
            list.AddSqlParameter("@UPDATE_DATE", UPDATE_DATE);

            //USER_NAME = login.u;
            //INSERT_BY = login.u;
            string query = "IF EXISTS (SELECT NAME FROM HOTELINFO WHERE NAME=@NAME) BEGIN UPDATE HOTELINFO SET PLOT_NO=@PLOT_NO,LANDMARK=@LANDMARK,CITY=@CITY,STATE=@STATE,PINCODE=@PINCODE,COUNTRY=@COUNTRY,MOBILE_NO=@MOBILE_NO,EMAIL_ID=@EMAIL_ID,LANDLINE1=@LANDLINE1,LANDLINE2=@LANDLINE2,WEBSITE=@WEBSITE,HOURS12=@HOURS12,HOURS24=@HOURS24,EXTRAHOURS=@EXTRAHOURS,GST=@GST,UPDATE_BY=@UPDATE_BY,UPDATE_DATE=@UPDATE_DATE WHERE NAME=@NAME END "+"" +
                "ELSE BEGIN INSERT INTO HOTELINFO (NAME, PLOT_NO, LANDMARK, CITY, STATE, PINCODE, COUNTRY, MOBILE_NO, EMAIL_ID, LANDLINE1, LANDLINE2, WEBSITE, GST,HOURS12,HOURS24,EXTRAHOURS,INSERT_BY,INSERT_DATE) Values (@Name, @Plot_No, @Landmark, @city, @State, @Pincode, @Country, @Mobile_No, @EMAIL_ID, @Landline1, @Landline2, @website, @GST,@HOURS12,@HOURS24,@EXTRAHOURS,@INSERT_BY,@INSERT_DATE) END";
            DbFunctions.ExecuteCommand<int>(query, list);
        }
        public DataTable GetInfo()
        {
            var sqlParams = new List<SqlParameter>();
            string S = "SELECT NAME,PLOT_NO,LANDMARK,CITY,STATE,PINCODE,COUNTRY,MOBILE_NO,EMAIL_ID,LANDLINE1,LANDLINE2,WEBSITE,GST,HOURS12,HOURS24,EXTRAHOURS,UPDATE_BY,UPDATE_DATE FROM HotelInfo";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, sqlParams);
            if (dt.Rows.Count == 0)
            {
                Name = "";
                city = "";
                Country = "";
                Email = "";
                GST_NO = "";
                Landline_1 = ""; 
                Landline_2 = "";
                Landmark = "";
                Mobile_No = "";
                Pincode = "";
                Plot_No = "";
                State = "";
                website = "";
            }
            else
            {
                Name = dt.Rows[0]["NAME"].ToString();
                Plot_No = dt.Rows[0]["PLOT_NO"].ToString();
                Landmark = dt.Rows[0]["LANDMARK"].ToString();
                city = dt.Rows[0]["CITY"].ToString();
                State = dt.Rows[0]["STATE"].ToString();
                Pincode = dt.Rows[0]["PINCODE"].ToString();
                Country = dt.Rows[0]["COUNTRY"].ToString();
                Mobile_No = dt.Rows[0]["MOBILE_NO"].ToString();
                Email = dt.Rows[0]["EMAIL_ID"].ToString();
                Landline_1 = dt.Rows[0]["LANDLINE1"].ToString();
                Landline_2 = dt.Rows[0]["LANDLINE2"].ToString();
                website = dt.Rows[0]["WEBSITE"].ToString();
                GST_NO = dt.Rows[0]["GST"].ToString();
                HOURS12 = dt.Rows[0]["HOURS12"].ToString();
                HOURS24 = dt.Rows[0]["HOURS24"].ToString();
                EXTRAHOURS = dt.Rows[0]["EXTRAHOURS"].ToString();
            }
            return dt;
        }
        public DataTable GetIn()
        {

            var sqlParams = new List<SqlParameter>();
            string S = "select * from HOTELINFO ";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, sqlParams);
            if (dt.Rows.Count == 0)
            {

            }
            else
            {
                Name = dt.Rows[0]["NAME"].ToString();
                city = dt.Rows[0]["CITY"].ToString();
                Country = dt.Rows[0]["COUNTRY"].ToString();
                Email = dt.Rows[0]["EMAIL_ID"].ToString();
                GST_NO = dt.Rows[0]["GST"].ToString();
                Landline_1 = dt.Rows[0]["LANDLINE1"].ToString();
                Landline_2 = dt.Rows[0]["LANDLINE2"].ToString();
                Landmark = dt.Rows[0]["LANDMARK"].ToString();
                Mobile_No = dt.Rows[0]["MOBILE_NO"].ToString();
                Pincode = dt.Rows[0]["PINCODE"].ToString();
                Plot_No = dt.Rows[0]["PLOT_NO"].ToString();
                State = dt.Rows[0]["STATE"].ToString();
                website = dt.Rows[0]["WEBSITE"].ToString();
                HOURS12 = dt.Rows[0]["HOURS12"].ToString();
                HOURS24 = dt.Rows[0]["HOURS24"].ToString();
                EXTRAHOURS = dt.Rows[0]["EXTRAHOURS"].ToString();
            }
            return dt;
        }
        public DataTable get()
        {
            var list = new List<SqlParameter>();
            string s = "select NAME from  HotelInfo";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {
                Name = "";
            }
            else
            {
                Name = dt.Rows[0]["NAME"].ToString();
            }
            return dt;
        }
        public int getid1()
        { 
            int a = 0;
            string S = "SELECT MAX(HOTELINFO_ID) FROM HotelInfo";
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
        public DataTable market()
        {
            var list = new List<SqlParameter>();
            string s = "select CITY from HotelInfo";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {
                city = "";
            }
            else
            {
                city = dt.Rows[0]["CITY"].ToString();
            }
            return dt;
        }
        public DataTable getLandLinenumber()
        {
            var list = new List<SqlParameter>();
            string landline = "SELECT LANDLINE1,MOBILE_NO FROM HotelInfo ";
            DataTable ll = DbFunctions.ExecuteCommand<DataTable>(landline, list);
            return ll;
        }
        public DataTable GetGuestData()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT FIRSTNAME,MOBILE_NO,EMAIL FROM CHECKIN";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
    }
}