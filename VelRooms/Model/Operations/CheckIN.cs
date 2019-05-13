using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using HMS.View.Masters;
using System.Text.RegularExpressions;
using System.Windows;
using HMS.View.Operations;
namespace HMS.Model
{
    public class Checksin
    {
        public int CHECKIN_ID { get; set; }
        public string ROOM_NO { get; set; }
        public string Company_Gst { get; set; }
        public String ROOM_TYPE { get; set; }
        public DateTime ARRIVAL_DATE { get; set; }
        public string ARRIVAL_TIME { get; set; }
        public DateTime DEPARTURE_DATE { get; set; }
        public String SUFFIX { get; set; }
        public String FIRSTNAME { get; set; }
        public String LASTNAME { get; set; }
        public String ADDRESS { get; set; }
        public int ZIP { get; set; }
        public String CITY { get; set; }
        public String STATE { get; set; }
        public String COUNTRY { get; set; }
        public Int64 MOBILE_NUMBER { get; set; }
        public String EMAIL { get; set; }
        public String ID_TYPE { get; set; }
        public String ID_PROOF { get; set; }
        public String COMPANY_NAME { get; set; }
        public String COMPANY_A { get; set; }
        public String MARKET_SEGMENT { get; set; }
        public int PAX { get; set; }
        public int PAX_ADULT { get; set; }
        public int PAX_CHILD { get; set; }
        public int EXTRABED { get; set; }
        public int EXTRA_ADULT { get; set; }
        public int EXTRA_CHILD { get; set; }
        public String PLANCODE { get; set; }
        public string TAX { get; set; }
        public decimal RACK_TARRIF { get; set; }
        public decimal RACK_EADULT { get; set; }
        public decimal RACK_ECHILD { get; set; }
        public decimal CHARGED_TARRIF { get; set; }
        public decimal CHARGED_EADULT { get; set; }
        public decimal CHARGED_ECHILD { get; set; }
        public string status { get; set; }
        public string SCANTY_BAGGAGE { get; set; }
        public String PAYMENT_MODE { get; set; }
        public decimal AMOUNT_RECEIVED { get; set; }
        public String CURRENCY_TYPE { get; set; }
        public String TRANSACTION_NO { get; set; }
        public String PARTICULARS { get; set; }
        public String CHEQUE_NO { get; set; }
        public int ID { get; set; }
        public List<int> id_res { get; set; }
        //public List<int> roomno_res { get; set; }
        //public List<string> roomcategory_res { get; set; }
        public int RESERVATION_ID { get; set; }
        //11/15/2017
        //public string USER_NAME { get; set; }
        public string INSERT_BY { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime UPDTAE_DATE { get; set; }
        public String IMAGE { get; set; }
        public int CHECK_OUT { get; set; }
        public string PLAN_CODE { get; set; }
        public void INSERT()
        {
            string S = null;
            //if (RESERVSTIONCHECKIN.p == 1)
            //{
            //    int count = roomno_res.Count;
            //    for (int i = 0; i < count; i++)
            //    {
            //        ROOM_NO = Convert.ToString(roomno_res[i]);
            //        ROOM_TYPE = roomcategory_res[i];
            //        int P = PAX / count;
            //        if (Checkin.ADVANCE == 1)
            //        {
            //            ID = id_res[i];
            //        }
            //        FETCH_TARRIF(P);
            //        S = "INSERT INTO CHECKIN (RESERVATION_ID,ROOM_NO,ROOM_CATEGORY,ARRIVAL_DATE,ARRIVAL_TIME,DEPARTURE_DATE,SUFFIX,FIRSTNAME,LASTNAME,ADDRESS,ZIP,CITY,STATE,COUNTRY,MOBILE_NO,EMAIL,ID_TYPE,ID_DATA,COMPANY_NAME,COMPANY_ADDRESS,PAX,PAX_ADULT,PAX_CHILD,EXTRA_BED,EXTRA_ADULT,EXTRA_CHILD,PLANCODE,TAX,RACK_TARRIF,RACK_EBED_ADULT,RACK_EBED_CHILD,CHARGED_TARRIF,CHARGED_EBED_ADULT,CHARGED_EBED_CHILD,MARKET_SEGMENT,STATUS,SCANTY_BAGGAGE,INSERT_BY,INSERT_DATE,PHOTO,CHECK_OUT)"+
            //            "VALUES(@RESERVATION_ID,@ROOM_NO,@ROOM_CATEGORY,@ARRIVAL_DATE,@ARRIVAL_TIME,@DEPARTURE_DATE,@SUFFIX,@FIRSTNAME,@LASTNAME,@ADDRESS,@ZIP,@CITY,@STATE,@COUNTRY,@MOBILE_NO,@EMAIL,@ID_TYPE,@ID_DATA,@COMPANY_NAME,@COMPANY_ADDRESS,@PAX,@PAX_ADULT,@PAX_CHILD,@EXTRA_BED,@EXTRA_ADULT,@EXTRA_CHILD,@PLANCODE,@TAX,@RACK_TARRIF,@RACK_EBED_ADULT,@RACK_EBED_CHILD,@CHARGED_TARRIF,@CHARGED_EBED_ADULT,@CHARGED_EBED_CHILD,@MARKET_SEGMENT,@STATUS,@SCANTY_BAGGAGE,@INSERT_BY,@INSERT_DATE,@PHOTO,@CHECK_OUT)";
            //        SUB_INSERT(S);

            //        if (Checkin.ADVANCE == 1)
            //        {

            //            INSERT_ADVANCE();
            //        }
            //    }
            //}
            //else
            //{
                S = "INSERT INTO CHECKIN (RESERVATION_ID,ROOM_NO,ROOM_CATEGORY,ARRIVAL_DATE,ARRIVAL_TIME,DEPARTURE_DATE,SUFFIX,FIRSTNAME,LASTNAME,ADDRESS,ZIP,CITY,STATE,COUNTRY,MOBILE_NO,EMAIL,ID_TYPE,ID_DATA,COMPANY_NAME,COMPANY_ADDRESS,PAX,PAX_ADULT,PAX_CHILD,EXTRA_BED,EXTRA_ADULT,EXTRA_CHILD,PLANCODE,TAX,RACK_TARRIF,RACK_EBED_ADULT,RACK_EBED_CHILD,CHARGED_TARRIF,CHARGED_EBED_ADULT,CHARGED_EBED_CHILD,MARKET_SEGMENT,STATUS,SCANTY_BAGGAGE,INSERT_BY,INSERT_DATE,PHOTO,CHECK_OUT,Company_Gst)VALUES(@RESERVATION_ID,@ROOM_NO,@ROOM_CATEGORY,@ARRIVAL_DATE,@ARRIVAL_TIME,@DEPARTURE_DATE,@SUFFIX,@FIRSTNAME,@LASTNAME,@ADDRESS,@ZIP,@CITY,@STATE,@COUNTRY,@MOBILE_NO,@EMAIL,@ID_TYPE,@ID_DATA,@COMPANY_NAME,@COMPANY_ADDRESS,@PAX,@PAX_ADULT,@PAX_CHILD,@EXTRA_BED,@EXTRA_ADULT,@EXTRA_CHILD,@PLANCODE,@TAX,@RACK_TARRIF,@RACK_EBED_ADULT,@RACK_EBED_CHILD,@CHARGED_TARRIF,@CHARGED_EBED_ADULT,@CHARGED_EBED_CHILD,@MARKET_SEGMENT,@STATUS,@SCANTY_BAGGAGE,@INSERT_BY,@INSERT_DATE,@PHOTO,@CHECK_OUT,@Company_Gst)";
                SUB_INSERT(S);
                if (Checkin.ADVANCE == 2)
                {
                    INSERT_ADVANCE();
                }
            //}
        }
        public void SUB_INSERT(string S)
        {
            var LIST = new List<SqlParameter>();

            LIST.AddSqlParameter("@RESERVATION_ID", RESERVATION_ID);
            LIST.AddSqlParameter("@ROOM_NO", ROOM_NO);
            LIST.AddSqlParameter("@ROOM_CATEGORY", ROOM_TYPE);
            LIST.AddSqlParameter("@ARRIVAL_DATE", ARRIVAL_DATE);
            LIST.AddSqlParameter("@ARRIVAL_TIME", ARRIVAL_TIME);
            LIST.AddSqlParameter("@DEPARTURE_DATE", DEPARTURE_DATE);
            LIST.AddSqlParameter("@SUFFIX", SUFFIX);
            LIST.AddSqlParameter("@FIRSTNAME", FIRSTNAME);
            LIST.AddSqlParameter("@LASTNAME", LASTNAME);
            LIST.AddSqlParameter("@ADDRESS", ADDRESS);
            LIST.AddSqlParameter("@ZIP", ZIP);
            LIST.AddSqlParameter("@CITY", CITY);
            LIST.AddSqlParameter("@STATE", STATE);
            LIST.AddSqlParameter("@COUNTRY", COUNTRY);
            LIST.AddSqlParameter("@MOBILE_NO", MOBILE_NUMBER);
            LIST.AddSqlParameter("@EMAIL", EMAIL);
            LIST.AddSqlParameter("@ID_TYPE", ID_TYPE);
            LIST.AddSqlParameter("@ID_DATA", ID_PROOF);
            LIST.AddSqlParameter("@COMPANY_ADDRESS", COMPANY_A);
            LIST.AddSqlParameter("@COMPANY_NAME", COMPANY_NAME);
            LIST.AddSqlParameter("@PAX", PAX);
            LIST.AddSqlParameter("@PAX_ADULT", PAX_ADULT);
            LIST.AddSqlParameter("@PAX_CHILD", PAX_CHILD);
            LIST.AddSqlParameter("@EXTRA_BED", EXTRABED);
            LIST.AddSqlParameter("@EXTRA_ADULT", EXTRA_ADULT);
            LIST.AddSqlParameter("@EXTRA_CHILD", EXTRA_CHILD);
            LIST.AddSqlParameter("@PLANCODE", PLANCODE);
            LIST.AddSqlParameter("@TAX", TAX);
            LIST.AddSqlParameter("@RACK_TARRIF", RACK_TARRIF);
            LIST.AddSqlParameter("@RACK_EBED_ADULT", RACK_EADULT);
            LIST.AddSqlParameter("@RACK_EBED_CHILD", RACK_ECHILD);
            LIST.AddSqlParameter("@CHARGED_TARRIF", CHARGED_TARRIF);
            LIST.AddSqlParameter("@CHARGED_EBED_ADULT", CHARGED_EADULT);
            LIST.AddSqlParameter("@CHARGED_EBED_CHILD", CHARGED_ECHILD);
            LIST.AddSqlParameter("@MARKET_SEGMENT", MARKET_SEGMENT);
            LIST.AddSqlParameter("@STATUS", status);
            LIST.AddSqlParameter("@SCANTY_BAGGAGE", SCANTY_BAGGAGE);
            //SS rr II uu11/15/2017
            //LIST.AddSqlParameter("@USER_NAME", USER_NAME);
            LIST.AddSqlParameter("@CHECK_OUT", CHECK_OUT);
            LIST.AddSqlParameter("@INSERT_BY", login.u);
            LIST.AddSqlParameter("@INSERT_DATE", DateTime.Today);
            LIST.AddSqlParameter("@PHOTO", IMAGE);
            LIST.AddSqlParameter("@Company_Gst", Company_Gst);
            //USER_NAME = login.u;
            DbFunctions.ExecuteCommand<int>(S, LIST);
            UPDATE_COLOR();
        }
        public DataTable GET_COMPANY()
        {
            String S = "SELECT COMPANY_NAME FROM COMPANYMASTER";
            var L = new List<SqlParameter>();
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(S, L);
            return DT;
        }
        public void FETCH_TARRIF(int A)
        {
            string S = "SELECT * FROM ROOMMASTER WHERE ROOM_NO=@ROOMNO";
            var L = new List<SqlParameter>();
            L.AddSqlParameter("@ROOMNO", ROOM_NO);
            DataTable D = DbFunctions.ExecuteCommand<DataTable>(S, L);
            if (A == 1)
            {
                RACK_TARRIF = Convert.ToDecimal(D.Rows[0]["SINGLERATE_TARRIF"]);
                CHARGED_TARRIF = RACK_TARRIF;
            }
            else if (A == 2)
            {
                RACK_TARRIF = Convert.ToDecimal(D.Rows[0]["DOUBLERATE_TARRIF"]);
                CHARGED_TARRIF = RACK_TARRIF;
            }
            else if (A == 3)
            {
                RACK_TARRIF = Convert.ToDecimal(D.Rows[0]["TRIPLERATE_TARRIF"]);
                CHARGED_TARRIF = RACK_TARRIF;
            }
            else if (A == 4)
            {
                RACK_TARRIF = Convert.ToDecimal(D.Rows[0]["QUADRATE_TARRIF"]);
                CHARGED_TARRIF = RACK_TARRIF;
            }
            else if (A > 4)
            {
                RACK_TARRIF = Convert.ToDecimal(D.Rows[0]["COMMON_PRICE"]);
                CHARGED_TARRIF = RACK_TARRIF;
            }
        }
        public DataTable GET_COMPANY_ADDRESS()
        {
            String S = "SELECT * FROM COMPANYMASTER WHERE COMPANY_NAME =@COMPANYNAME";
            var L = new List<SqlParameter>();
            L.AddSqlParameter("@COMPANYNAME", COMPANY_NAME);
            DataTable D = DbFunctions.ExecuteCommand<DataTable>(S, L);
            return D;
        }
        public void UPDATE_COLOR()
        {
            String COLOR = "Orange";
            String S = "UPDATE ROOMMASTER SET BACKGROUND_COLOR=@color where ROOM_NO=@ROOMNO";
            var L = new List<SqlParameter>();
            L.AddSqlParameter("@color", COLOR);
            L.AddSqlParameter("@ROOMNO", ROOM_NO);
            DbFunctions.ExecuteCommand<int>(S, L);
        }
        public void updateroomstatus()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@ROOM_NO", ROOM_NO);
            string s = "UPDATE ROOMSTATUS SET STATUS=1 WHERE ROOM_NO=@ROOM_NO";
            DbFunctions.ExecuteCommand<int>(s,list);
        }
        public static int ss = 0;
        public int get_checkin_id()
        {
            int a = 0;
            string S = "SELECT MAX(CHECKIN_ID) FROM CHECKIN";
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
                ss = a;
            }
            return a;
        }
        public int get_advance_id()
        {
            int a = 0;
            string S = "SELECT MAX(ADVANCE_ID) FROM ADVANCE";
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
        public DataTable fetch_PLANCODE(int ROOMNO)
        {
            var listParams = new List<SqlParameter>();
            listParams.AddSqlParameter("@ROOM_NO", ROOMNO);
            string S = "SELECT PLAN_CODE FROM ROOMMASTER_PLAN WHERE ROOM_NO=@ROOM_NO ";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(S, listParams);
            return d;
        }
        public DataTable planrate()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT SINGLE_PLAN,DOUBLE_PLAN,TRIPLE_PLAN,QUAD_PLAN,COMMON_PLAN FROM ROOMMASTER_PLAN WHERE ROOM_NO='"+Checkin.rn+"' AND PLAN_CODE='"+Checkin.pc+"'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public void FETCH_TAX(String S)
        {
            String STR = "SELECT FACTOR FROM TAX_CODE WHERE FROM_AMOUNT < '" + S + "' AND TO_AMOUNT >= '" + S + "'";
            var l = new List<SqlParameter>();
            DataTable D = DbFunctions.ExecuteCommand<DataTable>(STR, l);
            if (D.Rows.Count == 0)
            {
                TAX = "0";
            }
            else
            {
                TAX = D.Rows[0]["FACTOR"].ToString();
            }
            //for (int I = 0; I < D.Rows.Count; I++)
            //{
            //    //decimal COST = Convert.ToDecimal(D.Rows[I]["FROM_AMOUNT"]);
            //    //decimal COST_TWO = Convert.ToDecimal(D.Rows[I]["TO_AMOUNT"]);
            //    RACK_TARRIF = Convert.ToDecimal(S);
            //    if (RACK_TARRIF >= COST && RACK_TARRIF <= COST_TWO)
            //    {
            //        TAX = int.Parse(D.Rows[I]["FACTOR"].ToString());
            //    }
            //    else if (RACK_TARRIF > COST_TWO && COST == 0)
            //    {
            //        TAX = Convert.ToInt16(D.Rows[I]["FACTOR"]);
            //    }
        }
        public DataTable FETCH_PAX_DETAILS(int A)
        {
            string S = "SELECT * FROM ROOMMASTER WHERE ROOM_NO =@ROOM_NO";
            var l = new List<SqlParameter>();
            l.AddSqlParameter("@ROOM_NO", A);
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(S, l);
            return d;
        }

        public static int maxpax { get; set; }
        public DataTable paxdetails()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT MAX_PAX,CONVERT(decimal(17,2),SINGLERATE_TARRIF) AS SINGLERATE_TARRIF,CONVERT(decimal(17,2),DOUBLERATE_TARRIF) as DOUBLERATE_TARRIF,CONVERT(decimal(17,2),TRIPLERATE_TARRIF) as TRIPLERATE_TARRIF,CONVERT(decimal(17,2),QUADRATE_TARRIF) as QUADRATE_TARRIF,CONVERT(decimal(17,2),EXTRABED_ADULT) as EXTRABED_ADULT,CONVERT(decimal(17,2),EXTRABED_CHILD) as EXTRABED_CHILD FROM ROOMMASTER WHERE ROOM_NO ='" + Vacant.room_no + "'";
            DataTable D = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (D.Rows.Count == 0)
            {

            }
            else
            {
                maxpax = Convert.ToInt16(D.Rows[0]["MAX_PAX"].ToString());
            }
            return D;
        }
        public DataTable Getpaxctg()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT MAXPAX FROM ROOMCATEGORY WHERE ROOM_CATEGORY='" + Vacant.ctg+"'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public void INSERT_POST()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@ROOM_NO", ROOM_NO);
            list.AddSqlParameter("@CHECKIN_ID", CHECKIN_ID);
            list.AddSqlParameter("@GUEST_NAME", FIRSTNAME);
            list.AddSqlParameter("@CHARGES", CHARGED_EADULT + CHARGED_ECHILD);

