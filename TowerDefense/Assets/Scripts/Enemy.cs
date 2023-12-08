using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    public List<float> effectDuration = new List<float>();
    //effects: slowed, fire, death, poisoned, frozen, stunned, bleeding, blown 
    //ice slow is building up, nature slow is decaying slow
    public GameObject ice, nature, death, poisoned, frozen, stunned, bleeding, fire, blown;
    public float iceAmount, natureAmount;
    public float bonusDamageOnHit = 0f;
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
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
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
                if (effects[i] == "ice"){
                    iceAmount = (effectDuration[i])/400f;
                } else if (effects[i] == "nature"){
                    natureAmount = (effectDuration[i])/200f;
                }
                if (effectDuration[i] <= 0f)
                {
                    RemoveEffect(effects[i]);
                } 
            }
        }
        //constantly update nature slow and ice slow
        speed = baseSpeed - (iceAmount + natureAmount);
        if (speed < 0.1f){
            speed = 0.1f;
        }
        this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = speed;
    }
    public void TakeDamage(float damage){
        currentHealth -= damage + bonusDamageOnHit;
    }
    private void pushEffect(string effect)
    {

        for (int i = 0; i < effects.Length; i++)
        {
            if (effects[i] == "")
            {
                effects[i] = effect;
                if (effect == "ice"){
                    effectDuration[i] += 20f;
                    iceAmount = (effectDuration[i])/400f;
                }else{
                    effectDuration[i] = 200f;
                }
                if (effect == "nature"){
                    natureAmount = (effectDuration[i])/200f;
                }
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
                    effectDuration[i - 1] = 0f;
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
    public void ApplyEffect(string[] effects2){
        for (int j = 0; j < 3; j++)
        {
            if (effects2[j] == "")
            {
                break;
            }
        string effect = effects2[j];
            if (!(((IList)effects).Contains((effect)))){
            pushEffect(effect);
            if (effect == "ice"){
                ice.SetActive(true);
            } else if (effect == "nature"){
                nature.SetActive(true);
            } else if (effect == "death"){
                bonusDamageOnHit += 1f;
                death.SetActive(true);
            } else if (effect == "poisoned"){
                dot += 0.2f;
                poisoned.SetActive(true);
            } else if (effect == "frozen"){
                // removedSpeedFrozen = speed;
                // speed = 0;
                frozen.SetActive(true);
            } else if (effect == "stunned"){
                // removedSpeedStun = speed;
                // speed = 0;
                stunned.SetActive(true);
            } else if (effect == "bleeding"){
                dot += 0.3f;
                bleeding.SetActive(true);
            } else if (effect == "fire"){
                dot += 0.05f;
                bonusDamageOnHit += .3f;
                fire.SetActive(true);
            } else if (effect == "blown"){
                // speed -= 20 + baseSpeed;
                blown.SetActive(true);
            }
            
        } else {
            for (int i = 0; i < effects.Length; i++)
            {
                if (effects[i] == effect)
                {
                    if (effect == "ice"){
                        effectDuration[i] += 20f;
                        iceAmount = (effectDuration[i])/400f;
                    } else {
                        effectDuration[i] = 200f;
                    }
                    if (effect == "nature"){
                        natureAmount = (effectDuration[i])/200f;
                    }
                    break;
                }
            }
        }
        }
    }
    public void RemoveEffect(string effect){
        if (((IList)effects).Contains((effect))){
            popEffect(effect);
            if (effect == "ice"){
                iceAmount = 0;
                ice.SetActive(false);
            } else if (effect == "nature"){
                natureAmount = 0;
                nature.SetActive(false);
            } else if (effect == "death"){
                bonusDamageOnHit -= 1f;
                death.SetActive(false);
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
            } else if (effect == "fire"){
                dot -= 0.1f;
                bonusDamageOnHit -= 0.3f;
                fire.SetActive(false);
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
