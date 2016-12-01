using UnityEngine;
using System.Collections;

public class FreezeRotation : MonoBehaviour {

    public Rigidbody start, parent;

	// Use this for initialization
	void Start () {
	    start = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	    start.rotation = parent.rotation;
	}
}
