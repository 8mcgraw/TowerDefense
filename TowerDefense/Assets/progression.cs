using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progression : MonoBehaviour
{
    public GameObject[] levels;
    public bool[] levelsCompleted;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        //if levels scene active, update the gameobjects
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "LevelSelector")
        {
            //update the selection script with the completed levels
            selection selectionScript = GameObject.Find("Selection").GetComponent<selection>();
            selectionScript.levelsCompleted = levelsCompleted;
            //at any point hit escape to go back to level select
           
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            //string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("LevelSelector");
            //UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(currentScene);
        }
    }
}
