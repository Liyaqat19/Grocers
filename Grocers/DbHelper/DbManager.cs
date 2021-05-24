using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Grocers.DbHelper
{
    public class DbManager
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["GrocersConnectionString"].ToString();
        SqlConnection connection = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter();
        public DataSet GetData(string procedureName, Dictionary<string, object> parameters = null)
        {
            connection = new SqlConnection(connectionString);
            cmd = new SqlCommand(procedureName, connection);

            cmd.CommandType = CommandType.StoredProcedure;
            if (parameters != null && parameters.Count > 0)
            {
                foreach (var p in parameters)
                {
                    cmd.Parameters.AddWithValue("@" + p.Key, p.Value);
                }
            }
            adp = new SqlDataAdapter(cmd);
            ds = new DataSet();
            connection.Open();
            adp.Fill(ds);
            connection.Close();
            return ds;
        }
        public bool SaveOrUpdateData(string procedureName, Dictionary<string, object> parameters = null)
        {
            bool flag = false;
            try
            {
                connection = new SqlConnection(connectionString);
                cmd = new SqlCommand(procedureName, connection);

                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null && parameters.Count > 0)
                {
                    foreach (var p in parameters)
                    {
                            cmd.Parameters.AddWithValue("@" + p.Key, p.Value);
                    }
                }
                connection.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return flag;
        }

        public bool SaveOrUpdateDataWithDataTable(string procedureName,List<SqlParameter> parameters = null)
        {
            bool flag = false;
            try
            {
                connection = new SqlConnection(connectionString);
                cmd = new SqlCommand(procedureName, connection);

                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null && parameters.Count > 0)
                {
                    foreach (var p in parameters)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                connection.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return flag;
        }


    }
}