            string S = "INSERT INTO POSTCHARGES (ROOM_NO,CHECKIN_ID,GUEST_NAME,CHARGES,POSTCHARGES) VALUES (@ROOM_NO,(SELECT CHECKIN_ID FROM CHECKIN WHERE ROOM_NO = @ROOM_NO AND CHECK_OUT != 1),@GUEST_NAME,@CHARGES,(SELECT POSTCHARGES FROM POSTCHARGES WHERE POSTCHARGES !=1 AND ROOM_NO ='" + ROOM_NO + "' ) )";

            DbFunctions.ExecuteCommand<int>(S, list);
        }
        public void INSERT_RES_CHECKIN_ADVANCE()
        {
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@RESERVATION_ID", RESERVATION_ID);
            LIST.AddSqlParameter("@CHECKIN_ID", CHECKIN_ID);
            LIST.AddSqlParameter("@ADVANCE_FOR", "ROOM");
            LIST.AddSqlParameter("@ROOM_NO", ROOM_NO);
            LIST.AddSqlParameter("@PAYTYPE", PAYMENT_MODE);
            LIST.AddSqlParameter("@CURRENCY_CODE", CURRENCY_TYPE);
            LIST.AddSqlParameter("@AMOUNT_RECEIVED", AMOUNT_RECEIVED);
            LIST.AddSqlParameter("@PARTICULARS", PARTICULARS);
            LIST.AddSqlParameter("@TRANSACTION_NO", TRANSACTION_NO);
            LIST.AddSqlParameter("@CHEQUE_NO", CHEQUE_NO);
            LIST.AddSqlParameter("@INSERT_BY", login.u);
            LIST.AddSqlParameter("@INSERT_DATE", DateTime.Today);
            LIST.AddSqlParameter("@ADVANCE_Time", DateTime.Now.ToShortTimeString());
            string RESCHADV = "INSERT INTO ADVANCE (RESERVATION_ID,CHECKIN_ID,ADVANCE_FOR,ROOM_NO,PAYTYPE,CURRENCY_CODE,AMOUNT_RECEIVED,PARTICULARS,TRANSACTION_NO,CHEQUE_NO,INSERT_BY,INSERT_DATE,ADVANCE,ADVANCE_Time)" +
                    "VALUES(@RESERVATION_ID,@CHECKIN_ID,@ADVANCE_FOR,@ROOM_NO,@PAYTYPE,@CURRENCY_CODE,@AMOUNT_RECEIVED,@PARTICULARS,@TRANSACTION_NO,@CHEQUE_NO,@INSERT_BY,@INSERT_DATE,'0',@ADVANCE_Time)";
            DbFunctions.ExecuteCommand<int>(RESCHADV, LIST);
        }
        public void INSERT_ADVANCE()
        {
            string S = null;
            //if (RESERVSTIONCHECKIN.p == 1)
            //{
            //    S = "INSERT INTO ADVANCE (RESERVATION_ID,CHECKIN_ID,ROOM_NO,ADVANCE_FOR,PAYTYPE,CURRENCY_CODE,AMOUNT_RECEIVED,PARTICULARS,TRANSACTION_NO,CHEQUE_NO,INSERT_BY,INSERT_DATE)" +
            //        "VALUES(@RESERVATION_ID,@CHECKIN_ID,@ROOM_NO,@ADVANCE_FOR,@PAYTYPE,@CURRENCY_CODE,@AMOUNT_RECEIVED,@PARTICULARS,@TRANSACTION_NO,@CHEQUE_NO,@INSERT_BY,@INSERT_DATE)";
            //}
            //else
            //{
                S = "INSERT INTO ADVANCE (CHECKIN_ID,ADVANCE_FOR,ROOM_NO,PAYTYPE,CURRENCY_CODE,AMOUNT_RECEIVED,PARTICULARS,TRANSACTION_NO,CHEQUE_NO,INSERT_BY,INSERT_DATE,ADVANCE_Time)" +
                    "VALUES(@CHECKIN_ID,@ADVANCE_FOR,@ROOM_NO,@PAYTYPE,@CURRENCY_CODE,@AMOUNT_RECEIVED,@PARTICULARS,@TRANSACTION_NO,@CHEQUE_NO,@INSERT_BY,@INSERT_DATE,@ADVANCE_Time)";
            //}
            var LIST = new List<SqlParameter>();
            //if (RESERVSTIONCHECKIN.p == 1)
            //{
            //    LIST.AddSqlParameter("@RESERVATION_ID", RESERVATION_ID);
            //}
            LIST.AddSqlParameter("@CHECKIN_ID", ID);
            LIST.AddSqlParameter("@ADVANCE_FOR", "ROOM");
            //if (RESERVSTIONCHECKIN.p == 1)
            //{
            //   ROOM_NO = "";
            //}
            //else
            //{
            LIST.AddSqlParameter("@ROOM_NO", ROOM_NO);
            LIST.AddSqlParameter("@ADVANCE_Time", DateTime.Now.ToShortTimeString());
            // }
            LIST.AddSqlParameter("@PAYTYPE", PAYMENT_MODE);
            LIST.AddSqlParameter("@CURRENCY_CODE", CURRENCY_TYPE);
            LIST.AddSqlParameter("@AMOUNT_RECEIVED", AMOUNT_RECEIVED);
            LIST.AddSqlParameter("@PARTICULARS", PARTICULARS);
            LIST.AddSqlParameter("@TRANSACTION_NO", TRANSACTION_NO);
            LIST.AddSqlParameter("@CHEQUE_NO", CHEQUE_NO);
            LIST.AddSqlParameter("@INSERT_BY", login.u);
            LIST.AddSqlParameter("@INSERT_DATE", DateTime.Today);
            DbFunctions.ExecuteCommand<int>(S, LIST);
            UPDATE_COLOR();
        }
        public DataTable roomchange()
        {
            var L = new List<SqlParameter>();
            string s = "SELECT * FROM CHECKIN WHERE ROOM_NO = '" + ROOM_NO + "' AND CHECK_OUT=0  ";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, L);
            //if (dt.Rows.Count == 0)
            //{
            //    FIRSTNAME = "";
            //    status = "";
            //}
            //else
            //{
            //    FIRSTNAME = dt.Rows[0]["FIRSTNAME"].ToString();
            //    ARRIVAL_DATE = Convert.ToDateTime(dt.Rows[0]["ARRIVAL_DATE"]);
            //    DEPARTURE_DATE = Convert.ToDateTime(dt.Rows[0]["DEPARTURE_DATE"]);
            //    status = dt.Rows[0]["STATUS"].ToString();
            //}
            return dt;
        }
        public string v;
        public void number()
        {
            if (!Regex.Match(v, "^[0-9]{4}-[0-9]{4}-[0-9]{4}$").Success)
            {

            }
            else
            {
                MessageBox.Show("enter numbers only");
            }

        }
        public DateTime arrivaldatee;
        public string arrivaltime;

        public void ins(string s)
        {
            DateTime arrivaldate = DateTime.Today;

            arrivaldatee = arrivaldate.Date;
            arrivaltime = arrivaldate.ToShortTimeString();
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@ROOM_NO", ROOM_NO);
            //list.AddSqlParameter("@ROOM_TARRIF", CHARGED_TARRIF);
            list.AddSqlParameter("@EXTRABED_ADULT", CHARGED_EADULT);
            list.AddSqlParameter("@EXTRABED_CHILD", CHARGED_ECHILD);
            //list.AddSqlParameter("@CHECKIN_ID", CHECKIN_ID);
            list.AddSqlParameter("@INSERT_DATE", arrivaldate);
            list.AddSqlParameter("@INSERT_TIME", arrivaltime);
           // list.AddSqlParameter("@ROOMCHANGEAMOUNT", "0.00");
            DbFunctions.ExecuteCommand<int>(s, list);

        }

        public void Night_Audit()
        {
            string s = null;
            //if (RESERVSTIONCHECKIN.p == 1)
            //{
            //    int count = roomno_res.Count;

            //    for (int i = 0; i < count; i++)
            //    {
            //        ROOM_NO = Convert.ToString(roomno_res[i]);
            //        ROOM_TYPE = roomcategory_res[i];
            //        s = "INSERT INTO night_audit (ROOM_NO,ROOM_TARRIF,EXTRABED_ADULT,EXTRABED_CHILD,CHECKIN_ID,INSERT_DATE,INSERT_TIME,NIGHT)"+
            //            " VALUES (@ROOM_NO,(select CHARGED_TARRIF FROM CHECKIN WHERE ROOM_NO='" + ROOM_NO + "' AND CHECK_OUT=0),@EXTRABED_ADULT,@EXTRABED_CHILD,"+
            //            "(SELECT CHECKIN_ID FROM CHECKIN WHERE ROOM_NO = @ROOM_NO AND CHECK_OUT !=1 ),@INSERT_DATE,"+
            //            "(select ARRIVAL_TIME FROM CHECKIN WHERE CHECK_OUT=0 AND ROOM_NO=@ROOM_NO),0)";
            //        ins(s);
            //    }
            //}
            //else
            //{
                s = "INSERT INTO night_audit (ROOM_NO,ROOM_TARRIF,EXTRABED_ADULT,EXTRABED_CHILD,CHECKIN_ID,INSERT_DATE,INSERT_TIME,NIGHT,GST)" +
                    " VALUES (@ROOM_NO,(select CHARGED_TARRIF FROM CHECKIN WHERE ROOM_NO='" + ROOM_NO + "' AND CHECK_OUT=0),@EXTRABED_ADULT,@EXTRABED_CHILD," +
                    "(SELECT CHECKIN_ID FROM CHECKIN WHERE ROOM_NO = @ROOM_NO AND CHECK_OUT !=1 ),@INSERT_DATE," +
                    "(select ARRIVAL_TIME FROM CHECKIN WHERE CHECK_OUT=0 AND ROOM_NO=@ROOM_NO),0,(select TAX FROM CHECKIN WHERE ROOM_NO='" + ROOM_NO + "' AND CHECK_OUT=0))";

            ins(s);

            //}
        }
        //reservatio  checkin column update 
        public void reservationcheckinupdate()
        {
            var list = new List<SqlParameter>();
            string s = "update RESERVATION set  CHECKIN =(SELECT CHECKIN_ID FROM CHECKIN WHERE RESERVATION_ID='" + RESERVATION_ID + "'  AND ROOM_NO='" + ROOM_NO + "'  ) WHERE RESERVATION_ID='" + RESERVATION_ID + "' ";
            DbFunctions.ExecuteCommand<int>(s, list);
        }
        public void advanceupdate()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@RESERVATION_ID", RESERVATION_ID);
            list.AddSqlParameter("@CHECKIN_ID", CHECKIN_ID);
            list.AddSqlParameter("@ROOM_NO", ROOM_NO);
            string S = "UPDATE ADVANCE SET CHECKIN_ID=@CHECKIN_ID,ROOM_NO=@ROOM_NO WHERE RESERVATION_ID ='" + RESERVATION_ID + "' AND ADVANCE = 0 "; //ROOM_NO ='" + ROOM_NO + "' 
            DbFunctions.ExecuteCommand<int>(S, list);
        }
        public void RESERVATIONINT()
        {
            var LIST = new List<SqlParameter>();
            string SS = "UPDATE RESERVATION SET RESERVATION=1 WHERE RESERVATION_ID ='" + RESERVATION_ID + "' ";
            DbFunctions.ExecuteCommand<int>(SS, LIST);
        }

        public void adavance()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@CHECKIN_ID", ID);
            string s1 = " UPDATE ADVANCE SET ADVANCE =0 WHERE ROOM_NO ='" + ROOM_NO + "' AND CHECKIN_ID='" + ss + "' ";
            DbFunctions.ExecuteCommand<int>(s1, list);

        }
        public void postcharges()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@CHECKIN_ID", ID);
            string post = "update POSTCHARGES SET POSTCHARGES=0 where ROOM_NO='" + ROOM_NO + "' AND CHECKIN_ID='" + ss + "'  ";
            DbFunctions.ExecuteCommand<int>(post, list);

        }
        public string REPRINTDATE { get; set; }
        public DataTable REPRRINT1()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@CHECKIN_ID", CHECKIN_ID);
            string s = "SELECT CHECKIN_ID,MOBILE_NO,GUEST_NAME,ROOM_NO,INSERT_DATE,(select ARRIVAL_DATE from CHECKIN where CHECKIN_ID = c.CHECKIN_ID AND CHECK_OUT=1) As ARRIVAL_DATE from CHECKOUT c where INSERT_DATE ='" + REPRINTDATE+"'";
            DataTable SRIKAR = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (SRIKAR.Rows.Count == 0)
            {
                //FIRSTNAME = "";
                //MOBILE_NUMBER = int.Parse("");
                //ARRIVAL_DATE = Convert.ToDateTime("");
            }
            else
            {
                CHECKIN_ID = Convert.ToInt32(SRIKAR.Rows[0]["CHECKIN_ID"]);
                FIRSTNAME = SRIKAR.Rows[0]["GUEST_NAME"].ToString();
                ARRIVAL_DATE = DateTime.Parse(SRIKAR.Rows[0]["INSERT_DATE"].ToString());
            }
            return SRIKAR;
        }
        public DataTable REPRRINT2()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@CHECKIN_ID", CHECKIN_ID);
            string s = "SELECT CHECKIN_ID,MOBILE_NO,GUEST_NAME,ROOM_NO,INSERT_DATE,(SELECT ARRIVAL_DATE from CHECKIN where CHECKIN_ID = '" + CHECKIN_ID + "' and CHECK_OUT = 1) As ARRIVAL_DATE FROM CHECKOUT WHERE CHECKIN_ID ='" + CHECKIN_ID + "'";
            DataTable SRIKAR = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (SRIKAR.Rows.Count == 0)
            {
                //FIRSTNAME = "";
                //MOBILE_NUMBER = int.Parse("");
                //ARRIVAL_DATE = Convert.ToDateTime("");
            }
            else
            {
                CHECKIN_ID = Convert.ToInt32(SRIKAR.Rows[0]["CHECKIN_ID"]);
                FIRSTNAME = SRIKAR.Rows[0]["GUEST_NAME"].ToString();
                ARRIVAL_DATE = DateTime.Parse(SRIKAR.Rows[0]["INSERT_DATE"].ToString());
            }
            return SRIKAR;
        }
        public string PHONE { get; set; }
        public DataTable checkin()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT SUFFIX,FIRSTNAME,LASTNAME,ADDRESS,ZIP,CITY,STATE,COUNTRY,MOBILE_NO,EMAIL,ID_TYPE,ID_DATA,COMPANY_NAME,COMPANY_ADDRESS FROM CHECKIN WHERE CHECK_OUT=1 AND MOBILE_NO='" + PHONE + "'";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;

        }
        public DataTable CompanyName()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT COMPANY_NAME FROM COMPANYMASTER";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable CompanyAddress()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT CITY FROM COMPANYMASTER";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable Plancode()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT PLAN_CODE FROM PLANCODES";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable PLANN()
        {
            var LIST = new List<SqlParameter>();
            string S = "SELECT PLAN_CODE FROM ROOMMASTER_PLAN WHERE ROOM_NO=609";
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(S, LIST);
            return DT;
        }

        public DataTable getCheckinId()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT CHECKIN_ID,MOBILE_NO,FIRSTNAME FROM CHECKIN WHERE CHECK_OUT = 0 And ROOM_NO = '" + ROOM_NO +"'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {
                CHECKIN_ID = 0;
                MOBILE_NUMBER = 0;
                FIRSTNAME = "";
            }
            else
            {
                CHECKIN_ID = Convert.ToInt32(dt.Rows[0]["CHECKIN_ID"]);
                FIRSTNAME = dt.Rows[0]["FIRSTNAME"].ToString();
                MOBILE_NUMBER = Convert.ToInt64(dt.Rows[0]["MOBILE_NO"]);
            }
            return dt;
        }
    }
}
