using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageElderScript : MonoBehaviour
{
    public GameObject text;
    public GameObject text2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter (Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player has collided with the village elder");
            text.SetActive(false);
            text2.SetActive(true);
        } else {
            Debug.Log("Something has collided with the village elder");
        }
    }
}
