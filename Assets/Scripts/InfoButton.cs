using UnityEngine;

public class InfoButton : MonoBehaviour
{
    private string boxName;

    void Start()
    {
        boxName = gameObject.name;
    }

    public void HideResultPanel()
    {
        ReferenceManager.Instance.infoPanelManager.ShowInfoPanel(boxName);
        ReferenceManager.Instance.resultPanel.SetActive(false);
    }
}
