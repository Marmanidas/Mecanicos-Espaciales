using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ControlFinJuego : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textoVictoriaDerrota;
    [SerializeField] TextMeshProUGUI textoNumeroBatallas;
    ControlEntreEscenas control;
   
    public void SalirJuego()
    {
        Application.Quit();
        Debug.Log("Salimos del juego");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void RepetirPartida()
    {
        SceneManager.LoadScene(1);
    }

    private void Start()
    {
        Invoke(nameof(CalcularResultados), 0.3f);
    }

    void CalcularResultados()
    {
        control = FindObjectOfType<ControlEntreEscenas>();
        textoVictoriaDerrota.text = "" + control.TextoVictoria();
        textoNumeroBatallas.text = "" + control.Batallas();

    }

}
