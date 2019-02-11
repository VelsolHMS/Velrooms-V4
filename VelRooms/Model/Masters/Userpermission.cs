using DAL;
using HMS.View.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model.Masters
{
    class Userpermission
    {
        public string HOTELINFO { get; set; }
        public string COMPANY { get; set; }
        public string CATEGORY { get; set; }
        public string PLANDEFINATION { get; set; }
        public string ROOMTARIFF  { get; set; }
        public string TAX { get; set; }
        public string AMENITIES { get; set; }
        public string REVENUE { get; set; }
        public string DEPARTMENT { get; set; }
        public string RESET_PASSWORD { get; set; }
        public string REG_USER { get; set; }
        public string USERPERMISSIONS { get; set; }
        public string ENQUIRY { get; set; }
        public string RESERVATION { get; set; }
        public string CHECKIN { get; set; }
        public string CHECKOUT { get; set; }
        public string CO_COMPANY { get; set; }
        public string CO_BILLONHOLD { get; set; }
        public string CO_TRANSFER { get; set; }
        public string ADVANCE { get; set; }
        public string PENDINGBILL { get; set; }
        public string PB_COMPANY { get; set; }
        public string PB_BILLONHOLD { get; set; }
        public string GROUP_CHECKIN { get; set; }
        public string POSTCHARGES { get; set; }
        public string PAIDOUTS { get; set; }
        public string ROOMCHANGE { get; set; }
        public string REFUND { get; set; }
        public string BLOCK_ROOM { get; set; }
        public string DISCOUNT { get; set; }
        public string GUESTINFO { get; set; }
        public string CHANGEROOMSTATUS { get; set; }
        public string MISSALES { get; set; }
        public string BILLSETTLE { get; set; }
        public string REPRINT { get; set; }
        public string DASHBOARD { get; set; }
        public string TARIFF_POSTEDFORTHEDAY { get; set; }
        public string ROOMOCCUPANCY { get; set; }
        public string DISCOUNT_DAY { get; set; }
        public string DISCOUNT_MONTH { get; set; }
        public string EXPECTED_ARRIVALS { get; set; }
        public string EXPECTED_DEPARTURES { get; set; } 
        public string CANCELLED_RESERATION { get; set; } 
        public string TODAY_ARRIVALS { get; set; }
        public string CHECKOUT_FORTHEDAY { get; set; }
        public string GUEST_ADVANCE { get; set; }
        public string GUEST_INHOUSE { get; set; }
        public string ROOM_RATELIST { get; set; }
        public string RESERVATION_LIST { get; set; }
        public string TRANSACTION_LIST { get; set; }
        public string TAX_REPORT { get; set; }
        public string FO_TRANSACTIONLIST { get; set; }
        public string CHANGE_GUESTINFO { get; set; }
        public string ROOM_CHANGE { get; set; }
        public string OUTSTANDING_BALANCE { get; set; }
        public string MONTHWISE_ROOMTARIFF { get; set; }
        public string PENDINGBILLREPORT { get; set; }    
        public string USERNAME { get; set; }
        public string DESIGINATION { get; set; }
        public string INSERT_BY { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public void master()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@USERNAME",USERNAME);
            list.AddSqlParameter("@DESIGINATION",DESIGINATION);
            list.AddSqlParameter("@HOTELINFO",HOTELINFO);
            list.AddSqlParameter("@COMPANY",COMPANY);
            list.AddSqlParameter("@CATEGORY",CATEGORY);
            list.AddSqlParameter("@PLANDEFINATION",PLANDEFINATION);
            list.AddSqlParameter("@ROOMTARRIF",ROOMTARIFF);
            list.AddSqlParameter("@TAX",TAX);
            list.AddSqlParameter("@AMENITIES",AMENITIES);
            list.AddSqlParameter("@REVENUE",REVENUE);
            list.AddSqlParameter("@DEPARTMENT",DEPARTMENT);
            list.AddSqlParameter("@RESET_PASSWORD",RESET_PASSWORD);
            list.AddSqlParameter("@REG_USER",REG_USER);
            list.AddSqlParameter("@USERPEMISSIONS",USERPERMISSIONS);
            INSERT_BY = login.u;
            list.AddSqlParameter("@INSERT_BY",INSERT_BY);
            INSERT_DATE = DateTime.Today.Date;
            list.AddSqlParameter("@INSERT_DATE",INSERT_DATE);
            string S = "INSERT INTO MASTERPERMISSIONS(USERNAME,DESIGINATION,HOTELINFO,COMPANY,CATEGORY,PLANDEFINATION,ROOMTARRIF,TAX,AMENITIES,REVENUE,DEPARTMENT,RESET_PASSWORD,REG_USER,USERPEMISSIONS,INSERT_BY,INSERT_DATE)" +
                "VALUES(@USERNAME,@DESIGINATION,@HOTELINFO,@COMPANY,@CATEGORY,@PLANDEFINATION,@ROOMTARRIF,@TAX,@AMENITIES,@REVENUE,@DEPARTMENT,@RESET_PASSWORD,@REG_USER,@USERPEMISSIONS,@INSERT_BY,@INSERT_DATE)";
            DbFunctions.ExecuteCommand<int>(S, list);
        }

        public void masterupdate()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@USERNAME", USERNAME);
            list.AddSqlParameter("@DESIGINATION", DESIGINATION);
            list.AddSqlParameter("@HOTELINFO", HOTELINFO);
            list.AddSqlParameter("@COMPANY", COMPANY);
            list.AddSqlParameter("@CATEGORY", CATEGORY);
            list.AddSqlParameter("@PLANDEFINATION", PLANDEFINATION);
            list.AddSqlParameter("@ROOMTARRIF", ROOMTARIFF);
            list.AddSqlParameter("@TAX",TAX);
            list.AddSqlParameter("@AMENITIES", AMENITIES);
            list.AddSqlParameter("@REVENUE", REVENUE);
            list.AddSqlParameter("@DEPARTMENT", DEPARTMENT);
            list.AddSqlParameter("@RESET_PASSWORD", RESET_PASSWORD);
            list.AddSqlParameter("@REG_USER", REG_USER);
            list.AddSqlParameter("@USERPEMISSIONS", USERPERMISSIONS);
            UPDATE_BY = login.u;
            list.AddSqlParameter("@UPDATE_BY", UPDATE_BY);
            UPDATE_DATE = DateTime.Today.Date;
            list.AddSqlParameter("@UPDATE_DATE", UPDATE_DATE);
            string s = "UPDATE MASTERPERMISSIONS SET DESIGINATION=@DESIGINATION,HOTELINFO=@HOTELINFO,COMPANY=@COMPANY,CATEGORY=@CATEGORY,PLANDEFINATION=@PLANDEFINATION,ROOMTARRIF=@ROOMTARRIF,TAX=@TAX,AMENITIES=@AMENITIES,REVENUE=@REVENUE,DEPARTMENT=@DEPARTMENT,RESET_PASSWORD=@RESET_PASSWORD,REG_USER=@REG_USER,USERPEMISSIONS=@USERPEMISSIONS WHERE USERNAME='" + USERNAME + "'";
            DbFunctions.ExecuteCommand<int>(s,list);
        }
        public void operation()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@USERNAME", USERNAME);
            list.AddSqlParameter("@DESIGINATION", DESIGINATION);
            list.AddSqlParameter("@ENQUIRY",ENQUIRY);
            list.AddSqlParameter("@RESERVATION", RESERVATION);
            list.AddSqlParameter("@CHECKIN", CHECKIN);
            list.AddSqlParameter("@CHECKOUT", CHECKOUT);
            list.AddSqlParameter("@CO_COMPANY", CO_COMPANY);
            list.AddSqlParameter("@CO_BILLONHOLD", CO_BILLONHOLD);
            list.AddSqlParameter("@CO_TRANSFER", CO_TRANSFER);
            list.AddSqlParameter("@ADVANCE", ADVANCE);
            list.AddSqlParameter("@PENDINGBILL", PENDINGBILL);
            list.AddSqlParameter("@PB_COMPANY", PB_COMPANY);
            list.AddSqlParameter("@PB_BILLONHOLD", PB_BILLONHOLD);
            list.AddSqlParameter("@GROUP_CHECKIN", GROUP_CHECKIN);
            list.AddSqlParameter("@POSTCHARGES", POSTCHARGES);
            list.AddSqlParameter("@PAIDOUTS", PAIDOUTS);
            list.AddSqlParameter("@ROOMCHANGE", ROOMCHANGE);
            list.AddSqlParameter("@REFUND", REFUND);
            list.AddSqlParameter("@BLOCK_ROOM", BLOCK_ROOM);
            list.AddSqlParameter("@DISCOUNT", DISCOUNT);
            list.AddSqlParameter("@GUESTINFO", GUESTINFO);
            list.AddSqlParameter("@CHANGEROOMSTATUS", CHANGEROOMSTATUS);
            list.AddSqlParameter("@MISSALES", MISSALES);
            list.AddSqlParameter("@BILLSETTLE", BILLSETTLE);
            list.AddSqlParameter("@REPRINT", REPRINT);
            list.AddSqlParameter("@DASHBOARD", DASHBOARD);
            INSERT_BY = login.u;
            list.AddSqlParameter("@INSERT_BY", INSERT_BY);
            INSERT_DATE = DateTime.Today.Date; 
            list.AddSqlParameter("@INSERT_DATE", INSERT_DATE);
            string s = "INSERT INTO OPERATIONPERMISSIONS(USERNAME,DESIGINATION,ENQUIRY,RESERVATION,CHECKIN,CHECKOUT,CO_COMPANY,CO_BILLONHOLD,CO_TRANSFER,ADVANCE,PENDINGBILL,PB_COMPANY,PB_BILLONHOLD,GROUP_CHECKIN,POSTCHARGES,PAIDOUTS,ROOMCHANGE,REFUND,BLOCK_ROOM,DISCOUNT,GUESTINFO,CHANGEROOMSTATUS,MISSALES,BILLSETTLE,REPRINT,DASHBOARD,INSERT_BY,INSERT_DATE)"+
                " VALUES(@USERNAME,@DESIGINATION,@ENQUIRY,@RESERVATION,@CHECKIN,@CHECKOUT,@CO_COMPANY,@CO_BILLONHOLD,@CO_TRANSFER,@ADVANCE,@PENDINGBILL,@PB_COMPANY,@PB_BILLONHOLD,@GROUP_CHECKIN,@POSTCHARGES,@PAIDOUTS,@ROOMCHANGE,@REFUND,@BLOCK_ROOM,@DISCOUNT,@GUESTINFO,@CHANGEROOMSTATUS,@MISSALES,@BILLSETTLE,@REPRINT,@DASHBOARD,@INSERT_BY,@INSERT_DATE)";
            DbFunctions.ExecuteCommand<int>(s, list);
        }
        public void operationupdate()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@USERNAME", USERNAME);
            list.AddSqlParameter("@DESIGINATION", DESIGINATION);
            list.AddSqlParameter("@ENQUIRY", ENQUIRY);
            list.AddSqlParameter("@RESERVATION", RESERVATION);
            list.AddSqlParameter("@CHECKIN", CHECKIN);
            list.AddSqlParameter("@CHECKOUT", CHECKOUT);
            list.AddSqlParameter("@CO_COMPANY", CO_COMPANY);
            list.AddSqlParameter("@CO_BILLONHOLD", CO_BILLONHOLD);
            list.AddSqlParameter("@CO_TRANSFER", CO_TRANSFER);
            list.AddSqlParameter("@ADVANCE", ADVANCE);
            list.AddSqlParameter("@PENDINGBILL", PENDINGBILL);
            list.AddSqlParameter("@PB_COMPANY", PB_COMPANY);
            list.AddSqlParameter("@PB_BILLONHOLD", PB_BILLONHOLD);
            list.AddSqlParameter("@GROUP_CHECKIN", GROUP_CHECKIN);
            list.AddSqlParameter("@POSTCHARGES", POSTCHARGES);
            list.AddSqlParameter("@PAIDOUTS", PAIDOUTS);
            list.AddSqlParameter("@ROOMCHANGE", ROOMCHANGE);
            list.AddSqlParameter("@REFUND", REFUND);
            list.AddSqlParameter("@BLOCK_ROOM", BLOCK_ROOM);
            list.AddSqlParameter("@DISCOUNT", DISCOUNT);
            list.AddSqlParameter("@GUESTINFO", GUESTINFO);
            list.AddSqlParameter("@CHANGEROOMSTATUS", CHANGEROOMSTATUS);
            list.AddSqlParameter("@MISSALES", MISSALES);
            list.AddSqlParameter("@BILLSETTLE", BILLSETTLE);
            list.AddSqlParameter("@REPRINT", REPRINT);
            list.AddSqlParameter("@DASHBOARD", DASHBOARD);
            UPDATE_BY = login.u;
            list.AddSqlParameter("@UPDATE_BY", UPDATE_BY);
            UPDATE_DATE = DateTime.Today.Date;
            list.AddSqlParameter("@UPDATE_DATE", UPDATE_DATE);
            string S = "UPDATE OPERATIONPERMISSIONS SET DESIGINATION=@DESIGINATION,ENQUIRY=@ENQUIRY,RESERVATION=@RESERVATION,CHECKIN=@CHECKIN,CHECKOUT=@CHECKOUT,CO_COMPANY=@CO_COMPANY,CO_BILLONHOLD=@CO_BILLONHOLD,CO_TRANSFER=@CO_TRANSFER,ADVANCE=@ADVANCE,PENDINGBILL=@PENDINGBILL,PB_COMPANY=@PB_COMPANY,PB_BILLONHOLD=@PB_BILLONHOLD,GROUP_CHECKIN=@GROUP_CHECKIN,POSTCHARGES=@POSTCHARGES,PAIDOUTS=@PAIDOUTS,ROOMCHANGE=@ROOMCHANGE,REFUND=@REFUND,BLOCK_ROOM=@BLOCK_ROOM,DISCOUNT=@DISCOUNT,GUESTINFO=@GUESTINFO,CHANGEROOMSTATUS=@CHANGEROOMSTATUS,MISSALES=@MISSALES,BILLSETTLE=@BILLSETTLE,REPRINT=@REPRINT,DASHBOARD=@DASHBOARD WHERE USERNAME='" + USERNAME+"' ";
            DbFunctions.ExecuteCommand<int>(S, list);
        }
        public void Report()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@USERNAME", USERNAME);
            list.AddSqlParameter("@DESIGINATION", DESIGINATION);
            list.AddSqlParameter("@TARIFF_POSTED_DAY",TARIFF_POSTEDFORTHEDAY);
            list.AddSqlParameter("@ROOMOCCUPANCY", ROOMOCCUPANCY);
            list.AddSqlParameter("@DISCOUNT_DAY", DISCOUNT_DAY);
            list.AddSqlParameter("@DISCOUNT_MONTH", DISCOUNT_MONTH);
            list.AddSqlParameter("@EXPECTED_ARRIVALS", EXPECTED_ARRIVALS);
            list.AddSqlParameter("@EXPECTED_DEPARTURES", EXPECTED_DEPARTURES);
            list.AddSqlParameter("@CANCELLED_RESERVATION",CANCELLED_RESERATION);
            list.AddSqlParameter("@TODAY_ARRIVALS", TODAY_ARRIVALS);
            list.AddSqlParameter("@CHECKOUTFORTHE_DAY", CHECKOUT_FORTHEDAY);
            list.AddSqlParameter("@GUEST_ADVANCE", GUEST_ADVANCE);
            list.AddSqlParameter("@GUEST_INHOUSE", GUEST_INHOUSE);
            list.AddSqlParameter("@ROOM_RATELIST", ROOM_RATELIST);
            list.AddSqlParameter("@RESERVATION_LIST", RESERVATION_LIST);
            list.AddSqlParameter("@TRANSACTION_LIST", TRANSACTION_LIST);
            list.AddSqlParameter("@TAX_REPORT", TAX_REPORT);
            list.AddSqlParameter("@FO_TRANSACTIONLIST", FO_TRANSACTIONLIST);
            list.AddSqlParameter("@CHANGE_GUESTINFO", CHANGE_GUESTINFO);
            list.AddSqlParameter("@ROOM_CHANGE", ROOM_CHANGE);
            list.AddSqlParameter("@OUTSTANDING_BALANCE", OUTSTANDING_BALANCE);
            list.AddSqlParameter("@MONTHWISE_ROOMTARIFF", MONTHWISE_ROOMTARIFF);
            list.AddSqlParameter("@PENDINGBILL", PENDINGBILL);
            INSERT_BY = login.u;
            list.AddSqlParameter("@INSERT_BY", INSERT_BY);
            INSERT_DATE = DateTime.Today.Date;
            list.AddSqlParameter("@INSERT_DATE",INSERT_DATE);
            string s = "INSERT INTO REPORTPERMISSIONS(USERNAME,DESIGINATION,TARIFF_POSTED_DAY,ROOMOCCUPANCY,DISCOUNT_DAY,DISCOUNT_MONTH,EXPECTED_ARRIVALS,EXPECTED_DEPARTURES,CANCELLED_RESERVATION,TODAY_ARRIVALS,CHECKOUTFORTHE_DAY,GUEST_ADVANCE,GUEST_INHOUSE,ROOM_RATELIST,RESERVATION_LIST,TRANSACTION_LIST,TAX_REPORT,FO_TRANSACTIONLIST,CHANGE_GUESTINFO,ROOM_CHANGE,OUTSTANDING_BALANCE,MONTHWISE_ROOMTARIFF,PENDINGBILL,INSERT_BY,INSERT_DATE)" +
                " VALUES(@USERNAME,@DESIGINATION,@TARIFF_POSTED_DAY,@ROOMOCCUPANCY,@DISCOUNT_DAY,@DISCOUNT_MONTH,@EXPECTED_ARRIVALS,@EXPECTED_DEPARTURES,@CANCELLED_RESERVATION,@TODAY_ARRIVALS,@CHECKOUTFORTHE_DAY,@GUEST_ADVANCE,@GUEST_INHOUSE,@ROOM_RATELIST,@RESERVATION_LIST,@TRANSACTION_LIST,@TAX_REPORT,@FO_TRANSACTIONLIST,@CHANGE_GUESTINFO,@ROOM_CHANGE,@OUTSTANDING_BALANCE,@MONTHWISE_ROOMTARIFF,@PENDINGBILL,@INSERT_BY,@INSERT_DATE)";
            DbFunctions.ExecuteCommand<int>(s, list);
        }
        public void Reportupdate()
        {
            var list = new List<SqlParameter>();
            list.AddSqlParameter("@USERNAME", USERNAME);
            list.AddSqlParameter("@DESIGINATION", DESIGINATION);
            list.AddSqlParameter("@TARIFF_POSTED_DAY", TARIFF_POSTEDFORTHEDAY);
            list.AddSqlParameter("@ROOMOCCUPANCY", ROOMOCCUPANCY);
            list.AddSqlParameter("@DISCOUNT_DAY", DISCOUNT_DAY);
            list.AddSqlParameter("@DISCOUNT_MONTH", DISCOUNT_MONTH);
            list.AddSqlParameter("@EXPECTED_ARRIVALS", EXPECTED_ARRIVALS);
            list.AddSqlParameter("@EXPECTED_DEPARTURES", EXPECTED_DEPARTURES);
            list.AddSqlParameter("@CANCELLED_RESERVATION", CANCELLED_RESERATION);
            list.AddSqlParameter("@TODAY_ARRIVALS", TODAY_ARRIVALS);
            list.AddSqlParameter("@CHECKOUTFORTHE_DAY", CHECKOUT_FORTHEDAY);
            list.AddSqlParameter("@GUEST_ADVANCE", GUEST_ADVANCE);
            list.AddSqlParameter("@GUEST_INHOUSE", GUEST_INHOUSE);
            list.AddSqlParameter("@ROOM_RATELIST", ROOM_RATELIST);
            list.AddSqlParameter("@RESERVATION_LIST", RESERVATION_LIST);
            list.AddSqlParameter("@TRANSACTION_LIST", TRANSACTION_LIST);
            list.AddSqlParameter("@TAX_REPORT", TAX_REPORT);
            list.AddSqlParameter("@FO_TRANSACTIONLIST", FO_TRANSACTIONLIST);
            list.AddSqlParameter("@CHANGE_GUESTINFO", CHANGE_GUESTINFO);
            list.AddSqlParameter("@ROOM_CHANGE", ROOM_CHANGE);
            list.AddSqlParameter("@OUTSTANDING_BALANCE", OUTSTANDING_BALANCE);
            list.AddSqlParameter("@MONTHWISE_ROOMTARIFF", MONTHWISE_ROOMTARIFF);
            list.AddSqlParameter("@PENDINGBILL", PENDINGBILL);
            UPDATE_BY = login.u;
            list.AddSqlParameter("@UPDATE_BY", UPDATE_BY);
            UPDATE_DATE = DateTime.Today.Date;
            list.AddSqlParameter("@UPDATE_DATE", UPDATE_DATE);
            string S = "UPDATE REPORTPERMISSIONS SET DESIGINATION=@DESIGINATION,TARIFF_POSTED_DAY=@TARIFF_POSTED_DAY,ROOMOCCUPANCY=@ROOMOCCUPANCY,DISCOUNT_DAY=@DISCOUNT_DAY,DISCOUNT_MONTH=@DISCOUNT_MONTH,EXPECTED_ARRIVALS=@EXPECTED_ARRIVALS,CANCELLED_RESERVATION=@CANCELLED_RESERVATION,TODAY_ARRIVALS=@TODAY_ARRIVALS,CHECKOUTFORTHE_DAY=@CHECKOUTFORTHE_DAY,GUEST_ADVANCE=@GUEST_ADVANCE,GUEST_INHOUSE=@GUEST_INHOUSE,ROOM_RATELIST=@ROOM_RATELIST,RESERVATION_LIST=@RESERVATION_LIST,TRANSACTION_LIST=@TRANSACTION_LIST,TAX_REPORT=@TAX_REPORT,FO_TRANSACTIONLIST=@FO_TRANSACTIONLIST,CHANGE_GUESTINFO=@CHANGE_GUESTINFO,ROOM_CHANGE=@ROOM_CHANGE,OUTSTANDING_BALANCE=@OUTSTANDING_BALANCE,MONTHWISE_ROOMTARIFF=@MONTHWISE_ROOMTARIFF,PENDINGBILL=@PENDINGBILL WHERE USERNAME='" + USERNAME+"' ";
            DbFunctions.ExecuteCommand<int>(S,list);
        }
        public DataTable user()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT * FROM REGISTRATION";
            DataTable D = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return D;
        }
        public DataTable user1()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT DESGINATION FROM REGISTRATION WHERE USER_NAME='" + USERNAME + "'";
            DataTable S = DbFunctions.ExecuteCommand<DataTable>(s,list);
            return S;
        }

        public DataTable MASTER()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT * FROM MASTERPERMISSIONS WHERE USERNAME ='"+ USERNAME +"'";
            DataTable D = DbFunctions.ExecuteCommand<DataTable>(s,list);
            return D;
        }
        public DataTable MASTER1()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT * FROM MASTERPERMISSIONS WHERE USERNAME ='" + login.u + "'";
            DataTable D = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return D;
        }

        public DataTable uname()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT USERNAME FROM MASTERPERMISSIONS WHERE USERNAME='" + USERNAME + "'";
            DataTable D = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return D;
        }

        public DataTable Opr()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT * FROM OPERATIONPERMISSIONS WHERE USERNAME='" + USERNAME + "'";
            DataTable D = DbFunctions.ExecuteCommand<DataTable>(s,list);
            return D;
        }
        public DataTable Opr1()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT * FROM OPERATIONPERMISSIONS WHERE USERNAME='"+ login.u +"' ";
            DataTable D = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return D;
        }
        public DataTable rep()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT * FROM REPORTPERMISSIONS WHERE USERNAME='" + login.u+ "' ";
            DataTable D = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return D;
        }
        public DataTable unameopr()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT USERNAME FROM OPERATIONPERMISSIONS WHERE USERNAME='" + USERNAME + "'";
            DataTable D = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return D;
        }

        public DataTable REPORT()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT * FROM REPORTPERMISSIONS WHERE USERNAME='" + USERNAME + "'";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s,list);
            return d;
        }
        public DataTable REPORT1()
        {
            var list = new List<SqlParameter>();
            string s = "SELECT USERNAME FROM REPORTPERMISSIONS WHERE USERNAME ='"+ USERNAME +"'";
            DataTable d = DbFunctions.ExecuteCommand<DataTable>(s, list);
            return d;
        }
    }
}