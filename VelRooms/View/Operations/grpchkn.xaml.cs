using HMS.Model.Operations;
using HMS.ViewModel;
using HMS.Model;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Forms.Integration;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Text;
using System.Web;
using System.Net;
using System.IO;
using System.Windows.Navigation;
using System.Windows.Documents;
using System.Timers;

namespace HMS.View.Operations
{
    /// <summary>
    /// Interaction logic for grpchkn.xaml
    /// </summary>
    public partial class grpchkn : Page
    {
        public string rooms, category, cate, rack;
        public string[] value;
        public string[] values, catego;
        public int j, k, error = 0;
        public static int ka = 0;
        Hotelinfo hotelinfo = new Hotelinfo();

        GroupCheckinDeparture grpc = new GroupCheckinDeparture();
        RESERVSTIONCHECKIN rec = new RESERVSTIONCHECKIN();
        public DataTable dt = new DataTable();
        public DataTable dt1 = new DataTable();
        public decimal racktarrif = 0, chargedtarrif = 0, extrabedadult = 0;
        public string tcextad, tcextch;
        public decimal tpax = 0, tadult = 0, tchild = 0, trtarrif = 0, trextad = 0, trextch = 0, tctarrif = 0;
        int NoOfRooms;
        data daa = new data();
        public Timer t = new Timer();
        Checksin ch = new Checksin();
        gruopcheckin gc = new gruopcheckin();
        public grpchkn()
        {
            data.COUNT = 0;
            InitializeComponent();
            data.COUNT = 1;

            int gid = gc.Group_Checkinid();
            tbgckn.Text = gid.ToString();

            DataTable dt3 = gc.states();
            DataRow r1 = dt3.NewRow();
            r1["STATE"] = "--Select A State--";
            dt3.Rows.InsertAt(r1, 0);

            txtstate.ItemsSource = dt3.DefaultView;

            string r = Vacant.roomnos.ToString();
            value = r.Split(' ');
            string ss = value.Length.ToString();
            NoOfRooms = int.Parse(ss) - 1;
            j = int.Parse(ss) - 1;
            for (int i = 1; i < value.Length; i++)
            {
                if (j == 1)
                {
                    rooms += value[i];
                }
                else
                {
                    rooms += value[i] + ", ";
                }
                j--;
            }
            tbrmst.Text = rooms.ToString();
            string res = r.ToString();
            j = int.Parse(ss) - 1;
            values = res.Split(' ');
            for (int i = 1; i < values.Length; i++)
            {
                gc.ROOM_NO =value[i];
                gc.roomcategory();
                if (j == 1)
                {
                    category += gc.ROOM_CATEGORY;
                    cate += gc.ROOM_CATEGORY;
                }
                else
                {
                    category += gc.ROOM_CATEGORY + ", ";
                    cate += gc.ROOM_CATEGORY + ",";
                }
                j--;
            }
            catego = cate.Split(',');

            tbrmtyp.Text = category.ToString();
            //category = "";
            if (RESERVSTIONCHECKIN.p == 1)
            {
                String time = DateTime.Now.ToString("h:mm:ss tt");
                arrival.Content = RESERVSTIONCHECKIN.arraivaldate+" "+time;
                departure.Content = RESERVSTIONCHECKIN.departuredate;
                txtfirstname.Text = RESERVSTIONCHECKIN.firstname;
                txtlastname.Text = RESERVSTIONCHECKIN.lastname;
                ADDRESS.Text = RESERVSTIONCHECKIN.address;
                ZIP.Text = RESERVSTIONCHECKIN.zip;
                txtcity.Text = RESERVSTIONCHECKIN.city;
                txtstate.Text = RESERVSTIONCHECKIN.state;
                txtcountry.Text = RESERVSTIONCHECKIN.country;
                txtmobileno.Text = RESERVSTIONCHECKIN.mobile;
                txtemail.Text = RESERVSTIONCHECKIN.email;
                //idproof.Text = RESERVSTIONCHECKIN.Idproof;
                //txtproof.Text = RESERVSTIONCHECKIN.IdNumber;
                txtpax.Text = RESERVSTIONCHECKIN.pax;
                txtadult.Text = RESERVSTIONCHECKIN.adult;
                txtchildd.Text = RESERVSTIONCHECKIN.child;
                //RESERVSTIONCHECKIN.p = 0;
            }
            else
            {
                arrival.Content = DateTime.Now.ToString();
                departure.Content = DateTime.Now.AddDays(GroupCheckinDeparture.days).ToString();
            }
            Vacant.roomnos = "";
            k = GroupCheckinDeparture.rooms;
            ka = GroupCheckinDeparture.rooms;
            Rooms();
            Pax();
            RackTarrif();
            RExtraBedAdult();
            PlanCodes();
            Tax();
            dt.Columns.Add("reservationid", typeof(string));
            dt.Columns.Add("groupcheckin", typeof(string));
            dt.Columns.Add("roomno", typeof(string));
            dt.Columns.Add("roomtype", typeof(string));
            dt.Columns.Add("arrival", typeof(string));
            dt.Columns.Add("atime", typeof(string));
            dt.Columns.Add("departure", typeof(string));
            dt.Columns.Add("suffix", typeof(string));
            dt.Columns.Add("firstname", typeof(string));
            dt.Columns.Add("lastname", typeof(string));
            dt.Columns.Add("address", typeof(string));
            dt.Columns.Add("zip", typeof(string));
            dt.Columns.Add("city", typeof(string));
            dt.Columns.Add("state", typeof(string));
            dt.Columns.Add("country", typeof(string));
            dt.Columns.Add("idproof", typeof(string));
            dt.Columns.Add("iddata", typeof(string));
            dt.Columns.Add("mobileno", typeof(string));
            dt.Columns.Add("email", typeof(string));
            dt.Columns.Add("pax", typeof(string));
            dt.Columns.Add("paxadult", typeof(string));
            dt.Columns.Add("paxchild", typeof(string));
            dt.Columns.Add("adult", typeof(string));
            dt.Columns.Add("child", typeof(string));
            dt.Columns.Add("racktarrif", typeof(Decimal));
            dt.Columns.Add("rextraadult", typeof(Decimal));
            dt.Columns.Add("rextrachild", typeof(Decimal));
            dt.Columns.Add("chartarrif", typeof(Decimal));
            dt.Columns.Add("cextraadult", typeof(string));
            dt.Columns.Add("cextrachild", typeof(string));
            dt.Columns.Add("plancode", typeof(string));
            dt.Columns.Add("tax", typeof(string));
            dt.Columns.Add("status", typeof(string));
            dt.Columns.Add("scantry", typeof(string));
            dt.Columns.Add("market", typeof(string));
            dt1.Columns.Add("room", typeof(string));
            dt1.Columns.Add("pax", typeof(string));
            dt1.Columns.Add("adult", typeof(string));
            dt1.Columns.Add("child", typeof(string));
            dt1.Columns.Add("rtarrif", typeof(Decimal));
            dt1.Columns.Add("radult", typeof(Decimal));
            dt1.Columns.Add("rchild", typeof(Decimal));
            dt1.Columns.Add("ctarrif", typeof(Decimal));
            dt1.Columns.Add("cadult", typeof(string));
            dt1.Columns.Add("cchild", typeof(string));
            dt1.Columns.Add("tax", typeof(string));
            dt1.Columns.Add("plan", typeof(string));
            deseble();
        }
        public void deseble()
        {
            txtpax.IsEnabled = false;
            txtadult.IsEnabled = false;
            txtchildd.IsEnabled = false;
            RACKTARRIF.IsEnabled = false;
            RACKADULT.IsEnabled = false;
            RACKCHILD.IsEnabled = false;
            CHARGETARRIF.IsEnabled = false;
            CHARGEADULT.IsEnabled = false;
            CHARGECHILD.IsEnabled = false;
        }
        public void timer_Elasped(object sender, ElapsedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                //spin.Visibility = Visibility.Hidden;
                Send_SMS();
                clear();
            }));
        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                error++;
            else
                error--;
        }
        private void txtproof_LostFocus(object sender, RoutedEventArgs e)
        {
            Binding b = new Binding();
            if (idproof.Text == "Aadhar")
            {
                b.Source = daa;
                daa.Addharcard = txtproof.Text;
                b.Path = new PropertyPath("Addharcard");
                b.NotifyOnValidationError = true;
                b.ValidatesOnDataErrors = true;
                BindingOperations.SetBinding(txtproof, TextBox.TextProperty, b);
            }
            else if (idproof.Text == "Pancard")
            {
                b.Source = daa;
                daa.Pancard = txtproof.Text;
                b.Path = new PropertyPath("Pancard");
                b.NotifyOnValidationError = true;
                b.ValidatesOnDataErrors = true;
                BindingOperations.SetBinding(txtproof, TextBox.TextProperty, b);
            }
            else if (idproof.Text == "DrivingLicense")
            {
                b.Source = daa;
                daa.Driving = txtproof.Text;
                b.Path = new PropertyPath("Driving");
                b.NotifyOnValidationError = true;
                b.ValidatesOnDataErrors = true;
                BindingOperations.SetBinding(txtproof, TextBox.TextProperty, b);
            }
            else if (idproof.Text == "Voterid")
            {
                b.Source = daa;
                daa.Voterid = txtproof.Text;
                b.Path = new PropertyPath("Voterid");
                b.NotifyOnValidationError = true;
                b.ValidatesOnDataErrors = true;
                BindingOperations.SetBinding(txtproof, TextBox.TextProperty, b);
            }
            else if (idproof.Text == "Passport")
            {
                b.Source = daa;
                daa.Passport = txtproof.Text;
                b.Path = new PropertyPath("Passport");
                b.NotifyOnValidationError = true;
                b.ValidatesOnDataErrors = true;
                BindingOperations.SetBinding(txtproof, TextBox.TextProperty, b);
            }
            else { }
        }
        private void errbtn_Click(object sender, RoutedEventArgs e)
        {
            pop1.IsOpen = false;
        }
        private void txtfirstname_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
        private void btntd_Click(object sender, RoutedEventArgs e)
        {
            poptp.IsOpen = true;
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
        private void btnupload_Click(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog dlg = new OpenFileDialog();
            //dlg.InitialDirectory = "c:\\";
            //dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            //dlg.RestoreDirectory = true;

            //if (dlg.ShowDialog() == true)
            //{
            //    string selectedFileName = dlg.FileName;
            //    String S = selectedFileName;
            //    gc.IMAGE = S;
            //    BitmapImage bitmap = new BitmapImage();
            //    bitmap.BeginInit();
            //    bitmap.UriSource = new Uri(dlg.FileName);
            //    bitmap.EndInit();
            //    IMAGE.Source = bitmap;
            // }
        }
        public void clear()
        {
            tbgck.Text = "";
            select.Text = "";
            txtfirstname.Text = "";
            txtlastname.Text = "";
            ADDRESS.Text = "";
            ZIP.Text = "";
            txtcity.Text = "";
            txtstate.Text = "";
            txtcountry.Text = "";
            idproof.Text = "";
            txtproof.Text = "";
            txtmobileno.Text = "";
            txtemail.Text = "";
            txtpax.Text = "";
            status.Text = "";
            scantybaggage.Text = "";
            txtmarketseg.Content = "";
            txtpax.Text = "";
            txtadult.Text = "";
            txtchildd.Text = "";
            RACKTARRIF.Text = "";
            RACKADULT.Text = "";
            RACKCHILD.Text = "";
            CHARGETARRIF.Text = "";
            CHARGEADULT.Text = "";
            CHARGECHILD.Text = "";
           // spin.Visibility = Visibility.Hidden;
            //this.NavigationService.Refresh();
        }
        public DataRow r;
        public decimal AdvanceAmount = 0,SubAdvanceAmount = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (error != 0 || txtfirstname.Text == "" || txtlastname.Text == "" || ADDRESS.Text == "" || ZIP.Text == "" || txtcity.Text == "" || txtmobileno.Text == "")
                {
                    pop1.IsOpen = true;
                    if (txtfirstname.Text == "")
                    { txtfirstname.Text = ""; }
                    if (txtlastname.Text == "")
                    { txtlastname.Text = ""; }
                    if (ADDRESS.Text == "")
                    { ADDRESS.Text = ""; }
                    if (ZIP.Text == "")
                    { ZIP.Text = ""; }
                    if (txtcity.Text == "")
                    { txtcity.Text = ""; }
                    if (txtmobileno.Text == "")
                    { txtmobileno.Text = ""; }
                    //if(txtpax.Text=="")
                    //{ txtpax.Text = ""; }
                    //if(txtadult.Text =="")
                    //{ txtadult.Text = ""; }
                }
                else
                {
                    pop1.IsOpen = false;
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        r = dt.NewRow();
                        if (RESERVSTIONCHECKIN.p == 1)
                        {
                            r["reservationid"] = RESERVSTIONCHECKIN.res_id;
                            gc.RESERVATION_ID = RESERVSTIONCHECKIN.res_id;
                        }
                        else
                        {
                            r["reservationid"] = "0";
                            gc.RESERVATION_ID = "0";
                        }
                        r["groupcheckin"] = tbgckn.Text;
                        r["roomno"] = dt1.Rows[i]["room"].ToString();
                        r["roomtype"] = catego[i];
                        DateTime d = Convert.ToDateTime(arrival.Content);
                        r["arrival"] = d.ToShortDateString();
                        r["atime"] = d.ToShortTimeString();
                        DateTime dd = DateTime.Today.AddDays(GroupCheckinDeparture.days);
                        r["departure"] = dd.ToShortDateString();
                        r["suffix"] = select.Text;
                        r["firstname"] = txtfirstname.Text;
                        r["lastname"] = txtlastname.Text;
                        r["address"] = ADDRESS.Text;
                        r["zip"] = ZIP.Text;
                        r["city"] = txtcity.Text;
                        r["state"] = txtstate.Text;
                        r["country"] = txtcountry.Text;
                        r["idproof"] = idproof.Text;
                        r["iddata"] = txtproof.Text;
                        r["mobileno"] = txtmobileno.Text;
                        r["email"] = txtemail.Text;
                        r["pax"] = txtpax.Text;
                        r["paxadult"] = dt1.Rows[i]["adult"];
                        r["paxchild"] = dt1.Rows[i]["child"];
                        r["adult"] = dt1.Rows[i]["adult"];
                        r["child"] = dt1.Rows[i]["child"];
                        r["racktarrif"] = dt1.Rows[i]["rtarrif"];
                        r["rextraadult"] = dt1.Rows[i]["radult"];
                        r["rextrachild"] = dt1.Rows[i]["rchild"];
                        r["chartarrif"] = dt1.Rows[i]["ctarrif"];
                        r["cextraadult"] = dt1.Rows[i]["cadult"];
                        r["cextrachild"] = dt1.Rows[i]["cchild"];
                        r["plancode"] = dt1.Rows[i]["plan"];
                        r["tax"] = dt1.Rows[i]["tax"];
                        r["status"] = status.Text;
                        r["scantry"] = scantybaggage.Text;
                        r["market"] = txtmarketseg.Content;
                        dt.Rows.Add(r);
                    }
                    if(Convert.ToInt32(gc.RESERVATION_ID) > 0)
                    {
                        DataTable dt_ad_amount = gc.GetAdvanceAmount();
                        if (dt_ad_amount.Rows[0]["AMOUNT_RECEIVED"].ToString() == "0.00" || dt_ad_amount.Rows[0]["AMOUNT_RECEIVED"].ToString() == null || dt_ad_amount.Rows[0]["AMOUNT_RECEIVED"].ToString() == "")
                        {
                            AdvanceAmount = 0;
                        }
                        else
                        {
                            AdvanceAmount = Convert.ToDecimal(dt_ad_amount.Rows[0]["AMOUNT_RECEIVED"]);
                            SubAdvanceAmount = Math.Round((AdvanceAmount / NoOfRooms),2,MidpointRounding.AwayFromZero);
                        }
                    }
                    for (int l = 0; l < dt.Rows.Count; l++)
                    {
                        gc.RESERVATION_ID = dt.Rows[l]["reservationid"].ToString();
                        gc.GROUP_CHECKINID = dt.Rows[l]["groupcheckin"].ToString();
                        gc.ROOM_NO = dt.Rows[l]["roomno"].ToString();
                        gc.ROOM_CATEGORY = dt.Rows[l]["roomtype"].ToString();
                        gc.ARRIVAL_DATE = dt.Rows[l]["arrival"].ToString();
                        gc.ARRIVAL_TIME = dt.Rows[l]["atime"].ToString();
                        gc.DEPARTURE_DATE = dt.Rows[l]["departure"].ToString();
                        gc.SUFFIX = dt.Rows[l]["suffix"].ToString();
                        gc.FIRST_NAME = dt.Rows[l]["firstname"].ToString();
                        gc.LAST_NAME = dt.Rows[l]["lastname"].ToString();
                        gc.ADDRESS = dt.Rows[l]["address"].ToString();
                        gc.ZIP = dt.Rows[l]["zip"].ToString();
                        gc.CITY = dt.Rows[l]["city"].ToString();
                        gc.STATE = dt.Rows[l]["state"].ToString();
                        gc.COUNTRY = dt.Rows[l]["country"].ToString();
                        gc.MOBILE_NO = dt.Rows[l]["mobileno"].ToString();
                        gc.EMAIL = dt.Rows[l]["email"].ToString();
                        gc.ID_PROOF = dt.Rows[l]["idproof"].ToString();
                        //gc.ID_DATA = dt.Rows[l]["iddata"].ToString();
                        gc.ID_DATA = txtproof.Text;
                        gc.PAX = txtpax.Text;
                        gc.PAXADULT = txtadult.Text;
                        gc.PAXCHILD = txtchildd.Text;
                        int r = int.Parse(txtadult.Text) + int.Parse(txtchildd.Text);
                        gc.TEXTRABED = r.ToString();
                        gc.EXTRABEDADULT = dt.Rows[l]["adult"].ToString();
                        gc.EXTRABEDCHILD = dt.Rows[l]["child"].ToString();
                        gc.PLANCODE = dt.Rows[l]["plancode"].ToString();
                        ch.FETCH_TAX(dt.Rows[l]["racktarrif"].ToString());
                        gc.TAX = ch.TAX;
                        //gc.TAX = dt.Rows[l]["tax"].ToString();
                        gc.RACK_TARIFF = Convert.ToDecimal(dt.Rows[l]["racktarrif"].ToString());
                        gc.RACK_ADULT = Convert.ToDecimal(dt.Rows[l]["rextraadult"].ToString());
                        gc.RACK_CHILD = Convert.ToDecimal(dt.Rows[l]["rextrachild"].ToString());
                        gc.CHARGED_TARIFF = Convert.ToDecimal(dt.Rows[l]["chartarrif"].ToString());
                        gc.CHARGED_ADULT = dt.Rows[l]["cextraadult"].ToString();
                        gc.CHARGED_CHILD = dt.Rows[l]["cextrachild"].ToString();
                        gc.MARKET = dt.Rows[l]["market"].ToString();
                        gc.SCANTRY = dt.Rows[l]["scantry"].ToString();
                        gc.STATUS = dt.Rows[l]["status"].ToString();

                        gc.Insert1();
                        gc.coloruppdate();
                        gc.Night_Insert();
                        if (AdvanceAmount > 0)
                        {
                            if (l == 0)
                            {
                                gc.SplitedAdvance = SubAdvanceAmount.ToString();
                                gc.AdvanceUpdate();
                            }
                            else
                            {
                                gc.SplitedAdvance = SubAdvanceAmount.ToString();
                                gc.InsertAdvance();
                            }
                        }
                        gc.RESERID = RESERVSTIONCHECKIN.res_id;
                        gc.Updatereservtion();
                    }
                    if (RESERVSTIONCHECKIN.p == 1)
                    {
                        ch.RESERVATIONINT();
                    }
                    //  spin.Visibility = Visibility.Visible;
                    t.Interval = 5000; // 5 sec
                    t.Elapsed += timer_Elasped;
                    t.Start();
                    popup_insert.IsOpen = true;
                    //this.NavigationService.Refresh();
                    Button.IsEnabled = false;
                }
            }
            catch (Exception) { }
        }
        public void Send_SMS()
        {
            DataTable landline = hotelinfo.getLandLinenumber();
            String ll_number = landline.Rows[0]["LANDLINE1"].ToString();

            String username = "9494433233";
            String password = "33233";
            String mobileNumber = "91"+txtmobileno.Text;
            String customer = "Thank you very much for choosing us! \nYour Room No's : "+tbrmst.Text+"\nAdvance Paid : 0.00 \nFor Assistance Call : "+ll_number+"";
            String url = "http://sms.zestwings.com/smpp.sms?username="+username+"&password="+password+"&to="+mobileNumber+"&from=VELSOL&text="+customer+"";

            try
            {
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(url);

                //Prepare and Add URL Encoded data
                UTF8Encoding encoding = new UTF8Encoding();
                //byte[] data = encoding.GetBytes(sbPostData.ToString());
                //Specify post method
                httpWReq.Method = "POST";
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
        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            poptp.IsOpen = false;
        }
        private void insertpop_Click(object sender, RoutedEventArgs e)
        {
            popup_insert.IsOpen = false;
            if(RESERVSTIONCHECKIN.p == 1)
            {
                RESERVSTIONCHECKIN.p = 0;
                this.NavigationService.Navigate(rec);
            }
            else
            {
                this.NavigationService.Navigate(grpc);
            }
        }
        public static string plansstate { get; set; }
        private void btnpupdt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tpax = 0;
                tadult = 0;
                tchild = 0;
                trtarrif = 0;
                trextad = 0;
                trextch = 0;
                tctarrif = 0;
                tcextad = "0";
                tcextch = "0";
                Button.IsEnabled = true;
                for (int i = 1; i < value.Length; i++)
                {
                    var room = string.Format("txtroom{0}", i);
                    var pax = string.Format("pax{0}", i);
                    var adult = string.Format("extraa{0}", i);
                    var child = string.Format("extrac{0}", i);
                    var rackta = string.Format("tarrif{0}", i);
                    var rextad = string.Format("textraa{0}", i);
                    var rextch = string.Format("textrac{0}", i);
                    var ctarrif = string.Format("ctarrif{0}", i);
                    var ctradul = string.Format("ctextraa{0}", i);
                    var ctrchld = string.Format("ctextrac{0}", i);
                    var tax = string.Format("tax{0}", i);
                    var plan = string.Format("cplan{0}", i);

                    var txtroomm = this.FindName(room);
                    var txttopax = this.FindName(pax);
                    var txtadutt = this.FindName(adult);
                    var txtchild = this.FindName(child);
                    var txtrackt = this.FindName(rackta);
                    var txtrexad = this.FindName(rextad);
                    var txtrexch = this.FindName(rextch);
                    var txtchart = this.FindName(ctarrif);
                    var txtcexad = this.FindName(ctradul);
                    var txtcexch = this.FindName(ctrchld);
                    var txttaxxx = this.FindName(tax);
                    var txtplann = this.FindName(plan);

                    string t = ((TextBlock)txtroomm).Text;
                    string a = ((TextBox)txttopax).Text;
                    string b = ((TextBox)txtadutt).Text;
                    string c = ((TextBox)txtchild).Text;
                    string d = ((TextBox)txtrackt).Text;
                    string m = ((TextBox)txtrexad).Text;
                    string f = ((TextBox)txtrexch).Text;
                    string g = ((TextBox)txtchart).Text;
                    string h = ((TextBox)txtcexad).Text;
                    string l = ((TextBox)txtcexch).Text;
                    string y = ((TextBox)txttaxxx).Text;
                    string u = ((ComboBox)txtplann).Text;
                    tpax += decimal.Parse(a);
                    if (b == "")
                    {
                        tadult = 0;
                    }
                    else
                    {
                        tadult += decimal.Parse(b);
                    }
                    if (c == "")
                    {
                        tchild = 0;
                    }
                    else
                    {
                        tchild += decimal.Parse(c);
                    }
                    trtarrif += decimal.Parse(d);
                    if (m == "")
                    {
                        trextad = 0;
                    }
                    else
                    {
                        trextad += decimal.Parse(m);
                    }
                    if (f == "")
                    {
                        trextch = 0;
                    }
                    else
                    {
                        trextch += decimal.Parse(f);
                    }
                    tctarrif += decimal.Parse(g);
                    if (h == "")
                    {
                        tcextad = "0.00";
                    }
                    else
                    {
                        tcextad += h;
                    }
                    txtpax.Text = tpax.ToString();
                    if (txtadult.Text == "")
                    {
                        txtadult.Text = "0";
                    }
                    else
                    {
                        txtadult.Text = tadult.ToString();
                    }
                    if (txtchildd.Text == "")
                    {
                        txtchildd.Text = "0";
                    }
                    else
                    {
                        txtchildd.Text = tchild.ToString();
                    }
                    RACKTARRIF.Text = trtarrif.ToString();
                    if (RACKADULT.Text == "")
                    {
                        RACKADULT.Text = "0.00";
                    }
                    else
                    {
                        RACKADULT.Text = trextad.ToString();
                    }
                    if (RACKCHILD.Text == "")
                    {
                        RACKCHILD.Text = "0.00";
                    }
                    else
                    {
                        RACKCHILD.Text = trextch.ToString();
                    }
                    if (CHARGETARRIF.Text == "0.00")
                    {
                    }
                    else
                    {
                        CHARGETARRIF.Text = tctarrif.ToString();
                    }
                    CHARGEADULT.Text = tcextad.ToString();
                    CHARGECHILD.Text = tcextch.ToString();
                    DataRow r = dt1.NewRow();
                    r["room"] = t;
                    r["pax"] = a;
                    r["adult"] = b;
                    r["child"] = c;
                    r["rtarrif"] = d;
                    r["radult"] = m;
                    r["rchild"] = f;
                    r["ctarrif"] = g;
                    r["cadult"] = h;
                    r["cchild"] = l;
                    r["tax"] = y;
                    r["plan"] = u;

                    dt1.Rows.Add(r);
                }
                poptp.IsOpen = false;
            }
            catch (Exception) { }
        }
        public int udf = 4;
        //*****************************************************Methods To Display Data For Tarrif's Popup**************************************************************//

        public void Rooms()           //To Display Rooms In Tarrif Popup
        {
            for(int i = 1; i < value.Length; i++)
            {
                var textblock = string.Format("txtroom{0}", i);
                var txtroo = this.FindName(textblock);
                if(txtroo is TextBlock)
                {
                    ((TextBlock)txtroo).Text = value[i];
                    ((TextBlock)txtroo).Visibility = Visibility.Visible;
                }
            }
        }

        public void Pax()                 //To Display Pax In Tarrif Popup
        {
            for (int i = 1; i < value.Length; i++)
            {
                gc.ROOM_NO =value[i];
                gc.Getpax();

                var textbox = string.Format("pax{0}", i);
                var textboxea = string.Format("extraa{0}", i);
                var textboxec = string.Format("extrac{0}", i);

                var txtpax = this.FindName(textbox);
                var txtadult = this.FindName(textboxea);
                var txtchild = this.FindName(textboxec);

                if (txtpax is TextBox)
                {
                    ((TextBox)txtpax).Text = gc.PAX.ToString();
                    ((TextBox)txtpax).Visibility = Visibility.Visible;
                    ((TextBox)txtadult).Visibility = Visibility.Visible;
                    ((TextBox)txtchild).Visibility = Visibility.Visible;
                }
            }
        }

        public void RackTarrif()            //To Display Rack Tarrif In Tarrif Popup
        {
            for (int i = 1; i < value.Length; i++)
            {
                gc.ROOM_NO =value[i];
                gc.Getracktarrif();
                var textbox = string.Format("tarrif{0}", i);
                var textboxp = string.Format("pax{0}", i);
                var textboxc = string.Format("ctarrif{0}", i);
                var textboxca = string.Format("ctextraa{0}", i);
                var textboxcc = string.Format("ctextrac{0}", i);
                var textboxtax = string.Format("tax{0}", i);
                var txttarrif = this.FindName(textbox);
                var txtpax = this.FindName(textboxp);
                var txtcharge = this.FindName(textboxc);
                var txtchargea = this.FindName(textboxca);
                var txtchargec = this.FindName(textboxcc);
                var txttax = this.FindName(textboxtax);
                if (txttarrif is TextBox && txtcharge is TextBox)
                {
                    if(((TextBox)txtpax).Text == "1")
                    {
                        ((TextBox)txttarrif).Text = gc.SINGLERATE.ToString();
                        ((TextBox)txtcharge).Text = gc.SINGLERATE.ToString();
                        ((TextBox)txttarrif).Visibility = Visibility.Visible;
                        ((TextBox)txtcharge).Visibility = Visibility.Visible;
                        ((TextBox)txtchargea).Visibility = Visibility.Visible;
                        ((TextBox)txtchargec).Visibility = Visibility.Visible;
                    }
                    if (((TextBox)txtpax).Text == "2")
                    {
                        ((TextBox)txttarrif).Text = gc.DOUBLERATE.ToString();
                        ((TextBox)txtcharge).Text = gc.DOUBLERATE.ToString();
                        ((TextBox)txttarrif).Visibility = Visibility.Visible;
                        ((TextBox)txtcharge).Visibility = Visibility.Visible;
                        ((TextBox)txtchargea).Visibility = Visibility.Visible;
                        ((TextBox)txtchargec).Visibility = Visibility.Visible;
                    }
                    if (((TextBox)txtpax).Text == "3")
                    {
                        ((TextBox)txttarrif).Text = gc.TRIPLERATE.ToString();
                        ((TextBox)txtcharge).Text = gc.TRIPLERATE.ToString();
                        ((TextBox)txttarrif).Visibility = Visibility.Visible;
                        ((TextBox)txtcharge).Visibility = Visibility.Visible;
                        ((TextBox)txtchargea).Visibility = Visibility.Visible;
                        ((TextBox)txtchargec).Visibility = Visibility.Visible;
                    }
                    if (((TextBox)txtpax).Text == "4")
                    {
                        ((TextBox)txttarrif).Text = gc.QUADRATE.ToString();
                        ((TextBox)txtcharge).Text = gc.QUADRATE.ToString();
                        ((TextBox)txttarrif).Visibility = Visibility.Visible;
                        ((TextBox)txtcharge).Visibility = Visibility.Visible;
                        ((TextBox)txtchargea).Visibility = Visibility.Visible;
                        ((TextBox)txtchargec).Visibility = Visibility.Visible;
                    }
                }
            }
        }
        private void ctarrif1_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            chargedtarrif += decimal.Parse(tb.Text);
        }
        private void ctextraa1_LostFocus(object sender, RoutedEventArgs e)
        {
        }
        private void ctextrac1_LostFocus(object sender, RoutedEventArgs e)
        {
        }
        private void extraa1_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
      
            string[] s = Regex.Split(tb.Name, @"\D+");

            var num = s[1];

            var textboxa = string.Format("ctextraa{0}", num);
            var textboxra = string.Format("textraa{0}", num);
            var txtextraa = this.FindName(textboxa);
            var txtrextraa = this.FindName(textboxra);

            string v = ((TextBox)txtrextraa).Text;

            if(tb.Text != "")
            {
                decimal j = decimal.Parse(tb.Text);
                decimal k = decimal.Parse(v);

                ((TextBox)txtextraa).Text = (j * k).ToString();
            }
        }

        private void cplan1_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                ComboBox cb = sender as ComboBox;
                string[] s = Regex.Split(cb.Name, @"\D+");

                var num = s[1];
                var textboxc = string.Format("ctarrif{0}", num);
                var textboxp = string.Format("pax{0}", num);
                var plan = string.Format("cplan{0}", num);
                var ctarrif = string.Format("ctarrif{0}", num);
                var tct = this.FindName(plan);
                var tct1 = this.FindName(ctarrif);
                var pax = this.FindName(textboxp);
                var txtcharge = this.FindName(textboxc);
                var txtplann = this.FindName(plan);
                string v = ((TextBox)tct1).Text;
                string u = ((ComboBox)txtplann).Text;
                gc.PLANCODE = ((ComboBox)txtplann).Text;
                gc.placodeing();
                gc.plansselect();
                if (cb != null)
                {
                    if (txtcharge is TextBox)
                    {
                        int k = 4;
                        int kk = Convert.ToInt32(((TextBox)pax).Text);
                        if (((TextBox)pax).Text == "1")
                        {
                            string a = gc.SINGLERATE_PLAN.ToString();
                            if (a == "0.00")
                            {
                                ((TextBox)txtcharge).Text = v;
                            }
                            else
                            {
                                ((TextBox)txtcharge).Text = a;
                            }
                        }
                        else if (((TextBox)pax).Text == "2")
                        {
                            string b = gc.DOUBLERATE_PLAN.ToString();
                            if (b == "0.00")
                            {
                                ((TextBox)txtcharge).Text = v;
                            }
                            else
                            {
                                ((TextBox)txtcharge).Text = b;
                            }
                        }
                        else if (((TextBox)pax).Text == "3")
                        {
                            string c = gc.TRIPLERATE_PLAN.ToString();
                            if (c == "0.00")
                            {
                                ((TextBox)txtcharge).Text = v;
                            }
                            else
                            {
                                ((TextBox)txtcharge).Text = c;
                            }

                        }
                        else if (((TextBox)pax).Text == "4")
                        {
                            string d = gc.QUADRATE_PLAN.ToString();
                            if (d == "0.00")
                            {
                                ((TextBox)txtcharge).Text = v;
                            }
                            else
                            {
                                ((TextBox)txtcharge).Text = d;
                            }
                        }
                        else if (kk > k)
                        {
                            string ee = gc.COMMON_PLAN.ToString();
                            if (ee == "0.00")
                            {
                                ((TextBox)txtcharge).Text = v;
                            }
                            else
                            {
                                ((TextBox)txtcharge).Text = ee;
                            }

                        }
                    }
                }
            }
            catch (Exception) { }
            //}
        }
        private void extrac1_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBox tb = sender as TextBox;

                string[] s = Regex.Split(tb.Name, @"\D+");

                var num = s[1];

                var textboxa = string.Format("ctextrac{0}", num);
                var textboxra = string.Format("textrac{0}", num);
                var txtextraa = this.FindName(textboxa);
                var txtrextraa = this.FindName(textboxra);

                string v = ((TextBox)txtrextraa).Text;

                if (tb.Text != "")
                {
                    decimal j = decimal.Parse(tb.Text);
                    decimal k = decimal.Parse(v);

                    ((TextBox)txtextraa).Text = (j * k).ToString();
                }
            }
            catch (Exception) { }
        }

        public void RExtraBedAdult()           //To Display Rack Extra Bed Adult And Child Tarrif In Tarrof Popup
        {
            for(int i = 1; i < value.Length; i++)
            {
                var textboxa = string.Format("textraa{0}", i);
                var txtadult = this.FindName(textboxa);
                var textboxc = string.Format("textrac{0}", i);
                var txtchild = this.FindName(textboxc);
                if(txtadult is TextBox)
                {
                    ((TextBox)txtadult).Text = gc.EXTRABEDADULT.ToString();
                    ((TextBox)txtadult).Visibility = Visibility.Visible;
                }
                if(txtchild is TextBox)
                {
                    ((TextBox)txtchild).Text = gc.EXTRABEDCHILD.ToString();
                    ((TextBox)txtchild).Visibility = Visibility.Visible;
                }
            }
        }

        public void PlanCodes()               //To Display Plancodes Tarrif In Tarrif Popup
        {
            DataTable d = gc.GetPlanCodes();
            DataRow r = d.NewRow();
            r["NAME"] = "--Select A Plan--";
            d.Rows.InsertAt(r, 0);

            for(int i = 1; i < value.Length; i++)
            {
                var cmb = string.Format("cplan{0}", i);
                var cmbpln = this.FindName(cmb);
                if(cmbpln is ComboBox)
                {
                    ((ComboBox)cmbpln).ItemsSource = d.DefaultView;
                    ((ComboBox)cmbpln).Visibility = Visibility.Visible;
                }
            }
        }
        public void Tax()               //To Display Tax In Tarrof Popup
        {
            for(int i = 1; i < value.Length; i++)
            {
                var textbox = string.Format("tarrif{0}", i);
                var txttarrif = this.FindName(textbox);

                gc.ROOM_NO =value[i];
                gc.RACK_TARIFF = Convert.ToDecimal(((TextBox)txttarrif).Text);
                gc.GetTax();

                var textboxtax = string.Format("tax{0}", i);
                var txttax = this.FindName(textboxtax);

                if(txttax is TextBox)
                {
                    ((TextBox)txttax).Text = gc.TAX;
                    ((TextBox)txttax).Visibility = Visibility.Visible;
                }
            }
        }
    }
}
