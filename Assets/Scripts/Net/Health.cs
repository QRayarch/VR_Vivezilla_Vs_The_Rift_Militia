using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

    [SyncVar]
    public float health = 100;

	// Use this for initialization
	void Start () {
        
    }
	
    public void Damage(float a)
    {
        if (IsDead) return;
        health -= a;
    }

    public bool IsDead
    {
        get { return health < 0; }
    }
}
