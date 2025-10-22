using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanelManager : MonoBehaviour
{
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private GameObject box;
    [SerializeField] private RectTransform layout;
   
    private int rfaScore = 0, rfpScore = 0, mfaScore = 0, mfpScore = 0;
    [SerializeField] private TextMeshProUGUI rfaText, rfpText, mfaText, mfpText;

    private Dictionary<string, System.Action> scoreActions;
    void Awake()
    {
        scoreActions = new Dictionary<string, System.Action>(4)
        {
        ["rfa"] = () => { rfaScore++; rfaText.text = rfaScore.ToString(); },
        ["rfp"] = () => { rfpScore++; rfpText.text = rfpScore.ToString(); },
        ["mfa"] = () => { mfaScore++; mfaText.text = mfaScore.ToString(); },
        ["mfp"] = () => {mfpScore++;mfpText.text = mfpScore.ToString();}
        };

    }

    public void ResultUpdate(GameObject creature,Texture2D screenshot)
    {
        Creature creatureComponent = creature.GetComponent<Creature>();
        AddScore(creatureComponent.CreatureAndForestType);
        AddBoxToLayout(creatureComponent.CreatureName,screenshot,creatureComponent.DisplayName);
    }

    private void AddScore(string creatureAndForestType)
    {
        if (scoreActions.TryGetValue(creatureAndForestType, out System.Action action))
            action();
    }

    private void AddBoxToLayout(string creatureName, Texture2D screenshot,string displayName)
    {
        GameObject newBox = Instantiate(box, layout, false);
        newBox.name = creatureName;
        newBox.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = displayName;
        newBox.transform.GetChild(1).GetComponent<RawImage>().texture = screenshot;
    }
}
