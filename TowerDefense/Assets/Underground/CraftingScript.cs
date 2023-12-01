using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CraftingScript : MonoBehaviour
{   
    //public GameObject magicTower, fireTower, turretTower;
    public GameObject Bank, ShortTower, RegularTower, TallTower;
    public bool shortTower = false, regularTower = false, tallTower = false;
    /// <summary>
    /// private int timer = 0;
    /// </summary>
    public GameObject TowerCraft;
    public GameObject TowerCraftBackground;
    // Start is called before the first frame update
    void Start()
    {
        TowerCraft = GameObject.Find("TowerCraft");
        TowerCraft.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Player"){
            TowerCraft.gameObject.SetActive(true);
            TowerCraft.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            TowerCraft.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
        if (other.transform.tag == "Player"){
            TowerCraft.gameObject.SetActive(false);
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
            StartCoroutine(Buy(ShortTower, "dirt", 1, "dirt"));
        } else if (regularTower){
            StartCoroutine(Buy(RegularTower, "dirt", 2, "dirt"));
        } else if (tallTower){
            StartCoroutine(Buy(TallTower, "dirt", 3, "dirt"));
        }
        
        TowerCraft.gameObject.SetActive(false);
        shortTower = false;
        regularTower = false;
        tallTower = false;
        TowerCraft.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        TowerCraft.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
    }
    public void CraftIronTower(){
        if (shortTower){
            StartCoroutine(Buy(ShortTower, "iron", 1, "iron"));
        } else if (regularTower){
            StartCoroutine(Buy(RegularTower, "iron", 2, "iron"));
        } else if (tallTower){
            StartCoroutine(Buy(TallTower, "iron", 3, "iron"));
        }
        TowerCraft.gameObject.SetActive(false);
        shortTower = false;
        regularTower = false;
        tallTower = false;
        TowerCraft.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        TowerCraft.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
    }
    public void CraftGoldTower(){
        if (shortTower){
            StartCoroutine(Buy(ShortTower, "gold", 1, "gold"));
        } else if (regularTower){
            StartCoroutine(Buy(RegularTower, "gold", 2, "gold"));
        } else if (tallTower){
            StartCoroutine(Buy(TallTower, "gold", 3, "gold"));
        }
        TowerCraft.gameObject.SetActive(false);
        shortTower = false;
        regularTower = false;
        tallTower = false;
        TowerCraft.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        TowerCraft.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
    }

    IEnumerator Buy(GameObject product, string resource, int cost, string type = null){  
        //if (number>0){
            Debug.Log("Buying");
            //number=0;
            if (/*Bank.gameObject.GetComponent<Currencies>().incrementCurrency(resource, -cost)*/true){
                product.SetActive(true);
                if (type != null){
                    product.GetComponent<TowerScript>().MaterialType = type;
                }
                Instantiate(product, this.gameObject.transform.position + new Vector3(-2,3,0), Quaternion.identity);
                product.SetActive(false);
            } else {
                Debug.Log("Not enough resources");
            }
        //}
        yield return new WaitForSeconds(2);
        //number=1;
    }

}
