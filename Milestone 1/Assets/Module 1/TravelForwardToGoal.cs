using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class TravelForwardToGoal : MonoBehaviour
{
    public Transform goal;
    float speed = 3;
    float rotSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);


        Vector3 direction = lookAtGoal - transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,Quaternion.LookRotation(direction),Time.deltaTime * rotSpeed);
        



        if (Vector3.Distance(lookAtGoal, transform.position) > 2.5)
        { 
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
}
