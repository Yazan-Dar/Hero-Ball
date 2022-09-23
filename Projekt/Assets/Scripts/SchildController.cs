using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchildController : MonoBehaviour
{
    private Gamemanager gm;
    private GameObject SchildAudio;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<Gamemanager>();
        SchildAudio = GameObject.Find("Schild Audio");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            SchildAudio.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
            gm.getSchild();
        }
    }
}
