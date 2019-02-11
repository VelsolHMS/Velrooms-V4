using HMS.mainwindowpages;
using HMS.Model.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HMS.mainwindowpages
{
    /// <summary>
    /// Interaction logic for UserPermissions.xaml
    /// </summary>
    public partial class UserPermission : Page
    {
        public UserPermission()
        {
            InitializeComponent();
            DataTable D = u.user();
            cbuser.ItemsSource = D.DefaultView;
            MASTER.IsEnabled = false;
            OPERATIONS.IsEnabled = false;
            REPORTS.IsEnabled = false;
            OTHERS.IsEnabled = false;
            savemaster.Content = "SAVE";
            saveopr.Content = "SAVE";
            saverep.Content = "SAVE";
        }
        Userpermission u = new Userpermission();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                spmaster.Visibility = Visibility.Visible;
                wpmaster.Visibility = Visibility.Visible;
                wpoperations.Visibility = Visibility.Hidden;
                spoperations.Visibility = Visibility.Hidden;
                spreports.Visibility = Visibility.Hidden;
                wpreports.Visibility = Visibility.Hidden;
                DataTable dmaster = u.MASTER();
                if (dmaster.Rows.Count == 0)
                {
                    spmaster.Visibility = Visibility.Visible;
                    wpmaster.Visibility = Visibility.Visible;
                }
                else
                {
                    int HOTELINFO = int.Parse(dmaster.Rows[0]["HOTELINFO"].ToString()); if (HOTELINFO == 1) { hotelinfo.IsChecked = true; } else { hotelinfo.IsChecked = false; }
                    int COMPANY = int.Parse(dmaster.Rows[0]["COMPANY"].ToString()); if (COMPANY == 1) { company.IsChecked = true; } else { company.IsChecked = false; }
                    int CATEGORY = int.Parse(dmaster.Rows[0]["CATEGORY"].ToString()); if (CATEGORY == 1) { category.IsChecked = true; } else { category.IsChecked = false; }
                    int PLANDEFINATION = int.Parse(dmaster.Rows[0]["PLANDEFINATION"].ToString());
                    if (PLANDEFINATION == 1)
                    {
                        plan.IsChecked = true;
                    }
                    else
                    {
                        plan.IsChecked = false;
                    }
                    int ROOMTARR = int.Parse(dmaster.Rows[0]["ROOMTARRIF"].ToString());
                    if (ROOMTARR == 1)
                    {
                        ROOMTARRIF.IsChecked = true;
                    }
                    else
                    {
                        ROOMTARRIF.IsChecked = false;
                    }
                    int TAX = int.Parse(dmaster.Rows[0]["TAX"].ToString());
                    if (TAX == 1)
                    {
                        taxcode.IsChecked = true;
                    }
                    else
                    {
                        taxcode.IsChecked = false;
                    }
                    int AMENITY = int.Parse(dmaster.Rows[0]["AMENITIES"].ToString());
                    if (AMENITY == 1)
                    {
                        amenities.IsChecked = true;
                    }
                    else
                    {
                        amenities.IsChecked = false;
                    }
                    int REVENUE = int.Parse(dmaster.Rows[0]["REVENUE"].ToString());
                    if (REVENUE == 1)
                    {
                        revenue.IsChecked = true;
                    }
                    else
                    {
                        revenue.IsChecked = false;
                    }
                    int DEPARTMENT = int.Parse(dmaster.Rows[0]["DEPARTMENT"].ToString());
                    if (DEPARTMENT == 1)
                    {
                        department.IsChecked = true;
                    }
                    else
                    {
                        department.IsChecked = false;
                    }
                    int RESETPASSWORD = int.Parse(dmaster.Rows[0]["RESET_PASSWORD"].ToString());
                    if (RESETPASSWORD == 1)
                    {
                        resetpassword.IsChecked = true;
                    }
                    else
                    {
                        resetpassword.IsChecked = false;
                    }
                    int REGUSER = int.Parse(dmaster.Rows[0]["REG_USER"].ToString());
                    if (REGUSER == 1)
                    {
                        reguser.IsChecked = true;
                    }
                    else
                    {
                        reguser.IsChecked = false;
                    }
                    int USERPERMISSION = int.Parse(dmaster.Rows[0]["USERPEMISSIONS"].ToString());
                    if (USERPERMISSION == 1)
                    {
                        userpermision.IsChecked = true;
                    }
                    else
                    {
                        userpermision.IsChecked = false;
                    }
                }
            }
            catch (Exception) { }
            //DataTable UNAME = u.uname();
            //if (UNAME.Rows.Count == 0)
            //{

            //}
            //else
            //{


            //    string NAME = UNAME.Rows[0]["USERNAME"].ToString();
            //    if (NAME == cbuser.Text)
            //    { 
            //        savemaster.Content = "UPDATE";
            //    }
            //    else
            //    {
            //        savemaster.Content = "SAVE";
            //    }
            //}
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            wpoperations.Visibility = Visibility.Visible;
            spoperations.Visibility = Visibility.Visible;
            spmaster.Visibility = Visibility.Hidden;
            wpmaster.Visibility = Visibility.Hidden;
            spreports.Visibility = Visibility.Hidden;
            wpreports.Visibility = Visibility.Hidden;
            DataTable UNAME = u.unameopr();
            if (UNAME.Rows.Count == 0)
            {
                wpoperations.Visibility = Visibility.Visible;
                spoperations.Visibility = Visibility.Visible;
            }
            else
            {
                string NAME = UNAME.Rows[0]["USERNAME"].ToString();
                if (NAME == cbuser.Text)
                {
                    savemaster.Content = "UPDATE";
                }
                else
                {
                    savemaster.Content = "SAVE";
                }
                DataTable dopr = u.Opr();
                if (dopr.Rows.Count == 0)
                {
                    wpoperations.Visibility = Visibility.Visible;
                    spoperations.Visibility = Visibility.Visible;
                }
                else
                {
                    int ENQUIRY = int.Parse(dopr.Rows[0]["ENQUIRY"].ToString());
                    if (ENQUIRY == 1)
                    {
                        enquiry.IsChecked = true;
                    }
                    else
                    {
                        enquiry.IsChecked = false;
                    }
                    int RESERVATION = int.Parse(dopr.Rows[0]["RESERVATION"].ToString());
                    if (RESERVATION == 1)
                    {
                        Reservation.IsChecked = true;
                    }
                    else
                    {
                        Reservation.IsChecked = false;
                    }
                    int CHECKIN = int.Parse(dopr.Rows[0]["CHECKIN"].ToString());
                    if (CHECKIN == 1)
                    {
                        Checkin.IsChecked = true;
                    }
                    else
                    {
                        Checkin.IsChecked = false;
                    }
                    int CHECKOUT = int.Parse(dopr.Rows[0]["CHECKOUT"].ToString());
                    if (CHECKOUT == 1)
                    {
                        checkout.IsChecked = true;
                    }
                    else
                    {
                        checkout.IsChecked = false;
                    }
                    int COCOMPANY = int.Parse(dopr.Rows[0]["CO_COMPANY"].ToString());
                    if (COCOMPANY == 1)
                    {
                        cocompany.IsChecked = true;
                    }
                    else
                    {
                        cocompany.IsChecked = false;
                    }
                    int CObill = int.Parse(dopr.Rows[0]["CO_BILLONHOLD"].ToString());
                    if (CObill == 1)
                    {
                        cobillonhold.IsChecked = true;
                    }
                    else
                    {
                        cobillonhold.IsChecked = false;
                    }
                    int COTRANSFER = int.Parse(dopr.Rows[0]["CO_TRANSFER"].ToString());
                    if (COTRANSFER == 1)
                    {
                        cotransfer.IsChecked = true;
                    }
                    else
                    {
                        cotransfer.IsChecked = false;
                    }
                    int ADVANCE = int.Parse(dopr.Rows[0]["ADVANCE"].ToString());
                    if (ADVANCE == 1)
                    {
                        advance.IsChecked = true;
                    }
                    else
                    {
                        advance.IsChecked = false;
                    }
                    int Pendingbill = int.Parse(dopr.Rows[0]["PENDINGBILL"].ToString());
                    if (Pendingbill == 1)
                    {
                        pendingbill.IsChecked = true;
                    }
                    else
                    {
                        pendingbill.IsChecked = false;
                    }
                    int pbcompanI = int.Parse(dopr.Rows[0]["PB_COMPANY"].ToString());
                    if (pbcompanI == 1)
                    {
                        pbcompany.IsChecked = true;
                    }
                    else
                    {
                        pbcompany.IsChecked = false;
                    }
                    int Pbbillonhold = int.Parse(dopr.Rows[0]["PB_BILLONHOLD"].ToString());
                    if (Pbbillonhold == 1)
                    {
                        pbbillonhold.IsChecked = true;
                    }
                    else
                    {
                        pbbillonhold.IsChecked = false;
                    }
                    int Groupcheckin = int.Parse(dopr.Rows[0]["GROUP_CHECKIN"].ToString());
                    if (Groupcheckin == 1)
                    {
                        groupcheckin.IsChecked = true;
                    }
                    else
                    {
                        groupcheckin.IsChecked = false;
                    }
                    int Postcharges = int.Parse(dopr.Rows[0]["POSTCHARGES"].ToString());
                    if (Postcharges == 1)
                    {
                        postcharges.IsChecked = true;
                    }
                    else
                    {
                        postcharges.IsChecked = false;
                    }
                    int Paidouts = int.Parse(dopr.Rows[0]["PAIDOUTS"].ToString());
                    if (Paidouts == 1)
                    {
                        paidouts.IsChecked = true;
                    }
                    else
                    {
                        paidouts.IsChecked = false;
                    }
                    int RoomchangE = int.Parse(dopr.Rows[0]["ROOMCHANGE"].ToString());
                    if (RoomchangE == 1)
                    {
                        Roomchange.IsChecked = true;
                    }
                    else
                    {
                        Roomchange.IsChecked = false;
                    }
                    int REFUND = int.Parse(dopr.Rows[0]["REFUND"].ToString());
                    if (REFUND == 1)
                    {
                        refund.IsChecked = true;
                    }
                    else
                    {
                        refund.IsChecked = false;
                    }
                    int BLOCK_ROOM = int.Parse(dopr.Rows[0]["BLOCK_ROOM"].ToString());
                    if (BLOCK_ROOM == 1)
                    {
                        Blockroom.IsChecked = true;
                    }
                    else
                    {
                        Blockroom.IsChecked = false;
                    }
                    int DISCOUNT = int.Parse(dopr.Rows[0]["DISCOUNT"].ToString());
                    if (DISCOUNT == 1)
                    {
                        discount.IsChecked = true;
                    }
                    else
                    {
                        discount.IsChecked = false;
                    }
                    int GUESTINFO = int.Parse(dopr.Rows[0]["GUESTINFO"].ToString());
                    if (GUESTINFO == 1)
                    {
                        Guestinfo.IsChecked = true;
                    }
                    else
                    {
                        Guestinfo.IsChecked = false;
                    }
                    int CHANGEROOMSTATUS = int.Parse(dopr.Rows[0]["CHANGEROOMSTATUS"].ToString());
                    if (CHANGEROOMSTATUS == 1)
                    {
                        changeroom.IsChecked = true;
                    }
                    else
                    {
                        changeroom.IsChecked = false;
                    }
                    int MISSALES = int.Parse(dopr.Rows[0]["MISSALES"].ToString());
                    if (MISSALES == 1)
                    {
                        missales.IsChecked = true;
                    }
                    else
                    {
                        missales.IsChecked = false;
                    }
                    int Billsettle = int.Parse(dopr.Rows[0]["BILLSETTLE"].ToString());
                    if (Billsettle == 1)
                    {
                        billsettle.IsChecked = true;
                    }
                    else
                    {
                        billsettle.IsChecked = false;
                    }
                    int REPRINT = int.Parse(dopr.Rows[0]["REPRINT"].ToString());
                    if (REPRINT == 1)
                    {
                        Reprint.IsChecked = true;
                    }
                    else
                    {
                        Reprint.IsChecked = false;
                    }
                    int DASHBOARD = int.Parse(dopr.Rows[0]["DASHBOARD"].ToString());
                    if (DASHBOARD == 1)
                    {
                        dashboard.IsChecked = true;
                    }
                    else
                    {
                        dashboard.IsChecked = false;
                    }
                }
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            wpoperations.Visibility = Visibility.Hidden;
            spoperations.Visibility = Visibility.Hidden;
            spmaster.Visibility = Visibility.Hidden;
            wpmaster.Visibility = Visibility.Hidden;
            spreports.Visibility = Visibility.Visible;
            wpreports.Visibility = Visibility.Visible;
            DataTable ureport = u.REPORT1();
            if (ureport.Rows.Count == 0)
            {
                spreports.Visibility = Visibility.Visible;
                wpreports.Visibility = Visibility.Visible;
            }
            else
            {
                string NAME = ureport.Rows[0]["USERNAME"].ToString();
                if (NAME == cbuser.Text)
                {
                    saverep.Content = "UPDATE";
                }
                else
                {
                    saverep.Content = "SAVE";
                }
            }
            DataTable s = u.REPORT();
            if(s.Rows.Count == 0)
            {

                spreports.Visibility = Visibility.Visible;
                wpreports.Visibility = Visibility.Visible;
            }
            else
            {
                int TARIFF = int.Parse(s.Rows[0]["TARIFF_POSTED_DAY"].ToString());
                if(TARIFF ==1)
                {
                    tariff.IsChecked = true;

                }
                else
                {
                    tariff.IsChecked = false;
                }
                int RoomOcupancy = int.Parse(s.Rows[0]["ROOMOCCUPANCY"].ToString());
                if(RoomOcupancy == 1)
                {
                    Room.IsChecked = true;
                }
                else
                {
                    Room.IsChecked = false;
                }
                int discountday = int.Parse(s.Rows[0]["DISCOUNT_DAY"].ToString());
                if(discountday == 1)
                {
                    daydiscount.IsChecked = true;
                }
                else
                {
                    daydiscount.IsChecked = false;
                }
                int discountmonth = int.Parse(s.Rows[0]["DISCOUNT_MONTH"].ToString());
                if (discountmonth ==1)
                {
                    monthdiscount.IsChecked = true;
                }
                else
                {
                    monthdiscount.IsChecked = false;
                }
                int expectedarrival = int.Parse(s.Rows[0]["EXPECTED_ARRIVALS"].ToString());
                if (expectedarrival ==1)
                {
                    expectedarrivals.IsChecked = true;

                }
                else
                {
                    expectedarrivals.IsChecked = false;
                }
                int expecteddepartur = int.Parse(s.Rows[0]["EXPECTED_DEPARTURES"].ToString());
                if (expecteddepartur ==1)
                {
                    expecteddepartures.IsChecked = true;
                }
                else
                {
                    expecteddepartures.IsChecked = false;
                }
                int cancellreservation = int.Parse(s.Rows[0]["CANCELLED_RESERVATION"].ToString());
                if (cancellreservation ==1)
                {
                    reservationcancel.IsChecked = true;
                }
                else
                {
                    reservationcancel.IsChecked = false;
                }
                int todayarrivals = int.Parse(s.Rows[0]["TODAY_ARRIVALS"].ToString());
                if (todayarrivals == 1)
                {
                    todayarrival.IsChecked = true;
                }
                else
                {
                    todayarrival.IsChecked = false;
                }
                int checkoutforthedays = int.Parse(s.Rows[0]["CHECKOUTFORTHE_DAY"].ToString());
                if (checkoutforthedays == 1)
                {
                    checkoutfortheday.IsChecked = true;
                }
                else
                {
                    checkoutfortheday.IsChecked = false;
                }
                int guestadvances = int.Parse(s.Rows[0]["GUEST_ADVANCE"].ToString());
                if (guestadvances == 1)
                {
                    guestadvance.IsChecked = true;
                }
                else
                {
                    guestadvance.IsChecked = false;
                }
                int guestinhouse = int.Parse(s.Rows[0]["GUEST_INHOUSE"].ToString());
                if (guestinhouse == 1)
                {
                    Inhouseguest.IsChecked = true;
                }
                else
                {
                    Inhouseguest.IsChecked = false;
                }
                int roomrate = int.Parse(s.Rows[0]["ROOM_RATELIST"].ToString());
                if (roomrate ==1)
                {
                    roomratelist.IsChecked = true;
                }
                else
                {
                    roomratelist.IsChecked = false;
                }
                int reservation = int.Parse(s.Rows[0]["RESERVATION_LIST"].ToString());
                if (reservation ==1)
                {
                    reservationlist.IsChecked = true;
                }
                else
                {
                    reservationlist.IsChecked = false;
                }
                int transaction = int.Parse(s.Rows[0]["TRANSACTION_LIST"].ToString());
                if (transaction ==1)
                {
                    transactionlist.IsChecked = true;
                }
                else
                {
                    transactionlist.IsChecked = false;
                }
                int tax = int.Parse(s.Rows[0]["TAX_REPORT"].ToString());
                if (tax ==1 )
                {
                    TaxReports.IsChecked = true;
                }
                else
                {
                    TaxReports.IsChecked = false;
                }
                int fo = int.Parse(s.Rows[0]["FO_TRANSACTIONLIST"].ToString());
                if (fo ==1)
                {
                    folist.IsChecked = true;
                }
                else
                {
                    folist.IsChecked = false;
                }
                int changeguestinfo = int.Parse(s.Rows[0]["CHANGE_GUESTINFO"].ToString());
                if (changeguestinfo ==1)
                {
                    guestchange.IsChecked = true;
                }
                else
                {
                    guestchange.IsChecked = false;
                }
                int roomchange = int.Parse(s.Rows[0]["ROOM_CHANGE"].ToString());
                if (roomchange == 1)
                {
                    changeroomreport.IsChecked = true;
                }
                else
                {
                    changeroomreport.IsChecked = false;
                }
                int outstanding= int.Parse(s.Rows[0]["OUTSTANDING_BALANCE"].ToString());
                if (outstanding ==1)
                {
                    outstandingbalance.IsChecked = true;
                }
                else
                {
                    outstandingbalance.IsChecked = false;
                }
                int month = int.Parse(s.Rows[0]["MONTHWISE_ROOMTARIFF"].ToString());
                if (month ==1)
                {
                    monthwiseroom.IsChecked = true;
                }
                else
                {
                    monthwiseroom.IsChecked = false;
                }
                int pending = int.Parse(s.Rows[0]["PENDINGBILL"].ToString());
                if (pending ==1)
                {
                    pendingbillreport.IsChecked = true;
                }
                else
                {
                    pendingbillreport.IsChecked  = false;
                }
            }
        }

        private void saverep_Click(object sender, RoutedEventArgs e)
        {
            u.DESIGINATION = cbdesignation.Text;
            if (tariff.IsChecked ==true)
            {
                tariff.Content = 1;
                u.TARIFF_POSTEDFORTHEDAY = Convert.ToString(tariff.Content);
            }
            else
            {
                tariff.Content = 0;
                u.TARIFF_POSTEDFORTHEDAY = Convert.ToString(tariff.Content);

            }
            if (Room.IsChecked ==true)
            {
                Room.Content = 1;
                u.ROOMOCCUPANCY = Convert.ToString(Room.Content);
            }
            else
            {
                Room.Content = 0;
                u.ROOMOCCUPANCY = Convert.ToString(Room.Content);
            }
            if (daydiscount.IsChecked ==true)
            {
                daydiscount.Content = 1;
                u.DISCOUNT_DAY = Convert.ToString(daydiscount.Content);
            }
            else
            {
                daydiscount.Content = 0;
                u.DISCOUNT_DAY = Convert.ToString(daydiscount.Content);
            }
            if (monthdiscount.IsChecked ==true)
            {
                monthdiscount.Content = 1;
                u.DISCOUNT_MONTH = Convert.ToString(monthdiscount.Content);
            }
            else
            {
                monthdiscount.Content = 0;
                u.DISCOUNT_MONTH = Convert.ToString(monthdiscount.Content);
            }
            if (expectedarrivals.IsChecked ==true)
            {
                expectedarrivals.Content = 1;
                u.EXPECTED_ARRIVALS = Convert.ToString(expectedarrivals.Content);
            }
            else
            {
                expectedarrivals.Content = 0;
                u.EXPECTED_ARRIVALS = Convert.ToString(expectedarrivals.Content);
            }
            if (expecteddepartures.IsChecked ==true)
            {
                expecteddepartures.Content = 1;
                u.EXPECTED_DEPARTURES = Convert.ToString(expecteddepartures.Content);
            }
            else
            {
                expecteddepartures.Content = 0;
                u.EXPECTED_DEPARTURES = Convert.ToString(expecteddepartures.Content);
            }
            if (reservationcancel.IsChecked ==true)
            {
                reservationcancel.Content = 1;
                u.CANCELLED_RESERATION = Convert.ToString(reservationcancel.Content);
            }
            else
            {
                reservationcancel.Content = 0;
                u.CANCELLED_RESERATION = Convert.ToString(reservationcancel.Content);
            }
            if (todayarrival.IsChecked ==true)
            {
                todayarrival.Content = 1;
                u.TODAY_ARRIVALS = Convert.ToString(todayarrival.Content);
            }
            else
            {
                todayarrival.Content = 0;
                u.TODAY_ARRIVALS = Convert.ToString(todayarrival.Content);
            }
            if (checkoutfortheday.IsChecked ==true)
            {
                checkoutfortheday.Content = 1;
                u.CHECKOUT_FORTHEDAY = Convert.ToString(checkoutfortheday.Content);
            }
            else
            {
                checkoutfortheday.Content = 0;
                u.CHECKOUT_FORTHEDAY = Convert.ToString(checkoutfortheday.Content);
            }
            if (guestadvance.IsChecked ==true)
            {
                guestadvance.Content = 1;
                u.GUEST_ADVANCE = Convert.ToString(guestadvance.Content);
            }
            else
            {
                guestadvance.Content = 0;
                u.GUEST_ADVANCE = Convert.ToString(guestadvance.Content);
            }
            if(Inhouseguest.IsChecked == true)
            {
                Inhouseguest.Content = 1;
                u.GUEST_INHOUSE = Convert.ToString(Inhouseguest.Content);
            }
            else
            {
                Inhouseguest.Content = 0;
                u.GUEST_INHOUSE = Convert.ToString(Inhouseguest.Content);
            }
            if (roomratelist.IsChecked ==true)
            {
                roomratelist.Content = 1;
                u.ROOM_RATELIST = Convert.ToString(roomratelist.Content);
            }
            else
            {
                roomratelist.Content = 0;
                u.ROOM_RATELIST = Convert.ToString(roomratelist.Content);
            }
            if(reservationlist.IsChecked == true)
            {
                reservationlist.Content = 1;
                u.RESERVATION_LIST = Convert.ToString(reservationlist.Content);
            }
            else
            {
                reservationlist.Content = 0;
                u.RESERVATION_LIST = Convert.ToString(reservationlist.Content);
            }
            if (transactionlist.IsChecked ==true)
            {
                transactionlist.Content = 1;
                u.TRANSACTION_LIST = Convert.ToString(transactionlist.Content);
            }
            else
            {
                transactionlist.Content = 0;
                u.TRANSACTION_LIST = Convert.ToString(transactionlist.Content);
            }
            if (TaxReports.IsChecked ==true)
            {
                TaxReports.Content = 1;
                u.TAX_REPORT = Convert.ToString(TaxReports.Content);
            }
            else
            {
                TaxReports.Content = 0;
                u.TAX_REPORT = Convert.ToString(TaxReports.Content);
            }
            if (folist.IsChecked ==true)
            {
                folist.Content = 1;
                u.FO_TRANSACTIONLIST = Convert.ToString(folist.Content);
            }
            else
            {
                folist.Content = 0;
                u.FO_TRANSACTIONLIST = Convert.ToString(folist.Content);
            }
            if (guestchange.IsChecked ==true)
            {
                guestchange.Content = 1;
                u.CHANGE_GUESTINFO = Convert.ToString(guestchange.Content);
            }
            else
            {
                guestchange.Content = 0;
                u.CHANGE_GUESTINFO = Convert.ToString(guestchange.Content);
            }
            if (changeroomreport.IsChecked ==true)
            {
                changeroomreport.Content = 1;
                u.ROOM_CHANGE = Convert.ToString(changeroomreport.Content);
            }
            else
            {
                changeroomreport.Content = 0;
                u.ROOM_CHANGE = Convert.ToString(changeroomreport.Content);
            }
            if (outstandingbalance.IsChecked ==true)
            {
                outstandingbalance.Content = 1;
                u.OUTSTANDING_BALANCE = Convert.ToString(outstandingbalance.Content);
            }
            else
            {
                outstandingbalance.Content = 0;
                u.OUTSTANDING_BALANCE = Convert.ToString(outstandingbalance.Content);
            }
            if (monthwiseroom.IsChecked ==true)
            {
                monthwiseroom.Content = 1;
                u.MONTHWISE_ROOMTARIFF =Convert.ToString(monthwiseroom.Content);
            }
            else
            {
                monthwiseroom.Content = 0;
                u.MONTHWISE_ROOMTARIFF = Convert.ToString(monthwiseroom.Content);
            }
            if (pendingbillreport.IsChecked ==true)
            {
                pendingbillreport.Content = 1;
                u.PENDINGBILL = Convert.ToString(pendingbillreport.Content);
            }
            else
            {
                pendingbillreport.Content = 0;
                u.PENDINGBILL = Convert.ToString(pendingbillreport.Content);
            }
            string S = "SAVE", C = Convert.ToString(saverep.Content);
            if (C == S)
            {
                u.Report();
            }
            else
            {
                u.Reportupdate();
            }
            cbuser.Text = "";
            cbdesignation.Text = "";
            this.NavigationService.Refresh();
        }

        private void resetrep_Click(object sender, RoutedEventArgs e)
        {

        }

        private void saveopr_Click(object sender, RoutedEventArgs e)
        {
            u.DESIGINATION = cbdesignation.Text;
            if (enquiry.IsChecked ==true)
            {
                enquiry.Content = 1;
                u.ENQUIRY = Convert.ToString(enquiry.Content);
            }
            else
            {
                enquiry.Content = 0;
                u.ENQUIRY = Convert.ToString(enquiry.Content);
            }
            if (Reservation.IsChecked == true)
            {
                Reservation.Content = 1;
                u.RESERVATION = Convert.ToString(Reservation.Content);
            }
            else
            {
                Reservation.Content = 0;
                u.RESERVATION = Convert.ToString(Reservation.Content);
            }
            if (Checkin.IsChecked ==true)
            {
                Checkin.Content = 1;
                u.CHECKIN = Convert.ToString(Checkin.Content);
            }
            else
            {
                Checkin.Content = 0;
                u.CHECKIN = Convert.ToString(Checkin.Content);
            }
            if (checkout.IsChecked ==true)
            {
                checkout.Content = 1;
                u.CHECKOUT = Convert.ToString(checkout.Content);
            }
            else
            {
                checkout.Content = 0;
                u.CHECKOUT = Convert.ToString(checkout.Content);
            }
            if (cocompany.IsChecked ==true)
            {
                cocompany.Content = 1;
                u.CO_COMPANY = Convert.ToString(cocompany.Content);
            }
            else
            {
                cocompany.Content = 0;
                u.CO_COMPANY = Convert.ToString(cocompany.Content);
            }
            if (cobillonhold.IsChecked ==true)
            {
                cobillonhold.Content = 1;
                u.CO_BILLONHOLD = Convert.ToString(cobillonhold.Content);
            }
            else
            {
                cobillonhold.Content = 1;
                u.CO_BILLONHOLD = Convert.ToString(cobillonhold.Content);
            }
            if (cotransfer.IsChecked ==true)
            {
                cotransfer.Content = 1;
                u.CO_TRANSFER = Convert.ToString(cotransfer.Content);
            }
            else
            {
                cotransfer.Content = 0;
                u.CO_TRANSFER = Convert.ToString(cotransfer.Content);
            }
            if (advance.IsChecked ==true)
            {
                advance.Content = 1;
                u.ADVANCE = Convert.ToString(advance.Content);
            }
            else
            {
                advance.Content = 0;
                u.ADVANCE = Convert.ToString(advance.Content);
            }
            if (pendingbill.IsChecked ==true)
            {
                pendingbill.Content = 1;
                u.PENDINGBILL = Convert.ToString(pendingbill.Content);
            }
            else
            {
                pendingbill.Content = 0;
                u.PENDINGBILL = Convert.ToString(pendingbill.Content);
            }
            if (pbcompany.IsChecked ==true)
            {
                pbcompany.Content = 1;
                u.PB_COMPANY = Convert.ToString(pbcompany.Content);
            }
            else
            {
                pbcompany.Content = 0;
                u.PB_COMPANY = Convert.ToString(pbcompany.Content);
            }
            if (pbbillonhold.IsChecked ==true)
            {
                pbbillonhold.Content = 1;
                u.PB_BILLONHOLD = Convert.ToString(pbbillonhold.Content);
            }
            else
            {
                pbbillonhold.Content = 0;
                u.PB_BILLONHOLD = Convert.ToString(pbbillonhold.Content);
            }
            if (groupcheckin.IsChecked ==true)
            {
                groupcheckin.Content = 1;
                u.GROUP_CHECKIN = Convert.ToString(groupcheckin.Content);
            }
            else
            {
                groupcheckin.Content = 0;
                u.GROUP_CHECKIN = Convert.ToString(groupcheckin.Content);
            }
            if (postcharges.IsChecked ==true)
            {
                postcharges.Content = 1;
                u.POSTCHARGES = Convert.ToString(postcharges.Content);
            }
            else
            {
                postcharges.Content = 0;
                u.POSTCHARGES = Convert.ToString(postcharges.Content);
            }
            if (paidouts.IsChecked ==true)
            {
                paidouts.Content = 1;
                u.PAIDOUTS = Convert.ToString(paidouts.Content);
            }
            else
            {
                paidouts.Content = 0;
                u.PAIDOUTS = Convert.ToString(paidouts.Content);
            }
            if (Roomchange.IsChecked ==true)
            {
                Roomchange.Content = 1;
                u.ROOMCHANGE = Convert.ToString(Roomchange.Content);
            }
            else
            {
                Roomchange.Content = 0;
                u.ROOMCHANGE = Convert.ToString(Roomchange.Content);
            }
            if (refund.IsChecked ==true)
            {
                refund.Content = 1;
                u.REFUND = Convert.ToString(refund.Content);

            }
            else
            {
                refund.Content = 0;
                u.REFUND = Convert.ToString(refund.Content);

            }
            if (Blockroom.IsChecked ==true)
            {
                Blockroom.Content = 1;
                u.BLOCK_ROOM = Convert.ToString(Blockroom.Content);
            }
            else
            {
                Blockroom.Content = 0;
                u.BLOCK_ROOM = Convert.ToString(Blockroom.Content);
            }
            if (discount.IsChecked ==true)
            {
                discount.Content = 1;
                u.DISCOUNT = Convert.ToString(discount.Content);
            }
            else
            {
                discount.Content = 0;
                u.DISCOUNT = Convert.ToString(discount.Content);
            }
            if (Guestinfo.IsChecked ==true)
            {
                Guestinfo.Content = 1;
                u.GUESTINFO = Convert.ToString(Guestinfo.Content);
            }
            else
            {
                Guestinfo.Content = 0;
                u.GUESTINFO = Convert.ToString(Guestinfo.Content);
            }
            if (changeroom.IsChecked ==true)
            {
                changeroom.Content = 1;
                u.CHANGEROOMSTATUS = Convert.ToString(changeroom.Content);
            }
            else
            {
                changeroom.Content = 0;
                u.CHANGEROOMSTATUS = Convert.ToString(changeroom.Content);
            }
            if (missales.IsChecked ==true)
            {
                missales.Content = 1;
                u.MISSALES = Convert.ToString(missales.Content);
            }
            else
            {
                missales.Content = 0;
                u.MISSALES = Convert.ToString(missales.Content);
            }
            if (billsettle.IsChecked ==true)
            {
                billsettle.Content = 1;
                u.BILLSETTLE = Convert.ToString(billsettle.Content);
            }
            else
            {
                billsettle.Content = 0;
                u.BILLSETTLE = Convert.ToString(billsettle.Content);
            }
            if (Reprint.IsChecked ==true)
            {
                Reprint.Content = 1;
                u.REPRINT = Convert.ToString(Reprint.Content);
            }
            else
            {
                Reprint.Content = 0;
                u.REPRINT = Convert.ToString(Reprint.Content);
            }
            if (dashboard.IsChecked ==true)
            {
                dashboard.Content =1;
                u.DASHBOARD = Convert.ToString(dashboard.Content);
            }
            else
            {
                dashboard.Content = 0;
                u.DASHBOARD = Convert.ToString(dashboard.Content);
            }
            string S = "SAVE", C = Convert.ToString(saveopr.Content);
            if (C ==S)
            {
                u.operation();
            }
            else
            {
                u.operationupdate();
            }
            cbuser.Text = "";
            cbdesignation.Text = "";
            this.NavigationService.Refresh();
        }

        private void resetopr_Click(object sender, RoutedEventArgs e)
        {

        }

        private void savemaster_Click(object sender, RoutedEventArgs e)
        {
            u.DESIGINATION = cbdesignation.Text;
            if(hotelinfo.IsChecked == true)
            {
                hotelinfo.Content = 1;
                u.HOTELINFO = Convert.ToString(hotelinfo.Content);

            }
            else
            {
                hotelinfo.Content = 0;
                u.HOTELINFO = Convert.ToString(hotelinfo.Content);
            }
            if(company.IsChecked == true)
            {
                company.Content = 1;
                u.COMPANY = Convert.ToString(company.Content);
            }
            else
            {
                company.Content = 0;
                u.COMPANY = Convert.ToString(company.Content);
            }
            if (category.IsChecked ==true)
            {
                category.Content = 1;
                u.CATEGORY = Convert.ToString(category.Content);
            }
            else
            {
                category.Content = 0;
                u.CATEGORY = Convert.ToString(category.Content);
            }
            if (plan.IsChecked ==true)
            {
                plan.Content = 1;
                u.PLANDEFINATION = Convert.ToString(plan.Content);
            }
            else
            {
                plan.Content = 0;
                u.PLANDEFINATION = Convert.ToString(plan.Content);
            }
            if (ROOMTARRIF.IsChecked ==true)
            {
                ROOMTARRIF.Content = 1;
                u.ROOMTARIFF = Convert.ToString(ROOMTARRIF.Content);
            }
            else
            {
                ROOMTARRIF.Content = 0;
                u.ROOMTARIFF = Convert.ToString(ROOMTARRIF.Content);
            }
            if (taxcode.IsChecked == true)
            {
                taxcode.Content = 1;
                u.TAX = Convert.ToString(taxcode.Content);
            }
            else
            {
                taxcode.Content = 0;
                u.TAX = Convert.ToString(taxcode.Content);
            }
            if (amenities.IsChecked == true)
            {
                amenities.Content = 1;
                u.AMENITIES = Convert.ToString(amenities.Content);
            }
            else
            {
                amenities.Content = 0;
                u.AMENITIES = Convert.ToString(amenities.Content);
            }
            if (revenue.IsChecked ==true)
            {
                revenue.Content = 1;
                u.REVENUE = Convert.ToString(revenue.Content);
            }
            else
            {
                revenue.Content = 0;
                u.REVENUE = Convert.ToString(revenue.Content);
            }
            if (department.IsChecked ==true)
            {
                department.Content = 1;
                u.DEPARTMENT = Convert.ToString(department.Content);
            }
            else
            {
                department.Content = 0;
                u.DEPARTMENT = Convert.ToString(department.Content);
            }
            if (resetpassword.IsChecked ==true)
            {
                resetpassword.Content = 1;
                u.RESET_PASSWORD =Convert.ToString(resetpassword.Content);
            }
            else
            {
                resetpassword.Content = 0;
                u.RESET_PASSWORD = Convert.ToString(resetpassword.Content);
            }
            if (reguser.IsChecked ==true)
            {
                reguser.Content = 1;
                u.REG_USER = Convert.ToString(reguser.Content);
            }
            else
            {
                reguser.Content = 0;
                u.REG_USER = Convert.ToString(reguser.Content);
            }
            if (userpermision.IsChecked ==true)
            {
                userpermision.Content = 1;
                u.USERPERMISSIONS = Convert.ToString(userpermision.Content);
            }
            else
            {
                userpermision.Content = 0;
                u.USERPERMISSIONS = Convert.ToString(userpermision.Content);
            }
            u.USERNAME = cbuser.Text;
            u.DESIGINATION = cbdesignation.Text;
           string a ="SAVE", b = Convert.ToString(savemaster.Content);
            if (b == a)
            {
                u.master();
            }
            else
            {
                u.masterupdate();
            }
            cbuser.Text = "";
            cbdesignation.Text = "";
            this.NavigationService.Refresh();
        }

        private void resetmaster_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbuser_DropDownClosed(object sender, EventArgs e)
        {
            u.USERNAME = cbuser.Text; 
            DataTable s = u.user1();
            cbdesignation.ItemsSource = s.DefaultView;
            MASTER.IsEnabled = true;
            OPERATIONS.IsEnabled = true;
            REPORTS.IsEnabled = true;
            OTHERS.IsEnabled = true;
            DataTable UNAME = u.uname();
            if (UNAME.Rows.Count == 0)
            {

            }
            else
            {


                string NAME = UNAME.Rows[0]["USERNAME"].ToString();
                if (NAME == cbuser.Text)
                {
                    savemaster.Content = "UPDATE";
                }
                else
                {
                    savemaster.Content = "SAVE";
                }
            }
            DataTable uoprname = u.unameopr();
            if(uoprname.Rows.Count == 0)
            {

            }
            else
            {
                string NAME = uoprname.Rows[0]["USERNAME"].ToString();
                if (NAME == cbuser.Text)
                {
                    saveopr.Content = "UPDATE";
                }
                else
                {
                    saveopr.Content = "SAVE";
                }
            }
            DataTable ureport = u.REPORT1();
            if (ureport.Rows.Count == 0)
            {

            }
            else
            {
                string NAME = ureport.Rows[0]["USERNAME"].ToString();
                if (NAME == cbuser.Text)
                {
                    saverep.Content = "UPDATE";
                }
                else
                {
                    saverep.Content = "SAVE";
                }
            }
        }
    }
}
