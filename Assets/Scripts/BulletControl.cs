using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class BulletControl : NetworkBehaviour
{

    public ParticleSystem particleSystem;
    int multiplier;
    Text usingText;

    private void Start()
    {
        if (gameObject.transform.position.x < 0)
        {
            usingText = GameObject.Find("Player1Score").GetComponent<Text>();
        }
        else
        {
            usingText = GameObject.Find("Player2Score").GetComponent<Text>();
        }
    }

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
        int score = Int32.Parse(usingText.GetComponent<Text>().text);
        score++;
        usingText.text = score + "";
        ParticleSystem b = Instantiate(particleSystem, transform.position, Quaternion.Euler(0, 0, 0));
        NetworkServer.Spawn(b.gameObject);
        Destroy(collider);
    }

}
