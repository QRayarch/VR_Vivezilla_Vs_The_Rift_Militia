using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GunStuff : NetworkBehaviour {

    public GameObject bullet;
    public float fireRate = 0.1f;
    public float speed = 10000;
    public Transform forward;
    public float destroyBulletAfterTime = 3;
    public float acc = 0.01f;
    public Collider ignored;
    public bool doScale = true;
    public int maxAmmo = 1000;

    [SyncVar]
    private float bulletTimer = 0;

    [SyncVar]
    private int ammo;
    [SyncVar]
    public bool doesUseAmmo = false;

    [SyncVar]
    public float damage = 1;

    void Reset()
    {
        forward = transform;
    }

    void Start()
    {

    }

    [Command]
    public void CmdFireBullet() {
        if (doesUseAmmo && ammo <= 0) return;
        if(bulletTimer >= fireRate)
        {
            GameObject temp = ((GameObject)Instantiate(bullet, forward.position + (forward.forward), Quaternion.identity));
            if(doScale)
            {
                temp.transform.localScale *= damage;
            }
            Rigidbody rb = temp.GetComponent<Rigidbody>();
            rb.AddForce((forward.forward + Random.insideUnitSphere * acc).normalized * speed);
            Physics.IgnoreCollision(ignored, rb.GetComponent<Collider>());
            NetworkServer.Spawn(rb.gameObject);
            Destroy(rb.gameObject, destroyBulletAfterTime);

            bulletTimer = 0;
            ammo -= 1;
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

    public void GiveAmmo(int a)
    {
        ammo = Mathf.Clamp(ammo + a, 0, maxAmmo);
    }

    public float NormalizedAmmo
    {
        get { return (float)ammo / maxAmmo; }
    }
}
