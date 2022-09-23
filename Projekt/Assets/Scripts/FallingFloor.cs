using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloor : MonoBehaviour
{
    private float xPosition;
    private float zPosition;
    private float yPosition = -10;
    private float startYPosition;
    private float t;
    private float timeToReachTarget;
    Vector3 startPosition;
    Vector3 target;

    void Start()
    {
        startPosition = target = transform.position;
        xPosition = startPosition.x;
        zPosition = startPosition.z;
        startYPosition = startPosition.y;
    }

    void Update()
    {
        t += Time.deltaTime / timeToReachTarget;
        transform.position = Vector3.Lerp(startPosition, target, t);
    }

    public void SetDestination(Vector3 destination, float time)
    {
        t = 0;
        startPosition = transform.position;
        timeToReachTarget = time;
        target = destination;
    }

    private void OnCollisionEnter(Collision collision)
    {
        SetDestination(new Vector3(xPosition, yPosition, zPosition), 30);
    }

    private void OnCollisionExit(Collision collision)
    {
        SetDestination(new Vector3(xPosition, startYPosition, zPosition), 30);
    }
}
