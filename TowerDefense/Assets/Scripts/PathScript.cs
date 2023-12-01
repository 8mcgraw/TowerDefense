using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    void OnTriggerStay(Collider collision){
        if(collision.gameObject.tag == "Tower"){
            Debug.Log("Tower is on the path");
            collision.transform.LookAt(this.transform);
            collision.gameObject.transform.position = (collision.gameObject.transform.position - Vector3.forward);
        }
        else{
            Debug.Log("Tower is not on the path");
        }
    }
}
