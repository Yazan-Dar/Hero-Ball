using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public GameObject Bullet;
    private GameObject bl;
    private float Shootspace;
    private float Shootintensity;
    private float Shootcounter;

    void Update()
    {
        Shootspace = Random.Range(0.2F, 4F);
        Shootintensity = Random.Range(800, 1500);
        Shootcounter -= Time.deltaTime;
        if (Shootcounter <= 0)
        {
            Shootcounter = Shootspace;
            bl = Instantiate(Bullet, transform.position, transform.rotation);
            Rigidbody rb = bl.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * Shootintensity);
            GetComponent<AudioSource>().Play();
            Destroy(bl, 6.0f);
        }
    }
}
