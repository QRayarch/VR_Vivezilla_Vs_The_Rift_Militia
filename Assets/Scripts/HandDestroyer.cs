﻿using UnityEngine;
using System.Collections;

public class HandDestroyer : MonoBehaviour {

    public ushort hapticAmountOnHit = 1000;
    public Haptics.Hand hand;

    [Header("FX")]
    public ParticleSystem effect;

	// Use this for initialization
	void Start () {
	
	}


    void OnCollisionEnter(Collision collision)
    {
        Building building = collision.collider.gameObject.GetComponent<Building>();
        if (building == null || building.health <= 0) return;
        building.health -= 1;
        if(effect != null)
        {
            effect.transform.position = collision.contacts[0].point;
            effect.Emit(10);
        }
        Haptics.ProvideHaptics(hand, hapticAmountOnHit);
        if (building.health <= 0)
        {
            for(int i = 0; i < collision.collider.gameObject.transform.childCount; ++i)
            {
                Rigidbody rb = collision.collider.gameObject.transform.GetChild(i).GetComponent<Rigidbody>();
                rb.isKinematic = false;
                rb.useGravity = true;
            }
            collision.collider.enabled = false;
        }
    }
}
