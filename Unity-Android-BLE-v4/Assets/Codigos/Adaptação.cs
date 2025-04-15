using UnityEngine;
using UnityEngine.UI;



[RequireComponent(typeof(Canvas))]
public class Adaptação : MonoBehaviour
{
    private Canvas canvas;
    private CanvasScaler canvasScaler;



    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvasScaler = canvas.GetComponent<CanvasScaler>();

        if (canvasScaler != null)
        {
            AjustarCanvas();
        }
        else
        {
            Debug.LogWarning("El Canvas no tiene un CanvasScaler. Agregándolo automáticamente...");
            canvasScaler = canvas.gameObject.AddComponent<CanvasScaler>();
            AjustarCanvas();
        }
    }



    void AjustarCanvas()
    {
        // Configurar el modo de escala
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;

        // Usar la resolución base como referencia
        canvasScaler.referenceResolution = new Vector2(1080, 1920);

        // Ajustar por el aspecto de la pantalla
        float aspectRatio = (float)Screen.width / Screen.height;
        if (aspectRatio > 0.6f) // Teléfonos más anchos (ejemplo 16:9 o más)
        {
            canvasScaler.matchWidthOrHeight = 1f; // Prioriza altura
        }
        else // Teléfonos más cuadrados
        {
            canvasScaler.matchWidthOrHeight = 0f; // Prioriza ancho
        }
    }
}


