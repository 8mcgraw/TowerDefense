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
    public GameObject Prompt, text;
    public bool close = false;
    /// <summary>
    /// private int timer = 0;
    /// </summary>
    public GameObject TowerCraft;
    public GameObject TowerCraftBackground;
    // Start is called before the first frame update
    void Start()
    {
    }    
    void Update()
    {
        //if towercraft child 0, child 0 is active, press 1 to craft short tower, 2 for regular, 3 for tall
        if ((TowerCraft.transform.GetChild(0).transform.GetChild(0).gameObject.activeSelf)&&(close)){
            if (Input.GetKeyDown(KeyCode.Alpha1)){
                CraftShortTower();
            } else if (Input.GetKeyDown(KeyCode.Alpha2)){
                CraftregularTower();
            } else if (Input.GetKeyDown(KeyCode.Alpha3)){
                CraftTallTower();
            }
        } else if ((TowerCraft.transform.GetChild(0).transform.GetChild(1).gameObject.activeSelf)&&(close)){
            if (Input.GetKeyDown(KeyCode.Alpha1)){
                CraftDirtTower();
            } else if (Input.GetKeyDown(KeyCode.Alpha2)){
                CraftIronTower();
            } else if (Input.GetKeyDown(KeyCode.Alpha3)){
                CraftGoldTower();
            }
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Player"){
            close = true;
            TowerCraft.gameObject.SetActive(true);
            TowerCraft.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            TowerCraft.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
        if (other.transform.tag == "Player"){
            close = false;
            TowerCraft.gameObject.SetActive(false);
        }
        shortTower = false;
        regularTower = false;
        tallTower = false;
        TowerCraft.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        TowerCraft.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
        Prompt.SetActive(false);
        text.SetActive(false);
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
            if (Bank.gameObject.GetComponent<Currencies>().incrementCurrency(resource, -cost)){
                product.SetActive(true);
                if (type != null){
                    product.GetComponent<TowerScript>().MaterialType = type;
                }
                Instantiate(product, this.gameObject.transform.position + new Vector3(-2,2,0), Quaternion.identity);
                product.SetActive(false);
            } else {
                Debug.Log("Not enough resources");
                Prompt.SetActive(true);
                text.SetActive(true);
            }
        //}
        yield return new WaitForSeconds(2);
        //number=1;
    }

}
