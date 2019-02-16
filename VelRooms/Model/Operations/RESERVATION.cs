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


namespace HMS.Model
{
    public class RESERVATION
    {
        public string SEARCH { get; set; }
        public string RESERVATIONID { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public string ROOM_CATEGORY { get; set; }
        public string NOOFROOMS { get; set; }
        public string PAXS { get; set; }
        public string ADULTS { get; set; }
        public string CHILDS { get; set; }
        public DateTime ARRIVALDATE { get; set; }
        public string ARRIVAL_TIME { get; set; }
        public DateTime DEPARTUREDATE { get; set; }
        public string DEPARTURE_TIME { get; set; }
        public string DAYS { get; set; }
        public string GUESTSTATUS { get; set; }
        public string COMPANY { get; set; }
        public string COMPANY_CONTACT { get; set; }
        public string NATIONALITY { get; set; }
        public string COMPANYADDRESS { get; set; }
        public string DOORNO { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string COUNTRY { get; set; }
        public string ZIP { get; set; }
        public string MOBILE_NO { get; set; }
        public string EMAILID { get; set; }
        public string SPECIALINSTRUCTION { get; set; }
        public string AMOUNT_RECEIVED { get; set; }
        public string STATUS { get; set; }

        //11/15/2017
        //public string USER_NAME { get; set; }
        public string INSERT_BY { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime UPDTAE_DATE { get; set; }
        public static DataTable dt { get; set; }
        public void INSERT()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@RESERVATION_ID", RESERVATIONID);
            list.AddSqlParameter("@FIRSTNAME", FIRSTNAME);
            list.AddSqlParameter("@LASTNAME", LASTNAME);
            list.AddSqlParameter("@ROOM_CATEGORY", ROOM_CATEGORY);
            list.AddSqlParameter("@NO_OF_ROOMS", NOOFROOMS);
            list.AddSqlParameter("@PAX", PAXS);
            list.AddSqlParameter("@ADULT", ADULTS);
            list.AddSqlParameter("@CHILD", CHILDS);
            list.AddSqlParameter("@ARRIVAL_DATE", ARRIVALDATE);
            list.AddSqlParameter("@ARRIVAL_TIME", ARRIVAL_TIME);
            list.AddSqlParameter("@DEPARTURE_DATE", DEPARTUREDATE);
            list.AddSqlParameter("@DEPARTURE_TIME", DEPARTURE_TIME);
            list.AddSqlParameter("@DAYS", DAYS);
            list.AddSqlParameter("@GUEST_STATUS", GUESTSTATUS);
            list.AddSqlParameter("@COMPANY_NAME", COMPANY);
            list.AddSqlParameter("@NATIONALITY", NATIONALITY);
            list.AddSqlParameter("@COMPANY_ADDRESS", COMPANYADDRESS);
            list.AddSqlParameter("@DOOR_NO", DOORNO);
            list.AddSqlParameter("@CITY", CITY);
            list.AddSqlParameter("@STATE", STATE);
            list.AddSqlParameter("@COUNTRY", COUNTRY);
            list.AddSqlParameter("@ZIP", ZIP);
            list.AddSqlParameter("@MOBILE_NO", MOBILE_NO);
            list.AddSqlParameter("@EMAIL", EMAILID);
            list.AddSqlParameter("@SPECIALINSTRUCTIONS", SPECIALINSTRUCTION);
            list.AddSqlParameter("@STATUS", STATUS);
            // USER INSERT SRI INSERTBY
            //list.AddSqlParameter("@USER_NAME", USER_NAME);
            list.AddSqlParameter("@INSERT_BY", INSERT_BY);
            list.AddSqlParameter("@INSERT_DATE", INSERT_DATE);
            //USER_NAME = login.u;
            //INSERT_BY = login.u;
            //INSERT_DATE = DateTime.Today.ToShortDateString();
            // string S = "IF EXISTS(SELECT MOBILE_NO FROM RESERVATION WHERE MOBILE_NO = @MOBILE_NO) BEGIN UPDATE RESERVATION SET FIRSTNAME=@FIRSTNAME,LASTNAME=@LASTNAME,ROOM_CATEGORY=@ROOM_CATEGORY,NO_OF_ROOMS=@NO_OF_ROOMS,PAX=@PAX,ADULT=@ADULT,CHILD=@CHILD,ARRIVAL_DATE=@ARRIVAL_DATE,ARRIVAL_TIME=@ARRIVAL_TIME,DEPARTURE_DATE=@DEPARTURE_DATE,DEPARTURE_TIME=@DEPARTURE_TIME,DAYS=@DAYS,GUEST_STATUS=@GUEST_STATUS,COMPANY_NAME=@COMPANY_NAME,NATIONALITY=@NATIONALITY,COMPANY_ADDRESS=@COMPANY_ADDRESS,DOOR_NO=@DOOR_NO,CITY=@CITY,STATE=@STATE,COUNTRY=@COUNTRY,ZIP=@ZIP,EMAIL=@EMAIL,ID_TYPE=@ID_TYPE,ID_DATA=@ID_DATA,SPECIALINSTRUCTIONS=@SPECIALINSTRUCTIONS,STATUS=@STATUS,INSERT_BY=@INSERT_BY,INSERT_DATE=@INSERT_DATE WHERE MOBILE_NO = @MOBILE_NO END ELSE BEGIN INSERT INTO RESERVATION(FIRSTNAME,LASTNAME,ROOM_CATEGORY,NO_OF_ROOMS,PAX,ADULT,CHILD,ARRIVAL_DATE,ARRIVAL_TIME,DEPARTURE_DATE,DEPARTURE_TIME,DAYS,GUEST_STATUS,COMPANY_NAME,NATIONALITY,COMPANY_ADDRESS,DOOR_NO,CITY,STATE,COUNTRY,ZIP,MOBILE_NO,EMAIL,ID_TYPE,ID_DATA,SPECIALINSTRUCTIONS,STATUS,INSERT_BY,INSERT_DATE) VALUES (@FIRSTNAME,@LASTNAME,@ROOM_CATEGORY,@NO_OF_ROOMS,@PAX,@ADULT,@CHILD,@ARRIVAL_DATE,@ARRIVAL_TIME,@DEPARTURE_DATE,@DEPARTURE_TIME,@DAYS,@GUEST_STATUS,@COMPANY_NAME,@NATIONALITY,@COMPANY_ADDRESS,@DOOR_NO,@CITY,@STATE,@COUNTRY,@ZIP,@MOBILE_NO,@EMAIL,@ID_TYPE,@ID_DATA,@SPECIALINSTRUCTIONS,@STATUS,@INSERT_BY,@INSERT_DATE)END";
            string S = "INSERT INTO RESERVATION(FIRSTNAME,LASTNAME,ROOM_CATEGORY,NO_OF_ROOMS,PAX,ADULT,CHILD,ARRIVAL_DATE,ARRIVAL_TIME,DEPARTURE_DATE,DEPARTURE_TIME,DAYS,GUEST_STATUS,COMPANY_NAME,NATIONALITY,COMPANY_ADDRESS,DOOR_NO,CITY,STATE,COUNTRY,ZIP,MOBILE_NO,EMAIL,SPECIALINSTRUCTIONS,STATUS,INSERT_BY,INSERT_DATE) VALUES (@FIRSTNAME,@LASTNAME,@ROOM_CATEGORY,@NO_OF_ROOMS,@PAX,@ADULT,@CHILD,@ARRIVAL_DATE,@ARRIVAL_TIME,@DEPARTURE_DATE,@DEPARTURE_TIME,@DAYS,@GUEST_STATUS,@COMPANY_NAME,@NATIONALITY,@COMPANY_ADDRESS,@DOOR_NO,@CITY,@STATE,@COUNTRY,@ZIP,@MOBILE_NO,@EMAIL,@SPECIALINSTRUCTIONS,@STATUS,@INSERT_BY,@INSERT_DATE)";
            DbFunctions.ExecuteCommand<int>(S, list);
        }

        public void UPDATE1()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@RESERVATION_ID", RESERVATIONID);
            list.AddSqlParameter("@FIRSTNAME", FIRSTNAME);
            list.AddSqlParameter("@LASTNAME", LASTNAME);
            list.AddSqlParameter("@ROOM_CATEGORY", ROOM_CATEGORY);
            list.AddSqlParameter("@NO_OF_ROOMS", NOOFROOMS);
            list.AddSqlParameter("@PAX", PAXS);
            list.AddSqlParameter("@ADULT", ADULTS);
            list.AddSqlParameter("@CHILD", CHILDS);
            list.AddSqlParameter("@ARRIVAL_DATE", ARRIVALDATE);
            list.AddSqlParameter("@ARRIVAL_TIME", ARRIVAL_TIME);
            list.AddSqlParameter("@DEPARTURE_DATE", DEPARTUREDATE);
            list.AddSqlParameter("@DEPARTURE_TIME", DEPARTURE_TIME);
            list.AddSqlParameter("@DAYS", DAYS);
            list.AddSqlParameter("@GUEST_STATUS", GUESTSTATUS);
            list.AddSqlParameter("@COMPANY_NAME", COMPANY);
            list.AddSqlParameter("@NATIONALITY", NATIONALITY);
            list.AddSqlParameter("@COMPANY_ADDRESS", COMPANYADDRESS);
            list.AddSqlParameter("@DOOR_NO", DOORNO);
            list.AddSqlParameter("@CITY", CITY);
            list.AddSqlParameter("@STATE", STATE);
            list.AddSqlParameter("@COUNTRY", COUNTRY);
            list.AddSqlParameter("@ZIP", ZIP);
            list.AddSqlParameter("@MOBILE_NO", MOBILE_NO);
            list.AddSqlParameter("@EMAIL", EMAILID);
            list.AddSqlParameter("@SPECIALINSTRUCTIONS", SPECIALINSTRUCTION);
            list.AddSqlParameter("@STATUS", STATUS);
            // USER INSERT SRI INSERTBY
            //list.AddSqlParameter("@USER_NAME", USER_NAME);
            list.AddSqlParameter("@INSERT_BY", INSERT_BY);
            list.AddSqlParameter("@INSERT_DATE", INSERT_DATE);
            //USER_NAME = login.u;
            //INSERT_BY = login.u;
            //INSERT_DATE = DateTime.Today.ToShortDateString();

            string S = "UPDATE RESERVATION SET FIRSTNAME=@FIRSTNAME,LASTNAME=@LASTNAME,ROOM_CATEGORY=@ROOM_CATEGORY,NO_OF_ROOMS=@NO_OF_ROOMS,PAX=@PAX,ADULT=@ADULT,CHILD=@CHILD,ARRIVAL_DATE=@ARRIVAL_DATE,ARRIVAL_TIME=@ARRIVAL_TIME,DEPARTURE_DATE=@DEPARTURE_DATE,DEPARTURE_TIME=@DEPARTURE_TIME,DAYS=@DAYS,GUEST_STATUS=@GUEST_STATUS,COMPANY_NAME=@COMPANY_NAME,NATIONALITY=@NATIONALITY,COMPANY_ADDRESS=@COMPANY_ADDRESS,DOOR_NO=@DOOR_NO,CITY=@CITY,STATE=@STATE,COUNTRY=@COUNTRY,ZIP=@ZIP,EMAIL=@EMAIL,SPECIALINSTRUCTIONS=@SPECIALINSTRUCTIONS,STATUS=@STATUS,INSERT_BY=@INSERT_BY,INSERT_DATE=@INSERT_DATE WHERE MOBILE_NO = '"+MOBILE_NO+"'";
        //  string S = "INSERT INTO RESERVATION(FIRSTNAME,LASTNAME,ROOM_CATEGORY,NO_OF_ROOMS,PAX,ADULT,CHILD,ARRIVAL_DATE,ARRIVAL_TIME,DEPARTURE_DATE,DEPARTURE_TIME,DAYS,GUEST_STATUS,COMPANY_NAME,NATIONALITY,COMPANY_ADDRESS,DOOR_NO,CITY,STATE,COUNTRY,ZIP,MOBILE_NO,EMAIL,ID_TYPE,ID_DATA,SPECIALINSTRUCTIONS,STATUS,INSERT_BY,INSERT_DATE) VALUES (@FIRSTNAME,@LASTNAME,@ROOM_CATEGORY,@NO_OF_ROOMS,@PAX,@ADULT,@CHILD,@ARRIVAL_DATE,@ARRIVAL_TIME,@DEPARTURE_DATE,@DEPARTURE_TIME,@DAYS,@GUEST_STATUS,@COMPANY_NAME,@NATIONALITY,@COMPANY_ADDRESS,@DOOR_NO,@CITY,@STATE,@COUNTRY,@ZIP,@MOBILE_NO,@EMAIL,@ID_TYPE,@ID_DATA,@SPECIALINSTRUCTIONS,@STATUS,@INSERT_BY,@INSERT_DATE)";
            DbFunctions.ExecuteCommand<int>(S, list);
        }
        public void A()
        {
            var LIST = new List<SqlParameter>();
            string SS = "UPDATE ADVANCE SET ADVANCE = 0 where RESERVATION_ID='" + e+ "' ";
            DbFunctions.ExecuteCommand<int>(SS, LIST);
        }
        public void Company_contact()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT CONTACT_PERSON_NUMBER FROM COMPANYMASTER WHERE COMPANY_NAME = '" + COMPANY + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {
                COMPANY_CONTACT = "0";
            }
            else
            {
                COMPANY_CONTACT = dt.Rows[0]["CONTACT_PERSON_NUMBER"].ToString();
            }
        }

