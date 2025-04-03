using UnityEngine;
using UnityEngine.UI;

public class TrocarNumerosparaDados : MonoBehaviour
{
    public Text numberText; // Referencia al componente de texto en UI
    private int currentNumber = 0;

    void Start()
    {
        UpdateNumber(0); // Inicializa en 0
    }

    public void UpdateNumber(int newNumber)
    {
        currentNumber = newNumber;
        numberText.text = currentNumber.ToString();
    }
}