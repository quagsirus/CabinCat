using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    [SerializeField] Button button;

    private void Start()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            button.gameObject.SetActive(false);
        }
    }

    public void QuitButtonPressed()
    {
        Application.Quit();
    }
}
