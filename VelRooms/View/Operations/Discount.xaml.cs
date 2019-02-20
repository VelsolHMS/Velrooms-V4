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

namespace HMS.View.Operations
{
    /// <summary>
    /// Interaction logic for Discount.xaml
    /// </summary>
    public partial class Discount : Page
    {
        public int error = 0;
        public string result, result1, Checkin_ID;
        discount disc = new discount();
        public Discount()
        {
            data.COUNT = 0;
            InitializeComponent();
        //    clearing();
            data.COUNT = 1;
            //txtroomno.Text = "";
            disable();
        }

        public void disable()
        {
            txtroomno.IsEnabled = false;
            txtguestname.IsEnabled = false;
            rbdiscount.IsEnabled = false;
            txtparticular.IsEnabled = false;
            txtamount.IsEnabled = false;
            txtpercentage.IsEnabled = false;
        }

        public void enable()
        {
            txtroomno.IsEnabled = true;
            txtguestname.IsEnabled = true;
            rbdiscount.IsEnabled = true;
            txtparticular.IsEnabled = true;
            txtamount.IsEnabled = true;
            txtpercentage.IsEnabled = true;
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
        private void save_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            if (error != 0 || txtpercentage.Text != "" || txtamount.Text != "" || txtparticular.Text != "")
            {
                if(txtpercentage.Text == "0" || txtpercentage.Text == "00")
                {
                    if(txtamount.Text == "0.00" || txtamount.Text == "00.00")
                    {
                        txtamount.Text = "1.00";
                    }
                }
                string a = "Save"; string b = Convert.ToString(save.Content);
                if (a == b)
                {
                    if (txtpercentage.Text == "0" || txtpercentage.Text == "00")
                    {
                        if (txtamount.Text != "")
                        {
                            if (rbdiscount.IsChecked == true)
                            {
                                result = "1";
                            }
                            else result = "0";
                            disc.DISCOUNT_ROOM = txtroomno.Text;
                            disc.Room_Discount();
                            disc.ROOM_NO = txtroomno.Text;
                            disc.RESERVATION_ID = txtregno.Text;
                            disc.GUEST_NAME = txtguestname.Text;
                            disc.DISCOUNT_ON_TAX = result.ToString();
                            disc.PARTICULARS = txtparticular.Text;
                            disc.AMOUNT = txtamount.Text;
                            disc.PERCENTAGE = txtpercentage.Text;
                            // ss rr  yyy 11/15/2017
                            //disc.USER_NAME = login.u;
                            disc.INSERT_BY = login.u;
                            disc.INSERT_DATE = DateTime.Today;
                            if (disc.result == "0")
                            {
                                disc.Insert();
                                disc.A();
                                //MessageBox.Show("Inserted sucessfully");
                                popup_insert.IsOpen = true;
                            }
                            else
                            {
                                MessageBox.Show("Discount Has Already Been Added To This Room Number");

                            }
                            clearing();
                            this.NavigationService.Refresh();
                        }
                        else
                        {
                            txtpercentage.Text = "";
                        }
                    }
                    if (txtamount.Text == "0.00")
                    {
                        if (txtpercentage.Text != "")
                        {
                            if (rbdiscount.IsChecked == true)
                            {
                                result = "1";
                            }
                            else result = "0";
                            disc.DISCOUNT_ROOM = txtroomno.Text;
                            disc.Room_Discount();
                            disc.ROOM_NO = txtroomno.Text;
                            disc.RESERVATION_ID = txtregno.Text;
                            disc.GUEST_NAME = txtguestname.Text;
                            disc.DISCOUNT_ON_TAX = result.ToString();
                            disc.PARTICULARS = txtparticular.Text;
                            disc.AMOUNT = txtamount.Text;
                            disc.PERCENTAGE = txtpercentage.Text;
                            // ss rr  yyy 11/15/2017
                            //disc.USER_NAME = login.u;
                            disc.INSERT_BY = login.u;
                            disc.INSERT_DATE = DateTime.Today;
                            if (disc.result == "0")
                            {
                                disc.Insert();
                                disc.A();
                                //MessageBox.Show("inserted sucessfully");
                                popup_insert.IsOpen = true;
                            }
                            else
                            {
                                MessageBox.Show("Discount Has Already Been Added To This Room Number");
                            }
                            clearing();
                            this.NavigationService.Refresh();
                        }
                        else
                        {
                            txtamount.Text = "";
                        }
                    }
                }
                else
                {
                    disc.AMOUNT = txtamount.Text;
                    disc.CHECKIN_ID = Convert.ToInt32(Checkin_ID);
                    disc.PERCENTAGE = txtpercentage.Text;
                    disc.PARTICULARS = txtparticular.Text;
                    disc.UpdateDiscount();
                    //MessageBox.Show("Updated sucessfully");
                    popup_update.IsOpen = true;
                    clearing();
                    this.NavigationService.Refresh();
                }
            }
            else
            {
                //MessageBox.Show("Please fill all fields");
                pop1.IsOpen = true;
            }
            //}
            //catch (Exception)
            //{
            //}
            //else
            //{
            //    if (rbdiscount.IsChecked == true)
            //    {
            //        result = "1";
            //    }
            //   else result = "0";

            //    disc.DISCOUNT_ROOM = txtroomno.Text;
            //    disc.Room_Discount();
            //    disc.ROOM_NO = txtroomno.Text;
            //    disc.RESERVATION_ID = txtregno.Text;
            //    disc.GUEST_NAME = txtguestname.Text;
            //    disc.DISCOUNT_ON_TAX = result.ToString();
            //    disc.PARTICULARS = txtparticular.Text;
            //    disc.AMOUNT = txtamount.Text;
            //    disc.PERCENTAGE = txtpercentage.Text;
            //    // ss rr  yyy 11/15/2017
            //    //disc.USER_NAME = login.u;
            //    disc.INSERT_BY = login.u;
            //    disc.INSERT_DATE = DateTime.Today;
            //    if (disc.result == "0")
            //    {
            //            disc.Insert();
            //            disc.A();
            //            MessageBox.Show("inserted sucessfully");

            //    }
            //    else 
            //    {
            //        MessageBox.Show("Discount Has Already Been Added To This Room Number");

            //    }

            //clearing();
            //this.NavigationService.Refresh();
            // }
        }
        private void modify_Click(object sender, RoutedEventArgs e)
        {
            enable();
            save.Content = "Update";
        }
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            disable();
            clearing();
            this.NavigationService.Refresh();
            save.Content = "Save";
        }
        public void clearing()
        {
            txtroomno.Text = "";
            txtregno.Text = "";
            txtguestname.Text = "";
            rbdiscount.IsChecked = false;
            txtparticular.Text = "";
            txtamount.Text = "";
            txtpercentage.Text = "";
        }
        private void roomnos_Initialized(object sender, EventArgs e)
        {
            int index = 0;
            DataTable dt = disc.Retrive_Room_No();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int ROOMNO = Convert.ToInt16(dt.Rows[i]["ROOM_NO"]);
                Button BT = new Button();
                BT.Height = 24; BT.Width = 70;
                BT.Margin = new System.Windows.Thickness(6, 0, 4, 6);
                BT.Padding = new System.Windows.Thickness(0,-2,0,0);
                BT.Content = ROOMNO;
                BT.FontSize = 15;
                BT.Click += Butt_Click;
                room.Children.Insert(index, BT);
                result1 = Convert.ToString(BT.Content);
                index++;
            }
        }
        private void txtroomno_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                string a = "Update", b = Convert.ToString(save.Content);
                if (b == a)
                {
                    disc.ROOM_NO = txtroomno.Text;
                    disc.Retrive();
                    txtregno.Text = disc.RESERVATION_ID;
                    txtguestname.Text = disc.GUEST_NAME;
                    if (disc.DISCOUNT_ON_TAX == "1")
                    {
                        rbdiscount.IsChecked = true;
                    }
                    else rbdiscount.IsChecked = false;
                    txtparticular.Text = disc.PARTICULARS;
                    txtamount.Text = Convert.ToString(Math.Round(double.Parse(disc.AMOUNT), 2, MidpointRounding.AwayFromZero));
                    txtpercentage.Text = disc.PERCENTAGE;
                }
            }
            catch (Exception)
            {
            }
        }
        private void txtamount_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtamount.Text == "" || txtamount.Text == "0.0" || txtamount.Text == "0.00")
            {
                txtpercentage.IsEnabled = true;
            }
            else
            {
                txtpercentage.Text = "0";
                txtpercentage.IsEnabled = false;
            }
        }

        private void insertpop_Click(object sender, RoutedEventArgs e)
        {
            popup_insert.IsOpen = false;
        }

        private void updatepop_Click(object sender, RoutedEventArgs e)
        {
            popup_update.IsOpen = false;
        }

        private void txtpercentage_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtpercentage.Text == "" || txtpercentage.Text == "0" || txtpercentage.Text == "00")
            {
                txtamount.IsEnabled = true;
            }
            else
            {
                txtamount.Text = "0.00";
                txtamount.IsEnabled = false;
            }
        }
        private void Butt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                enable();
                Button btn = (Button)sender;
                txtroomno.Text = Convert.ToString(btn.Content);
                disc.ROOM_NO = txtroomno.Text;
                disc.Retrive_guestname();
                DataTable dt = disc.CheckDiscount();
                if(dt.Rows.Count > 0)
                {
                    save.Content = "Update";
                    txtguestname.Text = disc.GUEST_NAME;
                    txtparticular.Text = dt.Rows[0]["PARTICULAR"].ToString();
                    txtamount.Text = Math.Round(Convert.ToDecimal(dt.Rows[0]["AMOUNT"]), 2, MidpointRounding.AwayFromZero).ToString();
                    txtpercentage.Text = dt.Rows[0]["PERCENTAGE"].ToString();
                    Checkin_ID = dt.Rows[0]["CHECKIN_ID"].ToString();
                    if(txtpercentage.Text == "0")
                    {
                        txtpercentage.IsEnabled = false;
                        txtamount.IsEnabled = true;
                    }
                    else
                    {
                        txtpercentage.IsEnabled = true;
                        txtamount.IsEnabled = false;
                    }
                }
                else
                {
                    save.Content = "Save";
                    txtparticular.Text = "";
                    txtamount.Text = "0.00";
                    txtpercentage.Text = "";
                    txtguestname.Text = disc.GUEST_NAME;
                }
                txtregno.IsEnabled = false;
            }
            catch (Exception)
            {
            }
        }
    }
}
