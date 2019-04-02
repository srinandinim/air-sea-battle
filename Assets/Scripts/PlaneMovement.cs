using UnityEngine;
using UnityEngine.Networking;

public class PlaneMovement : NetworkBehaviour
{
    Vector3 startingPosition;
    Rigidbody2D rb;
    float speed;

    private void Start()
    {
        startingPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        speed = GameObject.Find("ObstacleParent").GetComponent<ObstacleController>().getSpeed();
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Tank").Length > 1) { 
            CmdMovement();
        }
    }

    [Command]
    void CmdMovement()
    {
        rb.velocity = new Vector2(speed, 0.0f);
        if (rb.transform.position.x > 12 || rb.transform.position.x < -12f)
            rb.transform.position = startingPosition;
        NetworkServer.Spawn(gameObject);
    }

}
