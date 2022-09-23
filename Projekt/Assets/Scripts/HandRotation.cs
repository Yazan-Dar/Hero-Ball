using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRotation : MonoBehaviour
{
    private float random;

    void Update()
    {
        random = Random.Range(20f, 300f);
        transform.Rotate(random * Time.deltaTime, 0 * Time.deltaTime, 0 * Time.deltaTime
       );
    }
}
