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
    public float timer = 0f;
    public float health = 10f;
    public GameObject meshObject;
    public float c;

    private void Start()
    {
        meshObject = this.gameObject;
        if (this.gameObject.transform.childCount > 0){
            meshObject = this.gameObject.transform.GetChild(0).gameObject;
        }
        if (this.gameObject.tag == "dirt")
        {
            health = 10f;
        }
        if (this.gameObject.tag == "rock")
        {
            health = 20f;
        }
        if (this.gameObject.tag == "crystal")
        {
            health = 30f;
        }
    }

    private void FixedUpdate()
    {
        if (tileMined){
            StartCoroutine(Mining(timer+1));
            tileMined = false;
        }
        if (timer>0){
            //break animation
            c = ((health-timer)/health);
            meshObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(c,c,c));
        }
    }
    public IEnumerator Mining(float x)
    {
        //If playerscript finishes its wait time and sends a true
        if (tileMined)
        {
            if (timer==health) {
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
            yield return new WaitForSeconds(0.1f);
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
