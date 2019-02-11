using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.View;
using HMS.View.Operations;

namespace HMS.Model.Masters
{
    public class dashboard1
    {
        public string RESERVATION_NO { get; set; }
        public string FIRST_NAME { get; set; }
        public string NO_OF_ROOMS { get; set; }
        public string ARRIVAL_DATE { get; set; }
        public string CONTACT_NO { get; set; }

        public decimal checkintotal, discounttotal, miscellenoustotal, postchargestotal, paidoutstotal;

        // Method To Retrive Reservation Details
        public DataTable reservation_list()
        {
            var list = new List<SqlParameter>();
            // string query = "SELECT RESERVATION_ID,FIRSTNAME,NO_OF_ROOMS,ARRIVAL_DATE,MOBILE_NO FROM RESERVATION ";
            string query = "SELECT RESERVATION_ID,FIRSTNAME,NO_OF_ROOMS,ARRIVAL_DATE,MOBILE_NO,(SELECT SUM(AMOUNT_RECEIVED) FROM ADVANCE WHERE RESERVATION_ID =R.RESERVATION_ID) AS AMOUNT,(SELECT ARRIVAL_DATE FROM CHECKIN WHERE CHECKIN_ID=CHECKIN)AS BOOKINGDATE  FROM RESERVATION R";
            DataTable reserve = DbFunctions.ExecuteCommand<DataTable>(query, list);
            return reserve;
        }
        public DataTable reservation_advance()
        {
            var list = new List<SqlParameter>();
            //string srikar = "SELECT AMOUNT_RECEIVED FROM ADVANCE a, RESERVATION r WHERE a.RESERVATION_ID=r.RESERVATION_ID ";
            string srikar = "SELECT AMOUNT_RECEIVED,RESERVATION_ID FROM ADVANCE ";
            DataTable SRI = DbFunctions.ExecuteCommand<DataTable>(srikar, list);
            return SRI;

        }

        // public string pndng;

        // Method To Retrive Guest Information
        public DataTable guestinfo_list()
        {
            //pndng = Checkout.stotalpendingamount;
            var list = new List<SqlParameter>();
            //list.AddSqlParameter("@pndng", pndng);
            string query1 = "SELECT ROOM_NO,GUEST_NAME,ARRIVAL_DATE,ARRIVAL_TIME,CONTACT_NO FROM INGUESTHOUSEINFO WHERE GUESTSTATUS=0 ";
            DataTable guestinfo = DbFunctions.ExecuteCommand<DataTable>(query1, list);
            return guestinfo;
        }
        //public DataTable DDD()
        //{
        //    var LIST = new List<SqlParameter>();
        //    string S="SELECT FROM "


        //}

        public DataTable roomcheckin_count()
        {
            var list = new List<SqlParameter>();
            string query3 = "SELECT SUM(CHARGED_TARRIF) AS TOTAL_TARIFF FROM CHECKIN";
            DataTable checkin_count = DbFunctions.ExecuteCommand<DataTable>(query3, list);
            decimal.TryParse(checkin_count.Rows[0]["TOTAL_TARIFF"].ToString(), out checkintotal);
            return checkin_count;
        }

        public DataTable discount_count()
        {
            var list = new List<SqlParameter>();
            string query3 = "SELECT SUM(AMOUNT) AS TOTAL_TARIFF FROM DISCOUNT";
            DataTable discount_count = DbFunctions.ExecuteCommand<DataTable>(query3, list);
            decimal.TryParse(discount_count.Rows[0]["TOTAL_TARIFF"].ToString(), out discounttotal);
            return discount_count;
        }

        public DataTable miscellenous_count()
        {
            var list = new List<SqlParameter>();
            string query3 = "SELECT SUM(TOTAL_AMOUNT) AS TOTAL_TARIFF FROM MISCELLENOUS";
            DataTable miscellenous_count = DbFunctions.ExecuteCommand<DataTable>(query3, list);
            decimal.TryParse(miscellenous_count.Rows[0]["TOTAL_TARIFF"].ToString(), out miscellenoustotal);
            return miscellenous_count;
        }

        public DataTable postcharges_count()
        {
            var list = new List<SqlParameter>();
            string query3 = "SELECT SUM(TOTAL_AMOUNT) AS TOTAL_TARIFF FROM POSTCHARGES";
            DataTable postcharges_count = DbFunctions.ExecuteCommand<DataTable>(query3, list);
            decimal.TryParse(postcharges_count.Rows[0]["TOTAL_TARIFF"].ToString(), out postchargestotal);
            return postcharges_count;
        }

        public DataTable paidouts_count()
        {
            var list = new List<SqlParameter>();
            string query3 = "SELECT SUM(AMOUNT) AS TOTAL_TARIFF FROM PAIDOUT";
            DataTable paidouts_count = DbFunctions.ExecuteCommand<DataTable>(query3, list);
            decimal.TryParse(paidouts_count.Rows[0]["TOTAL_TARIFF"].ToString(), out paidoutstotal);
            return paidouts_count;
        }

        public decimal JAN = 0;


        public DataTable jan()
        {
            var list = new List<SqlParameter>();
            string srikar = "SELECT DISTINCT(SELECT SUM(CHARGED_TARRIF) FROM CHECKIN WHERE YEAR(INSERT_DATE)=YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 1) AS AMOUNT,(SELECT SUM(AMOUNT) FROM PAIDOUT WHERE YEAR(INSERT_DATE)=YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 1) AS PAIDOUTS,(SELECT SUM(TOTAL_AMOUNT) FROM MISCELLENOUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 1) AS MISCELLENOUSAMOUNT,(SELECT SUM(AMOUNT) FROM DISCOUNT WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 1) AS DISCOUNT,(SELECT SUM(CHARGES) FROM POSTCHARGES WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 1) AS POSTCHARGES FROM CHECKIN ";
            DataTable data = DbFunctions.ExecuteCommand<DataTable>(srikar, list);
            if (data.Rows.Count == 0)
            {
                JAN = 0;
            }
            else
            {
                if (data.Rows[0]["AMOUNT"].ToString() == "")
                {
                    JAN += 0;
                }
                else
                {
                    JAN += decimal.Parse(data.Rows[0]["AMOUNT"].ToString());
                }
                if (data.Rows[0]["PAIDOUTS"].ToString() == "")
                {
                    JAN += 0;
                }
                else
                {
                    JAN += decimal.Parse(data.Rows[0]["PAIDOUTS"].ToString());
                }
                if (data.Rows[0]["MISCELLENOUSAMOUNT"].ToString() == "")
                {
                    JAN += 0;
                }
                else
                {
                    JAN += decimal.Parse(data.Rows[0]["MISCELLENOUSAMOUNT"].ToString());
                }
                if (data.Rows[0]["DISCOUNT"].ToString() == "")
                {
                    JAN += 0;
                }
                else
                {
                    JAN += decimal.Parse(data.Rows[0]["DISCOUNT"].ToString());
                }
                if (data.Rows[0]["POSTCHARGES"].ToString() == "")
                {
                    JAN += 0;
                }
                else
                {
                    JAN += decimal.Parse(data.Rows[0]["POSTCHARGES"].ToString());
                }
            }
            return data;

        }
        public decimal FEB = 0;


