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
using System.Data.SqlClient;
using HMS.Model;
using HMS.View;
using HMS.ViewModel;
using HMS.Model.Operations;
using System.Windows.Controls.Primitives;

namespace HMS.View.Operations
{
    /// <summary>
    /// Interaction logic for rcs.xaml
    /// </summary>
    public partial class rcs : Page
    {
        rcs1 RCS = new rcs1();
        //public static int i = 0, j = 0; 
        public rcs()
        {
            InitializeComponent();
            label();
            toggle();
            labelG();
            DataTable doo = RCS.geton();
            if(doo.Rows.Count==0)
            {
                rbtnsave.Content = "Save";
            }
            else
            {
                rbtnsave.Content = "Update";
            }
        }

        public void label()
        {
            WrapPanel wrap1 = new WrapPanel();
            DataTable DT1 = RCS.roomno();
            for (int o = 0; o < DT1.Rows.Count; o++)
            {
                Label lbl = new Label();
                int A = int.Parse(DT1.Rows[o]["ROOM_NO"].ToString());
                lbl.Content = A;
                lbl.Height = 35;
                lbl.Width = 70;
                lbl.Background = Brushes.White;
                lbl.Foreground = Brushes.Black;
                lbl.BorderBrush = Brushes.Black;
                lbl.FontWeight = FontWeights.Bold;
                wrap1.Orientation = Orientation.Vertical;
                lbl.Margin = new System.Windows.Thickness(100, 0, 0, 0);
                wrap1.Children.Add(lbl);
               
            }
            WRAPRS.Children.Add(wrap1);
           
        }
        public static List<string> che = new List<string>();
        public static List<string> cher = new List<string>();
        public static List<string> unche = new List<string>();
        public static List<string> uncher = new List<string>();
        public static List<string> de = new List<string>();
        public static List<string> defun = new List<string>();
        private void tog1_Checked(object sender, RoutedEventArgs e)
        {
            ToggleButton button = (ToggleButton)sender;
            button.Background = Brushes.Green;
            //button.Content = "1";
            if (che == null)
            {
                che = new List<string>();
            }
            che.Add(((ToggleButton)sender).Content.ToString());
            S1 = string.Join(",", che.ToArray());
        }

        private void tog1_Unchecked(object sender, RoutedEventArgs e)
        {
            ToggleButton button = (ToggleButton)sender;
            button.Background = Brushes.Blue;
            if (unche == null)
            {
                unche = new List<string>();
            }
            unche.Add(((ToggleButton)sender).Content.ToString());
            S2 = string.Join(",", unche.ToArray());
        }
        public void toggle()
        {
            WrapPanel wrap2 = new WrapPanel();
            StackPanel stack11 = new StackPanel();
            DataTable DT2 = RCS.roomno();
            DataTable dtr = RCS.roomnoss();
            DataTable dtg = RCS.Toggle();
            DataTable DO = RCS.geton();
            if (DO.Rows.Count == 0)
            {
                for (int p = 0; p < DT2.Rows.Count; p++)
                {
                    ToggleButton tg = new ToggleButton();
                    tg.Background = Brushes.Blue;
                    tg.Foreground = Brushes.Blue;
                    tg.Height = 35;
                    tg.Width = 180;
                    tg.Name = "Toggle1";
                    tg.Content = DT2.Rows[p]["ROOM_NO"];
                    tg.IsChecked = false;
                    for (int k = 0; k < dtg.Rows.Count; k++)
                    {
                        if (DT2.Rows[p]["ROOM_NO"].ToString() == dtg.Rows[k]["ROOM_NO"].ToString())
                        {
                            cnt++;
                            tg.IsChecked = true;
                            tg.Background = Brushes.DarkGreen;
                            tg.Foreground = Brushes.DarkGreen;
                            if (de == null)
                            {
                                de = new List<string>();
                            }
                            de.Add(tg.Content.ToString());
                            S3 = string.Join(",", de.ToArray());
                        }
                        else 
                        {
                        }
                    }
                    wrap2.Orientation = Orientation.Vertical;
                    tg.Margin = new System.Windows.Thickness(140, 0, 0, 0);
                    tg.FontWeight = FontWeights.Bold;
                    tg.FontSize = 16;
                    tg.Click += new RoutedEventHandler(tog1_click);
                    tg.Checked += new RoutedEventHandler(tog1_Checked);
                    tg.Unchecked += new RoutedEventHandler(tog1_Unchecked);
                    wrap2.Children.Add(tg);
                }
                WRAPRS.Children.Add(wrap2);
            }
            else
            {
                rbtnsave.Content = "Update";
                for (int p = 0; p < DT2.Rows.Count; p++)
                {
                    string rmn = DT2.Rows[p]["ROOM_NO"].ToString();
                    ToggleButton tg = new ToggleButton();
                    tg.Background = Brushes.Blue;
                    tg.Foreground = Brushes.Blue;
                    tg.Height = 35;
                    tg.Width = 180;
                    tg.Name = "Toggle1";
                    tg.Content = DT2.Rows[p]["ROOM_NO"];
                    tg.IsChecked = false;
                    for (int k = 0; k < DO.Rows.Count; k++)
                    {
                        if (DT2.Rows[p]["ROOM_NO"].ToString()==DO.Rows[k]["ROOM_NO"].ToString())
                        {
                            cnt++;
                            tg.IsChecked = true;
                            tg.Background = Brushes.DarkGreen;
                            tg.Foreground = Brushes.DarkGreen;
                        }
                        else
                        { 
                        }
                    }
                    wrap2.Orientation = Orientation.Vertical;
                    tg.Margin = new System.Windows.Thickness(140, 0, 0, 0);
                    tg.FontWeight = FontWeights.Bold;
                    tg.FontSize = 16;
                    tg.Checked += new RoutedEventHandler(tog1_Checked);
                    tg.Unchecked += new RoutedEventHandler(tog1_Unchecked);
                    wrap2.Children.Add(tg);
                    bool existss = dtr.Select().ToList().Exists(row => row["ROOM_NO"].ToString().ToUpper() == rmn);
                    if (existss == true)
                    {
                    }
                    else
                    {
                        if (defun == null)
                        {
                            defun = new List<string>();
                        }
                        defun.Add(tg.Content.ToString());
                        S4 = string.Join(",", defun.ToArray());
                    }
                }
                WRAPRS.Children.Add(wrap2);
            }
        }
        public string A, A1,S1,S2,S3,S4,SC,SU;
        public static int k = 0,cnt=0,R=0,W=0;
        public void labelG()
        {
            WrapPanel wrap3 = new WrapPanel();
            DataTable DT11 = RCS.roomno();
            DataTable DTG = RCS.GUEST();
            k = 0;
            for (int q = 0; q < DT11.Rows.Count; q++)
            {
                Label lblG = new Label();
                lblG.Height = 35;
                lblG.Width = 70;
                lblG.Background = Brushes.White;
                lblG.Foreground = Brushes.Black;
                lblG.BorderBrush = Brushes.Black;
                lblG.FontWeight = FontWeights.Bold;
                lblG.Content = "";
                for (int r = 0; r < DTG.Rows.Count; r++)
                {
                    if (DT11.Rows[q]["ROOM_NO"].ToString() == DTG.Rows[r]["ROOM_NO"].ToString())
                    {
                        A = DTG.Rows[r]["FIRSTNAME"].ToString();
                        lblG.Content = A;
                    }
                    else
                    {
                    }
                }
                lblG.Margin = new System.Windows.Thickness(140, 0, 0, 0);
                wrap3.Orientation = Orientation.Vertical;
                wrap3.Children.Add(lblG);
            }
            WRAPRS.Children.Add(wrap3);
        }
        public string[] X1, Y1, N1,W1,U1;
        private void rbtnsave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable dtg1 = RCS.Toggle();
                DataTable DT21 = RCS.roomno();
                if (S1 != null)
                {
                    string X = S1.ToString();
                    X1 = X.Split(',');
                }
                else { }
                if (S2 != null)
                {
                    string W = S2.ToString();
                    W1 = W.Split(',');
                }
                else { }
                if (S3 != null)
                {
                    string Y = S3.ToString();
                    Y1 = Y.Split(',');
                }
                else { }
                if (S4 != null)
                {
                    string U = S4.ToString();
                    U1 = U.Split(',');
                }
                else { }

