using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currencies : MonoBehaviour
{
    public bool updated = false;
    //All currencies will go in this dictionary.
    public IDictionary<string, int> currencies = new Dictionary<string, int>();

    //You CAN use this to create new currencies, but you can also just increment them
    public void addToCurrencies(string name, int amount)
    {
        currencies.Add(name, amount);
    }

    void Start()
    {
    }

    //If you want to add currency, use this, if you want to deduct: use this in an if()else
    //where the else tells the player they dont have enough

    public bool incrementCurrency(string name, int amount)
    {
        updated = true;
        Debug.Log("Incrementing " + name + " by " + amount);
        if (currencies.ContainsKey(name))
        {
            if ((currencies[name] + amount) > -1)
            {
                currencies[name] = currencies[name] + amount;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (amount > -1)
            {
                addToCurrencies(name, amount);
                return true;
            }
            else
            {
                return false;
            }
        }
    }


    //Can be used to return currency ammount
    public int checkCurrency(string name)
    {
        if (currencies.ContainsKey(name))
        {
            return currencies[name];
        }
        else
        {
            return 0;
        }
    }


    //Use for your textmeshpro that shows the player's currencies
    public string listCurrencies()
    {
        string output = "";
        foreach (KeyValuePair<string, int> currency in currencies)
        {
            output = output + currency.Key + ": " + currency.Value + "\n";
        }
        return output;
    }
}
