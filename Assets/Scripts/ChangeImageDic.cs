using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;



public class ChangeImageDic : MonoBehaviour
{


    public GameObject plantNumObject;
    public GameObject Content;

    private string conn, sqlQuery;
    IDbConnection dbconn;
    IDbCommand dbcmd;
    private IDataReader reader;
    string DBName = "PlantSitter.db";
    public string plantnum;



    private void Awake()
    {
        StartCoroutine(DBCreate());
        plantNumObject = GameObject.Find("plantNumObject");
        plantnum = plantNumObject.GetComponent<ChangeScenes>().plantNum;
        Debug.Log(plantnum);
        Destroy(plantNumObject);


    }
    private void Start()
    {
        DBConnectionCheck();
        DictionaryDisplay();
        

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




    public void DictionaryDisplay()
    {
        IDbConnection dbConnection = new SqliteConnection(GetDBFilePath());
        dbConnection.Open();



        GameObject text;
        GameObject mask_Image;
        GameObject real_Image;
        Image plants_image;

        IDbCommand selectedPlantCommand = dbConnection.CreateCommand();
        Debug.Log(plantnum);
        selectedPlantCommand.CommandText = "SELECT explain FROM Infoplant WHERE ImageNo = '" + plantnum + "'";
        IDataReader selectedPlantReader = selectedPlantCommand.ExecuteReader();
        
        while (selectedPlantReader.Read())
        {
            text = transform.GetChild(1).gameObject;
            byte[] vs = (byte[])selectedPlantReader[0];
            text.GetComponent<Text>().text = Encoding.Default.GetString(vs);
        }
        

        mask_Image = transform.GetChild(0).gameObject;
        real_Image = mask_Image.transform.GetChild(0).gameObject;

        plants_image = real_Image.GetComponent<Image>();
        plants_image.sprite = Resources.Load(plantnum, typeof(Sprite)) as Sprite;
        
       

        selectedPlantReader.Dispose();
        selectedPlantReader = null;
        dbConnection.Close();
        dbConnection = null;
    }


}