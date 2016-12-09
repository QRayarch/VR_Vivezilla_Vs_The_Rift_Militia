using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

    public int health;
    public int lifeTime;
    private float totalTime = 0;

	// Use this for initialization
	void Start ()
    {

	}

    void Update()
    {
        if (health <= 0)
        {
            totalTime += Time.deltaTime;
            if (totalTime >= lifeTime)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
