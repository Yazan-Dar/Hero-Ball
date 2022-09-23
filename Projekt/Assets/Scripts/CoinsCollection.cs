using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCollection : MonoBehaviour
{
    private Gamemanager gm;
    private GameObject coinsAudio;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<Gamemanager>();
        coinsAudio = GameObject.Find("Coins Audio");
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime * 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            coinsAudio.GetComponent<AudioSource>().Play();
            gm.getScore();
            gm.getCoinsLeft();
            Destroy(gameObject);
        }
    }
}