                string N = String.Concat(S1 + ',' + S3);
                N1 = N.Split(',');
                Array.Sort(N1);

                DataTable dtt = new DataTable();
                dtt.Columns.Add("mycol");
                if (N1 != null)
                {
                    foreach (string val in N1)
                    {
                        dtt.Rows.Add(val);
                    }
                }
                else { }
                R = 0;
                if (rbtnsave.Content.ToString() == "Save")
                {
                    for (int i = 0; i < DT21.Rows.Count; i++)
                    {
                        for (int j = 0; j < N1.Length; j++)
                        {
                            RCS.ROOM_NO = DT21.Rows[i]["ROOM_NO"].ToString();
                            bool exists1 = dtt.Select().ToList().Exists(row => row["mycol"].ToString().ToUpper() == RCS.ROOM_NO);
                            if (exists1 == true)
                            {
                                RCS.STATUS = "1";
                            }
                            else
                            {
                                RCS.STATUS = "0";
                            }
                            RCS.INSERT();
                            i++;
                        }
                        T = i--;
                        for (int k = T; k < DT21.Rows.Count; k++)
                        {
                            RCS.ROOM_NO = DT21.Rows[k]["ROOM_NO"].ToString();
                            bool exists = dtt.Select().ToList().Exists(row => row["mycol"].ToString().ToUpper() == RCS.ROOM_NO);
                            if (exists == true)
                            {
                                RCS.STATUS = "1";
                            }
                            else
                            {
                                RCS.STATUS = "0";
                            }
                            RCS.INSERT();
                        }
                        break;
                    }
                    MessageBox.Show("Inserted successfully");

                }
                else
                {
                    if (S1 != null)
                    {
                        for (int i = 0; i < X1.Length; i++)
                        {
                            rcs1.rm = X1[i];
                            RCS.UPDATE();
                            RCS.UPDATEHOME();

                        }
                    }
                    else
                    {

                    }
                    if (S2 != null)
                    {
                        for (int j = 0; j < W1.Length; j++)
                        {
                            rcs1.rmm = W1[j];
                            RCS.UPDATE0();
                            RCS.UPDATEBLUE();
                        }
                    }
                    if (S4 != null)
                    {
                        for (int k = 0; k < U1.Length; k++)
                        {
                            rcs1.ru = U1[k];
                            rcs1.STS = "0";
                            RCS.INSERTU();
                        }
                    }
                    MessageBox.Show("Updated successfully");
                    S1 = S2 = S4 = null;
                }
            }
            catch (Exception) { }
        }
        public static int tog,T;
        private void tog1_click(object sender, RoutedEventArgs e)
        {
        }
    }
}
