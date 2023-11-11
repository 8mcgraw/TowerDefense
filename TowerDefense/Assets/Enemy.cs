using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Spawn;
    public Animator animator;
    public float maxHealth;
    public float currentHealth;
    public float speed;
    public int NodeIndex;
    public int ID;

    void Start(){
        Init();
    }
    public void Init(){
        currentHealth = maxHealth;
        gameObject.transform.position = Spawn.transform.position;//Spawn.gameObject.GetComponent<GameLoopManager>().NodeParent.position;
        NodeIndex = 0;

        Transform goal = GameObject.FindGameObjectWithTag("Finish").transform;
        UnityEngine.AI.NavMeshAgent agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        //agent.transform.position = Spawn.transform.position;
        agent.destination = goal.position;
    }
    void Update(){
        if(currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
        else
        {
        Transform goal = GameObject.FindGameObjectWithTag("Finish").transform;
        UnityEngine.AI.NavMeshAgent agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;
        }
    }
    public void TakeDamage(int i){
        currentHealth -= i;
    }
    IEnumerator Die(){
        animator.SetBool("Dead", true);
        speed = 0;
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        //Destroy(gameObject);
        //gameObject.SetActive(false);
        //EntitySummoner.RemoveEnemy(this);
        yield return new WaitForSeconds(4);
        EntitySummoner.RemoveEnemy(this);
        //GameLoopManager.EnqueueEnemyToRemove(this);
    }
}
