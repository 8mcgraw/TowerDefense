using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour
{
    public GameObject[] target = new GameObject[100];
    public ProjectileScript projectilescript;
    public float damage;
    public float cooldown = 100f;
    public float timer = 50f;
    public bool setTower = false;
    public string[] orbEffects = new string[3];
    public GameObject[] orbSpheres = new GameObject[6];
    public GameObject sphere;
    //baseSphere, redSphere, blueSphere, purpleSphere, greenSphere, yellowSphere
    public GameObject[] orbProjectiles = new GameObject[6];
    public GameObject projectile;
    //empty, redProjectile, blueProjectile, purpleProjectile, greenProjectile, yellowProjectile
    int orbEffectCount = 0;
    SphereCollider myCollider;
    public string projectileType;
    public float range = 0f; //adjust collider to fit range, change range in model section
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("OrbScript");
        myCollider = GetComponent<SphereCollider>();
        //check how many orbEffects there are
        for (int i = 0; i < orbEffects.Length; i++)
        {
            if (orbEffects[i] != "")
            {
                orbEffectCount++;
                Debug.Log(orbEffects[i] +": " + orbEffectCount);
            }
        }
        Debug.Log("Count: "+orbEffectCount);
        if (orbEffectCount == 0){
            
        } else if (orbEffectCount == 1){
    //baseSphere, redSphere, blueSphere, purpleSphere, greenSphere, yellowSphere
            if (orbEffects[0] == "fire"){
                orbSpheres[1].SetActive(true);
                orbProjectiles[1].SetActive(true);
                sphere = orbSpheres[1];
            }
            else if (orbEffects[0] == "ice"){
                orbSpheres[2].SetActive(true);
                orbProjectiles[2].SetActive(true);
                sphere = orbSpheres[2];
            }
            else if (orbEffects[0] == "death"){
                orbSpheres[3].SetActive(true);
                orbProjectiles[3].SetActive(true);
                sphere = orbSpheres[3];
            } 
            else if (orbEffects[0] == "nature"){
                orbSpheres[4].SetActive(true);
                orbProjectiles[4].SetActive(true);
                sphere = orbSpheres[4];
            }
            else if (orbEffects[0] == "holy"){
                orbSpheres[5].SetActive(true);
                orbProjectiles[5].SetActive(true);
                sphere = orbSpheres[5];
            } else {
                orbSpheres[0].SetActive(true);
                sphere = orbSpheres[0];
            }
            
        }//NEED TO HAVE 5 CHILDREN EACH UNDER MAIN ORB EFFECT
        else if (orbEffectCount > 1){
            if (orbEffects[0] == "fire"){
                orbSpheres[1].SetActive(true);
                sphere = orbSpheres[1];
            }
            else if (orbEffects[0] == "ice"){
                orbSpheres[2].SetActive(true);
                sphere = orbSpheres[2];
            }
            else if (orbEffects[0] == "death"){
                orbSpheres[3].SetActive(true);
                sphere = orbSpheres[3];
            } 
            else if (orbEffects[0] == "nature"){
                orbSpheres[4].SetActive(true);
                sphere = orbSpheres[4];
            }
            else if (orbEffects[0] == "holy"){
                orbSpheres[5].SetActive(true);
                sphere = orbSpheres[5];
            } else {
                orbSpheres[0].SetActive(true);
                sphere = orbSpheres[0];
            }
            if (orbEffects[1] == "fire"){
                orbProjectiles[1].SetActive(true);
                sphere.GetComponent<Renderer>().material = orbSpheres[1].GetComponent<Renderer>().material;
                //get the sphere's children and change their color to be this material's color
                sphere.transform.GetChild(0).GetComponent<ParticleSystem>().startColor = orbSpheres[1].transform.GetChild(0).GetComponent<ParticleSystem>().startColor;
                sphere.transform.GetChild(1).GetComponent<Light>().color = orbSpheres[1].transform.GetChild(1).GetComponent<Light>().color;
                //for each of sphere.transform.GetChild(0).transform.GetChild() set the color to be the same as orbSpheres[1].transform.GetChild(0).transform.GetChild()
                for (int i = 0; i < sphere.transform.GetChild(0).transform.childCount; i++){
                    sphere.transform.GetChild(0).transform.GetChild(i).GetComponent<ParticleSystem>().startColor = orbSpheres[1].transform.GetChild(0).transform.GetChild(i).GetComponent<ParticleSystem>().startColor;
                }
            } else if (orbEffects[1] == "ice"){
                orbProjectiles[2].SetActive(true);
                sphere.GetComponent<Renderer>().material = orbSpheres[2].GetComponent<Renderer>().material;
                sphere.transform.GetChild(0).GetComponent<ParticleSystem>().startColor = orbSpheres[2].transform.GetChild(0).GetComponent<ParticleSystem>().startColor;
                sphere.transform.GetChild(1).GetComponent<Light>().color = orbSpheres[2].transform.GetChild(1).GetComponent<Light>().color;
                for (int i = 0; i < sphere.transform.GetChild(0).transform.childCount; i++){
                    sphere.transform.GetChild(0).transform.GetChild(i).GetComponent<ParticleSystem>().startColor = orbSpheres[2].transform.GetChild(0).transform.GetChild(i).GetComponent<ParticleSystem>().startColor;
                }
            } else if (orbEffects[1] == "death"){
                orbProjectiles[3].SetActive(true);
                sphere.GetComponent<Renderer>().material = orbSpheres[3].GetComponent<Renderer>().material;
                sphere.transform.GetChild(0).GetComponent<ParticleSystem>().startColor = orbSpheres[3].transform.GetChild(0).GetComponent<ParticleSystem>().startColor;
                sphere.transform.GetChild(1).GetComponent<Light>().color = orbSpheres[3].transform.GetChild(1).GetComponent<Light>().color;
                for (int i = 0; i < sphere.transform.GetChild(0).transform.childCount; i++){
                    sphere.transform.GetChild(0).transform.GetChild(i).GetComponent<ParticleSystem>().startColor = orbSpheres[3].transform.GetChild(0).transform.GetChild(i).GetComponent<ParticleSystem>().startColor;
                }
            } else if (orbEffects[1] == "nature"){
                orbProjectiles[4].SetActive(true);
                sphere.GetComponent<Renderer>().material = orbSpheres[4].GetComponent<Renderer>().material;
                sphere.transform.GetChild(0).GetComponent<ParticleSystem>().startColor = orbSpheres[4].transform.GetChild(0).GetComponent<ParticleSystem>().startColor;
                sphere.transform.GetChild(1).GetComponent<Light>().color = orbSpheres[4].transform.GetChild(1).GetComponent<Light>().color;
                for (int i = 0; i < sphere.transform.GetChild(0).transform.childCount; i++){
                    sphere.transform.GetChild(0).transform.GetChild(i).GetComponent<ParticleSystem>().startColor = orbSpheres[4].transform.GetChild(0).transform.GetChild(i).GetComponent<ParticleSystem>().startColor;
                }
            } else if (orbEffects[1] == "holy"){
                orbProjectiles[5].SetActive(true);
                sphere.GetComponent<Renderer>().material = orbSpheres[5].GetComponent<Renderer>().material;
                sphere.transform.GetChild(0).GetComponent<ParticleSystem>().startColor = orbSpheres[5].transform.GetChild(0).GetComponent<ParticleSystem>().startColor;
                sphere.transform.GetChild(1).GetComponent<Light>().color = orbSpheres[5].transform.GetChild(1).GetComponent<Light>().color;
                for (int i = 0; i < sphere.transform.GetChild(0).transform.childCount; i++){
                    sphere.transform.GetChild(0).transform.GetChild(i).GetComponent<ParticleSystem>().startColor = orbSpheres[5].transform.GetChild(0).transform.GetChild(i).GetComponent<ParticleSystem>().startColor;
                }
            } else {
                orbProjectiles[0].SetActive(true);
                sphere.GetComponent<Renderer>().material.color = new Color(Color.white.r, Color.white.g, Color.white.b, 0.5f);
            }
            if (orbEffectCount == 3){
                if (orbEffects[2] == "fire"){
                    sphere.transform.GetChild(1).GetComponent<Light>().color = orbSpheres[1].transform.GetChild(1).GetComponent<Light>().color;
                    orbProjectiles[1].SetActive(true);
                    orbProjectiles[2].SetActive(false);
                    orbProjectiles[3].SetActive(false);
                    orbProjectiles[4].SetActive(false);
                    orbProjectiles[5].SetActive(false);
                } else if (orbEffects[2] == "ice"){
                    sphere.transform.GetChild(1).GetComponent<Light>().color = orbSpheres[2].transform.GetChild(1).GetComponent<Light>().color;
                    orbProjectiles[1].SetActive(false);
                    orbProjectiles[2].SetActive(true);
                    orbProjectiles[3].SetActive(false);
                    orbProjectiles[4].SetActive(false);
                    orbProjectiles[5].SetActive(false);
                } else if (orbEffects[2] == "death"){
                    sphere.transform.GetChild(1).GetComponent<Light>().color = orbSpheres[3].transform.GetChild(1).GetComponent<Light>().color;
                    orbProjectiles[1].SetActive(false);
                    orbProjectiles[2].SetActive(false);
                    orbProjectiles[3].SetActive(true);
                    orbProjectiles[4].SetActive(false);
                    orbProjectiles[5].SetActive(false);
                } else if (orbEffects[2] == "nature"){
                    sphere.transform.GetChild(1).GetComponent<Light>().color = orbSpheres[4].transform.GetChild(1).GetComponent<Light>().color;
                    orbProjectiles[1].SetActive(false);
                    orbProjectiles[2].SetActive(false);
                    orbProjectiles[3].SetActive(false);
                    orbProjectiles[4].SetActive(true);
                    orbProjectiles[5].SetActive(false);
                } else if (orbEffects[2] == "holy"){
                    sphere.transform.GetChild(1).GetComponent<Light>().color = orbSpheres[5].transform.GetChild(1).GetComponent<Light>().color;
                    orbProjectiles[1].SetActive(false);
                    orbProjectiles[2].SetActive(false);
                    orbProjectiles[3].SetActive(false);
                    orbProjectiles[4].SetActive(false);
                    orbProjectiles[5].SetActive(true);
                } else {
                    sphere.transform.GetChild(1).GetComponent<Light>().color = new Color(Color.white.r, Color.white.g, Color.white.b, 0.5f);
                }
            }
        }

    }

    

    void FixedUpdate(){
        if((this.transform.parent.parent != null)&&(this.transform.parent.parent.tag == "Tower")&&(setTower == false)){
            TowerScript Tower = this.transform.parent.parent.GetComponent<TowerScript>();
            string Model = Tower.Model.tag;
            if (Tower.MaterialType == "dirt"){
                range = 5f;
                projectileType = "bullet";
                cooldown = 10f;
                damage = 2f;
            } else if (Tower.MaterialType == "iron"){
                range = 3f;
                projectileType = "lazer";
                cooldown = 2f;
                damage = 0.5f;
            } else if (Tower.MaterialType == "gold"){
                range = 7.5f;
                projectileType = "splash";
                cooldown = 20f;
                damage = 3f;
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
        if(target[0] == null){
            popTarget(target[0]);
        }
        if (timer > 0){
            timer--;
        } else {
        
            if (target[0] != null)
            {
            Enemy enemy = target[0].gameObject.GetComponent<Enemy>();
                if ((target[0]!=null)&&(enemy != null)&&(enemy.currentHealth>0)&&(this.transform.parent!=null)&&(this.transform.parent.parent!=null)&&(this.transform.parent.parent.parent==null)&&(this.transform.parent.parent.tag=="Tower")&&(this.transform.parent.parent.GetComponent<TowerScript>().onPath==false))
                {
                    transform.LookAt(target[0].transform);
                    projectilescript.attack(target[0], projectileType, damage, orbEffects);
                    timer = cooldown;
                } else {
                    popTarget(target[0]);
                }
            }else{
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
                    return;
                } else {
                    if (i > 10){
                        return;
                    }
                }
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
        if (((collision.gameObject.tag == "Enemy")||(collision.gameObject.tag == "enemy"))&&(System.Array.IndexOf(target, collision.gameObject) == -1))
        {
            pushTarget(collision.gameObject);
        }
        //if target[0] is missing, pop target
        if (target[0] == null)
        {
            popTarget(target[0]);
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
