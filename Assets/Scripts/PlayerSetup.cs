using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour
{
    public GameObject tankPrefab;

    private void Start()
    {
        if (isServer)
            SpawnTank();
    }

    public void SpawnTank()
    {
        if (isServer == false)
            return;
        
        GameObject myTank = Instantiate(tankPrefab, transform.position, Quaternion.Euler(0, 0, 0));
        if (myTank.transform.position.x > 0)
        {
            myTank.transform.RotateAround(transform.position, transform.up, 180f);
        }

        NetworkServer.SpawnWithClientAuthority(myTank, connectionToClient);
    }

}
