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

    private void AddAllUnitsIntoList()
    {
        //TODO
    }
}
