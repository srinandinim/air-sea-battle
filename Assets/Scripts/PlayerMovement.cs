using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 mousePosition, objectPosition;
    float angle;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 45));
    }

    void Update()
    {
        mousePosition = Input.mousePosition;
        objectPosition = Camera.main.WorldToScreenPoint(transform.position);
        mousePosition.x = mousePosition.x - objectPosition.x;
        mousePosition.y = mousePosition.y - objectPosition.y;
        angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        if (angle > 12 && angle < 90)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        } /*else if (angle > 60)
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
