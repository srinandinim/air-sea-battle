using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
        mousePosition.x = mousePosition.x - objectPosition.x;
        mousePosition.y = mousePosition.y - objectPosition.y;
        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg - 90;
        if (angle < 60 && angle > -60)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
