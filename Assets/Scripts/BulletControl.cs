using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public Vector2 speed;
    Rigidbody2D rb;
    int multiplier;

    void Start()
    {
        rb = GetComponent <Rigidbody2D> ();
        multiplier = GameObject.Find("Player(Clone)").GetComponent<PlayerSetup>().getMultiplier();
        Debug.Log(multiplier);
        if (multiplier == 1)
            speed = Vector2.one;
        if (multiplier == -1)
            speed = new Vector2(-1, 1);
        rb.velocity = speed;
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
