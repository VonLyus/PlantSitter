using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationController : MonoBehaviour
{

    public GameObject _LocationController;

    // Start is called before the first frame update
    void Start()
    {
        _LocationController.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick_GetControll()
    {
        _LocationController.SetActive(true);
    }
    }
