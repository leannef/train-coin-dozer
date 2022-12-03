using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using Unity.VisualScripting;
using System.Xml;

public class Sqlite : MonoBehaviour
{
    private IDbConnection dbConnection;
    private string dbPath => "URI=file:" + Application.persistentDataPath + "/PlayerData.sqlite";
    public void InitializeDatabase()
    {
        Debug.Log("Initialize Database");
        // Open a connection to the database.
        Debug.Log(Application.persistentDataPath);
        dbConnection = new SqliteConnection(dbPath);
        dbConnection.Open();
        CreateDatabase();
        IDbCommand dbCommandReadValues = dbConnection.CreateCommand();
        dbCommandReadValues.CommandText = "SELECT count(*) FROM PlayerProfile";
        int RowCount = Convert.ToInt32(dbCommandReadValues.ExecuteScalar());
        if (RowCount > 0)
        {
            Debug.Log("player id should always be 1. ");
            Player.id = RowCount;
            OnLoadPlayerData();
        }
        else
        {
            CreatePlayerEntry();
        }
        dbConnection.Close();

    }


    private void CreateDatabase()
    {
        // Create a table for player in the database if it does not exist yet.
        IDbCommand dbCommandCreateTable = dbConnection.CreateCommand();
        dbCommandCreateTable.CommandText = "CREATE TABLE IF NOT EXISTS PlayerProfile (id INTEGER PRIMARY KEY, goldCount INTEGER DEFAULT 50, lastVisit datatime )"; 
        dbCommandCreateTable.ExecuteNonQuery();

        dbCommandCreateTable.CommandText = "CREATE TABLE IF NOT EXISTS Souvenir(id INTEGER PRIMARY KEY, shortname VARCHAR NOT NULL,  quantity INTEGER, type INTEGER NOT NULL, country INTEGER, souvenirId INTEGER, FOREIGN KEY (souvenirId) REFERENCES PlayerProfile(id))";
        dbCommandCreateTable.ExecuteNonQuery();

        dbCommandCreateTable.CommandText = "CREATE TABLE IF NOT EXISTS Powerup(id INTEGER PRIMARY KEY, type INTEGER NOT NULL, quantity INTEGER NOT NULL, powerupId INTEGER, FOREIGN KEY (powerupId) REFERENCES PlayerProfile(id))";
        dbCommandCreateTable.ExecuteNonQuery();
    }

    public void OnLoadPlayerData()
    {
        IDbCommand dbCommandReadValues = dbConnection.CreateCommand();
        dbCommandReadValues.CommandText = "SELECT goldCount FROM PlayerProfile WHERE id =" + Player.id;
        Player.gold = Convert.ToInt32(dbCommandReadValues.ExecuteScalar());

        dbCommandReadValues.CommandText = "SELECT Powerup.type, Powerup.quantity FROM PlayerProfile, Powerup WHERE PlayerProfile.id = Powerup.powerupId";
        IDataReader dataReader = dbCommandReadValues.ExecuteReader();
        while (dataReader.Read())
        {
            PowerUp p = PowerUp.WithType(Convert.ToInt32(dataReader[0]));
            Player.powerupItems = new Dictionary<PowerUp, int>();
            Player.powerupItems.Add(p, Convert.ToInt32(dataReader[1]));
        }   
        dataReader.Close();

        dbCommandReadValues.CommandText = "SELECT Souvenir.shortname, Souvenir.quantity FROM PlayerProfile, Powerup WHERE PlayerProfile.id = Souvenir.souvenirId";
        dataReader = dbCommandReadValues.ExecuteReader();
        while (dataReader.Read())
        {
            Souvenir s = Souvenir.WithShortname(Convert.ToString(dataReader[0]));
            Player.souvenirtItems = new Dictionary<Souvenir, int>();
            Player.souvenirtItems.Add(s, Convert.ToInt32(dataReader[1]));
        }
        dataReader.Close();
    }

    private void CreatePlayerEntry()
    {
        IDbCommand dbCommandInsertValue = dbConnection.CreateCommand();
        dbCommandInsertValue.CommandText = "INSERT INTO PlayerProfile (goldCount) VALUES (50)"; 
        dbCommandInsertValue.ExecuteNonQuery();
        for (int i = 0; i < 6; i++)
        {
            Debug.Log("add powerup entry");
            dbCommandInsertValue.CommandText = "INSERT INTO Powerup (type, quantity, powerupId) VALUES (" + i + ",0 ,1)";
            dbCommandInsertValue.ExecuteNonQuery();
        }
    }

    public void OnUpdateCoin()
    {
        //TODO: updtae UI gold display
        IDbCommand dbCommandInsertValue = dbConnection.CreateCommand();
        dbCommandInsertValue.CommandText = "UPDATE PlayerProfile SET goldCount = " + Player.gold;
        dbCommandInsertValue.ExecuteNonQuery();
    }

    public void OnUpdatePowerUp()
    {
        IDbCommand dbCommandInsertValue = dbConnection.CreateCommand();
        foreach (KeyValuePair<PowerUp, int> entry in Player.powerupItems)
        {
            int type = (int)entry.Key.type;
            dbCommandInsertValue.CommandText = "UPDATE Powerup SET quantity = " + entry.Value + "WHERE type=" + type;
            dbCommandInsertValue.ExecuteNonQuery();
        }
    }

    public void OnUpdateSouvenir()
    {
        IDbCommand dbCommandInsertValue = dbConnection.CreateCommand();
        foreach (KeyValuePair<Souvenir, int> entry in Player.souvenirtItems)
        {
            string shortname = entry.Key.shortname;
            dbCommandInsertValue.CommandText = "UPDATE Powerup SET quantity = " + entry.Value + "WHERE shortname=" + shortname;
            dbCommandInsertValue.ExecuteNonQuery();
        }
    }

    public void OnUpdatePlayerData()
    {
        dbConnection = new SqliteConnection(dbPath);
        dbConnection.Open();
        OnUpdateCoin();
        OnUpdatePowerUp();
        OnUpdateSouvenir();
        dbConnection.Close();
    }

}