        public DataTable feb()
        {
            var list = new List<SqlParameter>();
            string srikar = "SELECT DISTINCT(SELECT SUM(CHARGED_TARRIF) FROM CHECKIN WHERE YEAR(INSERT_DATE)=YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 2) AS AMOUNT,(SELECT SUM(AMOUNT) FROM PAIDOUT WHERE YEAR(INSERT_DATE)=YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 2) AS PAIDOUTS,(SELECT SUM(TOTAL_AMOUNT) FROM MISCELLENOUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 2) AS MISCELLENOUSAMOUNT,(SELECT SUM(AMOUNT) FROM DISCOUNT WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 2) AS DISCOUNT,(SELECT SUM(CHARGES) FROM POSTCHARGES WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 2) AS POSTCHARGES FROM CHECKIN ";
            DataTable data = DbFunctions.ExecuteCommand<DataTable>(srikar, list);
            if (data.Rows.Count == 0)
            {
                FEB = 0;
            }
            else
            {
                if (data.Rows[0]["AMOUNT"].ToString() == "")
                {
                    FEB += 0;
                }
                else
                {
                    FEB += decimal.Parse(data.Rows[0]["AMOUNT"].ToString());
                }
                if (data.Rows[0]["PAIDOUTS"].ToString() == "")
                {
                    FEB += 0;
                }
                else
                {
                    FEB += decimal.Parse(data.Rows[0]["PAIDOUTS"].ToString());
                }
                if (data.Rows[0]["MISCELLENOUSAMOUNT"].ToString() == "")
                {
                    FEB += 0;
                }
                else
                {
                    FEB += decimal.Parse(data.Rows[0]["MISCELLENOUSAMOUNT"].ToString());
                }
                if (data.Rows[0]["DISCOUNT"].ToString() == "")
                {
                    FEB += 0;
                }
                else
                {
                    FEB += decimal.Parse(data.Rows[0]["DISCOUNT"].ToString());
                }
                if (data.Rows[0]["POSTCHARGES"].ToString() == "")
                {
                    FEB += 0;
                }
                else
                {
                    FEB += decimal.Parse(data.Rows[0]["POSTCHARGES"].ToString());
                }
            }
            return data;

        }
        public decimal MAR = 0;


        public DataTable mar()
        {
            var list = new List<SqlParameter>();
            string srikar = "SELECT DISTINCT(SELECT SUM(CHARGED_TARRIF) FROM CHECKIN WHERE YEAR(INSERT_DATE)=YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 3) AS AMOUNT,(SELECT SUM(AMOUNT) FROM PAIDOUT WHERE YEAR(INSERT_DATE)=YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 3) AS PAIDOUTS,(SELECT SUM(TOTAL_AMOUNT) FROM MISCELLENOUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 3) AS MISCELLENOUSAMOUNT,(SELECT SUM(AMOUNT) FROM DISCOUNT WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 3) AS DISCOUNT,(SELECT SUM(CHARGES) FROM POSTCHARGES WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 3) AS POSTCHARGES FROM CHECKIN ";
            DataTable data = DbFunctions.ExecuteCommand<DataTable>(srikar, list);
            if (data.Rows.Count == 0)
            {
                MAR = 0;
            }
            else
            {
                if (data.Rows[0]["AMOUNT"].ToString() == "")
                {
                    MAR += 0;
                }
                else
                {
                    MAR += decimal.Parse(data.Rows[0]["AMOUNT"].ToString());
                }
                if (data.Rows[0]["PAIDOUTS"].ToString() == "")
                {
                    MAR += 0;
                }
                else
                {
                    MAR += decimal.Parse(data.Rows[0]["PAIDOUTS"].ToString());
                }
                if (data.Rows[0]["MISCELLENOUSAMOUNT"].ToString() == "")
                {
                    MAR += 0;
                }
                else
                {
                    MAR += decimal.Parse(data.Rows[0]["MISCELLENOUSAMOUNT"].ToString());
                }
                if (data.Rows[0]["DISCOUNT"].ToString() == "")
                {
                    MAR += 0;
                }
                else
                {
                    MAR += decimal.Parse(data.Rows[0]["DISCOUNT"].ToString());
                }
                if (data.Rows[0]["POSTCHARGES"].ToString() == "")
                {
                    MAR += 0;
                }
                else
                {
                    MAR += decimal.Parse(data.Rows[0]["POSTCHARGES"].ToString());
                }
            }
            return data;

        }
        public decimal APR = 0;


