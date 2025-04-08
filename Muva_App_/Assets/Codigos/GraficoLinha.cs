using UnityEngine;

public class GraficoLinha : MonoBehaviour
{
    public LineRenderer linha;

    void Start()
    {
        // Dados para o gráfico: (X, Y)
        Vector3[] pontos = new Vector3[]
        {
            new Vector3(0, 1, 0),
            new Vector3(1, 2, 0),
            new Vector3(2, 1.5f, 0),
            new Vector3(3, 3, 0)
        };

        linha.positionCount = pontos.Length;
        linha.SetPositions(pontos);

        // Personaliza a linha
        linha.widthMultiplier = 0.1f;
        linha.material = new Material(Shader.Find("Sprites/Default"));
        linha.startColor = Color.green;
        linha.endColor = Color.green;
    }
}
