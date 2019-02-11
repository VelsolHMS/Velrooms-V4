using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.View.Masters;
using DAL;
using System.Data;
using System.Windows;


namespace HMS.Model.Masters
{
    public class plancode
    {

        public string PLAN_CODE { get; set; }
        public string NAME { get; set; }
        public string REPORTING_NAME { get; set; }
        public string STATUS { get; set; }
        public string button { get; set; }
        //11/15/2017
        //public string USER_NAME { get; set; }
        public string INSERT_BY { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime UPDATE_DATE { get; set; }

        public void INSERT()
        {

            var listParams = GETBINDEDDATA();

            // USER INSERT SRI INSERTBY
            //listParams.AddSqlParameter("@USER_NAME", USER_NAME);
            listParams.AddSqlParameter("@INSERT_BY", INSERT_BY);
            listParams.AddSqlParameter("@INSERT_DATE", INSERT_DATE);
            //USER_NAME = login.u;
            INSERT_BY = login.u;
            INSERT_DATE = DateTime.Today;
            string S = "Insert into PLANCODES (PLAN_CODE,NAME,REPORTING_NAME,STATUS,INSERT_BY,INSERT_DATE)VALUES(@PLAN_CODE,@NAME,@REPORTING_NAME,@STATUS,@INSERT_BY,@INSERT_DATE)";
            DbFunctions.ExecuteCommand<int>(S, listParams);
        }

        public List<SqlParameter> GETBINDEDDATA()
        {
            var listParams = new List<SqlParameter>();
            listParams.AddSqlParameter("@PLAN_CODE", PLAN_CODE);
            listParams.AddSqlParameter("@NAME", NAME);
            listParams.AddSqlParameter("@REPORTING_NAME", REPORTING_NAME);
            listParams.AddSqlParameter("@STATUS", STATUS);

            return listParams;
        }
        public void UPDATE()
        {

            var listParams = GETBINDEDDATA();

            listParams.AddSqlParameter("@UPDATEBY", login.u);
            listParams.AddSqlParameter("@UPDATEDATE", DateTime.Now);
            string s = "UPDATE PLANCODES SET NAME =@NAME,REPORTING_NAME=@REPORTING_NAME,STATUS=@STATUS,UPDATE_BY=@UPDATEBY,UPDATE_DATE=@UPDATEDATE WHERE PLAN_CODE=@PLAN_CODE";
            DbFunctions.ExecuteCommand<int>(s, listParams);
        }

        public void GET_STATUS_OF_DATA()
        {

            if (PLAN_CODE != "")
            {
                string S = "SELECT * FROM PLANCODES WHERE PLAN_CODE=@PLAN_CODE";
                var listParams = new List<SqlParameter>();
                listParams.AddSqlParameter("@PLAN_CODE", PLAN_CODE);
                object OB = DbFunctions.ExecuteCommand<object>(S, listParams);
                if (button == "add")
                {
                    if (OB != null)
                    {
                        //validate here (PLANECODE TEXTBOX)-------beacause we should not allow user to insert plancode which is already present.
                    }
                    else { }
                }
                if (button == "modify")
                {
                    if (OB == null)
                    {
                        match = 0;
                        CLEARBACK();
                        //validate here(PLANECODE TEXTBOX)    -------we should not allow user to add the date which is not present .
                    }
                    else
                    {
                        c = 1; match = 1;
                        string STR = "SELECT * FROM PLANCODES WHERE PLAN_CODE=@PLAN_CODE";
                        fetchdata(STR);

                    }

                    return;
                }
            }
        }
        public int c = 0; public int match = 0;
        public void CLEARBACK()
        {

            string S = string.Empty;
            NAME = S;
            REPORTING_NAME = S;
            STATUS = S;
        }
        public void fetchdata(string S)
        {

            var listParams = new List<SqlParameter>();
            listParams.AddSqlParameter("@PLAN_CODE", PLAN_CODE);
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, listParams);
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                PLAN_CODE = dt.Rows[r]["PLAN_CODE"].ToString();
                NAME = dt.Rows[r]["NAME"].ToString();
                REPORTING_NAME = dt.Rows[r]["REPORTING_NAME"].ToString();
                STATUS = dt.Rows[r]["STATUS"].ToString();

            }

        }
        public string d = null;
        public DataTable setdata()
        {

            DataTable D = null;
            if (button == "modify")
            {
                if (PLAN_CODE != "")
                {
                    var listParams = new List<SqlParameter>();
                    listParams.AddSqlParameter("@PLAN_CODE", PLAN_CODE);
                    string S = "SELECT TOP 4 PLAN_CODE FROM PLANCODES WHERE PLAN_CODE LIKE '" + PLAN_CODE + "%' ";
                    using (D = DbFunctions.ExecuteCommand<DataTable>(S, listParams))
                    {
                        d = PLAN_CODE;

                    }
                }
                PLAN_CODE = d;
            }
            return D;
        }
        public int count = 0; public int pc = 0;
        public void GETCOUNT()
        {
            count++;
            if (count >= 3)
            {
                if (d.Length != 2 && d.Length < 2)
                {
                    if (d.Length == 0)
                    {
                        PLAN_CODE = ""; count = 0; CLEARBACK(); pc = 1;
                    }
                }
            }
        }
        public DataTable fill_plangrid()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT PLAN_CODE,NAME,REPORTING_NAME,STATUS FROM PLANCODES";
            DataTable dt= DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable fill_plandata()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT PLAN_CODE,NAME,REPORTING_NAME,STATUS FROM PLANCODES";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        //public DataTable Name()
        //{
        //    var list = new List<SqlParameter>();
        //    string s = "SELECT NAME FROM PLANCODES";
        //    DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
        //    return dt;
        //}
    }
}