        public DataTable apr()
        {
            var list = new List<SqlParameter>();
            string srikar = "SELECT DISTINCT(SELECT SUM(CHARGED_TARRIF) FROM CHECKIN WHERE YEAR(INSERT_DATE)=YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 4) AS AMOUNT,(SELECT SUM(AMOUNT) FROM PAIDOUT WHERE YEAR(INSERT_DATE)=YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 4) AS PAIDOUTS,(SELECT SUM(TOTAL_AMOUNT) FROM MISCELLENOUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 4) AS MISCELLENOUSAMOUNT,(SELECT SUM(AMOUNT) FROM DISCOUNT WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 4) AS DISCOUNT,(SELECT SUM(CHARGES) FROM POSTCHARGES WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 4) AS POSTCHARGES FROM CHECKIN ";
            DataTable data = DbFunctions.ExecuteCommand<DataTable>(srikar, list);
            if (data.Rows.Count == 0)
            {
                APR = 0;
            }
            else
            {
                if (data.Rows[0]["AMOUNT"].ToString() == "")
                {
                    APR += 0;
                }
                else
                {
                    APR += decimal.Parse(data.Rows[0]["AMOUNT"].ToString());
                }
                if (data.Rows[0]["PAIDOUTS"].ToString() == "")
                {
                    APR += 0;
                }
                else
                {
                    APR += decimal.Parse(data.Rows[0]["PAIDOUTS"].ToString());
                }
                if (data.Rows[0]["MISCELLENOUSAMOUNT"].ToString() == "")
                {
                    APR += 0;
                }
                else
                {
                    APR += decimal.Parse(data.Rows[0]["MISCELLENOUSAMOUNT"].ToString());
                }
                if (data.Rows[0]["DISCOUNT"].ToString() == "")
                {
                    APR += 0;
                }
                else
                {
                    APR += decimal.Parse(data.Rows[0]["DISCOUNT"].ToString());
                }
                if (data.Rows[0]["POSTCHARGES"].ToString() == "")
                {
                    APR += 0;
                }
                else
                {
                    APR += decimal.Parse(data.Rows[0]["POSTCHARGES"].ToString());
                }
            }
            return data;

        }
        public decimal MAY = 0;


        public DataTable may()
        {
            var list = new List<SqlParameter>();
            string srikar = "SELECT DISTINCT(SELECT SUM(CHARGED_TARRIF) FROM CHECKIN WHERE YEAR(INSERT_DATE)=YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 5) AS AMOUNT,(SELECT SUM(AMOUNT) FROM PAIDOUT WHERE YEAR(INSERT_DATE)=YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 5) AS PAIDOUTS,(SELECT SUM(TOTAL_AMOUNT) FROM MISCELLENOUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 5) AS MISCELLENOUSAMOUNT,(SELECT SUM(AMOUNT) FROM DISCOUNT WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 5) AS DISCOUNT,(SELECT SUM(CHARGES) FROM POSTCHARGES WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 5) AS POSTCHARGES FROM CHECKIN ";
            DataTable data = DbFunctions.ExecuteCommand<DataTable>(srikar, list);
            if (data.Rows.Count == 0)
            {
                MAY = 0;
            }
            else
            {
                if (data.Rows[0]["AMOUNT"].ToString() == "")
                {
                    MAY += 0;
                }
                else
                {
                    MAY += decimal.Parse(data.Rows[0]["AMOUNT"].ToString());
                }
                if (data.Rows[0]["PAIDOUTS"].ToString() == "")
                {
                    MAY += 0;
                }
                else
                {
                    MAY += decimal.Parse(data.Rows[0]["PAIDOUTS"].ToString());
                }
                if (data.Rows[0]["MISCELLENOUSAMOUNT"].ToString() == "")
                {
                    MAY += 0;
                }
                else
                {
                    MAY += decimal.Parse(data.Rows[0]["MISCELLENOUSAMOUNT"].ToString());
                }
                if (data.Rows[0]["DISCOUNT"].ToString() == "")
                {
                    MAY += 0;
                }
                else
                {
                    MAY += decimal.Parse(data.Rows[0]["DISCOUNT"].ToString());
                }
                if (data.Rows[0]["POSTCHARGES"].ToString() == "")
                {
                    MAY += 0;
                }
                else
                {
                    MAY += decimal.Parse(data.Rows[0]["POSTCHARGES"].ToString());
                }
            }
            return data;

        }
        public decimal JUNE = 0;


        public DataTable june()
        {
            var list = new List<SqlParameter>();
            string srikar = "SELECT DISTINCT(SELECT SUM(CHARGED_TARRIF) FROM CHECKIN WHERE YEAR(INSERT_DATE)=YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 6) AS AMOUNT,(SELECT SUM(AMOUNT) FROM PAIDOUT WHERE YEAR(INSERT_DATE)=YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 6) AS PAIDOUTS,(SELECT SUM(TOTAL_AMOUNT) FROM MISCELLENOUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 6) AS MISCELLENOUSAMOUNT,(SELECT SUM(AMOUNT) FROM DISCOUNT WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 6) AS DISCOUNT,(SELECT SUM(CHARGES) FROM POSTCHARGES WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 6) AS POSTCHARGES FROM CHECKIN ";
            DataTable data = DbFunctions.ExecuteCommand<DataTable>(srikar, list);
            if (data.Rows.Count == 0)
            {
                JUNE = 0;
            }
            else
            {
                if (data.Rows[0]["AMOUNT"].ToString() == "")
                {
                    JUNE += 0;
                }
                else
                {
                    JUNE += decimal.Parse(data.Rows[0]["AMOUNT"].ToString());
                }
                if (data.Rows[0]["PAIDOUTS"].ToString() == "")
                {
                    JUNE += 0;
                }
                else
                {
                    JUNE += decimal.Parse(data.Rows[0]["PAIDOUTS"].ToString());
                }
                if (data.Rows[0]["MISCELLENOUSAMOUNT"].ToString() == "")
                {
                    JUNE += 0;
                }
                else
                {
                    JUNE += decimal.Parse(data.Rows[0]["MISCELLENOUSAMOUNT"].ToString());
                }
                if (data.Rows[0]["DISCOUNT"].ToString() == "")
                {
                    JUNE += 0;
                }
                else
                {
                    JUNE += decimal.Parse(data.Rows[0]["DISCOUNT"].ToString());
                }
                if (data.Rows[0]["POSTCHARGES"].ToString() == "")
                {
                    JUNE += 0;
                }
                else
                {
                    JUNE += decimal.Parse(data.Rows[0]["POSTCHARGES"].ToString());
                }
            }
            return data;

        }
        public decimal JULY = 0;


