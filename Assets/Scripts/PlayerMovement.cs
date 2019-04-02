using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour
{
    float angle;
    int multiplier;
    public GameObject gameObject, player;

    private void Start()
    {
        if (gameObject.transform.position.x < 0)
        {
            multiplier = 1;
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 45));
            angle = 45;
        } else
        {
            multiplier = -1;
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 125));
            angle = 125;
        }
    }

    public int getMultiplier()
    {
        return multiplier;
    }

    void Update()
    {
        if (hasAuthority)
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
            mousePosition.x = mousePosition.x - objectPosition.x;
            mousePosition.y = mousePosition.y - objectPosition.y;
            float mouseAngle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
            if (multiplier == 1)
            {
                if (mouseAngle > 0 && mouseAngle < 150)
                {
                    gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, mouseAngle));
                    angle = mouseAngle;
                    CmdAngleChange(angle);
                }
            }
            else if (multiplier == -1)
            {
                if (mouseAngle > 22 && mouseAngle < 172)
                {
                    gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, mouseAngle));
                    angle = mouseAngle;
                    CmdAngleChange(angle);
                }
            }
        }
            
    }

    [Command]
    void CmdAngleChange(float ang)
    {
        RpcAngleChange(ang);
    }

    [ClientRpc]
    void RpcAngleChange(float ang)
    {
        if (!isLocalPlayer)
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, ang));
    }

    public Vector3 getPosition()
    {
        return player.transform.position;
    }
    
    public float getAngle()
    {
        return angle;
    }
}
