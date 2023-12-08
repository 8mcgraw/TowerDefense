using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EntitySummoner : MonoBehaviour
{
    public static List<Enemy> EnemiesInGame;
    public static List<Transform> EnemiesInGameTransform;
    public static Dictionary<int, GameObject> EnemyPrefabs;
    public static Dictionary<int, Queue<Enemy>> EnemyObjectPools;

    public GameObject[] spawnPoints;

    public static bool IsInitialized;
    // Start is called before the first frame update
    public static void Init()
    {
        if (!IsInitialized)
        {
        EnemyPrefabs = new Dictionary<int, GameObject>();
        EnemyObjectPools = new Dictionary<int, Queue<Enemy>>();
        EnemiesInGameTransform = new List<Transform>();
        EnemiesInGame = new List<Enemy>();

        EnemySummonData[] Enemies = Resources.LoadAll<EnemySummonData>("Enemies");
        foreach (EnemySummonData enemy in Enemies)
        {
            if (!EnemyObjectPools.ContainsKey(enemy.EnemyID))
            {
                // Add the new Enemy to the Dictionary
                EnemyObjectPools.Add(enemy.EnemyID, new Queue<Enemy>());
                EnemyPrefabs.Add(enemy.EnemyID, enemy.EnemyPrefab);
            }
            else
            {
                // Handle the situation where the key already exists
                Debug.LogWarning($"Key {enemy.EnemyID} already exists in EnemyObjectPools. Associated prefab: {EnemyPrefabs[enemy.EnemyID].name}");
            }
        }
        IsInitialized = true;
        }
        else
        {
        Debug.Log("ENTITY SUMMONER: Already Initialized");
        }

    }
    public Enemy SummonEnemy(int EnemyID, int spawnPoint)
    {
        if (spawnPoints.Length < 1){
            spawnPoint = 0;
        } else {
            spawnPoint = spawnPoint % spawnPoints.Length;
        }
        Enemy SummonedEnemy = null;

        if(EnemyPrefabs.ContainsKey(EnemyID))
        {
            Queue<Enemy> ReferencedQueue = EnemyObjectPools[EnemyID];
            if (ReferencedQueue.Count > 0)
            {
                //Dequeue Enemy and initialize
                SummonedEnemy = ReferencedQueue.Dequeue();

                SummonedEnemy.Init();
                SummonedEnemy.gameObject.SetActive(true);
                SummonedEnemy.transform.position = new Vector3(spawnPoints[spawnPoint].transform.position.x, spawnPoints[spawnPoint].transform.position.y, spawnPoints[spawnPoint].transform.position.z);
            
            }
            else
            {
                //Instantiate New Instance of Enemy And Initialize
                GameObject NewEnemy = Instantiate(EnemyPrefabs[EnemyID], new Vector3(spawnPoints[spawnPoint].transform.position.x, spawnPoints[spawnPoint].transform.position.y, spawnPoints[spawnPoint].transform.position.z), Quaternion.identity);
                SummonedEnemy = NewEnemy.GetComponent<Enemy>();
                SummonedEnemy.Init();
            }
        } else {
            Debug.Log($"ENTITY SUMMONER: {EnemyID} not found");
            return null;
        }

        EnemiesInGameTransform.Add(SummonedEnemy.transform);
        EnemiesInGame.Add(SummonedEnemy);
        SummonedEnemy.ID = EnemyID;
        //disable navagent
        SummonedEnemy.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        SummonedEnemy.transform.position = new Vector3(spawnPoints[spawnPoint].transform.position.x, spawnPoints[spawnPoint].transform.position.y, spawnPoints[spawnPoint].transform.position.z);
        SummonedEnemy.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        return SummonedEnemy;
    }
    public static void RemoveEnemy(Enemy EnemyToRemove)
    {
        EnemyObjectPools[EnemyToRemove.ID].Enqueue(EnemyToRemove);
        EnemyToRemove.gameObject.SetActive(false);
        EnemiesInGameTransform.Remove(EnemyToRemove.transform);
        EnemiesInGame.Remove(EnemyToRemove);
        
    }
}
