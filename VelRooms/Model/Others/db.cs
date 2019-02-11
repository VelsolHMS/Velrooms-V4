using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.mainwindowpages;
using DAL;


namespace HMS.Model.Others
{
  public  class db
    {

        public decimal advtotal,porctotal,tartotal;
        public Decimal value;

        //Method to get the sum of advance 
        public DataTable Todaysale()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT CONVERT(decimal(17,2),SUM(AMOUNT_RECEIVED)) AS AMOUNT_RECEIVED,(SELECT CONVERT(decimal(17,2),SUM(TOTAL_AMOUNT)) FROM POSTCHARGES WHERE INSERT_DATE=CAST(GETDATE() AS date)) AS POSTCHARGES,(SELECT CONVERT(decimal(17,2),SUM(AMOUNT)) FROM PAIDOUT WHERE INSERT_DATE=CAST(GETDATE() AS date)) AS PAIDOUT,(SELECT CONVERT(decimal(17,2),SUM(AMOUNT)) FROM REFUND WHERE INSERT_DATE=CAST(GETDATE() AS date)) AS REFUND FROM ADVANCE  WHERE INSERT_DATE=CAST(GETDATE() AS date)";
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return DT;
        }
        public DataTable advance()
        {
            var list = new List<SqlParameter>();
            string s = "select CONVERT(decimal(17,2),sum(Amount_Received)) AS Total_Adv from ADVANCE where INSERT_DATE=cast(GETDATE()as date)";
            DataTable adv_count = DbFunctions.ExecuteCommand<DataTable>(s, list);
            decimal.TryParse(adv_count.Rows[0]["Total_Adv"].ToString(), out advtotal);
            return adv_count;
          
        }
        public DataTable Charged()
        {
            var list = new List<SqlParameter>();
            string s = "select CONVERT(decimal(17,2),sum(TOTAL_AMOUNT)) as Total_Charge from POSTCHARGES where INSERT_DATE=cast(GETDATE()as date)";
            DataTable por_Count = DbFunctions.ExecuteCommand<DataTable>(s, list);
            decimal.TryParse(por_Count.Rows[0]["Total_Charge"].ToString(), out porctotal);
            return por_Count;
        }

        public DataTable Tariff()
        {
            var list = new List<SqlParameter>();
            string s = "select CONVERT(decimal(17,2),sum(Room_Tarrif)) as Total_Tariff from night_audit where NIGHT=0 and INSERT_DATE=cast(GETDATE()as date)";
            DataTable tar_Count = DbFunctions.ExecuteCommand<DataTable>(s, list);
            decimal.TryParse(tar_Count.Rows[0]["Total_Tariff"].ToString(), out tartotal);
            return tar_Count;
        }
        public DataTable CHECKINS()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT ROOM_NO,FIRSTNAME,(SELECT(CONVERT(NVARCHAR,ARRIVAL_DATE,103))) AS ARRIVAL_DATE,"+
                "(SELECT(CONVERT(NVARCHAR, DEPARTURE_DATE, 103))) AS DEPARTURE_DATE,(DATEDIFF(d,ARRIVAL_DATE,DEPARTURE_DATE)) AS STAY_DAYS,"+
                "(SELECT CONVERT(decimal(17, 2), TOTAL_AMOUNT) FROM POSTCHARGES WHERE ROOM_NO=A.ROOM_NO AND CHECKIN_ID=A.CHECKIN_ID AND POSTCHARGES=0 AND INSERT_DATE=CAST(GETDATE() AS DATE)) AS POSTCHARGES," +
                "(SELECT CONVERT(decimal(17, 2), CHARGED_TARRIF)) AS CHARGED_TARRIF,"+
                "(SELECT CONVERT(decimal(17, 2), SUM(AMOUNT_RECEIVED)) FROM ADVANCE B WHERE ROOM_NO = A.ROOM_NO AND ADVANCE = 0 AND INSERT_DATE = cast(GETDATE() as date) AND CHECKIN_ID IN "+
                "(SELECT CHECKIN_ID FROM CHECKIN WHERE ROOM_NO = A.ROOM_NO AND INSERT_DATE = cast(GETDATE() as date))) AS AMOUNT_RECEIVED,(CHARGED_TARRIF - (SELECT CONVERT(decimal(17, 2), SUM(AMOUNT_RECEIVED)) FROM"+
                " ADVANCE B WHERE ROOM_NO = A.ROOM_NO AND ADVANCE = 0 AND INSERT_DATE = cast(GETDATE() as date) AND CHECKIN_ID IN (SELECT CHECKIN_ID FROM CHECKIN WHERE ROOM_NO = A.ROOM_NO AND ARRIVAL_DATE = cast(GETDATE() as date)))) AS "+
                " BALANCEAMOUNT FROM CHECKIN A WHERE CHECK_OUT = 0 AND INSERT_DATE = cast(GETDATE() as date)";
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return DT;
        }

        public DataTable CHECKOUTS()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT ROOM_NO,FIRSTNAME,MOBILE_NO FROM CHECKIN WHERE CHECK_OUT=0 AND DEPARTURE_DATE=CAST(GETDATE() as date) AND ARRIVAL_TIME BETWEEN '"+DB.time+"' AND DATEADD(HOUR,5,getdate())";
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return DT;
        }
        public DataTable RESERV()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT RESERVATION_ID,FIRSTNAME,MOBILE_NO FROM RESERVATION WHERE ARRIVAL_DATE=CAST(GETDATE() AS DATE) AND ARRIVAL_TIME BETWEEN '" + DB.time + "' AND DATEADD(HOUR,5,getdate())";
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return DT;
        }

        public DataTable RESERVCHECKOUT()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT ROOM_NO,FIRSTNAME,MOBILE_NO FROM CHECKIN WHERE CHECK_OUT=0 AND DEPARTURE_DATE=CAST(GETDATE() as date) AND ARRIVAL_TIME BETWEEN '"+DB.time+"' AND DATEADD(HOUR,5,getdate()) UNION ALL SELECT RESERVATION_ID, FIRSTNAME, MOBILE_NO FROM RESERVATION WHERE ARRIVAL_DATE = CAST(GETDATE() AS DATE) AND ARRIVAL_TIME BETWEEN '"+DB.time+"' AND DATEADD(HOUR,5,getdate())";
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return DT;
        }
        public DataTable ROOMCAT()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT DISTINCT A.ROOM_CATEGORY,(SELECT COUNT(ROOM_CATEGORY) FROM ROOMMASTER  WHERE ROOM_CATEGORY=A.ROOM_CATEGORY) AS COUNT FROM ROOMCATEGORY A WHERE ROOM_CATEGORY=A.ROOM_CATEGORY";
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return DT;
        }
    }
}
