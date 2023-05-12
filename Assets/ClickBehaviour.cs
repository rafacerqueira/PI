using UnityEngine;
using UnityEngine.EventSystems;

public class ClickBehaviour : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
        else
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                PlacePieces.Instance.ClonePiece(PlacePieces.Instance.piece1, transform);
            }
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                PlacePieces.Instance.ClonePiece(PlacePieces.Instance.piece2, transform);
            }
        }
    }
}

