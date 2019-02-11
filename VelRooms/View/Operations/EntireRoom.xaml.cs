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
using System.Data;
using HMS.Model;

namespace HMS.View.Operations
{
    /// <summary>
    /// Interaction logic for EntireRoom.xaml
    /// </summary>
    public partial class EntireRoom : Page
    {
        Entireroom ENT = new Entireroom();
        List<String> LI = new List<string>();
        public EntireRoom()
        {
            InitializeComponent();
            roomno.IsEnabled = false;
            guestname.IsEnabled = false;
            string s = null;
            //   ROW.Height = new GridLength(8 + I, GridUnitType.Star);
            DataTable dt = ENT.GET_ROOMCATEGORY();
            ENT.night_auditing();
            int row = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                s = dt.Rows[i]["ROOM_CATEGORY"].ToString();
                if (LI.Contains(s)) { }
                else
                {

                    LI.Add(s);
                    int NO_OF_ROOMS = 0;
                    Label LB = new Label();
                    LB.Content = s;
                    LB.FontSize = 15;
                    LB.Width = 90;
                    LB.FontWeight = FontWeights.Bold;
                    // LB.Margin = new System.Windows.Thickness(0, 0, 15, 0);
                    WrapPanel WP = new WrapPanel();
                    WP.Orientation = Orientation.Horizontal;
                    WP.Margin = new System.Windows.Thickness(0, 0, 20, 8);
                    Grid g = new Grid();
                    g.Children.Add(WP);
                    WP.Children.Add(LB);
                    Label L = new Label();
                    string K = ":";
                    L.Content = s + " " + K;
                    L.FontWeight = FontWeights.Bold;
                    L.FontSize = 15;
                    CATEGORY.Children.Add(L);
                    DataTable DT = ENT.GET_ROOM_NO(s);
                    for (int J = 0; J < DT.Rows.Count; J++)
                    {
                        int ROOMNO = Convert.ToInt16(DT.Rows[J]["ROOM_NO"]);
                        Button BT = new Button();
                        BT.Height = 24; BT.Width = 70;
                        BT.Margin = new System.Windows.Thickness(2, 0, 2, 0);
                        BT.Content = ROOMNO;
                        BT.FontSize = 15;
                        string S = ENT.GET_BACKGROUND_COLOR(ROOMNO);
                        SET_COLOR(S, BT);
                        WP.Children.Add(BT);
                        NO_OF_ROOMS = J + 1;
                    }
                    Label LBL = new Label();
                    LBL.Content = NO_OF_ROOMS;
                    LBL.FontWeight = FontWeights.Bold;
                    LBL.FontSize = 15;
                    CATEGORY.Children.Add(LBL);
                    RowDefinition rd = new RowDefinition();
                    rd.Height = new GridLength(20, GridUnitType.Star);
                    g.RowDefinitions.Add(rd);
                    WRAP.Children.Add(g);
                    Grid.SetRow(g, row);
                    row++;
                }
            }
        }
        public int Green = 0; public int orange = 0; public int red = 0; public int blue = 0;
        public int gray = 0; public int pink = 0;
        public void SET_COLOR(string S, Button bt)
        {
            switch (S)
            {
                case "Green":
                    bt.Background = Brushes.DarkGreen;
                    bt.BorderBrush = Brushes.DarkGreen;
                    bt.Click += new RoutedEventHandler(Green_click);
                    Green++;
                    break;
                case "Orange":
                    bt.Background = Brushes.Orange;
                    bt.Click += new RoutedEventHandler(Orange_click);
                    orange++;
                    break;
                case "Red":
                    bt.Background = Brushes.Red;
                    bt.Foreground = Brushes.White;
                    bt.Click += new RoutedEventHandler(Red_click);
                    red++;
                    break;
                case "Pink":
                    bt.Background = Brushes.LightPink;
                    bt.Click += new RoutedEventHandler(Pink_click);
                    pink++;
                    break;
                case "Blue":
                    bt.Background = Brushes.Blue;
                    bt.Click += new RoutedEventHandler(Blue_click);
                    blue++;
                    break;
                case "Gray":
                    bt.Background = Brushes.Gray;
                    bt.Click += new RoutedEventHandler(Gray_click);
                    gray++;
                    break;
            }
            VACANT.Content = Green; VACANT.Focusable = true;
            OCCUPIED.Content = orange;
            MAINTANANCE.Content = red;
            MANAGEMENT.Content = pink;
            BLUE.Content = blue;
            GRAY.Content = gray;
        }
        protected void Green_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("iam green");
        }
        protected void Orange_click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button bt = sender as Button;
                string s = bt.Content.ToString();
                roomno.Text = s;
                DataTable D = ENT.get_details(Convert.ToInt16(s));
                if (D != null)
                {
                    guestname.Text = D.Rows[0]["FIRSTNAME"] + " " + D.Rows[0]["LASTNAME"];
                    arrivaldate.Content = D.Rows[0]["ARRIVAL_DATE"];
                    departuredate.Content = D.Rows[0]["DEPARTURE_DATE"];
                }
            }
            catch (Exception) { }
        }
        protected void Red_click(object sender, RoutedEventArgs e)
        {
        }
        protected void Pink_click(object sender, RoutedEventArgs e)
        {
        }
        protected void Blue_click(object sender, RoutedEventArgs e)
        {
          
        }
        protected void Gray_click(object sender, RoutedEventArgs e)
        {
        }
    }
}
