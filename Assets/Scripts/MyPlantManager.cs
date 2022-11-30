using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlantManager : MonoBehaviour
{
    public ChangeScenes cs;

    public void OnClickBox()
    {
        string nowbutton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        cs.plantNum = nowbutton;
        Debug.Log(nowbutton);
        if (cs.plantNum != "0") cs.PlantInfoScene();
    }
}
