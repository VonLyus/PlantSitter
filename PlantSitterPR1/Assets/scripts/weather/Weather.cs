using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class Weather : MonoBehaviour
{
   
    public TMP_Text weatherText;
    public WeatherData weatherInfo;
    public RawImage weatherIcon;
    public int cityInfo;

    public int Sigugun;
    public int Sido;

    public string cityInfoName;

    //스트링 배열로 값을 저장하여 index 값이 일치하면 값을 city에 저장하기
    // Start is called before the first frame update
    private void Awake()
    {//드롭박스에서 날씨를 얻어오기

    }

    void Start()
    {


    }

    //입력하면.. 변수는 city 값을 얻는거
    /*
    public void start_weather(int Sigugun)
    {
        Sido = GameObject.Find("locationSido").GetComponent<DropDownSido>().Judge;

        Sigugun = GameObject.Find("locationSigugun").GetComponent<DropDownSigugun>().GuJudge;

        Debug.Log(Sido);
        Debug.Log(Sigugun);
        CityJudge(Sido, Sigugun);
    }
    */

    public void CheckCityWeather(string city)
    {
        weatherText.gameObject.SetActive(false);
        weatherIcon.gameObject.SetActive(false);

        StartCoroutine(GetWeather(city));
    }
    public void CityJudge(int Sido, int Sigugun) {

        Debug.Log(Sido);
        Debug.Log(Sigugun);

        if (Sido == 1 && Sigugun == 0)
        {
            CheckCityWeather("Gangnam-gu");
        }
        if (Sido == 1 && Sigugun == 1)
        {
            CheckCityWeather("Gangdong-gu");
        }
        if (Sido == 1 && Sigugun == 2)
        {
            CheckCityWeather("Gangbuk-gu");
        }
        if (Sido == 1 && Sigugun == 3)
        {
            CheckCityWeather("Gangseo-gu");
        }
        if (Sido == 1 && Sigugun == 4)
        {
            CheckCityWeather("Gwanak-gu");
        }
        if (Sido == 1 && Sigugun == 5)
        {
            CheckCityWeather("Gwangjin-gu");
        }
        if (Sido == 1 && Sigugun == 6)
        {
            CheckCityWeather("Guro-gu");
        }
        if (Sido == 1 && Sigugun == 7)
        {
            CheckCityWeather("Geumcheon-gu");
        }
        if (Sido == 1 && Sigugun == 8)
        {
            CheckCityWeather("Nowon-gu");
        }
        if (Sido == 1 && Sigugun == 9)
        {
            CheckCityWeather("Dobong-gu");
        }
        if (Sido == 1 && Sigugun == 10)
        {
            CheckCityWeather("Dongdaemun-gu");
        }
        if (Sido == 1 && Sigugun == 11)
        {
            CheckCityWeather("Dongjak-gu");
        }
        if (Sido == 1 && Sigugun == 12)
        {
            CheckCityWeather("Mapo-gu");
        }
        if (Sido == 1 && Sigugun == 13)
        {
            CheckCityWeather("Seodaemun-gu");
        }
        if (Sido == 1 && Sigugun == 14)
        {
            CheckCityWeather("Seocho-gu");
        }
        if (Sido == 1 && Sigugun == 15)
        {
            CheckCityWeather("Seongdong-gu");
        }
        if (Sido == 1 && Sigugun == 16)
        {
            CheckCityWeather("Seongbuk-gu");
        }
        if (Sido == 1 && Sigugun == 17)
        {
            CheckCityWeather("Songpa-gu");
        }
        if (Sido == 1 && Sigugun == 18)
        {
            CheckCityWeather("Yangcheon-gu");
        }
        if (Sido == 1 && Sigugun == 19)
        {
            CheckCityWeather("Yeongdeungpo-gu");
        }
        if (Sido == 1 && Sigugun == 20)
        {
            CheckCityWeather("Yongsan-gu");
        }
        if (Sido == 1 && Sigugun == 21)
        {
            CheckCityWeather("Eunpyeong-gu");
        }
        if (Sido == 1 && Sigugun == 22)
        {
            CheckCityWeather("Jongno-gu");
        }
        if (Sido == 1 && Sigugun == 23)
        {
            CheckCityWeather("Jung-gu");
        }
        if (Sido == 1 && Sigugun == 24)
        {
            CheckCityWeather("Jungnang-gu");
        }

        //강원도
        if (Sido == 15 && Sigugun == 1)
        {
            CheckCityWeather("Gangneung-si");
        }
        if (Sido == 15 && Sigugun == 2)
        {
            CheckCityWeather("Goseong-gun");
        }
        if (Sido == 15 && Sigugun == 3)
        {
            CheckCityWeather("Donghae-si");
        }
        if (Sido == 15 && Sigugun == 4)
        {
            CheckCityWeather("Samcheok-si");
        }
        if (Sido == 15 && Sigugun == 5)
        {
            CheckCityWeather("Sokcho-si");
        }
        if (Sido == 15 && Sigugun == 6)
        {
            CheckCityWeather("Yanggu-gun");
        }
        if (Sido == 15 && Sigugun == 7)
        {
            CheckCityWeather("Yangyang-gun");
        }
        if (Sido == 15 && Sigugun == 8)
        {
            CheckCityWeather("Yeongwol-gun");
        }
        if (Sido == 15 && Sigugun == 9)
        {
            CheckCityWeather("Wonju-si");

        }
        if (Sido == 15 && Sigugun == 10)
        {
            CheckCityWeather("Inje-gun");

        }
        if (Sido == 15 && Sigugun == 11)
        {
            CheckCityWeather("Jeongseon-gun");

        }
        if (Sido == 15 && Sigugun == 12)
        {
            CheckCityWeather("Cheorwon-gun");

        }
        if (Sido == 15 && Sigugun == 13)
        {
            CheckCityWeather("Chuncheon-si");

        }
        if (Sido == 15 && Sigugun == 14)
        {
            CheckCityWeather("Taebaek-si");

        }
        if (Sido == 15 && Sigugun == 15)
        {
            CheckCityWeather("Pyeongchang-gun");

        }
        if (Sido == 15 && Sigugun == 16)
        {
            CheckCityWeather("Hongcheon-gun");

        }
        if (Sido == 15 && Sigugun == 17)
        {
            CheckCityWeather("Hwacheon-gun");

        }
        if (Sido == 15 && Sigugun == 18)
        {
            CheckCityWeather("Hoengseong-gun");

        }
    }

    // Update is called once per frame
    void Update()
    {/*
        Sido = GameObject.Find("locationSido").GetComponent<DropDownSido>().Judge;

        Sigugun = GameObject.Find("locationSigugun").GetComponent<DropDownSigugun>().GuJudge;

        Debug.Log(Sido);
        Debug.Log(Sigugun);
        CityJudge(Sido, Sigugun);
    */
    }

    //api 날씨 정보 얻어오기
    IEnumerator GetWeather(string city)
    {
        city = UnityWebRequest.EscapeURL(city);
        
        string url = "http://api.openweathermap.org/data/2.5/weather?units=metric&lang=kr";
        url += "&appid=1d0a98dea1684fc5fe329e496a7366ec";//APP_ID;
        url += "&q=" + city;// + city (state, country도 추가할수 있음);

        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        string json = www.downloadHandler.text;
        json = json.Replace("\"base\":", "\"basem\":");
        weatherInfo = JsonUtility.FromJson<WeatherData>(json);
        
        weatherText.gameObject.SetActive(true);
        weatherText.text = weatherInfo.name + "\n";
        weatherText.text += weatherInfo.main.temp.ToString("N1") + " ℃\n";
        weatherText.text += weatherInfo.main.humidity.ToString("N1") + "%\n";
        
        if (weatherInfo.weather.Length > 0)
        {   //날씨 정보
            weatherText.text += weatherInfo.weather[0].description;
            //날씨 아이콘
            StartCoroutine(GetWeatherIcon(weatherInfo.weather[0].icon));

        }

    }
    
    //------------------------------------------------------
    //아이콘 api 정보 얻어 오기
    IEnumerator GetWeatherIcon(string icon) 
    {
        string url = "http://openweathermap.org/img/wn/" + icon + "@2x.png";
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        weatherIcon.gameObject.SetActive(true);
        weatherIcon.texture = DownloadHandlerTexture.GetContent(www);

    }
}