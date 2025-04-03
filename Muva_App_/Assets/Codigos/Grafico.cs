using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Grafico : MonoBehaviour
{
    public RectTransform graphContainer; // Contenedor donde se dibujará el gráfico
    public GameObject pointPrefab; // Prefab para los puntos del gráfico
    public LineRenderer lineRenderer; // LineRenderer para conectar los puntos
    public List<float> data; // Datos a mostrar en el gráfico
    public float spacing = 50f; // Espaciado entre puntos

    private List<GameObject> points = new List<GameObject>();

    void Start()
    {
        DrawGraph();
    }

    void DrawGraph()
    {
        ClearGraph();

        Vector3[] linePoints = new Vector3[data.Count];

        for (int i = 0; i < data.Count; i++)
        {
            GameObject point = CreatePoint(new Vector2(i * spacing, data[i]));
            linePoints[i] = point.GetComponent<RectTransform>().anchoredPosition;
        }

        DrawLine(linePoints);
    }

    GameObject CreatePoint(Vector2 anchoredPos)
    {
        GameObject point = Instantiate(pointPrefab, graphContainer);
        point.GetComponent<RectTransform>().anchoredPosition = anchoredPos;
        points.Add(point);
        return point;
    }

    void DrawLine(Vector3[] positions)
    {
        lineRenderer.positionCount = positions.Length;
        lineRenderer.SetPositions(positions);
    }

    void ClearGraph()
    {
        foreach (GameObject point in points)
        {
            Destroy(point);
        }
        points.Clear();

        if (lineRenderer != null)
        {
            lineRenderer.positionCount = 0;
        }
    }
}