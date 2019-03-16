using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 mousePosition, objectPosition;
    float mouseAngle, angle;
    int multiplier;

    private void Start()
    {
        multiplier = GetComponent<PlayerSetup>().getMultiplier();

        if (multiplier == 1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 45));
            angle = 45;
        }

        if (multiplier == -1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 125));
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
            if (mouseAngle > 12 && mouseAngle < 90)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, mouseAngle));
                angle = mouseAngle;
            }
        }
        else if (multiplier == -1)
        {
            if (mouseAngle > 82 && mouseAngle < 165)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, mouseAngle));
                angle = mouseAngle;
            }

        }

        /*else if (angle > 60)
        {
            angle = 60;
        } else if (angle < -60)
        {
            angle = -60;
        }*/
    }

    public float getAngle()
    {
        return angle;
    }
}
