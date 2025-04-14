using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Android.BLE;
using Android.BLE.Commands;
using UnityEngine.SceneManagement;

public class AçãoLigar : MonoBehaviour
{
    private bool ligadoOn = false;

    [SerializeField] Sprite botaoOFF;
    [SerializeField] Sprite botaoON;

    [SerializeField] string nomeBlueTooth;
    [SerializeField] private int scanTime = 10;
    [SerializeField] Text status;

    private string deviceUuid = string.Empty;
    private string deviceName = string.Empty;
    private ConnectToDevice connectCommand;
    private bool isConnected = false;
    private float scanTimer = 0f;
    private bool isScanning = false;

    void Start()
    {
        OnOff();
    }

    void Update()
    {
        if (isScanning)
        {
            scanTimer += Time.deltaTime;
            if (scanTimer > scanTime)
            {
                scanTimer = 0f;
                isScanning = false;
            }
        }
    }

    public void OnOff()
    {
        if (ligadoOn)
        {
            gameObject.GetComponent<Image>().sprite = botaoON;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = botaoOFF;
        }
    }

    public void Toggle()
    {
        ligadoOn = !ligadoOn;
        OnOff();

        if (ligadoOn)
        {
            ScanForDevices();
        }
        else
        {
            ManualDisconnect();
        }
    }

    private void ScanForDevices()
    {
        if (!isScanning)
        {
            isScanning = true;
            BleManager.Instance.QueueCommand(new DiscoverDevices(OnDeviceFound, scanTime * 1000));
        }
    }

    private void OnDeviceFound(string name, string device)
    {
        if (device == nomeBlueTooth)
        {
            deviceUuid = name;
            deviceName = device;
            isScanning = false;
            scanTimer = 0f;
            Connect();
        }
    }

    private void Connect()
    {
        if (!isConnected)
        {
            connectCommand = new ConnectToDevice(deviceUuid, OnConnected, OnDisconnected);
            BleManager.Instance.QueueCommand(connectCommand);
        }
    }

    private void OnConnected(string uuid)
    {
        isConnected = true;

        // Suscribirse al servicio si es necesario
        GerenciarComunicacao gc = GameObject.Find("Comunicacao").GetComponent<GerenciarComunicacao>();
        gc.SubscribeServico(deviceUuid);

        if (status != null)
            status.text = "Conectado a " + nomeBlueTooth;
    }

    private void OnDisconnected(string uuid)
    {
        isConnected = false;
        deviceUuid = string.Empty;
        deviceName = string.Empty;
        scanTimer = 0f;
        isScanning = false;

        if (status != null)
            status.text = "Desconectado";
    }

    private void ManualDisconnect()
    {
        if (isConnected && connectCommand != null)
        {
            connectCommand.Disconnect();
            OnDisconnected(deviceUuid);
        }
    }
}
