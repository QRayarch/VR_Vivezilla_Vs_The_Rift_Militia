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
        collision.gameObject.GetComponent<Building>().health -= 1;
        int health = collision.gameObject.GetComponent<Building>().health;
        if (health <= 0)
        {
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
            //Destroy(other.gameObject);
        }
    }
}
