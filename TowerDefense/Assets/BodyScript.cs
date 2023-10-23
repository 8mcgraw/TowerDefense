using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay (Collider collision)
    {
        if ((collision.gameObject.tag == "Head")&&(collision.transform.parent == null))
        {
            collision.GetComponent<Rigidbody>().useGravity = false;
            collision.GetComponent<SphereCollider>().enabled = false;
            collision.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            collision.transform.SetParent(this.gameObject.transform);
            Debug.Log("THIS OBJECT: "+this.gameObject.transform.tag);
            Debug.Log("THIS PARENT: "+collision.transform.parent.tag);
            collision.transform.position = this.transform.position + new Vector3(0.07f, 0.75f, 0.0f);
            collision.transform.rotation = this.transform.rotation * Quaternion.Euler(0, 280, 0);
            collision.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Debug.Log("Head has collided with the body");
        }
    }
}
