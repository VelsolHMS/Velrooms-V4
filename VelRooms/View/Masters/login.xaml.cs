using HMS.Model.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
using System.Windows.Shapes;
using System.Data.SqlClient;


namespace HMS.View.Masters
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {

        public string dispusername, pwd;
        public string username, password;
        public Boolean U = true;
        public Boolean P = true;
        public static string u;
        public DateTime d = DateTime.Today.Date;
        public DateTime d1 = DateTime.Parse("2019/04/09");
        public DateTime date = DateTime.Parse("2019/03/25");
        public DateTime date1 = DateTime.Parse("2019/04/09");
        public login()
        {
            InitializeComponent();
            DateTime currdate = DateTime.Today.Date;
            //TXTUSERNAME.Focus();
            if (Process.GetProcesses().Count(p => p.ProcessName == "HMS") > 1)
            {
                foreach (var process in
                Process.GetProcessesByName("HMS"))
                {
                    MessageBox.Show("Application is running Please check");
                    process.Kill();
                }
            }
            DataTable dtt = rd.License1();
            if (dtt.Rows.Count == 0)
            {
                ExpPOP.IsOpen = true;
            }
            else
            {
                DateTime insertdate1 = Convert.ToDateTime(dtt.Rows[0]["INSERT_DATE"]);
                string dur1 = dtt.Rows[0]["DURATION"].ToString();
                if (dur1 == "1 Month")
                {
                    DateTime Onee = insertdate1.AddMonths(1);
                    DateTime NDate1 = Onee.AddDays(-10);
                    if (DateTime.Today.Date > Onee)
                    {
                        rd.UPDATELICENSESTATUS();
                        ExpPOP.IsOpen = true;
                    }
                    else if (currdate < NDate1)
                    {
                    }
                    else if (currdate >= NDate1)
                    {
                        if (NDate1 <= Onee)
                        {
                            WarningPOP.IsOpen = true;
                        }
                        else { }
                    }
                }
                else if (dur1 == "3 Months")
                {
                    DateTime Threee = insertdate1.AddMonths(3);
                    DateTime NDate3 = Threee.AddMonths(-1);
                    if (DateTime.Today.Date > Threee)
                    {
                        rd.UPDATELICENSESTATUS();
                        ExpPOP.IsOpen = true;
                    }
                    else if (currdate < NDate3)
                    {
                    }
                    else if (currdate >= NDate3)
                    {
                        if (NDate3 <= Threee)
                        {
                            WarningPOP.IsOpen = true;
                        }
                        else { }
                    }
                }
                else if (dur1 == "6 Months")
                {
                    DateTime Sixx = insertdate1.AddMonths(6);
                    DateTime NDate6 = Sixx.AddMonths(-1);
                    if (DateTime.Today.Date > Sixx)
                    {
                        rd.UPDATELICENSESTATUS();
                        ExpPOP.IsOpen = true;
                    }
                    else if (currdate < NDate6)
                    {
                    }
                    else if (currdate >= NDate6)
                    {
                        if (NDate6 <= Sixx)
                        {
                            WarningPOP.IsOpen = true;
                        }
                        else { }
                    }
                }
                else if (dur1 == "9 Months")
                {
                    DateTime Ninee = insertdate1.AddMonths(9);
                    DateTime NDate9 = Ninee.AddMonths(-1);
                    if (DateTime.Today.Date > Ninee)
                    {
                        rd.UPDATELICENSESTATUS();
                        ExpPOP.IsOpen = true;
                    }
                    else if (currdate < NDate9)
                    {
                    }
                    else if (currdate >= NDate9)
                    {
                        if (NDate9 <= Ninee)
                        {
                            WarningPOP.IsOpen = true;
                        }
                        else { }
                    }
                }
                else if (dur1 == "12 Months")
                {
                    DateTime Twelvee = insertdate1.AddMonths(12);
                    DateTime NDate12 = Twelvee.AddMonths(-1);
                    if (DateTime.Today.Date > Twelvee)
                    {
                        rd.UPDATELICENSESTATUS();
                        ExpPOP.IsOpen = true;
                    }
                    else if (currdate < NDate12)
                    {
                    }
                    else if (currdate >= NDate12)
                    {
                        if (NDate12 <= Twelvee)
                        {
                            WarningPOP.IsOpen = true;
                        }
                        else { }
                    }
                }
                //DataTable DT = rd.License();
                //string dur = DT.Rows[0]["DURATION"].ToString();
                //DateTime insertdate = Convert.ToDateTime(DT.Rows[0]["INSERT_DATE"]);
                //if (dur == "1Month")
                //{
                //    DateTime One = insertdate.AddMonths(1);
                //    DateTime NDate1 = One.AddDays(-10);
                //    if (currdate > One)
                //    {
                //        ExpPOP.IsOpen = true;
                //    }
                //    else if (currdate < NDate1)
                //    {
                //    }
                //    else if (currdate >= NDate1)
                //    {
                //        if (NDate1 <= One)
                //        {
                //            WarningPOP.IsOpen = true;
                //        }
                //        else { }
                //    }
                //}
                //else if (dur == "3Months")
                //{
                //    DateTime Three = insertdate.AddMonths(3);
                //    DateTime NDate3 = Three.AddMonths(-1);
                //    if (currdate > Three)
                //    {
                //        ExpPOP.IsOpen = true;
                //    }
                //    else if (currdate < NDate3)
                //    {
                //    }
                //    else if (currdate >= NDate3)
                //    {
                //        if (NDate3 <= Three)
                //        {
                //            WarningPOP.IsOpen = true;
                //        }
                //        else { }
                //    }
                //}
                //else if (dur == "6Months")
                //{
                //    DateTime Six = insertdate.AddMonths(6);
                //    DateTime NDate6 = Six.AddMonths(-1);
                //    if (currdate > Six)
                //    {
                //        ExpPOP.IsOpen = true;
                //    }
                //    else if (currdate < NDate6)
                //    {
                //    }
                //    else if (currdate >= NDate6)
                //    {
                //        if (NDate6 <= Six)
                //        {
                //            WarningPOP.IsOpen = true;
                //        }
                //        else { }
                //    }
                //}
                //else if (dur == "9Months")
                //{
                //    DateTime Nine = insertdate.AddMonths(9);
                //    DateTime NDate9 = Nine.AddMonths(-1);
                //    if (currdate > Nine)
                //    {
                //        ExpPOP.IsOpen = true;
                //    }
                //    else if (currdate < NDate9)
                //    {
                //    }
                //    else if (currdate >= NDate9)
                //    {
                //        if (NDate9 <= Nine)
                //        {
                //            WarningPOP.IsOpen = true;
                //        }
                //        else { }
                //    }
                //}
                //else if (dur == "12Months")
                //{
                //    DateTime Twelve = insertdate.AddMonths(12);
                //    DateTime NDate12 = Twelve.AddMonths(-1);
                //    if (currdate > Twelve)
                //    {
                //        ExpPOP.IsOpen = true;
                //    }
                //    else if (currdate < NDate12)
                //    {
                //    }
                //    else if (currdate >= NDate12)
                //    {
                //        if (NDate12 <= Twelve)
                //        {
                //            WarningPOP.IsOpen = true;
                //        }
                //        else { }
                //    }
                //}
            }
        }
        registration rd = new registration();
        // public string  signin  ;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                username = TXTUSERNAME.Text;
                password = TXTPASSWORD.Password;
                if (username != "")
                {
                    mf_popup.IsOpen = false;
                    DataTable dt = rd.signin();
                    if (dt.Rows.Count == 0)
                    {
                        TXTPASSWORD.Password = "";
                    }
                    if (password != "" && password == dt.Rows[0]["PASS_WORD"].ToString())
                    {
                        mf_popup.IsOpen = false;
                        try
                        {
                            rd.signin();
                            Main m = new Main();
                            m.Show();
                            this.Close();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Enter correct username And password.");
                        }
                    }
                    else
                    {
                        mf_popup.IsOpen = true;
                    }
                }
                else
                {
                    mf_popup.IsOpen = true;
                }
            }
            catch (Exception)
            {
            }
        }
        public void TXTUSERNAME_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TXTUSERNAME.Text != "")
            {
                mf_popup.IsOpen = false;
                try
                {
                    rd.USERNAME = TXTUSERNAME.Text;
                    rd.PASSWORD = TXTPASSWORD.Password;
                    //rd.user()
                    DataTable DT = rd.user();
                    if (DT.Rows.Count == 0)
                    {
                        MessageBox.Show("User dosenot exist");
                        TXTUSERNAME.Text = "";
                        U = false;
                    }
                    else if (DT.Rows[0]["USER_NAME"].ToString().Equals(TXTUSERNAME.Text.ToUpper()))
                    {
                        //username given small also converting uppercase value in database
                        u = TXTUSERNAME.Text.ToUpper();
                        dispusername = DT.Rows[0]["USER_NAME"].ToString();
                        U = true ;
                    }
                    //U = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("please Check the username");
                }
            }
            else
            {
                mf_popup.IsOpen = true;
            }
        }
        private void TXTPASSWORD_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                rd.USERNAME = TXTUSERNAME.Text.ToUpper();
                DataTable dt = rd.signin();
                if (dt.Rows.Count == 0)
                {
                    TXTPASSWORD.Password = "";
                    P = false;
                }
                else
                {
                    pwd = dt.Rows[0]["PASS_WORD"].ToString();

                    if (pwd.Equals(TXTPASSWORD.Password))
                    {
                        P = true;
                        // MessageBox.Show("Success");
                    }
                    else
                    {
                        MessageBox.Show("INCORRECT PASSWORD");
                        TXTPASSWORD.Password = "";
                        P = false;
                    }
                    //P = true;
                } 
            }
            catch (Exception)
            {
                MessageBox.Show("please Check the password");
            }
        }
        private void tclink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {

        }
        private void tclink_RequestNavigate_1(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {

        }
        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {

        }
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            ExpPOP.IsOpen = false;
            this.Close();
        }
        private void btnexit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_GotFocus(object sender, RoutedEventArgs e)
        {
            if(P == true)
            {
            }
            else
            {
                TXTPASSWORD.Focus();
            }
        }
        private void TXTPASSWORD_GotFocus(object sender, RoutedEventArgs e)
        {
            if (U ==true)
            {
            }
            else
            {
                TXTUSERNAME.Focus();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TXTPASSWORD.Password = "";
            mf_popup.IsOpen = false;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WarningPOP.IsOpen = false;
        }
    }
}
