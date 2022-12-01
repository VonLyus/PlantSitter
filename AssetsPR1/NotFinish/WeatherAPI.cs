using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;

public class WeatherAPI : MonoBehaviour
{
    string jsonResult;
    bool isOnLoading = true;

    void Start()
    {
        StartCoroutine(LoadData());

    }


    IEnumerator LoadData()
    {


        string GetDataUrl = "http://apis.data.go.kr/1360000/VilageFcstInfoService_2.0/getUltraSrtNcst?serviceKey=OBoAOq6UdAal3w2BX5rTWRjJ94s1ohjBIovamRMNWFWXtEAk%2BAljSaSFwUulwQ%2BaiCjzOjRsKhw%2FFGL5DaJA%2Fg%3D%3D";
        GetDataUrl += "&numOfRows=10";
        GetDataUrl += "&pageNo=1";
        GetDataUrl += "&base_date=20210628";
        GetDataUrl += "&base_time=0600";
        GetDataUrl += "&nx=55";
        GetDataUrl += "&ny=127";


        using (UnityWebRequest www = UnityWebRequest.Get(GetDataUrl))
        {
            //www.chunkedTransfer = false;
            yield return www.Send();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }

            else

            {
                if (www.isDone)
                {
                    isOnLoading = false;
                    jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);

                    Debug.Log(jsonResult);
                }
            }
        }
    }

}
