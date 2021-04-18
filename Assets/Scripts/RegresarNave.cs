using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegresarNave : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Radar radar;
    [SerializeField] GestorDeCombate gestorCombate;

    [SerializeField] GameObject panelResultados;

    public void RegresarLanave()
    {
        panelResultados.SetActive(true);
        gameManager.Fade(false);
        gestorCombate.Combate();
        MostrarResultados();
    }


    void MostrarResultados()
    {
        PanelResultados resultados = panelResultados.GetComponent<PanelResultados>();
        resultados.MostrarResultadosEnemigo();
    }
}
