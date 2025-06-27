using UnityEngine;

public class NextButton : MonoBehaviour
{
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private GameObject creaturePanel;
    public void NextPanel()
    {   
        if (creaturePanel != null)
        creaturePanel.SetActive(true);
        if (tutorialPanel != null)
        tutorialPanel.SetActive(false);
    }
}
