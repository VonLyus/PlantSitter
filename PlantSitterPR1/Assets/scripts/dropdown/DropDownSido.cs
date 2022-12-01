using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropDownSido : MonoBehaviour
{
    public string DROPDOWN_KEY = "DROPDOWN_KEY";
    public int currentOption;

    public GameObject _DropDownSigugun;
    public GameObject _DropDownSigugunButton;
    

   

    // 방금 클릭한 게임 오브젝트를 가져와서 저장
    //GameObject clickObject = EventSystem.current.currentSelectedGameObject;

    public int Judge;

    public TMP_Dropdown options;

    public Button button;

    

    public List<string> optionList = new List<string>();

        void Awake()
        {
            if (PlayerPrefs.HasKey(DROPDOWN_KEY) == false) currentOption = 0;
            else currentOption = PlayerPrefs.GetInt(DROPDOWN_KEY);
        }

    void Start()
    {
        
        _DropDownSigugun.SetActive(false);
        _DropDownSigugunButton.SetActive(false);
        

        options = this.GetComponent<TMP_Dropdown>();

            options.ClearOptions();
            optionList.Add("Select");
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
            options.onValueChanged.AddListener(delegate { setDropDownSido(options.value); });
        setDropDownSido(currentOption); //최초 옵션 실행이 필요한 경우
        }

    void setDropDownSido(int option)
        {

            PlayerPrefs.SetInt(DROPDOWN_KEY, option);
            Judge = option;
            Debug.Log("current option : " + option);

    }

    public void OnClick_GetSido()
    {
        if (Judge != 0)
        {
            _DropDownSigugun.SetActive(true);
            _DropDownSigugunButton.SetActive(true);
            

        }
        if (Judge == 0) {
            _DropDownSigugun.SetActive(false);
            _DropDownSigugunButton.SetActive(false);
            

        }
    }


}
