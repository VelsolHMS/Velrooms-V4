using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using HMS.View.Masters;
using HMS.View.Operations;

namespace HMS.Model.Operations
{
    public class gruopcheckin
    {
        public string RESERVATION_ID { get; set; }
        public string GROUP_CHECKINID { get; set; }
        public string ROOM_CATEGORY { get; set; }
        public string ARRIVAL_DATE { get; set; }
        public string ARRIVAL_TIME { get; set; }
        public string SUFFIX { get; set; }
        public string DEPARTURE_DATE { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string ADDRESS { get; set; }
        public string ZIP { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string COUNTRY { get; set; }
        public string ID_PROOF { get; set; }
        public string ID_DATA { get; set; }
        public string MOBILE_NO { get; set; }
        public string EMAIL { get; set; }
        public string PAX { get; set; }
        public string PAXADULT { get; set; }
        public string PAXCHILD { get; set; }
        public string TEXTRABED { get; set; }
        public string TAX { get; set; }
        public string ADULT { get; set; }
        public string CHILD { get; set; }
        public decimal RACK_TARIFF { get; set; }
        public Decimal RACK_ADULT { get; set; }
        public Decimal RACK_CHILD { get; set; }
        public Decimal CHARGED_TARIFF { get; set; }
        public string CHARGED_ADULT { get; set; }
        public string CHARGED_CHILD { get; set; }
        public string STATUS { get; set; }
        public string SCANTRY { get; set; }
        public string ROOMS { get; set; }
        public string ROOM_NO { get; set; }
        public Decimal SINGLERATE { get; set; }
        public Decimal DOUBLERATE { get; set; }
        public Decimal TRIPLERATE { get; set; }
        public Decimal QUADRATE { get; set; }
        public string EXTRABEDADULT { get; set; }
        public string EXTRABEDCHILD { get; set; }
        public string PLANCODE { get; set; }
        public string MARKET { get; set; }
        public string IMAGE { get; set; }
        public string INSERT_BY { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public decimal rsingle, rdouble, rtriple, rquad, rextraadult, rextrachild;
        public int a = 0;

        public void Insert1()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@RESERVATION_ID", RESERVATION_ID);
            list.AddSqlParameter("@ROOM_NO", ROOM_NO);
            list.AddSqlParameter("@ROOM_CATEGORY", ROOM_CATEGORY);
            list.AddSqlParameter("@ARRIVAL_DATE", ARRIVAL_DATE);
            list.AddSqlParameter("@ARRIVAL_TIME", ARRIVAL_TIME);
            list.AddSqlParameter("@DEPARTURE_DATE", DEPARTURE_DATE);
            list.AddSqlParameter("@SUFFIX", SUFFIX);
            list.AddSqlParameter("@FIRSTNAME", FIRST_NAME);
            list.AddSqlParameter("@LASTNAME", LAST_NAME);
            list.AddSqlParameter("@ADDRESS", ADDRESS);
            list.AddSqlParameter("@ZIP", ZIP);
            list.AddSqlParameter("@CITY", CITY);
            list.AddSqlParameter("@STATE", STATE);
            list.AddSqlParameter("@COUNTRY", COUNTRY);
            list.AddSqlParameter("@MOBILE_NO", MOBILE_NO);
            list.AddSqlParameter("@EMAIL", EMAIL);
            list.AddSqlParameter("@ID_TYPE", ID_PROOF);
            list.AddSqlParameter("@ID_DATA", ID_DATA);
            list.AddSqlParameter("@PAX", PAX);
            list.AddSqlParameter("@PAX_ADULT", PAXADULT);
            list.AddSqlParameter("@PAX_CHILD", PAXCHILD);
            list.AddSqlParameter("@EXTRA_BED", TEXTRABED);
            list.AddSqlParameter("@EXTRA_ADULT", EXTRABEDADULT);
            list.AddSqlParameter("@EXTRA_CHILD", EXTRABEDCHILD);
            list.AddSqlParameter("@PLANCODE", PLANCODE);
            list.AddSqlParameter("@TAX", TAX);
            list.AddSqlParameter("@RACK_TARRIF", RACK_TARIFF);
            list.AddSqlParameter("@RACK_EBED_ADULT", RACK_ADULT);
            list.AddSqlParameter("@RACK_EBED_CHILD", RACK_CHILD);
            list.AddSqlParameter("@CHARGED_TARRIF", CHARGED_TARIFF);
            list.AddSqlParameter("@CHARGED_EBED_ADULT", CHARGED_ADULT);
            list.AddSqlParameter("@CHARGED_EBED_CHILD", CHARGED_CHILD);
            list.AddSqlParameter("@MARKET_SEGMENT", MARKET);
            list.AddSqlParameter("@SCANTY_BAGGAGE", SCANTRY);
            list.AddSqlParameter("@STATUS", STATUS);
            INSERT_BY = login.u;
            list.AddSqlParameter("@INSERT_BY", INSERT_BY);
            INSERT_DATE = DateTime.Today.Date;
            list.AddSqlParameter("@INSERT_DATE", INSERT_DATE);
            list.AddSqlParameter("@GROUP_CHECKINID", GROUP_CHECKINID);
            list.AddSqlParameter("@CHECK_OUT", "0");
            list.AddSqlParameter("@PHOTO", IMAGE);
            string s = "INSERT INTO CHECKIN (RESERVATION_ID,ROOM_NO,ROOM_CATEGORY,ARRIVAL_DATE,ARRIVAL_TIME,DEPARTURE_DATE,SUFFIX,FIRSTNAME,LASTNAME,ADDRESS,ZIP,CITY,STATE,COUNTRY," +
                       "MOBILE_NO,EMAIL,ID_TYPE,ID_DATA,PAX,PAX_ADULT,PAX_CHILD,EXTRA_BED,EXTRA_ADULT,EXTRA_CHILD,PLANCODE,TAX,RACK_TARRIF,RACK_EBED_ADULT,RACK_EBED_CHILD,PHOTO," +
                       "CHARGED_TARRIF,CHARGED_EBED_ADULT,CHARGED_EBED_CHILD,INSERT_BY,INSERT_DATE,MARKET_SEGMENT,SCANTY_BAGGAGE,STATUS,GROUP_CHECKINID,CHECK_OUT) " +
                       "VALUES (@RESERVATION_ID,@ROOM_NO,@ROOM_CATEGORY,@ARRIVAL_DATE,@ARRIVAL_TIME,@DEPARTURE_DATE,@SUFFIX,@FIRSTNAME," +
                       "@LASTNAME,@ADDRESS,@ZIP,@CITY,@STATE,@COUNTRY," +
                       "@MOBILE_NO,@EMAIL,@ID_TYPE,@ID_DATA,@PAX,@PAX_ADULT,@PAX_CHILD,@EXTRA_BED,@EXTRA_ADULT," +
                       "@EXTRA_CHILD,@PLANCODE,@TAX,@RACK_TARRIF,@RACK_EBED_ADULT,@RACK_EBED_CHILD,@PHOTO," +
                       "@CHARGED_TARRIF,@CHARGED_EBED_ADULT,@CHARGED_EBED_CHILD,@INSERT_BY,@INSERT_DATE,@MARKET_SEGMENT," +
                       "@SCANTY_BAGGAGE,@STATUS,@GROUP_CHECKINID,@CHECK_OUT)";
            DbFunctions.ExecuteCommand<int>(s, list);
        }

        public int Group_Checkinid()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT MAX(GROUP_CHECKINID) FROM CHECKIN";
            object gci = DbFunctions.ExecuteCommand<object>(s, list);
            if (gci == System.DBNull.Value)
            {

                a = 1;
            }

            else
            {
                a = Convert.ToInt32(gci);
                a = a + 1;
            }
            return a;
        }

        public void NIGHTT(string S)
        {
            DateTime dt = DateTime.Today;

            //ARRIVAL_TIME = dt.ToShortDateString();

            var list = new List<SqlParameter>();
            list.AddSqlParameter("@gid", GROUP_CHECKINID);
            list.AddSqlParameter("@roomno", ROOM_NO);
            list.AddSqlParameter("@roomtarrif", CHARGED_TARIFF);
            list.AddSqlParameter("@eadult", CHARGED_ADULT);
            list.AddSqlParameter("@echild", CHARGED_CHILD);
            list.AddSqlParameter("@insert", dt.ToShortDateString());
            list.AddSqlParameter("@time", ARRIVAL_TIME);
            list.AddSqlParameter("@night", 0);
            DbFunctions.ExecuteCommand<int>(S, list);
        }
        public void Night_Insert()
        {
            string S = null;
            DateTime dt = DateTime.Today;
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@gid", GROUP_CHECKINID);
            list.AddSqlParameter("@roomno", ROOM_NO);
            list.AddSqlParameter("@roomtarrif", CHARGED_TARIFF);
            list.AddSqlParameter("@eadult", CHARGED_ADULT);
            list.AddSqlParameter("@echild", CHARGED_CHILD);
            list.AddSqlParameter("@insert", dt.ToShortDateString());
            list.AddSqlParameter("@time", ARRIVAL_TIME);
            list.AddSqlParameter("@night", 0);
            list.AddSqlParameter("@TAX", TAX);
            S = "INSERT INTO NIGHT_AUDIT (ROOM_NO,ROOM_TARRIF,EXTRABED_ADULT,EXTRABED_CHILD,CHECKIN_ID,INSERT_DATE,INSERT_TIME,NIGHT,GST) " +
                           "VALUES (@roomno,@roomtarrif,@eadult,@echild,(SELECT CHECKIN_ID FROM CHECKIN WHERE GROUP_CHECKINID = @gid AND ROOM_NO=@roomno AND CHECK_OUT=0),@insert,@time,@night,@TAX)";
            DbFunctions.ExecuteCommand<int>(S, list);
        }
        public DataTable GetAdvance()
        {
            //select* from ADVANCE where RESERVATION_ID = ''
            var list = new List<SqlParameter>();
            string s = "Select * from ADVANCE where RESERVATION_ID = '" + RESERVATION_ID + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable GetAdvanceAmount()
        {
            //select* from ADVANCE where RESERVATION_ID = ''
            var list = new List<SqlParameter>();
            string s = "Select Sum(AMOUNT_RECEIVED) as AMOUNT_RECEIVED from ADVANCE where RESERVATION_ID = '" + RESERVATION_ID + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public string SplitedAdvance { get; set; }
        public string CheckinId { get; set; }
        public void AdvanceUpdate()
        {
            //Update ADVANCE set CHECKIN_ID = '',ADVANCE_FOR = 'ROOM',ROOM_NO = '',AMOUNT_RECEIVED = '',UPDATE_BY = '',UPDATE_DATE = '' where RESERVATION_ID = ''
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@SplitedAdvance", SplitedAdvance);
            list.AddSqlParameter("@ROOM_NO", ROOM_NO);
            list.AddSqlParameter("@UPDATE_BY", login.u);
            list.AddSqlParameter("@UPDATE_DATE", DateTime.Today.Date);
            string S = "Update ADVANCE set CHECKIN_ID = (Select CHECKIN_ID from CHECKIN where ROOM_NO = @ROOM_NO and CHECK_OUT = 0),ADVANCE_FOR = 'ROOM',ROOM_NO = @ROOM_NO,AMOUNT_RECEIVED = @SplitedAdvance,UPDATE_BY = @UPDATE_BY,UPDATE_DATE = @UPDATE_DATE where RESERVATION_ID = '" + RESERVATION_ID + "'";
            DbFunctions.ExecuteCommand<int>(S, list);
        }
        public void InsertAdvance()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@SplitedAdvance", SplitedAdvance);
            list.AddSqlParameter("@RESERVATION_ID", RESERVATION_ID);
            list.AddSqlParameter("@ROOM_NO", ROOM_NO);
            string S = "INSERT INTO ADVANCE (CHECKIN_ID,RESERVATION_ID,ADVANCE_FOR,ROOM_NO,PAYTYPE,CURRENCY_CODE,AMOUNT_RECEIVED,PARTICULARS,TRANSACTION_NO,CHEQUE_NO,ADVANCE,INSERT_BY,INSERT_DATE)"+
                    "VALUES((Select CHECKIN_ID from CHECKIN where ROOM_NO = @ROOM_NO AND CHECK_OUT = 0),@RESERVATION_ID,'ROOM',@ROOM_NO," +
                    "(Select distinct PAYTYPE from ADVANCE where RESERVATION_ID = @RESERVATION_ID AND ADVANCE = 0),(Select distinct CURRENCY_CODE from ADVANCE where RESERVATION_ID = @RESERVATION_ID AND ADVANCE = 0)," +
                    "@SplitedAdvance,(Select distinct PARTICULARS from ADVANCE where RESERVATION_ID = @RESERVATION_ID AND ADVANCE = 0),(Select distinct TRANSACTION_NO from ADVANCE where RESERVATION_ID = @RESERVATION_ID AND ADVANCE = 0)," +
                    "(Select distinct CHEQUE_NO from ADVANCE where RESERVATION_ID = @RESERVATION_ID AND ADVANCE = 0),0,(Select distinct INSERT_BY from ADVANCE where RESERVATION_ID = @RESERVATION_ID AND ADVANCE = 0),(Select distinct INSERT_DATE from ADVANCE where RESERVATION_ID = @RESERVATION_ID AND ADVANCE = 0))";
            DbFunctions.ExecuteCommand<int>(S, list);
        }
        public void coloruppdate()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("roomno", ROOM_NO);
            string s = "UPDATE ROOMMASTER SET BACKGROUND_COLOR = 'Orange' where ROOM_NO=@roomno ";
            DbFunctions.ExecuteCommand<int>(s,list);
        }

        public string RESERID;
        public void Updatereservtion()
        {
            var list = new List<SqlParameter>();
            string s = "Update RESERVATION SET RESERVATION=1 WHERE RESERVATION_ID='" + RESERID + "'";
            DbFunctions.ExecuteCommand<int>(s, list);
        }
        public DataTable states()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT STATE FROM states";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }

        public void roomcategory()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@room",ROOM_NO);
            string s = "SELECT ROOM_CATEGORY FROM ROOMMASTER WHERE ROOM_NO = @room";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if(dt.Rows.Count == 0)
            {
                ROOM_CATEGORY = "";
            }
            else
            {
                ROOM_CATEGORY = dt.Rows[0]["ROOM_CATEGORY"].ToString();
            }
        }
        public void Getpax()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@room", ROOM_NO);
            string s = "SELECT MAX_PAX FROM ROOMMASTER WHERE ROOM_NO = @room";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if(dt.Rows.Count == 0)
            {
                PAX = "0.00";
            }
            else
            {
                PAX =dt.Rows[0]["MAX_PAX"].ToString();
            }
        }

