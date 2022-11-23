using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class Sqlite : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        // Read all values from the table.
        IDbConnection dbConnection = CreateAndOpenDatabase();
        IDbCommand dbCommandReadValues = dbConnection.CreateCommand();

        dbCommandReadValues.CommandText = "SELECT count(id) FROM PlayerProfile";
        dbCommandReadValues.CommandType = CommandType.Text;
        int RowCount = 0;
        RowCount = Convert.ToInt32(dbCommandReadValues.ExecuteScalar());
        if (RowCount > 0)
        {
            dbCommandReadValues.CommandText = "SELECT * FROM PlayerProfile";
            IDataReader dataReader = dbCommandReadValues.ExecuteReader();
            while (dataReader.Read())
            {
                // The `player id` has index 0,  `goldCount` has the index 1.
                GameManager.Instance.gold = dataReader.GetInt32(1);
                Debug.Log(dataReader.GetInt32(1));
                //GamaManager.instance.lastVisit = dataReader.GetInt32(1);
            }
        }
        else
        {
            CreatePlayerEntry();
        }

        Debug.Log("Should always be 1 palyer row: " + RowCount);
        // Remember to always close the connection at the end.
        dbConnection.Close();
    }

    private IDbConnection CreateAndOpenDatabase()
    {
        // Open a connection to the database.
        string dbUri = "URI=file:" + Application.persistentDataPath + "/PlayerData.sqlite";
        Debug.Log(Application.persistentDataPath);
        IDbConnection dbConnection = new SqliteConnection(dbUri);
        dbConnection.Open();

        // Create a table for player in the database if it does not exist yet.
        IDbCommand dbCommandCreateTable = dbConnection.CreateCommand();
        dbCommandCreateTable.CommandText = "CREATE TABLE IF NOT EXISTS PlayerProfile (id INTEGER PRIMARY KEY, goldCount INTEGER(60) DEFAULT 50, lastVisit datatime )";
        dbCommandCreateTable.ExecuteReader();
        //var dbcmd : IDbCommand = dbconnection.CreateCommand();
        //dbcmd.CommandText = "INSERT INTO name (name)  VALUES ('50')";
        //dbcmd.ExecuteNonQuery();

        return dbConnection;
    }

    private void CreatePlayerEntry()
    {
        IDbConnection dbConnection = CreateAndOpenDatabase();
        IDbCommand dbCommandInsertValue = dbConnection.CreateCommand();
        dbCommandInsertValue.CommandText = "INSERT INTO PlayerProfile (id, goldCount) VALUES (0, " + 50 + ")"; 
        dbCommandInsertValue.ExecuteNonQuery();
    }

    public void OnUpdateCoin()
    {
        int gold = GameManager.Instance.gold - 1;
        //TODO: updtae UI gold display
        IDbConnection dbConnection = CreateAndOpenDatabase();
        IDbCommand dbCommandInsertValue = dbConnection.CreateCommand();
        dbCommandInsertValue.CommandText = "UPDATE PlayerProfile SET goldCount = " + gold;
        dbCommandInsertValue.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void OnUpdateSouvenir()
    {
        int gold = GameManager.Instance.gold - 1;
        //TODO: updtae UI gold display
        IDbConnection dbConnection = CreateAndOpenDatabase();
        IDbCommand dbCommandInsertValue = dbConnection.CreateCommand();
        dbCommandInsertValue.CommandText = "UPDATE PlayerProfile SET goldCount = " + gold;
        dbCommandInsertValue.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void OnUpdatePowerUp()
    {

    }

}


