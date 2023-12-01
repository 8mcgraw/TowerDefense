using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerScript : MonoBehaviour
{
    bool close = false;
    bool carrying = false;
    public GameObject player, Projectile;
    public Animator animator;
<<<<<<< Updated upstream
    public GameObject[] target = new GameObject[100];
    public ProjectileScript projectilescript;
    void Start()
    {

=======
    public bool onPath = false;
    public GameObject SpherePos;
    public string MaterialType = "wood";
    public GameObject Model;
    public GameObject[] Materials;
    public float range = 0f;
    public Light myRange;

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
        if (MaterialType == "wood"){
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
>>>>>>> Stashed changes
    }


    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        if ((close == true) && (Input.GetKey(KeyCode.E)))
=======
        if (onPath){
            myRange.color = Color.red;
        } else {
            myRange.color = Color.blue;
        }
        if ((close == true) && (Input.GetKeyDown(KeyCode.E))&& (animator.GetBool("carrying") == false )&&(!FindChildWithTag(this.gameObject, "Orb")))
>>>>>>> Stashed changes
        {
            this.GetComponent<SphereCollider>().enabled = false;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            this.transform.position = player.transform.position + new Vector3(0.28f, -0.3f, -0.2f);
            this.transform.parent = player.transform;
            this.transform.rotation = player.transform.rotation * Quaternion.Euler(new Vector3(270, 0, 130));
            animator.SetBool("carrying", true);
            carrying = true;
<<<<<<< Updated upstream
        }
        if ((carrying == true) && (Input.GetKey(KeyCode.Q)))
=======
            myRange.enabled = true;
        }else  if ((carrying == true) && ((Input.GetKeyDown(KeyCode.Q))||(Input.GetKeyDown(KeyCode.E)))&&(!onPath))
>>>>>>> Stashed changes
        {
            this.transform.parent = null;
            this.transform.position = player.transform.position + this.transform.forward; ;
            this.transform.rotation = player.transform.rotation * Quaternion.Euler(new Vector3(270, 0, 130));
            animator.SetBool("carrying", false);
            carrying = false;
            this.GetComponent<SphereCollider>().enabled = true;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            myRange.enabled = false;

        }
    }


    void pushTarget(GameObject newTarget)
    {

        for (int i = 0; i < target.Length; i++)
        {
            if (target[i] == null)
            {
                target[i] = newTarget;
                break;
            }
        }
    }


    private GameObject popTarget()
    {

        GameObject oldTarget = target[0];
        //target[0] = null;
        for (int i = 1; i < target.Length; i++)
        {
            if (target[i] == null)
            {
                target[i - 1] = null;
                return oldTarget;
            }
            target[i - 1] = target[i];
        }
        return oldTarget;

    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            close = true;
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            pushTarget(collision.gameObject);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            close = false;
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            popTarget();
        }


    }


    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject == target[0])
        {
<<<<<<< Updated upstream
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                transform.LookAt(target[0].transform);
                Instantiate(Projectile);
                //projectilescript.attack(target[0]);
                enemy.TakeDamage(50);
                Destroy(target[0]);
=======
            collision.GetComponent<Rigidbody>().useGravity = false;
            //collision.GetComponent<SphereCollider>().enabled = false;
            collision.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            collision.transform.SetParent(this.gameObject.transform);
            // Debug.Log("THIS OBJECT: "+this.gameObject.transform.tag);
            // Debug.Log("THIS PARENT: "+collision.transform.parent.tag);
            collision.transform.position = SpherePos.gameObject.transform.position;
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
>>>>>>> Stashed changes
            }
        }
    }
}
