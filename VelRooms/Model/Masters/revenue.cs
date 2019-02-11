using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using DAL;
using HMS.View.Masters;
using System;

namespace HMS.Model
{
    public class revenue
    {
        public string REVENUE_CODE { get; set; }
        public string AUDIT_GROUP { get; set; }
        public string NAME { get; set; }
        public string CLASSIFICATION { get; set; }
        public string MISCELLANOUS { get; set; }
        public string PRINT_VOUCHER { get; set; }
        public string TAX_STRUCTURE { get; set; }
        public string MIS_TAX_STRUCTURE { get; set; }
        public string STATUS { get; set; }
        //11/15/2017
        // public string USER_NAME { get; set; }
        public string INSERT_BY { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime UPDATE_DATE { get; set; }

        //Insertion of data into database
        public void Insert()
        {
            var list = new List<SqlParameter>();

            list.AddSqlParameter("@REVENUE_CODE", REVENUE_CODE);
            list.AddSqlParameter("@AUDIT_GROUP", AUDIT_GROUP);
            list.AddSqlParameter("@NAME", NAME);
            list.AddSqlParameter("@CLASSIFICATION", CLASSIFICATION);
            list.AddSqlParameter("@MISCELLANOUS", MISCELLANOUS);
            list.AddSqlParameter("@PRINT_VOUCHER", PRINT_VOUCHER);
            list.AddSqlParameter("@TAX_STRUCTURE", TAX_STRUCTURE);
            list.AddSqlParameter("@MIS_TAX_STRUCTURE", MIS_TAX_STRUCTURE);
            list.AddSqlParameter("@STATUS", STATUS);
            // USER INSERT SRIKAR INSERTBY
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

            string query = "IF EXISTS (SELECT REVENUE_CODE FROM REVENUE WHERE REVENUE_CODE = @REVENUE_CODE) BEGIN UPDATE REVENUE SET AUDIT_GROUP = @AUDIT_GROUP," +
                           "NAME = @NAME,CLASSIFICATION = @CLASSIFICATION,MISCELLANOUS = @MISCELLANOUS,PRINT_VOUCHER = @PRINT_VOUCHER," +
                           "TAX_STRUCTURE = @TAX_STRUCTURE,MIS_TAX_STRUCTURE = @MIS_TAX_STRUCTURE,STATUS = @STATUS,UPDATE_BY=@UPDATE_BY,UPDATE_DATE=@UPDATE_DATE WHERE REVENUE_CODE = @REVENUE_CODE END " +
                           "ELSE BEGIN INSERT INTO REVENUE(REVENUE_CODE, AUDIT_GROUP, NAME, CLASSIFICATION, MISCELLANOUS, PRINT_VOUCHER, TAX_STRUCTURE, " +
                           "MIS_TAX_STRUCTURE, STATUS,INSERT_BY,INSERT_DATE)VALUES (@REVENUE_CODE,@AUDIT_GROUP,@NAME,@CLASSIFICATION,@MISCELLANOUS,@PRINT_VOUCHER,@TAX_STRUCTURE," +
                           "@MIS_TAX_STRUCTURE,@STATUS,@INSERT_BY,@INSERT_DATE)END";

            DbFunctions.ExecuteCommand<int>(query, list);
        }
        public void UPDATE()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@REVENUE_CODE", REVENUE_CODE);
            list.AddSqlParameter("@AUDIT_GROUP", AUDIT_GROUP);
            list.AddSqlParameter("@NAME", NAME);
            list.AddSqlParameter("@CLASSIFICATION", CLASSIFICATION);
            list.AddSqlParameter("@MISCELLANOUS", MISCELLANOUS);
            list.AddSqlParameter("@PRINT_VOUCHER", PRINT_VOUCHER);
            list.AddSqlParameter("@TAX_STRUCTURE", TAX_STRUCTURE);
            list.AddSqlParameter("@MIS_TAX_STRUCTURE", MIS_TAX_STRUCTURE);
            list.AddSqlParameter("@STATUS", STATUS);
            UPDATE_BY = login.u;
            UPDATE_DATE = DateTime.Today;
            list.AddSqlParameter("@UPDATE_BY", UPDATE_BY);
            list.AddSqlParameter("@UPDATE_DATE", UPDATE_DATE);

            string s = "UPDATE REVENUE SET AUDIT_GROUP = @AUDIT_GROUP," +
                           "NAME = @NAME,CLASSIFICATION = @CLASSIFICATION,MISCELLANOUS = @MISCELLANOUS,PRINT_VOUCHER = @PRINT_VOUCHER," +
                           "TAX_STRUCTURE = @TAX_STRUCTURE,MIS_TAX_STRUCTURE = @MIS_TAX_STRUCTURE,STATUS = @STATUS,UPDATE_BY=@UPDATE_BY,UPDATE_DATE=@UPDATE_DATE WHERE REVENUE_CODE = @REVENUE_CODE";
            DbFunctions.ExecuteCommand<int>(s, list);
        }
        //Retrival of data from database
        public void Retrive()
        {
            var list = new List<SqlParameter>();

            string S = "SELECT * FROM REVENUE WHERE REVENUE_CODE = '" + REVENUE_CODE + "'";

            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, list);

            NAME = dt.Rows[0]["NAME"].ToString();
            AUDIT_GROUP = dt.Rows[0]["AUDIT_GROUP"].ToString();
            CLASSIFICATION = dt.Rows[0]["CLASSIFICATION"].ToString();
            MISCELLANOUS = dt.Rows[0]["MISCELLANOUS"].ToString();
            PRINT_VOUCHER = dt.Rows[0]["PRINT_VOUCHER"].ToString();
            TAX_STRUCTURE = dt.Rows[0]["TAX_STRUCTURE"].ToString();
            MIS_TAX_STRUCTURE = dt.Rows[0]["MIS_TAX_STRUCTURE"].ToString();
            STATUS = dt.Rows[0]["STATUS"].ToString();
        }
        public DataTable fill_revenuegrid()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT REVENUE_CODE,NAME,MISCELLANOUS,STATUS,MIS_TAX_STRUCTURE,PRINT_VOUCHER,TAX_STRUCTURE FROM REVENUE";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable fill_revenuedata()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT REVENUE_CODE,NAME,MISCELLANOUS,STATUS,MIS_TAX_STRUCTURE,TAX_STRUCTURE,PRINT_VOUCHER FROM REVENUE";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
    }
}



