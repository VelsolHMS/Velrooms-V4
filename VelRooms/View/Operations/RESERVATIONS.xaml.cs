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
using HMS.Model;
using HMS.ViewModel;
using System.Data;
using HMS.View.Masters;
using HMS.mainwindowpages;
using System.Web;
using System.Net;
using System.IO;
using System.Globalization;
using System.ComponentModel;

namespace HMS.View.Operations
{
    /// <summary>
    /// Interaction logic for RESERVATIONS.xaml
    /// </summary>
    public partial class RESERVATIONS : Page
    {
        RESERVATION RE = new RESERVATION();
        advance1 A = new advance1();
        Refund rf = new Refund();
        data daa = new data();
        Hotelinfo hotelinfo = new Hotelinfo();
        REFUND r = new REFUND();
        public DateTime dt22;
        public DateTime dt11;
        public DataTable datatable;
        public DataTable datatable1;
        public int abc = 2, error = 0, reservationid;
        public string advres, selectedid = null, button;
        public static string x;
        public static string y;
        public static string z;
        public static int ResRef = 0;
        public int ad;
        public int ch;
        public int p;
        public RESERVATIONS()
        {
            data.COUNT = 0;
            InitializeComponent();
            data.COUNT = 1;
            reports.a = 2;
            txtcountycode.Text = "INR";
            //DataTable DT = RE.fill_grid();
            datatable = RE.Grid();
            dgres.ItemsSource = datatable.DefaultView;
            datatable1 = RE.Grid1();
            dtbooking.ItemsSource = datatable1.DefaultView;
            DataTable d = RE.GETNAME();
            DataRow row = d.NewRow();
            row["ROOM_CATEGORY"] = "Select Room Type";
            d.Rows.InsertAt(row, 0);
            cbroomtype.ItemsSource = d.DefaultView;
            DataTable comp = RE.GET1();
            txtcompany.ItemsSource = comp.DefaultView;
            DataTable s = RE.state();
            DataRow rs = s.NewRow();
            rs["STATE"] = "Select State";
            s.Rows.InsertAt(rs, 0);
            txtstate.ItemsSource = s.DefaultView;
            int id = RE.get_reservation_id();
            aa.Text = Convert.ToString(id);

            save.Content = "Save";
            advres = Convert.ToString(save.Content);
            txtsearch.IsEnabled = true;
            popup1.IsEnabled = false;
            Cancel.IsEnabled = false;

            //ICollectionView dataView = CollectionViewSource.GetDefaultView(dgres.ItemsSource);
            //dataView.SortDescriptions.Clear();
            //dataView.SortDescriptions.Add(new SortDescription("ARRIVAL_DATE", ListSortDirection.Descending));
            //dataView.Refresh();    
        }
        private void SAVE_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                A.RESERVATION_NO = txtreservation.Text;
                A.GUEST_NAME = txtguestname.Text;
                A.COMPANY = txtcompanyname.Text;
                A.CONTACT_NO = txtcontactno.Text;
                A.AMOUNT_RECEIVED = txtamountrecivd.Text;
                A.PAYMENT_MODE = cbpaymnt.Text;
                A.PARTICULARS = txtparticulars.Text;
                A.CURRENCY_CODE = txtcountycode.Text;
                A.ONLINE_PAYMENT = cbonline.Text;
                A.TRANSACTION_NO = txttransactionno.Text;
                A.CHEQUE_NO = txtcheque.Text;
                A.RECEIPT_NO = lblreceiptno.Content.ToString();
                A.Insert();
                popup.IsOpen = false;
                RE.RESERVATIONID = aa.Text;
                RE.FIRSTNAME = txtfirstname.Text;
                RE.LASTNAME = txtlastname.Text;
                RE.NOOFROOMS = txtrooms.Text;
                RE.PAXS = txtpaxs.Text;
                RE.ADULTS = txtadult.Text;
                RE.CHILDS = txtchild.Text;
                DateTime todaysDate = Convert.ToDateTime(dt.Text);
                string s = String.Format("{0:yyyy/MM/dd}", todaysDate);
                RE.ARRIVALDATE = Convert.ToDateTime(s.ToString());
                RE.ARRIVAL_TIME = Checkintime.Text;
                DateTime today = Convert.ToDateTime(dt1.Text);
                string s1 = String.Format("{0:yyyy/MM/dd}", today);
                RE.DEPARTUREDATE = Convert.ToDateTime(s1.ToString());
                RE.DEPARTURE_TIME = Checkintime.Text;
                RE.DAYS = txtdays.Text;
                RE.ROOM_CATEGORY = cbroomtype.Text;
                RE.GUESTSTATUS = cbguest.Text;
                RE.COMPANY = txtcompany.Text;
                RE.NATIONALITY = cbnationality.Text;
                RE.COMPANYADDRESS = txtrichtextbox.Text;
                RE.DOORNO = txtdoorno.Text;
                RE.CITY = txtcity.Text;
                RE.STATE = txtstate.Text;
                RE.COUNTRY = cbcountry.Text;
                RE.ZIP = txtzip.Text;
                RE.MOBILE_NO = txtmobileno.Text;
                RE.EMAILID = txtemail.Text;
                //RE.IDPROOF = txtidproof.Text;
                //RE.IDPROOF1 = txtidproof1.Text;
                RE.SPECIALINSTRUCTION = txtsplinstruction.Text;
                RE.STATUS = "ACTIVE";
                // ddff  sri11/15/2017
                //RE.USER_NAME = login.u;
                RE.INSERT_BY = login.u;
                RE.INSERT_DATE = DateTime.Today;
                string a = "Save"; string b = Convert.ToString(save.Content);
                if (a == b)
                {
                    RE.INSERT();
                    DataTable dtt = RE.Grid();
                    dgres.ItemsSource = dtt.DefaultView;
                    //clear();
                    this.NavigationService.Refresh();
                    MessageBox.Show("Saved Successfully");

                }
                else
                {
                    RE.UPDATE1();
                    DataTable dt1 = RE.Grid();
                    dgres.ItemsSource = dt1.DefaultView;
                    //clear();
                    this.NavigationService.Refresh();
                    MessageBox.Show("Updated Successfully");

                    save.Content = "Save";
                }
                RE.R();
                RE.A();
                Send_SMS();
                //     popup.IsOpen = false;
                //A.RESERVATION_NO = aa.Text;
                //A.PAYMENT_MODE = cbpaymnt.Text;
                //A.CURRENCY_CODE = txtcountycode.Text;
                //A.AMOUNT_RECEIVED = txtamountrecivd.Text;
                //A.ONLINE_PAYMENT = cbonline.Text;
                //A.PARTICULARS = txtparticulars.Text;
                //A.TRANSACTION_NO = txttransactionno.Text;
                //A.Insert();
                //RE.A();

                //DataTable d = report();
                //RESERVATION.dt = d;

