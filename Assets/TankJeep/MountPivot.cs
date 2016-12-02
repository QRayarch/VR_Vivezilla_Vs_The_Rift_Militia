using UnityEngine;
using System.Collections;

public class MountPivot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () { 
	    float lR = Input.GetAxis("Right Stick X") * 10;
        if(lR > 0.5f || lR < -0.5f) {
            transform.Rotate(0,lR,0);
        }
	}
}
