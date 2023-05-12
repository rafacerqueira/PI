using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData){
        // Handled by DraggableItem.OnEndDrag
    }

    /*public void OnPointerEnter(PointerEventData eventData){
        DraggableItem draggableItem = eventData.pointerDrag.GetComponent<DraggableItem>();
        if (draggableItem != null)
        {
            draggableItem.potentialDropZone = this;
        }
    }

    public void OnPointerExit(PointerEventData eventData){
        DraggableItem draggableItem = eventData.pointerDrag.GetComponent<DraggableItem>();
        if (draggableItem != null && draggableItem.potentialDropZone == this)
        {
            draggableItem.potentialDropZone = null;
        }
    }*/
}

