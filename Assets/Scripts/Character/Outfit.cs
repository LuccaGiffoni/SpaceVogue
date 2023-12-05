using UnityEngine;

[CreateAssetMenu(fileName = "Outfit", menuName = "Outfit Object")]
public class Outfit : ScriptableObject
{
    [SerializeField] public int OutfitIndex;
    [SerializeField] public Sprite OutfitSprite;
    [SerializeField] public RuntimeAnimatorController OutfitAnimator;
    [SerializeField] public float Price;
}