using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

    public int health;
    public int lifeTime;
    private float totalTime = 0;
    private float shrinkTime = 0;
    private bool destroy = false;
    private bool isRunning = false;
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

                for (int c = 0; c < transform.childCount; ++c)
                {
                    transform.GetChild(c).localScale /= (2 * Time.deltaTime);
                }
                if (!isRunning)
                {
                    isRunning = true;
                    StartCoroutine(ShrinkAndBoom());
                }
                if(destroy)
                {
                   // Destroy(this.gameObject);
                }   
            }
        }
    }

    IEnumerator ShrinkAndBoom()
    {
        yield return new WaitForSeconds(3);
        destroy = true;
    }
}
