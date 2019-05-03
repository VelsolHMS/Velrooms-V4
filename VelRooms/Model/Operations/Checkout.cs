using DAL;
using HMS.View.Operations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HMS.View.Masters;

namespace HMS.Model.Operations
{
    public class Checkout1
    {
        public string ROOM_CATEGORY { get; set; }
        public string ROOM_NO { get; set; }
        public string RESERVATION_ID { get; set; }
        public string GUEST_NAME { get; set; }
        public string COMPANY { get; set; }
        public string CONTACT_NO { get; set; }
        public string COMPANY_CONTACT { get; set; }
        public string TOTAL_DAYS { get; set; }
        public string BILL_NO { get; set; }
        public string DATE { get; set; }
        public string ARRIVAL_DATE { get; set; }
        public string DEPARTURE_DATE { get; set; }
        public string ROOM_TARRIF { get; set; }
        public string EXTRA_CHARGES { get; set; }
        public string CGST { get; set; }
        public string SGST { get; set; }
        public string TOTAL { get; set; }
        public string ADVANCE { get; set; }
        public string GST_PERCENTAGE { get; set; }
        public string DISCOUNT { get; set; }
        public string BALANCE_AMOUNT { get; set; }
        public DateTime CURRENTDATE { get; set; }
        public string GST_MONEY { get; set; }
        public string ROOM_NO1 { get; set; }
        public string TIME { get; set; }
        public string MOBILE_NO;
        public decimal CHARGED_TARRIF, tax, amount, percentage, advanceamt, charges, gst;
        public int checkinid, checkoutid;
        public float factor;
        public DateTime arrival, departure;
        public static int RR, LL;
        public void Insert()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@ROOM_NO", RR);
            list.AddSqlParameter("@CURRENTDATE", DateTime.Today.Date);
            list.AddSqlParameter("@INSERT_BY", login.u);
            list.AddSqlParameter("@Checkout_Time", DateTime.Now.ToShortTimeString());
            list.AddSqlParameter("@INSERT_DATE", DateTime.Today.Date);
            string S = "INSERT INTO CHECKOUT (ROOM_NO,CURRENTDATE,GUEST_NAME,MOBILE_NO,ARRIVAL_DATE,DEPARTURE_DATE,TARRIF,CHARGES,CGST,SGST,TOTAL,ADVANCE,DISCOUNT,BALANCE,TRANSFER_AMOUNT,CHECKIN_ID,prints,INSERT_BY,INSERT_DATE,Checkout_Time)" +
               " VALUES (@ROOM_NO,@CURRENTDATE,(select FIRSTNAME from CHECKIN WHERE ROOM_NO ='" + RR + "' AND CHECK_OUT=0 )," +
               "(select MOBILE_NO from CHECKIN WHERE ROOM_NO='" + RR + "' AND  CHECK_OUT=0)," +
                "(select ARRIVAL_DATE from CHECKIN WHERE ROOM_NO='" + RR + "' AND CHECK_OUT=0)," +
                "(select DEPARTURE_DATE from CHECKIN WHERE ROOM_NO='" + RR + "' AND CHECK_OUT=0)," +
                "(select ROOM_TARRIF from PRINTSTATUS WHERE ROOM_NO='" + RR + "' AND BILLSETTLE = 0)," +
                "(select EXTRA_CHARGES from PRINTSTATUS WHERE ROOM_NO='" + RR + "' AND BILLSETTLE = 0)," +
                "(select CGST from PRINTSTATUS where ROOM_NO= '" + RR + "'  AND BILLSETTLE = 0)," +
                "(select SGST from PRINTSTATUS where ROOM_NO= '" + RR + "'  AND BILLSETTLE = 0)," +
                "(SELECT TOTAL FROM PRINTSTATUS WHERE ROOM_NO='"+ RR + "' AND BILLSETTLE = 0)," +
                "(SELECT ADVANCE FROM PRINTSTATUS WHERE ROOM_NO='" + RR + "' AND BILLSETTLE = 0)," +
                "(SELECT DISCOUNT FROM PRINTSTATUS WHERE ROOM_NO='" + RR + "' AND BILLSETTLE = 0)," +
                "(SELECT BALANCE_AMOUNT FROM PRINTSTATUS WHERE ROOM_NO='" + RR + "' AND BILLSETTLE = 0)," +
                "(SELECT TRANSFER_AMOUNT from PRINTSTATUS WHERE ROOM_NO='" + RR + "' AND BILLSETTLE = 0)," +
                "(SELECT CHECKIN_ID from checkin where ROOM_NO='" + RR + "' AND CHECK_OUT=0) ,1,@INSERT_BY,@INSERT_DATE,@Checkout_Time)";
            DbFunctions.ExecuteCommand<int>(S, list);
        }
        public DataTable CC()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@ROOM_NO", RR);
            string S = "UPDATE CHECKIN SET CHECK_OUT=1 WHERE ROOM_NO ='" + RR + "' AND CHECKIN_ID IN (SELECT CHECKIN_ID FROM CHECKIN WHERE ROOM_NO ='" + RR + "' AND CHECK_OUT = 0) ";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, list);
            return dt;
        }
        //public DataTable CC1()
        //{
        //    var list = new List<SqlParameter>();
        //    list.AddSqlParameter("@ROOM_NO", RR);
        //    string S = "delete from night_audit where ROOM_NO ='" + RR + "'";
        //    DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, list);
        //    return dt;
        //}

        public static DataTable dt { get; set; }

        //Method To Get All Room Category From Room Master
        public DataTable GET_ROOMCATEGORY()
        {
            var listParams = new List<SqlParameter>();
            string S = "SELECT ROOM_CATEGORY FROM ROOMMASTER";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, listParams);
            return dt;
        }
        public DataTable room_category()
        {
            var listParams = new List<SqlParameter>();
            string S = "SELECT ROOM_CATEGORY FROM ROOMMASTER WHERE ROOM_NO=@RMNO";
            listParams.AddSqlParameter("@RMNO", ROOM_NO);
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, listParams);
            return dt;
        }
        public DataTable company_contact()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT CONTACT_PERSON_NUMBER FROM COMPANYMASTER WHERE COMPANY_NAME = '" + COMPANY + "'";
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return DT;
        }
        public decimal transfer;
        public DataTable ROOMCATEGORY()
        {
            var listParams = new List<SqlParameter>();
            string S = "SELECT ROOM_CATEGORY FROM ROOMMASTER WHERE ROOM_NO = '" + ROOM_NO + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, listParams);
            return dt;
        }
        //Method to get hotel name and address from report ***Modified by krishna 20-11-2017***
        public DataTable GET_HOTELADDRESS()
        {
            String S = "SELECT NAME,PLOT_NO,LANDMARK,CITY,STATE,PINCODE,COUNTRY FROM hotelinfo WHERE HOTELINFO_ID=@HOTELINFOID";
            var L = new List<SqlParameter>();
            L.AddSqlParameter("@HOTELINFOID", 1);
            DataTable D = DAL.DbFunctions.ExecuteCommand<DataTable>(S, L);
            DataTable H = new DataTable();
            H.Columns.Add("NAME", typeof(string)); H.Columns.Add("ADDRESS", typeof(string));
            DataRow DR = H.NewRow();
            H.Rows.Add(DR);
            H.Rows[0]["NAME"] = D.Rows[0]["NAME"];
            H.Rows[0]["ADDRESS"] = "Address" + " : " + D.Rows[0]["PLOT_NO"] + "," + D.Rows[0]["LANDMARK"] + "," + D.Rows[0]["CITY"] + "," + D.Rows[0]["PINCODE"] + "," + D.Rows[0]["STATE"] + "," + D.Rows[0]["COUNTRY"];
            return H;
        }
        public DataTable checkoutdetails()
        {
            var L = new List<SqlParameter>();
            string s = "SELECT CHECKIN_ID,ROOM_NO,ROOM_CATEGORY,TAX FROM CHECKIN WHERE ROOM_NO = '" + ROOM_NO + "' ";
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(s, L);
            if (DT.Rows.Count == 0)
            {
                tax = 0;
            }
            else
            {
                decimal.TryParse(DT.Rows[0]["TAX"].ToString(), out tax);
            }
            //checkinid = int.Parse(DT.Rows[0]["CHECKIN_ID"].ToString());
            return DT;
        }
        // Method To Get All Room Numbers From Checkin 
        public DataTable GET_ROOM_NO(String R)
        {
            var listParams = new List<SqlParameter>();
            string S = "SELECT ROOM_NO,BACKGROUND_COLOR FROM ROOMMASTER WHERE ROOM_CATEGORY='" + R + "' AND BACKGROUND_COLOR != 'Green'  ";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, listParams);
            return dt;
        }
        public DataTable GET_ROOM_NO1()
        {
            var listParams = new List<SqlParameter>();
            string S = "SELECT ROOM_NO,BACKGROUND_COLOR FROM ROOMMASTER WHERE  BACKGROUND_COLOR != 'Green'  ";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, listParams);
            return dt;
        }
        public int a = 0;
        public int night_auditcount()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("ROOM_NO", ROOM_NO);
            string s = "select count(ROOM_TARRIF) AS Total from night_audit where ROOM_NO = @ROOM_NO AND NIGHT=0 ";
            object c = DbFunctions.ExecuteCommand<object>(s, list);
            if (c == System.DBNull.Value)
            {
                a = 1;
            }
            else
            {
                a = Convert.ToInt32(c);
            }
            return a;
        }
        public int ADVANCE_ID;
        public DataTable sumofnight()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT * FROM night_audit Where ROOM_NO='" + ROOM_NO + "' AND NIGHT=0";
            DataTable D = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return D;
        }
        //public DataTable ADVANCE_ID1()
        //{
        //    var LIST = new List<SqlParameter>();
        //    string LI = "SELECT ADVACE_ID FROM ADVANCE ";
        //    DataTable DT = DbFunctions.ExecuteCommand<DataTable>(LI, LIST);
        //    return DT;
        //}
        public void DISCOUNTINT()
        {
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@ROOM", RR);
            string SS = "UPDATE DISCOUNT SET DISCOUNT = 1 WHERE CHECKIN_ID =(select CHECKIN_ID FROM CHECKIN where ROOM_NO = @ROOM AND CHECK_OUT =0)";
            DbFunctions.ExecuteCommand<int>(SS, LIST);
        }
        public void DISCOUNT1()
        {
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@CHECKIN_ID", LL);
            string SS = "UPDATE DISCOUNT SET DISCOUNT=0 WHERE CHECKIN_ID=@CHECKIN_ID";
            DbFunctions.ExecuteCommand<int>(SS, LIST);
        }
        public void ADVANCEINT()
        {
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@ROOM", RR);
            string SS = "UPDATE ADVANCE SET ADVANCE = 1 WHERE CHECKIN_ID =(select CHECKIN_ID FROM CHECKIN where ROOM_NO = @ROOM AND CHECK_OUT =0)";
            DbFunctions.ExecuteCommand<int>(SS, LIST);
        }
        public void A()
        {
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@CHECKIN_ID", LL);
            string SS = "UPDATE ADVANCE SET ADVANCE=0 WHERE  CHECKIN_ID=@CHECKIN_ID";
            DbFunctions.ExecuteCommand<int>(SS, LIST);
        }
        public void POSTCHARGESINT()
        {
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@ROOM", RR);
            string SS = "UPDATE POSTCHARGES SET POSTCHARGES = 1 WHERE CHECKIN_ID =(select CHECKIN_ID FROM CHECKIN where ROOM_NO = @ROOM AND CHECK_OUT =0)";
            DbFunctions.ExecuteCommand<int>(SS, LIST);
        }
        public void POSTCHARGES()
        {
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@CHECKIN_ID", LL);
            string SS = "UPDATE POSTCHARGES SET POSTCHARGES=0 WHERE  CHECKIN_ID=@CHECKIN_ID ";
            DbFunctions.ExecuteCommand<int>(SS, LIST);
        }
        public int get_checkout_id()
        {
            int a = 0;
            string S = "SELECT MAX(BILL_NO) FROM PRINTSTATUS";
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
        public string ADDRESS { get; set; }
        public string RESERVATION_NO { get; set; } 
        public string ROOMTYPE { get; set; }
        public DataTable guestinfo()
        {
            var list = new List<SqlParameter>();
            string s = "Select DATEDIFF(DAY,ARRIVAL_DATE,DEPARTURE_DATE) as DAYS,ARRIVAL_DATE,ARRIVAL_TIME,FIRSTNAME,COMPANY_NAME,MOBILE_NO,ADDRESS,RESERVATION_ID,ROOM_CATEGORY,CITY,STATE,ZIP,COUNTRY,COMPANY_NAME,Company_Gst FROM CHECKIN WHERE ROOM_NO = '" + ROOM_NO+"' AND CHECK_OUT=0 ";
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (DT.Rows.Count == 0)
            {
            }
            else
            {
                TOTAL_DAYS = DT.Rows[0]["DAYS"].ToString();
                GUEST_NAME = DT.Rows[0]["FIRSTNAME"].ToString();
                COMPANY = DT.Rows[0]["COMPANY_NAME"].ToString();
                CONTACT_NO = DT.Rows[0]["MOBILE_NO"].ToString();
                ADDRESS = DT.Rows[0]["ADDRESS"].ToString();
                RESERVATION_NO = DT.Rows[0]["RESERVATION_ID"].ToString();
                ROOMTYPE = DT.Rows[0]["ROOM_CATEGORY"].ToString();
            }
            return DT;
        }
        public void insert()
        {
            Checkout CK = new Checkout();
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@ROOM_NO", ROOM_NO);
            string s = "INSERT INTO CHECKOUT(ROOM_NO)VALUES(@ROOM_NO)";
            DbFunctions.ExecuteCommand<int>(s, list);
        }
        //public string FETCH_TAX(String S)
        //{
        //    string TAX = null;
        //    String STR = "SELECT * FROM TAX_CODE";
        //    var l = new List<SqlParameter>();
        //    DataTable D = DbFunctions.ExecuteCommand<DataTable>(STR, l);
        //    for (int I = 0; I < D.Rows.Count; I++)
        //    {
        //        decimal COST = Convert.ToDecimal(D.Rows[I]["FROM_AMOUNT"]);
        //        decimal COST_TWO = Convert.ToDecimal(D.Rows[I]["TO_AMOUNT"]);
        //        decimal RACK_TARRIF = Convert.ToDecimal(S);
        //        if (RACK_TARRIF > COST && RACK_TARRIF <= COST_TWO)
        //        {
        //            TAX = D.Rows[I]["FACTOR"].ToString();
        //        }
        //        else if (RACK_TARRIF > COST && COST_TWO == 0)
        //        {
        //            TAX = D.Rows[I]["FACTOR"].ToString();
        //        }

        //    }
        //    return TAX;
        //}
        public float k;
        public int ii = 0;
        public void get_datetime()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT INSERT_DATE,INSERT_TIME FROM night_audit WHERE ROOM_NO = '" + ROOM_NO + "' AND NIGHT=0 AND CHECKIN_ID='"+ LL +"' ";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            try
            {
                if (ii >= 0)
                {
                    DateTime dd = Convert.ToDateTime(dt.Rows[ii]["INSERT_DATE"].ToString());
                    DATE = dd.ToShortDateString();
                    TIME = dt.Rows[ii]["INSERT_TIME"].ToString();
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
        }
        public DateTime da;
        public void color()
        {
            var list = new List<SqlParameter>();
            string s = "UPDATE ROOMMASTER SET BACKGROUND_COLOR='Gray' WHERE ROOM_NO='" + ROOM_NO + "' ";
            DbFunctions.ExecuteCommand<int>(s, list);
        }
        public DataTable checkoutbilling()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT c.ROOM_NO,(select FIRSTNAME FROM CHECKIN WHERE ROOM_NO=c.ROOM_NO and CHECK_OUT=0 ) AS GUESTNAME,"+
                "(SELECT ADDRESS FROM CHECKIN WHERE ROOM_NO=c.ROOM_NO AND CHECK_OUT=0) AS GUESTADDRESS,"+
                "(SELECT RESERVATION_ID FROM CHECKIN WHERE ROOM_NO=c.ROOM_NO AND CHECK_OUT=0) AS RESERVATION_ID,"+
                "(SELECT ROOM_CATEGORY FROM CHECKIN WHERE ROOM_NO=c.ROOM_NO AND CHECK_OUT=0) AS ROOM_TYPE,"+
                "(SELECT PAX FROM CHECKIN WHERE ROOM_NO=c.ROOM_NO AND CHECK_OUT=0) AS PAX,c.ROOM_TARRIF,"+
                "(SELECT CONVERT(varchar(10),ARRIVAL_DATE,103) FROM CHECKIN WHERE ROOM_NO=c.ROOM_NO AND CHECK_OUT=0) AS ARRIVALDATE,"+
                "(SELECT CONVERT(varchar(10),CAST(ARRIVAL_TIME as varchar),100) FROM CHECKIN WHERE ROOM_NO=c.ROOM_NO AND CHECK_OUT=0) AS ARRIVALTIME,"+
                "( select AMOUNT_RECEIVED from ADVANCE where ROOM_NO=c.ROOM_NO and ADVANCE=0 and INSERT_DATE=c.INSERT_DATE ) AS ADVANCE,"+
                "(select CHARGES from POSTCHARGES where ROOM_NO=c.ROOM_NO and POSTCHARGES=0) AS CHARGES ,"+
                "(SELECT MAX(BILL_NO) FROM PRINTSTATUS ) AS INVOICE,(SELECT STR(CGST)*2 FROM PRINTS WHERE ROOM_NO=c.ROOM_NO ) AS TAX ,"+
                "c.INSERT_DATE,(SELECT AMOUNT =CASE WHEN A.AMOUNT=0.00 THEN (SELECT CHARGED_TARRIF FROM CHECKIN WHERE ROOM_NO=A.ROOM_NO AND CHECK_OUT=0)/A.PERCENTAGE"+
                " ELSE A.AMOUNT END FROM DISCOUNT A WHERE ROOM_NO = c.ROOM_NO AND DISCOUNT = 0 ) AS DISCOUNT,"+
                "(select TOTAL from PRINTS where ROOM_NO = c.ROOM_NO and PRINTSTATUS = 0 ) AS TOTAL,"+
                "(SELECT INSERT_BY FROM PRINTS WHERE PRINTSTATUS = 0) AS USERNAME,(SELECT NAME FROM HotelInfo) AS HOTEL,"+
                "(SELECT CONCAT(PLOT_NO, ',', LANDMARK, ',', CITY, ',', STATE, ' - ', PINCODE, '.') FROM HotelInfo) AS HOTELADDRESS FROM night_audit c WHERE c.ROOM_NO ='"+ ROOM_NO +"'  and NIGHT = 0";
            DataTable S= DbFunctions.ExecuteCommand<DataTable>(s,list);
            return S;
        }
        public static string N, AD, GS;
        public DataTable hotel()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT NAME,(SELECT CONCAT(PLOT_NO, ',', LANDMARK, ',', CITY, ',', STATE, ' - ', PINCODE,'.') FROM HotelInfo) AS ADDRESS,GST  FROM HotelInfo";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if(dt.Rows.Count == 0)
            {
            }
            else
            {
                N = dt.Rows[0]["NAME"].ToString();
                AD = dt.Rows[0]["ADDRESS"].ToString();
                GS = dt.Rows[0]["GST"].ToString();
            }
            return dt;
        }
        public void BillSplitInsert()
        {
            var lists = new List<SqlParameter>();
            //lists.AddSqlParameter("@BILL_NO", BILL_NO);
            lists.AddSqlParameter("@DATE", DateTime.Today);
            lists.AddSqlParameter("@ROOM_NO", ROOM_NO);
            //lists.AddSqlParameter("@ARRIVAL_DATE", Convert.ToDateTime(ARRIVAL_DATE));
            //lists.AddSqlParameter("@DEPARTURE_DATE", Convert.ToDateTime(DEPARTURE_DATE));
            //lists.AddSqlParameter("@GUEST_NAME", GUEST_NAME);
            //lists.AddSqlParameter("@MOBILE_NO", CONTACT_NO);
            lists.AddSqlParameter("@ROOM_TARRIF", ROOM_TARRIF);
            lists.AddSqlParameter("@EXTRA_CHARGES", EXTRA_CHARGES);
            lists.AddSqlParameter("@CGST", CGST);
            lists.AddSqlParameter("@SGST", SGST);
            lists.AddSqlParameter("@TOTAL", TOTAL);
            lists.AddSqlParameter("@ADVANCE", ADVANCE);
            lists.AddSqlParameter("@DISCOUNT", DISCOUNT);
            lists.AddSqlParameter("@BALANCE_AMOUNT", BALANCE_AMOUNT);
            lists.AddSqlParameter("@CHECKIN_ID", LL);
            lists.AddSqlParameter("@INSERT_BY", login.u);
            lists.AddSqlParameter("@INSERT_DATE", DateTime.Today);
            string s = "INSERT INTO PRINTSTATUS (DATE,ROOM_NO,ARRIVAL_DATE,DEPARTURE_DATE,GUEST_NAME,MOBILE_NO,ROOM_TARRIF,EXTRA_CHARGES,CGST,SGST,TOTAL,ADVANCE,DISCOUNT,BALANCE_AMOUNT,CHECKIN_ID,INSERT_BY,INSERT_DATE,COMPANYNAME)"
                + "VALUES (@DATE,@ROOM_NO,(select ARRIVAL_DATE from CHECKIN WHERE CHECKIN_ID='" + LL + "' AND CHECK_OUT=0 ),(SELECT DEPARTURE_DATE FROM CHECKIN WHERE CHECKIN_ID='" + LL + "' AND CHECK_OUT=0),(SELECT FIRSTNAME FROM CHECKIN WHERE CHECKIN_ID='" + LL + "' AND CHECK_OUT=0),(SELECT MOBILE_NO FROM CHECKIN WHERE CHECKIN_ID='" + LL + "' AND CHECK_OUT=0),"
                + "@ROOM_TARRIF,@EXTRA_CHARGES,@CGST,@SGST,@TOTAL,@ADVANCE,@DISCOUNT,@BALANCE_AMOUNT,@CHECKIN_ID,@INSERT_BY,@INSERT_DATE,(SELECT COMPANY_NAME FROM CHECKIN WHERE CHECKIN_ID='" + LL + "' AND CHECK_OUT=0))";
            DbFunctions.ExecuteCommand<int>(s, lists);
        }
        public int CheckingBillgeneration()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT ROOM_NO FROM PRINTSTATUS WHERE ROOM_NO = '" + ROOM_NO + "' AND CHECKIN_ID = '" + LL + "'";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (d.Rows.Count > 0)
            {
                RESERVATION_ID = "";
            }
            else
            {
                RESERVATION_ID = "success";
            }
            return a;
        }
        public string rno;
        public DataTable checkoutdata()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT ROOM_NO, PAX, TAX, CHECKIN_ID, MOBILE_NO, DEPARTURE_DATE, ARRIVAL_DATE, RESERVATION_ID, FIRSTNAME, INSERT_BY FROM CHECKIN WHERE ROOM_NO = '"+ ROOM_NO + "' AND CHECK_OUT = 0";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        //Method to check if the room is transfered or not
        //select * from ROOM_CHANGE where CHECKIN_ID = (select CHECKIN_ID from CHECKIN where ROOM_NO = '203' AND CHECK_OUT = 0) AND TRANSFER_ROOM = '203'
        public DataTable CheckingIfRoomChanged()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@ROOM_NO", ROOM_NO);
            string s = "SELECT * from ROOM_CHANGE where CHECKIN_ID = (SELECT CHECKIN_ID from CHECKIN where ROOM_NO = @ROOM_NO AND CHECK_OUT = 0) AND TRANSFER_ROOM = @ROOM_NO AND ROOM_CHANGE = 'Transfer'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable GetNightAudit(string CheckinId)
        {
            //select ROOM_TARRIF, GST from night_audit where CHECKIN_ID = 108763 AND NIGHT = 0
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@CheckinId", CheckinId);
            string s = "Select ROOM_TARRIF, GST from night_audit where CHECKIN_ID = @CheckinId AND NIGHT = 0";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable UserDetails()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT CHECKIN_ID, ROOM_NO, MOBILE_NO, ARRIVAL_DATE, DEPARTURE_DATE, FIRSTNAME, ARRIVAL_TIME FROM CHECKIN WHERE ROOM_NO = '" + ROOM_NO + "' AND CHECK_OUT = 0";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable RoomAdditionalCharges()
        {
            var list = new List<SqlParameter>();
            string s = "Select CHECKIN_ID,(Select Sum(AMOUNT_RECEIVED) from ADVANCE where CHECKIN_ID = c.CHECKIN_ID and ADVANCE = 0) AS ADVANCE," +
                "(Select AMOUNT from DISCOUNT where CHECKIN_ID = c.CHECKIN_ID And DISCOUNT = 0) AS DISCOUNT," +
	            "(Select PERCENTAGE from DISCOUNT where CHECKIN_ID = c.CHECKIN_ID And DISCOUNT = 0) AS DIS_PER," +
                "(Select SUM(BALANCE_AMOUNT) from REFUND WHERE CHECKIN_ID = c.CHECKIN_ID) AS REFUND," +
                "(Select SUM(TOTAL_AMOUNT) from POSTCHARGES where CHECKIN_ID = c.CHECKIN_ID AND POSTCHARGES = 0) AS POSTCHARGES from CHECKIN c where ROOM_NO = '" + ROOM_NO + "' And CHECK_OUT = 0";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable Room_NA_Details()
        {
            //SELECT c.INSERT_DATE,c.ROOM_TARRIF,c.ROOM_NO,(SELECT AMOUNT_RECEIVED FROM ADVANCE WHERE ADVANCE = 0 AND CHECKIN_ID = c.CHECKIN_ID AND INSERT_DATE = c.INSERT_DATE) AS ADVANCE,(select CHARGES from POSTCHARGES where POSTCHARGES = 0 AND  CHECKIN_ID = c.CHECKIN_ID AND INSERT_DATE = c.INSERT_DATE) AS CHARGES,c.GST FROM night_audit c WHERE NIGHT = 0 AND CHECKIN_ID = (Select CHECKIN_ID from CHECKIN where ROOM_NO = '313' AND CHECK_OUT = 0)
            var list = new List<SqlParameter>();
            string s = "SELECT c.INSERT_DATE,c.INSERT_TIME,c.ROOM_TARRIF,c.ROOM_NO,(SELECT Sum(AMOUNT_RECEIVED) FROM ADVANCE WHERE ADVANCE = 0 AND CHECKIN_ID = c.CHECKIN_ID AND INSERT_DATE = c.INSERT_DATE) AS ADVANCE,(select SUM(CHARGES) from POSTCHARGES where POSTCHARGES = 0 AND  CHECKIN_ID = c.CHECKIN_ID AND INSERT_DATE = c.INSERT_DATE) AS CHARGES,c.GST FROM night_audit c WHERE NIGHT = 0 AND CHECKIN_ID = (Select CHECKIN_ID from CHECKIN where ROOM_NO = '" + ROOM_NO + "' AND CHECK_OUT = 0)";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DateTime From_dt { get; set; }
        public DateTime To_dt { get; set; }
        public decimal NA_Advance, NA_Charges;
        public DataTable GetAdvance()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT Sum(AMOUNT_RECEIVED) as ADVANCE from ADVANCE where INSERT_DATE Between '" + From_dt + "' and '" + To_dt + "' and CHECKIN_ID = (Select CHECKIN_ID from CHECKIN where ROOM_NO = '" + ROOM_NO + "' AND CHECK_OUT = 0) AND ADVANCE = 0";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (d.Rows.Count == 0)
            {
                NA_Advance = 0;
            }
            else
            {
                if (d.Rows[0]["ADVANCE"].ToString() == null || d.Rows[0]["ADVANCE"].ToString() == "")
                {
                    NA_Advance = 0;
                }
                else
                {
                    NA_Advance = Convert.ToDecimal(d.Rows[0]["ADVANCE"]);
                }
            }
            return d;
        }
        public DataTable GetCharges()
        {
            var list = new List<SqlParameter>();
            string s = "select Sum(CHARGES) as CHARGES from POSTCHARGES where INSERT_DATE Between '" + From_dt + "' and '" + To_dt + "' and CHECKIN_ID = (Select CHECKIN_ID from CHECKIN where ROOM_NO = '" + ROOM_NO + "' AND CHECK_OUT = 0) AND POSTCHARGES = 0";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (d.Rows.Count == 0)
            {
                NA_Charges = 0;
            }
            else
            {
                if (d.Rows[0]["CHARGES"].ToString() == null || d.Rows[0]["CHARGES"].ToString() == "")
                {
                    NA_Charges = 0;
                }
                else
                {
                    NA_Charges = Convert.ToDecimal(d.Rows[0]["CHARGES"]);
                }
            }
            return d;
        }
        // Checking Rows in prints table
        public DataTable check_prints()
        {
            var list = new List<SqlParameter>();
            string sd = "Select * FROM PRINTS";
            DataTable da = DbFunctions.ExecuteCommand<DataTable>(sd, list);
            return da;
        }
        // Inserting row in Prints Table
        public void Prints_insert()
        {
            var lists = new List<SqlParameter>();   
            lists.AddSqlParameter("@DATE", DateTime.Today.Date);
            lists.AddSqlParameter("@ROOM_NO", ROOM_NO);
            lists.AddSqlParameter("@Ch_Tarrif", Checkout.Ch_Tarrif);
            lists.AddSqlParameter("@Ch_CSGST", Checkout.Ch_CSGST);
            lists.AddSqlParameter("@TOTAL", Checkout.Ch_Total);
            lists.AddSqlParameter("@TRANSFER_AMOUNT", Checkout.RC_TransferAmount);
            lists.AddSqlParameter("@Ch_Advance", Checkout.Ch_Advance);
            lists.AddSqlParameter("@Ch_Discount", Checkout.Ch_Discount);
            lists.AddSqlParameter("@Ch_Charges", Checkout.Ch_Charges);
            lists.AddSqlParameter("@Ch_PendingAmount", Checkout.Ch_PendingAmount);
            lists.AddSqlParameter("@INSERT_BY", login.u);
            lists.AddSqlParameter("@INSERT_DATE", DateTime.Today.Date);
            string s = "INSERT INTO PRINTS (BILL_NO,DATE,ROOM_NO,ARRIVAL_DATE,DEPARTURE_DATE,GUEST_NAME,MOBILE_NO,ROOM_TARRIF,EXTRA_CHARGES,CGST,SGST,TOTAL,TRANSFER_AMOUNT,ADVANCE,DISCOUNT,BALANCE_AMOUNT,PRINTSTATUS,INSERT_BY,INSERT_DATE)" +
                 "VALUES ((SELECT CHECKIN_ID FROM CHECKIN WHERE ROOM_NO='" + ROOM_NO + "' AND CHECK_OUT=0),@DATE,@ROOM_NO," +
                 "(select ARRIVAL_DATE from CHECKIN WHERE ROOM_NO='" + ROOM_NO + "' AND CHECK_OUT=0 )," +
                 "(select DEPARTURE_DATE from CHECKIN WHERE ROOM_NO='" + ROOM_NO + "' AND CHECK_OUT=0)," +
                 "(select FIRSTNAME from CHECKIN WHERE ROOM_NO='" + ROOM_NO + "' AND CHECK_OUT=0)," +
                 "(select MOBILE_NO from CHECKIN WHERE ROOM_NO='" + ROOM_NO + "' AND CHECK_OUT=0),@Ch_Tarrif," +
                 "@Ch_Charges,@Ch_CSGST,@Ch_CSGST,@TOTAL,@TRANSFER_AMOUNT,@Ch_Advance,@Ch_Discount,@Ch_PendingAmount,'0',@INSERT_BY,@INSERT_DATE)";
            DbFunctions.ExecuteCommand<int>(s, lists);
        }
        // Inserting row in PrintStatus Table
        public void PrintStatus_Insert()
        {
            var lists = new List<SqlParameter>();     
            lists.AddSqlParameter("@DATE", DateTime.Today.Date);
            lists.AddSqlParameter("@ROOM_NO", ROOM_NO);
            lists.AddSqlParameter("@Ch_Tarrif", Checkout.Ch_Tarrif);
            lists.AddSqlParameter("@Ch_CSGST", Checkout.Ch_CSGST);
            lists.AddSqlParameter("@TOTAL", Checkout.Ch_Total);
            lists.AddSqlParameter("@TRANSFER_AMOUNT", Checkout.RC_TransferAmount); 
            lists.AddSqlParameter("@Ch_Advance", Checkout.Ch_Advance);
            lists.AddSqlParameter("@Ch_Discount", Checkout.Ch_Discount);
            lists.AddSqlParameter("@Ch_Charges", Checkout.Ch_Charges);
            lists.AddSqlParameter("@Ch_PendingAmount", Checkout.Ch_PendingAmount);
            lists.AddSqlParameter("@INSERT_BY", login.u);
            lists.AddSqlParameter("@INSERT_DATE", DateTime.Today.Date);

            string s = "INSERT INTO PRINTSTATUS (DATE,ROOM_NO,ARRIVAL_DATE,DEPARTURE_DATE,GUEST_NAME,MOBILE_NO,ROOM_TARRIF,EXTRA_CHARGES,CGST,SGST,TOTAL,TRANSFER_AMOUNT,ADVANCE,DISCOUNT,BALANCE_AMOUNT,CHECKIN_ID,INSERT_BY,INSERT_DATE,COMPANYNAME,BILLSETTLE)" +
                "VALUES (@DATE,@ROOM_NO,(select ARRIVAL_DATE from CHECKIN WHERE ROOM_NO='" + ROOM_NO + "' AND CHECK_OUT=0 )," +
                "(select DEPARTURE_DATE from CHECKIN WHERE ROOM_NO='" + ROOM_NO + "' AND CHECK_OUT=0)," +
                "(select FIRSTNAME from CHECKIN WHERE ROOM_NO='" + ROOM_NO + "' AND CHECK_OUT=0)," +
                "(select MOBILE_NO from CHECKIN WHERE ROOM_NO='" + ROOM_NO + "' AND CHECK_OUT=0)," +
                "@Ch_Tarrif,@Ch_Charges,@Ch_CSGST,@Ch_CSGST,@TOTAL,@TRANSFER_AMOUNT,@Ch_Advance,@Ch_Discount,@Ch_PendingAmount," +
                "(SELECT CHECKIN_ID FROM CHECKIN WHERE  ROOM_NO='" + ROOM_NO + "' AND CHECK_OUT=0),@INSERT_BY,@INSERT_DATE,(SELECT COMPANY_NAME FROM CHECKIN WHERE ROOM_NO='" + ROOM_NO + "' AND CHECK_OUT=0),'0')";
            DbFunctions.ExecuteCommand<int>(s, lists);
        }
        public DataTable TransferAmount()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@ROOM_NO", ROOM_NO);
            string sd = "SELECT Sum(AMOUNT) As AMOUNT from SETTLE_TRANSFERPAY where TOROOMCHECKIN_ID = (Select CHECKIN_ID from CHECKIN where CHECK_OUT = 0 AND ROOM_NO = @ROOM_NO)";
            DataTable da = DbFunctions.ExecuteCommand<DataTable>(sd, list);
            return da;
        }
    }
}