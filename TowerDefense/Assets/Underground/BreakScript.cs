using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class BreakScript : MonoBehaviour
{
    public TMPro.TMP_Text text, text1;
    public GameObject broken, Currencies;
    public bool tileMined = false;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        //If playerscript finishes its wait time and sends a true
        if (tileMined)
        {

            float dropChance = Random.Range(1f, 100f);

            //50% chance of getting dirt or granite
            if (broken.tag == "dirt")
            {
                if (dropChance < 50f)
                {
                    GetComponent<Currencies>().addToCurrencies("Dirt", 1);
                    text.text = GetComponent<Currencies>().listCurrencies();
                }
                else
                {
                    GetComponent<Currencies>().incrementCurrency("Granite", 1);
                    text.text = GetComponent<Currencies>().listCurrencies();
                }
            }
            //50% chance of getting iron or gold
            if (broken.tag == "rock")
            {
                if (dropChance < 50f)
                {
                    GetComponent<Currencies>().addToCurrencies("Iron", 1);
                    text.text = GetComponent<Currencies>().listCurrencies();
                }
                else
                {
                    GetComponent<Currencies>().incrementCurrency("Gold", 1);
                    text.text = GetComponent<Currencies>().listCurrencies();
                }
            }
            //50% chance of getting wood or orbs
            if (broken.tag == "wood")
            {
                if (dropChance < 50f)
                {
                    GetComponent<Currencies>().addToCurrencies("Wood", 1);
                    text.text = GetComponent<Currencies>().listCurrencies();
                }
                else
                {
                    GetComponent<Currencies>().incrementCurrency("Orbs", 1);
                    text.text = GetComponent<Currencies>().listCurrencies();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (tag == "Player")
        {
            this.gameObject.SetActive(true);
        }
    }
}
