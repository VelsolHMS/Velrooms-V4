using DAL;
using HMS.View.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.View.Operations;

namespace HMS.Model.Operations
{
    public class Pendingbill
    {
        public string BILL_DATE { get; set; }
        public string BILL_NO { get; set; }
        public string Registration_No { get; set; }
        public string ROOM_NO { get; set; }
        public string GUEST_NAME { get; set; }
        public string COMPANY_CODE { get; set; }
        public string COMPANY_NAME { get; set; }
        public string Amount_Recevied { get; set; }
        public string PENDING_AMOUNT { get; set; }
        public string BALANCE_AMOUNT { get; set; }
        public string ADVANCE { get; set; }
        public string PAYMENT_TYPE { get; set; }
        public string PENDING_PAY_TYPE { get; set; }
        public string REMARKS { get; set; }
        //public string USER_NAME { get; set; }
        public string INSERT_BY { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public void INSERT()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@Bill_Date", BILL_DATE);
            list.AddSqlParameter("@Bill_No", BILL_NO);
            list.AddSqlParameter("@Registraion_No", Registration_No);
            list.AddSqlParameter("@Room_No", ROOM_NO);
            list.AddSqlParameter("@Guest_Name", GUEST_NAME);
            list.AddSqlParameter("@Company_Code", COMPANY_CODE);
            list.AddSqlParameter("@Company_Name", COMPANY_NAME);
            list.AddSqlParameter("@Amount_Recevied", Amount_Recevied);
            list.AddSqlParameter("@Pending_Amount", PENDING_AMOUNT);
            list.AddSqlParameter("@Balance_Amount", BALANCE_AMOUNT);
            list.AddSqlParameter("@Payment_Type", PAYMENT_TYPE);
            list.AddSqlParameter("@pending_Pay_Type", PENDING_PAY_TYPE);
            list.AddSqlParameter("@Remarks", REMARKS);
            //  list.AddSqlParameter("@User_Name", USER_NAME);
            INSERT_BY = login.u;
            INSERT_DATE = DateTime.Today;
            list.AddSqlParameter("@Insert_By", INSERT_BY);
            list.AddSqlParameter("@Insert_Date", INSERT_DATE);
            //USER_NAME = login.u;
            //list.AddSqlParameter("")
            string s = "insert into PENDINGBILL (Bill_Date,Bill_No,Registraion_No,Room_No,Guest_Name,Company_Code,Company_Name,Amount_Recevied,Pending_Amount,Balance_Amount,Payment_Type,pending_Pay_Type,Remarks,Insert_By,Insert_Date) values(@BILL_DATE,@BILL_NO,@Registraion_No,@ROOM_NO,@GUEST_NAME,@COMPANY_CODE,@COMPANY_NAME,@Amount_Recevied,@PENDING_AMOUNT,@BALANCE_AMOUNT,@PAYMENT_TYPE,@PENDING_PAY_TYPE,@REMARKS,@INSERT_BY,@INSERT_DATE)";
            DbFunctions.ExecuteCommand<int>(s, list);
        }
        public void balance_update()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@balance", BALANCE_AMOUNT);
            list.AddSqlParameter("@bill", BILL_NO);
            list.AddSqlParameter("@paid", Amount_Recevied);
            decimal blnc = Convert.ToDecimal(BALANCE_AMOUNT);
            decimal pd = Convert.ToDecimal(Amount_Recevied);
            decimal ttlam = blnc+pd;
            list.AddSqlParameter("@ttl",ttlam );
            string s = "UPDATE SETTLE_OTHERPAY SET AMOUNT=@ttl,BALANCE = @balance,ADVANCE=@paid WHERE BILL_NO = @bill";
            DbFunctions.ExecuteCommand<int>(s, list);
        }
        public void status_update()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@bill", BILL_NO);
            string s = "UPDATE SETTLE_OTHERPAY SET STATUS = 'Settled' WHERE BILL_NO = @bill";
            DbFunctions.ExecuteCommand<int>(s, list);
        }
        public DataTable get()
        {
            var list = new List<SqlParameter>();
            string ss = "select BILL_NO,CONVERT(decimal(17,2),BALANCE_AMOUNT) AS BALANCE_AMOUNT from SETTLE WHERE COMPANY_NAME ='" + COMPANY_NAME + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(ss, list);
            if (dt.Rows.Count == 0)
            {
                BILL_NO = "";
                PENDING_AMOUNT = "";
            }
            else
            {
                BILL_NO = dt.Rows[0]["BILL_NO"].ToString();
                PENDING_AMOUNT = dt.Rows[0]["BALANCE_AMOUNT"].ToString();
            }
            return dt;

        }
        public void insert1()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@Company_Name", COMPANY_NAME);
            list.AddSqlParameter("@Pending_Amount", PENDING_AMOUNT);
            list.AddSqlParameter("@Amount_Recevied", Amount_Recevied);
            list.AddSqlParameter("@Balance_Amount", BALANCE_AMOUNT);
            list.AddSqlParameter("@Payment_Type", PAYMENT_TYPE);
            list.AddSqlParameter("@pending_Pay_Type", PENDING_PAY_TYPE);
            list.AddSqlParameter("@Remarks", REMARKS);
            //list.AddSqlParameter("@User_Name", USER_NAME);
            INSERT_BY = login.u;
            INSERT_DATE = DateTime.Today;
            list.AddSqlParameter("@Insert_By", INSERT_BY);
            list.AddSqlParameter("@Insert_Date", INSERT_DATE);
            //USER_NAME = login.u;

            string s = "insert into PENDINGBILL(Company_Name,Pending_Amount,Amount_Recevied,Balance_Amount,Payment_Type,pending_Pay_Type,Remarks,Insert_By,Insert_Date)values(@COMPANY_NAME,@PENDING_AMOUNT,@Amount_Recevied,@BALANCE_AMOUNT,@PAYMENT_TYPE,@PENDING_PAY_TYPE,@REMARKS,@INSERT_BY,@INSERT_DATE)";
            DbFunctions.ExecuteCommand<int>(s, list);
        }
    }
}
