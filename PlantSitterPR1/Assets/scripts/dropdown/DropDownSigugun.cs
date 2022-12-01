using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DropDownSigugun : MonoBehaviour{


    //gameObject.SetActive(false);
    public string DROPDOWN_KEY = "DROPDOWN_KEY";
    public int TypeJudge;

    public int GuJudge;
    public int currentOptions;
    public GameObject _LocationController;
    public TMP_Dropdown secOptions;
    public Button button;

    //public GameObject APIManager;
    //public GameObject _DropDownSigugun;
    //public GameObject _DropDownSigugunButton;
    //public RawImage weatherIcon;
    //public TMP_Text weatherText;


    //리스트 생성
    public List<string> optionList = new List<string>();


    void Awake()
    {//처음 설정
        if (PlayerPrefs.HasKey(DROPDOWN_KEY) == false) currentOptions = 0;
        else currentOptions = PlayerPrefs.GetInt(DROPDOWN_KEY);
        
    }

    void Start()
    {

        secOptions = this.GetComponent<TMP_Dropdown>();

        secOptions.ClearOptions();

        TypeJudge = GameObject.Find("locationSido").GetComponent<DropDownSido>().Judge;

        //서울특별시
        if (TypeJudge == 1)
        {
            optionList.Add("Gangnam-gu");
            optionList.Add("Gangdong-gu");
            optionList.Add("Gangbuk-gu");
            optionList.Add("Gangseo-gu");
            optionList.Add("Gwanak-gu");
            optionList.Add("Gwangjin-gu");
            optionList.Add("Guro-gu");
            optionList.Add("Geumcheon-gu");
            optionList.Add("Nowon-gu");
            optionList.Add("Dobong-gu");
            optionList.Add("Dongdaemun-gu");
            optionList.Add("Dongjak-gu");
            optionList.Add("Mapo-gu");
            optionList.Add("Seodaemun-gu");
            optionList.Add("Seocho-gu");
            optionList.Add("Seongdong-gu");
            optionList.Add("Seongbuk-gu");
            optionList.Add("Songpa-gu");
            optionList.Add("Yangcheon-gu");
            optionList.Add("Yeongdeungpo-gu");
            optionList.Add("Yongsan-gu");
            optionList.Add("Eunpyeong-gu");
            optionList.Add("Jongno-gu");
            optionList.Add("Jung-gu");
            optionList.Add("Jungnang-gu");
        }

        if (TypeJudge == 2)
        {
            optionList.Add("Gangnam-gu");
            optionList.Add("Gangdong-gu");
            optionList.Add("Gangbuk-gu");
            optionList.Add("Gangseo-gu");
            optionList.Add("Gwanak-gu");
            optionList.Add("Gwangjin-gu");
            optionList.Add("Guro-gu");
            optionList.Add("Geumcheon-gu");
            optionList.Add("Nowon-gu");
            optionList.Add("Dobong-gu");
            optionList.Add("Dongdaemun-gu");
            optionList.Add("Dongjak-gu");
            optionList.Add("Mapo-gu");
            optionList.Add("Seodaemun-gu");
            optionList.Add("Seocho-gu");
            optionList.Add("Seongdong-gu");
            optionList.Add("Seongbuk-gu");
            optionList.Add("Songpa-gu");
            optionList.Add("Yangcheon-gu");
            optionList.Add("Yeongdeungpo-gu");
            optionList.Add("Yongsan-gu");
            optionList.Add("Eunpyeong-gu");
            optionList.Add("Jongno-gu");
            optionList.Add("Jung-gu");
            optionList.Add("Jungnang-gu");
        }

        if (TypeJudge == 3)
        {
            optionList.Add("Gangnam-gu");
            optionList.Add("Gangdong-gu");
            optionList.Add("Gangbuk-gu");
            optionList.Add("Gangseo-gu");
            optionList.Add("Gwanak-gu");
            optionList.Add("Gwangjin-gu");
            optionList.Add("Guro-gu");
            optionList.Add("Geumcheon-gu");
            optionList.Add("Nowon-gu");
            optionList.Add("Dobong-gu");
            optionList.Add("Dongdaemun-gu");
            optionList.Add("Dongjak-gu");
            optionList.Add("Mapo-gu");
            optionList.Add("Seodaemun-gu");
            optionList.Add("Seocho-gu");
            optionList.Add("Seongdong-gu");
            optionList.Add("Seongbuk-gu");
            optionList.Add("Songpa-gu");
            optionList.Add("Yangcheon-gu");
            optionList.Add("Yeongdeungpo-gu");
            optionList.Add("Yongsan-gu");
            optionList.Add("Eunpyeong-gu");
            optionList.Add("Jongno-gu");
            optionList.Add("Jung-gu");
            optionList.Add("Jungnang-gu");
        }

        if (TypeJudge == 4)
        {
            optionList.Add("Gangnam-gu");
            optionList.Add("Gangdong-gu");
            optionList.Add("Gangbuk-gu");
            optionList.Add("Gangseo-gu");
            optionList.Add("Gwanak-gu");
            optionList.Add("Gwangjin-gu");
            optionList.Add("Guro-gu");
            optionList.Add("Geumcheon-gu");
            optionList.Add("Nowon-gu");
            optionList.Add("Dobong-gu");
            optionList.Add("Dongdaemun-gu");
            optionList.Add("Dongjak-gu");
            optionList.Add("Mapo-gu");
            optionList.Add("Seodaemun-gu");
            optionList.Add("Seocho-gu");
            optionList.Add("Seongdong-gu");
            optionList.Add("Seongbuk-gu");
            optionList.Add("Songpa-gu");
            optionList.Add("Yangcheon-gu");
            optionList.Add("Yeongdeungpo-gu");
            optionList.Add("Yongsan-gu");
            optionList.Add("Eunpyeong-gu");
            optionList.Add("Jongno-gu");
            optionList.Add("Jung-gu");
            optionList.Add("Jungnang-gu");
        }

        if (TypeJudge == 5)
        {
            optionList.Add("Gangnam-gu");
            optionList.Add("Gangdong-gu");
            optionList.Add("Gangbuk-gu");
            optionList.Add("Gangseo-gu");
            optionList.Add("Gwanak-gu");
            optionList.Add("Gwangjin-gu");
            optionList.Add("Guro-gu");
            optionList.Add("Geumcheon-gu");
            optionList.Add("Nowon-gu");
            optionList.Add("Dobong-gu");
            optionList.Add("Dongdaemun-gu");
            optionList.Add("Dongjak-gu");
            optionList.Add("Mapo-gu");
            optionList.Add("Seodaemun-gu");
            optionList.Add("Seocho-gu");
            optionList.Add("Seongdong-gu");
            optionList.Add("Seongbuk-gu");
            optionList.Add("Songpa-gu");
            optionList.Add("Yangcheon-gu");
            optionList.Add("Yeongdeungpo-gu");
            optionList.Add("Yongsan-gu");
            optionList.Add("Eunpyeong-gu");
            optionList.Add("Jongno-gu");
            optionList.Add("Jung-gu");
            optionList.Add("Jungnang-gu");
        }

        if (TypeJudge == 6)
        {
            optionList.Add("Gangnam-gu");
            optionList.Add("Gangdong-gu");
            optionList.Add("Gangbuk-gu");
            optionList.Add("Gangseo-gu");
            optionList.Add("Gwanak-gu");
            optionList.Add("Gwangjin-gu");
            optionList.Add("Guro-gu");
            optionList.Add("Geumcheon-gu");
            optionList.Add("Nowon-gu");
            optionList.Add("Dobong-gu");
            optionList.Add("Dongdaemun-gu");
            optionList.Add("Dongjak-gu");
            optionList.Add("Mapo-gu");
            optionList.Add("Seodaemun-gu");
            optionList.Add("Seocho-gu");
            optionList.Add("Seongdong-gu");
            optionList.Add("Seongbuk-gu");
            optionList.Add("Songpa-gu");
            optionList.Add("Yangcheon-gu");
            optionList.Add("Yeongdeungpo-gu");
            optionList.Add("Yongsan-gu");
            optionList.Add("Eunpyeong-gu");
            optionList.Add("Jongno-gu");
            optionList.Add("Jung-gu");
            optionList.Add("Jungnang-gu");
        }

        if (TypeJudge == 7)
        {
            optionList.Add("Gangnam-gu");
            optionList.Add("Gangdong-gu");
            optionList.Add("Gangbuk-gu");
            optionList.Add("Gangseo-gu");
            optionList.Add("Gwanak-gu");
            optionList.Add("Gwangjin-gu");
            optionList.Add("Guro-gu");
            optionList.Add("Geumcheon-gu");
            optionList.Add("Nowon-gu");
            optionList.Add("Dobong-gu");
            optionList.Add("Dongdaemun-gu");
            optionList.Add("Dongjak-gu");
            optionList.Add("Mapo-gu");
            optionList.Add("Seodaemun-gu");
            optionList.Add("Seocho-gu");
            optionList.Add("Seongdong-gu");
            optionList.Add("Seongbuk-gu");
            optionList.Add("Songpa-gu");
            optionList.Add("Yangcheon-gu");
            optionList.Add("Yeongdeungpo-gu");
            optionList.Add("Yongsan-gu");
            optionList.Add("Eunpyeong-gu");
            optionList.Add("Jongno-gu");
            optionList.Add("Jung-gu");
            optionList.Add("Jungnang-gu");
        }

        if (TypeJudge == 8)
        {
            optionList.Add("Gangnam-gu");
            optionList.Add("Gangdong-gu");
            optionList.Add("Gangbuk-gu");
            optionList.Add("Gangseo-gu");
            optionList.Add("Gwanak-gu");
            optionList.Add("Gwangjin-gu");
            optionList.Add("Guro-gu");
            optionList.Add("Geumcheon-gu");
            optionList.Add("Nowon-gu");
            optionList.Add("Dobong-gu");
            optionList.Add("Dongdaemun-gu");
            optionList.Add("Dongjak-gu");
            optionList.Add("Mapo-gu");
            optionList.Add("Seodaemun-gu");
            optionList.Add("Seocho-gu");
            optionList.Add("Seongdong-gu");
            optionList.Add("Seongbuk-gu");
            optionList.Add("Songpa-gu");
            optionList.Add("Yangcheon-gu");
            optionList.Add("Yeongdeungpo-gu");
            optionList.Add("Yongsan-gu");
            optionList.Add("Eunpyeong-gu");
            optionList.Add("Jongno-gu");
            optionList.Add("Jung-gu");
            optionList.Add("Jungnang-gu");
        }

        if (TypeJudge == 9)
        {
            optionList.Add("Gangnam-gu");
            optionList.Add("Gangdong-gu");
            optionList.Add("Gangbuk-gu");
            optionList.Add("Gangseo-gu");
            optionList.Add("Gwanak-gu");
            optionList.Add("Gwangjin-gu");
            optionList.Add("Guro-gu");
            optionList.Add("Geumcheon-gu");
            optionList.Add("Nowon-gu");
            optionList.Add("Dobong-gu");
            optionList.Add("Dongdaemun-gu");
            optionList.Add("Dongjak-gu");
            optionList.Add("Mapo-gu");
            optionList.Add("Seodaemun-gu");
            optionList.Add("Seocho-gu");
            optionList.Add("Seongdong-gu");
            optionList.Add("Seongbuk-gu");
            optionList.Add("Songpa-gu");
            optionList.Add("Yangcheon-gu");
            optionList.Add("Yeongdeungpo-gu");
            optionList.Add("Yongsan-gu");
            optionList.Add("Eunpyeong-gu");
            optionList.Add("Jongno-gu");
            optionList.Add("Jung-gu");
            optionList.Add("Jungnang-gu");
        }

        if (TypeJudge == 10)
        {
            optionList.Add("Gangnam-gu");
            optionList.Add("Gangdong-gu");
            optionList.Add("Gangbuk-gu");
            optionList.Add("Gangseo-gu");
            optionList.Add("Gwanak-gu");
            optionList.Add("Gwangjin-gu");
            optionList.Add("Guro-gu");
            optionList.Add("Geumcheon-gu");
            optionList.Add("Nowon-gu");
            optionList.Add("Dobong-gu");
            optionList.Add("Dongdaemun-gu");
            optionList.Add("Dongjak-gu");
            optionList.Add("Mapo-gu");
            optionList.Add("Seodaemun-gu");
            optionList.Add("Seocho-gu");
            optionList.Add("Seongdong-gu");
            optionList.Add("Seongbuk-gu");
            optionList.Add("Songpa-gu");
            optionList.Add("Yangcheon-gu");
            optionList.Add("Yeongdeungpo-gu");
            optionList.Add("Yongsan-gu");
            optionList.Add("Eunpyeong-gu");
            optionList.Add("Jongno-gu");
            optionList.Add("Jung-gu");
            optionList.Add("Jungnang-gu");
        }

        if (TypeJudge == 11)
        {
            optionList.Add("Gangnam-gu");
            optionList.Add("Gangdong-gu");
            optionList.Add("Gangbuk-gu");
            optionList.Add("Gangseo-gu");
            optionList.Add("Gwanak-gu");
            optionList.Add("Gwangjin-gu");
            optionList.Add("Guro-gu");
            optionList.Add("Geumcheon-gu");
            optionList.Add("Nowon-gu");
            optionList.Add("Dobong-gu");
            optionList.Add("Dongdaemun-gu");
            optionList.Add("Dongjak-gu");
            optionList.Add("Mapo-gu");
            optionList.Add("Seodaemun-gu");
            optionList.Add("Seocho-gu");
            optionList.Add("Seongdong-gu");
            optionList.Add("Seongbuk-gu");
            optionList.Add("Songpa-gu");
            optionList.Add("Yangcheon-gu");
            optionList.Add("Yeongdeungpo-gu");
            optionList.Add("Yongsan-gu");
            optionList.Add("Eunpyeong-gu");
            optionList.Add("Jongno-gu");
            optionList.Add("Jung-gu");
            optionList.Add("Jungnang-gu");
        }

        if (TypeJudge == 12)
        {
            optionList.Add("Gangnam-gu");
            optionList.Add("Gangdong-gu");
            optionList.Add("Gangbuk-gu");
            optionList.Add("Gangseo-gu");
            optionList.Add("Gwanak-gu");
            optionList.Add("Gwangjin-gu");
            optionList.Add("Guro-gu");
            optionList.Add("Geumcheon-gu");
            optionList.Add("Nowon-gu");
            optionList.Add("Dobong-gu");
            optionList.Add("Dongdaemun-gu");
            optionList.Add("Dongjak-gu");
            optionList.Add("Mapo-gu");
            optionList.Add("Seodaemun-gu");
            optionList.Add("Seocho-gu");
            optionList.Add("Seongdong-gu");
            optionList.Add("Seongbuk-gu");
            optionList.Add("Songpa-gu");
            optionList.Add("Yangcheon-gu");
            optionList.Add("Yeongdeungpo-gu");
            optionList.Add("Yongsan-gu");
            optionList.Add("Eunpyeong-gu");
            optionList.Add("Jongno-gu");
            optionList.Add("Jung-gu");
            optionList.Add("Jungnang-gu");
        }

        if (TypeJudge == 13)
        {
            optionList.Add("Gangnam-gu");
            optionList.Add("Gangdong-gu");
            optionList.Add("Gangbuk-gu");
            optionList.Add("Gangseo-gu");
            optionList.Add("Gwanak-gu");
            optionList.Add("Gwangjin-gu");
            optionList.Add("Guro-gu");
            optionList.Add("Geumcheon-gu");
            optionList.Add("Nowon-gu");
            optionList.Add("Dobong-gu");
            optionList.Add("Dongdaemun-gu");
            optionList.Add("Dongjak-gu");
            optionList.Add("Mapo-gu");
            optionList.Add("Seodaemun-gu");
            optionList.Add("Seocho-gu");
            optionList.Add("Seongdong-gu");
            optionList.Add("Seongbuk-gu");
            optionList.Add("Songpa-gu");
            optionList.Add("Yangcheon-gu");
            optionList.Add("Yeongdeungpo-gu");
            optionList.Add("Yongsan-gu");
            optionList.Add("Eunpyeong-gu");
            optionList.Add("Jongno-gu");
            optionList.Add("Jung-gu");
            optionList.Add("Jungnang-gu");
        }

        if (TypeJudge == 14)
        {
            optionList.Add("Gangnam-gu");
            optionList.Add("Gangdong-gu");
            optionList.Add("Gangbuk-gu");
            optionList.Add("Gangseo-gu");
            optionList.Add("Gwanak-gu");
            optionList.Add("Gwangjin-gu");
            optionList.Add("Guro-gu");
            optionList.Add("Geumcheon-gu");
            optionList.Add("Nowon-gu");
            optionList.Add("Dobong-gu");
            optionList.Add("Dongdaemun-gu");
            optionList.Add("Dongjak-gu");
            optionList.Add("Mapo-gu");
            optionList.Add("Seodaemun-gu");
            optionList.Add("Seocho-gu");
            optionList.Add("Seongdong-gu");
            optionList.Add("Seongbuk-gu");
            optionList.Add("Songpa-gu");
            optionList.Add("Yangcheon-gu");
            optionList.Add("Yeongdeungpo-gu");
            optionList.Add("Yongsan-gu");
            optionList.Add("Eunpyeong-gu");
            optionList.Add("Jongno-gu");
            optionList.Add("Jung-gu");
            optionList.Add("Jungnang-gu");
        }

        
        //강원도
        if (TypeJudge == 15)
        {
            optionList.Add("Gangneung-si");
            optionList.Add("Goseong-gun");
            optionList.Add("Donghae-si");
            optionList.Add("Samcheok-si");
            optionList.Add("Sokcho-si");
            optionList.Add("Yanggu-gun");
            optionList.Add("Yangyang-gun");
            optionList.Add("Yeongwol-gun");
            optionList.Add("Wonju-si");
            optionList.Add("Inje-gun");

            optionList.Add("Jeongseon-gun");
            optionList.Add("Cheorwon-gun");
            optionList.Add("Chuncheon-si");

            optionList.Add("Taebaek-si");
            optionList.Add("Pyeongchang-gun");
            optionList.Add("Hongcheon-gun");
            optionList.Add("Hwacheon-gun");
            optionList.Add("Hoengseong-gun");

        }

        if (TypeJudge == 16)
        {
            optionList.Add("Gangnam-gu");
            optionList.Add("Gangdong-gu");
            optionList.Add("Gangbuk-gu");
            optionList.Add("Gangseo-gu");
            optionList.Add("Gwanak-gu");
            optionList.Add("Gwangjin-gu");
            optionList.Add("Guro-gu");
            optionList.Add("Geumcheon-gu");
            optionList.Add("Nowon-gu");
            optionList.Add("Dobong-gu");
            optionList.Add("Dongdaemun-gu");
            optionList.Add("Dongjak-gu");
            optionList.Add("Mapo-gu");
            optionList.Add("Seodaemun-gu");
            optionList.Add("Seocho-gu");
            optionList.Add("Seongdong-gu");
            optionList.Add("Seongbuk-gu");
            optionList.Add("Songpa-gu");
            optionList.Add("Yangcheon-gu");
            optionList.Add("Yeongdeungpo-gu");
            optionList.Add("Yongsan-gu");
            optionList.Add("Eunpyeong-gu");
            optionList.Add("Jongno-gu");
            optionList.Add("Jung-gu");
            optionList.Add("Jungnang-gu");
        }

        if (TypeJudge == 17)
        {
            optionList.Add("Gangnam-gu");
            optionList.Add("Gangdong-gu");
            optionList.Add("Gangbuk-gu");
            optionList.Add("Gangseo-gu");
            optionList.Add("Gwanak-gu");
            optionList.Add("Gwangjin-gu");
            optionList.Add("Guro-gu");
            optionList.Add("Geumcheon-gu");
            optionList.Add("Nowon-gu");
            optionList.Add("Dobong-gu");
            optionList.Add("Dongdaemun-gu");
            optionList.Add("Dongjak-gu");
            optionList.Add("Mapo-gu");
            optionList.Add("Seodaemun-gu");
            optionList.Add("Seocho-gu");
            optionList.Add("Seongdong-gu");
            optionList.Add("Seongbuk-gu");
            optionList.Add("Songpa-gu");
            optionList.Add("Yangcheon-gu");
            optionList.Add("Yeongdeungpo-gu");
            optionList.Add("Yongsan-gu");
            optionList.Add("Eunpyeong-gu");
            optionList.Add("Jongno-gu");
            optionList.Add("Jung-gu");
            optionList.Add("Jungnang-gu");
        }





        //옵션 설정하기

        secOptions.AddOptions(optionList);

            secOptions.value = currentOptions;

            secOptions.onValueChanged.AddListener(delegate { setDropDownSigugun(secOptions.value); });
        setDropDownSigugun(currentOptions); //최초 옵션 실행이 필요한 경우
        
    

    }



    //dropdowncontroller를 클릭시 값이 변경되는 걸 설정
    void setDropDownSigugun(int option)
        {
            // 데이터를 저장하기위해 playerprefs
            PlayerPrefs.SetInt(DROPDOWN_KEY, option);

            GuJudge = option;
        
        // option 값을 출력하기
        Debug.Log("current option : " + option);

        }

    public void OnClick_GetSigugun()
    {

        GameObject.Find("APIManager").GetComponent<Weather>().CityJudge(TypeJudge,GuJudge);

        _LocationController.SetActive(false);

        //_DropDownSigugun.SetActive(false);
        //_DropDownSigugunButton.SetActive(false);
        //APIManager.gameObject.SetActive(true);
    }
}
