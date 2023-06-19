using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick2 : MonoBehaviour
{
    public GameObject OnClickPopup2; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click(){
        OnClickPopup2.SetActive(false);
    }
}