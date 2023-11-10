using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeRuntimeComponent : MonoBehaviour
{
    [SerializeField] TMP_Text textTimer;
    float runtime;
    //At the end screen when the player dies, it writes the time they did on the canvas
    //using a playerpref that's set in the TrapHitPlayer script
    void Start()
    {
        runtime = PlayerPrefs.GetFloat("timer");
        textTimer.text = "Runtime: " + runtime;
    }

}
