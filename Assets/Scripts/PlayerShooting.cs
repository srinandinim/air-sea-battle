using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log ("space key was pressed");
            Debug.Log(playerMovement.getAngle() + "");
        }
    }
}
