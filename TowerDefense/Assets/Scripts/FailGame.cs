using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class FailGame : MonoBehaviour
{
    public int health = 100;
    public bool close = false;
    public GameObject prompt;
    public GameObject textt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (close == true)
        {
            prompt.SetActive(true);
            textt.SetActive(true);
            GameObject text = prompt.gameObject.transform.GetChild(0).gameObject;
            TextMeshProUGUI textComponent = text.GetComponent<TextMeshProUGUI>();
            if (textComponent != null)
            {
                textComponent.text = "Press Enter to Start Wave";
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                GameLoopManager gameLoopManager = GameObject.Find("GameMaster")?.GetComponent<GameLoopManager>();
                if (gameLoopManager != null)
                {
                    gameLoopManager.StartWave();
                    
                    //Debug.Log("Wave Started");
                }
            }
        }
        else
        {
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            health -= 10;
            Debug.Log("Health: " + health);
            if (health <= 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Failed Screen");
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            close = true;
            prompt.SetActive(true);
            textt.SetActive(true);
        }
    }
    void OnTriggerExit (Collider collision)
    {
        if (collision.gameObject.tag == "Player"){
            close = false;
        }
        prompt.SetActive(false);
        textt.SetActive(false);
    }
}
