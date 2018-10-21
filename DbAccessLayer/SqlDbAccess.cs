namespace DbAccessLayer
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Web.Configuration;
    using MySql.Data.MySqlClient;
    using MySql.Data;
    


    public enum ConnectionStringSourceType
    {
        ConnectionString, AppConfig, WebConfig,MySetting
    }


    public class SqlDbAccess : IDbAccess
    {
        private bool _HasError = false;

        private bool _HandleError = true;

        private Exception _Exception = null;

        private string _ConnectionString;

        private SqlConnection _Connection;


        public SqlDbAccess()
        {
            Init(true, null, -1);
        }

        public SqlDbAccess(bool HandleError)
        {
            Init(HandleError, null, -1);
        }

        public SqlDbAccess(string ConnectionParameter, ConnectionStringSourceType Source)
        {
            Init(true, ConnectionParameter, (int)Source);
        }

        private void Init(bool handleError, string connectionParameter, int connectionStringSource)
        {
            switch (connectionStringSource)
            {
                case (int)(ConnectionStringSourceType.ConnectionString):

                    this._ConnectionString = connectionParameter;

                    break;

                case (int)(ConnectionStringSourceType.AppConfig):

                    this._ConnectionString = ConfigurationManager.ConnectionStrings[connectionParameter].ConnectionString;

                    break;

                case (int)(ConnectionStringSourceType.WebConfig):

                    this._ConnectionString = WebConfigurationManager.ConnectionStrings[connectionParameter].ConnectionString;

                    break;

                default:

                    try
                    {
                        this._ConnectionString = ConfigurationManager.ConnectionStrings["SqlConStr"].ConnectionString;
                    }
                    catch
                    {
                        try
                        {
                            this._ConnectionString = WebConfigurationManager.ConnectionStrings["SqlConStr"].ConnectionString;
                        }
                        catch
                        {
                            throw new Exception("ConStr parameter not found in App.config or Web.config files.");
                        }
                    }
                    break;
            }

            this._Connection = new SqlConnection(this._ConnectionString);

            this._HandleError = handleError;
        }


        #region IDbAccess Members

        public int ExecuteProcedure(string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        {
            this.ClearError();

            int result = int.MinValue;

            using (SqlCommand command = (SqlCommand)BuildCommand(CommandType.StoredProcedure, StoredProcedureName, Parameters))
            {
                command.CommandTimeout = 0;

                try
                {
                    this._Connection.Open();

                    result = command.ExecuteNonQuery();

                    this._Connection.Close();
                }
                catch (Exception ex)
                {
                    this.SetError(ex);
                }
            }

            return result;
        }

        public int ExecuteSqlCommandText(string SqlCommandText, params System.Data.IDataParameter[] Parameters)
        {
            this.ClearError();

            int result = int.MinValue;

            using (SqlCommand command = (SqlCommand)BuildCommand(CommandType.Text, SqlCommandText, Parameters))
            {
                command.CommandTimeout = 0;

                try
                {
                    this._Connection.Open();

                    result = command.ExecuteNonQuery();

                    this._Connection.Close();
                }
                catch (Exception ex)
                {
                    this.SetError(ex);
                }
            }

            return result;
        }

        public object GetScalarFromSqlCommandText(string SqlCommandText, params System.Data.IDataParameter[] Parameters)
        {
            this.ClearError();

            object result = null;

            using (SqlCommand command = (SqlCommand)BuildCommand(CommandType.Text, SqlCommandText, Parameters))
            {
                command.CommandTimeout = 0;

                try
                {
                    this._Connection.Open();

                    result = command.ExecuteScalar();

                    this._Connection.Close();
                }
                catch (Exception ex)
                {
                    this.SetError(ex);
                }
            }

            return result;
        }

        public object GetScalarFromProcedure(string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        {
            this.ClearError();

            object result = null;

            using (SqlCommand command = (SqlCommand)BuildCommand(CommandType.StoredProcedure, StoredProcedureName, Parameters))
            {
                command.CommandTimeout = 0;

                try
                {
                    this._Connection.Open();

                    result = command.ExecuteScalar();

                    this._Connection.Close();
                }
                catch (Exception ex)
                {
                    this.SetError(ex);
                }
            }

            return result;
        }

        public DataTable GetDataTableFromProcedure(string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        {
            return GetDataTableFromProcedure(null, StoredProcedureName, Parameters);
        }

        public DataTable GetDataTableFromProcedure(string TableName, string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        {
            this.ClearError();

            using (DataTable dataTable = new DataTable())
            {
                if (TableName != null)
                    dataTable.TableName = TableName;

                using (SqlDataAdapter daTableBuilder = new SqlDataAdapter())
                {
                    daTableBuilder.SelectCommand = (SqlCommand)this.BuildCommand(CommandType.StoredProcedure, StoredProcedureName, Parameters);

                    daTableBuilder.SelectCommand.CommandTimeout = 0;

                    try
                    {
                        daTableBuilder.Fill(dataTable);
                    }
                    catch (Exception ex)
                    {
                        this.SetError(ex);

                        return null;
                    }
                }

                return dataTable;
            }
        }

        public DataTable GetDataTableFromSqlCommandText(string SqlCommandText, params System.Data.IDataParameter[] Parameters)
        {
            return GetDataTableFromSqlCommandText(null, SqlCommandText, Parameters);
        }

        public DataTable GetDataTableFromSqlCommandText(string TableName, string SqlCommandText, params System.Data.IDataParameter[] Parameters)
        {
            this.ClearError();

            using (DataTable dataTable = new DataTable())
            {
                if (TableName != null)
                    dataTable.TableName = TableName;

                using (SqlDataAdapter daTableBuilder = new SqlDataAdapter())
                {
                    daTableBuilder.SelectCommand = (SqlCommand)this.BuildCommand(CommandType.Text, SqlCommandText, Parameters);

                    daTableBuilder.SelectCommand.CommandTimeout = 0;

                    try
                    {
                        daTableBuilder.Fill(dataTable);
                    }
                    catch (Exception ex)
                    {
                        this.SetError(ex);

                        return null;
                    }
                }

                return dataTable;
            }
        }

        public DataSet GetDataSetFromProcedure(string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        {
            this.ClearError();

            using (DataSet dataSet = new DataSet())
            {
                using (SqlDataAdapter daDsBuilder = new SqlDataAdapter())
                {
                    daDsBuilder.SelectCommand = (SqlCommand)this.BuildCommand(CommandType.StoredProcedure, StoredProcedureName, Parameters);

                    daDsBuilder.SelectCommand.CommandTimeout = 0;

                    try
                    {
                        daDsBuilder.Fill(dataSet);
                    }
                    catch (Exception ex)
                    {
                        this.SetError(ex);

                        return null;
                    }
                }

                return dataSet;
            }
        }

        public DataSet GetDataSetFromSqlCommandText(string SqlCommandText, params System.Data.IDataParameter[] Parameters)
        {
            this.ClearError();

            using (DataSet dataSet = new DataSet())
            {
                using (SqlDataAdapter daDsBuilder = new SqlDataAdapter())
                {
                    daDsBuilder.SelectCommand = (SqlCommand)this.BuildCommand(CommandType.Text, SqlCommandText, Parameters);

                    daDsBuilder.SelectCommand.CommandTimeout = 0;

                    try
                    {
                        daDsBuilder.Fill(dataSet);
                    }
                    catch (Exception ex)
                    {
                        this.SetError(ex);

                        return null;
                    }
                }

                return dataSet;
            }
        }

        public DataRow GetDataRowFromProcedure(string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        {
            this.ClearError();

            using (DataTable dataTable = new DataTable())
            {
                using (SqlDataAdapter daDrBuilder = new SqlDataAdapter())
                {
                    daDrBuilder.SelectCommand = (SqlCommand)BuildCommand(CommandType.StoredProcedure, StoredProcedureName, Parameters);

                    daDrBuilder.SelectCommand.CommandTimeout = 0;

                    try
                    {
                        daDrBuilder.Fill(dataTable);
                    }
                    catch (Exception ex)
                    {
                        this.SetError(ex);

                        return null;
                    }
                }

                if (dataTable.Rows.Count > 0)
                    return dataTable.Rows[0];
                else
                    return null;
            }
        }

        public DataRow GetDataRowFromSqlCommandText(string SqlCommandText, params System.Data.IDataParameter[] Parameters)
        {
            this.ClearError();

            using (DataTable dataTable = new DataTable())
            {
                using (SqlDataAdapter daDrBuilder = new SqlDataAdapter())
                {
                    daDrBuilder.SelectCommand = (SqlCommand)BuildCommand(CommandType.Text, SqlCommandText, Parameters);

                    daDrBuilder.SelectCommand.CommandTimeout = 0;

                    try
                    {
                        daDrBuilder.Fill(dataTable);
                    }
                    catch (Exception ex)
                    {
                        this.SetError(ex);

                        return null;
                    }
                }

                if (dataTable.Rows.Count > 0)
                    return dataTable.Rows[0];
                else
                    return null;
            }
        }

        ///<summary>
        /// After Using IDataReader Object it's important to explicitly close it, or end up with open connections.
        /// </summary>
        /// <param name="SqlCommandText"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public SqlDataReader GetSqlDataReaderFromCommandText(string SqlCommandText, params System.Data.IDataParameter[] Parameters)
        {
            return (SqlDataReader)GetDataReaderFromCommandText(SqlCommandText, Parameters);
        }

        /// <summary>
        /// After Using IDataReader Object it's important to explicitly close it, or end up with open connections.
        /// </summary>
        /// <param name="SqlCommandText"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public IDataReader GetDataReaderFromCommandText(string SqlCommandText, params System.Data.IDataParameter[] Parameters)
        {
            this.ClearError();

            SqlDataReader result = null;

            using (SqlCommand command = (SqlCommand)BuildCommand(CommandType.Text, SqlCommandText, Parameters))
            {
                command.CommandTimeout = 0;

                try
                {
                    this._Connection.Open();

                    result = command.ExecuteReader(CommandBehavior.CloseConnection);

                    //this._Connection.Close();
                }
                catch (Exception ex)
                {
                    this.SetError(ex);
                }
            }

            return (IDataReader)result;
        }

        ///<summary>
        /// After Using IDataReader Object it's important to explicitly close it, or end up with open connections.
        /// </summary>
        /// <param name="SqlCommandText"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public SqlDataReader GetSqlDataReaderFromProcedure(string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        {
            return (SqlDataReader)GetDataReaderFromProcedure(StoredProcedureName, Parameters);
        }

        ///<summary>
        /// After Using IDataReader Object it's important to explicitly close it, or end up with open connections.
        /// </summary>
        /// <param name="SqlCommandText"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public IDataReader GetDataReaderFromProcedure(string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        {
            this.ClearError();

            SqlDataReader result = null;

            using (SqlCommand command = (SqlCommand)BuildCommand(CommandType.StoredProcedure, StoredProcedureName, Parameters))
            {
                command.CommandTimeout = 0;

                try
                {
                    this._Connection.Open();

                    result = command.ExecuteReader(CommandBehavior.CloseConnection);

                    //this._Connection.Close();
                }
                catch (Exception ex)
                {
                    this.SetError(ex);
                }
            }

            return (IDataReader)result;
        }

        public SqlCommand BuildSqlCommand(CommandType CommandType, string CommandText, params System.Data.IDataParameter[] Parameters)
        {
            return (SqlCommand)BuildCommand(CommandType, CommandText, Parameters);
        }

        public IDbCommand BuildCommand(System.Data.CommandType CommandType, string CommandText, params System.Data.IDataParameter[] Parameters)
        {
            this.ClearError();

            using (SqlCommand command = new SqlCommand(CommandText, this._Connection))
            {
                command.CommandType = CommandType;

                if (Parameters != null)
                {
                    try
                    {
                        command.Parameters.Clear();
                        foreach (SqlParameter parameter in Parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    catch (Exception ex)
                    {
                        this.SetError(ex);
                    }
                }
                return (IDbCommand)command;
            }
        }

        public void ClearError()
        {
            _HasError = false;

            _Exception = null;
        }

        public SqlConnection SqlConnection
        {
            get
            {
                return (SqlConnection)Connection;
            }
        }

        public IDbConnection Connection
        {
            get
            {
                return this._Connection;
            }
        }

        public string ConnectionString
        {
            get
            {
                return this._ConnectionString;
            }
        }

        public bool HandleError
        {
            get
            {
                return _HandleError;
            }
            set
            {
                _HandleError = value;

                this.ClearError();
            }
        }

        public bool HasError
        {
            get
            {
                return _HasError;
            }
        }

        public Exception ErrorException
        {
            get
            {
                return _Exception;
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this.Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && (_Connection != null))
            {
                _Connection.Dispose();
            }
        }

        #endregion

        private void SetError(Exception ex)
        {
            this._HasError = true;

            this._Exception = ex;

            if (this._Connection.State == ConnectionState.Open)

                try { this._Connection.Close(); }

                catch { }

            if (!_HandleError)

                throw ex;
        }
    }
   
    
    public class MySqlDbAccess : IDbAccess
    {
        private bool _HasError = false;

        private bool _HandleError = true;

        private Exception _Exception = null;

        private string _ConnectionString;

        private MySqlConnection _Connection;




        #region IDbAccess Members
        public MySqlDbAccess()
        {
            Init(true, null, -1);
        }

         public MySqlDbAccess(bool HandleError)
        {
            Init(HandleError, null, -1);
        }

         public MySqlDbAccess(string ConnectionParameter, ConnectionStringSourceType Source)
        {
            Init(true, ConnectionParameter, (int)Source);
        }
        private void Init(bool handleError, string connectionParameter, int connectionStringSource)
        {
            switch (connectionStringSource)
            {
                case (int)(ConnectionStringSourceType.ConnectionString):

                    this._ConnectionString = connectionParameter;

                    break;

                case (int)(ConnectionStringSourceType.AppConfig):

                    this._ConnectionString =  ConfigurationManager.ConnectionStrings[connectionParameter].ConnectionString;

                    break;

                case (int)(ConnectionStringSourceType.WebConfig):

                    this._ConnectionString = WebConfigurationManager.ConnectionStrings[connectionParameter].ConnectionString;

                    break;
                case (int)(ConnectionStringSourceType.MySetting):

                    this._ConnectionString = connectionParameter;

                    break;
                default:

                    try
                    {
                        this._ConnectionString = ConfigurationManager.ConnectionStrings["SqlConStr"].ConnectionString;
                    }
                    catch
                    {
                        try
                        {
                            this._ConnectionString = WebConfigurationManager.ConnectionStrings["SqlConStr"].ConnectionString;
                        }
                        catch
                        {
                            throw new Exception("ConStr parameter not found in App.config or Web.config files.");
                        }
                    }
                    break;
            } 

            this._Connection = new MySqlConnection(this._ConnectionString);

            this._HandleError = handleError;
        }


        public int ExecuteProcedure(string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        {
            this.ClearError();

            int result = int.MinValue;

            using (MySqlCommand command = (MySqlCommand)BuildCommand(CommandType.StoredProcedure, StoredProcedureName, Parameters))
            {
                command.CommandTimeout = 0;

                try
                {
                    this._Connection.Open();

                    result = command.ExecuteNonQuery ();

                    this._Connection.Close();
                }
                catch (Exception ex)
                {
                    this.SetError(ex);
                }
            }

            return result;
        }

        public int ExecuteSqlCommandText(string SqlCommandText, params System.Data.IDataParameter[] Parameters)
        {
            this.ClearError();

            int result = int.MinValue;

            using (MySqlCommand command = (MySqlCommand)BuildCommand(CommandType.Text, SqlCommandText, Parameters))
            {
                command.CommandTimeout = 0;

                try
                {
                    this._Connection.Open();

                    result = command.ExecuteNonQuery();

                    this._Connection.Close();
                }
                catch (Exception ex)
                {
                    this.SetError(ex);
                }
            }

            return result;
        }

        /// <summary>
        /// not supported in Mysql, use other functions please
        /// </summary>
        /// <param name="SqlCommandText"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>

        public object GetScalarFromSqlCommandText(string SqlCommandText, params System.Data.IDataParameter[] Parameters)
        {
            return ExecuteSqlCommandText(SqlCommandText, Parameters);
        }

        /// <summary>
        /// not supported in Mysql, use other functions please
        /// </summary>
        /// <param name="StoredProcedureName"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public object GetScalarFromProcedure(string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        {
            this.ClearError();

            object result = null;

            using (MySqlCommand command = (MySqlCommand)BuildCommand(CommandType.StoredProcedure, StoredProcedureName, Parameters))
            {
                command.CommandTimeout = 0;

                try
                {
                    this._Connection.Open();

                    result = command.ExecuteScalar();

                    this._Connection.Close();
                }
                catch (Exception ex)
                {
                    this.SetError(ex);
                }
            }

            return result;
        }

        public DataTable GetDataTableFromProcedure(string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        {
            return GetDataTableFromProcedure(null, StoredProcedureName, Parameters);
        }

        public DataTable GetDataTableFromProcedure(string TableName, string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        {
            this.ClearError();

            using (DataTable dataTable = new DataTable())
            {
                if (TableName != null)
                    dataTable.TableName = TableName;

                using (MySqlDataAdapter daTableBuilder = new MySqlDataAdapter())
                {
                    daTableBuilder.SelectCommand = (MySqlCommand)this.BuildCommand(CommandType.StoredProcedure, StoredProcedureName, Parameters);

                    daTableBuilder.SelectCommand.CommandTimeout = 0;

                    try
                    {
                        daTableBuilder.Fill(dataTable);
                    }
                    catch (Exception ex)
                    {
                        this.SetError(ex);

                        return null;
                    }
                }

                return dataTable;
            }
        }

        public DataTable GetDataTableFromSqlCommandText(string SqlCommandText, params System.Data.IDataParameter[] Parameters)
        {
            return GetDataTableFromSqlCommandText(null, SqlCommandText, Parameters);
        }

        public DataTable GetDataTableFromSqlCommandText(string TableName, string SqlCommandText, params System.Data.IDataParameter[] Parameters)
        {
            this.ClearError();

            using (DataTable dataTable = new DataTable())
            {
                if (TableName != null)
                    dataTable.TableName = TableName;

                using (MySqlDataAdapter daTableBuilder = new MySqlDataAdapter())
                {
                    daTableBuilder.SelectCommand = (MySqlCommand)this.BuildCommand(CommandType.Text, SqlCommandText, Parameters);

                    daTableBuilder.SelectCommand.CommandTimeout = 0;

                    try
                    {
                        daTableBuilder.Fill(dataTable);
                    }
                    catch (Exception ex)
                    {
                        this.SetError(ex);

                        return null;
                    }
                }

                return dataTable;
            }
        }

        public DataSet GetDataSetFromProcedure(string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        {
            this.ClearError();

            using (DataSet dataSet = new DataSet())
            {
                using (MySqlDataAdapter daDsBuilder = new MySqlDataAdapter())
                {
                    daDsBuilder.SelectCommand = (MySqlCommand)this.BuildCommand(CommandType.StoredProcedure, StoredProcedureName, Parameters);

                    daDsBuilder.SelectCommand.CommandTimeout = 0;

                    try
                    {
                        daDsBuilder.Fill(dataSet);
                    }
                    catch (Exception ex)
                    {
                        this.SetError(ex);

                        return null;
                    }
                }

                return dataSet;
            }
        }

        public DataSet GetDataSetFromSqlCommandText(string SqlCommandText, params System.Data.IDataParameter[] Parameters)
        {
            this.ClearError();

            using (DataSet dataSet = new DataSet())
            {
                using (MySqlDataAdapter daDsBuilder = new MySqlDataAdapter())
                {
                    daDsBuilder.SelectCommand = (MySqlCommand)this.BuildCommand(CommandType.Text, SqlCommandText, Parameters);

                    daDsBuilder.SelectCommand.CommandTimeout = 0;

                    try
                    {
                        daDsBuilder.Fill(dataSet);
                    }
                    catch (Exception ex)
                    {
                        this.SetError(ex);

                        return null;
                    }
                }

                return dataSet;
            }
        }

        public DataRow GetDataRowFromProcedure(string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        {
            this.ClearError();

            using (DataTable dataTable = new DataTable())
            {
                using (MySqlDataAdapter daDrBuilder = new MySqlDataAdapter())
                {
                    daDrBuilder.SelectCommand = (MySqlCommand)BuildCommand(CommandType.StoredProcedure, StoredProcedureName, Parameters);

                    daDrBuilder.SelectCommand.CommandTimeout = 0;

                    try
                    {
                        daDrBuilder.Fill(dataTable);
                    }
                    catch (Exception ex)
                    {
                        this.SetError(ex);

                        return null;
                    }
                }

                if (dataTable.Rows.Count > 0)
                    return dataTable.Rows[0];
                else
                    return null;
            }
        }

        public DataRow GetDataRowFromSqlCommandText(string SqlCommandText, params System.Data.IDataParameter[] Parameters)
        {
            this.ClearError();

            using (DataTable dataTable = new DataTable())
            {
                using (MySqlDataAdapter daDrBuilder = new MySqlDataAdapter())
                {
                    daDrBuilder.SelectCommand = (MySqlCommand)BuildCommand(CommandType.Text, SqlCommandText, Parameters);

                    daDrBuilder.SelectCommand.CommandTimeout = 0;

                    try
                    {
                        daDrBuilder.Fill(dataTable);
                    }
                    catch (Exception ex)
                    {
                        this.SetError(ex);

                        return null;
                    }
                }

                if (dataTable.Rows.Count > 0)
                    return dataTable.Rows[0];
                else
                    return null;
            }
        }

        ///<summary>
        /// After Using IDataReader Object it's important to explicitly close it, or end up with open connections.
        /// </summary>
        /// <param name="SqlCommandText"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public MySqlDataReader GetSqlDataReaderFromCommandText(string SqlCommandText, params System.Data.IDataParameter[] Parameters)
        {
            return (MySqlDataReader)GetDataReaderFromCommandText(SqlCommandText, Parameters);
        }

        /// <summary>
        /// After Using IDataReader Object it's important to explicitly close it, or end up with open connections.
        /// </summary>
        /// <param name="SqlCommandText"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public IDataReader GetDataReaderFromCommandText(string SqlCommandText, params System.Data.IDataParameter[] Parameters)
        {
            this.ClearError();

            MySqlDataReader result = null;

            using (MySqlCommand command = (MySqlCommand)BuildCommand(CommandType.Text, SqlCommandText, Parameters))
            {
                command.CommandTimeout = 0;

                try
                {
                    this._Connection.Open();

                    result = command.ExecuteReader(CommandBehavior.CloseConnection);

                    //this._Connection.Close();
                }
                catch (Exception ex)
                {
                    this.SetError(ex);
                }
            }

            return (IDataReader)result;
        }

        ///<summary>
        /// After Using IDataReader Object it's important to explicitly close it, or end up with open connections.
        /// </summary>
        /// <param name="SqlCommandText"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public MySqlDataReader GetSqlDataReaderFromProcedure(string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        {
            return (MySqlDataReader)GetDataReaderFromProcedure(StoredProcedureName, Parameters);
        }

        ///<summary>
        /// After Using IDataReader Object it's important to explicitly close it, or end up with open connections.
        /// </summary>
        /// <param name="SqlCommandText"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public IDataReader GetDataReaderFromProcedure(string StoredProcedureName, params System.Data.IDataParameter[] Parameters)
        {
            this.ClearError();

            MySqlDataReader result = null;

            using (MySqlCommand command = (MySqlCommand)BuildCommand(CommandType.StoredProcedure, StoredProcedureName, Parameters))
            {
                command.CommandTimeout = 0;

                try
                {
                    this._Connection.Open();

                    result = command.ExecuteReader(CommandBehavior.CloseConnection);

                    //this._Connection.Close();
                }
                catch (Exception ex)
                {
                    this.SetError(ex);
                }
            }

            return (IDataReader)result;
        }

        public MySqlCommand BuildMySqlCommand(CommandType CommandType, string CommandText, params System.Data.IDataParameter[] Parameters)
        {
            return (MySqlCommand)BuildCommand(CommandType, CommandText, Parameters);
        }

        public IDbCommand BuildCommand(System.Data.CommandType CommandType, string CommandText, params System.Data.IDataParameter[] Parameters)
        {
            this.ClearError();

            using (MySqlCommand command = new MySqlCommand(CommandText, this._Connection))
            {
                command.CommandType = CommandType;

                if (Parameters != null)
                {
                    try
                    {
                        command.Parameters.Clear();
                        foreach (MySqlParameter  parameter in Parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    catch (Exception ex)
                    {
                        this.SetError(ex);
                    }
                }
                return (IDbCommand)command;
            }
        }

        public void ClearError()
        {
            _HasError = false;

            _Exception = null;
        }

        public MySqlConnection SqlConnection
        {
            get
            {
                return (MySqlConnection)Connection;
            }
        }

        public IDbConnection Connection
        {
            get
            {
                return this._Connection;
            }
        }

        public string ConnectionString
        {
            get
            {
                return this._ConnectionString;
            }
        }

        public bool HandleError
        {
            get
            {
                return _HandleError;
            }
            set
            {
                _HandleError = value;

                this.ClearError();
            }
        }

        public bool HasError
        {
            get
            {
                return _HasError;
            }
        }

        public Exception ErrorException
        {
            get
            {
                return _Exception;
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this.Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && (_Connection != null))
            {
                _Connection.Dispose();
            }
        }

        #endregion

        private void SetError(Exception ex)
        {
            this._HasError = true;

            this._Exception = ex;

            if (this._Connection.State == ConnectionState.Open)

                try { this._Connection.Close(); }

                catch { }

            if (!_HandleError)

                throw ex;
        }
    }

}
