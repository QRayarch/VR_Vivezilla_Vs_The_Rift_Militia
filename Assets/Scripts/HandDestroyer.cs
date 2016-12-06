using UnityEngine;
using System.Collections;

public class HandDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag.Equals("MainBuilding"))
        {
            collision.collider.gameObject.GetComponent<Building>().health -= 1;
            int health = collision.collider.gameObject.GetComponent<Building>().health;
            if (health <= 0)
            {
                for (int i = 0; i < collision.collider.gameObject.transform.childCount; ++i)
                {
                    Rigidbody rb = collision.collider.gameObject.transform.GetChild(i).GetComponent<Rigidbody>();
                    rb.isKinematic = false;
                    rb.useGravity = true;
                }
                collision.collider.enabled = false;
            }
        }
    }
}
