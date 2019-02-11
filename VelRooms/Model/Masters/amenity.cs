using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using HMS.View.Masters;

namespace HMS.Model
{
    public class Amenity
    {
        public String AMENITY_CODE { get; set; }
        public String AMENITY_NAME { get; set; }
        public String DESCRIPTION { get; set; }
        public String AMOUNT { get; set; }
        public String REPORTING_NAME { get; set; }
        public String STATUS { get; set; }
        public string button { get; set; }
        //11/15/2017
        //public string USER_NAME { get; set; }
        public string INSERT_BY { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public List<SqlParameter> GETBINDEDDATA()
        {
            var listParams = new List<SqlParameter>();
            listParams.AddSqlParameter("@AMENITY_CODE", AMENITY_CODE);
            listParams.AddSqlParameter("@AMENITY_NAME", AMENITY_NAME);
            listParams.AddSqlParameter("@DESCRIPTION", DESCRIPTION);
            listParams.AddSqlParameter("@AMOUNT", AMOUNT);
            listParams.AddSqlParameter("@REPORTING_NAME", REPORTING_NAME);
            listParams.AddSqlParameter("@STATUS", STATUS);
            return listParams;
        }
        public void INSERT()
        {
            var listParams = GETBINDEDDATA();
            // USER INSERT SRI INSERTBY
            // listParams.AddSqlParameter("@USER_NAME", USER_NAME);
            INSERT_BY = login.u;
            INSERT_DATE = DateTime.Today;
            listParams.AddSqlParameter("@INSERT_BY", INSERT_BY);
            listParams.AddSqlParameter("@INSERT_DATE", INSERT_DATE);
            String S = "INSERT INTO AMENITIES(AMENITY_CODE,AMENITY_NAME,DESCRIPTION,AMOUNT,REPORTING_NAME,STATUS,INSERT_BY,INSERT_DATE)VALUES(@AMENITY_CODE,@AMENITY_NAME,@DESCRIPTION,@AMOUNT,@REPORTING_NAME,@STATUS,@INSERT_BY,@INSERT_DATE)";
            DbFunctions.ExecuteCommand<int>(S, listParams);

        }
        public DataTable retrive()
        {
            var list = GETBINDEDDATA();
            string s = "SELECT * FROM AMENITIES WHERE AMENITY_CODE = '" + AMENITY_CODE + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {
                AMENITY_NAME = "";
                DESCRIPTION = "";
                AMOUNT = "";
                REPORTING_NAME = "";
                STATUS = "";
            }
            else
            {
                AMENITY_NAME = dt.Rows[0]["AMENITY_NAME"].ToString();
                DESCRIPTION = dt.Rows[0]["DESCRIPTION"].ToString();
                AMOUNT = dt.Rows[0]["AMOUNT"].ToString();
                REPORTING_NAME = dt.Rows[0]["REPORTING_NAME"].ToString();
                STATUS = dt.Rows[0]["STATUS"].ToString();
            }
            return dt;
        }
        public void UPDATE()
        {
            var listParams = GETBINDEDDATA();
            listParams.AddSqlParameter("UPDATE_BY", login.u);
            listParams.AddSqlParameter("UPDATE_DATE", DateTime.Now);
            String S = "UPDATE AMENITIES SET AMENITY_NAME=@AMENITY_NAME,DESCRIPTION=@DESCRIPTION,AMOUNT=@AMOUNT,REPORTING_NAME=@REPORTING_NAME,STATUS=@STATUS,UPDATE_BY=@UPDATE_BY,UPDATE_DATE=@UPDATE_DATE WHERE AMENITY_CODE=@AMENITY_CODE";
            DbFunctions.ExecuteCommand<int>(S, listParams);

        }
        public int match = 0, c = 0;
        public void GET_STATUS_OF_DATA()
        {
            var listParams = new List<SqlParameter>();
            listParams.AddSqlParameter("@AMENITY_CODE", AMENITY_CODE);
            String S = "SELECT * FROM AMENITIES WHERE AMENITY_CODE=@AMENITY_CODE";
            object OB = DbFunctions.ExecuteCommand<object>(S, listParams);
            if (button == "add")
            {
                if (OB != null)
                {

                    //validate here (CODE TEXTBOX)-------beacause we should not allow user to insert code which is already present.
                }
                else { }
            }
            if (button == "modify")
            {
                if (OB == null)
                {
                    match = 0;
                    CLEARBACK_CODE();
                }
                else
                {
                    c = 1; match = 1;
                    string s = "SELECT * FROM AMENITIES WHERE AMENITY_CODE = @AMENITY_CODE";
                    GET_FETCHED_DATA(s);
                }
            }
            return;
        }
        public string d = null;
        public DataTable setdata()
        {
            DataTable D = null;
            if (button == "modify")
            {
                if (AMENITY_CODE != "")
                {
                    var listParams = new List<SqlParameter>();
                    listParams.AddSqlParameter("@AMENITY_CODE", AMENITY_CODE);
                    string S = "SELECT TOP 5 AMENITY_CODE FROM AMENITIES WHERE AMENITY_CODE LIKE '" + AMENITY_CODE + "%' ";
                    using (D = DbFunctions.ExecuteCommand<DataTable>(S, listParams))
                    {
                        d = AMENITY_CODE;

                    }
                }
                AMENITY_CODE = d;

            }
            return D;
        }
        public void CLEARBACK_CODE()
        {
            String S = String.Empty;
            AMENITY_NAME = S;
            REPORTING_NAME = S;
            STATUS = S;
            AMOUNT = S;
            DESCRIPTION = S;
        }
        public void GET_FETCHED_DATA(String S)
        {
            var listParams = new List<SqlParameter>();
            listParams.AddSqlParameter("@AMENITY_CODE", AMENITY_CODE);
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, listParams);
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                AMENITY_NAME = dt.Rows[r]["AMENITY_NAME"].ToString();
                DESCRIPTION = dt.Rows[r]["DESCRIPTION"].ToString();
                AMOUNT = dt.Rows[r]["AMOUNT"].ToString();
                REPORTING_NAME = dt.Rows[r]["REPORTING_NAME"].ToString();
                STATUS = dt.Rows[r]["STATUS"].ToString();
            }

        }
        public int count = 0, pc = 0;
        public void GETCOUNT()
        {
            count++;
            if (count >= 3)
            {
                if (d.Length != 2 && d.Length < 2)
                {
                    if (d.Length == 0)
                    {
                        AMENITY_CODE = ""; count = 0; CLEARBACK_CODE(); pc = 1;

                    }
                }
            }
        }
        public object GET_STATUS_OF_DATA_NAMEFIELD()
        {
            var listParams = new List<SqlParameter>();
            listParams.AddSqlParameter("@AMENITY_NAME", AMENITY_NAME);
            String S = "SELECT * FROM AMENITIES WHERE AMENITY_NAME=@AMENITY_NAME";
            object OB = DbFunctions.ExecuteCommand<object>(S, listParams);//  return OB;
            if (button == "add")
            {
                if (OB != null)
                {
                    //validate here (CODE TEXTBOX)-------beacause we should not allow user to insert code which is already present.
                }
                else { }
            }
            if (button == "modify")
            {
                //if (OB != null)
                //{
                //    //nameclear = "1"; name = 1;
                //    string w = "SELECT * FROM AMENITIES WHERE NAME=@NAME";
                //    GET_FETCHED_DATA_NAME(w);

                //}
                //else
                //{
                //    CLEARBACK_NAME();
                //    //validate here (CODE TEXTBOX)-------beacause we should not allow user to insert code which is doesnot exist.
                //}


                //  setdata_NAME();
            }
            return OB;
        }
        public string F = null;
        public DataTable setdata_NAME()
        {
            DataTable D = null;
            if (button == "modify")
            {
                if (AMENITY_NAME != "")
                {
                    var listParams = new List<SqlParameter>();
                    listParams.AddSqlParameter("@AMENITY_NAME", AMENITY_NAME);
                    string S = "SELECT AMENITY_NAME FROM AMENITIES WHERE AMENITY_NAME LIKE '" + AMENITY_NAME + "%' ";
                    using (D = DbFunctions.ExecuteCommand<DataTable>(S, listParams))
                    {
                        F = AMENITY_NAME;
                    }
                }
                AMENITY_NAME = F;
            }
            return D;
        }
        public void GET_FETCHED_DATA_NAME(string S)
        {
            var listParams = new List<SqlParameter>();
            listParams.AddSqlParameter("@AMENITY_NAME", AMENITY_NAME);
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, listParams);
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                AMENITY_CODE = dt.Rows[r]["AMENITY_CODE"].ToString();
                DESCRIPTION = dt.Rows[r]["DESCRIPTION"].ToString();
                AMOUNT = dt.Rows[r]["AMOUNT"].ToString();
                REPORTING_NAME = dt.Rows[r]["REPORTING_NAME"].ToString();
                STATUS = dt.Rows[r]["STATUS"].ToString();
            }
        }
        public void CLEARBACK_NAME()
        {
            string S = string.Empty;
            AMENITY_CODE = S;
            DESCRIPTION = S;
            AMOUNT = S;
            REPORTING_NAME = S;
            STATUS = S;
        }
        //public int u = 0;
        //public void GETCOUNT_NAME()
        //{
        //    u++;
        //    if (u >= 3)
        //    {
        //        if (F.Length != 2 && F.Length < 2)
        //        {
        //            if (F.Length == 1)
        //            {
        //                AMENITY_NAME = ""; u = 0; CLEARBACK_NAME();
        //            }
        //        }
        //    }
        //}
        public DataTable data()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT AMENITY_CODE,AMENITY_NAME,DESCRIPTION,CONVERT(decimal(17,2),AMOUNT) AS AMOUNT,REPORTING_NAME,STATUS FROM AMENITIES";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public DataTable grid()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT AMENITY_CODE,AMENITY_NAME,DESCRIPTION,AMOUNT,REPORTING_NAME,STATUS FROM AMENITIES";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
    }
}