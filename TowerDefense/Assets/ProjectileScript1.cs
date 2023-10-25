using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript1 : MonoBehaviour
{
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void attack(GameObject target)
    {
        for (int i = 0; i < 10; i++)
        {
            transform.LookAt(target.transform);

            this.gameObject.transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale * (Vector3.Distance(transform.position, target.transform.position)), i/10);
            this.gameObject.transform.position = Vector3.Lerp(transform.position, Vector3.Lerp(transform.position, target.transform.position, 0.5F), i/10);
        }

    }

}
