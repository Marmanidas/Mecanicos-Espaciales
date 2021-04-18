using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Slider sliderProgreso;
    [SerializeField] Animator fade;
    [SerializeField] Animator paneles;
    [SerializeField] Animator nave;
    [SerializeField] Animator radar;
    [SerializeField] Animator tienda;

    [SerializeField] GameObject panelVictoriaDerrota;
    TextMeshProUGUI textoVictoriaDerrota;
    ControlEntreEscenas controlEscenas;

    bool radarEstaActivo;
    bool tiendaEstaActiva;
    bool finalJuego;
    int contadorBatallas;



    private void Start()
    {
        sliderProgreso.value = 4;
        sliderProgreso.maxValue = 15;
        controlEscenas = FindObjectOfType<ControlEntreEscenas>();
    }

    public void ResolverBatalla(int punto)
    {
        sliderProgreso.value += punto;
        contadorBatallas++;

        if (sliderProgreso.value >= sliderProgreso.maxValue)
        {
            PanelVictoriaDerrota("¡Victoria!", true, true);
        }
        else if (sliderProgreso.value <= 0)
        {
            PanelVictoriaDerrota("¡Derrota!", true, false);
        }
    }

 
    public void Fade (bool oscuroClaro )
    {
        nave.SetBool("Despegar", oscuroClaro);
        fade.SetBool("Oscuro", oscuroClaro);
 
    }

    public void ActivarDesactivarPaneles (bool activo)
    {
        paneles.SetBool("Desapanelar", activo);
        if (radarEstaActivo == true)
        {
            radarEstaActivo = false;
            radar.SetBool("ApareceRadar", false);
        }
        if (tiendaEstaActiva == true)
        {
            tiendaEstaActiva = false;
            tienda.SetBool("Tienda", false);
        }
    }

    public void activarRadar (bool activado)
    {
        radarEstaActivo = activado;
    }

    public void activaTienda (bool activada)
    {
        tiendaEstaActiva = activada;
    }

    public int NumeroDeBatallasRealizadas()
    {
        return contadorBatallas;
    }

    public void PanelVictoriaDerrota (string texto, bool AparicionFinal, bool victoriaPartida)
    {
        panelVictoriaDerrota.SetActive(true);
        textoVictoriaDerrota = panelVictoriaDerrota.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        textoVictoriaDerrota.text = "" + texto;
        if (AparicionFinal == true)
        {
            finalJuego = victoriaPartida;
            FinDelJuego();
        }
        Invoke(nameof(EliminarPanelVictoriaDerrota), 2f);


    }

    void EliminarPanelVictoriaDerrota ()
    {
        panelVictoriaDerrota.SetActive(false);
    }

    void FinDelJuego()
    {
        string batallas = NumeroDeBatallasRealizadas().ToString();
        if (finalJuego == true)
        {
            controlEscenas.RecogerDatos ("¡Ganado!", batallas);
        }
        else if (finalJuego == false)
        {
            controlEscenas.RecogerDatos("¡Perdido!", batallas);
        }
           
    }

    public void TemporalfinDelJuego (bool final)
    {
        finalJuego = final;
        FinDelJuego();
    }


    public void BotonReiniciarSalir (bool salir)
    {
        if (salir == true)
        {
            Application.Quit();
        }
        else if (salir == false)
        {
            SceneManager.LoadScene(1);
        }
    }
  


}
