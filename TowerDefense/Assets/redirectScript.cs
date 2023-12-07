using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redirectScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("LevelSelector");
    }
}
