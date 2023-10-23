using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public Vector3 speed = new Vector3(0.1f, 0.1f, 0.1f);
    public Animator animator;
    public GameObject model;

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
        if(Input.GetKey(KeyCode.W)){
            transform.position += Vector3.Scale(Vector3.forward, speed);
            animator.SetBool("walking", true);
            model.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
        }
        if(Input.GetKey(KeyCode.S)){
            transform.position += Vector3.Scale(Vector3.back, speed);
            animator.SetBool("walking", true);
            model.transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
        }
        if(Input.GetKey(KeyCode.A)){
            transform.position += Vector3.Scale(Vector3.left, speed);
            animator.SetBool("walking", true);
            model.transform.rotation = Quaternion.Euler(new Vector3(0,270,0));
        }
        if(Input.GetKey(KeyCode.D)){
            transform.position += Vector3.Scale(Vector3.right, speed);
            animator.SetBool("walking", true);
            model.transform.rotation = Quaternion.Euler(new Vector3(0,90,0));
        }
        if(Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.S) == false && Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false){
            animator.SetBool("walking", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(Input.GetKey(KeyCode.E)){
            
        }
    }


}
