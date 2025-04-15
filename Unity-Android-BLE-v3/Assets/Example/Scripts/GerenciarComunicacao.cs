using Android.BLE;
using Android.BLE.Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GerenciarComunicacao : MonoBehaviour
{
    [SerializeField]
    private string _servico = "ffe0", _caracteristica = "ffe1";

    // [SerializeField]
    // Image barraTemperatura, barraUmidade;
    // [SerializeField]
    // TextMeshProUGUI textoTemperatura, textoUmidade;

    public SubscribeToCharacteristic sb;
    string _deviceUuid = string.Empty;

    // Text receiveTXT;
    // InputField sendInput;

    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        //   receiveTXT = GameObject.Find("ReceiveTXT").GetComponent<Text>();
        //   sendInput = GameObject.Find("SendINPUT").GetComponent<InputField>();

    }
    public void SubscribeServico(string _dvcUuid)
    {
        //aqui
        //ATENÇÃO, BLUETOOTH LOW ENERGY SÓ RECEBE 20 BYTES DE CADA VEZ, CONTANDO \r\n
        _deviceUuid = _dvcUuid;
        sb = new SubscribeToCharacteristic(_deviceUuid, _servico, _caracteristica, (byte[] value) =>
       {
           Receber(value);
       });
        BleManager.Instance.QueueCommand(sb);
        sb.Start();
    }
    public void Enviar(string value)
    {
        //ATENÇÃO, BLUETOOTH LOW ENERGY SÓ TRANSMITE 20 BYTES DE CADA VEZ, CONTANDO \r\n
        byte[] msg = Encoding.ASCII.GetBytes(value + '\n');
        WriteToCharacteristic w = new WriteToCharacteristic(_deviceUuid, _servico, _caracteristica, msg);
        w.Start();
    }
    private void Receber(byte[] value)
    {
        //Recebo os dados em um byte array (byte[]) que contém
        //os caracteres ASCII dos numeros, e com separador ponto-e-vígula

        string[] dados = (Encoding.ASCII.GetString(value)).Split(";");
        Recebedor(dados);
    }

    Action<String[]> Recebedor;
    public void RegistraRecebedor(Action<String[]> funcao)
    {
        Recebedor = funcao;
    }
}
