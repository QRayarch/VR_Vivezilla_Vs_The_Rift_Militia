using UnityEngine;
using System.Collections;

public class BodyTransform : MonoBehaviour {

    public Transform head;
    public float bodyMoveSpeed = 10;
    public float rotateSpeed = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 bodyPos = head.position;
        bodyPos.y = 0;

        transform.position = Vector3.Lerp(transform.position, bodyPos, Time.deltaTime * bodyMoveSpeed);

        Vector3 bodyRotation = head.rotation.eulerAngles;
        bodyRotation.x = bodyRotation.z = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(bodyRotation), Time.deltaTime * rotateSpeed);
	}
}
