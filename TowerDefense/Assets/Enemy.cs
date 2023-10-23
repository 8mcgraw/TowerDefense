using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public float maxHealth;
    public float currentHealth;
    public float speed;
    public int ID;

    void Start(){
        Init();
    }
    public void Init(){
        currentHealth = maxHealth;
        
        Transform goal = GameObject.FindGameObjectWithTag("Finish").transform;
        UnityEngine.AI.NavMeshAgent agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;
    }
    void Update(){
        Transform goal = GameObject.FindGameObjectWithTag("Finish").transform;
        UnityEngine.AI.NavMeshAgent agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;
        if(currentHealth <= 0){
            StartCoroutine(Die());
        }
    }
    public void TakeDamage(){
        currentHealth -= 1;
    }
    IEnumerator Die(){
        animator.SetBool("Dead", true);
        speed = 0;
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        //Destroy(gameObject);
        //gameObject.SetActive(false);
        //EntitySummoner.RemoveEnemy(this);
        yield return new WaitForSeconds(4);
        //GameLoopManager.EnqueueEnemyToRemove(this);
    }
}
