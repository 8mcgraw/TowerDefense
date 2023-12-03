using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerScript : MonoBehaviour
{
    private bool close = false;
    public bool carrying = false;
    public bool found2 = false;
    public GameObject player;
    public Animator animator;
    public bool onPath = false;
    public GameObject SpherePos;
    public string MaterialType = "dirt";
    public GameObject Model;
    public GameObject[] Materials;
    public Light myRange;
    public float range = 0f;

    void Start()
    {
        myRange = SpherePos.gameObject.AddComponent<Light>();
        myRange.type = LightType.Point;
        myRange.color = Color.blue;
        myRange.intensity = 100;
        myRange.enabled = false;

        if (MaterialType == "iron"){
            range = 3f;
            foreach(GameObject material in Materials){
                material.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                material.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0.2f,0.2f,0.2f));
                material.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", new Color(0.3f,0.3f,0.35f) * 1);
            }
        }
        if (MaterialType == "dirt"){
            range = 5f;
            foreach(GameObject material in Materials){
                material.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                material.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0.6037736f,0.5085683f,0.2876468f));
                material.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", new Color(0f,0f,0f) * 1);
            }
        }
        if (MaterialType == "gold"){
            range = 7.5f;
            foreach(GameObject material in Materials){
                material.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                material.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(1f,1f,0f));
                material.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", new Color(0.44f,0.44f,0f) * 1);
            }
        }
        if (Model.tag == "short"){
            range = range * 0.5f;
        } else if (Model.tag == "regular"){
            range = range * 1f;
        } else if (Model.tag == "tall"){
            range = range * 2f;
        }
        myRange.range = range;
    }


    // Update is called once per frame
    void Update()
    {
        if (onPath){
            myRange.color = Color.red;
        } else {
            myRange.color = Color.blue;
        }
        if ((close == true) && (Input.GetKeyDown(KeyCode.E))&& (animator.GetBool("carrying") == false )&&(!FindChildWithTag(this.gameObject, "Orb")))
        {
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<BoxCollider>().enabled = false;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            this.transform.position = player.transform.position + new Vector3(0f, 2f, 0f);
            this.transform.parent = player.transform;
            this.transform.rotation = new Quaternion(0,0,0,0);
            animator.SetBool("carrying", true);
            carrying = true;            
            myRange.enabled = true;
        } else if ((carrying == true) && ((Input.GetKeyDown(KeyCode.E))||(Input.GetKeyDown(KeyCode.Q)))&&(!onPath))
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
            myRange.enabled = false;

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
                if(found2 == false) {
                    GameObject.Find("GameMaster").gameObject.GetComponent<GameLoopManager>().towerBuilt = true;
                    found2 = true;
                }
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
