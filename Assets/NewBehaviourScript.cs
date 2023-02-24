using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public TMP_InputField posicaoX;
    public TMP_InputField posicaoY;

    public void StoreName(){
    string x = posicaoX.text;
    string y = posicaoY.text;

    int pos_x;
    int pos_y;

    x = x.Trim();
    y = y.Trim();

    pos_x = int.Parse(x);
    pos_y = int.Parse(y);
    
    if(pos_x > 2){
            Debug.Log("x > 2 => + 1 POINT :)");
    }
    if(pos_y == 0){
            Debug.Log("y == 0 => - 1 POINT :(");
    }

    Debug.Log("variavel x : " + x + ", variavel y : " + y);
    
}

}

