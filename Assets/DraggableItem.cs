using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;

    private Vector3 start_position;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin drag");
        start_position = transform.position;
        parentAfterDrag = transform.parent;

        // Set isOccupied to false for the slot the piece is leaving
        InventorySlot slot = parentAfterDrag.GetComponent<InventorySlot>();
        if (slot != null)
        {
            slot.isOccupied = false;
        }

        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Drag");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
{
    Debug.Log("end drag");
    image.raycastTarget = true;

    InventorySlot slot = parentAfterDrag.GetComponent<InventorySlot>();
    if (slot != null && slot.isOccupied)
    {
        // Slot is occupied, return to original position
        Debug.Log("Slot is occupied");
        transform.position = start_position;
    }
    else
    {
        transform.SetParent(parentAfterDrag);
        if(slot != null)
        {
            slot.isOccupied = true;  // The slot is now occupied
        }
    }
}

}
