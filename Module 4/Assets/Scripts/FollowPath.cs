using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPath : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject wpManager;
    GameObject[] wps;


    // Start is called before the first frame update
    void Start()
    {
        wps = wpManager.GetComponent<WaypointManager>().getWps();
        agent = this.GetComponent<NavMeshAgent>();
    }

    public void GoToHelipad()
    {
        agent.SetDestination(wps[0].transform.position);
    }

    
}
