using UnityEngine;
using System.Collections;

public class CopyTransform : MonoBehaviour {

    public Transform trans;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        UpdateTransform();
	}

    void UpdateTransform()
    {
        trans.position = this.transform.position;
        trans.rotation = this.transform.rotation;
    }
}
