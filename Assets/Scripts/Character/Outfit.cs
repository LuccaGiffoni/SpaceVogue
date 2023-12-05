using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "Outfit", menuName = "Outfit Object")]
public class Outfit : ScriptableObject
{
    [SerializeField] public int OutfitIndex;
    [SerializeField] public Sprite OutfitSprite;
    [SerializeField] public AnimatorController OutfitAnimator;
    [SerializeField] public float Price;
}