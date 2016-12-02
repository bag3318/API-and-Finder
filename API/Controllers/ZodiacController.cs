using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;
using API.Models;
using System.Text;
using System.Collections.Specialized;
using MySql.Data.MySqlClient;

namespace API.Controllers
{
    public class ZodiacController : ApiController
    {
        string connectionString = ConfigurationManager.AppSettings["sql"];
        public List<Zodiac> ZodiacData(string sql)
        {
            MySqlCommand mySqlCommandZodiac; // define mysql command
            MySqlDataReader mySqlDataReaderZodiac; // define sql data reader
            MySqlConnection mySqlConnectionZodiac = new MySqlConnection(connectionString); // define new connection
            List<Zodiac> zodiacSigns = new List<Zodiac>(); // define new message list
            try
            {
                mySqlConnectionZodiac.Open(); // open the connection
                mySqlCommandZodiac = new MySqlCommand(sql, mySqlConnectionZodiac); // define new command passing in string sql and the connection
                mySqlDataReaderZodiac = mySqlCommandZodiac.ExecuteReader(); // execute
                if (mySqlDataReaderZodiac.HasRows) // if the table has rows
                {
                    while (mySqlDataReaderZodiac.Read()) // read the mySql data table
                    {
                        Zodiac zodiac = new Zodiac();
                        zodiac.Id = mySqlDataReaderZodiac["id"].ToString().Trim();
                        zodiac.ZodiacSign = mySqlDataReaderZodiac["zodiac"].ToString().Trim();
                        zodiacSigns.Add(zodiac); // finally, append the message
                    }
                }
                // close all connections and readers
                mySqlDataReaderZodiac.Close(); // first close the datareader
                mySqlConnectionZodiac.Close(); // then close the connection
                return zodiacSigns; // make sure all code paths return something


            }
            catch (MySqlException mySqlException) // we put the general exception first
            {
                string excptn = mySqlException.Message;
                return zodiacSigns;

            }
            catch (Exception err) // then this exception
            {
                string errMsg = err.Message; // output the error in a string
                return zodiacSigns; // return zodiacSigns
            }
            finally // this will execute no matter what
            {
                if (mySqlConnectionZodiac != null) // if not null
                {
                    mySqlConnectionZodiac.Dispose(); // dump the whole thing
                }

            }
        }

        [HttpGet] // HTTP GET request, define that we are doing a get request
        [ActionName("RetrieveZodiacSign")] // define the action name
        public List<Zodiac> RetrieveZodiacSignById(int id) // define new public list for message while passing in the integer id
        {
            StringBuilder mySql = new StringBuilder(); // define a new stringbuilder to pass in sql statements
            mySql.Append("SELECT * FROM "); // select all from
            mySql.Append("zodiac_sign "); // the zodiac table
            mySql.Append("WHERE "); // where the
            mySql.Append("id = "); // id is equal to
            mySql.Append("'" + id + "'"); // the integer id
            List<Zodiac> zodiacSigns = new List<Zodiac>(); // define new list of zodiac signs, of type Zodiac
            return zodiacSigns = ZodiacData(mySql.ToString()); // return zodiac signs with the sql statement

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
   