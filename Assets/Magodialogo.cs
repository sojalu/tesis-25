using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using TMPro;


public class MagoDialogo : MonoBehaviour
{
    public GameObject panelDialogo;
    public TextMeshProUGUI textoDialogo;
    public string[] lineasDeDialogo;

    private int lineaActual = 0;
    private bool jugadorCerca = false;
    private bool dialogoActivo = false;

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogoActivo)
            {
                panelDialogo.SetActive(true);
                textoDialogo.text = lineasDeDialogo[lineaActual];
                dialogoActivo = true;
            }
            else
            {
                lineaActual++;
                if (lineaActual < lineasDeDialogo.Length)
                {
                    textoDialogo.text = lineasDeDialogo[lineaActual];
                }
                else
                {
                    panelDialogo.SetActive(false);
                    lineaActual = 0;
                    dialogoActivo = false;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            panelDialogo.SetActive(false);
            lineaActual = 0;
            dialogoActivo = false;
        }
    }
}


