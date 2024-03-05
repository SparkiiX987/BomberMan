using System.Collections.Generic;
using UnityEngine;

public class UnitsManager : MonoBehaviour
{
    public List<Unit> units = new List<Unit>();
    public UnitsManager ennemiesUnits;

    private void Awake()
    {
        foreach (Unit unit in units)
        {
            unit.unitsManager = this;
        }
    }

    public Unit GetUnit(Unit _unit)
    {
        foreach (Unit unit in units)
        {
            if (unit == _unit) return unit;
        }
        return null;
    }

    private void AddAllUnitsIntoList()
    {
        //TODO
    }
}
