using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class circularLoading : MonoBehaviour
{
    public Image loadingImage;
    public float loadingProgress = 0;

    // Update is called once per frame
    void Update()
    {
        loadingImage.fillAmount = loadingProgress;
    }
}