using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.SqlClient;
using HMS.View.Masters;

namespace HMS.Model.Operations
{
    public class PAIDOUT
    {
        public string OUTLETCODE { get; set; }
        public string PAIDOUTS { get; set; }
        public string OPENINGBLANCE { get; set; }
        public string VOCHERNUMBER { get; set; }
        public string AUTHORIZATIONS { get; set; }
        public string AMOUNT { get; set; }
        public string PARTICULAR { get; set; }
        public string STATUS { get; set; }
        public string AMOUNT_TYPE { get; set; }
        public string PAYTYPE { get; set; }
        //11/15/2017
        //public string USER_NAME { get; set; }
        public string INSERT_BY { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime UPDTAE_DATE { get; set; }

        public void INSERT()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@OUTLETCODE", OUTLETCODE);
            list.AddSqlParameter("@PAIDOUTS", PAIDOUTS);
            list.AddSqlParameter("@OPENINGBLANCE", OPENINGBLANCE);
            list.AddSqlParameter("@VOCHERNUMBER", VOCHERNUMBER);
            list.AddSqlParameter("@AUTHORIZATIONS", AUTHORIZATIONS);
            list.AddSqlParameter("@AMOUNT", AMOUNT);
            list.AddSqlParameter("@PAYTYPE", PAYTYPE);
            list.AddSqlParameter("@PARTICULAR", PARTICULAR);
            // USER INSERT SRI INSERTBY
            //list.AddSqlParameter("@USER_NAME", USER_NAME);
            INSERT_BY = login.u;
            INSERT_DATE = DateTime.Today;
            list.AddSqlParameter("@INSERT_BY", INSERT_BY);
            list.AddSqlParameter("@INSERT_DATE", INSERT_DATE);
            //USER_NAME = login.u;
            string S = "INSERT INTO PAIDOUT(OUTLETCODE,VOCHERNUMBER,AUTHORIZATIONS,AMOUNT,PARTICULAR,INSERT_BY,INSERT_DATE,PAY_TYPE)VALUES(@OUTLETCODE,@VOCHERNUMBER,@AUTHORIZATIONS,@AMOUNT,@PARTICULAR,@INSERT_BY,@INSERT_DATE,@PAYTYPE)";
            DbFunctions.ExecuteCommand<int>(S, list);
        }
        public void INSERT1()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@OUTLETCODE", OUTLETCODE);
            list.AddSqlParameter("@PAIDOUTS", PAIDOUTS);
            list.AddSqlParameter("@OPENINGBLANCE", OPENINGBLANCE);
            list.AddSqlParameter("@VOCHERNUMBER", VOCHERNUMBER);
            list.AddSqlParameter("@AUTHORIZATIONS", AUTHORIZATIONS);
            list.AddSqlParameter("@AMOUNT", AMOUNT);
            list.AddSqlParameter("@PARTICULAR", PARTICULAR);
            list.AddSqlParameter("@STATUS", STATUS);
            list.AddSqlParameter("@AMOUNT_TYPE", AMOUNT_TYPE);
            // USER INSERT SRI INSERTBY
            //list.AddSqlParameter("@USER_NAME", USER_NAME);
            INSERT_BY = login.u;
            INSERT_DATE = DateTime.Today;
            list.AddSqlParameter("@INSERT_BY", INSERT_BY);
            list.AddSqlParameter("@INSERT_DATE", INSERT_DATE);
            //USER_NAME = login.u;
            string SS = "INSERT INTO PAIDOUT_OPENINGBALANCE(OUTLETCODE,VOCHERNUMBER,AUTHORIZATIONS,AMOUNT,PARTICULAR,STATUS,AMOUNT_TYPE,INSERT_BY,INSERT_DATE)VALUES(@OUTLETCODE,@VOCHERNUMBER,@AUTHORIZATIONS,@AMOUNT,@PARTICULAR,'MANUAL',@AMOUNT_TYPE,@INSERT_BY,@INSERT_DATE)";
            DbFunctions.ExecuteCommand<int>(SS, list);
        }
        public int id()
        {
            int a = 0;
            string S = "SELECT MAX(PAIDOUT) FROM PAIDOUT";
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
        public int getid1()
        {
            int a = 0;
            string S = "SELECT MAX(VOCHERNUMBER) FROM PAIDOUT_OPENINGBALANCE";
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
