using UnityEngine;
using UnityEngine.Networking;

public class BulletControl : NetworkBehaviour
{

    public ParticleSystem particleSystem;

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
            CmdExplosion(collision.gameObject);
        }
    }

    [Command]
    void CmdExplosion(GameObject collider)
    {
        ParticleSystem b = Instantiate(particleSystem, transform.position, Quaternion.Euler(0, 0, 0));
        NetworkServer.Spawn(b.gameObject);
        Destroy(collider);
    }
}
