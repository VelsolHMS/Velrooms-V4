using DAL;
using HMS.View.Masters;
using HMS.View.Operations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model
{
    public class ROOMCHANGE1
    {
        public string ROOM_CHANGE { get; set; }
        public string MAINROOM { get; set; }
        public string TRANSFERROOM { get; set; }
        public string FROM_GUESTNAME { get; set; }
        public DateTime FROM_ARRIVALDATE { get; set; }
        public DateTime FROM_DEPARTUREDATE { get; set; }
        public string FROM_GUESTSTATUS { get; set; }
        public string TO_GUESTNAME { get; set; }
        public DateTime TO_ARRIVALDATE { get; set; }
        public DateTime TO_DEPARTUREDATE { get; set; }
        public string TO_GUESTSTATUS { get; set; }
        public string RM_CHECKINID { get; set; }
        public string RM_TOCHECKINID { get; set; }

        //11/15/2017
        // public string USER_NAME { get; set; }
        public string INSERT_BY { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime UPDTAE_DATE { get; set; }

        public void INSERT()
        {
            string ss = "insert into ROOM_CHANGE(ROOM_CHANGE,MAIN_ROOM,TRANSFER_ROOM,FROM_GUESTNAME,FROM_ARRIVAL_DATE,FROM_DEPARTURE_DATE,FROM_GUESTSTATUS,INSERT_BY,INSERT_DATE)"+
                " Values(@ROOM_CHANGE,@MAIN_ROOM,@TRANSFER_ROOM,@FROM_GUESTNAME,@FROM_ARRIVAL_DATE,@FROM_DEPARTURE_DATE,@FROM_GUESTSTATUS,@INSERT_BY,@INSERT_DATE) ";
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@ROOM_CHANGE", ROOM_CHANGE);
            LIST.AddSqlParameter("@MAIN_ROOM", MAINROOM);
            LIST.AddSqlParameter("@TRANSFER_ROOM", TRANSFERROOM);
            LIST.AddSqlParameter("@FROM_GUESTNAME", FROM_GUESTNAME);
            LIST.AddSqlParameter("@FROM_ARRIVAL_DATE", FROM_ARRIVALDATE);
            LIST.AddSqlParameter("@FROM_DEPARTURE_DATE", FROM_DEPARTUREDATE);
            LIST.AddSqlParameter("@FROM_GUESTSTATUS", FROM_GUESTSTATUS);
            INSERT_BY = login.u;
            INSERT_DATE = DateTime.Today;
            LIST.AddSqlParameter("@INSERT_BY", INSERT_BY);
            LIST.AddSqlParameter("@INSERT_DATE", INSERT_DATE);
            
            DbFunctions.ExecuteCommand<int>(ss, LIST);
            string up = "UPDATE ROOMMASTER SET BACKGROUND_COLOR='Blue' WHERE ROOM_NO=@ROOMNO";
            var li = new List<SqlParameter>();
            li.AddSqlParameter("@ROOMNO", MAINROOM);
            DAL.DbFunctions.ExecuteCommand<int>(up, li);
        }
        public void TransferInsert()
        {
            var List = new List<SqlParameter>();
            List.AddSqlParameter("@ROOM_CHANGE", ROOM_CHANGE);
            List.AddSqlParameter("@MAINROOM", MAINROOM);
            List.AddSqlParameter("@TRANSFERROOM", TRANSFERROOM);
            List.AddSqlParameter("@FROM_GUESTNAME", FROM_GUESTNAME);
            List.AddSqlParameter("@FROM_ARRIVAL_DATE", FROM_ARRIVALDATE);
            List.AddSqlParameter("@FROM_DEPARTURE_DATE", FROM_DEPARTUREDATE);
            List.AddSqlParameter("@FROM_GUESTSTATUS", FROM_GUESTSTATUS);
            List.AddSqlParameter("@RM_CHECKINID", RM_CHECKINID);
            List.AddSqlParameter("@INSERT_BY", login.u);
            List.AddSqlParameter("@INSERT_DATE", DateTime.Today.Date);
            string ss = "INSERT INTO ROOM_CHANGE(ROOM_CHANGE,MAIN_ROOM,TRANSFER_ROOM,FROM_GUESTNAME,FROM_GUESTSTATUS,FROM_ARRIVAL_DATE,FROM_DEPARTURE_DATE,INSERT_BY,INSERT_DATE,CHECKIN_ID)" +
                        "Values(@ROOM_CHANGE,@MAINROOM,@TRANSFERROOM,@FROM_GUESTNAME,@FROM_GUESTSTATUS,@FROM_ARRIVAL_DATE,@FROM_DEPARTURE_DATE,@INSERT_BY,@INSERT_DATE,@RM_CHECKINID) ";
            DbFunctions.ExecuteCommand<int>(ss, List);
        }
        public void SwapInsert()
        {

        }
        public DataTable GetRoomDetails()
        {
            var List = new List<SqlParameter>();
            List.AddSqlParameter("@MAINROOM", MAINROOM);
            string s = "SELECT * from CHECKIN where CHECK_OUT = 0 AND ROOM_NO = @MAINROOM ";
            DataTable D = DbFunctions.ExecuteCommand<DataTable>(s, List);
            return D;
        }
        public decimal Rm_ChargedTariff { get; set; }
        public string Rm_GST { get; set; }
        public string Rm_RoomCategory { get; set; }
        public void UpdateNightAudit()
        {
            var List = new List<SqlParameter>();
            List.AddSqlParameter("@TRANSFERROOM", TRANSFERROOM);
            //List.AddSqlParameter("@Rm_ChargedTariff", Rm_ChargedTariff);
            List.AddSqlParameter("@RM_CHECKINID", RM_CHECKINID);
            //List.AddSqlParameter("@Rm_GST", Rm_GST);
            string s = "Update night_audit set ROOM_NO = @TRANSFERROOM where CHECKIN_ID = @RM_CHECKINID";//, GST = '@Rm_GST'
            DbFunctions.ExecuteCommand<DataTable>(s, List);
        }
        public decimal GetTariff()
        {
            decimal tariff = 0;
            var List = new List<SqlParameter>();
            List.AddSqlParameter("@TRANSFERROOM", TRANSFERROOM);
            string s = "SELECT SINGLERATE_TARRIF,ROOM_CATEGORY from ROOMMASTER where ROOM_NO = @TRANSFERROOM";
            DataTable D = DbFunctions.ExecuteCommand<DataTable>(s, List);
            if(D.Rows.Count == 0 || D.Rows.Count > 1)
            {
                tariff = 0;
                Rm_RoomCategory = "";
            }
            else 
            {
                if (D.Rows[0]["SINGLERATE_TARRIF"].ToString() == null || D.Rows[0]["SINGLERATE_TARRIF"].ToString() == "")
                {
                    tariff = 0;
                }
                else
                {
                    tariff = Convert.ToDecimal(D.Rows[0]["SINGLERATE_TARRIF"]);
                }
                if (D.Rows[0]["ROOM_CATEGORY"].ToString() == null || D.Rows[0]["ROOM_CATEGORY"].ToString() == "")
                {
                    Rm_RoomCategory = "";
                }
                else
                {
                    Rm_RoomCategory = D.Rows[0]["ROOM_CATEGORY"].ToString();
                }
            }
            return tariff;
        }
        public void UpdateAdvance()
        {
            var List = new List<SqlParameter>();
            List.AddSqlParameter("@TRANSFERROOM", TRANSFERROOM);
            List.AddSqlParameter("@RM_CHECKINID", RM_CHECKINID);
            List.AddSqlParameter("@INSERT_BY", login.u);
            List.AddSqlParameter("@INSERT_DATE", DateTime.Today.Date);
            string s = "Update ADVANCE set ROOM_NO = @TRANSFERROOM, UPDATE_BY = @INSERT_BY, UPDATE_DATE = @INSERT_DATE where CHECKIN_ID = @RM_CHECKINID AND ADVANCE = 0";
            DbFunctions.ExecuteCommand<DataTable>(s, List);
        }
        public void UpdatePostCharges()
        {
            var List = new List<SqlParameter>();
            List.AddSqlParameter("@TRANSFERROOM", TRANSFERROOM);
            List.AddSqlParameter("@RM_CHECKINID", RM_CHECKINID);
            List.AddSqlParameter("@INSERT_BY", login.u);
            List.AddSqlParameter("@INSERT_DATE", DateTime.Today.Date);
            string s = "Update POSTCHARGES set ROOM_NO = @TRANSFERROOM, UPDATE_BY = @INSERT_BY, UPDATE_DATE = @INSERT_DATE where CHECKIN_ID = @RM_CHECKINID AND POSTCHARGES = 0";
            DbFunctions.ExecuteCommand<DataTable>(s, List);
        }
        public void UpdateDiscount()
        {
            var List = new List<SqlParameter>();
            List.AddSqlParameter("@TRANSFERROOM", TRANSFERROOM);
            List.AddSqlParameter("@RM_CHECKINID", RM_CHECKINID);
            List.AddSqlParameter("@INSERT_BY", login.u);
            List.AddSqlParameter("@INSERT_DATE", DateTime.Today.Date);
            string s = "Update DISCOUNT set ROOM_NO = @TRANSFERROOM, UPDATE_BY = @INSERT_BY, UPDATE_DATE = @INSERT_DATE where CHECKIN_ID = @RM_CHECKINID AND DISCOUNT = 0";
            DbFunctions.ExecuteCommand<DataTable>(s, List);
        }
        public void UpdateMRColor()
        {
            var List = new List<SqlParameter>();
            List.AddSqlParameter("@MAINROOM", MAINROOM);
            string s = "Update ROOMMASTER set BACKGROUND_COLOR = 'Blue' where ROOM_NO = @MAINROOM";
            DbFunctions.ExecuteCommand<DataTable>(s, List);
        }
        public void UpdateTRColor()
        {
             var List = new List<SqlParameter>();
            List.AddSqlParameter("@TRANSFERROOM", TRANSFERROOM);
            string s = "Update ROOMMASTER set BACKGROUND_COLOR = 'Orange' where ROOM_NO = @TRANSFERROOM";
            DbFunctions.ExecuteCommand<DataTable>(s, List);
        }
        public void UpdatecheckinDetails()
        {
            var List = new List<SqlParameter>();
            List.AddSqlParameter("@TRANSFERROOM", TRANSFERROOM);
            List.AddSqlParameter("@Rm_ChargedTariff", Rm_ChargedTariff);
            List.AddSqlParameter("@RM_CHECKINID", RM_CHECKINID);
            List.AddSqlParameter("@Rm_RoomCategory", Rm_RoomCategory);
            List.AddSqlParameter("@Rm_GST", Rm_GST);
            List.AddSqlParameter("@INSERT_BY", login.u);
            List.AddSqlParameter("@INSERT_DATE", DateTime.Today.Date);
            string s = "Update CHECKIN set ROOM_NO = @TRANSFERROOM, ROOM_CATEGORY = @Rm_RoomCategory, tax = @Rm_GST, RACK_TARRIF = @Rm_ChargedTariff, CHARGED_TARRIF = @Rm_ChargedTariff, UPDATE_BY = @INSERT_BY, UPDATE_DATE = @INSERT_DATE where CHECKIN_ID = @RM_CHECKINID";
            DbFunctions.ExecuteCommand<DataTable>(s, List);
        }
        public static DateTime c;
        public DataTable INSERTDATENIGHT()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT INSERT_DATE FROM night_audit WHERE NIGHT=0 AND ROOM_NO='" + MAINROOM + "'";
            DataTable D = DbFunctions.ExecuteCommand<DataTable>(s,list);
            if(D.Rows.Count == 0)
            {
                c = DateTime.Today.Date;
            }
            else
            {
                c = DateTime.Parse(D.Rows[0]["INSERT_DATE"].ToString());
            }
            return D;
        }
        public DataTable count()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@INSERT_DATE",c);
            string s = "SELECT SUM(ROOM_TARRIF) AS ROOM_TARRIF FROM night_audit WHERE NIGHT=0 AND ROOM_NO='" + MAINROOM + "' ";
            DataTable d= DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
        public void swapinsert()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@MAIN_ROOM", MAINROOM);
            list.AddSqlParameter("@TRANSFER_ROOM", TRANSFERROOM);
            list.AddSqlParameter("@ROOM_CHANGE", ROOM_CHANGE);
            list.AddSqlParameter("@TO_GUESTNAME", TO_GUESTNAME);
            list.AddSqlParameter("@TO_GUESTSTATUS", TO_GUESTSTATUS);
            list.AddSqlParameter("@TO_ARRIVAL_DATE", TO_ARRIVALDATE);
            list.AddSqlParameter("@TO_DEPARTURE_DATE", TO_DEPARTUREDATE);
            list.AddSqlParameter("@FROM_GUESTNAME", FROM_GUESTNAME);
            list.AddSqlParameter("@FROM_ARRIVAL_DATE", FROM_ARRIVALDATE);
            list.AddSqlParameter("@FROM_DEPARTURE_DATE", FROM_DEPARTUREDATE);
            list.AddSqlParameter("@FROM_GUESTSTATUS", FROM_GUESTSTATUS);
            INSERT_BY = login.u;
            INSERT_DATE = DateTime.Today;
            list.AddSqlParameter("@INSERT_BY", INSERT_BY);
            list.AddSqlParameter("@INSERT_DATE", INSERT_DATE);
            string S = "INSERT INTO ROOM_CHANGE (MAIN_ROOM,TRANSFER_ROOM,ROOM_CHANGE,FROM_GUESTNAME,FROM_GUESTSTATUS,FROM_ARRIVAL_DATE,FROM_DEPARTURE_DATE,TO_GUESTNAME,TO_ARRIVAL_DATE,TO_DEPARTURE_DATE,TO_GUESTSTATUS,INSERT_BY,INSERT_DATE) Values(@MAIN_ROOM,@TRANSFER_ROOM,@ROOM_CHANGE,@FROM_GUESTNAME,@FROM_GUESTSTATUS,@FROM_ARRIVAL_DATE,@FROM_DEPARTURE_DATE,@TO_GUESTNAME,@TO_ARRIVAL_DATE,@TO_DEPARTURE_DATE,@TO_GUESTSTATUS,@INSERT_BY,@INSERT_DATE) ";
            DbFunctions.ExecuteCommand<int>(S, list);
        }

        public void Swapupdate()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@MAIN_ROOM", MAINROOM);
            list.AddSqlParameter("@TO_GUESTNAME", TO_GUESTNAME);
            list.AddSqlParameter("@TO_GUESTSTATUS", TO_GUESTSTATUS);
            list.AddSqlParameter("@TO_ARRIVAL_DATE", TO_ARRIVALDATE);
            list.AddSqlParameter("@TO_DEPARTURE_DATE", TO_DEPARTUREDATE);
            UPDATE_BY = login.u;
            UPDTAE_DATE = DateTime.Today;
            list.AddSqlParameter("@UPDATE_BY", UPDATE_BY);
            list.AddSqlParameter("@UPDATE_DATE", UPDTAE_DATE);
            string s = "UPDATE CHECKIN SET FIRSTNAME=@TO_GUESTNAME, STATUS=@TO_GUESTSTATUS,ARRIVAL_DATE=@TO_ARRIVAL_DATE, DEPARTURE_DATE=@TO_DEPARTURE_DATE,UPDATE_BY=@UPDATE_BY,UPDATE_DATE=@UPDATE_DATE WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0";
            DbFunctions.ExecuteCommand<int>(s, list);
        }
        public void Swapupdate1()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@TRANSFER_ROOM", TRANSFERROOM);
            list.AddSqlParameter("@FROM_GUESTNAME", FROM_GUESTNAME);
            list.AddSqlParameter("@FROM_ARRIVAL_DATE", FROM_ARRIVALDATE);
            list.AddSqlParameter("@FROM_DEPARTURE_DATE", FROM_DEPARTUREDATE);
            list.AddSqlParameter("@FROM_GUESTSTATUS", FROM_GUESTSTATUS);
            UPDATE_BY = login.u;
            UPDTAE_DATE = DateTime.Today;
            list.AddSqlParameter("@UPDATE_BY", UPDATE_BY);
            list.AddSqlParameter("@UPDATE_DATE", UPDTAE_DATE);
            string s = "UPDATE CHECKIN SET FIRSTNAME=@FROM_GUESTNAME, STATUS=@FROM_GUESTSTATUS,ARRIVAL_DATE=@FROM_ARRIVAL_DATE, DEPARTURE_DATE=@FROM_DEPARTURE_DATE,UPDATE_BY=@UPDATE_BY,UPDATE_DATE=@UPDATE_DATE WHERE ROOM_NO='" + TRANSFERROOM + "' AND CHECK_OUT=0";
            DbFunctions.ExecuteCommand<int>(s, list);
        }

        public void updateadvance()
        {
            var lt = new List<SqlParameter>();
            lt.AddSqlParameter("@MAIN_ROOM", MAINROOM);
            lt.AddSqlParameter("@TRANSFER_ROOM", TRANSFERROOM);
            string s = "update ADVANCE SET ROOM_NO='" + TRANSFERROOM + "',CHECKIN_ID=(SELECT CHECKIN_ID FROM CHECKIN WHERE ROOM_NO='" + TRANSFERROOM + "' AND CHECK_OUT=0 ) WHERE ROOM_NO='" + MAINROOM + "' AND ADVANCE=0 ";
            DbFunctions.ExecuteCommand<int>(s, lt);
        }
        public void updatepostcharges()
        {
            var lis = new List<SqlParameter>();
            lis.AddSqlParameter("@MAIN_ROOM", MAINROOM);
            lis.AddSqlParameter("@TRANSFER_ROOM", TRANSFERROOM);
            string s = "update POSTCHARGES SET ROOM_NO=@TRANSFER_ROOM,CHECKIN_ID=(SELECT CHECKIN_ID FROM CHECKIN WHERE ROOM_NO='" + TRANSFERROOM + "' AND CHECK_OUT=0) WHERE ROOM_NO='" + MAINROOM + "' AND POSTCHARGES=0 ";
            DbFunctions.ExecuteCommand<int>(s, lis);

        }
        public void DISCOUNTUPDATE()
        {
            var ist = new List<SqlParameter>();
            ist.AddSqlParameter("@MAIN_ROOM", MAINROOM);
            ist.AddSqlParameter("@TRANSFER_ROOM", TRANSFERROOM);
            string s = "update DISCOUNT SET ROOM_NO=@TRANSFER_ROOM,CHECKIN_ID=(SELECT CHECKIN_ID FROM CHECKIN WHERE ROOM_NO='" + TRANSFERROOM + "' AND CHECK_OUT=0) WHERE ROOM_NO='" + MAINROOM + "' AND DISCOUNT=0";
            DbFunctions.ExecuteCommand<int>(s, ist);
        }

        public void checkinupdate()
        {
            var l = new List<SqlParameter>();
            l.AddSqlParameter("@MAIN_ROOM", MAINROOM);
            string s = "update CHECKIN SET CHECK_OUT=1 WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0";
            DbFunctions.ExecuteCommand<int>(s, l);
        }
        public int CHECKINID;
        public static int CHECKIN;

        public DataTable checkinupdat()
        {
            var list = new List<SqlParameter>();
            string s = "Select CHECKIN_ID FROM CHECKIN WHERE ROOM_NO = '" + MAINROOM + "' AND CHECK_OUT=0 ";
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (DT.Rows.Count == 0)
            {
                CHECKINID = 0;
            }
            else
            {
                CHECKINID = int.Parse(DT.Rows[0]["CHECKIN_ID"].ToString());
                CHECKIN = CHECKINID;
            }
            return DT;
        }

        public void checkinnn()
        {
            var s = new List<SqlParameter>();
            s.AddSqlParameter("@MAIN_ROOM", MAINROOM);
            s.AddSqlParameter("@TRANSFER_ROOM", TRANSFERROOM);
            string r = "UPDATE CHECKIN SET ROOM_CATEGORY=(SELECT ROOM_CATEGORY FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),ARRIVAL_TIME=(SELECT ARRIVAL_TIME FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),SUFFIX=(SELECT SUFFIX FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),LASTNAME=(SELECT LASTNAME FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),ADDRESS=(SELECT ADDRESS FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),ZIP=(SELECT ZIP FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),CITY=(SELECT CITY FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),STATE=(SELECT STATE FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),COUNTRY=(SELECT COUNTRY FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),MOBILE_NO=(SELECT MOBILE_NO FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),EMAIL=(SELECT EMAIL FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),ID_TYPE=(SELECT ID_TYPE FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),ID_DATA=(SELECT ID_DATA FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),COMPANY_NAME=(SELECT COMPANY_NAME FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),COMPANY_ADDRESS=(SELECT COMPANY_ADDRESS FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),PLANCODE=(SELECT PLANCODE FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),TAX=(SELECT TAX FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0) WHERE ROOM_NO='" + TRANSFERROOM + "' AND CHECK_OUT=0 AND CHECKIN_ID='" + CHECKINID + "'";
            DbFunctions.ExecuteCommand<int>(r, s);
        }

        public void NIGHT_AUDIT()
        {
            var LISTS = new List<SqlParameter>();
            LISTS.AddSqlParameter("@MAIN_ROOM", MAINROOM);
            LISTS.AddSqlParameter("@TRANSFER_ROOM", TRANSFERROOM);
            string s = "update night_audit set ROOM_NO='" + TRANSFERROOM + "',CHECKIN_ID='" + CHECKINID + "' WHERE ROOM_NO='" + MAINROOM + "' AND NIGHT=0 ";
            DbFunctions.ExecuteCommand<int>(s, LISTS);
        }


        public int CHECKIN_ID { get; set; }
        public string ROOM_NO { get; set; }
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
        public long MOBILE_NUMBER { get; set; }
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
        public List<int> roomno_res { get; set; }
        public List<string> roomcategory_res { get; set; }
        public int RESERVATION_ID { get; set; }
        //11/15/2017
        //public string USER_NAME { get; set; }

        public String IMAGE { get; set; }
        public int CHECK_OUT { get; set; }



        public void insertcheckin()
        {

            var LIST = new List<SqlParameter>();

            LIST.AddSqlParameter("@RESERVATION_ID", RESERVATION_ID);
            LIST.AddSqlParameter("@ROOM_NO",TRANSFERROOM);
            LIST.AddSqlParameter("@ROOM_CATEGORY", ROOM_TYPE);
            LIST.AddSqlParameter("@ARRIVAL_DATE", FROM_ARRIVALDATE);
            LIST.AddSqlParameter("@ARRIVAL_TIME", ARRIVAL_TIME);
            LIST.AddSqlParameter("@DEPARTURE_DATE", FROM_DEPARTUREDATE);
            LIST.AddSqlParameter("@SUFFIX", SUFFIX);
            LIST.AddSqlParameter("@FIRSTNAME", FROM_GUESTNAME);
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
            string S = "INSERT INTO CHECKIN (RESERVATION_ID,ROOM_NO,ROOM_CATEGORY,ARRIVAL_DATE,ARRIVAL_TIME,DEPARTURE_DATE,SUFFIX,FIRSTNAME,LASTNAME,ADDRESS,ZIP,CITY,STATE,COUNTRY,MOBILE_NO,EMAIL,ID_TYPE,ID_DATA,COMPANY_NAME,COMPANY_ADDRESS,PAX,PAX_ADULT,PAX_CHILD,EXTRA_BED,EXTRA_ADULT,EXTRA_CHILD,PLANCODE,TAX,RACK_TARRIF,RACK_EBED_ADULT,RACK_EBED_CHILD,CHARGED_TARRIF,CHARGED_EBED_ADULT,CHARGED_EBED_CHILD,MARKET_SEGMENT,STATUS,SCANTY_BAGGAGE,INSERT_BY,INSERT_DATE,PHOTO,CHECK_OUT)" +
               "VALUES((SELECT RESERVATION_ID FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),@ROOM_NO," +
               "(SELECT ROOM_CATEGORY FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),@ARRIVAL_DATE," +
               "(SELECT ARRIVAL_TIME FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0 ),@DEPARTURE_DATE," +
               "(SELECT SUFFIX FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0 ),@FIRSTNAME," +
               "(SELECT LASTNAME FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0 )," +
               "(SELECT ADDRESS FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0 ),(SELECT ZIP FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0 )," +
               "(SELECT CITY FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),(SELECT STATE FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0)," +
               "(SELECT COUNTRY FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),(SELECT MOBILE_NO FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0)," +
               "(SELECT EMAIL FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0 ),(SELECT ID_TYPE FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0 )," +
              "(SELECT ID_DATA FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),(SELECT COMPANY_NAME FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0)," +
              "(SELECT COMPANY_ADDRESS FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),(SELECT PAX FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0)," +
              "(SELECT PAX_ADULT FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),(SELECT PAX_CHILD FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),(SELECT EXTRA_BED FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0)," +
              "(SELECT EXTRA_ADULT FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),(SELECT EXTRA_CHILD FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),(SELECT PLANCODE FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),(SELECT TAX FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),(SELECT SINGLERATE_TARRIF FROM ROOMMASTER WHERE ROOM_NO='" + TRANSFERROOM + "')," +
              "(SELECT RACK_EBED_ADULT FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),(SELECT RACK_EBED_CHILD FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0)," +
              "(SELECT SINGLERATE_TARRIF FROM ROOMMASTER WHERE ROOM_NO='" + TRANSFERROOM + "'),(SELECT CHARGED_EBED_ADULT FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),(SELECT CHARGED_EBED_CHILD FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0)," +
              "(SELECT MARKET_SEGMENT FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),(SELECT STATUS FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0)," +
              "(SELECT SCANTY_BAGGAGE FROM CHECKIN WHERE ROOM_NO='" + MAINROOM + "' AND CHECK_OUT=0),@INSERT_BY,@INSERT_DATE,@PHOTO,0)";
            DbFunctions.ExecuteCommand<int>(S, LIST);

        }

       public void night()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@ROOM_NO",TRANSFERROOM);
            string s = "INSERT INTO night_audit(ROOM_NO,ROOM_TARRIF,EXTRABED_ADULT,EXTRABED_CHILD,CHECKIN_ID,INSERT_DATE,INSERT_TIME,NIGHT)" +
                " VALUES(@ROOM_NO,(SELECT CHARGED_TARRIF FROM CHECKIN WHERE ROOM_NO='"+TRANSFERROOM+ "' AND CHECK_OUT=0),(SELECT CHARGED_EBED_ADULT FROM CHECKIN WHERE ROOM_NO='" + TRANSFERROOM + "' AND CHECK_OUT=0),"+
                "(SELECT CHARGED_EBED_CHILD FROM CHECKIN WHERE ROOM_NO='" + TRANSFERROOM + "' AND CHECK_OUT=0),(SELECT CHECKIN_ID FROM CHECKIN WHERE ROOM_NO='" + TRANSFERROOM + "' AND CHECK_OUT=0),"+
                "(SELECT ARRIVAL_DATE FROM CHECKIN WHERE ROOM_NO='" + TRANSFERROOM + "' AND CHECK_OUT=0),"+
                "(SELECT ARRIVAL_TIME FROM CHECKIN WHERE ROOM_NO='" + TRANSFERROOM + "' AND CHECK_OUT=0),0)";
            DbFunctions.ExecuteCommand<int>(s, list);
        }
        public void night1()
        {
            var list = new List<SqlParameter>();
            string s = "update night_audit set NIGHT=1 WHERE ROOM_NO='" + MAINROOM + "' ";
            DbFunctions.ExecuteCommand<int>(s, list);
        }
        public void updatemainroom()
        {
            var list = new List<SqlParameter>();
            string s = "UPDATE CHECKIN SET CHECK_OUT=1 WHERE ROOM_NO ='" + MAINROOM + "'";
            DbFunctions.ExecuteCommand<int>(s,list);
        }
        public void UPDATECOLOR()
        {

            var list = new List<SqlParameter>();
            list.AddSqlParameter("@MAIN_ROOM", MAINROOM);
            list.AddSqlParameter("@TRANSFER_ROOM", TRANSFERROOM);
            string S = "UPDATE ROOMMASTER SET BACKGROUND_COLOR='Orange' where ROOM_NO='" + TRANSFERROOM + "' ";
            DbFunctions.ExecuteCommand<int>(S, list);
        }
        public void NIGHT()
        {
            var LISTS = new List<SqlParameter>();
            LISTS.AddSqlParameter("@MAIN_ROOM", MAINROOM);
            LISTS.AddSqlParameter("@TRANSFER_ROOM", TRANSFERROOM);
            string s = "update night_audit set CHECKIN_ID=(SELECT CHECKIN_ID FROM CHECKIN WHERE ROOM_NO='" + TRANSFERROOM + "' AND CHECK_OUT=0 ) WHERE ROOM_NO='" + TRANSFERROOM + "' AND NIGHT=0 ";
            DbFunctions.ExecuteCommand<int>(s, LISTS);
        }

    }
}