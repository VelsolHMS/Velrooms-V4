using HMS.Model.Masters;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace HMS.mainwindowpages
{
    /// <summary>
    /// Interaction logic for masters.xaml
    /// </summary>
    public partial class masters : Page
    {
       
        public masters()
        {
            InitializeComponent();
            //this.frame2.Navigate(new Uri("mainwindowpages/HotelName.xaml", UriKind.RelativeOrAbsolute));
        }
        Userpermission u = new Userpermission();
        
        private void btnhtinfo_Click(object sender, RoutedEventArgs e)
        {
            DataTable d = u.MASTER1();
            if (d.Rows.Count == 0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
            }
            else
            {
                int HOTELINFO = int.Parse(d.Rows[0]["HOTELINFO"].ToString());
                if (HOTELINFO == 1)
                {
                    this.frame2.Navigate(new Uri("View/Masters/HotelInfo.xaml", UriKind.RelativeOrAbsolute));
                    (sender as Button).Background = new SolidColorBrush(Colors.Orange);

                    //btnhtinfo.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncategory.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnami.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnplan.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmmst.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmtax.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrvn.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btndpt.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncmp.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnRstPass.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnRegUsr.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                  
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");
                }
            }
        }

        private void btncmpclick(object sender, RoutedEventArgs e)
        {
            DataTable d = u.MASTER1();
            if (d.Rows.Count == 0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
            }
            else
            {


                int COMPANY = int.Parse(d.Rows[0]["COMPANY"].ToString());
                if (COMPANY == 1)
                {
                    this.frame2.Navigate(new Uri("View/Masters/Company_Master.xaml", UriKind.RelativeOrAbsolute));
                    (sender as Button).Background = new SolidColorBrush(Colors.Orange);

                    btnhtinfo.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncategory.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnami.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnplan.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmmst.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmtax.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrvn.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btndpt.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    //btncmp.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnRstPass.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnRegUsr.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    

                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");
                }
            }
        }

        private void btnctgclick(object sender, RoutedEventArgs e)
        {
            DataTable d = u.MASTER1();
            if (d.Rows.Count == 0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
            }
            else
            {

                int CATEGORY = int.Parse(d.Rows[0]["CATEGORY"].ToString());
                if (CATEGORY == 1)
                {
                    this.frame2.Navigate(new Uri("View/Masters/RoomCategory.xaml", UriKind.RelativeOrAbsolute));
                    (sender as Button).Background = new SolidColorBrush(Colors.Orange);

                    btnhtinfo.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    //btncategory.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnami.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnplan.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmmst.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmtax.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrvn.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btndpt.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncmp.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnRstPass.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnRegUsr.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                   

                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");
                }
            }
        }

        private void btnplnclick(object sender, RoutedEventArgs e)
        {
            DataTable d = u.MASTER1();
            if (d.Rows.Count == 0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
            }
            else
            {
                int PLANDEFINATION = int.Parse(d.Rows[0]["PLANDEFINATION"].ToString());
                if (PLANDEFINATION == 1)
                {
                    this.frame2.Navigate(new Uri("View/Masters/Planecode.xaml", UriKind.RelativeOrAbsolute));
                    (sender as Button).Background = new SolidColorBrush(Colors.Orange);
                    btnhtinfo.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncategory.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnami.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    //btnplan.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmmst.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmtax.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrvn.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btndpt.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncmp.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnRstPass.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnRegUsr.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                  

                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");
                }
            }
        }

        private void btnamiclick(object sender, RoutedEventArgs e)
        {
            DataTable d = u.MASTER1();
            if (d.Rows.Count == 0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
            }
            else
            {

                int AMENITIES = int.Parse(d.Rows[0]["AMENITIES"].ToString());
                if (AMENITIES == 1)
                {
                    this.frame2.Navigate(new Uri("View/Masters/Amenities.xaml", UriKind.RelativeOrAbsolute));
                    (sender as Button).Background = new SolidColorBrush(Colors.Orange);

                    btnhtinfo.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncategory.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    //btnami.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnplan.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmmst.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmtax.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrvn.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btndpt.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncmp.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnRstPass.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnRegUsr.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                   

                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");
                }
            }
        }

        private void btnrvnclick(object sender, RoutedEventArgs e)
        {
            DataTable d = u.MASTER1();
            if (d.Rows.Count == 0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
            }
            else
            {


                int REVENUE = int.Parse(d.Rows[0]["REVENUE"].ToString());
                if (REVENUE == 1)
                {
                    this.frame2.Navigate(new Uri("View/Masters/Revenue.xaml", UriKind.RelativeOrAbsolute));
                    (sender as Button).Background = new SolidColorBrush(Colors.Orange);

                    btnhtinfo.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncategory.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnami.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnplan.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmmst.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmtax.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    //btnrvn.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btndpt.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncmp.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnRstPass.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnRegUsr.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                   

                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");
                }
            }
        }

        private void btndptclick(object sender, RoutedEventArgs e)
        {
            DataTable d = u.MASTER1();
            if (d.Rows.Count == 0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
            }
            else
            {

                int DEPARTMENT = int.Parse(d.Rows[0]["DEPARTMENT"].ToString());
                if (DEPARTMENT == 1)
                {
                    this.frame2.Navigate(new Uri("View/Masters/DEPARTMENT.xaml", UriKind.RelativeOrAbsolute));
                    (sender as Button).Background = new SolidColorBrush(Colors.Orange);

                    btnhtinfo.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncategory.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnami.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnplan.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmmst.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmtax.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrvn.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    //btndpt.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncmp.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnRstPass.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnRegUsr.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                   
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");
                }
            }
        }
        private void btnrmtaxclick(object sender, RoutedEventArgs e)
        {
            DataTable d = u.MASTER1();
            if (d.Rows.Count == 0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
            }
            else
            {
                int TAX = int.Parse(d.Rows[0]["TAX"].ToString());
                if (TAX == 1)
                {
                    this.frame2.Navigate(new Uri("View/Masters/TAXCODE.xaml", UriKind.RelativeOrAbsolute));
                    (sender as Button).Background = new SolidColorBrush(Colors.Orange);

                    btnhtinfo.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncategory.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnami.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnplan.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmmst.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    //btnrmtax.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrvn.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btndpt.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncmp.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnRstPass.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnRegUsr.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                  
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");
                }
            }
        }

        private void btnrmmstclick(object sender, RoutedEventArgs e)
        {
            DataTable d = u.MASTER1();
            if (d.Rows.Count == 0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
            }
            else
            {


                int TARRIF = int.Parse(d.Rows[0]["ROOMTARRIF"].ToString());
                if (TARRIF == 1)
                {
                    this.frame2.Navigate(new Uri("View/Masters/RoomMaster.xaml", UriKind.RelativeOrAbsolute));
                    (sender as Button).Background = new SolidColorBrush(Colors.Orange);

                    btnhtinfo.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncategory.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnami.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnplan.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    //btnrmmst.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmtax.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrvn.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btndpt.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncmp.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnRstPass.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnRegUsr.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                   
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");
                }
            }
        }
        private void btnRegUsr_Click(object sender, RoutedEventArgs e)
        {
            DataTable d = u.MASTER1();
            if (d.Rows.Count == 0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
            }
            else
            {


                int REG = int.Parse(d.Rows[0]["REG_USER"].ToString());
                if (REG == 1)
                {
                    this.frame2.Navigate(new Uri("View/Masters/REGISTRATION.xaml", UriKind.RelativeOrAbsolute));
                    (sender as Button).Background = new SolidColorBrush(Colors.Orange);

                    btnhtinfo.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncategory.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnami.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnplan.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmmst.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmtax.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrvn.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btndpt.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncmp.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnRstPass.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    //btnRegUsr.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                   
                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");
                }
            }
        }

        private void btnRstPass_Click(object sender, RoutedEventArgs e)
        {
            DataTable d = u.MASTER1();
            if (d.Rows.Count == 0)
            {
                MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");

            }
            else
            {


                int RESETPASSWORD = int.Parse(d.Rows[0]["RESET_PASSWORD"].ToString());
                if (RESETPASSWORD == 1)
                {
                    this.frame2.Navigate(new Uri("View/Masters/resetpassword.xaml", UriKind.RelativeOrAbsolute));
                    (sender as Button).Background = new SolidColorBrush(Colors.Orange);

                    btnhtinfo.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncategory.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnami.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnplan.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmmst.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrmtax.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnrvn.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btndpt.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btncmp.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    //btnRstPass.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    btnRegUsr.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    

                }
                else
                {
                    MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");
                }
            }
        }

       
    }
}
