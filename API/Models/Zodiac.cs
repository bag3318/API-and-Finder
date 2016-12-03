using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// code to english comments are in green
namespace API.Models // define namespace: model
{
    public class Zodiac // define a public class name: zodiac
    {
        private string id; // define private text named id
        public string Id // define public text property named Id
        {
            get { return id; } // get the id's returned value
            set { id = value; } // set the id = to the value of the id column in the database in the zodiac table
        }
        // same thing for this
        private string zodiacSign;
        public string ZodiacSign
        {
            get { return zodiacSign; }
            set { zodiacSign = value; }
        }
        // for this its a little different
        private List<Zodiac> zodiacSigns; // define a new private list of type zodiac, named zodiacSigns
        public List<Zodiac> ZodiacSigns // do the same thing here except its a property and tis public
        {
            get { return zodiacSigns; } // same thing here as line 13
            set { zodiacSigns = value; } // same thing here as line 14
        }
        // same thing here as the first method
        private string excptnMsg;
        public string ExcptnMsg
        {
            get { return excptnMsg; }
            set { excptnMsg = value; }

        }
        // same thing here except this is a boolean, which can only return true or false
        private bool isDbChangeSuccessful;
        public bool IsDbChangeSuccessful
        {
            get { return isDbChangeSuccessful; }
            set { isDbChangeSuccessful = value; }
        }
        // same thing here as well
        private bool status;
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}