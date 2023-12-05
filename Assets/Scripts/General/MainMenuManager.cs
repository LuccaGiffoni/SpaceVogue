using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(mainMenu.activeInHierarchy) mainMenu.SetActive(false);
            else mainMenu.SetActive(true);
        }
    }

    public void LeaveGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        mainMenu.SetActive(false);
    }
}
