using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
using System.Text;

public class SqlDbCommand : SqlDbConnect
{
    private SqliteCommand _sqlComm;

    public SqlDbCommand(string dbpath) : base(dbpath)
    {
        _sqlComm = new SqliteCommand(_sqlConn);
    }

    public int CreateTable()
    {
        //List<string> col, List<string> colType

        /*
        if (col.Count != colType.Count)
        {
            Debug.LogError("col Count != col Type Count.");
            return;
        }
        StringBuilder strB = new StringBuilder();
        strB.Append("Create Table ");
        strB.Append(tableName);
        strB.Append(" (");

        */

        var sql = "Create table e010_1(id int, fname varchar(16), lname varchar(16), gender int)";
        _sqlComm.CommandText = sql;
        return _sqlComm.ExecuteNonQuery();  // 执行语句
    }

    public int DeleteTable(string tablename)
    {
        var sql = $"Drop table{tablename}";
        _sqlComm.CommandText = sql;
        return _sqlComm.ExecuteNonQuery();  // 执行语句
    }

}
