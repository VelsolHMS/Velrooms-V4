using DAL;
using HMS.View.Masters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model.Masters
{
    class BankWallet1
    {
        public int BANK_ID { get; set; }
        public string BANK_CODE { get; set; }
        public string BANK_NAME { get; set; }
        public string ACCOUNT_NUMBER { get; set; }
        public int WALLET_ID { get; set; }
        public string WALLET_CODE { get; set; }
        public string WALLET_NAME { get; set; }
        public string REPORT_NAME { get; set; }
        public string STATUS { get; set; }
        public string INSERT_BY { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime UPDATE_DATE { get; set; }

        public void INSERT()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@BANK_ID", BANK_ID);
            list.AddSqlParameter("@BANK_CODE", BANK_CODE);
            list.AddSqlParameter("@BANK_NAME", BANK_NAME);
            list.AddSqlParameter("@ACCOUNT_NUMBER", ACCOUNT_NUMBER);
            list.AddSqlParameter("@WALLET_ID", WALLET_ID);
            list.AddSqlParameter("@WALLET_CODE", WALLET_CODE);
            list.AddSqlParameter("@WALLET_NAME", WALLET_NAME);
            list.AddSqlParameter("@REPORT_NAME", REPORT_NAME);
            list.AddSqlParameter("@STATUS", STATUS);
            INSERT_BY = login.u;
            INSERT_DATE = DateTime.Today;
            list.AddSqlParameter("@INSERT_BY", INSERT_BY);
            list.AddSqlParameter("@INSERT_DATE", INSERT_DATE);

            string K = "INSERT INTO BANK (BANK_CODE,BANK_NAME,ACCOUNT_NUMBER,REPORT_NAME,STATUS,INSERT_BY,INSERT_DATE) VALUES(@BANK_CODE,@BANK_NAME,@ACCOUNT_NUMBER,@REPORT_NAME,@STATUS,@INSERT_BY,@INSERT_DATE)";
            DbFunctions.ExecuteCommand<int>(K, list);

        }

        public void INSERT1()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@BANK_ID", BANK_ID);
            list.AddSqlParameter("@BANK_CODE", BANK_CODE);
            list.AddSqlParameter("@BANK_NAME", BANK_NAME);
            list.AddSqlParameter("@ACCOUNT_NUMBER", ACCOUNT_NUMBER);
            list.AddSqlParameter("@WALLET_ID", WALLET_ID);
            list.AddSqlParameter("@WALLET_CODE", WALLET_CODE);
            list.AddSqlParameter("@WALLET_NAME", WALLET_NAME);
            list.AddSqlParameter("@REPORT_NAME", REPORT_NAME);
            list.AddSqlParameter("@STATUS", STATUS);
            INSERT_BY = login.u;
            INSERT_DATE = DateTime.Today;
            list.AddSqlParameter("@INSERT_BY", INSERT_BY);
            list.AddSqlParameter("@INSERT_DATE", INSERT_DATE);

            string KK = "INSERT INTO WALLET (WALLET_CODE,WALLET_NAME,REPORT_NAME,STATUS,INSERT_BY,INSERT_DATE)VALUES(@WALLET_CODE,@WALLET_NAME,@REPORT_NAME,@STATUS,@INSERT_BY,@INSERT_DATE)";
            DbFunctions.ExecuteCommand<int>(KK, list);
        }
    }
}
