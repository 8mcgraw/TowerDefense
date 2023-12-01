using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CraftingScript : MonoBehaviour
{
    public TMP_Text text, text1;
    //public GameObject magicTower, fireTower, turretTower;
    public GameObject Bank, DeathOrb, FireOrb, IceOrb, ShortTower, RegularTower, TallTower;
    bool orb = false, shortTower = false, regularTower = false, tallTower = false;
    public int number = 1;
    private string t;
    private int timer = 0;
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
            t = "Press 1 to buy an orb. \nPress 2 to buy a short tower.\nPress 3 to buy a normal tower.\nPress 4 to buy a tall tower.\n";
            timer = 0;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            timer++;
            text.text = Bank.gameObject.GetComponent<Currencies>().listCurrencies();
            text1.text = t;
            if (!orb && !shortTower && !regularTower && !tallTower && (timer>20)){
                t = "Press 1 to buy an orb. \nPress 2 to buy a short tower.\nPress 3 to buy a normal tower.\nPress 4 to buy a tall tower.\n";
                if (Input.GetKey(KeyCode.Alpha1)){
                    timer = 0;
                    orb = true;
                    t = "Press 1 to buy a death orb for 1 orb. \nPress 2 to buy a fire orb for 1 gem.\nPress 3 to buy an ice orb for 1 gem.\nPress 4 to return.\n";
                }else if (Input.GetKey(KeyCode.Alpha2)){
                    timer = 0;
                    shortTower = true;
                    t = "Press 1 to buy a wood short tower for 1 dirt. \nPress 2 to buy an iron short tower for 1 iron.\nPress 3 to buy a gold short tower for 1 gold.\nPress 4 to return.\n";
                }else if (Input.GetKey(KeyCode.Alpha3)){
                    timer = 0;
                    regularTower = true;
                    t = "Press 1 to buy a wood regular tower for 1 dirt. \nPress 2 to buy an iron regular tower for 1 iron.\nPress 3 to buy a gold regular tower for 1 gold.\nPress 4 to return.\n";
                }else if (Input.GetKey(KeyCode.Alpha4)){
                    timer = 0;
                    tallTower = true;
                    t = "Press 1 to buy a wood tall tower for 1 dirt. \nPress 2 to buy an iron tall tower for 1 iron.\nPress 3 to buy a gold tall tower for 1 gold.\nPress 4 to return.\n";
                }
            }
            if (orb){
                if (Input.GetKey(KeyCode.Alpha1) && timer>20){
                    timer = 0;
                    StartCoroutine(Buy(DeathOrb, "Orbs", 1));
                } else if (Input.GetKey(KeyCode.Alpha2) && timer>20){
                    timer = 0;
                    StartCoroutine(Buy(FireOrb, "Gems", 1));
                } else if (Input.GetKey(KeyCode.Alpha3) && timer>20){
                    timer = 0;
                    StartCoroutine(Buy(IceOrb, "Gems", 1));
                } else if (Input.GetKey(KeyCode.Alpha4) && timer>20){
                    timer = 0;
                    orb = false;
                }
            } else if (shortTower){
                if (Input.GetKey(KeyCode.Alpha1) && timer>20){
                    timer = 0;
                    StartCoroutine(Buy(ShortTower, "Dirt", 1, "wood"));
                } else if (Input.GetKey(KeyCode.Alpha2) && timer>20){
                    timer = 0;
                    StartCoroutine(Buy(ShortTower, "Iron", 1, "iron"));
                } else if (Input.GetKey(KeyCode.Alpha3) && timer>20){
                    timer = 0;
                    StartCoroutine(Buy(ShortTower, "Gold", 1, "gold"));
                } else if (Input.GetKey(KeyCode.Alpha4) && timer>20){
                    timer = 0;
                    shortTower = false;
                }
            } else if (regularTower){
                if (Input.GetKey(KeyCode.Alpha1) && timer>20){
                    timer = 0;
                    StartCoroutine(Buy(RegularTower, "Dirt", 1, "wood"));
                } else if (Input.GetKey(KeyCode.Alpha2) && timer>20){
                    timer = 0;
                    StartCoroutine(Buy(RegularTower, "Iron", 1, "iron"));
                } else if (Input.GetKey(KeyCode.Alpha3) && timer>20){
                    timer = 0;
                    StartCoroutine(Buy(RegularTower, "Gold", 1, "gold"));
                } else if (Input.GetKey(KeyCode.Alpha4) && timer>20){
                    timer = 0;
                    regularTower = false;
                }

            } else if (tallTower){
                if (Input.GetKey(KeyCode.Alpha1)){
                    timer = 0;
                    StartCoroutine(Buy(TallTower, "Dirt", 1, "wood"));
                } else if (Input.GetKey(KeyCode.Alpha2) && timer>20){
                    timer = 0;
                    StartCoroutine(Buy(TallTower, "Iron", 1, "iron"));
                } else if (Input.GetKey(KeyCode.Alpha3) && timer>20){
                    timer = 0;
                    StartCoroutine(Buy(TallTower, "Gold", 1, "gold"));
                } else if (Input.GetKey(KeyCode.Alpha4) && timer>20){
                    timer = 0;
                    tallTower = false;
                }

            }
        }
    }

    public IEnumerator Buy(GameObject product, string resource, int cost, string type = null){
        if (number>0){
            Debug.Log("Buying");
            number=0;
            if (/*Bank.gameObject.GetComponent<Currencies>().incrementCurrency(resource, -cost)*/true){
                t += "Success!\n";
                product.SetActive(true);
                if (type != null){
                    product.GetComponent<TowerScript>().MaterialType = type;
                }
                Instantiate(product, this.gameObject.transform.position + new Vector3(-2,3,0), Quaternion.identity);
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
        orb = false;
        shortTower = false;
        regularTower = false;
        tallTower = false;
    }
}
