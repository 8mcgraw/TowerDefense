using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilemapRender : MonoBehaviour
{
    //public GameObject point;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //BUGGY RAYCAST. Meant to track which block the player clicks to mine, and which blocks should render that the player approaches
    private void FixedUpdate()
    {
        //Aim from the screen (camera) to the collider the player is looking at
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, 10))
        {
            print("There is something in front of the player!");
            if (hit.collider != null) {
                GameObject target = hit.collider.gameObject;
                target.SetActive(true);
            }
        }
        //// Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 7;//only hit the underground layer

        //// Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
    }
}
