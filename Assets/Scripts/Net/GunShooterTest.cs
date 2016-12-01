using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(GunStuff))]
public class GunShooterTest : NetworkBehaviour
{
    private GunStuff gun;

    void Start()
    {
        gun = GetComponent<GunStuff>();
    }

	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)return;
            


        if (Input.GetKey(KeyCode.Space))
        {
            gun.CmdFireBullet();
        }
	}
}
