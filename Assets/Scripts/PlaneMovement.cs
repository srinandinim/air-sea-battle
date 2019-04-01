using UnityEngine;
using UnityEngine.Networking;

public class PlaneMovement : NetworkBehaviour
{
    Vector3 startingPosition;
    Rigidbody2D rb;
    float obstacleSpeed = 0.05f;
    public float transitionSpeed = 10;

    private void Start()
    {
        startingPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        //obstacleSpeed = Random.Range(0.02f, 0.08f);
    }

    void Update()
    {
        // if (GameObject.FindGameObjectsWithTag("Tank").Length > 1)
        if (true)
        {
            CmdMovement();
        }
        
    }

    [Command]
    void CmdMovement()
    {
        rb.velocity = new Vector2(3.0f, 0.0f);
        if (rb.transform.position.x > 12)
            rb.transform.position = startingPosition;
        NetworkServer.Spawn(gameObject);
    }

}
