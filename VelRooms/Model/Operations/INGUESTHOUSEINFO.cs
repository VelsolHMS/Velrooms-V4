using DAL;
using HMS.View.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model
{
    public class INGUESTHOUSEINFOS
    {
        // public string HOUSEGUEST_ID { get; set; }
        public string ROOM_NO { get; set; }
        public string GUEST_NAME { get; set; }
        public string COMPANY_NAME { get; set; }
        public string Company_Gst { get; set; }
        public string ARRIVAL_DATE { get; set; }
        public string ARRIVAL_TIME { get; set; }
        public string DEPARTURE_DATE { get; set; }
        public string DEPARTURE_TIME { get; set; }
        public string CONTACT_NO { get; set; }
        public string EMAIL { get; set; }
        public string ID_TYPE { get; set; }
        public string ID_DATA { get; set; }
        //11/15/2017
        //public string USER_NAME { get; set; }
        public string INSERT_BY { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime UPDTAE_DATE { get; set; }
        public void INSERT()
        {
            var list = new List<SqlParameter>();
            //  list.AddSqlParameter("@HOUSEGUEST_ID", HOUSEGUEST_ID);
            list.AddSqlParameter("@ROOM_NO", ROOM_NO);
            list.AddSqlParameter("@GUEST_NAME", GUEST_NAME);
            list.AddSqlParameter("@COMPANY_NAME", COMPANY_NAME);
            list.AddSqlParameter("@Company_Gst", Company_Gst);
            list.AddSqlParameter("@ARRIVAL_DATE", ARRIVAL_DATE);
            list.AddSqlParameter("@ARRIVAL_TIME", ARRIVAL_TIME);
            list.AddSqlParameter("@DEPARTURE_DATE", DEPARTURE_DATE);
            list.AddSqlParameter("@DEPARTURE_TIME", DEPARTURE_TIME);
            list.AddSqlParameter("@CONTACT_NO", CONTACT_NO);
            list.AddSqlParameter("@EMAIL", EMAIL);
            list.AddSqlParameter("@ID_TYPE", ID_TYPE);
            list.AddSqlParameter("@ID_DATA", ID_DATA);
            // USER INSERT SRI INSERTBY
            //list.AddSqlParameter("@USER_NAME", USER_NAME);
            INSERT_BY = login.u;
            INSERT_DATE = DateTime.Today;
            list.AddSqlParameter("@INSERT_BY", INSERT_BY);
            list.AddSqlParameter("@INSERT_DATE", INSERT_DATE);
            //USER_NAME = login.u;

            string query = "IF EXISTS (SELECT ROOM_NO FROM  INGUESTHOUSEINFO  WHERE ROOM_NO=@ROOM_NO AND GUESTSTATUS = 0) BEGIN UPDATE  INGUESTHOUSEINFO SET GUEST_NAME=@GUEST_NAME,COMPANY_NAME=@COMPANY_NAME,ARRIVAL_DATE=@ARRIVAL_DATE,ARRIVAL_TIME=@ARRIVAL_TIME,DEPARTURE_DATE=@DEPARTURE_DATE,DEPARTURE_TIME=@DEPARTURE_TIME,CONTACT_NO=@CONTACT_NO,EMAIL=@EMAIL,INSERT_BY=@INSERT_BY,INSERT_DATE=@INSERT_DATE WHERE ROOM_NO=@ROOM_NO END ELSE BEGIN INSERT INTO INGUESTHOUSEINFO(ROOM_NO,GUEST_NAME,COMPANY_NAME,ARRIVAL_DATE,ARRIVAL_TIME,DEPARTURE_DATE,DEPARTURE_TIME,CONTACT_NO,EMAIL,ID_TYPE,ID_DATA,INSERT_BY,INSERT_DATE) VALUES (@ROOM_NO,@GUEST_NAME,@COMPANY_NAME,@ARRIVAL_DATE,@ARRIVAL_TIME,@DEPARTURE_DATE,@DEPARTURE_TIME,@CONTACT_NO,@EMAIL,@ID_TYPE,@ID_DATA,@INSERT_BY,@INSERT_DATE) END";
            DbFunctions.ExecuteCommand<int>(query, list);
        }

        public void UPDATE()
        {
            var list = new List<SqlParameter>();
            string S = "SELECT * FROM INGUESTHOUSEINFO WHERE ROOM_NO  = '" + ROOM_NO + "' ";

            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, list);
            //IN.ROOM_NO = dt.Rows[0][1].ToString();
            GUEST_NAME = dt.Rows[0][1].ToString();
            COMPANY_NAME = dt.Rows[0][2].ToString();
            ARRIVAL_DATE = dt.Rows[0][3].ToString();
            ARRIVAL_TIME = dt.Rows[0][4].ToString();
            DEPARTURE_DATE = dt.Rows[0][5].ToString();
            DEPARTURE_TIME = dt.Rows[0][6].ToString();
            CONTACT_NO = dt.Rows[0][7].ToString();
            EMAIL = dt.Rows[0][8].ToString();
        }

        public DataTable guest()
        {
            var list = new List<SqlParameter>();

            string s = "SELECT FIRSTNAME,COMPANY_NAME,ARRIVAL_DATE,ARRIVAL_TIME,DEPARTURE_DATE,MOBILE_NO,EMAIL,ID_TYPE,ID_DATA,Company_Gst FROM CHECKIN WHERE ROOM_NO = '" + ROOM_NO+"' AND CHECK_OUT = 0";
            DataTable DW= DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (DW.Rows.Count == 0)
            {
                Company_Gst = "";
                GUEST_NAME = "";
                COMPANY_NAME = "";
                ARRIVAL_DATE = "";
                ARRIVAL_TIME = "";
                DEPARTURE_DATE = "";
                DEPARTURE_TIME = "";
                CONTACT_NO = "";
                EMAIL = "";
                ID_TYPE = "";
                ID_DATA = "";
            }
            else
            {
                Company_Gst = DW.Rows[0]["Company_Gst"].ToString();
                GUEST_NAME = DW.Rows[0]["FIRSTNAME"].ToString();
                COMPANY_NAME = DW.Rows[0]["COMPANY_NAME"].ToString();
                ARRIVAL_DATE = DW.Rows[0]["ARRIVAL_DATE"].ToString();
                ARRIVAL_TIME = DW.Rows[0]["ARRIVAL_TIME"].ToString();
                DEPARTURE_DATE = DW.Rows[0]["DEPARTURE_DATE"].ToString();
                DEPARTURE_TIME = DW.Rows[0]["ARRIVAL_TIME"].ToString();
                CONTACT_NO = DW.Rows[0]["MOBILE_NO"].ToString();
                EMAIL = DW.Rows[0]["EMAIL"].ToString();
                ID_TYPE= DW.Rows[0]["ID_TYPE"].ToString();
                ID_DATA= DW.Rows[0]["ID_DATA"].ToString();
            }
            return DW;
        } 
        public void UPDTE()
        {
            var I = new List<SqlParameter>();
            string S = "UPDATE INGUESTHOUSEINFO SET GUESTSTATUS = 0 WHERE ROOM_NO='" + ROOM_NO + "' AND CONTACT_NO='" + CONTACT_NO + "' ";
            DbFunctions.ExecuteCommand<int>(S, I);
        }
        public void guestupdate()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@GUEST_NAME", GUEST_NAME);
            list.AddSqlParameter("@COMPANY_NAME", COMPANY_NAME);
            list.AddSqlParameter("@Company_Gst", Company_Gst);
            list.AddSqlParameter("@ARRIVAL_DATE", ARRIVAL_DATE);
            list.AddSqlParameter("@ARRIVAL_TIME", ARRIVAL_TIME);
            list.AddSqlParameter("@DEPARTURE_DATE", DEPARTURE_DATE);
            list.AddSqlParameter("@DEPARTURE_TIME", DEPARTURE_TIME);
            list.AddSqlParameter("@CONTACT_NO", CONTACT_NO);
            list.AddSqlParameter("@EMAIL", EMAIL);
            list.AddSqlParameter("@ID_TYPE", ID_TYPE);
            list.AddSqlParameter("@ID_DATA", ID_DATA);
            string s = "UPDATE CHECKIN SET FIRSTNAME=@GUEST_NAME,COMPANY_NAME=@COMPANY_NAME,DEPARTURE_DATE=@DEPARTURE_DATE,Company_Gst=@Company_Gst,MOBILE_NO=@CONTACT_NO,EMAIL=@EMAIL,ID_TYPE=@ID_TYPE,ID_DATA=@ID_DATA WHERE ROOM_NO='" + ROOM_NO + "' AND CHECK_OUT=0  ";
            DbFunctions.ExecuteCommand<int>(s,list);
        }
    }
}