using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class craftingBank : MonoBehaviour
{
    public GameObject Currencies;
    int dirt = 0;//TESTING DIRT RIGHT GNORW
    int granite = 0, sandstone = 0, obsidian = 0, wood = 0, orbs = 0, iron = 0, gold = 0, copper = 0, gems = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Currencies>().addToCurrencies("Dirt", dirt);
        GetComponent<Currencies>().addToCurrencies("Granite", granite);
        GetComponent<Currencies>().addToCurrencies("Sandstone", sandstone);
        GetComponent<Currencies>().addToCurrencies("Obsidian", obsidian);
        GetComponent<Currencies>().addToCurrencies("Wood", wood);
        GetComponent<Currencies>().addToCurrencies("Orbs", orbs);
        GetComponent<Currencies>().addToCurrencies("Iron", iron);
        GetComponent<Currencies>().addToCurrencies("Gold", gold);
        GetComponent<Currencies>().addToCurrencies("Copper", copper);
        GetComponent<Currencies>().addToCurrencies("Gems", gems);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
