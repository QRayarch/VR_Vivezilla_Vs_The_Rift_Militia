using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour {

    //public float dmg = 10;
    
    void OnTriggerEnter(Collider c)
    {
        if (gameObject.CompareTag("MainBuilding"))
        {
            Destroy(gameObject);
            return;
        }

        GameObject t = c.gameObject;
        while (t.transform.parent != null)
        {
            t = t.transform.parent.gameObject;
        }
        Health h = t.gameObject.GetComponent<Health>();
        if(h != null)
        {
            h.Damage(transform.localScale.x);
        }
        Destroy(gameObject);
    }
}
