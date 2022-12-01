using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeBackground : MonoBehaviour
{
    public GameObject[] background;
    int index;
    float timer;
    int waitingTime;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        timer = 0.0f;
        waitingTime = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (index >= 5)
            index = 0;

        if (index < 0)
            index = 5;

        if (index == 0)
        {
            background[0].gameObject.SetActive(true);
            background[1].gameObject.SetActive(false);
            background[2].gameObject.SetActive(false);
            background[3].gameObject.SetActive(false);
            background[4].gameObject.SetActive(false);
        }

        if (index == 1)
        {
            background[0].gameObject.SetActive(false);
            background[1].gameObject.SetActive(true);
            background[2].gameObject.SetActive(false);
            background[3].gameObject.SetActive(false);
            background[4].gameObject.SetActive(false);
        }

        if (index == 2)
        {
            background[0].gameObject.SetActive(false);
            background[1].gameObject.SetActive(false);
            background[2].gameObject.SetActive(true);
            background[3].gameObject.SetActive(false);
            background[4].gameObject.SetActive(false);
        }

        if (index == 3)
        {
            background[0].gameObject.SetActive(false);
            background[1].gameObject.SetActive(false);
            background[2].gameObject.SetActive(false);
            background[3].gameObject.SetActive(true);
            background[4].gameObject.SetActive(false);
        }
        if (index == 4)
        {
            background[0].gameObject.SetActive(false);
            background[1].gameObject.SetActive(false);
            background[2].gameObject.SetActive(false);
            background[3].gameObject.SetActive(false);
            background[4].gameObject.SetActive(true);
        }

        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            //Action
            index += 1;
            timer = 0;
        }

    }
}
