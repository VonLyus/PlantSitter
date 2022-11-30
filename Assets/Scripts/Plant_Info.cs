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
using System.Text.RegularExpressions;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;




public class Plant_Info : MonoBehaviour
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



        GameObject mask_Image;
        GameObject real_Image;
        Image plants_image;

        

        mask_Image = transform.GetChild(0).gameObject;
        real_Image = mask_Image.transform.GetChild(0).gameObject;

        plants_image = real_Image.GetComponent<Image>();
        plants_image.sprite = Resources.Load(plantnum, typeof(Sprite)) as Sprite;

        IDbCommand InfoPlantCommand = dbConnection.CreateCommand();
        InfoPlantCommand.CommandText = "SELECT nickname, suitableHum, suitableTemp, waterCycle FROM Infoplant WHERE ImageNo = '" + plantnum + "'";
        IDataReader InfoPlantReader = InfoPlantCommand.ExecuteReader();

        string nickname = InfoPlantReader[0].ToString();

        byte[] byteSuitableHum = (byte[])InfoPlantReader[1];
        byte[] byteSuitableTemp = (byte[])InfoPlantReader[2];
        string suitableHum = Encoding.Default.GetString(byteSuitableHum);
        string suitableTemp = Encoding.Default.GetString(byteSuitableTemp);
        string waterCycle = InfoPlantReader[3].ToString();
        int suitableHum_min = Convert.ToInt32(suitableHum.Substring(0, 2));
        int suitableHum_max = Convert.ToInt32(suitableHum.Substring(3, 2));
        int suitableTemp_min = Convert.ToInt32(suitableTemp.Substring(0, 2));
        int suitableTemp_max = Convert.ToInt32(suitableTemp.Substring(3, 2));
        string strwaterCycle = Regex.Replace(waterCycle, @"\D", "");
        int intwaterCycle = int.Parse(strwaterCycle);
        Debug.Log(intwaterCycle);

        IDbCommand MyPlantCommand = dbConnection.CreateCommand();
        MyPlantCommand.CommandText = "SELECT recentWater, indoorTemp, indoorHum, startDate, location FROM Myplant WHERE nickname = '" + nickname + "'";
        IDataReader MyPlantReader = MyPlantCommand.ExecuteReader();

        string strRecentWater = MyPlantReader[0].ToString();
        DateTime recentwater = new DateTime(Convert.ToInt32(strRecentWater.Substring(0, 4)), Convert.ToInt32(strRecentWater.Substring(4, 2)), Convert.ToInt32(strRecentWater.Substring(6, 2)), 0, 0, 0);
        string strindoorTemp = MyPlantReader[1].ToString();
        int indoorTemp = Convert.ToInt32(strindoorTemp);
        string strindoorHum = MyPlantReader[2].ToString();
        int indoorHum = Convert.ToInt32(strindoorHum);
        string strStartDate = MyPlantReader[3].ToString();
        string location = MyPlantReader[4].ToString();

        DateTime startDate = new DateTime(Convert.ToInt32(strStartDate.Substring(0, 4)), Convert.ToInt32(strStartDate.Substring(4, 2)), Convert.ToInt32(strStartDate.Substring(6, 2)), 0, 0, 0);
        DateTime now = DateTime.Now;
        DateTime nextWater = recentwater.AddDays(intwaterCycle);

        TimeSpan diff = now - startDate;

        while (true)
        {
            if (DateTime.Compare(now, nextWater)<0) { break; }
            nextWater = nextWater.AddDays(intwaterCycle);
            Debug.Log(nextWater);
        }

        TimeSpan water_diff = nextWater - now;

        transform.GetChild(1).gameObject.GetComponent<Text>().text = nickname;
        transform.GetChild(2).gameObject.GetComponent<Text>().text = diff.Days + "days";
        transform.GetChild(3).gameObject.GetComponent<Text>().text = strindoorHum + "%";
        transform.GetChild(4).gameObject.GetComponent<Text>().text = strindoorTemp + "°C";
        transform.GetChild(5).gameObject.GetComponent<Text>().text = water_diff.Days + "days";
        transform.GetChild(6).gameObject.GetComponent<Text>().text = location;

        if(location == "실내")
        {
            if(indoorHum < suitableHum_min && indoorTemp < suitableTemp_min)
            {
                transform.GetChild(7).gameObject.GetComponent<Text>().text = "실내 습도와 온도가 모두 낮습니다. \n"+ nickname+ "을(를) 위해 실내 환경을 조절해주세요";
            }
            else if(indoorHum < suitableHum_min &&  suitableTemp_min < indoorTemp && indoorTemp < suitableTemp_max)
            {
                transform.GetChild(7).gameObject.GetComponent<Text>().text = "실내 온도는 적당하나, 실내 습도가 낮습니다. \n" + nickname + "을(를) 위해 실내 환경을 조절해주세요";
            }
            else if (suitableHum_min < indoorHum && indoorHum < suitableHum_max && indoorTemp < suitableTemp_min)
            {
                transform.GetChild(7).gameObject.GetComponent<Text>().text = "실내 습도는 적당하나, 실내 온도가 낮습니다. \n" + nickname + "을(를) 위해 실내 환경을 조절해주세요";
            }
            else if (suitableHum_min < indoorHum && indoorHum < suitableHum_max && suitableTemp_min < indoorTemp && indoorTemp < suitableTemp_max)
            {
                transform.GetChild(7).gameObject.GetComponent<Text>().text = "실내 습도와 온도가 모두 적당합니다. \n앞으로도" + nickname + "을(를) 위해 실내 환경을 유지해주세요";
            }

        }
        else
        {

        }

        InfoPlantReader.Dispose();
        InfoPlantReader = null;
        MyPlantReader.Dispose();
        MyPlantReader = null;
        dbConnection.Close();
        dbConnection = null;
    }


}