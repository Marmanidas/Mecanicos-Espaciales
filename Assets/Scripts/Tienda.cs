using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tienda : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Image imagenObjeto;
    [SerializeField] List<PlantillaEquipo> listaObjetosEquipo;

    [SerializeField] PlantillaEquipo plantilla;

    [SerializeField] GameObject panelDescripcion;
    [SerializeField] Image imagenObjetoTienda;
    [SerializeField] TextMeshProUGUI textonombreObjeto;
    [SerializeField] TextMeshProUGUI textoDescripcionObjeto;

    [SerializeField] Image imagenEquipoNave;

    [SerializeField] ControlNave controlNave;
    [SerializeField] Radar radar;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void AparicionPanel()
    {
        //int frecuencia = gameManager.NumeroDeBatallasRealizadas();
        float frecuencia = Random.value;
        if (frecuencia > 0.5f)
        {
            AparecePanel();
        }
        else
        {
            Debug.Log("no hay tienda");
        }
    }

    public void AparecePanel()
    {
        int equipoAleatorio = Random.Range(0, listaObjetosEquipo.Count);
        plantilla = listaObjetosEquipo[equipoAleatorio];

        imagenObjeto.sprite = plantilla.imagenEquipo;
        imagenObjeto.SetNativeSize();

        gameManager.activaTienda(true);
        anim.SetBool("Tienda", true);

    }

    public void BotonVerStatsDelobjeto()
    {
        panelDescripcion.SetActive(true);
        imagenObjetoTienda.sprite = plantilla.imagenEquipo;
        imagenObjetoTienda.SetNativeSize();
        textonombreObjeto.text = "" + plantilla.nombreEquipo;
        textoDescripcionObjeto.text = "" + plantilla.descripcion;

        anim.SetBool("Tienda", false);

    }

    public void BotonNoEquipar()
    {
        panelDescripcion.SetActive(false);
    }

    public void BotonEquipar()
    {
        panelDescripcion.SetActive(false);
        imagenEquipoNave.sprite = plantilla.imagenEquipo;
        imagenEquipoNave.SetNativeSize();

        switch (plantilla.tipoBono){

            case "casco":
            case "lasers":
            case "maniobra":
            case "torpedos":
            case "motores":
            case "creditos":
                controlNave.GestorBonosEquipo(plantilla.tipoBono, plantilla.sumaBono);
                break;
            case "avanza":
                gameManager.ResolverBatalla(plantilla.sumaBono);
                break;
            case "radar":
                radar.DatosRadar();
                break;
        }

        
    }
}
