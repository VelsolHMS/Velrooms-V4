using HMS.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using HMS.ViewModel;
using HMS.View.Masters;
using System.Net;
using HMS.Model.Others;

namespace HMS.View.Operations
{
    /// <summary>
    /// Interaction logic for Checkin.xaml
    /// </summary>
    public partial class Checkin : Page
    {
        Checksin ch = new Checksin();
        Planecode p = new Planecode();
        Hotelinfo hotelinfo = new Hotelinfo();
        public int error = 0;
        RESERVATION r = new RESERVATION();
        advance1 advance = new advance1();
        data daa = new data();
        List<int> lo = new List<int>();
        List<string> st = new List<string>();
        TextBlock tb = new TextBlock();
        List<int> id = new List<int>();
        DataTable d = new DataTable();
        public string roomnoKEY = null;
        public Checkin()
        {
            data.COUNT = 0;
            InitializeComponent();
            data.COUNT = 1;
            //  Clear();
            RACKTARRIF.IsEnabled = false;
            RACKADULT.IsEnabled = false;
            RACKCHILD.IsEnabled = false;
            Hotelinfo H = new Hotelinfo();
            H.market();
            txtextrabed.Text = "0";EADULT.Text = "0";ECHILD.Text = "0";
            txtextrabed.IsEnabled = false;EADULT.IsEnabled = false;ECHILD.IsEnabled = false;
            txtmarketseg.Text = H.city;
            DataTable d  = ch.CompanyName();
            txtcompany.ItemsSource = d.DefaultView;
            //DataTable d1 = ch.CompanyAddress();
            //companyADDRESS.ItemsSource = d1.DefaultView;
            //DataTable d2 = ch.Plancode();
            //plancode.ItemsSource = d2.DefaultView;
            DataTable s = r.state();
            txtstate.ItemsSource = s.DefaultView;
            int ID = ch.get_checkin_id();
            checkinid.Text = ID.ToString();
            if (RESERVSTIONCHECKIN.p == 1)
            {
                //d = RESERVSTIONCHECKIN.DD;
                //int a = RESERVSTIONCHECKIN.index;
                CHARGETARRIF.IsReadOnly = true;
                //rescheckinstack.Children.Remove(r1);
                //rescheckinstack.Children.Remove(r2);
                //rescheckinstack.Children.Remove(roomno);
                //rescheckinstack.Children.Remove(roomcategory);
                //reservationid.Text = "Reservation-id :" + "" + d.Rows[0]["RESERVATION_ID"].ToString();
                //tb.Margin = new Thickness(10, 0, 0, 0);
                //tb.Width = 518;
                //tb.FontSize = 11;
                //tb.FontWeight = FontWeights.Bold;
                //rescheckinstack.Children.Add(tb);
                //int noofrooms = Convert.ToInt16(d.Rows[0]["NO_OF_ROOMS"]);
                //for (int I = 0; I < noofrooms; I++)
                //{
                //    if (I == 0)
                //    {
                //        checkinid.FontSize = 9;
                //        checkinid.FontWeight = FontWeights.Bold;
                //        checkinid.Text = ID.ToString();
                //        id.Add(ID);
                //    }
                //    if (I > 0)
                //    {
                //        checkinid.FontSize = 10;
                //        ID = ID + 1;
                //        checkinid.Text = " " + checkinid.Text + "," + ID;
                //        id.Add(ID);
                //    }
                //}
                //foreach (KeyValuePair<int, string> pair in Vacant.l)
                //{
                //    st.Add(pair.Value);
                //    string B = pair.Value.ToString();
                //    tb.Text = tb.Text + " " + B + ":";
                //    if (!lo.Contains(pair.Key))
                //    {
                //        lo.Add(pair.Key);
                //        string A = pair.Key.ToString();
                //        tb.Text = tb.Text + " " + A;
                //    }
                //}

                //txtfirstname.Text = d.Rows[a]["FIRSTNAME"].ToString();
                //txtlastname.Text = d.Rows[a]["LASTNAME"].ToString();
                //txtcompany.Text = d.Rows[a]["COMPANY_NAME"].ToString();
                //companyADDRESS.Text = d.Rows[a]["COMPANY_ADDRESS"].ToString();
                //string TIME = DateTime.Now.ToString("hh:mm:ss tt");
                //DateTime DATE = Convert.ToDateTime(d.Rows[a]["ARRIVAL_DATE"]);
                //string date = DATE.ToShortDateString();
                //arrival.Text = date + " " + TIME;
                //DateTime d_date = Convert.ToDateTime(d.Rows[a]["DEPARTURE_DATE"]);
                //DateTime D_TIME = Convert.ToDateTime(d.Rows[a]["DEPARTURE_TIME"]);
                //String Dtime = D_TIME.ToString("hh:mm:ss tt");
                //string d_d = DATE.ToShortDateString();
                //departure.Text = d_d + " " + Dtime;
                //ADDRESS.Text = d.Rows[a]["DOOR_NO"].ToString();
                //txtcity.Text = d.Rows[a]["CITY"].ToString();
                //String ST = d.Rows[a]["STATE"].ToString();
                //txtstate.SelectedItem = ST;
                //ZIP.Text = d.Rows[a]["ZIP"].ToString();
                //String CO = d.Rows[a]["COUNTRY"].ToString();
                //txtcountry.SelectedItem = CO.ToLower();
                //txtadult.Text = d.Rows[a]["ADULT"].ToString();
                //txtchild.Text = d.Rows[a]["CHILD"].ToString();
                //txtemail.Text = d.Rows[a]["EMAIL"].ToString();
                //txtmobileno.Text = d.Rows[a]["MOBILE_NO"].ToString();
                // roomcategory.Content = d.Rows[a]["ROOM_CATEGORY"];
                //idproof.Text = d.Rows[a]["ID_TYPE"].ToString();
                //txtproof.Text = d.Rows[a]["ID_DATA"].ToString();
                //txtpax.Text = d.Rows[a]["PAX"].ToString();
            }
            else
            {
                arrival.Text = DateTime.Now.ToShortDateString();
                departure.Text = CheckinDeparture.date;
                roomno.Text = Vacant.roomno.ToString();
                roomcategory.Text = Vacant.ROOMTYPE;
               
                DataTable dt = ch.fetch_PLANCODE(Convert.ToInt16(roomno.Text));
                plancode.ItemsSource = dt.DefaultView;
                DataTable DT = ch.GET_COMPANY();
                DataRow ROW = DT.NewRow();
                ROW["COMPANY_NAME"] = "Select a Compny";
                DT.Rows.InsertAt(ROW, 0);
                txtcompany.ItemsSource = DT.DefaultView;
                DataTable dc = ch.Getpaxctg();
                if (dc.Rows.Count == 0)
                {
                }
                else
                {
                    txtpax.Text = dc.Rows[0]["MAXPAX"].ToString();
                }
            }
        }
        public static string ADVROOM;
        public void Clear()
        {
            txtfirstname.Text = "";
            txtlastname.Text = "";
            ADDRESS.Text = "";
            ZIP.Text = "";
            txtcity.Text = "";
            txtmobileno.Text = "";
            txtemail.Text = "";
            txtproof.Text = "";
            txtpax.Text = "";
            txtadult.Text = "";
            txtextrabed.Text = "";
            EADULT.Text = "";
            imgcaptured.Source = null;
        }
        public int a = 0;
        private void txtpax_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DataTable d = ch.paxdetails();
                //if (RESERVSTIONCHECKIN.p == 1)
                //{
                //    if (Checksin.maxpax == 1)
                //    {
                //        RACKTARRIF.Text = d.Rows[0]["SINGLERATE_TARRIF"].ToString();
                //        RACKADULT.Text = d.Rows[0]["EXTRABED_ADULT"].ToString();
                //        RACKCHILD.Text = d.Rows[0]["EXTRABED_CHILD"].ToString();
                //        CHARGETARRIF.Text = d.Rows[0]["SINGLERATE_TARRIF"].ToString();
                //        if (RACKTARRIF.Text != "")
                //        {
                //            ch.FETCH_TAX(RACKTARRIF.Text);
                //            TAXPER.Text = ch.TAX;
                //        }
                //        else
                //        {
                //            TAXPER.Text = "0.00";
                //        }
                //    }
                //    else if (Checksin.maxpax == 2)
                //    {
                //        RACKTARRIF.Text = d.Rows[0]["DOUBLERATE_TARRIF"].ToString();
                //        RACKADULT.Text = d.Rows[0]["EXTRABED_ADULT"].ToString();
                //        RACKCHILD.Text = d.Rows[0]["EXTRABED_CHILD"].ToString();
                //        CHARGETARRIF.Text = d.Rows[0]["DOUBLERATE_TARRIF"].ToString();
                //        if (RACKTARRIF.Text != "")
                //        {
                //            ch.FETCH_TAX(RACKTARRIF.Text);
                //            TAXPER.Text = ch.TAX;
                //        }
                //        else
                //        {
                //            TAXPER.Text = "0.00";
                //        }
                //    }
                //    else if (Checksin.maxpax == 3)
                //    {
                //        RACKTARRIF.Text = d.Rows[0]["TRIPLERATE_TARRIF"].ToString();
                //        RACKADULT.Text = d.Rows[0]["EXTRABED_ADULT"].ToString();
                //        RACKCHILD.Text = d.Rows[0]["EXTRABED_CHILD"].ToString();
                //        CHARGETARRIF.Text = d.Rows[0]["TRIPLERATE_TARRIF"].ToString();
                //        if (RACKTARRIF.Text != "")
                //        {
                //            ch.FETCH_TAX(RACKTARRIF.Text);
                //            TAXPER.Text = ch.TAX;
                //        }
                //        else
                //        {
                //            TAXPER.Text = "0.00";
                //        }
                //    }
                //    else if (Checksin.maxpax == 4)
                //    {
                //        RACKTARRIF.Text = d.Rows[0]["QUADRATE_TARRIF"].ToString();
                //        RACKADULT.Text = d.Rows[0]["EXTRABED_ADULT"].ToString();
                //        RACKCHILD.Text = d.Rows[0]["EXTRABED_CHILD"].ToString();
                //        CHARGETARRIF.Text = d.Rows[0]["QUADRATE_TARRIF"].ToString();
                //        if (RACKTARRIF.Text != "")
                //        {
                //            ch.FETCH_TAX(RACKTARRIF.Text);
                //            TAXPER.Text = ch.TAX;
                //        }
                //        else
                //        {
                //            TAXPER.Text = "0.00";
                //        }
                //    }
                //}
                //else
                //{
                if (Checksin.maxpax == 1)
                {
                    RACKTARRIF.Text = d.Rows[0]["SINGLERATE_TARRIF"].ToString();
                    RACKADULT.Text = d.Rows[0]["EXTRABED_ADULT"].ToString();
                    RACKCHILD.Text = d.Rows[0]["EXTRABED_CHILD"].ToString();
                    CHARGETARRIF.Text = d.Rows[0]["SINGLERATE_TARRIF"].ToString();
                    if (RACKTARRIF.Text != "")
                    {
                        ch.FETCH_TAX(RACKTARRIF.Text);
                        TAXPER.Text = ch.TAX;
                    }
                    else
                    {
                        TAXPER.Text = "0.00";
                    }
                }
                else if (Checksin.maxpax == 2)
                {
                    RACKTARRIF.Text = d.Rows[0]["DOUBLERATE_TARRIF"].ToString();
                    RACKADULT.Text = d.Rows[0]["EXTRABED_ADULT"].ToString();
                    RACKCHILD.Text = d.Rows[0]["EXTRABED_CHILD"].ToString();
                    CHARGETARRIF.Text = d.Rows[0]["DOUBLERATE_TARRIF"].ToString();
                    if (RACKTARRIF.Text != "")
                    {
                        ch.FETCH_TAX(RACKTARRIF.Text);
                        TAXPER.Text = ch.TAX;
                    }
                    else
                    {
                        TAXPER.Text = "0.00";
                    }
                }
                else if (Checksin.maxpax == 3)
                {
                    RACKTARRIF.Text = d.Rows[0]["TRIPLERATE_TARRIF"].ToString();
                    RACKADULT.Text = d.Rows[0]["EXTRABED_ADULT"].ToString();
                    RACKCHILD.Text = d.Rows[0]["EXTRABED_CHILD"].ToString();
                    CHARGETARRIF.Text = d.Rows[0]["TRIPLERATE_TARRIF"].ToString();
                    if (RACKTARRIF.Text != "")
                    {
                        ch.FETCH_TAX(RACKTARRIF.Text);
                        TAXPER.Text = ch.TAX;
                    }
                    else
                    {
                        TAXPER.Text = "0.00";
                    }
                }
                else if (Checksin.maxpax == 4)
                {
                    RACKTARRIF.Text = d.Rows[0]["QUADRATE_TARRIF"].ToString();
                    RACKADULT.Text = d.Rows[0]["EXTRABED_ADULT"].ToString();
                    RACKCHILD.Text = d.Rows[0]["EXTRABED_CHILD"].ToString();
                    CHARGETARRIF.Text = d.Rows[0]["QUADRATE_TARRIF"].ToString();
                    if (RACKTARRIF.Text != "")
                    {
                        ch.FETCH_TAX(RACKTARRIF.Text);
                        TAXPER.Text = ch.TAX;
                    }
                    else
                    {
                        TAXPER.Text = "0.00";
                    }
                }
                else if (Checksin.maxpax > 4)
                {
                    RACKTARRIF.Text = d.Rows[0]["QUADRATE_TARRIF"].ToString();
                    RACKADULT.Text = d.Rows[0]["EXTRABED_ADULT"].ToString();
                    RACKCHILD.Text = d.Rows[0]["EXTRABED_CHILD"].ToString();
                    CHARGETARRIF.Text = d.Rows[0]["QUADRATE_TARRIF"].ToString();
                    if (RACKTARRIF.Text != "")
                    {
                        ch.FETCH_TAX(RACKTARRIF.Text);
                        TAXPER.Text = ch.TAX;
                    }
                    else
                    {
                        TAXPER.Text = "0.00";
                    }
                }
            }
            catch (Exception) { }
        }
        private void EADULT_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (EADULT.Text != "")
            {
                if (txtpax.Text != "")
                {
                    decimal RADULT = Convert.ToDecimal(RACKADULT.Text);
                    if (txtextrabed.Text != "")
                    {
                        decimal ADULT = Convert.ToDecimal(EADULT.Text);
                        int EXTRABED = Convert.ToInt16(txtextrabed.Text);
                        if (ADULT <= EXTRABED)
                        {
                            decimal D = ADULT * RADULT;
                            String CADULT = Convert.ToString(D);
                            CHARGEADULT.Text = CADULT.ToString();
                        }
                        if (ADULT > EXTRABED)
                        {
                            MessageBox.Show("ADULT IS GREATER THAN EXTRABED,YOU COULD NOT DO THIS"); CHARGEADULT.Text = ""; return;
                        }
                    }
                }
            }
            else { CHARGEADULT.Text = ""; }
        }
        private void ECHILD_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ECHILD.Text != "")
            {
                if (txtpax.Text != "")
                {
                    string ADULT = "0.00";
                    decimal RCHILD = Convert.ToDecimal(RACKCHILD.Text);
                    if (txtextrabed.Text != "")
                    {
                        decimal CHILD = Convert.ToDecimal(ECHILD.Text);
                        int EXTRABED = Convert.ToInt16(txtextrabed.Text);
                        if (CHILD <= EXTRABED)
                        {
                            decimal D = CHILD * RCHILD;
                            String CADULT = Convert.ToString(D);
                            CHARGECHILD.Text = CADULT.ToString();
                        }
                        if (CHILD > EXTRABED)
                        {
                            MessageBox.Show(" NO OF CHILDRENS ARE GREATER THAN EXTRABED,YOU COULD NOT DO THIS");
                            CHARGECHILD.Text = ""; return;
                        }
                        if (EADULT.Text != "")
                        {
                            ADULT = EADULT.Text;
                        }
                        decimal ADULT_PLUS_CHILD =decimal.Parse(CHILD + ADULT);
                        if (ADULT_PLUS_CHILD > EXTRABED)
                        {
                            MessageBox.Show("YOUR EXTRABED OF ADULTS AND CHILDS ARE MORE THAN THE EXTRABEDS");
                            CHARGECHILD.Text = "";
                            return;
                        }
                    }
                }
            }
            else { CHARGECHILD.Text = ""; }
        }
        public void BIND()
        {
            try
            {
                if(imgcaptured.Source == null)
                {
                    ch.IMAGE = "";
                }
                else
                {
                    string root = @"C:\\Users\\Swamy\\source\\repos\\Velrooms-V2\\VelRooms\\Pictures";
                    // If directory does not exist, don't even try 
                    if (Directory.Exists(root))
                    {
                        string BasePath = "C:\\Users\\Swamy\\source\\repos\\Velrooms-V2\\VelRooms\\Pictures\\";
                        string File_name = txtfirstname.Text + checkinid.Text + ".jpg";
                        string Filepath = System.IO.Path.Combine(BasePath + File_name);
                        Helper.SaveImageCapture((BitmapSource)imgcaptured.Source, Filepath);
                        ch.IMAGE = Filepath;
                    }
                    else
                    {
                        ch.IMAGE = "";
                    }
                }
                if (RESERVSTIONCHECKIN.p != 1)
                {
                    ch.ARRIVAL_DATE = Convert.ToDateTime(arrival.Text);
                    ch.DEPARTURE_DATE = Convert.ToDateTime(departure.Text);
                }
                else
                {
                    //ch.roomno_res = lo;
                    //ch.roomcategory_res = st;
                    ch.ARRIVAL_DATE = Convert.ToDateTime(arrival.Text);
                    ch.DEPARTURE_DATE = Convert.ToDateTime(departure.Text);
                }
                ch.ROOM_NO = Convert.ToString(roomno.Text);
                ch.ROOM_TYPE = Convert.ToString(roomcategory.Text);
                ////TimeSpan ts = new TimeSpan(); 
                ch.ARRIVAL_TIME = DateTime.Now.ToShortTimeString();
                ch.Company_Gst = gst_no.Text;
                ch.SUFFIX = select.Text;
                ch.FIRSTNAME = txtfirstname.Text;
                ch.LASTNAME = txtlastname.Text;
                ch.ADDRESS = ADDRESS.Text;
                ch.ZIP = Convert.ToInt32(ZIP.Text);
                ch.CITY = txtcity.Text;
                ch.STATE = txtstate.Text;
                ch.COUNTRY = txtcountry.Text;
                ch.MOBILE_NUMBER = Convert.ToInt64(txtmobileno.Text);
                ch.EMAIL = txtemail.Text;
                ch.ID_TYPE = idproof.Text;
                ch.ID_PROOF = txtproof.Text;
                ch.COMPANY_NAME = txtcompany.Text;
                ch.COMPANY_A = companyADDRESS.Text;
                ch.MARKET_SEGMENT = txtmarketseg.Text.ToString();
                ch.PAX = Convert.ToInt16(txtpax.Text);
                ch.PAX_ADULT = Convert.ToInt16(txtadult.Text);
                ch.PAX_CHILD = Convert.ToInt16(txtchild.Text);
                ch.EXTRABED = Convert.ToInt16(txtextrabed.Text);
                ch.EXTRA_ADULT = Convert.ToInt16(EADULT.Text);
                ch.EXTRA_CHILD = Convert.ToInt16(ECHILD.Text);
                ch.PLANCODE = plancode.Text;
                //ch.FETCH_TAX(CHARGETARRIF.Text);
                //TAXPER.Text = ch.TAX;
                ch.TAX = TAXPER.Text.ToString();
                ch.RACK_TARRIF = Convert.ToDecimal(RACKTARRIF.Text);
                ch.RACK_ECHILD = Convert.ToDecimal(RACKCHILD.Text);
                ch.RACK_EADULT = Convert.ToDecimal(RACKADULT.Text);
                ch.CHARGED_TARRIF = Convert.ToDecimal(CHARGETARRIF.Text);
                if (CHARGEADULT.Text == "")
                {
                    CHARGEADULT.Text = "0.00";
                }
                else
                {
                    ch.CHARGED_EADULT = Convert.ToDecimal(CHARGEADULT.Text);
                }
                if (CHARGECHILD.Text == "")
                {
                    CHARGECHILD.Text = "0.00";
                }
                else
                {
                    ch.CHARGED_ECHILD = Convert.ToDecimal(CHARGECHILD.Text);
                }
                ch.status = status.Text;
                ch.CHECK_OUT = 0;
                if (RESERVSTIONCHECKIN.p == 1)
                {
                    ch.RESERVATION_ID = Convert.ToInt16(RESERVSTIONCHECKIN.res_id);
                    ch.reservationcheckinupdate();
                    ch.CHECKIN_ID = int.Parse(checkinid.Text.ToString());
                    ch.advanceupdate();
                }
                else
                {
                    ch.CHECKIN_ID = int.Parse(checkinid.Text.ToString());
                    ch.RESERVATION_ID = 0;
                }
                ch.SCANTY_BAGGAGE = scantybaggage.Text;
                //11/15/17 ss rr yy ujj
                //ch.USER_NAME = login.u;
                ch.INSERT_BY = login.u;
                ch.INSERT_DATE = DateTime.Today;
            }
            catch (Exception)
            {
                MessageBox.Show("please enter values");
            }
        }
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
        private void SAVE_Click(object sender, RoutedEventArgs e)
        {
            //popup.IsOpen = true;
            if ((error != 0) || txtchild.Text == "" || txtadult.Text == "" || EADULT.Text == "" || ECHILD.Text == "" || txtextrabed.Text == "" || txtfirstname.Text == "" || txtlastname.Text == "" || ADDRESS.Text == "" || txtcity.Text == "" || ZIP.Text == "" || txtmobileno.Text == "" || txtpax.Text == "" || txtproof.Text == "")
            {
                //  pop1.IsOpen = true;
                if (txtchild.Text == "")
                { txtchild.Text = ""; }
                if (EADULT.Text == "")
                { EADULT.Text = ""; }
                if (ECHILD.Text == "")
                { ECHILD.Text = ""; }
                if (txtextrabed.Text == "")
                { txtextrabed.Text = ""; }
                if (txtadult.Text == "")
                { txtadult.Text = ""; }
                if (txtfirstname.Text == "")
                { txtfirstname.Text = ""; }
                if (txtlastname.Text == "")
                { txtlastname.Text = ""; }
                if (ADDRESS.Text == "")
                { ADDRESS.Text = ""; }
                if (txtcity.Text == "")
                { txtcity.Text = ""; }
                if (ZIP.Text == "")
                { ZIP.Text = ""; }
                if (txtpax.Text == "")
                { txtpax.Text = ""; }
                if (txtmobileno.Text == "")
                { txtmobileno.Text = ""; }
                //MessageBox.Show("Please fill all fields");
                pop1.IsOpen = true;
            }
            else
            {
                if (txtamntrecivd.Text == "")
                {
                    txtamntrecivd.Text = "0.00";
                }
                if (txtchild.Text == "")
                {
                    txtchild.Text = "0";
                }
                if (EADULT.Text == "")
                {
                    EADULT.Text = "0";
                    CHARGEADULT.Text = "0.00";
                }
                if (ECHILD.Text == "")
                {
                    ECHILD.Text = "0"; CHARGECHILD.Text = "0.00";
                }
                if (txtextrabed.Text == "")
                {
                    txtextrabed.Text = "0"; RACKTARRIF.Text = "0.00"; CHARGETARRIF.Text = "0.00";
                }
                if (RACKADULT.Text == "") { RACKADULT.Text = "0.00"; }
                if (RACKCHILD.Text == "")
                {
                    RACKCHILD.Text = "0.00";
                }
                //tb.Text = "Do you want to pay advance";
                if (ADVANCEPOPUP.IsOpen == false)
                {
                    popup.IsOpen = true;
                }
                BIND();
                //ch.ROOM_NO = Convert.ToInt16(roomnoKEY);
                //this.NavigationService.Refresh();
            }
        }
        private void yes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (error!= 0 || txtfirstname.Text == null || txtlastname.Text == null || ADDRESS.Text == null || ZIP.Text == null || txtcity.Text == null || txtmobileno.Text == null || idproof.Text == null || txtproof.Text == null || txtpax.Text == null || txtadult.Text == null || txtchild.Text == null || txtextrabed.Text == null || EADULT.Text == null || ECHILD.Text == null || TAXPER.Text == null || RACKTARRIF.Text == null || RACKCHILD.Text == null || RACKADULT.Text == null || CHARGETARRIF.Text == null || CHARGEADULT.Text == null || CHARGECHILD.Text == null)
                {
                    //MessageBox.Show("FILL ALL COLUMNS ");
                    pop1.IsOpen = true;
                }
                else
                {
                    popup.IsOpen = false;
                    int a = Convert.ToInt32(txtadult.Text);
                    int b = Convert.ToInt32(txtchild.Text);
                    int cv = a + b;
                    if (txtpax.Text == cv.ToString())
                    {
                        if (RESERVSTIONCHECKIN.p != 1)
                        {
                            ADVANCE = 2;
                            txtroomno.Text = Convert.ToString(roomno.Text);
                        }
                        else
                        {
                            ADVANCE = 1;
                            txtroomno.Text = roomno.Text;
                            //ch.adavance();
                            //ch.updateroomstatus();
                        }
                        checkin_id.Text = checkinid.Text.ToString();
                        if (RESERVSTIONCHECKIN.p != 1)
                        {
                            ADVANCE = 2;
                            ch.ID = Convert.ToInt32(checkin_id.Text);
                            //ch.adavance();
                            //ch.updateroomstatus();
                        }
                        else
                        {
                            ADVANCE = 1;
                            ch.id_res = id;
                            //ch.adavance();
                        }
                        guestname.Text = txtfirstname.Text;
                        companyname.Text = txtcompany.Text;
                        contactno.Text = txtmobileno.Text;
                        RECEIPTNO.Content = ch.get_advance_id();
                        ADVANCEPOPUP.IsOpen = true;
                    }
                    else
                    {
                        popup.IsOpen = false;
                        MessageBox.Show("Adults AND Childs ARE Greterthen PAX ");
                        txtpax.Text = "";
                        txtadult.Text = "";
                        txtchild.Text = "";
                        txtextrabed.Text = "";
                        EADULT.Text = "";
                        ECHILD.Text = "";
                        plancode.Text = "";
                        TAXPER.Text = "";
                        RACKTARRIF.Text = "";
                        RACKADULT.Text = "";
                        RACKCHILD.Text = "";
                        CHARGETARRIF.Text = "";
                        CHARGEADULT.Text = "";
                        CHARGECHILD.Text = "";
                    }
                }
            }
            catch (Exception) { }
        }
        public static int ADVANCE = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void no_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtfirstname.Text == null && txtlastname.Text == null && ADDRESS.Text == null && ZIP.Text == null && txtcity.Text == null && txtmobileno.Text == null && idproof.Text == null && txtproof.Text == null && txtpax.Text == null && txtadult.Text == null && txtchild.Text == null && txtextrabed.Text == null && EADULT.Text == null && ECHILD.Text == null && TAXPER.Text == null && RACKTARRIF.Text == null && RACKCHILD.Text == null && RACKADULT.Text == null && CHARGETARRIF.Text == null && CHARGEADULT.Text == null && CHARGECHILD.Text == null)
                {
                    //MessageBox.Show("FILL ALL COLUMNS");
                    pop1.IsOpen = true;
                }
                else
                {
                    int a = Convert.ToInt32(txtadult.Text);
                    int b = Convert.ToInt32(txtchild.Text);
                    int cv = a + b;
                    if (txtpax.Text == cv.ToString())
                    {
                        ADVANCE = 0;
                        popup.IsOpen = false; ADVANCEPOPUP.IsOpen = false;
                        ch.INSERT();
                        //ch.adavance();
                        //ch.advanceupdate();
                        //ch.INSERT_POST();
                        ch.Night_Audit();
                        //ch.updateroomstatus();
                        if (RESERVSTIONCHECKIN.p == 1)
                        {
                            ch.RESERVATIONINT();
                        }
                        //ch.postcharges();
                        popup_insert.IsOpen = true;
                        Send_SMS();
                    }
                    else
                    {
                        popup.IsOpen = false;
                        MessageBox.Show("Adults AND Childs ARE Greterthen PAX ");
                        txtpax.Text = "";
                        txtadult.Text = "";
                        txtchild.Text = "";
                        txtextrabed.Text = "";
                        EADULT.Text = "";
                        ECHILD.Text = "";
                        plancode.Text = "";
                        TAXPER.Text = "";
                        RACKTARRIF.Text = "";
                        RACKADULT.Text = "";
                        RACKCHILD.Text = "";
                        CHARGETARRIF.Text = "";
                        CHARGEADULT.Text = "";
                        CHARGECHILD.Text = "";
                    }
                }
            }
            catch (Exception) { }
        }
        CheckinDeparture C = new CheckinDeparture();
        RESERVSTIONCHECKIN rES = new RESERVSTIONCHECKIN();
        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (error != 0 || txtamntrecivd.Text == "0" || txtamntrecivd.Text == "0.0" || txtamntrecivd.Text == "0.00")
                {
                    pop1.IsOpen = true;
                }
                else
                {
                    pop1.IsOpen = false;
                    BIND_ADVANCE();
                    ch.INSERT();
                    //ch.adavance();
                    // ch.INSERT_POST();
                    ch.Night_Audit();
                    if (RESERVSTIONCHECKIN.p == 1)
                    {
                        ch.RESERVATIONINT();
                        ch.INSERT_RES_CHECKIN_ADVANCE();
                        // ch.adavance();
                    }
                    //ch.postcharges();
                    ch.CHECKIN_ID = int.Parse(checkinid.Text.ToString());
                    ch.ROOM_NO = Convert.ToString(roomno.Text);
                    //ch.RESERVATION_ID = int.Parse(reservationid.Text);

                    // ch.advanceupdate();
                    ADVANCEPOPUP.IsOpen = false;
                    popup_insert.IsOpen = true;
                    Send_SMS();
                }
            }
            catch (Exception) { }
        }
        public void Send_SMS()
        {
            DataTable landline = hotelinfo.getLandLinenumber();
            String ll_number = landline.Rows[0]["LANDLINE1"].ToString();
            string no = "9848082999";
            String AdvanceAmount;
            if (txtamntrecivd.Text != null)
            {
                AdvanceAmount = txtamntrecivd.Text;
            }
            else
            {
                AdvanceAmount = "0.00";
            }
            String username = "9494433233";
            String password = "33233";
            String mobileNumber = "91"+txtmobileno.Text;
            String customer = "Thank you very much for choosing us! \nYour Room No : "+roomno.Text+"\nAdvance Paid : "+AdvanceAmount+"\nFor Assistance Call : "+ll_number+","+no+"";
            String url = "http://sms.zestwings.com/smpp.sms?username="+username+"&password="+password+"&to="+mobileNumber+"&from=VELSOL&text="+customer+"";
            try
            {
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(url);
                
                // Prepare and Add URL Encoded data
                UTF8Encoding encoding = new UTF8Encoding();
                httpWReq.Method = "GET";
                httpWReq.ContentType = "application/x-www-form-urlencoded";
                
                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string responseString = reader.ReadToEnd();

                // Close the response
                reader.Close();
                response.Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            // popup.IsOpen = false;
        }
        public void BIND_ADVANCE()
        {
            ch.PAYMENT_MODE = cbpaymnt.Text;
            ch.CURRENCY_TYPE = currencycode.Text;
            ch.AMOUNT_RECEIVED = Convert.ToDecimal(txtamntrecivd.Text);
            ch.ROOM_NO = txtroomno.Text;
            ch.PARTICULARS = txtparticulars.Text;
            ch.TRANSACTION_NO = transactionno.Text;
            ch.CHEQUE_NO = TXTCHEQUE.Text;
        }
        private void cbpaymnt_DropDownClosed(object sender, EventArgs e)
        {
            if (cbpaymnt.Text == "Cheque")
            {
                TXTCHEQUE.IsEnabled = true;
                transactionno.IsEnabled = false;
            }
            else if (cbpaymnt.Text == "Cash Payment")
            {
                TXTCHEQUE.IsEnabled = false;
                transactionno.IsEnabled = false;
            }
            else if (cbpaymnt.Text == "Credit Card")
            {
                TXTCHEQUE.IsEnabled = false;
                transactionno.IsEnabled = true;
            }
            else if (cbpaymnt.Text == "Debit Card")
            {
                TXTCHEQUE.IsEnabled = false;
                transactionno.IsEnabled = true;
            }
        }
        private void txtcompany_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //if (e.IsDown && e.Key == Key.Down)
            //{
            //    companymaster rr = new companymaster();
            //    rr.COMPANY_NAME = txtcompany.Text;
            //    rr.get();
            //    companyADDRESS.Text = rr.PLOT_NO + "," + rr.LANDMARK + "\n" + rr.CITY + "-" + rr.PINCODE + "\n" + rr.STATE + "\n" + rr.COUNTRY + "\n" + rr.EMAIL + "\n" + rr.CONTACT;
            //}
            //else if (e.Key == Key.Up)
            //{
            //    companymaster rr = new companymaster();
            //    rr.COMPANY_NAME = txtcompany.Text;
            //    rr.get();
            //    companyADDRESS.Text = rr.PLOT_NO + "," + rr.LANDMARK + "\n" + rr.CITY + "-" + rr.PINCODE + "\n" + rr.STATE + "\n" + rr.COUNTRY + "\n" + rr.EMAIL + "\n" + rr.CONTACT;
            //}
        }
        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("mainwindowpages/home.xaml", UriKind.RelativeOrAbsolute));
        }
        private void txtproof_LostFocus(object sender, RoutedEventArgs e)
        {
            Binding b = new Binding();
            if (idproof.Text == "Aadhar")
            {
               // txtproof.Text = "";
                b.Source = daa;
                daa.Addharcard = txtproof.Text.ToUpper();
                b.Path = new PropertyPath("Addharcard");
                b.NotifyOnValidationError = true;
                b.ValidatesOnDataErrors = true;
                BindingOperations.SetBinding(txtproof, TextBox.TextProperty, b);
            }
            else if (idproof.Text == "Pancard")
            {
                //txtproof.Text = "";
                b.Source = daa;
                daa.Pancard = txtproof.Text;
                b.Path = new PropertyPath("Pancard");
                b.NotifyOnValidationError = true;
                b.ValidatesOnDataErrors = true;
                BindingOperations.SetBinding(txtproof, TextBox.TextProperty, b);
            }
            else if (idproof.Text == "DrivingLicense")
            {
               // txtproof.Text = "";
                b.Source = daa;
                daa.Driving = txtproof.Text;
                b.Path = new PropertyPath("Driving");
                b.NotifyOnValidationError = true;
                b.ValidatesOnDataErrors = true;
                BindingOperations.SetBinding(txtproof, TextBox.TextProperty, b);
            }
            else if (idproof.Text == "Voterid")
            {
                //txtproof.Text = "";
                b.Source = daa;
                daa.Voterid = txtproof.Text;
                b.Path = new PropertyPath("Voterid");
                b.NotifyOnValidationError = true;
                b.ValidatesOnDataErrors = true;
                BindingOperations.SetBinding(txtproof, TextBox.TextProperty, b);
            }
            else if (idproof.Text == "Passport")
            {
               // txtproof.Text = "";
                b.Source = daa;
                daa.Passport = txtproof.Text;
                b.Path = new PropertyPath("Passport");
                b.NotifyOnValidationError = true;
                b.ValidatesOnDataErrors = true;
                BindingOperations.SetBinding(txtproof, TextBox.TextProperty, b);
            }
            else
            {
            }
        }
        private void txtproof_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (idproof.Text == "Aadhar")
            {
                if (txtproof.Text.Length == 4)
                {
                    txtproof.Text += "-";
                    txtproof.SelectionStart = txtproof.Text.Length + 4;
                }
                if (txtproof.Text.Length == 9)
                {
                    txtproof.Text += "-";
                    txtproof.SelectionStart = txtproof.Text.Length + 9;
                }
            }
        }
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            this.NavigationService.Refresh();
        }
        private void insertpop_Click(object sender, RoutedEventArgs e)
        {
            popup_insert.IsOpen = false;
            if (RESERVSTIONCHECKIN.p == 1)
            {
                RESERVSTIONCHECKIN.p = 0;
                this.NavigationService.Navigate(rES);
            }
            else
            {
                this.NavigationService.Navigate(C);
            }
        }
        private void txtsearch_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                ch.PHONE = txtsearch.Text;
                DataTable d = ch.checkin();
                if (d.Rows.Count == 0)
                {
                }
                else
                {
                    select.Text = d.Rows[0]["SUFFIX"].ToString();
                    txtfirstname.Text = d.Rows[0]["FIRSTNAME"].ToString();
                    txtlastname.Text = d.Rows[0]["LASTNAME"].ToString();
                    ADDRESS.Text = d.Rows[0]["ADDRESS"].ToString();
                    ZIP.Text = d.Rows[0]["ZIP"].ToString();
                    txtcity.Text = d.Rows[0]["CITY"].ToString();
                    txtstate.Text = d.Rows[0]["STATE"].ToString();
                    txtcountry.Text = d.Rows[0]["COUNTRY"].ToString();
                    txtmobileno.Text = d.Rows[0]["MOBILE_NO"].ToString();
                    txtemail.Text = d.Rows[0]["EMAIL"].ToString();
                    idproof.Text = d.Rows[0]["ID_TYPE"].ToString();
                    txtproof.Text = d.Rows[0]["ID_DATA"].ToString();
                    txtcompany.Text = d.Rows[0]["COMPANY_NAME"].ToString();
                    companyADDRESS.Text = d.Rows[0]["COMPANY_ADDRESS"].ToString();
                }
            }
            catch (Exception) { }
        }
        public int PL, AL;
        public static string ctg;
        private void txtpax_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable dp = ch.Getpaxctg();
                int PX = Convert.ToInt32(txtpax.Text);
                int MP = Convert.ToInt32(dp.Rows[0]["MAXPAX"]);
                if (PX > MP)
                {
                    txtextrabed.IsEnabled = true; EADULT.IsEnabled = true; ECHILD.IsEnabled = true;
                    //txtextrabed.IsReadOnly = true; EADULT.IsEnabled = true; ECHILD.IsEnabled = true;
                }
                else
                {
                    txtextrabed.IsEnabled = false; EADULT.IsEnabled = false; ECHILD.IsEnabled = false;
                }
            }
            catch (Exception) { }
        }
        public static string rn,pc;
        private void txtcompany_DropDownClosed(object sender, EventArgs e)
        {
            companymaster rr = new companymaster();
            rr.COMPANY_NAME = txtcompany.Text;
            DataTable dt= rr.get();
            // companyADDRESS.Text = rr.PLOT_NO + "," + rr.LANDMARK + "\n" + rr.CITY + "-" + rr.PINCODE + "\n" + rr.STATE + "\n" + rr.COUNTRY + "\n" + rr.EMAIL + "\n" + rr.CONTACT;
            companyADDRESS.ItemsSource = dt.DefaultView;
            //DataTable d1 = ch.CompanyAddress();
            //companyADDRESS.ItemsSource = d1.DefaultView;
        }
        WebCam webcam;
        private void btnCapture_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string root = @"C:\\Users\\Swamy\\source\\repos\\Velrooms-V2\\VelRooms\\Pictures";
                // If directory does not exist, don't even try 
                if (Directory.Exists(root))
                {
                    webcam = new WebCam();
                    webcam.InitializeWebCam(ref imgVideo);
                    webcam.Start();
                    if(imgVideo.Source == null)
                    {
                        Camerapopup.IsOpen = false;
                        MessageBox.Show("Please connect a web camera and try again");
                    }
                    else
                    {
                        Camerapopup.IsOpen = true;
                    }
                }
                else
                {
                    MessageBox.Show("The Specified Folder Path of images is not Correct. Please Contact To Velsol.!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please connect a web camera and try again");
            }
        }
        private void btncls_Click(object sender, RoutedEventArgs e)
        {
            webcam.Stop();
            Camerapopup.IsOpen = false;
        }
        private void Capture_Click(object sender, RoutedEventArgs e)
        {
            imgcaptured.Source = imgVideo.Source;
            webcam.Stop();
            Camerapopup.IsOpen = false;
        }
        private void idproof_DropDownClosed(object sender, EventArgs e)
        {
            txtproof.Text = "";
        }
        private void CHARGETARRIF_LostFocus(object sender, RoutedEventArgs e)
        {
            ch.FETCH_TAX(CHARGETARRIF.Text);
            TAXPER.Text = ch.TAX;
        }
        private void plancode_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                rn = roomno.Text;
                pc = plancode.Text;
                DataTable dt = ch.planrate();
                if (dt.Rows.Count == 0)
                {
                }
                else
                {
                    if (txtpax.Text == "1")
                    {
                        CHARGETARRIF.Text = dt.Rows[0]["SINGLE_PLAN"].ToString();
                    }
                    else if (txtpax.Text == "2")
                    {
                        CHARGETARRIF.Text = dt.Rows[0]["DOUBLE_PLAN"].ToString();
                    }
                    else if (txtpax.Text == "3")
                    {
                        CHARGETARRIF.Text = dt.Rows[0]["TRIPLE_PLAN"].ToString();
                    }
                    else if (txtpax.Text == "4")
                    {
                        CHARGETARRIF.Text = dt.Rows[0]["QUAD_PLAN"].ToString();
                    }
                    else
                    {
                        CHARGETARRIF.Text = dt.Rows[0]["COMMON_PLAN"].ToString();
                    }
                }
            }
            catch (Exception) { }
        }
        private void txtadult_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtpax.Text == "" || txtadult.Text == "")
                {
                }
                else
                {
                    PL = Convert.ToInt32(txtpax.Text);
                    AL = Convert.ToInt32(txtadult.Text);
                    txtchild.Text = (PL - AL).ToString();
                    txtchild.IsEnabled = false;
                }
            }
            catch (Exception) { }
        }
    }
}