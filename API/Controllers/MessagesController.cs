using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;
using API.Models;
using System.Text;
using System.Collections.Specialized;
using MySql.Data.MySqlClient;
namespace API.Controllers // define namespace
{
    public class MessageController : ApiController
    {
        string connectionString = ConfigurationManager.AppSettings["sql"]; // define app settings
        public List<Message> MessageData(string sql)
        {
            MySqlCommand mySqlCommandMessage;
            MySqlDataReader mySqlDataReaderMessage;
            MySqlConnection mySqlConnectionMessage = new MySqlConnection(connectionString);
            List<Message> messages = new List<Message>(); // define new message list
            try
            {
                mySqlConnectionMessage.Open();
                mySqlCommandMessage = new MySqlCommand(sql, mySqlConnectionMessage);
                mySqlDataReaderMessage = mySqlCommandMessage.ExecuteReader();
                if (mySqlDataReaderMessage.HasRows) // if the table has rows
                {
                    while (mySqlDataReaderMessage.Read()) // read the mySql data table
                    {
                        Message message = new Message();
                        message.Message1 = mySqlDataReaderMessage["message"].ToString().Trim();
                        message.Id = mySqlDataReaderMessage["id"].ToString().Trim();
                        message.Rating = mySqlDataReaderMessage["rating"].ToString().Trim();
                        messages.Add(message);
                    }
                }
                // close all connections and readers
                mySqlDataReaderMessage.Close();
                mySqlConnectionMessage.Close();
                return messages; // make sure all code paths return something


            }
            catch (MySqlException mySqlException) // here is our catch statement
            {
                string excptn = mySqlException.Message;
                return messages;

            }
            catch (Exception err)
            {
                string errMsg = err.Message;
                return messages;
            }
            finally
            {
                if (mySqlConnectionMessage != null) // if not null
                {
                    mySqlConnectionMessage.Dispose(); // dump the whole thing
                }

            }
        }

        [HttpGet] // HTTP GET request
        [ActionName("RetrieveMessage")]

        public List<Message> RetrieveMessagesById(int id)
        {
            StringBuilder mySql = new StringBuilder();
            mySql.Append("SELECT * FROM ");
            mySql.Append("message ");
            mySql.Append("WHERE ");
            mySql.Append("id = ");
            mySql.Append("'" + id + "'");
            List<Message> messages = new List<Message>();
            return messages = MessageData(mySql.ToString());

        }
        [HttpPost] // specify the http protocal method
        [ActionName("AddMessage")] // add our action name
        public Message AddMessage(Message message)
        {

            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
            ListDictionary paramsList = new ListDictionary();

            try
            {
                mySqlConnection.Open(); // open mySql connection
                foreach (Message message1 in message.Messages) // for each of the messages in the messages column in the db table
                {
                    paramsList.Add("@id", message.Id); // add the id parameter from the database table
                    paramsList.Add("@message", message.Messages); // do the same thing for message
                    paramsList.Add("@rating", message.Rating);
                    int status = ExecSPWithParams("dbo.insert_message", paramsList); // call Message.cs model to get the status of executeSPwithparams 
                    if (status > 0) // if the status is greater than zero
                    {
                        message.Id = paramsList["@id"].ToString();
                    }
                    else
                    {
                        message.Id = "1";
                    }
                }
                mySqlConnection.Close();

                return message;

            }
            catch (MySqlException mySqlException)
            {
                message.ExcptnMsg = mySqlException.Message;
                message.Id = "0";
                return message;
            }
            catch (Exception err)
            {
                message.ExcptnMsg = err.Message;
                message.Id = "0";
                return message;
            }
            finally
            {
                if (mySqlConnection != null)
                {
                    mySqlConnection.Dispose();
                }

            }
        } // end method
        [HttpDelete] // delete request
        [ActionName("RemoveMessage")]
        public Message RemoveMessage(Message message)
        {
            MySqlConnection MySqlConnection = new MySqlConnection(connectionString);

            ListDictionary paramsList = new ListDictionary();
            try
            {
                MySqlConnection.Open();
                paramsList.Add("@id", message.Id);
                paramsList.Add("@message", message.Message1);
                paramsList.Add("@rating", message.Rating);
                int status = ExecSPWithParams("dbo.delete_message", paramsList);

                if (status > 0)
                {
                    message.IsDbChangeSuccessful = true;
                }
                else
                {
                    message.IsDbChangeSuccessful = false;
                }
                MySqlConnection.Close();
                return message;
            }
            catch (MySqlException MySqlException) // put first becuase of general exception
            {
                message.ExcptnMsg = MySqlException.Message;
                message.Id = "0";
                return message;
            }
            catch (Exception err)
            {
                message.ExcptnMsg = err.Message;
                message.Id = "0";
                return message;
            }
            finally // and this finally statement executes regardless
            {
                if (MySqlConnection != null) // if the mySql connection isnt null
                {
                    MySqlConnection.Dispose(); // then lets dispose it
                }

            }

        }
        [HttpPut] // put request
        [ActionName("UpdateMessage")]
        public Message ChangeMessage(Message message)
        {

            MySqlConnection MySqlConnection = new MySqlConnection(connectionString);

            ListDictionary paramsList = new ListDictionary();

            try
            {
                MySqlConnection.Open();

                paramsList.Add("@id", message.Id);
                paramsList.Add("@message", message.Message1);
                paramsList.Add("@message", message.Rating);
                int status = ExecSPWithParams("dbo.update_message", paramsList);

                if (status > 0)
                {
                    message.IsDbChangeSuccessful = true;
                }
                else
                {
                    message.IsDbChangeSuccessful = false;
                }

                MySqlConnection.Close();
                return message;
            }


            catch (MySqlException MySqlException)
            {
                message.IsDbChangeSuccessful = false;
                message.ExcptnMsg = MySqlException.Message;
                return message;
            }
            catch (Exception err)
            {

                message.IsDbChangeSuccessful = false;
                message.ExcptnMsg = err.Message;
                return message;
            }
            finally
            {
                if (MySqlConnection != null)
                {
                    MySqlConnection.Dispose();
                }

            }
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