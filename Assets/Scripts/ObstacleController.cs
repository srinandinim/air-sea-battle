using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObstacleController : NetworkBehaviour
{

    float speed;
    public GameObject plane;
    int[] planeHeights;
    bool planesAppeared, gameEnded;
    
    int p1Score;
    int p2Score;
    
    void Start()
    {
        GameObject.Find("Player1Score").GetComponent<Text>().text = "0";
        GameObject.Find("Player2Score").GetComponent<Text>().text = "0";
        int planeCount = UnityEngine.Random.Range(2, 5);
        planeHeights = new int[planeCount];
        planesAppeared = false;
        gameEnded = false;
        CmdCreatePlanes(planeCount);
    }
    
    private void Update()
    {
        if (gameEnded == false && planesAppeared && GameObject.FindGameObjectsWithTag("Obstacle").Length < 1)
        {
            Debug.Log("End Game");
            gameEnded = true;
            CmdEndGame();
        }
    }

    [Command]
    void CmdEndGame()
    {
        RpcEndGame();
    }

    [ClientRpc]
    void RpcEndGame()
    {
        p1Score = Int32.Parse(GameObject.Find("Player1Score").GetComponent<Text>().text);
        p2Score = Int32.Parse(GameObject.Find("Player2Score").GetComponent<Text>().text);
        PlayerPrefs.SetInt("Player1Score", p1Score);
        PlayerPrefs.SetInt("Player2Score", p2Score);
        NetworkManager.singleton.ServerChangeScene("EndGame");
    }
    
    [Command]
    void CmdCreatePlanes(int count)
    {
        planesAppeared = true;
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
