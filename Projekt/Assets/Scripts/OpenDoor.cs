using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject door;
    private GameObject DoorAudio;

    private void Start()
    {
        DoorAudio = GameObject.Find("Door Audio");
    }

    private void OnCollisionEnter(Collision collision)
    {
        DoorAudio.GetComponent<AudioSource>().Play();
        GetComponent<MeshRenderer>().material.color = Color.green;
        GameObject.Destroy(door);
    }
}
