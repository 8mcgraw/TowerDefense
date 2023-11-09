using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class BreakScript : MonoBehaviour
{
    public TMPro.TMP_Text text, text1;
    public GameObject Bank;
    public bool tileMined = false;
    public int timer = 0;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        if (tileMined){
            StartCoroutine(Mining(timer+1));
            tileMined = false;
        }
    }
    public IEnumerator Mining(int x)
    {
        //If playerscript finishes its wait time and sends a true
        if (tileMined)
        {
            if (timer==1) {
                float dropChance = Random.Range(1f, 100f);

                //50% chance of getting dirt or granite
                if (this.gameObject.tag == "dirt")
                {
                    if (dropChance < 50f)
                    {
                        Bank.gameObject.GetComponent<Currencies>().incrementCurrency("Dirt", 1);
                        text.text = Bank.gameObject.GetComponent<Currencies>().listCurrencies();
                    }
                    else
                    {
                        Bank.gameObject.GetComponent<Currencies>().incrementCurrency("Granite", 1);
                        text.text = Bank.gameObject.GetComponent<Currencies>().listCurrencies();
                    }
                }
                //50% chance of getting iron or gold
                if (this.gameObject.tag == "rock")
                {
                    if (dropChance < 50f)
                    {
                        Bank.gameObject.GetComponent<Currencies>().incrementCurrency("Iron", 1);
                        text.text = Bank.gameObject.GetComponent<Currencies>().listCurrencies();
                    }
                    else
                    {
                        Bank.gameObject.GetComponent<Currencies>().incrementCurrency("Gold", 1);
                        text.text = Bank.gameObject.GetComponent<Currencies>().listCurrencies();
                    }
                }
                //50% chance of getting gems or orbs
                if (this.gameObject.tag == "crystal")
                {
                    if (dropChance < 50f)
                    {
                        Bank.gameObject.GetComponent<Currencies>().incrementCurrency("Gems", 1);
                        text.text = Bank.gameObject.GetComponent<Currencies>().listCurrencies();
                    }
                    else
                    {
                        Bank.gameObject.GetComponent<Currencies>().incrementCurrency("Orbs", 1);
                        text.text = Bank.gameObject.GetComponent<Currencies>().listCurrencies();
                    }
                }
                this.gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(1);
            timer=x;
            tileMined = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //this.gameObject.SetActive(true);
        }
    }
}
