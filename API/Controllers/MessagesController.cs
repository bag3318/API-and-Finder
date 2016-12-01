using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;
using API.Models;
using System.Text;
using System.Collections.Specialized;
using System.Data.SqlClient;

namespace API.Controllers // define namespace
{
    public class MessageController : ApiController
    {
        string connectionString = ConfigurationManager.AppSettings["sql"]; // define app settings
        public List<Message> MessageData(string sql)
        {
            SqlCommand SqlCommandMessage;
            SqlDataReader SqlDataReaderMessage;
            SqlConnection SqlConnection = new SqlConnection(connectionString);
            SqlConnection SqlConnectionMessage = new SqlConnection(connectionString);
            List<Message> messages = new List<Message>(); // define new message list
            try
            {
                SqlConnectionMessage.Open();
                SqlCommandMessage = new SqlCommand(sql, SqlConnectionMessage);
                SqlDataReaderMessage = SqlCommandMessage.ExecuteReader();
                if (SqlDataReaderMessage.HasRows) // if the table has rows
                {
                    while (SqlDataReaderMessage.Read()) // read the sql data table
                    {
                        Message message = new Message();
                        message.Message1 = SqlDataReaderMessage["message"].ToString().Trim();
                        message.Id = SqlDataReaderMessage["id"].ToString().Trim();
                        message.Rating = SqlDataReaderMessage["rating"].ToString().Trim();
                        messages.Add(message);
                        StringBuilder SqlString = new StringBuilder();
                        SqlString.Append("SELECT * FROM ");
                        SqlString.Append("messages WHERE ");
                        SqlString.Append("id = ");
                        SqlString.Append("'" + message.Id + "'");
                        SqlConnectionMessage.Open();
                        SqlCommandMessage = new SqlCommand(SqlString.ToString(), SqlConnectionMessage); // we must convert SqlString, which is a stringbuilder, to a regular string by using the .ToString() property.
                        SqlDataReaderMessage = SqlCommandMessage.ExecuteReader();
                    }
                }
                // close all connections and readers
                SqlDataReaderMessage.Close();
                SqlConnectionMessage.Close();
                return messages; // make sure all code paths return something


            }
            catch (SqlException SqlException) // here is our catch statement
            {
                string excptn = SqlException.Message;
                return messages;

            }
            catch (Exception err)
            {
                string errMsg = err.Message;
                return messages;
            }
            finally
            {
                if (SqlConnection != null) // if not null
                {
                    SqlConnection.Dispose(); // dump the whole thing
                }

            }
        }

        [HttpGet] // HTTP GET request
        [ActionName("RetrieveMessage")]

        public List<Message> RetrieveMessagesById(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM ");
            sql.Append("messages");
            sql.Append("WHERE ");
            sql.Append("id = ");
            sql.Append("'" + id + "'");
            List<Message> messages = new List<Message>();
            return messages = MessageData(sql.ToString());

        }
        [HttpPost] // specify the http protocal method
        [ActionName("AddMessage")] // add our action name
        public Message AddMessage(Message message)
        {

            SqlConnection SqlConnection = new SqlConnection(connectionString);
            ListDictionary paramsList = new ListDictionary();

            try
            {
                SqlConnection.Open(); // open sql connection
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
                SqlConnection.Close();

                return message;

            }
            catch (SqlException sqlException)
            {
                message.ExcptnMsg = sqlException.Message;
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
                if (SqlConnection != null)
                {
                    SqlConnection.Dispose();
                }

            }
        } // end method
        [HttpDelete] // delete request
        [ActionName("RemoveMessage")]
        public Message RemoveMessage(Message message)
        {
            SqlConnection SqlConnection = new SqlConnection(connectionString);

            ListDictionary paramsList = new ListDictionary();
            try
            {
                SqlConnection.Open();
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
                SqlConnection.Close();
                return message;
            }
            catch (SqlException SqlException) // put first becuase of general exception
            {
                message.ExcptnMsg = SqlException.Message;
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
                if (SqlConnection != null) // if the sql connection isnt null
                {
                    SqlConnection.Dispose(); // then lets dispose it
                }

            }

        }
        [HttpPut] // put request
        [ActionName("UpdateMessage")]

        public Message ChangeMessage(Message message)
        {

            SqlConnection SqlConnection = new SqlConnection(connectionString);

            ListDictionary paramsList = new ListDictionary();

            try
            {
                SqlConnection.Open();

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

                SqlConnection.Close();
                return message;
            }


            catch (SqlException SqlException)
            {
                message.IsDbChangeSuccessful = false;
                message.ExcptnMsg = SqlException.Message;
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
                if (SqlConnection != null)
                {
                    SqlConnection.Dispose();
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
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            int status = ServerCommon.ExecuteNonQuery(con, spName, paramsList);
            con.Close();
            return status;
        }
    }
}