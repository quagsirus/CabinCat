using System.Collections;
using TMPro;
using UnityEngine;

public class Man : MonoBehaviour
{
    [SerializeField] private float textDisplayLength = 5f;
    [SerializeField] private bool displayingText;
    [SerializeField] private TextMeshPro textDisplay;
    [SerializeField] private float textDuration; 

    private void Start()
    {
        Globals.Instance.Man = this;
        textDisplay.enabled = false;
    }

    public bool SetText(string text)
    {
        if (displayingText) return false;
        StartCoroutine(UpdateText(text));
        StartCoroutine(HideTextDelay());
        return true;
    }

    public IEnumerator HideTextDelay()
    {
        if (textDisplay.enabled)
        {
            textDuration = textDisplayLength;
            yield break;
        }

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
        displayingText = true;
        textDisplay.text = "";
        foreach (var c in newText)
        {
            textDisplay.text += c;
            yield return new WaitForSeconds(0.1f);
        }

        displayingText = false;
    }
}