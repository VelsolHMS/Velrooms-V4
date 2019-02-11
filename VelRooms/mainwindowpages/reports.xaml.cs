using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CrystalDecisions.CrystalReports;
using System.Data;
using HMS.View.Operations;
using CrystalDecisions.CrystalReports.Engine;
using HMS.Model;
using HMS.Model.Operations;
using System.Data.SqlClient;
using HMS.Model.Masters;
using HMS.View;

namespace HMS.mainwindowpages
{
    /// <summary>
    /// Interaction logic for reports.xaml
    /// </summary>
    public partial class reports : Window
    {

        public static int a = 0;
        Userpermission u = new Userpermission();
        public reports()
        {
            InitializeComponent();
           
                //if (a == 1)
                //{
                //    lable.Visibility = Visibility.Hidden;
                //    Reports.Visibility = Visibility.Hidden;
                //    btnreport.Visibility = Visibility.Hidden;
                //    (ssrsreport.Child as System.Windows.Forms.WebBrowser).Navigate("http://velsol/Reports/Pages/Report.aspx?ItemPath=%2fSSRSReporting%2fCHECKOUT");
                //}
                //else if (a == 2)
                //{
                //    lable.Visibility = Visibility.Hidden;
                //    Reports.Visibility = Visibility.Hidden;
                //    btnreport.Visibility = Visibility.Hidden;
                //    (ssrsreport.Child as System.Windows.Forms.WebBrowser).Navigate("http://velsol/Reports/Pages/Report.aspx?ItemPath=%2fSSRSReporting%2fReprint");
                //}
                //else
                //{
                //}
            
        }

