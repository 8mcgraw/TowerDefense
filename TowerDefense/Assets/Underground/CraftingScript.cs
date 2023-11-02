using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CraftingScript : MonoBehaviour
{
    public TMP_Text text, text1;
    //public GameObject magicTower, fireTower, turretTower;
    public GameObject Bank, Orb, Tower;
    public int number = 1;
    private string t;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Player"){
            t = "Press 1 to buy an orb for 1 Orb. \nPress 2 to buy a tower for 1 Granite.\n";
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
        text1.text = t;
        if (Input.GetKey(KeyCode.Alpha1)){
            StartCoroutine (Buy(Orb, "Orbs", 1));
            Debug.Log("Trying");
            //If they have enough to craft it
            //This code may need to go in the crafting bank as that's where the different types of resources were added
            //if ((Bank.gameObject.GetComponent<Currencies>().checkCurrency("Orbs")>0 )&&( Bank.gameObject.GetComponent<Currencies>().checkCurrency("Granite")>0))
            //{
                //if (Bank.gameObject.GetComponent<Currencies>().incrementCurrency("Orbs", -1) && Bank.gameObject.GetComponent<Currencies>().incrementCurrency("Granite", -1)){
            
        }
        if (Input.GetKey(KeyCode.Alpha2)){
            StartCoroutine (Buy(Tower, "Granite", 1));
            Debug.Log("Trying");
        }
            text.text = Bank.gameObject.GetComponent<Currencies>().listCurrencies();
        }
    }

    public IEnumerator Buy(GameObject product, string resource, int cost){
        if (number>0){
            Debug.Log("Buying");
            number=0;
            if (Bank.gameObject.GetComponent<Currencies>().incrementCurrency(resource, -cost)){
                t += "Success!\n";
                product.SetActive(true);
                Instantiate(product, new Vector3(0,2,0), Quaternion.identity);
                product.SetActive(false);
            } else {
                t += "You don't have enough resources to craft this\n";
            }
        }
        yield return new WaitForSeconds(2);
        number=1;
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.transform.tag == "Player"){
            text1.text = "";
        }
    }
}
