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
    public TextMeshProUGUI contadorText;

    private int contador = 0;
    private float tempoInicial;
    private bool contadorAtivo;

    public float tempoTotal = 120f; // Tempo total em segundos (2 minutos)

    private void Start()
    {
        tempoInicial = Time.time;
        contadorAtivo = true;
    }

    private void Update()
    {
        if (contadorAtivo)
        {
            float tempoAtual = Time.time - tempoInicial;
            float tempoRestante = tempoTotal - tempoAtual;

            if (tempoRestante <= 0f)
            {
                tempoRestante = 0f;
                contadorAtivo = false;
                mensagem.text = "Tempo esgotado!";
                mensagem.gameObject.SetActive(true);
            }

            contadorText.text ="Tempo Restante: " + FormatTime(tempoRestante);
        }
    }

   public void StoreName()
{
    if (!contadorAtivo)
    {
        return; // Ignore if the counter is inactive
    }

    string x = moveFrom.text;
    string y = moveTo.text;

    int movefrom;
    int moveto;

    x = x.Trim();
    y = y.Trim();

    if (int.TryParse(x, out movefrom) && int.TryParse(y, out moveto))
    {
        string inventorySlotFromName = "InventorySlot_" + movefrom;
        string inventorySlotToName = "InventorySlot_" + moveto;

        GameObject inventorySlotFromObject = GameObject.Find(inventorySlotFromName);
        GameObject inventorySlotToObject = GameObject.Find(inventorySlotToName);

        if (inventorySlotFromObject != null && inventorySlotToObject != null)
        {
            InventorySlot inventorySlotFrom = inventorySlotFromObject.GetComponent<InventorySlot>();
            InventorySlot inventorySlotTo = inventorySlotToObject.GetComponent<InventorySlot>();

            if (inventorySlotFrom != null && inventorySlotFrom.HasChild() && inventorySlotTo != null && !inventorySlotTo.HasChild())
            {
                // Move the child object from moveFrom to moveTo
                Transform childObject = inventorySlotFrom.transform.GetChild(0);
                childObject.SetParent(inventorySlotTo.transform);
                childObject.localPosition = Vector3.zero;

                contador++;
                mensagem.text = "Player 1 = " + contador;
                mensagem.gameObject.SetActive(true);
            }
            else
            {
                mensagem.text = "Challenge failed";
                mensagem.gameObject.SetActive(true);
            }
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

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
