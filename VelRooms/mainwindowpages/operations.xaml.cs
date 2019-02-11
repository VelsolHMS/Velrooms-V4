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
using HMS.View.Operations;
using System.Data;
using HMS.Model.Masters;

namespace HMS.mainwindowpages
{
    /// <summary>
    /// Interaction logic for operations.xaml
    /// </summary>
    public partial class operations : Page
    {
        public operations()
        {
            InitializeComponent();
            //this.frame1.Navigate(new Uri("mainwindowpages/HotelName.xaml", UriKind.RelativeOrAbsolute));
        }
        Userpermission u = new Userpermission();
        private void btnresvclick(object sender, RoutedEventArgs e)
        {

            DataTable dopr = u.Opr1();
            if (dopr.Rows.Count == 0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
            }
            else
            {
                int RESERVATION = int.Parse(dopr.Rows[0]["RESERVATION"].ToString());
                if (RESERVATION == 1)
                {
                    this.frame1.Navigate(new Uri("View/Operations/RESERVATIONS.xaml", UriKind.Relative));
                    (sender as Button).Background = new SolidColorBrush(Colors.Orange);
                    btncin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrescin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnadv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncheckout.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnchrgs.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnmis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpaidouts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpbcollection.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrefund.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnreprint.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmcng.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmsts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnsettle.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngsinf.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnblkrm.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btndis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngrpcin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    RESERVSTIONCHECKIN.p = 0;
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");

                }
            }
        }
        private void btncinclick(object sender, RoutedEventArgs e)
        {
            DataTable dopr = u.Opr1();
            if (dopr.Rows.Count == 0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
            }
            else
            {
                int CHECKIN = int.Parse(dopr.Rows[0]["CHECKIN"].ToString());
                if (CHECKIN == 1)
                {
                    //this.frame1.Refresh();
                    this.frame1.Navigate(new Uri("View/Operations/CheckinDeparture.xaml", UriKind.Relative));
                    (sender as Button).Background = new SolidColorBrush(Colors.Orange);
                    //btncin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrescin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnadv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncheckout.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnchrgs.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnmis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpaidouts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpbcollection.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrefund.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnreprint.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmcng.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmsts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnsettle.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngsinf.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnblkrm.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnresv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btndis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngrpcin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    RESERVSTIONCHECKIN.p = 0;
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");
                }
            }
        }
        private void btnrescinclick(object sender, RoutedEventArgs e)
        {
            DataTable dopr = u.Opr1();
            if (dopr.Rows.Count == 0)
            {

            }
            else
            {
                this.frame1.Navigate(new Uri("View/Operations/RESERVSTIONCHECKIN.xaml", UriKind.Relative));
                (sender as Button).Background = new SolidColorBrush(Colors.Orange);
                btncin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                //btnrescin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                btnadv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                btncheckout.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                btnchrgs.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                btnmis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                btnpaidouts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                btnpbcollection.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                btnrefund.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                btnreprint.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                btnrmcng.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                btnrmsts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                btnsettle.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                btngsinf.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                btnblkrm.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                btnresv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                btndis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                btngrpcin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                RESERVSTIONCHECKIN.p = 0;
            }
        }
        private void btnadvclick(object sender, RoutedEventArgs e)
        {
            DataTable dopr = u.Opr1();
            if (dopr.Rows.Count ==0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
            }
            else
            {
                int ADVANCE = int.Parse(dopr.Rows[0]["ADVANCE"].ToString());
                if (ADVANCE == 1)
                {
                    this.frame1.Navigate(new Uri("View/Operations/Advance.xaml", UriKind.Relative));
                    (sender as Button).Background = new SolidColorBrush(Colors.Orange);


                    btncin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrescin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    //btnadv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncheckout.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnchrgs.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnmis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpaidouts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpbcollection.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrefund.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnreprint.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmcng.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmsts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnsettle.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngsinf.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnblkrm.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnresv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btndis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngrpcin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    RESERVSTIONCHECKIN.p = 0;
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");

                }
            }
        }

