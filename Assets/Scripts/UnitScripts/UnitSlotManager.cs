using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSlotManager : MonoBehaviour
{
    public List<GameObject> unitInstances = new List<GameObject>();
    public GameObject unitContainerPrefab;
    [SerializeField] private GridLayoutGroup gridLayoutGroup;
    public bool isPlayer1;
    public bool isPlayer2;

    public InventoryManager inventoryManager;
    public TurnGestion turnGestion;

    public void Awake()
    {
        InitializeUnitSlots();
    }

    public void InitializeUnitSlots()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject unitInstance = Instantiate(unitContainerPrefab, gridLayoutGroup.transform);
            unitInstances.Add(unitInstance);
        }
    }

    public void WinRound()
    {
        if (isPlayer1 && unitInstances.Count == 0)
        {
            Debug.Log("Player 1 wins the round!");
            turnGestion.player2Win = true;
        }
        else if (isPlayer2 && unitInstances.Count == 0)
        {
            Debug.Log("Player 2 wins the round!");
            turnGestion.player1Win = true;
        }
    }
}