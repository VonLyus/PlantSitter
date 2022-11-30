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



public class DisplayDictionary : MonoBehaviour
{


    public GameObject prefab;
    public GameObject prefabbar;
    public GameObject Content;

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

        IDbCommand CountCommand = dbConnection.CreateCommand();
        CountCommand.CommandText = "SELECT COUNT(*) FROM Infoplant";
        int myCount = Convert.ToInt32(CountCommand.ExecuteScalar());

        int y = myCount / 4;
        if (myCount % 4 != 0) { y++; }
        RectTransform rect = Content.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(1080, y*400 + 200);


        GameObject button;
        GameObject text;
        GameObject button_Image;
        Image plants_image;

        IDbCommand ownedCommand = dbConnection.CreateCommand();
        ownedCommand.CommandText = "SELECT Kind, ImageNo FROM Infoplant WHERE Own = '소유'";
        IDataReader ownedReader = ownedCommand.ExecuteReader();

        int k = 0;
        int cnt = 0;

        while (ownedReader.Read())
        {
            string column1 = ownedReader[0].ToString();
            string column2 = ownedReader[1].ToString();
            string Image_Path = column2;

            if (cnt % 4 == 0)
            {
                k = cnt / 4;
                
                button = Instantiate(prefab, new Vector3(transform.position.x, transform.position.y - (400f * k), transform.position.z), Quaternion.identity, transform);
                button.name = column2;
                text = button.transform.GetChild(1).gameObject;
                text.GetComponent<Text>().text = column1;

                button_Image = button.transform.GetChild(0).gameObject;
                plants_image = button_Image.GetComponent<Image>();
                plants_image.sprite=Resources.Load(Image_Path, typeof(Sprite)) as Sprite;
            }
            else if (cnt % 4 != 0)
            {
                k = cnt / 4;
                button = Instantiate(prefab, new Vector3(transform.position.x + (250f * (cnt%4)), transform.position.y - (400f * k), transform.position.z), Quaternion.identity, transform);
                button.name = column2;
                text = button.transform.GetChild(1).gameObject;
                text.GetComponent<Text>().text = column1;

                button_Image = button.transform.GetChild(0).gameObject;
                plants_image = button_Image.GetComponent<Image>();
                plants_image.sprite = Resources.Load(Image_Path, typeof(Sprite)) as Sprite;
            }
            cnt++;

        }   //보유중 식물 출력

        GameObject new_bar;

        new_bar = Instantiate(prefabbar, new Vector3(transform.position.x+376, transform.position.y - (400f * k)-270, transform.position.z), Quaternion.identity, transform);
        text = new_bar.transform.GetChild(0).gameObject;
        text.GetComponent<Text>().text = "미보유종";


        IDbCommand unownedCommand = dbConnection.CreateCommand();
        unownedCommand.CommandText = "SELECT Kind, ImageNo FROM Infoplant WHERE Own = '미소유'";
        IDataReader unownedReader = unownedCommand.ExecuteReader();

        k = cnt / 4;
        cnt = 4 * k;
        while (unownedReader.Read())
        {
            string column1 = unownedReader[0].ToString();
            string column2 = unownedReader[1].ToString();
            string Image_Path = column2;
            if (cnt % 4 == 0)
            {
                k = cnt / 4;

                button = Instantiate(prefab, new Vector3(transform.position.x, transform.position.y - (400f * k)-510, transform.position.z), Quaternion.identity, transform);
                button.name = column2;
                text = button.transform.GetChild(1).gameObject;
                text.GetComponent<Text>().text = column1;

                button_Image = button.transform.GetChild(0).gameObject;
                plants_image = button_Image.GetComponent<Image>();
                plants_image.sprite = Resources.Load(Image_Path, typeof(Sprite)) as Sprite;
            }
            else if (cnt % 4 != 0)
            {
                k = cnt / 4;
                button = Instantiate(prefab, new Vector3(transform.position.x + (250f * (cnt % 4)), transform.position.y - (400f * k)-510, transform.position.z), Quaternion.identity, transform);
                button.name = column2;
                text = button.transform.GetChild(1).gameObject;
                text.GetComponent<Text>().text = column1;

                button_Image = button.transform.GetChild(0).gameObject;
                plants_image = button_Image.GetComponent<Image>();
                plants_image.sprite = Resources.Load(Image_Path, typeof(Sprite)) as Sprite;
            }
            cnt++;

        }   //미보유 식물 출력








        ownedReader.Dispose();
        unownedReader = null;
        ownedCommand.Dispose();
        unownedCommand = null;
        dbConnection.Close();
        dbConnection = null;
    }


}