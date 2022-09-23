using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    public Gamemanager gm;

    private void Start()
    {
        gm.lifeChanged.AddListener(UpdateLife);
        GetComponent<Text>().text = gm.LifeNumber.ToString();
    }

    private void UpdateLife(int value)
    {
        GetComponent<Text>().text = value.ToString();
    }

}
