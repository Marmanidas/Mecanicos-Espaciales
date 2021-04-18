using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorDeCombate : MonoBehaviour
{
    [SerializeField] ControlEnemigos controlEnemigos;
    [SerializeField] ControlNave controlNave;
    [SerializeField] GameManager gameManager;

    [SerializeField] List<int> listaPuntosEnemigos = new List<int>();
    [SerializeField] public List<int> listaPuntosNave = new List<int>();

    int CarNave;
    int CarEnemigo;

    int puntoVictoria;
    int puntoDerrota;

    int puntosDestinados;

    public void Combate()
    {
        controlNave.BucleCombateNave();
        puntosDestinados = 0;
        for (int i = 0; i <= listaPuntosEnemigos.Count-1; i++)
        {
            CarNave = listaPuntosNave[i];
            CarEnemigo = listaPuntosEnemigos[i];
            puntosDestinados += CarNave;

            if (CarNave >= CarEnemigo)
            {
                puntoVictoria++;
                puntosDestinados++;
            }
            else if (CarNave < CarEnemigo)
            {
                puntoDerrota++;
                puntosDestinados--;
            }

        }
        if (puntoVictoria > puntoDerrota)
        {
            gameManager.ResolverBatalla(+1);
            gameManager.PanelVictoriaDerrota("¡Victoria!", false, false);
        }
        else
        {
            gameManager.ResolverBatalla(-1);
            gameManager.PanelVictoriaDerrota("¡Derrota!", false, false);
        }
        puntoVictoria = 0;
        puntoDerrota = 0;
    }

    public void GestorPuntosEnemigos(int puntos)
    {      
        listaPuntosEnemigos.Add(puntos);
    }
    public void GestorPuntosAliados (int puntos)
    {
        listaPuntosNave.Add(puntos);
    }

    public void LimpiarListas()
    {
        listaPuntosEnemigos.Clear();
        listaPuntosNave.Clear();
    }

    public int CreditosTrasLaBatalla()
    {
        return puntosDestinados;
    }


}
