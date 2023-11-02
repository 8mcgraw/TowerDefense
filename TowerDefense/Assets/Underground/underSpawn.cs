using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class underSpawn : MonoBehaviour
{
    public GameObject Player;
    public GameObject Spawn;
    // Start is called before the first frame update
    void Start()
    {
        Player.transform.localPosition = Spawn.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void MovetoUnderGround(){
    //     Player.transform.localPosition = Spawn.transform.localPosition;
            // change scene
            //swap active scene? keep both loaded.
    // }
}
