using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] componentsToDisable;
    int multiplier;

    void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }

        if (NetworkServer.connections.Count > 0)
        {
            multiplier = 1;
        }
        else
        {
            multiplier = -1;
        }

    }

    public int getMultiplier()
    {
        return multiplier;
    }

}
