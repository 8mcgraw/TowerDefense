using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    private static Queue<Enemy> EnemiesToRemove;
    private static Queue<int> EnemyIDsToSummon;
    public bool endLoop = false;
    public int timer = 0;
    public bool wave1 = false, wave2 = false, wave3 = false;
    public bool pause1 = false, pause2 = false, pause3 = false;
    public int spawnPoint = 0;
    public int level = 1;
    public bool pause = false;
    // Start is called before the first frame update
    void Start()
    {
        EnemiesToRemove = new Queue<Enemy>();
        EnemyIDsToSummon = new Queue<int>();
        EntitySummoner.Init();

        StartCoroutine(GameLoop());
        // SummonTest();
        //InvokeRepeating("SummonTest", 6f, 1f);
        //InvokeRepeating("RemoveTest", 0f, 1.5f);
    }

    // Update is called once per frame

    void SummonTest(){
        //EnqueueEnemyIDsToSummon(1);
    }

    void RemoveTest(){
        if(EntitySummoner.EnemiesInGame.Count > 0){
            EntitySummoner.RemoveEnemy(EntitySummoner.EnemiesInGame[Random.Range(0, EntitySummoner.EnemiesInGame.Count)]);
        }
    }

    IEnumerator GameLoop()
    {

        while(endLoop == false)
        {
            //Spawn Enemies, Towers, Move Enemies, Tick Towers, Apply Effects, Damage Enemies, Remove Enemies, Remove Towers.
            if(EnemyIDsToSummon.Count > 0){
                for(int i = 0; i<EnemyIDsToSummon.Count; i++ )
                {
                    this.gameObject.GetComponent<EntitySummoner>().SummonEnemy(EnemyIDsToSummon.Dequeue(), spawnPoint);
                }
            }
            if(EnemiesToRemove.Count > 0){
                for (int i=0; i< EnemiesToRemove.Count; i++){
                    EntitySummoner.RemoveEnemy(EnemiesToRemove.Dequeue());
                }
            }
            if(level==0){
                if ((timer % 200 == 0)&&(wave1==false)){
                    spawnPoint = Random.Range(0, 4);
                    //Debug.Log(spawnPoint);
                    EnqueueEnemyIDToSummon(1);
                    //wave1=true;
                }
            }
            if(level==1){
                if ((timer > 1000)&&(!wave1)&&(!pause1)){
                    pause = true;
                    pause1 = true;
                }
                if ((!pause)&&(pause1)&&(!wave1)){
                    wave1=true;
                    spawnPoint = 0;
                    EnqueueEnemyIDToSummon(1);
                    EnqueueEnemyIDToSummon(1);
                    EnqueueEnemyIDToSummon(1);
                    EnqueueEnemyIDToSummon(1);
                }

            }
            yield return null;
        }
        Debug.Log("Game Over"); 
        UnityEngine.SceneManagement.SceneManager.LoadScene("VictoryScreen");
    }

    void FixedUpdate()
    {
        if (!pause){
            timer++;
        }
    }

    public void StartWave(){
        pause = false;
        //Debug.Log("Wave Started2");
    }

    public static void EnqueueEnemyIDToSummon(int ID){
        EnemyIDsToSummon.Enqueue(ID);
    }
    public static void EnqueueEnemyToRemove(Enemy EnemyToRemove){
        EnemiesToRemove.Enqueue(EnemyToRemove);
    }
}