        public DataTable july()
        {
            var list = new List<SqlParameter>();
            string srikar = "SELECT DISTINCT(SELECT SUM(CHARGED_TARRIF) FROM CHECKIN WHERE YEAR(INSERT_DATE)=YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 7) AS AMOUNT,(SELECT SUM(AMOUNT) FROM PAIDOUT WHERE YEAR(INSERT_DATE)=YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 7) AS PAIDOUTS,(SELECT SUM(TOTAL_AMOUNT) FROM MISCELLENOUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 7) AS MISCELLENOUSAMOUNT,(SELECT SUM(AMOUNT) FROM DISCOUNT WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 7) AS DISCOUNT,(SELECT SUM(CHARGES) FROM POSTCHARGES WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 7) AS POSTCHARGES FROM CHECKIN ";
            DataTable data = DbFunctions.ExecuteCommand<DataTable>(srikar, list);
            if (data.Rows.Count == 0)
            {
                JULY = 0;
            }
            else
            {
                if (data.Rows[0]["AMOUNT"].ToString() == "")
                {
                    JULY += 0;
                }
                else
                {
                    JULY += decimal.Parse(data.Rows[0]["AMOUNT"].ToString());
                }
                if (data.Rows[0]["PAIDOUTS"].ToString() == "")
                {
                    JULY += 0;
                }
                else
                {
                    JULY += decimal.Parse(data.Rows[0]["PAIDOUTS"].ToString());
                }
                if (data.Rows[0]["MISCELLENOUSAMOUNT"].ToString() == "")
                {
                    JULY += 0;
                }
                else
                {
                    JULY += decimal.Parse(data.Rows[0]["MISCELLENOUSAMOUNT"].ToString());
                }
                if (data.Rows[0]["DISCOUNT"].ToString() == "")
                {
                    JULY += 0;
                }
                else
                {
                    JULY += decimal.Parse(data.Rows[0]["DISCOUNT"].ToString());
                }
                if (data.Rows[0]["POSTCHARGES"].ToString() == "")
                {
                    JULY += 0;
                }
                else
                {
                    JULY += decimal.Parse(data.Rows[0]["POSTCHARGES"].ToString());
                }
            }
            return data;

        }
        public decimal AUG = 0;


        public DataTable aug()
        {
            var list = new List<SqlParameter>();
            string srikar = "SELECT DISTINCT(SELECT SUM(CHARGED_TARRIF) FROM CHECKIN WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 8) AS AMOUNT,(SELECT SUM(AMOUNT) FROM PAIDOUT WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 8) AS PAIDOUTS,(SELECT SUM(TOTAL_AMOUNT) FROM MISCELLENOUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 8) AS MISCELLENOUSAMOUNT,(SELECT SUM(AMOUNT) FROM DISCOUNT WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 8) AS DISCOUNT,(SELECT SUM(CHARGES) FROM POSTCHARGES WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 8) AS POSTCHARGES FROM CHECKIN ";

            DataTable data = DbFunctions.ExecuteCommand<DataTable>(srikar, list);
            if (data.Rows.Count == 0)
            {
                AUG = 0;
            }
            else
            {
                if (data.Rows[0]["AMOUNT"].ToString() == "")
                {
                    AUG += 0;
                }
                else
                {
                    AUG += decimal.Parse(data.Rows[0]["AMOUNT"].ToString());
                }
                if (data.Rows[0]["PAIDOUTS"].ToString() == "")
                {
                    AUG += 0;
                }
                else
                {
                    AUG += decimal.Parse(data.Rows[0]["PAIDOUTS"].ToString());
                }
                if (data.Rows[0]["MISCELLENOUSAMOUNT"].ToString() == "")
                {
                    AUG += 0;
                }
                else
                {
                    AUG += decimal.Parse(data.Rows[0]["MISCELLENOUSAMOUNT"].ToString());
                }
                if (data.Rows[0]["DISCOUNT"].ToString() == "")
                {
                    AUG += 0;
                }
                else
                {
                    AUG += decimal.Parse(data.Rows[0]["DISCOUNT"].ToString());
                }
                if (data.Rows[0]["POSTCHARGES"].ToString() == "")
                {
                    AUG += 0;
                }
                else
                {
                    AUG += decimal.Parse(data.Rows[0]["POSTCHARGES"].ToString());
                }
            }
            return data;
        }

        public decimal SEP = 0;


        public DataTable sep()
        {
            var list = new List<SqlParameter>();
            string srikar = "SELECT DISTINCT(SELECT SUM(CHARGED_TARRIF) FROM CHECKIN WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 9) AS AMOUNT,(SELECT SUM(AMOUNT) FROM PAIDOUT WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 9) AS PAIDOUTS,(SELECT SUM(TOTAL_AMOUNT) FROM MISCELLENOUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 9) AS MISCELLENOUSAMOUNT,(SELECT SUM(AMOUNT) FROM DISCOUNT WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 9) AS DISCOUNT,(SELECT SUM(CHARGES) FROM POSTCHARGES WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 9) AS POSTCHARGES FROM CHECKIN ";
            DataTable data = DbFunctions.ExecuteCommand<DataTable>(srikar, list);
            if (data.Rows.Count == 0)
            {
                SEP = 0;
            }
            else
            {
                if (data.Rows[0]["AMOUNT"].ToString() == "")
                {
                    SEP += 0;
                }
                else
                {
                    SEP += decimal.Parse(data.Rows[0]["AMOUNT"].ToString());
                }
                if (data.Rows[0]["PAIDOUTS"].ToString() == "")
                {
                    SEP += 0;
                }
                else
                {
                    SEP += decimal.Parse(data.Rows[0]["PAIDOUTS"].ToString());
                }
                if (data.Rows[0]["MISCELLENOUSAMOUNT"].ToString() == "")
                {
                    SEP += 0;
                }
                else
                {
                    SEP += decimal.Parse(data.Rows[0]["MISCELLENOUSAMOUNT"].ToString());
                }
                if (data.Rows[0]["DISCOUNT"].ToString() == "")
                {
                    SEP += 0;
                }
                else
                {
                    SEP += decimal.Parse(data.Rows[0]["DISCOUNT"].ToString());
                }
                if (data.Rows[0]["POSTCHARGES"].ToString() == "")
                {
                    SEP += 0;
                }
                else
                {
                    SEP += decimal.Parse(data.Rows[0]["POSTCHARGES"].ToString());
                }
            }
            return data;
        }
        public decimal OCT = 0;


