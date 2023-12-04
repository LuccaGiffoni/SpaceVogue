using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Rendering;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    [SerializeField] private AnimatorController Outfit;

    public float Currency {  get; private set; }
    public List<AnimatorController> Outfits { get; private set; } = new();

    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(Instance);
    }

    private void Start()
    {
        Outfits.Clear();
        if(Outfit != null) Outfits.Add(Outfit);
    }

    public void ChangeOutfit(AnimatorController newOutfit)
    {
        Outfit = newOutfit;
    }

    public void BuyNewOutfit(AnimatorController newOutfit, float price)
    {
        if (Currency - price >= 0)
        {
            Outfits.Add(newOutfit);
        }
        else
        {
            WarningSystem.Instance.SendMessage("Not enough money to buy it!");
        }
    }
}