using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey ("return")){
<<<<<<< Updated upstream:TowerDefense/Assets/EndScreen.cs
            UnityEngine.SceneManagement.SceneManager.LoadScene("Basic Tower Defense");
=======
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Basic Tower Defense");
>>>>>>> Stashed changes:TowerDefense/Assets/OldStuff/EndScreen.cs
        }
    }
}
