using UnityEngine;
using UnityEngine.Networking;

public class ObstacleController : NetworkBehaviour
{

    float speed;
    public GameObject plane;
    bool[] planeHeights;

    void Start()
    {
        //speed = Random.Range(0.02f, 0.08f);
        int planeCount = Random.Range(1, 4);
        planeHeights = new bool[4];
        CmdCreatePlanes(planeCount);
    }

    [Command]
    void CmdCreatePlanes(int count)
    {
        while (GameObject.FindGameObjectsWithTag("Obstacle").Length < count)
        {
            int obstacleHeight = Random.Range(1, 4);
            for (int i = 0; i < planeHeights.Length; i++)
            {
                if (i+1 == obstacleHeight)
                {
                    while (planeHeights[i])
                    {
                        obstacleHeight = Random.Range(1, 4); 
                    }
                    planeHeights[i] = true;
                }
               
            }
            GameObject p = Instantiate(plane, new Vector3(-12f, obstacleHeight, 0), Quaternion.Euler(0, 0, 0));
            NetworkServer.Spawn(p);
        }
    }

    public float getSpeed()
    {
        return speed;
    }
}
