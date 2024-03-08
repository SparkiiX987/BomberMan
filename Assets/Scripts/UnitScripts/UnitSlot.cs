using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class UnitSlot : MonoBehaviour
{
    public GameObject unitImage;
    public Unit unit;
    public bool hasInstantiate;

    public GameObject uniqueItemSlot;
    public bool uniqueItemFilled;
    public GameObject generalItemSlot;
    public bool generalItemFilled;
    public UnitsManager unitsManager;
    public Image image;


    private void Awake()
    {
        uniqueItemFilled = false;
        generalItemFilled = false;
    }
    private void Start()
    {
        if (unit != null)
            UnitRef(unit);
    }

    public void UnitRef(Unit _unit)
    {
        int unitIndex = unitsManager.units.IndexOf(_unit);
        unit = unitsManager.units[unitIndex];
    }

    private void ChangeUnitImage(Sprite newImage)
    {
        unitImage.GetComponent<Image>().sprite = newImage;
    }

    public void AddUnit(GameObject newUnit)
    {
        ChangeUnitImage(unit.GetComponent<Unit>().unitIcon);
    }

    public void EquipItem(Item item, Slot slot)
    {
        ChangeItemImage(item, slot);
        unitsManager.inventoryManager.RemoveItemByID(item);
    }

    public void ChangeItemImage(Item item, Slot slot)
    {
        if (item.isUniqueItem)
        {
            uniqueItemSlot.GetComponent<Image>().sprite = slot.currentItemSprite.sprite;
            uniqueItemFilled = true;

        }
        else
        {
            generalItemSlot.GetComponent<Image>().sprite= slot.currentItemSprite.sprite;
            generalItemFilled = true;
        }
    }
}
