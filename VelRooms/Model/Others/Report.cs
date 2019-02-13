using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Model;
using HMS.Reports;

namespace HMS.Model.Others
{
    class Report
    {
        public string Fmdate, Todate;
        public DataTable guestdetails()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT DISTINCT ARRIVAL_DATE,FIRSTNAME,MOBILE_NO,EMAIL FROM CHECKIN WHERE INSERT_DATE BETWEEN '" + Fmdate + "' AND '" + Todate + "' ";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public static string Name, Address1, Gst;
        public static string Hotel, HotelAddress,GST;
        public DataTable Address()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT NAME,(SELECT CONCAT(PLOT_NO, ',', LANDMARK, ',', CITY, ',', STATE, ' - ', PINCODE, '.') FROM HotelInfo) AS ADDRESS,GST FROM HotelInfo";
            DataTable D = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (D.Rows.Count == 0)
            {

            }
            else
            {
                Name = D.Rows[0]["NAME"].ToString();
                Address1 = D.Rows[0]["ADDRESS"].ToString();
                Gst = D.Rows[0]["GST"].ToString();
            }
            return D;
        }
        public DataTable monthwisetax()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT distinct ROOM_NO,FIRSTNAME,MOBILE_NO,DATEDIFF(day, ARRIVAL_DATE, DEPARTURE_DATE) AS STAY_DAYS,ROOM_CATEGORY,(CHARGED_TARRIF+CHARGED_EBED_ADULT+CHARGED_EBED_CHILD)AS ROOM_TARRIF, TAX FROM CHECKIN WHERE INSERT_DATE BETWEEN '"+MonthWiseTaxReport.fd+ "' AND '" + MonthWiseTaxReport.td + "'";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public DataTable monthwisegst()
        {
            var list = new List<SqlParameter>();
            string s = "select INSERT_DATE,convert(decimal(17,2),sum(ROOM_TARRIF))as ROOM_TARRIF,CONCAT(GST,' % ')AS TAX,GST,Convert(decimal(17,2),(sum(ROOM_TARRIF)*GST/100))AS TOTALGST from night_audit where INSERT_DATE between '" + FromDate + "' and '" + ToDate + "' group by INSERT_DATE , GST ORDER BY INSERT_DATE ASC";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public DataTable TOTALGST()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT convert(decimal(17,2),SUM(ROOM_TARRIF))as ROOM_TARRIF,GST,(sum(ROOM_TARRIF)*GST/100)AS TOTALGST FROM night_audit where INSERT_DATE between '" + FromDate + "' and '" + ToDate + "' GROUP BY GST ORDER BY GST ASC";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public DataTable taxcode()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT TAX_CODE FROM TAX_CODE ORDER BY FACTOR ASC";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        
        public DataTable outbalcmpwise()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT COMPANY_CODE, COMPANY_NAME,(CAST(PLOT_NO AS VARCHAR(20)) + ' ,' + LANDMARK + ' ,' + CITY + ' , ' + STATE + ' - ' + CAST(PINCODE AS VARCHAR(20))) AS COMPANYADDRESS,(SELECT Pending_Amount from PENDINGBILL where Company_Name = COMPANYMASTER.COMPANY_NAME AND Pending_Amount != null OR Pending_Amount != 0) AS PENDINGAMOUNT,(SELECT Remarks from PENDINGBILL where Company_Name = COMPANYMASTER.COMPANY_NAME AND Pending_Amount != null OR Pending_Amount != 0)AS REMARKS FROM COMPANYMASTER WHERE INSERT_DATE = '" + SelectedDate + "'";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public DataTable advtranslist()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT DISTINCT ROOM_NO, RESERVATION_ID, CHECKIN_ID, convert(decimal(17,2),AMOUNT_RECEIVED) AS AMOUNT_RECEIVED,PAYTYPE,PARTICULARS,INSERT_BY,(SELECT FIRSTNAME FROM CHECKIN WHERE CHECKIN_ID = AD.CHECKIN_ID) AS GUEST_NAME FROM ADVANCE AD WHERE INSERT_DATE='" + SelectedDate+ "'AND AMOUNT_RECEIVED!=0";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public DataTable pctranslist()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT DISTINCT ROOM_NO,convert(decimal(17,2),TOTAL_AMOUNT) AS TOTAL_AMOUNT,GUEST_NAME,PARTICULARS,INSERT_BY FROM POSTCHARGES WHERE INSERT_DATE = '" + SelectedDate+"'";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public DataTable disctranslist()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT DISTINCT ROOM_NO,RESERVATION_NO,GUEST_NAME,convert(decimal(17,2),AMOUNT) AS AMOUNT,PARTICULAR,INSERT_BY FROM DISCOUNT D WHERE INSERT_DATE='" + SelectedDate + "'";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public DataTable refundtranslist()
        {
            var list = new List<SqlParameter>();
            //string s = "SELECT DISTINCT ROOM_NO,TAX,(SELECT convert(decimal(17,2),AMOUNT_RECEIVED) FROM ADVANCE WHERE CHECKIN_ID = CO.CHECKIN_ID)as ADVANCE,(SELECT RESERVATION_ID FROM CHECKIN WHERE CHECKIN_ID=CO.CHECKIN_ID AND ROOM_NO=CO.ROOM_NO) AS RESERVATION_NO,FIRSTNAME,(SELECT convert(decimal(17,2),SUM(ROOM_TARRIF)) FROM night_audit WHERE NIGHT = 0 AND ROOM_NO = CO.ROOM_NO) AS ROOM_TARRIF ,INSERT_BY FROM CHECKIN CO WHERE DEPARTURE_DATE='" + SelectedDate + "' AND CHECK_OUT =0";
            string s = "SELECT DISTINCT ROOM_NO,RESERVATION_ID,GUEST_NAME,convert(decimal(17,2),BALANCE_AMOUNT) AS BALANCE_AMOUNT,REASON,INSERT_BY FROM REFUND RF WHERE INSERT_DATE = '" + SelectedDate + "'";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public DataTable couttranslist()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT ROOM_NO,GUEST_NAME,BALANCE_AMOUNT,INSERT_BY,PAYMENT_MODE from SETTLE where INSERT_DATE = '" + SelectedDate + "'";
            //string s = "SELECT DISTINCT ROOM_NO,GUEST_NAME,BALANCE,INSERT_BY FROM CHECKOUT CO WHERE INSERT_DATE ='" + SelectedDate + "'";
            //string s = "SELECT DISTINCT ROOM_NO,ADVANCE ,GUEST_NAME ,BALANCE ,INSERT_BY FROM CHECKOUT CO WHERE DEPARTURE_DATE='" + SelectedDate + "'";
            //string s = "SELECT DISTINCT ROOM_NO,TAX,(SELECT convert(decimal(17,2),AMOUNT_RECEIVED) FROM ADVANCE WHERE CHECKIN_ID = CO.CHECKIN_ID)as ADVANCE,(SELECT RESERVATION_ID FROM CHECKIN WHERE CHECKIN_ID=CO.CHECKIN_ID AND ROOM_NO=CO.ROOM_NO) AS RESERVATION_NO,FIRSTNAME,(SELECT convert(decimal(17,2),SUM(ROOM_TARRIF)) FROM night_audit WHERE NIGHT = 0 AND ROOM_NO = CO.ROOM_NO) AS ROOM_TARRIF ,INSERT_BY FROM CHECKIN CO WHERE INSERT_DATE='" + SelectedDate + "' AND CHECK_OUT =0";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public string SelectedDate { get; set; }
        public string OB_Date { get; set; }
        public string OB_Date1 { get; set; }
        public DataTable RoomOccupency1()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT NAME AS Hotel,GST AS GST,(SELECT CONCAT(PLOT_NO,',',LANDMARK,',',CITY,',',STATE,' - ',PINCODE,'.') FROM HotelInfo) AS HotelAddress FROM HotelInfo";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {

            }
            else
            {
                Hotel = dt.Rows[0]["Hotel"].ToString();
                HotelAddress = dt.Rows[0]["HotelAddress"].ToString();
                GST = dt.Rows[0]["GST"].ToString();
            }
            return dt;
        }
        public string RoomOCCfromdate { get; set; }
        public string RoomOCCtodate { get; set; }

