using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCameraController : MonoBehaviour
{
    public GameObject player;
    public float SmoothRotation = 0.5f;
    public float RotationsSpeed = 5.0f;

    private Vector3 camDistance;
    private Vector3 _camDistanceY;

    void Awake()
    {
        camDistance = transform.position - player.transform.position;
        _camDistanceY = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        Debug.Log(mouseX + " " + mouseY);
        Quaternion camTurnAngle = Quaternion.AngleAxis(mouseX * RotationsSpeed, Vector3.up);
        Quaternion camTurnAngleY = Quaternion.AngleAxis(mouseY * RotationsSpeed, Vector3.left);
        camDistance = camTurnAngle * camDistance;
        _camDistanceY = camTurnAngleY * _camDistanceY;
        Vector3 newPosition = player.transform.position + camDistance;
        Vector3 newPositionY = player.transform.position + _camDistanceY;
        transform.position = Vector3.Slerp(transform.position, newPosition, SmoothRotation);
        transform.position = Vector3.Slerp(transform.position, newPositionY, SmoothRotation);
        transform.LookAt(player.transform);
    }
}
