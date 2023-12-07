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
    public GameObject TeleportOverworld, cameraOverworld, cameraUnderground, dest, prompt, textPressEnter, textBuildTower, overworldTeleporter, undergroundText;
    public GameObject hammer;
    public bool waitForEnemies = false;
    public GameObject prompt2, winText;
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
                //put player in overworld
                if(timer==0){
                    GameObject.FindGameObjectWithTag("Player").transform.position = dest.transform.position + new Vector3(-2, 0, 3);
                    cameraUnderground.SetActive(false);
                    cameraOverworld.SetActive(true);
                }
                //pause before combat
                if(timer==1)
                    pause = true;
                //first wave
                if(timer==2){
                    SummonEnemyAmount(2,2,200);
                    waitForEnemies = true;
                    //wait till wave over
                    if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
                        waitForEnemies = false;
                }
                //first wave over
                //tell player to go underground
                if(timer==3){
                    prompt.SetActive(true);
                    undergroundText.SetActive(true);
                }




                if(timer==3000) 
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
            yield return null;
        }
        Debug.Log("Game Over"); 
        prompt2.SetActive(true);
        winText.SetActive(true);
        // UnityEngine.SceneManagement.SceneManager.LoadScene("VictoryScreen");
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
        if(!waitForEnemies){
            if (!pause){
                timer++;
                overworldTeleporter.GetComponent<TeleportToUnderground>().pause = false;
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
        if((waitForEnemies)||(pause))
            overworldTeleporter.GetComponent<TeleportToUnderground>().pause = true;
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
