using UnityEngine;

public class Creature : MonoBehaviour
{
    [SerializeField] private string creatureName;
    [SerializeField] private string displayName;
    [SerializeField] private string creatureAndForestType;
    [SerializeField] private GameObject[] sameCreature;

    public string CreatureName => creatureName;
    public string DisplayName => displayName;
    public string CreatureAndForestType => creatureAndForestType;
    public GameObject[] SameCreature => sameCreature;
}
