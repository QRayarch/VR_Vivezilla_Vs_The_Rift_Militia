using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {

    public GameObject followPoint;
	public float lerpSpeed;

	// Update is called once per frame
	void Update () {
	    transform.position = Vector3.Lerp(transform.position,followPoint.transform.position,lerpSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, followPoint.transform.rotation, lerpSpeed * Time.deltaTime);
	}
}
