using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Grafico : MonoBehaviour
{
    public RectTransform graphContainer; // Contenedor donde se dibujar� el gr�fico
    public GameObject pointPrefab; // Prefab para los puntos del gr�fico
    public List<float> data; // Datos a mostrar en el gr�fico
    public float spacing = 50f; // Espaciado entre puntos

    private List<GameObject> points = new List<GameObject>();

    void Start()
    {
        DrawGraph();
    }

    void DrawGraph()
    {
        ClearGraph();

        for (int i = 0; i < data.Count; i++)
        {
            CreatePoint(new Vector2(i * spacing, data[i]));
        }
    }

    void CreatePoint(Vector2 anchoredPos)
    {
        GameObject point = Instantiate(pointPrefab, graphContainer);
        point.GetComponent<RectTransform>().anchoredPosition = anchoredPos;
        points.Add(point);
    }

    void ClearGraph()
    {
        foreach (GameObject point in points)
        {
            Destroy(point);
        }
        points.Clear();
    }
}