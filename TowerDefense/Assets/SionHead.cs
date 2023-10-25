using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SionHead : MonoBehaviour
{
    // public GameObject textStart;
    // public GameObject textElder;
    // public GameObject textHeads;
    bool close = false;
    bool carrying = false;
    public GameObject player;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((close==true)&&(Input.GetKey (KeyCode.E))){
            this.GetComponent<SphereCollider>().enabled = false;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            this.transform.position = player.transform.position + new Vector3(0.28f, -0.3f, -0.2f);
            this.transform.parent = player.transform;
            this.transform.rotation = player.transform.rotation * Quaternion.Euler(new Vector3(270,0,130));
            // textHeads.SetActive(false);
            // textElder.SetActive(true);
            // Debug.Log("Player has picked up the sion head");
            animator.SetBool("carrying", true);
            carrying = true;
        }
        if ((carrying==true)&&(Input.GetKey (KeyCode.Q))){
            this.transform.parent = null;
            this.transform.position = player.transform.position + this.transform.forward;;
            this.transform.rotation = player.transform.rotation * Quaternion.Euler(new Vector3(270,0,130));
            // textElder.SetActive(false);
            // textStart.SetActive(true);
            // Debug.Log("Player has dropped the sion head");
            animator.SetBool("carrying", false);
            carrying = false;
            this.GetComponent<SphereCollider>().enabled = true;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        } 
    }
    void OnTriggerEnter (Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // textStart.SetActive(false);
            // textElder.SetActive(false);
            // textHeads.SetActive(true);
            // Debug.Log("Player has collided with the sion head");
            close = true;
        }
    }
    private void OnTriggerExit(Collider collision)
{
    if (collision.gameObject.tag == "Player")
    {
        close = false;
        // textStart.SetActive(false);
        // textElder.SetActive(true);
        // textHeads.SetActive(false);
    }

}

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(1);
        }
    }
    }
}
