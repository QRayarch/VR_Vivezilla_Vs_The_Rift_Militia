using UnityEngine;
using System.Collections;

public class BarrelMovement : MonoBehaviour {

    public GunStuff gun;

    public void Fire()
    {
        gun.CmdFireBullet();
    }

    public void Rotate(float uD)
    {
        uD *= 10;
        if (uD > 0.5f || uD < -0.5f)
        {
            transform.Rotate(uD, 0, 0);
        }
    }

}
