using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
[ExecuteInEditMode]
[DisallowMultipleComponent]
public class StretchArm : MonoBehaviour {

    public Transform shoulder;
    public Transform hand;

    private LineRenderer lineRen;

	// Use this for initialization
	void Start () {
        lineRen = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        lineRen.SetPosition(0, shoulder.position);
        lineRen.SetPosition(1, hand.position);
	}
}
