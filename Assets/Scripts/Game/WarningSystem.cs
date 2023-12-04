using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WarningSystem : MonoBehaviour
{
    [HideInInspector] public WarningSystem Instance;

    [SerializeField] private TextMeshProUGUI warningText;
    [SerializeField] private GameObject warningObject;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    public void SendWarning(string warning)
    {
        warningText.text = warning;
        StartCoroutine(LogWarningToUser());
    }

    private IEnumerator LogWarningToUser()
    {
        warningObject.SetActive(true);

        yield return new WaitForSeconds(3);

        warningObject.SetActive(false);

        yield return null;
    }
}