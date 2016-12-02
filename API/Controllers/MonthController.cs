using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;
using API.Models;
using System.Text;
using System.Collections.Specialized;
using MySql.Data.MySqlClient;// define mysql statement

namespace API.Controllers
{
    public class MonthController : ApiController
    {
        string connectionString = ConfigurationManager.AppSettings["sql"];
        public List<Month> MonthData(string sql)
        {
            MySqlCommand mySqlCommandMonth; // define mysql command
            MySqlDataReader mySqlDataReaderMonth; // define sql data reader
            MySqlConnection mySqlConnectionMonth = new MySqlConnection(connectionString); // define new connection
            List<Month> months = new List<Month>(); // define new message list
            try
            {
                mySqlConnectionMonth.Open(); // open the connection
                mySqlCommandMonth = new MySqlCommand(sql, mySqlConnectionMonth); // define new command passing in string sql and the connection
                mySqlDataReaderMonth = mySqlCommandMonth.ExecuteReader(); // execute
                if (mySqlDataReaderMonth.HasRows) // if the table has rows
                {
                    while (mySqlDataReaderMonth.Read()) // read the mySql data table
                    {
                        Month month = new Month();
                        month.Id = mySqlDataReaderMonth["id"].ToString().Trim(); // read the id column
                        month.Birthstone = mySqlDataReaderMonth["birthstone"].ToString().Trim(); // the birthstone column
                        month.Day = mySqlDataReaderMonth["days"].ToString().Trim(); // the days column
                        month.Month1 = mySqlDataReaderMonth["month"].ToString().Trim(); // and the month column
                        months.Add(month); // finally, append the message
                    }
                }
                // close all connections and readers
                mySqlDataReaderMonth.Close(); // first close the datareader
                mySqlConnectionMonth.Close(); // then close the connection
                return months; // make sure all code paths return something


            }
            catch (MySqlException mySqlException) // we put the general exception first
            {
                string excptn = mySqlException.Message;
                return months;

            }
            catch (Exception err) // then this exception
            {
                string errMsg = err.Message; // output the error in a string
                return months; // return months
            }
            finally // this will execute no matter what
            {
                if (mySqlConnectionMonth != null) // if not null
                {
                    mySqlConnectionMonth.Dispose(); // dump the whole thing
                }

            }
        }

        [HttpGet] // HTTP GET request, define that we are doing a get request
        [ActionName("RetrieveAllMonthData")] // define the action name
        public List<Month> RetrieveAllMonthDataById(int id) // define new public list for message while passing in the integer id
        {
            StringBuilder mySql = new StringBuilder(); // define a new stringbuilder to pass in sql statements
            mySql.Append("SELECT * FROM "); // select all from
            mySql.Append("months "); // the months table
            mySql.Append("WHERE "); // where the
            mySql.Append("id = "); // id is equal to
            mySql.Append("'" + id + "'"); // the integer id
            List<Month> months = new List<Month>(); // define new list of months of type Month
            return months = MonthData(mySql.ToString()); // return month with the sql statement

        }
        /*
         * WARNING: DO NOT DELETE XML CODE BELOW!
         */

        /// <summary>
        /// 	Executes given Stored Procedue and returns integer 
        /// </summary>
        /// <param name="spName">Stored procedure</param>
        /// <param name="paramsList">Parameter List</param>
        /// <returns>Integer</returns>

        private int ExecSPWithParams(string spName, ListDictionary paramsList)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            int status = ServerCommon.ExecuteNonQuery(con, spName, paramsList);
            con.Close();
            return status;
        }
    }
}