                //*************For Report*****************
                //ReportDocument rr = new ReportDocument();
                //rr.Load("../../Reservationreceipt.rpt");
                //RESERVATION rev = new RESERVATION(); 
                //DataTable hotel1 = rev.GET_HOTELADDRESS();
                //rr.Subreports[0].SetDataSource(hotel1);
                //rr.SetDataSource(RESERVATION.dt);    
                //rr.PrintToPrinter(1, false, 0, 0);

                clear();
                save.IsEnabled = true;
                Clear.IsEnabled = true;
                //     modify.IsEnabled = true;
                Cancel.IsEnabled = true;
                //this.NavigationService.Refresh();
                //NavigationService nav = NavigationService.GetNavigationService(this);
                //nav.Refresh();
            }
            catch (Exception) { }
        }
        private void YES_Click_1(object sender, RoutedEventArgs e)
        {
            popreservation.IsOpen = false;
            popup.IsOpen = true;
            txtguestname.Text = txtfirstname.Text;
            txtcontactno.Text = txtmobileno.Text;
            txtcompanyname.Text = txtcompany.Text;
        }
        private void NO_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                popreservation.IsOpen = false;
                //  RE.SEARCH = txtsearch.Text;
                RE.RESERVATIONID = aa.Text;
                RE.FIRSTNAME = txtfirstname.Text;
                RE.LASTNAME = txtlastname.Text;
                RE.NOOFROOMS = txtrooms.Text;
                RE.PAXS = txtpaxs.Text;
                RE.ADULTS = txtadult.Text;
                RE.CHILDS = txtchild.Text;
                DateTime todaysDate = Convert.ToDateTime(dt.Text).Date;
                string s = String.Format("{0:yyyy/MM/dd}", todaysDate);
                RE.ARRIVALDATE = Convert.ToDateTime(s.ToString());
                RE.ARRIVAL_TIME = Checkintime.Text;
                DateTime today = Convert.ToDateTime(dt1.Text).Date;
                string s1 = String.Format("{0:yyyy/MM/dd}", today);
                RE.DEPARTUREDATE = Convert.ToDateTime(s1.ToString());
                RE.DEPARTURE_TIME = Checkintime.Text;
                RE.DAYS = txtdays.Text;
                RE.ROOM_CATEGORY = cbroomtype.Text;
                RE.GUESTSTATUS = cbguest.Text;
                RE.COMPANY = txtcompany.Text;
                RE.NATIONALITY = cbnationality.Text;
                RE.COMPANYADDRESS = txtrichtextbox.Text;
                RE.DOORNO = txtdoorno.Text;
                RE.CITY = txtcity.Text;
                RE.STATE = txtstate.Text;
                RE.COUNTRY = cbcountry.Text;
                RE.ZIP = txtzip.Text;
                RE.MOBILE_NO = txtmobileno.Text;
                RE.EMAILID = txtemail.Text;
                //RE.IDPROOF = txtidproof.Text;
                //RE.IDPROOF1 = txtidproof1.Text;
                RE.SPECIALINSTRUCTION = txtsplinstruction.Text;
                RE.STATUS = "ACTIVE";
                // ddff  sri11/15/2017
                //RE.USER_NAME = login.u;
                RE.INSERT_BY = login.u;
                RE.INSERT_DATE = DateTime.Today;
                string a = "Save"; string b = Convert.ToString(save.Content);
                if (a == b)
                {
                    RE.INSERT();
                    DataTable dtt = RE.Grid();
                    dgres.ItemsSource = dtt.DefaultView;
                    MessageBox.Show("Saved Successfully");
                    //clear();
                    this.NavigationService.Refresh();
                }
                else
                {
                    RE.UPDATE1();
                    DataTable dt1 = RE.Grid();
                    dgres.ItemsSource = dt1.DefaultView;
                    MessageBox.Show("Updated Successfully");
                    //clear();
                    this.NavigationService.Refresh();
                    //  save.Content = "Save";
                }
                //  RE.INSERT();
                RE.R();
                // RE.A();
                popup.IsOpen = false;

                A.RESERVATION_NO = aa.Text;
                A.PAYMENT_MODE = cbpaymnt.Text;
                A.CURRENCY_CODE = txtcountycode.Text;
                A.AMOUNT_RECEIVED = txtamountrecivd.Text;
                A.ONLINE_PAYMENT = cbonline.Text;
                A.PARTICULARS = txtparticulars.Text;
                A.TRANSACTION_NO = txttransactionno.Text;
                A.Insert();
                RE.A();
                Send_SMS();
                //DataTable d = report();
                //RESERVATION.dt = d;

                //*************For Report*****************
                //ReportDocument rr = new ReportDocument();
                //rr.Load("../../Reservationreceipt.rpt");
                //RESERVATION rev = new RESERVATION();
                //DataTable hotel1 = rev.GET_HOTELADDRESS();
                //rr.Subreports[0].SetDataSource(hotel1);
                //rr.SetDataSource(RESERVATION.dt);
                //rr.PrintToPrinter(1, false, 0, 0);
                clear();
                this.NavigationService.Refresh();
                save.IsEnabled = true;
                Clear.IsEnabled = true;
                //Show.IsEnabled = true;
                //Enquiry.IsEnabled = false;
                //  modify.IsEnabled = true;
                Cancel.IsEnabled = true;
            }
            catch (Exception) { }
        }
        public void Send_SMS()
        {
            DataTable landline = hotelinfo.getLandLinenumber();
            String ll_number = landline.Rows[0]["LANDLINE1"].ToString();
            string no = "9848082999";
            String username = "9494433233";
            String password = "33233";
            String mobileNumber = "91" + txtmobileno.Text;
            String customer = "Hi We Confirm your Reservation as follows : Arrival : "+dt.Text+"\nDeparture : "+dt1.Text+"\nRoom Type : "+cbroomtype.Text+"\nThankyou Very Much \nFor Assistance Call : "+ll_number+","+no+"";
            String url = "http://sms.zestwings.com/smpp.sms?username=" + username + "&password=" + password + "&to=" + mobileNumber + "&from=VELSOL&text=" + customer + "";

            try
            {
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(url);

                //Prepare and Add URL Encoded data
                UTF8Encoding encoding = new UTF8Encoding();
                httpWReq.Method = "GET";
                httpWReq.ContentType = "application/x-www-form-urlencoded";

                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string responseString = reader.ReadToEnd();

                //Close the response
                reader.Close();
                response.Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            //     popup.IsOpen = false;
        }
        //public DataTable report()
        //{
        //    DataTable advrec = new DataTable();

        //    advrec.Columns.Add("Reservation No :", typeof(Int64));
        //    advrec.Columns.Add("Date :", typeof(DateTime));
        //    advrec.Columns.Add("Guest Name :", typeof(string));
        //    advrec.Columns.Add("Guest Contact :", typeof(Int64));
        //    advrec.Columns.Add("Company Name :", typeof(string));
        //    advrec.Columns.Add("Company Contact :", typeof(Int64));
        //    advrec.Columns.Add("Arrival Date :", typeof(DateTime));
        //    advrec.Columns.Add("Arrival Time :", typeof(DateTime));
        //    advrec.Columns.Add("Departure Date :", typeof(DateTime));
        //    advrec.Columns.Add("Departure Time :", typeof(DateTime));
        //    advrec.Columns.Add("Pax :", typeof(Int16));
        //    advrec.Columns.Add("Adult :", typeof(Int16));
        //    advrec.Columns.Add("Child :", typeof(Int16));
        //    advrec.Columns.Add("No Of Days :", typeof(Int16));
        //    advrec.Columns.Add("Room Category :", typeof(string));
        //    advrec.Columns.Add("No Of Rooms :", typeof(Int16));
        //    advrec.Columns.Add("Advance :", typeof(decimal));
        //    advrec.Columns.Add("Payment Mode :", typeof(string));
        //    advrec.Columns.Add("Transaction Number :", typeof(string));
        //    advrec.Columns.Add("Cheque Number :", typeof(string));
        //    advrec.Columns.Add("User Name :", typeof(string));

        //    DataRow row = advrec.NewRow();

        //    row["Reservation No :"] = Convert.ToInt64(aa.Text);
        //    row["Date :"] = DateTime.Now;
        //    row["Guest Name :"] = txtfirstname.Text;
        //    row["Guest Contact :"] = txtcontactno.Text;
        //    row["Company Name :"] = txtcompanyname.Text;
        //    row["Company Contact :"] = txtcontactno.Text;
        //    row["Arrival Date :"] = dt.Text;
        //    row["Arrival Time :"] = DateTime.Now.ToShortTimeString();
        //    row["Departure Date :"] = dt1.Text;
        //    row["Departure Time :"] = DateTime.Now.ToShortTimeString();
        //    row["Pax :"] = txtpaxs.Text;
        //    row["Adult :"] = txtadult.Text;
        //    if (txtchild.Text == "")
        //    {
        //        row["Child :"] = 0;
        //    }
        //    else
        //    {
        //        row["Child :"] = txtchild.Text;
        //    }
        //    row["No Of Days :"] = txtdays.Text;
        //    row["Room Category :"] = cbroomtype.Text;
        //    row["No Of Rooms :"] = txtrooms.Text;
        //    if (txtamountrecivd.Text == "")
        //    {
        //        row["Advance :"] = 0.00;
        //    }
        //    else
        //    {
        //        row["Advance :"] = txtamountrecivd.Text;
        //    }
        //    row["Payment Mode :"] = cbpaymnt.Text;
        //    row["Transaction Number :"] = txttransactionno.Text;
        //    row["Cheque Number :"] = txtcheque.Text;
        //    row["User Name :"] = login.u;

        //    advrec.Rows.Add(row);
        //    return advrec;

        //}

        public void clear()
        {
            txtamountrecivd.Text = "";
            txtparticulars.Text = "";
            txttransactionno.Text = "";
            txtsearch.Text = "";
            txtfirstname.Text = "";
            txtlastname.Text = "";
            txtrooms.Text = "";
            txtpaxs.Text = "";
            txtadult.Text = "";
            txtchild.Text = "";
            dt.Text = "";
            dt1.Text = "";
            txtcompany.Text = "";
            txtrichtextbox.Text = "";
            txtdoorno.Text = "";
            txtcity.Text = "";
            cbroomtype.SelectedIndex = 0;
            txtzip.Text = "";
            txtmobileno.Text = "";
            //txtidproof.SelectedIndex = 0;
            //txtidproof1.Text = "";
            txtemail.Text = "";
            txtsplinstruction.Text = "";
        }

        ////////////////////////reservation id with serch///////////////
        private void aa_LostFocus(object sender, RoutedEventArgs e)
        {

            //RE.RESERVATIONID = selectedid;
            //RE.UPDATE();
            ////aa.Text = RE.RESERVATIONID; 
            //txtfirstname.Text = RE.FIRSTNAME;
            //txtlastname.Text = RE.LASTNAME;
            //txtrooms.Text = RE.NOOFROOMS;
            //txtpaxs.Text = RE.PAXS;
            //txtadult.Text = RE.ADULTS;
            //txtchild.Text = RE.CHILDS;
            //dt.Text = Convert.ToDateTime(RE.ARRIVALDATE).ToString();
            //dt1.Text = Convert.ToDateTime(RE.DEPARTUREDATE).ToString();
            //txtdays.Text = RE.DAYS;
            //cbroomtype.Text = RE.ROOM_CATEGORY;
            //cbguest.Text = RE.GUESTSTATUS;
            //txtcompany.Text = RE.COMPANY;
            //cbnationality.Text = RE.NATIONALITY;
            //txtrichtextbox.Text = RE.COMPANYADDRESS;
            //txtdoorno.Text = RE.DOORNO;
            //txtcity.Text = RE.CITY;
            //txtstate.Text = RE.STATE;
            //cbcountry.Text = RE.COUNTRY;
            //txtzip.Text = RE.ZIP;
            //txtmobileno.Text = RE.MOBILE_NO;
            //txtidproof.Text = RE.IDPROOF;
            //txtidproof1.Text = RE.IDPROOF1;
            //txtsplinstruction.Text = RE.SPECIALINSTRUCTION;
            //txtemail.Text = RE.EMAILID;
        }
        ////////////////search with mobileno////////////////////////////
        private void txtsearch_LostFocus(object sender, RoutedEventArgs e)
        {
            z = txtsearch.Text;
            try
            {
                if (txtsearch.Text == "")
                {
                    clear();
                    this.NavigationService.Refresh();
                }
                else
                {
                    DataTable dtm = RE.MobileNo();
                    if (dtm.Rows.Count == 0)
                    {
                        MessageBox.Show("Please Enter Valid Mobile Number");
                    }
                    else
                    {
                        save.Content = "Update";
                        RE.MOBILE_NO = txtsearch.Text;
                        RE.UPDATE();
                        aa.Text = RE.RESERVATIONID;
                        txtfirstname.Text = RE.FIRSTNAME;
                        txtlastname.Text = RE.LASTNAME;
                        txtrooms.Text = RE.NOOFROOMS;
                        txtpaxs.Text = RE.PAXS;
                        txtadult.Text = RE.ADULTS;
                        txtchild.Text = RE.CHILDS;
                        //Checkintime.Text = RE.ARRIVAL_TIME;
                        dt.Text = Convert.ToDateTime(RE.ARRIVALDATE).ToString();
                        dt1.Text = Convert.ToDateTime(RE.DEPARTUREDATE).ToString();
                        txtdays.Text = RE.DAYS;
                        cbroomtype.Text = RE.ROOM_CATEGORY;
                        cbguest.Text = RE.GUESTSTATUS;
                        txtcompany.Text = RE.COMPANY;
                        cbnationality.Text = RE.NATIONALITY;
                        txtrichtextbox.Text = RE.COMPANYADDRESS;
                        txtdoorno.Text = RE.DOORNO;
                        txtcity.Text = RE.CITY;
                        txtstate.Text = RE.STATE;
                        cbcountry.Text = RE.COUNTRY;
                        txtzip.Text = RE.ZIP;
                        txtmobileno.Text = RE.MOBILE_NO;
                        //txtidproof.Text = RE.IDPROOF;
                        //txtidproof1.Text = RE.IDPROOF1;
                        txtsplinstruction.Text = RE.SPECIALINSTRUCTION;
                        txtemail.Text = RE.EMAILID;
                    }
                }
            }
            catch (SystemException)
            {
               // MessageBox.Show(ex.Message.ToString());
            }
        }
        private void dt1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dt1.SelectedDate < DateTime.Today.Date)
                {
                    MessageBox.Show("Departure Date cannot be less than the Arrival Date");
                    dt1.Text = "";
                }
                else if (!(dt1.Text == ""))
                {
                    //dt1.Text = Convert.ToString(DateTime.Today.Date);
                    dt11 = DateTime.Parse(dt.Text.Trim());
                    dt22 = DateTime.Parse(dt1.Text.Trim());
                    TimeSpan ts = dt22.Subtract(dt11);
                    int noofdays = ts.Days;
                    txtdays.Text = noofdays.ToString();
                }
            }
            catch (Exception) { }
        }
        private void txtcompany_DropDownClosed_1(object sender, EventArgs e)
        {
            companymaster rr = new companymaster();
            rr.COMPANY_NAME = txtcompany.Text;
            rr.get();
            txtrichtextbox.Text = rr.CITY;// rr.PLOT_NO + "," + rr.LANDMARK + "\n" + rr.CITY; // + "-" + rr.PINCODE + "\n" + rr.STATE + "\n" + rr.COUNTRY + "\n" + rr.EMAIL + "\n" + rr.CONTACT;
        }
        private void cbroomtype_DropDownClosed(object sender, EventArgs e)
        {
            Roommaster rr = new Roommaster();
            rr.ROOM_CATEGORY = cbroomtype.Text;
            rr.room();
            TXTROOMTYPE.Text = rr.ROOM_CATEGORY;
            TXTSINGLEBED.Text = Convert.ToDecimal(rr.SINGLERATE_TARRIF).ToString();
            TXTDOULE.Text = Convert.ToDecimal(rr.DOUBLERATE_TARRIF).ToString();
            TXTTRIPLE.Text = Convert.ToDecimal(rr.TRIPLERATE_TARRIF).ToString();
            TXTQUARD.Text = Convert.ToDecimal(rr.QUADRATE_TARRIF).ToString();
            TXTADULT.Text = Convert.ToDecimal(rr.ADULT_EXTRABADCOST).ToString();
            TXTCHILD.Text = Convert.ToDecimal(rr.CHILD_EXTRABEDCOST).ToString();
        }
        //////////////////////////////////advance popup/////////////////////////////////////////////////////////////////////
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                error++;
            else
                error--;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pop1.IsOpen = false;
        }
        //private void save_Click(object sender, RoutedEventArgs e)
        //{
        //    if (error != 0 || txtfirstname.Text == "" || txtlastname.Text == "" || txtmobileno.Text == "" || txtcity.Text == "" || txtzip.Text == "" || txtrooms.Text == "" || txtpaxs.Text == "" || txtadult.Text == "" || txtchild.Text == "")
        //    {
        //        if (txtfirstname.Text == "")
        //            txtfirstname.Text = "";
        //        if (txtlastname.Text == "")
        //            txtlastname.Text = "";
        //        if (txtmobileno.Text == "")
        //            txtmobileno.Text = "";
        //        if (txtcity.Text == "")
        //            txtcity.Text = "";
        //        if (txtzip.Text == "")
        //            txtzip.Text = "";
        //        if (txtrooms.Text == "")
        //            txtrooms.Text = "";
        //        if (txtpaxs.Text == "")
        //            txtpaxs.Text = "";
        //        if (txtadult.Text == "")
        //            txtadult.Text = "";
        //        if (txtchild.Text == "")
        //            txtchild.Text = "";
        //    }
        //    else
        //    {
        //        popreservation.IsOpen = true;
        //        //string a = "Save"; string b = Convert.ToString(save.Content);
        //if (a == b)
        //{
        //    RE.INSERT();
        //    DataTable dtt = RE.fill_grid();
        //    dgres.ItemsSource = dtt.DefaultView;
        //    clear();
        //    MessageBox.Show("Saved Successfully");
        //    this.NavigationService.Refresh();
        //}
        //else
        //{
        //    RE.UPDATE();
        //    DataTable dt1 = RE.fill_grid();
        //    dgres.ItemsSource = dt1.DefaultView;
        //    clear();
        //    MessageBox.Show("Updated Successfully");
        //    this.NavigationService.Refresh();
        //    save.Content = "Save";
        //}
        //     }

        //if (error != 0)
        //{
        //    pop1.IsOpen = true;
        //}
        //else
        //{
        //    RE.RESERVATIONID = aa.Text;
        //    RE.advanceamnt();
        //    if (advres == "Cancel")
        //    {
        //        cancelpop.IsOpen = true;
        //    }
        //    else if (advres == "Update")
        //    {
        //        popup.IsOpen = false;
        //        RE.FIRSTNAME = txtfirstname.Text;
        //        RE.LASTNAME = txtlastname.Text;
        //        RE.NOOFROOMS = txtrooms.Text;
        //        RE.PAXS = txtpaxs.Text;
        //        RE.ADULTS = txtadult.Text;
        //        RE.CHILDS = txtchild.Text;
        //        RE.ARRIVALDATE = Convert.ToDateTime(dt.Text);
        //        RE.DEPARTUREDATE = Convert.ToDateTime(dt1.Text);
        //        RE.DAYS = txtdays.Text;
        //        RE.ROOM_CATEGORY = cbroomtype.Text;
        //        RE.GUESTSTATUS = cbguest.Text;
        //        RE.COMPANY = txtcompany.Text;
        //        RE.NATIONALITY = cbnationality.Text;
        //        RE.COMPANYADDRESS = txtrichtextbox.Text;
        //        RE.DOORNO = txtdoorno.Text;
        //        RE.CITY = txtcity.Text;
        //        RE.STATE = txtstate.Text;
        //        RE.COUNTRY = cbcountry.Text;
        //        RE.ZIP = txtzip.Text;
        //        RE.MOBILE_NO = txtmobileno.Text;
        //        RE.EMAILID = txtemail.Text;
        //        RE.IDPROOF = txtidproof.Text;
        //        RE.IDPROOF1 = txtidproof1.Text;
        //        RE.SPECIALINSTRUCTION = txtsplinstruction.Text;
        //        RE.STATUS = "ACTIVE";
        //        // ddff  sri11/15/2017
        //        //RE.USER_NAME = login.u;
        //        RE.INSERT_BY = login.u;
        //        RE.INSERT_DATE = DateTime.Today;

        //        RE.INSERT();
        //        MessageBox.Show("inserted sucessfully");
        //        clear();

        //        save.IsEnabled = true;
        //        Clear.IsEnabled = true;
        //        //Show.IsEnabled = true;
        //        //Enquiry.IsEnabled = false;
        //        modify.IsEnabled = true;
        //       // ADD.IsEnabled = true;
        //        Cancel.IsEnabled = true;

        //        save.Content = "Save";
        //    }
        //    else if (advres == "Save")
        //    {
        //        RE.COMPANY = txtcompany.Text;
        //        RE.Company_contact();
        //        txtcontactno.Text = RE.COMPANY_CONTACT;
        //        popup.IsOpen = true;

        //    }
        //   }
        //clear();
        // txtroom.IsEnabled = false;
        // txtguestname.IsEnabled = false;
        // txtreservation.IsEnabled = false;
        // txtcompanyname.IsEnabled = false;
        // txtcontactno.IsEnabled = false;
        // cbpaymnt.IsEnabled = false;
        // txtcountycode.IsEnabled = false;
        // txtamountrecivd.IsEnabled = false;
        // cbonline.IsEnabled = false;
        // txtparticulars.IsEnabled = false;
        // txttransactionno.IsEnabled = false;
        // txtcheque.IsEnabled = false;

        //  }
        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            //txtreservation.IsEnabled = true;
            txtguestname.IsEnabled = true;
            txtcompanyname.IsEnabled = true;
            txtcontactno.IsEnabled = true;
            cbpaymnt.IsEnabled = true;
            txtcountycode.IsEnabled = true;
            txtamountrecivd.IsEnabled = true;
            txtparticulars.IsEnabled = true;
        }
        private void cbpaymnt_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (cbpaymnt.Text == "Cash")
                {
                    cbonline.IsEnabled = false;
                    txttransactionno.IsEnabled = false;
                    txtcheque.IsEnabled = false;
                }
                else if (cbpaymnt.Text == "Card")
                {
                    cbonline.IsEnabled = false;
                    txttransactionno.IsEnabled = true;
                    txtcheque.IsEnabled = false;
                }
                else if (cbpaymnt.Text == "Cheque")
                {
                    cbonline.IsEnabled = false;
                    txttransactionno.IsEnabled = false;
                    txtcheque.IsEnabled = true;
                }
                else if (cbpaymnt.Text == "Online Payments")
                {
                    cbonline.IsEnabled = true;
                    txttransactionno.IsEnabled = true;
                    txtcheque.IsEnabled = false;
                }
            }
            catch (Exception) { }
        }
        //////////////////////////////////////Enquiry popup///////////////////////////////////////////////////////////////////////////////
        private void Enquiry_Click(object sender, RoutedEventArgs e)
        {
            //Enquiry popup
            txtguestname1.IsEnabled = false;
            txtcompanynamename1.IsEnabled = false;
            txtreservationid.IsEnabled = false;
            txtmobilenumber.IsEnabled = false;
            dt2.IsEnabled = false;
            popup1.IsOpen = true;
            Cancel.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
        }
        private void rd_Checked(object sender, RoutedEventArgs e)
        {
            txtguestname1.IsEnabled = true;
            txtcompanynamename1.IsEnabled = false;
            txtreservationid.IsEnabled = false;
            txtmobilenumber.IsEnabled = false;
            dt2.IsEnabled = false;
            txtcompanynamename1.Text = "";
            txtreservationid.Text = "";
            txtmobilenumber.Text = "";
            dt2.Text = "";
           // x = txtguestname1.Text;
        }
        private void txtguestname1_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                RE.FIRSTNAME = txtguestname1.Text;
                DataTable D = RE.ID1();
                if (D.Rows.Count == 0)
                {
                    cancelpopup.IsOpen = true;
                }
                else
                {
                    dg.ItemsSource = D.DefaultView;
                }
            }
            catch (Exception) { }
        }
        private void rd1_Checked(object sender, RoutedEventArgs e)
        {
            txtguestname1.IsEnabled = false;
            txtcompanynamename1.IsEnabled = true;
            txtreservationid.IsEnabled = false;
            txtmobilenumber.IsEnabled = false;
            dt2.IsEnabled = false;
            txtguestname1.Text = "";
            txtreservationid.Text = "";
            txtmobilenumber.Text = "";
            dt2.Text = "";
        //    x = txtcompanynamename1.Text;
        }
        private void txtcompanynamename1_LostFocus(object sender, RoutedEventArgs e)
        {
            RE.COMPANY = txtcompanynamename1.Text;
            DataTable DE = RE.COMPAY();
            if (DE.Rows.Count == 0)
            {
                cancelpopup.IsOpen = true;
            }
            else
            {
                dg.ItemsSource = DE.DefaultView;
            }
        }
        private void rd2_Checked(object sender, RoutedEventArgs e)
        {
            txtguestname1.IsEnabled = false;
            txtcompanynamename1.IsEnabled = false;
            txtreservationid.IsEnabled = true;
            txtmobilenumber.IsEnabled = false;
            dt2.IsEnabled = false;
            txtguestname1.Text = "";
            txtcompanynamename1.Text = "";
            txtmobilenumber.Text = "";
            dt2.Text = "";
            x = txtreservationid.Text;
        }
        private void txtreservationid_LostFocus(object sender, RoutedEventArgs e)
        {
            RE.RESERVATIONID = txtreservationid.Text;
            DataTable DD = RE.ID();
            if (DD.Rows.Count == 0)
            {
                cancelpopup.IsOpen = true;
            }
            else
            {
                dg.ItemsSource = DD.DefaultView;
            }
        }
        private void rd3_Checked(object sender, RoutedEventArgs e)
        {
            txtguestname1.IsEnabled = false;
            txtcompanynamename1.IsEnabled = false;
            txtreservationid.IsEnabled = false;
            txtmobilenumber.IsEnabled = true;
            dt2.IsEnabled = false;
            txtguestname1.Text = "";
            txtcompanynamename1.Text = "";
            txtreservationid.Text = "";
            dt2.Text = "";
         //   x = txtmobilenumber.Text;
        }
        private void txtmobilenumber_LostFocus(object sender, RoutedEventArgs e)
        {
            RE.MOBILE_NO = txtmobilenumber.Text;
            DataTable dd = RE.G();
            if (dd.Rows.Count == 0)
            {
                cancelpopup.IsOpen = true;
            }
            else
            {
                dg.ItemsSource = dd.DefaultView;
            }
        }
        private void rd4_Checked(object sender, RoutedEventArgs e)
        {
            txtguestname1.IsEnabled = false;
            txtcompanynamename1.IsEnabled = false;
            txtreservationid.IsEnabled = false;
            txtmobilenumber.IsEnabled = false;
            dt2.IsEnabled = true;
            txtguestname1.Text = "";
            txtcompanynamename1.Text = "";
            txtreservationid.Text = "";
            txtmobilenumber.Text = "";
            //x = dt2.Text;
        }
        private void btnroomtarrif_Click(object sender, RoutedEventArgs e)
        {
            popup2.IsOpen = true;
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                save.IsEnabled = true;
                Clear.IsEnabled = true;
                Cancel.IsEnabled = true;
                // popup1.IsOpen = true;
                cancel.IsOpen = true;
                advres = "Cancel";
                txtguestname1.IsEnabled = false;
                txtcompanynamename1.IsEnabled = false;
                txtreservationid.IsEnabled = false;
                txtmobilenumber.IsEnabled = false;
                dt2.IsEnabled = false;
                Cancel.Background = new SolidColorBrush(Colors.Orange);
            }
            catch (Exception) { }
        }
        private void dt_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dt.SelectedDate < DateTime.Today.Date)
            {
                MessageBox.Show("Arrival Date cannot be less than the current date");
                dt.Text = "";
            }
            else if (dt.SelectedDate == DateTime.Today.Date)
            {
                dt.Text = Convert.ToString(DateTime.Today.Date);
            }
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            clear();
            this.NavigationService.Refresh();
            Cancel.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
        }
        private void txtcompany_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //if(e.Key == Key.Down)
            //{
            //    companymaster rr = new companymaster();
            //    rr.COMPANY_NAME = txtcompany.Text;
            //    DataTable cr = rr.get();
            //    txtrichtextbox.Text = cr.Rows[0]["PLOT_NO"] + "," + cr.Rows[0]["LANDMARK"] + "\n" + cr.Rows[0]["CITY"] + "-" + cr.Rows[0]["PINCODE"] + "\n" + cr.Rows[0]["STATE"] + "\n" + cr.Rows[0]["COUNTRY"] + "\n" + cr.Rows[0]["EMAIL"] + "\n" + cr.Rows[0]["MOBILE_NO"];
            //}
        }
        private void txtcompany_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.SystemKey == Key.Down)
            {
                companymaster rr = new companymaster();
                rr.COMPANY_NAME = txtcompany.Text;
                rr.get();
                txtrichtextbox.Text = rr.CITY;// rr.PLOT_NO + "," + rr.LANDMARK + "\n" + rr.CITY + "-" + rr.PINCODE + "\n" + rr.STATE + "\n" + rr.COUNTRY + "\n" + rr.EMAIL + "\n" + rr.CONTACT;
            }
            else if (e.SystemKey == Key.Up)
            {
                companymaster rr = new companymaster();
                rr.COMPANY_NAME = txtcompany.Text;
                rr.get();
                txtrichtextbox.Text = rr.CITY;// rr.PLOT_NO + "," + rr.LANDMARK + "\n" + rr.CITY + "-" + rr.PINCODE + "\n" + rr.STATE + "\n" + rr.COUNTRY + "\n" + rr.EMAIL + "\n" + rr.CONTACT;
            }
        }
        //private void txtidproof1_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    Binding b = new Binding();
        //    if (txtidproof.Text == "Aadhar")
        //    {
        //        b.Source = daa;
        //        daa.Addharcard = txtidproof1.Text;
        //        b.Path = new PropertyPath("Addharcard");
        //        b.NotifyOnValidationError = true;
        //        b.ValidatesOnDataErrors = true;
        //        BindingOperations.SetBinding(txtidproof1, TextBox.TextProperty, b);
        //    }
        //    else if (txtidproof.Text == "Pancard")
        //    {
        //        b.Source = daa;
        //        daa.Pancard = txtidproof1.Text;
        //        b.Path = new PropertyPath("Pancard");
        //        b.NotifyOnValidationError = true;
        //        b.ValidatesOnDataErrors = true;
        //        BindingOperations.SetBinding(txtidproof1, TextBox.TextProperty, b);
        //    }
        //    else if (txtidproof.Text == "Driving License")
        //    {
        //        b.Source = daa;
        //        daa.Driving = txtidproof1.Text;
        //        b.Path = new PropertyPath("Driving");
        //        b.NotifyOnValidationError = true;
        //        b.ValidatesOnDataErrors = true;
        //        BindingOperations.SetBinding(txtidproof1, TextBox.TextProperty, b);
        //    }
        //    else if (txtidproof.Text == "VoterId")
        //    {
        //        b.Source = daa;
        //        daa.Voterid = txtidproof1.Text;
        //        b.Path = new PropertyPath("Voterid");
        //        b.NotifyOnValidationError = true;
        //        b.ValidatesOnDataErrors = true;
        //        BindingOperations.SetBinding(txtidproof1, TextBox.TextProperty, b);
        //    }
        //    else if (txtidproof.Text == "Passport")
        //    {
        //        b.Source = daa;
        //        daa.Passport = txtidproof1.Text;
        //        b.Path = new PropertyPath("Passport");
        //        b.NotifyOnValidationError = true;
        //        b.ValidatesOnDataErrors = true;
        //        BindingOperations.SetBinding(txtidproof1, TextBox.TextProperty, b);
        //    }
        //}

        //private void txtidproof1_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (txtidproof.Text == "Aadhar")
        //    {
        //        if (txtidproof1.Text.Length == 4)
        //        {
        //            txtidproof1.Text += "-";
        //            txtidproof1.SelectionStart = txtidproof1.Text.Length + 4;
        //        }
        //        if (txtidproof1.Text.Length == 9)
        //        {
        //            txtidproof1.Text += "-";
        //            txtidproof1.SelectionStart = txtidproof1.Text.Length + 9;
        //        }
        //    }
        //}

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            popup.IsOpen = false;
            popup1.IsOpen = false;
            popup2.IsOpen = false;
            //   clear();
            //   this.NavigationService.Refresh();
        }
        private void yes_Click(object sender, RoutedEventArgs e)
        {
            Refund.receivedid = selectedid;
            Refund.a = 1;
            this.NavigationService.Navigate(rf);
        }
        private void dgres_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                save.Content = "Update";
                txtsearch.IsEnabled = false;
                int i = dgres.SelectedIndex;
                if (datatable.Rows.Count == 0)
                {
                }
                else
                {
                    if (i >= 0)
                    {
                        Cancel.IsEnabled = true;
                        aa.Text = datatable.Rows[i]["RESERVATION_ID"].ToString();
                        txtfirstname.Text = datatable.Rows[i]["FIRSTNAME"].ToString();
                        txtlastname.Text = datatable.Rows[i]["LASTNAME"].ToString();
                        txtrooms.Text = datatable.Rows[i]["NO_OF_ROOMS"].ToString();
                        txtpaxs.Text = datatable.Rows[i]["PAX"].ToString();
                        txtadult.Text = datatable.Rows[i]["ADULT"].ToString();
                        txtchild.Text = datatable.Rows[i]["CHILD"].ToString();
                        dt.Text = Convert.ToDateTime(datatable.Rows[i]["ARRIVAL_DATE"]).ToString();
                        dt1.Text = Convert.ToDateTime(datatable.Rows[i]["DEPARTURE_DATE"]).ToString();
                        txtdays.Text = datatable.Rows[i]["DAYS"].ToString();
                        cbroomtype.Text = datatable.Rows[i]["ROOM_CATEGORY"].ToString();
                        cbguest.Text = datatable.Rows[i]["GUEST_STATUS"].ToString();
                        txtcompany.Text = datatable.Rows[i]["COMPANY_NAME"].ToString();
                        cbnationality.Text = datatable.Rows[i]["NATIONALITY"].ToString();
                        txtrichtextbox.Text = datatable.Rows[i]["COMPANY_ADDRESS"].ToString();
                        txtdoorno.Text = datatable.Rows[i]["DOOR_NO"].ToString();
                        txtcity.Text = datatable.Rows[i]["CITY"].ToString();
                        txtstate.Text = datatable.Rows[i]["STATE"].ToString();
                        cbcountry.Text = datatable.Rows[i]["COUNTRY"].ToString();
                        txtzip.Text = datatable.Rows[i]["ZIP"].ToString();
                        txtmobileno.Text = datatable.Rows[i]["MOBILE_NO"].ToString();
                        //txtidproof.Text = datatable.Rows[i]["ID_TYPE"].ToString();
                        //txtidproof1.Text = datatable.Rows[i]["ID_DATA"].ToString();
                        txtsplinstruction.Text = datatable.Rows[i]["SPECIALINSTRUCTIONS"].ToString();
                        txtemail.Text = datatable.Rows[i]["EMAIL"].ToString();
                    }
                    else
                    { }
                }
            }
            catch (Exception) { }
        }
        private void save_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (error != 0 || txtfirstname.Text == "" || txtlastname.Text == "" || txtmobileno.Text == "" || txtcity.Text == "" || txtzip.Text == "" || txtrooms.Text == "" || txtpaxs.Text == "" || txtadult.Text == "" || txtchild.Text == "")
                {
                    if (txtfirstname.Text == "")
                        txtfirstname.Text = "";
                    if (txtlastname.Text == "")
                        txtlastname.Text = "";
                    if (txtmobileno.Text == "")
                        txtmobileno.Text = "";
                    if (txtcity.Text == "")
                        txtcity.Text = "";
                    if (txtzip.Text == "")
                        txtzip.Text = "";
                    if (txtrooms.Text == "")
                        txtrooms.Text = "";
                    if (txtpaxs.Text == "")
                        txtpaxs.Text = "";
                    if (txtadult.Text == "")
                        txtadult.Text = "";
                    if (txtchild.Text == "")
                        txtchild.Text = "";
                }
                else
                {
                    popreservation.IsOpen = true;
                }
            }
            catch (Exception) { }
        }
        private void Card_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }
        public static string num;
        private void dg_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                num = txtreservationid.Text;
                Refund.receivedid = selectedid;
                Refund.a = 1;
                this.NavigationService.Navigate(rf);
                DataTable dt = RE.Res();
                if (dt.Rows.Count == 0)
                { }
                else
                {
                    rf.GUESTNAME.Text = dt.Rows[0]["FIRSTNAME"].ToString();
                    rf.COMPANYNAME.Text = dt.Rows[0]["COMPANY_NAME"].ToString();
                    rf.RESERVATION_ID.Text = dt.Rows[0]["RESERVATION_ID"].ToString();
                    rf.ROOMS.Text = dt.Rows[0]["NO_OF_ROOMS"].ToString();
                    rf.PAX.Text = dt.Rows[0]["PAX"].ToString();
                    rf.ARRIVAL_DATE.Text = dt.Rows[0]["ARRIVAL_DATE"].ToString();
                    rf.DEPARTURE_DATE.Text = dt.Rows[0]["DEPARTURE_DATE"].ToString();
                    rf.ADVANCEAMOUNT.Text = dt.Rows[0]["AMOUNT_RECEIVED"].ToString();
                }
            }
            catch (Exception) { }
        }
        public string amount;
        public static string id;
        private void yes1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cancel.IsOpen = false;
                id = aa.Text;
                DataTable da = RE.AdvanceAmount();
                //amount = da.Rows[0]["AMOUNT_RECEIVED"].ToString();
                //if (amount == "0.00")
                //{
                //}
                if (da.Rows.Count == 0)
                {
                    canc.IsOpen = true;
                }
                else
                {
                    DataTable RC = RE.RefundCheck();
                    if (RC.Rows.Count > 0)
                    {
                        canc.IsOpen = true;
                    }
                    else
                    {
                        num = aa.Text;
                        Refund.receivedid = selectedid;
                        Refund.a = 1;
                        this.NavigationService.Navigate(rf);
                        DataTable dt = RE.Res();
                        if (dt.Rows.Count == 0)
                        { }
                        else
                        {
                            ResRef = 1;
                            rf.GUESTNAME.Text = dt.Rows[0]["FIRSTNAME"].ToString();
                            rf.COMPANYNAME.Text = dt.Rows[0]["COMPANY_NAME"].ToString();
                            rf.RESERVATION_ID.Text = dt.Rows[0]["RESERVATION_ID"].ToString();
                            rf.ROOMS.Text = dt.Rows[0]["NO_OF_ROOMS"].ToString();
                            rf.PAX.Text = dt.Rows[0]["PAX"].ToString();
                            rf.ARRIVAL_DATE.Text = dt.Rows[0]["ARRIVAL_DATE"].ToString();
                            rf.DEPARTURE_DATE.Text = dt.Rows[0]["DEPARTURE_DATE"].ToString();
                            rf.ADVANCEAMOUNT.Text = dt.Rows[0]["AMOUNT_RECEIVED"].ToString();
                            rf.amount.Text = "0.00";
                            rf.balance_amount.Text = dt.Rows[0]["AMOUNT_RECEIVED"].ToString();
                            rf.refund.IsChecked = true;
                        }
                    }
                }
            }
            catch (Exception) { }
        }
        private void no1_Click(object sender, RoutedEventArgs e)
        {
            clear();
            this.NavigationService.Refresh();
        }
        private void gridsearch_LostFocus(object sender, RoutedEventArgs e)
        {
            y = gridsearch.Text;
            try
            {
                DataTable dt = RE.gridfilter();
                dgres.ItemsSource = dt.DefaultView;
                if (gridsearch.Text=="")
                {
                    datatable = RE.Grid();
                    dgres.ItemsSource = datatable.DefaultView;
                }
            }
            catch(SystemException )
            { }
        }
        private void btncls_Click(object sender, RoutedEventArgs e)
        {
            popbooking.IsOpen = false;
        }
        private void pstbook_Click(object sender, RoutedEventArgs e)
        {
            popbooking.IsOpen = true;
            datatable1 = RE.Grid1();
            dtbooking.ItemsSource = datatable1.DefaultView;
        }
        private void dtbooking_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                popbooking.IsOpen = false;
                Cancel.IsEnabled = true;
                //DataTable dt2 = RE.fill_data();
                save.Content = "Update";
                txtsearch.IsEnabled = false;
                int i = dtbooking.SelectedIndex;
                if (datatable1.Rows.Count == 0)
                {
                }
                else
                {
                    if (i >= 0)
                    {
                        aa.Text = datatable1.Rows[i]["RESERVATION_ID"].ToString();
                        txtfirstname.Text = datatable1.Rows[i]["FIRSTNAME"].ToString();
                        txtlastname.Text = datatable1.Rows[i]["LASTNAME"].ToString();
                        txtrooms.Text = datatable1.Rows[i]["NO_OF_ROOMS"].ToString();
                        txtpaxs.Text = datatable1.Rows[i]["PAX"].ToString();
                        txtadult.Text = datatable1.Rows[i]["ADULT"].ToString();
                        txtchild.Text = datatable1.Rows[i]["CHILD"].ToString();
                        //dt.Text = Convert.ToDateTime(datatable1.Rows[i]["ARRIVAL_DATE"]).ToString();
                        //dt1.Text = Convert.ToDateTime(datatable1.Rows[i]["DEPARTURE_DATE"]).ToString();
                        //txtdays.Text = datatable1.Rows[i]["DAYS"].ToString();
                        cbroomtype.Text = datatable1.Rows[i]["ROOM_CATEGORY"].ToString();
                        cbguest.Text = datatable1.Rows[i]["GUEST_STATUS"].ToString();
                        txtcompany.Text = datatable1.Rows[i]["COMPANY_NAME"].ToString();
                        cbnationality.Text = datatable1.Rows[i]["NATIONALITY"].ToString();
                        txtrichtextbox.Text = datatable1.Rows[i]["COMPANY_ADDRESS"].ToString();
                        txtdoorno.Text = datatable1.Rows[i]["DOOR_NO"].ToString();
                        txtcity.Text = datatable1.Rows[i]["CITY"].ToString();
                        txtstate.Text = datatable1.Rows[i]["STATE"].ToString();
                        cbcountry.Text = datatable1.Rows[i]["COUNTRY"].ToString();
                        txtzip.Text = datatable1.Rows[i]["ZIP"].ToString();
                        txtmobileno.Text = datatable1.Rows[i]["MOBILE_NO"].ToString();
                        //txtidproof.Text = datatable1.Rows[i]["ID_TYPE"].ToString();
                        //txtidproof1.Text = datatable1.Rows[i]["ID_DATA"].ToString();
                        txtsplinstruction.Text = datatable1.Rows[i]["SPECIALINSTRUCTIONS"].ToString();
                        txtemail.Text = datatable1.Rows[i]["EMAIL"].ToString();
                    }
                    else
                    { }
                }
            }
            catch (Exception) { }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                RESERVATION r = new RESERVATION();
                RESERVATIONS re = new RESERVATIONS();
                REFUND R = new REFUND();
                canc.IsOpen = false;
                R.MOBILE_NO = txtmobileno.Text;
                R.RESERVATION_ID = Convert.ToInt32(aa.Text);
                R.GUEST_NAME = txtfirstname.Text;
                R.STATUS = "CANCLED";
                R.ADVANCE_STATUS = "CLEARED";
                R.Status_change();
                R.Insert_Cancellation();
                //R.CANCELRESERVATION();
                R.R1();
                //this.NavigationService.Navigate(re);
                DataTable dt = r.Grid();
                dgres.ItemsSource = dt.DefaultView;
            }
            catch (Exception) { }
        }
        private void txtadult_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtpaxs.Text == "" || txtadult.Text == "")
            {
            }
            else
            {
                p = Convert.ToInt32(txtpaxs.Text);
                ad = Convert.ToInt32(txtadult.Text);
                txtchild.Text = (p - ad).ToString();
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            cancelpopup.IsOpen = false;
        }
        private void dt2_LostFocus(object sender, RoutedEventArgs e)
        {
            RE.ARRIVALDATE = Convert.ToDateTime(dt2.Text);
            DataTable ED = RE.DATE();
            if (ED.Rows.Count == 0)
            {
                MessageBox.Show("This reservation has already been cancelled");
            }
            dg.ItemsSource = ED.DefaultView;
        }
        private void no_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Refresh();
        }
        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid datagrid = sender as DataGrid;
                DataGridRow row = (DataGridRow)datagrid.ItemContainerGenerator.ContainerFromIndex(datagrid.SelectedIndex);
                DataGridCell RowColumn = datagrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
                selectedid = ((TextBlock)RowColumn.Content).Text;
                popup1.IsOpen = false;
                aa.Text = selectedid;
                aa.Focus();
                RE.RESERVATIONID = selectedid;
                DataTable cdt = RE.Cancle();
                //aa.Text = RE.RESERVATIONID;
                txtfirstname.Text = RE.FIRSTNAME;
                txtlastname.Text = RE.LASTNAME;
                txtrooms.Text = RE.NOOFROOMS;
                txtpaxs.Text = RE.PAXS;
                txtadult.Text = RE.ADULTS;
                txtchild.Text = RE.CHILDS;
                dt.Text = Convert.ToDateTime(RE.ARRIVALDATE).ToString();
                dt1.Text = Convert.ToDateTime(RE.DEPARTUREDATE).ToString();
                txtdays.Text = RE.DAYS;
                cbroomtype.Text = RE.ROOM_CATEGORY;
                cbguest.Text = RE.GUESTSTATUS;
                txtcompany.Text = RE.COMPANY;
                cbnationality.Text = RE.NATIONALITY;
                txtrichtextbox.Text = RE.COMPANYADDRESS;
                txtdoorno.Text = RE.DOORNO;
                txtcity.Text = RE.CITY;
                txtstate.Text = RE.STATE;
                cbcountry.Text = RE.COUNTRY;
                txtzip.Text = RE.ZIP;
                txtmobileno.Text = RE.MOBILE_NO;
                //txtidproof.Text = RE.IDPROOF;
                //txtidproof1.Text = RE.IDPROOF1;
                txtsplinstruction.Text = RE.SPECIALINSTRUCTION;
                txtemail.Text = RE.EMAILID;
            }
            catch (Exception) { }
        }   
    }
}
