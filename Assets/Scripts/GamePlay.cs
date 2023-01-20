using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{

    [SerializeField] public Image BarraVida;

    [SerializeField] float vidaActual = 100f;
    [SerializeField] float vidaMax = 100f;
    [SerializeField] float vidaMin = 0f;

    [SerializeField] public ParticleSystem Particulas;
  
private void Awake() {
    Particulas.Stop();
}
   
    private void OnCollisionEnter(Collision other)
    {
        vidaActual = vidaActual - 25f;
        Debug.Log("Nombre: " + other);
        Particulas.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        vidaActual = vidaActual - 25f;
        Debug.Log("Nombre: " + other);
        Particulas.Play();
    }

    void Update()
    {

        BarraVida.fillAmount = vidaActual / vidaMax;
        Debug.Log("Vida: " + vidaActual / vidaMax);
        if (vidaActual <= 0)
        {
          //  SceneManager.LoadScene("SampleScene");
        }
    }
}
