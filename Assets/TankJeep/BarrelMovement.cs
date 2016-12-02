using UnityEngine;
using System.Collections;

public class BarrelMovement : MonoBehaviour {
	
    public GameObject firePos;
    public GameObject bullet;
    public float fireRate;

    bool canFire = true;

    IEnumerator fireCoolDown() {
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }

	// Update is called once per frame
	void Update () {
        float uD = Input.GetAxis("Right Stick Y") * 10;

        if(uD > 0.5f || uD < -0.5f) {
            transform.Rotate(uD,0,0);
        }

        if(Input.GetButton("Fire1") && canFire) {
            Rigidbody temp = ((GameObject)Instantiate(bullet,firePos.transform.position,Quaternion.identity)).GetComponent<Rigidbody>();
            temp.velocity = firePos.transform.forward * 100;
            canFire = false;
            StartCoroutine(fireCoolDown());
        }
	}
}
