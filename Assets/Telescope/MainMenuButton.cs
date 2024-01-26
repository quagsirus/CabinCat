using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void MainMenuButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(0).name);
    }
}
