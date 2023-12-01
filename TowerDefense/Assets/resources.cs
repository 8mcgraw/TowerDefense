using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resources : MonoBehaviour
{
    public GameObject Bank;
    public GameObject resourcesBackground;
    public IDictionary<string, int> currencies = new Dictionary<string, int>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(resourcesBackground == null){
            resourcesBackground = GameObject.Find("ResourcesBackground");
        }
        if (Bank == null){
            if (GameObject.Find("/Bank") != null)
            {
                Bank = GameObject.Find("/Bank");
            }
            resourcesBackground.SetActive(false);
        } else {
            resourcesBackground.SetActive(true);
           // Debug.Log("Bank");
            if (Bank.GetComponent<Currencies>().updated==true){
                Bank.GetComponent<Currencies>().updated = false;
                Debug.Log("BankUpdate");
                currencies = Bank.GetComponent<Currencies>().currencies;
                BankUpdate();
            }
        }
        //for each resourcesBackground child, if the dictionary contains its name, enable it
        
    }
    //allow bank to update this script
    void BankUpdate(){
        foreach (Transform child in resourcesBackground.transform)
        {
            //Debug.Log(child.name);
            if (currencies.ContainsKey(child.name))
            {
                child.gameObject.SetActive(true);
                child.gameObject.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = currencies[child.name].ToString();
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
