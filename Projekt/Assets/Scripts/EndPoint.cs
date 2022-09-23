using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPoint : MonoBehaviour
{
    private Gamemanager gm;
    public GameObject nextLevelBtn;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<Gamemanager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        gm.EndPoint(nextLevelBtn);
    }
}
