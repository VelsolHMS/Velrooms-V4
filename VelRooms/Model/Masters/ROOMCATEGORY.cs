using System;
using System.Collections.Generic;
using DAL;
using System.Data.SqlClient;
using System.Data;
using HMS.View.Masters;

namespace HMS.Model
{
    public class RoomCateogry1
    {
        public string ROOMTYPE { get; set; }
        public string ROOMNAME { get; set; }
        public string REPORTINGNAME { get; set; }
        public string MAXPAX { get; set; }
        public DateTime ACTIVEDATE { get; set; }
        public string NOOFROOMS { get; set; }
        public string STATUS { get; set; }
        //11/15/2017
        // public string USER_NAME { get; set; }
        public string INSERT_BY { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public string button { get; set; }
        public void insert()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@ROOM_CATEGORY", ROOMTYPE);
            list.AddSqlParameter("@ROOM_NAME", ROOMNAME);
            list.AddSqlParameter("@REPORTING_NAME", REPORTINGNAME);
            list.AddSqlParameter("@MAXPAX", MAXPAX);
            list.AddSqlParameter("@ACTIVE_DATE", ACTIVEDATE);
            list.AddSqlParameter("@NO_OF_ROOMS", NOOFROOMS);
            list.AddSqlParameter("@STATUS", STATUS);
            // USER INSERT SRI INSERTBY
            //list.AddSqlParameter("@USER_NAME", USER_NAME);
            INSERT_BY = login.u;

            list.AddSqlParameter("@INSERT_BY", INSERT_BY);
            list.AddSqlParameter("@INSERT_DATE", DateTime.Today);
            UPDATE_BY = login.u;
            UPDATE_DATE = DateTime.Today;
            list.AddSqlParameter("@UPDATE_BY", UPDATE_BY);
            list.AddSqlParameter("@UPDATE_DATE", UPDATE_DATE);
            //USER_NAME = login.u;

            string query = "IF EXISTS (SELECT ROOM_CATEGORY FROM ROOMCATEGORY WHERE ROOM_CATEGORY=@ROOM_CATEGORY) BEGIN UPDATE ROOMCATEGORY SET ROOM_NAME=@ROOM_NAME,REPORTING_NAME=@REPORTING_NAME,MAXPAX=@MAXPAX,NO_OF_ROOMS=@NO_OF_ROOMS,ACTIVE_DATE=@ACTIVE_DATE,STATUS=@STATUS,UPDATE_BY=@UPDATE_BY,UPDATE_DATE=@UPDATE_DATE WHERE ROOM_CATEGORY=@ROOM_CATEGORY END ELSE BEGIN INSERT INTO ROOMCATEGORY(ROOM_CATEGORY,ROOM_NAME,REPORTING_NAME,MAXPAX,NO_OF_ROOMS,ACTIVE_DATE,STATUS,INSERT_BY,INSERT_DATE ) VALUES(@ROOM_CATEGORY,@ROOM_NAME,@REPORTING_NAME,@MAXPAX,@NO_OF_ROOMS,@ACTIVE_DATE,@STATUS,@INSERT_BY,@INSERT_DATE) END";
            DbFunctions.ExecuteCommand<int>(query, list);
        }
        public void update()
        {
            var list = new List<SqlParameter>();
            string S = "SELECT * FROM ROOMCATEGORY WHERE ROOM_CATEGORY = '" + ROOMTYPE + "' ";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, list);
            if (dt.Rows.Count == 0)
            {
                ROOMNAME = "";
                REPORTINGNAME = "";
                MAXPAX = "";
                // ACTIVEDATE = "";
                NOOFROOMS = "";
                STATUS = "";
            }
            else
            {
                ROOMNAME = dt.Rows[0]["ROOM_NAME"].ToString();
                REPORTINGNAME = dt.Rows[0]["REPORTING_NAME"].ToString();
                MAXPAX = dt.Rows[0]["MAXPAX"].ToString();
                ACTIVEDATE = Convert.ToDateTime(dt.Rows[0]["ACTIVE_DATE"]);
                NOOFROOMS = dt.Rows[0]["NO_OF_ROOMS"].ToString();
                STATUS = dt.Rows[0]["STATUS"].ToString();
            }
        }
        public void STATUS1()
        {

        }
        public DataTable fill_grid()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT ROOM_CATEGORY,NO_OF_ROOMS,ROOM_NAME,MAXPAX,REPORTING_NAME,STATUS FROM ROOMCATEGORY";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable fill_data()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT ROOM_CATEGORY,ROOM_NAME,MAXPAX,NO_OF_ROOMS,REPORTING_NAME,ACTIVE_DATE,STATUS FROM ROOMCATEGORY";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable RoomName()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT ROOM_CATEGORY FROM ROOMCATEGORY";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
    }
}
