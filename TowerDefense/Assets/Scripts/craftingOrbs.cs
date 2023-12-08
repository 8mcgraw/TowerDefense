using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class craftingOrbs : MonoBehaviour
{
    public string[] orbCombination = new string[3];
    public GameObject MasterOrb;
    public GameObject[] crystalDust = new GameObject[9];
    public GameObject[] Highlight = new GameObject[3];
    public GameObject OrbCraft;
    public GameObject text, notEnoughText;
    public GameObject Bank;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((orbCombination.Length == 3) && ((orbCombination[0] != "") && (orbCombination[1] != "") && (orbCombination[2] != "")))
        {
            text.SetActive(true);
        }
        else
        {
            text.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            OrbCraft.gameObject.SetActive(true);
        }
        notEnoughText.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            OrbCraft.gameObject.SetActive(false);
        }
        notEnoughText.SetActive(false);
    }
    public void finalize()
    {
        //make tuple array of resource: string and int
        
        if (orbCombination[0] == "ice"){
            if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                notEnoughText.SetActive(true);
                return;
            }
            MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[0] = "ice";
                    if(orbCombination[1] == "ice"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>1)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "ice";
                                            if(orbCombination[2] == "ice"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>2)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "ice";
                                            } else if (orbCombination[2] == "fire"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "fire";
                                            } else if (orbCombination[2] == "death"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "death";
                                            } else if (orbCombination[2] == "holy"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "holy";
                                            } else if (orbCombination[2] == "nature"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "nature";
                                            }
                    } else if (orbCombination[1] == "fire"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "fire";
                                            if(orbCombination[2] == "ice"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "ice";
                                            } else if (orbCombination[2] == "fire"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "fire";
                                            } else if (orbCombination[2] == "death"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "death";
                                            } else if (orbCombination[2] == "holy"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "holy";
                                            } else if (orbCombination[2] == "nature"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "nature";
                                            }
                    } else if (orbCombination[1] == "death"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "death";
                                            if(orbCombination[2] == "ice"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "ice";
                                            } else if (orbCombination[2] == "fire"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "fire";
                                            } else if (orbCombination[2] == "death"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "death";
                                            } else if (orbCombination[2] == "holy"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "holy";
                                            } else if (orbCombination[2] == "nature"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "nature";
                                            }
                    } else if (orbCombination[1] == "holy"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "holy";
                                            if(orbCombination[2] == "ice"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "ice";
                                            } else if (orbCombination[2] == "fire"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "fire";
                                            } else if (orbCombination[2] == "death"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "death";
                                            } else if (orbCombination[2] == "holy"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "holy";
                                            } else if (orbCombination[2] == "nature"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "nature";
                                            }
                    } else if (orbCombination[1] == "nature"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "nature";
                                            if(orbCombination[2] == "ice"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "ice";
                                            } else if (orbCombination[2] == "fire"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "fire";
                                            } else if (orbCombination[2] == "death"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "death";
                                            } else if (orbCombination[2] == "holy"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "holy";
                                            } else if (orbCombination[2] == "nature"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "nature";
                                            }
                    }
        } else if (orbCombination[0] == "fire"){
            if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                notEnoughText.SetActive(true);
                return;
            }
            MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[0] = "fire";
                    if(orbCombination[1] == "ice"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "ice";
                                            if(orbCombination[2] == "ice"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "ice";
                                            } else if (orbCombination[2] == "fire"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "fire";
                                            } else if (orbCombination[2] == "death"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "death";
                                            } else if (orbCombination[2] == "holy"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "holy";
                                            } else if (orbCombination[2] == "nature"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "nature";
                                            }
                    } else if (orbCombination[1] == "fire"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>1)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "fire";
                                            if(orbCombination[2] == "ice"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "ice";
                                            } else if (orbCombination[2] == "fire"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>2)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "fire";
                                            } else if (orbCombination[2] == "death"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "death";
                                            } else if (orbCombination[2] == "holy"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "holy";
                                            } else if (orbCombination[2] == "nature"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "nature";
                                            }
                    } else if (orbCombination[1] == "death"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "death";
                                            if(orbCombination[2] == "ice"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "ice";
                                            } else if (orbCombination[2] == "fire"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "fire";
                                            } else if (orbCombination[2] == "death"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "death";
                                            } else if (orbCombination[2] == "holy"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "holy";
                                            } else if (orbCombination[2] == "nature"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "nature";
                                            }
                    } else if (orbCombination[1] == "holy"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "holy";
                                            if(orbCombination[2] == "ice"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "ice";
                                            } else if (orbCombination[2] == "fire"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "fire";
                                            } else if (orbCombination[2] == "death"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "death";
                                            } else if (orbCombination[2] == "holy"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "holy";
                                            } else if (orbCombination[2] == "nature"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "nature";
                                            }
                    } else if (orbCombination[1] == "nature"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "nature";
                                            if(orbCombination[2] == "ice"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "ice";
                                            } else if (orbCombination[2] == "fire"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "fire";
                                            } else if (orbCombination[2] == "death"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "death";
                                            } else if (orbCombination[2] == "holy"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "holy";
                                            } else if (orbCombination[2] == "nature"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "nature";
                                            }
                    } 
        } else if (orbCombination[0] == "death"){
            if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                notEnoughText.SetActive(true);
                return;
            }
            MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[0] = "death";
                    if(orbCombination[1] == "ice"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "ice";
                                            if(orbCombination[2] == "ice"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "ice";
                                            } else if (orbCombination[2] == "fire"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "fire";
                                            } else if (orbCombination[2] == "death"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "death";
                                            } else if (orbCombination[2] == "holy"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "holy";
                                            } else if (orbCombination[2] == "nature"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "nature";
                                            }
                    } else if (orbCombination[1] == "fire"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "fire";
                                            if(orbCombination[2] == "ice"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "ice";
                                            } else if (orbCombination[2] == "fire"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "fire";
                                            } else if (orbCombination[2] == "death"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "death";
                                            } else if (orbCombination[2] == "holy"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "holy";
                                            } else if (orbCombination[2] == "nature"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "nature";
                                            }
                    } else if (orbCombination[1] == "death"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>1)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "death";
                                            if(orbCombination[2] == "ice"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "ice";
                                            } else if (orbCombination[2] == "fire"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "fire";
                                            } else if (orbCombination[2] == "death"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>2)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "death";
                                            } else if (orbCombination[2] == "holy"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "holy";
                                            } else if (orbCombination[2] == "nature"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "nature";
                                            }
                    } else if (orbCombination[1] == "holy"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "holy";
                                            if(orbCombination[2] == "ice"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "ice";
                                            } else if (orbCombination[2] == "fire"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "fire";
                                            } else if (orbCombination[2] == "death"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "death";
                                            } else if (orbCombination[2] == "holy"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "holy";
                                            } else if (orbCombination[2] == "nature"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "nature";
                                            }
                    } else if (orbCombination[1] == "nature"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "nature";
                                            if(orbCombination[2] == "ice"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "ice";
                                            } else if (orbCombination[2] == "fire"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "fire";
                                            } else if (orbCombination[2] == "death"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "death";
                                            } else if (orbCombination[2] == "holy"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "holy";
                                            } else if (orbCombination[2] == "nature"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "nature";
                                            }
                    }
        } else if (orbCombination[0] == "holy"){
            if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                notEnoughText.SetActive(true);
                return;
            }
            MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[0] = "holy";
                    if(orbCombination[1] == "ice"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "ice";
                                            if(orbCombination[2] == "ice"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "ice";
                                            } else if (orbCombination[2] == "fire"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "fire";
                                            } else if (orbCombination[2] == "death"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "death";
                                            } else if (orbCombination[2] == "holy"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "holy";
                                            } else if (orbCombination[2] == "nature"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "nature";
                                            }
                    } else if (orbCombination[1] == "fire"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "fire";
                                            if(orbCombination[2] == "ice"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "ice";
                                            } else if (orbCombination[2] == "fire"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "fire";
                                            } else if (orbCombination[2] == "death"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "death";
                                            } else if (orbCombination[2] == "holy"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "holy";
                                            } else if (orbCombination[2] == "nature"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "nature";
                                            }
                    } else if (orbCombination[1] == "death"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "death";
                                            if(orbCombination[2] == "ice"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "ice";
                                            } else if (orbCombination[2] == "fire"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "fire";
                                            } else if (orbCombination[2] == "death"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "death";
                                            } else if (orbCombination[2] == "holy"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "holy";
                                            } else if (orbCombination[2] == "nature"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "nature";
                                            }
                    } else if (orbCombination[1] == "holy"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>1)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "holy";
                                            if(orbCombination[2] == "ice"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "ice";
                                            } else if (orbCombination[2] == "fire"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "fire";
                                            } else if (orbCombination[2] == "death"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "death";
                                            } else if (orbCombination[2] == "holy"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>2)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "holy";
                                            } else if (orbCombination[2] == "nature"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "nature";
                                            }
                    } else if (orbCombination[1] == "nature"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "nature";
                                            if(orbCombination[2] == "ice"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "ice";
                                            } else if (orbCombination[2] == "fire"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "fire";
                                            } else if (orbCombination[2] == "death"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "death";
                                            } else if (orbCombination[2] == "holy"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "holy";
                                            } else if (orbCombination[2] == "nature"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "nature";
                                            }
                    }
        } else if (orbCombination[0] == "nature"){
            if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                notEnoughText.SetActive(true);
                return;
            }
            MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[0] = "nature";
                    if(orbCombination[1] == "ice"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "ice";
                                            if(orbCombination[2] == "ice"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "ice";
                                            } else if (orbCombination[2] == "fire"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "fire";
                                            } else if (orbCombination[2] == "death"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "death";
                                            } else if (orbCombination[2] == "holy"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "holy";
                                            } else if (orbCombination[2] == "nature"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "nature";
                                            }
                    } else if (orbCombination[1] == "fire"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "fire";
                                            if(orbCombination[2] == "ice"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "ice";
                                            } else if (orbCombination[2] == "fire"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "fire";
                                            } else if (orbCombination[2] == "death"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "death";
                                            } else if (orbCombination[2] == "holy"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "holy";
                                            } else if (orbCombination[2] == "nature"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "nature";
                                            }
                    } else if (orbCombination[1] == "death"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "death";
                                            if(orbCombination[2] == "ice"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "ice";
                                            } else if (orbCombination[2] == "fire"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "fire";
                                            } else if (orbCombination[2] == "death"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "death";
                                            } else if (orbCombination[2] == "holy"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "holy";
                                            } else if (orbCombination[2] == "nature"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "nature";
                                            }
                    } else if (orbCombination[1] == "holy"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "holy";
                                            if(orbCombination[2] == "ice"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "ice";
                                            } else if (orbCombination[2] == "fire"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "fire";
                                            } else if (orbCombination[2] == "death"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "death";
                                            } else if (orbCombination[2] == "holy"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "holy";
                                            } else if (orbCombination[2] == "nature"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "nature";
                                            }
                    } else if (orbCombination[1] == "nature"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>1)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "nature";
                                            if(orbCombination[2] == "ice"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "ice";
                                            } else if (orbCombination[2] == "fire"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "fire";
                                            } else if (orbCombination[2] == "death"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "death";
                                            } else if (orbCombination[2] == "holy"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "holy";
                                            } else if (orbCombination[2] == "nature"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>2)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "nature";
                                            }
                    }
                        
        }
        
        // if (orbCombination[0] == "ice")
        // {
        //     if (orbCombination[1] == "ice")
        //     {
        //         if (orbCombination[2] == "ice")
        //         {
        //             cost = 3;
        //             resource = "blueCrystal";
        //         }
        //     }
        // }
        // if (orbCombination[0] == "fire")
        // {
        //     if (orbCombination[1] == "fire")
        //     {
        //         if (orbCombination[2] == "fire")
        //         {
        //             cost = 3;
        //             resource = "redCrystal";
        //         }
        //     }
        // }
        // if (orbCombination[0] == "death")
        // {
        //     if (orbCombination[1] == "death")
        //     {
        //         if (orbCombination[2] == "death")
        //         {
        //             cost = 3;
        //             resource = "purpleCrystal";
        //         }
        //     }
        // }
        // if (orbCombination[0] == "holy")
        // {
        //     if (orbCombination[1] == "holy")
        //     {
        //         if (orbCombination[2] == "holy")
        //         {
        //             cost = 3;
        //             resource = "yellowCrystal";
        //         }
        //     }
        // }
        // if (orbCombination[0] == "nature")
        // {
        //     if (orbCombination[1] == "nature")
        //     {
        //         if (orbCombination[2] == "nature")
        //         {
        //             cost = 3;
        //             resource = "greenCrystal";
        //         }
        //     }
        // }
        // if (Bank.gameObject.GetComponent<Currencies>().checkCurrency(resource1)>0)
        // {
            
        //MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "death";
            for (int i = 0; i < 3; i++){
                if (MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[i]=="fire"){
                    Bank.gameObject.GetComponent<Currencies>().incrementCurrency("redCrystal", -1);
                } else if (MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[i]=="ice"){
                    Bank.gameObject.GetComponent<Currencies>().incrementCurrency("blueCrystal", -1);
                } else if (MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[i]=="death"){
                    Bank.gameObject.GetComponent<Currencies>().incrementCurrency("purpleCrystal", -1);
                } else if (MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[i]=="holy"){
                    Bank.gameObject.GetComponent<Currencies>().incrementCurrency("yellowCrystal", -1);
                } else if (MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[i]=="nature"){
                    Bank.gameObject.GetComponent<Currencies>().incrementCurrency("greenCrystal", -1);
                }
            }
            GameObject newOrb = Instantiate(MasterOrb, this.gameObject.transform.position + new Vector3(-2, 3, 0), Quaternion.identity);
            newOrb.SetActive(true);
            Highlight[0].SetActive(false);
            Highlight[1].SetActive(false);
            Highlight[2].SetActive(false);
            orbCombination[0] = "";
            orbCombination[1] = "";
            orbCombination[2] = "";
            OrbCraft.gameObject.SetActive(false);
        // }
        // else
        // {
        //     Debug.Log("Not enough resources");
        //     notEnoughText.SetActive(true);
        // }
    }

    public void SelectRed()
    {
        if (orbCombination[0] == "")
        {
            orbCombination[0] = "fire";
            Highlight[0].SetActive(true);
            Highlight[0].transform.position = crystalDust[0].transform.position;
        }
        else if (orbCombination[1] == "")
        {
            orbCombination[1] = "fire";
            Highlight[1].SetActive(true);
            Highlight[1].transform.position = crystalDust[0].transform.position;
        }
        else if (orbCombination[2] == "")
        {
            orbCombination[2] = "fire";
            Highlight[2].SetActive(true);
            Highlight[2].transform.position = crystalDust[0].transform.position;
        }
        else
        if (orbCombination[0] == "fire")
        {
            orbCombination[0] = "";
            Highlight[0].SetActive(false);
        }
        else if (orbCombination[1] == "fire")
        {
            orbCombination[1] = "";
            Highlight[1].SetActive(false);
        }
        else if (orbCombination[2] == "fire")
        {
            orbCombination[2] = "";
            Highlight[2].SetActive(false);
        }

    }
    public void SelectBlue()
    {
        if (orbCombination[0] == "")
        {
            orbCombination[0] = "ice";
            Highlight[0].SetActive(true);
            Highlight[0].transform.position = crystalDust[1].transform.position;
        }
        else if (orbCombination[1] == "")
        {
            orbCombination[1] = "ice";
            Highlight[1].SetActive(true);
            Highlight[1].transform.position = crystalDust[1].transform.position;
        }
        else if (orbCombination[2] == "")
        {
            orbCombination[2] = "ice";
            Highlight[2].SetActive(true);
            Highlight[2].transform.position = crystalDust[1].transform.position;
        }
        else
        if (orbCombination[0] == "ice")
        {
            orbCombination[0] = "";
            Highlight[0].SetActive(false);
        }
        else if (orbCombination[1] == "ice")
        {
            orbCombination[1] = "";
            Highlight[1].SetActive(false);
        }
        else if (orbCombination[2] == "ice")
        {
            orbCombination[2] = "";
            Highlight[2].SetActive(false);
        }

    }

    public void SelectPurple()
    {
        if (orbCombination[0] == "")
        {
            orbCombination[0] = "death";
            Highlight[0].SetActive(true);
            Highlight[0].transform.position = crystalDust[2].transform.position;
        }
        else if (orbCombination[1] == "")
        {
            orbCombination[1] = "death";
            Highlight[1].SetActive(true);
            Highlight[1].transform.position = crystalDust[2].transform.position;
        }
        else if (orbCombination[2] == "")
        {
            orbCombination[2] = "death";
            Highlight[2].SetActive(true);
            Highlight[2].transform.position = crystalDust[2].transform.position;
        }
        else
        if (orbCombination[0] == "death")
        {
            orbCombination[0] = "";
            Highlight[0].SetActive(false);
        }
        else if (orbCombination[1] == "death")
        {
            orbCombination[1] = "";
            Highlight[1].SetActive(false);
        }
        else if (orbCombination[2] == "death")
        {
            orbCombination[2] = "";
            Highlight[2].SetActive(false);
        }
    }
    public void SelectGreen()
    {
        if (orbCombination[0] == "")
        {
            orbCombination[0] = "nature";
            Highlight[0].SetActive(true);
            Highlight[0].transform.position = crystalDust[3].transform.position;
        }
        else if (orbCombination[1] == "")
        {
            orbCombination[1] = "nature";
            Highlight[1].SetActive(true);
            Highlight[1].transform.position = crystalDust[3].transform.position;
        }
        else if (orbCombination[2] == "")
        {
            orbCombination[2] = "nature";
            Highlight[2].SetActive(true);
            Highlight[2].transform.position = crystalDust[3].transform.position;
        }
        else
        if (orbCombination[0] == "nature")
        {
            orbCombination[0] = "";
            Highlight[0].SetActive(false);
        }
        else if (orbCombination[1] == "nature")
        {
            orbCombination[1] = "";
            Highlight[1].SetActive(false);
        }
        else if (orbCombination[2] == "nature")
        {
            orbCombination[2] = "";
            Highlight[2].SetActive(false);
        }
    }
    public void SelectYellow()
    {
        if (orbCombination[0] == "")
        {
            orbCombination[0] = "holy";
            Highlight[0].SetActive(true);
            Highlight[0].transform.position = crystalDust[4].transform.position;
        }
        else if (orbCombination[1] == "")
        {
            orbCombination[1] = "holy";
            Highlight[1].SetActive(true);
            Highlight[1].transform.position = crystalDust[4].transform.position;
        }
        else if (orbCombination[2] == "")
        {
            orbCombination[2] = "holy";
            Highlight[2].SetActive(true);
            Highlight[2].transform.position = crystalDust[4].transform.position;
        }
        else
        if (orbCombination[0] == "holy")
        {
            orbCombination[0] = "";
            Highlight[0].SetActive(false);
        }
        else if (orbCombination[1] == "holy")
        {
            orbCombination[1] = "";
            Highlight[1].SetActive(false);
        }
        else if (orbCombination[2] == "holy")
        {
            orbCombination[2] = "";
            Highlight[2].SetActive(false);
        }

    }
}
