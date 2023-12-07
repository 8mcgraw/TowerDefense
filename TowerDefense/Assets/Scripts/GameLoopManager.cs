using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    private static Queue<Enemy> EnemiesToRemove;
    private static Queue<int> EnemyIDsToSummon;
    public bool endLoop = false;
    public int timer = 0;
    public bool wave1 = false, wave2 = false, wave3 = false;
    public bool pause1 = false, pause2 = false, pause3 = false;
    public bool towerBuilt;
    public int spawnPoint = 0;
    public int level = 1;
    public bool pause = false;
    public bool startWave;
    public HashSet<int> SpecialScriptIDs = new HashSet<int>();
    public GameObject TeleportOverworld, cameraOverworld, cameraUnderground, dest, prompt, textPressEnter, textBuildTower, overworldTeleporter;
    public GameObject hammer;
    // Start is called before the first frame update
    void Start()
    {
        EnemiesToRemove = new Queue<Enemy>();
        EnemyIDsToSummon = new Queue<int>();
        EntitySummoner.Init();

        StartCoroutine(GameLoop());
        //SummonTest();
        //InvokeRepeating("SummonTest", 1f, 1f);
        //InvokeRepeating("RemoveTest", 0f, 1.5f);
    }

    // Update is called once per frame

    void SummonTest(){
        EnqueueEnemyIDToSummon(1);
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
            //Debug.Log("Game Loop");
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
                    Debug.Log(spawnPoint);
                    EnqueueEnemyIDToSummon(1);
                    //wave1=true;
                }
            }
            if(level==1){
                if ((timer > 3000)&&(!wave1)&&(!pause1)){
                    Debug.Log("Wave 1 Started");
                    pause = true;
                    pause1 = true;
                    //Teleport
                    GameObject.FindGameObjectWithTag("Player").transform.position = dest.transform.position + new Vector3(-2, 0, 3);
                    hammer.SetActive(false);
                    //pause the teleporting script of the teleporter
                    overworldTeleporter.GetComponent<TeleportToUnderground>().pause = true;
                    cameraUnderground.SetActive(false);
                    cameraOverworld.SetActive(true);
                    //Force Play

                }
                if ((!pause)&&(pause1)&&(!wave1)){
                    prompt.SetActive(false);
                    textPressEnter.SetActive(false);
                    textBuildTower.SetActive(false);
                    //wave1=true;
                    spawnPoint = 0;

                    SummonEnemyAmount(2,1,1);
                    if(timer==3005)
                    SummonEnemyAmount(2,1,100);
                    if(timer==3010)
                    SummonEnemyAmount(2,1,101);
                    if(timer==3015)
                    SummonEnemyAmount(2,1,102);

                    //yield return new WaitForSeconds(10);
                    if(timer==3300)
                    SummonEnemyAmount(1,1,2);
                    //yield return new WaitForSeconds(1);

                    if(timer==3400)
                    SummonEnemyAmount(1,1,3);
                    //yield return new WaitForSeconds(10);

                    if(timer==3800)
                    SummonEnemyAmount(1,1,4);
                    
                    //yield return new WaitForSeconds(1);
                    if(timer==3900)
                    SummonEnemyAmount(1,1,5);
                    //yield return new WaitForSeconds(1);

                    if(timer==4000)
                    SummonEnemyAmount(1,1,6);
                    //yield return new WaitForSeconds(1);

                    if(timer==4100)
                    SummonEnemyAmount(4,1,7);
                    //yield return new WaitForSeconds(10);

                    if(timer==5000)
                    SummonEnemyAmount(4,1,8);
                    
                    //yield return new WaitForSeconds(1);

                    if(timer==5100)
                    SummonEnemyAmount(4,1,9);

                    //yield return new WaitForSeconds(1);

                    if(timer==5200)
                    SummonEnemyAmount(4,1,10);

                    //yield return new WaitForSeconds(1);

                    if(timer==5300)
                    SummonEnemyAmount(3,1,11);
                    //yield return new WaitForSeconds(10);

                    if(timer==6000)
                    SummonEnemyAmount(3,1,12);
                    //yield return new WaitForSeconds(1);

                    if(timer==6100)
                    SummonEnemyAmount(5,1,13);
                    //yield return new WaitForSeconds(1);

                    if(timer==6200)
                    SummonEnemyAmount(5,1,14);

                    if((GameObject.FindGameObjectsWithTag("Enemy").Length == 0)&&(timer>6500))
                    {
                        endLoop = true;
                    }

                }


            }
            yield return null;
        }
        Debug.Log("Game Over"); 
        UnityEngine.SceneManagement.SceneManager.LoadScene("VictoryScreen");
    }
    //Function to call to summon an enemy a certain amount of time. Wont be called more than once.
    //Special number needs to be once more for every time this is called
    void SummonEnemyAmount(int enemy, int amount, int specialNumber){
        //checks if specialNumber is in SpecialScriptIDs
        if (SpecialScriptIDs.Contains(specialNumber)){
            return;
        } else {
            SpecialScriptIDs.Add(specialNumber);
            for (int i = 0; i < amount; i++){
                this.gameObject.GetComponent<EntitySummoner>().SummonEnemy(enemy, 0);
            }
        }
    }

    void FixedUpdate()
    {
        if (!pause){
            timer++;
        }else{
            if (!towerBuilt) {
                prompt.SetActive(true);
                textBuildTower.SetActive(true);
                textPressEnter.SetActive(false);
                Debug.Log("Build Tower");
            } else {
                prompt.SetActive(true);
                textPressEnter.SetActive(true);
                textBuildTower.SetActive(false);
                Debug.Log("Press Enter to Start Wave");
            }
        }
    }

    public void StartWave(){
        if(towerBuilt)
        {
            pause = false;
        } 
        //Debug.Log("Wave Started2");
    }

    public static void EnqueueEnemyIDToSummon(int ID){
        EnemyIDsToSummon.Enqueue(ID);
    }
    public static void EnqueueEnemyToRemove(Enemy EnemyToRemove){
        EnemiesToRemove.Enqueue(EnemyToRemove);
    }
}
