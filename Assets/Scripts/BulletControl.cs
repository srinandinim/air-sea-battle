using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{    
    void Update()
    {
        if (transform.position.x > 12 || transform.position.x < -12 || transform.position.y > 5 || transform.position.y < -5)
        {
            Destroy(gameObject, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Hit a Plane");
            Destroy(collision.gameObject);
        }
        //Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    }
}
