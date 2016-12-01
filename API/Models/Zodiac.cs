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
            get { return Id; }
            set { Id = value; }
        }
        private string zodiasign;
        public string ZodiacSign
        {
            get { return ZodiacSign; }
            set { ZodiacSign = value; }
        }
        private List<Zodiac> zodiacs;
        public List<Zodiac> Zodiacs
        {
            get { return Zodiacs; }
            set { Zodiacs = value; }
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