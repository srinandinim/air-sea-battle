using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    
    void Update()
    {
       Vector3 temp = new Vector3(.05f, 0, 0);
       transform.position += temp;
       if (transform.position.x > 12)
        {
            temp = new Vector3(-12f, 4, 0);
            transform.position = temp;
        }
    }

}
