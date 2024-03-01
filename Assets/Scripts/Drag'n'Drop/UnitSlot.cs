using UnityEngine;
using UnityEngine.UI;

public class UnitSlot : MonoBehaviour
{
    public GameObject unitImage;
    public Unit unit;
    public bool hasInstantiate;



    private void ChangeImage(Sprite newImage)
    {
        unitImage.GetComponent<Image>().sprite = newImage;
    }

    public void AddItem(Unit newUnit)
    {
        unit = newUnit;
        ChangeImage(unit.unitIcon);
    }
}
