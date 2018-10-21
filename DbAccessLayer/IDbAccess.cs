namespace DbAccessLayer
{
    using System;
    using System.Data;

    interface IDbAccess : IDisposable
    {
        //int ExecuteProcedure( string StoredProcedureName );

        //int ExecuteProcedure( string StoredProcedureName, IDataParameter[] Parameters );

        int ExecuteProcedure( string StoredProcedureName, params IDataParameter[] Parameters );

        //int ExecuteSqlCommandText( string SqlCommandText );

        //int ExecuteSqlCommandText( string SqlCommandText, IDataParameter[] Parameters );

        int ExecuteSqlCommandText( string SqlCommandText, params IDataParameter[] Parameters );

        //object GetScalarFromSqlCommandText( string SqlCommandText );

        //object GetScalarFromSqlCommandText( string SqlCommandText, IDataParameter[] Parameters );

        object GetScalarFromSqlCommandText( string SqlCommandText, params IDataParameter[] Parameters );

        //object GetScalarFromProcedure( string StoredProcedureName );

        //object GetScalarFromProcedure( string StoredProcedureName, IDataParameter[] Parameters );

        object GetScalarFromProcedure( string StoredProcedureName, params IDataParameter[] Parameters );

        //DataTable GetDataTableFromProcedure( string StoredProcedureName );

        //DataTable GetDataTableFromProcedure( string StoredProcedureName, IDataParameter[] Parameters );

        DataTable GetDataTableFromProcedure( string StoredProcedureName, params IDataParameter[] Parameters );

        //DataTable GetDataTableFromProcedure( string TableName, string StoredProcedureName, IDataParameter[] Parameters );

        DataTable GetDataTableFromProcedure( string TableName, string StoredProcedureName, params IDataParameter[] Parameters );

        //DataTable GetDataTableFromSqlCommandText( string SqlCommandText );

        //DataTable GetDataTableFromSqlCommandText( string SqlCommandText, IDataParameter[] Parameters );

        DataTable GetDataTableFromSqlCommandText( string SqlCommandText, params IDataParameter[] Parameters );

        //DataTable GetDataTableFromSqlCommandText( string TableName, string SqlCommandText, IDataParameter[] Parameters );

        DataTable GetDataTableFromSqlCommandText( string TableName, string SqlCommandText, params IDataParameter[] Parameters );

        //DataSet GetDataSetFromProcedure( string StoredProcedureName );

        //DataSet GetDataSetFromProcedure( string StoredProcedureName, IDataParameter[] Parameters );

        DataSet GetDataSetFromProcedure( string StoredProcedureName, params IDataParameter[] Parameters );

        //DataSet GetDataSetFromSqlCommandText( string SqlCommandText );

        //DataSet GetDataSetFromSqlCommandText( string SqlCommandText, IDataParameter[] Parameters );

        DataSet GetDataSetFromSqlCommandText( string SqlCommandText, params IDataParameter[] Parameters );

        //DataRow GetDataRowFromProcedure( string StoredProcedureName );

        //DataRow GetDataRowFromProcedure( string StoredProcedureName, IDataParameter[] Parameters );

        DataRow GetDataRowFromProcedure( string StoredProcedureName, params IDataParameter[] Parameters );

        //DataRow GetDataRowFromSqlCommandText( string SqlCommandText );

        //DataRow GetDataRowFromSqlCommandText( string SqlCommandText, IDataParameter[] Parameters );

        DataRow GetDataRowFromSqlCommandText( string SqlCommandText, params IDataParameter[] Parameters );

        IDataReader GetDataReaderFromCommandText( string StoredProcedureName, params IDataParameter[] Parameters );

        IDataReader GetDataReaderFromProcedure( string SqlCommandText, params IDataParameter[] Parameters );

        //SqlCommand BuildCommand( string CommandText, CommandType CommandType );

        //SqlCommand BuildCommand( CommandType CommandType, string CommandText, IDataParameter[] Parameters );

        IDbCommand BuildCommand( CommandType CommandType, string CommandText, params IDataParameter[] Parameters );

        void ClearError();

        IDbConnection Connection { get; }

        string ConnectionString { get; }

        bool HandleError { get; set; }

        bool HasError { get; }

        Exception ErrorException { get; }
    }
}