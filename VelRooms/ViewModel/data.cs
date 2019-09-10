using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using HMS.ViewModel;
using HMS.View.Operations;

namespace HMS.ViewModel
{
    public class data : IDataErrorInfo
    {
        public string Amount { get; set; }
        public string Amount1 { get; set; }
        public string Amount2 { get; set; }
        public string Amount3 { get; set; }
        public string Amount4 { get; set; }
        public string Amount5 { get; set; }
        public string Amount6 { get; set; }
        public string Amount7 { get; set; }
        public string Amount8 { get; set; }
        public string Amount9 { get; set; }
        public string Amount10 { get; set; }
        public string Price { get; set; }
        public string Name { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string Companycode { get; set; }
        public string Companyname { get; set; }
        public string Mobilenumber { get; set; }
        public string Contact { get; set; }
        public string Plotno { get; set; }
        public string Pincode { get; set; }
        public string Emailid { get; set; }
        public string Emailid1 { get; set; }
        public string Mailid { get; set; }
        public string Creditlimit { get; set; }
        public string Creditdays { get; set; }
        public string Blacklisted { get; set; }
        public string Reason { get; set; }
        public string Remarks { get; set; }
        public string Reportname { get; set; }
        public string Landline1 { get; set; }
        public string Landline2 { get; set; }
        public string Gst { get; set; }
        public string Planname { get; set; }
        public string Password { get; set; }
        public string Repassword { get; set; }
        public string Pax { get; set; }
        public string Paxadult { get; set; }
        public string Paxchild { get; set; }
        public string Extra { get; set; }
        public string Extraadult { get; set; }
        public string Extrachild { get; set; }
        public string Rooms { get; set; }
        public string Date { get; set; }
        public string ToDate { get; set; }
        public string Roomname { get; set; }
        public string Number { get; set; }
        public string Number1 { get; set; }
        public string Taxcode { get; set; }
        public string Toamount { get; set; }
        public string Website { get; set; }
        public string Transactionno { get; set; }
        public string Chequeno { get; set; }
        public string Percentage { get; set; }
        public string Tipamount { get; set; }
        public string Authorization { get; set; }
        public string Reservationid { get; set; }
        public string Transferroom { get; set; }
        public string Transferrooms { get; set; }
        public string Special { get; set; }
        public string Addharcard { get; set; }
        public string Pancard { get; set; }
        public string Driving { get; set; }
        public string Voterid { get; set; }
        public string Passport { get; set; }
        public string Time { get; set; }
        public string GST { get; set; }
        public string ExtraHours { get; set; }
        public string Discount { get; set; }
        public string AName { get; set; }
        public string ACode { get; set; }
        public string PCode { get; set; }
        public string CDate { get; set; }
        public string ID { get; set; }
        public string DPercentage { get; set; }
        public string Search { get; set; }
        public string gridSearch { get; set; }
        public string BillNo { get; set; }
        public string View { get; set; }
        public string ResID { get; set; }
        public string AdRooms { get; set; }
        public string Bankcode { get; set; }
        public static int COUNT;
        public string columnName;
        public string result = null;

        //public string drive = @"[A-Z]{2}[0-9]{2}[0-9]{4}[0-9]{7}";
        //public string drive = @"[A-Z]{2}[0-9]{12,14}$";//[0-9]{4}[0-9]{6,8}";
        public string drive = @"[A-Z0-9]{12,20}$";//[0-9]{4}[0-9]{6,8}";
        public string pan = @"[A-Z]{5}[0-9]{4}[A-Z]{1}";
        //public string acode = @"[A-Z]{5}[0-9]{5}";//[0-9]{4}|[0-9]{8}
        //public string name = @"[a-zA-z]\s?[a-zA-z]";
        public string name = @"^[a-zA-Z ]+$";
        public string code = @"^[a - zA - Z0 - 9_.-] *$";
        public string percentage = @"(\D)\s*([\d,]+)";
        // public string reg = @"(\D)\s*([.\d,]+)";
        //public string reg = @"((\d+)+(\.\d+))$";
        public string reg = @"^\s*(?=.*[0-9])\d*(?:\.\d{1,2})?\s*$";
        public string aadhar = @"^\d{4}[-]\d{4}[-]\d{4}$";
        public string voter = @"[A-Z]{3}[0-9]{7}";
        public string passport = @"^[A-PR-WY][1-9]\d\s?\d{4}[1-9]$";
        public string time = @"(([01]?[0-9]):([0-5][0-9]) ([AaPp][Mm]))";
        public string discount = @"^\d{1,3}[.]\d{2}$";
        public string id = @"^[0-9]+$";
      //  public string gst = @"^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$";

        public string Error
        {
            get { throw new NotImplementedException(); }
        }
        public string this[string columnName]
        {
            get
            {

                if (COUNT != 0)
                {
                    if (columnName == "Amount")
                    {
                        if (string.IsNullOrEmpty(Amount))
                        {
                            result = "Please enter valid amount";
                        }
                        else if (Regex.IsMatch(Amount, reg) && IsAlphaNumeric(Amount) == false)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Amount Must be like 1000.00";
                        }
                    }
                    if(columnName == "ID")
                    {
                        if (string.IsNullOrEmpty(ID))
                        {
                            result = "Please enter Id";
                        }
                        else if (Regex.IsMatch(ID, id) == true)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Please enter Valid Id";
                        }
                    }
                    if (columnName == "ResID")
                    {
                        if (string.IsNullOrEmpty(ResID))
                        {
                            result = null;
                        }
                        else if (Regex.IsMatch(ResID, id) == true)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Please enter Valid Id";
                        }
                    }
                    if (columnName == "BillNo")
                    {
                        if (string.IsNullOrEmpty(BillNo))
                        {
                            result = "Please enter Valid BillNo";
                        }
                        else if (Regex.IsMatch(BillNo, id) == true)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Please enter Valid BillNo";
                        }
                    }
                    if (columnName == "Amount1")
                    {

                        if (string.IsNullOrEmpty(Amount1))
                        {
                            result = "Please enter valid amount";
                        }
                        else if (Regex.IsMatch(Amount1, reg) && IsAlphaNumeric(Amount1) == false)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Amount Must be like 1000.00";
                        }
                    }
                    if (columnName == "Amount2")
                    {

                        if (string.IsNullOrEmpty(Amount2))
                        {
                            result = "Please enter valid amount";
                        }
                        else if (Regex.IsMatch(Amount2, reg) && IsAlphaNumeric(Amount2) == false)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Amount Must be like 1000.00";
                        }
                    }
                    if (columnName == "Amount3")
                    {

                        if (string.IsNullOrEmpty(Amount3))
                        {
                            result = "Please enter valid amount";
                        }
                        else if (Regex.IsMatch(Amount3, reg) && IsAlphaNumeric(Amount3) == false)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Amount Must be like 1000.00";
                        }
                    }
                    if (columnName == "Amount4")
                    {

                        if (string.IsNullOrEmpty(Amount4))
                        {
                            result = "Please enter valid amount";
                        }
                        else if (Regex.IsMatch(Amount4, reg) && IsAlphaNumeric(Amount4) == false)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Amount Must be like 1000.00";
                        }
                    }
                    if (columnName == "Amount5")
                    {

                        if (string.IsNullOrEmpty(Amount5))
                        {
                            result = "Please enter valid amount";
                        }
                        else if (Regex.IsMatch(Amount5, reg) && IsAlphaNumeric(Amount5) == false)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Amount Must be like 1000.00";
                        }
                    }
                    if (columnName == "Amount6")
                    {

                        if (string.IsNullOrEmpty(Amount6))
                        {
                            result = "Please enter valid amount";
                        }
                        else if (Regex.IsMatch(Amount6, reg) && IsAlphaNumeric(Amount6) == false)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Amount Must be like 1000.00";
                        }
                    }
                    if (columnName == "Amount7")
                    {

                        if (string.IsNullOrEmpty(Amount7))
                        {
                            result = "Please enter valid amount";
                        }
                        else if (Regex.IsMatch(Amount7, reg) && IsAlphaNumeric(Amount7) == false)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Amount Must be like 1000.00";
                        }
                    }
                    if (columnName == "Amount8")
                    {

                        if (string.IsNullOrEmpty(Amount8))
                        {
                            result = "Please enter valid amount";
                        }
                        else if (Regex.IsMatch(Amount8, reg) && IsAlphaNumeric(Amount8) == false)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Amount Must be like 1000.00";
                        }
                    }
                    if (columnName == "Amount9")
                    {

                        if (string.IsNullOrEmpty(Amount9))
                        {
                            result = "Please enter valid amount";
                        }
                        else if (Regex.IsMatch(Amount9, reg) && IsAlphaNumeric(Amount9) == false)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Amount Must be like 1000.00";
                        }
                    }
                    if (columnName == "Amount10")
                    {

                        if (string.IsNullOrEmpty(Amount10))
                        {
                            result = "Please enter valid amount";
                        }
                        else if (Regex.IsMatch(Amount10, reg) && IsAlphaNumeric(Amount10) == false)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Amount Must be like 1000.00";
                        }
                    }
                    if (columnName == "PCode")
                    {
                        if(string.IsNullOrEmpty(PCode))
                        {
                            result = "Please enter valid Code";
                        }
                        else if(IsAlphaNumeric(PCode)==true)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Please enter valid Code";
                        }
                    }
                    if (columnName == "ACode")
                    {
                        if (string.IsNullOrEmpty(ACode))
                        {
                            result = "Please enter valid Code";
                        }
                        else if (IsAlphaNumeric(ACode) == true && ACode.Length == 5)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Please enter valid Code";
                        }
                    }
                    if (columnName == "Price")
                    {

                        if (string.IsNullOrEmpty(Price))
                        {
                            result = "Please enter valid amount";
                        }
                        else if (Regex.IsMatch(Price,reg)&&IsNumeric(Price)==true)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Amount Must be like 1000.00";
                        }
                    }
                    if (columnName == "Toamount")
                    {
                        if(string.IsNullOrEmpty(Toamount))
                        {
                            result = "please enter valid amount";
                        }
                        else if(Regex.IsMatch(Toamount,reg)&&IsAlphaNumeric(Toamount)==false)
                        {
                            result = null;
                        }
                        else /*if(IsAlphabets(Toamount))*/
                        {
                            result = "Amount Must be like 1000.00";
                        }
                        //else
                        //{
                        //    result = "Please enter the amount greater than FromAMount";
                        //}
                    }
                    if(columnName =="Discount")
                    {
                        if(Regex.IsMatch(Discount,discount)&&IsAlphaNumeric(Discount)==false)
                        {
                            result = null;
                        }
                       
                        else
                        {
                            result = "Discount must be like 0.00";
                        }
                    }
                    if(columnName == "Time")
                    {
                        if(string.IsNullOrEmpty(time))
                        {
                            result = "please enter valid time";
                        }
                        else if(Regex.IsMatch(Time,time)&& IsAlphaNumeric(Time)==false)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Time must be like 00:00 AM/PM";
                        }
                    }
                    if(columnName == "ExtraHours")
                    {
                        if(IsNumeric(ExtraHours)==true)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Please enter valid Hours";
                        }
                    }
                    if (columnName == "Percentage")
                    {

                        if (string.IsNullOrEmpty(Percentage))
                        {
                            result = "Please enter valid percentage";
                        }
                        else if (Regex.IsMatch(Percentage, percentage) && IsAlphaNumeric(Percentage) == false)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Percentage must be like 10.0%";
                        }
                    }
                    if (columnName == "Name")
                    {

                        if (string.IsNullOrEmpty(Name))
                        {
                            result = "Please enter a Name";
                        }
                        else if (Regex.IsMatch(Name, name))
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Enter only Characters";
                        }
                    }
                    if (columnName == "View")
                    {

                        if (string.IsNullOrEmpty(View))
                        {
                            result = "Please enter RoomView";
                        }
                        else if (Regex.IsMatch(View, View))
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Enter only Characters";
                        }
                    }
                    if (columnName == "AName")
                    {

                        if (string.IsNullOrEmpty(AName))
                        {
                            result = "Please enter a Name";
                        }
                        else if (Regex.IsMatch(AName, name))
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Enter only Characters";
                        }
                    }

                    if (columnName == "Name1")
                    {

                        if (string.IsNullOrEmpty(Name1))
                        {
                            result = "Please enter a Name";
                        }
                        else if (Regex.IsMatch(Name1, name))
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Enter only Characters";
                        }
                    }
                    if (columnName == "Name2")
                    {

                        if (string.IsNullOrEmpty(Name2))
                        {
                            result = "Please enter a Name";
                        }
                        else if (Regex.IsMatch(Name2, name))
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Enter only Characters";
                        }
                    }
                    if (columnName == "City")
                    {

                        if (string.IsNullOrEmpty(City))
                        {
                            result = "Please enter a City";
                        }
                        else if (Regex.IsMatch(City, name))
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Enter only Characters";
                        }
                    }
                    if (columnName == "Description")
                    {
                        if(string.IsNullOrEmpty(Description))
                        {
                            result = null;
                        }
                        else if (Regex.IsMatch(Description, name))
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Enter only Characters";
                        }

                    }
                    if (columnName == "Companycode")
                    {
                        if (string.IsNullOrEmpty(Companycode))
                        {
                            result = "Please enter Company Code";
                        }
                        else if (IsAlphaNumeric(Companycode) == true)
                        {
                            result = null;
                        }
                    }
                    if (columnName == "Companyname")
                    {
                        if (string.IsNullOrEmpty(Companyname))
                        {
                            result = "Please enter Company name";
                        }
                        else if (Regex.IsMatch(Companyname, name))
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Please enter only Characters";
                        }
                    }
                    if (columnName == "Mobilenumber")
                    {
                        if (string.IsNullOrEmpty(Mobilenumber))
                        {
                            result = "Mobile number cannot be empty";
                        }
                        else if (IsNumeric(Mobilenumber) == true && Mobilenumber.Length == 10)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Please enter valid mobile number";
                        }
                    }
                    if (columnName == "Search")
                    {
                        if (string.IsNullOrEmpty(Search))
                        {
                            result = null;
                        }
                        else if (IsNumeric(Search) == true && Search.Length == 10)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Please enter valid mobile number";
                        }
                    }
                    if (columnName == "gridSearch")
                    {
                        if (string.IsNullOrEmpty(gridSearch))
                        {
                            result = null;
                        }
                        else if (IsNumeric(gridSearch) == true && gridSearch.Length == 10)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Please enter valid mobile number";
                        }
                    }
                    if (columnName == "Plotno")
                    {
                        if (string.IsNullOrEmpty(Plotno))
                        {
                            result = "Door/Plot no cannot be empty";
                        }
                        else
                        {
                            result = null;
                        }
                    }
                    if (columnName == "Pincode")
                    {
                        if (string.IsNullOrEmpty(Pincode))
                        {
                            result = "Please enter a pincode";
                        }
                        else if (IsNumeric(Pincode) == true && Pincode.Length == 6)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Please enter valid pincode";
                        }
                    }
                    if (columnName == "Contact")
                    {
                        if (string.IsNullOrEmpty(Contact))
                        {
                            result = "Please enter Mobile Number";
                        }
                        else if (IsNumeric(Contact) == true && Contact.Length == 10)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Please enter valid mobile number";
                        }
                    }
                    if (columnName == "Emailid")
                    {
                        string mail = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
                        if (string.IsNullOrEmpty(Emailid))
                        {
                            result = "Please provide  email id";
                        }
                        else if (Regex.IsMatch(Emailid, mail))
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Please enter valid email id ";
                        }
                    }
                    
                    if (columnName == "Mailid")
                    {
                        string mail = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
                        if (Mailid == "")
                        {
                            result = null;
                        }
                        else if (Regex.IsMatch(Mailid, mail))
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Please provide a email address ";
                        }
                    }
                    if (columnName == "Creditlimit")
                    {
                        if (string.IsNullOrEmpty(Creditlimit))
                        {
                            result = "Please enter a credit limit";
                        }
                        else if (IsNumeric(Creditlimit) == true)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Please enter only numbers";
                        }
                    }
                    if (columnName == "Creditdays")
                    {
                        if (string.IsNullOrEmpty(Creditdays))
                        {
                            result = "Please enter no of credit days";
                        }
                        else if (IsNumeric(Creditdays) == true)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Please enter numbers only";
                        }
                    }
                    if (columnName == "Blacklisted")
                    {
                        if (string.IsNullOrEmpty(Blacklisted))
                        {
                            result = "please enter valid name";
                        }
                        else if (Regex.IsMatch(Blacklisted, name))
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Please enter only Characters";
                        }
                    }
                    if (columnName == "Reason")
                    {
                        if (string.IsNullOrEmpty(Reason))
                        {
                            result = "Reason cannot be empty";
                        }
                        else if (Regex.IsMatch(Reason, name))
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Enter only Characters";
                        }
                    }
                    if (columnName == "Remarks")
                    {
                        if (string.IsNullOrEmpty(Remarks))
                        {
                            result = "Please enter a remarks";
                        }
                        else if (Regex.IsMatch(Remarks, name))
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Enter only Characters";
                        }
                    }
                    if (columnName == "Reportname")
                    {
                        if (string.IsNullOrEmpty(Reportname))
                        {
                            result = "Please enter a name";
                        }
                        else if (Regex.IsMatch(Reportname, name))
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Enter a valid name";
                        }
                    }
                    if (columnName == "Landline1")
                    {
                        if (string.IsNullOrEmpty(Landline1))
                        {
                            result = "Please enter Landline number ";
                        }
                        else
                        {
                            string a = "[0-9 -]{4}[0-9]{6,8}";
                        //    string b = @"/^[0-9]\d{2,4}-\d{6,8}$/";
                            if (Regex.IsMatch(Landline1, a) && IsAlphaNumeric(Landline1)==false)
                            {
                                result = null;
                            }
                            else { result = "please enter valid number (example 040-00000000) "; }
                        }
                    }
                    if (columnName == "Landline2")
                    {
                        string a = "[0-9 -]{4}[0-9]{6,8}";
                        if (Regex.IsMatch(Landline2, a)&& IsAlphaNumeric(Landline2)==false)
                        {
                            result = null;
                        }
                        else result = "please enter valid  number (example 040-00000000) ";

                    }
                    if (columnName == "Gst")
                    {
                        string a = "^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$";
                        if (Regex.IsMatch(Gst, a))
                        {
                            result = null;
                        }
                        else
                        {
                            result = "please enter valid GST number (example 12ABCDE1234B1ZA)";
                        }
                    }
                    
                    if (columnName == "Planname")
                    {
                        if (string.IsNullOrEmpty(Planname))
                        {
                            result = "Please Enter Valid PlanName";
                        }
                        else if (Regex.IsMatch(Planname, name))
                        {
                            result = null;
                        }
                       //  else result = "Please Select a Plan";
                    }
                    if (columnName == "Password")
                    {
                        if (string.IsNullOrEmpty(Password))
                        {
                            result = "Password cannot be empty";
                        }
                        else if (IsAlphaNumeric(Password) == true)
                        {
                            result = null;
                        }
                    }
                    if (columnName == "Repassword")
                    {
                        if (String.IsNullOrEmpty(Repassword))
                        {
                            result = "Please re-type the passwords";
                        }
                        else if (Repassword.Equals(Password))
                        {
                            result = null;
                        }
                        else result = "Please check the passwords";
                    }
                    if (columnName == "Pax")
                    {
                        if (String.IsNullOrEmpty(Pax))
                        {
                            result = "Please enter Pax";
                        }
                        else if (IsNumeric(Pax) == true)
                        {
                            result = null;
                        }
                        else result = "Enter Only Numbers";
                    }
                    if (columnName == "Date")
                    {
                        if (String.IsNullOrEmpty(Date))
                        {
                              result = "Please select date";
                        }
                        else if (!(Date == ""))
                        {
                            result = null;
                        }
                    }
                    if (columnName == "CDate")
                        {
                        if (String.IsNullOrEmpty(CDate))
                        {
                            result = "Please select date";
                        }
                        else if (!(CDate == ""))
                        {
                            result = null;
                        }
                    }
                    if (columnName == "ToDate")
                    {
                        if (String.IsNullOrEmpty(ToDate))
                        {
                            result = "Please select date";
                        }
                        else if (!(ToDate == ""))
                        {
                            result = null;
                        }
                    }
                    if (columnName == "Rooms")
                    {
                        if (String.IsNullOrEmpty(Rooms))
                        {
                            result = "Please enter Room Number";
                        }
                        else if (IsNumeric(Rooms) && Rooms.Length <= 5)
                        {
                            result = null;
                        }
                        else if(IsAlphabets(Rooms)||(IsAlphaNumeric(Rooms))==true)
                        {
                            result = "Please Enter Numbers Only";
                        }
                        else result = "Please enter valid Room Number";
                    }
                    if (columnName == "AdRooms")
                    {
                        if (String.IsNullOrEmpty(AdRooms))
                        {
                            result = null;
                        }
                        else if (IsNumeric(AdRooms) && AdRooms.Length <= 5)
                        {
                            result = null;
                        }
                        else if (IsAlphabets(AdRooms) || (IsAlphaNumeric(AdRooms)) == true)
                        {
                            result = "Please Enter Numbers Only";
                        }
                        else result = "Please enter valid Room Number";
                    }
                    if (columnName == "Transferrooms")
                    {
                        if (String.IsNullOrEmpty(Transferrooms))
                        {
                            result = "Please enter Room Number";
                        }
                        else if (IsNumeric(Transferrooms) && Transferrooms.Length == 3)
                        {
                            result = null;
                        }
                        else result = "Room number must contain only 3 digits";
                    }
                    if (columnName == "Transferroom")
                    {
                        if (String.IsNullOrEmpty(Transferroom))
                        {
                            result = "Please enter Room Number";
                        }
                        else if (IsNumeric(Transferroom) && Transferroom.Length == 3)
                        {
                            result = null;
                        }
                        else result = "Room number must contain only 3 digits";
                    }
                    if (columnName == "Roomname")
                    {
                        //  string reg = @"^[A-Za-z0-9- ]+$";
                        if (string.IsNullOrEmpty(Roomname))
                        {
                            result = "Please Enter Valid Room";
                        }
                        //else if (IsAlphaNumeric(Roomname) == true)
                        //{
                        //    result = null;
                        //}
                        else result = null;
                        // result = "Please enter valid name";
                    }
                    if (columnName == "Number")
                    {
                        if (string.IsNullOrEmpty(Number))
                        {
                            result = "Please enter a number";
                        }
                        else if (IsNumeric(Number) == true)
                        {
                            result = null;
                        }
                        else result = "Enter only numbers";
                    }
                    if (columnName == "Number1")
                    {
                        if (string.IsNullOrEmpty(Number1))
                        {
                            result = "Please enter a number";
                        }
                        else if (IsNumeric(Number1) == true)
                        {
                            result = null;
                        }
                        else result = "Enter only numbers";
                    }
                    if (columnName == "Paxadult")
                    {
                        if (string.IsNullOrEmpty(Paxadult))
                        {
                            result = "Please enter Adult";
                        }
                        else if (IsNumeric(Paxadult) == true && Paxadult.Length <= 2)
                        {
                            result = null;
                        }
                        else result = "Enter only numbers";
                    }
                    if (columnName == "Paxchild")
                    {
                        if (IsNumeric(Paxchild) == true && Paxchild.Length <= 2)
                        {
                            result = null;
                        }
                        else result = "Enter only numbers";
                    }
                    if (columnName == "Taxcode")
                    {
                        if (IsAlphaNumeric(Taxcode) == true)
                        {
                            result = null;
                        }
                        else result = "Please enter a valid code";
                    }
                    if (columnName == "Website")
                    {
                        string web = @"^([\w\-]+)(\.[\w\-]+)((\.(\w){2,3})+)$";
                        //if (string.IsNullOrEmpty(Website))
                        //{
                        //    result = "Please enter a Website Name";
                        //}

                        //else 
                        if (Regex.IsMatch(Website, web))
                        {
                            result = null;
                        }
                        else if (IsNumeric(Website))
                        {
                            result = null;
                        }
                        else
                        { result = "please enter valid website (example www.xyz.com) "; }
                      
                    }
                    if (columnName == "Transactionno")
                    {
                        if (string.IsNullOrEmpty(Transactionno))
                        {
                            result = "Transaction Number cannot be empty";
                        }
                        else if (IsAlphaNumeric(Transactionno) == true && Transactionno.Length == 12)
                        {
                            result = null;
                        }
                        else result = "Please check the transaction no";
                    }
                    if (columnName == "Chequeno")
                    {
                        if (string.IsNullOrEmpty(Chequeno))
                        {
                            result = "Cheque number cannot be empty";
                        }
                        else if (IsNumeric(Chequeno) == true && Chequeno.Length == 6)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Please provide a valid cheque no";
                        }
                    }
                    if (columnName == "Extra")
                    {
                        if (IsNumeric(Extra) == true && Extra.Length <= 2)
                        {
                            result = null;
                        }
                        else result = "Enter only numbers";
                    }
                    if (columnName == "Extraadult")
                    {
                        if (IsNumeric(Extraadult) == true && Extraadult.Length <= 2)
                        {
                            result = null;
                        }
                        else result = "Enter only numbers";
                    }
                    if (columnName == "Extrachild")
                    {
                        if (IsNumeric(Extrachild) == true && Extrachild.Length <= 2)
                        {
                            result = null;
                        }
                        else result = "Enter only numbers";
                    }
                    if (columnName == "Tipamount")
                    {
                        if (Regex.IsMatch(Tipamount, reg) && IsAlphaNumeric(Tipamount) == false)
                        {
                            result = null;
                        }
                        else result = "Amount must be 1000.00";
                    }
                    if (columnName == "Authorization")
                    {
                        if (string.IsNullOrEmpty(Authorization))
                        {
                            result = "Authorization cannot be empty";
                        }
                        else if (Regex.IsMatch(Authorization, name))
                        {
                            result = null;
                        }
                        else result = "Please enter only alphabets";
                    }
                    if (columnName == "Reservationid")
                    {
                        if (string.IsNullOrEmpty(Reservationid))
                        {
                            result = "Reservation ID cannot be null";
                        }
                        else if (IsNumeric(Reservationid) == true)
                        {
                            result = null;
                        }
                        else result = "Please enter only numbers";
                    }
                    if (columnName == "Special")
                    {
                        if (IsAlphaNumeric(Special) == true)
                        {
                            result = null;
                        }
                        else result = "Please enter a valid Instruction";
                    }
                    if (columnName == "Addharcard")
                    {
                        if (string.IsNullOrEmpty(Addharcard))
                        {
                            result = "Aadhar number cannot be empty";
                        }
                        else if (Regex.IsMatch(Addharcard, aadhar) && Addharcard.Length == 14)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Invalid aadhar number";
                        }
                    }
                    if (columnName == "Pancard")
                    {
                        if (string.IsNullOrEmpty(Pancard))
                        {
                            result = "Pan number cannot be empty";
                        }
                        else if (Regex.IsMatch(Pancard, pan))
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Invalid pan number";
                        }
                    }
                    if (columnName == "Driving")
                    {
                        if (string.IsNullOrEmpty(Driving))
                        {
                            result = "Driving license cannot be empty";
                        }
                        else if (Regex.IsMatch(Driving, drive))
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Invalid Driving license number";
                        }
                    }
                    if (columnName == "Passport")
                    {
                        if (string.IsNullOrEmpty(Passport))
                        {
                            result = "Passport number cannot be empty";
                        }
                        else if (Regex.IsMatch(Passport, passport))
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Invalid passport number";
                        }
                    }
                    if (columnName == "Voterid")
                    {
                        if (string.IsNullOrEmpty(Voterid))
                        {
                            result = "Voterid number cannot be empty";
                        }
                        else if (Regex.IsMatch(Voterid, voter))
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Invalid voterid number";
                        }
                    }

                    if (columnName == "Bankcode")
                    {
                        if (string.IsNullOrEmpty(Bankcode))
                        {
                            result = "Please enter a code";
                        }
                        else if (Regex.IsMatch(Bankcode, code))
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Enter a valid code";
                        }
                    }

                    if (columnName == "DPercentage")
                    {
                        if (string.IsNullOrEmpty(DPercentage))
                        {
                            result = null;
                        }
                        else if (Regex.IsMatch(DPercentage, id) == true)
                        {
                            result = null;
                        }
                        else
                        {
                            result = "Please enter Valid Percentage";
                        }
                    }
                }
                return result;
            }
        }
        public bool IsNumeric(string value)
        {
           
            return value.All(char.IsNumber);
        }
        public bool IsAlphaNumeric(string result)
        {
            return result.All(char.IsLetterOrDigit);
        }
        public bool IsAlphabets(string alpa)
        {
            return alpa.All(char.IsLetter);
        }
    }
}
