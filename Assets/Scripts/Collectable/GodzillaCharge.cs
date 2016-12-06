using UnityEngine;
using System.Collections;

public class GodzillaCharge : CollectableBase {
    void Start()
    {
        identity = 2;
    }
    public override void doTask(PlayerSelector p)
    {
        //Your code here
        base.doTask(p);
    }
}
