using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (((other.transform.tag=="dirt")||(other.transform.tag=="rock")||(other.transform.tag=="wood"))&&(Input.GetKey(KeyCode.Space))){
            other.gameObject.GetComponent<BreakScript>().tileMined = true;
        }
        // if ((other.gameObject.GetComponent<BreakScript>().tileMined==false)&&(Input.GetKey(KeyCode.Space))){
        //     other.gameObject.GetComponent<BreakScript>().tileMined = true;
        // }
    }
}
