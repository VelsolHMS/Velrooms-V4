using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Configuration;
using HMS.View.Masters;

namespace HMS.Model
{
    public class Roommaster
    {
        public int ROOM_NO { get; set; }
        public string ROOM_CATEGORY { get; set; }
        public string ROOM_VIEW { get; set; }
        public int MAX_PAX { get; set; }
        public string CURRENCY { get; set; }
        public string PLANCODE { get; set; }
        public decimal SINGLERATE_TARRIF { get; set; }
        public decimal SINGLERATE_PLAN { get; set; }
        public decimal DOUBLERATE_TARRIF { get; set; }
        public decimal DOUBLERATE_PLAN { get; set; }
        public decimal TRIPLERATE_TARRIF { get; set; }
        public decimal TRIPLERATE_PLAN { get; set; }
        public decimal QUADRATE_TARRIF { get; set; }
        public decimal QUADRATE_PLAN { get; set; }
        public string STATUS { get; set; }
        public DateTime ACTIVE_CALENDER { get; set; }
        public decimal COMMON_PRICE { get; set; }
        public decimal ADULT_EXTRABADCOST { get; set; }
        public decimal CHILD_EXTRABEDCOST { get; set; }
        public Object AMENITY_NAMES { get; set; }
        public decimal COMMON_PLAN { get; set; }
        public string button { get; set; }
        //11/15/2017
        //public string USER_NAME { get; set; }
        public string INSERT_BY { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public void INSERT()
        {
            int A = GETROOMNO();
            if (A == 0)
            {
                string s = "INSERT INTO ROOMMASTER (ROOM_NO,ROOM_CATEGORY,ROOM_VIEW,MAX_PAX,ACTIVE_DATE,CURRENCY,SINGLERATE_TARRIF,DOUBLERATE_TARRIF,TRIPLERATE_TARRIF,QUADRATE_TARRIF,COMMON_PRICE,EXTRABED_ADULT,EXTRABED_CHILD,STATUS,BACKGROUND_COLOR,INSERT_BY,INSERT_DATE)"+"" +
                    "VALUES(@ROOM_NO,@ROOM_CATEGORY,@ROOM_VIEW,@MAX_PAX,@ACTIVE_DATE,@CURRENCY,@SINGLERATE_TARRIF,@DOUBLERATE_TARRIF,@TRIPLERATE_TARRIF,@QUADRATE_TARRIF,@COMMON_PRICE,@EXTRABED_ADULT,@EXTRABED_CHILD,@STATUS,@BACKGROUND_COLOR,@INSERT_BY,@INSERT_DATE)";
                var listParams = new List<SqlParameter>();
                listParams.AddSqlParameter("@ROOM_NO", ROOM_NO);
                listParams.AddSqlParameter("@ROOM_CATEGORY", ROOM_CATEGORY);
                listParams.AddSqlParameter("@ROOM_VIEW", ROOM_VIEW);
                listParams.AddSqlParameter("@MAX_PAX", MAX_PAX);
                listParams.AddSqlParameter("@ACTIVE_DATE", ACTIVE_CALENDER);
                listParams.AddSqlParameter("@CURRENCY", CURRENCY);
                listParams.AddSqlParameter("@SINGLERATE_TARRIF", SINGLERATE_TARRIF);
                listParams.AddSqlParameter("@DOUBLERATE_TARRIF", DOUBLERATE_TARRIF);
                listParams.AddSqlParameter("@TRIPLERATE_TARRIF", TRIPLERATE_TARRIF);
                listParams.AddSqlParameter("@QUADRATE_TARRIF", QUADRATE_TARRIF);
                listParams.AddSqlParameter("@COMMON_PRICE", COMMON_PRICE);
                listParams.AddSqlParameter("@EXTRABED_ADULT", ADULT_EXTRABADCOST);
                listParams.AddSqlParameter("@EXTRABED_CHILD", CHILD_EXTRABEDCOST);
                listParams.AddSqlParameter("@STATUS", STATUS);
                listParams.AddSqlParameter("@BACKGROUND_COLOR", "Green");
                INSERT_BY = login.u;
                INSERT_DATE = DateTime.Today;
                listParams.AddSqlParameter("@INSERT_BY", INSERT_BY);
                listParams.AddSqlParameter("@INSERT_DATE", INSERT_DATE);
                DbFunctions.ExecuteCommand<int>(s, listParams);

                INSERT_INTO_PLANCODE();
                if (AMENITY_NAMES == null)
                {

                }
                else
                {

                    string res = AMENITY_NAMES.ToString();
                    string[] values = res.Split(' ');
                    for (int i = 1; i < values.Length; i++)
                    {
                        values[i] = values[i].Trim();

                        String I = "INSERT INTO ROOMMASTER_AMENITY(ROOM_NO,AMENITY,ENABLE,INSERT_BY,INSERT_DATE)VALUES(@ROOM_NO,@AMENITY,@ENABLE,@INSERT_BY,@INSERT_DATE)";
                        var l = new List<SqlParameter>();
                        l.AddSqlParameter("@ROOM_NO", ROOM_NO);
                        l.AddSqlParameter("@AMENITY", values[i]);
                        l.AddSqlParameter("@INSERT_BY", login.u);
                        l.AddSqlParameter("@INSERT_DATE", DateTime.Today);
                        l.AddSqlParameter("@ENABLE", "yes");

                        DbFunctions.ExecuteCommand<int>(I, l);
                    }
                }
                //if (A != 0)
                //{
                //    int B = GETPLANCODE_ROOMNO_MATCH();
                //    if (B == 0)
                //    {
                //        INSERT_INTO_PLANCODE();
                //    }
                //}
            }
            if(A!=0)
            {
                int B = GETPLANCODE_ROOMNO_MATCH();
                if (B == 0)
                {
                    INSERT_INTO_PLANCODE();
                }
            }
        }
        public void INSERT1()
        {
            int A = GETROOMNO();
            if (A == 0)
            {
                string s = "INSERT INTO ROOMMASTER (ROOM_NO,ROOM_CATEGORY,ROOM_VIEW,MAX_PAX,ACTIVE_DATE,CURRENCY,SINGLERATE_TARRIF,DOUBLERATE_TARRIF,TRIPLERATE_TARRIF,QUADRATE_TARRIF,COMMON_PRICE,EXTRABED_ADULT,EXTRABED_CHILD,STATUS,BACKGROUND_COLOR,INSERT_BY,INSERT_DATE)" + "" +
                    "VALUES(@ROOM_NO,@ROOM_CATEGORY,@ROOM_VIEW,@MAX_PAX,@ACTIVE_DATE,@CURRENCY,@SINGLERATE_TARRIF,@DOUBLERATE_TARRIF,@TRIPLERATE_TARRIF,@QUADRATE_TARRIF,@COMMON_PRICE,@EXTRABED_ADULT,@EXTRABED_CHILD,@STATUS,@BACKGROUND_COLOR,@INSERT_BY,@INSERT_DATE)";
                var listParams = new List<SqlParameter>();
                listParams.AddSqlParameter("@ROOM_NO", ROOM_NO);
                listParams.AddSqlParameter("@ROOM_CATEGORY", ROOM_CATEGORY);
                listParams.AddSqlParameter("@ROOM_VIEW", ROOM_VIEW);
                listParams.AddSqlParameter("@MAX_PAX", MAX_PAX);
                listParams.AddSqlParameter("@ACTIVE_DATE", ACTIVE_CALENDER);
                listParams.AddSqlParameter("@CURRENCY", CURRENCY);
                listParams.AddSqlParameter("@SINGLERATE_TARRIF", SINGLERATE_TARRIF);
                listParams.AddSqlParameter("@DOUBLERATE_TARRIF", DOUBLERATE_TARRIF);
                listParams.AddSqlParameter("@TRIPLERATE_TARRIF", TRIPLERATE_TARRIF);
                listParams.AddSqlParameter("@QUADRATE_TARRIF", QUADRATE_TARRIF);
                listParams.AddSqlParameter("@COMMON_PRICE", COMMON_PRICE);
                listParams.AddSqlParameter("@EXTRABED_ADULT", ADULT_EXTRABADCOST);
                listParams.AddSqlParameter("@EXTRABED_CHILD", CHILD_EXTRABEDCOST);
                listParams.AddSqlParameter("@STATUS", STATUS);
                listParams.AddSqlParameter("@BACKGROUND_COLOR", "Green");
                INSERT_BY = login.u;
                INSERT_DATE = DateTime.Today;
                listParams.AddSqlParameter("@INSERT_BY", INSERT_BY);
                listParams.AddSqlParameter("@INSERT_DATE", INSERT_DATE);
                DbFunctions.ExecuteCommand<int>(s, listParams);

                INSERT_INTO_PLANCODE();
                if (AMENITY_NAMES == null)
                {

                }
                else
                {

                    string res = AMENITY_NAMES.ToString();
                    string[] values = res.Split(' ');
                    for (int i = 1; i < values.Length; i++)
                    {
                        values[i] = values[i].Trim();

                        String I = "INSERT INTO ROOMMASTER_AMENITY(ROOM_NO,AMENITY,ENABLE,INSERT_BY,INSERT_DATE)VALUES(@ROOM_NO,@AMENITY,@ENABLE,@INSERT_BY,@INSERT_DATE)";
                        var l = new List<SqlParameter>();
                        l.AddSqlParameter("@ROOM_NO", ROOM_NO);
                        l.AddSqlParameter("@AMENITY", values[i]);
                        l.AddSqlParameter("@INSERT_BY", login.u);
                        l.AddSqlParameter("@INSERT_DATE", DateTime.Today);
                        l.AddSqlParameter("@ENABLE", "yes");

                        DbFunctions.ExecuteCommand<int>(I, l);
                    }
                }
                if (A != 0)
                {
                    int B = GETPLANCODE_ROOMNO_MATCH();
                    if (B == 0)
                    {
                        INSERT_INTO_PLANCODE();
                    }
                }
            }
        }
        public void DATATABLE_TO_SAVEDATA(DataTable dt)
        {
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                ROOM_NO = Convert.ToInt16(dt.Rows[r]["ROOMNO"]);
                ROOM_CATEGORY = dt.Rows[r]["ROOMCATEGORY"].ToString();
                ROOM_VIEW = dt.Rows[r]["ROOMVIEW"].ToString();
                MAX_PAX = Convert.ToInt16(dt.Rows[r]["MAXPAX"].ToString());
                ACTIVE_CALENDER = Convert.ToDateTime(dt.Rows[r]["ACTIVEDATE"]);
                CURRENCY = dt.Rows[r]["CURRENCY"].ToString();
                PLANCODE = dt.Rows[r]["PLANCODE"].ToString();
                SINGLERATE_TARRIF = Convert.ToDecimal(dt.Rows[r]["SINGLERATETARRIF"]);
                SINGLERATE_PLAN = Convert.ToDecimal(dt.Rows[r]["SINGLERATEPLAN"]);
                DOUBLERATE_TARRIF = Convert.ToDecimal(dt.Rows[r]["DOUBLERATETARRIF"]);
                DOUBLERATE_PLAN = Convert.ToDecimal(dt.Rows[r]["DOUBLERATEPLAN"]);
                TRIPLERATE_TARRIF = Convert.ToDecimal(dt.Rows[r]["TRIPLERATETARRIF"]);
                TRIPLERATE_PLAN = Convert.ToDecimal(dt.Rows[r]["TRIPLERATEPLAN"]);
                QUADRATE_TARRIF = Convert.ToDecimal(dt.Rows[r]["QUADRATETARRIF"]);
                QUADRATE_PLAN = Convert.ToDecimal(dt.Rows[r]["QUADRATEPLAN"]);
                ADULT_EXTRABADCOST = Convert.ToDecimal(dt.Rows[r]["ADULT-EXTRABEDCOST"]);
                CHILD_EXTRABEDCOST = Convert.ToDecimal(dt.Rows[r]["CHILD-EXTRABEDCOST"]);
                STATUS = dt.Rows[r]["STATUS"].ToString();
                COMMON_PRICE = Convert.ToDecimal(dt.Rows[r]["COMMONPRICE"]);
                COMMON_PLAN = Convert.ToDecimal(dt.Rows[r]["COMMONPLAN"]);
                AMENITY_NAMES = dt.Rows[r]["AMENITIES"].ToString();
                if (button == "add")
                {
                    INSERT();
                }
                if (button == "modify")
                {
                    UPDATE();
                }
            }
        }

