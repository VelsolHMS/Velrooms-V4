using System.Collections.Generic;
using DAL;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using HMS.View;
using HMS.Properties;
using HMS.View.Masters;
using System;

namespace HMS.Model
{
    public class miscellenous
    {
        public string MEMBER_NAME { get; set; }
        public string REVENUE { get; set; }
        public string PAYMENT_MODE { get; set; }
        public string EXCHANGE_RATE { get; set; }
        public string EXCHANGE_AMOUNT { get; set; }
        public string CURRENCY_CODE { get; set; }
        public string RECEIVED_AMOUNT { get; set; }
        public string TAX_CODE { get; set; }
        public string TAX_AMOUNT { get; set; }
        public string PARTICULARS { get; set; }
        public string TOTAL_AMOUNT { get; set; }

        //11/15/2017
        //  public string USER_NAME { get; set; }
        public string INSERT_BY { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime UPDATE_DATE { get; set; }

        //Insertion of data into database
        public void Insert()
        {
            var list = new List<SqlParameter>();

            list.AddSqlParameter("@MEMBER_NAME", MEMBER_NAME);
            list.AddSqlParameter("@REVENUE", REVENUE);
            list.AddSqlParameter("@PAYMENT_MODE", PAYMENT_MODE);
            list.AddSqlParameter("@EXCHANGE_RATE", EXCHANGE_RATE);
            list.AddSqlParameter("@EXCHANGE_AMOUNT", EXCHANGE_AMOUNT);
            list.AddSqlParameter("@CURRENCY_CODE", CURRENCY_CODE);
            list.AddSqlParameter("@RECEIVED_AMOUNT", RECEIVED_AMOUNT);
            list.AddSqlParameter("@TAX_CODE", TAX_CODE);
            list.AddSqlParameter("@TAX_AMOUNT", TAX_AMOUNT);
            list.AddSqlParameter("@PARTICULARS", PARTICULARS);
            list.AddSqlParameter("@TOTAL_AMOUNT", TOTAL_AMOUNT);
            // USER INSERT SRI INSERTBY
            //list.AddSqlParameter("@USER_NAME", USER_NAME);
            INSERT_BY = login.u;
            INSERT_DATE = DateTime.Today;
            list.AddSqlParameter("@INSERT_BY", INSERT_BY);
            list.AddSqlParameter("@INSERT_DATE", INSERT_DATE);
            //USER_NAME = login.u;

            //list.AddSqlParameter("@USER_NAME", USER_NAME);
            //list.AddSqlParameter("@RECEIPT_NO", RECEIPT_NO);

            string query = "IF EXISTS (SELECT MEMBER_NAME FROM MISCELLENOUS WHERE MEMBER_NAME = @MEMBER_NAME) " +
                           "BEGIN UPDATE MISCELLENOUS SET REVENUE = @REVENUE, PAYMENT_MODE = @PAYMENT_MODE, EXCHANGE_RATE = @EXCHANGE_RATE, " +
                           "EXCHANGE_AMOUNT = @EXCHANGE_AMOUNT, CURRENCY_CODE = @CURRENCY_CODE, RECEIVED_AMOUNT = @RECEIVED_AMOUNT, TAX_CODE = @TAX_CODE," +
                           "TAX_AMOUNT = @TAX_AMOUNT, PARTICULARS = @PARTICULARS, TOTAL_AMOUNT = @TOTAL_AMOUNT ,INSERT_BY=@INSERT_BY,INSERT_DATE=@INSERT_DATE WHERE MEMBER_NAME = @MEMBER_NAME END " +
                           "ELSE BEGIN INSERT INTO MISCELLENOUS(MEMBER_NAME, REVENUE, PAYMENT_MODE, EXCHANGE_RATE, EXCHANGE_AMOUNT, CURRENCY_CODE, " +
                           "RECEIVED_AMOUNT,TAX_CODE,TAX_AMOUNT,PARTICULARS,TOTAL_AMOUNT,INSERT_BY,INSERT_DATE)VALUES (@MEMBER_NAME, @REVENUE, @PAYMENT_MODE, @EXCHANGE_RATE," +
                           "@EXCHANGE_AMOUNT, @CURRENCY_CODE, @RECEIVED_AMOUNT, @TAX_CODE, @TAX_AMOUNT, @PARTICULARS, @TOTAL_AMOUNT,@INSERT_BY,@INSERT_DATE)END";

            DbFunctions.ExecuteCommand<int>(query, list);
        }

        //Retrival of data form database
        public void Retrive()
        {
            var list = new List<SqlParameter>();

            string query = "SELECT * FROM MISCELLENOUS WHERE MEMBER_NAME = '" + MEMBER_NAME + "'";

            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(query, list);

            REVENUE = dt.Rows[0][1].ToString();
            PAYMENT_MODE = dt.Rows[0][2].ToString();
            EXCHANGE_RATE = dt.Rows[0][3].ToString();
            EXCHANGE_AMOUNT = dt.Rows[0][4].ToString();
            CURRENCY_CODE = dt.Rows[0][5].ToString();
            RECEIVED_AMOUNT = dt.Rows[0][6].ToString();
            TAX_CODE = dt.Rows[0][7].ToString();
            TAX_AMOUNT = dt.Rows[0][8].ToString();
            PARTICULARS = dt.Rows[0][9].ToString();
            TOTAL_AMOUNT = dt.Rows[0][10].ToString();
        }

        //TAX Percentage
        public DataTable tax()
        {
            var list = new List<SqlParameter>();
            string query = "SELECT FACTOR FROM TAX_CODE WHERE TAX_CODE = '" + TAX_CODE + "'";
            DataTable tax = DbFunctions.ExecuteCommand<DataTable>(query, list);
            return tax;
        }

        public DataTable mixtax()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT MIS_TAX_STRUCTURE FROM REVENUE WHERE NAME='" + REVENUE + "'";
            DataTable D = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return D;
        }
            //Tax Codes for tax percentage
        public DataTable taxcodes()
        {
            var list = new List<SqlParameter>();
            string query = "SELECT TAX_CODE FROM TAX_CODE WHERE STATUS='ACTIVE' ";
            DataTable taxcodes = DbFunctions.ExecuteCommand<DataTable>(query, list);
            return taxcodes;
        }
        //Revenue Codes
        public DataTable revenue()
        {
            var list = new List<SqlParameter>();
            string query = "SELECT NAME FROM REVENUE WHERE MISCELLANOUS='Yes' AND  STATUS='ACTIVE' ";
            DataTable revenue = DbFunctions.ExecuteCommand<DataTable>(query, list);
            return revenue;
        }
        public int getid()
        {
            int a = 0;
            string S = "SELECT MAX(MISCELLENOUS_ID) FROM MISCELLENOUS";
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
    }

}
