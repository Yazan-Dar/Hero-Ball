using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCollection : MonoBehaviour
{
    private Gamemanager gm;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<Gamemanager>();
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime * 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Destroy(gameObject);
            gm.getLife();
        }
    }
}
