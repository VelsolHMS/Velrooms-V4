using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using HMS.Model;
using HMS.View.Masters;
using HMS.ViewModel;

namespace HMS.View.Operations
{
    /// <summary>
    /// Interaction logic for ROOMCHANGE.xaml
    /// </summary>
    public partial class ROOMCHANGE : Page
    {
        Checksin ch = new Checksin();
        public string s1, s2, s3, s4, t1, t2, t3, t4;
        public int error = 0;
        public void CLEARS()
        {
            txtmainroom.Text = "";
            txttransferroom.Text = "";
            txtguestname.Text = "";
            txtgueststatus.Text = "";
            txtarrivaldate.Text = "";
            txtdeparturedate.Text = "";
            txtguestname1.Text = "";
            txtgueststatus1.Text = "";
            txtarrivaldate1.Text = "";
            txtdeparturedate1.Text = "";
            txtguestname2.Text = "";
            txtgueststatus2.Text = "";
            txtarrivaldate2.Text = "";
            txtdeparturedate2.Text = "";
            txtswap.Text = "";
            this.NavigationService.Refresh();
        }
        public ROOMCHANGE()
        {
            data.COUNT = 0;
            InitializeComponent();
            data.COUNT = 1;
            // FALSE();
            ENABLE.IsChecked = true;
            swap.Content = "transfer";
        }
        private void ENABLE_Checked(object sender, RoutedEventArgs e)
        {
            groupbox.Visibility = Visibility.Visible;
            swaproom.Visibility = Visibility.Hidden;
            swap_icon.Visibility = Visibility.Hidden;
            txtswap.Visibility = Visibility.Hidden;
            transfer.Visibility = Visibility.Visible;
            txttransferroom.Visibility = Visibility.Visible;
            swap.Content = "transfer";
            // CLEARS(); 
            //txtmainroom.Text = "";
            //txttransferroom.Text = "";
        }
        private void txttransferroom_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Checksin c = new Checksin();
                DataTable dt = c.roomchange();
                if (dt.Rows.Count == 0)
                {
                    if (txtmainroom.Text == txttransferroom.Text)
                    {
                        txttransferroom.Text = "";
                        //MessageBox.Show("please enter the vacant room ?");
                        pop2.IsOpen = true;
                    }
                    else
                    {
                    }
                }
                else
                {
                    txttransferroom.Text = "";
                    //MessageBox.Show("please enter the vacant room");
                    pop2.IsOpen = true;
                }
            }
            catch (Exception) { }
        }
        private void DISEBLE_Checked(object sender, RoutedEventArgs e)
        {
            groupbox.Visibility = Visibility.Hidden;
            swaproom.Visibility = Visibility.Visible;
            swap_icon.Visibility = Visibility.Visible;
            txtswap.Visibility = Visibility.Visible;
            transfer.Visibility = Visibility.Hidden;
            txttransferroom.Visibility = Visibility.Hidden;
            swap.Content = "swap";
            //CLEARS();
            //txtmainroom.Text = "";
            //txtswap.Text = "";
        }
        private void Error_Click(object sender, RoutedEventArgs e)
        {
            pop2.IsOpen = false;
        }

        private void Error1_Click(object sender, RoutedEventArgs e)
        {
            pop3.IsOpen = false;
        }

        private void txtmainroom_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Checksin c = new Checksin();
                c.ROOM_NO = txtmainroom.Text;
                DataTable dt = c.roomchange();
                if (dt.Rows.Count == 0)
                {
                    txtmainroom.Text = "";
                    pop3.IsOpen = true;
                    //MessageBox.Show("Please Enter the Occupied Room");
                }
                else
                {
                    txtguestname.Text = dt.Rows[0]["FIRSTNAME"].ToString();
                    txtgueststatus.Text = dt.Rows[0]["STATUS"].ToString();
                    txtarrivaldate.Text = dt.Rows[0]["ARRIVAL_DATE"].ToString();
                    txtdeparturedate.Text = dt.Rows[0]["DEPARTURE_DATE"].ToString();
                    txtguestname1.Text = dt.Rows[0]["FIRSTNAME"].ToString();
                    txtgueststatus1.Text = dt.Rows[0]["STATUS"].ToString();
                    txtarrivaldate1.Text = dt.Rows[0]["ARRIVAL_DATE"].ToString();
                    txtdeparturedate1.Text = dt.Rows[0]["DEPARTURE_DATE"].ToString();
                }
            }
            catch (Exception) { }
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
        private void CLEAR_Click(object sender, RoutedEventArgs e)
        {
            CLEARS();
        }
        public static decimal cunt1;
        private void Swap_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            if (error != 0 || (ENABLE.IsChecked == true && txtmainroom.Text == "") || (ENABLE.IsChecked == true && txttransferroom.Text == "") || (DISEBLE.IsChecked == true && txtmainroom.Text == "") || (DISEBLE.IsChecked == true && txtswap.Text == ""))
            {
                if (ENABLE.IsChecked == true)
                {
                    if (txtmainroom.Text == "")
                    { txtmainroom.Text = ""; }
                    if (txttransferroom.Text == "")
                    { txttransferroom.Text = ""; }
                }
                if (DISEBLE.IsChecked == true)
                {
                    if (txtmainroom.Text == "")
                    { txtmainroom.Text = ""; }
                    if (txtswap.Text == "")
                    { txtswap.Text = ""; }
                }
            }
            else
            {
                if (swap.Content.ToString() == "transfer")
                {
                    //new code for Room Transfer
                    ROOMCHANGE1 RM_T = new ROOMCHANGE1();
                    RM_T.MAINROOM = txtmainroom.Text;
                    DataTable dt = RM_T.GetRoomDetails();
                    if (dt.Rows.Count > 0)
                    {
                        RM_T.ROOM_CHANGE = "Transfer";
                        RM_T.TRANSFERROOM = txttransferroom.Text;
                        RM_T.FROM_GUESTNAME = txtguestname.Text;
                        RM_T.FROM_GUESTSTATUS = txtgueststatus.Text;
                        RM_T.RM_CHECKINID = dt.Rows[0]["CHECKIN_ID"].ToString();
                        RM_T.FROM_ARRIVALDATE = Convert.ToDateTime(txtarrivaldate.Text);
                        RM_T.FROM_DEPARTUREDATE = Convert.ToDateTime(txtdeparturedate.Text);
                        RM_T.TransferInsert();
                        RM_T.Rm_ChargedTariff = RM_T.GetTariff();
                        ch.FETCH_TAX(RM_T.Rm_ChargedTariff.ToString());
                        RM_T.Rm_GST = ch.TAX;
                        RM_T.UpdateNightAudit();
                        RM_T.UpdateAdvance();
                        RM_T.UpdatePostCharges();
                        RM_T.UpdateDiscount();
                        RM_T.UpdatecheckinDetails();
                        RM_T.UpdateMRColor();
                        RM_T.UpdateTRColor();
                    }
                    else
                    {
                        MessageBox.Show("This room is vacant");
                    }
                    //old code for Room Transfer.
                    //ROOMCHANGE1 RM = new ROOMCHANGE1();
                    //RM.MAINROOM = txtmainroom.Text;
                    //RM.ROOM_CHANGE = "transfer";
                    //RM.TRANSFERROOM = txttransferroom.Text;
                    //RM.FROM_GUESTNAME = txtguestname.Text;
                    //RM.FROM_GUESTSTATUS = txtgueststatus.Text;
                    //RM.FROM_ARRIVALDATE = Convert.ToDateTime(txtarrivaldate.Text);
                    //RM.FROM_DEPARTUREDATE = Convert.ToDateTime(txtdeparturedate.Text);
                    //RM.INSERT_BY = login.u;
                    //RM.INSERT_DATE = DateTime.Today.Date;
                    //RM.INSERT();

                    //Checksin c = new Checksin();
                    //c.ROOM_NO = txttransferroom.Text;
                    //c.FIRSTNAME = txtguestname.Text;
                    //c.ARRIVAL_DATE = Convert.ToDateTime(txtarrivaldate.Text.ToString());
                    //c.DEPARTURE_DATE = Convert.ToDateTime(txtdeparturedate.Text.ToString());
                    /////c.INSERT();
                    //RM.insertcheckin();
                    //RM.updatemainroom();
                    //RM.INSERTDATENIGHT();
                    //DataTable d = RM.count();
                    //if (DateTime.Today.Date > ROOMCHANGE1.c)
                    //{
                    //    if (d.Rows.Count == 0)
                    //    {
                    //        cunt1 = decimal.Parse("0.00");
                    //    }
                    //    else
                    //    {
                    //        cunt1 = Convert.ToDecimal(d.Rows[0]["ROOM_TARRIF"]);
                    //    }
                    //}
                    //else
                    //{
                    //    cunt1 = decimal.Parse("0.00");
                    //}
                    //RM.night();
                    //RM.night1();
                    //RM.UPDATECOLOR();
                    CLEARS();
                }
                if (swap.Content.ToString() == "swap")
                {
                    s1 = txtguestname1.Text;
                    s2 = txtgueststatus1.Text;
                    s3 = txtarrivaldate1.Text;
                    s4 = txtdeparturedate1.Text;
                    t1 = txtguestname2.Text;
                    t2 = txtgueststatus2.Text;
                    t3 = txtarrivaldate2.Text;
                    t4 = txtdeparturedate2.Text;
                    txtguestname1.Text = t1;
                    txtgueststatus1.Text = t2;
                    txtarrivaldate1.Text = t3;
                    txtdeparturedate1.Text = t4;
                    txtguestname2.Text = s1;
                    txtgueststatus2.Text = s2;
                    txtdeparturedate2.Text = s3;
                    txtarrivaldate2.Text = s4;

                    ROOMCHANGE1 RM = new ROOMCHANGE1();
                    RM.MAINROOM = txtmainroom.Text;
                    RM.ROOM_CHANGE = "swap";
                    RM.TRANSFERROOM = txtswap.Text;
                    RM.FROM_GUESTNAME = txtguestname.Text;
                    RM.FROM_GUESTSTATUS = txtgueststatus.Text;
                    RM.FROM_ARRIVALDATE = Convert.ToDateTime(txtarrivaldate.Text);
                    RM.FROM_DEPARTUREDATE = Convert.ToDateTime(txtdeparturedate.Text);
                    RM.TO_GUESTNAME = txtguestname1.Text;
                    RM.TO_GUESTSTATUS = txtgueststatus1.Text;
                    RM.TO_ARRIVALDATE = Convert.ToDateTime(txtarrivaldate1.Text);
                    RM.TO_DEPARTUREDATE = Convert.ToDateTime(txtdeparturedate1.Text);
                    RM.INSERT_BY = login.u;
                    RM.INSERT_DATE = DateTime.Today;

                    RM.swapinsert();
                    Checksin c = new Checksin();
                    c.ROOM_NO = txtmainroom.Text;
                    RM.Swapupdate();
                    txtguestname2.Text = c.FIRSTNAME;
                    txtarrivaldate2.Text = c.ARRIVAL_DATE.ToString();
                    txtdeparturedate2.Text = c.DEPARTURE_DATE.ToString();
                    txtgueststatus2.Text = c.status;
                    c.ROOM_NO = txtswap.Text;
                    RM.Swapupdate1();
                    txtguestname1.Text = c.FIRSTNAME;
                    txtarrivaldate1.Text = c.ARRIVAL_DATE.ToString();
                    txtdeparturedate1.Text = c.DEPARTURE_DATE.ToString();
                    txtgueststatus1.Text = c.status;
                    CLEARS();
                }
            }
            //}
            //catch (Exception) { }
        }
        private void txtswap_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Checksin c = new Checksin();
                c.ROOM_NO = txtswap.Text;
                c.roomchange();
                txtguestname2.Text = c.FIRSTNAME;
                txtgueststatus2.Text = c.status;
                txtarrivaldate2.Text = Convert.ToDateTime(c.ARRIVAL_DATE).ToString();
                txtdeparturedate2.Text = Convert.ToDateTime(c.DEPARTURE_DATE).ToString();
            }
            catch (Exception) { }
        }
    }
}