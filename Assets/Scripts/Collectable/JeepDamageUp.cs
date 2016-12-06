using UnityEngine;
using System.Collections;

public class JeepDamageUp : CollectableBase
{
    public override void doTask(PlayerSelector p)
    {
        p.GetComponent<GunStuff>().damageIncrement();
        Destroy(this);
    }
}
