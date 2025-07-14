using System.Collections.Generic;
using UnityEngine;

public class InfoPanelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] infoBoxes;
    [SerializeField] private GameObject infoPanel;
    private GameObject currentInfoBox;
    private Dictionary<string, GameObject> infoBoxDict;
    private const int SuffixLength = 5;

    void Awake()
    {
        BuildInfoBoxDictionary();
    }

    private void BuildInfoBoxDictionary()
    {
        infoBoxDict = new Dictionary<string, GameObject>(infoBoxes.Length);

        for (int i = 0; i < infoBoxes.Length; i = i + 1)
        {
            string key = infoBoxes[i].name;
            key = key.Substring(0, key.Length - SuffixLength);

            infoBoxDict[key] = infoBoxes[i];
        }
    }
    public void ShowInfoPanel(string boxName)
    {
        infoPanel.SetActive(true);

        if (infoBoxDict.TryGetValue(boxName, out GameObject infoBox))
        {
            currentInfoBox = Instantiate(infoBox, infoPanel.transform, false);
            currentInfoBox.transform.SetSiblingIndex(0);
        }
    }

    public void DestroyInfoBox()
    {
        Destroy(currentInfoBox);
    }
}
