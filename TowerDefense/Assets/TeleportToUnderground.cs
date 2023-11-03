using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToUnderground : MonoBehaviour

{
public UnityEngine.SceneManagement.Scene undergroundScene;
public UnityEngine.SceneManagement.Scene overworldScene;
    // Start is called before the first frame update
    void Start()
    {
        undergroundScene = UnityEngine.SceneManagement.SceneManager.GetSceneByName("Assets/Underground/LV1 Underground.unity");
        overworldScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player"){
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Lv1 Underground");
            //UnityEngine.SceneManagement.SceneManager.MoveGameObjectToScene(collider.gameObject, undergroundScene);
            UnityEditor.SceneManagement.EditorSceneManager.OpenScene("LV1 Underground");
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(overworldScene);
        }
    }
}
