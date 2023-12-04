using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : ScriptableObject
{
    public float Currency {  get; private set; }
    public Sprite Outfit { get; private set; }
    public List<Sprite> Outfits { get; private set; } = new();
}