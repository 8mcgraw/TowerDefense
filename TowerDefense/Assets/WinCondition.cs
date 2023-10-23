using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject Head1;
    public GameObject Head2;
    public GameObject Head3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Head1.transform.parent.tag == "Body")&&(Head2.transform.parent.tag == "Body")&&(Head3.transform.parent.tag == "Body")){
            UnityEngine.SceneManagement.SceneManager.LoadScene("VictoryScreen");
        }
    }
}
