using HMS.mainwindowpages;
using HMS.Model;
using HMS.Model.Masters;
using HMS.View.Masters;
using PreLoader.CustomControls;
using System;
using System.Data;
using System.Windows;
using OfficeExcel = Microsoft.Office.Interop.Excel;
using System.Windows.Input;
using System.Windows.Threading;
using System.ComponentModel;

namespace HMS.View
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        Hotelinfo h = new Hotelinfo();
        registration r = new registration();
        login L = new login();
        Userpermission u = new Userpermission();
        PreLoaderControl preLoader = new PreLoaderControl();
        public Main()
        {
            InitializeComponent();
            DataTable dt = h.get();
            if (dt.Rows.Count == 0)
            {
                txtblock.Text = "";
                Hotel_Name = "";
            }
            else
            {
                txtblock.Text = Convert.ToString(dt.Rows[0]["NAME"]);
                Hotel_Name = txtblock.Text;
            }
            DataTable D = r.user();
            user.Text = login.u;
        }
        private void logout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void popupMasteropen_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new Uri("mainwindowpages/masters.xaml", UriKind.RelativeOrAbsolute));
        }
        private void btndashboard_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new Uri("mainwindowpages/DB.xaml", UriKind.RelativeOrAbsolute));
        }
        private void btnhome_Click(object sender, RoutedEventArgs e)
        {
            //PreLoaderPopup.IsOpen = true;
            //DisableButtons();
            //MyWorker.DoWork += worker_DoWorkHome;
            //MyWorker.RunWorkerCompleted += worker_RunWorkerCompletedHome;
            //MyWorker.RunWorkerAsync();
            this.frame.Navigate(new Uri("mainwindowpages/home.xaml", UriKind.RelativeOrAbsolute));
        }
        private void btnopr_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new Uri("mainwindowpages/operations.xaml", UriKind.RelativeOrAbsolute));
        }
        //private void btnrpt_Click(object sender, RoutedEventArgs e)
        //{
        //    reports r = new reports();
        //    r.Show();
        //}
        private void Btnclsmenu_Click(object sender, RoutedEventArgs e)
        {
            btnopenmenu.Visibility = Visibility.Visible;
            Btnclsmenu.Visibility = Visibility.Hidden;
        }
        private void btnopenmenu_Click(object sender, RoutedEventArgs e)
        {
            btnopenmenu.Visibility = Visibility.Hidden;
            Btnclsmenu.Visibility = Visibility.Visible;
        }
        private void ScrollViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
                e.Handled = true;
        }
        private void btnpermissions_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable d = u.MASTER1();
                if (d.Rows.Count == 0)
                {
                    MessageBox.Show(" YOU DON'T HAVE PERMISSIONS CONTANCT VELSOL PVT LIMITED");
                }
                else
                {
                    int PERMISSION = int.Parse(d.Rows[0]["USERPEMISSIONS"].ToString());
                    if (PERMISSION == 1)
                    {
                        this.frame.Navigate(new Uri("View/Masters/UserPermissions.xaml", UriKind.RelativeOrAbsolute));
                    }
                    else
                    {
                        MessageBox.Show("YOU DON'T HAVE A PERMISSION TO OPEN THIS PAGE");
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void FOT_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new Uri("Reports/frontofficeReport.xaml", UriKind.RelativeOrAbsolute));
        }
        private void PB_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new Uri("View/Pendingbillreport.xaml", UriKind.RelativeOrAbsolute));
        }
        //System.ComponentModel.BackgroundWorker MyWorker = new System.ComponentModel.BackgroundWorker();
        private readonly System.ComponentModel.BackgroundWorker MyWorker = new System.ComponentModel.BackgroundWorker();
        public DispatcherTimer timer = null;
        public string Selected_Path,File_Path,Hotel_Name;
        private void btnexprt_Click(object sender, RoutedEventArgs e)
        {
            //Clearing the frame
            this.frame.Content = null;
            //Opening a Dialog for selecting a folder.
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            //if the path is selected and clicking on Ok Button checking this condition.
            if (result.ToString() == "OK")
            {
                Selected_Path = dialog.SelectedPath;
                PreLoaderPopup.IsOpen = true;
                DisableButtons();
                MyWorker.DoWork += worker_DoWork;
                MyWorker.RunWorkerCompleted += worker_RunWorkerCompleted;
                MyWorker.RunWorkerAsync();
            }
            //By Using Multithreading running 2 methods at a time
            //Task task1 = Task.Factory.StartNew(() => GetData());
            //Task task2 = Task.Factory.StartNew(() => openPopup());
            //Task.WaitAll(task1, task2);

            //setting timer for 2 seconds after that calling a method named timer_Tick
            //timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromMilliseconds(2000);
            //timer.Tick += new EventHandler(timer_Tick);
            //timer.Start();
        }
        private void DisableButtons()
        {
            Btnclsmenu.IsEnabled = false;
            btnopenmenu.IsEnabled = false;
            btndashboard.IsEnabled = false;
            btnhome.IsEnabled = false;
            btnopr.IsEnabled = false;
            //btnrpt.IsEnabled = false;
            //btnrpt1.IsEnabled = false;
            CTXReport.IsEnabled = false;
            popupMasteropen.IsEnabled = false;
            btnpermissions.IsEnabled = false;
            logout.IsEnabled = false;
        }
        private void EnableButtons()
        {
            Btnclsmenu.IsEnabled = true;
            btnopenmenu.IsEnabled = true;
            btndashboard.IsEnabled = true;
            btnhome.IsEnabled = true;
            btnopr.IsEnabled = true;
            //btnrpt.IsEnabled = true;
            //btnrpt1.IsEnabled = true;
            CTXReport.IsEnabled = true;
            popupMasteropen.IsEnabled = true;
            btnpermissions.IsEnabled = true;
            logout.IsEnabled = true;
        }
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PreLoaderPopup.IsOpen = false;
            EnableButtons();
            MessageBox.Show("Excel Sheet has been Downloaded \nPath :- " + File_Path);
        }
        private void worker_RunWorkerCompletedHome(object sender, RunWorkerCompletedEventArgs e)
        {
            PreLoaderPopup.IsOpen = false;
            EnableButtons();
        }
        private void mDailyTar_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new Uri("Reports/TarrifFortheDay.xaml", UriKind.RelativeOrAbsolute));
        }
        //private void mMontlyTar_Click(object sender, RoutedEventArgs e)
        //{
        //    this.frame.Navigate(new Uri("Reports/CheckoutDetails.xaml", UriKind.RelativeOrAbsolute));
        //}
        private void mRoomOccu_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new Uri("Reports/RoomOccupancy.xaml", UriKind.RelativeOrAbsolute));
        }
        private void mDailyDis_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new Uri("Reports/DiscountDateWise.xaml", UriKind.RelativeOrAbsolute));
        }
        private void mMontlyDis_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new Uri("Reports/MonthWiseDiscount.xaml", UriKind.RelativeOrAbsolute));
        }
        private void mDep_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new Uri("Reports/Departuretoday.xaml", UriKind.RelativeOrAbsolute));
        }
        private void mCanlRes_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new Uri("Reports/CancelledReservations.xaml", UriKind.RelativeOrAbsolute));
        }
        private void mDailyCheckouts_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new Uri("Reports/CheckoutDay.xaml", UriKind.RelativeOrAbsolute));
        }
        private void mGuestAdvance_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new Uri("Reports/GuestAdvance.xaml", UriKind.RelativeOrAbsolute));
        }
        private void mGuestInHouse_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new Uri("Reports/GuestInHouse.xaml", UriKind.RelativeOrAbsolute));
        }
        private void mResList_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new Uri("Reports/ReservationList.xaml", UriKind.RelativeOrAbsolute));
        }
        private void mTransList_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new Uri("Reports/TransactionList.xaml", UriKind.RelativeOrAbsolute));
        }
        private void mDailyTax_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new Uri("Reports/Taxdatewise.xaml", UriKind.RelativeOrAbsolute));
        }
        private void mMonthlyTax_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new Uri("Reports/MonthWiseGSTReport.xaml", UriKind.RelativeOrAbsolute));
        }
        //private void mChangeGuestInfo_Click(object sender, RoutedEventArgs e)
        //{
        //    this.frame.Navigate(new Uri("Reports/ChangeGuestInfo.xaml", UriKind.RelativeOrAbsolute));
        //}
        //private void mRoomChange_Click(object sender, RoutedEventArgs e)
        //{
        //    this.frame.Navigate(new Uri("Reports/RoomChangeReport.xaml", UriKind.RelativeOrAbsolute));
        //}
        private void mOutStandBalance_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new Uri("Reports/Oustandingbal.xaml", UriKind.RelativeOrAbsolute));
        }
        //private void mReprint_Click(object sender, RoutedEventArgs e)
        //{
        //    this.frame.Navigate(new Uri("Reports/Reprint.xaml", UriKind.RelativeOrAbsolute));
        //}
        //private void mCheckout_Click(object sender, RoutedEventArgs e)
        //{
        //    this.frame.Navigate(new Uri("Reports/CheckoutDetails.xaml", UriKind.RelativeOrAbsolute));
        //}
        private void mTodayRes_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new Uri("Reports/TodayBookings.xaml", UriKind.RelativeOrAbsolute));
        }
        private void mMWRoomTariff_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new Uri("Reports/MonthWiseRoomTariff.xaml", UriKind.RelativeOrAbsolute));
        }
        private void mPlan_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new Uri("Reports/Plan Wise Room Tarrif.xaml", UriKind.RelativeOrAbsolute));
        }
        private void mRoomRate_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new Uri("Reports/RoomTarrif.xaml", UriKind.RelativeOrAbsolute));
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable t = h.GetGuestData();
            //Create a DataSet with the existing DataTablesMysql
            DataSet ds = new DataSet("Guest Details");
            ds.Tables.Add(t);
            ExportDataSetToExcel(ds, Selected_Path); //Forms.Application.StartupPath
        }
        private void MMonthlyBillGst_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new Uri("Reports/BillWiseGst.xaml", UriKind.RelativeOrAbsolute));
        }
        private void worker_DoWorkHome(object sender, DoWorkEventArgs e)
        {
            //this.frame.Navigate(new Uri("mainwindowpages/home.xaml", UriKind.RelativeOrAbsolute));
        }
        private void ExportDataSetToExcel(DataSet ds, string strPath)
        {
            int inHeaderLength = 0, inColumn = 0, inRow = 0;
            System.Reflection.Missing Default = System.Reflection.Missing.Value;
            //Creating Excel File
            strPath += @"\"+Hotel_Name+" "+DateTime.Now.ToString().Replace(':', '-')+".xls";
            OfficeExcel.Application excelApp = new OfficeExcel.Application();
            OfficeExcel.Workbook excelWorkBook = excelApp.Workbooks.Add(1);
            foreach (DataTable dtbl in ds.Tables)
            {
                //Create Excel WorkSheet
                OfficeExcel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add(Default, excelWorkBook.Sheets[excelWorkBook.Sheets.Count], 1, Default);
                excelWorkSheet.Name = dtbl.TableName;//Name worksheet

                //Write Column Name
                for (int i = 0; i < dtbl.Columns.Count; i++)
                    excelWorkSheet.Cells[inHeaderLength + 1, i + 1] = dtbl.Columns[i].ColumnName.ToUpper();
                //Write Rows
                for (int m = 0; m < dtbl.Rows.Count; m++)
                {
                    for (int n = 0; n < dtbl.Columns.Count; n++)
                    {
                        inColumn = n + 1;
                        inRow = inHeaderLength + 2 + m;
                        excelWorkSheet.Cells[inRow, inColumn] = dtbl.Rows[m].ItemArray[n].ToString();
                        //if (m % 2 == 0)
                        //    excelWorkSheet.get_Range("A" + inRow.ToString(), "G" + inRow.ToString()).Interior.Color = System.Drawing.ColorTranslator.FromHtml("#FCE4D6");
                    }
                }
                //Excel Header
                //OfficeExcel.Range cellRang = excelWorkSheet.get_Range("A1", "G3");
                //cellRang.Merge(false);
                //cellRang.Interior.Color = System.Drawing.Color.White;
                //cellRang.Font.Color = System.Drawing.Color.Gray;
                //cellRang.HorizontalAlignment = OfficeExcel.XlHAlign.xlHAlignCenter;
                //cellRang.VerticalAlignment = OfficeExcel.XlVAlign.xlVAlignCenter;
                //cellRang.Font.Size = 26;
                //excelWorkSheet.Cells[1, 1] = "Greate Novels Of All Time";

                //Style table column names
                OfficeExcel.Range cellRang = excelWorkSheet.get_Range("A1", "C1");
                cellRang.Font.Bold = true;
                cellRang.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                cellRang.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#ED7D31");
                excelWorkSheet.get_Range("F4").EntireColumn.HorizontalAlignment = OfficeExcel.XlHAlign.xlHAlignRight;
                //Formate price column
                excelWorkSheet.get_Range("F5").EntireColumn.NumberFormat = "0.00";
                //Auto fit columns
                excelWorkSheet.Columns.AutoFit();
            }
            //Delete First Page
            excelApp.DisplayAlerts = false;
            Microsoft.Office.Interop.Excel.Worksheet lastWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelWorkBook.Worksheets[1];
            lastWorkSheet.Delete();
            excelApp.DisplayAlerts = true;
            //Set Defualt Page
            (excelWorkBook.Sheets[1] as OfficeExcel._Worksheet).Activate();
            excelWorkBook.SaveAs(strPath, Default, Default, Default, false, Default, OfficeExcel.XlSaveAsAccessMode.xlNoChange, Default, Default, Default, Default, Default);
            excelWorkBook.Close();
            excelApp.Quit();
            File_Path = strPath;
        }
    }
}
