using UnityEngine;
using System.Collections;

public class JeepDamageUp : CollectableBase
{
    void Start()
    {
        identity = 3;
    }

    public override void doTask(PlayerSelector p)
    {
        p.GetComponent<GunStuff>().damageIncrement();
        base.doTask(p);
    }
}
