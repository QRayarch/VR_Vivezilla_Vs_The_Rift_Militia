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
        if (!trans.gameObject.activeInHierarchy) return;
        this.transform.position = trans.position;
        this.transform.rotation = trans.rotation;
    }
}
