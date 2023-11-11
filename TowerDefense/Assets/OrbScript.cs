using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour
{
    public GameObject[] target = new GameObject[100];
    public ProjectileScript projectilescript;
    public int damage;
    public float cooldown = 100f;
    public float timer = 50f;
    public bool setTower = false;
    SphereCollider myCollider;
    string projectileType;
    public float range = 0f; //adjust collider to fit range, change range in model section
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<SphereCollider>();
        
    }

    

    void FixedUpdate(){
        if((this.transform.parent.parent != null)&&(this.transform.parent.parent.tag == "Tower")&&(setTower == false)){
            TowerScript Tower = this.transform.parent.parent.GetComponent<TowerScript>();
            string Model = Tower.Model.tag;
            if (Tower.MaterialType == "wood"){
                range = 5f;
                projectileType = "bullet";
                cooldown = 10f;
                damage = 5;
            } else if (Tower.MaterialType == "iron"){
                range = 3f;
                projectileType = "lazer";
                cooldown = 2f;
                damage = 1;
            } else if (Tower.MaterialType == "gold"){
                range = 7.5f;
                projectileType = "splash";
                cooldown = 20f;
                damage = 10;
            }
            if (Model == "short"){
            cooldown = cooldown * 0.5f;
            range = range * 0.5f;
            } else if (Model == "regular"){
            cooldown = cooldown * 1f;
            range = range * 1f;
            } else if (Model == "tall"){
            cooldown = cooldown * 2f;
            range = range * 2f;
            }
            myCollider.radius = range;
            setTower = true;
        }
        if (timer > 0){
            timer--;
        } else {
            timer = cooldown;
        
            if (target[0] != null)
            {
            Enemy enemy = target[0].gameObject.GetComponent<Enemy>();
                if ((target[0]!=null)&&(enemy != null)&&(enemy.currentHealth>0)&&(this.transform.parent!=null)&&(this.transform.parent.parent!=null)&&(this.transform.parent.parent.parent==null)&&(this.transform.parent.parent.tag=="Tower")&&(this.transform.parent.parent.GetComponent<TowerScript>().onPath==false))
                {
                    transform.LookAt(target[0].transform);
                    projectilescript.attack(target[0], projectileType, damage);
                } else {
                    popTarget(target[0]);
                }
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
        if ((collision.gameObject.tag == "Enemy")||(collision.gameObject.tag == "enemy"))
        {
            pushTarget(collision.gameObject);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if ((collision.gameObject.tag == "Enemy")||(collision.gameObject.tag == "enemy"))
        {
            popTarget(collision.gameObject);
        }
    }

}
