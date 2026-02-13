using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Framework.DAL
{
    public class clsBaseRepository
    {
        public static bool IsRecordFound(string TableName, string ColumnName, int ID) {
            string Query = $"SELECT IsFound = 1 FROM {TableName} WHERE " +
                $"{ColumnName} = @ID;";
            SqlParameter[] Parameters = new SqlParameter[]
            {
                new SqlParameter($"@ID", SqlDbType.Int) { Value = ID }
            };
            object Result = DbHelper.GetScalar(Query, Parameters);
            if(Result != null)
            {
                return Convert.ToBoolean(Result);
            }
            return false;
        }
        public static bool DeleteRecord(string TableName, string ColumnName, int ID)
        {
            string Query = $"DELETE FROM {TableName} WHERE {ColumnName} = @{ID};";
            SqlParameter[] Parameters = new SqlParameter[]
            {
                new SqlParameter($"@ID", SqlDbType.Int) { Value = ID }
            };
            return DbHelper.ExecuteNonQuery(Query, Parameters) > 0;
        }
    }
}
