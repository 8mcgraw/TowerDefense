using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerScript : MonoBehaviour
{
    private bool close = false;
    public bool carrying = false;
    public GameObject player;
    public Animator animator;
    public bool onPath = false;
    public GameObject SpherePos;
    public string MaterialType = "wood";
    public GameObject Model;
    public GameObject[] Materials;

    void Start()
    {
        if (Model.tag == "short"){
            
        } else if (Model.tag == "regular"){

        } else if (Model.tag == "tall"){

        }
        if (MaterialType == "iron"){
            foreach(GameObject material in Materials){
                material.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                material.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0.2f,0.2f,0.2f));
                material.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", new Color(0.3f,0.3f,0.35f) * 1);
            }
        }
        if (MaterialType == "wood"){
            foreach(GameObject material in Materials){
                material.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                material.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0.6037736f,0.5085683f,0.2876468f));
                material.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", new Color(0f,0f,0f) * 1);
            }
        }
        if (MaterialType == "gold"){
            foreach(GameObject material in Materials){
                material.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                material.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(1f,1f,0f));
                material.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", new Color(0.44f,0.44f,0f) * 1);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if ((close == true) && (Input.GetKey(KeyCode.E))&& (animator.GetBool("carrying") == false )&&(!FindChildWithTag(this.gameObject, "Orb")))
        {
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<BoxCollider>().enabled = false;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            this.transform.position = player.transform.position + new Vector3(0f, 2.5f, 2f);
            this.transform.parent = player.transform;
            this.transform.rotation = new Quaternion(0,0,0,0);
            animator.SetBool("carrying", true);
            carrying = true;
        }
        if ((carrying == true) && (Input.GetKey(KeyCode.Q))&&(!onPath))
        {
            this.transform.parent = null;
            //this.transform.position = player.transform.position + player.transform.forward + this.transform.up*2;
            //this.transform.rotation = player.transform.rotation * Quaternion.Euler(new Vector3(270, 0, 130));
            animator.SetBool("carrying", false);
            carrying = false;
            //this.GetComponent<SphereCollider>().enabled = true;
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<BoxCollider>().enabled = true;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;


        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            close = true;
        }
        if (collision.transform.tag == "Path"){
            onPath = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            close = false;
        }
        if (collision.transform.tag == "Path"){
            onPath = false;
        }


    }

    private void OnTriggerStay(Collider collision)
    {
        if ((!FindChildWithTag(this.gameObject, "Orb"))&&(this.transform.parent==null)&&(collision.gameObject.tag == "Orb")&&(collision.transform.parent == null)&&(!onPath))
        {
            collision.GetComponent<Rigidbody>().useGravity = false;
            //collision.GetComponent<SphereCollider>().enabled = false;
            collision.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            collision.transform.SetParent(this.gameObject.transform);
            // Debug.Log("THIS OBJECT: "+this.gameObject.transform.tag);
            // Debug.Log("THIS PARENT: "+collision.transform.parent.tag);
            collision.transform.position = SpherePos.gameObject.transform.position;;
            collision.transform.rotation = this.transform.rotation * Quaternion.Euler(0, 280, 0);
            collision.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        if (collision.transform.tag == "Path"){
            onPath = true;
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
