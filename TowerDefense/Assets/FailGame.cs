using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailGame : MonoBehaviour
{
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
    void OnTriggerEnter (Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Failed Screen");
        }
        if (collision.gameObject.tag == "Player"){
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
