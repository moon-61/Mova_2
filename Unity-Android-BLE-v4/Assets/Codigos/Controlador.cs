using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Controlador: MonoBehaviour
{
    public GameObject about;
    public GameObject confi;
    public GameObject noti;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void ClickEnBotonPulsar()
    {
        Debug.Log("Se ha pulsado el botón.");
        //logo.SetActive(false);
    }
    public void Mostrarabout()
    {
        about.SetActive(true);
    }
    public void Ocultarabout()
    {
        about.SetActive(false);
    }

    public void Mostrarconfi()
    {
        confi.SetActive(true);
    }
    public void Ocultarconfi()
    {
        confi.SetActive(false);
    }

    public void Mostrarnoti()
    {
        noti.SetActive(true);
    }
    public void Ocultarnoti()
    {
        noti.SetActive(false);
    }
}