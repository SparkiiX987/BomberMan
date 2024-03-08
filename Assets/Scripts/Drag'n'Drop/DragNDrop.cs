using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragNDrop : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;
    [SerializeField] GraphicRaycaster m_Raycaster;

    private bool draging = false;
    [SerializeField] private GameObject dragNDropGO;

    Slot parentSlot;
    GameObject unitSlot;
    Item item;

    void Update()
    {
        //get mouse pos
        Vector3 mousePos = Input.mousePosition;
        PointerEventData pointerEventData = new PointerEventData(eventSystem);
        pointerEventData.position = mousePos;

        dragNDropGO.transform.position = mousePos;

        List<RaycastResult> results = new List<RaycastResult>();

        m_Raycaster.Raycast(pointerEventData, results);

        if (results.Count > 0 )
        {
            GameObject result = results[0].gameObject;
            UnitDragAndDrop(result);

            if (results.Count > 1) 
            {
                ItemDragAndDrop(result, results[1].gameObject);
            }
        }
    }

    private void UnitDragAndDrop(GameObject result)
    {
        if (draging)
        {
            result.transform.SetParent(dragNDropGO.transform);
        }

        if (Input.GetMouseButtonDown(0) && result.CompareTag("UnitSlot") && result.GetComponentInParent<UnitSlot>().unit != null && !result.GetComponentInParent<UnitSlot>().hasInstantiate)
        {
            draging = true;
            unitSlot = result.transform.parent.gameObject;
        }

        else if (draging && Input.GetMouseButtonUp(0) && result.CompareTag("UnitSlot"))
        {
            draging = false;
            ReturnImage(result);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitData;

            if (!unitSlot.GetComponent<UnitSlot>().hasInstantiate && Physics.Raycast(ray, out hitData) && hitData.collider.TryGetComponent<Case>(out Case _case) && !_case.HasUnite())
            {
                result.GetComponentInParent<UnitSlot>().hasInstantiate = true;
                unitSlot.GetComponent<UnitSlot>().unit.GetComponent<Unit>().currentCase = _case;
                unitSlot.GetComponent<UnitSlot>().InstantiateUnit(unitSlot.GetComponent<UnitSlot>().unit.GetComponent<Unit>().currentCase);
            }
        }
    }

    public void ItemDragAndDrop(GameObject result, GameObject unitInstance)
    {
        if (draging)
        {
            result.transform.SetParent(dragNDropGO.transform);
        }

        InventoryManager inventoryManager = result.GetComponentInParent<InventoryManager>();
        
        if (Input.GetMouseButtonDown(0) && result.CompareTag("ItemSlot") && inventoryManager.itemsList[inventoryManager.itemsSlots.IndexOf(result.GetComponentInParent<Slot>().gameObject)] != inventoryManager.emptyItem)
        {
            parentSlot = result.GetComponentInParent<Slot>();
            item = inventoryManager.itemsList[inventoryManager.itemsSlots.IndexOf(parentSlot.gameObject)];
            draging = true;
            unitSlot = result.transform.parent.gameObject;
        }
        else if (draging && Input.GetMouseButtonUp(0))
        {
            draging = false;
            ReturnImage(result);
            if (unitInstance.GetComponentInParent<UnitSlot>() != null)
            {
                UnitSlot unitSlot = unitInstance.GetComponentInParent<UnitSlot>();
                if (item.isUniqueItem && !unitSlot.uniqueItemFilled && unitInstance.CompareTag("UnitSlot"))
                {
                    unitSlot.EquipItem(item, parentSlot);
                }
                else if (!item.isUniqueItem && !unitSlot.generalItemFilled && unitInstance.CompareTag("UnitSlot"))
                {
                    unitSlot.EquipItem(item, parentSlot);
                }
            }
        }
    }

    private void ReturnImage(GameObject draggedImage)
    {
        draggedImage.transform.SetParent(unitSlot.transform);
        draggedImage.transform.position = unitSlot.transform.position;
    }
}
