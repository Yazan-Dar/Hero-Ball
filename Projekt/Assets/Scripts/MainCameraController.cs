using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 camDistance;
    private float cameraView;
    private float rangeOfZoom;
    private float minZoomRange = 40.0f;
    private float maxZoomRange = 80.0f;
    private float zoomSpeed = 40.0f;

    void Start()
    {
        camDistance = transform.position - player.transform.position;
        cameraView = Camera.main.fieldOfView;
    }

    void LateUpdate()
    {
        if (Camera.main.gameObject.activeInHierarchy)
        {
            transform.position = player.transform.position + camDistance;
            float mouseScroll = Input.GetAxis("Mouse ScrollWheel");
            cameraView -= mouseScroll * zoomSpeed;
            rangeOfZoom = Mathf.Clamp(cameraView, minZoomRange, maxZoomRange);
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, rangeOfZoom, 5.0f * Time.deltaTime);
        }
    }
}
