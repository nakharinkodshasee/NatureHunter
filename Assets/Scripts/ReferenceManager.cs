using UnityEngine;

public class ReferenceManager : MonoBehaviour
{
    public static ReferenceManager Instance { get; private set; }
    
    [Header("UI References")]
    public GameObject resultPanel;
    public InfoPanelManager infoPanelManager;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}