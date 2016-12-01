using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GunStuff : NetworkBehaviour {

    public GameObject bullet;
    public float fireRate = 0.1f;
    public float speed = 10000;
    public Transform forward;

    [SyncVar]
    private float bulletTimer = 0;

    void Reset()
    {
        forward = transform;
    }

    [Command]
    public void CmdFireBullet() {
        
        if(bulletTimer >= fireRate)
        {
            Rigidbody rb = ((GameObject)Instantiate(bullet, forward.position + (forward.forward), Quaternion.identity)).GetComponent<Rigidbody>();
            rb.AddForce((forward.forward + Random.insideUnitSphere * 0.01f).normalized * speed);
            NetworkServer.Spawn(rb.gameObject);
            Destroy(rb.gameObject, 3.0f);

            bulletTimer = 0;
        }
    }

    void Update()
    {
        bulletTimer += Time.deltaTime;
    }

    public float NormalizedShootTime
    {
        get { return Mathf.Clamp(bulletTimer / fireRate, 0, 1); }
    }
}
