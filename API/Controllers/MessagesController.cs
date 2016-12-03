using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;
using API.Models;
using System.Text;
using System.Collections.Specialized;
using MySql.Data.MySqlClient;


namespace API.Controllers // define api namespace: controller
{
    public class MessageController : ApiController // define controller class
    {
        string connectionString = ConfigurationManager.AppSettings["sql"]; // define app settings
        public List<Message> MessageData(string sql) // pass in string sql
        {
            MySqlCommand mySqlCommandMessage; // define mysql command
            MySqlDataReader mySqlDataReaderMessage; // define sql data reader
            MySqlConnection mySqlConnectionMessage = new MySqlConnection(connectionString); // define new connection
            List<Message> messages = new List<Message>(); // define new message list
            try
            {
                mySqlConnectionMessage.Open(); // open the connection
                mySqlCommandMessage = new MySqlCommand(sql, mySqlConnectionMessage); // define new command passing in string sql and the connection
                mySqlDataReaderMessage = mySqlCommandMessage.ExecuteReader(); // execute
                if (mySqlDataReaderMessage.HasRows) // if the table has rows
                {
                    while (mySqlDataReaderMessage.Read()) // read the mySql data table
                    {
                        Message message = new Message(); // add new message
                        message.Message1 = mySqlDataReaderMessage["usrmessage"].ToString().Trim(); // add message from the db
                        message.Id = mySqlDataReaderMessage["id"].ToString().Trim(); // id
                        message.Rating = mySqlDataReaderMessage["rating"].ToString().Trim(); // and rating
                        messages.Add(message); // finally, append the message
                    }
                }
                // close all connections and readers
                mySqlDataReaderMessage.Close(); // first close the datareader
                mySqlConnectionMessage.Close(); // then close the connection
                return messages; // make sure all code paths return something


            }
            catch (MySqlException mySqlException) // we put the general exception first
            {
                string excptn = mySqlException.Message; // catch the message error
                return messages; // return messages

            }
            catch (Exception err) // then this exception
            {
                string errMsg = err.Message; // output the error in a string
                return messages; // return messages
            }
            finally // this will execute no matter what
            {
                if (mySqlConnectionMessage != null) // if not null
                {
                    mySqlConnectionMessage.Dispose(); // dump the whole connection
                }

            }
        }

        [HttpGet] // HTTP GET request, define that we are doing a get request
        [ActionName("RetrieveMessage")] // define the action name
        public List<Message> RetrieveMessagesById(int id) // define new public list for message while passing in the integer id
        { // open method
            StringBuilder mySql = new StringBuilder(); // define a new stringbuilder to pass in sql statements
            mySql.Append("SELECT * FROM "); // select all from
            mySql.Append("message "); // message
            mySql.Append("WHERE "); // where the
            mySql.Append("id = "); // id is equal to
            mySql.Append("'" + id + "'"); // the integer id
            List<Message> messages = new List<Message>(); // define new list of messages, of type Message
            return messages = MessageData(mySql.ToString()); // return messages with the sql statement

        } // close method
        [HttpPost] // specify the http protocal method
        [ActionName("AddMessage")] // add our action name

        public Message AddMessage(Message message) // define a new public method of type Message named add message while passing message of type Messsage
        {

            MySqlConnection mySqlConnection = new MySqlConnection(connectionString); // define new mysql connection = to a connection string
            ListDictionary paramsList = new ListDictionary(); // define a new parameter list of type list dictionary

            try
            {
                mySqlConnection.Open(); // open mySql connection
                foreach (Message message1 in message.Messages) // for each of the messages in the messages column in the db table
                {
                    paramsList.Add("ID", message.Id);
                    paramsList.Add("usrmsg", message.Messages); // do the same thing for message
                    paramsList.Add("rate", message.Rating); // and for rating
                    int status = ExecSPWithParams("insert_message", paramsList); // call Message.cs model to get the status of executeSPwithparams 
                    if (status > 0) // if the status is greater than zero
                    {
                        message.Id = paramsList["ID"].ToString(); // add the id to a string
                    }
                    else
                    {
                        message.Id = "1"; // else set the id equal to 1
                    }
                }
                mySqlConnection.Close(); // close the connection
                
                return message; // and return the message

            }
            catch (MySqlException mySqlException) // for our catch statement, we put the general exception first
            {
                message.ExcptnMsg = mySqlException.Message; // so we output the error here
                message.Id = "0"; // set the message's id = to 0
                return message; // and return the message itself to make sure all code paths return a value
            }
            catch (Exception err) // then we put this exception in our second catch statement
            {
                message.ExcptnMsg = err.Message; // output the error message here
                message.Id = "0"; // set the messsage's id = 0
                return message; // and return the message
            }
            finally // finally (this will execute no matter what)
            {
                if (mySqlConnection != null) // if the mysql connection is NOT = to null (nothing)
                {
                    mySqlConnection.Dispose(); // dipsose the whole connection
                }

            }
        } // end method
        [HttpDelete] // delete request
        [ActionName("RemoveMessage")]
        public Message RemoveMessage(Message message)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

            ListDictionary paramsList = new ListDictionary();
            try
            {
                mySqlConnection.Open();
                paramsList.Add("@id", message.Id);
                paramsList.Add("@usrmessage", message.Message1);
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
                mySqlConnection.Close();
                return message;
            }
            catch (MySqlException mySqlException) // put first becuase of general exception
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
            finally // and this finally statement executes regardless
            {
                if (mySqlConnection != null) // if the mySql connection isnt null
                {
                    mySqlConnection.Dispose(); // then lets dispose it
                }

            }

        }
        /*
         *  // since we do not need edit the messages, we will not need a put request (we don't need to push anything)
         *  [HttpPut] // put request
         *  [ActionName("UpdateMessage")]
         *  public Message ChangeMessage(Message message)
         *  {
         *  
         *  MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
         * 
         *  ListDictionary paramsList = new ListDictionary();
         * 
         *       try
         *       {
         *           mySqlConnection.Open();
         *
         *           paramsList.Add("@id", message.Id);
         *           paramsList.Add("@message", message.Message1);
         *           paramsList.Add("@message", message.Rating);
         *           int status = ExecSPWithParams("dbo.update_message", paramsList);
         *
         *           if (status > 0)
         *           {
         *               message.IsDbChangeSuccessful = true;
         *           }
         *           else
         *           {
         *               message.IsDbChangeSuccessful = false;
         *           }
         * 
         *           mySqlConnection.Close();
         *           return message;
         *       }
         *  
         *       catch (MySqlException MySqlException)
         *       {
         *           message.IsDbChangeSuccessful = false;
         *           message.ExcptnMsg = MySqlException.Message;
         *           return message;
         *       }
         *       catch (Exception err)
         *       {
         *           message.IsDbChangeSuccessful = false;
         *           message.ExcptnMsg = err.Message;
         *           return message;
         *       }
         *       finally
         *       {
         *          {
         *               mySqlConnection.Dispose();
         *          }
         *      }
         *  }
         */

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

