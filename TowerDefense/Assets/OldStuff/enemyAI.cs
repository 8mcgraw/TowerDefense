using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NavmeshAgent = UnityEngine.AI.NavMeshAgent;

public class enemyAI : MonoBehaviour
{
    //public Camera camera;
    public Transform goal;
    public void Init()
    {
        UnityEngine.AI.NavMeshAgent agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;
    }

    // void Update()
    // {
    //     NavmeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    //     Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
    //     //if ray hits something in 3d space, let's store it
    //     RaycastHit hit;

    //     if (Physics.Raycast(ray, out hit))
    //     {
    //         //ray hit something!
    //         //hit.transform ... is where the hit occured.
    //         agent.destination = hit.point;
    //     }

    //     //agent.destination = goal.position;
    // }
}
