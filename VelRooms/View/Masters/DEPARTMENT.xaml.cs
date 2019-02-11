using HMS.Model;
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
using HMS.ViewModel;
using System.Data.SqlClient;
using System.Data;
using HMS.Model.Masters;

namespace HMS.View.Masters
{
    /// <summary>
    /// Interaction logic for DEPARTMENT.xaml
    /// </summary>
    public partial class DEPARTMENT : Page
    {
        public int error = 0;
        DEPARTMENTS d = new DEPARTMENTS();

        public DEPARTMENT()
        {
            data.COUNT = 0;
            InitializeComponent();
            data.COUNT = 1;
            Save.Content = "Save";
            DataTable dt = d.fill_deptgrid();
            dgdept.ItemsSource = dt.DefaultView;
        }

//        private void Add_Click(object sender, RoutedEventArgs e)
//        {
//            txtdepartmentcode.Text = "";
//            txtdepartmentname.Text = "";
//            txtreportname.Text = "";
//            txtdepartmentcode.IsEnabled = true;
//            txtdepartmentname.IsEnabled = true;
//            txtreportname.IsEnabled = true;
//            ComboBox1.IsEnabled = true;
//            Modify.IsEnabled = false;
//            Save.IsEnabled = true;
//            clear.IsEnabled = true;
//           // Add.IsEnabled = false;
//            

////            Add.Background = new SolidColorBrush(Colors.Orange);
//            Modify.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
//        }

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
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DEPARTMENTS DE = new DEPARTMENTS();
            try
            {
                if (error != 0 ||txtdepartmentcode.Text=="" ||txtdepartmentname.Text == ""||txtreportname.Text=="")
                {
                   // pop1.IsOpen = true;
                    if(txtdepartmentcode.Text =="")
                    { txtdepartmentcode.Text = ""; }
                    if (txtdepartmentname.Text == "")
                    { txtdepartmentname.Text = ""; }
                    if(txtreportname.Text =="")
                    { txtreportname.Text = ""; }
                }
                else
                {

                    DE.DEPARTMENT_CODE = txtdepartmentcode.Text;
                    DE.DEPARTMENT_NAME = txtdepartmentname.Text;
                    DE.REPORT_NAME = txtreportname.Text;
                    DE.STATUS = ComboBox1.Text;
                    //S  R I I I 11/15/2017
                    //DE.USER_NAME = login.u;
                    DE.INSERT_BY = login.u;
                    DE.INSERT_DATE = DateTime.Today;

                    //DEPARTMENT
                    DE.INSERT();
                    string a1 = "Save", b1 = Convert.ToString(Save.Content);
                    if (b1 == a1)
                    {
                        //    insert.Content = "Inserted Sucessfully";
                        //    pop2.IsOpen = true;
                        DataTable dt = d.fill_deptgrid();
                        dgdept.ItemsSource = dt.DefaultView;
                        MessageBox.Show("inserted sucessfully");
                    }
                    DE.UPDATE();
                    string a = "Update", b = Convert.ToString(Save.Content);
                    if (b == a)
                    {//Save.Content = "Update";
                     //    insert.Content = "Updated Sucessfully";
                     //    pop2.IsOpen = true;
                        DataTable dt = d.fill_deptgrid();
                        dgdept.ItemsSource = dt.DefaultView;
                        MessageBox.Show("updated sucessfully");
                    }
                    txtdepartmentcode.Text = "";
                    txtdepartmentname.Text = "";
                    txtreportname.Text = "";
                    ComboBox1.Text = "";
                    this.NavigationService.Refresh();
                }
                //Add.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
                //Modify.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            }
            catch (Exception)
            {
                MessageBox.Show("please Eneter correct values");
            }
        }
        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtdepartmentcode.IsEnabled = true;
                txtdepartmentname.IsEnabled = true;
                txtreportname.IsEnabled = true;
                ComboBox1.IsEnabled = true;
                Save.Content = "Update";
                //Add.IsEnabled = false;
                txtdepartmentcode.IsEnabled = true;
                txtdepartmentname.IsEnabled = true;
                txtreportname.IsEnabled = true;
                ComboBox1.IsEnabled = true;
                Save.IsEnabled = true;
                clear.IsEnabled = true;
                //Modify.IsEnabled = false;
                insertpop.Content = "updatepopup";
            }
            catch (Exception)
            {
            }
        }
        private void txtdepartmentcode_LostFocus(object sender, RoutedEventArgs e)
        {         
            string a = "Update", b = Convert.ToString(Save.Content);
            try
            {
                if (b == a)
                {
                    DEPARTMENTS DE = new DEPARTMENTS();
                    DE.DEPARTMENT_CODE = txtdepartmentcode.Text;
                    DE.UPDATE_BY = login.u;
                    DE.UPDATE_DATE = DateTime.Today;
                    DE.UPDATE();
                    txtdepartmentname.Text = DE.DEPARTMENT_NAME;
                    txtreportname.Text = DE.REPORT_NAME;
                    ComboBox1.Text = DE.STATUS;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Eneter departmentcode correctly");
            }
        }
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            txtdepartmentcode.Text = "";
            txtdepartmentname.Text = "";
            txtreportname.Text = "";
            ComboBox1.Text = "";
            clear.IsEnabled = false;
            Save.IsEnabled = false;
            //Add.IsEnabled = true;
    //        Modify.IsEnabled = true;
            Save.Content = "SAVE";
            txtdepartmentcode.IsEnabled = false;
            txtdepartmentname.IsEnabled = false;
            txtreportname.IsEnabled = false;
            ComboBox1.IsEnabled = false;
            this.NavigationService.Refresh();

            //Add.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            //Modify.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
        }
        private void insertpop_Click(object sender, RoutedEventArgs e)
        {
            pop2.IsOpen = false;
        }
        private void dgdept_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int i = dgdept.SelectedIndex;
            DataTable dt = d.fill_deptdata();
            if (dt.Rows.Count == 0)
            {
            }
            else
            {
                if (i >= 0)
                {
                    Save.Content = "Update";
                    txtdepartmentcode.Text = dt.Rows[i]["DEPARTMENT_CODE"].ToString();
                    txtdepartmentname.Text = dt.Rows[i]["DEPARTMENT_NAME"].ToString();
                    txtreportname.Text = dt.Rows[i]["REPORT_NAME"].ToString();
                    ComboBox1.Text = dt.Rows[i]["STATUS"].ToString();
                }
                else
                {
                }
            }
        }
    }
}
