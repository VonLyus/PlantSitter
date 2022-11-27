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
            //Start���� onValueChanged�� delegate�� setDropDown �޼��带 �߰��ϸ�,

            //�Ź� �ɼ��� ���õ� �� ���� setDropDown�� ȣ��ȴ�.
            options.onValueChanged.AddListener(delegate { setDropDown(options.value); });
            setDropDown(currentOption); //���� �ɼ� ������ �ʿ��� ���
        }

        void setDropDown(int option)
        {
            //���� �ɼ��� �����ϴ� �ڵ�

            PlayerPrefs.SetInt(DROPDOWN_KEY, option);
            Judge = option;
            // option ���� ����
            Debug.Log("current option : " + option);

        }



}
