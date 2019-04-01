using UnityEngine;
using UnityEngine.Networking;

public class PlaneMovement : NetworkBehaviour
{
    Vector3 startingPosition;
    Rigidbody2D rb;
    float obstacleSpeed;

    private void Start()
    {
        startingPosition = transform.position;
        obstacleSpeed = GameObject.Find("ObstacleParent").GetComponent<ObstacleController>().getSpeed();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Tank").Length > 1){
            CmdMovement();
        }
    }

    [Command]
    void CmdMovement()
    {
        rb.velocity = new Vector2(obstacleSpeed, 0.0f);
        if (rb.transform.position.x > 12)
            rb.transform.position = startingPosition;
        NetworkServer.Spawn(gameObject);
    }

}