        public DataTable RoomOccupency2()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT distinct(CHECKIN.ROOM_CATEGORY) AS Category, ROOMMASTER.ROOM_NO As Roomno,(select distinct(COUNT(ROOM_NO)) from CHECKIN where CHECKIN.ROOM_CATEGORY = ROOMMASTER.ROOM_CATEGORY AND CHECKIN.ROOM_NO = ROOMMASTER.ROOM_NO AND CHECKIN.INSERT_DATE BETWEEN '" + RoomOCCfromdate + "' AND '" + RoomOCCtodate + "') As Count" +
                " FROM CHECKIN INNER JOIN ROOMMASTER ON CHECKIN.ROOM_CATEGORY = ROOMMASTER.ROOM_CATEGORY AND CHECKIN.ROOM_NO = ROOMMASTER.ROOM_NO AND CHECKIN.INSERT_DATE BETWEEN '" + RoomOCCfromdate + "' AND '" + RoomOCCtodate + "' ORDER BY CHECKIN.ROOM_CATEGORY";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public string ReservDate { get; set; }
        public DataTable Reservlist1()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT NAME AS Hotel,GST AS GST,(SELECT CONCAT(PLOT_NO,',',LANDMARK,',',CITY,',',STATE,' - ',PINCODE,'.') FROM HotelInfo) AS HotelAddress FROM HotelInfo";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {

            }
            else
            {
                Hotel = dt.Rows[0]["Hotel"].ToString();
                HotelAddress = dt.Rows[0]["HotelAddress"].ToString();
                GST = dt.Rows[0]["GST"].ToString();
            }
            return dt;
        }
        public DataTable Reservlist2()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT CONVERT(INT,RESERVATION_ID) AS RESERVATION_ID,FIRSTNAME,MOBILE_NO,CONCAT(ID_DATA,'(',ID_TYPE,')') AS ID,CONVERT(INT,DAYS) AS DAYS,"+
                "CONCAT(CONVERT(VARCHAR(10), ARRIVAL_DATE, 103), '  ', CONVERT(VARCHAR(15), CAST(ARRIVAL_TIME AS VARCHAR), 100)) AS ARRIVAL,NO_OF_ROOMS, PAX, "+
                "CONVERT(VARCHAR(10), DEPARTURE_DATE, 103) AS DEPARTURE, INSERT_BY from RESERVATION WHERE INSERT_DATE = '"+ReservDate+"'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable Cancelreservation1()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT NAME AS Hotel,GST AS GST,(SELECT CONCAT(PLOT_NO,',',LANDMARK,',',CITY,',',STATE,' - ',PINCODE,'.') FROM HotelInfo) AS HotelAddress FROM HotelInfo";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {

            }
            else
            {
                Hotel = dt.Rows[0]["Hotel"].ToString();
                HotelAddress = dt.Rows[0]["HotelAddress"].ToString();
                GST = dt.Rows[0]["GST"].ToString();
            }
            return dt;
        }
        public string Canceldate { get; set; }
        public DataTable Cancelreservation2()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT CANCEL_ID,RESERVATION_ID,GUESTNAME,MOBILE_NO,(SELECT INSERT_DATE FROM RESERVATION WHERE STATUS = 'CANCLED' AND RESERVATION_ID = A.RESERVATION_ID) AS INSERT_DATE, INSERT_BY FROM RESERVATIONCANCEL A WHERE INSERT_DATE  = '" + Canceldate+"'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable Daywiseadvance1()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT NAME AS Hotel,GST AS GST,(SELECT CONCAT(PLOT_NO,',',LANDMARK,',',CITY,',',STATE,' - ',PINCODE,'.') FROM HotelInfo) AS HotelAddress FROM HotelInfo";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {

            }
            else
            {
                Hotel = dt.Rows[0]["Hotel"].ToString();
                HotelAddress = dt.Rows[0]["HotelAddress"].ToString();
                GST = dt.Rows[0]["GST"].ToString();
            }
            return dt;
        }
        public string DayWiseAdvanceDate { get; set; }
        public DataTable Daywiseadvance2()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT ROOM_NO,FIRSTNAME,MOBILE_NO,CONCAT(ID_DATA, '(', ID_TYPE, ')') AS ID,"+
                "(SELECT ROOM_NO FROM ADVANCE WHERE ADVANCE = 0 AND CHECKIN_ID = A.CHECKIN_ID AND INSERT_DATE = '"+DayWiseAdvanceDate+"') AS ROOM,"+
                "(SELECT RESERVATION_ID FROM ADVANCE WHERE ADVANCE = 0 AND CHECKIN_ID = A.CHECKIN_ID AND INSERT_DATE = '"+DayWiseAdvanceDate+"') AS RESERV,"+
                "(SELECT INSERT_BY FROM ADVANCE WHERE ADVANCE = 0 AND CHECKIN_ID = A.CHECKIN_ID AND INSERT_DATE = '"+DayWiseAdvanceDate+"') AS INSERT_BY,"+
                "(SELECT SUM(AMOUNT_RECEIVED) FROM ADVANCE WHERE ROOM_NO = A.ROOM_NO AND ADVANCE.ADVANCE = 0 AND CHECKIN_ID = A.CHECKIN_ID AND ADVANCE.INSERT_DATE = '"+DayWiseAdvanceDate+"') "+
                "AS AMOUNT_RECEIVED FROM CHECKIN A WHERE CHECK_OUT = 0 AND INSERT_DATE IN(SELECT INSERT_DATE FROM ADVANCE WHERE INSERT_DATE = '"+DayWiseAdvanceDate+"')";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable Daywisereservationadvance()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT RESERVATION_ID,FIRSTNAME,MOBILE_NO,ID_DATA+''+ID_TYPE AS ID,(SELECT AMOUNT_RECEIVED FROM ADVANCE WHERE RESERVATION_ID = A.RESERVATION_ID) AS AMOUNT_RECEIVED, INSERT_BY FROM RESERVATION A WHERE RESERVATION = 0 AND INSERT_DATE = '"+DayWiseAdvanceDate+"'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public string RES { get; set; }
         public string ROOM { get; set; }
        public DataTable DAY1()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT RESERVATION_ID,ROOM_NO,AMOUNT_RECEIVED,INSERT_BY FROM ADVANCE WHERE INSERT_DATE='"+DayWiseAdvanceDate+"' AND AMOUNT_RECEIVED>0.00 AND ADVANCE=0";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable DAY2()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT RESERVATION_ID,FIRSTNAME,MOBILE_NO,ID_DATA+''+ID_TYPE AS ID,(SELECT AMOUNT_RECEIVED FROM ADVANCE WHERE RESERVATION_ID = A.RESERVATION_ID) AS AMOUNT_RECEIVED, INSERT_BY FROM RESERVATION A WHERE INSERT_DATE = '"+DayWiseAdvanceDate+"' AND RESERVATION_ID='"+RES+"'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable DAY3()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT ROOM_NO,FIRSTNAME,MOBILE_NO,CONCAT(ID_DATA,'(',ID_TYPE,')') AS ID,(SELECT SUM(AMOUNT_RECEIVED) FROM ADVANCE WHERE ROOM_NO = A.ROOM_NO AND ADVANCE.ADVANCE = 0 AND CHECKIN_ID = A.CHECKIN_ID AND ADVANCE.INSERT_DATE = '"+DayWiseAdvanceDate+"') AS AMOUNT_RECEIVED,"+
                "(SELECT INSERT_BY FROM ADVANCE WHERE ADVANCE = 0 AND CHECKIN_ID = A.CHECKIN_ID AND INSERT_DATE = '"+DayWiseAdvanceDate+"') AS INSERT_BY FROM CHECKIN A WHERE  CHECK_OUT = 0 AND ROOM_NO='"+ROOM+"'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable TodayBookings1()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT NAME AS Hotel,GST AS GST,(SELECT CONCAT(PLOT_NO,',',LANDMARK,',',CITY,',',STATE,' - ',PINCODE,'.') FROM HotelInfo) AS HotelAddress FROM HotelInfo";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {

            }
            else
            {
                Hotel = dt.Rows[0]["Hotel"].ToString();
                HotelAddress = dt.Rows[0]["HotelAddress"].ToString();
                GST = dt.Rows[0]["GST"].ToString();
            }
            return dt;
        }
        public DataTable TodayBookings2()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT RESERVATION_ID,FIRSTNAME,MOBILE_NO,CONCAT(CONVERT(VARCHAR(10), ARRIVAL_DATE, 103), '  ', CONVERT(VARCHAR(15), CAST(ARRIVAL_TIME AS VARCHAR), 100)) AS ARRIVAL,"+
                " NO_OF_ROOMS, PAX, DAYS,(SELECT AMOUNT_RECEIVED FROM ADVANCE where RESERVATION_ID = RESERVATION.RESERVATION_ID ) AS ADVANCEGIVEN,INSERT_BY FROM RESERVATION WHERE INSERT_DATE = CAST(GETDATE() AS DATE)";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable MonthWiseDiscount1()
        {
            var list = new List<SqlParameter>();
            string s = " SELECT NAME AS Hotel,GST AS GST,(SELECT CONCAT(PLOT_NO,',',LANDMARK,',',CITY,',',STATE,' - ',PINCODE,'.') FROM HotelInfo) AS HotelAddress,(SELECT SUM(AMOUNT) FROM DISCOUNT WHERE INSERT_DATE BETWEEN '"+MWDFromDate+"' AND '"+MWDToDate+"') AS TOTAL  FROM HotelInfo";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {

            }
            else
            {
                Hotel = dt.Rows[0]["Hotel"].ToString();
                HotelAddress = dt.Rows[0]["HotelAddress"].ToString();
                GST = dt.Rows[0]["GST"].ToString();
            }
            return dt;
        }
        public DataTable MWDGrandTotal()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT SUM(AMOUNT) AS TOTAL FROM DISCOUNT WHERE INSERT_DATE BETWEEN '"+MWDFromDate+"' AND '"+MWDToDate+"'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public string MWDFromDate { get; set; }
        public string MWDToDate { get; set; }
        public DataTable MonthWiseDiscount2()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT INSERT_DATE,SUM(AMOUNT) AS AMOUNT FROM DISCOUNT WHERE INSERT_DATE BETWEEN '"+MWDFromDate+"' AND '"+MWDToDate+"' GROUP BY INSERT_DATE";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable RoomTarrif1()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT NAME AS Hotel,GST AS GST,(SELECT CONCAT(PLOT_NO,',',LANDMARK,',',CITY,',',STATE,' - ',PINCODE,'.') FROM HotelInfo) AS HotelAddress FROM HotelInfo";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {

            }
            else
            {
                Hotel = dt.Rows[0]["Hotel"].ToString();
                HotelAddress = dt.Rows[0]["HotelAddress"].ToString();
                GST = dt.Rows[0]["GST"].ToString();
            }
            return dt;
        }
        
        public string Roomtype { get; set; }
        public DataTable RoomTarrif2()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT DISTINCT ROOM_CATEGORY,ROOM_NO,SINGLERATE_TARRIF,DOUBLERATE_TARRIF,TRIPLERATE_TARRIF,QUADRATE_TARRIF,EXTRABED_ADULT,EXTRABED_CHILD FROM ROOMMASTER";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable PlanWiseRoomTarrif()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT DISTINCT PLAN_CODE, ROOM_NO, SINGLE_PLAN,DOUBLE_PLAN,TRIPLE_PLAN,QUAD_PLAN,(SELECT ROOM_CATEGORY FROM ROOMMASTER WHERE ROOM_NO = A.ROOM_NO) AS ROOM_CATEGORY FROM ROOMMASTER_PLAN A WHERE PLAN_CODE!=''";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public string forentofficedate;
        public DataTable forentofficeadavance()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT DISTINCT CONVERT(varchar(103),INSERT_DATE) AS DATE,RESERVATION_ID," +
                        "(SELECT ARRIVAL_TIME FROM CHECKIN WHERE CHECKIN_ID = A.CHECKIN_ID) AS TIME,(SELECT BILL_NO FROM PRINTSTATUS WHERE CHECKIN_ID=A.CHECKIN_ID) AS BILL," +
                        " ROOM_NO,(SELECT FIRSTNAME FROM CHECKIN WHERE CHECKIN_ID = A.CHECKIN_ID) AS GUESTNAME," +
                        " PAYTYPE,convert(decimal(17,2),AMOUNT_RECEIVED) AS AMOUNT_RECEIVED, INSERT_BY FROM ADVANCE A WHERE INSERT_DATE = '" + forentofficedate + "' and ADVANCE=1 ";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public static decimal Cash, card, cheque;
        public DataTable advancecash()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT convert(decimal(17,2),Sum(AMOUNT_RECEIVED)) AS Cash FROM ADVANCE WHERE PAYTYPE='Cash' And INSERT_DATE='" + forentofficedate + "' and ADVANCE=1";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {
                Cash = Convert.ToDecimal(0.00);
            }
            else
            {
                if (dt.Rows[0]["Cash"].ToString() == "") { }
                else
                {
                    Cash = Convert.ToDecimal(dt.Rows[0]["Cash"]);
                }
            }
            return dt;
        }
        public DataTable advancecard()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT CONVERT(decimal(17,2),SUM(AMOUNT_RECEIVED)) AS Card  FROM ADVANCE WHERE PAYTYPE='Card' And INSERT_DATE='" + forentofficedate + "' And ADVANCE=1";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {
                card = Convert.ToDecimal(0.00);
            }
            else
            {
                if (dt.Rows[0]["Card"].ToString() == "")
                {
                    card = Convert.ToDecimal(0.00);
                }
                else
                {
                    card = Convert.ToDecimal(dt.Rows[0]["Card"]);
                }

            }
            return dt;
        }
        public DataTable advancecheque()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT convert(decimal(17,2),Sum(AMOUNT_RECEIVED)) AS Cheque FROM ADVANCE WHERE PAYTYPE='Cheque' And INSERT_DATE='" + forentofficedate + "' ";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {
                cheque = Convert.ToDecimal(0.00);
            }
            else
            {
                if (dt.Rows[0]["Cheque"].ToString() == "")
                {
                    cheque = Convert.ToDecimal(0.00);
                }
                else
                {
                    cheque = Convert.ToDecimal(dt.Rows[0]["Cheque"]);
                }
            }
            return dt;
        }

        public DataTable froentsettle()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT AB.BILL_NO,AB.CHECKIN_ID,AB.DATE,AB.ROOM_NO,(SELECT RESERVATION_ID FROM CHECKIN WHERE CHECKIN_ID = AB.CHECKIN_ID) AS RES_NO,(SELECT ARRIVAL_TIME FROM CHECKIN WHERE CHECKIN_ID = AB.CHECKIN_ID) AS TIME, AB.GUEST_NAME,(SELECT PAYMENT_MODE FROM SETTLE WHERE BILL_NO = AB.BILL_NO) AS PAYMODE,(SELECT CONVERT(decimal(17,2),AMOUNT) FROM SETTLE WHERE BILL_NO = AB.BILL_NO) AS AMOUNT, AB.INSERT_BY FROM PRINTSTATUS AB WHERE AB.INSERT_DATE = '" + forentofficedate + "' AND AB.BILLSETTLE = 1";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }

        public static decimal c, cr, ch;
        public DataTable froentcash()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT CONVERT(decimal(17,2),sum(AMOUNT)) AS AMOUNT FROM SETTLE where INSERT_DATE='" + forentofficedate + "' AND PAYMENT_MODE='Cash'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {
                c = Convert.ToDecimal(0.00);
            }
            else
            {
                if (dt.Rows[0]["AMOUNT"].ToString() == "")
                {
                    c = Convert.ToDecimal(0.00);
                }
                else
                {
                    c = Convert.ToDecimal(dt.Rows[0]["AMOUNT"]);
                }
            }
            return dt;
        }
        public DataTable froentcard()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT CONVERT(decimal(17,2),sum(AMOUNT)) AS AMOUNT FROM SETTLE where INSERT_DATE='" + forentofficedate + "' AND PAYMENT_MODE='Card'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {
                cr = Convert.ToDecimal(0.00);
            }
            else
            {
                if (dt.Rows[0]["AMOUNT"].ToString() == "")
                {
                    cr = Convert.ToDecimal(0.00);
                }
                else
                {
                    cr = Convert.ToDecimal(dt.Rows[0]["AMOUNT"]);
                }
            }
            return dt;
        }
        public DataTable froentcheque()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT CONVERT(decimal(17,2),sum(AMOUNT)) AS AMOUNT FROM SETTLE where INSERT_DATE='" + forentofficedate + "' AND PAYMENT_MODE='Cheque'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {
                ch = Convert.ToDecimal(0.00);
            }
            else
            {
                if (dt.Rows[0]["AMOUNT"].ToString() == "")
                {
                    ch = Convert.ToDecimal(0.00);
                }
                else
                {
                    ch = Convert.ToDecimal(dt.Rows[0]["AMOUNT"]);
                }
            }
            return dt;
        }
        public static decimal openingbalance;
        public DataTable OPENING()
        {
            var list = new List<SqlParameter>();
            string s = "select CONVERT(DECIMAL(17,2),SUM(AMOUNT)) AS OPENINGBALANCE from PAIDOUT_OPENINGBALANCE WHERE INSERT_DATE='" + forentofficedate + "'";
            DataTable DS = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (DS.Rows.Count == 0)
            {
                openingbalance = Convert.ToDecimal(0.00);
            }
            else
            {
                if (DS.Rows[0]["OPENINGBALANCE"].ToString() == "")
                {
                    openingbalance = Convert.ToDecimal(0.00);
                }
                else
                {
                    openingbalance = Convert.ToDecimal(DS.Rows[0]["OPENINGBALANCE"]);
                }
            }
            return DS;
        }
        public static decimal adv;
        public DataTable advance()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT CONVERT(DECIMAL(17,2),SUM(AMOUNT_RECEIVED)) AS AMOUNT FROM ADVANCE WHERE ADVANCE=1 AND INSERT_DATE='" + forentofficedate + "' ";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (d.Rows.Count == 0)
            {
                adv = Convert.ToDecimal(0.00);
            }
            else
            {
                if (d.Rows[0]["AMOUNT"].ToString() == "")
                {
                    adv = Convert.ToDecimal(0.00);
                }
                else
                {
                    adv = Convert.ToDecimal(d.Rows[0]["AMOUNT"]);
                }
            }
            return d;
        }
        public static decimal ROOMCOLLECT;
        public DataTable Roomcollextion()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT CONVERT(decimal(17,2),sum(AMOUNT)) AS AMOUNT FROM SETTLE where INSERT_DATE='" + forentofficedate + "' ";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (d.Rows.Count == 0)
            {
                ROOMCOLLECT = Convert.ToDecimal(0.00);
            }
            else
            {
                if (d.Rows[0]["AMOUNT"].ToString() == "")
                {
                    ROOMCOLLECT = Convert.ToDecimal(0.00);
                }
                else
                {
                    ROOMCOLLECT = Convert.ToDecimal(d.Rows[0]["AMOUNT"]);
                }
            }
            return d;
        }
        public static decimal MISCELL;
        public DataTable Miscellenous()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT CONVERT(DECIMAL(17,2),SUM(TOTAL_AMOUNT)) AS MISAMOUNT FROM MISCELLENOUS where INSERT_DATE='" + forentofficedate + "'";
            DataTable dd = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dd.Rows.Count == 0)
            {
                MISCELL = Convert.ToDecimal(0.00);
            }
            else
            {
                if (dd.Rows[0]["MISAMOUNT"].ToString() == "")
                {
                    MISCELL = Convert.ToDecimal(0.00);
                }
                else
                {
                    MISCELL = Convert.ToDecimal(dd.Rows[0]["MISAMOUNT"]);
                }
            }
            return dd;
        }
        public static decimal PENDINGBILL;
        public DataTable pendingbill()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT CONVERT(decimal(17,2),sum(Balance_Amount)) as pending FROM PENDINGBILL WHERE Insert_Date='" + forentofficedate + "'";
            DataTable dd = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dd.Rows.Count == 0)
            {
                MISCELL = Convert.ToDecimal(0.00);
            }
            else
            {
                if (dd.Rows[0]["pending"].ToString() == "")
                {
                    MISCELL = Convert.ToDecimal(0.00);
                }
                else
                {
                    MISCELL = Convert.ToDecimal(dd.Rows[0]["pending"]);
                }

            }
            return dd;
        }
        public decimal SA, OB, AD, MA, PB;
        public static decimal totalcash1;
        public DataTable totalcash()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT CONVERT(decimal(17,2),sum(AMOUNT)) AS AMOUNT," +
  "(select CONVERT(DECIMAL(17, 2), SUM(AMOUNT))  from PAIDOUT_OPENINGBALANCE WHERE INSERT_DATE = '" + forentofficedate + "') AS OPENINGBALANCE," +
  "(SELECT CONVERT(DECIMAL(17, 2), SUM(AMOUNT_RECEIVED))  FROM ADVANCE WHERE INSERT_DATE = '" + forentofficedate + "' AND PAYTYPE ='Cash') AS AMOUNT1," +
  "(SELECT CONVERT(DECIMAL(17, 2), SUM(TOTAL_AMOUNT))  FROM MISCELLENOUS where INSERT_DATE = '" + forentofficedate + "' and PAYMENT_MODE ='Cash') AS MISAMOUNT," +
  "(SELECT CONVERT(decimal(17, 2), sum(Balance_Amount))  FROM PENDINGBILL WHERE Insert_Date = '" + forentofficedate + "' and Payment_Type ='Cash') as pending FROM SETTLE where PAYMENT_MODE = 'Cash' and INSERT_DATE = '" + forentofficedate + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {
                SA = Convert.ToDecimal(0.00);
                OB = Convert.ToDecimal(0.00);
                AD = Convert.ToDecimal(0.00);
                MA = Convert.ToDecimal(0.00);
                PB = Convert.ToDecimal(0.00);
            }
            else
            {
                if (dt.Rows[0]["AMOUNT"].ToString() == "")
                {
                    SA = Convert.ToDecimal(0.00);
                }
                else
                {
                    SA = Convert.ToDecimal(dt.Rows[0]["AMOUNT"]);
                }
                if (dt.Rows[0]["OPENINGBALANCE"].ToString() == "")
                {
                    OB = Convert.ToDecimal(0.00);
                }
                else
                {
                    OB = Convert.ToDecimal(dt.Rows[0]["OPENINGBALANCE"]);
                }
                if (dt.Rows[0]["AMOUNT1"].ToString() == "")
                {
                    AD = Convert.ToDecimal(0.00);
                }
                else
                {
                    AD = Convert.ToDecimal(dt.Rows[0]["AMOUNT1"]);
                }
                if (dt.Rows[0]["MISAMOUNT"].ToString() == "")
                {
                    MA = Convert.ToDecimal(0.00);
                }
                else
                {
                    MA = Convert.ToDecimal(dt.Rows[0]["MISAMOUNT"]);
                }
                if (dt.Rows[0]["pending"].ToString() == "")
                {
                    PB = Convert.ToDecimal(0.00);
                }
                else
                {
                    PB = Convert.ToDecimal(dt.Rows[0]["pending"]);
                }
                totalcash1 = SA + OB + AD + MA + PB;
            }
            return dt;
        }
        public decimal SA1, OB1, AD1, MA1, PB1;
        public static decimal totalcard1;
        public DataTable totalcard()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT CONVERT(decimal(17,2),sum(AMOUNT)) AS AMOUNT," +
