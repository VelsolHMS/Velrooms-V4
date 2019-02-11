using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.View.Masters;



namespace HMS.Model
{
    public class Taxcode1
    {
        public DateTime ACTIVEDATE { get; set; }
        public string MODULE { get; set; } 
        public string TAX_CODE { get; set; }
        public string TAX_NAME { get; set; }
        public string FROM_AMOUNT { get; set; }
        public string TO_AMOUNT { get; set; }
        public string CALCULATION_TYPE { get; set; }
        public string FACTOR { get; set; }
        public string STATUS { get; set; }
        //11/15/2017
        //public string USER_NAME { get; set; }
        public string INSERT_BY { get; set; }
        public DateTime INSERT_DATE { get; set; } 
        public string UPDATE_BY { get; set; }
        public DateTime UPDATE_DATE { get; set; } 
        public string ID { get; set; }
        public void INSERT()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@ACTIVE_DATE", ACTIVEDATE);
            list.AddSqlParameter("@MODULE", MODULE);
            list.AddSqlParameter("@TAX_CODE", TAX_CODE);
            list.AddSqlParameter("@TAX_NAME", TAX_NAME);
            list.AddSqlParameter("@FROM_AMOUNT", FROM_AMOUNT);
            list.AddSqlParameter("@TO_AMOUNT", TO_AMOUNT);
            list.AddSqlParameter("@CALCULATION_TYPE", CALCULATION_TYPE);
            list.AddSqlParameter("@FACTOR", FACTOR);
            list.AddSqlParameter("@STATUS", STATUS);
            // USER INSERT SRI INSERTBY
            //list.AddSqlParameter("@USER_NAME", USER_NAME);
            INSERT_BY = login.u;
            INSERT_DATE = DateTime.Today;
            list.AddSqlParameter("@INSERT_BY", INSERT_BY);
            list.AddSqlParameter("@INSERT_DATE", INSERT_DATE);
            UPDATE_BY = login.u;
            UPDATE_DATE = DateTime.Today;
            list.AddSqlParameter("@UPDATE_BY", UPDATE_BY);
            list.AddSqlParameter("@UPDATE_DATE", UPDATE_DATE);
            //USER_NAME = login.u;


            string query = "IF EXISTS (SELECT TAX_CODE FROM TAX_CODE WHERE TAX_CODE=@TAX_CODE) BEGIN UPDATE TAX_CODE SET ACTIVE_DATE=@ACTIVE_DATE,MODULE=@MODULE,TAX_NAME=@TAX_NAME,CALCULATION_TYPE=@CALCULATION_TYPE,FROM_AMOUNT=@FROM_AMOUNT,TO_AMOUNT=@TO_AMOUNT,FACTOR=@FACTOR,UPDATE_BY=@UPDATE_BY,UPDATE_DATE=@UPDATE_DATE WHERE TAX_CODE=@TAX_CODE END ELSE BEGIN INSERT INTO TAX_CODE(ACTIVE_DATE,MODULE,TAX_CODE,TAX_NAME,FROM_AMOUNT,TO_AMOUNT,CALCULATION_TYPE,FACTOR,STATUS,INSERT_BY,INSERT_DATE)VALUES (@ACTIVE_DATE,@MODULE,@TAX_CODE,@TAX_NAME,@FROM_AMOUNT,@TO_AMOUNT,@CALCULATION_TYPE,@FACTOR,@STATUS,@INSERT_BY,@INSERT_DATE)END";
            DbFunctions.ExecuteCommand<int>(query, list);
        }
        public void UPDATE()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@ACTIVE_DATE", ACTIVEDATE);
            list.AddSqlParameter("@MODULE", MODULE);
            list.AddSqlParameter("@TAX_CODE", TAX_CODE);
            list.AddSqlParameter("@TAX_NAME", TAX_NAME);
            list.AddSqlParameter("@FROM_AMOUNT", FROM_AMOUNT);
            list.AddSqlParameter("@TO_AMOUNT", TO_AMOUNT);
            list.AddSqlParameter("@CALCULATION_TYPE", CALCULATION_TYPE);
            list.AddSqlParameter("@FACTOR", FACTOR);
            list.AddSqlParameter("@STATUS", STATUS);
            UPDATE_BY = login.u;
            UPDATE_DATE = DateTime.Today;
            list.AddSqlParameter("@UPDATE_BY", UPDATE_BY);
            list.AddSqlParameter("@UPDATE_DATE", UPDATE_DATE);
            //USER_NAME = login.u;

            string uquery = "UPDATE TAX_CODE SET ACTIVE_DATE=@ACTIVE_DATE,MODULE=@MODULE,TAX_NAME=@TAX_NAME,CALCULATION_TYPE=@CALCULATION_TYPE,FROM_AMOUNT=@FROM_AMOUNT,TO_AMOUNT=@TO_AMOUNT,FACTOR=@FACTOR,STATUS=@STATUS,UPDATE_BY=@UPDATE_BY,UPDATE_DATE=@UPDATE_DATE WHERE TAX_CODE=@TAX_CODE";
            DbFunctions.ExecuteCommand<int>(uquery, list);
        }
        public void Retrive()
        {
            var list = new List<SqlParameter>();
            string S = "SELECT * FROM TAX_CODE WHERE TAX_CODE = '" + TAX_CODE + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, list);
            ACTIVEDATE = Convert.ToDateTime(dt.Rows[0]["ACTIVE_DATE"].ToString());
            MODULE = dt.Rows[0]["MODULE"].ToString();
            TAX_NAME = dt.Rows[0]["TAX_NAME"].ToString();
            FROM_AMOUNT = dt.Rows[0]["FROM_AMOUNT"].ToString();
            TO_AMOUNT = dt.Rows[0]["TO_AMOUNT"].ToString();
            CALCULATION_TYPE = dt.Rows[0]["CALCULATION_TYPE"].ToString();
            FACTOR = dt.Rows[0]["FACTOR"].ToString();
            STATUS = dt.Rows[0]["STATUS"].ToString();
        }
        public DataTable fill_taxgrid()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT TAX_CODE ,TAX_NAME,CONVERT(decimal(17,2),FROM_AMOUNT) AS FROM_AMOUNT,CONVERT(decimal(17,2),TO_AMOUNT) AS TO_AMOUNT,FACTOR,STATUS FROM TAX_CODE";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable fill_taxdata()
        {
            var list = new List<SqlParameter>();
            string S = "SELECT TAX_CODE,TAX_NAME,MODULE,FACTOR,ACTIVE_DATE,CONVERT(decimal(17,2),FROM_AMOUNT) AS FROM_AMOUNT,CONVERT(decimal(17,2),TO_AMOUNT) AS TO_AMOUNT,CALCULATION_TYPE,STATUS FROM TAX_CODE";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, list);
            return dt;
        }

        public DataTable values()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT CONVERT(decimal(17,2),FROM_AMOUNT) as FROM_AMOUNT,CONVERT(decimal(17,2),TO_AMOUNT) as TO_AMOUNT FROM TAX_CODE WHERE FROM_AMOUNT='" + TAXCODE.amount + "' AND TO_AMOUNT='" + TAXCODE.amount1 + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
    }
}
