using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.View.Masters;
using System.Data;

namespace HMS.Model
{
    public class DEPARTMENTS
    {
        public string DEPARTMENT_CODE { get; set; }
        public string DEPARTMENT_NAME { get; set; }
        public string REPORT_NAME { get; set; }
        public string STATUS { get; set; }
        //11/15/2017
        //public string USER_NAME { get; set; }
        public string INSERT_BY { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public void INSERT()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@DEPARTMENT_CODE", DEPARTMENT_CODE);
            list.AddSqlParameter("@DEPARTMENT_NAME", DEPARTMENT_NAME);
            list.AddSqlParameter("@REPORT_NAME", REPORT_NAME);
            list.AddSqlParameter("@STATUS", STATUS);
            // USER INSERT SRI INSERTBY
            //list.AddSqlParameter("@USER_NAME", USER_NAME);
            INSERT_BY = login.u;
            list.AddSqlParameter("@INSERT_BY", INSERT_BY);
            list.AddSqlParameter("@INSERT_DATE", DateTime.Today);
            UPDATE_BY = login.u;
            list.AddSqlParameter("@UPDATE_BY", UPDATE_BY);
            list.AddSqlParameter("@UPDATE_DATE", DateTime.Today);

            //IF EXISTS (SELECT DEPARTMENT_CODE FROM DEPARTMENT WHERE DEPARTMENT_CODE=@DEPARTMENT_CODE) BEGIN UPDATE DEPARTMENT SET DEPARTMENT_NAME=@DEPARTMENT_NAME,REPORT_NAME=@REPORT_NAME,INSERT_BY=@INSERT_BY,INSERT_DATE=@INSERT_DATE,STATUS=@STATUS,UPDATE_BY=@UPDATE_BY,UPDATE_DATE=@UPDATE_DATE WHERE DEPARTMENT_CODE=@DEPARTMENT_CODE END ELSE BEGIN 
            string query = "INSERT INTO DEPARTMENT(DEPARTMENT_CODE,DEPARTMENT_NAME,REPORT_NAME,STATUS,INSERT_BY,INSERT_DATE)VALUES(@DEPARTMENT_CODE,@DEPARTMENT_NAME,@REPORT_NAME,@STATUS,@INSERT_BY,@INSERT_DATE)";
            DbFunctions.ExecuteCommand<int>(query, list);
        }
        public void UPDATE()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@DEPARTMENT_CODE", DEPARTMENT_CODE);
            list.AddSqlParameter("@DEPARTMENT_NAME", DEPARTMENT_NAME);
            list.AddSqlParameter("@REPORT_NAME", REPORT_NAME);
            list.AddSqlParameter("@STATUS", STATUS);
            // USER INSERT SRI INSERTBY
            //list.AddSqlParameter("@USER_NAME", USER_NAME);
            INSERT_BY = login.u;
            list.AddSqlParameter("@INSERT_BY", INSERT_BY);
            list.AddSqlParameter("@INSERT_DATE", DateTime.Today);
            UPDATE_BY = login.u;
            list.AddSqlParameter("@UPDATE_BY", UPDATE_BY);
            list.AddSqlParameter("@UPDATE_DATE", DateTime.Today);

            //IF EXISTS (SELECT DEPARTMENT_CODE FROM DEPARTMENT WHERE DEPARTMENT_CODE=@DEPARTMENT_CODE) BEGIN UPDATE DEPARTMENT SET DEPARTMENT_NAME=@DEPARTMENT_NAME,REPORT_NAME=@REPORT_NAME,INSERT_BY=@INSERT_BY,INSERT_DATE=@INSERT_DATE,STATUS=@STATUS,UPDATE_BY=@UPDATE_BY,UPDATE_DATE=@UPDATE_DATE WHERE DEPARTMENT_CODE=@DEPARTMENT_CODE END ELSE BEGIN 
            string query = "UPDATE DEPARTMENT SET DEPARTMENT_NAME=@DEPARTMENT_NAME,REPORT_NAME=@REPORT_NAME,INSERT_BY=@INSERT_BY,INSERT_DATE=@INSERT_DATE,STATUS=@STATUS,UPDATE_BY=@UPDATE_BY,UPDATE_DATE=@UPDATE_DATE WHERE DEPARTMENT_CODE=@DEPARTMENT_CODE";
            DbFunctions.ExecuteCommand<int>(query, list);
            //var list = new List<SqlParameter>();

            //string S = "SELECT * FROM DEPARTMENT WHERE DEPARTMENT_CODE = '" + DEPARTMENT_CODE + "' ";
            //DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, list);
            //if (dt.Rows.Count == 0)
            //{
            //    DEPARTMENT_NAME = "";
            //    REPORT_NAME = "";

            //}
            //else
            //{
            //    DEPARTMENT_NAME = dt.Rows[0][1].ToString();
            //    REPORT_NAME = dt.Rows[0][2].ToString();
            //    STATUS = dt.Rows[0][3].ToString();
            //}
        }
        public DataTable fill_deptgrid()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT DEPARTMENT_CODE,DEPARTMENT_NAME,REPORT_NAME,STATUS FROM DEPARTMENT";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable fill_deptdata()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT DEPARTMENT_CODE,DEPARTMENT_NAME,REPORT_NAME,STATUS FROM DEPARTMENT";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
    }
}
