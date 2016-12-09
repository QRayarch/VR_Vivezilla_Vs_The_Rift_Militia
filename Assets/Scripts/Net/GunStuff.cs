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

    [SyncVar]
    public float damage = 1;

    void Reset()
    {
        forward = transform;
    }

    [Command]
    public void CmdFireBullet() {
        
        if(bulletTimer >= fireRate)
        {
            GameObject temp = ((GameObject)Instantiate(bullet, forward.position + (forward.forward), Quaternion.identity));
            temp.transform.localScale  *= damage;
            Rigidbody rb = temp.GetComponent<Rigidbody>();
            rb.AddForce((forward.forward + Random.insideUnitSphere * 0.01f).normalized * speed);
            NetworkServer.Spawn(rb.gameObject);
            Destroy(rb.gameObject, 3.0f);

            bulletTimer = 0;
        }
    }

    public void damageIncrement() { damage += 1; }

    void Update()
    {
        bulletTimer += Time.deltaTime;
    }

    public float NormalizedShootTime
    {
        get { return Mathf.Clamp(bulletTimer / fireRate, 0, 1); }
    }
}