"(select CONVERT(DECIMAL(17, 2), SUM(AMOUNT))  from PAIDOUT_OPENINGBALANCE WHERE INSERT_DATE = '" + forentofficedate + "') AS OPENINGBALANCE," +
    "(SELECT CONVERT(DECIMAL(17, 2), SUM(AMOUNT_RECEIVED))  FROM ADVANCE WHERE INSERT_DATE = '" + forentofficedate + "' AND PAYTYPE ='Card') AS AMOUNT1," +
          "(SELECT CONVERT(DECIMAL(17, 2), SUM(TOTAL_AMOUNT))  FROM MISCELLENOUS where INSERT_DATE = '" + forentofficedate + "' and PAYMENT_MODE ='Card') AS MISAMOUNT," +
                "(SELECT CONVERT(decimal(17, 2), sum(Balance_Amount))  FROM PENDINGBILL WHERE Insert_Date = '" + forentofficedate + "' and Payment_Type ='Card' ) as pending FROM SETTLE where PAYMENT_MODE = 'Card' and INSERT_DATE = '" + forentofficedate + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {
                SA1 = Convert.ToDecimal(0.00);
                OB1 = Convert.ToDecimal(0.00);
                AD1 = Convert.ToDecimal(0.00);
                MA1 = Convert.ToDecimal(0.00);
                PB1 = Convert.ToDecimal(0.00);
            }
            else
            {
                if (dt.Rows[0]["AMOUNT"].ToString() == "")
                {
                    SA1 = Convert.ToDecimal(0.00);
                }
                else
                {
                    SA1 = Convert.ToDecimal(dt.Rows[0]["AMOUNT"]);
                }
                if (dt.Rows[0]["OPENINGBALANCE"].ToString() == "")
                {
                    OB1 = Convert.ToDecimal(0.00);
                }
                else
                {
                    OB1 = Convert.ToDecimal(dt.Rows[0]["OPENINGBALANCE"]);
                }
                if (dt.Rows[0]["AMOUNT1"].ToString() == "")
                {
                    AD1 = Convert.ToDecimal(0.00);
                }
                else
                {
                    AD1 = Convert.ToDecimal(dt.Rows[0]["AMOUNT1"]);
                }
                if (dt.Rows[0]["MISAMOUNT"].ToString() == "")
                {
                    MA1 = Convert.ToDecimal(0.00);
                }
                else
                {
                    MA1 = Convert.ToDecimal(dt.Rows[0]["MISAMOUNT"]);
                }
                if (dt.Rows[0]["pending"].ToString() == "")
                {
                    PB1 = Convert.ToDecimal(0.00);
                }
                else
                {
                    PB1 = Convert.ToDecimal(dt.Rows[0]["pending"]);
                }
                totalcard1 = SA1 + OB1 + AD1 + MA1 + PB1;
            }
            return dt;
        }
        public decimal SA11, OB11, AD11, MA11, PB11;
        public static decimal totalcheque1;
        public DataTable totalcheque()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT CONVERT(decimal(17,2),sum(AMOUNT)) AS AMOUNT," +
