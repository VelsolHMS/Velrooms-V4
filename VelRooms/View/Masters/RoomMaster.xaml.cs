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
using HMS.ViewModel;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace HMS.View.Masters
{
    /// <summary>
    /// Interaction logic for RoomMaster.xaml
    /// </summary>
    public partial class RoomMaster : Page
    {
        Roommaster rm = new Roommaster();
        public int error = 0;
        public RoomMaster()
        {
            data.COUNT = 0;
            InitializeComponent();
            data.COUNT = 1;
            date.Text = DateTime.Today.Date.ToString();
            //GET_LOADING_DETAILS();
            //datagrid.Items.Refresh();
            RESERVATION RE = new RESERVATION();
            date.DisplayDateStart = DateTime.Today;
            DataTable d = RE.GETNAME();
            DataRow row = d.NewRow();
            row["ROOM_CATEGORY"] = "Select Room Type";
            d.Rows.InsertAt(row, 0);
            TXTCATEGORY.ItemsSource = d.DefaultView;
            BT = "add";
            save.Content = "Save";
            insertpop.Content = "insertpopup";
            
            rm.button = BT;
            DataTable st = rm.fetchplancode();
            plancode.ItemsSource = st.DefaultView;
            DataTable dt = rm.fill_mastergrid();
            dgroomrate.ItemsSource = dt.DefaultView;
            DataTable DR = rm.FETCH_AMENITIES();
            for (int r = 0; r < DR.Rows.Count; r++)
            {
                String A = DR.Rows[r]["AMENITY_NAME"].ToString();
                CheckBox CH = new CheckBox();
                CH.FontSize = 13;
                CH.Content = A;
                wp.Children.Add(CH);
            }
            ENABLE(); SET_DISABLE();
        }
        public void GET_LOADING_DETAILS()
        {
            DataTable d = rm.fetchroomtype();
            TXTCATEGORY.ItemsSource = d.DefaultView;
        }
        public void DISABLE()
        {
            txtroomno.IsEnabled = false;
            TXTCATEGORY.IsEnabled = false;
            txtroomview.IsEnabled = false;
            txtmaxpax.IsEnabled = false;
            date.IsEnabled = false;
            currency.IsEnabled = false;
            plancode.IsEnabled = false;
            txtsinglerate.IsEnabled = false;
            txtdoublerate.IsEnabled = false;
            txttriplerate.IsEnabled = false;
            txtquadrate.IsEnabled = false;
            txtsinglerateplan.IsEnabled = false;
            txtdoublerateplan.IsEnabled = false;
            txttriplerateplan.IsEnabled = false;
            txtquadrateplan.IsEnabled = false;
            save.IsEnabled = false;
            //clear.IsEnabled = false;
        }
        public void SET_DISABLE()
        {
            txtsinglerate.IsEnabled = false; txtdoublerate.IsEnabled = false; txttriplerate.IsEnabled = false;
            txtquadrate.IsEnabled = false; txtsinglerateplan.IsEnabled = false; txtdoublerateplan.IsEnabled = false;
            txtquadrateplan.IsEnabled = false; txttriplerateplan.IsEnabled = false; txtmaxpax.IsReadOnly = true;
        }
        public void ENABLE()
        {
            txtroomno.IsEnabled = true;
            TXTCATEGORY.IsEnabled = true;
            txtroomview.IsEnabled = true;
            txtmaxpax.IsEnabled = true;
            date.IsEnabled = true;
            currency.IsEnabled = true;
            plancode.IsEnabled = true;
            txtsinglerate.IsEnabled = true;
            txtdoublerate.IsEnabled = true;
            txttriplerate.IsEnabled = true;
            txtquadrate.IsEnabled = true;
            txtsinglerateplan.IsEnabled = true;
            txtdoublerateplan.IsEnabled = true;
            txttriplerateplan.IsEnabled = true;
            txtquadrateplan.IsEnabled = true;
            //status.IsEnabled = true;
            //add.IsEnabled = false; modify.IsEnabled = false; save.IsEnabled = true; clear.IsEnabled = true; txtmaxpax.IsReadOnly = true;
            //txtcommonplan.IsEnabled = false;
            //foreach (var CNT in wp.Children)
            //{
            //    var C = CNT as CheckBox;
            //    C.IsEnabled = true;
            //}
        }
        public void clearall()
        {
            CLEAR();
            //foreach (var CNT in wp.Children)
            //{
            //    var C = CNT as CheckBox;
            //    C.IsChecked = false;
            //    C.IsEnabled = false;
            //}
            //add.IsEnabled = true; modify.IsEnabled = true; save.IsEnabled = false; clear.IsEnabled = false; list.Visibility = Visibility.Hidden; status.Text = string.Empty;
            f = "";/* txtroomno.Clear();*/

            //add.IsEnabled = true; modify.IsEnabled = true; search.IsEnabled = true; save.IsEnabled = false; clear.IsEnabled = false;

        }
        public void CLEAR()
        {
            txtroomno.Clear(); TXTCATEGORY.Text = ""; txtroomview.Clear(); txtmaxpax.Clear(); date.Text = ""; currency.Text = ""; plancode.Text = "";
            txtsinglerate.Clear(); txtdoublerate.Clear(); txttriplerate.Clear(); txtquadrate.Clear(); txtcommonprice.Clear(); txtcommonplan.Clear();
            txtadult.Clear(); txtchild.Clear();txtsinglerateplan.Clear();txtdoublerateplan.Clear();txttriplerateplan.Clear();
            List<CheckBox> toRemove = new List<CheckBox>();
            foreach (var o in wp.Children)
            {
                if (o is CheckBox)
                    toRemove.Add((CheckBox)o);
            }
            for (int i = 0; i < toRemove.Count; i++)
            {
                wp.Children.Remove(toRemove[i]);
            }
            // add.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            //modify.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
        }
        public void BIND()
        {
            rm.ROOM_NO = Convert.ToInt16(txtroomno.Text);
            rm.ROOM_CATEGORY = TXTCATEGORY.Text;
            rm.ROOM_VIEW = txtroomview.Text;
            rm.MAX_PAX = Convert.ToInt16(txtmaxpax.Text);
            rm.CURRENCY = currency.Text;
            rm.PLANCODE = plancode.Text;
            if (txtsinglerate.Text=="")
            {
                txtsinglerate.Text = "0.00";
            }
            else
            {
                rm.SINGLERATE_TARRIF = Convert.ToDecimal(txtsinglerate.Text);

            }
            if (txtsinglerateplan.Text == "")
            {
                txtsinglerateplan.Text = "0.00";
            }
            else
            {
                rm.SINGLERATE_PLAN = Convert.ToDecimal(txtsinglerateplan.Text);

            }
            if(txtdoublerate.Text=="")
            {
                txtdoublerate.Text = "0.00";
            }
            else
            {
                rm.DOUBLERATE_TARRIF = Convert.ToDecimal(txtdoublerate.Text);

            }
            if (txtdoublerateplan.Text == "")
            {
                txtdoublerateplan.Text = "0.00";
            }
            else
            {
                rm.DOUBLERATE_PLAN = Convert.ToDecimal(txtdoublerateplan.Text);
            }
            if (txttriplerate.Text == "")
            {
                txttriplerate.Text = "0.00";
            }
            else
            {
                rm.TRIPLERATE_TARRIF = Convert.ToDecimal(txttriplerate.Text);

            }
            if(txttriplerateplan.Text =="")
            {
                txttriplerateplan.Text = "0.00";
            }
            else
            {
                rm.TRIPLERATE_PLAN = Convert.ToDecimal(txttriplerateplan.Text);

            }
            if(txtquadrate.Text=="")
            {
                txtquadrate.Text = "0.00";
            }
            else
            {
                rm.QUADRATE_TARRIF = Convert.ToDecimal(txtquadrate.Text);

            }
            if(txtquadrateplan.Text=="")
            {
                txtquadrateplan.Text = "0.00";
            }
            else
            {
                rm.QUADRATE_PLAN = Convert.ToDecimal(txtquadrateplan.Text);

            }
            rm.STATUS = status.Text;
            rm.ACTIVE_CALENDER = Convert.ToDateTime(date.SelectedDate.Value.Date.ToString());
            if(txtcommonprice.Text=="")
            {
                txtcommonprice.Text = "0.00";
            }
            else
            {
                rm.COMMON_PRICE = Convert.ToDecimal(txtcommonprice.Text);

            }
            rm.ADULT_EXTRABADCOST = Convert.ToDecimal(txtadult.Text);
            rm.CHILD_EXTRABEDCOST = Convert.ToDecimal(txtchild.Text);
            if(txtcommonplan.Text=="")
            {
                txtcommonplan.Text = "0.00";
            }
            else
            {
                rm.COMMON_PLAN = Convert.ToDecimal(txtcommonplan.Text);

            }
            rm.button = BT;
        }
        public static string f = null; public static string BT = null;
        private void add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtroomview.Text = "";
                txtmaxpax.Text = "";
                BT = "add";
                save.Content = "Save";
                insertpop.Content = "insertpopup";
                rm.button = BT;
                DataTable st = rm.fetchplancode();
                plancode.ItemsSource = st.DefaultView;
                DataTable DR = rm.FETCH_AMENITIES();
                for (int r = 0; r < DR.Rows.Count; r++)
                {
                    String A = DR.Rows[r]["AMENITY_NAME"].ToString();
                    CheckBox CH = new CheckBox();
                    CH.FontSize = 13;
                    CH.Content = A;
                    wp.Children.Add(CH);
                }
                ENABLE(); SET_DISABLE();

                // add.Background = new SolidColorBrush(Colors.Orange);
                //modify.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
            }
            catch (Exception) { }
        }
        //private void modify_Click(object sender, RoutedEventArgs e)
        //{
        //    BT = "modify";
        //    insertpop.Content = "updatepopup";
        //    rm.button = BT;
        //    ENABLE(); SET_DISABLE();
        //    save.Content = "Update";
        //    insertpop.Content = "updatepopup";

        //    modify.Background = new SolidColorBrush(Colors.Orange);
        //    //add.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
        //}
        //ToolTip TP = new ToolTip();
        //private void Validation_Error(object sender, ValidationErrorEventArgs e)
        //{
        //    if (e.Action == ValidationErrorEventAction.Added)
        //        error++;
        //    else
        //        error--;
        //}
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    pop1.IsOpen = false;
        //}
        //private void save_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {

        //        if (error != 0)
        //        {
        //            pop1.IsOpen = true;
        //        }
        //        else
        //        {
        //            DataTable dt = DataGridtoDataTable(datagrid);
        //            if (BT == "add")
        //            {
        //                if (txtroomno.Foreground != Brushes.Red)
        //                {

        //                    rm.DATATABLE_TO_SAVEDATA(dt);
        //                    MessageBox.Show("inserted sucessfully");
        //                }
        //                //string a1 = "insertpopup", b1 = Convert.ToString(insertpop.Content);
        //                //if (b1 == a1)
        //                //{
        //                //    insert.Content = "Inserted Sucessfully";
        //                //    pop2.IsOpen = true;
        //                //}

        //            }
        //            else
        //            {

        //            }
        //            if (BT == "modify")
        //            {

        //                //  insert.Content = "Updated Sucessfully";
        //                //pop2.IsOpen = true;
        //                rm.DATATABLE_TO_SAVEDATA(dt);
        //                MessageBox.Show("updated sucessfully");
        //            }
        //            int i = datagrid.Items.Count;

        //            for (int j = i - 1; j >= 0; j--)
        //            {
        //                datagrid.Items.RemoveAt(j);
        //            }
        //            DISABLE();
        //            clearall();
        //            this.NavigationService.Refresh();

        //            //add.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
        //            modify.Background = new SolidColorBrush(Color.FromRgb(53, 71, 102));
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("please Enter correct values");
        //    }
        //}
        public static DataTable DataGridtoDataTable(DataGrid dg)
        {
            dg.SelectAllCells();
            dg.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dg);
            dg.UnselectAllCells();
            String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            string[] Lines = result.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            string[] Fields;
            Fields = Lines[0].Split(new char[] { ',' });
            int Cols = Fields.GetLength(0);

            DataTable dt = new DataTable();
            for (int i = 0; i < Cols; i++)
                dt.Columns.Add(Fields[i].ToUpper(), typeof(string));
            DataRow Row;
            for (int i = 1; i < Lines.GetLength(0) - 1; i++)
            {
                Fields = Lines[i].Split(new char[] { ',' });
                Row = dt.NewRow();
                for (int f = 0; f < Cols; f++)
                {
                    Row[f] = Fields[f]; 
                }
                dt.Rows.Add(Row);
            }
            return dt;
        }
        //private void clear_Click(object sender, RoutedEventArgs e)
        //{
        //    DISABLE();
        //    clearall();
        //    this.NavigationService.Refresh();
        //}
        private void txtmaxpax_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtmaxpax.Text != "")
            {
                int maxpax = Convert.ToInt16(txtmaxpax.Text);
                if (plancode.Text == "")
                {
                    if (txtmaxpax.Text == "1")
                    {
                        txtsinglerate.IsEnabled = true;
                        txtdoublerate.IsEnabled = false;
                        txtdoublerate.Text = "0.00";
                        txttriplerate.IsEnabled = false;
                        txttriplerate.Text = "0.00";
                        txtquadrate.IsEnabled = false;
                        txtquadrate.Text = "0.00";
                        txtcommonplan.IsEnabled = false; txtcommonplan.Text = "0.00"; txtcommonprice.IsEnabled = false;
                    }
                    else if (txtmaxpax.Text == "2")
                    {
                        txtsinglerate.IsEnabled = true; txtdoublerate.IsEnabled = true; txttriplerate.IsEnabled = false;
                        txtquadrate.IsEnabled = false; txttriplerate.Text = "0.00"; txtquadrate.Text = "0.00"; txtcommonplan.Text = "0.00"; txtcommonplan.IsEnabled = false; txtcommonprice.IsEnabled = false;
                    }
                    else if (txtmaxpax.Text == "3")
                    {
                        txtsinglerate.IsEnabled = true; txtdoublerate.IsEnabled = true; txttriplerate.IsEnabled = true;
                        txtquadrate.IsEnabled = false; txtcommonplan.IsEnabled = false; txtquadrate.Text = "0.00"; txtcommonplan.Text = "0.00"; txtcommonprice.IsEnabled = false;
                    }
                    else if (txtmaxpax.Text == "4")
                    {
                        txtsinglerate.IsEnabled = true; txtdoublerate.IsEnabled = true; txttriplerate.IsEnabled = true;
                        txtquadrate.IsEnabled = true; txtcommonplan.IsEnabled = false; txtcommonplan.Text = "0.00"; txtcommonprice.IsEnabled = false;
                    }
                    else if (txtmaxpax.Text == "")
                    {
                        txtsinglerate.IsEnabled = false;
                        txtdoublerate.IsEnabled = false;
                        txttriplerate.IsEnabled = false;
                        txtquadrate.IsEnabled = false;
                    }
                    else if (maxpax > 4)
                    {
                        txtcommonplan.IsEnabled = true; txtcommonprice.IsEnabled = true;
                        txtsinglerate.IsEnabled = false; txtdoublerate.IsEnabled = false; txttriplerate.IsEnabled = false;
                        txtquadrate.IsEnabled = false;
                        // txtsinglerate.Text = "0.00"; txtdoublerate.Text = "0.00"; txttriplerate.Text = "0.00"; txtquadrate.Text = "0.00";
                        txtsinglerate.Text = txtcommonprice.Text; txtdoublerate.Text = txtcommonprice.Text;
                        txttriplerate.Text = txtcommonprice.Text; txtquadrate.Text = txtcommonprice.Text;
                    }
                }
                else
                {
                    switch (txtmaxpax.Text)
                    {
                        case "1":
                            txtsinglerate.IsEnabled = true; txtsinglerateplan.IsEnabled = true;
                            txtdoublerate.IsEnabled = false; txtdoublerateplan.IsEnabled = false;
                            txttriplerate.IsEnabled = false; txttriplerateplan.IsEnabled = false;
                            txtquadrate.IsEnabled = false; txtquadrateplan.IsEnabled = false;
                            txtcommonplan.IsEnabled = false;
                            break;
                        case "2":
                            txtsinglerate.IsEnabled = true; txtsinglerateplan.IsEnabled = true;
                            txtdoublerate.IsEnabled = true; txtdoublerateplan.IsEnabled = true;
                            txttriplerate.IsEnabled = false; txttriplerateplan.IsEnabled = false;
                            txtquadrate.IsEnabled = false; txtquadrateplan.IsEnabled = false;
                            txtcommonplan.IsEnabled = false;
                            break;
                        case "3":
                            txtsinglerate.IsEnabled = true; txtsinglerateplan.IsEnabled = true;
                            txtdoublerate.IsEnabled = true; txtdoublerateplan.IsEnabled = true;
                            txttriplerate.IsEnabled = true; txttriplerateplan.IsEnabled = true;
                            txtquadrate.IsEnabled = false; txtquadrateplan.IsEnabled = false;
                            txtcommonplan.IsEnabled = false;
                            break;
                        case "4":
                            txtsinglerate.IsEnabled = true; txtsinglerateplan.IsEnabled = true;
                            txtdoublerate.IsEnabled = true; txtdoublerateplan.IsEnabled = true;
                            txttriplerate.IsEnabled = true; txttriplerateplan.IsEnabled = true;
                            txtquadrate.IsEnabled = true; txtquadrateplan.IsEnabled = true;
                            txtcommonplan.IsEnabled = false;
                            break;
                        case "5":
                            if (maxpax > 4)
                            {
                                txtsinglerate.IsEnabled = false; txtdoublerate.IsEnabled = false; txttriplerate.IsEnabled = false;
                                txtquadrate.IsEnabled = false;
                                txtsinglerateplan.IsEnabled = false; txtdoublerateplan.IsEnabled = false; txttriplerateplan.IsEnabled = false; txtquadrateplan.IsEnabled = false;
                                txtcommonprice.IsEnabled = true; txtcommonplan.IsEnabled = true;
                                //txtsinglerate.Text = ""; txtdoublerate.Text = ""; txttriplerate.Text = ""; txtquadrate.Text = "";
                                //txtsinglerateplan.Text = ""; txtdoublerateplan.Text = ""; txttriplerateplan.Text = ""; txtquadrateplan.Text = "";
                            }
                            break;
                    }
                }
                txtcommonprice.IsEnabled = true;
                if (txtcommonprice.Text != "")
                {
                    filltext();
                }
            }
        }
        public static int b = 0;
        public void filltext()
        {
            b = Convert.ToInt16(txtmaxpax.Text);
            if (b == 1)
            {
                txtsinglerate.Text = txtcommonprice.Text;
                txtdoublerate.Text = "0.00"; txttriplerate.Text = "0.00"; txtquadrate.Text = "0.00";
            }
            else if (b == 2)
            {
                txtsinglerate.Text = txtcommonprice.Text; txtdoublerate.Text = txtcommonprice.Text; txttriplerate.Text = "0.00";
                txtquadrate.Text = "0.00";
            }
            else if (b == 3)
            {
                txtsinglerate.Text = txtcommonprice.Text; txtdoublerate.Text = txtcommonprice.Text; txttriplerate.Text = txtcommonprice.Text;
                txtquadrate.Text = "0.00";
            }
            else if (b == 4)
            {
                txtsinglerate.Text = txtcommonprice.Text; txtdoublerate.Text = txtcommonprice.Text; txttriplerate.Text = txtcommonprice.Text;
                txtquadrate.Text = txtcommonprice.Text;
            }
           
        }
        public static string Amenity_checks = null;
        private void plancode_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                string y = "Update"; string z = Convert.ToString(save.Content);
                if (y == z)
                {
                    DataTable dt = rm.RoomTarrif();
                    if (dt.Rows.Count == 0)
                    { }
                    else
                    {
                        txtsinglerate.Text = dt.Rows[0]["SINGLERATE_TARRIF"].ToString();
                        txtdoublerate.Text = dt.Rows[0]["DOUBLERATE_TARRIF"].ToString();
                        txttriplerate.Text = dt.Rows[0]["TRIPLERATE_TARRIF"].ToString();
                        txtquadrate.Text = dt.Rows[0]["QUADRATE_TARRIF"].ToString();
                        txtcommonprice.Text = dt.Rows[0]["COMMON_PRICE"].ToString();
                        txtadult.Text = dt.Rows[0]["EXTRABED_ADULT"].ToString();
                        txtchild.Text = dt.Rows[0]["EXTRABED_CHILD"].ToString();
                    }
                }
                if (txtmaxpax.Text != "")
                {
                    if (plancode.Text != "")
                    {
                        int b = Convert.ToInt16(txtmaxpax.Text);
                        if (b == 1)
                        {
                            txtsinglerateplan.IsEnabled = true; txtdoublerateplan.IsEnabled = false; txtdoublerateplan.Text = "0.00"; txttriplerateplan.IsEnabled = false;
                            txttriplerateplan.Text = "0.00"; txtquadrateplan.Text = "0.00";
                            txtquadrateplan.IsEnabled = false;
                        }
                        else if (b == 2)
                        {
                            txtsinglerateplan.IsEnabled = true; txtdoublerateplan.IsEnabled = true; txttriplerateplan.IsEnabled = false;
                            txttriplerateplan.Text = "0.00"; txtquadrateplan.Text = "0.00";
                            txtquadrateplan.IsEnabled = false;
                        }
                        else if (b == 3)
                        {
                            txtsinglerateplan.IsEnabled = true; txtdoublerateplan.IsEnabled = true; txttriplerateplan.IsEnabled = true;
                            txtquadrateplan.Text = "0.00";
                            txtquadrateplan.IsEnabled = false;
                        }
                        else if (b == 4)
                        {
                            txtsinglerateplan.IsEnabled = true; txtdoublerateplan.IsEnabled = true; txttriplerateplan.IsEnabled = true;
                            txtquadrateplan.IsEnabled = true;
                        }
                        else if (b > 4)
                        {
                            txtsinglerateplan.IsEnabled = false; txtdoublerateplan.IsEnabled = false; txttriplerateplan.IsEnabled = false;
                            txtsinglerateplan.Text = "0.00"; txtdoublerate.Text = "0.00"; txttriplerate.Text = "0.00"; txtquadrate.Text = "0.00";
                            txtquadrateplan.IsEnabled = false; txtcommonplan.IsEnabled = true;
                        }
                        if (save.Content.ToString() == "Update")
                        {
                            rm.PLANCODE = plancode.Text;
                            rm.fetch_plancode_isselected();
                            txtsinglerateplan.Text = rm.SINGLERATE_PLAN.ToString();
                            txtdoublerateplan.Text = rm.DOUBLERATE_PLAN.ToString();
                            txttriplerateplan.Text = rm.TRIPLERATE_PLAN.ToString();
                            txtquadrateplan.Text = rm.QUADRATE_PLAN.ToString();
                            txtcommonplan.Text = rm.COMMON_PLAN.ToString();
                        }
                        if (plancode.Text != "")
                        {
                            rm.PLANCODE = plancode.Text;
                            rm.fetch_plancode_isselected();
                            txtsinglerateplan.Text = rm.SINGLERATE_PLAN.ToString();
                            txtdoublerateplan.Text = rm.DOUBLERATE_PLAN.ToString();
                            txttriplerateplan.Text = rm.TRIPLERATE_PLAN.ToString();
                            txtquadrateplan.Text = rm.QUADRATE_PLAN.ToString();
                            txtcommonplan.Text = rm.COMMON_PLAN.ToString();
                        }
                    }
                }
                if (y == z)
                {
                    PC = plancode.Text;
                    DataTable dt1 = rm.planaa();
                    if (dt1.Rows.Count == 0)
                    {

                    }
                    else if (plancode.Text != "")
                    {
                        txtsinglerateplan.Text = dt1.Rows[0]["SINGLE_PLAN"].ToString();
                        txtdoublerateplan.Text = dt1.Rows[0]["DOUBLE_PLAN"].ToString();
                        txttriplerateplan.Text = dt1.Rows[0]["TRIPLE_PLAN"].ToString();
                        txtquadrateplan.Text = dt1.Rows[0]["QUAD_PLAN"].ToString();
                    }
                }
            }
            catch (Exception) { }
        }
        private void txtcommonprice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DATA != 1)
            {

                if (txtmaxpax.Text != "")
                {
                    int b = Convert.ToInt16(txtmaxpax.Text);
                    if (b <= 4)
                    {
                        filltext();
                    }
                    if (b > 4)
                    {
                        //txtsinglerate.IsEnabled = false; txtdoublerate.IsEnabled = false; txttriplerate.IsEnabled = false; txtquadrate.IsEnabled = false;
                        txtsinglerate.Text = txtcommonprice.Text; txtdoublerate.Text = txtcommonprice.Text; txttriplerate.Text = txtcommonprice.Text; txtquadrate.Text = txtcommonprice.Text;
                    }
                }
            }
        }
        public static int DATA = 0;
        public void GET_CHECKED_AMENITY()
        {
            DATA = 1;
            if (txtsinglerate.Text == "")
            {
                txtsinglerate.Text = "0.00";
            }
            if (txtsinglerateplan.Text == "")
            {
                txtsinglerateplan.Text = "0.00";
            }
            if (txtdoublerate.Text == "")
            {
                txtdoublerate.Text = "0.00";
            }
            if (txtdoublerateplan.Text == "")
            {
                txtdoublerateplan.Text = "0.00";
            }
            if (txttriplerate.Text == "")
            {
                txttriplerate.Text = "0.00";
            }
            if (txttriplerateplan.Text == "")
            {
                txttriplerateplan.Text = "0.00";
            }
            if (txtquadrate.Text == "")
            {
                txtquadrate.Text = "0.00";
            }
            if (txtquadrateplan.Text == "")
            {
                txtquadrateplan.Text = "0.00";
            }
            if (txtcommonprice.Text == "")
            {
                txtcommonprice.Text = "0.00";
            }
            if (txtadult.Text == "")
            {
                txtadult.Text = "0.00";
            }
            if (txtchild.Text == "")
            {
                txtchild.Text = "0.00";
            }
            //if (date.Text == "")
            //{
            //    MessageBox.Show("please select the date"); return;
            //}
            if (txtroomview.Text == "")
            {
                MessageBox.Show("please enter room view"); return;
            }
            if (txtcommonplan.Text == "")
            {
                txtcommonplan.Text = "0.00";
            }
            foreach (var ctrl in wp.Children)
            {
                var c = ctrl as CheckBox;
                if (c != null && c.IsChecked == true)
                {
                    if (Amenity_checks == "")
                    {
                        Amenity_checks = c.Content.ToString();
                    }

                    else
                    {
                        Amenity_checks = Amenity_checks + " " + c.Content.ToString();
                    }
                }
            }
            DATA = 0;
        }
        //private void Confirm_Click_1(object sender, RoutedEventArgs e)
        //{
        //    GET_CHECKED_AMENITY();
        //    datagrid.Items.Add(new Roommaster { ROOM_NO = Convert.ToInt16(txtroomno.Text), ROOM_VIEW = txtroomview.Text, ROOM_CATEGORY = TXTCATEGORY.Text, MAX_PAX = Convert.ToInt16(txtmaxpax.Text), ACTIVE_CALENDER = Convert.ToDateTime(date.SelectedDate.Value.Date.ToString()), CURRENCY = currency.Text, PLANCODE = plancode.Text, SINGLERATE_TARRIF = Convert.ToDecimal(txtsinglerate.Text), SINGLERATE_PLAN = Convert.ToDecimal(txtsinglerateplan.Text), DOUBLERATE_TARRIF = Convert.ToDecimal(txtdoublerate.Text), DOUBLERATE_PLAN = Convert.ToDecimal(txtdoublerateplan.Text), TRIPLERATE_TARRIF = Convert.ToDecimal(txttriplerate.Text), TRIPLERATE_PLAN = Convert.ToDecimal(txttriplerateplan.Text), QUADRATE_TARRIF = Convert.ToDecimal(txtquadrate.Text), QUADRATE_PLAN = Convert.ToDecimal(txtquadrateplan.Text), STATUS = status.Text, COMMON_PRICE = Convert.ToDecimal(txtcommonprice.Text), ADULT_EXTRABADCOST = Convert.ToDecimal(txtadult.Text), CHILD_EXTRABEDCOST = Convert.ToDecimal(txtchild.Text), AMENITY_NAMES = Amenity_checks, COMMON_PLAN = Convert.ToDecimal(txtcommonplan.Text) });
        //    Amenity_checks = null;
        //    txtsinglerateplan.IsEnabled = false; txtdoublerateplan.IsEnabled = false; plancode.Text = ""; txtsinglerateplan.Text = ""; txtdoublerateplan.Text = ""; txttriplerateplan.Text = ""; txtquadrateplan.Text = ""; txtcommonplan.Text = "";
        //    txttriplerateplan.IsEnabled = false; txtquadrateplan.IsEnabled = false;
        //    if (BT == "add")
        //    {
        //        tb.Text = "Do you want to add another plancode";
        //        popup.IsOpen = true;

        //    }
        //}
        public int count = 0;
        public static string plan;
        private void yes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (count == 0)
                {
                    string a = "Save"; string b = Convert.ToString(save.Content);
                    if (a == b)
                    {
                        rm.INSERT1();
                        DataTable dt1 = rm.fill_mastergrid();
                        dgroomrate.ItemsSource = dt1.DefaultView;
                    }
                    count++;
                }
                plancode.Text = string.Empty;
                plancode.IsDropDownOpen = true;
                //DataTable dp = rm.RoomPlan();
                //int j = plancode.SelectedIndex;
                //plan = dp.Rows[j]["PLAN_CODE"].ToString();
                //if (plancode.Text != plan)
                //{
                //    string a = "Save"; string b = Convert.ToString(save.Content);
                //    if (a == b)
                //    {
                //        rm.INSERT1();
                //        DataTable dt1 = rm.fill_mastergrid();
                //        dgroomrate.ItemsSource = dt1.DefaultView;
                //    }
                //   // count++;
                //}
                popup.IsOpen = false;
                if (plancode.Text != "")
                {
                    if (txtsinglerateplan.IsEnabled == true)
                    {
                        if (txtsinglerateplan.Text == "")
                        { txtsinglerateplan.Text = ""; }
                        txtsinglerateplan.Text = string.Empty;
                    }
                    if (txtdoublerateplan.IsEnabled == true)
                    {
                        if (txtdoublerateplan.Text == "")
                        { txtdoublerateplan.Text = ""; }
                        txtdoublerateplan.Text = string.Empty;
                    }
                    if (txttriplerateplan.IsEnabled == true)
                    {
                        if (txttriplerateplan.Text == "")
                        { txttriplerateplan.Text = ""; }
                        txttriplerateplan.Text = string.Empty;
                    }
                    if (txtquadrateplan.IsEnabled == true)
                    {
                        if (txtquadrateplan.Text == "")
                        { txtquadrateplan.Text = ""; }
                        txtquadrateplan.Text = string.Empty;
                    }
                }
            }
            catch (Exception) { }
        }
        private void no_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // CLEAR(); status.Text = "";
                popup.IsOpen = false;
                string a = "Save"; string b = Convert.ToString(save.Content);
                if (a == b)
                {
                    rm.INSERT();
                    DataTable dt1 = rm.fill_mastergrid();
                    dgroomrate.ItemsSource = dt1.DefaultView;
                    //MessageBox.Show("Saved Successfully");
                    popup_insert.IsOpen = true;
                    clearall();
                    this.NavigationService.Refresh();

                }
                else
                {
                    rm.UPDATE();
                    DataTable dt1 = rm.fill_mastergrid();
                    dgroomrate.ItemsSource = dt1.DefaultView;
                    //MessageBox.Show("Updated Successfully");
                    popup_update.IsOpen = true;
                    clearall();
                    this.NavigationService.Refresh();
                }
            }
            catch (Exception) { }
        }
        //public void setplan()
        //{

        //        if (txtmaxpax.Text != "")
        //        {
        //            string s = string.Empty;
        //          b = Convert.ToInt16(txtmaxpax.Text);
        //            if (b == 1)
        //            {
        //                txtsinglerateplan.Text = txtcommonplan.Text; txtdoublerateplan.Text = s;
        //                txttriplerateplan.Text = s;txtquadrateplan.Text = s;
        //            }
        //            if (b== 2)
        //            {
        //                txtsinglerateplan.Text = txtcommonplan.Text;
        //                txtdoublerateplan.Text = txtcommonplan.Text;
        //                txttriplerateplan.Text = s; txtquadrateplan.Text = s;
        //            }
        //            if (b == 3)
        //            {
        //                txtsinglerateplan.Text = txtcommonplan.Text;
        //                txtdoublerateplan.Text = txtcommonplan.Text;
        //                txttriplerateplan.Text = txtcommonplan.Text;
        //                txtquadrateplan.Text = s;
        //            }
        //            if (b == 4)
        //            {
        //                txtsinglerateplan.Text = txtcommonplan.Text;
        //                txtdoublerateplan.Text = txtdoublerateplan.Text;
        //                txttriplerateplan.Text = txtcommonplan.Text;
        //                txtquadrateplan.Text = txtcommonplan.Text;
        //            }

        //        }
        //    }
        private void txtcommonplan_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DATA != 1)
            {

            }
        }
        DataTable D = null;
        private void txtroomno_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string a = txtroomno.Text;
                Regex n = new Regex(@"^[0-9]+$");
                if (BT == "add")
                {
                    if (n.IsMatch(a))
                    {
                        if (txtroomno.Text != "")
                        {

                            rm.ROOM_NO = Convert.ToInt16(txtroomno.Text);
                            rm.GET_STATUS_OF_DATA();
                            if (rm.EXIST == 0)
                            {
                                //TP.IsOpen = false;
                                txtroomno.Foreground = Brushes.Black;
                            }
                            else if (rm.EXIST == 1)
                            {
                                string x = "Update"; string y = Convert.ToString(save.Content);
                                if (x != y)
                                {
                                    txtroomno.Foreground = Brushes.Red;
                                    MessageBox.Show("This roomno already exists");
                                }
                            }
                        }
                    }
                }
                if (BT == "modify")
                {

                    if (txtroomno.Text != "")
                    {
                        rm.ROOM_NO = Convert.ToInt16(txtroomno.Text);
                        DataTable dt = rm.GET_STATUS_OF_DATA();
                        List<CheckBox> toRemove = new List<CheckBox>();
                        foreach (var o in wp.Children)
                        {
                            if (o is CheckBox)
                                toRemove.Add((CheckBox)o);
                        }
                        for (int i = 0; i < toRemove.Count; i++)
                        {
                            wp.Children.Remove(toRemove[i]);
                        }

                        if (rm.match == 1)
                        {

                            foreach (var o in wp.Children)
                            {
                                if (o is CheckBox)
                                    toRemove.Add((CheckBox)o);
                            }
                            for (int i = 0; i < toRemove.Count; i++)
                            {
                                wp.Children.Remove(toRemove[i]);
                            }
                            DataTable DTBL = rm.fetch_PLANCODE_MODIFY();
                            plancode.ItemsSource = DTBL.DefaultView;
                            for (int r = 0; r < dt.Rows.Count; r++)
                            {
                                string NAME = dt.Rows[r]["AMENITY"].ToString();
                                string AMENITY = rm.GET_AMENITY(NAME);
                                CheckBox CH = new CheckBox();
                                CH.Content = NAME;
                                wp.Children.Add(CH);
                                if (AMENITY == "yes")
                                {
                                    CH.IsChecked = true;
                                    CH.IsEnabled = true;
                                }
                                else if (AMENITY == "no")
                                {
                                    CH.IsChecked = false;
                                    CH.IsEnabled = true;
                                }
                            }
                            BIND_FETCHED_DATA();

                        }
                        else
                        {
                            BIND_FETCHED_DATA_CLEAR();
                            foreach (var CNTRL in wp.Children)
                            {
                                var C = CNTRL as CheckBox;
                                if (C != null)
                                {
                                    C.IsChecked = false;
                                    C.IsEnabled = true;
                                }

                            }

                        }
                        if (rm.match != 1)
                        {

                            D = rm.setdata();
                            if (D != null)
                            {
                                //list.ItemsSource = D.DefaultView;
                                //list.Visibility = Visibility.Visible;

                            }
                            txtroomno.Text = rm.d;
                            int b = rm.d.Length;
                            txtroomno.Select(txtroomno.Text.Length, b);

                        }
                    }
                    rm.GETCOUNT(); if (rm.pc == 1)
                    {
                        txtroomno.Text = string.Empty; rm.pc = 0;
                    }
                }
            }
            catch (Exception) { }
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (BT == "modify")
                {
                    //list.Items.Refresh();
                    //list.Visibility = Visibility.Hidden;
                    string w = "SELECT * FROM ROOMMASTER WHERE ROOM_NO='" + txtroomno.Text + "'";
                    DataTable dt = rm.fetchdata(w);
                    List<CheckBox> toRemove = new List<CheckBox>();
                    foreach (var o in wp.Children)
                    {
                        if (o is CheckBox)
                            toRemove.Add((CheckBox)o);
                    }
                    for (int i = 0; i < toRemove.Count; i++)
                    {
                        wp.Children.Remove(toRemove[i]);
                    }
                    for (int r = 0; r < dt.Rows.Count; r++)
                    {
                        string NAME = dt.Rows[r]["AMENITY"].ToString();
                        string AMENITY = rm.GET_AMENITY(NAME);
                        CheckBox CH = new CheckBox();
                        CH.Content = NAME;
                        wp.Children.Add(CH);
                        if (AMENITY == "yes")
                        {
                            CH.IsChecked = true;
                            CH.IsEnabled = true;
                        }
                        else if (AMENITY == "no")
                        {
                            CH.IsChecked = false;
                            CH.IsEnabled = true;
                        }
                        DataTable DTBL = rm.fetch_PLANCODE_MODIFY();
                        plancode.ItemsSource = DTBL.DefaultView;
                        BIND_FETCHED_DATA();
                        //list.Visibility = Visibility.Hidden;

                    }
                }
            }
            catch (Exception) { }
        }
        private void txtroomno_GotFocus(object sender, RoutedEventArgs e)
        {
            if (BT == "modify")
            {
                if (txtroomno.Text != "")
                {
                    DataTable DT = rm.setdata();
                    if (DT != null)
                    {
                        //list.ItemsSource = D.DefaultView;
                        //list.Visibility = Visibility.Visible;
                    }
                }
            }
        }
        private void txtroomno_LostFocus(object sender, RoutedEventArgs e)
        {
            //list.Visibility = Visibility.Hidden;
        }
        private void txtroomno_KeyUp(object sender, KeyEventArgs e)
        {
            if (BT == "modify")
            {
                if (e.Key == Key.Back)
                {
                    if (rm.c != 1)
                    {
                        rm.CLEARBACK(); rm.c = 0;
                    }
                    if (txtroomno.Text.Length == 0)
                    {
                        //list.Visibility = Visibility.Hidden;

                    }
                }
            }
        }
        public void BIND_FETCHED_DATA()
        {
            txtroomno.Text = rm.ROOM_NO.ToString();
            TXTCATEGORY.Text = rm.ROOM_CATEGORY;
            txtroomview.Text = rm.ROOM_VIEW;
            txtmaxpax.Text = rm.MAX_PAX.ToString();
            date.Text = rm.ACTIVE_CALENDER.ToShortDateString();
            currency.Text = rm.CURRENCY;
            //plancode.Text = rm.PLANCODE;
            txtsinglerate.Text = rm.SINGLERATE_TARRIF.ToString();
            //txtsinglerateplan.Text = rm.SINGLERATE_PLAN.ToString();
            txtdoublerate.Text = rm.DOUBLERATE_TARRIF.ToString();
            //txtdoublerateplan.Text = rm.DOUBLERATE_PLAN.ToString();
            txttriplerate.Text = rm.TRIPLERATE_TARRIF.ToString();
            //txttriplerateplan.Text = rm.TRIPLERATE_PLAN.ToString();
            txtquadrate.Text = rm.QUADRATE_TARRIF.ToString();
            //txtquadrateplan.Text = rm.QUADRATE_PLAN.ToString();
            txtcommonprice.Text = rm.COMMON_PRICE.ToString();
            //txtcommonplan.Text = rm.COMMON_PLAN.ToString();
            txtadult.Text = rm.ADULT_EXTRABADCOST.ToString();
            txtchild.Text = rm.CHILD_EXTRABEDCOST.ToString();
            status.Text = rm.STATUS;
        }
        public void BIND_FETCHED_DATA_CLEAR()
        {
            txtroomno.Text = rm.ROOM_NO.ToString();
            TXTCATEGORY.Text = rm.ROOM_CATEGORY;
            txtroomview.Text = rm.ROOM_VIEW;
            txtmaxpax.Text = rm.MAX_PAX.ToString();
            date.Text = rm.ACTIVE_CALENDER.ToShortDateString();
            currency.Text = rm.CURRENCY;
            plancode.Text = rm.PLANCODE;
            txtsinglerate.Text = rm.SINGLERATE_TARRIF.ToString();
            txtsinglerateplan.Text = rm.SINGLERATE_PLAN.ToString();
            txtdoublerate.Text = rm.DOUBLERATE_TARRIF.ToString();
            txtdoublerateplan.Text = rm.DOUBLERATE_PLAN.ToString();
            txttriplerate.Text = rm.TRIPLERATE_TARRIF.ToString();
            txttriplerateplan.Text = rm.TRIPLERATE_PLAN.ToString();
            txtquadrate.Text = rm.QUADRATE_TARRIF.ToString();
            txtquadrateplan.Text = rm.QUADRATE_PLAN.ToString();
            txtcommonprice.Text = rm.COMMON_PRICE.ToString();
            txtcommonplan.Text = rm.COMMON_PLAN.ToString();
            txtadult.Text = rm.ADULT_EXTRABADCOST.ToString();
            txtchild.Text = rm.CHILD_EXTRABEDCOST.ToString();
            status.Text = rm.STATUS;
        }
        private void date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BT == "add")
            {
                if (date.SelectedDate < DateTime.Today.Date)
                {
                    MessageBox.Show("Active from date cannot be less than the current date");
                    date.Text = "";
                }
                else if (date.SelectedDate == DateTime.Today.Date)
                {
                    date.Text = Convert.ToString(DateTime.Today.Date);
                }
            }
            else if (BT == "modify")
            {
            }
        }
        private void TXTCATEGORY_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                DataRowView dt = null;
                if (TXTCATEGORY.SelectedIndex == -1)
                {
                    dt = TXTCATEGORY.Items[TXTCATEGORY.SelectedIndex + 1] as DataRowView;
                }
                else if (TXTCATEGORY.SelectedIndex == TXTCATEGORY.Items.Count - 1)
                {
                    dt = TXTCATEGORY.Items[TXTCATEGORY.SelectedIndex] as DataRowView;
                }
                else
                {
                    dt = TXTCATEGORY.Items[TXTCATEGORY.SelectedIndex] as DataRowView;
                }
                string sValue = string.Empty;
                if (dt != null)
                {

                    sValue = dt.Row["ROOM_CATEGORY"] as string;
                    TXTCATEGORY.Text = sValue;
                    String S = "SELECT MAXPAX FROM ROOMCATEGORY WHERE ROOM_CATEGORY='" + TXTCATEGORY.Text + "'";
                    DataTable DR = rm.SETMAXPAX(S, TXTCATEGORY.Text);
                    for (int r = 0; r < DR.Rows.Count; r++)
                    {
                        txtmaxpax.Text = DR.Rows[r]["MAXPAX"].ToString();
                    }
                }
            }
            catch (Exception) { }
        }
        private void TXTCATEGORY_DropDownClosed(object sender, EventArgs e)
        {
            String S = "SELECT MAXPAX FROM ROOMCATEGORY WHERE ROOM_CATEGORY='" + TXTCATEGORY.Text + "'";
            DataTable DR = rm.SETMAXPAX(S, TXTCATEGORY.Text);
            for (int r = 0; r < DR.Rows.Count; r++)
            {
                txtmaxpax.Text = DR.Rows[r]["MAXPAX"].ToString();
            }
        }
        private void insertpop_Click(object sender, RoutedEventArgs e)
        {
            popup_insert.IsOpen = false;
        }
        private void hlClr_Click(object sender, RoutedEventArgs e)
        {
            clearall();
            this.NavigationService.Refresh();
        }
        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (error != 0 || txtroomno.Text == "" || date.Text == ""|| txtroomview.Text == "")
                {
                    date.Text = "";
                    // pop1.IsOpen = true;
                    if (txtroomno.Text == "")
                    { txtroomno.Text = ""; }
                    if(txtroomview.Text=="")
                    { txtroomview.Text = ""; }
                    if (date.Text == "")
                    {
                        date.Text = string.Empty;
                        date.Text = null;
                    }
                }
                else
                {
                    BIND();
                    GET_CHECKED_AMENITY();
                    if (Amenity_checks == null)
                    {
                        rm.AMENITY_NAMES = Amenity_checks;
                    }
                    else
                    {
                        rm.AMENITY_NAMES = Amenity_checks;
                    }
                    DataTable dt = rm.fill_mastergrid();
                    dgroomrate.ItemsSource = dt.DefaultView;
                    if (BT == "add")
                    {
                        tb.Text = "Do you want to add another plancode";
                        popup.IsOpen = true;
                    }
                    //MessageBoxResult result = MessageBox.Show("Do you Want to change Plancode??", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    //if (result == MessageBoxResult.Yes)
                    //{
                    //    plancode.IsDropDownOpen = true;
                    //}

                    //else
                    //{
                    //    string a = "Save"; string b = Convert.ToString(save.Content);
                    //    if (a == b)
                    //    {
                    //        rm.INSERT();
                    //        DataTable dt1 = rm.fill_mastergrid();
                    //        dgroomrate.ItemsSource = dt1.DefaultView;
                    //        MessageBox.Show("Saved Successfully");
                    //        clearall();
                    //        this.NavigationService.Refresh();
                    //    }
                    //    else
                    //    {

                    //        rm.UPDATE();
                    //        DataTable dt1 = rm.fill_mastergrid();
                    //        dgroomrate.ItemsSource = dt1.DefaultView;
                    //        MessageBox.Show("Updated Successfully");
                    //        clearall();
                    //        this.NavigationService.Refresh();
                    //    }
                    //}
                    //   this.NavigationService.Refresh();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("please Enter correct values");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
        private void DataGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int i = dgroomrate.SelectedIndex;
            DataTable dt = rm.fill_masterdata();
            if (dt.Rows.Count == 0)
            { }
            else
            {
                if (i >= 0)
                {
                    save.Content = "Update";
                    txtroomno.Text = dt.Rows[i]["ROOM_NO"].ToString();
                    txtroomno.IsReadOnly = true;
                    TXTCATEGORY.Text = dt.Rows[i]["ROOM_CATEGORY"].ToString();
                    txtmaxpax.Text = dt.Rows[i]["MAX_PAX"].ToString();
                    PAX =Convert.ToInt32(txtmaxpax.Text);
                    //date.Text = Convert.ToDateTime(dt.Rows[i]["ACTIVE_DATE"]).ToString();
                    status.Text = dt.Rows[i]["STATUS"].ToString();
                    txtroomview.Text = dt.Rows[i]["ROOM_VIEW"].ToString();
                    currency.Text = dt.Rows[i]["CURRENCY"].ToString();
                    txtsinglerate.Text = dt.Rows[i]["SINGLERATE_TARRIF"].ToString();
                    txtdoublerate.Text = dt.Rows[i]["DOUBLERATE_TARRIF"].ToString();
                    txttriplerate.Text = dt.Rows[i]["TRIPLERATE_TARRIF"].ToString();
                    txtquadrate.Text = dt.Rows[i]["QUADRATE_TARRIF"].ToString();
                    txtcommonprice.Text = dt.Rows[i]["COMMON_PRICE"].ToString();
                    txtadult.Text = dt.Rows[i]["EXTRABED_ADULT"].ToString();
                    txtchild.Text = dt.Rows[i]["EXTRABED_CHILD"].ToString();
                    //plancode.Text = dt.Rows[i]["PLAN_CODE"].ToString();
                    //PC = plancode.Text;
                    //plancode.SelectedIndex = 0;
                    GET_CHECKED_AMENITY();
                    DataTable dt1 = rm.planaa();
                    if (dt1.Rows.Count == 0)
                    {
                    }
                    else if (plancode.Text != "")
                    {
                        txtsinglerateplan.Text = dt1.Rows[0]["SINGLE_PLAN"].ToString();
                        txtdoublerateplan.Text = dt1.Rows[0]["DOUBLE_PLAN"].ToString();
                        txttriplerateplan.Text = dt1.Rows[0]["TRIPLE_PLAN"].ToString();
                        txtquadrateplan.Text = dt1.Rows[0]["QUAD_PLAN"].ToString();
                        if(PAX==1)
                        {
                            txtsinglerateplan.IsEnabled = true; txtdoublerateplan.IsEnabled = false; txttriplerateplan.IsEnabled = false; txtquadrateplan.IsEnabled = false;
                        }
                        else if(PAX==2)
                        {
                            txtsinglerateplan.IsEnabled = true; txtdoublerateplan.IsEnabled = true; txttriplerateplan.IsEnabled = false; txtquadrateplan.IsEnabled = false;
                        }
                        else if(PAX==3)
                        {
                            txtsinglerateplan.IsEnabled = true; txtdoublerateplan.IsEnabled = true; txttriplerateplan.IsEnabled = true; txtquadrateplan.IsEnabled = false;
                        }
                        else if(PAX==4)
                        {
                            txtsinglerateplan.IsEnabled = true; txtdoublerateplan.IsEnabled = true; txttriplerateplan.IsEnabled = true; txtquadrateplan.IsEnabled = true;
                        }
                        else if(PAX>4)
                        {
                            txtsinglerateplan.IsEnabled = false; txtdoublerateplan.IsEnabled = false; txttriplerateplan.IsEnabled = false; txtquadrateplan.IsEnabled = false;
                            txtcommonplan.IsEnabled = true;
                        }
                    }
                }
            }
        }
        public static string PC;
        public static int PAX;
        private void txtroomno_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
        }

        private void updatepop_Click(object sender, RoutedEventArgs e)
        {
            popup_update.IsOpen = false;
        }

    }
}