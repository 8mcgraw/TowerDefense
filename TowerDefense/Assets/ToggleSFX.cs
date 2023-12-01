using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToggleSFX : MonoBehaviour
{
    public GameObject sfxOn;
    public GameObject sfxOff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleSFXOn(){
        AudioListener.volume = 1f;
        sfxOn.SetActive(true);
        sfxOff.SetActive(false);
    }
    
    public void ToggleSFXOff(){
        AudioListener.volume = 0f;
        sfxOn.SetActive(false);
        sfxOff.SetActive(true);
    }

    public void ToggleMusic(){
        Debug.Log("Toggle Music");
        //if on, turn off, if off turn on
        this.gameObject.GetComponent<AudioSource>().mute = !this.GetComponent<AudioSource>().mute;
    }
}
