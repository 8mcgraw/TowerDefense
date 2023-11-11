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
    public string attackType = "bullet";
    private Vector3 originalSize;
    private int attackDamage = 0;

    // Start is called before the first frame update
    void Start()
    {
        originalSize = this.gameObject.transform.localScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((attackType == "lazer")&&(activate == true)){
            this.gameObject.SetActive(true);
            //transform.LookAt(newTarget.transform);
            //this.gameObject.transform.localScale = new Vector3(0.6f, i%10, 0.49f);
            //Vector3.Lerp(transform.localScale, transform.localScale *10* (Vector3.Distance(transform.position, newTarget.transform.position)), i / 10);
            //Vector3(0.6, x, 0.49)
            this.gameObject.transform.localScale = new Vector3(0.10f, 0.10f, 1.1f*Vector3.Distance(this.transform.parent.position, newTarget.transform.position));
            this.gameObject.transform.position = Vector3.Lerp(this.transform.parent.position, newTarget.transform.position, 0.5f);
            //this.gameObject.transform.position = new Vector3(0f, Vector3.Distance(transform.parent.position, newTarget.transform.position), 0f);
            if (i%10 >= 9){
                activate = false;
                newTarget.gameObject.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
            i++;
        } else if((attackType == "bullet")&&(activate == true)){
            this.gameObject.SetActive(true);
            this.gameObject.transform.position = Vector3.Lerp(this.transform.parent.position, newTarget.transform.position, (i%10)/10);
            if (i%10 >= 9){
                activate = false;
                newTarget.gameObject.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
            i++;
        } else if ((attackType == "splash")&&(activate == true)) {
            this.gameObject.transform.position = Vector3.Lerp(this.transform.parent.position, newTarget.transform.position, (i%20)/20);
            this.gameObject.transform.localScale = Vector3.Lerp(originalSize, originalSize*7f, (i%20)/20);
            this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0,90*i,0));
            this.gameObject.SetActive(true);
            if (i%20 >= 19){
                activate = false;
                newTarget.gameObject.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
            i++;
        } else {
            i=0;
            this.gameObject.SetActive(false);
        }

    }
                    //pierce??
            // this.gameObject.transform.position = Vector3.Lerp(this.transform.parent.position, newTarget.transform.position, (i%10)/10);
            // this.gameObject.transform.localScale = new Vector3(0.25f, 0.25f, 0.3f*Vector3.Distance(this.transform.parent.position, newTarget.transform.position));
    public void attack(GameObject target, string type, int damage)
    {
        this.gameObject.SetActive(true);
        //Debug.Log("test");
        newTarget = target;
        activate = true;
        attackType = type;
        attackDamage = damage;
    }

}
