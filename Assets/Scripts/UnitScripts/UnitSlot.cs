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

    private void Start()
    {
        uniqueItemFilled = false;
        generalItemFilled = false;
    }

    private void ChangeUnitImage(Sprite newImage)
    {
        unitImage.GetComponent<Image>().sprite = newImage;
    }

    public void AddUnit(GameObject newUnit)
    {
        unit = newUnit;
        ChangeUnitImage(unit.GetComponent<Unit>().unitIcon);
    }

    public void EquipItem(Item item, Slot slot)
    {
        ChangeItemImage(item, slot);
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
            print(slot);
            generalItemSlot.GetComponent<Image>().sprite= slot.currentItemSprite.sprite;
            generalItemFilled = true;
        }
    }
}
