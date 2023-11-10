using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapHitPlayer : MonoBehaviour
{
    //[SerializeField] TimerComponent timer;

    //Trigger if trap hit player
    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            //Debug.Log(timer.runtime);
            TimerComponent timer = GameObject.FindGameObjectWithTag("UI").GetComponent<TimerComponent>();
            PlayerPrefs.SetFloat("timer", timer.runtime);
            SceneManager.LoadScene(2);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
