using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PanelResultados : MonoBehaviour
{
    [SerializeField] ControlEnemigos controlEnemigos;
    [SerializeField] ControlNave controlNave;
    [SerializeField] GestorDeCombate gestorDeCombate;
    [SerializeField] GameManager gameManager;
    [SerializeField] Radar radar;
    [SerializeField] Tienda tienda;

    [SerializeField] TextMeshProUGUI [] arrayTextosEnemigos;
    [SerializeField] TextMeshProUGUI[] arrayTextosAliado;
    [SerializeField] Image[] arrayDotVerde;

 
    public void MostrarResultadosEnemigo()
    {
        DesactivarDotVerde();
        int datoNave;
        int datoEnemigo;

        for (int c = 0; c <= arrayTextosAliado.Length - 1; c++)
        {
            TextMeshProUGUI textoTemporalnave = arrayTextosAliado[c];
            datoNave = controlNave.DatosDelTextoNave(c).Value;
            textoTemporalnave.text = controlNave.DatosDelTextoNave(c).Value.ToString();

            TextMeshProUGUI texto = arrayTextosEnemigos[c];
            datoEnemigo = controlEnemigos.DatosDelTextoEnemigo(c).Value;
            texto.text = controlEnemigos.DatosDelTextoEnemigo(c).Value.ToString();
       
            if (datoNave >= datoEnemigo)
            {
                Image dotVerde = textoTemporalnave.GetComponentInChildren<Image>();
                dotVerde.enabled = true;
            }
        }

         
    }


    void DesactivarDotVerde()
    {
        foreach (Image imagen in arrayDotVerde)
        {
            imagen.enabled = false;
        }
    }

    public void BotonContinuar()
    {
        Invoke(nameof(LlamarRadar), 1.5f);
        gestorDeCombate.LimpiarListas();
        controlEnemigos.CalculaPuntosEnemigos();
        gameManager.ActivarDesactivarPaneles(false);
        DesactivarDotVerde();
        tienda.AparicionPanel();
        this.gameObject.SetActive(false);
    }

    void LlamarRadar()
    {
        radar.EstablecerEspionaje();
    }
}