        public int e ;
        public int get_reservation_id()
        {
            int a = 0;
            string S = "SELECT MAX(RESERVATION_ID) FROM RESERVATION";
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
                e = a;
            }
            return a;
        }
        public DataTable GET()
        {

            var list = new List<SqlParameter>();
            string ss = "select ROOM_CATEGORY from ROOMCATEGORY WHERE ACTIVE_DATE <=current_timestamp AND  STATUS='Active' ";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(ss, list);
            return dt;
        }
        public DataTable GETNAME()
        {

            var list = new List<SqlParameter>();
            string ss = "select ROOM_CATEGORY from ROOMCATEGORY WHERE STATUS = 'Active' AND ACTIVE_DATE <= CURRENT_TIMESTAMP ";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(ss, list);
            return dt;
        }
        public DataTable ROOM()
        {
            var list = new List<SqlParameter>();
            string ss = "select * from ROOMMASTER";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(ss, list);
            return dt;
        }
        public void R()
        {
            var LIST = new List<SqlParameter>();
            string SS = "UPDATE RESERVATION SET RESERVATION = 0 WHERE RESERVATION_ID ='" + e + "' ";
            DbFunctions.ExecuteCommand<int>(SS, LIST);
        }

        public DataTable GET1()
        {
            var list = new List<SqlParameter>();
            string sa = "select COMPANY_NAME FROM COMPANYMASTER ";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(sa, list);
            return dt;
        }
        public DataTable state()
        {
            var list = new List<SqlParameter>();
            string sa = "select STATE FROM states";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(sa, list);
            return dt;
        }
        public DataTable name()
        {
            var list = new List<SqlParameter>();
            string ss = "select * from RESERVATION WHERE FIRSTNAME = '" + FIRSTNAME + "' AND STATUS <> 'CANCLED'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(ss, list);
            if (dt.Rows.Count == 0)
            {
                RESERVATIONID = "";
                FIRSTNAME = "";
                MOBILE_NO = "";
                PAXS = "";
                COMPANY = "";
                ROOM_CATEGORY = "";
                NOOFROOMS = "";
            }
            else
            {
                RESERVATIONID = dt.Rows[0]["RESERVATION_ID"].ToString();
                FIRSTNAME = dt.Rows[0]["FIRSTNAME"].ToString();
                MOBILE_NO = dt.Rows[0]["MOBILE_NO"].ToString();
                PAXS = dt.Rows[0]["PAX"].ToString();
                COMPANY = dt.Rows[0]["COMPANY_NAME"].ToString();
                ARRIVALDATE = Convert.ToDateTime(dt.Rows[0]["ARRIVAL_DATE"].ToString());
                DEPARTUREDATE = Convert.ToDateTime(dt.Rows[0]["DEPARTURE_DATE"].ToString());
                ROOM_CATEGORY = dt.Rows[0]["ROOM_CATEGORY"].ToString();
                NOOFROOMS = dt.Rows[0]["NO_OF_ROOMS"].ToString();
            }

            return dt;
        }
        public DataTable G()
        {
            var list = new List<SqlParameter>();
            string ss = "select * from RESERVATION WHERE MOBILE_NO = '" + MOBILE_NO + "' AND STATUS <> 'CANCLED'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(ss, list);
            if (dt.Rows.Count == 0)
            {
                RESERVATIONID = "";
                FIRSTNAME = "";
                MOBILE_NO = "";
                PAXS = "";
                COMPANY = "";
                ROOM_CATEGORY = "";
                NOOFROOMS = "";
            }
            else
            {
                RESERVATIONID = dt.Rows[0]["RESERVATION_ID"].ToString();
                FIRSTNAME = dt.Rows[0]["FIRSTNAME"].ToString();
                MOBILE_NO = dt.Rows[0]["MOBILE_NO"].ToString();
                PAXS = dt.Rows[0]["PAX"].ToString();
                COMPANY = dt.Rows[0]["COMPANY_NAME"].ToString();
                ARRIVALDATE = Convert.ToDateTime(dt.Rows[0]["ARRIVAL_DATE"].ToString());
                DEPARTUREDATE = Convert.ToDateTime(dt.Rows[0]["DEPARTURE_DATE"].ToString());
                ROOM_CATEGORY = dt.Rows[0]["ROOM_CATEGORY"].ToString();
                NOOFROOMS = dt.Rows[0]["NO_OF_ROOMS"].ToString();
            }

            return dt;
        }
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
        public DataTable ID()
        {
            var list = new List<SqlParameter>();
            DataTable dt = new DataTable();
            string ss = "select * from RESERVATION WHERE RESERVATION_ID ='" + RESERVATIONID + "' AND STATUS <> 'CANCLED'";
            Object O = DbFunctions.ExecuteCommand<Object>(ss, list);
            if (O != null)
            {
                string s = "select * from RESERVATION WHERE RESERVATION_ID ='" + RESERVATIONID + "' AND STATUS <> 'CANCLED'";
                dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
                if (dt.Rows.Count == 0)
                {
                    RESERVATIONID = "";
                    FIRSTNAME = "";
                    MOBILE_NO = "";
                    PAXS = "";
                    COMPANY = "";
                    ROOM_CATEGORY = "";
                    NOOFROOMS = "";
                }
                else
                {
                    RESERVATIONID = dt.Rows[0]["RESERVATION_ID"].ToString();
                    FIRSTNAME = dt.Rows[0]["FIRSTNAME"].ToString();
                    MOBILE_NO = dt.Rows[0]["MOBILE_NO"].ToString();
                    PAXS = dt.Rows[0]["PAX"].ToString();
                    COMPANY = dt.Rows[0]["COMPANY_NAME"].ToString();
                    ARRIVALDATE = Convert.ToDateTime(dt.Rows[0]["ARRIVAL_DATE"].ToString());
                    DEPARTUREDATE = Convert.ToDateTime(dt.Rows[0]["DEPARTURE_DATE"].ToString());
                    ROOM_CATEGORY = dt.Rows[0]["ROOM_CATEGORY"].ToString();
                    NOOFROOMS = dt.Rows[0]["NO_OF_ROOMS"].ToString();
                }
            }
            return dt;
        }
        public DataTable ID1()
        {
            var list = new List<SqlParameter>();
            DataTable dt = new DataTable();
            string ss = "select * from RESERVATION WHERE FIRSTNAME ='" + FIRSTNAME + "' AND RESERVATION=0  AND STATUS <> 'CANCLED'";
            Object O = DbFunctions.ExecuteCommand<Object>(ss, list);
            if (O != null)
            {
                string s = "select * from RESERVATION WHERE FIRSTNAME ='" + FIRSTNAME + "'  AND RESERVATION=0  AND STATUS <> 'CANCLED'";
                dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
                if (dt.Rows.Count == 0)
                {
                    RESERVATIONID = "";
                    FIRSTNAME = "";
                    MOBILE_NO = "";
                    PAXS = "";
                    COMPANY = "";
                    ROOM_CATEGORY = "";
                    NOOFROOMS = "";
                }
                else
                {
                    RESERVATIONID = dt.Rows[0]["RESERVATION_ID"].ToString();
                    FIRSTNAME = dt.Rows[0]["FIRSTNAME"].ToString();
                    MOBILE_NO = dt.Rows[0]["MOBILE_NO"].ToString();
                    PAXS = dt.Rows[0]["PAX"].ToString();
                    COMPANY = dt.Rows[0]["COMPANY_NAME"].ToString();
                    ARRIVALDATE = Convert.ToDateTime(dt.Rows[0]["ARRIVAL_DATE"].ToString());
                    DEPARTUREDATE = Convert.ToDateTime(dt.Rows[0]["DEPARTURE_DATE"].ToString());
                    ROOM_CATEGORY = dt.Rows[0]["ROOM_CATEGORY"].ToString();
                    NOOFROOMS = dt.Rows[0]["NO_OF_ROOMS"].ToString();
                }
            }
            return dt;
        }
        public object EXIST_ID()
        {
            String S = "SELECT COUNT(RESERVATION_ID) FROM CHECKIN WHERE RESERVATION_ID=@RES_ID";
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@RES_ID", RESERVATIONID);
            object O = DAL.DbFunctions.ExecuteCommand<object>(S, LIST);
            return O;
        }
        public DataTable COMPAY()
        {
            var list = new List<SqlParameter>();
            string ss = "select * from RESERVATION WHERE COMPANY_NAME ='" + COMPANY + "'  AND RESERVATION=0  AND STATUS <> 'CANCLED'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(ss, list); 
            RESERVATIONID = dt.Rows[0]["RESERVATION_ID"].ToString();
            FIRSTNAME = dt.Rows[0]["FIRSTNAME"].ToString();
            MOBILE_NO = dt.Rows[0]["MOBILE_NO"].ToString();
            PAXS = dt.Rows[0]["PAX"].ToString();
            COMPANY = dt.Rows[0]["COMPANY_NAME"].ToString();
            ARRIVALDATE = Convert.ToDateTime(dt.Rows[0]["ARRIVAL_DATE"].ToString()); 
            DEPARTUREDATE = Convert.ToDateTime(dt.Rows[0]["DEPARTURE_DATE"].ToString());
            ROOM_CATEGORY = dt.Rows[0]["ROOM_CATEGORY"].ToString();
            NOOFROOMS = dt.Rows[0]["NO_OF_ROOMS"].ToString();
            return dt;
        }
        public DataTable DATE()
        {
            var list = new List<SqlParameter>();
            string ss = "select * from RESERVATION WHERE ARRIVAL_DATE ='" + ARRIVALDATE + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(ss, list);
            if (dt.Rows.Count == 0)
            {
                RESERVATIONID = "";
                FIRSTNAME = "";
                MOBILE_NO = "";
                PAXS = "";
                COMPANY = "";
                ROOM_CATEGORY = "";
                NOOFROOMS = "";
            }
            else
            {
                RESERVATIONID = dt.Rows[0]["RESERVATION_ID"].ToString();
                FIRSTNAME = dt.Rows[0]["FIRSTNAME"].ToString();
                MOBILE_NO = dt.Rows[0]["MOBILE_NO"].ToString();
                PAXS = dt.Rows[0]["PAX"].ToString();
                COMPANY = dt.Rows[0]["COMPANY_NAME"].ToString();
                ARRIVALDATE = Convert.ToDateTime(dt.Rows[0]["ARRIVAL_DATE"].ToString());  
                DEPARTUREDATE = Convert.ToDateTime(dt.Rows[0]["DEPARTURE_DATE"].ToString());
                ROOM_CATEGORY = dt.Rows[0]["ROOM_CATEGORY"].ToString();
                NOOFROOMS = dt.Rows[0]["NO_OF_ROOMS"].ToString();
            }

            return dt;
        }
        public void UPDATE()
        {
            var list = new List<SqlParameter>();

            string S = "SELECT * FROM RESERVATION WHERE MOBILE_NO = '" + MOBILE_NO + "' OR RESERVATION_ID = '" + RESERVATIONID + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, list);
            if (dt.Rows.Count == 0) { }
            else
            {
                RESERVATIONID = dt.Rows[0]["RESERVATION_ID"].ToString();
                FIRSTNAME = dt.Rows[0]["FIRSTNAME"].ToString();
                LASTNAME = dt.Rows[0]["LASTNAME"].ToString();
                ROOM_CATEGORY = dt.Rows[0]["ROOM_CATEGORY"].ToString();
                NOOFROOMS = dt.Rows[0]["NO_OF_ROOMS"].ToString();
                PAXS = dt.Rows[0]["PAX"].ToString();
                ADULTS = dt.Rows[0]["ADULT"].ToString();
                CHILDS = dt.Rows[0]["CHILD"].ToString();
                ARRIVALDATE = Convert.ToDateTime(dt.Rows[0]["ARRIVAL_DATE"].ToString());
                DEPARTUREDATE = Convert.ToDateTime(dt.Rows[0]["DEPARTURE_DATE"].ToString());
                DAYS = dt.Rows[0]["DAYS"].ToString();
                GUESTSTATUS = dt.Rows[0]["GUEST_STATUS"].ToString();
                NATIONALITY = dt.Rows[0]["NATIONALITY"].ToString();
                COMPANY = dt.Rows[0]["COMPANY_NAME"].ToString();
                COMPANYADDRESS = dt.Rows[0]["COMPANY_ADDRESS"].ToString();
                DOORNO = dt.Rows[0]["DOOR_NO"].ToString();
                CITY = dt.Rows[0]["CITY"].ToString();
                STATE = dt.Rows[0]["STATE"].ToString();
                COUNTRY = dt.Rows[0]["COUNTRY"].ToString();
                ZIP = dt.Rows[0]["ZIP"].ToString();
                MOBILE_NO = dt.Rows[0]["MOBILE_NO"].ToString();
                //IDPROOF = dt.Rows[0]["ID_TYPE"].ToString();
                //IDPROOF1 = dt.Rows[0]["ID_DATA"].ToString();
                SPECIALINSTRUCTION = dt.Rows[0]["SPECIALINSTRUCTIONS"].ToString();
                EMAILID = dt.Rows[0]["EMAIL"].ToString();
            }
        }
        public static int room;
        public void NO_OFROOMS()
        {
            var LIST = new List<SqlParameter>();
            string NO = "SELECT NO_OF_ROOMS FROM RESERVATION WHERE RESERVATION_ID='"+ RESERVATIONID +"' AND RESERVATION=0 ";
            DataTable S = DbFunctions.ExecuteCommand<DataTable>(NO,LIST);
            if(S.Rows.Count == 0)
            {
                room = 0;
            }
            else
            {
                room = int.Parse(S.Rows[0]["NO_OF_ROOMS"].ToString());

            }
        }
        //public void Guestmobileno()
        //{
        //    var list = new List<SqlParameter>();
        //    string s = "SELECT MOBILE_NO FROM RESERVATION WHERE RESERVATION_ID = '" + RESERVATIONID + "'";
        //    DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
        //    MOBILE_NO = dt.Rows[0]["MOBILE_NO"].ToString();
        //}
        public DataTable Cancle()
        {
            var list = new List<SqlParameter>();

            string S = "SELECT * FROM RESERVATION WHERE RESERVATION_ID = '" + RESERVATIONID + "' AND STATUS <> 'CANCLED'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, list);
            if (dt.Rows.Count == 0)
            {
                FIRSTNAME = "";
                LASTNAME = "";
                ROOM_CATEGORY = "";
                NOOFROOMS = "";
                PAXS = "";
                ADULTS = "";
                CHILDS = "";
                DAYS = "";
                GUESTSTATUS = "";
                NATIONALITY = "";
                COMPANY = "";
                COMPANYADDRESS = "";
                DOORNO = "";
                CITY = "";
                STATE = "";
                COUNTRY = "";
                ZIP = "";
                MOBILE_NO = "";
                SPECIALINSTRUCTION = "";
                EMAILID = "";
            }
            else
            {
                FIRSTNAME = dt.Rows[0]["FIRSTNAME"].ToString();
                LASTNAME = dt.Rows[0]["LASTNAME"].ToString();
                ROOM_CATEGORY = dt.Rows[0]["ROOM_CATEGORY"].ToString();
                NOOFROOMS = dt.Rows[0]["NO_OF_ROOMS"].ToString();
                PAXS = dt.Rows[0]["PAX"].ToString();
                ADULTS = dt.Rows[0]["ADULT"].ToString();
                CHILDS = dt.Rows[0]["CHILD"].ToString();
                ARRIVALDATE = Convert.ToDateTime(dt.Rows[0]["ARRIVAL_DATE"].ToString());
                DEPARTUREDATE = Convert.ToDateTime(dt.Rows[0]["DEPARTURE_DATE"].ToString());
                DAYS = dt.Rows[0]["DAYS"].ToString();
                GUESTSTATUS = dt.Rows[0]["GUEST_STATUS"].ToString();
                NATIONALITY = dt.Rows[0]["NATIONALITY"].ToString();
                COMPANY = dt.Rows[0]["COMPANY_NAME"].ToString();
                COMPANYADDRESS = dt.Rows[0]["COMPANY_ADDRESS"].ToString();
                DOORNO = dt.Rows[0]["DOOR_NO"].ToString();
                CITY = dt.Rows[0]["CITY"].ToString();
                STATE = dt.Rows[0]["STATE"].ToString();
                COUNTRY = dt.Rows[0]["COUNTRY"].ToString();
                ZIP = dt.Rows[0]["ZIP"].ToString();
                MOBILE_NO = dt.Rows[0]["MOBILE_NO"].ToString();
                SPECIALINSTRUCTION = dt.Rows[0]["SPECIALINSTRUCTIONS"].ToString();
                EMAILID = dt.Rows[0]["EMAIL"].ToString();
            }
            return dt;
        }
        public DataTable advanceamnt()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT SUM(AMOUNT_RECEIVED) AS AMOUNT FROM ADVANCE WHERE RESERVATION_ID = '" + RESERVATIONID + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (dt.Rows.Count == 0)
            {
                AMOUNT_RECEIVED = "0.00";
            }
            else
            {
                AMOUNT_RECEIVED = dt.Rows[0]["AMOUNT"].ToString();
            }
            return dt;
        }
        public void ADVANCE()
        {
            var LIST = new List<SqlParameter>();
            string SS = "UPDATE ADVANCE SET ADVANCE = 0 where RESERVATION_ID='" + e + "'   ";
            DbFunctions.ExecuteCommand<int>(SS, LIST);
        }
        public DataTable fill_grid()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT RESERVATION_ID,FIRSTNAME,MOBILE_NO,ARRIVAL_DATE FROM RESERVATION WHERE STATUS <> 'CANCLED' AND ARRIVAL_DATE>='"+DateTime.Today+"'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable Grid()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT RESERVATION_ID,FIRSTNAME,LASTNAME,MOBILE_NO,ARRIVAL_DATE,DEPARTURE_DATE,ROOM_CATEGORY,NO_OF_ROOMS,PAX,ADULT,CHILD,ARRIVAL_TIME,DAYS,COMPANY_NAME,COMPANY_ADDRESS,GUEST_STATUS,NATIONALITY,CITY,DOOR_NO,STATE,COUNTRY,ZIP,EMAIL,SPECIALINSTRUCTIONS FROM RESERVATION WHERE  RESERVATION=0 AND CONVERT(date,ARRIVAL_DATE)>=CONVERT(date,GetDate()) ORDER BY INSERT_DATE DESC";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable Res()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT RESERVATION_ID,FIRSTNAME,PAX,COMPANY_NAME,ARRIVAL_DATE,NO_OF_ROOMS,DEPARTURE_DATE,(select CONVERT(decimal(17,2), sum(AMOUNT_RECEIVED)) from ADVANCE where RESERVATION_ID = '" + RESERVATIONS.num+"') AS AMOUNT_RECEIVED FROM RESERVATION WHERE RESERVATION_ID = '"+RESERVATIONS.num+ "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable gridfilter()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT RESERVATION_ID,FIRSTNAME,LASTNAME,MOBILE_NO,ARRIVAL_DATE,DEPARTURE_DATE,ROOM_CATEGORY,NO_OF_ROOMS,PAX,ADULT,CHILD,ARRIVAL_TIME,DAYS,COMPANY_NAME,COMPANY_ADDRESS,GUEST_STATUS,NATIONALITY,CITY,DOOR_NO,STATE,COUNTRY,ZIP,EMAIL,SPECIALINSTRUCTIONS FROM RESERVATION WHERE STATUS ='ACTIVE' AND MOBILE_NO='"+ RESERVATIONS.y +"'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        } 
        public DataTable Grid1()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT RESERVATION_ID,FIRSTNAME,LASTNAME,MOBILE_NO,ARRIVAL_DATE,DEPARTURE_DATE,ROOM_CATEGORY,NO_OF_ROOMS,PAX,ADULT,CHILD,ARRIVAL_TIME,INSERT_DATE,DAYS,COMPANY_NAME,COMPANY_ADDRESS,GUEST_STATUS,NATIONALITY,CITY,DOOR_NO,STATE,COUNTRY,ZIP,EMAIL,SPECIALINSTRUCTIONS FROM RESERVATION WHERE STATUS ='ACTIVE' AND CONVERT(date,ARRIVAL_DATE)<CONVERT(date,GetDate())";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable FillReservationDetails()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT RESERVATION_ID,INSERT_DATE,NO_OF_ROOMS,ARRIVAL_DATE,ARRIVAL_TIME,DEPARTURE_DATE,ROOM_CATEGORY,FIRSTNAME,MOBILE_NO FROM RESERVATION WHERE STATUS ='ACTIVE' AND RESERVATION=0 AND  CONVERT(date,ARRIVAL_DATE)>=CONVERT(date,GetDate()) ORDER BY INSERT_DATE DESC";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable GetReservationDetails(String res_id)
        {
            var list = new List<SqlParameter>();
            string s = "SELECT RESERVATION_ID,INSERT_DATE,NO_OF_ROOMS,ARRIVAL_DATE,DEPARTURE_DATE,ROOM_CATEGORY,FIRSTNAME,LASTNAME,MOBILE_NO,GUEST_STATUS,COMPANY_NAME,COMPANY_ADDRESS,COUNTRY,STATE,CITY,DOOR_NO,ZIP,EMAIL,PAX,ADULT,CHILD FROM RESERVATION WHERE RESERVATION_ID ='" + res_id +"'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable MobileNo()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT * FROM RESERVATION WHERE MOBILE_NO = '" + RESERVATIONS.z + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable AdvanceAmount()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT * FROM ADVANCE WHERE RESERVATION_ID = '" + RESERVATIONS.id+ "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable RefundCheck()
        {
            //select* from REFUND where RESERVATION_ID = '15186'
            var list = new List<SqlParameter>();
            string s = "Select * from REFUND where RESERVATION_ID = '"+ RESERVATIONS.id+"'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
    }
}