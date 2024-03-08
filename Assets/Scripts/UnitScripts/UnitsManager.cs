using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitsManager : MonoBehaviour
{
    public List<Unit> units = new List<Unit>();
    public List<GameObject> unitUI = new List<GameObject>();
    public UnitsManager ennemiesUnits;
    private UnitSlot unitSlot;
    public GameObject unitContainerPrefab;
    [SerializeField] private GridLayoutGroup gridLayoutGroup;
    public bool isPlayer1;
    public GameObject unitSpawn;

    public InventoryManager inventoryManager;
    public TurnGestion turnGestion;

    private void Awake()
    {
        InitializeUnits();
    }

    private void InitializeUnits()
    {
        for (int i = 0; i < units.Count; i++)
        {
            units[i].unitsManager = this;
            GameObject unitInstance = Instantiate(unitContainerPrefab, gridLayoutGroup.transform);
            unitInstance.GetComponent<UnitSlot>().unitsManager = this;
            unitInstance.GetComponent<UnitSlot>().unit = units[i];
            unitUI.Add(unitInstance);
            Instantiate(units[i], unitSpawn.transform);
        }
    }

    public void GetUnit(Unit _unit)
    {
        int unitIndex = units.IndexOf(_unit);
        int uSlotIndex = unitUI.IndexOf(unitContainerPrefab);

        foreach (Unit unit in units)
        {
            if (uSlotIndex == unitIndex)
            {
                unitSlot.image.sprite = unit.unitIcon;
                unitSlot.unit = unit;
            }
        }
    }

    public Unit GetKilledUnit(Unit _unit)
    {
        foreach (Unit unit in units)
        {
            if (unit == _unit) return unit;
        }
        return null;
    }

    public void UpdateImage()
    {

    }

    public void WinRound()
    {
        if (isPlayer1 && unitUI.Count == 0)
        {
            Debug.Log("Player 1 wins the round!");
            turnGestion.player2Win = true;
        }
        else if (!isPlayer1 && unitUI.Count == 0)
        {
            Debug.Log("Player 2 wins the round!");
            turnGestion.player1Win = true;
        }
    }
}
