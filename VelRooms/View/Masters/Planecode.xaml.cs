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
using HMS.Model.Masters;
using HMS.ViewModel;

namespace HMS.View.Masters
{
    /// <summary>
    /// Interaction logic for Planecode.xaml
    /// </summary>
    public partial class Planecode : Page
    {
        plancode PCODE = new plancode();
        public int error = 0;

        public Planecode()
        {
            data.COUNT = 0;
            InitializeComponent();
            data.COUNT = 1;
            //DataTable dt1 = PCODE.Name();
            //DataRow row = dt1.NewRow();
            //row["NAME"] = "Select PlanName*";
            //dt1.Rows.InsertAt(row, 0);
            //TXTPLANNAME.ItemsSource = dt1.DefaultView;
            //TXTPLANNAME.SelectedIndex = 1;
            //add.IsEnabled = true;
            //modify.IsEnabled = true;
            save.IsEnabled = true;
            clear.IsEnabled = true;
            BTN = "add";
            insertpop.Content = "insertpopup";
            DataTable dt = PCODE.fill_plangrid();
            dgplancode.ItemsSource = dt.DefaultView;
        }

        public void Disable()
        {
            foreach (UIElement control in grid.Children)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    TextBox txtBox = (TextBox)control;
                    txtBox.IsEnabled = false;
                }
                if (control.GetType() == typeof(ComboBox))
                {
                    ComboBox cm = (ComboBox)control;
                    cm.IsEnabled = false;
                }
            }
                                        /*add.IsEnabled = true*/; //modify.IsEnabled = true; save.IsEnabled = false; clear.IsEnabled = false;
        }

        public void Enable()
        {
            foreach (UIElement control in grid.Children)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    TextBox tb = (TextBox)control;
                    tb.IsEnabled = true;
                }
                if (control.GetType() == typeof(ComboBox))
                {
                    ComboBox cmb = (ComboBox)control;
                    cmb.IsEnabled = true;
                }
            }
            //add.IsEnabled = false; modify.IsEnabled = false; save.IsEnabled = true; clear.IsEnabled = true;
        }
        public void clearall()
        {

            foreach (UIElement control in grid.Children)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    TextBox txtBox = (TextBox)control;
                    txtBox.Text = string.Empty;
                }
                if (control.GetType() == typeof(ComboBox))
                {
                    ComboBox cm = (ComboBox)control;
                    cm.Text = string.Empty;
                }

            }
            //add.IsEnabled = true; modify.IsEnabled = true; save.IsEnabled = false; clear.IsEnabled = false; li.Visibility = Visibility.Hidden;
          //  TXTPLANNAME.IsEnabled = false;
           // TXTREPORTINGNAME.IsEnabled =false;
        }

        public void clearing()
        {
            TXTPLANCODE.Text = "";
            TXTPLANNAME.Text = "";
            TXTREPORTINGNAME.Text = "";
        }
        public static string BTN = null;
        private void add_Click(object sender, EventArgs e)
        {
            clearing();
            BTN = "add";
            Enable();
            insertpop.Content = "insertpopup";

           // add.Background = new SolidColorBrush(Colors.Orange);
        //    modify.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
        }

        private void modify_Click(object sender, RoutedEventArgs e)
        {
            BTN = "modify";
            Enable();
            insertpop.Content = "updatepopup";

     //       modify.Background = new SolidColorBrush(Colors.Orange);
            //add.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
        }
        public void BIND()
        {
            PCODE.PLAN_CODE = TXTPLANCODE.Text;
            PCODE.NAME = TXTPLANNAME.Text;
            PCODE.REPORTING_NAME = TXTREPORTINGNAME.Text;
            PCODE.STATUS = STATUS.Text;
            PCODE.button = BTN;
            //SS R  I U II II 11/15/2017
            //PCODE.USER_NAME = login.u;
            PCODE.INSERT_BY = login.u;
            PCODE.INSERT_DATE = DateTime.Today;
        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                error++;
            else
                error--;
        }
        private void save_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (error != 0 || TXTPLANCODE.Text =="" || TXTPLANNAME.Text=="")
                {
                  //  pop1.IsOpen = true;
                    if (TXTPLANCODE.Text == "")
                    {
                        TXTPLANCODE.Text = "";
                    }
                    if(TXTPLANNAME.Text=="")
                    {
                        TXTPLANNAME.Text = "";
                    }   
                }

                else
                {
                        BIND();
                        string a = "Save"; string b = Convert.ToString(save.Content);
                        if (a == b)
                        {
                            PCODE.INSERT();
                            DataTable dt = PCODE.fill_plangrid();
                            dgplancode.ItemsSource = dt.DefaultView;
                            //   clearall();
                            MessageBox.Show("Saved Successfully");

                        }
                        else
                        {
                            PCODE.UPDATE();
                            DataTable dt = PCODE.fill_plandata();
                            dgplancode.ItemsSource = dt.DefaultView;
                            MessageBox.Show("Updated Successfully");
                            save.Content = "Save";
                        }
                        //if (BTN == "add")
                        //{
                        //    PCODE.INSERT();
                        //    //string a1 = "insertpopup", b1 = Convert.ToString(insertpop.Content);
                        //    //if (b1 == a1)
                        //    //{
                        //    //    insert.Content = "Inserted Sucessfully";
                        //    //    pop2.IsOpen = true;
                        //    //}
                        //    MessageBox.Show("inserted sucessfully");

                        //}
                        //if (BTN == "modify")
                        //{
                        //    //string a = "updatepopup", b = Convert.ToString(insertpop.Content);
                        //    //if (b == a)
                        //    //{
                        //    //    insert.Content = "Updated Sucessfully";
                        //    //    pop2.IsOpen = true;

                        //    //}
                        //    PCODE.UPDATE_BY = login.u;
                        //    PCODE.UPDATE_DATE = DateTime.Today;
                        //    PCODE.UPDATE();
                        //    MessageBox.Show("updated sucessfully");
                        //}
                        //Disable();
                        clearing();
                    this.NavigationService.Refresh();
                    // add.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                    //            modify.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                }
             
            }
            catch (Exception)
            {
                MessageBox.Show("please Enter correct values");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pop1.IsOpen = false;
        }
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            Disable();
            clearall();
            this.NavigationService.Refresh();

            //add.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
       //     modify.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
        }
        public int a = 0; DataTable D = null;
        private void txtPLANCODE_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (BTN == "add")
                {
                    PCODE.GET_STATUS_OF_DATA();
                }
                BIND();
                if (BTN == "modify")
                {
                    if (TXTPLANCODE.Text != "")
                    {
                        PCODE.GET_STATUS_OF_DATA();
                        if (PCODE.match == 1)
                        {
                            BIND_FETCHED_DATA();
                            li.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            BIND_FETCHED_DATA();
                            li.Visibility = Visibility.Visible;
                        }
                        if (PCODE.match != 1)
                        {
                            if (TXTPLANNAME.Text == "" && TXTREPORTINGNAME.Text == "" && STATUS.Text == "")
                            {
                                D = PCODE.setdata();
                                if (D != null)
                                {
                                    li.ItemsSource = D.DefaultView;
                                    li.Visibility = Visibility.Visible;

                                }
                                TXTPLANCODE.Text = PCODE.d;
                                int b = PCODE.d.Length;
                                TXTPLANCODE.Select(TXTPLANCODE.Text.Length, b);
                            }
                        }
                    }

                    PCODE.GETCOUNT(); if (PCODE.pc == 1)
                    {
                        TXTPLANCODE.Text = string.Empty; PCODE.pc = 0;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("please check the plancode");
            }
        }
        public int matched = 0;
        public void BIND_FETCHED_DATA()
        {
            TXTPLANNAME.Text = PCODE.NAME;
            TXTREPORTINGNAME.Text = PCODE.REPORTING_NAME;
            STATUS.Text = PCODE.STATUS;
        }
        private void li_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BTN == "modify")
            {
                li.Items.Refresh();
                li.Visibility = Visibility.Hidden;
                string w = "SELECT * FROM PLANCODE WHERE PLAN_CODE='" + TXTPLANCODE.Text + "'";
                PCODE.fetchdata(w);
                BIND_FETCHED_DATA();
                li.Visibility = Visibility.Hidden;
            }
        }
        private void TXTPLANCODE_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (BTN == "modify")
                {
                    if (TXTPLANCODE.Text != "")
                    {
                        PCODE.setdata();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("please check the plancode");
            }
        }
        private void TXTPLANCODE_LostFocus(object sender, RoutedEventArgs e)
        {
            li.Visibility = Visibility.Hidden;
        }
        private void TXTPLANCODE_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (BTN == "modify")
                {
                    if (e.Key == Key.Back)
                    {
                        if (PCODE.c != 1)
                        {
                            PCODE.CLEARBACK(); PCODE.c = 0;
                        }
                        if (TXTPLANCODE.Text.Length == 0)
                        {
                            li.Visibility = Visibility.Hidden;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("please check the plancode");
            }
        }
        private void insertpop_Click(object sender, RoutedEventArgs e)
        {
            pop2.IsOpen = false;
        }

        private void dgplancode_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int i = dgplancode.SelectedIndex;
            DataTable dt = PCODE.fill_plandata();
            if (dt.Rows.Count == 0)
            {
            }
            else
            {
                if (i >= 0)
                {
                    save.Content = "Update";
                    TXTPLANCODE.Text = dt.Rows[i]["PLAN_CODE"].ToString();
                    TXTPLANNAME.Text = dt.Rows[i]["NAME"].ToString();
                    TXTREPORTINGNAME.Text = dt.Rows[i]["REPORTING_NAME"].ToString();
                    STATUS.Text = dt.Rows[i]["STATUS"].ToString();
                }
                else
                { }
            }
        }
        //private void TXTPLANNAME_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if(TXTPLANNAME.SelectedIndex == 0)
        //    {
        //        TXTPLANNAME.Text = "";
        //    }
        //}
    }
}
