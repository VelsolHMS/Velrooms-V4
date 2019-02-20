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
using HMS.View.Masters;
using System.Data;
using HMS.mainwindowpages;

namespace HMS.View.Operations
{
    /// <summary>
    /// Interaction logic for Block_Room.xaml
    /// </summary>
    public partial class Block_Room : Page
    {
        public int error = 0;
        public string maintenance, management, maintenance1, management1;

        public Block_Room()
        {
            data.COUNT = 0;
            InitializeComponent();
            clear();
            data.COUNT = 1;
            enable();
            txtroomtype.IsReadOnly = true;
           // btnsave.IsEnabled = false;
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
        //   private void btnsave_Click(object sender, RoutedEventArgs e)
        //{
        //    if (error != 0)
        //    {
        //        pop1.IsOpen = true;
        //    }
        //    else
        //    {
        //        if (rbmaintance.IsChecked == true)
        //        {
        //            maintenance = "1";
        //        }
        //        else maintenance = "0";
        //        if (rbmanagement.IsChecked == true)
        //        {
        //            management = "1";
        //        }
        //        else management = "0";

        //        blockroom br = new blockroom();

        //        br.ROOM_NO = txtroomno.Text;
        //        br.ROOM_TYPE = txtroomtype.Text;
        //        br.FROM_DATE = dpfromdate.Text;
        //        br.TO_DATE = dptodate.Text;
        //        br.MAINTANCE = maintenance.ToString();
        //        br.MANAGEMENT = management.ToString();
        //        br.REASON = txtreason.Text;
        //        //11/15/2017
        //        //br.USER_NAME = login.u;
        //        br.INSERT_BY = login.u;
        //        br.INSERT_DATE = DateTime.Today;
        //        //
        //        br.Insert();
        //        MessageBox.Show("inserted sucessfully");
        //        clear();

        //        disable();

        //        btnblock.IsEnabled = true;
        //        btnrelease.IsEnabled = true;
        //        btnsave.IsEnabled = false;

        //        this.NavigationService.Refresh();

        //        btnblock.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
        //        btnrelease.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
        //    }
        //}
        //public async Task<string> delay()
        //{
        //    clear();

        //    btnblock.IsEnabled = false;
        //    btnrelease.IsEnabled = false;
        //    btnsave.IsEnabled = false;
        //    await Task.Delay(900000);//asynchronously it is updating the color in room master after the given period of time.
        //    return "Finished";
        //}
        private void btnrelease_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                home h = new home();

                br.ROOM_NO = txtroomno.Text;
                enable();

                string St = null;

                if (rbmaintance1.IsChecked == true)
                {
                    St = "Green";
                }
                else
                {
                    St = "Blue";
                }
                Button btn = new Button();
                btn.Content = txtroomno.Text;
                br.ROOM_NO = txtroomno.Text;
                ER.SET_COLOR(St, btn);

                br.ColorUpdate(St);

                //string result = await delay();


                //string S = "Green";
                //Button bt = new Button();
                //bt.Content = txtroomno.Text;

                //br.ROOM_NO = txtroomno.Text;

                //ER.SET_COLOR(S, bt);

                //br.ColorUpdate(S);

                clear();
                h.t.Start();

                btnrelease.Background = new SolidColorBrush(Colors.Orange);
                btnblock.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            }
            catch (Exception) { }
        }
        public void UPDATEINTO_DB()
        {
            if (error != 0)
            {
                pop1.IsOpen = true;
            }
            else
            {
                if (rbmaintance.IsChecked == true)
                {
                    maintenance = "1";
                    
                }
                else
                {
                    maintenance = "0";
                    
                }
                if (rbmanagement.IsChecked == true)
                {
                    management = "1";
                }
                else
                {
                    management = "0";
                  
                }

                if (rbmaintance1.IsChecked == true)
                {
                    maintenance1 = "1";

                }
                else
                {
                    maintenance1 = "0";
                   
                }

                if (rbmanagement1.IsChecked == true)
                {
                    management1 = "1";
                }
                else
                {
                    management1 = "0";
                }
                blockroom br = new blockroom();

                br.ROOM_NO = txtroomno.Text;
                br.ROOM_TYPE = txtroomtype.Text;
                br.FROM_DATE = dpfromdate.Text;
                br.TO_DATE = dptodate.Text;
                br.MAINTANCE = maintenance.ToString();
                br.MANAGEMENT = management.ToString();
                br.MAINTANCE1 = maintenance1.ToString();
                br.MANAGEMENT1 = management1.ToString();
                br.REASON = txtreason.Text;
                //11/15/2017
                //br.USER_NAME = login.u;
                br.INSERT_BY = login.u;
                br.INSERT_DATE = DateTime.Today;
                //
                br.Insert();

                clear();

                disable();

                btnblock.IsEnabled = true;
                btnrelease.IsEnabled = true;
                //btnsave.IsEnabled = false;

                this.NavigationService.Refresh();
            }
        }
        EntireRoom ER = new EntireRoom();
        blockroom br = new blockroom();
        private void btnblock_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                br.ROOM_NO = txtroomno.Text;
                string S = null;

