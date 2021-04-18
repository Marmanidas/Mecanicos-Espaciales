using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ControlEnemigos : MonoBehaviour
{
    Dictionary<string, int> statsEnemigo = new Dictionary<string, int>();
    [SerializeField] GestorDeCombate gestorDeCombate;
    [SerializeField] GameManager gameManager;

    int combateMin, combateMax;

    private void Start()
    {
        combateMin = 0;
        combateMax = 2;

        statsEnemigo.Add("casco", 0);
        statsEnemigo.Add("lasers", 0);
        statsEnemigo.Add("maniobra", 0);
        statsEnemigo.Add("torpedos", 0);
        statsEnemigo.Add("motores", 0);
        CalculaPuntosEnemigos();
       
    }

    public void CalculaPuntosEnemigos()
    {
        SubirNivelEnemigo();
        foreach (string clave in statsEnemigo.Keys.ToList())
        {
            int puntuacion = Random.Range(combateMin, combateMax);
            statsEnemigo[clave] = puntuacion;
        }
        BucleCombateEnemigo();
    }

    public void BucleCombateEnemigo()
    {

        foreach (int valor in statsEnemigo.Values.ToList())
        {
            gestorDeCombate.GestorPuntosEnemigos(valor);
        }


    }

    public KeyValuePair<string, int> DatosDelTextoEnemigo(int index) 
    {
        KeyValuePair<string, int> par = statsEnemigo.ElementAt(index);
        return par;
    }

    void SubirNivelEnemigo()
    {
        bool inicio = false;
        int batallas = gameManager.NumeroDeBatallasRealizadas();

        if (inicio == true)
        {
            if (batallas % 6 == 0 || batallas % 10 == 0)
            {
                combateMax++;
            }
        }

        if (batallas % 3 == 0)
        {
            Debug.Log("El enemigo sube de nivel");
            combateMax +=2;
            inicio = true;
        }
        if (batallas % 2 == 0)
        {
            combateMin++;
        }
       
       
       
    }
}
   
