using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public GameObject prompt;
    // Start is called before the first frame update
    void Start()
    {
        if(prompt != null) {
            prompt.SetActive(true);
            GameObject text = prompt.gameObject.transform.GetChild(0).gameObject;
            TextMeshProUGUI textComponent = text.GetComponent<TextMeshProUGUI>();
            if (textComponent != null)
            {
                textComponent.text = "Press Escape to Try Again";
            }
        }
        else
        {
            prompt.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey ("escape")){
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("LevelSelector");
        }
    }
}
