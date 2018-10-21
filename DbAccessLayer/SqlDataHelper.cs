using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Web.Configuration;
using System.Configuration;
using System.IO;

namespace DbAccessLayer
{
    public class SqlDataHelper
    {
          #region Methods

        internal static string GetConnectionString(string ConnectionStringName)
        {
            string connectionString = null;

            ConnectionStringSettings settings = WebConfigurationManager.ConnectionStrings[ConnectionStringName];
            if (settings != null)
            {
                connectionString = settings.ConnectionString;
            }

            return connectionString;
        }

       
        /// <summary>
        /// Gets a boolean value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A boolean value</returns>
        public static bool GetBoolean(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return false;
            }
            return Convert.ToBoolean(rdr[index]);
        }

        /// <summary>
        /// Gets a byte array of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A byte array</returns>
        public static byte[] GetBytes(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (byte[])rdr[index];
        }

        /// <summary>
        /// Gets a datetime value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A date time</returns>
        public static DateTime GetDateTime(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return DateTime.MinValue;
            }
            return (DateTime)rdr[index];
        }

        /// <summary>
        /// Gets an UTC datetime value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A date time</returns>
        public static DateTime GetUtcDateTime(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return DateTime.MinValue;
            }
            return DateTime.SpecifyKind((DateTime)rdr[index], DateTimeKind.Utc);
        }

        /// <summary>
        /// Gets a nullable datetime value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A date time if exists; otherwise, null</returns>
        public static DateTime? GetNullableDateTime(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (DateTime)rdr[index];
        }

        /// <summary>
        /// Gets a nullable UTC datetime value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A date time if exists; otherwise, null</returns>
        public static DateTime? GetNullableUtcDateTime(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return DateTime.SpecifyKind((DateTime)rdr[index], DateTimeKind.Utc);
        }

        /// <summary>
        /// Gets a decimal value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A decimal value</returns>
        public static decimal GetDecimal(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return decimal.Zero;
            }
            return Convert.ToDecimal(rdr[index]);
        }

        /// <summary>
        /// Gets a nullable Double value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A nullable Double value</returns>
        public static Decimal? GetNullableDecimal(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (Decimal)rdr[index];
        }

        /// <summary>
        /// Gets a double value of a data reader by a column name
        /// Sql same type is : Float
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A double value</returns>
        public static double GetDouble(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0.0;
            }
            return (double)rdr[index];
        }

        /// <summary>
        /// Gets a nullable Double value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A nullable Double value</returns>
        public static double? GetNullableDouble(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (double)rdr[index];
        }

        /// <summary>
        /// Gets a GUID value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A GUID value</returns>
        public static Guid GetGuid(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return Guid.Empty;
            }
            return (Guid)rdr[index];
        }


        /// <summary>
        /// Gets a nullable Int16 value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A nullable Int16 value</returns>
        public static Int16? GetNullableInt16(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (Int16)rdr[index];
        }

        /// <summary>
        /// Gets an SmallInt value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>An integer value</returns>
        public static Int16 GetInt16(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0;
            }
            return (Int16)rdr[index];

        }

        /// <summary>
        /// Gets an integer value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>An integer value</returns>
        public static int GetInt(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0;
            }
            return (int)rdr[index];
            
        }

        /// <summary>
        /// Gets an integer value of a data reader by a column name
        /// sql same datatype: BigInt
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>An integer value</returns>
        public static Int64 GetInt64(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0;
            }
            return (Int64)rdr[index];

        }

        /// <summary>
        /// Gets a nullable Int64 value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A nullable Int64 value</returns>
        public static Int64? GetNullableInt64(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (Int64)rdr[index];
        }

        /// <summary>
        /// Gets an Real value of a data reader by a column name
        /// 
        /// sql same datatype: Real
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>An integer value</returns>
        public static float GetReal(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0;
            }
            return (float)rdr[index];

        }

        /// <summary>
        /// Gets a nullable Real value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A nullable Real value</returns>
        public static float? GetNullableReal(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (float)rdr[index];
        }

        /// <summary>
        /// Gets an tinyint value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>An tinyint value</returns>
        public static Byte GetTinyInt(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0;
            }
            return (Byte)rdr[index];
            
        }

        /// <summary>
        /// Gets a nullable TinyInt value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A nullable TinyInt value</returns>
        public static Byte? GetNullableTinyInt(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (Byte)rdr[index];
        }

        /// <summary>
        /// Gets a nullable integer value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A nullable integer value</returns>
        public static int? GetNullableInt(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (int)rdr[index];
        }

        /// <summary>
        /// Gets a string of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A string value</returns>
        public static string GetString(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return string.Empty;
            }
            return (string)rdr[index];
        }
        #endregion
    }

    public class MySqlDataHelper
    {

        #region Methods

         /// <summary>
        /// Gets a boolean value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A boolean value</returns>
        public static bool GetBoolean(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return false;
            }
            return Convert.ToBoolean(rdr[index]);
        }

        /// <summary>
        /// Gets a byte array of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A byte array</returns>
        public static byte[] GetBytes(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (byte[])rdr[index];
        }

        /// <summary>
        /// Gets a datetime value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A date time</returns>
        public static DateTime GetDateTime(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return DateTime.MinValue;
            }
            return (DateTime)rdr[index];
        }

        /// <summary>
        /// Gets an UTC datetime value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A date time</returns>
        public static DateTime GetUtcDateTime(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return DateTime.MinValue;
            }
            return DateTime.SpecifyKind((DateTime)rdr[index], DateTimeKind.Utc);
        }

        /// <summary>
        /// Gets a nullable datetime value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A date time if exists; otherwise, null</returns>
        public static DateTime? GetNullableDateTime(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (DateTime)rdr[index];
        }

        /// <summary>
        /// Gets a nullable UTC datetime value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A date time if exists; otherwise, null</returns>
        public static DateTime? GetNullableUtcDateTime(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return DateTime.SpecifyKind((DateTime)rdr[index], DateTimeKind.Utc);
        }

        /// <summary>
        /// Gets a decimal value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A decimal value</returns>
        public static decimal GetDecimal(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return decimal.Zero;
            }
            return Convert.ToDecimal(rdr[index]);
        }

        /// <summary>
        /// Gets a nullable Double value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A nullable Double value</returns>
        public static Decimal? GetNullableDecimal(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (Decimal)rdr[index];
        }

        /// <summary>
        /// Gets a double value of a data reader by a column name
        /// Sql same type is : Float
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A double value</returns>
        public static double GetDouble(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0.0;
            }
            return (double)rdr[index];
        }

        /// <summary>
        /// Gets a nullable Double value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A nullable Double value</returns>
        public static double? GetNullableDouble(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (double)rdr[index];
        }

        /// <summary>
        /// Gets a GUID value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A GUID value</returns>
        public static Guid GetGuid(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return Guid.Empty;
            }
            return (Guid)rdr[index];
        }


        /// <summary>
        /// Gets a nullable Int16 value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A nullable Int16 value</returns>
        public static Int16? GetNullableInt16(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (Int16)rdr[index];
        }

        /// <summary>
        /// Gets an SmallInt value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>An integer value</returns>
        public static Int16 GetInt16(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0;
            }
            return (Int16)rdr[index];

        }

        /// <summary>
        /// Gets an integer value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>An integer value</returns>
        public static int GetInt(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0;
            }
            return (int)rdr[index];

        }

        /// <summary>
        /// Gets an integer value of a data reader by a column name
        /// sql same datatype: BigInt
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>An integer value</returns>
        public static Int64 GetInt64(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0;
            }
            return (Int64)rdr[index];

        }

        /// <summary>
        /// Gets a nullable Int64 value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A nullable Int64 value</returns>
        public static Int64? GetNullableInt64(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (Int64)rdr[index];
        }

        /// <summary>
        /// Gets an Real value of a data reader by a column name
        /// 
        /// sql same datatype: Real
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>An integer value</returns>
        public static float GetReal(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0;
            }
            return (float)rdr[index];

        }

        /// <summary>
        /// Gets a nullable Real value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A nullable Real value</returns>
        public static float? GetNullableReal(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (float)rdr[index];
        }

        /// <summary>
        /// Gets an tinyint value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>An tinyint value</returns>
        public static Byte GetTinyInt(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0;
            }
            return (Byte)rdr[index];

        }

        /// <summary>
        /// Gets a nullable TinyInt value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A nullable TinyInt value</returns>
        public static Byte? GetNullableTinyInt(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (Byte)rdr[index];
        }

        /// <summary>
        /// Gets a nullable integer value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A nullable integer value</returns>
        public static int? GetNullableInt(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (int)rdr[index];
        }

        /// <summary>
        /// Gets a string of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A string value</returns>
        public static string GetString(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return string.Empty;
            }
            return (string)rdr[index];
        }
        #endregion

    }

}
