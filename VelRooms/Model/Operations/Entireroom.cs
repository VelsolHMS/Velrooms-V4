using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.SqlClient;
using System.Windows;

namespace HMS.Model
{
    public class Entireroom
    {
        public string ROOM_TARIFF { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public DateTime INSERT_TIME { get; set; }
        public string ROOM_CATEGORY { get; set; }

        public int AUDIT_ID { get; set; }

        public DataTable GET_ROOMCATEGORY()
        {
            var listParams = new List<SqlParameter>();
            string S = "SELECT ROOM_CATEGORY FROM ROOMMASTER";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, listParams);
            return dt;
        }
        public DataTable GET_ROOM_NO(String R)
        {
            var listParams = new List<SqlParameter>();
            string S = "SELECT ROOM_NO FROM ROOMMASTER WHERE ROOM_CATEGORY='" + R + "'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, listParams);
            return dt;
        }
        public DataTable get_details(int A)
        {
            string s = "SELECT * FROM CHECKIN WHERE ROOM_NO=@ROOMNO";
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@ROOMNO", A);
            DataTable D = DbFunctions.ExecuteCommand<DataTable>(s, LIST);
            return D;
        }
        public string GET_BACKGROUND_COLOR(int A)
        {
            var LIST = new List<SqlParameter>();
            LIST.AddSqlParameter("@ROOMNO", A);
            string S = "SELECT BACKGROUND_COLOR FROM ROOMMASTER WHERE ROOM_NO=@ROOMNO";
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(S, LIST);
            string COLOR = DT.Rows[0]["BACKGROUND_COLOR"].ToString();
            return COLOR;
        }
        public DataTable GET_ROOM_NO_COLOR(string s)
        {
            var listParams = new List<SqlParameter>();
            string S = "SELECT ROOM_NO FROM ROOMMASTER WHERE ROOM_CATEGORY=@ROOMCATEGORY AND BACKGROUND_COLOR=@BGCOLOR";
            listParams.AddSqlParameter("@ROOMCATEGORY", s);
            listParams.AddSqlParameter("@BGCOLOR", "Green");
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(S, listParams);
            return dt;

        }
        public DataTable GET_ROOMCATEGORY_VACANT_ROOM(int A)
        {
            var LIST = new List<SqlParameter>();
            string S = "SELECT ROOM_CATEGORY FROM ROOMMASTER WHERE ROOM_NO=@ROOMNO";
            LIST.AddSqlParameter("@ROOMNO", A);
            DataTable DT = DbFunctions.ExecuteCommand<DataTable>(S, LIST);
            return DT;
        }
        public string arrivaldatee, arrivaltimee, arrivaltime, insertdatee, insert, inserttimee, inserttime;

        public int audithours, extrahours, totalhours;