        public DataTable oct()
        {
            var list = new List<SqlParameter>();
            string srikar = "SELECT DISTINCT(SELECT SUM(CHARGED_TARRIF) FROM CHECKIN WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 10) AS AMOUNT,(SELECT SUM(AMOUNT) FROM PAIDOUT WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 10) AS PAIDOUTS,(SELECT SUM(TOTAL_AMOUNT) FROM MISCELLENOUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 10) AS MISCELLENOUSAMOUNT,(SELECT SUM(AMOUNT) FROM DISCOUNT WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 10) AS DISCOUNT,(SELECT SUM(CHARGES) FROM POSTCHARGES WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 10) AS POSTCHARGES FROM CHECKIN ";
            DataTable data = DbFunctions.ExecuteCommand<DataTable>(srikar, list);
            if (data.Rows.Count == 0)
            {
                OCT = 0;
            }
            else
            {
                if (data.Rows[0]["AMOUNT"].ToString() == "")
                {
                    OCT += 0;
                }
                else
                {
                    OCT += decimal.Parse(data.Rows[0]["AMOUNT"].ToString());
                }
                if (data.Rows[0]["PAIDOUTS"].ToString() == "")
                {
                    OCT += 0;
                }
                else
                {
                    OCT += decimal.Parse(data.Rows[0]["PAIDOUTS"].ToString());
                }
                if (data.Rows[0]["MISCELLENOUSAMOUNT"].ToString() == "")
                {
                    OCT += 0;
                }
                else
                {
                    OCT += decimal.Parse(data.Rows[0]["MISCELLENOUSAMOUNT"].ToString());
                }
                if (data.Rows[0]["DISCOUNT"].ToString() == "")
                {
                    OCT += 0;
                }
                else
                {
                    OCT += decimal.Parse(data.Rows[0]["DISCOUNT"].ToString());
                }
                if (data.Rows[0]["POSTCHARGES"].ToString() == "")
                {
                    OCT += 0;
                }
                else
                {
                    OCT += decimal.Parse(data.Rows[0]["POSTCHARGES"].ToString());
                }
            }
            return data;
        }
        public decimal NOV = 0;


        public DataTable nov()
        {
            var list = new List<SqlParameter>();
            string srikar = "SELECT DISTINCT(SELECT SUM(CHARGED_TARRIF) FROM CHECKIN WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 11) AS AMOUNT,(SELECT SUM(AMOUNT) FROM PAIDOUT WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 11) AS PAIDOUTS,(SELECT SUM(TOTAL_AMOUNT) FROM MISCELLENOUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 11) AS MISCELLENOUSAMOUNT,(SELECT SUM(AMOUNT) FROM DISCOUNT WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 11) AS DISCOUNT,(SELECT SUM(CHARGES) FROM POSTCHARGES WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 11) AS POSTCHARGES FROM CHECKIN ";
            DataTable data = DbFunctions.ExecuteCommand<DataTable>(srikar, list);
            if (data.Rows.Count == 0)
            {
                NOV = 0;
            }
            else
            {
                if (data.Rows[0]["AMOUNT"].ToString() == "")
                {
                    NOV += 0;
                }
                else
                {
                    NOV += decimal.Parse(data.Rows[0]["AMOUNT"].ToString());
                }
                if (data.Rows[0]["PAIDOUTS"].ToString() == "")
                {
                    NOV += 0;
                }
                else
                {
                    NOV += decimal.Parse(data.Rows[0]["PAIDOUTS"].ToString());
                }
                if (data.Rows[0]["MISCELLENOUSAMOUNT"].ToString() == "")
                {
                    NOV += 0;
                }
                else
                {
                    NOV += decimal.Parse(data.Rows[0]["MISCELLENOUSAMOUNT"].ToString());
                }
                if (data.Rows[0]["DISCOUNT"].ToString() == "")
                {
                    NOV += 0;
                }
                else
                {
                    NOV += decimal.Parse(data.Rows[0]["DISCOUNT"].ToString());
                }
                if (data.Rows[0]["POSTCHARGES"].ToString() == "")
                {
                    NOV += 0;
                }
                else
                {
                    NOV += decimal.Parse(data.Rows[0]["POSTCHARGES"].ToString());
                }
            }
            return data;
        }
        public decimal DEC = 0;