                int A = br.COLOR();
                if (A > 0)
                {
                    if (rbmaintance.IsChecked == true)
                    {
                        S = "Red";
                    }
                    else if (rbmanagement.IsChecked == true)
                    {
                        S = "Pink";
                    }
                    else if (rbmaintance1.IsChecked == true)
                    {
                        S = "Green";
                        // br.col();
                    }
                    else if (rbmanagement1.IsChecked == true)
                    {
                        S = "Blue";
                    }
                    Button bt = new Button();
                    bt.Content = txtroomno.Text;
                    br.ROOM_NO = txtroomno.Text;
                    ER.SET_COLOR(S, bt);
                    br.ColorUpdate(S);
                    bt.Foreground = new System.Windows.Media.SolidColorBrush(Colors.White);
                    UPDATEINTO_DB();
                    clear();

                    btnblock.IsEnabled = false;
                    btnrelease.IsEnabled = false;
                    // btnsave.IsEnabled = false;

                    btnblock.Background = new SolidColorBrush(Colors.Orange);
                    btnrelease.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                }
                else if (A == 0)
                {
                    //MessageBox.Show("The Room No which you have entered is not vacant , You can't block this room");
                    pop1.IsOpen = true;
                }
            }
            catch (Exception) { }
        }
        public void enable()
        {
            txtroomno.IsEnabled = true;
            txtroomtype.IsEnabled = true;
            dpfromdate.IsEnabled = true;
            dptodate.IsEnabled = true;
            rbmaintance.IsEnabled = true;
            rbmanagement.IsEnabled = true;
            txtreason.IsEnabled = true;
        }
        public void disable()
        {
            txtroomno.IsEnabled = false;
            txtroomtype.IsEnabled = false;
            dpfromdate.IsEnabled = false;
            dptodate.IsEnabled = false;
            rbmaintance.IsEnabled = false;
            rbmanagement.IsEnabled = false;
            txtreason.IsEnabled = false;
        }
        private void txtroomno_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtroomno.Text == null)
                {
                    txtroomno.Text = "";
                }
                else if (txtroomno.Text.Length == 3)
                {
                    blockroom br = new blockroom();
                    br.ROOM_NO = txtroomno.Text;
                    int A = br.Roomretrive();

                    if (A == 0)
                    {
                        txtroomtype.Text = br.ROOM_TYPE;
                        btnblock.IsEnabled = true; btnrelease.IsEnabled = true;
                    }
                    else if (A == 1)
                    {
                        DataTable d = br.RELEASE();
                        if (d != null)
                        {
                            txtroomno.Text = d.Rows[0]["ROOM_NO"].ToString();
                            txtroomtype.Text = d.Rows[0]["ROOM_CATEGORY"].ToString();
                            dpfromdate.Text = d.Rows[0]["FROM_DATE"].ToString();
                            dptodate.Text = d.Rows[0]["TO_DATE"].ToString();
                            int MA = Convert.ToInt16(d.Rows[0]["MAINTANCE"]);
                            if (MA == 0)
                            {
                                rbmaintance.IsChecked = false;
                            }
                            else if (MA == 1)
                            {
                                rbmaintance.IsChecked = true;
                            }
                            int MANA = Convert.ToInt16(d.Rows[0]["MANAGEMENT"]);
                            if (MANA == 0)
                            {
                                rbmanagement.IsChecked = false;
                            }
                            else if (MANA == 1)
                            {
                                rbmanagement.IsChecked = true;
                            }
                            int MA1 = Convert.ToInt16(d.Rows[0]["DIRTY"]);
                            if (MA1 == 0)
                            {
                                rbmaintance1.IsChecked = false;
                            }
                            else if (MA1 == 1)
                            {
                                rbmaintance1.IsChecked = true;
                            }
                            int MANA1 = Convert.ToInt16(d.Rows[0]["CLEAN"]);
                            if (MANA1 == 0)
                            {
                                rbmanagement1.IsChecked = false;
                            }
                            else if (MANA1 == 1)
                            {
                                rbmanagement1.IsChecked = true;
                            }
                            txtreason.Text = d.Rows[0]["REASON"].ToString();
                            //bind feteched data to textboxes .
                            btnblock.IsEnabled = true; btnrelease.IsEnabled = true;
                        }
                        else
                        {
                            //MessageBox.Show("The Room No is inavlid , please check again");
                            pop1.IsOpen = true;
                            btnblock.IsEnabled = false; btnrelease.IsEnabled = false;
                        }
                        // MessageBox.Show("The Room No Which you have entered is may be it is not vacant or incorrect");
                        pop1.IsOpen = true;
                    }
                }
            }
            catch(Exception)
            {
                //MessageBox.Show("Please Enter Valid Room No");
                pop1.IsOpen = true;
                txtroomno.Foreground = Brushes.Red;
            }
        }
        private void rbmaintance_Click(object sender, RoutedEventArgs e)
        {
            rbmaintance1.IsChecked = false;
            rbmanagement.IsChecked = false;
            rbmanagement1.IsChecked = false;
        }
        private void rbmanagement_Click(object sender, RoutedEventArgs e)
        {
            rbmaintance.IsChecked = false;
            rbmaintance1.IsChecked = false;
            //rbmanagement.IsChecked = false;
            rbmanagement1.IsChecked = false;
        }
        private void rbmaintance1_Click(object sender, RoutedEventArgs e)
        {
            rbmaintance.IsChecked = false;
            //rbmaintance1.IsChecked = false;
            rbmanagement.IsChecked = false;
            rbmanagement1.IsChecked = false;
        }
        private void rbmanagement1_Click(object sender, RoutedEventArgs e)
        {
            rbmaintance.IsChecked = false;
            rbmaintance1.IsChecked = false;
            rbmanagement.IsChecked = false;
            //rbmanagement1.IsChecked = false;
        }
        private void dpfromdate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpfromdate.SelectedDate < DateTime.Today.Date)
            {
                MessageBox.Show("From date cannot be less than the current date");
                dpfromdate.Text = "";
            }
            else if (dpfromdate.SelectedDate == DateTime.Today.Date)
            {
                dpfromdate.Text = Convert.ToString(DateTime.Today.Date);
            }
        }
        private void dptodate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dptodate.SelectedDate < DateTime.Today.Date)
                {
                    MessageBox.Show("To date cannot be less than the from date");
                    dptodate.Text = "";
                }
                else if (dptodate.SelectedDate < dpfromdate.SelectedDate)
                {
                    MessageBox.Show("To date cannot be less than from date");
                    dptodate.Text = "";
                }
                else if (dptodate.SelectedDate == DateTime.Today.Date)
                {
                    dptodate.Text = Convert.ToString(DateTime.Today.Date);
                }
            }
            catch (Exception) { }
        }
        public void clear()
        {
            txtroomno.Text = "";
            txtroomtype.Text = "";
            dpfromdate.Text = "";
            dptodate.Text = "";
            rbmaintance.IsEnabled = false;
            rbmanagement.IsEnabled = false;
            txtreason.Text = "";
        }
    }
}

