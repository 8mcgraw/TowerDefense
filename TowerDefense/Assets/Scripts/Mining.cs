using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : MonoBehaviour
{
    public float miningTimer = 0;
    public bool canMine = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        if (miningTimer > 2)
        {
            canMine = true;
        } else {
            miningTimer++;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (((other.transform.tag=="dirt")||(other.transform.tag=="rock")||(other.transform.tag=="wood")||(other.transform.tag=="crystalRed")||(other.transform.tag=="crystalBlue")||(other.transform.tag=="crystalGreen")||(other.transform.tag=="crystalYellow")||(other.transform.tag=="crystalPurple"))&&(Input.GetKey(KeyCode.Space))&&(canMine==true)){
            other.gameObject.GetComponent<BreakScript>().tileMined = true;
            canMine=false;
            miningTimer = 0;
        }
        // if ((other.gameObject.GetComponent<BreakScript>().tileMined==false)&&(Input.GetKey(KeyCode.Space))){
        //     other.gameObject.GetComponent<BreakScript>().tileMined = true;
        // }
    }
}