        public DataTable dec()
        {
            var list = new List<SqlParameter>();
            string srikar = "SELECT DISTINCT(SELECT SUM(CHARGED_TARRIF) FROM CHECKIN WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 12) AS AMOUNT,(SELECT SUM(AMOUNT) FROM PAIDOUT WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 12) AS PAIDOUTS,(SELECT SUM(TOTAL_AMOUNT) FROM MISCELLENOUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 12) AS MISCELLENOUSAMOUNT,(SELECT SUM(AMOUNT) FROM DISCOUNT WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 12) AS DISCOUNT,(SELECT SUM(CHARGES) FROM POSTCHARGES WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 12) AS POSTCHARGES FROM CHECKIN ";
            DataTable data = DbFunctions.ExecuteCommand<DataTable>(srikar, list);
            if (data.Rows.Count == 0)
            {
                DEC = 0;
            }
            else
            {
                if (data.Rows[0]["AMOUNT"].ToString() == "")
                {
                    DEC += 0;
                }
                else
                {
                    DEC += decimal.Parse(data.Rows[0]["AMOUNT"].ToString());
                }
                if (data.Rows[0]["PAIDOUTS"].ToString() == "")
                {
                    DEC += 0;
                }
                else
                {
                    DEC += decimal.Parse(data.Rows[0]["PAIDOUTS"].ToString());
                }
                if (data.Rows[0]["MISCELLENOUSAMOUNT"].ToString() == "")
                {
                    DEC += 0;
                }
                else
                {
                    DEC += decimal.Parse(data.Rows[0]["MISCELLENOUSAMOUNT"].ToString());
                }
                if (data.Rows[0]["DISCOUNT"].ToString() == "")
                {
                    DEC += 0;
                }
                else
                {
                    DEC += decimal.Parse(data.Rows[0]["DISCOUNT"].ToString());
                }
                if (data.Rows[0]["POSTCHARGES"].ToString() == "")
                {
                    DEC += 0;
                }
                else
                {
                    DEC += decimal.Parse(data.Rows[0]["POSTCHARGES"].ToString());
                }
            }
            return data;
        }
        public decimal SRIKAR245 = 0;
        public DataTable SRI()
        {
            var list = new List<SqlParameter>();
            string srikar = "SELECT DISTINCT(SELECT SUM(CHARGED_TARRIF) FROM CHECKIN WHERE  INSERT_DATE = Convert(DATE, GetDate())) AS AMOUNT,(SELECT SUM(AMOUNT) FROM PAIDOUT WHERE INSERT_DATE = Convert(DATE, GetDate())) AS PAIDOUTS,(SELECT SUM(TOTAL_AMOUNT) FROM MISCELLENOUS WHERE INSERT_DATE = Convert(DATE, GetDate())) AS MISCELLENOUSAMOUNT,(SELECT SUM(AMOUNT) FROM DISCOUNT WHERE INSERT_DATE = Convert(DATE, GetDate())) AS DISCOUNT,(SELECT SUM(CHARGES) FROM POSTCHARGES WHERE INSERT_DATE = Convert(DATE, GetDate())) AS POSTCHARGES FROM CHECKIN  ";
            DataTable data = DbFunctions.ExecuteCommand<DataTable>(srikar, list);
            if (data.Rows.Count == 0)
            {
                SRIKAR245 = 0;
            }
            else
            {
                if (data.Rows[0]["AMOUNT"].ToString() == "")
                {
                    SRIKAR245 += 0;
                }
                else
                {
                    SRIKAR245 += decimal.Parse(data.Rows[0]["AMOUNT"].ToString());
                }
                if (data.Rows[0]["PAIDOUTS"].ToString() == "")
                {
                    SRIKAR245 += 0;
                }
                else
                {
                    SRIKAR245 += decimal.Parse(data.Rows[0]["PAIDOUTS"].ToString());
                }
                if (data.Rows[0]["MISCELLENOUSAMOUNT"].ToString() == "")
                {
                    SRIKAR245 += 0;
                }
                else
                {
                    SRIKAR245 += decimal.Parse(data.Rows[0]["MISCELLENOUSAMOUNT"].ToString());
                }
                if (data.Rows[0]["DISCOUNT"].ToString() == "")
                {
                    SRIKAR245 += 0;
                }
                else
                {
                    SRIKAR245 += decimal.Parse(data.Rows[0]["DISCOUNT"].ToString());
                }
                if (data.Rows[0]["POSTCHARGES"].ToString() == "")
                {
                    SRIKAR245 += 0;
                }
                else
                {
                    SRIKAR245 += decimal.Parse(data.Rows[0]["POSTCHARGES"].ToString());
                }
            }
            return data;
        }
        public decimal jan1 = 0, feb1 = 0, apr1 = 0, may1 = 0, june1 = 0, july1 = 0, aug1 = 0, sep1 = 0, oct1 = 0, nov1 = 0, dec1 = 0;
        public string a, b, c;
        public DataTable JANUARY()
        {
            var LIST = new List<SqlParameter>();
            string S = "SELECT CGST = SUM(CAST(CGST AS decimal(17, 2))), SGST = SUM(CAST(SGST AS decimal(17, 2))),(SELECT CGST = SUM(CAST(CGST AS decimal(17, 2))) * 2 FROM PRINTSTATUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 1) AS TAX   FROM PRINTSTATUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 1";
            DataTable SRI = DbFunctions.ExecuteCommand<DataTable>(S, LIST);
            foreach (DataRow R in SRI.Rows)
            {

                if (R["CGST"] == DBNull.Value && R["SGST"] == DBNull.Value && R["TAX"] == DBNull.Value)
                {
                    R["CGST"] = 0.00;
                    R["SGST"] = 0.00;
                    R["TAX"] = 0.00;
                    jan1 =decimal.Parse("0.00");
                }
                else
                {
                    jan1 = decimal.Parse(SRI.Rows[0]["CGST"].ToString());
                    jan1 = decimal.Parse(SRI.Rows[0]["SGST"].ToString());
                    jan1 = decimal.Parse(SRI.Rows[0]["TAX"].ToString());
                }


            }
            return SRI;
        }

