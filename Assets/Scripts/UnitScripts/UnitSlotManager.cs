using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSlotManager : MonoBehaviour
{
    public List<GameObject> unitInstances = new List<GameObject>(); 
    public GameObject unitContainerPrefab;
    [SerializeField] private GridLayoutGroup gridLayoutGroup;

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
}