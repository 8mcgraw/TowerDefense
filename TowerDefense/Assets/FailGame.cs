using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailGame : MonoBehaviour
{
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
        if (collision.gameObject.tag == "Enemy")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Failed Screen");
        }
    }
}
