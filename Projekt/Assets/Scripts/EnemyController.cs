using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Gamemanager gm;
    private GameObject[] enemys;
    private float speed = 1f;
    private float timer = 0.0f;
    private float timeToRun = 200.0f;
    private bool isTure;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<Gamemanager>();
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update()
    {
        if (enemys.Length != 0)
        {
            foreach (GameObject enemy in enemys)
            {
                enemy.transform.position = new Vector3(enemy.transform.position.x, Mathf.Sin(Time.time * speed) + 8f, enemy.transform.position.z);
            }
        }

        if (isTure)
        {
            timer = timer + 1.0f;
            if (timer == timeToRun)
            {
                gm.ShieldProtection();
                isTure = false;
                timer = 0.0f;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            gm.explode();
            isTure = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            gm.explode();
            isTure = true;
        }
    }

}
