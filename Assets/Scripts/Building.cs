using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

    public int health;
    public int lifeTime;
    private float totalTime = 0;
    private float shrinkTime = 0;
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
                int count = 0;
                for (int c = 0; c < transform.childCount; ++c)
                {
                    if(transform.GetChild(c).localScale.magnitude >= 0.05f)
                    {
                        transform.GetChild(c).localScale /= (1.01f);
                    } else
                    {
                        count++;
                    }

                }
 
                if(count == transform.childCount)
                {
                   Destroy(this.gameObject);
                }   
            }
        }
    }
}
