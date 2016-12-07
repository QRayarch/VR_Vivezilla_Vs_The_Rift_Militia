using UnityEngine;
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
        collision.collider.gameObject.GetComponent<Building>().health -= 1;
        int health = collision.collider.gameObject.GetComponent<Building>().health;
        if(effect != null)
        {
            effect.transform.position = collision.contacts[0].point;
            effect.Emit(10);
        }
        Haptics.ProvideHaptics(hand, hapticAmountOnHit);
        if (health <= 0)
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
