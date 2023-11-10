using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class interact : MonoBehaviour
{

    MoveComponent player;
    TextMeshProUGUI text;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveComponent>();
        text = GameObject.Find("IntE").GetComponent<TextMeshProUGUI>();
    }
   //show the UI if the player Enter
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject);
        player.Coin = gameObject;
        text.enabled = true;
     


    }
   // Close the UI if the player exit the zone
    private void OnTriggerExit(Collider other)
    {
        text.enabled = false;
        player.Coin = null;

    }
}
