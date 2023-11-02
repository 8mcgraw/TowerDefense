using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToOverworld : MonoBehaviour

{
public UnityEngine.SceneManagement.Scene undergroundScene;
public UnityEngine.SceneManagement.Scene overworldScene;
    // Start is called before the first frame update
    void Start()
    {
        overworldScene = UnityEngine.SceneManagement.SceneManager.GetSceneByName("");
        undergroundScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player"){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Basic Tower Defense");
            //UnityEngine.SceneManagement.SceneManager.MoveGameObjectToScene(collider.gameObject, undergroundScene);
            UnityEditor.SceneManagement.EditorSceneManager.OpenScene("Basic Tower Defense");
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(undergroundScene);
        }
    }
}
