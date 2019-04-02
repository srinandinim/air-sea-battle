using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ObstacleController : NetworkBehaviour
{

    float speed, scaleFactor, rotation;
    public GameObject plane;
    int[] planeHeights;
    bool planesAppeared, gameEnded, startingBool;
    public Sprite obstacle1, obstacle2;
    Sprite usingSprite;
    int p1Score, p2Score, levelCount, startingSide;

    void Start()
    {
        GameObject.Find("Player1Score").GetComponent<Text>().text = "0";
        GameObject.Find("Player2Score").GetComponent<Text>().text = "0";
        newLevel();
    }

    private void Update()
    {
        if (gameEnded == false && planesAppeared && GameObject.FindGameObjectsWithTag("Obstacle").Length < 1)
        {
            if (levelCount != 3)
                newLevel();
            else
            {
                gameEnded = true;
                CmdEndGame();
            }
        }
    }

    void newLevel()
    {
        int planeCount = UnityEngine.Random.Range(2, 5);
        planeHeights = new int[planeCount];
        planesAppeared = false;
        gameEnded = false;
        startingBool = (UnityEngine.Random.value > 0.5f);
        speed = UnityEngine.Random.Range(2.5f, 6.0f);
        levelCount++;
        if (startingBool)
        {
            startingSide = -1;
            rotation = 0f;
        } else
        {
            startingSide = 1;
            rotation = 180f;
        }
        usingSprite = obstacle1;
        scaleFactor = 0.5f;
        /*if (levelCount == 2)
        {
            usingSprite = obstacle2;
            scaleFactor = 0.75f;
        }*/
        CmdCreatePlanes(planeCount);
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
        int index = 0; ;
        if (startingSide == 1)
            speed = speed * -1f;
        while (GameObject.FindGameObjectsWithTag("Obstacle").Length < count)
        {
            int obstacleHeight = UnityEngine.Random.Range(1, 5);
            int position = Array.IndexOf(planeHeights, obstacleHeight);
            if (position < 0)
            {
                planeHeights[index] = obstacleHeight;
                index++;
                GameObject p = Instantiate(plane, new Vector3(12f * startingSide, obstacleHeight, 0), Quaternion.Euler(0, rotation, 0));
                //p.GetComponent<SpriteRenderer>().sprite = usingSprite;
                p.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
                //p.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0.0f);
                NetworkServer.Spawn(p);
                RpcCreatePlanes(obstacleHeight);
            }
        }

    }

    [ClientRpc]
    void RpcCreatePlanes(int obstacleHeight)
    {}

    public float getSpeed()
    {
        return speed;
    }

}