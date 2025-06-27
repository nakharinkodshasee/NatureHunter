using UnityEngine;

public class ReturnButton : MonoBehaviour
{
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private InfoPanelManager infoPanelManager;
    public void Return()
    {
        resultPanel.SetActive(true);
        infoPanel.SetActive(false);
        infoPanelManager.DestroyInfoBox();
    }

}
