using UnityEngine;

public class PlacePieces : MonoBehaviour
{

    public static PlacePieces Instance { get; private set; }
    public GameObject piece1; // Assign the first piece in the inspector
    public GameObject piece2; // Assign the second piece in the inspector

    private Camera mainCamera;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        mainCamera = Camera.main;
    }

     public void ClonePiece(GameObject piece, Transform parentSlot)
    {
        GameObject clone = Instantiate(piece, parentSlot.position, Quaternion.identity, parentSlot);
    }

    GameObject FindClosestInventorySlot(Vector2 position)
    {
        GameObject[] slots = GameObject.FindGameObjectsWithTag("InventorySlot");
        GameObject closestSlot = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject slot in slots)
        {
            float distance = Vector2.Distance(position, slot.transform.position);
            if (distance < closestDistance)
            {
                closestSlot = slot;
                closestDistance = distance;
            }
        }

        return closestSlot;
    }
}

