using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    private static Queue<Enemy> EnemiesToRemove;
    private static Queue<int> EnemyIDsToSummon;
    public bool endLoop = false;
    public int timer = 0;
    public int nextWave = 0;
    public bool wave1 = false, wave2 = false, wave3 = false;
    public bool pause1 = false, pause2 = false, pause3 = false;
    public bool towerBuilt;
    public int spawnPoint = 0;
    public int level;
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

        //StartCoroutine(GameLoop());
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
                if ((timer % 400 == 0)&&(wave1==false)){
                    spawnPoint = Random.Range(0, 4);
                    Debug.Log(spawnPoint);
                    this.gameObject.GetComponent<EntitySummoner>().SummonEnemy(1, spawnPoint);
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
                //set timer
                if(timer==3){
                    prompt.SetActive(true);
                    undergroundText.SetActive(true);
                    nextWave = 3000;
                }
                if(timer==1000){
                    prompt.SetActive(false);
                    undergroundText.SetActive(false);
                }
                //pause before combat
                if (timer == 2999)
                    pause = true;
                
                if (timer==3000)
                SummonEnemyAmount(2,1,1);
                if(timer==3005)
                SummonEnemyAmount(2,1,2);
                if(timer==3010)
                SummonEnemyAmount(2,1,3);
                if(timer==3015)
                SummonEnemyAmount(2,1,4);
                if (timer == 3300)
                SummonEnemyAmount(1,1,5);
                if (timer==3400)
                SummonEnemyAmount(1,1,6);
                if(timer==3500)
                SummonEnemyAmount(1,1,7);
                if(timer==3600)
                SummonEnemyAmount(1,1,8);                
                if(timer==3700)
                SummonEnemyAmount(1,1,9);
                if(timer==3800)
                SummonEnemyAmount(1,1,10);
                if(timer==3900)
                SummonEnemyAmount(7,1,11);

                if(timer==3905){
                    waitForEnemies = true;
                //wait till wave over
                if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
                    waitForEnemies = false;
                }

                //second wave over
                //tell player to go underground
                //set timer
                if (timer == 3910)
                {
                    prompt.SetActive(true);
                    undergroundText.SetActive(true);
                    nextWave = 7000;
                }
                if(timer==5000){
                    prompt.SetActive(false);
                    undergroundText.SetActive(false);
                }
                //put player in overworld
                //if (timer == 0)
                //{
                //    GameObject.FindGameObjectWithTag("Player").transform.position = dest.transform.position + new Vector3(-2, 0, 3);
                //    cameraUnderground.SetActive(false);
                //    cameraOverworld.SetActive(true);
                //}
                //pause before combat
                if (timer == 6999)
                    pause = true;

                //Third wave
                if (timer==7000)
                SummonEnemyAmount(7,1,12);                
                if(timer==7100)
                SummonEnemyAmount(7,1,13);
                if(timer==7200)
                SummonEnemyAmount(4,1,14);
                if(timer==7300)
                SummonEnemyAmount(4,1,15);
                if(timer==7400)
                SummonEnemyAmount(7,1,16);
                if(timer==7500)
                SummonEnemyAmount(7,1,17);

                if (timer == 7505){
                    waitForEnemies = true;
                //wait till wave over
                if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
                    waitForEnemies = false;
                }
                //third wave over
                //tell player to go underground
                //set timer
                if (timer == 7510)
                {
                    prompt.SetActive(true);
                    undergroundText.SetActive(true);
                    nextWave = 11000;
                }
                if(timer==8400){
                    prompt.SetActive(false);
                    undergroundText.SetActive(false);
                }
                //put player in overworld
                //if (timer == 0)
                //{
                //    GameObject.FindGameObjectWithTag("Player").transform.position = dest.transform.position + new Vector3(-2, 0, 3);
                //    cameraUnderground.SetActive(false);
                //    cameraOverworld.SetActive(true);
                //}
                //pause before combat
                if (timer == 10999)
                    pause = true;

                //fourth wave
                if (timer == 11000)
                SummonEnemyAmount(4, 1, 18);
                if (timer == 11200)
                SummonEnemyAmount(4, 1, 19);
                if (timer == 11400)
                SummonEnemyAmount(6, 1, 20);
                if (timer == 11600)
                SummonEnemyAmount(6, 1, 21);
                if (timer == 11800)
                SummonEnemyAmount(4, 1, 22);
                if (timer == 12000)
                SummonEnemyAmount(4, 1, 23); 
                if (timer == 12200)
                SummonEnemyAmount(5, 1, 24); 
                if (timer == 12400)
                SummonEnemyAmount(3, 1, 25);
                if (timer==12600)
                SummonEnemyAmount(8,1,26);
                if (timer == 12700)
                SummonEnemyAmount(8, 1, 27); 
                if (timer == 12800)
                SummonEnemyAmount(8, 1, 28); 
                if (timer == 12900)
                SummonEnemyAmount(8, 1, 29); 
                if (timer == 13000)
                SummonEnemyAmount(8, 1, 30);

                if (timer == 13000){
                    waitForEnemies = true;
                //wait till wave over
                if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
                    waitForEnemies = false;
                }
                if ((GameObject.FindGameObjectsWithTag("Enemy").Length == 0)&&(timer>13000))
                {
                    endLoop = true;
                }
            }
            if(level == 2)
            {
                //put player in overworld
                if (timer == 0)
                {
                    GameObject.FindGameObjectWithTag("Player").transform.position = dest.transform.position + new Vector3(-2, 0, 3);
                    cameraUnderground.SetActive(false);
                    cameraOverworld.SetActive(true);
                }
                //pause before combat
                if (timer == 1)
                    pause = true;
                //first wave
                if (timer == 2)
                {
                    SummonEnemyAmount(2, 2, 200);
                    waitForEnemies = true;
                    //wait till wave over
                    if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
                        waitForEnemies = false;
                }
                //first wave over
                //tell player to go underground
                //set timer
                if (timer == 3)
                {
                    //prompt.SetActive(true);
                    undergroundText.SetActive(true);
                    nextWave = 3000;
                }

                if (timer == 3000)
                    SummonEnemyAmount(2, 1, 1);
                if (timer == 3005)
                    SummonEnemyAmount(2, 1, 2);
                if (timer == 3010)
                    SummonEnemyAmount(2, 1, 3);
                if (timer == 3015)
                    SummonEnemyAmount(2, 1, 4);
                if (timer == 3300)
                    SummonEnemyAmount(1, 1, 5);
                if (timer == 3400)
                    SummonEnemyAmount(1, 1, 6);
                if (timer == 3500)
                    SummonEnemyAmount(1, 1, 7);
                if (timer == 3600)
                    SummonEnemyAmount(1, 1, 8);
                if (timer == 3700)
                    SummonEnemyAmount(1, 1, 9);
                if (timer == 3800)
                    SummonEnemyAmount(1, 1, 10);
                if (timer == 3900)
                    SummonEnemyAmount(7, 1, 11);

                pause = true;
                waitForEnemies = true;
                //wait till wave over
                if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
                    waitForEnemies = false;

                if (timer == 4000)
                    SummonEnemyAmount(7, 1, 12);
                if (timer == 4100)
                    SummonEnemyAmount(7, 1, 13);
                if (timer == 4200)
                    SummonEnemyAmount(4, 1, 14);
                if (timer == 4300)
                    SummonEnemyAmount(4, 1, 15);
                if (timer == 4400)
                    SummonEnemyAmount(7, 1, 16);
                if (timer == 4500)
                    SummonEnemyAmount(7, 1, 17);

                pause = true;
                waitForEnemies = true;
                //wait till wave over
                if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
                    waitForEnemies = false;

                if (timer == 5000)
                    SummonEnemyAmount(4, 1, 18);
                if (timer == 5200)
                    SummonEnemyAmount(4, 1, 19);
                if (timer == 5400)
                    SummonEnemyAmount(6, 1, 20);
                if (timer == 5600)
                    SummonEnemyAmount(6, 1, 21);
                if (timer == 5800)
                    SummonEnemyAmount(4, 1, 22);
                if (timer == 6000)
                    SummonEnemyAmount(4, 1, 23);
                if (timer == 6200)
                    SummonEnemyAmount(6, 1, 24);
                if (timer == 6400)
                    SummonEnemyAmount(6, 1, 25);
                if (timer == 6600)
                    SummonEnemyAmount(3, 1, 26);
                if (timer == 6700)
                    SummonEnemyAmount(3, 1, 27);
                if (timer == 6800)
                    SummonEnemyAmount(3, 1, 28);

                if (timer == 7200)
                    SummonEnemyAmount(8, 1, 29);
                if (timer == 7250)
                    SummonEnemyAmount(8, 1, 30);
                if (timer == 7300)
                    SummonEnemyAmount(8, 1, 31);
                if (timer == 7350)
                    SummonEnemyAmount(8, 1, 32);
                if (timer == 7400)
                    SummonEnemyAmount(8, 1, 33);

                if ((GameObject.FindGameObjectsWithTag("Enemy").Length == 0) && (timer > 8200))
                {
                    endLoop = true;
                }
            }
            if(level == 3)
            {
                //put player in overworld
                if (timer == 0)
                {
                    GameObject.FindGameObjectWithTag("Player").transform.position = dest.transform.position + new Vector3(-2, 0, 3);
                    cameraUnderground.SetActive(false);
                    cameraOverworld.SetActive(true);
                }
                //pause before combat
                if (timer == 1)
                    pause = true;
                //first wave
                if (timer == 2)
                {
                    SummonEnemyAmount(1, 2, 1);
                    waitForEnemies = true;
                    //wait till wave over
                    if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
                        waitForEnemies = false;
                }
                //first wave over
                //set timer
                if (timer == 3)
                {
                    //prompt.SetActive(true);
                    undergroundText.SetActive(true);//[?]
                    nextWave = 3000;
                }

                //enemrerys

                if ((GameObject.FindGameObjectsWithTag("Enemy").Length == 0) && (timer > 6500))
                {
                    endLoop = true;
                }
            return;
        }
        if (endLoop==true){
        Debug.Log("Game Over"); 
        prompt2.SetActive(true);
        winText.SetActive(true);
        // UnityEngine.SceneManagement.SceneManager.LoadScene("VictoryScreen");
        }
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
                this.gameObject.GetComponent<EntitySummoner>().SummonEnemy(enemy, spawnPoint);
            }
        }
    }

    // IEnumerator GameLoop()
    // {

    //     while(endLoop == false)
    //     {
    //         //Debug.Log("Game Loop");
    //         //Spawn Enemies, Towers, Move Enemies, Tick Towers, Apply Effects, Damage Enemies, Remove Enemies, Remove Towers.
    //         if(EnemyIDsToSummon.Count > 0){
    //             for(int i = 0; i<EnemyIDsToSummon.Count; i++ )
    //             {
    //                 this.gameObject.GetComponent<EntitySummoner>().SummonEnemy(EnemyIDsToSummon.Dequeue(), spawnPoint);
    //             }
    //         }
    //         if(EnemiesToRemove.Count > 0){
    //             for (int i=0; i< EnemiesToRemove.Count; i++){
    //                 EntitySummoner.RemoveEnemy(EnemiesToRemove.Dequeue());
    //             }
    //         }

    //         if(level==0){
    //             if ((timer % 400 == 0)&&(wave1==false)){
    //                 spawnPoint = Random.Range(0, 4);
    //                 Debug.Log(spawnPoint);
    //                 this.gameObject.GetComponent<EntitySummoner>().SummonEnemy(1, spawnPoint);
    //                 //wave1=true;
    //             }
    //         }
    //         if(level==1){
    //             //put player in overworld
    //             if(timer==0){
    //                 GameObject.FindGameObjectWithTag("Player").transform.position = dest.transform.position + new Vector3(-2, 0, 3);
    //                 cameraUnderground.SetActive(false);
    //                 cameraOverworld.SetActive(true);
    //             }
    //             //pause before combat
    //             if(timer==1)
    //                 pause = true;
    //             //first wave
    //             if(timer==2){
    //                 SummonEnemyAmount(2,2,200);
    //                 waitForEnemies = true;
    //                 //wait till wave over
    //                 if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
    //                     waitForEnemies = false;
    //             }
    //             //first wave over
    //             //tell player to go underground
    //             //set timer
    //             if(timer==3){
    //                 prompt.SetActive(true);
    //                 undergroundText.SetActive(true);
    //                 nextWave = 3000;
    //             }
    //             if(timer==1000){
    //                 prompt.SetActive(false);
    //                 undergroundText.SetActive(false);
    //             }
    //             //pause before combat
    //             if (timer == 2999)
    //                 pause = true;
                
    //             if (timer==3000)
    //             SummonEnemyAmount(2,1,1);
    //             if(timer==3005)
    //             SummonEnemyAmount(2,1,2);
    //             if(timer==3010)
    //             SummonEnemyAmount(2,1,3);
    //             if(timer==3015)
    //             SummonEnemyAmount(2,1,4);
    //             if (timer == 3300)
    //             SummonEnemyAmount(1,1,5);
    //             if (timer==3400)
    //             SummonEnemyAmount(1,1,6);
    //             if(timer==3500)
    //             SummonEnemyAmount(1,1,7);
    //             if(timer==3600)
    //             SummonEnemyAmount(1,1,8);                
    //             if(timer==3700)
    //             SummonEnemyAmount(1,1,9);
    //             if(timer==3800)
    //             SummonEnemyAmount(1,1,10);
    //             if(timer==3900)
    //             SummonEnemyAmount(7,1,11);

    //             if(timer==3905){
    //                 waitForEnemies = true;
    //             //wait till wave over
    //             if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
    //                 waitForEnemies = false;
    //             }

    //             //second wave over
    //             //tell player to go underground
    //             //set timer
    //             if (timer == 3910)
    //             {
    //                 prompt.SetActive(true);
    //                 undergroundText.SetActive(true);
    //                 nextWave = 7000;
    //             }
    //             if(timer==5000){
    //                 prompt.SetActive(false);
    //                 undergroundText.SetActive(false);
    //             }
    //             //put player in overworld
    //             //if (timer == 0)
    //             //{
    //             //    GameObject.FindGameObjectWithTag("Player").transform.position = dest.transform.position + new Vector3(-2, 0, 3);
    //             //    cameraUnderground.SetActive(false);
    //             //    cameraOverworld.SetActive(true);
    //             //}
    //             //pause before combat
    //             if (timer == 1)
    //                 pause = true;

    //             //Third wave
    //             if (timer==7000)
    //             SummonEnemyAmount(7,1,12);                
    //             if(timer==7100)
    //             SummonEnemyAmount(7,1,13);
    //             if(timer==7200)
    //             SummonEnemyAmount(4,1,14);
    //             if(timer==7300)
    //             SummonEnemyAmount(4,1,15);
    //             if(timer==7400)
    //             SummonEnemyAmount(7,1,16);
    //             if(timer==7500)
    //             SummonEnemyAmount(7,1,17);

    //             if (timer == 7505){
    //                 waitForEnemies = true;
    //             //wait till wave over
    //             if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
    //                 waitForEnemies = false;
    //             }
    //             //third wave over
    //             //tell player to go underground
    //             //set timer
    //             if (timer == 7510)
    //             {
    //                 prompt.SetActive(true);
    //                 undergroundText.SetActive(true);
    //                 nextWave = 11000;
    //             }
    //             if(timer==8400){
    //                 prompt.SetActive(false);
    //                 undergroundText.SetActive(false);
    //             }
    //             //put player in overworld
    //             //if (timer == 0)
    //             //{
    //             //    GameObject.FindGameObjectWithTag("Player").transform.position = dest.transform.position + new Vector3(-2, 0, 3);
    //             //    cameraUnderground.SetActive(false);
    //             //    cameraOverworld.SetActive(true);
    //             //}
    //             //pause before combat
    //             if (timer == 10999)
    //                 pause = true;

    //             //fourth wave
    //             if (timer == 11000)
    //             SummonEnemyAmount(4, 1, 18);
    //             if (timer == 11200)
    //             SummonEnemyAmount(4, 1, 19);
    //             if (timer == 11400)
    //             SummonEnemyAmount(6, 1, 20);
    //             if (timer == 11600)
    //             SummonEnemyAmount(6, 1, 21);
    //             if (timer == 11800)
    //             SummonEnemyAmount(4, 1, 22);
    //             if (timer == 12000)
    //             SummonEnemyAmount(4, 1, 23); 
    //             if (timer == 12200)
    //             SummonEnemyAmount(5, 1, 24); 
    //             if (timer == 12400)
    //             SummonEnemyAmount(3, 1, 25);
    //             if (timer==12600)
    //             SummonEnemyAmount(8,1,26);
    //             if (timer == 12700)
    //             SummonEnemyAmount(8, 1, 27); 
    //             if (timer == 12800)
    //             SummonEnemyAmount(8, 1, 28); 
    //             if (timer == 12900)
    //             SummonEnemyAmount(8, 1, 29); 
    //             if (timer == 13000)
    //             SummonEnemyAmount(8, 1, 30);

    //             if (timer == 13000){
    //                 waitForEnemies = true;
    //             //wait till wave over
    //             if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
    //                 waitForEnemies = false;
    //             }
    //             if ((GameObject.FindGameObjectsWithTag("Enemy").Length == 0)&&(timer>13000))
    //             {
    //                 endLoop = true;
    //             }
    //         }
    //         if(level == 2)
    //         {
    //             //put player in overworld
    //             if (timer == 0)
    //             {
    //                 GameObject.FindGameObjectWithTag("Player").transform.position = dest.transform.position + new Vector3(-2, 0, 3);
    //                 cameraUnderground.SetActive(false);
    //                 cameraOverworld.SetActive(true);
    //             }
    //             //pause before combat
    //             if (timer == 1)
    //                 pause = true;
    //             //first wave
    //             if (timer == 2)
    //             {
    //                 SummonEnemyAmount(2, 2, 200);
    //                 waitForEnemies = true;
    //                 //wait till wave over
    //                 if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
    //                     waitForEnemies = false;
    //             }
    //             //first wave over
    //             //tell player to go underground
    //             //set timer
    //             if (timer == 3)
    //             {
    //                 //prompt.SetActive(true);
    //                 undergroundText.SetActive(true);
    //                 nextWave = 3000;
    //             }

    //             if (timer == 3000)
    //                 SummonEnemyAmount(2, 1, 1);
    //             if (timer == 3005)
    //                 SummonEnemyAmount(2, 1, 2);
    //             if (timer == 3010)
    //                 SummonEnemyAmount(2, 1, 3);
    //             if (timer == 3015)
    //                 SummonEnemyAmount(2, 1, 4);
    //             if (timer == 3300)
    //                 SummonEnemyAmount(1, 1, 5);
    //             if (timer == 3400)
    //                 SummonEnemyAmount(1, 1, 6);
    //             if (timer == 3500)
    //                 SummonEnemyAmount(1, 1, 7);
    //             if (timer == 3600)
    //                 SummonEnemyAmount(1, 1, 8);
    //             if (timer == 3700)
    //                 SummonEnemyAmount(1, 1, 9);
    //             if (timer == 3800)
    //                 SummonEnemyAmount(1, 1, 10);
    //             if (timer == 3900)
    //                 SummonEnemyAmount(7, 1, 11);

    //             pause = true;
    //             waitForEnemies = true;
    //             //wait till wave over
    //             if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
    //                 waitForEnemies = false;

    //             if (timer == 4000)
    //                 SummonEnemyAmount(7, 1, 12);
    //             if (timer == 4100)
    //                 SummonEnemyAmount(7, 1, 13);
    //             if (timer == 4200)
    //                 SummonEnemyAmount(4, 1, 14);
    //             if (timer == 4300)
    //                 SummonEnemyAmount(4, 1, 15);
    //             if (timer == 4400)
    //                 SummonEnemyAmount(7, 1, 16);
    //             if (timer == 4500)
    //                 SummonEnemyAmount(7, 1, 17);

    //             pause = true;
    //             waitForEnemies = true;
    //             //wait till wave over
    //             if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
    //                 waitForEnemies = false;

    //             if (timer == 5000)
    //                 SummonEnemyAmount(4, 1, 18);
    //             if (timer == 5200)
    //                 SummonEnemyAmount(4, 1, 19);
    //             if (timer == 5400)
    //                 SummonEnemyAmount(6, 1, 20);
    //             if (timer == 5600)
    //                 SummonEnemyAmount(6, 1, 21);
    //             if (timer == 5800)
    //                 SummonEnemyAmount(4, 1, 22);
    //             if (timer == 6000)
    //                 SummonEnemyAmount(4, 1, 23);
    //             if (timer == 6200)
    //                 SummonEnemyAmount(6, 1, 24);
    //             if (timer == 6400)
    //                 SummonEnemyAmount(6, 1, 25);
    //             if (timer == 6600)
    //                 SummonEnemyAmount(3, 1, 26);
    //             if (timer == 6700)
    //                 SummonEnemyAmount(3, 1, 27);
    //             if (timer == 6800)
    //                 SummonEnemyAmount(3, 1, 28);

    //             if (timer == 7200)
    //                 SummonEnemyAmount(8, 1, 29);
    //             if (timer == 7250)
    //                 SummonEnemyAmount(8, 1, 30);
    //             if (timer == 7300)
    //                 SummonEnemyAmount(8, 1, 31);
    //             if (timer == 7350)
    //                 SummonEnemyAmount(8, 1, 32);
    //             if (timer == 7400)
    //                 SummonEnemyAmount(8, 1, 33);

    //             if ((GameObject.FindGameObjectsWithTag("Enemy").Length == 0) && (timer > 8200))
    //             {
    //                 endLoop = true;
    //             }
    //         }
    //         if(level == 3)
    //         {
    //             //put player in overworld
    //             if (timer == 0)
    //             {
    //                 GameObject.FindGameObjectWithTag("Player").transform.position = dest.transform.position + new Vector3(-2, 0, 3);
    //                 cameraUnderground.SetActive(false);
    //                 cameraOverworld.SetActive(true);
    //             }
    //             //pause before combat
    //             if (timer == 1)
    //                 pause = true;
    //             //first wave
    //             if (timer == 2)
    //             {
    //                 SummonEnemyAmount(1, 2, 1);
    //                 waitForEnemies = true;
    //                 //wait till wave over
    //                 if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
    //                     waitForEnemies = false;
    //             }
    //             //first wave over
    //             //set timer
    //             if (timer == 3)
    //             {
    //                 //prompt.SetActive(true);
    //                 undergroundText.SetActive(true);//[?]
    //                 nextWave = 3000;
    //             }

    //             //enemrerys

    //             if ((GameObject.FindGameObjectsWithTag("Enemy").Length == 0) && (timer > 6500))
    //             {
    //                 endLoop = true;
    //             }

    //         }
    //         yield return null;
    //     }
    //     Debug.Log("Game Over"); 
    //     prompt2.SetActive(true);
    //     winText.SetActive(true);
    //     // UnityEngine.SceneManagement.SceneManager.LoadScene("VictoryScreen");
    // }
    // //Function to call to summon an enemy a certain amount of time. Wont be called more than once.
    // //Special number needs to be once more for every time this is called
    // void SummonEnemyAmount(int enemy, int amount, int specialNumber){
    //     //checks if specialNumber is in SpecialScriptIDs
    //     if (SpecialScriptIDs.Contains(specialNumber)){
    //         return;
    //     } else {
    //         SpecialScriptIDs.Add(specialNumber);
    //         for (int i = 0; i < amount; i++){
    //             this.gameObject.GetComponent<EntitySummoner>().SummonEnemy(enemy, spawnPoint);
    //         }
    //     }
    // }

    
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
