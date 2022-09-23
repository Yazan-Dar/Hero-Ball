using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsLeftSecondLevel : MonoBehaviour
{
    private Gamemanager gm;
    public GameObject rock;
    private GameObject DoorAudio;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<Gamemanager>();
        DoorAudio = GameObject.Find("Door Audio");
    }

    void Update()
    {
        GetComponent<TextMeshPro>().text = gm.CoinsLeft.ToString() + " Coins left";
        if (gm.CoinsLeft.ToString().Equals("0"))
        {
            DoorAudio.GetComponent<AudioSource>().Play();
            Destroy(rock);
            //GetComponent<TextMeshPro>().text = "";
            GetComponent<TextMeshPro>().gameObject.SetActive(false);
        }
    }
}
