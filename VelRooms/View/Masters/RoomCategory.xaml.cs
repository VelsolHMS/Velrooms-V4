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
using HMS.ViewModel;
using HMS.Model;

namespace HMS.View.Masters
{
    /// <summary>
    /// Interaction logic for RoomCategory.xaml
    /// </summary>
    public partial class RoomCategory : Page
    {
        public int error = 0;
        RoomCateogry1 ROOM = new RoomCateogry1();
        //private Model _Models = null;

        public RoomCategory()
        {
            data.COUNT = 0;
            InitializeComponent();
            data.COUNT = 1;
            txtactivedate.Text = DateTime.Today.Date.ToString();
            txtactivedate.DisplayDateStart = DateTime.Today;
            //DataTable dt1 = ROOM.RoomName();
            //DataRow row = dt1.NewRow();
            //row["ROOM_CATEGORY"] = "Select RoomCategory*";
            //dt1.Rows.InsertAt(row, 0);
            //txtroomtype.ItemsSource = dt1.DefaultView;
            //txtroomtype.SelectedIndex = 1;
            ////_Models = new Models();
            // DataContext = _Models;
            SAVE.Content = "Save";
            SAVE.IsEnabled = true;
            clear.IsEnabled = true;
            insertpop.Content = "insertpopup";
            
            //clearing();
            DataTable dt = ROOM.fill_grid();
            dgroomcategory.ItemsSource = dt.DefaultView;
        }
        public string _txtroomtype
        {
            get { return txtroomtype.Text; }
        }
        public void clearing()
        {
            txtroomtype.Text = "";
            txtroomname.Text = "";
            txtreportingname.Text = "";
            txtnoofrooms.Text = "";
            txtmaxpax.Text = "";
            txtactivedate.Text = "";

            txtroomtype.IsEnabled = true;
            txtmaxpax.IsEnabled = true;
        }
        //private void Add_Click(object sender, RoutedEventArgs e)
        //{
        //    clearing();
        //    txtroomtype.IsEnabled = true;
        //    txtroomname.IsEnabled = true;
        //    txtreportingname.IsEnabled = true;
        //    txtnoofrooms.IsEnabled = true;
        //    txtmaxpax.IsEnabled = true;
        //    txtactivedate.IsEnabled = true;
        //    Combobox1.IsEnabled = true;

        //    SAVE.IsEnabled = true;
        //    clear.IsEnabled = true;
        //    //Add.IsEnabled = false;
        //    modify.IsEnabled = false;
        //   
        //   

