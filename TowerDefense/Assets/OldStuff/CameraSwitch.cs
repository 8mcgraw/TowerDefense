using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey ("space")){
            if(camera1.activeSelf){
                camera1.SetActive(false);
                camera2.SetActive(true);
            } else {
                camera1.SetActive(true);
                camera2.SetActive(false);
            }
        }
    }
}
