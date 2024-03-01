using UnityEngine;
using UnityEngine.UI;

public class UnitSlot : MonoBehaviour
{
    public GameObject unitImage;
    public GameObject unit;
    public bool hasInstantiate;

    private void ChangeImage(Sprite newImage)
    {
        unitImage.GetComponent<Image>().sprite = newImage;
    }

    public void AddUnit(GameObject newUnit)
    {
        unit = newUnit;
        ChangeImage(unit.GetComponent<Unit>().unitIcon);
    }
}
