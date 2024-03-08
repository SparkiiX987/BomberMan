using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class UnitSlot : MonoBehaviour
{
    public GameObject unitImage;
    public GameObject unit;
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

    public GameObject InstantiateUnit(Case _case)
    {
        GameObject thisUnit = Instantiate(unit);
        return thisUnit;
    }

    private void ChangeUnitImage(Sprite newImage)
    {
        unitImage.GetComponent<Image>().sprite = newImage;
    }

    public void AddUnit(GameObject newUnit)
    {
        ChangeUnitImage(unit.GetComponent<Unit>().unitIcon);
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

    public void EquipItem(Item item, Slot slot)
    {
        if (!hasInstantiate)
        {
            ChangeItemImage(item, slot);
            unitsManager.inventoryManager.RemoveItemByID(item);
            if (uniqueItemFilled)
            {
                unit.GetComponent<Unit>().item1 = item;
            }
            else if (generalItemFilled)
            {
                unit.GetComponent<Unit>().item2 = item;
            }
        }   
    }
}
