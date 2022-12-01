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

    // Start is called before the first frame update
    void Start()
    {

    }

    public void CheckCityWeather(string city)
    {
        weatherText.gameObject.SetActive(false);
        weatherIcon.gameObject.SetActive(false);

        StartCoroutine(GetWeather(city));
    }

    // Update is called once per frame
    void Update()
    {

    }

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
        {
            weatherText.text += weatherInfo.weather[0].description;
            StartCoroutine(GetWeatherIcon(weatherInfo.weather[0].icon));

        }

    }
    //------------------------------------------------------
    IEnumerator GetWeatherIcon(string icon) 
    {
        string url = "http://openweathermap.org/img/wn/" + icon + "@2x.png";
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        weatherIcon.gameObject.SetActive(true);
        weatherIcon.texture = DownloadHandlerTexture.GetContent(www);

    }
}