        public DataTable FEBRUARY()
        {
            //Boolean has = false;
            var LIST = new List<SqlParameter>();
            string S = "SELECT CGST = SUM(CAST(CGST AS decimal(17, 2))), SGST = SUM(CAST(SGST AS decimal(17, 2))),(SELECT CGST = SUM(CAST(CGST AS decimal(17, 2))) * 2 FROM PRINTSTATUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 2) AS TAX   FROM PRINTSTATUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 2";
            DataTable SRI = DbFunctions.ExecuteCommand<DataTable>(S, LIST);
            
                foreach(DataRow R in SRI.Rows)
               { 
                
                    if(R["CGST"] == DBNull.Value && R["SGST"] == DBNull.Value && R["TAX"] == DBNull.Value)
                    {
                    R["CGST"] = 0.00;
                    R["SGST"] = 0.00;
                    R["TAX"] = 0.00;
                    feb1 = 0;
                    }
                    else
                    {
                        feb1 = decimal.Parse(SRI.Rows[0]["CGST"].ToString());
                        feb1 = decimal.Parse(SRI.Rows[0]["SGST"].ToString());
                        feb1 = decimal.Parse(SRI.Rows[0]["TAX"].ToString());
                    }
                
                
            }
            return SRI;
        }
        public decimal mar1 = 0;
        public DataTable march()
        {
            var LIST = new List<SqlParameter>();
            string S = "SELECT CGST = SUM(CAST(CGST AS decimal(17, 2))), SGST = SUM(CAST(SGST AS decimal(17, 2))),(SELECT CGST = SUM(CAST(CGST AS decimal(17, 2))) * 2 FROM PRINTSTATUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 3) AS TAX   FROM PRINTSTATUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 3";
            DataTable SRI = DbFunctions.ExecuteCommand<DataTable>(S, LIST);
            foreach (DataRow R in SRI.Rows)
            {

                if (R["CGST"] == DBNull.Value && R["SGST"] == DBNull.Value && R["TAX"] == DBNull.Value)
                {
                    R["CGST"] = 0.00;
                    R["SGST"] = 0.00;
                    R["TAX"] = 0.00;
                    mar1 = 0;
                }
                else { 
                mar1 = decimal.Parse(SRI.Rows[0]["CGST"].ToString());
                mar1 = decimal.Parse(SRI.Rows[0]["SGST"].ToString());
                mar1 = decimal.Parse(SRI.Rows[0]["TAX"].ToString());
            }
            
           
                
            }
            return SRI;
        }
        public DataTable APRIL()
        {
            var LIST = new List<SqlParameter>();
            string S = "SELECT CGST = SUM(CAST(CGST AS decimal(17, 2))), SGST = SUM(CAST(SGST AS decimal(17, 2))),(SELECT CGST = SUM(CAST(CGST AS decimal(17, 2))) * 2 FROM PRINTSTATUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 4) AS TAX   FROM PRINTSTATUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 4";
            DataTable SRI = DbFunctions.ExecuteCommand<DataTable>(S, LIST);
            foreach (DataRow R in SRI.Rows)
            {

                if (R["CGST"] == DBNull.Value && R["SGST"] == DBNull.Value && R["TAX"] == DBNull.Value)
                {
                    R["CGST"] = 0.00;
                    R["SGST"] = 0.00;
                    R["TAX"] = 0.00;
                    apr1 = 0;
                }
                else
                {
                    apr1 = decimal.Parse(SRI.Rows[0]["CGST"].ToString());
                    apr1 = decimal.Parse(SRI.Rows[0]["SGST"].ToString());
                    apr1 = decimal.Parse(SRI.Rows[0]["TAX"].ToString());
                }



            }
            return SRI;
        }
        public DataTable MAYY()
        {
            var LIST = new List<SqlParameter>();
            string S = "SELECT CGST = SUM(CAST(CGST AS decimal(17, 2))), SGST = SUM(CAST(SGST AS decimal(17, 2))),(SELECT CGST = SUM(CAST(CGST AS decimal(17, 2))) * 2 FROM PRINTSTATUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 5) AS TAX   FROM PRINTSTATUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 5";
            DataTable SRI = DbFunctions.ExecuteCommand<DataTable>(S, LIST);
            foreach (DataRow R in SRI.Rows)
            {

                if (R["CGST"] == DBNull.Value && R["SGST"] == DBNull.Value && R["TAX"] == DBNull.Value)
                {
                    R["CGST"] = 0.00;
                    R["SGST"] = 0.00;
                    R["TAX"] = 0.00;
                    may1 = 0;
                }
                else
                {
                    may1 = decimal.Parse(SRI.Rows[0]["CGST"].ToString());
                    may1 = decimal.Parse(SRI.Rows[0]["SGST"].ToString());
                    may1 = decimal.Parse(SRI.Rows[0]["TAX"].ToString());
                }



            }
            return SRI;
        }
        public DataTable JUN()
        {
            var LIST = new List<SqlParameter>();
            string S = "SELECT CGST = SUM(CAST(CGST AS decimal(17, 2))), SGST = SUM(CAST(SGST AS decimal(17, 2))),(SELECT CGST = SUM(CAST(CGST AS decimal(17, 2))) * 2 FROM PRINTSTATUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 6) AS TAX   FROM PRINTSTATUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 6";
            DataTable SRI = DbFunctions.ExecuteCommand<DataTable>(S, LIST);
            foreach (DataRow R in SRI.Rows)
            {

                if (R["CGST"] == DBNull.Value && R["SGST"] == DBNull.Value && R["TAX"] == DBNull.Value)
                {
                    R["CGST"] = 0.00;
                    R["SGST"] = 0.00;
                    R["TAX"] = 0.00;
                    june1 = 0;
                }
                else
                {
                    june1 = decimal.Parse(SRI.Rows[0]["CGST"].ToString());
                    june1 = decimal.Parse(SRI.Rows[0]["SGST"].ToString());
                    june1 = decimal.Parse(SRI.Rows[0]["TAX"].ToString());
                }

            }
            return SRI;
        }
        public DataTable JUL()
        {
            var LIST = new List<SqlParameter>();
            string S = "SELECT CGST = SUM(CAST(CGST AS decimal(17, 2))), SGST = SUM(CAST(SGST AS decimal(17, 2))),(SELECT CGST = SUM(CAST(CGST AS decimal(17, 2))) * 2 FROM PRINTSTATUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 7) AS TAX   FROM PRINTSTATUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 7";
            DataTable SRI = DbFunctions.ExecuteCommand<DataTable>(S, LIST);
            foreach (DataRow R in SRI.Rows)
            {

                if (R["CGST"] == DBNull.Value && R["SGST"] == DBNull.Value && R["TAX"] == DBNull.Value)
                {
                    R["CGST"] = 0.00;
                    R["SGST"] = 0.00;
                    R["TAX"] = 0.00;
                    july1 = 0;
                }
                else
                {
                    july1 = decimal.Parse(SRI.Rows[0]["CGST"].ToString());
                    july1 = decimal.Parse(SRI.Rows[0]["SGST"].ToString());
                    july1 = decimal.Parse(SRI.Rows[0]["TAX"].ToString());
                }



            }
            return SRI;
        }
        public DataTable AUGEST()
        {
            var LIST = new List<SqlParameter>();
            string S = "SELECT CGST = SUM(CAST(CGST AS decimal(17, 2))), SGST = SUM(CAST(SGST AS decimal(17, 2))),(SELECT CGST = SUM(CAST(CGST AS decimal(17, 2))) * 2 FROM PRINTSTATUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 8) AS TAX   FROM PRINTSTATUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 8";
            DataTable SRI = DbFunctions.ExecuteCommand<DataTable>(S, LIST);
            foreach (DataRow R in SRI.Rows)
            {

                if (R["CGST"] == DBNull.Value && R["SGST"] == DBNull.Value && R["TAX"] == DBNull.Value)
                {
                    R["CGST"] = 0.00;
                    R["SGST"] = 0.00;
                    R["TAX"] = 0.00;
                    aug1 = 0;
                }
                else
                {
                    aug1 = decimal.Parse(SRI.Rows[0]["CGST"].ToString());
                    aug1 = decimal.Parse(SRI.Rows[0]["SGST"].ToString());
                    aug1 = decimal.Parse(SRI.Rows[0]["TAX"].ToString());
                }
            }
            return SRI;
        }
        public DataTable SEPTE()
        {
            var LIST = new List<SqlParameter>();
            string S = "SELECT CGST = SUM(CAST(CGST AS decimal(17, 2))), SGST = SUM(CAST(SGST AS decimal(17, 2))),(SELECT CGST = SUM(CAST(CGST AS decimal(17, 2))) * 2 FROM PRINTSTATUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 9) AS TAX   FROM PRINTSTATUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 9";
            DataTable SRI = DbFunctions.ExecuteCommand<DataTable>(S, LIST);
            foreach (DataRow R in SRI.Rows)
            {

                if (R["CGST"] == DBNull.Value && R["SGST"] == DBNull.Value && R["TAX"] == DBNull.Value)
                {
                    R["CGST"] = 0.00;
                    R["SGST"] = 0.00;
                    R["TAX"] = 0.00;
                    sep1 = 0;
                }
                else
                {
                    sep1 = decimal.Parse(SRI.Rows[0]["CGST"].ToString());
                    sep1 = decimal.Parse(SRI.Rows[0]["SGST"].ToString());
                    sep1 = decimal.Parse(SRI.Rows[0]["TAX"].ToString());
                }
            }
            return SRI;
        }
        public DataTable OCTOB()
        {
            var LIST = new List<SqlParameter>();
            string S = "SELECT CGST = SUM(CAST(CGST AS decimal(17, 2))), SGST = SUM(CAST(SGST AS decimal(17, 2))),(SELECT CGST = SUM(CAST(CGST AS decimal(17, 2))) * 2 FROM PRINTSTATUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 10) AS TAX   FROM PRINTSTATUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 10";
            DataTable SRI = DbFunctions.ExecuteCommand<DataTable>(S, LIST);
            foreach (DataRow R in SRI.Rows)
            {

                if (R["CGST"] == DBNull.Value && R["SGST"] == DBNull.Value && R["TAX"] == DBNull.Value)
                {
                    R["CGST"] = 0.00;
                    R["SGST"] = 0.00;
                    R["TAX"] = 0.00;
                    oct1 = 0;
                }
                else
                {
                    oct1 = decimal.Parse(SRI.Rows[0]["CGST"].ToString());
                    oct1 = decimal.Parse(SRI.Rows[0]["SGST"].ToString());
                    oct1 = decimal.Parse(SRI.Rows[0]["TAX"].ToString());
                }
            }
            return SRI;
        }
        public DataTable NOVEM()
        {
            var LIST = new List<SqlParameter>();
            string S = "SELECT CGST = SUM(CAST(CGST AS decimal(17, 2))), SGST = SUM(CAST(SGST AS decimal(17, 2))),(SELECT CGST = SUM(CAST(CGST AS decimal(17, 2))) * 2 FROM PRINTSTATUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 11) AS TAX   FROM PRINTSTATUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 11";
            DataTable SRI = DbFunctions.ExecuteCommand<DataTable>(S, LIST);
            foreach (DataRow R in SRI.Rows)
            {

                if (R["CGST"] == DBNull.Value && R["SGST"] == DBNull.Value && R["TAX"] == DBNull.Value)
                {
                    R["CGST"] = 0.00;
                    R["SGST"] = 0.00;
                    R["TAX"] = 0.00;
                    nov1 = 0;
                }
                else
                {
                    nov1 = decimal.Parse(SRI.Rows[0]["CGST"].ToString());
                    nov1 = decimal.Parse(SRI.Rows[0]["SGST"].ToString());
                    nov1 = decimal.Parse(SRI.Rows[0]["TAX"].ToString());
                }
            }
            return SRI;
        }
        public DataTable DECM()
        {
            var LIST = new List<SqlParameter>();
            string S = "SELECT CGST = SUM(CAST(CGST AS decimal(17, 2))), SGST = SUM(CAST(SGST AS decimal(17, 2))),(SELECT CGST = SUM(CAST(CGST AS decimal(17, 2))) * 2 FROM PRINTSTATUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 12) AS TAX   FROM PRINTSTATUS WHERE YEAR(INSERT_DATE) = YEAR(GETDATE()) AND MONTH(INSERT_DATE) = 12";
            DataTable SRI = DbFunctions.ExecuteCommand<DataTable>(S, LIST);
            foreach (DataRow R in SRI.Rows)
            {

                if (R["CGST"] == DBNull.Value && R["SGST"] == DBNull.Value && R["TAX"] == DBNull.Value)
                {
                    R["CGST"] = 0.00;
                    R["SGST"] = 0.00;
                    R["TAX"] = 0.00;
                    dec1 = 0;
                }
                else
                {
                    dec1 = decimal.Parse(SRI.Rows[0]["CGST"].ToString());
                    dec1 = decimal.Parse(SRI.Rows[0]["SGST"].ToString());
                    dec1 = decimal.Parse(SRI.Rows[0]["TAX"].ToString());
                }
            }
            return SRI;
        }


