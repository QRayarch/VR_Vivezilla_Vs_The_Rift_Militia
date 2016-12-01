using UnityEngine;
using System.Collections;

public class GhettoSpring : MonoBehaviour {

    public Rigidbody target;
    Rigidbody self;

    public float lerpAmount;
	// Use this for initialization
	void Start () {
	    self = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	    transform.position = target.position;//Vector3.Lerp(transform.position,target.position, lerpAmount * Time.deltaTime);
        self.position = transform.position;
	}
}