        private void btnchrgsclick(object sender, RoutedEventArgs e)
        {
            DataTable dopr = u.Opr1();
            if (dopr.Rows.Count == 0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
            }
            else
            {
                int Postcharges = int.Parse(dopr.Rows[0]["POSTCHARGES"].ToString());
                if (Postcharges == 1)
                {
                    this.frame1.Navigate(new Uri("View/Operations/PostChargesxaml.xaml", UriKind.Relative));
                    (sender as Button).Background = new SolidColorBrush(Colors.Orange);


                    btncin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrescin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnadv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncheckout.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    //btnchrgs.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnmis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpaidouts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpbcollection.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrefund.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnreprint.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmcng.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmsts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnsettle.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngsinf.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnblkrm.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnresv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btndis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngrpcin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    RESERVSTIONCHECKIN.p = 0;
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");

                }
            }
        }

        private void btnpdotclick(object sender, RoutedEventArgs e)
        {
            DataTable dopr = u.Opr1();
            if (dopr.Rows.Count == 0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
            }
            else
            {

                int Paidouts = int.Parse(dopr.Rows[0]["PAIDOUTS"].ToString());
                if (Paidouts == 1)
                {
                    this.frame1.Navigate(new Uri("View/Operations/Paidouts.xaml", UriKind.Relative));
                    (sender as Button).Background = new SolidColorBrush(Colors.Orange);


                    btncin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrescin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnadv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncheckout.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnchrgs.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnmis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    //btnpaidouts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpbcollection.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrefund.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnreprint.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmcng.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmsts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnsettle.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngsinf.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnblkrm.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnresv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btndis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngrpcin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    RESERVSTIONCHECKIN.p = 0;
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");

                }
            }
        }
        private void btnhmcngclick(object sender, RoutedEventArgs e)
        {
            DataTable dopr = u.Opr1();
            if (dopr.Rows.Count == 0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
            }
            else
            {

                int RoomchangE = int.Parse(dopr.Rows[0]["ROOMCHANGE"].ToString());
                if (RoomchangE == 1)
                {
                    this.frame1.Navigate(new Uri("View/Operations/ROOMCHANGE.xaml", UriKind.Relative));
                    (sender as Button).Background = new SolidColorBrush(Colors.Orange);


                    btncin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrescin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnadv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncheckout.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnchrgs.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnmis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpaidouts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpbcollection.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrefund.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnreprint.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    //btnrmcng.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmsts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnsettle.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngsinf.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnblkrm.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnresv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btndis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngrpcin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    RESERVSTIONCHECKIN.p = 0;
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");

                }
            }
        }
        private void btnrefndclick(object sender, RoutedEventArgs e)
        {
            DataTable dopr = u.Opr1();
            if (dopr.Rows.Count == 0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
            }
            else
            {
                int REFUND = int.Parse(dopr.Rows[0]["REFUND"].ToString());
                if (REFUND == 1)
                {
                    this.frame1.Navigate(new Uri("View/Operations/Refund.xaml", UriKind.Relative));
                    (sender as Button).Background = new SolidColorBrush(Colors.Orange);


                    btncin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrescin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnadv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncheckout.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnchrgs.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnmis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpaidouts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpbcollection.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    // btnrefund.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnreprint.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmcng.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmsts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnsettle.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngsinf.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnblkrm.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnresv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btndis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngrpcin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    RESERVSTIONCHECKIN.p = 0;
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");

                }
            }
        }
        private void btnblkrmclick(object sender, RoutedEventArgs e)
        {
            DataTable dopr = u.Opr1();
            if (dopr.Rows.Count == 0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
            }
            else
            {
                int BLOCK_ROOM = int.Parse(dopr.Rows[0]["BLOCK_ROOM"].ToString());
                if (BLOCK_ROOM == 1)
                {
                    this.frame1.Navigate(new Uri("View/Operations/Block_Room.xaml", UriKind.Relative));
                    (sender as Button).Background = new SolidColorBrush(Colors.Orange);


                    btncin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrescin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnadv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncheckout.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnchrgs.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnmis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpaidouts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpbcollection.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrefund.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnreprint.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmcng.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmsts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnsettle.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngsinf.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    //btnblkrm.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnresv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btndis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngrpcin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    RESERVSTIONCHECKIN.p = 0;
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");

                }
            }
        }
        private void btndosclick(object sender, RoutedEventArgs e)
        {
            DataTable dopr = u.Opr1();
            if (dopr.Rows.Count == 0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
            }
            else
            {

                int DISCOUNT = int.Parse(dopr.Rows[0]["DISCOUNT"].ToString());
                if (DISCOUNT == 1)
                {
                    this.frame1.Navigate(new Uri("View/Operations/Discount.xaml", UriKind.Relative));
                    (sender as Button).Background = new SolidColorBrush(Colors.Orange);


                    btncin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrescin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnadv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncheckout.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnchrgs.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnmis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpaidouts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpbcollection.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrefund.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnreprint.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmcng.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmsts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnsettle.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngsinf.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnblkrm.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnresv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    //btndis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngrpcin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    RESERVSTIONCHECKIN.p = 0;
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");

                }
            }
        }
        private void btngsinfclick(object sender, RoutedEventArgs e)
        {
            DataTable dopr = u.Opr1();
            if (dopr.Rows.Count == 0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
            }
            else
            {
                int GUESTINFO = int.Parse(dopr.Rows[0]["GUESTINFO"].ToString());
                if (GUESTINFO == 1)
                {
                    this.frame1.Navigate(new Uri("View/Operations/INGUESTHOUSEINFO.xaml", UriKind.Relative));
                    (sender as Button).Background = new SolidColorBrush(Colors.Orange);


                    btncin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrescin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnadv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncheckout.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnchrgs.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnmis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpaidouts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpbcollection.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrefund.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnreprint.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmcng.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmsts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnsettle.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    //btngsinf.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnblkrm.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnresv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btndis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngrpcin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    RESERVSTIONCHECKIN.p = 0;
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");

                }
            }
        }
        private void btnmisclick(object sender, RoutedEventArgs e)
        {
            DataTable dopr = u.Opr1();
            if (dopr.Rows.Count == 0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
            }
            else
            {
                int MISSALES = int.Parse(dopr.Rows[0]["MISSALES"].ToString());
                if (MISSALES == 1)
                {
                    this.frame1.Navigate(new Uri("View/Operations/Miscellenous_Collection.xaml", UriKind.Relative));
                    (sender as Button).Background = new SolidColorBrush(Colors.Orange);


                    btncin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrescin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnadv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncheckout.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnchrgs.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    //btnmis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpaidouts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpbcollection.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrefund.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnreprint.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmcng.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmsts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnsettle.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngsinf.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnblkrm.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnresv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btndis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngrpcin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    RESERVSTIONCHECKIN.p = 0;
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");

                }
            }
        }
        private void btnckotclick(object sender, RoutedEventArgs e)
        {
            DataTable dopr = u.Opr1();
            if (dopr.Rows.Count == 0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
            }
            else
            {

                int CHECKOUT = int.Parse(dopr.Rows[0]["CHECKOUT"].ToString());
                if (CHECKOUT == 1)
                {

                    this.frame1.Navigate(new Uri("View/Operations/Checkout.xaml", UriKind.Relative));
                    (sender as Button).Background = new SolidColorBrush(Colors.Orange);


                    btncin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrescin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnadv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    //btncheckout.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnchrgs.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnmis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpaidouts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpbcollection.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrefund.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnreprint.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmcng.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmsts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnsettle.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngsinf.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnblkrm.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnresv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btndis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngrpcin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    RESERVSTIONCHECKIN.p = 0;
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");

                }

            }
        }
        private void btnsettle_Click(object sender, RoutedEventArgs e)
        {
            DataTable dopr = u.Opr1();
            if (dopr.Rows.Count == 0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
            }
            else
            {
                int Billsettle = int.Parse(dopr.Rows[0]["BILLSETTLE"].ToString());
                if (Billsettle == 1)
                {
                    this.frame1.Navigate(new Uri("View/Operations/settle.xaml", UriKind.Relative));
                    (sender as Button).Background = new SolidColorBrush(Colors.Orange);


                    btncin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrescin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnadv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncheckout.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnchrgs.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnmis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpaidouts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpbcollection.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrefund.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnreprint.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmcng.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmsts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    //btnsettle.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngsinf.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnblkrm.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnresv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btndis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngrpcin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    RESERVSTIONCHECKIN.p = 0;
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");

                }
            }
        }
        private void btnpbcollectionClick(object sender, RoutedEventArgs e)
        {
            DataTable dopr = u.Opr1();
            if (dopr.Rows.Count == 0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
            }
            else
            {
                int Pendingbill = int.Parse(dopr.Rows[0]["PENDINGBILL"].ToString());
                if (Pendingbill == 1)
                {
                    this.frame1.Navigate(new Uri("View/Operations/Pendingbillgrid.xaml", UriKind.Relative));
                    (sender as Button).Background = new SolidColorBrush(Colors.Orange);
                    btncin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrescin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnadv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncheckout.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnchrgs.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnmis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpaidouts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    //btnpbcollection.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrefund.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnreprint.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmcng.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmsts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnsettle.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngsinf.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnblkrm.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnresv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btndis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngrpcin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    RESERVSTIONCHECKIN.p = 0;
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");

                }
            }
        }
        private void btnrmstsClick(object sender, RoutedEventArgs e)
        {

            this.frame1.Navigate(new Uri("View/Operations/rcs.xaml", UriKind.Relative));
            (sender as Button).Background = new SolidColorBrush(Colors.Orange);

            btnpbcollection.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            btncin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            btnrescin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            btnadv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            btncheckout.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            btnchrgs.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            btnmis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            btnpaidouts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            btnpbcollection.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            btnrefund.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            btnreprint.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            btnrmcng.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            //btnrmsts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            btnsettle.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            btngsinf.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            btnblkrm.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            btnresv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            btndis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            btngrpcin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            RESERVSTIONCHECKIN.p = 0;
        }
        private void btnreprint_Click(object sender, RoutedEventArgs e)
        {
            DataTable dopr = u.Opr1();
            if (dopr.Rows.Count == 0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
            }
            else
            {
                int REPRINT = int.Parse(dopr.Rows[0]["REPRINT"].ToString());
                if (REPRINT == 1)
                {
                    this.frame1.Navigate(new Uri("View/Operations/Reprint.xaml", UriKind.Relative));
                    (sender as Button).Background = new SolidColorBrush(Colors.Orange);

                    btnpbcollection.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrescin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnadv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncheckout.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnchrgs.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnmis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpaidouts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpbcollection.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrefund.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    //btnreprint.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmcng.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmsts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnsettle.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngsinf.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnblkrm.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnresv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btndis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngrpcin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    RESERVSTIONCHECKIN.p = 0;
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");
                }
            }
        }
        private void btngrpcin_Click(object sender, RoutedEventArgs e)
        {
            DataTable dopr = u.Opr1();
            if (dopr.Rows.Count == 0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
            }
            else
            {
                int Groupcheckin = int.Parse(dopr.Rows[0]["GROUP_CHECKIN"].ToString());
                if (Groupcheckin == 1)
                {
                    //this.frame1.Refresh();
                    this.frame1.Navigate(new Uri("View/Operations/GroupCheckinDeparture.xaml", UriKind.Relative));
                    (sender as Button).Background = new SolidColorBrush(Colors.Orange);

                    btnpbcollection.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrescin.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnadv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncheckout.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnchrgs.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnmis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpaidouts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnpbcollection.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrefund.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnreprint.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmcng.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmsts.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnsettle.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btngsinf.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnblkrm.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnresv.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btndis.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    RESERVSTIONCHECKIN.p = 0;
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");

                }
            }
        }
    }
}
