using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManagement.Common;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace PatientManagement.DataAccess
{
	public class SqlHelper 
	{
		public static string HospitalDB_CoonectionString = ConfigurationManager.ConnectionStrings["Hospital_ConnectionString"].ConnectionString;
        SqlConnection sqlcon;
        SqlCommand sqlcmd;

        public SqlHelper()
        {
            sqlcon = new SqlConnection();
            sqlcon.ConnectionString=HospitalDB_CoonectionString;

        }

        //overloaded the constructor to support multiple connections tring on the fly
        public SqlHelper(string strConnectionString)
        {
            sqlcon = new SqlConnection();
            sqlcon.ConnectionString = strConnectionString;
        }

        void OpenConnection()
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {

            }

        }


        public void CloseConnection()
        {
            if (sqlcon.State == ConnectionState.Open)
            {
                try
                {
                    sqlcon.Close();
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }

        #region ExecuteScalar Methods
        public Object ExecuteScalar(string strSpName, SqlParameter[] arrSqlParam)
        {
            try
            {
                OpenConnection();
                sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = strSpName;
                if (arrSqlParam != null)
                {
                    sqlcmd.Parameters.AddRange(arrSqlParam);
                }
                int obj = (int)sqlcmd.ExecuteScalar();
                
                return obj;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                CloseConnection();
            }
        }
        #endregion

        #region DataReader Methods

        public SqlDataReader ExecuteDataReader(SqlCommand cmd)
        {
            SqlDataReader dr;

            try
            {
                OpenConnection();

                sqlcmd = cmd;
                sqlcmd.Connection = sqlcon;

                dr = sqlcmd.ExecuteReader(CommandBehavior.CloseConnection);

                return dr;
            }
            catch (Exception exp)
            {
                CloseConnection();
                throw exp;
            }

        }

        /// <summary>
        /// ExecuteDataReader
        /// </summary>
        /// <param name="strSpName">string</param>
        /// <param name="arrSqlParam">SqlParameter[]</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader ExecuteDataReader(string strSpName, SqlParameter[] arrSqlParam)
        {
            return ExecuteDataReader(strSpName, arrSqlParam, 0);
        }

        /// <summary>
        /// ExecuteDataReader
        /// </summary>
        /// <param name="strSpName">string</param>
        /// <param name="arrSqlParam">v</param>
        /// <param name="timeOutInSeconds">timeOutInSeconds</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader ExecuteDataReader(string strSpName, SqlParameter[] arrSqlParam, int timeOutInSeconds)
        {
            SqlDataReader dr;

            try
            {
                OpenConnection();

                sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = strSpName;
                if (timeOutInSeconds > 0)
                {
                    sqlcmd.CommandTimeout = timeOutInSeconds;
                }
                if (arrSqlParam != null)
                    sqlcmd.Parameters.AddRange(arrSqlParam);

                dr = sqlcmd.ExecuteReader(CommandBehavior.CloseConnection);

                return dr;
            }
            catch (Exception exp)
            {
                CloseConnection();
                throw exp;
            }
        }
        #endregion



        #region ExecuteNonQuery Methods

        public int ExecuteNonQuery(string strSpName, SqlParameter[] arrSqlParam)
        {

            try
            {
                OpenConnection();

                sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = strSpName;
                if (arrSqlParam != null)
                {
                    sqlcmd.Parameters.AddRange(arrSqlParam);
                }
                int iRowsAffected = sqlcmd.ExecuteNonQuery();

                return iRowsAffected;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                CloseConnection();
            }
        }

        public int ExecuteNonQuery(string strSpName, SqlParameter[] arrSqlParam, int timeOutInSeconds)
        {

            try
            {
                OpenConnection();

                sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = strSpName;
                if (timeOutInSeconds > 0)
                {
                    sqlcmd.CommandTimeout = timeOutInSeconds;
                }
                if (arrSqlParam != null)
                    sqlcmd.Parameters.AddRange(arrSqlParam);

                int iRowsAffected = sqlcmd.ExecuteNonQuery();

                return iRowsAffected;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                CloseConnection();
            }
        }
        #endregion


        #region HandlingDifferen Datattypes
        /// <summary>
        /// HandleDateTime : to handle DateTime?
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>DateTime?</returns>
        public static DateTime? HandleDateTime(object obj)
        {
            if (Convert.IsDBNull(obj))
            {
                return null;
            }
            else
            {
                return Convert.ToDateTime(obj);
            }
        }
        public static Double HandleDouble(object obj)
        {
            if (Convert.IsDBNull(obj))
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble(obj);
            }
        }
        /// <summary>
        /// HandleString : to handle null/string
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>string</returns>
        public static string HandleString(object obj)
        {
            if (Convert.IsDBNull(obj))
            {
                return string.Empty;
            }
            else
            {
                return obj.ToString();
            }
        }

        /// <summary>
        /// HandleString : to handle null/string
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>string</returns>
        public static string HandleNullableString(object obj)
        {
            if (Convert.IsDBNull(obj))
            {
                return null;
            }
            else
            {
                return obj.ToString();
            }
        }

        /// <summary>
        /// HandleNullableInt : to handle null/int
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>int?</returns>
        public static int? HandleNullableInt(object obj)
        {
            if (Convert.IsDBNull(obj))
            {
                return null;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// HandleInt : to handle null/int
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>int</returns>
        public static int HandleInt(object obj)
        {
            if (Convert.IsDBNull(obj))
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// HandleNullableDecimal : to handle null/int
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>decimal?</returns>
        public static decimal? HandleNullableDecimal(object obj)
        {
            if (Convert.IsDBNull(obj))
            {
                return null;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }

        /// <summary>
        /// HandleDecimal : to handle null/int
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>decimal</returns>
        public static decimal HandleDecimal(object obj)
        {
            if (Convert.IsDBNull(obj))
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }

        /// <summary>
        /// HandleNullbleBool : to handle null/int
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>int</returns>
        public static bool? HandleNullbleBool(object obj)
        {
            if (Convert.IsDBNull(obj))
            {
                return null;
            }
            else
            {
                return Convert.ToBoolean(obj);
            }
        }

        /// <summary>
        /// HandleNullbleBool : to handle null/int
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>int</returns>
        public static bool HandleBool(object obj)
        {
            if (Convert.IsDBNull(obj))
            {
                return false;
            }
            else
            {
                return Convert.ToBoolean(obj);
            }
        }

        #endregion
    }

}

