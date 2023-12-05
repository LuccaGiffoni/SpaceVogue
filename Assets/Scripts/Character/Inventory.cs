using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    [Header("Itens")]
    [SerializeField] public Outfit actualOutfit;
    [SerializeField] private List<Outfit> outfitsList;
    [SerializeField] private SpriteRenderer outfitSprite;

    [Header("Inventory")]
    [SerializeField] private List<Button> buttons = new();
    [SerializeField] private TextMeshProUGUI currencyText;

    [Header("Player")]
    [SerializeField] private float currency;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(Instance);
    }

    private void Start()
    {
        outfitsList.Clear();
        outfitSprite.sprite = actualOutfit.OutfitSprite;
        currencyText.text = currency.ToString();

        foreach(var button in buttons)
        {
            for(var i = 1; i < outfitsList.Count; i++)
            {
                button.gameObject.SetActive(true);
            }
        }
    }

    public void ChangeOutfit(Outfit newOutfit)
    {
        actualOutfit = newOutfit;
        animator.runtimeAnimatorController = newOutfit.OutfitAnimator;
        outfitSprite.sprite = newOutfit.OutfitSprite;
    }

    public bool BuyNewOutfit(Outfit newOutfit)
    {
        if (currency - newOutfit.Price >= 0)
        {
            currency -= newOutfit.Price;
            outfitsList.Add(newOutfit);
            currencyText.text = currency.ToString();

            foreach (var button in buttons)
            {
                for (var i = 0; i < outfitsList.Count; i++)
                {
                    button.gameObject.SetActive(true);
                }
            }

            return true;
        }
        else
        {
            //WarningSystem.Instance.SendMessage("Not enough money to buy it!");

            return false;
        }
    }
}