using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryManager;
    [SerializeField] private GameObject inventoryButton;

    [SerializeField] private List<GameObject> dialoguesList = new();

    private void Start()
    {
        inventoryManager.SetActive(false);
        inventoryButton.SetActive(true);
    }

    public void ToggleInventoryMenu()
    {
        if (inventoryManager.activeInHierarchy)
        {
            inventoryManager.SetActive(false);
            inventoryButton.SetActive(true);
        }
        else
        {
            inventoryManager.SetActive(true);
            inventoryButton.SetActive(false);

            foreach (GameObject dialogue in dialoguesList)
            {
                dialogue.SetActive(false);
            }
        }
    }
}
