using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionKnopf : MonoBehaviour
{
    public GameObject door;
    public GameObject doorBtn;
    private GameObject DoorAudio;

    private void Start()
    {
        DoorAudio = GameObject.Find("Door Audio");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "DoorBtn")
        {
            DoorAudio.GetComponent<AudioSource>().Play();
            doorBtn.GetComponent<MeshRenderer>().material.color = Color.green;
            GameObject.Destroy(door);
        }
    }
}