        public void INSERT_INTO_PLANCODE()
        {
            string S = "INSERT INTO ROOMMASTER_PLAN(ROOM_NO,PLAN_CODE,SINGLE_PLAN,DOUBLE_PLAN,TRIPLE_PLAN,QUAD_PLAN,COMMON_PLAN,INSERT_BY,INSERT_DATE)VALUES(@ROOM_NO,@PLAN_CODE,@SINGLE_PLAN,@DOUBLE_PLAN,@TRIPLE_PLAN,@QUAD_PLAN,@COMMON_PLAN,@INSERT_BY,@INSERT_DATE)";
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@ROOM_NO", ROOM_NO);
            list.AddSqlParameter("@PLAN_CODE", PLANCODE);
            list.AddSqlParameter("@SINGLE_PLAN", SINGLERATE_PLAN);
            list.AddSqlParameter("@DOUBLE_PLAN", DOUBLERATE_PLAN);
            list.AddSqlParameter("@TRIPLE_PLAN", TRIPLERATE_PLAN);
            list.AddSqlParameter("@QUAD_PLAN", QUADRATE_PLAN);
            list.AddSqlParameter("@COMMON_PLAN", COMMON_PLAN);
            list.AddSqlParameter("@INSERT_BY", INSERT_BY);
            list.AddSqlParameter("@INSERT_DATE", INSERT_DATE);
            DbFunctions.ExecuteCommand<int>(S, list);
        }
        public int GETPLANCODE_ROOMNO_MATCH()
        {
            int A = 0;
            var LIST = new List<SqlParameter>();
            String S = "SELECT PLAN_CODE FROM ROOMMASTER_PLAN WHERE ROOM_NO=@ROOM_NO AND  PLAN_CODE=@PLAN_CODE ";
            LIST.AddSqlParameter("@ROOM_NO", ROOM_NO);
            LIST.AddSqlParameter("@PLAN_CODE", PLANCODE);
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(S, LIST);
            if (DT.Rows.Count == 0)
            {
                A = 0;
            }
            if (DT.Rows.Count > 0)
            {
                A = 1;
            }
            return A;
        }

