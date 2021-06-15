using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqlTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestDb();
    }

    void TestDb()
    {
        string dbPath = Application.dataPath + "/../Save/SaveData.db";
        //SqlDbConnect sqlDbConnect = new SqlDbConnect(dbPath);
        SqlDbCommand sql = new SqlDbCommand(dbPath);
        sql.CreateTable();
    }
}
