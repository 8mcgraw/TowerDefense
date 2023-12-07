using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Spawn;
    public Animator animator;
    public float maxHealth;
    public float currentHealth = 1;
    public float baseSpeed;
    public float speed;
    public float removedSpeedStun;
    public float removedSpeedFrozen;
    public int NodeIndex;
    public int ID;
    public string[] effects = new string[100];
    public int[] effectDuration = new int[100];
    //effects: slowed, burning, cursed, poisoned, frozen, stunned, bleeding, blown 
    public GameObject slow, slow2, cursed, poisoned, frozen, stunned, bleeding, burning, blown;
    public int bonusDamageOnHit = 0;
    public float dot = 0f;
    public Transform goal;

    void Start(){
        Init();
    }
    public void Init(){
        currentHealth = maxHealth;
        transform.position = Spawn.transform.position;//ADDED to force start position
        Transform goal = GameObject.FindGameObjectWithTag("Finish").transform;
        UnityEngine.AI.NavMeshAgent agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;
        speed = baseSpeed;
    }
    void Update(){
    }
    void FixedUpdate(){
        if(currentHealth <= 0){
            StartCoroutine(Die());
        } else {
        Transform goal = GameObject.FindGameObjectWithTag("Finish").transform;
        UnityEngine.AI.NavMeshAgent agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;
        }

        if (dot>0f){
            currentHealth -= dot;
        }
        for (int i = 0; i < effects.Length; i++)
        {
            if (effects[i] == "")
            {
                break;
            } else {
                effectDuration[i]--;
                if (effectDuration[i] <= 0)
                {
                    RemoveEffect(effects[i]);
                } 
            }
        }
        this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = speed;

    }
    public void TakeDamage(int damage){
        currentHealth -= damage + bonusDamageOnHit;
    }
    private void pushEffect(string effect)
    {

        for (int i = 0; i < effects.Length; i++)
        {
            if (effects[i] == "")
            {
                effects[i] = effect;
                effectDuration[i] = 300;
                break;
            }
        }
    }


    private void popEffect(string effect)
    {
        bool found = false;
        for (int i = 0; i < effects.Length; i++)
        {
            if (effects[i] == "")
            {
                if (found)
                {
                    effects[i - 1] = "";
                    effectDuration[i - 1] = 0;
                }
                return;
            }
            if (found)
            {
                effects[i - 1] = effects[i];
                effectDuration[i - 1] = effectDuration[i];
            }
            if (effects[i] == effect)
            {
                found = true;
            }
        }
        return;

    }
    public void ApplyEffect(string effect){
        if (!(((IList)effects).Contains((effect)))){
            pushEffect(effect);
            if (effect == "slow"){
                speed -= baseSpeed/2;
                slow.SetActive(true);
            } else if (effect == "slow2"){
                speed -= 3*(baseSpeed/4);
                slow2.SetActive(true);
            } else if (effect == "cursed"){
                bonusDamageOnHit += 3;
                cursed.SetActive(true);
            } else if (effect == "poisoned"){
                dot += 0.2f;
                poisoned.SetActive(true);
            } else if (effect == "frozen"){
                removedSpeedFrozen = speed;
                speed = 0;
                frozen.SetActive(true);
            } else if (effect == "stunned"){
                removedSpeedStun = speed;
                speed = 0;
                stunned.SetActive(true);
            } else if (effect == "bleeding"){
                dot += 0.3f;
                bleeding.SetActive(true);
            } else if (effect == "burning"){
                dot += 0.1f;
                bonusDamageOnHit += 1;
                burning.SetActive(true);
            } else if (effect == "blown"){
                speed -= 20 + baseSpeed;
                blown.SetActive(true);
            }
            
        } else {
            for (int i = 0; i < effects.Length; i++)
            {
                if (effects[i] == effect)
                {
                    effectDuration[i] = 300;
                    break;
                }
            }
        }
    }
    public void RemoveEffect(string effect){
        if (((IList)effects).Contains((effect))){
            popEffect(effect);
            if (effect == "slow"){
                speed += baseSpeed/2;
                slow.SetActive(false);
            } else if (effect == "slow2"){
                speed += 3*(baseSpeed/4);
                slow2.SetActive(false);
            } else if (effect == "cursed"){
                bonusDamageOnHit -= 3;
                cursed.SetActive(false);
            } else if (effect == "poisoned"){
                dot -= 0.2f;
                poisoned.SetActive(false);
            } else if (effect == "frozen"){
                speed += removedSpeedFrozen;
                removedSpeedFrozen = 0;
                frozen.SetActive(false);
            } else if (effect == "stunned"){
                speed += removedSpeedStun;
                removedSpeedStun = 0;
                stunned.SetActive(false);
            } else if (effect == "bleeding"){
                dot -= 0.3f;
                bleeding.SetActive(false);
            } else if (effect == "burning"){
                dot -= 0.1f;
                bonusDamageOnHit -= 1;
                burning.SetActive(false);
            } else if (effect == "blown"){
                speed += 20 + baseSpeed;
                blown.SetActive(false);
            }
        }
    }
    IEnumerator Die(){
        animator.SetBool("Dead", true);
        //remove effects
        for (int i = 0; i < effects.Length; i++)
        {
            if (effects[i] == "")
            {
                break;
            }
            RemoveEffect(effects[i]);
        }
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
