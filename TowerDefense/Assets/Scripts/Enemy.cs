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
    //effects: slowed, burning, cursed, poisoned, frozen, stunned, bleeding, blown 
    //iceSlow is building up, nature slow is decaying slow
    public GameObject iceSlow, natureSlow, cursed, poisoned, frozen, stunned, bleeding, burning, blown;
    public float iceSlowAmount, natureSlowAmount;
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
                if (effects[i] == "iceSlow"){
                    iceSlowAmount = (effectDuration[i])/500f;
                } else if (effects[i] == "natureSlow"){
                    natureSlowAmount = (effectDuration[i])/300f;
                }
                if (effectDuration[i] <= 0f)
                {
                    RemoveEffect(effects[i]);
                } 
            }
        }
        //constantly update nature slow and ice slow
        speed = baseSpeed - (iceSlowAmount + natureSlowAmount);
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
                if (effect == "iceSlow"){
                    effectDuration[i] += 20f;
                    iceSlowAmount = (effectDuration[i])/500f;
                }else{
                    effectDuration[i] = 200f;
                }
                if (effect == "natureSlow"){
                    natureSlowAmount = (effectDuration[i])/200f;
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
    public void ApplyEffect(string[] effects){
        for (int j = 0; j < effects.Length; j++)
        {
            if (effects[j] == "")
            {
                break;
            }
        string effect = effects[j];
            if (!(((IList)effects).Contains((effect)))){
            pushEffect(effect);
            if (effect == "iceSlow"){
                iceSlow.SetActive(true);
            } else if (effect == "natureSlow"){
                natureSlow.SetActive(true);
            } else if (effect == "cursed"){
                bonusDamageOnHit += 3;
                cursed.SetActive(true);
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
            } else if (effect == "burning"){
                dot += 0.1f;
                bonusDamageOnHit += 1;
                burning.SetActive(true);
            } else if (effect == "blown"){
                // speed -= 20 + baseSpeed;
                blown.SetActive(true);
            }
            
        } else {
            for (int i = 0; i < effects.Length; i++)
            {
                if (effects[i] == effect)
                {
                    if (effect == "iceSlow"){
                        effectDuration[i] += 20f;
                        iceSlowAmount = (effectDuration[i])/500f;
                    } else {
                        effectDuration[i] = 200f;
                    }
                    if (effect == "natureSlow"){
                        natureSlowAmount = (effectDuration[i])/200f;
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
            if (effect == "iceSlow"){
                iceSlowAmount = 0;
                iceSlow.SetActive(false);
            } else if (effect == "natureSlow"){
                natureSlowAmount = 0;
                natureSlow.SetActive(false);
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
