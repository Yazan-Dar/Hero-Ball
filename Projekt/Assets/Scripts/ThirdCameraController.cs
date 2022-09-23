using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCameraController : MonoBehaviour
{
    public GameObject player;
    public float SmoothRotation = 0.5f;
    public float RotationsSpeed = 5.0f;

    private Vector3 camDistance;

    void Awake()
    {
        camDistance = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        Debug.Log(mouseX);
        Quaternion camTurnAngle = Quaternion.AngleAxis(mouseX * RotationsSpeed, Vector3.up);
        camDistance = camTurnAngle * camDistance;
        Vector3 newPosition = player.transform.position + camDistance;
        transform.position = Vector3.Slerp(transform.position, newPosition, SmoothRotation);
        transform.LookAt(player.transform);
    }
}
