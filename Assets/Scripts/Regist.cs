using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine.Networking;



public class Regist : MonoBehaviour
{
    public TMP_Text NickName;
    public TMP_Text Kind;
    public TMP_Text WaterDate;
    public TMP_Text Temp;
    public TMP_Text Humid;
    public TMP_Text Date;
    public Button RegistButton;
    public Button SearchButton;
    public TMP_Text ListText;
    private string conn, sqlQuery;
    IDbConnection dbconn;
    IDbCommand dbcmd;
    private IDataReader reader;
    string DBName = "PlantSitter.db";

    private void Awake()
    {
        StartCoroutine(DBCreate());
    }
    private void Start()
    {
        DBConnectionCheck();

    }
    IEnumerator DBCreate()
    {
        string filepath = string.Empty;
        if (Application.platform == RuntimePlatform.Android)
        {
            filepath = Application.persistentDataPath + "/PlantSitter.db";
            if (!File.Exists(filepath))
            {
                UnityWebRequest unityWebRequest = UnityWebRequest.Get("jar:file://" + Application.dataPath + "!/assets/" + DBName);
                unityWebRequest.downloadedBytes.ToString();
                yield return unityWebRequest.SendWebRequest().isDone;
                File.WriteAllBytes(filepath, unityWebRequest.downloadHandler.data);
            }
        }
        else
        {
            filepath = Application.dataPath + "/PlantSitter.db";
            if (!File.Exists(filepath))
            {
                File.Copy(Application.streamingAssetsPath + "/PlantSitter.db", filepath);
            }
        }
        Debug.Log("DB CREATE Ok");
    }
    public string GetDBFilePath()
    {
        string str = string.Empty;
        if (Application.platform == RuntimePlatform.Android)
        {
            str = "URI=file:" + Application.persistentDataPath + "/PlantSitter.db";
        }
        else
        {
            str = "URI=file:" + Application.dataPath + "/PlantSitter.db";
        }
        return str;
    }
    public void DBConnectionCheck()
    {
        try
        {
            IDbConnection dbConnection = new SqliteConnection(GetDBFilePath());
            dbConnection.Open();

            if (dbConnection.State == ConnectionState.Open)
            {
                Debug.Log("DB Conn: OK");
            }
            else
            {
                Debug.Log("DB Conn: Fail");
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    private void DBInsert(string query)
    {
        IDbConnection dbConnection = new SqliteConnection(GetDBFilePath());
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = query;
        dbCommand.ExecuteNonQuery();
        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();
        dbConnection = null;
    }
    public void Regist_Button()
    {
        DBInsert("Insert into Myplant values('" + NickName.text + "','" + Kind.text + "','" + WaterDate.text + "','" + Temp.text + "','" + Humid.text + "','" + Date.text + "')");
    }
    public void DataBaseRead(string query)
    {
        IDbConnection dbConnection = new SqliteConnection(GetDBFilePath());
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = query;
        IDataReader dataReader = dbCommand.ExecuteReader();
        while (dataReader.Read())
        {
            ListText.text += dataReader.GetString(0) + "," + dataReader.GetString(1) + "," + dataReader.GetString(2) + "," + dataReader.GetString(3) + "," + dataReader.GetString(4) + "," + dataReader.GetString(5) + "\n";
            Debug.Log(dataReader.GetString(0) + "," + dataReader.GetString(1) + "," + dataReader.GetString(2) + "," + dataReader.GetString(3) + "," + dataReader.GetString(4) + "," + dataReader.GetString(5));
        }
        dataReader.Dispose();
        dataReader = null;
        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();
        dbConnection = null;
    }
    public void Search_Button()
    {
        DataBaseRead("Select * From Myplant");
    }

  
}