using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private GameObject mainMenuPanel;
    public void StartGame()
    {
        tutorialPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }
}
