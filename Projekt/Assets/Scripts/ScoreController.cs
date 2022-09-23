using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Gamemanager gm;

    private void Start()
    {
        gm.scoreChanged.AddListener(UpdateScore);
        GetComponent<Text>().text = gm.ScoreNumber.ToString();
    }

    private void UpdateScore(int value)
    {
        GetComponent<Text>().text = value.ToString();
    }
}
