using System.Collections;
using TMPro;
using UnityEngine;

public class Man : MonoBehaviour
{
    [SerializeField] private readonly float textDisplayLength = 5f;
    private bool displayingText;
    [SerializeField] private TextMeshPro textDisplay;
    [SerializeField] private float textDuration;

    private void Start()
    {
        Globals.Instance.Man = this;
        textDisplay.enabled = false;
    }

    public void SetText(string text)
    {
        Debug.Log("ass");
        if (displayingText) return;
        StartCoroutine(UpdateText(text));
        StopCoroutine(HideTextDelay());
        StartCoroutine(HideTextDelay());
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
        Debug.Log("oui");
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