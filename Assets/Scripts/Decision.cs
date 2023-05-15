using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NPC" )
        {
            Debug.Log(other.name + " triggered");
            //ShopKeeper and NPC is the same.
            ShopKeeper npc = other.transform.GetComponent<ShopKeeper>();

            if(transform.childCount > 0)
            {
                int which = Random.Range(0, transform.childCount);
                npc.setTarget(transform.GetChild(which));
                transform.GetChild(which).gameObject.SetActive(true);
            }

        }
    }
}
