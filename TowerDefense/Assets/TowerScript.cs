using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerScript : MonoBehaviour
{
    bool close = false;
    bool carrying = false;
    public int damage;
    public GameObject player, Projectile;
    public Animator animator;
    public GameObject[] target = new GameObject[100];
    public ProjectileScript projectilescript;
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if ((close == true) && (Input.GetKey(KeyCode.E)))
        {
            this.GetComponent<SphereCollider>().enabled = false;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            this.transform.position = player.transform.position + new Vector3(0.28f, -0.3f, -0.2f);
            this.transform.parent = player.transform;
            this.transform.rotation = player.transform.rotation * Quaternion.Euler(new Vector3(270, 0, 130));
            animator.SetBool("carrying", true);
            carrying = true;
        }
        if ((carrying == true) && (Input.GetKey(KeyCode.Q)))
        {
            this.transform.parent = null;
            this.transform.position = player.transform.position + this.transform.forward; ;
            this.transform.rotation = player.transform.rotation * Quaternion.Euler(new Vector3(270, 0, 130));
            animator.SetBool("carrying", false);
            carrying = false;
            this.GetComponent<SphereCollider>().enabled = true;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;


        }
    }

    void FixedUpdate(){
        Enemy enemy = target[0].gameObject.GetComponent<Enemy>();
            if ((enemy != null)&&(enemy.currentHealth>0))
            {
                transform.LookAt(target[0].transform);
                projectilescript.attack(target[0]);
                enemy.TakeDamage(damage);
            } else {
                popTarget();
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
}
