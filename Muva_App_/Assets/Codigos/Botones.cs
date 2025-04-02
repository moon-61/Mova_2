using UnityEngine;
using UnityEngine.UI;

public class Botones : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject panel1; // Home
    public GameObject panel2; //Actividades
    public GameObject panel3; //Datos
    public GameObject panel4; //Inicio
    public GameObject panel5; //Pausa
    public void ShowPanel1()
    {
        panel1.SetActive(true);
        panel2.SetActive(false); // Oculta otros paneles si es necesario
        panel3.SetActive(false);
        panel4.SetActive(false);
        panel5.SetActive(false);
    }

    public void ShowPanel2()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
        panel3.SetActive(false);
        panel4.SetActive(false);
        panel5.SetActive(false);
    }

    public void ShowPanel3()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(true);
        panel4.SetActive(false);
        panel5.SetActive(false);
    }

    public void ShowPanel4()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
        panel4.SetActive(true);
        panel5.SetActive(false);
    }

    public void ShowPanel5()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
        panel4.SetActive(false);
        panel5.SetActive(true);
    }
}
