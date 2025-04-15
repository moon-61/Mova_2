using System;
using TMPro;
using UnityEngine;

public class ControlesCenaMova : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI pressao, movimento, alerta;

    Action<String> Enviador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject gm = GameObject.Find("Comunicacao");
        GerenciarComunicacao gc=gm.GetComponent<GerenciarComunicacao>();
        gc.RegistraRecebedor(Receber);
        Enviador = gc.Enviar;//Os dados são enviados pelo script que está na primeira cena
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Receber(string[] dados)
    {
       pressao.text = dados[0];
       movimento.text = dados[1];
       float p=float.Parse(dados[0]);
       float m=float.Parse(dados[1]);


    }
    public void Enviar(string dados)
    {
        Enviador(dados);
    }    
}
