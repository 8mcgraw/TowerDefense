using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EntitySummoner : MonoBehaviour
{
    public static List<Enemy> EnemiesInGame;
    public static Dictionary<int, GameObject> EnemyPrefabs;
    public static Dictionary<int, Queue<Enemy>> EnemyObjectPools;

    public static bool IsInitialized;
    // Start is called before the first frame update
    public static void Init()
    {
        if (!IsInitialized)
        {
        EnemyPrefabs = new Dictionary<int, GameObject>();
        EnemyObjectPools = new Dictionary<int, Queue<Enemy>>();
        EnemiesInGame = new List<Enemy>();

        EnemySummonData[] Enemies = Resources.LoadAll<EnemySummonData>("Enemies");
        foreach (EnemySummonData enemy in Enemies)
        {
            EnemyPrefabs.Add(enemy.EnemyID, enemy.EnemyPrefab);
            EnemyObjectPools.Add(enemy.EnemyID, new Queue<Enemy>());
        }
        IsInitialized = true;
    }
    else
    {
        Debug.Log("ENTITY SUMMONER: Already Initialized");
    }

    }
    public static Enemy SummonEnemy(int EnemyID)
    {
        Enemy SummonedEnemy = null;

        if(EnemyPrefabs.ContainsKey(EnemyID)){
            Queue<Enemy> ReferencedQueue = EnemyObjectPools[EnemyID];
            if (ReferencedQueue.Count > 0)
            {
                //Dequeue Enemy and initialize
                SummonedEnemy = ReferencedQueue.Dequeue();

                SummonedEnemy.gameObject.SetActive(true);
                SummonedEnemy.Init();
            }
            else
            {
                //Instantiate New Instance of Enemy And Initialize
                GameObject NewEnemy = Instantiate(EnemyPrefabs[EnemyID], Vector3.zero, Quaternion.identity);
                SummonedEnemy = NewEnemy.GetComponent<Enemy>();
            }
        } else {
            Debug.Log($"ENTITY SUMMONER: {EnemyID} not found");
            return null;
        }
        EnemiesInGame.Add(SummonedEnemy);
        return SummonedEnemy;
    }
    public static void RemoveEnemy(Enemy EnemyToRemove){
        //EnemyObjectPools[EnemyToRemove.ID].Enqueue(EnemyToRemove);
        EnemyToRemove.gameObject.SetActive(false);
        EnemiesInGame.Remove(EnemyToRemove);
        
    }
}
