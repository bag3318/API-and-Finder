using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Specialized;

namespace API
{
    public class ServerCommon
    {
        private static int m_CommandTimeout = 300;
        private static Hashtable m_MySqlCommandCache = new Hashtable();

        public static int ExecuteNonQuery(MySqlConnection connection, string procedure, ListDictionary parameterValues)
        {
            bool flag = false;
            try
            {
                if (connection == null)
                    throw new ArgumentException("Valid connection is required.");
                if (procedure == null || procedure == "")
                    throw new ArgumentException("Valid procedure is required.");
                MySqlCommand sqlCommand = ServerCommon.GetMySqlCommand(connection.ConnectionString, procedure);
                sqlCommand.Connection = connection;
                ServerCommon.SetParameterValues(sqlCommand, parameterValues);
                if (connection.State == ConnectionState.Closed)
                {
                    flag = true;
                    connection.Open();
                }
                int num = sqlCommand.ExecuteNonQuery();
                ServerCommon.GetParameterValues(sqlCommand, parameterValues);
                return num;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (flag)
                    connection.Close();
            }
        }
        public static MySqlCommand GetMySqlCommand(string connectionString, string procedure)
        {
            try
            {
                if (procedure == null || procedure == "" || (connectionString == null || connectionString == ""))
                    return (MySqlCommand)null;
                MySqlCommand sqlCommand = ServerCommon.Get(true, connectionString, procedure);
                if (sqlCommand != null)
                    return sqlCommand;
                MySqlConnection connection = new MySqlConnection(connectionString);
                try
                {
                    MySqlCommand command = new MySqlCommand(procedure, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    MySqlCommandBuilder.DeriveParameters(command);
                    foreach (MySqlParameter sqlParameter in (DbParameterCollection)command.Parameters)
                        sqlParameter.SourceColumn = sqlParameter.ParameterName.Substring(1, sqlParameter.ParameterName.ToString().Length - 1);
                    ServerCommon.Add(command);
                    command.CommandTimeout = ServerCommon.m_CommandTimeout;
                    return command;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (connection != null)
                        connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void SetParameterValues(MySqlCommand command, ListDictionary parameterValues)
        {
            try
            {
                if (command == null || parameterValues == null)
                    return;
                foreach (MySqlParameter sqlParameter in (DbParameterCollection)command.Parameters)
                {
                    if (parameterValues.Contains((object)sqlParameter.ParameterName))
                    {
                        sqlParameter.Value = parameterValues[(object)sqlParameter.ParameterName];
                        sqlParameter.SourceColumn = (string)null;
                    }
                    else if (parameterValues.Contains((object)sqlParameter.ParameterName.Substring(1)))
                    {
                        sqlParameter.Value = parameterValues[(object)sqlParameter.ParameterName.Substring(1)];
                        sqlParameter.SourceColumn = (string)null;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public static void GetParameterValues(MySqlCommand command, ListDictionary parameterValues)
        {
            try
            {
                if (command == null || parameterValues == null)
                    return;
                foreach (MySqlParameter sqlParameter in (DbParameterCollection)command.Parameters)
                {
                    if (sqlParameter.Direction == ParameterDirection.ReturnValue)
                        parameterValues[(object)sqlParameter.ParameterName] = sqlParameter.Value;
                    else if (parameterValues.Contains((object)sqlParameter.ParameterName))
                    {
                        if (sqlParameter.Direction == ParameterDirection.InputOutput || sqlParameter.Direction == ParameterDirection.Output)
                            parameterValues[(object)sqlParameter.ParameterName] = sqlParameter.Value;
                    }
                    else if (parameterValues.Contains((object)sqlParameter.ParameterName.Substring(1)) && (sqlParameter.Direction == ParameterDirection.InputOutput || sqlParameter.Direction == ParameterDirection.Output))
                        parameterValues[(object)sqlParameter.ParameterName.Substring(1)] = sqlParameter.Value;
                }
            }
            catch
            {
                throw;
            }
        }
        public static MySqlCommand Get(bool clone, string connectionString, string commandText)
        {
            if (connectionString == null || connectionString == "" || (commandText == null || commandText == ""))
                return (MySqlCommand)null;
            MySqlCommand sqlCommand = (MySqlCommand)ServerCommon.m_MySqlCommandCache[(object)(commandText + "@" + connectionString)];
            if (sqlCommand != null && clone)
                return (MySqlCommand)((ICloneable)sqlCommand).Clone();
            return sqlCommand;
        }
        public static void Add(MySqlCommand command)
        {
            try
            {
                if (command == null)
                    throw new NullReferenceException("Connection is null.  Command cache requires a connection string.");
                ServerCommon.m_MySqlCommandCache[(object)(command.CommandText + "@" + command.Connection.ConnectionString)] = (object)command;
            }
            catch
            {
                throw;
            }
        }
    }
}