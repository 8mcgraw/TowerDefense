using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class circularLoading : MonoBehaviour
{
    public Image loadingImage;
    public float loadingProgress = 0;
    public GameObject GameMaster, timerBackground, finish;
    int timer;
    int nextWave;
    int timerZero;

    // Update is called once per frame
    void Update()
    {
        if (GameMaster == null) {
            timerBackground.SetActive(false);
            finish = GameObject.FindGameObjectWithTag("Finish");
            GameMaster = GameObject.Find("GameMaster");
        } else {
            timerBackground.SetActive(true);
            timer = GameMaster.gameObject.GetComponent<GameLoopManager>().timer;
            if (nextWave!=GameMaster.gameObject.GetComponent<GameLoopManager>().nextWave) {
                nextWave = GameMaster.gameObject.GetComponent<GameLoopManager>().nextWave;
                timerZero = timer;
            }
            loadingImage.fillAmount = (float)((nextWave-timerZero)-(timer-timerZero))/(nextWave-timerZero);
        }
    }
}