using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbPhysics : MonoBehaviour
{
    bool close = false;
    public bool carrying = false;
    public Animator animator;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((close == true) && (Input.GetKey(KeyCode.E))&& (animator.GetBool("carrying") == false )&&(this.transform.parent==null))
        {
            this.GetComponent<SphereCollider>().enabled = false;
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            this.transform.position = player.transform.position + new Vector3(0f, 0f, -1f);
            this.transform.parent = player.transform;
            //this.transform.rotation = player.transform.rotation * Quaternion.Euler(new Vector3(270, 0, 130));
            animator.SetBool("carrying", true);
            carrying = true;
        }
        if ((carrying == true) && (Input.GetKey(KeyCode.Q)))
        {
            this.transform.parent = null;
            //this.transform.rotation = player.transform.rotation * Quaternion.Euler(new Vector3(270, 0, 130));
            animator.SetBool("carrying", false);
            carrying = false;
            this.GetComponent<SphereCollider>().enabled = true;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;


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
}