        //Method To Get All Room Numbers Based On Color
        public DataTable night_auditing()
        {
            DateTime currentdatetime = DateTime.Now;
            DataTable alldata = new DataTable();
            DataTable dt2 = new DataTable();

            alldata.Columns.Add("ROOM_NO", typeof(int));
            alldata.Columns.Add("CHECKIN_ID", typeof(int));
            alldata.Columns.Add("CHARGED_TARRIF", typeof(decimal));

            dt2.Columns.Add("ROOM_NO", typeof(int));
            dt2.Columns.Add("CHECKIN_ID", typeof(int));
            dt2.Columns.Add("CHARGED_TARRIF", typeof(decimal));
            dt2.Columns.Add("CHARGED_EBED_ADULT", typeof(decimal));
            dt2.Columns.Add("CHARGED_EBED_CHILD", typeof(decimal));
            dt2.Columns.Add("TAX", typeof(decimal));

            var list = new List<SqlParameter>();
            string s = "SELECT ROOM_NO FROM ROOMMASTER WHERE BACKGROUND_COLOR = 'Orange'";
            DataTable dt = DbFunctions.ExecuteCommand<DataTable>(s, list);

            alldata.Merge(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                var list1 = new List<SqlParameter>();

                string query = "SELECT ROOM_NO, CHECKIN_ID, CHARGED_TARRIF, CHARGED_EBED_ADULT, CHARGED_EBED_CHILD,TAX FROM CHECKIN WHERE ROOM_NO = '" + dt.Rows[i]["ROOM_NO"] + "' AND CHECK_OUT = 0 ";
                DataTable dt1 = DbFunctions.ExecuteCommand<DataTable>(query, list1);
                DataRow row = dt2.NewRow();
                if (dt1.Rows.Count == 0)
                {

                }
                else
                {
                    row["ROOM_NO"] = dt1.Rows[0]["ROOM_NO"];
                    row["CHECKIN_ID"] = dt1.Rows[0]["CHECKIN_ID"];
                    row["CHARGED_TARRIF"] = dt1.Rows[0]["CHARGED_TARRIF"];
                    row["CHARGED_EBED_ADULT"] = dt1.Rows[0]["CHARGED_EBED_ADULT"];
                    row["CHARGED_EBED_CHILD"] = dt1.Rows[0]["CHARGED_EBED_CHILD"];
                    row["TAX"] = dt1.Rows[0]["TAX"];
                    dt2.Rows.Add(row);

                    string D = "SELECT MAX(AUDIT_ID) AS AUDIT_ID  FROM night_audit WHERE CHECKIN_ID = '" + dt2.Rows[i]["CHECKIN_ID"] + "' AND ROOM_NO='"+dt2.Rows[i]["ROOM_NO"]+"' AND NIGHT = 0";
                    DataTable sd = DbFunctions.ExecuteCommand<DataTable>(D, list1);
                    try
                    {
                        if (sd.Rows.Count == 0)
                        {
                            AUDIT_ID = 0;
                        }
                        else
                        {
                            AUDIT_ID = int.Parse(sd.Rows[0]["AUDIT_ID"].ToString());
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Checkout the last inserted room and recheckin the room");
                    }
                    //  var list1 = new List<SqlParameter>();
                    //string s1 = "SELECT INSERT_DATE, INSERT_TIME FROM NIGHT_AUDIT WHERE CHECKIN_ID = '" + dt2.Rows[i]["CHECKIN_ID"] + "' AND AUDIT_ID IN (SELECT MAX(AUDIT_ID) FROM NIGHT_AUDIT WHERE CHECKIN_ID = '" + dt2.Rows[i]["CHECKIN_ID"] + "' AND NIGHT=0)";
                    string s1 = "SELECT INSERT_DATE,(SELECT ARRIVAL_TIME from CHECKIN where CHECKIN_ID = NA.CHECKIN_ID) As INSERT_TIME FROM NIGHT_AUDIT NA WHERE AUDIT_ID='" + AUDIT_ID + "'";// AND NIGHT=0 
                    DataTable dt3 = DbFunctions.ExecuteCommand<DataTable>(s1, list1);
                    if (dt3.Rows.Count == 0)
                    {
                        //INSERT_DATE = "";
                        //INSERT_TIME = "";
                    }
                    else
                    {
                        INSERT_DATE = Convert.ToDateTime(dt3.Rows[0]["INSERT_DATE"]);
                        INSERT_TIME = Convert.ToDateTime(dt3.Rows[0]["INSERT_TIME"]);
                    }
                    // var list3 = new List<SqlParameter>();
                    string s2 = "SELECT HOURS12, HOURS24, EXTRAHOURS FROM HOTELINFO";
                    DataTable dt4 = DbFunctions.ExecuteCommand<DataTable>(s2, list1);
                    if (dt4.Rows[0]["HOURS12"].ToString() == "0")
                    {
                        audithours = 24;
                        extrahours = int.Parse(dt4.Rows[0]["EXTRAHOURS"].ToString());
                        totalhours = audithours + extrahours;
                    }
                    else
                    {
                        audithours = 12;
                        extrahours = int.Parse(dt4.Rows[0]["EXTRAHOURS"].ToString());
                        totalhours = audithours + extrahours;
                    }

                    //extrahours = int.Parse(dt4.Rows[0]["EXTRAHOURS"].ToString());
                    //totalhours = audithours + extrahours;

                    DateTime dateee = DateTime.Now;
                    DateTime time3 = new DateTime();
                    DateTime time4 = new DateTime();
                    int noofhours, noofdays;

                    arrivaldatee = dateee.ToShortDateString();
                    arrivaltimee = dateee.ToShortTimeString();
                    arrivaltime = dateee.ToString("HH:mm:ss");
                    insertdatee = INSERT_DATE.ToShortDateString();
                    //inserttimee = INSERT_TIME.ToShortDateString();
                    inserttime = INSERT_TIME.ToShortTimeString();

                    string s3 = insertdatee + " " + inserttime;
                    string s4 = arrivaldatee + " " + arrivaltime;

                    DateTime.TryParse(s3.ToString(), out time3);
                    DateTime.TryParse(s4.ToString(), out time4);

                    DateTime s5 = time3;
                    DateTime s6 = time4;

                    double hours = time4.Subtract(time3).TotalHours;
                    double days = time4.Subtract(time3).TotalDays;
                    noofdays = (int)days;
                    noofhours = (int)hours;

                    // noofhours = noofhours + extrahours;

                    if (audithours == 24)
                    {
                        if (noofhours >= totalhours)
                        {
                            int count = noofhours / totalhours;
                            int add = 1;

                            while (count != 0)
                            {
                                string checkid = dt1.Rows[0]["CHECKIN_ID"].ToString();
                                string roomno = dt1.Rows[0]["ROOM_NO"].ToString();
                                string charge = dt1.Rows[0]["CHARGED_TARRIF"].ToString();
                                string ebedadult = dt1.Rows[0]["CHARGED_EBED_ADULT"].ToString();
                                string ebedchild = dt1.Rows[0]["CHARGED_EBED_CHILD"].ToString();
                                string tax = dt1.Rows[0]["TAX"].ToString();

                                DateTime insert_date = Convert.ToDateTime(s3.ToString());

                                string insertdate = insert_date.Date.AddDays(add).ToShortDateString();
                                string inserttime1 = insert_date.AddHours(extrahours).ToShortTimeString();

                                // var list4 = new List<SqlParameter>();
                                list1.AddSqlParameter("@CHECKIN_ID", checkid);
                                list1.AddSqlParameter("@ROOM_NO", roomno);
                                list1.AddSqlParameter("@ROOM_TARIFF", charge);
                                list1.AddSqlParameter("@EXTRABED_ADULT", ebedadult);
                                list1.AddSqlParameter("@EXTRABED_CHILD", ebedchild);
                                list1.AddSqlParameter("@INSERT_DATE", insertdate);
                                list1.AddSqlParameter("@INSERT_TIME", inserttime1);
                                list1.AddSqlParameter("@TAX", tax);
                                insert = "INSERT INTO NIGHT_AUDIT(ROOM_NO, ROOM_TARRIF, EXTRABED_ADULT, EXTRABED_CHILD, CHECKIN_ID, INSERT_DATE, INSERT_TIME, NIGHT,GST) VALUES(@ROOM_NO, " +      
                                                       "@ROOM_TARIFF,@EXTRABED_ADULT,@EXTRABED_CHILD,@CHECKIN_ID,@INSERT_DATE,@INSERT_TIME,0,@TAX)";
                                add = add + 1;
                                count = count - 1;
                                if (count >= 0)
                                {
                                    DbFunctions.ExecuteCommand<int>(insert, list1);
                                    list1.Clear();
                                }    // DateTime date = dateee.AddHours(-(totalhours));
                            }
                        }
                    }
                }
            }
            return dt;
        }
    }
}
