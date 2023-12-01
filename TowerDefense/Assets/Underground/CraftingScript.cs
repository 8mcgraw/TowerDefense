using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CraftingScript : MonoBehaviour
{
    public TMP_Text text, text1;
    //public GameObject magicTower, fireTower, turretTower;
    public GameObject Bank, DeathOrb, FireOrb, IceOrb, ShortTower, RegularTower, TallTower;
    bool shortTower = false, regularTower = false, tallTower = false;
    public int number = 1;
    private string t;
    /// <summary>
    /// private int timer = 0;
    /// </summary>
    public GameObject TowerCraft;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TowerCraft == null){
            TowerCraft = GameObject.Find("TowerCraft");
        } 
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Player"){
            TowerCraft.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
        if (other.transform.tag == "Player"){
            TowerCraft.transform.GetChild(0).gameObject.SetActive(false);
        }
        shortTower = false;
        regularTower = false;
        tallTower = false;
        TowerCraft.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        TowerCraft.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
    }
    public void CraftShortTower(){
        shortTower = true;
        regularTower = false;
        tallTower = false;
        TowerCraft.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
        TowerCraft.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
    }
    public void CraftregularTower(){
        shortTower = false;
        regularTower = true;
        tallTower = false;
        TowerCraft.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
        TowerCraft.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
    }
    public void CraftTallTower(){
        shortTower = false;
        regularTower = false;
        tallTower = true;
        TowerCraft.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
        TowerCraft.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
    }
    public void CraftDirtTower(){
        if (shortTower){
            StartCoroutine(Buy(ShortTower, "dirt", 1));
        } else if (regularTower){
            StartCoroutine(Buy(RegularTower, "dirt", 2));
        } else if (tallTower){
            StartCoroutine(Buy(TallTower, "dirt", 3));
        }
    }
    public void CraftIronTower(){
        if (shortTower){
            StartCoroutine(Buy(ShortTower, "iron", 1));
        } else if (regularTower){
            StartCoroutine(Buy(RegularTower, "iron", 2));
        } else if (tallTower){
            StartCoroutine(Buy(TallTower, "iron", 3));
        }
    }
    public void CraftGoldTower(){
        if (shortTower){
            StartCoroutine(Buy(ShortTower, "gold", 1));
        } else if (regularTower){
            StartCoroutine(Buy(RegularTower, "gold", 2));
        } else if (tallTower){
            StartCoroutine(Buy(TallTower, "gold", 3));
        }
    }

    public IEnumerator Buy(GameObject product, string resource, int cost, string type = null){
        //if (number>0){
            Debug.Log("Buying");
            //number=0;
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
        //}
        //yield return new WaitForSeconds(2);
        //number=1;
        return;
    }

}
