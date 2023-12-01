using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using TMPro;

public class playerScript : MonoBehaviour
{
    public float speed = 5.0f;
    public Animator animator;
    public GameObject model, GameMaster;

    //public TMPro.TextMeshPro t1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (GameMaster.gameObject.GetComponent<GameLoopManager>().startWave == false)
        {

            //    t1.text = "Press Enter to Start Wave";
            Debug.Log("Press Enter to Start Wave");
        }
        //else {
        //    if(t1.text == "Press Enter to Start Wave")
        //    {
        //        t1.text == "";
        //    }
        //}
        if(Input.GetKey(KeyCode.Return) && UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex > 2
            && UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex < 8)
        {
            GameMaster.gameObject.GetComponent<GameLoopManager>().startWave = true;
            Debug.Log("Wave Started");

        }
        if (Input.GetKey(KeyCode.W)){
            GetComponent<Rigidbody>().velocity = new Vector3(0,GetComponent<Rigidbody>().velocity.y,speed);
            //transform.position += Vector3.Scale(Vector3.forward, speed);
            animator.SetBool("walking", true);
            model.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
        }
        if(Input.GetKey(KeyCode.S)){
            GetComponent<Rigidbody>().velocity = new Vector3(0,GetComponent<Rigidbody>().velocity.y,-speed);
            //transform.position += Vector3.Scale(Vector3.back, speed);
            animator.SetBool("walking", true);
            model.transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
        }
        if(Input.GetKey(KeyCode.A)){
            GetComponent<Rigidbody>().velocity = new Vector3(-speed,GetComponent<Rigidbody>().velocity.y,0);
            //transform.position += Vector3.Scale(Vector3.left, speed);
            animator.SetBool("walking", true);
            model.transform.rotation = Quaternion.Euler(new Vector3(0,270,0));
        }
        if(Input.GetKey(KeyCode.D)){
            GetComponent<Rigidbody>().velocity = new Vector3(speed,GetComponent<Rigidbody>().velocity.y,0);
            //transform.position += Vector3.Scale(Vector3.right, speed);
            animator.SetBool("walking", true);
            model.transform.rotation = Quaternion.Euler(new Vector3(0,90,0));
        }
        if(Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.S) == false && Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false){
            GetComponent<Rigidbody>().velocity = new Vector3(0,GetComponent<Rigidbody>().velocity.y,0);
            animator.SetBool("walking", false);
        }
    }


}
