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
            get { return Id; }
            set { Id = value; }
        }
        private string month1;
        public string Month1
        {
            get { return Month1; }
            set { Month1 = value; }
        }
        private string birthstone;
        public string Birthstone
        {
            get { return Birthstone; }
            set { Birthstone = value; }
        }
        private string day;
        public string Day
        {
            get { return Day; }
            set { Day = value; }
        }
        private List<Month> months;
        public List<Month> Months
        {
            get { return Months; }
            set { Months = value; }
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