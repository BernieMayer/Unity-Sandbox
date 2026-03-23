using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    private KnapsackGame gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<KnapsackGame>();
    }

    void OnMouseDown()
    {
        gameManager.AddItem(item);
        Destroy(gameObject);
    }
}