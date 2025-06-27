using UnityEngine;

public class Creature : MonoBehaviour
{
    [SerializeField] private string creatureName;
    [SerializeField] private string creatureAndForestType;
    [SerializeField] private GameObject[] sameCreature;

    public string CreatureName => creatureName;
    public string CreatureAndForestType => creatureAndForestType;
    public GameObject[] SameCreature => sameCreature;
}
