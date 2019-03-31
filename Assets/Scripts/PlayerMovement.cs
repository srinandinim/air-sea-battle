using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 mousePosition, objectPosition, mouseTempPosition;
    float mouseAngle, angle;
    int multiplier;
    public GameObject gameObject, player;

    private void Start()
    {
        if (gameObject.transform.position.x == -7.75)
        {
            multiplier = -1;
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 45));
            angle = 45;
        } else
        {
            multiplier = 1;
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 125));
            angle = 125;
        }
    }

    void Update()
    {
        mousePosition = Input.mousePosition;
        objectPosition = Camera.main.WorldToScreenPoint(transform.position);
        mousePosition.x = mousePosition.x - objectPosition.x;
        mousePosition.y = mousePosition.y - objectPosition.y;
        mouseAngle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        if (multiplier == 1)
        {
            if (mouseAngle > 0 && mouseAngle < 150)
            {
                gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, mouseAngle));
                mouseTempPosition = mousePosition;
                angle = mouseAngle;
            }
        }
        else if (multiplier == -1)
        {
            if (mouseAngle > 22 && mouseAngle < 172)
            {
                gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, mouseAngle));
                mouseTempPosition = mousePosition;
                angle = mouseAngle;
            }
        }
    }

    public Vector3 getPosition()
    {
        return player.transform.position;
    }

    public Vector3 getMousePosition()
    {
        return mouseTempPosition;
    }
    
    public float getAngle()
    {
        return angle;
    }
}