        public void Getracktarrif()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@room", ROOM_NO);
            string s = "SELECT * FROM ROOMMASTER WHERE ROOM_NO =@room";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if(dt.Rows.Count == 0)
            {
                SINGLERATE = decimal.Parse("0.00");
                DOUBLERATE = decimal.Parse("0.00");
                TRIPLERATE = decimal.Parse("0.00");
                QUADRATE = decimal.Parse("0.00");
                EXTRABEDADULT = "0.00";
            }
            else
            {
                rsingle = decimal.Parse(dt.Rows[0]["SINGLERATE_TARRIF"].ToString());
                rdouble = decimal.Parse(dt.Rows[0]["DOUBLERATE_TARRIF"].ToString());
                rtriple = decimal.Parse(dt.Rows[0]["TRIPLERATE_TARRIF"].ToString());
                rquad = decimal.Parse(dt.Rows[0]["QUADRATE_TARRIF"].ToString());
                rextraadult = decimal.Parse(dt.Rows[0]["EXTRABED_ADULT"].ToString());
                rextrachild = decimal.Parse(dt.Rows[0]["EXTRABED_CHILD"].ToString());

                SINGLERATE = Convert.ToDecimal(Math.Round(rsingle, 2, MidpointRounding.AwayFromZero));
                DOUBLERATE = Convert.ToDecimal(Math.Round(rdouble, 2, MidpointRounding.AwayFromZero));
                TRIPLERATE = Convert.ToDecimal(Math.Round(rtriple, 2, MidpointRounding.AwayFromZero));
                QUADRATE = Convert.ToDecimal(Math.Round(rquad, 2, MidpointRounding.AwayFromZero));
                EXTRABEDADULT = Convert.ToString(Math.Round(rextraadult, 2, MidpointRounding.AwayFromZero));
                EXTRABEDCHILD = Convert.ToString(Math.Round(rextrachild, 2, MidpointRounding.AwayFromZero));
            }
        }

        public DataTable GetPlanCodes()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT NAME FROM PLANCODES";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }

        public void GetTax()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@room", ROOM_NO);
            list.AddSqlParameter("@amount", RACK_TARIFF);
            string s = "SELECT FACTOR FROM TAX_CODE WHERE FROM_AMOUNT < @amount AND TO_AMOUNT > @amount";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if(dt.Rows.Count == 0)
            {
                TAX = "0.00";
            }
            else
            {
                TAX = dt.Rows[0]["FACTOR"].ToString();
            }
        }
        public static string plancode11;
        public DataTable placodeing()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT PLAN_CODE FROM PLANCODES WHERE NAME='"+PLANCODE+"'";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if(d.Rows.Count == 0)
            {
                plancode11 = "0.00";
            }
            else
            {
                plancode11 = d.Rows[0]["PLAN_CODE"].ToString();
            }
            return d;
        }

        public Decimal SINGLERATE_PLAN, DOUBLERATE_PLAN, TRIPLERATE_PLAN, QUADRATE_PLAN, COMMON_PLAN;
      
        public DataTable plansselect()
        {
            var listParams = new List<SqlParameter>();
            listParams.AddSqlParameter("@PLAN_CODE", plancode11);
            listParams.AddSqlParameter("@ROOM_NO", ROOM_NO);
            String STR = "SELECT CONVERT(decimal(17,2),SINGLE_PLAN) AS SINGLE_PLAN,CONVERT(decimal(17,2),DOUBLE_PLAN) AS DOUBLE_PLAN,CONVERT(decimal(17,2),TRIPLE_PLAN) AS TRIPLE_PLAN,CONVERT(decimal(17,2),QUAD_PLAN) AS QUAD_PLAN,CONVERT(decimal(17,2),COMMON_PLAN) AS COMMON_PLAN FROM ROOMMASTER_PLAN WHERE ROOM_NO=@ROOM_NO AND PLAN_CODE=@PLAN_CODE";
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(STR, listParams);
            if (DT.Rows.Count == 0)
            {
                SINGLERATE_PLAN = decimal.Parse("0.00");
                DOUBLERATE_PLAN = decimal.Parse("0.00");
                TRIPLERATE_PLAN = decimal.Parse("0.00");
                QUADRATE_PLAN = decimal.Parse("0.00");
                COMMON_PLAN = decimal.Parse("0.00");
            }
            else
            {
                for (int D = 0; D < DT.Rows.Count; D++)
                {
                    if (Convert.ToDecimal(DT.Rows[D]["SINGLE_PLAN"]) == 0)
                    {
                        SINGLERATE_PLAN = decimal.Parse("0.00");
                    }
                    else
                    {
                        SINGLERATE_PLAN = Convert.ToDecimal(DT.Rows[D]["SINGLE_PLAN"]);

                    }
                    if (Convert.ToDecimal(DT.Rows[D]["DOUBLE_PLAN"]) == 0)
                    {
                        DOUBLERATE_PLAN = Convert.ToDecimal("0.00");
                    }
                    else
                    {
                        DOUBLERATE_PLAN = Convert.ToDecimal(DT.Rows[D]["DOUBLE_PLAN"]);
                    }
                    if (Convert.ToDecimal(DT.Rows[D]["TRIPLE_PLAN"]) == 0)
                    {
                        TRIPLERATE_PLAN = Convert.ToDecimal("0.00");
                    }
                    else
                    {
                        TRIPLERATE_PLAN = Convert.ToDecimal(DT.Rows[D]["TRIPLE_PLAN"]);
                    }
                    if (Convert.ToDecimal(DT.Rows[D]["QUAD_PLAN"]) == 0)
                    {
                        QUADRATE_PLAN = Convert.ToDecimal("0.00");
                    }
                    else
                    {
                        QUADRATE_PLAN = Convert.ToDecimal(DT.Rows[D]["QUAD_PLAN"]);
                    }
                    if (Convert.ToDecimal(DT.Rows[D]["COMMON_PLAN"]) == 0)
                    {
                        COMMON_PLAN = Convert.ToDecimal("0.00");
                    }
                    else
                    {
                        COMMON_PLAN = Convert.ToDecimal(DT.Rows[D]["COMMON_PLAN"]);
                    }

                }
                
            }
            return DT;
        }
    }
}
