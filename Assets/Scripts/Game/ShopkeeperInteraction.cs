using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopkeeperInteraction : MonoBehaviour
{
    public static ShopkeeperInteraction Instance;

    [Header("Dialogue Settings")]
    [SerializeField] private List<string> dialogueList = new();
    [SerializeField] private TextMeshProUGUI dialogueBoxText;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private int typingSpeed = 10;

    [Header("Buttons")]
    [SerializeField] private List<Button> confirmationButtons = new();
    [SerializeField] private List<Button> buyingButtons = new();

    [Header("Item")]
    [SerializeField] private Outfit newOutfit;

    private int dialogueIndex = 0;
    public bool hasPlayerBought = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            WarningSystem.Instance.SendWarning("Press 'T' to talk with the Shopkeeper");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueBox.SetActive(false);

            dialogueIndex = 0;
            dialogueBoxText.text = "";

            foreach (var button in confirmationButtons)
            {
                button.gameObject.SetActive(true);
            }

            foreach (var button in buyingButtons)
            {
                button.gameObject.SetActive(false);
            }
        }
    }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(Instance);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && WarningSystem.isAbleToAction)
        {
            if (!hasPlayerBought)
            {
                dialogueIndex = 0;
                dialogueBox.SetActive(true);

                foreach (var button in confirmationButtons)
                {
                    button.gameObject.SetActive(true);
                }

                foreach (var button in buyingButtons)
                {
                    button.gameObject.SetActive(false);
                }

                TypeText();
            }
            else
            {
                dialogueIndex = 4;
                dialogueBox.SetActive(true);
                TypeText();
            }
        }
    }

    private void TypeText()
    {
        dialogueBoxText.text = dialogueList[dialogueIndex];

        if (dialogueIndex == 1)
        {
            foreach (var button in confirmationButtons)
            {
                button.gameObject.SetActive(false);
            }

            foreach (var button in buyingButtons)
            {
                button.gameObject.SetActive(true);
            }
        }
        else if (hasPlayerBought)
        {
            foreach (var button in confirmationButtons)
            {
                button.gameObject.SetActive(false);
            }

            foreach (var button in buyingButtons)
            {
                button.gameObject.SetActive(false);
            }
        }
    }

    public void StartBuying()
    {
        dialogueIndex = 1;

        TypeText();
    }

    public void BuyClothes()
    {
        var response = Inventory.Instance.BuyNewOutfit(newOutfit);

        if (response)
        {
            dialogueIndex = 2;

            foreach (var button in confirmationButtons)
            {
                button.gameObject.SetActive(false);
            }

            foreach (var button in buyingButtons)
            {
                button.gameObject.SetActive(false);
            }

            hasPlayerBought = true;

            TypeText();
        }
        else
        {
            dialogueIndex = 5;

            foreach (var button in confirmationButtons)
            {
                button.gameObject.SetActive(false);
            }

            foreach (var button in buyingButtons)
            {
                button.gameObject.SetActive(false);
            }

            TypeText();
        }
    }

    public void LeaveShop()
    {
        dialogueIndex = 3;

        TypeText();

        foreach (var button in confirmationButtons)
        {
            button.gameObject.SetActive(false);
        }

        foreach (var button in buyingButtons)
        {
            button.gameObject.SetActive(false);
        }
    }
}