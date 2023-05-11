using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         InventorySlot[] slots = FindObjectsOfType<InventorySlot>();
         //ItemB[] slotsB = FindObjectsOfType<ItemB>();
        foreach (InventorySlot slot in slots)
        {
            slot.gameObject.AddComponent<ClickBehaviour>();
        }
        /*foreach (ItemB slotB in slotsB)
        {
            slotB.gameObject.AddComponent<ClickBehaviour>();
        }*/
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
