using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CraftingScript : MonoBehaviour
{
    public TMP_Text text, text1;
    //public GameObject magicTower, fireTower, turretTower;
    public GameObject Currencies;
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
        text1.text = "Press 1 for Magic Tower = 1 Orb + 1 rock \n ";
        if (Input.GetKey(KeyCode.Alpha1))
        {
            //If they have enough to craft it
            //This code may need to go in the crafting bank as that's where the different types of resources were added
            if (GetComponent<Currencies>().incrementCurrency("Orbs", 1) && GetComponent<Currencies>().incrementCurrency("Granite", 1))
            {
                //Give the player the tower part
                //Instantiate(magicTower, other.transform);
            }
            
        }
    }
}
