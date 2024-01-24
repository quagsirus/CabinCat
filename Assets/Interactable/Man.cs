using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Man : MonoBehaviour
{
    [SerializeField] TextMeshPro textDisplay;
    public bool displayingText = false;
    [SerializeField] float textDisplayLength = 5f;
    float textDuration;

    void Start()
    {
        Globals.Instance.man = this;
        textDisplay.enabled = false;
    }

    public void SetText(string text)
    {
        Debug.Log("ass");
        if (!displayingText) {
        StartCoroutine(UpdateText(text));
        StartCoroutine(HideTextDelay());
        }
    }

    public IEnumerator HideTextDelay()
    {
        textDuration = textDisplayLength;
        textDisplay.enabled = true;
        while (textDuration > 0)
        {
            yield return new WaitForSeconds(0.1f);
            textDuration -= 0.1f;
        }
        textDisplay.enabled = false;
    }

    public IEnumerator UpdateText(string newText)
    {
        Debug.Log("oui");
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
