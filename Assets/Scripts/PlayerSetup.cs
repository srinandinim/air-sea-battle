using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour
{
    /*[SerializeField]
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

    */
    public GameObject tankPrefab;
    int multiplier;

    private void Start()
    {
        
        if (NetworkServer.connections.Count > 0)
            multiplier = 1;
        else
            multiplier = -1;

        if (isServer)
            SpawnTank();
    }

    public int getMultiplier()
    {
        return multiplier;
    }

    public void SpawnTank()
    {
        if (isServer == false)
            return;

        float rot = transform.rotation.y;

        GameObject myTank = Instantiate(tankPrefab, transform.position, Quaternion.Euler(0, rot, 0));
        
        NetworkServer.SpawnWithClientAuthority(myTank, connectionToClient);
    }

}
