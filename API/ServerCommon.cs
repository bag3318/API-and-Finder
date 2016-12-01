using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Specialized;

namespace API
{
    public class ServerCommon
    {
        private static int m_CommandTimeout = 300;
        private static Hashtable m_SqlCommandCache = new Hashtable();

        public static int ExecuteNonQuery(SqlConnection connection, string procedure, ListDictionary parameterValues)
        {
            bool flag = false;
            try
            {
                if (connection == null)
                    throw new ArgumentException("Valid connection is required.");
                if (procedure == null || procedure == "")
                    throw new ArgumentException("Valid procedure is required.");
                SqlCommand sqlCommand = ServerCommon.GetSqlCommand(connection.ConnectionString, procedure);
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
        public static SqlCommand GetSqlCommand(string connectionString, string procedure)
        {
            try
            {
                if (procedure == null || procedure == "" || (connectionString == null || connectionString == ""))
                    return (SqlCommand)null;
                SqlCommand sqlCommand = ServerCommon.Get(true, connectionString, procedure);
                if (sqlCommand != null)
                    return sqlCommand;
                SqlConnection connection = new SqlConnection(connectionString);
                try
                {
                    SqlCommand command = new SqlCommand(procedure, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlCommandBuilder.DeriveParameters(command);
                    foreach (SqlParameter sqlParameter in (DbParameterCollection)command.Parameters)
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
        public static void SetParameterValues(SqlCommand command, ListDictionary parameterValues)
        {
            try
            {
                if (command == null || parameterValues == null)
                    return;
                foreach (SqlParameter sqlParameter in (DbParameterCollection)command.Parameters)
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
        public static void GetParameterValues(SqlCommand command, ListDictionary parameterValues)
        {
            try
            {
                if (command == null || parameterValues == null)
                    return;
                foreach (SqlParameter sqlParameter in (DbParameterCollection)command.Parameters)
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
        public static SqlCommand Get(bool clone, string connectionString, string commandText)
        {
            if (connectionString == null || connectionString == "" || (commandText == null || commandText == ""))
                return (SqlCommand)null;
            SqlCommand sqlCommand = (SqlCommand)ServerCommon.m_SqlCommandCache[(object)(commandText + "@" + connectionString)];
            if (sqlCommand != null && clone)
                return (SqlCommand)((ICloneable)sqlCommand).Clone();
            return sqlCommand;
        }
        public static void Add(SqlCommand command)
        {
            try
            {
                if (command == null)
                    throw new NullReferenceException("Connection is null.  Command cache requires a connection string.");
                ServerCommon.m_SqlCommandCache[(object)(command.CommandText + "@" + command.Connection.ConnectionString)] = (object)command;
            }
            catch
            {
                throw;
            }
        }
    }
}