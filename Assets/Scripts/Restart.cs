using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    [SerializeField] GameObject StartSpawn;

    //When a player hits an object its not supposed to or falls on a grey platform
    //it respawns to the nearest checkpoint (only in the tutorial)
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterController>().enabled = false;
            collision.transform.position = StartSpawn.transform.position;
            collision.gameObject.GetComponent<CharacterController>().enabled = true;
        }
    }
   
}
