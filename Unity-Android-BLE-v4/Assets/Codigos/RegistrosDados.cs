using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class RegistroDados : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tiempoTotalTxt;
    [SerializeField] private TextMeshProUGUI presionMaxTxt;
    [SerializeField] private TextMeshProUGUI flexionMaxTxt;
    [SerializeField] private LineRenderer graficoPresion;
    [SerializeField] private LineRenderer graficoFlexion;

    private float tiempoTotal = 0;
    private float presionMax = 0;
    private float flexionMax = 0;
    private List<Vector2> datosPresion = new List<Vector2>();
    private List<Vector2> datosFlexion = new List<Vector2>();
    private float tiempoInicio;

    void Start()
    {
        tiempoInicio = Time.time;
        ActualizarInterfaz();
    }

    public void RecibirDatos(string data)
    {
                string[] valores = data.Split(';');
        if (valores.Length < 2) return;

        float presion = float.Parse(valores[0]);
        float flexion = float.Parse(valores[1]);

        // Actualizar valores máximos
        if (presion > presionMax) presionMax = presion;
        if (flexion > flexionMax) flexionMax = flexion;

        // Guardar datos en listas
        float tiempoActual = Time.time - tiempoInicio;
        datosPresion.Add(new Vector2(tiempoActual, presion));
        datosFlexion.Add(new Vector2(tiempoActual, flexion));

        // Actualizar la interfaz
        ActualizarInterfaz();
        ActualizarGraficos();
    }

    private void ActualizarInterfaz()
    {
        tiempoTotal = Time.time - tiempoInicio;
        tiempoTotalTxt.text = tiempoTotal.ToString("F1") + " h";
        presionMaxTxt.text = presionMax.ToString("F0");
        flexionMaxTxt.text = flexionMax.ToString("F0");
    }

    private void ActualizarGraficos()
    {
        ActualizarGrafico(graficoPresion, datosPresion);
        ActualizarGrafico(graficoFlexion, datosFlexion);
    }

    private void ActualizarGrafico(LineRenderer grafico, List<Vector2> datos)
    {
        grafico.positionCount = datos.Count;
        for (int i = 0; i < datos.Count; i++)
        {
            grafico.SetPosition(i, new Vector3(datos[i].x, datos[i].y, 0));
        }
    }
}
