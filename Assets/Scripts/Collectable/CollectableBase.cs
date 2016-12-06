using UnityEngine;
using System.Collections;

public class CollectableBase : MonoBehaviour {
    int identity;

    void OnCollisionEnter(Collider col)
    {
        PlayerSelector player= col.gameObject.transform.root.GetComponent<PlayerSelector>();
        if((int)player.GetMode() == 2)
        {
            if(identity == 2){
                doTask(player);
            }
        } else if((int)player.GetMode() == 3 && 3 == identity){
            if(identity == 3){
                doTask(player);
            }
        }
    }

    public virtual void doTask(PlayerSelector p) { }
}
