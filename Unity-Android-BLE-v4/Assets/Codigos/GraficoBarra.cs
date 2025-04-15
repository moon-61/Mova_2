using UnityEngine;
using UnityEngine.UI;

public class BarChart : MonoBehaviour
{
    public RectTransform chartArea;     // Painel onde as barras serão desenhadas
    public GameObject barPrefab;        // Prefab da barra
    public float barWidth = 50f;        // Largura de cada barra
    public float barSpacing = 10f;      // Espaço entre barras
    public float maxValue = 100f;       // Valor máximo representado
    public float[] data = { 5, 12 }; // Dados de exemplo

    void Start()
    {
        CreateChart();
    }

    void CreateChart()
{
    float areaWidth = chartArea.rect.width;
    int barCount = data.Length;

    float totalSpacing = barSpacing * (barCount - 1);
    float totalBarWidth = areaWidth - totalSpacing;
    float barActualWidth = totalBarWidth / barCount;

    for (int i = 0; i < barCount; i++)
    {
        GameObject bar = Instantiate(barPrefab, chartArea);
        RectTransform rt = bar.GetComponent<RectTransform>();

        float height = (data[i] / maxValue) * chartArea.rect.height;
        rt.sizeDelta = new Vector2(barActualWidth, height);

        float x = i * (barActualWidth + barSpacing);
        rt.anchoredPosition = new Vector2(x, 0);
    }
}

}
