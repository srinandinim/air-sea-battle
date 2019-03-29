using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    PlayerMovement playerMovement;
    Transform shootPosition;
    public GameObject bullet;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            shootPosition = playerMovement.getFirePos();
            Instantiate(bullet, shootPosition);
        }
    }

    public Transform getShootPosition()
    {
        return shootPosition;
    }
}
