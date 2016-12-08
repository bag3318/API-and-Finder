using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;

namespace API.Models
{
    public class Message
    {
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string message1;
        public string Message1
        {
            get { return message1; }
            set { message1 = value; }
        }
        private string rating;
        public string Rating
        {
            get { return rating; }
            set { rating = value; }
        }
        //  [JsonIgnore]
     //   [JsonIgnore]
        private string excptnMsg;
      //  [JsonIgnore]
        public string ExcptnMsg
        {
            get { return excptnMsg; }
            set { excptnMsg = value; }

        }
      //  [JsonIgnore]
        private bool isDbChangeSuccessful;
       // [JsonIgnore]
        public bool IsDbChangeSuccessful
        {
            get { return isDbChangeSuccessful; }
            set { isDbChangeSuccessful = value; }
        }
       // [JsonIgnore]
        private bool status;
       // [JsonIgnore]
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
