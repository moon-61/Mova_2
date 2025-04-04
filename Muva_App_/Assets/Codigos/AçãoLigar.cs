using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AçãoLigar : MonoBehaviour
{
    private bool ligadoOn = false;  // Inicializa o estado como desligado
    [SerializeField] Image botaoOFF;
    [SerializeField] Image botaoON;

    void Start()
    {
        OnOff();  // Ajusta o estado do botão ao iniciar
    }

    public void OnOff()
    {
        if (ligadoOn)
        {
            // Se estiver ligado, mostra a imagem OFF e oculta a imagem ON
            botaoON.enabled = false;
            botaoOFF.enabled = true;
        }
        else
        {
            // Se estiver desligado, mostra a imagem ON e oculta a imagem OFF
            botaoON.enabled = true;
            botaoOFF.enabled = false;
        }
    }

    // Função chamada ao clicar no botão
    public void Toggle()
    {
        ligadoOn = !ligadoOn;  // Alterna o estado de ligadoOn
        OnOff();  // Atualiza o estado do botão
    }
}
