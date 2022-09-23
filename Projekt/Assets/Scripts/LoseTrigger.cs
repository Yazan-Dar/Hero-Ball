using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseTrigger : MonoBehaviour
{
    private Gamemanager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<Gamemanager>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            gm.LoseLife();
        }
    }
}
