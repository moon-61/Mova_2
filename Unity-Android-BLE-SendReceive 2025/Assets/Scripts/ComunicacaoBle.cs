using UnityEngine;
using TMPro;
public class ComunicacaoBle : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI exibir;
    
    GameObject comunicacao;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        comunicacao = GameObject.Find("Comunicacao");
        comunicacao.SendMessage("DefinirObjetoRecebedor", gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Recebe(string dados)
    {
        exibir.text = dados;
    }
}
