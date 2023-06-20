using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public TMP_InputField moveFrom;
    public TMP_InputField moveTo;

    public TextMeshProUGUI mensagem;

    private int contador = 0;

    public void StoreName()
    {
        string x = moveFrom.text;
        string y = moveTo.text;

        int movefrom;
        int moveto;

        x = x.Trim();
        y = y.Trim();

        if (int.TryParse(x, out movefrom) && int.TryParse(y, out moveto))
        {
            if (validMove(movefrom, moveto))
            {
                contador++;
                mensagem.text = "Player 1 = " + contador;
                mensagem.gameObject.SetActive(true);
            }
        }
    }

    public bool validMove(int movefrom, int moveto)
    {
        int xfrom = movefrom / 10 - 1;
        int yfrom = movefrom % 10 - 1;
        int xto = moveto / 10 - 1;
        int yto = moveto % 10 - 1;

        if (xfrom < 0 || xfrom > 7 || yfrom < 0 || yfrom > 7 || xto < 0 || xto > 7 || yto < 0 || yto > 7)
        {
            return false;
        }

        return true;
    }
}
