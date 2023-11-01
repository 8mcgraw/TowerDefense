using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerScript : MonoBehaviour
{
    private bool close = false;
    public bool carrying = false;
    public GameObject player;
    public Animator animator;
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if ((close == true) && (Input.GetKey(KeyCode.E))&& (animator.GetBool("carrying") == false )&&(!FindChildWithTag(this.gameObject, "Orb")))
        {
            //this.GetComponent<SphereCollider>().enabled = false;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            this.transform.position = player.transform.position + new Vector3(0.28f, -0.3f, -0.2f);
            this.transform.parent = player.transform;
            //this.transform.rotation = player.transform.rotation * Quaternion.Euler(new Vector3(270, 0, 130));
            animator.SetBool("carrying", true);
            carrying = true;
        }
        if ((carrying == true) && (Input.GetKey(KeyCode.Q)))
        {
            this.transform.parent = null;
            this.transform.position = player.transform.position + player.transform.forward + this.transform.up*2;
            //this.transform.rotation = player.transform.rotation * Quaternion.Euler(new Vector3(270, 0, 130));
            animator.SetBool("carrying", false);
            carrying = false;
            //this.GetComponent<SphereCollider>().enabled = true;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;


        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            close = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            close = false;
        }


    }

    private void OnTriggerStay(Collider collision)
    {
        if ((!FindChildWithTag(this.gameObject, "Orb"))&&(this.transform.parent==null)&&(collision.gameObject.tag == "Orb")&&(collision.transform.parent == null))
        {
            collision.GetComponent<Rigidbody>().useGravity = false;
            //collision.GetComponent<SphereCollider>().enabled = false;
            collision.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            collision.transform.SetParent(this.gameObject.transform);
            // Debug.Log("THIS OBJECT: "+this.gameObject.transform.tag);
            // Debug.Log("THIS PARENT: "+collision.transform.parent.tag);
            collision.transform.position = this.transform.position + new Vector3(0.07f, 0.75f, 0.0f);
            collision.transform.rotation = this.transform.rotation * Quaternion.Euler(0, 280, 0);
            collision.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
    bool FindChildWithTag(GameObject parent, string tag) {
        bool found = false;
 
        foreach(Transform transform in parent.transform) {
            if(transform.CompareTag(tag)) {
                found = true;
                break;
            }
        }
        
        return found;
        }
}
    // private void OnTriggerStay(Collider collision)
    // {
    //     if (collision.gameObject == target[0])
    //     {
    //         Enemy enemy = collision.gameObject.GetComponent<Enemy>();
    //         if ((enemy != null)&&(enemy.currentHealth>0))
    //         {
    //             transform.LookAt(target[0].transform);
    //             projectilescript.attack(target[0]);
    //             enemy.TakeDamage(damage);
    //         } else {
    //             popTarget();
    //         }
    //     }
    // }
