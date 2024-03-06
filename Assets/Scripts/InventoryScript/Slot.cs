using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour //IPointerEnterHandler, IPointerExitHandler
{
    public List<Sprite> itemSprite = new List<Sprite>();
    public List<Sprite> itemBorder = new List<Sprite>();
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDesc;
    public GameObject descScreen;
    public Image currentItemSprite;
    public Image currentBorderSprite;
    public bool hasInstantiate;

    public void UpdateItem(Item item)
    {
        if (item == null)
            return;
        ChangeSlotVisual(item);
    }

    public void ChangeSlotVisual(Item item)
    {
        switch (item.id)
        {
            case 0:
                itemName.text = "Empty";
                itemDesc.text = "";
                currentItemSprite.sprite = itemSprite[0];
                currentBorderSprite.sprite = itemBorder[0];
                break;
            case 1:
                itemName.text = "Crystal Powder";
                itemDesc.text = "" + "More Attack Speed";
                currentItemSprite.sprite = itemSprite[1];
                currentBorderSprite.sprite = itemBorder[1];
                break;
            case 2:
                itemName.text = "Refined Steel";
                itemDesc.text = "" + "More Damage";
                currentItemSprite.sprite = itemSprite[2];
                currentBorderSprite.sprite = itemBorder[1];
                break;
            case 3:
                itemName.text = "Light Armor";
                itemDesc.text = "" + "More Movement Speed";
                currentItemSprite.sprite = itemSprite[3];
                currentBorderSprite.sprite = itemBorder[1];
                break;
            case 4:
                itemName.text = "ChainMail";
                itemDesc.text = "" + "More Health";
                currentItemSprite.sprite = itemSprite[4];
                currentBorderSprite.sprite = itemBorder[1];
                break;
            case 5:
                itemName.text = "Double Blades";
                itemDesc.text = "" + "More Damage and Attack Speed" + "Only for Attacker";
                currentItemSprite.sprite = itemSprite[5];
                currentBorderSprite.sprite = itemBorder[2];
                break;
            case 6:
                itemName.text = "Halberd";
                itemDesc.text = "" + "More Range" + "Only for DPS";
                currentItemSprite.sprite = itemSprite[6];
                currentBorderSprite.sprite = itemBorder[2];
                break;
            case 7:
                itemName.text = "Crystal Belt";
                itemDesc.text = "" + "More Health and Movement Speed" + "Only for Tank";
                currentItemSprite.sprite = itemSprite[7];
                currentBorderSprite.sprite = itemBorder[2];
                break;
            case 8:
                itemName.text = "Powder Reserve";
                itemDesc.text = "" + "More Mine Range" + "Only for Trapper";
                currentItemSprite.sprite = itemSprite[8];
                currentBorderSprite.sprite = itemBorder[2];
                break;
            case 9:
                itemName.text = "Crystal Crown";
                itemDesc.text = "" + "Faster Ultimate Charge" + "Only for Buffer";
                currentItemSprite.sprite = itemSprite[9];
                currentBorderSprite.sprite = itemBorder[2];
                break;
        }
    }

    /*public void OnPointerEnter(PointerEventData eventData)
    {
        descScreen.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        descScreen.SetActive(false);
    }*/
}
