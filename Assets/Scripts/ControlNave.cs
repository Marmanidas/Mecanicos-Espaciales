using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using System.Linq;


public class ControlNave : MonoBehaviour
{
    [Header("Stats Nave")]
    [SerializeField] TextMeshProUGUI textoCreditos;
    [SerializeField] TextMeshProUGUI[] arrayTextosStatsNave;
    [SerializeField] GestorDeCombate gestorDeCombate;

    [SerializeField] GameManager gameManager;
   
    int indicearray;
    public int creditos;
    public int guardadoCreditos;
    public int puntosResto;



    Dictionary<string, int> statsNave = new Dictionary<string, int>();

    private void Start()
    {
        statsNave.Add("casco", 0);
        statsNave.Add("lasers", 0);
        statsNave.Add("maniobra", 0);
        statsNave.Add("torpedos", 0);
        statsNave.Add("motores", 0);

        statsNave["casco"] = 70;


        creditos = 7;
        GuardarCreditos();


        MostrarPuntuacionesNave();
    }

    public void PonerStatsACero()
    {
        foreach (string clave in statsNave.Keys.ToList())
        {
            statsNave[clave] = 0;
        }

        creditos = guardadoCreditos;
        MostrarPuntuacionesNave();
    }

    void MostrarPuntuacionesNave()
    {
        foreach (int clave in statsNave.Values.ToList())
        {
            arrayTextosStatsNave[indicearray].text = "" + clave;
            indicearray++;
        }
        indicearray = 0;
        textoCreditos.text = "" + creditos;
    }

    public void SumarPuntosNave(string tipoStat)
    {
        if (creditos != 0)
        {
            statsNave[tipoStat]++;
            creditos--;
            MostrarPuntuacionesNave();
        }
        else {

            Debug.Log("no hay suficientes créditos");
        }
       
        
    }

    public void CalculaPuntosBatalla()
    {
        puntosResto = creditos + gestorDeCombate.CreditosTrasLaBatalla();
        creditos = puntosResto;
        GuardarCreditos();
        PonerStatsACero();
        if (creditos <= 0)
        {
            gameManager.PanelVictoriaDerrota("¡Derrota!", true, false);
        }

         
    }

    void GuardarCreditos()
    {
        guardadoCreditos = creditos;
    }

    public void BucleCombateNave()
    {
        
        foreach (int valor in statsNave.Values.ToList())
        {
            gestorDeCombate.GestorPuntosAliados(valor);
        }

        
    }

    public KeyValuePair<string, int> DatosDelTextoNave(int index)
    {
        KeyValuePair<string, int> par = statsNave.ElementAt(index);
        return par;
    }

    public void GestorBonosEquipo(string bono, int cantidad)
    {
        if (bono == "creditos")
        {
            creditos += cantidad;
        }
        else
        {
            statsNave[bono] += cantidad;
        }
        MostrarPuntuacionesNave();
    }


}
