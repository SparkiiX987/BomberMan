using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSlotManager : MonoBehaviour
{
    public List<GameObject> unitPrefab = new List<GameObject>();
    public GameObject unitContainer;
    [SerializeField] private GridLayoutGroup gridLayoutGroup;
    private UnitSlot unitSlot;

    public void Awake()
    {
        InitializeUnitSlots();
        unitSlot = GetComponent<UnitSlot>();
    }

    public void InitializeUnitSlots()
    {
        foreach (GameObject unitContainer in unitPrefab)
        {
            GameObject unitInstance = Instantiate(unitContainer, gridLayoutGroup.transform);
            unitInstance.SetActive(true);
        }
    }
}
