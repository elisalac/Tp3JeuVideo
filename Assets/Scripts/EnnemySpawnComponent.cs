using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemySpawnComponent : MonoBehaviour
{
    [SerializeField] GameObject ennemy;
    [SerializeField] GameObject[] spawns;
    [SerializeField] GameObject Player;
    float delay = 5;
    NavMesh navMeshEnnemy;
    float lastSpeed = 0.2f;

    //spawner for the ennemi each time spawn 1 ennemi. the ennemie can spawn at 3 location
    //at random and become faster each time.
    void Update()
    {
        SpawnEnnemy();
        delay -= Time.deltaTime;
        
    }
    void SpawnEnnemy()
    {
        if(delay <= 0)
        {
            GameObject tempEnnemy = ObjectPool.objectPool.GetObject(ennemy);
            navMeshEnnemy = tempEnnemy.GetComponent<NavMesh>();
            if (tempEnnemy != null)
            {

                NavMeshAgent nav = tempEnnemy.GetComponent<NavMeshAgent>();
                
                tempEnnemy.transform.position = spawns[Random.Range(0,3)].transform.position;
                navMeshEnnemy.ChangeSpeed(navMeshEnnemy.basseSpeed + (navMeshEnnemy.basseSpeed * lastSpeed));
                nav.enabled = true;
                tempEnnemy.SetActive(true);
            }
            lastSpeed += 0.1f;
            delay = 5;
        }
    }
}
