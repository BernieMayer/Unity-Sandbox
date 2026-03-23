using System.Collections.Generic;
using UnityEngine;

public class KnapsackGame : MonoBehaviour
{
    public int maxWeight = 15;
    public List<Item> items = new List<Item>();

    private int currentWeight = 0;
    private int currentValue = 0;

    public void AddItem(Item item)
    {
        if (currentWeight + item.weight <= maxWeight)
        {
            currentWeight += item.weight;
            currentValue += item.value;

            Debug.Log("Added: " + item.itemName);
            Debug.Log("Weight: " + currentWeight + "/" + maxWeight);
            Debug.Log("Value: " + currentValue);
        }
        else
        {
            Debug.Log("Bag is too heavy!");
        }
    }
}