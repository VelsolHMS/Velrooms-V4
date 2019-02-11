using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace HMS.Model.Operations
{
    class rcs1
    {
        public string ROOM_NO { get; set; }
        public string STATUS { get; set; }
        public DataTable roomno()
        {
            var list = new List<SqlParameter>();
            string s = " SELECT ROOM_NO FROM ROOMMASTER AS ROOM_NO";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable roomnoss()
        {
            var list = new List<SqlParameter>();
            string s = " SELECT ROOM_NO FROM ROOMSTATUS AS ROOM_NO";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable Toggle()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT DISTINCT ROOM_NO FROM CHECKIN WHERE CHECK_OUT=0";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable GUEST()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT ROOM_NO,FIRSTNAME FROM  CHECKIN WHERE CHECK_OUT=0 ORDER BY ROOM_NO ASC";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable  geton()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT ROOM_NO FROM CHECKIN WHERE CHECK_OUT=0 UNION SELECT ROOM_NO FROM ROOMSTATUS WHERE STATUS=1";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        
        public void INSERT()
        {
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@ROOM_NO", ROOM_NO);
            LIST.AddSqlParameter("@STATUS", STATUS);
            string S = "INSERT INTO ROOMSTATUS (ROOM_NO,STATUS) VALUES(@ROOM_NO,@STATUS)";
            DbFunctions.ExecuteCommand<int>(S, LIST);
        }
        public static string rm,rmm,ru,STS;
        public void UPDATE()
        {
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@ROOM_NO", rm);
            LIST.AddSqlParameter("@STATUS", STATUS);
            string S = "UPDATE ROOMSTATUS SET STATUS=1 WHERE ROOM_NO=@ROOM_NO";
            DbFunctions.ExecuteCommand<int>(S, LIST);
        }
        public void UPDATE0()
        {
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@ROOM_NO", rmm);
            LIST.AddSqlParameter("@STATUS", STATUS);
            string S = "UPDATE ROOMSTATUS SET STATUS=0 WHERE ROOM_NO=@ROOM_NO";
            DbFunctions.ExecuteCommand<int>(S, LIST);
        }
        public void INSERTU()
        {
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@ROOM_NO", ru);
            LIST.AddSqlParameter("@STATUS", STS);
            string S = "INSERT INTO ROOMSTATUS (ROOM_NO,STATUS) VALUES(@ROOM_NO,@STATUS)";
            DbFunctions.ExecuteCommand<int>(S, LIST);
        }
        public void UPDATEBLUE()
        {
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@ROOM_NO", rmm);
            string S = "UPDATE ROOMMASTER SET BACKGROUND_COLOR='Blue' WHERE ROOM_NO=@ROOM_NO";
            DbFunctions.ExecuteCommand<int>(S, LIST);
        }
        public void UPDATEHOME()
        {
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@ROOM_NO", rm);
            string S = "UPDATE ROOMMASTER SET BACKGROUND_COLOR='Green' WHERE ROOM_NO=@ROOM_NO";
            DbFunctions.ExecuteCommand<int>(S, LIST);
        }
        //public void updateh1()
        //{
        //    var list = new List<SqlParameter>();
        //    list.AddSqlParameter("@ROOM_NO", rm);
        //    string s = "UPDATE ROOMMASTER SET BACKGROUND_COLOR='Blue' WHERE ROOM_NO IN (SELECT ROOM_NO FROM ROOMSTATUS WHERE STATUS=0)";
        //    DbFunctions.ExecuteCommand<int>(s, list);
        //}
        public static string ss = "0";
        
    }
}
