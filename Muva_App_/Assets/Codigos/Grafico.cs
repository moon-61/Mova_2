using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text;

public class Grafico : MonoBehaviour
{
    public RectTransform graphContainer;
    public GameObject pointPrefab;
    public LineRenderer lineRenderer;
    public float spacing = 50f;

    private List<float> data = new List<float>();
    private List<GameObject> points = new List<GameObject>();

    private string _deviceUuid;

    void Start()
    {
        // Subscribirse al servicio de comunicación BLE
        ExampleBleInteractor bleInteractor = FindObjectOfType<ExampleBleInteractor>();
        if (bleInteractor != null)
        {
            _deviceUuid = bleInteractor.GetUUID();

            GerenciarComunicacao gc = GameObject.Find("Comunicacao").GetComponent<GerenciarComunicacao>();
            gc.OnReceive += OnDataReceived; // Esto debe estar implementado en GerenciarComunicacao
        }
    }

    void OnDataReceived(byte[] rawData)
    {
        string mensaje = Encoding.ASCII.GetString(rawData);
        Debug.Log("Dato recibido: " + mensaje);

        if (float.TryParse(mensaje, out float valor))
        {
            data.Add(valor);
            DrawGraph();
        }
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

        lineRenderer.positionCount = linePoints.Length;
        lineRenderer.SetPositions(linePoints);
    }

    GameObject CreatePoint(Vector2 anchoredPos)
    {
        GameObject point = Instantiate(pointPrefab, graphContainer);
        point.GetComponent<RectTransform>().anchoredPosition = anchoredPos;
        points.Add(point);
        return point;
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
