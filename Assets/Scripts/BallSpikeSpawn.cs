using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BallSpikeSpawn : MonoBehaviour
{
    [SerializeField] GameObject ball;
    
    
    float delay = 10;
  
    //spawner for the ball
    void Update()
    {
        SpawnBall();
        delay -= Time.deltaTime;

    }
    void SpawnBall()
    {
        if (delay <= 0)
        {
            GameObject Balls = ObjectPool.objectPool.GetObject(ball);
          
            if (Balls != null)
            {



                Balls.transform.position = this.transform.position;

                Balls.GetComponent<TTL>().enabled = true;
                Balls.SetActive(true);
            }
            
            delay = 10;
        }
    }
}
