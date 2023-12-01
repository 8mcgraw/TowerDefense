using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selection : MonoBehaviour
{
    public GameObject selectedObject;
    public GameObject[] levels;
    public bool[] levelsCompleted;
    public bool updated = false;
    public bool notStarted = true;
    // Start is called before the first frame update
    void Start()
    {
        selectedObject = levels[0];
    }
    
    IEnumerator updateLevels(){
        notStarted = false;
        for(int i = 0; i<levels.Length; i++){
            Debug.Log("Level "+i+" is "+levelsCompleted[i]);
            if(levelsCompleted[i]){
                //set the tag to playable, set the color to green, set the light to blue
                levels[i].tag = "complete";
                levels[i].GetComponent<Renderer>().material.color = Color.green;
                yield return new WaitForSeconds(0.1f);
                levels[i].GetComponent<Light>().color = Color.blue;
                yield return new WaitForSeconds(0.2f);
            } else {
                //check if its the next playable level
                if(i>0){
                    if(levelsCompleted[i-1]){
                        //set the tag to nextlevel, set the color to blue, set the light to white
                        levels[i].tag = "nextlevel";
                        levels[i].GetComponent<Renderer>().material.color = Color.white;
                        yield return new WaitForSeconds(0.1f);
                        levels[i].GetComponent<Light>().color = Color.yellow;
                        yield return new WaitForSeconds(0.2f);
                    } else {
                        //set the tag to unplayable, set the color to grey, set the light to red
                        levels[i].tag = "unplayable";
                        levels[i].GetComponent<Renderer>().material.color = Color.grey;
                        yield return new WaitForSeconds(0.1f);
                        levels[i].GetComponent<Light>().color = Color.red;
                        yield return new WaitForSeconds(0.2f);
                    }
                }
            }
        }
        updated = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!updated){
            if (notStarted){
                StartCoroutine(updateLevels());
            }
        } else {
            //for each button press, switch the selectedObject to the next or previous level
            if ((Input.GetKeyDown(KeyCode.LeftArrow)||(Input.GetKeyDown(KeyCode.A))))
            {
                // Switches selectedObject left in the levels array
                if (selectedObject == null)
                {
                    selectedObject = levels[0];
                }
                else
                {
                    for (int i = 0; i < levels.Length; i++)
                    {
                        if (selectedObject == levels[i])
                        {
                            int nextIndex = (i - 1 + levels.Length) % levels.Length; // Calculate the next index using modulo operator
                            if (levels[nextIndex].tag == "complete" || levels[nextIndex].tag == "nextlevel") // Check if the next level is tagged as "playable"
                            {
                                selectedObject = levels[nextIndex];
                            }
                            break; // Added break statement to exit the loop once the selectedObject is found
                        }
                    }
                }
            }
            if ((Input.GetKeyDown(KeyCode.RightArrow) || (Input.GetKeyDown(KeyCode.D))))
            {
                // Switches selectedObject right in the levels array
                if (selectedObject == null)
                {
                    selectedObject = levels[0];
                }
                else
                {
                    for (int i = 0; i < levels.Length; i++)
                    {
                        if (selectedObject == levels[i])
                        {
                            int nextIndex = (i + 1) % levels.Length; // Calculate the next index using modulo operator
                            if (levels[nextIndex].tag == "complete" || levels[nextIndex].tag == "nextlevel") // Check if the next level is tagged as "playable"
                            {
                                selectedObject = levels[nextIndex];
                            }
                            break; // Added break statement to exit the loop once the selectedObject is found
                        }
                    }
                }
            }
            //select what the mouse is hovering over
            if(Input.GetMouseButtonDown(0)){
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if(Physics.Raycast(ray,out hit)){
                    if(hit.transform.tag == "complete" || hit.transform.tag == "nextlevel"){
                        selectedObject = hit.transform.gameObject;
                    }
                }
            }
            if(selectedObject != null){
                //sets the other objects to their proper colors
                for(int i = 0; i<levels.Length; i++){
                    if(selectedObject != levels[i]){
                        if(levels[i].tag == "complete"){
                            levels[i].GetComponent<Renderer>().material.color = Color.green;
                            levels[i].GetComponent<Light>().color = Color.blue;
                        } else if(levels[i].tag == "nextlevel"){
                            levels[i].GetComponent<Renderer>().material.color = Color.white;
                            levels[i].GetComponent<Light>().color = Color.yellow;
                        } else {
                            levels[i].GetComponent<Renderer>().material.color = Color.grey;
                            levels[i].GetComponent<Light>().color = Color.red;
                        }
                    }
                }
                //sets the selected object colors
                selectedObject.GetComponent<Renderer>().material.color = Color.yellow;
                selectedObject.GetComponent<Light>().color = Color.yellow;
            }
            //selects the object with keypresses 1-9
            if ((Input.GetKey(KeyCode.Alpha1)&&(levels[0].tag == "complete" || levels[0].tag == "nextlevel"))){
                selectedObject = levels[0];
            } else if ((Input.GetKey(KeyCode.Alpha2)&&(levels[1].tag == "complete" || levels[1].tag == "nextlevel"))){
                selectedObject = levels[1];
            } else if ((Input.GetKey(KeyCode.Alpha3)&&(levels[2].tag == "complete" || levels[2].tag == "nextlevel"))){
                selectedObject = levels[2];
            } else if ((Input.GetKey(KeyCode.Alpha4)&&(levels[3].tag == "complete" || levels[3].tag == "nextlevel"))){
                selectedObject = levels[3];
            } else if ((Input.GetKey(KeyCode.Alpha5)&&(levels[4].tag == "complete" || levels[4].tag == "nextlevel"))){
                selectedObject = levels[4];
            } else if ((Input.GetKey(KeyCode.Alpha6)&&(levels[5].tag == "complete" || levels[5].tag == "nextlevel"))){
                selectedObject = levels[5];
            } else if ((Input.GetKey(KeyCode.Alpha7)&&(levels[6].tag == "complete" || levels[6].tag == "nextlevel"))){
                selectedObject = levels[6];
            } else if ((Input.GetKey(KeyCode.Alpha8)&&(levels[7].tag == "complete" || levels[7].tag == "nextlevel"))){
                selectedObject = levels[7];
            } else if ((Input.GetKey(KeyCode.Alpha9)&&(levels[8].tag == "complete" || levels[8].tag == "nextlevel"))){
                selectedObject = levels[8];
            } else if ((Input.GetKey(KeyCode.Alpha0)&&(levels[9].tag == "complete" || levels[9].tag == "nextlevel"))){
                selectedObject = levels[9];
            }

            if(selectedObject != null){
                //start with the object selected using E or Enter or Space
                if((Input.GetKey(KeyCode.E))||(Input.GetKey(KeyCode.Space))||(Input.GetKey(KeyCode.Return))){
                    if(selectedObject.tag != "unplayable"){
                        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(selectedObject.name);
                    }
                }
            }
        }
    }
}
