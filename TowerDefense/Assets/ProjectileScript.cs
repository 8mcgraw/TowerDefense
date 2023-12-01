using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public int speed;
    private bool activate = false;
    private GameObject newTarget;
    private float i = 0;
    public string attackType = "bullet";
    private Vector3 originalSize;
    private int attackDamage = 0;
    public GameObject bulletAnimation;
    private string effect;
    public GameObject[] splashHit = new GameObject[100];
    public AudioClip laserSound;
    public AudioClip bulletSound;
    public AudioClip splashSound;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        originalSize = this.gameObject.transform.localScale;

        // Create a new AudioSource and play the clip
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((attackType == "lazer")&&(activate == true)){
            if (bulletAnimation != null)
            {
                Destroy(bulletAnimation);
            }
            this.gameObject.SetActive(true);
            if(i<1)
            {
                audioSource.PlayOneShot(laserSound, 0.2f);
            }

            // Calculate the scale of the projectile
            float scale = 0.10f + (1.1f * Vector3.Distance(this.transform.parent.position, newTarget.transform.position));
            this.gameObject.transform.localScale = new Vector3(0.10f, 0.10f, scale);

            // Set the position of the projectile halfway between the parent and the target
            this.gameObject.transform.position = Vector3.Lerp(this.transform.parent.position, newTarget.transform.position, 0.5f);
            //this.gameObject.transform.position = new Vector3(0f, Vector3.Distance(transform.parent.position, newTarget.transform.position), 0f);
            if (i%10 >= 9){
                activate = false;
                newTarget.gameObject.GetComponent<Enemy>().TakeDamage(attackDamage);
                newTarget.gameObject.GetComponent<Enemy>().ApplyEffect(effect);
            }
            i++;
        } else if((attackType == "bullet")&&(activate == true)){
            this.gameObject.SetActive(true);
            if(i<1)
            {
                audioSource.PlayOneShot(bulletSound, 0.2f);
            }
            this.gameObject.transform.position = Vector3.Lerp(this.transform.parent.position, newTarget.transform.position, (i%10)/10);
            if (i%10 >= 9){
                activate = false;
                newTarget.gameObject.GetComponent<Enemy>().TakeDamage(attackDamage);
                newTarget.gameObject.GetComponent<Enemy>().ApplyEffect(effect);
            }
            i++;
        } else if ((attackType == "splash")&&(activate == true)) {
            this.gameObject.transform.position = Vector3.Lerp(this.transform.parent.position, newTarget.transform.position, (i%20)/20);
            this.gameObject.transform.localScale = Vector3.Lerp(originalSize, originalSize*7f, (i%20)/20);
            this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0,90*i,0));
            this.gameObject.SetActive(true);
            if(i<1)
            {
            audioSource.time = 200f;
            audioSource.PlayOneShot(splashSound, 0.2f);
            }
            if (i%20 >= 19){
                activate = false;
                for (int j = 0; j < splashHit.Length; j++){
                    if (splashHit[j] != null){
                        splashHit[j].gameObject.GetComponent<Enemy>().TakeDamage(attackDamage);
                        splashHit[j].gameObject.GetComponent<Enemy>().ApplyEffect(effect);
                    }
                }
            }
            i++;
        } else {
            i=0;
            this.gameObject.SetActive(false);
        }

    }
    void OnTriggerEnter(Collider collision){
        if ((collision.gameObject.tag == "enemy")&&(attackType == "splash")&&(System.Array.IndexOf(splashHit, collision.gameObject) == -1)){
            //check if they are in the hit list, if not add them
            if (splashHit[0] == null){
                splashHit[0] = collision.gameObject;
            } else {
                for (int i = 0; i < splashHit.Length; i++){
                    if (splashHit[i] == null){
                        splashHit[i] = collision.gameObject;
                        break;
                    }
                }
            }
        }
    }

                    //pierce??
            // this.gameObject.transform.position = Vector3.Lerp(this.transform.parent.position, newTarget.transform.position, (i%10)/10);
            // this.gameObject.transform.localScale = new Vector3(0.25f, 0.25f, 0.3f*Vector3.Distance(this.transform.parent.position, newTarget.transform.position));
    public void attack(GameObject target, string type, int damage, string orbEffect)
    {
        GameObject newTarget = target;
        for (int i = 0; i < 10; i++)
        {
            transform.LookAt(newTarget.transform);

            this.gameObject.transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale * (Vector3.Distance(transform.position, newTarget.transform.position)), i / 10);
            this.gameObject.transform.position = Vector3.Lerp(transform.position, Vector3.Lerp(transform.position, newTarget.transform.position, 0.5F), i / 10);
        }
        this.gameObject.SetActive(false);
    }

    //on destroy
    public void OnDisable()
    {
        Destroy(audioSource, splashSound.length);
    }

}