        public void UPDATE()
        {
            int a = GETROOMNO();
            if (a == 1)
            {
                String S = "UPDATE ROOMMASTER SET ROOM_CATEGORY=@ROOM_CATEGORY,ROOM_VIEW=@ROOM_VIEW,MAX_PAX=@MAX_PAX,ACTIVE_DATE=@ACTIVE_DATE,CURRENCY=@CURRENCY,SINGLERATE_TARRIF=@SINGLERATE_TARRIF,DOUBLERATE_TARRIF=@DOUBLERATE_TARRIF,TRIPLERATE_TARRIF=@TRIPLERATE_TARRIF,QUADRATE_TARRIF=@QUADRATE_TARRIF,COMMON_PRICE=@COMMON_PRICE,EXTRABED_ADULT=@EXTRABED_ADULT,EXTRABED_CHILD=@EXTRABED_CHILD,STATUS=@STATUS WHERE ROOM_NO=@ROOM_NO";
                var listParams = new List<SqlParameter>();
                listParams.AddSqlParameter("@ROOM_NO", ROOM_NO);
                listParams.AddSqlParameter("@ROOM_CATEGORY", ROOM_CATEGORY);
                listParams.AddSqlParameter("@ROOM_VIEW", ROOM_VIEW);
                listParams.AddSqlParameter("@MAX_PAX", MAX_PAX);
                listParams.AddSqlParameter("@ACTIVE_DATE", ACTIVE_CALENDER);
                listParams.AddSqlParameter("@CURRENCY", CURRENCY);
                listParams.AddSqlParameter("@SINGLERATE_TARRIF", SINGLERATE_TARRIF);
                listParams.AddSqlParameter("@DOUBLERATE_TARRIF", DOUBLERATE_TARRIF);
                listParams.AddSqlParameter("@TRIPLERATE_TARRIF", TRIPLERATE_TARRIF);
                listParams.AddSqlParameter("@QUADRATE_TARRIF", QUADRATE_TARRIF);
                listParams.AddSqlParameter("@COMMON_PRICE", COMMON_PRICE);
                listParams.AddSqlParameter("@EXTRABED_ADULT", ADULT_EXTRABADCOST);
                listParams.AddSqlParameter("@EXTRABED_CHILD", CHILD_EXTRABEDCOST);
                listParams.AddSqlParameter("@STATUS", STATUS);
                //listParams.AddSqlParameter("@USER_NAME", USER_NAME);
                listParams.AddSqlParameter("@UPDATE_BY", login.u);
                listParams.AddSqlParameter("@UPDATE_DATE", DateTime.Today);
                DbFunctions.ExecuteCommand<int>(S, listParams);

                UPDATE_PLANCODE();
                UPDATE_AMENITY_ENABLE(ROOM_NO);
                if (AMENITY_NAMES == null)
                {

                }
                else
                {

                    string res = AMENITY_NAMES.ToString();
                    string[] values = res.Split(' ');
                    for (int i = 1; i < values.Length; i++)
                    {
                        values[i] = values[i].Trim();
                        int A = GET_AMENITY_STATUS(values[i]);
                        if (A == 1)
                        {
                            string I = "UPDATE  ROOMMASTER_AMENITY SET ENABLE=@ENABLE,UPDATE_BY=@UPDATE_BY,UPDATE_DATE=@UPDATE_DATE WHERE ROOM_NO=@ROOM_NO AND AMENITY=@AMENITY";
                            var l = new List<SqlParameter>();
                            l.AddSqlParameter("@ROOM_NO", ROOM_NO);
                            l.AddSqlParameter("@AMENITY", values[i]);
                            l.AddSqlParameter("@UPDATE_BY", login.u);
                            l.AddSqlParameter("@ENABLE", "yes");
                            l.AddSqlParameter("@UPDATE_DATE", DateTime.Today);
                            DbFunctions.ExecuteCommand<int>(I, l);
                        }
                        else
                        {
                            String I = "INSERT INTO ROOMMASTER_AMENITY(ROOM_NO,AMENITY,ENABLE,INSERT_BY,INSERT_DATE)VALUES(@ROOM_NO,@AMENITY,@ENABLE,@INSERT_BY,@INSERT_DATE)";
                            var l = new List<SqlParameter>();
                            l.AddSqlParameter("@ROOM_NO", ROOM_NO);
                            l.AddSqlParameter("@AMENITY", values[i]);
                            l.AddSqlParameter("@INSERT_BY", login.u);
                            l.AddSqlParameter("@INSERT_DATE", DateTime.Today);
                            l.AddSqlParameter("@ENABLE", "yes");

                            DbFunctions.ExecuteCommand<int>(I, l);
                        }
                    }
                }
                if (a != 0)
                {
                    int B = GETPLANCODE_ROOMNO_MATCH();
                    if (B == 1)
                    {
                        UPDATE_PLANCODE();
                    }
                    else
                    {
                        INSERT_BY = login.u;
                        INSERT_DATE = DateTime.Today.Date;
                        INSERT_INTO_PLANCODE();
                        
                    }
                }
            }
        }
        public void UPDATE_AMENITY_ENABLE(int A)
        {
            string S = "UPDATE ROOMMASTER_AMENITY SET ENABLE=@ENABLE WHERE ROOM_NO=@ROOM_NO";
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@ENABLE", "no");
            LIST.AddSqlParameter("@ROOM_NO", A);
            DbFunctions.ExecuteCommand<int>(S, LIST);
        }
        public int GET_AMENITY_STATUS(string S)
        {
            string AMENITY = "SELECT COUNT(AMENITY) FROM ROOMMASTER_AMENITY WHERE ROOM_NO=@ROOM_NO AND AMENITY=@AMENITY ";
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@ROOM_NO", ROOM_NO);
            LIST.AddSqlParameter("@AMENITY", S);
            int A = Convert.ToInt16(DbFunctions.ExecuteCommand<object>(AMENITY, LIST));
            return A;

        }
        public void UPDATE_PLANCODE()
        {
            string S = "UPDATE ROOMMASTER_PLAN SET SINGLE_PLAN=@SINGLE_PLAN,DOUBLE_PLAN=@DOUBLE_PLAN,TRIPLE_PLAN=@TRIPLE_PLAN,QUAD_PLAN=@QUAD_PLAN,COMMON_PLAN=@COMMON_PLAN,UPDATE_BY=@UPDATE_BY,UPDATE_DATE=@UPDATE_DATE WHERE ROOM_NO=@ROOM_NO AND PLAN_CODE=@PLAN_CODE";
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@ROOM_NO", ROOM_NO);
            list.AddSqlParameter("@PLAN_CODE", PLANCODE);
            list.AddSqlParameter("@SINGLE_PLAN", SINGLERATE_PLAN);
            list.AddSqlParameter("@DOUBLE_PLAN", DOUBLERATE_PLAN);
            list.AddSqlParameter("@TRIPLE_PLAN", TRIPLERATE_PLAN);
            list.AddSqlParameter("@QUAD_PLAN", QUADRATE_PLAN);
            list.AddSqlParameter("@COMMON_PLAN", COMMON_PLAN);
            list.AddSqlParameter("@UPDATE_BY", login.u);
            list.AddSqlParameter("@UPDATE_DATE", DateTime.Today);
            DbFunctions.ExecuteCommand<int>(S, list);
        }
        public List<SqlParameter> GETBINDEDDATA()
        {
            var listParams = new List<SqlParameter>();
            return listParams;
        }

