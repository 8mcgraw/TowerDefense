using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthChange : MonoBehaviour
{
    public GameObject finish;
    public float h, hbase = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //find an object with tag finish
        if (finish == null) {
            finish = GameObject.FindGameObjectWithTag("Finish");
        } else {
            h = finish.gameObject.GetComponent<FailGame>().health;
            if (hbase == 0) {
                hbase = h;
            }
            this.gameObject.transform.localScale = new Vector3(h/hbase, 1, 1);
        }

        
    }
}
