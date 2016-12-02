using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Zodiac
    {
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string zodiacSign;
        public string ZodiacSign
        {
            get { return zodiacSign; }
            set { zodiacSign = value; }
        }
        private List<Zodiac> zodiacSigns;
        public List<Zodiac> ZodiacSigns
        {
            get { return zodiacSigns; }
            set { zodiacSigns = value; }
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