using UnityEngine;
using System.Collections;

public class MountPivot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    public void Rotate(float lR)
    {
        lR *= 10;
        if (lR > 0.5f || lR < -0.5f)
        {
            transform.Rotate(0, lR, 0);
        }
    }
}
