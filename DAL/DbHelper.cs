using LL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class DbHelper
    {
        private static SqlCommand _PrepareCommand(SqlConnection con, string query,
            SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            if (parameters != null)
            {
                foreach(var p in parameters)
                {
                    if(p.Value == null)
                    {
                        p.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(p);
                }
            }
            return cmd;
        }
        private static SqlConnection _GetConnection()
        {
            string cs = ConfigurationManager
                        .ConnectionStrings["DefaultConnection"]
                        ?.ConnectionString;

            if (string.IsNullOrWhiteSpace(cs))
                throw new InvalidOperationException("invalid connection string");

            return new SqlConnection(cs);
        }
        public static DataTable GetDataTable(string query, 
            SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = _GetConnection())
            {
                using (SqlCommand cmd = _PrepareCommand(con, query, parameters))
                {
                    try
                    {
                        con.Open();
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if(reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError("GetDataTable Failed;", ex);
                        throw;
                    }
                }
            }
            return dt;
        }
        public static DataRow GetFirstRow(string query, 
            SqlParameter[] parameters = null)
        {
            DataTable dt = GetDataTable(query, parameters);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
        public static object GetScalar(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection con = _GetConnection())
            {
                using (SqlCommand cmd = _PrepareCommand(con, query, parameters))
                {
                    try
                    {
                        con.Open();
                        return cmd.ExecuteScalar();
                    }
                    catch(Exception ex)
                    {
                        Logger.LogError("GetScalar Failed;", ex);
                        throw;
                    }
                }
            }
        }
        public static int ExecuteNonQuery(string query, 
            SqlParameter[] parameters = null)
        {
            using (SqlConnection con = _GetConnection())
            {
                using (SqlCommand cmd = _PrepareCommand(con, query, parameters))
                {
                    try
                    {
                        con.Open();
                        return cmd.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        Logger.LogError("ExecuteNonQuery Failed;", ex);
                        throw;
                    }
                }
            }
        }
    }
}