        private void btnreport_Click(object sender, RoutedEventArgs e)
        {
            DataTable D = u.rep();
            if (D.Rows.Count == 0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
            }
            else
            {

                //TARIFFPOSTEDFORTHEDAY
                int tarrif = int.Parse(D.Rows[0]["TARIFF_POSTED_DAY"].ToString());
                if (tarrif == 1)
                {

                    if (Reports.Text == "Tariff Posted For The Day")
                    {
                        (ssrsreport.Child as System.Windows.Forms.WebBrowser).Navigate("http://velsol/Reports/Pages/Report.aspx?ItemPath=%2fSSRSReporting%2fTarrifPostedForTheDay");
                    }
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE PERMISSION TO OPEN THIS REPORT");
                }
                //ROOMOCCUPANCY
                int room = int.Parse(D.Rows[0]["ROOMOCCUPANCY"].ToString());
                if (room == 1)
                {

                    if (Reports.Text == "Room Occupancy")
                    {
                        (ssrsreport.Child as System.Windows.Forms.WebBrowser).Navigate("http://velsol/Reports/Pages/Report.aspx?ItemPath=%2fSSRSReporting%2fRoomOccupency");
                    }
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE PERMISSION TO OPEN THIS REPORT");
                }
                //DISCOUNTDAY
                int DISCOUNTDAY = int.Parse(D.Rows[0]["DISCOUNT_DAY"].ToString());
                if (DISCOUNTDAY == 1)
                {
                    if (Reports.Text == "Discount (Day Wise Report)")
                    {
                        (ssrsreport.Child as System.Windows.Forms.WebBrowser).Navigate("http://velsol/Reports/Pages/Report.aspx?ItemPath=%2fSSRSReporting%2fDiscount_Date_Wise");
                    }
                }

                else
                {
                    MessageBox.Show("YOU DON'T HAVE PERMISSION TO OPEN THIS REPORT");
                }
                //DISCOUNTMONTH
                int DISCOUNTMONTH = int.Parse(D.Rows[0]["DISCOUNT_MONTH"].ToString());
                if (DISCOUNTMONTH == 1)
                {
                    if (Reports.Text == "Discount (Month Wise Report)")
                    {
                        (ssrsreport.Child as System.Windows.Forms.WebBrowser).Navigate("http://velsol/Reports/Pages/Report.aspx?ItemPath=%2fSSRSReporting%2fDiscount_Month_Wise");
                    }
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE PERMISSION TO OPEN THIS REPORT");
                }

                //EXPECTEDARRIVALS
                int EXPECTEDARRIVALS = int.Parse(D.Rows[0]["EXPECTED_ARRIVALS"].ToString());
                if (EXPECTEDARRIVALS == 1)
                {
                    if (Reports.Text == "Expected Arrivals")
                    {
                        (ssrsreport.Child as System.Windows.Forms.WebBrowser).Navigate("http://velsol/Reports/Pages/Report.aspx?ItemPath=%2fSSRSReporting%2fRESERVATION");
                    }
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE PERMISSION TO OPEN THIS REPORT");
                }
                //EXPECTEDDEPARTURES
                int EXPECTEDEPARTURE = int.Parse(D.Rows[0]["EXPECTED_DEPARTURES"].ToString());
                if (EXPECTEDEPARTURE == 1)
                {
                    if (Reports.Text == "Expected Departures")
                    {
                        (ssrsreport.Child as System.Windows.Forms.WebBrowser).Navigate("http://velsol/Reports/Pages/Report.aspx?ItemPath=%2fSSRSReporting%2fDepartures");
                    }
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE PERMISSION TO OPEN THIS REPORT");
                }
                //CANCELRESERVATION
                 int CANCEL = int.Parse(D.Rows[0]["CANCELLED_RESERVATION"].ToString());
                 if (CANCEL == 1)
                 {
                 if (Reports.Text == "Cancelled Reservations")
                 {
                   (ssrsreport.Child as System.Windows.Forms.WebBrowser).Navigate("http://velsol/Reports/Pages/Report.aspx?ItemPath=%2fSSRSReporting%2fRESERVATIONCANCEL");
                 }
                 }
                 else
                  {
                     MessageBox.Show("YOU DON'T HAVE PERMISSION TO OPEN THIS REPORT");
                  }
                 //TODAYARRIVAL
                int todayarrival = int.Parse(D.Rows[0]["TODAY_ARRIVALS"].ToString());
                if (todayarrival == 1)
                {
                if (Reports.Text == "Todays Arrivals")
                {
                    (ssrsreport.Child as System.Windows.Forms.WebBrowser).Navigate("http://velsol/Reports/Pages/Report.aspx?ItemPath=%2fSSRSReporting%2fTodays+arrivals");
                }
                }
                else
                {
                  MessageBox.Show("YOU DON'T HAVE PERMISSION TO OPEN THIS REPORT");
                }
                //CHECKOUTFORTHEDAY
                int checkoutfortheday = int.Parse(D.Rows[0]["CHECKOUTFORTHE_DAY"].ToString());
                if (checkoutfortheday == 1)
                {
                    if (Reports.Text == "Checkouts For The Day")
                    {
                        (ssrsreport.Child as System.Windows.Forms.WebBrowser).Navigate("http://velsol/Reports/Pages/Report.aspx?ItemPath=%2fSSRSReporting%2fCheckoutsfortheday");
                    }
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE PERMISSION TO OPEN THIS REPORT");
                }

                //GUESTADVANCE
                int guestadvance = int.Parse(D.Rows[0]["GUEST_ADVANCE"].ToString());
                if (guestadvance ==1)
                {
                    if (Reports.Text == "Guest Advances")
                    {
                        (ssrsreport.Child as System.Windows.Forms.WebBrowser).Navigate("http://velsol/Reports/Pages/Report.aspx?ItemPath=%2fSSRSReporting%2fGUESTADVANCE");
                    }
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE PERMISSION TO OPEN THIS REPORT");
                }
                //GUESTINHOUSE
                int guestinhoousse = int.Parse(D.Rows[0]["GUEST_INHOUSE"].ToString());
                if (guestinhoousse == 1)
                {
                    if (Reports.Text == "Guest In House")
                    {
                        //  (ssrsreport.Child as System.Windows.Forms.WebBrowser).Navigate("http://velsol/Reports/Pages/Report.aspx?ItemPath=%2fSSRSReporting%2fGuestinhouse");
                     
                    }
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE PERMISSION TO OPEN THIS REPORT");
                }

                //ROOMRATELIST
                int roomratelist = int.Parse(D.Rows[0]["ROOM_RATELIST"].ToString());
                if (roomratelist == 1)
                {
                    if (Reports.Text == "Room Rate List")
                    {
                        (ssrsreport.Child as System.Windows.Forms.WebBrowser).Navigate("http://velsol/Reports/Pages/Report.aspx?ItemPath=%2fSSRSReporting%2fRoomRateList");
                    }
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE PERMISSION TO OPEN THIS REPORT");
                }
                //RESERVATIONLIST
                int reservationlist = int.Parse(D.Rows[0]["RESERVATION_LIST"].ToString());
                if (reservationlist ==1)
                {
                    if (Reports.Text == "Reservation List")
                    {
                        (ssrsreport.Child as System.Windows.Forms.WebBrowser).Navigate("http://velsol/Reports/Pages/Report.aspx?ItemPath=%2fSSRSReporting%2fReservatonlist");
                    }
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE PERMISSION TO OPEN THIS REPORT");
                }

                //TRANSACTIONLIST
                int transactionlist = int.Parse(D.Rows[0]["TRANSACTION_LIST"].ToString());
                if (transactionlist == 1)
                {
                    if (Reports.Text == "Transaction List")
                    {
                        (ssrsreport.Child as System.Windows.Forms.WebBrowser).Navigate("http://velsol/Reports/Pages/Report.aspx?ItemPath=%2fSSRSReporting%2fGuestinhouse");
                    }
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE PERMISSION TO OPEN THIS REPORT");
                }
                //TAXREPORT
                int taxreport = int.Parse(D.Rows[0]["TAX_REPORT"].ToString());
                if (taxreport == 1)
                {
                    if (Reports.Text == "Tax Report")
                    {
                        (ssrsreport.Child as System.Windows.Forms.WebBrowser).Navigate("http://velsol/Reports/Pages/Report.aspx?ItemPath=%2fSSRSReporting%2fDate+wise+Tax_Report");
                    }
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE PERMISSION TO OPEN THIS REPORT");
                }
                //FO TRANSACTIONLIST
                int fo = int.Parse(D.Rows[0]["FO_TRANSACTIONLIST"].ToString());
                if (fo == 1)
                {
                    if (Reports.Text == "Front Office Transaction List")
                    {
                        //(ssrsreport.Child as System.Windows.Forms.WebBrowser).Navigate("http://velsol/Reports/Pages/Report.aspx?ItemPath=%2fSSRSReporting%2fFront_Office_Sale");
                        NavigationService nav = NavigationService.GetNavigationService(this);
                        nav.Navigate(new Uri("View/frontoffice.xaml", UriKind.RelativeOrAbsolute));
                        //frontoffice ff = new frontoffice();
                        //nav.Navigate(ff);
                    }
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE PERMISSION TO OPEN THIS REPORT");
                }
                //CHANGEGUESTINFO
                int changeguestinfo = int.Parse(D.Rows[0]["CHANGE_GUESTINFO"].ToString());
                if (changeguestinfo == 1)
                {
                    if (Reports.Text == "Change Guest Info")
                    {
                        (ssrsreport.Child as System.Windows.Forms.WebBrowser).Navigate("http://velsol/Reports/Pages/Report.aspx?ItemPath=%2fSSRSReporting%2fCHANGE_GUEST_INFO");
                    }
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE PERMISSION TO OPEN THIS REPORT");
                }
                //ROOMCHANGE
                int roomchange = int.Parse(D.Rows[0]["ROOM_CHANGE"].ToString());
                if (roomchange == 1)
                {
                    if (Reports.Text == "Room Change Report")
                    {
                        (ssrsreport.Child as System.Windows.Forms.WebBrowser).Navigate("http://velsol/Reports/Pages/Report.aspx?ItemPath=%2fSSRSReporting%2fRoomChangeReport");
                    }
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE PERMISSION TO OPEN THIS REPORT");
                }
                //OUTSTANDING BALANCE
                int outstanding = int.Parse(D.Rows[0]["OUTSTANDING_BALANCE"].ToString());
                if (outstanding == 1)
                {
                    if (Reports.Text == "Out Standing Balance")
                    {
                        (ssrsreport.Child as System.Windows.Forms.WebBrowser).Navigate("http://velsol/Reports/Pages/Report.aspx?ItemPath=%2fSSRSReporting%2fOUTSTANDING+BALANCE");
                    }
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE PERMISSION TO OPEN THIS REPORT");
                }
                //MONTHWISEROOMTARRIF
                int monthwiseroomtariff = int.Parse(D.Rows[0]["MONTHWISE_ROOMTARIFF"].ToString());
                if (monthwiseroomtariff == 1)
                {
                    if (Reports.Text == "Month Wise Room Tariff")
                    {
                        (ssrsreport.Child as System.Windows.Forms.WebBrowser).Navigate("http://velsol/Reports/Pages/Report.aspx?ItemPath=%2fSSRSReporting%2fMonthWiseRoomTarrif");
                    }
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE PERMISSION TO OPEN THIS REPORT");
                }
                //PENDINGBILL
                int pendingbillreport = int.Parse(D.Rows[0]["PENDINGBILL"].ToString());
                if (pendingbillreport == 1)
                {
                    if (Reports.Text == "Pending Bill Report")
                    {
                        //(ssrsreport.Child as System.Windows.Forms.WebBrowser).Navigate("http://velsol/Reports/Pages/Report.aspx?ItemPath=%2fSSRSReporting%2fPending_Bill_Report");
                        NavigationService nav = NavigationService.GetNavigationService(this);
                        nav.Navigate(new Uri("View/Pendingbillreport.xaml", UriKind.RelativeOrAbsolute));
                    }
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE PERMISSION TO OPEN THIS REPORT");
                }
            }
        }
    }
}
