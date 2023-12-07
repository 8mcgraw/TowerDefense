using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public int speed;
    public bool activate = false;
    private GameObject newTarget;
    public float i = 0;
    public string attackType = "bullet";
    private Vector3 originalSize;
    public float attackDamage = 0;
    public GameObject bulletAnimation;
    public string[] effects = new string[3];
    public GameObject[] splashHit = new GameObject[100];
    public AudioClip laserSound;
    public AudioClip bulletSound;
    public AudioClip splashSound;
    public AudioSource audioSource;
    public GameObject sound;

    // Start is called before the first frame update
    void Start()
    {
        originalSize = this.gameObject.transform.localScale;

        // Create a new AudioSource and play the clip
        audioSource = gameObject.AddComponent<AudioSource>();
        sound = GameObject.Find("Progression");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("Projectile");
        if ((attackType == "lazer")&&(activate == true)){
            Debug.Log("Lazer2");
            if (bulletAnimation != null)
            {
                Destroy(bulletAnimation);
            }
            this.gameObject.SetActive(true);
            Debug.Log("Lazer2.1");
            if((i<1)&&(sound.GetComponent<ToggleSFX>().sfx == true))
            {
                Debug.Log("Lazer2.25");
                audioSource.PlayOneShot(laserSound, 0.05f);
            }
            Debug.Log("Lazer2.5");
            // Calculate the scale of the projectile
            float scale = 0.10f + (1.1f * Vector3.Distance(this.transform.parent.position, newTarget.transform.position));
            this.gameObject.transform.localScale = new Vector3(0.10f, 0.10f, scale);

            // Set the position of the projectile halfway between the parent and the target
            this.gameObject.transform.position = Vector3.Lerp(this.transform.parent.position, newTarget.transform.position, 0.5f);
            //this.gameObject.transform.position = new Vector3(0f, Vector3.Distance(transform.parent.position, newTarget.transform.position), 0f);
            if ((i%10 >= 9)){
                Debug.Log("Lazer3");
                activate = false;
                newTarget.gameObject.GetComponent<Enemy>().TakeDamage(attackDamage);
                newTarget.gameObject.GetComponent<Enemy>().ApplyEffect(effects);
            }
            Debug.Log("Lazer");
            i++;
        } else if((attackType == "bullet")&&(activate == true)){
            this.gameObject.SetActive(true);
            if((i<1)&&(sound.GetComponent<ToggleSFX>().sfx == true))
            {
                audioSource.PlayOneShot(bulletSound, 0.05f);
            }
            this.gameObject.transform.position = Vector3.Lerp(this.transform.parent.position, newTarget.transform.position, (i%10)/10);
            if (i%10 >= 9){
                activate = false;
                newTarget.gameObject.GetComponent<Enemy>().TakeDamage(attackDamage);
                newTarget.gameObject.GetComponent<Enemy>().ApplyEffect(effects);
            }
            i++;
        } else if ((attackType == "splash")&&(activate == true)) {
            this.gameObject.transform.position = Vector3.Lerp(this.transform.parent.position, newTarget.transform.position, (i%20)/20);
            this.gameObject.transform.localScale = Vector3.Lerp(originalSize, originalSize*7f, (i%20)/20);
            this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0,90*i,0));
            this.gameObject.SetActive(true);
            if((i<1)&&(sound.GetComponent<ToggleSFX>().sfx == true))
            {
            audioSource.time = 200f;
            audioSource.PlayOneShot(splashSound, 0.05f);
            }
            if (i%20 >= 19){
                activate = false;
                for (int j = 0; j < splashHit.Length; j++){
                    if (splashHit[j] != null){
                        splashHit[j].gameObject.GetComponent<Enemy>().TakeDamage(attackDamage);
                        splashHit[j].gameObject.GetComponent<Enemy>().ApplyEffect(effects);
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
    public void attack(GameObject target, string type, float damage, string[] orbEffects)
{
        this.gameObject.SetActive(true);
        Debug.Log("test");
        newTarget = target;
        activate = true;
        attackType = type;
        attackDamage = damage;
        effects = orbEffects;
        if ((orbEffects[0] == "holy")||(orbEffects[1] == "holy")||(orbEffects[2] == "holy"))
        {
            attackDamage = damage*3;
        }
        //i = 0;
    }

    //on destroy
    public void OnDisable()
    {
        //Destroy(audioSource, splashSound.length);
    }

}
