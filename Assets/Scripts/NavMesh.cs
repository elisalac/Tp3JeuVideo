using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
   public GameObject destination;
    NavMeshAgent agent;
    
    public float basseSpeed = 3.5F;
    // Start is called before the first frame update
    void Awake()
    {
        agent= GetComponent<NavMeshAgent>();
        destination = GameObject.FindGameObjectWithTag("Player");


    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = destination.transform.position;
        if (agent.isOnOffMeshLink)
        {
            agent.speed = 4;
        }
        else 
        {
            agent.speed = basseSpeed;
        }
    }

    //the change speed is call when we create a new ennemi. we use that too up the difficulty.
    public void ChangeSpeed(float newSpeed)
    {
        basseSpeed = newSpeed;
    }

}
