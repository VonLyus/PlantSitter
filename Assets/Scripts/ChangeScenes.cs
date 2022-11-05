using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
   
    public void MainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");

    }

    public void MyPlantScene()
    {
        SceneManager.LoadScene("MyPlant");
    }

    public void PlantInfoScene()
    {
        SceneManager.LoadScene("Plant_Info");
    }

    public void PlantRegisterScene()
    {
        SceneManager.LoadScene("Plant_Register");
    }

    public void DiaryScene()
    {
        SceneManager.LoadScene("Diary");

    }

    public void DictionaryScene()
    {
        SceneManager.LoadScene("Dictionary");
    }
}
