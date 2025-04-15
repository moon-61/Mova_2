using UnityEngine;
using UnityEngine.UI;

public class Botones : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Intro1; // Home
    public GameObject Intro2; //Actividades
    public GameObject Intro3; //Datos
    public GameObject Home; //Inicio
    public GameObject Atividades; //Pausa
    public GameObject Dados; //Datos
    public GameObject Inicio; //Inicio
    public GameObject Pausa; //Pausa




    public void ShowInicio1()
    {
        Intro1.SetActive(true);
        Intro2.SetActive(false); // Oculta otros paneles si es necesario
        Intro3.SetActive(false);
        Home.SetActive(false);
        Atividades.SetActive(false);
        Dados.SetActive(false);
        Inicio.SetActive(false);
        Pausa.SetActive(false);
    }
    public void ShowInicio2()
    {
        Intro1.SetActive(false);
        Intro2.SetActive(true); // Oculta otros paneles si es necesario
        Intro3.SetActive(false);
        Home.SetActive(false);
        Atividades.SetActive(false);
        Dados.SetActive(false);
        Inicio.SetActive(false);
        Pausa.SetActive(false);
    }
    public void ShowInicio3()
    {
        Intro1.SetActive(false);
        Intro2.SetActive(false); // Oculta otros paneles si es necesario
        Intro3.SetActive(true);
        Home.SetActive(false);
        Atividades.SetActive(false);
        Dados.SetActive(false);
        Inicio.SetActive(false);
        Pausa.SetActive(false);
    }
    public void ShowHome()
    {
        Intro1.SetActive(false);
        Intro2.SetActive(false); // Oculta otros paneles si es necesario
        Intro3.SetActive(false);
        Home.SetActive(true);
        Atividades.SetActive(false);
        Dados.SetActive(false);
        Inicio.SetActive(false);
        Pausa.SetActive(false);
    }

    public void ShowAtividades()
    {
        Intro1.SetActive(false);
        Intro2.SetActive(false); // Oculta otros paneles si es necesario
        Intro3.SetActive(false);
        Home.SetActive(false);
        Atividades.SetActive(true);
        Dados.SetActive(false);
        Inicio.SetActive(false);
        Pausa.SetActive(false);
    }

    public void ShowDados()
    {
        Intro1.SetActive(false);
        Intro2.SetActive(false); // Oculta otros paneles si es necesario
        Intro3.SetActive(false);
        Home.SetActive(false);
        Atividades.SetActive(false);
        Dados.SetActive(true);
        Inicio.SetActive(false);
        Pausa.SetActive(false);
    }

    public void ShowInicio()
    {
        Intro1.SetActive(false);
        Intro2.SetActive(false); // Oculta otros paneles si es necesario
        Intro3.SetActive(false);
        Home.SetActive(false);
        Atividades.SetActive(false);
        Dados.SetActive(false);
        Inicio.SetActive(true);
        Pausa.SetActive(false);
    }

    public void ShowPausarr()
    {
        Intro1.SetActive(false);
        Intro2.SetActive(false); // Oculta otros paneles si es necesario
        Intro3.SetActive(false);
        Home.SetActive(false);
        Atividades.SetActive(false);
        Dados.SetActive(false);
        Inicio.SetActive(false);
        Pausa.SetActive(true);
    }
}
