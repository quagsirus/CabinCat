using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Objectives : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    private int itemsCollected;
    private int itemsPresented;
    [SerializeField] private int totalItems;

    private void Start()
    {
        Globals.Instance.ItemGivenToMan += ItemPresented;
        Globals.Instance.ItemPickedUp += ItemCollected;
        UpdateDisplay();
    }

    private void ItemCollected()
    {
        itemsCollected++;
        UpdateDisplay();
    }

    private void ItemPresented()
    {
        itemsPresented++;
        UpdateDisplay();
        if (itemsPresented == totalItems) Globals.Instance.ObjectiveComplete = true;
    }

    private void UpdateDisplay()
    {
        text.text = $"Objectives:\nFind Mementos {itemsCollected}/{totalItems}\nPresent Mementos To Old Man {itemsPresented}/{totalItems}";
    }
}