        public decimal pending;
        public DataTable pendingonboard()
        {
            var list = new List<SqlParameter>();
            string s = "select SUM(ROOM_TARRIF) AS AMOUNT,(SELECT SUM(CHARGES) FROM POSTCHARGES WHERE POSTCHARGES=0 AND INSERT_DATE = Convert(DATE, GetDate())) AS AMOUNT1 from night_audit where NIGHT=0";
            DataTable data = DbFunctions.ExecuteCommand<DataTable>(s, list);
            if (data.Rows.Count == 0)
            {
                pending = 0;
            }
            else
            {
                if (data.Rows[0]["AMOUNT"].ToString() == "")
                {
                    pending += 0;
                }
                else
                {
                    pending += decimal.Parse(data.Rows[0]["AMOUNT"].ToString());
                }
                if (data.Rows[0]["AMOUNT1"].ToString() == "")
                {
                    pending += 0;
                }
                else
                {
                    pending += decimal.Parse(data.Rows[0]["AMOUNT1"].ToString());
                }
            }
                return data;
         
        }

        public decimal charge;
        public DataTable charges()
        {
            var list = new List<SqlParameter>();
            string ss = "SELECT SUM(CHARGES) as charges FROM POSTCHARGES WHERE POSTCHARGES = 0 AND INSERT_DATE = Convert(DATE, GetDate())";
            DataTable s = DbFunctions.ExecuteCommand<DataTable>(ss, list);
            if (s.Rows.Count == 0)
            {
                charge = 0;
            }
            else
            {
                if (s.Rows[0]["charges"].ToString() == "")
                {
                    charge = 0;
                }
                else
                {
                    charge = decimal.Parse(s.Rows[0]["charges"].ToString());
                }
            }
                return s;
           
        }

    }
}
