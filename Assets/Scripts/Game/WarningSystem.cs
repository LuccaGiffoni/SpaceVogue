using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WarningSystem : MonoBehaviour
{
    public static WarningSystem Instance;
    public static bool isAbleToAction = false;

    [SerializeField] private TextMeshProUGUI warningText;
    [SerializeField] private GameObject warningObject;

    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(Instance);
    }

    public void SendWarning(string warning)
    {
        warningText.text = warning;
        StartCoroutine(LogWarningToUser());
    }

    private IEnumerator LogWarningToUser()
    {
        warningObject.SetActive(true);
        isAbleToAction = true;

        yield return new WaitForSeconds(3);

        warningObject.SetActive(false);
        isAbleToAction = false;

        yield return null;
    }
}