using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;
using System.Threading.Tasks;
using HMS.View.Masters;
using System.Windows.Forms;

namespace HMS.Model
{
    public class blockroom
    {
        public string ROOM_NO { get; set; }
        public string ROOM_TYPE { get; set; }
        public string FROM_DATE { get; set; }
        public string TO_DATE { get; set; }
        public string MAINTANCE { get; set; }
        public string MANAGEMENT { get; set; }
        public string MAINTANCE1 { get; set; }
        public string MANAGEMENT1 { get; set; }
        public string REASON { get; set; }
        //11/15/2017
        //public string USER_NAME { get; set; }
        public string INSERT_BY { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        //Insertion Command To Store Data Into Database
        public void Insert()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@ROOM_NO", ROOM_NO);
            list.AddSqlParameter("@ROOM_CATEGORY", ROOM_TYPE);
            list.AddSqlParameter("@FROM_DATE", Convert.ToDateTime(FROM_DATE));
            list.AddSqlParameter("@TO_DATE", Convert.ToDateTime(TO_DATE));
            list.AddSqlParameter("@MAINTANCE", MAINTANCE);
            list.AddSqlParameter("@MANAGEMENT", MANAGEMENT);
            list.AddSqlParameter("@DIRTY", MAINTANCE1);
            list.AddSqlParameter("@CLEAN", MANAGEMENT1);
            list.AddSqlParameter("@REASON", REASON);
            // USER INSERT SRIKAR INSERTBY
            //list.AddSqlParameter("@USER_NAME", USER_NAME);
            INSERT_BY = login.u;

            list.AddSqlParameter("@INSERT_BY", INSERT_BY);
            list.AddSqlParameter("@INSERT_DATE", DateTime.Today);
            UPDATE_BY = login.u;
            list.AddSqlParameter("@UPDATE_BY", UPDATE_BY);
            list.AddSqlParameter("@UPDATE_DATE", DateTime.Today);
            //USER_NAME = login.u;

            string query = "INSERT INTO BLOCK_ROOM (ROOM_NO, ROOM_CATEGORY, FROM_DATE, TO_DATE, MAINTANCE, MANAGEMENT,DIRTY,CLEAN,REASON,INSERT_BY,INSERT_DATE) VALUES (@ROOM_NO, @ROOM_CATEGORY," +
                           "@FROM_DATE, @TO_DATE, @MAINTANCE, @MANAGEMENT,@DIRTY,@CLEAN ,@REASON,@INSERT_BY,@INSERT_DATE)";

            DbFunctions.ExecuteCommand<int>(query, list);
        }
        public DataTable RELEASE()
        {
                DataTable D = null;
                string get = "SELECT BACKGROUND_COLOR FROM ROOMMASTER WHERE ROOM_NO=@ROOMNO";
                var LI = new List<SqlParameter>();
                LI.AddSqlParameter("@ROOMNO", ROOM_NO);
                DataTable DT = DAL.DbFunctions.ExecuteCommand<DataTable>(get, LI);
                string AC = DT.Rows[0]["BACKGROUND_COLOR"].ToString();
                if (AC == "Pink")
                {
                    D = getdta();
                }
                else if (AC == "Red")
                {
                    D = getdta();
                }
                else if (AC == "Green")
                {
                    D = getdta();
                }
                else if (AC == "Blue")
                {
                    D = getdta();
                }

                return D;
           
        }
     
        public void col()
        {
            var list = new List<SqlParameter>();
            string s = "update ROOMMASTER SET BACKGROUND_COLOR='Green' where ROOM_NO='" + ROOM_NO + "' ";
            DbFunctions.ExecuteCommand<int>(s,list);

        }

        public DataTable getdta()
        {
            DataTable D = null;
            String S = "SELECT MAX(BLOCK_ROOM) FROM BLOCK_ROOM WHERE ROOM_NO=@ROOMNO";
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@ROOMNO", ROOM_NO);
            Object O = DAL.DbFunctions.ExecuteCommand<Object>(S, LIST);
            int A = Convert.ToInt16(O);
            String ST = "SELECT * FROM BLOCK_ROOM WHERE BLOCK_ROOM=@BROOM";
            var L = new List<SqlParameter>();
            L.AddSqlParameter("@BROOM", A);
            D = DAL.DbFunctions.ExecuteCommand<DataTable>(ST, L);
            return D;
        }

        public int COLOR()
        {
            var l = new List<SqlParameter>();
            string s = "SELECT * FROM ROOMMASTER WHERE ROOM_NO = @roomno AND BACKGROUND_COLOR=@BGCOLOR ";
            l.AddSqlParameter("@roomno", ROOM_NO);
            l.AddSqlParameter("@BGCOLOR", "Green");
            Object O = DAL.DbFunctions.ExecuteCommand<Object>(s, l);
            int A = Convert.ToInt16(O);
            return A;
        }
        // Retrival Method To Get Room Number And Room Type 
        public int Roomretrive()
        {
            int A = 0;
            var l = new List<SqlParameter>();
            string s = "SELECT COUNT(ROOM_NO) FROM ROOMMASTER WHERE ROOM_NO = @roomno AND BACKGROUND_COLOR=@BGCOLOR";
            l.AddSqlParameter("@roomno", ROOM_NO);
            l.AddSqlParameter("@BGCOLOR", "Green");
            Object O = DAL.DbFunctions.ExecuteCommand<Object>(s, l);
            int COUNT = Convert.ToInt16(O);
            if (COUNT > 0)
            {
                var list = new List<SqlParameter>();

                string query = "SELECT ROOM_NO,ROOM_CATEGORY FROM ROOMMASTER WHERE ROOM_NO = '" + ROOM_NO + "' ";

                DataTable dt = DbFunctions.ExecuteCommand<DataTable>(query, list);

                ROOM_TYPE = dt.Rows[0]["ROOM_CATEGORY"].ToString();
            }
            else
            {
                A = 1;
            }
            return A;
        }

        //Updating The Colour In The Database For Management
        public string ColorUpdate(string s)
        {
            var list = new List<SqlParameter>();
            string color = "UPDATE ROOMMASTER SET BACKGROUND_COLOR = '" + s.ToString() + "' WHERE ROOM_NO = '" + ROOM_NO + "' ";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(color, list);
            return dt.ToString();
        }
        public void ColorUpdate1()
        {
            var list = new List<SqlParameter>();
            string color = "UPDATE ROOMMASTER SET BACKGROUND_COLOR = 'Green' WHERE BACKGROUND_COLOR ='Blue' ";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(color, list);
            //return dt.ToString();
        }

    }
}

