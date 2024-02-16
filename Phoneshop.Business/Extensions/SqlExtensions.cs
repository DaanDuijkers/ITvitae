using System;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;

namespace Phoneshop.Business.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class SqlExtensions
    {
        public static int GetInt(this SqlDataReader reader, string columnName)
        {
            return Convert.ToInt32(reader[columnName]);
        }

        public static double GetDouble(this SqlDataReader reader, string columnName)
        {
            return Convert.ToDouble(reader[columnName]);
        }

        public static string GetString(this SqlDataReader reader, string columnName)
        {
            return Convert.ToString(reader[columnName]);
        }

        public static DateTime GetDateTime(this SqlDataReader reader, string columnName)
        {
            return Convert.ToDateTime(reader[columnName]);
        }
    }
}