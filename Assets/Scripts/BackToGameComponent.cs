using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToGameComponent : MonoBehaviour
{
    //When the user presses on the button it puts them back to the scene for the game.
    public void LoadSceneGame()
    {
        SceneManager.LoadScene(1);
    }
}
