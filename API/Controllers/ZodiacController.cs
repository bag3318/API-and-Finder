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
        string connectionString = ConfigurationManager.AppSettings["sql"]; // define app settings
        public List<Zodiac> ZodiacSignData(string sql) // define new list of type zodiac named Zodiac Sign Data while passing in the string sql
        {
            MySqlCommand mySqlCommandZodiac; // define mysql command
            MySqlDataReader mySqlDataReaderZodiac; // define mysql datareader
            MySqlConnection mySqlConnectionZodiac = new MySqlConnection(connectionString); // define new connection
            List<Zodiac> zodiacSigns = new List<Zodiac>(); // define new list
            try
            {
                mySqlConnectionZodiac.Open(); // open the connection
                mySqlCommandZodiac = new MySqlCommand(sql, mySqlConnectionZodiac); // define new mysql command with the string sql and mysql connection zodiac
                mySqlDataReaderZodiac = mySqlCommandZodiac.ExecuteReader(); // execute reader
                if (mySqlDataReaderZodiac.HasRows) // if the data table has rows
                {
                    while (mySqlDataReaderZodiac.Read()) // read the table
                    {
                        Zodiac zodiac = new Zodiac();  // define new variable zodiac of type zodiac
                        zodiac.Id = mySqlDataReaderZodiac["id"].ToString().Trim(); // read the id column in the data table
                        zodiac.ZodiacSign = mySqlDataReaderZodiac["zodiac"].ToString().Trim(); // read the zodiac column on the data table
                        zodiacSigns.Add(zodiac); // finally, append the zodiac sign
                    }
                }
                mySqlDataReaderZodiac.Close(); // close the data reader
                mySqlConnectionZodiac.Close(); // close the connection
                return zodiacSigns; // rmake sure all code paths return a value
            }
            catch (MySqlException mySqlException) // put the general exception first
            {
                string excptn = mySqlException.Message; // output the error in a string
                return zodiacSigns; // return zodiac signs
            }
            catch (Exception err) // then catch this exception
            {
                string errMsg = err.Message; // output the error to a string
                return zodiacSigns; // return zodiac signs
            }
            finally // this statement will execute no matter what
            {
                if (mySqlConnectionZodiac != null) // if the connection is not null
                {
                    mySqlConnectionZodiac.Dispose(); // dump everything
                }
            }
        }
        [HttpGet] // define the http method
        [ActionName("RetrieveZodiacSign")] // define action name
        public List<Zodiac> RetrieveZodiacSignById(int id) // make new list of type zodiac while passing in the integer id
        {
            StringBuilder mySql = new StringBuilder(); // define new stringbuilder
            mySql.Append("SELECT * FROM "); // select all from
            mySql.Append("zodiac_sign "); // the zodiac sign table 
            mySql.Append("WHERE "); // where
            mySql.Append("id = "); // the id column equals
            mySql.Append("'" + id + "'"); // the integer id that we passed into the public list method
            List<Zodiac> zodiacSigns = new List<Zodiac>(); // deifne new list named zodiacSigns of type list
            return zodiacSigns = ZodiacSignData(mySql.ToString()); // return zodiac sign data method with the sql string builder, then convert it to a string
        }
        /*
         * WARNING: DO NOT DELETE THE XML CODE BELOW!
         */
         // we use 3 foward slashes for programmign xml in visual c# (asp.net)
        /// <!-- define our summary -->
        /// <summary>
        ///     Executes given Stored Procedure and returns integer
        /// </summary>
        /// <param name="spName">Stored procedure</param> <!-- define our stored procedure parameter -->
        /// <param name="paramsList">Parameter List</param> <!-- define our parameter list parameter tag -->
        /// <returns>Integer</returns> <!-- this is what we will return -->
        private int ExecSPWithParams(string spName, ListDictionary paramsList) // define new private integer passing in the stored procedure name string and a list dictionary named paramsList
        {
            MySqlConnection con = new MySqlConnection(connectionString); // define mysql connection
            con.Open(); // open the mysql connection
            int status = ServerCommon.ExecuteNonQuery(con, spName, paramsList); // define the integer status
            con.Close(); // close the mysql connection
            return status; // return the integer status
        }
    }
}
   