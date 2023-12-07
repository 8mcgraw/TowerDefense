using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class FailGame : MonoBehaviour
{
    public int health = 21;
    public bool close = false;
    public GameObject prompt, prompt2;
    public GameObject textt;
    public GameObject failText;
    public GameObject gameLoopManager;
    public GameLoopManager loopManager;
    // Start is called before the first frame update
    void Start()
    {
        loopManager = GameObject.Find("GameMaster")?.GetComponent<GameLoopManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (close == true)
        // {
        //     prompt.SetActive(true);
        //     textt.SetActive(true);
        //     GameObject text = prompt.gameObject.transform.GetChild(0).gameObject;
        //     TextMeshProUGUI textComponent = text.GetComponent<TextMeshProUGUI>();
        //     if (textComponent != null)
        //     {
        //         textComponent.text = "Press Enter to Start Wave";
        //     }
        //     if (Input.GetKeyDown(KeyCode.Return))
        //     {
        //         GameLoopManager gameLoopManager = GameObject.Find("GameMaster")?.GetComponent<GameLoopManager>();
        //         if (gameLoopManager != null)
        //         {
        //             gameLoopManager.StartWave();
                    
        //             //Debug.Log("Wave Started");
        //         }
        //     }
        // }
        // else
        // {
        // }
    }
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collision: " + collision.gameObject.tag);
        if ((collision.gameObject.tag == "enemy")||(collision.gameObject.tag == "Enemy"))
        {
            health -= 10;
            Debug.Log("Health: " + health);
            if (health <= 0)
            {
                health = 0;
                prompt2.SetActive(true);
                failText.SetActive(true);
                loopManager.pause = true;
                loopManager.timer = -1000000000;
            }
            Destroy(collision.gameObject);
        }
        // if (collision.gameObject.tag == "Player")
        // {
        //     close = true;
        //     prompt.SetActive(true);
        //     textt.SetActive(true);
        // }
    }
    void OnTriggerExit (Collider collision)
    {
    //     if (collision.gameObject.tag == "Player"){
    //         close = false;
    //     }
    //     prompt.SetActive(false);
    //     textt.SetActive(false);
    }
}
