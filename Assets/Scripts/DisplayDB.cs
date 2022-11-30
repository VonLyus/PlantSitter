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
using UnityEngine.SceneManagement;



public class DisplayDB : MonoBehaviour
{
    

    public GameObject prefab;
    public GameObject new_Plant;

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

        MyplantDisplay();


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

    
    

    public void MyplantDisplay()
    {
        IDbConnection dbConnection = new SqliteConnection(GetDBFilePath());
        dbConnection.Open();

        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT ImageNo, nickname FROM Infoplant WHERE Own = '소유'";
        IDataReader dataReader = dbCommand.ExecuteReader();

        GameObject text;
        GameObject button;
        GameObject button_Image;
        Image plants_image;

        int cnt = 0;
        while (dataReader.Read())
        {
            string ImageNo = dataReader[0].ToString();
            string nickname = dataReader[1].ToString();

            if (cnt % 2 == 0)
            {
                int k = cnt / 2;
                button = Instantiate(prefab, new Vector3(transform.position.x, transform.position.y - (800f * k), transform.position.z), Quaternion.identity, transform);
                button.name = ImageNo;
                text = button.transform.GetChild(1).gameObject;
                text.GetComponent<Text>().text = nickname;

                button_Image = button.transform.GetChild(0).gameObject;
                plants_image = button_Image.GetComponent<Image>();
                Debug.Log(plants_image.sprite);
                plants_image.sprite = Resources.Load(ImageNo, typeof(Sprite)) as Sprite;
            }
            else if (cnt % 2 == 1)
            {
                int k = cnt / 2;
                button = Instantiate(prefab, new Vector3(transform.position.x+ 500f, transform.position.y - (800f * k), transform.position.z), Quaternion.identity, transform);
                button.name = ImageNo;
                text = button.transform.GetChild(1).gameObject;
                text.GetComponent<Text>().text = nickname;

                button_Image = button.transform.GetChild(0).gameObject;
                plants_image = button_Image.GetComponent<Image>();
                plants_image.sprite = Resources.Load(ImageNo, typeof(Sprite)) as Sprite;
            }
            cnt++;

        }
        if (cnt % 2 == 0)   //새로 등록하는 칸 출력
        {
            int k = cnt / 2;
            Instantiate(new_Plant, new Vector3(transform.position.x, transform.position.y - (800f * k), transform.position.z), Quaternion.identity, transform);
            
        }
        else
        {
            int k = cnt / 2;
            Instantiate(new_Plant, new Vector3(transform.position.x + 500f, transform.position.y - (800f * k), transform.position.z), Quaternion.identity, transform);
        }



        dataReader.Dispose();
        dataReader = null;
        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();
        dbConnection = null;
    }


}