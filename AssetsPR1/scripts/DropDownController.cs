using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


    public class DropDownController : MonoBehaviour
    {
        public string DROPDOWN_KEY = "DROPDOWN_KEY";

        public int currentOption;
        public int Judge;
        public TMP_Dropdown options;

        public List<string> optionList = new List<string>();

        void Awake()
        {
            if (PlayerPrefs.HasKey(DROPDOWN_KEY) == false) currentOption = 0;
            else currentOption = PlayerPrefs.GetInt(DROPDOWN_KEY);
        }

        void Start()
        {
            options = this.GetComponent<TMP_Dropdown>();

            options.ClearOptions();

            optionList.Add("seoul");
            optionList.Add("gyeonggi");
            optionList.Add("incheon");
            optionList.Add("busan");
            optionList.Add("daegu");
            optionList.Add("gwangju");
            optionList.Add("daejeon");
            optionList.Add("ulsan");
            optionList.Add("gyeongnam");
            optionList.Add("kyeongbuk");
            optionList.Add("chungnam");
            optionList.Add("chungbuk");
            optionList.Add("jeonnam");
            optionList.Add("jeonbuk");
            optionList.Add("kangwon");
            optionList.Add("jeju");
            optionList.Add("sejong");

            options.AddOptions(optionList);

            options.value = currentOption;
            //Start에서 onValueChanged에 delegate로 setDropDown 메서드를 추가하면,

            //매번 옵션이 선택될 때 마다 setDropDown이 호출된다.
            options.onValueChanged.AddListener(delegate { setDropDown(options.value); });
            setDropDown(currentOption); //최초 옵션 실행이 필요한 경우
        }

        void setDropDown(int option)
        {
            //현재 옵션을 갱신하는 코드

            PlayerPrefs.SetInt(DROPDOWN_KEY, option);
            Judge = option;
            // option 관련 동작
            Debug.Log("current option : " + option);

        }



}
