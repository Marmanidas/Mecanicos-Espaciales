using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlEntreEscenas : MonoBehaviour
{
    GameManager gameManager;
    string textoVictoriaDerrota;
    string numeroBatallas;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        gameManager = FindObjectOfType<GameManager>();
    }

    public void RecogerDatos(string victoria, string datos)
    {
        textoVictoriaDerrota = victoria;
        numeroBatallas = datos;
        SceneManager.LoadScene("FinVictoria");
    }

    public string TextoVictoria()
    {
        return textoVictoriaDerrota;
    }

    public string Batallas()
    {
        return numeroBatallas;
    }

   
}
