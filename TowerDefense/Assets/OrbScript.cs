using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour
{
    public GameObject[] target = new GameObject[100];
    public ProjectileScript projectilescript;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    void FixedUpdate(){
        if (target[0] != null)
        {
        Enemy enemy = target[0].gameObject.GetComponent<Enemy>();
            if ((target[0]!=null)&&(enemy != null)&&(enemy.currentHealth>0)&&(this.transform.parent!=null)&&(this.transform.parent.parent!=null)&&(this.transform.parent.parent.parent==null)&&(this.transform.parent.parent.tag=="Tower"))
            {
                transform.LookAt(target[0].transform);
                projectilescript.attack(target[0]);
                enemy.TakeDamage(damage);
            } else {
                popTarget(target[0]);
            }
        }
    }

    private void pushTarget(GameObject newTarget)
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


    private void popTarget(GameObject oldTarget)
    {
        bool found = false;
        for (int i = 0; i < target.Length; i++)
        {
            if (target[i] == null)
            {
                if (found)
                {
                    target[i - 1] = null;
                }
                return;
            }
            if (found)
            {
                target[i - 1] = target[i];
            }
            if (target[i] == oldTarget)
            {
                found = true;
            }
        }
        return;

    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            pushTarget(collision.gameObject);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            popTarget(collision.gameObject);
        }
    }

}
