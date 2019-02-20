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
using System.Data;
using System.Globalization;

namespace HMS.View.Operations
{
    /// <summary>
    /// Interaction logic for RESERVSTIONCHECKIN.xaml
    /// </summary>
    public partial class RESERVSTIONCHECKIN : Page
    {
        RESERVATION re = new RESERVATION();
        public DataTable datatable;
        public static int rooms, group, days, noofrooms, p = 0;

        private void Error1_Click(object sender, RoutedEventArgs e)
        {
            pop1.IsOpen = false;
        }

        private void Error2_Click(object sender, RoutedEventArgs e)
        {
            pop2.IsOpen = false;
        }

        public static String res_id, pax, adult, child, gueststatus, firstname, lastname, company_name, company_address, zip, city, state, country, address, mobile, email, arraivaldate, departuredate, roomcategory;//,Idproof,IdNumber
        public DataTable getDetails;
        public RESERVSTIONCHECKIN()
        {
            InitializeComponent();
            datatable = re.FillReservationDetails();
            //reserevationdetails.CurrentColumn[]
            //reserevationdetails.Columns["ARRIVAL_DATE"].DefaultCellStyle.Format = "HH:mm:ss";
            reserevationdetails.ItemsSource = datatable.DefaultView;
        }
        private void reserevationdetails_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int selected_index = reserevationdetails.SelectedIndex;
                res_id = datatable.Rows[selected_index]["RESERVATION_ID"].ToString();
                getDetails = re.GetReservationDetails(res_id);
                noofrooms = Convert.ToInt32(getDetails.Rows[0]["NO_OF_ROOMS"]);
                gueststatus = getDetails.Rows[0]["GUEST_STATUS"].ToString();
                firstname = getDetails.Rows[0]["FIRSTNAME"].ToString();
                lastname = getDetails.Rows[0]["LASTNAME"].ToString();
                company_name = getDetails.Rows[0]["COMPANY_NAME"].ToString();
                company_address = getDetails.Rows[0]["COMPANY_ADDRESS"].ToString();
                zip = getDetails.Rows[0]["ZIP"].ToString();
                city = getDetails.Rows[0]["CITY"].ToString();
                state = getDetails.Rows[0]["STATE"].ToString();
                country = getDetails.Rows[0]["COUNTRY"].ToString();
                mobile = getDetails.Rows[0]["MOBILE_NO"].ToString();
                email = getDetails.Rows[0]["EMAIL"].ToString();
                address = getDetails.Rows[0]["DOOR_NO"].ToString();
                string SystemDateFormate = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                arraivaldate = Convert.ToDateTime(getDetails.Rows[0]["ARRIVAL_DATE"]).ToString(SystemDateFormate);
                departuredate = Convert.ToDateTime(getDetails.Rows[0]["DEPARTURE_DATE"]).ToString(SystemDateFormate);
                //IdNumber = getDetails.Rows[0]["ID_DATA"].ToString();
                //Idproof = getDetails.Rows[0]["ID_TYPE"].ToString();
                roomcategory = getDetails.Rows[0]["ROOM_CATEGORY"].ToString();
                pax = getDetails.Rows[0]["PAX"].ToString();
                adult = getDetails.Rows[0]["ADULT"].ToString();
                child = getDetails.Rows[0]["CHILD"].ToString();
                if (arraivaldate != DateTime.Today.ToShortDateString())
                {
                    //MessageBox.Show("This reservation will not get check-In today. Please check the arrival date.");
                    pop1.IsOpen = true;
                }
                else
                {
                    if (noofrooms == 1)
                    {
                        p = 1;
                        CheckinDeparture.p = 1;
                        GroupCheckinDeparture.group = 0;
                    }
                    else if (noofrooms == 0)
                    {
                        pop2.IsOpen = true;
                        //MessageBox.Show("No of Rooms Should not be zero please Update.!");
                    }
                    else if (noofrooms > 1)
                    {
                        p = 1;
                        CheckinDeparture.p = 0;
                        GroupCheckinDeparture.rooms = noofrooms;
                        GroupCheckinDeparture.group = 1;
                    }
                    Vacant v = new Vacant();
                    this.NavigationService.Navigate(v);
                }
            }
            catch (Exception) { }
        }
    }
}