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
        
        if (orbCombination[0] == "blue"){
            if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                notEnoughText.SetActive(true);
                return;
            }
            MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[0] = "blue";
                    if(orbCombination[1] == "blue"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>1)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "blue";
                                            if(orbCombination[2] == "blue"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>2)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "blue";
                                            } else if (orbCombination[2] == "red"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "red";
                                            } else if (orbCombination[2] == "purple"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "purple";
                                            } else if (orbCombination[2] == "yellow"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "yellow";
                                            } else if (orbCombination[2] == "green"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "green";
                                            }
                    } else if (orbCombination[1] == "red"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "red";
                                            if(orbCombination[2] == "blue"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "blue";
                                            } else if (orbCombination[2] == "red"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "red";
                                            } else if (orbCombination[2] == "purple"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "purple";
                                            } else if (orbCombination[2] == "yellow"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "yellow";
                                            } else if (orbCombination[2] == "green"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "green";
                                            }
                    } else if (orbCombination[1] == "purple"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "purple";
                                            if(orbCombination[2] == "blue"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "blue";
                                            } else if (orbCombination[2] == "red"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "red";
                                            } else if (orbCombination[2] == "purple"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "purple";
                                            } else if (orbCombination[2] == "yellow"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "yellow";
                                            } else if (orbCombination[2] == "green"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "green";
                                            }
                    } else if (orbCombination[1] == "yellow"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "yellow";
                                            if(orbCombination[2] == "blue"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "blue";
                                            } else if (orbCombination[2] == "red"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "red";
                                            } else if (orbCombination[2] == "purple"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "purple";
                                            } else if (orbCombination[2] == "yellow"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "yellow";
                                            } else if (orbCombination[2] == "green"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "green";
                                            }
                    } else if (orbCombination[1] == "green"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "green";
                                            if(orbCombination[2] == "blue"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "blue";
                                            } else if (orbCombination[2] == "red"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "red";
                                            } else if (orbCombination[2] == "purple"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "purple";
                                            } else if (orbCombination[2] == "yellow"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "yellow";
                                            } else if (orbCombination[2] == "green"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "green";
                                            }
                    }
        } else if (orbCombination[0] == "red"){
            if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                notEnoughText.SetActive(true);
                return;
            }
            MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[0] = "red";
                    if(orbCombination[1] == "blue"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "blue";
                                            if(orbCombination[2] == "blue"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "blue";
                                            } else if (orbCombination[2] == "red"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "red";
                                            } else if (orbCombination[2] == "purple"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "purple";
                                            } else if (orbCombination[2] == "yellow"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "yellow";
                                            } else if (orbCombination[2] == "green"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "green";
                                            }
                    } else if (orbCombination[1] == "red"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>1)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "red";
                                            if(orbCombination[2] == "blue"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "blue";
                                            } else if (orbCombination[2] == "red"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>2)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "red";
                                            } else if (orbCombination[2] == "purple"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "purple";
                                            } else if (orbCombination[2] == "yellow"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "yellow";
                                            } else if (orbCombination[2] == "green"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "green";
                                            }
                    } else if (orbCombination[1] == "purple"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "purple";
                                            if(orbCombination[2] == "blue"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "blue";
                                            } else if (orbCombination[2] == "red"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "red";
                                            } else if (orbCombination[2] == "purple"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "purple";
                                            } else if (orbCombination[2] == "yellow"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "yellow";
                                            } else if (orbCombination[2] == "green"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "green";
                                            }
                    } else if (orbCombination[1] == "yellow"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "yellow";
                                            if(orbCombination[2] == "blue"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "blue";
                                            } else if (orbCombination[2] == "red"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "red";
                                            } else if (orbCombination[2] == "purple"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "purple";
                                            } else if (orbCombination[2] == "yellow"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "yellow";
                                            } else if (orbCombination[2] == "green"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "green";
                                            }
                    } else if (orbCombination[1] == "green"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "green";
                                            if(orbCombination[2] == "blue"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "blue";
                                            } else if (orbCombination[2] == "red"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "red";
                                            } else if (orbCombination[2] == "purple"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "purple";
                                            } else if (orbCombination[2] == "yellow"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "yellow";
                                            } else if (orbCombination[2] == "green"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "green";
                                            }
                    } 
        } else if (orbCombination[0] == "purple"){
            if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                notEnoughText.SetActive(true);
                return;
            }
            MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[0] = "purple";
                    if(orbCombination[1] == "blue"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "blue";
                                            if(orbCombination[2] == "blue"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "blue";
                                            } else if (orbCombination[2] == "red"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "red";
                                            } else if (orbCombination[2] == "purple"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "purple";
                                            } else if (orbCombination[2] == "yellow"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "yellow";
                                            } else if (orbCombination[2] == "green"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "green";
                                            }
                    } else if (orbCombination[1] == "red"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "red";
                                            if(orbCombination[2] == "blue"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "blue";
                                            } else if (orbCombination[2] == "red"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "red";
                                            } else if (orbCombination[2] == "purple"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "purple";
                                            } else if (orbCombination[2] == "yellow"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "yellow";
                                            } else if (orbCombination[2] == "green"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "green";
                                            }
                    } else if (orbCombination[1] == "purple"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>1)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "purple";
                                            if(orbCombination[2] == "blue"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "blue";
                                            } else if (orbCombination[2] == "red"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "red";
                                            } else if (orbCombination[2] == "purple"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>2)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "purple";
                                            } else if (orbCombination[2] == "yellow"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "yellow";
                                            } else if (orbCombination[2] == "green"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "green";
                                            }
                    } else if (orbCombination[1] == "yellow"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "yellow";
                                            if(orbCombination[2] == "blue"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "blue";
                                            } else if (orbCombination[2] == "red"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "red";
                                            } else if (orbCombination[2] == "purple"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "purple";
                                            } else if (orbCombination[2] == "yellow"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "yellow";
                                            } else if (orbCombination[2] == "green"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "green";
                                            }
                    } else if (orbCombination[1] == "green"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "green";
                                            if(orbCombination[2] == "blue"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "blue";
                                            } else if (orbCombination[2] == "red"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "red";
                                            } else if (orbCombination[2] == "purple"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "purple";
                                            } else if (orbCombination[2] == "yellow"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "yellow";
                                            } else if (orbCombination[2] == "green"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "green";
                                            }
                    }
        } else if (orbCombination[0] == "yellow"){
            if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                notEnoughText.SetActive(true);
                return;
            }
            MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[0] = "yellow";
                    if(orbCombination[1] == "blue"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "blue";
                                            if(orbCombination[2] == "blue"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "blue";
                                            } else if (orbCombination[2] == "red"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "red";
                                            } else if (orbCombination[2] == "purple"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "purple";
                                            } else if (orbCombination[2] == "yellow"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "yellow";
                                            } else if (orbCombination[2] == "green"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "green";
                                            }
                    } else if (orbCombination[1] == "red"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "red";
                                            if(orbCombination[2] == "blue"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "blue";
                                            } else if (orbCombination[2] == "red"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "red";
                                            } else if (orbCombination[2] == "purple"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "purple";
                                            } else if (orbCombination[2] == "yellow"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "yellow";
                                            } else if (orbCombination[2] == "green"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "green";
                                            }
                    } else if (orbCombination[1] == "purple"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "purple";
                                            if(orbCombination[2] == "blue"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "blue";
                                            } else if (orbCombination[2] == "red"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "red";
                                            } else if (orbCombination[2] == "purple"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "purple";
                                            } else if (orbCombination[2] == "yellow"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "yellow";
                                            } else if (orbCombination[2] == "green"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "green";
                                            }
                    } else if (orbCombination[1] == "yellow"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>1)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "yellow";
                                            if(orbCombination[2] == "blue"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "blue";
                                            } else if (orbCombination[2] == "red"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "red";
                                            } else if (orbCombination[2] == "purple"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "purple";
                                            } else if (orbCombination[2] == "yellow"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>2)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "yellow";
                                            } else if (orbCombination[2] == "green"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "green";
                                            }
                    } else if (orbCombination[1] == "green"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "green";
                                            if(orbCombination[2] == "blue"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "blue";
                                            } else if (orbCombination[2] == "red"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "red";
                                            } else if (orbCombination[2] == "purple"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "purple";
                                            } else if (orbCombination[2] == "yellow"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "yellow";
                                            } else if (orbCombination[2] == "green"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "green";
                                            }
                    }
        } else if (orbCombination[0] == "green"){
            if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>0)){
                notEnoughText.SetActive(true);
                return;
            }
            MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[0] = "green";
                    if(orbCombination[1] == "blue"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "blue";
                                            if(orbCombination[2] == "blue"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "blue";
                                            } else if (orbCombination[2] == "red"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "red";
                                            } else if (orbCombination[2] == "purple"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "purple";
                                            } else if (orbCombination[2] == "yellow"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "yellow";
                                            } else if (orbCombination[2] == "green"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "green";
                                            }
                    } else if (orbCombination[1] == "red"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "red";
                                            if(orbCombination[2] == "blue"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "blue";
                                            } else if (orbCombination[2] == "red"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "red";
                                            } else if (orbCombination[2] == "purple"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "purple";
                                            } else if (orbCombination[2] == "yellow"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "yellow";
                                            } else if (orbCombination[2] == "green"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "green";
                                            }
                    } else if (orbCombination[1] == "purple"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "purple";
                                            if(orbCombination[2] == "blue"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "blue";
                                            } else if (orbCombination[2] == "red"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "red";
                                            } else if (orbCombination[2] == "purple"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "purple";
                                            } else if (orbCombination[2] == "yellow"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "yellow";
                                            } else if (orbCombination[2] == "green"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "green";
                                            }
                    } else if (orbCombination[1] == "yellow"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "yellow";
                                            if(orbCombination[2] == "blue"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "blue";
                                            } else if (orbCombination[2] == "red"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "red";
                                            } else if (orbCombination[2] == "purple"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "purple";
                                            } else if (orbCombination[2] == "yellow"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "yellow";
                                            } else if (orbCombination[2] == "green"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>1)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "green";
                                            }
                    } else if (orbCombination[1] == "green"){
                        if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>1)){
                            notEnoughText.SetActive(true);
                            return;
                        }
                        MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[1] = "green";
                                            if(orbCombination[2] == "blue"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("blueCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "blue";
                                            } else if (orbCombination[2] == "red"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("redCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "red";
                                            } else if (orbCombination[2] == "purple"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("purpleCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "purple";
                                            } else if (orbCombination[2] == "yellow"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("yellowCrystal")>0)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "yellow";
                                            } else if (orbCombination[2] == "green"){
                                                if (!(Bank.gameObject.GetComponent<Currencies>().checkCurrency("greenCrystal")>2)){
                                                    notEnoughText.SetActive(true);
                                                    return;
                                                }
                                                MasterOrb.transform.GetChild(0).GetComponent<OrbScript>().orbEffects[2] = "green";
                                            }
                    }
                        
        }
        
        // if (orbCombination[0] == "blue")
        // {
        //     if (orbCombination[1] == "blue")
        //     {
        //         if (orbCombination[2] == "blue")
        //         {
        //             cost = 3;
        //             resource = "blueCrystal";
        //         }
        //     }
        // }
        // if (orbCombination[0] == "red")
        // {
        //     if (orbCombination[1] == "red")
        //     {
        //         if (orbCombination[2] == "red")
        //         {
        //             cost = 3;
        //             resource = "redCrystal";
        //         }
        //     }
        // }
        // if (orbCombination[0] == "purple")
        // {
        //     if (orbCombination[1] == "purple")
        //     {
        //         if (orbCombination[2] == "purple")
        //         {
        //             cost = 3;
        //             resource = "purpleCrystal";
        //         }
        //     }
        // }
        // if (orbCombination[0] == "yellow")
        // {
        //     if (orbCombination[1] == "yellow")
        //     {
        //         if (orbCombination[2] == "yellow")
        //         {
        //             cost = 3;
        //             resource = "yellowCrystal";
        //         }
        //     }
        // }
        // if (orbCombination[0] == "green")
        // {
        //     if (orbCombination[1] == "green")
        //     {
        //         if (orbCombination[2] == "green")
        //         {
        //             cost = 3;
        //             resource = "greenCrystal";
        //         }
        //     }
        // }
        // if (Bank.gameObject.GetComponent<Currencies>().checkCurrency(resource1)>0)
        // {
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
            orbCombination[0] = "red";
            Highlight[0].SetActive(true);
            Highlight[0].transform.position = crystalDust[0].transform.position;
        }
        else if (orbCombination[1] == "")
        {
            orbCombination[1] = "red";
            Highlight[1].SetActive(true);
            Highlight[1].transform.position = crystalDust[0].transform.position;
        }
        else if (orbCombination[2] == "")
        {
            orbCombination[2] = "red";
            Highlight[2].SetActive(true);
            Highlight[2].transform.position = crystalDust[0].transform.position;
        }
        else
        if (orbCombination[0] == "red")
        {
            orbCombination[0] = "";
            Highlight[0].SetActive(false);
        }
        else if (orbCombination[1] == "red")
        {
            orbCombination[1] = "";
            Highlight[1].SetActive(false);
        }
        else if (orbCombination[2] == "red")
        {
            orbCombination[2] = "";
            Highlight[2].SetActive(false);
        }

    }
    public void SelectBlue()
    {
        if (orbCombination[0] == "")
        {
            orbCombination[0] = "blue";
            Highlight[0].SetActive(true);
            Highlight[0].transform.position = crystalDust[1].transform.position;
        }
        else if (orbCombination[1] == "")
        {
            orbCombination[1] = "blue";
            Highlight[1].SetActive(true);
            Highlight[1].transform.position = crystalDust[1].transform.position;
        }
        else if (orbCombination[2] == "")
        {
            orbCombination[2] = "blue";
            Highlight[2].SetActive(true);
            Highlight[2].transform.position = crystalDust[1].transform.position;
        }
        else
        if (orbCombination[0] == "blue")
        {
            orbCombination[0] = "";
            Highlight[0].SetActive(false);
        }
        else if (orbCombination[1] == "blue")
        {
            orbCombination[1] = "";
            Highlight[1].SetActive(false);
        }
        else if (orbCombination[2] == "blue")
        {
            orbCombination[2] = "";
            Highlight[2].SetActive(false);
        }

    }

    public void SelectPurple()
    {
        if (orbCombination[0] == "")
        {
            orbCombination[0] = "purple";
            Highlight[0].SetActive(true);
            Highlight[0].transform.position = crystalDust[2].transform.position;
        }
        else if (orbCombination[1] == "")
        {
            orbCombination[1] = "purple";
            Highlight[1].SetActive(true);
            Highlight[1].transform.position = crystalDust[2].transform.position;
        }
        else if (orbCombination[2] == "")
        {
            orbCombination[2] = "purple";
            Highlight[2].SetActive(true);
            Highlight[2].transform.position = crystalDust[2].transform.position;
        }
        else
        if (orbCombination[0] == "purple")
        {
            orbCombination[0] = "";
            Highlight[0].SetActive(false);
        }
        else if (orbCombination[1] == "purple")
        {
            orbCombination[1] = "";
            Highlight[1].SetActive(false);
        }
        else if (orbCombination[2] == "purple")
        {
            orbCombination[2] = "";
            Highlight[2].SetActive(false);
        }
    }
    public void SelectGreen()
    {
        if (orbCombination[0] == "")
        {
            orbCombination[0] = "green";
            Highlight[0].SetActive(true);
            Highlight[0].transform.position = crystalDust[3].transform.position;
        }
        else if (orbCombination[1] == "")
        {
            orbCombination[1] = "green";
            Highlight[1].SetActive(true);
            Highlight[1].transform.position = crystalDust[3].transform.position;
        }
        else if (orbCombination[2] == "")
        {
            orbCombination[2] = "green";
            Highlight[2].SetActive(true);
            Highlight[2].transform.position = crystalDust[3].transform.position;
        }
        else
        if (orbCombination[0] == "green")
        {
            orbCombination[0] = "";
            Highlight[0].SetActive(false);
        }
        else if (orbCombination[1] == "green")
        {
            orbCombination[1] = "";
            Highlight[1].SetActive(false);
        }
        else if (orbCombination[2] == "green")
        {
            orbCombination[2] = "";
            Highlight[2].SetActive(false);
        }
    }
    public void SelectYellow()
    {
        if (orbCombination[0] == "")
        {
            orbCombination[0] = "yellow";
            Highlight[0].SetActive(true);
            Highlight[0].transform.position = crystalDust[4].transform.position;
        }
        else if (orbCombination[1] == "")
        {
            orbCombination[1] = "yellow";
            Highlight[1].SetActive(true);
            Highlight[1].transform.position = crystalDust[4].transform.position;
        }
        else if (orbCombination[2] == "")
        {
            orbCombination[2] = "yellow";
            Highlight[2].SetActive(true);
            Highlight[2].transform.position = crystalDust[4].transform.position;
        }
        else
        if (orbCombination[0] == "yellow")
        {
            orbCombination[0] = "";
            Highlight[0].SetActive(false);
        }
        else if (orbCombination[1] == "yellow")
        {
            orbCombination[1] = "";
            Highlight[1].SetActive(false);
        }
        else if (orbCombination[2] == "yellow")
        {
            orbCombination[2] = "";
            Highlight[2].SetActive(false);
        }

    }
}
