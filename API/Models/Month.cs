using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Month
    {
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string month1;
        public string Month1
        {
            get { return month1; }
            set { month1 = value; }
        }
        private string birthstone;
        public string Birthstone
        {
            get { return birthstone; }
            set { birthstone = value; }
        }
        private string day;
        public string Day
        {
            get { return day; }
            set { day = value; }
        }
        private List<Month> months;
        public List<Month> Months
        {
            get { return months; }
            set { months = value; }
        }
        private string excptnMsg;
        public string ExcptnMsg
        {
            get { return excptnMsg; }
            set { excptnMsg = value; }

        }
        private bool isDbChangeSuccessful;
        public bool IsDbChangeSuccessful
        {
            get { return isDbChangeSuccessful; }
            set { isDbChangeSuccessful = value; }
        }
        private bool status;
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}