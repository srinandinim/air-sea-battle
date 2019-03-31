using UnityEngine;
using UnityEngine.Networking;


public class PlayerShooting : NetworkBehaviour
{
    PlayerMovement playerMovement;
    Vector3 shootPosition;
    public GameObject bullet;
    float turretAngle;
    float turretPower = 10f;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (hasAuthority)
        {
            AuthorityUpdate();
        }
    }

    void AuthorityUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            shootPosition = playerMovement.getPosition();
            turretAngle = playerMovement.getAngle();
            Vector2 velocity = new Vector2(turretPower * Mathf.Cos(turretAngle * Mathf.Deg2Rad), turretPower * Mathf.Sin(turretAngle * Mathf.Deg2Rad));
            CmdFireBullet(shootPosition, velocity);
        }
    }

    [Command]
    void CmdFireBullet (Vector3 bulletPosition, Vector2 velocity)
    {
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        GameObject b = Instantiate(bullet, bulletPosition, Quaternion.Euler(0, 0, angle));
        Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
        rb.velocity = velocity;
        NetworkServer.Spawn(b);
    }

    }
