using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AçãoLigar : MonoBehaviour
{
    private bool ligadoOn = false;  // Inicializa o estado como desligado
    [SerializeField] Sprite botaoOFF;
    [SerializeField] Sprite botaoON;

    void Start()
    {
         // Ajusta o estado do botão ao iniciar
    }

    public void OnOff()
    {
        if (ligadoOn)
        {
            // Se estiver ligado, mostra a imagem OFF e oculta a imagem ON
            gameObject.GetComponent<Image>().sprite = botaoOFF;
            
        }
        else
        {
            // Se estiver desligado, mostra a imagem ON e oculta a imagem OFF
            gameObject.GetComponent<Image>().sprite = botaoON;
        }
    }

    // Função chamada ao clicar no botão
    public void Toggle()
    {
        ligadoOn = !ligadoOn;  // Alterna o estado de ligadoOn
        OnOff();  // Atualiza o estado do botão
    }
}