        //   // Add.Background = new SolidColorBrush(Colors.Orange);
        //    modify.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pop1.IsOpen = false;
        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                error++;
            else
                error--;
        }
        private void SAVE_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (error != 0 ||txtroomtype.Text=="" || txtroomname.Text == "" || txtmaxpax.Text==""||txtnoofrooms.Text==""||txtreportingname.Text ==""||txtactivedate.Text =="")
                {
                     txtactivedate.Text = "";
                    // txtroomname.Text = "";
                   // pop1.IsOpen = true;
                    if(txtroomtype.Text=="")
                    { txtroomtype.Text = ""; }
                    if(txtroomname.Text == "")
                    { txtroomname.Text = ""; }
                    if(txtmaxpax.Text == "")
                    { txtmaxpax.Text = ""; }
                    if(txtnoofrooms.Text == "")
                    { txtnoofrooms.Text = ""; }
                    if(txtreportingname.Text =="")
                    { txtreportingname.Text = ""; }
                    if (txtactivedate.Text=="")
                    { txtactivedate.Text = string.Empty;
                        txtactivedate.Text = null;
                    }
                }
                else
                {
                    ROOM.ROOMTYPE = txtroomtype.Text.ToUpper() ;
                    ROOM.ROOMNAME = txtroomname.Text;
                    ROOM.REPORTINGNAME = txtreportingname.Text;
                    ROOM.MAXPAX = txtmaxpax.Text;
                    ROOM.ACTIVEDATE = Convert.ToDateTime(txtactivedate.Text);
                    ROOM.NOOFROOMS = txtnoofrooms.Text;
                    ROOM.STATUS = Combobox1.Text;
                    // SS RR II U II 11/15/2017
                    ROOM.INSERT_BY = login.u;
                    ROOM.INSERT_DATE = DateTime.Today;
                    string a = "Save"; string b = Convert.ToString(SAVE.Content);
                    if(a==b)
                    {
                        ROOM.insert();
                        DataTable dt = ROOM.fill_grid();
                        dgroomcategory.ItemsSource = dt.DefaultView;
                        //MessageBox.Show("Saved Successfully");
                        popup_insert.IsOpen = true;
                    }
                    else
                    {
                        ROOM.insert();
                        DataTable dt = ROOM.fill_grid(); 
                        dgroomcategory.ItemsSource = dt.DefaultView;
                        //MessageBox.Show("Updated Successfully");
                        popup_update.IsOpen = true;
                        SAVE.Content = "Save";
                    }
                    //string a1 = "SAVE", b1 = Convert.ToString(SAVE.Content);
                    //if (b1 == a1)
                    //{
                    //    //SAVE.Content = "SAVE";
                    //    //insert.Content = "Inserted Sucessfully";
                    //    //pop2.IsOpen = true;
                    //    ROOM.insert();
                    //    MessageBox.Show("inserted sucessfully");
                    //    DataTable dt = ROOM.fill_grid();
                    //    dgroomcategory.ItemsSource = dt.DefaultView;
                    //}

                    //string a = "UPDATE", b = Convert.ToString(SAVE.Content);
                    //if (b == a)
                    //{
                    //    //insert.Content = "Updated Sucessfully";
                    //    //pop2.IsOpen = true;
                    //    ROOM.update();
                    //    DataTable dt = ROOM.fill_grid();
                    //    dgroomcategory.ItemsSource = dt.DefaultView;
                    //    SAVE.Content = "SAVE";
                    //    MessageBox.Show("updated sucessfully");

                    //}

                    //    ROOM.insert();
                    txtroomtype.Text = "";
                    txtroomname.Text = "";
                    txtreportingname.Text = "";
                    txtnoofrooms.Text = "";
                    txtmaxpax.Text = "";
                    txtactivedate.Text = "";
                    Combobox1.Text = "";
                    this.NavigationService.Refresh();
                    //Add.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            //        modify.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("please Enter correct values");
            }
        }
        //private void modify_Click(object sender, RoutedEventArgs e)
        //{
        //    SAVE.Content = "UPDATE";
        //    txtroomtype.IsEnabled = true;
        //    txtroomname.IsEnabled = true;
        //    txtreportingname.IsEnabled = true;
        //    txtnoofrooms.IsEnabled = true;
        //    txtmaxpax.IsEnabled = true;
        //    txtactivedate.IsEnabled = true;
        //    Combobox1.IsEnabled = true;
        //    SAVE.IsEnabled = true;
        //    clear.IsEnabled = true;
        //   // Add.IsEnabled = false;
        //    modify.IsEnabled = false;
        //    insertpop.Content = "updatepopup";

        //    modify.Background = new SolidColorBrush(Colors.Orange);
        //    //Add.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
        //}

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            SAVE.IsEnabled = false;
            //   Add.IsEnabled = true;
            //  modify.IsEnabled = true;
            txtroomtype.Text = "";
            txtroomname.Text = "";
            txtreportingname.Text = "";
            txtnoofrooms.Text = "";
            txtmaxpax.Text = "";
            txtactivedate.Text = "";
            Combobox1.Text = "";
            this.NavigationService.Refresh();
           // Add.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
        //    modify.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
        }
        public string d;
        private void txtroomtype_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable dt = ROOM.RoomName();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    d = dt.Rows[i]["ROOM_CATEGORY"].ToString();
                    if (txtroomtype.Text.ToUpper() == d)
                    {
                        txtroomtype.Foreground = Brushes.Red;
                        MessageBox.Show("Room Category Already Exists");
                        txtroomtype.Text = "";
                        //     txtroomtype.Focus();
                        break;
                    }
                }
                if (txtroomtype.Text == "")
                {
                    //     txtroomtype.Focus();
                }
                txtroomtype.Foreground = Brushes.Black;
                string a = "Update", b = Convert.ToString(SAVE.Content);
                if (b == a)
                {
                    RoomCateogry1 ROOM = new RoomCateogry1();
                    ROOM.ROOMTYPE = txtroomtype.Text;
                    ROOM.UPDATE_BY = login.u;
                    ROOM.UPDATE_DATE = DateTime.Today;
                    ROOM.update();
                    txtroomname.Text = ROOM.ROOMNAME;
                    txtreportingname.Text = ROOM.REPORTINGNAME;
                    txtmaxpax.Text = ROOM.MAXPAX;
                    txtactivedate.Text = Convert.ToDateTime(ROOM.ACTIVEDATE).ToString();
                    txtnoofrooms.Text = ROOM.NOOFROOMS;
                    Combobox1.Text = ROOM.STATUS;
                }
            } catch (Exception) { }
        }
        private void txtactivedate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtactivedate.SelectedDate < DateTime.Today.Date)
            {
                MessageBox.Show("Active date cannot be less than the current date");
                txtactivedate.Text = "";
            }
            else if (txtactivedate.SelectedDate == DateTime.Today.Date)
            {
                txtactivedate.Text = Convert.ToString(DateTime.Today.Date);
            }
        }
        private void dgroomcategory_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int i = dgroomcategory.SelectedIndex;
                DataTable dt = ROOM.fill_data();
                if (dt.Rows.Count == 0)
                {
                }
                else
                {
                    if (i >= 0)
                    {
                        SAVE.Content = "Update";
                        txtroomtype.Text = dt.Rows[i]["ROOM_CATEGORY"].ToString();
                        txtroomtype.IsEnabled = false;
                        txtroomname.Text = dt.Rows[i]["ROOM_NAME"].ToString();
                        txtmaxpax.Text = dt.Rows[i]["MAXPAX"].ToString();
                        txtmaxpax.IsEnabled = false;
                        //txtactivedate.Text = Convert.ToDateTime(dt.Rows[i]["ACTIVE_DATE"]).ToString();
                        txtnoofrooms.Text = dt.Rows[i]["NO_OF_ROOMS"].ToString();
                        txtreportingname.Text = dt.Rows[i]["REPORTING_NAME"].ToString();
                        Combobox1.Text = dt.Rows[i]["STATUS"].ToString();
                        dgroomcategory.UnselectAll();
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception) { }
        }
        private void dgroomcategory_LoadingRow(object sender, DataGridRowEventArgs e)
        {
           // this.dgroomcategory.Rows[0].Cells[1].Style.ForeColor = System.Drawing.Color.Red;
            //DataRowView item = e.Row.Item as DataRowView;
            //if (item != null)
            //{
            //    if (Combobox1.Text == "Active")
            //    {
            //        DataRow row = item.Row;
            //        e.Row.Foreground = new SolidColorBrush(Colors.Red);
            //    }
            //}
            //foreach (RoomCateogry1 item in dgroomcategory.ItemsSource)
            //{
            //    var row = dgroomcategory.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
            //    if (item.STATUS == "In Active")
            //    {
            //        row.Foreground = Brushes.Red;
            //    }
            //}
        }

        private void updatepop_Click(object sender, RoutedEventArgs e)
        {
            popup_update.IsOpen = false;
        }

        private void insertpop_Click(object sender, RoutedEventArgs e)
        {
            popup_insert.IsOpen = false;
        }
    }
}