"(select CONVERT(DECIMAL(17, 2), SUM(AMOUNT))  from PAIDOUT_OPENINGBALANCE WHERE INSERT_DATE = '" + forentofficedate + "') AS OPENINGBALANCE," +
    "(SELECT CONVERT(DECIMAL(17, 2), SUM(AMOUNT_RECEIVED))  FROM ADVANCE WHERE INSERT_DATE = '" + forentofficedate + "' AND PAYTYPE ='Cheque') AS AMOUNT1," +
          "(SELECT CONVERT(DECIMAL(17, 2), SUM(TOTAL_AMOUNT))  FROM MISCELLENOUS where INSERT_DATE = '" + forentofficedate + "' and PAYMENT_MODE ='Cheque') AS MISAMOUNT," +
                "(SELECT CONVERT(decimal(17, 2), sum(Balance_Amount))  FROM PENDINGBILL WHERE Insert_Date = '" + forentofficedate + "' and Payment_Type ='Cheque') as pending FROM SETTLE where PAYMENT_MODE = 'Cheque' and INSERT_DATE = '" + forentofficedate + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {
                SA11 = Convert.ToDecimal(0.00);
                OB11 = Convert.ToDecimal(0.00);
                AD11 = Convert.ToDecimal(0.00);
                MA11 = Convert.ToDecimal(0.00);
                PB11 = Convert.ToDecimal(0.00);
            }
            else
            {
                if (dt.Rows[0]["AMOUNT"].ToString() == "")
                {
                    SA11 = Convert.ToDecimal(0.00);
                }
                else
                {
                    SA11 = Convert.ToDecimal(dt.Rows[0]["AMOUNT"]);
                }
                if (dt.Rows[0]["OPENINGBALANCE"].ToString() == "")
                {
                    OB11 = Convert.ToDecimal(0.00);
                }
                else
                {
                    OB11 = Convert.ToDecimal(dt.Rows[0]["OPENINGBALANCE"]);
                }
                if (dt.Rows[0]["AMOUNT1"].ToString() == "")
                {
                    AD11 = Convert.ToDecimal(0.00);
                }
                else
                {
                    AD11 = Convert.ToDecimal(dt.Rows[0]["AMOUNT1"]);
                }
                if (dt.Rows[0]["MISAMOUNT"].ToString() == "")
                {
                    MA11 = Convert.ToDecimal(0.00);
                }
                else
                {
                    MA11 = Convert.ToDecimal(dt.Rows[0]["MISAMOUNT"]);
                }
                if (dt.Rows[0]["pending"].ToString() == "")
                {
                    PB11 = Convert.ToDecimal(0.00);
                }
                else
                {
                    PB11 = Convert.ToDecimal(dt.Rows[0]["pending"]);
                }
                totalcheque1 = SA11 + OB11 + AD11 + MA11 + PB11;
            }
            return dt;
        }
        public string pendingfromdate { get; set; }
        public string pendingtodate { get; set; }
        public DataTable PENDINGBILLREPORT()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT A.INSERT_DATE,A.BILL_NO,A.ROOM_NO," +
                       "(SELECT GUEST_NAME FROM PRINTSTATUS WHERE BILL_NO = A.BILL_NO) AS GUESTNAME," +
                        "(SELECT MOBILE_NO FROM PRINTSTATUS WHERE BILL_NO = A.BILL_NO) AS MOBILENO,(SELECT TOTAL FROM PRINTSTATUS WHERE BILL_NO = A.BILL_NO) AS TOTAL, A.BALANCE FROM SETTLE_OTHERPAY A WHERE INSERT_DATE BETWEEN '" + pendingfromdate + "' AND '" + pendingtodate + "'";
            DataTable st = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return st;
        }
        public string tarrifposteddate { get; set; }
        public DataTable TarrifPostedDay()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT DISTINCT ROOM_NO,(SELECT FIRSTNAME FROM CHECKIN WHERE CHECKIN_ID = NA.CHECKIN_ID) AS GUESTNAME,"+
                "(SELECT ROOM_CATEGORY FROM CHECKIN WHERE CHECKIN_ID = NA.CHECKIN_ID) AS CATEGORY,"+
                "(SELECT CHARGED_TARRIF FROM CHECKIN WHERE CHECKIN_ID = NA.CHECKIN_ID) AS TARRIF,"+
                "(SELECT CONCAT(Convert(decimal(17, 0), TAX), '%') FROM CHECKIN WHERE CHECKIN_ID = NA.CHECKIN_ID) AS GST,"+
                "(SELECT(TAX * CHARGED_TARRIF / 100) FROM CHECKIN WHERE CHECKIN_ID = NA.CHECKIN_ID) AS GSTAMOUNT FROM night_audit NA WHERE INSERT_DATE = '" + tarrifposteddate + "' ";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public DataTable Checkoutday()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT ROOM_NO,GUEST_NAME,MOBILE_NO,INSERT_BY,(SELECT RESERVATION_ID FROM CHECKIN WHERE ROOM_NO=CHECKOUT.ROOM_NO AND ARRIVAL_DATE=CHECKOUT.ARRIVAL_DATE and CHECKIN_ID=CHECKOUT.CHECKIN_ID ) AS RESERVATION_ID," +
            "(SELECT ID_TYPE FROM CHECKIN WHERE ROOM_NO = CHECKOUT.ROOM_NO AND ARRIVAL_DATE = CHECKOUT.ARRIVAL_DATE and CHECKIN_ID = CHECKOUT.CHECKIN_ID) AS ID_TYPE," +
            "(SELECT ID_DATA FROM CHECKIN WHERE ROOM_NO = CHECKOUT.ROOM_NO AND ARRIVAL_DATE = CHECKOUT.ARRIVAL_DATE and CHECKIN_ID = CHECKOUT.CHECKIN_ID ) AS ID_DATA," +
            "(CAST(ARRIVAL_DATE AS VARCHAR(20))+'  '+(SELECT ARRIVAL_TIME FROM CHECKIN WHERE ROOM_NO = CHECKOUT.ROOM_NO AND ARRIVAL_DATE = CHECKOUT.ARRIVAL_DATE and CHECKIN_ID = CHECKOUT.CHECKIN_ID)) AS ARRIVAL_TIMEDATE FROM CHECKOUT WHERE INSERT_DATE>= DATEADD(day, -1, getdate())";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public DataTable todaydeparture()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@Date", DateTime.Today.Date);
            string s = "SELECT ROOM_NO,FIRSTNAME,MOBILE_NO,ID_TYPE,ID_DATA,CONVERT(varchar(10),ARRIVAL_TIME,103)AS DEPARTURE FROM CHECKIN WHERE CHECK_OUT = 0 AND DEPARTURE_DATE = @Date";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public string datetax { get; set; }
        public DataTable datewisetax()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT distinct ROOM_NO,FIRSTNAME,MOBILE_NO,DATEDIFF(day, ARRIVAL_DATE, DEPARTURE_DATE) AS STAY_DAYS,ROOM_CATEGORY,(CHARGED_TARRIF+CHARGED_EBED_ADULT+CHARGED_EBED_CHILD) AS ROOM_TARRIF, CONCAT(CONVERT(decimal(11, 0), TAX),'%' )AS GST,(SELECT TAX*(CHARGED_TARRIF+CHARGED_EBED_ADULT+CHARGED_EBED_CHILD)/100) AS GSTAMOUNT FROM CHECKIN WHERE INSERT_DATE = '" + datetax + "'";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public string Discountdaywisedate { get; set; }
        public DataTable DiscountDateWise()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT CHECKIN_ID,ROOM_NO,RESERVATION_NO,GUEST_NAME," +
                       "(SELECT MOBILE_NO FROM CHECKIN WHERE CHECKIN_ID = DISCOUNT.CHECKIN_ID) AS MOBILENO," +
                       "(SELECT ROOM_CATEGORY FROM CHECKIN WHERE CHECKIN_ID = DISCOUNT.CHECKIN_ID) AS CATEGORY," +
                       "(SELECT CHARGED_TARRIF FROM CHECKIN WHERE CHECKIN_ID = DISCOUNT.CHECKIN_ID) AS TARRIF," +
                       "(SELECT DATEDIFF(D, ARRIVAL_DATE, DEPARTURE_DATE) FROM CHECKIN WHERE CHECKIN_ID = DISCOUNT.CHECKIN_ID) AS STAYDAYS," +
                       "CASE WHEN AMOUNT = 0.00 THEN(SELECT CHARGED_TARRIF + CHARGED_EBED_ADULT + CHARGED_EBED_CHILD FROM CHECKIN    WHERE CHECKIN_ID = DISCOUNT.CHECKIN_ID) / PERCENTAGE ELSE AMOUNT END AS AMOUNT," +
                       "(SELECT CHARGED_TARRIF + CHARGED_EBED_ADULT + CHARGED_EBED_CHILD FROM CHECKIN WHERE CHECKIN_ID = DISCOUNT.CHECKIN_ID) -(CASE WHEN AMOUNT = 0.00 THEN(SELECT CHARGED_TARRIF + CHARGED_EBED_ADULT + CHARGED_EBED_CHILD FROM CHECKIN  WHERE CHECKIN_ID = DISCOUNT.CHECKIN_ID) / PERCENTAGE ELSE AMOUNT END) AS DISCOUNTTOTAL FROM DISCOUNT WHERE INSERT_DATE = '" + Discountdaywisedate + "'";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public DataTable GuestInHouse()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT ROOM_NO,FIRSTNAME,MOBILE_NO,ID_TYPE,ID_DATA,DEPARTURE_DATE,(CAST(ARRIVAL_DATE AS VARCHAR(20))+'  '+ARRIVAL_TIME) AS  DATETIME_ARRIVAL FROM CHECKIN WHERE CHECK_OUT=0 and DEPARTURE_DATE >= GETDATE()";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public string MWFromDate { get; set; }
        public string MWToDate { get; set; }
        public DataTable MWRoomTariff()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT ROOM_NO,MAX(ROOM_CATEGORY)AS ROOM_CATEGORY,Count(ROOM_NO)AS Room_count,SUM(CHARGED_TARRIF) as TARIFF FROM CHECKIN WHERE INSERT_DATE BETWEEN '" + MWFromDate + "' AND '" + MWToDate + "' GROUP BY ROOM_NO";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        
        //Front office Report Queries
        public DataTable FOResAdvance()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT ROOM_NO,RESERVATION_ID,AMOUNT_RECEIVED,(SELECT FIRSTNAME FROM RESERVATION WHERE RESERVATION_ID =A.RESERVATION_ID )AS GUESTNAME,PAYTYPE,INSERT_BY from ADVANCE A WHERE INSERT_DATE = '" + SelectedDate + "' AND RESERVATION_ID > 0 AND AMOUNT_RECEIVED > 0"; //'" + SelectedDate + "'
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public DataTable FOCheckInAdvance()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT ROOM_NO,RESERVATION_ID,AMOUNT_RECEIVED,(SELECT FIRSTNAME FROM CHECKIN WHERE CHECKIN_ID =A.CHECKIN_ID )AS GUESTNAME,PAYTYPE,INSERT_BY from ADVANCE A WHERE INSERT_DATE = '" + SelectedDate + "' AND RESERVATION_ID IS NULL AND AMOUNT_RECEIVED > 0";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public DataTable FOExtraAdvance()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT ROOM_NO,RESERVATION_ID,AMOUNT_RECEIVED,(SELECT FIRSTNAME FROM CHECKIN WHERE CHECKIN_ID =A.CHECKIN_ID )AS GUESTNAME,PAYTYPE,INSERT_BY from ADVANCE A WHERE INSERT_DATE = '" + SelectedDate + "' AND RESERVATION_ID = 0 AND AMOUNT_RECEIVED > 0";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public DataTable FOPostCharge()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT ROOM_NO,GUEST_NAME,CHARGES,INSERT_BY FROM POSTCHARGES WHERE INSERT_DATE = '" + SelectedDate + "'"; //'" + SelectedDate + "'
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public DataTable FOMisColl()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT MEMBER_NAME,PAYMENT_MODE, RECEIVED_AMOUNT,INSERT_BY FROM MISCELLENOUS WHERE INSERT_DATE = '" + SelectedDate + "' AND RECEIVED_AMOUNT > 0";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public DataTable FOPaidOut()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT VOCHERNUMBER,AMOUNT,INSERT_BY,AUTHORIZATIONS,PAY_TYPE FROM PAIDOUT WHERE INSERT_DATE = '" + SelectedDate + "' AND AMOUNT > 0";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public DataTable FORefund()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT RESERVATION_ID,ROOM_NO,GUEST_NAME,BALANCE_AMOUNT,REASON,INSERT_BY FROM REFUND WHERE INSERT_DATE = '" + SelectedDate + "' AND BALANCE_AMOUNT > 0"; //'" + SelectedDate + "'
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        //public DataTable FOSettle()
        //{
        //    var list = new List<SqlParameter>();
        //    string s = "SELECT ROOM_NO,GUEST_NAME,BALANCE_AMOUNT,INSERT_BY FROM PRINTSTATUS WHERE INSERT_DATE = '" + SelectedDate + "' AND BILLSETTLE = 1";
        //    DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
        //    return d;
        //}
        public DataTable FOSettlements()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT ROOM_NO,RESERVATION_NO,GUEST_NAME,BALANCE_AMOUNT,INSERT_BY,PAYMENT_MODE from SETTLE where INSERT_DATE = '" + SelectedDate + "'";//AND BALANCE_AMOUNT > 0
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public DataTable FOOtherSettlements()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT ROOM_NO,PAYTYPE,AMOUNT,INSERT_BY,(SELECT GUEST_NAME from PRINTSTATUS where BILL_NO = so.BILL_NO) as Guest_Name from SETTLE_OTHERPAY so where INSERT_DATE = '" + SelectedDate + "' AND AMOUNT > 0";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public DataTable FORescancel()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT RESERVATION_ID,GUESTNAME,INSERT_BY FROM RESERVATIONCANCEL WHERE INSERT_DATE = '" + SelectedDate + "' ";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public DataTable FOOpeningBalance()
        {
            //select VOCHERNUMBER, AUTHORIZATIONS, AMOUNT, INSERT_BY from PAIDOUT_OPENINGBALANCE where STATUS = 'MANUAL' and INSERT_DATE = '2019-02-12'
            var list = new List<SqlParameter>();
            string s = "SELECT VOCHERNUMBER, AUTHORIZATIONS, AMOUNT, INSERT_BY from PAIDOUT_OPENINGBALANCE where STATUS = 'MANUAL' and INSERT_DATE = '" + SelectedDate + "' ";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public DataTable PendingBillAmount()
        {
            //SELECT SUM(Amount_Recevied) AS PendingBill from PENDINGBILL where Insert_Date = '2018-12-28' AND Amount_Recevied > 0
            var list = new List<SqlParameter>();
            string s = "SELECT SUM(Amount_Recevied) AS PendingBill from PENDINGBILL where Insert_Date = '" + SelectedDate + "' AND Amount_Recevied > 0";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public DataTable OpeningBalance_Cash()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT  SUM(AMOUNT) As AMOUNT from PAIDOUT_OPENINGBALANCE where INSERT_DATE = '" + OB_Date1 + "' AND AMOUNT_TYPE = 'Cash'";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public DataTable OpeningBalance_Card()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT  SUM(AMOUNT) As AMOUNT from PAIDOUT_OPENINGBALANCE where INSERT_DATE = '" + OB_Date1 + "' AND AMOUNT_TYPE = 'ToBank'";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public DataTable OB_Getting()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT Distinct (SELECT SUM(AMOUNT_RECEIVED) from ADVANCE WHERE INSERT_DATE = '" + OB_Date + "'  AND RESERVATION_ID > 0 and AMOUNT_RECEIVED > 0) AS R_Advance," +
                "(SELECT SUM(AMOUNT_RECEIVED) from ADVANCE WHERE INSERT_DATE = '" + OB_Date + "'  AND RESERVATION_ID IS NULL and AMOUNT_RECEIVED > 0) AS C_Advance," +
                "(SELECT SUM(AMOUNT_RECEIVED) from ADVANCE WHERE INSERT_DATE = '" + OB_Date + "'  AND RESERVATION_ID = 0 AND AMOUNT_RECEIVED > 0) AS E_Advance," +
                "(SELECT SUM(RECEIVED_AMOUNT) FROM MISCELLENOUS WHERE INSERT_DATE = '" + OB_Date + "'  AND RECEIVED_AMOUNT > 0) AS Mis," +
                "(SELECT SUM(AMOUNT) FROM PAIDOUT WHERE INSERT_DATE = '" + OB_Date + "'  AND AMOUNT > 0) AS PaidOuts," +
                "(SELECT SUM(BALANCE_AMOUNT) FROM REFUND WHERE INSERT_DATE = '" + OB_Date + "'  AND BALANCE_AMOUNT > 0) AS Refund," +
                "(SELECT SUM(AMOUNT) from PAIDOUT_OPENINGBALANCE where INSERT_DATE = '" + OB_Date + "') AS OpeningBalance," +
                "(SELECT SUM(BALANCE_AMOUNT) from SETTLE where INSERT_DATE = '" + OB_Date + "'  AND BALANCE_AMOUNT > 0) AS Settle," +
                "(SELECT SUM(Amount_Recevied) from PENDINGBILL where Insert_Date = '" + OB_Date + "'  AND Amount_Recevied > 0) AS PendingBill FROM CHECKIN";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public DataTable OB_Getting_Cash()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT Distinct (SELECT SUM(AMOUNT_RECEIVED) FROM ADVANCE WHERE INSERT_DATE = '" + OB_Date + "'  AND RESERVATION_ID > 0 and AMOUNT_RECEIVED > 0 and PAYTYPE = 'Cash') AS R_Advance," +
                "(SELECT SUM(AMOUNT_RECEIVED) FROM ADVANCE WHERE INSERT_DATE = '" + OB_Date + "'  AND RESERVATION_ID IS NULL and AMOUNT_RECEIVED > 0 and PAYTYPE = 'Cash') AS C_Advance," +
                "(SELECT SUM(AMOUNT_RECEIVED) FROM ADVANCE WHERE INSERT_DATE = '" + OB_Date + "'  AND RESERVATION_ID = 0 AND AMOUNT_RECEIVED > 0 and PAYTYPE = 'Cash') AS E_Advance," +
                "(SELECT SUM(RECEIVED_AMOUNT) FROM MISCELLENOUS WHERE INSERT_DATE = '" + OB_Date + "'  AND RECEIVED_AMOUNT > 0 AND PAYMENT_MODE = 'Cash') AS Mis," +
                "(SELECT SUM(AMOUNT) FROM PAIDOUT WHERE INSERT_DATE = '" + OB_Date + "'  AND AMOUNT > 0 AND PAY_TYPE = 'Cash') AS PaidOuts," +
                "(SELECT SUM(BALANCE_AMOUNT) FROM REFUND WHERE INSERT_DATE = '" + OB_Date + "'  AND BALANCE_AMOUNT > 0 ) AS Refund," +
                "(SELECT SUM(AMOUNT) FROM PAIDOUT_OPENINGBALANCE where INSERT_DATE = '" + OB_Date + "' AND AMOUNT_TYPE = 'Cash') AS OpeningBalance," +
                "(SELECT SUM(BALANCE_AMOUNT) FROM SETTLE where INSERT_DATE = '" + OB_Date + "'  AND BALANCE_AMOUNT > 0 AND PAYMENT_MODE = 'Cash') AS Settle," +
                "(SELECT SUM(Amount_Recevied) FROM PENDINGBILL where Insert_Date = '" + OB_Date + "'  AND Amount_Recevied > 0 AND Payment_Type = 'Cash') AS PendingBill FROM CHECKIN";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public DataTable OB_Getting_Card()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT Distinct (SELECT SUM(AMOUNT_RECEIVED) FROM ADVANCE WHERE INSERT_DATE = '" + OB_Date + "'  AND RESERVATION_ID > 0 and AMOUNT_RECEIVED > 0 and PAYTYPE != 'Cash') AS R_Advance," +
                "(SELECT SUM(AMOUNT_RECEIVED) FROM ADVANCE WHERE INSERT_DATE = '" + OB_Date + "' AND RESERVATION_ID IS NULL and AMOUNT_RECEIVED > 0 and PAYTYPE != 'Cash') AS C_Advance," +
                "(SELECT SUM(AMOUNT_RECEIVED) FROM ADVANCE WHERE INSERT_DATE = '" + OB_Date + "'  AND RESERVATION_ID = 0 AND AMOUNT_RECEIVED > 0 and PAYTYPE != 'Cash') AS E_Advance," +
                "(SELECT SUM(RECEIVED_AMOUNT) FROM MISCELLENOUS WHERE INSERT_DATE = '" + OB_Date + "'  AND RECEIVED_AMOUNT > 0 AND PAYMENT_MODE != 'Cash') AS Mis," +
                "(SELECT SUM(AMOUNT) FROM PAIDOUT WHERE INSERT_DATE = '" + OB_Date + "'  AND AMOUNT > 0 AND PAY_TYPE != 'Cash') AS PaidOuts," +
                "(SELECT SUM(AMOUNT) FROM PAIDOUT_OPENINGBALANCE where INSERT_DATE = '" + OB_Date + "' AND AMOUNT_TYPE != 'Cash') AS OpeningBalance," +
                "(SELECT SUM(BALANCE_AMOUNT) FROM SETTLE where INSERT_DATE = '" + OB_Date + "'  AND BALANCE_AMOUNT > 0 AND PAYMENT_MODE != 'Cash') AS Settle," +
                "(SELECT SUM(Amount_Recevied) FROM PENDINGBILL where Insert_Date = '" + OB_Date + "'  AND Amount_Recevied > 0 AND Payment_Type != 'Cash') AS PendingBill FROM CHECKIN";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
    }
}
