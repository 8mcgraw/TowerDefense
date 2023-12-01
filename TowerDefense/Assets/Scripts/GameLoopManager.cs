using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoopManager : MonoBehaviour
{
    public static Vector3[] NodePositions;
    private static Queue<Enemy> EnemiesToRemove;
    private static Queue<int> EnemyIDsToSummon;

    //public TMPro.TextMeshPro t;
    public Transform NodeParent;
    public bool endLoop = false;
    public int timer = 0;
    public bool wave1 = false, wave2 = false, wave3 = false, bossed = false, startWave = false;
    public GameObject summoner;
    public int spawnPoint = 0;
    // Start is called before the first frame update
    private void Start()
    {
        EnemyIDsToSummon = new Queue<int>();
        EnemiesToRemove = new Queue<Enemy>();
        EntitySummoner.Init();

        NodePositions = new Vector3[NodeParent.childCount];

        for (int i = 0; i < NodePositions.Length; i++)
        {
            NodePositions[i] = NodeParent.GetChild(i).position;
        }

        //SummonTest();
        StartCoroutine(GameLoop());
        //InvokeRepeating("SummonTest", 6f, 1f);
        //InvokeRepeating("RemoveTest", 0f, 1.5f);
    }

    // Update is called once per frame

    void SummonTest()
    {
        EnqueueEnemyIDToSummon(1);
        EnqueueEnemyIDToSummon(2);
        EnqueueEnemyIDToSummon(3);
        EnqueueEnemyIDToSummon(4);

    }

    void RemoveTest(){
        if(EntitySummoner.EnemiesInGame.Count > 0){
            EntitySummoner.RemoveEnemy(EntitySummoner.EnemiesInGame[Random.Range(0, EntitySummoner.EnemiesInGame.Count)]);
        }
    }

    IEnumerator GameLoop()
    {

        while (endLoop == false)
        {
            //Spawn Enemies, Towers, Move Enemies, Tick Towers, Apply Effects, Damage Enemies, Remove Enemies, Remove Towers.
            if (EnemyIDsToSummon.Count > 0)
            {
                for (int i = 0; i < EnemyIDsToSummon.Count; i++)
                {
                    summoner.gameObject.GetComponent<EntitySummoner>().SummonEnemy(EnemyIDsToSummon.Dequeue(), spawnPoint);
                }
            }
            if (EnemiesToRemove.Count > 0)
            {
                for (int i = 0; i < EnemiesToRemove.Count; i++)
                {
                    Debug.Log(EnemiesToRemove);
                    EntitySummoner.RemoveEnemy(EnemiesToRemove.Dequeue());
                }
            }

            //LEVEL1
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
            {
                //Start waves
                if (startWave == true)
                {
                    if ((timer > 1000) && (wave1 == false))
                    {
                        EnqueueEnemyIDToSummon(2);
                        wave1 = true;
                    }
                    if ((timer > 2000) && (wave2 == false))
                    {
                        EnqueueEnemyIDToSummon(2);
                        EnqueueEnemyIDToSummon(2);
                        wave2 = true;
                    }
                    if ((timer > 3000) && (wave3 == false))
                    {
                        EnqueueEnemyIDToSummon(3);
                        EnqueueEnemyIDToSummon(3);
                        EnqueueEnemyIDToSummon(3);
                        wave3 = true;
                    }
                    if ((timer > 4000) && (wave3 == true))
                    {
                        endLoop = true;
                    }
                }
            }
            //LEVEL2
            else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(4))
            {
                //Start waves
                if (startWave == true)
                {
                    if ((timer > 1000) && (wave1 == false))
                    {
                        EnqueueEnemyIDToSummon(1);
                        EnqueueEnemyIDToSummon(1);
                        wave1 = true;
                    }
                    if ((timer > 2000) && (wave2 == false))
                    {
                        EnqueueEnemyIDToSummon(1);
                        EnqueueEnemyIDToSummon(1);
                        EnqueueEnemyIDToSummon(1);
                        EnqueueEnemyIDToSummon(1);
                        wave2 = true;
                    }
                    if ((timer > 3000) && (wave3 == false))
                    {
                        EnqueueEnemyIDToSummon(1);
                        EnqueueEnemyIDToSummon(1);
                        EnqueueEnemyIDToSummon(1);
                        EnqueueEnemyIDToSummon(1);
                        EnqueueEnemyIDToSummon(1);
                        EnqueueEnemyIDToSummon(1);
                        wave3 = true;
                    }

                    //If waves finished, spawn boss
                    if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && wave3 == true)
                    {
                        EnqueueEnemyIDToSummon(2);
                        bossed = true;
                    }
                    //Boss ded
                    if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && bossed == true)
                    {
                        endLoop = true;
                    }
                }
            }
            //LEVEL3
            else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(5))
            {
                //Start waves
                if (startWave == true)
                {
                    if ((timer % 500 == 0) && (wave1 == false))
                    {
                        spawnPoint = 8;
                        EnqueueEnemyIDToSummon(2);

                    }
                    //if ((timer % 200 == 0) && (wave1 == false))
                    //{
                    //    spawnPoint = Random.Range(0, 4);
                    //    Debug.Log(spawnPoint);
                    //    EnqueueEnemyIDToSummon(1);
                    //    //wave1=true;
                    //}
                    if ((timer > 2000) && (wave2 == false))
                    {
                        EnqueueEnemyIDToSummon(4);
                        if (GameObject.FindGameObjectsWithTag("Enemy").Length != 0)
                        {
                            Debug.Log("Its a witch!");
                            summoner.gameObject.GetComponent<EntitySummoner>().SummonEnemy(4, 0);
                            summoner.gameObject.GetComponent<EntitySummoner>().SummonEnemy(4, 1);
                            yield return new WaitForSeconds(1);
                            summoner.gameObject.GetComponent<EntitySummoner>().SummonEnemy(4, 2);
                            summoner.gameObject.GetComponent<EntitySummoner>().SummonEnemy(4, 3);
                            yield return new WaitForSeconds(1);
                            summoner.gameObject.GetComponent<EntitySummoner>().SummonEnemy(4, 4);
                            summoner.gameObject.GetComponent<EntitySummoner>().SummonEnemy(4, 5);
                            yield return new WaitForSeconds(1);
                            summoner.gameObject.GetComponent<EntitySummoner>().SummonEnemy(4, 6);
                            summoner.gameObject.GetComponent<EntitySummoner>().SummonEnemy(4, 7);
                            wave2 = true;
                        }
                        wave1 = true;

                    }
                }
            }
            //LEVEL4
            else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(6))
            {

            }
            //LEVEL5
            else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(7))
            {

            }
            yield return null;









        }
        Debug.Log("Game Over"); 
        UnityEngine.SceneManagement.SceneManager.LoadScene("VictoryScreen");
    } 

    void FixedUpdate()
    {
        timer++;
    }

    public static void EnqueueEnemyIDToSummon(int ID){
        EnemyIDsToSummon.Enqueue(ID);
    }
    public static void EnqueueEnemyToRemove(Enemy EnemyToRemove){
        EnemiesToRemove.Enqueue(EnemyToRemove);
    }
}
