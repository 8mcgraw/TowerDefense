using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailGame : MonoBehaviour
{
    public int health = 100;
    public bool close = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(close == true){
            if(Input.GetKeyDown(KeyCode.E)){
                GameLoopManager gameLoopManager = GameObject.Find("GameMaster").GetComponent<GameLoopManager>();
                gameLoopManager.StartWave();
                //Debug.Log("Wave Started");
            }
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
        }
    }
    void OnTriggerExit (Collider collision)
    {
        if (collision.gameObject.tag == "Player"){
            close = false;
        }
    }
}
