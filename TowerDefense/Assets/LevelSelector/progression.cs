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

        } else {
            //if not in levels scene, display health and timer
            
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            //string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("LevelSelector");
            //UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(currentScene);
        }
        //if underground camera is active, make the music muffled
        if ((GameObject.Find("Main Camera Underground") != null) && (GameObject.Find("Main Camera Underground").activeSelf))
        {
            //change the spatial blend of the audio source to 0.1f
            this.gameObject.GetComponent<AudioSource>().spatialBlend = 0.5f;
        } else {
            //change the spatial blend of the audio source to 0.1f
            this.gameObject.GetComponent<AudioSource>().spatialBlend = 0.0f;}
    }
}
