using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopkeeperInteraction : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Player"))
        {
            WarningSystem.Instance.SendWarning("Press 'T' to talk with the Shopkeeper");
        }
    }
}
