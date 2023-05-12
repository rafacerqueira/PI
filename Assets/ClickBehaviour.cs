using UnityEngine;
using UnityEngine.EventSystems;

public class ClickBehaviour : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        InventorySlot slot = GetComponent<InventorySlot>();
        if (slot.isOccupied)
        {
            Destroy(transform.GetChild(0).gameObject);
            slot.isOccupied = false;  // The slot is no longer occupied
        }
        else
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                PlacePieces.Instance.ClonePiece(PlacePieces.Instance.piece1, transform);
                slot.isOccupied = true;  // The slot is now occupied
            }
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                PlacePieces.Instance.ClonePiece(PlacePieces.Instance.piece2, transform);
                slot.isOccupied = true;  // The slot is now occupied
            }
        }
    }
}


