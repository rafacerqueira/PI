using UnityEngine;
using UnityEngine.EventSystems;

public class ClickBehaviour : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(gameObject);
    }
}

