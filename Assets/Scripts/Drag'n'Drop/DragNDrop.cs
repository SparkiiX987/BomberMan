using System.Collections;
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

    GameObject Slot;
    GameObject DraggedImage;

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

            if(draging )
            {
                result.transform.SetParent(dragNDropGO.transform);
            }


            if(Input.GetMouseButtonDown(0) && result.tag == "UnitSlot" && result.GetComponentInParent<UnitSlot>().unit != null)
            {
                draging = true;
                Slot = result.transform.parent.gameObject;
            }

            else if (draging && Input.GetMouseButtonUp(0) && result.tag == "UnitSlot")
            {
                draging = false;
                ReturnImage(result);
                RaycastHit hit;
                if (!result.GetComponentInParent<UnitSlot>().hasInstantiate && Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), new Vector3(0, 0, 1), out hit, 1000) && hit.collider.TryGetComponent<Case>(out Case _case) && !_case.HasUnite())
                {
                    result.GetComponentInParent<UnitSlot>().hasInstantiate = true;
                    print(hit.collider.name);
                }
                    
            }
        }
    }

    private void ReturnImage(GameObject draggedImage)
    {
        draggedImage.transform.SetParent(Slot.transform);
        draggedImage.transform.position = Slot.transform.position;
    }

}
