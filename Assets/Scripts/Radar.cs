using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Radar : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoDatosUno;
    [SerializeField] TextMeshProUGUI puntosDatosUno;
    [SerializeField] TextMeshProUGUI textoDatosDos;
    [SerializeField] TextMeshProUGUI puntosDatosDos;

    [SerializeField] ControlEnemigos controlEnemigos;
    [SerializeField] GestorDeCombate gestorDeCombate;
    [SerializeField] GameManager gameManager;

    [SerializeField] Animator radar;

    float posibilidadEspionaje;

    public void EstablecerEspionaje()
    {
        posibilidadEspionaje = Random.value;
        if (posibilidadEspionaje > 0.4f)
        {
            Invoke(nameof(DatosRadar), 0.3f);
        }
        else
        {
            Debug.Log("No hay radar");
        }
    }

    public void DatosRadar()
    {
        radar.SetBool("ApareceRadar", true);
        gameManager.activarRadar(true);
        int indice = Random.Range(0, 4);
        textoDatosUno.text = controlEnemigos.DatosDelTextoEnemigo(indice).Key;
        puntosDatosUno.text = controlEnemigos.DatosDelTextoEnemigo(indice).Value.ToString();
        int indice2 = Random.Range(0, 4);
        if (indice2 == indice)
        {
            indice2++;
            if (indice2 > 4)
            {
                indice2 = 0;
            }
        }
        textoDatosDos.text = controlEnemigos.DatosDelTextoEnemigo(indice2).Key;
        puntosDatosDos.text = controlEnemigos.DatosDelTextoEnemigo(indice2).Value.ToString();
    }

}
