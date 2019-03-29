using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    PlayerMovement playerMovement;
    public GameObject bullet;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Instantiate(bullet, playerMovement.getFirePos());
        }
    }
}
