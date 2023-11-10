using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    //When the player falls onto the green platform at the end of the tutorial he gets teleported in the game.
    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(1);
        }
    }
}