        public int GETROOMNO()
        {
            //connections();
            //con = new SqlConnection(connection);
            //con.Open();
            String S = "SELECT COUNT(ROOM_NO) FROM ROOMMASTER WHERE ROOM_NO=@ROOM_NO";
            var listParams = new List<SqlParameter>();
            listParams.AddSqlParameter("@ROOM_NO", ROOM_NO);
            // SqlCommand CM = new SqlCommand(S, con);
            //CM.Parameters.AddWithValue("@ROOMNO", ROOM_NO);
            int A = Convert.ToInt16(DbFunctions.ExecuteCommand<Object>(S, listParams));
            // int A =Convert.ToInt16( CM.ExecuteScalar());
            //con.Close();
            return A;

        }

        public DataTable fetch_PLANCODE_MODIFY()
        {
            var listParams = new List<SqlParameter>();
            string S = "SELECT PLAN_CODE FROM ROOMMASTER_PLAN WHERE ROOM_NO=@ROOM_NO";
            listParams.AddSqlParameter("@ROOM_NO", ROOM_NO);
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(S, listParams);
            return d;
        }

        public DataTable fetchroomtype()
        {
            var listParams = new List<SqlParameter>();
            string s = "SELECT ROOM_CATEGORY FROM ROOMCATEGORY where STATUS = @status and ACTIVE_DATE <= @date ";
            listParams.AddSqlParameter("@status", "Active");
            DateTime dt = DateTime.Now;
            listParams.AddSqlParameter("@date", dt);
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, listParams);
            return d;
        }
        public DataTable fetchplancode()
        {
            var listParams = new List<SqlParameter>();
            string S = "SELECT PLAN_CODE FROM PLANCODES WHERE STATUS='Active' ";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(S, listParams);
            return d;
        }
        public DataTable FETCH_AMENITIES()
        {
            var listParams = new List<SqlParameter>();
            string addchecks = "SELECT AMENITY_NAME FROM AMENITIES WHERE STATUS='Active' ";
            DataTable DR = DbFunctions.ExecuteCommand<DataTable>(addchecks, listParams);
            return DR;
        }
        public DataTable SETMAXPAX(String S, String STR)
        {
            var listParams = new List<SqlParameter>();
            ROOM_CATEGORY = STR;
            // String S = "SELECT MAX_PAX FROM ROOMCATEGORY WHERE ROOM_TYPE='" + ROOM_CATEGORY+ "'";
            DataTable DR = DbFunctions.ExecuteCommand<DataTable>(S, listParams);
            return DR;
        }
        public int EXIST = 0;
        public DataTable GET_STATUS_OF_DATA()
        {
            DataTable DTB = null;
            if (ROOM_NO != 0)
            {

                int a = GETROOMNO();
                if (button == "add")
                {
                    if (a != 0)
                    {
                        EXIST = 1;
                        //validate here (room TEXTBOX)-------beacause we should not allow user to insert roomno which is already present.
                    }
                    else { EXIST = 0; }
                }

                if (button == "modify")
                {

                    if (a == 0)
                    {
                        match = 0;
                        CLEARBACK();
                        //validate here(PLANECODE TEXTBOX)    -------we should not allow user to add the roomno which is not present .
                    }
                    else
                    {
                        c = 1; match = 1;
                        string STR = "SELECT * FROM ROOMMASTER WHERE ROOM_NO=@ROOM_NO";
                        DTB = fetchdata(STR);

                    }
                }

            }
            return DTB;
        }
        public int c = 0; public int match = 0;
        public void CLEARBACK()
        {

            string S = string.Empty;

            ROOM_CATEGORY = S;
            ROOM_VIEW = S;
            MAX_PAX = 0;
            ACTIVE_CALENDER = Convert.ToDateTime("1998,04,30");
            CURRENCY = S;
            PLANCODE = S;
            SINGLERATE_PLAN = 0;
            SINGLERATE_TARRIF = 0;
            DOUBLERATE_PLAN = 0;
            DOUBLERATE_TARRIF = 0;
            TRIPLERATE_TARRIF = 0;
            TRIPLERATE_PLAN = 0;
            QUADRATE_TARRIF = 0;
            QUADRATE_PLAN = 0;
            COMMON_PRICE = 0;
            COMMON_PLAN = 0;
            ADULT_EXTRABADCOST = 0;
            CHILD_EXTRABEDCOST = 0;
            STATUS = S;
        }
        public DataTable fetchdata(string S)
        {

            var listParams = new List<SqlParameter>();
            listParams.AddSqlParameter("@ROOM_NO", ROOM_NO);
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, listParams);
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                ROOM_NO = Convert.ToInt16(dt.Rows[r]["ROOM_NO"]);
                ROOM_CATEGORY = dt.Rows[r]["ROOM_CATEGORY"].ToString();
                ROOM_VIEW = dt.Rows[r]["ROOM_VIEW"].ToString();
                MAX_PAX = Convert.ToInt16(dt.Rows[r]["MAX_PAX"]);
                ACTIVE_CALENDER = Convert.ToDateTime(dt.Rows[r]["ACTIVE_DATE"]);
                CURRENCY = dt.Rows[r]["CURRENCY"].ToString();
                SINGLERATE_TARRIF = Convert.ToDecimal(dt.Rows[r]["SINGLERATE_TARRIF"]);
                DOUBLERATE_TARRIF = Convert.ToDecimal(dt.Rows[r]["DOUBLERATE_TARRIF"]);
                TRIPLERATE_TARRIF = Convert.ToDecimal(dt.Rows[r]["TRIPLERATE_TARRIF"]);
                QUADRATE_TARRIF = Convert.ToDecimal(dt.Rows[r]["QUADRATE_TARRIF"]);
                COMMON_PRICE = Convert.ToDecimal(dt.Rows[r]["COMMON_PRICE"]);
                ADULT_EXTRABADCOST = Convert.ToDecimal(dt.Rows[r]["EXTRABED_ADULT"]);
                CHILD_EXTRABEDCOST = Convert.ToDecimal(dt.Rows[r]["EXTRABED_CHILD"]);
                STATUS = dt.Rows[r]["STATUS"].ToString();
            }
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@ROOM_NO", ROOM_NO);
            string ST = "SELECT AMENITY FROM ROOMMASTER_AMENITY WHERE ROOM_NO=@ROOM_NO";
            DataTable DATB = DbFunctions.ExecuteCommand<DataTable>(ST, list);
            return DATB;
        }
        public string GET_AMENITY(string S)
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@ROOM_NO", ROOM_NO);
            list.AddSqlParameter("@AMENITY", S);
            string ST = "SELECT ENABLE FROM ROOMMASTER_AMENITY WHERE ROOM_NO=@ROOM_NO AND AMENITY=@AMENITY";
            object A = DbFunctions.ExecuteCommand<object>(ST, list);
            string ENABLE = A.ToString();
            return ENABLE;
        }
        public void CLEARPLANCODEDATA()
        {
            String S = String.Empty;
            PLANCODE = S;
            SINGLERATE_PLAN = Convert.ToDecimal(S);
            DOUBLERATE_PLAN = Convert.ToDecimal(S);
            TRIPLERATE_PLAN = Convert.ToDecimal(S);
            QUADRATE_PLAN = Convert.ToDecimal(S);
            COMMON_PLAN = Convert.ToDecimal(S);
        }
        public void fetch_plancode_isselected()
        {
            var listParams = new List<SqlParameter>();
            listParams.AddSqlParameter("@PLAN_CODE", PLANCODE);
            listParams.AddSqlParameter("@ROOM_NO", ROOM_NO);
            String STR = "SELECT CONVERT(decimal(17,2),SINGLE_PLAN) AS SINGLE_PLAN,CONVERT(decimal(17,2),DOUBLE_PLAN) AS DOUBLE_PLAN,CONVERT(decimal(17,2),TRIPLE_PLAN) AS TRIPLE_PLAN,CONVERT(decimal(17,2),QUAD_PLAN) AS QUAD_PLAN,CONVERT(decimal(17,2),COMMON_PLAN) AS COMMON_PLAN FROM ROOMMASTER_PLAN WHERE ROOM_NO=@ROOM_NO AND PLAN_CODE=@PLAN_CODE";
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(STR, listParams);
            if (DT.Rows.Count == 0)
            {
                SINGLERATE_PLAN =decimal.Parse("0.00");
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
        }
        public string d = null;
        public DataTable setdata()
        {

            DataTable D = null;
            if (button == "modify")
            {
                string s = ROOM_NO.ToString();

                if (s != "")
                {
                    var listParams = new List<SqlParameter>();
                    listParams.AddSqlParameter("@ROOM_NO", ROOM_NO);
                    string S = "SELECT TOP 5 ROOM_NO FROM ROOMMASTER WHERE ROOM_NO LIKE '" + ROOM_NO + "%' ";
                    using (D = DbFunctions.ExecuteCommand<DataTable>(S, listParams))
                    {
                        d = Convert.ToString(ROOM_NO);

                    }
                }
                ROOM_NO = Convert.ToInt16(d);
            }
            return D;
        }
        public int count = 0; public int pc = 0;
        public void GETCOUNT()
        {
            count++;
            if (count >= 3)
            {
                if (d.Length != 2 && d.Length < 2)
                {
                    if (d.Length == 0)
                    {
                        ROOM_NO = Convert.ToInt16(""); count = 0; CLEARBACK(); pc = 1;
                    }
                }
            }
        }
        public void room()
        {
            var listParams = new List<SqlParameter>();
            string ss = "select * from ROOMMASTER where ROOM_CATEGORY = '" + ROOM_CATEGORY + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(ss, listParams);
            if (dt.Rows.Count == 0)
            {
                ROOM_NO = 0;
                ROOM_CATEGORY = "";
                ROOM_VIEW = "";
                MAX_PAX = 0;
                CURRENCY = "";
                SINGLERATE_TARRIF = Convert.ToDecimal("0.00");
                DOUBLERATE_TARRIF = Convert.ToDecimal("0.00");
                TRIPLERATE_TARRIF = Convert.ToDecimal("0.00");
                QUADRATE_TARRIF = Convert.ToDecimal("0.00");
                //COMMON_PRICE = Convert.ToDecimal(dt.Rows[0]["COMMON_PRICE"]);
                ADULT_EXTRABADCOST = Convert.ToDecimal("0.00");
                CHILD_EXTRABEDCOST = Convert.ToDecimal("0.00");
                STATUS = "";
            }
            else
            {
                ROOM_NO = Convert.ToInt16(dt.Rows[0]["ROOM_NO"]);
                ROOM_CATEGORY = dt.Rows[0]["ROOM_CATEGORY"].ToString();
                ROOM_VIEW = dt.Rows[0]["ROOM_VIEW"].ToString();
                MAX_PAX = Convert.ToInt16(dt.Rows[0]["MAX_PAX"]);
                ACTIVE_CALENDER = Convert.ToDateTime(dt.Rows[0]["ACTIVE_DATE"]);
                CURRENCY = dt.Rows[0]["CURRENCY"].ToString();
                SINGLERATE_TARRIF = Convert.ToDecimal(dt.Rows[0]["SINGLERATE_TARRIF"]);
                DOUBLERATE_TARRIF = Convert.ToDecimal(dt.Rows[0]["DOUBLERATE_TARRIF"]);
                TRIPLERATE_TARRIF = Convert.ToDecimal(dt.Rows[0]["TRIPLERATE_TARRIF"]);
                QUADRATE_TARRIF = Convert.ToDecimal(dt.Rows[0]["QUADRATE_TARRIF"]);
                //COMMON_PRICE = Convert.ToDecimal(dt.Rows[0]["COMMON_PRICE"]);
                ADULT_EXTRABADCOST = Convert.ToDecimal(dt.Rows[0]["EXTRABED_ADULT"]);
                CHILD_EXTRABEDCOST = Convert.ToDecimal(dt.Rows[0]["EXTRABED_CHILD"]);
                STATUS = dt.Rows[0]["STATUS"].ToString();
            }
        }
        public DataTable fill_mastergrid()
        {
            var list = new List<SqlParameter>();
             string s = "SELECT ROOM_NO,ROOM_CATEGORY,MAX_PAX,ACTIVE_DATE,STATUS FROM ROOMMASTER";
             DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable fill_masterdata()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT A.ROOM_NO,A.ROOM_CATEGORY,A.MAX_PAX,A.ACTIVE_DATE,A.STATUS,A.ROOM_VIEW,A.CURRENCY,CONVERT(decimal(17,2),SINGLERATE_TARRIF) AS SINGLERATE_TARRIF,CONVERT(decimal(17,2),DOUBLERATE_TARRIF) as DOUBLERATE_TARRIF,CONVERT(decimal(17,2),TRIPLERATE_TARRIF) as TRIPLERATE_TARRIF,CONVERT(decimal(17,2),QUADRATE_TARRIF) as QUADRATE_TARRIF,CONVERT(decimal(17,2),EXTRABED_ADULT) as EXTRABED_ADULT,CONVERT(decimal(17,2),EXTRABED_CHILD) as EXTRABED_CHILD,CONVERT(decimal(17,2),COMMON_PRICE) as COMMON_PRICE FROM ROOMMASTER A";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable plan()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT CONVERT(decimal(17,2),SINGLE_PLAN) AS SINGLE_PLAN,CONVERT(decimal(17,2),DOUBLE_PLAN) AS DOUBLE_PLAN,CONVERT(decimal(17,2),TRIPLE_PLAN) AS TRIPLE_PLAN,CONVERT(decimal(17,2),QUAD_PLAN) AS QUAD_PLAN FROM ROOMMASTER_PLAN WHERE ROOM_NO = '"+ROOM_NO+"' AND PLAN_CODE= '"+PLANCODE+"'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable planaa()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT CONVERT(decimal(17,2),SINGLE_PLAN) AS SINGLE_PLAN,CONVERT(decimal(17,2),DOUBLE_PLAN) AS DOUBLE_PLAN,CONVERT(decimal(17,2),TRIPLE_PLAN) AS TRIPLE_PLAN,CONVERT(decimal(17,2),QUAD_PLAN) AS QUAD_PLAN FROM ROOMMASTER_PLAN WHERE ROOM_NO = '" + ROOM_NO + "' AND PLAN_CODE= '" + RoomMaster.PC + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        public DataTable RoomTarrif()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT CONVERT(decimal(17,2),SINGLERATE_TARRIF)AS SINGLERATE_TARRIF,CONVERT(decimal(17,2),DOUBLERATE_TARRIF)AS DOUBLERATE_TARRIF,CONVERT(decimal(17,2),TRIPLERATE_TARRIF)AS TRIPLERATE_TARRIF,CONVERT(decimal(17,2),QUADRATE_TARRIF)AS QUADRATE_TARRIF,CONVERT(decimal(17,2),EXTRABED_ADULT) as EXTRABED_ADULT,CONVERT(decimal(17,2),EXTRABED_CHILD) as EXTRABED_CHILD,CONVERT(decimal(17,2),COMMON_PRICE) as COMMON_PRICE FROM ROOMMASTER WHERE ROOM_NO = '"+ROOM_NO+"'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return dt;
        }
        //public DataTable RoomPlan()
        //{
        //    var list = new List<SqlParameter>();
        //    string s = "SELECT PLAN_CODE FROM ROOMMASTER_PLAN WHERE ROOM_NO = '" + ROOM_NO + "'";
        //    DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);
        //    return dt;
        //}
    }
}