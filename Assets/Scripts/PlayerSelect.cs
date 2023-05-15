using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{

    public Camera theCamera;
    public float hitDistance = 20f;
    public Transform inventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = theCamera.ScreenPointToRay(Input.mousePosition);
        
        //This is for picking stuff up to check what option i took.

        int layer = 1 << 6;

        if (Physics.Raycast(ray, out hit,hitDistance,layer))
        {
            Transform objectHit = hit.transform;
            Debug.Log("hit " + objectHit.name);

            if(objectHit.tag == "A_pick" && Input.GetMouseButtonDown(0))
            {
                objectHit.parent = inventory;
                objectHit.gameObject.SetActive(false);
                //Must disable B_pick option
            }

            if (objectHit.tag == "B_pick" && Input.GetMouseButtonDown(0))
            {
                objectHit.parent = inventory;
                objectHit.gameObject.SetActive(false);
                //Must disable A_pick option
            }

            // Do something with the object that was hit by the raycast.
        }
    }
}
