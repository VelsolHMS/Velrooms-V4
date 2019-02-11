using DAL;
using HMS.View.Masters;
using HMS.View.Operations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model.Operations
{
    public class Enquiry1
    {
        public int Enquiry_id { get; set; }
        public string Name { get; set; }
        public Int64 Contact { get; set; }
        public string ComingFrom { get; set; }
        public string RoomType { get; set; }
        public int Expected_Rooms { get; set; }
        public int Expected_Pax { get; set; }
        public DateTime Expected_Arrival_Date { get; set; }
        public string Time { get; set; }
        public string Insert_by { get; set; }
        public DateTime Insert_date { get; set; }
        public string Update_by { get; set; }
        public DateTime Update_date { get; set; }
        public string Date { get; set; }
        public string Date1 { get; set; }

        public void insert()
        {

            var list = new List<SqlParameter>();
            list.AddSqlParameter("@Enquiry_id", Enquiry_id);
            list.AddSqlParameter("@Name", Name);
            list.AddSqlParameter("@Contact", Contact);
            list.AddSqlParameter("@ComingFrom", ComingFrom);
            list.AddSqlParameter("@RoomType", RoomType);
            list.AddSqlParameter("@Expected_Rooms", Expected_Rooms);
            list.AddSqlParameter("@Expected_Pax", Expected_Pax);
            list.AddSqlParameter("@Expected_Arrival_Date", Expected_Arrival_Date);
            list.AddSqlParameter("@Time", Time);
            Insert_by = login.u;
            list.AddSqlParameter("@Insert_By", Insert_by);
            Insert_date = DateTime.Today.Date;
            list.AddSqlParameter("@Insert_Date",Insert_date );
            Update_by = login.u;
            list.AddSqlParameter("@Update_By", Update_by);
            list.AddSqlParameter("@Update_Date",Insert_date);


            string s = "IF EXISTS(SELECT * FROM Enquiry WHERE Enquiry_id=@Enquiry_id )BEGIN UPDATE Enquiry SET Name=@Name,Contact=@Contact,ComingFrom=@ComingFrom,"+
                "RoomType=@RoomType,Expected_Rooms=@Expected_Rooms,Expected_Pax=@Expected_Pax,Expected_Arrival_Date=@Expected_Arrival_Date,Update_By=@Update_by,Update_Date=@Update_date END ELSE"+
                " BEGIN INSERT INTO Enquiry(Name,Contact,ComingFrom,RoomType,Expected_Rooms,Expected_Pax,Expected_Arrival_Date,Time,Insert_By,Insert_Date)"+
                " VALUES(@Name,@Contact,@ComingFrom,@RoomType,@Expected_Rooms,@Expected_Pax,@Expected_Arrival_Date,@Time,@Insert_by,@Insert_Date) END ";
            DbFunctions.ExecuteCommand<int>(s, list);
        }
        public void UPDATE()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@Enquiry_id", Enquiry_id);
            list.AddSqlParameter("@Name", Name);
            list.AddSqlParameter("@Contact", Contact);
            list.AddSqlParameter("@ComingFrom", ComingFrom);
            list.AddSqlParameter("@RoomType", RoomType);
            list.AddSqlParameter("@Expected_Rooms", Expected_Rooms);
            list.AddSqlParameter("@Expected_Pax", Expected_Pax);
            list.AddSqlParameter("@Expected_Arrival_Date", Expected_Arrival_Date);
            list.AddSqlParameter("@Time", Time);
            Update_by = login.u;
            list.AddSqlParameter("@Update_By", Update_by);
            list.AddSqlParameter("@Update_Date", DateTime.Today);

            string s = "UPDATE Enquiry SET Name=@Name,Contact=@Contact,ComingFrom=@ComingFrom,RoomType=@RoomType,Time=@Time,Expected_Rooms=@Expected_Rooms,Expected_Pax=@Expected_Pax,Expected_Arrival_Date=@Expected_Arrival_Date WHERE ENQUIRY_ID = @ENQUIRY_ID";
            DbFunctions.ExecuteCommand<int>(s, list);
        }
        public int getid()
        {
            int a = 0;
            string S = "SELECT MAX(Enquiry_id) FROM Enquiry";
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

        public DataTable id()
        {
            var list = new List<SqlParameter>();
            string s = "Select ENQUIRY_ID,NAME,CONTACT,EXPECTED_ARRIVAL_DATE,EXPECTED_PAX,EXPECTED_ROOMS from Enquiry where Enquiry_id ='" + Enquiry_id + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            Enquiry_id = Convert.ToInt32(dt.Rows[0]["ENQUIRY_ID"]);
            Name = dt.Rows[0]["NAME"].ToString();
            Contact = Convert.ToInt64(dt.Rows[0]["CONTACT"]);
            Expected_Arrival_Date =DateTime.Parse(dt.Rows[0]["EXPECTED_ARRIVAL_DATE"].ToString());
            Expected_Pax = Convert.ToInt32(dt.Rows[0]["EXPECTED_PAX"]);
            Expected_Rooms = Convert.ToInt32(dt.Rows[0]["EXPECTED_ROOMS"]);
            return dt;
        }
        public DateTime ed;
             
        public DataTable date()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@Expected_Arrival_Date", ed);
            string s = "Select  ENQUIRY_ID,NAME,CONTACT,EXPECTED_ARRIVAL_DATE,EXPECTED_PAX,EXPECTED_ROOMS from Enquiry where Expected_Arrival_Date =@Expected_Arrival_Date";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            Enquiry_id = Convert.ToInt32(dt.Rows[0]["ENQUIRY_ID"]);
            Name = dt.Rows[0]["NAME"].ToString();
            Contact = Convert.ToInt64(dt.Rows[0]["CONTACT"]);
            Expected_Arrival_Date = DateTime.Parse(dt.Rows[0]["EXPECTED_ARRIVAL_DATE"].ToString());
            Expected_Pax = Convert.ToInt32(dt.Rows[0]["EXPECTED_PAX"]);
            Expected_Rooms = Convert.ToInt32(dt.Rows[0]["EXPECTED_ROOMS"]);
            return dt;
        }
        public DataTable Name1()
        {
            var list = new List<SqlParameter>();
            string s = "Select  ENQUIRY_ID,NAME,CONTACT,EXPECTED_ARRIVAL_DATE,EXPECTED_PAX,EXPECTED_ROOMS from Enquiry where Name ='" + Name + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            Enquiry_id = Convert.ToInt32(dt.Rows[0]["ENQUIRY_ID"]);
            Name = dt.Rows[0]["NAME"].ToString();
            Contact = Convert.ToInt64(dt.Rows[0]["CONTACT"]);
            Expected_Arrival_Date = DateTime.Parse(dt.Rows[0]["EXPECTED_ARRIVAL_DATE"].ToString());
            Expected_Pax = Convert.ToInt32(dt.Rows[0]["EXPECTED_PAX"]);
            Expected_Rooms = Convert.ToInt32(dt.Rows[0]["EXPECTED_ROOMS"]);
            return dt;
        }
        public DataTable Contact1()
        {
            var list = new List<SqlParameter>();
            string s = "Select ENQUIRY_ID,NAME,CONTACT,EXPECTED_ARRIVAL_DATE,EXPECTED_PAX,EXPECTED_ROOMS from Enquiry where Contact ='" + Contact + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            Enquiry_id = Convert.ToInt32(dt.Rows[0]["ENQUIRY_ID"]);
            Name = dt.Rows[0]["NAME"].ToString();
            Contact = Convert.ToInt64(dt.Rows[0]["CONTACT"]);
            Expected_Arrival_Date = DateTime.Parse(dt.Rows[0]["EXPECTED_ARRIVAL_DATE"].ToString());
            Expected_Pax = Convert.ToInt32(dt.Rows[0]["EXPECTED_PAX"]);
            Expected_Rooms = Convert.ToInt32(dt.Rows[0]["EXPECTED_ROOMS"]);
            return dt;
        }
        public string dateformat(string a)
        {
            string str = null;
            string[] strArr = null;
            int count = 0;
            str = a;
            char[] splitchar = { ' ' };
            strArr = str.Split(splitchar);
            for (count = 0; count <= strArr.Length - 1; count++)
            {
                str = strArr[count];
            }

            char[] spl = { '-' };
            strArr = str.Split(spl);
            for (count = 0; count <= strArr.Length - 1; count++)
            {
                //  str = strArr[count];

                String MONTH = strArr[1];
                String Date = strArr[2];
                String YEAR = strArr[0];
                str = Date + "-" + MONTH + "-" + YEAR;
                a = str;
            }
            return a;
        }
        public DateTime fromdate { get; set; }
        public DateTime todate { get; set; }

        public DataTable insertdate()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@STARTDATE", enquiry.datet);
            list.AddSqlParameter("@ENDDATE", enquiry.datet1);
            string s = "Select ENQUIRY_ID,NAME,CONTACT,EXPECTED_ARRIVAL_DATE,EXPECTED_PAX,EXPECTED_ROOMS From ENQUIRY where INSERT_DATE BETWEEN @STARTDATE AND @ENDDATE";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {
                Enquiry_id =0;
                Name = "";
                Contact =1234567890;
                //Expected_Arrival_Date = "";
                Expected_Pax =0;
                Expected_Rooms = 0;
            }
            else
            {
                Enquiry_id = Convert.ToInt32(dt.Rows[0]["ENQUIRY_ID"]);
                Name = dt.Rows[0]["NAME"].ToString();
                Contact = Convert.ToInt64(dt.Rows[0]["CONTACT"]);
                // Expected_Arrival_Date = dt.Rows[0]["EXPECTED_ARRIVAL_DATE"].ToString();
                Expected_Pax = Convert.ToInt32(dt.Rows[0]["EXPECTED_PAX"]);
                Expected_Rooms = Convert.ToInt32(dt.Rows[0]["EXPECTED_ROOMS"]);
            }
            return dt;
        }
        public DataTable fill_enquirygrid()
        {
            var list = new List<SqlParameter>();
            string s = "Select ENQUIRY_ID,NAME,CONTACT,EXPECTED_ARRIVAL_DATE,EXPECTED_PAX,EXPECTED_ROOMS From ENQUIRY";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable fetch_data()
        {
            var list = new List<SqlParameter>();
            string s = "Select Enquiry_id, Name, Contact, Expected_Arrival_Date, Expected_Pax, Expected_Rooms,ROOMTYPE,COMINGFROM,TIME from Enquiry";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable Enquiry()
        {
            var list = new List<SqlParameter>();
            string s = "Select Enquiry_id, Name, Contact, Expected_Arrival_Date, Expected_Pax, Expected_Rooms,ROOMTYPE,COMINGFROM,TIME from Enquiry";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
    }
}