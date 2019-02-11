using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model.Masters
{
    public class Passwordreset
    {
        public string USER_NAME { get; set; }
        public string NAME { get; set; }
        public string REPORTING_NAME { get; set; }
        public string OLD_PASSWORD { get; set; }
        public string NEW_PASSWORD { get; set; }
        public string CONFIRM_PASSWORD { get; set; }

        public int match = 0, c = 0;
        public string d = null;

        public void GET_STATUS_OF_DATA()
        {
            var listParams = new List<SqlParameter>();
            listParams.AddSqlParameter("@USER_NAME", USER_NAME);
            String S = "SELECT * FROM REGISTRATION WHERE USER_NAME=@USER_NAME";
            object OB = DbFunctions.ExecuteCommand<object>(S, listParams);
            if (OB == null)
            {
                match = 0;
                NAME = "";
                REPORTING_NAME = "";
            }
            else
            {
                c = 1; match = 1;
                string s = "SELECT * FROM REGISTRATION WHERE USER_NAME = @USER_NAME";
                GET_FETCHED_DATA(s);
            }
            return;
        }
        public void GET_FETCHED_DATA(String S)
        {
            var listParams = new List<SqlParameter>();
            listParams.AddSqlParameter("@USER_NAME", USER_NAME);
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, listParams);
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                NAME = dt.Rows[r]["FIRSTNAME"].ToString();
                REPORTING_NAME = dt.Rows[r]["INSERT_BY"].ToString();
            }

        }
        public DataTable setdata()
        {
            DataTable D = null;
            if (USER_NAME != "")
            {
                var listParams = new List<SqlParameter>();
                listParams.AddSqlParameter("@USER_NAME", USER_NAME);
                string S = "SELECT TOP 5 USER_NAME FROM REGISTRATION WHERE USER_NAME LIKE '" + USER_NAME + "%' ";
                using (D = DbFunctions.ExecuteCommand<DataTable>(S, listParams))
                {
                    d = USER_NAME;

                }
            }
            USER_NAME = d;

            return D;
        }
        public void Get_Password()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT PASS_WORD FROM REGISTRATION WHERE USER_NAME = '" + USER_NAME + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {
                OLD_PASSWORD = "";
            }
            else
            {
                OLD_PASSWORD = dt.Rows[0]["PASS_WORD"].ToString();
            }
        }
        public void Password_Update()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@NEW_PASSWORD", NEW_PASSWORD);
            list.AddSqlParameter("@CONFIRM_PASSWORD", CONFIRM_PASSWORD);

            string S = "UPDATE REGISTRATION SET PASS_WORD = @NEW_PASSWORD , RETYPEPASSWORD = @CONFIRM_PASSWORD WHERE USER_NAME = '" + USER_NAME + "'";

            DbFunctions.ExecuteCommand<int>(S, list);
        }
    }
}
