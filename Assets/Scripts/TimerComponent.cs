using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerComponent : MonoBehaviour
{
    [SerializeField] TMP_Text textTimer;
    float elapsedTime = 0;
    public float runtime;

    //Calculates the time for the game, how long the player has been surviving
    void Update()
    {
        elapsedTime += Time.deltaTime;
        textTimer.text = "Runtime: " + Mathf.Round(elapsedTime * 100.0f) * 0.01f;
        runtime = Mathf.Round(elapsedTime * 100.0f) * 0.01f;
       
    }

    //When a player picks up a coin it adds 20 seconds to their score.
    public void AddTimePoint()
    {
        elapsedTime += 20f;
       

    }
}
