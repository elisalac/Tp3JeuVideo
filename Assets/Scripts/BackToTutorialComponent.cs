using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToTutorialComponent : MonoBehaviour
{
    //When the user presses on the button it puts them back to the scene for the tutorial.
    public void LoadSceneTutorial()
    {
        SceneManager.LoadScene(0);
    }
}
