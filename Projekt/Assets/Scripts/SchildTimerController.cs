using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchildTimerController : MonoBehaviour
{
    public Gamemanager gm;

    private void Start()
    {
        GetComponent<Text>().text = gm.TimerNumber.ToString();
    }

    private void Update()
    {
        GetComponent<Text>().text = gm.TimerNumber.ToString();
    }
}
