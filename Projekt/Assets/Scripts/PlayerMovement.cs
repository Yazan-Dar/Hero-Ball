using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float speed = 150.0f;
    public float jumpForce = 200.0f;
    public Camera[] cameras;
    private int currentCameraIndex;
    private Rigidbody rb;
    private Vector3 move;
    private Vector3 jump;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 1.0f, 0.0f);

        currentCameraIndex = 0;

        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }

        if (cameras.Length > 0)
        {
            cameras[0].gameObject.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Line001")
        {
            isGrounded = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentCameraIndex++;

            if (currentCameraIndex < cameras.Length)
            {
                cameras[currentCameraIndex - 1].gameObject.SetActive(false);
                cameras[currentCameraIndex].gameObject.SetActive(true);
            }
            else
            {
                cameras[currentCameraIndex - 1].gameObject.SetActive(false);
                currentCameraIndex = 0;
                cameras[currentCameraIndex].gameObject.SetActive(true);
            }
        }
    }

    void FixedUpdate()
    {
        float Vertical = Input.GetAxis("Vertical");
        float Horizontal = Input.GetAxis("Horizontal");
        move = new Vector3(Horizontal, 0.0f, Vertical);

        Vector3 relativeMovement1 = cameras[1].transform.TransformVector(move);
        Vector3 relativeMovement2 = cameras[2].transform.TransformVector(move);

        if (cameras[0].gameObject.activeInHierarchy)
        {
            rb.AddForce(move * speed * Time.deltaTime);
        }
        else if (cameras[1].gameObject.activeInHierarchy)
        {
            rb.AddForce(relativeMovement1 * speed * Time.deltaTime);
        }
        else
        {
            rb.AddForce(relativeMovement2 * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce * Time.deltaTime, ForceMode.Impulse);
            isGrounded = false;
            GetComponent<AudioSource>().Play();
        }
    }
}
