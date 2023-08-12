using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorNave : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Nave;
    private int NaveActual = 3;

    [SerializeField]
    private float impulso = 0.05f;
    private float velocidadActual = 0.1f;

    [SerializeField]
    private float velocidadMaxima = 0.15f;

    [SerializeField]
    private GameObject techo; //LimiteSuperior

 
    private Quaternion originalRotation;

    private Vector3 posicionCorrecta;

    [SerializeField]
    private AudioClip audio_Estabilizador;

    AudioSource audioSource;

    void Awake()
    {
        NaveActual = PlayerPrefs.GetInt("NaveActual");

        Nave[NaveActual].SetActive(true);


        Debug.Log("NaVe Actual gameplay: " + NaveActual);
        originalRotation = Nave[NaveActual].transform.rotation; //Mantiene la rotacion original
        posicionCorrecta = Nave[NaveActual].transform.position; //Mantiene la posicion original
 
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float inputSpaces = 0;
        inputSpaces = Input.GetAxis("Jump");
        if (inputSpaces == 1 || Input.touchCount > 0)
        {
            velocidadActual += impulso;
            if (velocidadActual > velocidadMaxima)
            {
                velocidadActual = velocidadMaxima;
            }
            AddForce(); //aplica empuje
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(audio_Estabilizador, 0.1F); //Sonido de estabilizador
            } 
        }
        else
        {
            audioSource.Stop();
        }
        Estabilidad();
    }

    private void AddForce()
    {
        Nave[NaveActual]
            .GetComponent<Rigidbody>()
            .AddForce(transform.up * velocidadActual, ForceMode.Impulse);
    }

    void Estabilidad()
    {
        if (Nave[NaveActual].transform.position.y >= techo.transform.position.y)
        {
            Nave[NaveActual].transform.position = new Vector3(
                posicionCorrecta.x,
                techo.transform.position.y,
                0
            );
        }
        else
        {
            Nave[NaveActual].transform.position = new Vector3(
                posicionCorrecta.x, Nave[NaveActual].transform.position.y,
                0
            ); //Mantener posicion horizontal
        }

        Nave[NaveActual].transform.rotation = originalRotation; //mantener rotación  original
    }
}
