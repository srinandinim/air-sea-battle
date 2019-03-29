using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    Vector2 speed;
    Rigidbody2D rb;
    int multiplier;
    Transform shootPosition;

    void Start()
    {
        rb = GetComponent <Rigidbody2D> ();

        multiplier = GameObject.Find("Player(Clone)").GetComponent<PlayerSetup>().getMultiplier();
        if (multiplier == 1)
            speed = new Vector2(2, 2);
        if (multiplier == -1)
            speed = new Vector2(2, 2);
        rb.velocity = speed;

       // shootPosition = GameObject.Find("Player(Clone)").GetComponent<PlayerShooting>().getShootPosition();
       // rb.transform.position = new Vector3(shootPosition.position.x, shootPosition.position.y, shootPosition.position.z);
    }

    void Update()
    {
        rb.velocity = speed;
        if (transform.position.x > 12 || transform.position.x < -12 || transform.position.y > 5 || transform.position.y < -5)
        {
            Destroy(gameObject, 1);
        }
    }
}
