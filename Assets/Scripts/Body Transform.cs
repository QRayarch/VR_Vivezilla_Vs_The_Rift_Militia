using UnityEngine;
using System.Collections;

public class BodyTransform : MonoBehaviour {

    public Transform head;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 bodyPos = head.position;
        bodyPos.y = 0;

        transform.position = bodyPos;
	}
}
