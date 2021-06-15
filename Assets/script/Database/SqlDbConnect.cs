using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
using System.IO;

/// <summary>
/// sqlite 连接
/// </summary>
public class SqlDbConnect : MonoBehaviour
{
    protected SqliteConnection _sqlConn; // 保存相互连接的数据变量

    public SqlDbConnect(string dbpath) // 初始化
    {
        if (!File.Exists(dbpath))
        {
            CreateDbSqlite(dbpath);
        }
        ConnectDbSqlite(dbpath);
    }

    private bool CreateDbSqlite(string dbpath)
    {
        // 异常
        try
        {
            var dirName = new FileInfo(dbpath).Directory.FullName;
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            SqliteConnection.CreateFile(dbpath);
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError($"数据库创建异常：{e.Message}");
            return false;
        }
    }

    private bool ConnectDbSqlite(string dbpath)
    {
        try
        {
            _sqlConn = new SqliteConnection(new SqliteConnectionStringBuilder() { DataSource = dbpath }.ToString());
            _sqlConn.Open();
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError($"数据库连接异常：{e.Message}");
            return false;
        }
    }

    public void Dispose()
    {
        // 释放
        _sqlConn.Dispose();
    }

}
