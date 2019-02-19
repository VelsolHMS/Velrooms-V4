using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using HMS.Model;
using System.Data;

namespace HMS.View.Operations
{
    /// <summary>
    /// Interaction logic for Vacant.xaml
    /// </summary>
    public partial class Vacant : Page
    {
        Entireroom ENT = new Entireroom();
        Checkin ch = new Checkin();
        
        RESERVATION r = new RESERVATION();
        List<String> LI = new List<string>();
        public static string roomnos;
        public static int days, w = 0;
        public int j, k, b;
        public Vacant()
        {
            InitializeComponent(); foreach (var key in l.Keys.ToList())
                // l[key] = null;
                l.Remove(key);
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                String s = null;
                DataTable dt = ENT.GET_ROOMCATEGORY();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    s = dt.Rows[i]["ROOM_CATEGORY"].ToString();
                    if (LI.Contains(s)) { }
                    else
                    {
                        LI.Add(s);
                        Label LB = new Label();
                        LB.Content = s;
                        LB.FontSize = 10;
                        LB.Width = 100;
                        LB.FontWeight = FontWeights.Bold;
                        //LB.Margin = new System.Windows.Thickness(0, 0, 15, 0);
                        WrapPanel WP = new WrapPanel();
                        WP.Orientation = Orientation.Horizontal;
                        WP.Margin = new System.Windows.Thickness(0, 0, 10, 8);
                        WP.Children.Add(LB);
                        DataTable DT = ENT.GET_ROOM_NO_COLOR(s);
                        for (int J = 0; J < DT.Rows.Count; J++)
                        {
                            int ROOMNO = Convert.ToInt16(DT.Rows[J]["ROOM_NO"]);
                            Button BT = new Button();
                            BT.Click += new RoutedEventHandler(Green_click);
                            BT.Height = 24; BT.Width = 70;
                            BT.Margin = new System.Windows.Thickness(2, 0, 2, 0);
                            BT.Padding = new System.Windows.Thickness(0, -3, 0, 0);
                            BT.Content = ROOMNO;
                            BT.FontSize = 15;
                            BT.Background = Brushes.DarkGreen;
                            BT.BorderBrush = Brushes.DarkGreen;
                            WP.Children.Add(BT);
                        }
                        WRAP.Children.Add(WP);
                    }
                }
                j = GroupCheckinDeparture.rooms;
                if (j != 0)
                {
                    count.Text = "You can book '" + j + "' Rooms";
                    countstk.Visibility = Visibility.Visible;
                }
                else
                {
                    countstk.Visibility = Visibility.Hidden;
                }
                k = j;
                //r.RESERVATIONID = RESERVSTIONCHECKIN.RESERVATIONID.ToString();
                //r.NO_OFROOMS();
                //b = RESERVATION.room;
            }
            catch (Exception) { }
        }
        public static string[] values;
        public static int roomno = 0; public static string ROOMTYPE = null; public int COUNT = 1;
        public static Dictionary<int, string> l = new Dictionary<int, string>();
        public static int room_no;
        public static string ctg;
        protected void Green_click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (GroupCheckinDeparture.group == 1)
                {
                    if (j != 0)
                    {
                        var button = sender as Button;
                        if (button.Background == Brushes.Gray)
                        {
                            MessageBox.Show("This Room is already Selected!");
                        }
                        else
                        {
                            button.Background = Brushes.Gray;
                            roomnos += " " + button.Content;
                            j--;
                            count.Text = "You Can Book '" + j + "' Rooms";
                        }
                    }
                    else
                    {
                        count.Text = "You Can Book '" + j + "' Rooms";
                    }
                    if (j == 0)
                    {
                        grpchkn gc = new grpchkn();
                        //if (RESERVSTIONCHECKIN.p == 1)
                        //{
                        //    int s = RESERVSTIONCHECKIN.noofrooms;
                        //}
                        this.NavigationService.Navigate(gc);
                    }
                    else
                    {
                        count.Text = "You Can Book '" + j + "' Rooms Only";
                    }
                }
                else
                {
                    var button = sender as Button;
                    roomno = Convert.ToInt16(button.Content);
                    room_no = Convert.ToInt16(button.Content);
                    button.IsEnabled = false;
                    button.Foreground = Brushes.White;
                    if (RESERVSTIONCHECKIN.p == 1 && CheckinDeparture.p == 1)
                    {
                        int s = RESERVSTIONCHECKIN.noofrooms;
                        if (COUNT > 0 && COUNT <= s)
                        {
                            int a = COUNT + 1;
                            count.Text = "You Can Book '" + a + "' Room";
                            DataTable dt = ENT.GET_ROOMCATEGORY_VACANT_ROOM(roomno);
                            ROOMTYPE = dt.Rows[0]["ROOM_CATEGORY"].ToString();

                            l.Add(roomno, ROOMTYPE);
                            if (COUNT == s)
                            {
                                popup.IsOpen = false;
                                Checkin ch = new Checkin();
                                //String time = DateTime.Now.ToString("h:mm:ss tt");
                                ch.arrival.Text = RESERVSTIONCHECKIN.arraivaldate;
                                ch.departure.Text = RESERVSTIONCHECKIN.departuredate;
                                ch.reservationid.Text = RESERVSTIONCHECKIN.res_id;
                                ch.roomcategory.Text = ROOMTYPE;
                                ch.roomno.Text = roomno.ToString();
                                ch.departure.Text = RESERVSTIONCHECKIN.departuredate;
                                ch.txtcompany.Text = RESERVSTIONCHECKIN.company_name;
                                ch.companyADDRESS.Text = RESERVSTIONCHECKIN.company_address;
                                ch.txtfirstname.Text = RESERVSTIONCHECKIN.firstname;
                                ch.txtlastname.Text = RESERVSTIONCHECKIN.lastname;
                                ch.ZIP.Text = RESERVSTIONCHECKIN.zip;
                                ch.txtmobileno.Text = RESERVSTIONCHECKIN.mobile;
                                ch.txtemail.Text = RESERVSTIONCHECKIN.email;
                                ch.txtcity.Text = RESERVSTIONCHECKIN.city;
                                ch.ADDRESS.Text = RESERVSTIONCHECKIN.address;
                                ch.txtstate.SelectedItem = RESERVSTIONCHECKIN.state;
                                ch.txtcountry.SelectedItem = RESERVSTIONCHECKIN.country;
                                //ch.idproof.Text = RESERVSTIONCHECKIN.Idproof;
                                //ch.txtproof.Text = RESERVSTIONCHECKIN.IdNumber;
                                ch.txtadult.Text = RESERVSTIONCHECKIN.adult;
                                ch.txtchild.Text = RESERVSTIONCHECKIN.child;
                                ch.txtpax.Text = RESERVSTIONCHECKIN.pax;
                                this.NavigationService.Navigate(ch);
                            }
                            else
                            {
                                popup.IsOpen = true;
                            }
                        }
                        else
                        {
                            popup.IsOpen = false;
                        }
                        COUNT++;
                    }
                    else if (CheckinDeparture.p == 1 && RESERVSTIONCHECKIN.p == 0)
                    {
                        DataTable dt = ENT.GET_ROOMCATEGORY_VACANT_ROOM(roomno);
                        ROOMTYPE = dt.Rows[0]["ROOM_CATEGORY"].ToString();
                        ctg = ROOMTYPE;
                        Checkin ch = new Checkin();
                        this.NavigationService.Navigate(ch);
                    }
                }
            }
            catch (Exception) { }
        }
    }
}