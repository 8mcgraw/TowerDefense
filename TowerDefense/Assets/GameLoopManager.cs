using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Jobs;

public class GameLoopManager : MonoBehaviour
{
    //public static Vector3[] NodePositions;
    private static Queue<Enemy> EnemiesToRemove;
    private static Queue<int> EnemyIDsToSummon;

    //public Transform NodeParent;
    public bool endLoop = false;
    // Start is called before the first frame update
    private void Start()
    {
        EnemyIDsToSummon = new Queue<int>();
        EnemiesToRemove = new Queue<Enemy>();
        EntitySummoner.Init();

        //NodePositions = new Vector3[NodeParent.childCount];

        //for (int i = 0; i < NodePositions.Length; i++)
        //{
        //    NodePositions[i] = NodeParent.GetChild(i).position;
        //}

        StartCoroutine(GameLoop());
        // SummonTest();
        InvokeRepeating("SummonTest", 6f, 1f);
        //InvokeRepeating("RemoveTest", 0f, 1.5f);
    }

    // Update is called once per frame

    void SummonTest()
    {
        EnqueueEnemyIDToSummon(1);
    }

    //void RemoveTest(){
    //    if(EntitySummoner.EnemiesInGame.Count > 0){
    //        EntitySummoner.RemoveEnemy(EntitySummoner.EnemiesInGame[Random.Range(0, EntitySummoner.EnemiesInGame.Count)]);
    //    }
    //}

    IEnumerator GameLoop()
    {

        while(endLoop == false)
        {
            //Spawn Enemies, Towers, Move Enemies, Tick Towers, Apply Effects, Damage Enemies, Remove Enemies, Remove Towers.
            if(EnemyIDsToSummon.Count > 0){
                for(int i = 0; i<EnemyIDsToSummon.Count; i++ )
                {
                    EntitySummoner.SummonEnemy(EnemyIDsToSummon.Dequeue());
                }
            }

            //Enemy Movement?
            //NativeArray<Vector3> NodesToUse = new NativeArray<Vector3>(NodePositions, Allocator.TempJob);
            NativeArray<float> EnemySpeeds = new NativeArray<float>(EntitySummoner.EnemiesInGame.Count, Allocator.TempJob);
            //NativeArray<int> NodeIndices = new NativeArray<int>(EntitySummoner.EnemiesInGame.Count, Allocator.TempJob);
            TransformAccessArray EnemyAccess = new TransformAccessArray(EntitySummoner.EnemiesInGameTransform.ToArray(), 2);

            for (int i = 0; i < EntitySummoner.EnemiesInGame.Count; i++)
            {
                EnemySpeeds[i] = EntitySummoner.EnemiesInGame[i].speed;
            //    NodeIndices[i] = EntitySummoner.EnemiesInGame[i].NodeIndex;
            }

            EnemySpeeds.Dispose();
            //NodeIndices.Dispose();
            EnemyAccess.Dispose();
            //NodesToUse.Dispose();

            //Remove Enemies
            if (EnemiesToRemove.Count > 0){
                for (int i=0; i< EnemiesToRemove.Count; i++)
                {
                    Debug.Log(EnemiesToRemove);
                    EntitySummoner.RemoveEnemy(EnemiesToRemove.Dequeue());
                }
            }

            //if(GameObject.FindGameObjectsWithTag("Enemy").Length == 20){
                //endLoop = true;
            //}
            yield return null;
        }

        Debug.Log("Game Over"); 
        UnityEngine.SceneManagement.SceneManager.LoadScene("VictoryScreen");
    }

    public static void EnqueueEnemyIDToSummon(int ID){
        EnemyIDsToSummon.Enqueue(ID);
    }
    public static void EnqueueEnemyToRemove(Enemy EnemyToRemove){
        EnemiesToRemove.Enqueue(EnemyToRemove);
    }
}

//public struct MoveEnemiesJob : IJobParallelForTransform
//{
//    [NativeDisableParallelForRestriction]
//    public NativeArray<Vector3> NodePositions;

//    [NativeDisableParallelForRestriction]
//    public NativeArray<float> EnemySpeed;

//    [NativeDisableParallelForRestriction]
//    public NativeArray<int> NodeIndex;

//    public float deltaTime;
//    public void Execute(int index, TransformAccess transform)
//    {
//        Vector3 PositionToMoveTo = NodePositions[NodeIndex[index]];

//        transform.position = Vector3.MoveTowards(transform.position, PositionToMoveTo, EnemySpeed[index] * deltaTime);

//        if(transform.position == PositionToMoveTo)
//        {
//            // NodeIndex[index]++;
//        }
//    }
//}
