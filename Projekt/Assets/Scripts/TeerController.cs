using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeerController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerMovement.speed = 5f;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerMovement.speed = 150.0f;
        }
    }
}
