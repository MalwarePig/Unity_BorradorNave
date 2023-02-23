using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorNave : MonoBehaviour
{

    [SerializeField]
    private GameObject Nave;

    [SerializeField]
    private float impulso = 0.05f;
    private float velocidadActual = 0.1f;
    [SerializeField]
    private float velocidadMaxima = 0.15f;

    [SerializeField]
    private GameObject techo;//LimiteSuperior

    [SerializeField] public ParticleSystem ParticulaEstabilizador;

    private Quaternion originalRotation;

    private Vector3 posicionCorrecta;

    [SerializeField] private AudioClip audio_Estabilizador;

    AudioSource audioSource;


    void Awake()
    {
        originalRotation = Nave.transform.rotation;//Mantiene la rotacion original
        posicionCorrecta = Nave.transform.position;//Mantiene la posicion original

        ParticulaEstabilizador.Stop();
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
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
            AddForce();//aplica empuje
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(audio_Estabilizador, 0.1F);  //Sonido de estabilizador  
            }


            ParticulaEstabilizador.Play(); //Activar particula de propulción
        }else{
             audioSource.Stop();
        }
        Estabilidad();
    }

    private void AddForce()
    {
        Nave.GetComponent<Rigidbody>().AddForce(transform.up * velocidadActual, ForceMode.Impulse);
    }

    void Estabilidad()
    {
        if (Nave.transform.position.y >= techo.transform.position.y)
        {
            Nave.transform.position = new Vector3(posicionCorrecta.x, techo.transform.position.y, 0);
        }
        else
        {
            Nave.transform.position = new Vector3(posicionCorrecta.x, Nave.transform.position.y, 0);//Mantener posicion horizontal
        }

        Nave.transform.rotation = originalRotation;//mantener rotación  original
    }


}
