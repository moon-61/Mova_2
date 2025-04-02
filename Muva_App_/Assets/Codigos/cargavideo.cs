using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class cargavideo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("Espera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Espera()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);

    }
    
}
