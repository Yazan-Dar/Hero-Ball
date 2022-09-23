using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsLeftFirstLevel : MonoBehaviour
{
    private Gamemanager gm;
    public GameObject plattform;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<Gamemanager>();
    }

    void Update()
    {
        GetComponent<TextMeshPro>().text = gm.CoinsLeft.ToString() + " Coins left";
        if (gm.CoinsLeft.ToString().Equals("0"))
        {
            plattform.SetActive(true);
            GetComponent<TextMeshPro>().gameObject.SetActive(false);
        }
    }
}
