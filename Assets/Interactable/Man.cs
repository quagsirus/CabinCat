using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Man : MonoBehaviour
{
    [SerializeField] TextMeshPro textDisplay;
    public bool displayingText = false;

    void Start()
    {
        Globals.Instance.man = this;
    }

    public void SetText(string text)
    {
        Debug.Log("ass");
        StartCoroutine(UpdateText(text));
    }

    public IEnumerator UpdateText(string newText)
    {
        Debug.Log("oui");
        if (displayingText)
        {
            yield break;
        }
        displayingText = true;
        textDisplay.text = "";
        foreach (char c in newText)
        {
            textDisplay.text += c;
            yield return new WaitForSeconds(0.1f);
        }
        displayingText = false;
    }
}
