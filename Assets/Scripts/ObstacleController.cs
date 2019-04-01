using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ObstacleController : NetworkBehaviour
{

    float speed;
    public GameObject plane;
    int[] planeHeights;

    void Start()
    {
        GameObject.Find("Player1Score").GetComponent<Text>().text = "0";
        GameObject.Find("Player2Score").GetComponent<Text>().text = "0";
        int planeCount = UnityEngine.Random.Range(2, 5);
        planeHeights = new int[planeCount];
        CmdCreatePlanes(planeCount);
    }
    
    [Command]
    void CmdCreatePlanes(int count)
    {
        int index = 0;
        speed = UnityEngine.Random.Range(2.5f, 6.0f);
        while (GameObject.FindGameObjectsWithTag("Obstacle").Length < count)
        {
            int obstacleHeight = UnityEngine.Random.Range(1, 5);
            int position = Array.IndexOf(planeHeights, obstacleHeight);
            if (position < 0)
            {
                planeHeights[index] = obstacleHeight;
                index++;
                GameObject p = Instantiate(plane, new Vector3(-12f, obstacleHeight, 0), Quaternion.Euler(0, 0, 0));
                NetworkServer.Spawn(p);
            }
        }
    }

    public float getSpeed()
    {
        return speed;
    }
}
