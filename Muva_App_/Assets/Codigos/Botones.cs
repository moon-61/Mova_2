using UnityEngine;
using UnityEngine.UI;

public class Botones : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject panel1; // El panel al que quieres redirigir
    public GameObject panel2; // Otro panel, si es necesario

    public void ShowPanel1()
    {
        panel1.SetActive(true);
        panel2.SetActive(false); // Oculta otros paneles si es necesario
    }

    public void ShowPanel2()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }
}
