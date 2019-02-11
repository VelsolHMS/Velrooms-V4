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
using HMS.Model.Operations;

namespace HMS.View.Operations
{
    /// <summary>
    /// Interaction logic for Pendingbillgrid.xaml
    /// </summary>
    public partial class Pendingbillgrid : Page
    {
        pendinggrid pg = new pendinggrid();
        PendingBill pb = new PendingBill();
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        public Pendingbillgrid()
        {
            InitializeComponent();
            dt = pg.GridData();
            dt1.Columns.Add("ID", typeof(int));
            dt1.Columns.Add("GuestName", typeof(string));
            dt1.Columns.Add("Company", typeof(string));
            dt1.Columns.Add("Amount", typeof(string));
            dt1.Columns.Add("Balance", typeof(string));
            dt1.Columns.Add("Date", typeof(string));
            dt1.Columns.Add("ADVANCE", typeof(string));
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow r = dt1.NewRow();
                r["ID"] = int.Parse(dt.Rows[i]["BILL_NO"].ToString());
                pg.BILL_NO = dt.Rows[i]["BILL_NO"].ToString();
                pg.Guestname();
                r["GuestName"] = pg.GUEST_NAME;
                r["Company"] = pg.COMPANY;
                decimal sss = decimal.Parse(dt.Rows[i]["AMOUNT"].ToString());
                r["Amount"] = Convert.ToString(Math.Round(sss, 2, MidpointRounding.AwayFromZero));
                r["Balance"] = dt.Rows[i]["Balance"].ToString();
                pg.Checkout();
                r["Date"] = pg.INSERT_DATE;
                //decimal SSP = Convert.ToDecimal(dt.Rows[i]["ADVANCE"].ToString());
                r["ADVANCE"] = dt.Rows[i]["ADVANCE"].ToString();
                dt1.Rows.Add(r);
            }
            pendingbillgrid.ItemsSource = dt1.DefaultView;
        }
        private void pendingbillgrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int i = pendingbillgrid.SelectedIndex;
                if (i < 0)
                {
                }
                else
                {
                    pb.txtbillno.Text = dt1.Rows[i]["ID"].ToString();
                    pb.txtroomnno.Text = dt.Rows[i]["ROOM_NO"].ToString();
                    pb.txtname.Text = dt1.Rows[i]["GuestName"].ToString();
                    pb.txtcompanyname.Text = dt1.Rows[i]["Company"].ToString();

                    pb.txtpendingamount1.Text = dt.Rows[i]["Balance"].ToString();
                    //decimal pend = Convert.ToDecimal(pb.txtpendingamount1.Text);
                    //decimal amnt =Convert.ToDecimal(pb.txtamount1.Text);
                    //pb.txtbalanceamount1.Text = (pend - amnt).ToString();
                    pb.dt.Text = dt1.Rows[i]["Date"].ToString();
                    pg.Reservation_No();
                    pb.txtresno.Text = pg.RESERVATION_NO;
                    this.NavigationService.Navigate(pb);
                }
            }
            catch (Exception) { }
        }
    }
}
