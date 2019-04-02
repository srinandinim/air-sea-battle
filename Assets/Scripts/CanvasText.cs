using UnityEngine;
using UnityEngine.UI;

public class CanvasText : MonoBehaviour
{
    public Text winner;
    int scoreOne, scoreTwo;

    private void Start()
    {
        scoreOne = PlayerPrefs.GetInt("Player1Score");
        scoreTwo = PlayerPrefs.GetInt("Player2Score");
        if (scoreOne > scoreTwo)
            winner.text = "PLAYER 1 WON!\n[" + scoreOne + " - " + scoreTwo + "]";
        if (scoreOne < scoreTwo)
            winner.text = "PLAYER 2 WON!\n[" + scoreOne + " - " + scoreTwo + "]";
        if (scoreOne == scoreTwo)
            winner.text = "IT IS A TIE!\n[" + scoreOne + "-" + scoreTwo + "]";
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}