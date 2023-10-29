using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public GameObject Projectile;
    public int speed;
    private bool activate = false;
    private GameObject newTarget;
    private float i = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (activate == true){
            this.gameObject.SetActive(true);
                //transform.LookAt(newTarget.transform);
                this.gameObject.transform.localScale = new Vector3(0.25f, 0.25f, 0.3f*Vector3.Distance(this.transform.parent.position, newTarget.transform.position));
                //this.gameObject.transform.localScale = new Vector3(0.6f, i%10, 0.49f);
                //Vector3.Lerp(transform.localScale, transform.localScale *10* (Vector3.Distance(transform.position, newTarget.transform.position)), i / 10);
                //Vector3(0.6, x, 0.49)
                this.gameObject.transform.localPosition = new Vector3(0f, 0f, (Vector3.Lerp(transform.parent.position, newTarget.transform.position, 0.5F)).y);
                //this.gameObject.transform.position = new Vector3(0f, Vector3.Distance(transform.parent.position, newTarget.transform.position), 0f);
                //Bullet: this.gameObject.transform.position = Vector3.Lerp(this.transform.parent.position, newTarget.transform.position, i % 10);
                i++;
        } else {
            this.gameObject.SetActive(false);
        }
        if (i%10 >= 9){
            activate = false;
        }

    }

    void FixedUpdate(){
    }
    public void attack(GameObject target)
    {
        this.gameObject.SetActive(true);
        //Debug.Log("test");
        newTarget = target;
        activate = true;
    }

}
