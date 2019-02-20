using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using HMS.Model;
using HMS.ViewModel;
using HMS.View.Masters;

namespace HMS.View.Operations
{
    /// <summary>
    /// Interaction logic for PostChargesxaml.xaml
    /// </summary>
    public partial class PostChargesxaml : Page
    {
        Postcharges pc = new Postcharges();
        public int error = 0;
        public PostChargesxaml()
        {
            data.COUNT = 0;
            InitializeComponent();
            particulars.Text = "";
            charges.Text = "";
            data.COUNT = 1;
            voucherno.IsReadOnly = true;
            DataTable dt = pc.GET_CHECKEIN_ROOMS();
            int i = 0;
            for (i = 0; i < dt.Rows.Count; i++)
            {
                int a = Convert.ToInt16(dt.Rows[i]["ROOM_NO"]);
                Button BT = new Button();
                BT.Height = 24; BT.Width = 70;
                BT.Margin = new System.Windows.Thickness(4, 0, 4, 6);
                BT.Padding = new System.Windows.Thickness(0, -2, 0, 0);
                BT.FontSize = 15;
                BT.Content = a;
                BT.Background = Brushes.Orange;
                BT.Click += new RoutedEventHandler(Roomno_click);
                checkedinrooms.Children.Add(BT);
            }
            DataTable D = pc.GET_REVENUE();
            revenuecode.ItemsSource = D.DefaultView;
            int A = pc.GET_VOUCHER_NO();
            voucherno.Text = A.ToString();
            DataTable da = pc.GET_tax();
            taxcode.ItemsSource = da.DefaultView;
        }
        protected void Roomno_click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button BT = sender as Button;
                pc.ROOMNO = Convert.ToInt16(BT.Content);
                DataTable DT = pc.GET_DETAILS();
                roomno.IsReadOnly = true;
                roomno.Text = DT.Rows[0]["ROOM_NO"].ToString();
                guestname.IsReadOnly = true;
                guestname.Text = DT.Rows[0]["FIRSTNAME"] + " " + DT.Rows[0]["LASTNAME"];
                int a = pc.GET_VOUCHER_NO();
                voucherno.Text = a.ToString();
                int A = pc.GET_MAX_NAME();
                pc.CHECKIN_ID = A;
            }
            catch (Exception) { }
        }
        public string BUT = null;
        public void BIND()
        {
            pc.ROOMNO = Convert.ToInt16(roomno.Text);
            pc.REVENUE_CODE = revenuecode.Text;

            pc.GUEST_NAME = guestname.Text;
            pc.PARTICULARS = particulars.Text;
            pc.TAX_CODE = taxcode.Text;
            pc.TOTAL_AMOUNT = Convert.ToDecimal(totalamount.Content);
            pc.CHARGES = Convert.ToDecimal(charges.Text);
            //11/15/2017
            //pc.USER_NAME = login.u;
            pc.INSERT_BY = login.u;
            string d = DateTime.Now.ToShortDateString();
            pc.DATE = Convert.ToDateTime(d);
            pc.INSERT_DATE = Convert.ToDateTime(d);
        }
        public int clear = 0;
        public void CLEARall()
        {
            clear = 1;
            foreach (UIElement control in GRID.Children)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    TextBox tb = (TextBox)control;
                    tb.Text = "";
                }
            }
            foreach (UIElement cn in rev.Children)
            {
                if (cn.GetType() == typeof(ComboBox))
                {
                    ComboBox cm = (ComboBox)cn;
                    cm.Text = "";
                }
            }
            guestname.Text = ""; particulars.Text = ""; charges.Text = ""; taxcode.Text = "";
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
            try
            {
                if (error != 0)
                {
                    pop1.IsOpen = true;
                }
                else
                {
                    BIND();
                    pc.INSERT();
                    pc.postextar();
                    pc.A();
                    //MessageBox.Show("inserted sucessfully");
                    popup_insert.IsOpen = true;
                    CLEARall();
                    BUT = "S";
                    BUT = null;
                    int A = pc.GET_VOUCHER_NO();
                    voucherno.Text = A.ToString();
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("please check the values");
                pop1.IsOpen = true;
            }
        }
        private void revenuecode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (clear != 1)
                {
                    if (BUT != "S")
                    {
                        if (BUT != "C")
                        {
                            DataRowView DataRowView = revenuecode.SelectedItem as DataRowView;
                            string sValue = string.Empty;

                            if (DataRowView != null)
                            {
                                sValue = DataRowView.Row["REVENUE_CODE"] as string;
                            }
                            pc.REVENUE_CODE = sValue;
                            //string TAX = pc.GET_TAXFROM_REVENUE();
                            //taxcode.Text = TAX;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("please check the revenue code.");
            }
        }
        private void CLEAR_Click(object sender, RoutedEventArgs e)
        {
            BUT = "C";
            CLEARall();
            this.NavigationService.Refresh();
            int A = pc.GET_VOUCHER_NO();
            voucherno.Text = A.ToString();
        }
        private void charges_LostFocus(object sender, RoutedEventArgs e)
        {
            totalamount.Content = charges.Text;
        }

        private void insertpop_Click(object sender, RoutedEventArgs e)
        {
            popup_insert.IsOpen = false;
        }
    }
}
