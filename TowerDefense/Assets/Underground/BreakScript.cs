using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System;

public class BreakScript : MonoBehaviour
{
    public GameObject Bank;
    public bool tileMined = false;
    public float timer = 0f;
    public float health = 10f;
    public float c;
    public Material dirt, rock, crystal;
    public GameObject[] adjacent = new GameObject[4];
    public int attempts = 0;
    //add sounds
    public AudioClip breakSound;
    public AudioSource audioSource;
    public GameObject sound;

    // Start is called before the first frame update

    private void Start()
    {
        // Create a new AudioSource and play the clip
        audioSource = gameObject.AddComponent<AudioSource>();
        sound = GameObject.Find("Progression");


        Bank = GameObject.Find("Bank");

        float dirtChance = 0;
        float rockChance = 0;
        float crystalChance = 0;
        float redChance = 0;
        float blueChance = 0;
        float greenChance = 0;
        float yellowChance = 0;
        float purpleChance = 0;
        
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Tower Defense Title"){

        } else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Basic Tower Defense"){
            dirtChance = 30;
            rockChance = 40;
            crystalChance = 30;
            redChance = crystalChance/5;
            blueChance = crystalChance/5;
            greenChance = crystalChance/5;
            yellowChance = crystalChance/5;
            purpleChance = crystalChance/5;
            
        }
        float r = UnityEngine.Random.Range(0,100);
        if (r <= dirtChance)
        {
            this.gameObject.tag = "dirt";
        }
        else if (r <= rockChance+dirtChance)
        {
            this.gameObject.tag = "rock";
        }
        else if (r <= rockChance+dirtChance+redChance)
        {
            this.gameObject.tag = "crystalRed";
        }
        else if (r <= rockChance+dirtChance+redChance+blueChance)
        {
            this.gameObject.tag = "crystalBlue";
        }
        else if (r <= rockChance+dirtChance+redChance+blueChance+greenChance)
        {
            this.gameObject.tag = "crystalGreen";
        }
        else if (r <= rockChance+dirtChance+redChance+blueChance+greenChance+yellowChance)
        {
            this.gameObject.tag = "crystalYellow";
        }
        else if (r <= rockChance+dirtChance+redChance+blueChance+greenChance+yellowChance+purpleChance)
        {
            this.gameObject.tag = "crystalPurple";
        }


        if (this.gameObject.tag == "dirt")
        {
            health = 10f;
            gameObject.GetComponent<Renderer>().material = dirt;
        }

        if (this.gameObject.tag == "rock")
        {
            health = 20f;
            gameObject.GetComponent<Renderer>().material = rock;
        }
        if (this.gameObject.tag == "crystalRed" || this.gameObject.tag == "crystalBlue" || this.gameObject.tag == "crystalGreen" || this.gameObject.tag == "crystalYellow" || this.gameObject.tag == "crystalPurple")
        {
            health = 30f;
            gameObject.GetComponent<Renderer>().material = crystal;
            if (this.gameObject.tag == "crystalRed")
            {
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(1f, 0f, 0f));
            }
            if (this.gameObject.tag == "crystalBlue")
            {
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(0f, 0f, 1f));
            }
            if (this.gameObject.tag == "crystalGreen")
            {
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(0f, 1f, 0f));
            }
            if (this.gameObject.tag == "crystalYellow")
            {
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(1f, 1f, 0f));
            }
            if (this.gameObject.tag == "crystalPurple")
            {
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(1f, 0f, 1f));
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(attempts<100){
            //Debug.Log("triggered");
            //check if adjacent array is full
            if (adjacent[3] == null)
            {
                //check to see if it has a break script
                if (other.gameObject.GetComponent<BreakScript>() != null)
                {
                    //Debug.Log("has break script");
                    //add to adjacent array of gameobjects
                    for (int i = 0; i < adjacent.Length; i++)
                    {
                        if (adjacent.Contains(other.gameObject) == true)
                        {
                            break;
                        }
                        if (adjacent[i] == null)
                        {
                            adjacent[i] = other.gameObject;
                            break;
                        }
                    }

                }
            } else {
            if (!adjacent.Contains(null))
                {
                    //Debug.Log("full");
                    //check if they are all the same type
                    // if ((adjacent[0].tag == adjacent[1].tag) && (adjacent[1].tag == adjacent[2].tag) && (adjacent[2].tag == adjacent[3].tag))
                    // {
                    //     //if they are, set this gameobject to that type
                    //     this.gameObject.tag = adjacent[0].tag;
                    // }
                    //either way set this to be undiscovered
                    this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(-10f, -10f, -10f));
                } else {
                    //if it doesnt have 4 adjacent gameobjects, set this to be discovered
                    this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(1f, 1f, 1f));
                }
            }
            attempts+=1;
        }
    }

    private void OnDisable()
    {
        //for each adjacent gameobject, take this object from its list and change its color to discovered
        for (int i = 0; i < adjacent.Length; i++)
        {
            if (adjacent[i] != null)
            {
                adjacent[i].GetComponent<BreakScript>().adjacent[Array.IndexOf(adjacent[i].GetComponent<BreakScript>().adjacent, this.gameObject)] = null;
                adjacent[i].GetComponent<Renderer>().material.SetColor("_Color", new Color(1f, 1f, 1f));
            }
        }
            if(sound.GetComponent<ToggleSFX>().sfx == true)
            {
                Debug.Log("Broken");
                audioSource.PlayOneShot(laserSound, 0.05f);
            }
    }

    private void FixedUpdate()
    {
        //check if it has 4 adjacent gameobjects
        

        if (tileMined){
            StartCoroutine(Mining(timer+1));
            tileMined = false;
        }
        if (timer>0){
            //break animation
            c = ((health+timer)/(health));
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(c,c,c));
        }
    }
    public IEnumerator Mining(float x)
    {
        //If playerscript finishes its wait time and sends a true
        if (tileMined)
        {
            if (timer==health) {
                float dropChance = UnityEngine.Random.Range(1f, 100f);

                //50% chance of getting dirt or granite
                if (this.gameObject.tag == "dirt")
                {
                    if (dropChance < 101f)
                    {
                        Bank.gameObject.GetComponent<Currencies>().incrementCurrency("dirt", 1);
                    }
                    else
                    {
                        Bank.gameObject.GetComponent<Currencies>().incrementCurrency("granite", 1);
                    }
                }
                //50% chance of getting iron or gold
                if (this.gameObject.tag == "rock")
                {
                    if (dropChance < 30f)
                    {
                        Bank.gameObject.GetComponent<Currencies>().incrementCurrency("iron", 1);
                    }
                    else if (dropChance < 50f)
                    {
                        Bank.gameObject.GetComponent<Currencies>().incrementCurrency("gold", 1);
                    }
                }
                //50% chance of getting gems or orbs
                if (this.gameObject.tag == "crystal")
                {
                    if (dropChance < 50f)
                    {
                        Bank.gameObject.GetComponent<Currencies>().incrementCurrency("gems", 1);
                    }
                    else
                    {
                        Bank.gameObject.GetComponent<Currencies>().incrementCurrency("orbs", 1);
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
