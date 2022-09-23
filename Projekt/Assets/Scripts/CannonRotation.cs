using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotation : MonoBehaviour
{
    public Transform player;
    public float range;

    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= range)
        {
            transform.LookAt(player.transform);
        }
    }
}
